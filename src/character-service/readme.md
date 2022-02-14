cd C:\Code\rpg-encounter-generator\src\character-service

dotnet ef migrations add InitDB -s .\RPGGen.CharacterService\RPGGen.CharacterService.csproj -p .\RPGGen.CharacterService.Data\RPGGen.CharacterService.Data.csproj

dotnet ef database update -s .\RPGGen.CharacterService\RPGGen.CharacterService.csproj -p .\RPGGen.CharacterService.Data\RPGGen.CharacterService.Data.csproj
