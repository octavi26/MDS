# MDS

This repository contains the full local craft game stack: React frontend,
ASP.NET Core backend, FastAPI AI/TTS service, PostgreSQL, and Ollama.

[SPEEDRUN DEMO](https://youtu.be/YmHGVLkeNgQ)



[RAPORT AGENTI](MDS_Mocking_Forge_Academic_Report.pdf)

## Start Everything

Requirements:

- Docker Desktop
- Git
- Ollama is installed automatically by the helper script on Windows when
  `winget` is available, and on macOS when Homebrew is available.

From the repo root, Windows users run:

```bat
dev.cmd
```

For startup debugging on Windows, run:

```bat
dev.cmd debug
```

That starts the Docker stack in the background, opens
`http://localhost:5173/?debug=1`, and follows Docker logs in the terminal. The
debug overlay on the page shows frontend startup steps, API URLs, HTTP statuses,
and request failures. Use `http://localhost:5173/?debug=0` to turn the overlay
off in that browser.

macOS/Linux users can also run:

```sh
./scripts/dev.sh
```

These helpers start native Ollama on the host, pull the required models, warm
them once, and then start the Docker stack. That is the default because native
Ollama can use Metal on macOS and the available GPU acceleration on Windows,
while Dockerized Ollama often falls back to CPU.

### Run modes (LLM acceleration)

The crafting AI and the companion both use Ollama. Pick the mode that matches
your machine:

| Your machine | Command | Speed |
| --- | --- | --- |
| **Windows (default)** | `dev.cmd` | Native Ollama, GPU-capable |
| **Windows debug** | `dev.cmd debug` | Native Ollama + on-screen startup diagnostics |
| **macOS (default)** | `./scripts/dev.sh` | Native Ollama, Metal-capable |
| **macOS debug** | `./scripts/dev.sh debug` | Native Ollama + on-screen startup diagnostics |
| **Docker Ollama fallback** | `dev.cmd container` or `./scripts/dev.sh container` | CPU unless Docker GPU passthrough is configured |
| **NVIDIA Docker fallback** | `docker compose -f docker-compose.yml -f docker-compose.container-ollama.yml -f docker-compose.gpu.yml up --build` | CUDA inside Docker |

**NVIDIA Docker fallback** also needs the [NVIDIA Container Toolkit](https://docs.nvidia.com/datacenter/cloud-native/container-toolkit/latest/install-guide.html);
Ollama then auto-detects the card inside the container.

The old raw Compose command still works if Ollama is already installed and
running on the host: `docker compose up --build`.

Open:

- Frontend placeholder: http://localhost:5173
- Backend Swagger: http://localhost:5088/swagger
- Backend health: http://localhost:5088/health
- Backend readiness: http://localhost:5088/ready
- AI service health: http://localhost:8001/health

### Companion voice (orc boss)

The talking companion speaks context-aware, sarcastic lines in an "orc boss"
voice. Everything runs locally, with the LLM served by native host Ollama by
default:

- **Voice (TTS):** Piper + ffmpeg, baked into the `ai-service` image. Works the
  same on macOS, Windows and Linux (the image is Linux; the Piper binary is
  selected per architecture at build time).
- **Lines (LLM):** native Ollama on the host. On the **first** helper-script
  run, it downloads `qwen2.5:3b-instruct` and `qwen2.5:0.5b-instruct`, so the
  first start takes a few extra minutes.

Two models are used, both served by Ollama: `qwen2.5:3b-instruct` for the
companion's lines (it needs the wit) and the small, fast `qwen2.5:0.5b-instruct`
for inventing new crafting combinations (it needs the speed).

Both pieces degrade gracefully: if TTS or the LLM is unavailable the game still
works (text-only / deterministic lines).

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
