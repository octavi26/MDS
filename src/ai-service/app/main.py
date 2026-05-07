from fastapi import FastAPI

app = FastAPI(title="Craft Game AI Service", version="0.1.0")


@app.get("/health")
async def health() -> dict[str, str]:
    return {"status": "ok", "service": "craft-game-ai"}


@app.get("/ready")
async def ready() -> dict[str, str]:
    return {"status": "ready"}
