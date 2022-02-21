
cd C:\Code\rpg-encounter-generator\src\infra

dapr run `
--app-id item-service `
--app-port 5120 `
--components-path ./components `
-- dotnet run --project ..\character-service\RPGGen.CharacterService\RPGGen.CharacterService.csproj

dapr run `
--app-id character-service `
--components-path ./components `
-- dotnet run --project ..\item-service\RPGGen.ItemService\RPGGen.ItemService.csproj
