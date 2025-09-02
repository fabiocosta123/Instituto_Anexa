# Etapa 1: Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o repositório para dentro de /src
COPY . .

# Restaura e publica diretamente o projeto Anexa.API
RUN dotnet restore Anexa.API/Anexa.API.csproj
RUN dotnet publish Anexa.API/Anexa.API.csproj -c Release -o /app/publish

# Etapa 3: Imagem final de runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Anexa.API.dll"]