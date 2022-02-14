
cd C:\Code\rpg-encounter-generator\src\infra

dapr run `
--app-id item-service `
--components-path ./components `
-- dotnet run --project ..\character-service\RPGGen.CharacterService\RPGGen.CharacterService.csproj

dapr run `
--app-id character-service `
--components-path ./components `
-- dotnet run -p ..\item-service\RPGGen.ItemService\RPGGen.ItemService.csproj
