FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["web_api.csproj", ""]
RUN dotnet restore "web_api.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "web_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "web_api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "web_api.dll"]
