#!/usr/bin/env sh
set -eu

if command -v docker >/dev/null 2>&1 && docker compose version >/dev/null 2>&1; then
  docker compose up --build
elif command -v docker-compose >/dev/null 2>&1; then
  docker-compose up --build
else
  echo "Docker Compose was not found. Install Docker Desktop, then run this script again." >&2
  exit 1
fi
