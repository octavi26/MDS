param(
    [ValidateSet("host", "debug", "container", "container-debug")]
    [string]$Mode = "host"
)

$ErrorActionPreference = "Stop"

function Invoke-DockerCompose {
    param(
        [string[]]$ComposeArgs,
        [bool]$UseContainerOllama
    )

    $composeFiles = @("-f", "docker-compose.yml")
    if ($UseContainerOllama) {
        $composeFiles += @("-f", "docker-compose.container-ollama.yml")
    }

    if (Get-Command docker -ErrorAction SilentlyContinue) {
        docker compose version *> $null
        if ($LASTEXITCODE -eq 0) {
            & docker compose @composeFiles @ComposeArgs
            exit $LASTEXITCODE
        }
    }

    if (Get-Command docker-compose -ErrorAction SilentlyContinue) {
        & docker-compose @composeFiles @ComposeArgs
        exit $LASTEXITCODE
    }

    throw "Docker Compose was not found. Install Docker Desktop, then run this script again."
}

function Get-OllamaCommand {
    $command = Get-Command ollama -ErrorAction SilentlyContinue
    if ($command) {
        return $command.Source
    }

    $localAppOllama = Join-Path $env:LOCALAPPDATA "Programs\Ollama\ollama.exe"
    if (Test-Path $localAppOllama) {
        return $localAppOllama
    }

    return $null
}

function Ensure-HostOllama {
    $ollama = Get-OllamaCommand
    if (-not $ollama) {
        $winget = Get-Command winget -ErrorAction SilentlyContinue
        if (-not $winget) {
            throw "Ollama was not found and winget is unavailable. Install Ollama, or run scripts/dev.ps1 container to use the Docker fallback."
        }

        Write-Host "Installing Ollama with winget..."
        winget install --id Ollama.Ollama -e --accept-package-agreements --accept-source-agreements
        $ollama = Get-OllamaCommand
        if (-not $ollama) {
            throw "Ollama was installed, but ollama.exe was not found in this shell. Open a new terminal and run this command again."
        }
    }

    & $ollama list *> $null
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Starting Ollama..."
        Start-Process -FilePath $ollama -ArgumentList "serve" -WindowStyle Minimized
    }

    $ready = $false
    for ($i = 0; $i -lt 60; $i++) {
        & $ollama list *> $null
        if ($LASTEXITCODE -eq 0) {
            $ready = $true
            break
        }
        Start-Sleep -Seconds 1
    }

    if (-not $ready) {
        throw "Ollama did not become ready on http://localhost:11434."
    }

    Write-Host "Pulling required Ollama models..."
    & $ollama pull qwen2.5:3b-instruct
    & $ollama pull qwen2.5:0.5b-instruct
    & $ollama run qwen2.5:3b-instruct "hi" *> $null
    & $ollama run qwen2.5:0.5b-instruct "hi" *> $null
}

$useContainerOllama = $Mode -eq "container" -or $Mode -eq "container-debug"
$debug = $Mode -eq "debug" -or $Mode -eq "container-debug"

if (-not $useContainerOllama) {
    Ensure-HostOllama
}

if ($debug) {
    Invoke-DockerCompose -ComposeArgs @("up", "--build", "--force-recreate", "-d") -UseContainerOllama $useContainerOllama
    Start-Process "http://localhost:5173/?debug=1"
    Invoke-DockerCompose -ComposeArgs @("logs", "-f") -UseContainerOllama $useContainerOllama
} else {
    Invoke-DockerCompose -ComposeArgs @("up", "--build") -UseContainerOllama $useContainerOllama
}
