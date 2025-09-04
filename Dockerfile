# Etapa 1: Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia primeiro a solução e os csproj (melhora cache do Docker)
COPY *.sln .
COPY Anexa.API/*.csproj Anexa.API/
COPY Anexa.Application/*.csproj Anexa.Application/
COPY Anexa.Domain/*.csproj Anexa.Domain/
COPY Anexa.Infrastructure/*.csproj Anexa.Infrastructure/

RUN dotnet restore

# Agora copia o resto do código
COPY . .

WORKDIR /src/Anexa.API
RUN dotnet publish -c Release -o /app/publish

# Etapa 3: Finaliza com runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Anexa.API.dll"]
