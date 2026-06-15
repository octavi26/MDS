"""Turns a companion line into a spoken "sarcastic orc boss" voice clip.

Pipeline: Piper (fast, local, CPU-only neural TTS) renders a deep male voice to
WAV, then ffmpeg applies a pitch/formant drop + grit + cave reverb so it sounds
like a monstrous boss rather than a polite assistant. Everything runs inside the
Dockerized ai-service, so it behaves identically on macOS, Windows, and Linux.

Results are cached on disk keyed by the text (+ voice + effect version), so a
line is only ever synthesized once.
"""

from __future__ import annotations

import hashlib
import os
import pathlib
import subprocess
import tempfile

# Where rendered clips live. In Docker this points at the mounted ai-media volume
# (TTS_MEDIA_DIR=/app/media); locally it falls back to a temp dir so importing
# this module never fails (e.g. when running the test suite on a dev machine).
MEDIA_DIR = pathlib.Path(
    os.environ.get("TTS_MEDIA_DIR")
    or os.path.join(tempfile.gettempdir(), "craftgame-tts-media")
)

# Baked into the image by the Dockerfile.
PIPER_BIN = os.environ.get("PIPER_BIN", "piper")
PIPER_MODEL = os.environ.get("PIPER_MODEL", "/app/voices/en_GB-alan-medium.onnx")

# >1.0 slows the delivery slightly for a more menacing, deliberate cadence.
PIPER_LENGTH_SCALE = os.environ.get("PIPER_LENGTH_SCALE", "1.15")

# Bump this string whenever the effect chain changes so cached clips regenerate.
FX_VERSION = "orc-v1"

# The "orc boss" effect:
#   asetrate*0.80  -> drop pitch AND formants ~20% (makes the speaker sound huge)
#   atempo=1.25    -> undo the slowdown that asetrate caused (keeps natural length)
#   aecho          -> short reverb tail, like a voice in a cavern
#   acrusher       -> mild bit-grit for a guttural, non-human rasp
ORC_FILTER = (
    "asetrate=22050*0.80,aresample=44100,atempo=1.25,"
    "aecho=0.8:0.85:55:0.35,"
    "acrusher=level_in=1:level_out=1:bits=12:mode=log:aa=1"
)

_TIMEOUT_SECONDS = 60


def _cache_key(text: str) -> str:
    raw = f"{FX_VERSION}|{PIPER_MODEL}|{PIPER_LENGTH_SCALE}|{text}"
    return hashlib.sha256(raw.encode("utf-8")).hexdigest()[:32]


def synthesize_to_media(text: str) -> str:
    """Render ``text`` to a cached WAV and return its public path (``/media/...``).

    Raises subprocess.CalledProcessError if piper/ffmpeg fail so the API layer can
    surface a 500; the backend treats any failure as "no voice line" and the game
    keeps working.
    """
    cleaned = (text or "").strip()
    if not cleaned:
        raise ValueError("text must not be empty")

    MEDIA_DIR.mkdir(parents=True, exist_ok=True)

    key = _cache_key(cleaned)
    out_path = MEDIA_DIR / f"{key}.wav"
    public_path = f"/media/{key}.wav"

    if out_path.exists():
        return public_path

    # The ffmpeg output must land on the SAME filesystem as the cache dir so the
    # final rename is atomic (os.replace can't cross devices, and the media dir is
    # a mounted volume separate from /tmp).
    fx_tmp = MEDIA_DIR / f".{key}.{os.getpid()}.tmp.wav"

    with tempfile.TemporaryDirectory() as tmp:
        raw_path = os.path.join(tmp, "raw.wav")

        subprocess.run(
            [
                PIPER_BIN,
                "--model",
                PIPER_MODEL,
                "--length_scale",
                PIPER_LENGTH_SCALE,
                "--output_file",
                raw_path,
            ],
            input=cleaned.encode("utf-8"),
            check=True,
            capture_output=True,
            timeout=_TIMEOUT_SECONDS,
        )

        try:
            subprocess.run(
                ["ffmpeg", "-y", "-i", raw_path, "-af", ORC_FILTER, str(fx_tmp)],
                check=True,
                capture_output=True,
                timeout=_TIMEOUT_SECONDS,
            )
            os.replace(fx_tmp, out_path)
        finally:
            fx_tmp.unlink(missing_ok=True)

    return public_path
