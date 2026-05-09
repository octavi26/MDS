import httpx
from fastapi.testclient import TestClient

from app.crafting.engine import CraftingEngine, fallback_result
from app.crafting.models import CraftRequest
from app.crafting.ollama import OllamaCombinationGenerator
from app.crafting.settings import CraftingSettings
from app.main import app, get_crafting_engine


def test_craft_returns_deterministic_recipe() -> None:
    client = TestClient(app)

    response = client.post("/craft", json={"element_a": "Fire", "element_b": "Water"})

    assert response.status_code == 200
    payload = response.json()
    assert payload["result"] == "Steam"
    assert payload["source"] == "deterministic-recipe"
    assert payload["deterministic"] is True
    assert payload["useful_steps"] == 1
    assert payload["difficulty"] == 1


def test_craft_recipe_lookup_is_order_independent() -> None:
    client = TestClient(app)

    response = client.post("/craft", json={"element_a": "Water", "element_b": "Air"})

    assert response.status_code == 200
    assert response.json()["result"] == "Rain"


def test_unknown_combination_uses_ollama_when_valid() -> None:
    async def handler(request: httpx.Request) -> httpx.Response:
        assert request.url.path == "/api/generate"
        return httpx.Response(200, json={"response": "Spark Crystal\n"})

    async def run() -> None:
        transport = httpx.MockTransport(handler)
        async with httpx.AsyncClient(transport=transport, base_url="http://ollama.test") as client:
            settings = CraftingSettings(timeout_seconds=1)
            generator = OllamaCombinationGenerator(settings, client)
            engine = CraftingEngine(settings, generator)

            response = await engine.craft(CraftRequest(element_a="Fire", element_b="Dust"))

        assert response.result == "Spark Crystal"
        assert response.source == "ollama"
        assert response.deterministic is False

    import anyio

    anyio.run(run)


def test_invalid_ollama_response_falls_back_stably() -> None:
    async def handler(_: httpx.Request) -> httpx.Response:
        return httpx.Response(200, json={"response": "Fire"})

    async def run() -> None:
        transport = httpx.MockTransport(handler)
        async with httpx.AsyncClient(transport=transport, base_url="http://ollama.test") as client:
            settings = CraftingSettings(timeout_seconds=1)
            generator = OllamaCombinationGenerator(settings, client)
            engine = CraftingEngine(settings, generator)

            request = CraftRequest(element_a="Fire", element_b="Dust", level_difficulty=3)
            first = await engine.craft(request)
            second = await engine.craft(request)

        assert first.result == second.result
        assert first.result == fallback_result("Fire", "Dust")
        assert first.source == "deterministic-fallback"
        assert first.deterministic is True
        assert first.difficulty == 3

    import anyio

    anyio.run(run)


def test_ollama_network_error_falls_back() -> None:
    async def handler(_: httpx.Request) -> httpx.Response:
        raise httpx.ConnectError("offline")

    async def run() -> None:
        transport = httpx.MockTransport(handler)
        async with httpx.AsyncClient(transport=transport, base_url="http://ollama.test") as client:
            settings = CraftingSettings(timeout_seconds=1)
            generator = OllamaCombinationGenerator(settings, client)
            engine = CraftingEngine(settings, generator)

            response = await engine.craft(CraftRequest(element_a="Stone", element_b="Rain"))

        assert response.result == fallback_result("Stone", "Rain")
        assert response.source == "deterministic-fallback"

    import anyio

    anyio.run(run)


def test_generation_can_be_disabled_for_deterministic_fallback() -> None:
    class DisabledGenerator:
        async def generate(self, _: CraftRequest) -> str | None:
            raise AssertionError("generator should not be called")

    engine = CraftingEngine(
        CraftingSettings(generation_enabled=False),
        DisabledGenerator(),  # type: ignore[arg-type]
    )

    async def run() -> None:
        response = await engine.craft(CraftRequest(element_a="Light", element_b="Mud"))
        assert response.source == "deterministic-fallback"

    import anyio

    anyio.run(run)


def test_fastapi_dependency_can_override_engine() -> None:
    class StaticEngine:
        async def craft(self, request: CraftRequest):
            return {
                "result": f"{request.element_a} Test",
                "source": "test",
                "deterministic": True,
                "useful_steps": None,
                "difficulty": request.level_difficulty,
            }

    app.dependency_overrides[get_crafting_engine] = lambda: StaticEngine()
    try:
        client = TestClient(app)
        response = client.post(
            "/craft",
            json={"element_a": "A", "element_b": "B", "level_difficulty": 4},
        )
    finally:
        app.dependency_overrides.clear()

    assert response.status_code == 200
    assert response.json()["result"] == "A Test"
