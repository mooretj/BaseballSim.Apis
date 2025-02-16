FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BaseballSim.Apis/BaseballSim.Apis.csproj", "BaseballSim.Apis/"]
COPY ["BaseballSim.Core/BaseballSim.Core.csproj", "BaseballSim.Core/"]
COPY ["BaseballSim.DAL/BaseballSim.DAL.csproj", "BaseballSim.DAL/"]
COPY ["BaseballSim.BLL/BaseballSim.BLL.csproj", "BaseballSim.BLL/"]
RUN dotnet restore "BaseballSim.Apis/BaseballSim.Apis.csproj"

COPY . .
WORKDIR "/src/BaseballSim.Apis"
RUN dotnet build "BaseballSim.Apis.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "BaseballSim.Apis.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseballSim.Apis.dll"]
