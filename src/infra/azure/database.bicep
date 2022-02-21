param location string
param dbServerName string
param dbName string

param dbSkuName string
param dbSkuTier string

// Docs: https://docs.microsoft.com/en-us/azure/templates/microsoft.sql/servers/databases?tabs=bicep
resource app_database 'Microsoft.Sql/servers/databases@2021-02-01-preview' = {
  name: '${dbServerName}/${dbName}' // The server/database naming is required or this won't work
  location: location
  sku: {
    name: dbSkuName
    tier: dbSkuTier
  }
}
