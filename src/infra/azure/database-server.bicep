param location string
param dbServerName string

param adminName string = uniqueString('BatteryHorseStapleCorrect!')

@secure()
param adminPassword string = newGuid()

// Docs: https://docs.microsoft.com/en-us/azure/templates/microsoft.sql/servers?tabs=bicep

resource app_databaseServer 'Microsoft.Sql/servers@2021-02-01-preview' = {
  name: dbServerName
  location: location
  properties: {
    administratorLogin: adminName
    administratorLoginPassword: adminPassword
  }
}
