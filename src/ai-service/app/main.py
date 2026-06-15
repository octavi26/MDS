from fastapi import Depends, FastAPI, HTTPException
from fastapi.concurrency import run_in_threadpool
from fastapi.middleware.cors import CORSMiddleware
from fastapi.staticfiles import StaticFiles

from app.crafting.engine import CraftingEngine
from app.crafting.hints import suggest_hint
from app.crafting.models import CraftRequest, CraftResponse, HintRequest, HintResponse
from app.tts import MEDIA_DIR, synthesize_to_media
from app.tts.models import TtsRequest, TtsResponse

app = FastAPI(title="Craft Game AI Service", version="0.1.0")

# The browser fetches voice clips directly from this service, so allow it.
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_methods=["*"],
    allow_headers=["*"],
)

# Serve rendered voice clips at /media/<hash>.wav.
MEDIA_DIR.mkdir(parents=True, exist_ok=True)
app.mount("/media", StaticFiles(directory=str(MEDIA_DIR)), name="media")


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


@app.post("/hint", response_model=HintResponse)
async def hint(request: HintRequest) -> HintResponse:
    """Suggest the next productive combination toward the goal, if there is one."""
    suggestion = suggest_hint(request.inventory, request.goal)
    if suggestion is None:
        return HintResponse(found=False)

    element_a, element_b, result = suggestion
    return HintResponse(found=True, element_a=element_a, element_b=element_b, result=result)


@app.post("/tts", response_model=TtsResponse)
async def tts(request: TtsRequest) -> TtsResponse:
    """Render a companion line to the sarcastic orc-boss voice and return its URL."""
    text = request.text.strip()
    if not text:
        raise HTTPException(status_code=400, detail="text must not be empty")

    try:
        # Piper/ffmpeg are blocking subprocesses; keep the event loop free.
        public_path = await run_in_threadpool(synthesize_to_media, text)
    except Exception as exc:  # noqa: BLE001 - surface as 500, backend degrades gracefully
        raise HTTPException(status_code=500, detail="voice synthesis failed") from exc

    return TtsResponse(url=public_path)
