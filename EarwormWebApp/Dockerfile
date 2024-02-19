FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EarwormWebApp/EarwormWebApp.csproj", "EarwormWebApp/"]
COPY ["MusicLookupClientProxy/MusicLookupClientProxy.csproj", "MusicLookupClientProxy/"]
RUN dotnet restore "././EarwormWebApp/EarwormWebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./EarwormWebApp/EarwormWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build/

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EarwormWebApp/EarwormWebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EarwormWebApp.dll"]