#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["character-service/RPGGen.CharacterService/RPGGen.CharacterService.csproj", "character-service/RPGGen.CharacterService/"]
COPY ["character-service/RPGGen.CharacterService.Domain/RPGGen.CharacterService.Domain.csproj", "character-service/RPGGen.CharacterService.Domain/"]
COPY ["character-service/RPGGen.CharacterService.Data/RPGGen.CharacterService.Data.csproj", "character-service/RPGGen.CharacterService.Data/"]
RUN dotnet restore "character-service/RPGGen.CharacterService/RPGGen.CharacterService.csproj"
COPY . .
WORKDIR "/src/character-service/RPGGen.CharacterService"
RUN dotnet build "RPGGen.CharacterService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RPGGen.CharacterService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RPGGen.CharacterService.dll"]
