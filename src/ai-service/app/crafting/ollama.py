import httpx

from app.crafting.models import CraftRequest
from app.crafting.settings import CraftingSettings


class OllamaCombinationGenerator:
    def __init__(
        self,
        settings: CraftingSettings,
        client: httpx.AsyncClient | None = None,
    ) -> None:
        self._settings = settings
        self._client = client

    async def generate(self, request: CraftRequest) -> str | None:
        if self._settings.provider.casefold() != "ollama":
            return None

        prompt = _build_prompt(request)
        payload = {
            "model": self._settings.ollama_model,
            "prompt": prompt,
            "stream": False,
            "options": {
                "temperature": 0.35,
                "top_p": 0.8,
                "num_predict": 12,
            },
        }

        try:
            if self._client is not None:
                response = await self._client.post("/api/generate", json=payload)
            else:
                async with httpx.AsyncClient(
                    base_url=self._settings.ollama_base_url,
                    timeout=self._settings.timeout_seconds,
                ) as client:
                    response = await client.post("/api/generate", json=payload)

            response.raise_for_status()
            data = response.json()
        except (httpx.HTTPError, ValueError):
            return None

        result = data.get("response")
        if not isinstance(result, str):
            return None

        return result


def _build_prompt(request: CraftRequest) -> str:
    # Note on goal-direction: we deliberately do NOT feed the level goal to the
    # model here. The crafting model is small and fast (so the game stays snappy),
    # and a small model just parrots the goal into every answer ("Engine of
    # Steel", "Engine of Nature") instead of judging when it's relevant. The real
    # path toward the goal is handled deterministically by the recipe/concept
    # tables, and the companion actively hints the next productive step. This
    # prompt's only job is a believable name for an off-path, creative combo.
    context = [
        "You create element names for a crafting puzzle game.",
        "Return exactly one short result name (one or two words), no explanation.",
        "The result must be a single real, concrete thing that two people would"
        " agree is what you get by combining the inputs.",
        "Do not return either input element unchanged.",
        "Do not concatenate or mash together the input names.",
        "Prefer a new concept implied by the relationship between the inputs.",
        "Use title case when possible.",
        f"Combine: {request.element_a} + {request.element_b}.",
    ]

    if request.inventory:
        context.append(f"Things the player already has: {', '.join(request.inventory[:12])}.")

    return "\n".join(context)
