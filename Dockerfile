
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DNTPracAPI_447/DNTPracAPI_447.csproj", "DNTPracAPI_447/"]
COPY ["DNTPrac_447/DNTPrac_447.csproj", "DNTPrac_447/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["DALPrac_447/DALPrac_447.csproj", "DALPrac_447/"]


# Restore NuGet packages for the entire dependency tree
RUN dotnet restore "DNTPracAPI_447/DNTPracAPI_447.csproj"

# Copy the remaining source code
COPY . .

# Build and publish the API project
WORKDIR "/src/DNTPracAPI_447"
RUN dotnet build "DNTPracAPI_447.csproj" -c $BUILD_CONFIGURATION -o /app/build
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "DNTPracAPI_447.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DNTPracAPI_447.dll"]