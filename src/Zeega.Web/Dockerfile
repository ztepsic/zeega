# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG VERSION=1.0.0
WORKDIR /src

# Copy Central Package Management files and nuget config
COPY ["Directory.Build.props", "./"]
COPY ["Directory.Packages.props", "./"]
COPY ["nuget.config", "./"]

# Copy all project files for restore
COPY ["Zeega.Web/Zeega.Web.csproj", "Zeega.Web/"]
COPY ["Zeega.Infrastructure/Zeega.Infrastructure.csproj", "Zeega.Infrastructure/"]
COPY ["Zeega.Domain/Zeega.Domain.csproj", "Zeega.Domain/"]

RUN dotnet restore "./Zeega.Web/Zeega.Web.csproj"

# Copy everything else
COPY . .
WORKDIR "/src/Zeega.Web"
RUN dotnet build "./Zeega.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build -p:Version=$VERSION

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG VERSION=1.0.0
RUN dotnet publish "./Zeega.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false -p:Version=$VERSION

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
ARG VERSION=1.0.0
LABEL org.opencontainers.image.version="${VERSION}"
LABEL org.opencontainers.image.title="Zeega Web"
LABEL org.opencontainers.image.description="Zeega Web Application"
LABEL org.opencontainers.image.source="https://github.com/zeega/zeega"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zeega.Web.dll"]