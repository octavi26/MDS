@echo off
setlocal

where docker >nul 2>nul
if %errorlevel%==0 (
    docker compose version >nul 2>nul
    if %errorlevel%==0 (
        docker compose up --build
        exit /b %errorlevel%
    )
)

where docker-compose >nul 2>nul
if %errorlevel%==0 (
    docker-compose up --build
    exit /b %errorlevel%
)

echo Docker Compose was not found. Install Docker Desktop, then run this script again.
exit /b 1
