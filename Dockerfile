# Etapa base: runtime ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etapa de build: SDK para compilar e publicar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY WebFamilyHome.csproj ./
RUN dotnet restore WebFamilyHome.csproj

# Copia o restante do código da pasta local
COPY . .

# Publica em Release
RUN dotnet publish WebFamilyHome.csproj -c Release -o /app/publish

# Etapa final: imagem enxuta só com runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebFamilyHome.dll"]
