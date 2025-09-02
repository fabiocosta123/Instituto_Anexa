# Etapa 1: Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo do repositório
COPY . .

# Restaura e publica a solução completa
RUN dotnet restore Anexa.sln
RUN dotnet publish Anexa.sln -c Release -o /app/publish

# Etapa 3: Finaliza com runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Anexa.API.dll"]