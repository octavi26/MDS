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
    context = [
        "You create element names for a crafting puzzle game.",
        "Return exactly one short result name, with no explanation.",
        "The result must be helpful, concrete, and plausible.",
        "Do not return either input element unchanged.",
        "Use title case when possible.",
        f"Combine: {request.element_a} + {request.element_b}.",
    ]

    if request.level_name:
        context.append(f"Level: {request.level_name}.")
    if request.level_difficulty is not None:
        context.append(f"Difficulty: {request.level_difficulty}.")
    if request.goal_element:
        context.append(f"Goal: {request.goal_element}.")
    if request.inventory:
        context.append(f"Current inventory: {', '.join(request.inventory[:12])}.")

    return "\n".join(context)
