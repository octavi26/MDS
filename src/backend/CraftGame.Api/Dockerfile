FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/backend/CraftGame.Api/CraftGame.Api.csproj", "src/backend/CraftGame.Api/"]
RUN dotnet restore "src/backend/CraftGame.Api/CraftGame.Api.csproj"
COPY . .
RUN dotnet publish "src/backend/CraftGame.Api/CraftGame.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CraftGame.Api.dll"]
