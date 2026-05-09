import re

from app.crafting.models import CraftRequest, CraftResponse
from app.crafting.ollama import OllamaCombinationGenerator
from app.crafting.recipes import find_recipe, normalize_element_name
from app.crafting.semantics import (
    find_concept_recipe,
    result_reuses_input_concept,
    semantic_fallback_result,
)
from app.crafting.settings import CraftingSettings


class CraftingEngine:
    def __init__(
        self,
        settings: CraftingSettings | None = None,
        generator: OllamaCombinationGenerator | None = None,
    ) -> None:
        self._settings = settings or CraftingSettings.from_env()
        self._generator = generator or OllamaCombinationGenerator(self._settings)

    async def craft(self, request: CraftRequest) -> CraftResponse:
        recipe = find_recipe(request.element_a, request.element_b)
        if recipe is not None:
            return CraftResponse(
                result=recipe.result,
                source="deterministic-recipe",
                deterministic=True,
                useful_steps=recipe.useful_steps,
                difficulty=recipe.difficulty,
            )

        concept_result = find_concept_recipe(request.element_a, request.element_b)
        if concept_result is not None:
            return CraftResponse(
                result=concept_result,
                source="concept-recipe",
                deterministic=True,
                useful_steps=None,
                difficulty=request.level_difficulty,
            )

        if self._settings.generation_enabled:
            generated = await self._generator.generate(request)
            valid = validate_result(generated, request)
            if valid is not None:
                return CraftResponse(
                    result=valid,
                    source="ollama",
                    deterministic=False,
                    useful_steps=None,
                    difficulty=request.level_difficulty,
                )

        return CraftResponse(
            result=fallback_result(request.element_a, request.element_b),
            source="deterministic-fallback",
            deterministic=True,
            useful_steps=None,
            difficulty=request.level_difficulty,
        )


def validate_result(result: str | None, request: CraftRequest) -> str | None:
    if result is None:
        return None

    cleaned = _clean_result(result)
    if cleaned is None:
        return None

    lowered = cleaned.casefold()
    inputs = {
        normalize_element_name(request.element_a).casefold(),
        normalize_element_name(request.element_b).casefold(),
    }

    if lowered in inputs:
        return None
    if result_reuses_input_concept(cleaned, request.element_a, request.element_b):
        return None

    banned_fragments = (
        "unknown",
        "nothing",
        "none",
        "error",
        "cannot",
        "can't",
        "no result",
        "same",
    )
    if any(fragment in lowered for fragment in banned_fragments):
        return None

    return cleaned


def fallback_result(element_a: str, element_b: str) -> str:
    return semantic_fallback_result(element_a, element_b)


def _clean_result(result: str) -> str | None:
    first_line = result.strip().splitlines()[0].strip()
    first_line = first_line.strip("\"'`.,:;!? ")
    first_line = re.sub(r"^(result|answer)\s*[:\-]\s*", "", first_line, flags=re.IGNORECASE)
    first_line = " ".join(first_line.split())

    if not 2 <= len(first_line) <= 40:
        return None
    if not re.fullmatch(r"[A-Za-z][A-Za-z '\-]*", first_line):
        return None

    return first_line.title()
