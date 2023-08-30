#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MusicShop.WebApi/MusicShop.WebApi.csproj", "MusicShop.WebApi/"]
COPY ["MusicShop.DataAccess/MusicShop.DataAccess.csproj", "MusicShop.DataAccess/"]
COPY ["MusicShop.AppData/MusicShop.AppData.csproj", "MusicShop.AppData/"]
COPY ["MusicShop.Contracts/MusicShop.Contracts.csproj", "MusicShop.Contracts/"]
COPY ["MusicShop.Domain/MusicShop.Domain.csproj", "MusicShop.Domain/"]
COPY ["MusicShop.Infrastructure/MusicShop.Infrastructure.csproj", "MusicShop.Infrastructure/"]
COPY ["MusicShop.Registrator/MusicShop.Registrator.csproj", "MusicShop.Registrator/"]
RUN dotnet restore "MusicShop.WebApi/MusicShop.WebApi.csproj"
COPY . .
WORKDIR "/src/MusicShop.WebApi"
RUN dotnet build "MusicShop.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicShop.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicShop.WebApi.dll"]