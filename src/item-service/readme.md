cd C:\Code\rpg-encounter-generator\src\item-service

dotnet ef migrations add InitDB -s .\RPGGen.ItemService\RPGGen.ItemService.csproj -p .\RPGGen.ItemService.Data\RPGGen.ItemService.Data.csproj

dotnet ef database update -s .\RPGGen.ItemService\RPGGen.ItemService.csproj -p .\RPGGen.ItemService.Data\RPGGen.ItemService.Data.csproj