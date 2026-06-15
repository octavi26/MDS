@echo off
setlocal

set "MODE=%~1"

where docker >nul 2>nul
if %errorlevel%==0 (
    docker compose version >nul 2>nul
    if %errorlevel%==0 (
        if /I "%MODE%"=="debug" (
            docker compose up --build --force-recreate -d
            if errorlevel 1 exit /b %errorlevel%
            start "" "http://localhost:5173/?debug=1"
            docker compose logs -f
            exit /b %errorlevel%
        )
        docker compose up --build
        exit /b %errorlevel%
    )
)

where docker-compose >nul 2>nul
if %errorlevel%==0 (
    if /I "%MODE%"=="debug" (
        docker-compose up --build --force-recreate -d
        if errorlevel 1 exit /b %errorlevel%
        start "" "http://localhost:5173/?debug=1"
        docker-compose logs -f
        exit /b %errorlevel%
    )
    docker-compose up --build
    exit /b %errorlevel%
)

echo Docker Compose was not found. Install Docker Desktop, then run this script again.
exit /b 1
