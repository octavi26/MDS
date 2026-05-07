$ErrorActionPreference = "Stop"
dotnet test MDS.sln
npm --prefix src/frontend test
Push-Location src/ai-service
python -m pytest
Pop-Location
