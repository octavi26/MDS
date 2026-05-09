from fastapi import Depends, FastAPI

from app.crafting.engine import CraftingEngine
from app.crafting.models import CraftRequest, CraftResponse

app = FastAPI(title="Craft Game AI Service", version="0.1.0")


def get_crafting_engine() -> CraftingEngine:
    return CraftingEngine()


@app.get("/health")
async def health() -> dict[str, str]:
    return {"status": "ok", "service": "craft-game-ai"}


@app.get("/ready")
async def ready() -> dict[str, str]:
    return {"status": "ready"}


@app.post("/craft", response_model=CraftResponse)
async def craft(
    request: CraftRequest,
    engine: CraftingEngine = Depends(get_crafting_engine),
) -> CraftResponse:
    return await engine.craft(request)
