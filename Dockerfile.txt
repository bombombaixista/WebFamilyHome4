# Etapa de build (SDK 9.0)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime (ASP.NET 9.0)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Configura a porta do Railway
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 5000

# Nome correto do DLL (Kanban.dll)
ENTRYPOINT ["dotnet", "Kanban.dll"]
