#!/usr/bin/env sh
set -eu

MODE="${1:-host}"
DEBUG=0
USE_CONTAINER_OLLAMA=0

case "$MODE" in
  host) ;;
  debug) DEBUG=1 ;;
  container) USE_CONTAINER_OLLAMA=1 ;;
  container-debug) USE_CONTAINER_OLLAMA=1; DEBUG=1 ;;
  *)
    echo "Usage: ./scripts/dev.sh [host|debug|container|container-debug]" >&2
    exit 1
    ;;
esac

if command -v docker >/dev/null 2>&1 && docker compose version >/dev/null 2>&1; then
  COMPOSE="docker compose"
elif command -v docker-compose >/dev/null 2>&1; then
  COMPOSE="docker-compose"
else
  echo "Docker Compose was not found. Install Docker Desktop, then run this script again." >&2
  exit 1
fi

COMPOSE_FILES="-f docker-compose.yml"
if [ "$USE_CONTAINER_OLLAMA" -eq 1 ]; then
  COMPOSE_FILES="$COMPOSE_FILES -f docker-compose.container-ollama.yml"
fi

ensure_host_ollama() {
  if ! command -v ollama >/dev/null 2>&1; then
    if [ "$(uname -s)" = "Darwin" ] && command -v brew >/dev/null 2>&1; then
      echo "Installing Ollama with Homebrew..."
      brew install ollama
    else
      echo "Ollama was not found. Install Ollama, or run ./scripts/dev.sh container to use the Docker fallback." >&2
      exit 1
    fi
  fi

  if [ "$(uname -s)" = "Darwin" ] && command -v brew >/dev/null 2>&1; then
    brew services start ollama >/dev/null 2>&1 || true
  fi

  if ! ollama list >/dev/null 2>&1; then
    echo "Starting Ollama..."
    (ollama serve >/tmp/mds-ollama.log 2>&1 &)
  fi

  i=0
  until ollama list >/dev/null 2>&1; do
    i=$((i + 1))
    if [ "$i" -ge 60 ]; then
      echo "Ollama did not become ready. Check /tmp/mds-ollama.log." >&2
      exit 1
    fi
    sleep 1
  done

  echo "Pulling required Ollama models..."
  ollama pull qwen2.5:3b-instruct
  ollama pull qwen2.5:0.5b-instruct
  ollama run qwen2.5:3b-instruct "hi" >/dev/null 2>&1 || true
  ollama run qwen2.5:0.5b-instruct "hi" >/dev/null 2>&1 || true
}

if [ "$USE_CONTAINER_OLLAMA" -eq 0 ]; then
  ensure_host_ollama
fi

if [ "$DEBUG" -eq 1 ]; then
  $COMPOSE $COMPOSE_FILES up --build --force-recreate -d
  if command -v open >/dev/null 2>&1; then
    open "http://localhost:5173/?debug=1" >/dev/null 2>&1 || true
  elif command -v xdg-open >/dev/null 2>&1; then
    xdg-open "http://localhost:5173/?debug=1" >/dev/null 2>&1 || true
  fi
  $COMPOSE $COMPOSE_FILES logs -f
else
  $COMPOSE $COMPOSE_FILES up --build
fi
