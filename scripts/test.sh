#!/usr/bin/env sh
set -eu

dotnet test MDS.sln
npm --prefix src/frontend test
cd src/ai-service && python -m pytest
