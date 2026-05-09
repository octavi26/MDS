from dataclasses import dataclass
import os


@dataclass(frozen=True)
class CraftingSettings:
    provider: str = "ollama"
    ollama_base_url: str = "http://localhost:11434"
    ollama_model: str = "qwen2.5:0.5b-instruct"
    timeout_seconds: float = 5.0
    generation_enabled: bool = True

    @classmethod
    def from_env(cls) -> "CraftingSettings":
        return cls(
            provider=os.getenv("CRAFT_AI_PROVIDER", "ollama"),
            ollama_base_url=os.getenv("OLLAMA_BASE_URL", "http://localhost:11434"),
            ollama_model=os.getenv("OLLAMA_MODEL", "qwen2.5:0.5b-instruct"),
            timeout_seconds=_float_env("CRAFT_AI_TIMEOUT_SECONDS", 5.0),
            generation_enabled=_bool_env("CRAFT_AI_GENERATION_ENABLED", True),
        )


def _float_env(name: str, default: float) -> float:
    raw = os.getenv(name)
    if raw is None:
        return default

    try:
        return max(0.1, float(raw))
    except ValueError:
        return default


def _bool_env(name: str, default: bool) -> bool:
    raw = os.getenv(name)
    if raw is None:
        return default

    return raw.strip().casefold() in {"1", "true", "yes", "on"}
