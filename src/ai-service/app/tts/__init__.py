"""Text-to-speech for the companion voice (Piper + ffmpeg "orc boss" effect)."""

from app.tts.engine import MEDIA_DIR, synthesize_to_media

__all__ = ["MEDIA_DIR", "synthesize_to_media"]
