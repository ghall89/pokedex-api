# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/Pokedex.API/Pokedex.API.csproj src/Pokedex.API/
COPY src/Pokedex.Domain/Pokedex.Domain.csproj src/Pokedex.Domain/
RUN dotnet restore src/Pokedex.API/Pokedex.API.csproj --disable-parallel

COPY . .
RUN dotnet publish src/Pokedex.API/Pokedex.API.csproj -c Release -o /app/publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

RUN apt-get update \
    && apt-get install -y --no-install-recommends curl \
    && rm -rf /var/lib/apt/lists/*

RUN mkdir -p /data \
    && curl -fL -o /data/pokedex.sqlite https://raw.githubusercontent.com/teamdandelion/PokemonSQLTutorial/master/pokedex.sqlite

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
ENTRYPOINT ["dotnet", "Pokedex.API.dll"]
