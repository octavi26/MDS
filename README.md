# MDS Project Scaffold

This repository is a clean runnable scaffold for the MDS project. It intentionally does **not** contain game logic, recipe logic, level logic, AI agent behavior, or a real interface yet.

It only prepares the stack so the team can start building the actual game from a working baseline.

## Start Everything

Requirements:

- Docker Desktop
- Git

From the repo root:

```sh
docker compose up --build
```

Open:

- Frontend placeholder: http://localhost:5173
- Backend Swagger: http://localhost:5088/swagger
- Backend health: http://localhost:5088/health
- Backend readiness: http://localhost:5088/ready
- AI service health: http://localhost:8001/health

The frontend should only say that it works. That is intentional.

## What Is Prepared

- `src/frontend`: React + Vite + TypeScript + Tailwind project
- `src/backend/CraftGame.Api`: ASP.NET Core Web API project
- `src/ai-service`: FastAPI project
- `db`: PostgreSQL service in Docker Compose
- `SignalR`: backend hub placeholder
- `Swagger`: backend API docs
- `GitHub Actions`: CI for backend, frontend, and AI service
- Cross-platform helper scripts in `scripts/`

## What Is Not Built Yet

- No game screen
- No level system
- No element inventory
- No combination logic
- No AI agent prompts
- No TTS pipeline
- No persisted gameplay schema

Those parts are intentionally left for the team to design and implement.

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
- **Gemini CLI Assistant** - Full-stack integration, AI-ready architecture, and database engineering

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
