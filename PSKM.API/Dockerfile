# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PSKM.API/PSKM.API.csproj", "PSKM.API/"]
COPY ["PSKM.Core/PSKM.Core.csproj", "PSKM.Core/"]
COPY ["PSKM.Data/PSKM.Data.csproj", "PSKM.Data/"]
COPY ["PSKM.Common/PSKM.Common.csproj", "PSKM.Common/"]
RUN dotnet restore "./PSKM.API/PSKM.API.csproj"
COPY . .
WORKDIR "/src/PSKM.API"
RUN dotnet build "./PSKM.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to apply migration before running app
FROM build AS migrations
WORKDIR "/src/PSKM.API"
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update --project "../PSKM.Data" --startup-project "../PSKM.API"


# This stage is used to publish the service dotnet ef database update --project PSKM.Data --startup-project PSKM.API
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PSKM.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PSKM.API.dll"]