# MDS

This repository contains the full local craft game stack: React frontend,
ASP.NET Core backend, FastAPI AI/TTS service, PostgreSQL, and Ollama.

## Start Everything

Requirements:

- Docker Desktop
- Git

From the repo root, start the whole project with one command:

```sh
docker compose up --build
```

Windows users can also run:

```bat
dev.cmd
```

macOS/Linux users can also run:

```sh
./scripts/dev.sh
```

This works everywhere, but the companion's language model runs on the **CPU**,
which is slow on a laptop (~25-30s per spoken line). If you have a GPU, use one
of the accelerated modes below for ~1-2s lines.

### Run modes (LLM acceleration)

The crafting AI and the companion both use Ollama. Pick the mode that matches
your machine:

| Your machine | Command | Speed |
| --- | --- | --- |
| **Any (default)** | `docker compose up --build` | CPU, slow but zero-setup |
| **NVIDIA GPU** (e.g. RTX 3060) | `docker compose -f docker-compose.yml -f docker-compose.gpu.yml up --build` | CUDA, fast |
| **Apple Silicon Mac** | see below | Metal, fast |

**NVIDIA GPU** also needs the [NVIDIA Container Toolkit](https://docs.nvidia.com/datacenter/cloud-native/container-toolkit/latest/install-guide.html);
Ollama then auto-detects the card.

**Apple Silicon Mac** — Docker can't reach the Mac GPU, so run Ollama natively
(Metal) on the host and let the Docker stack talk to it:

```sh
brew install ollama                    # once
brew services start ollama             # runs Ollama in the background (Metal)
ollama pull qwen2.5:3b-instruct
ollama pull qwen2.5:0.5b-instruct
docker compose -f docker-compose.yml -f docker-compose.mac.yml up --build
```

Open:

- Frontend placeholder: http://localhost:5173
- Backend Swagger: http://localhost:5088/swagger
- Backend health: http://localhost:5088/health
- Backend readiness: http://localhost:5088/ready
- AI service health: http://localhost:8001/health

### Companion voice (orc boss)

The talking companion speaks context-aware, sarcastic lines in an "orc boss"
voice. Everything runs locally inside Docker — **no manual setup on any OS**:

- **Voice (TTS):** Piper + ffmpeg, baked into the `ai-service` image. Works the
  same on macOS, Windows and Linux (the image is Linux; the Piper binary is
  selected per architecture at build time).
- **Lines (LLM):** a dockerized `ollama` service. On the **first**
  `docker compose up`, it downloads the `qwen2.5:3b-instruct` model (~2 GB,
  cached in the `ollama-data` volume), so the first start takes a few extra
  minutes. Until the model is ready, the companion uses built-in fallback lines.

Two models are used, both served by Ollama: `qwen2.5:3b-instruct` for the
companion's lines (it needs the wit) and the small, fast `qwen2.5:0.5b-instruct`
for inventing new crafting combinations (it needs the speed).

Both pieces degrade gracefully: if TTS or the LLM is unavailable the game still
works (text-only / deterministic lines). LLM generation is CPU-bound by default
and therefore slow on a laptop — see [Run modes](#run-modes-llm-acceleration)
above to use an NVIDIA or Apple-Silicon GPU for ~1-2s lines instead of ~25-30s.

## What Is Prepared

- `src/frontend`: React + Vite + TypeScript + Tailwind game frontend
- `src/backend/CraftGame.Api`: ASP.NET Core Web API with PostgreSQL persistence
- `src/ai-service`: FastAPI crafting, hint, and TTS service
- `db`: PostgreSQL service in Docker Compose
- `ollama`: local LLM service for crafting and companion lines
- `SignalR`: backend game hub
- `Swagger`: backend API docs
- `GitHub Actions`: CI for backend, frontend, and AI service
- Cross-platform helper scripts in `scripts/`

## Test Commands

```sh
dotnet test MDS.sln
npm --prefix src/frontend test
npm --prefix src/frontend run build
python -m pytest src/ai-service/tests
```

Or use:

- macOS/Linux: `./scripts/test.sh`
- Windows PowerShell: `scripts/test.ps1`

## 👥 Contributors

- **Project Team** - Initial scaffold and architecture

---

## Local Development

Backend:

```sh
dotnet run --project src/backend/CraftGame.Api
```

Frontend:

```sh
npm --prefix src/frontend install
npm --prefix src/frontend run dev
```

AI service:

```sh
cd src/ai-service
python -m venv .venv
. .venv/bin/activate
pip install -e ".[test]"
uvicorn app.main:app --host 0.0.0.0 --port 8001
```
