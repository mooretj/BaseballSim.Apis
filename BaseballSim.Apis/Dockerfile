FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BaseballSim.Apis/BaseballSim.Apis.csproj", "BaseballSim.Apis/"]
RUN dotnet restore "BaseballSim.Apis/BaseballSim.Apis.csproj"
COPY . .
WORKDIR "/src/BaseballSim.Apis"
RUN dotnet build "BaseballSim.Apis.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BaseballSim.Apis.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseballSim.Apis.dll"]
