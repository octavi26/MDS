$ErrorActionPreference = "Stop"

function Invoke-DockerCompose {
    param([string[]]$ComposeArgs)

    if (Get-Command docker -ErrorAction SilentlyContinue) {
        docker compose version *> $null
        if ($LASTEXITCODE -eq 0) {
            & docker compose @ComposeArgs
            exit $LASTEXITCODE
        }
    }

    if (Get-Command docker-compose -ErrorAction SilentlyContinue) {
        & docker-compose @ComposeArgs
        exit $LASTEXITCODE
    }

    throw "Docker Compose was not found. Install Docker Desktop, then run this script again."
}

Invoke-DockerCompose @("up", "--build")
