FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["worker_service.csproj", ""]
RUN dotnet restore "worker_service.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "worker_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "worker_service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "worker_service.dll"]
