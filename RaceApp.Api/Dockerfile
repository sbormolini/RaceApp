#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RaceApp.Api/RaceApp.Api.csproj", "RaceApp.Api/"]
RUN dotnet restore "RaceApp.Api/RaceApp.Api.csproj"
COPY . .
WORKDIR "/src/RaceApp.Api"
RUN dotnet build "RaceApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RaceApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RaceApp.Api.dll"]