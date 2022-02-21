#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["item-service/RPGGen.ItemService/RPGGen.ItemService.csproj", "item-service/RPGGen.ItemService/"]
COPY ["item-service/RPGGen.ItemService.Data/RPGGen.ItemService.Data.csproj", "item-service/RPGGen.ItemService.Data/"]
COPY ["item-service/RPGGen.ItemService.Domain/RPGGen.ItemService.Domain.csproj", "item-service/RPGGen.ItemService.Domain/"]
RUN dotnet restore "item-service/RPGGen.ItemService/RPGGen.ItemService.csproj"
COPY . .
WORKDIR "/src/item-service/RPGGen.ItemService"
RUN dotnet build "RPGGen.ItemService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RPGGen.ItemService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RPGGen.ItemService.dll"]
