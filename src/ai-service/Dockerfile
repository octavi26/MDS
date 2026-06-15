FROM python:3.12-slim

ENV PYTHONDONTWRITEBYTECODE=1 \
    PYTHONUNBUFFERED=1 \
    PATH="/opt/piper:${PATH}" \
    PIPER_BIN=/opt/piper/piper \
    PIPER_MODEL=/app/voices/en_GB-alan-medium.onnx \
    TTS_MEDIA_DIR=/app/media

WORKDIR /app

# ffmpeg powers the "orc boss" voice effect; curl fetches piper + the voice model.
RUN apt-get update \
    && apt-get install -y --no-install-recommends ffmpeg curl ca-certificates \
    && rm -rf /var/lib/apt/lists/*

# Install the Piper TTS binary for the target architecture (amd64 / arm64).
ARG TARGETARCH
RUN set -eux; \
    case "${TARGETARCH:-amd64}" in \
        amd64) PIPER_ARCH=x86_64 ;; \
        arm64) PIPER_ARCH=aarch64 ;; \
        *) PIPER_ARCH=x86_64 ;; \
    esac; \
    curl -fsSL "https://github.com/rhasspy/piper/releases/download/2023.11.14-2/piper_linux_${PIPER_ARCH}.tar.gz" -o /tmp/piper.tar.gz; \
    tar -xzf /tmp/piper.tar.gz -C /opt; \
    rm /tmp/piper.tar.gz; \
    /opt/piper/piper --help >/dev/null 2>&1 || true

# Bake in a deep British male voice (becomes the orc after the ffmpeg effect).
RUN mkdir -p /app/voices; \
    BASE="https://huggingface.co/rhasspy/piper-voices/resolve/main/en/en_GB/alan/medium"; \
    curl -fsSL "${BASE}/en_GB-alan-medium.onnx" -o /app/voices/en_GB-alan-medium.onnx; \
    curl -fsSL "${BASE}/en_GB-alan-medium.onnx.json" -o /app/voices/en_GB-alan-medium.onnx.json

COPY pyproject.toml ./
RUN pip install --no-cache-dir -e ".[test]"

COPY app ./app
COPY tests ./tests

RUN mkdir -p /app/media

EXPOSE 8001
CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "8001"]
