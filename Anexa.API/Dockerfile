# Etapa 1: Imagem base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todo o conteúdo de Anexa.API (contexto de build)
COPY . .

# Restaura e publica o projeto diretamente
RUN dotnet restore            # detecta automaticamente o Anexa.API.csproj
RUN dotnet publish -c Release -o /app/publish

# Etapa 3: Finaliza com runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Anexa.API.dll"]