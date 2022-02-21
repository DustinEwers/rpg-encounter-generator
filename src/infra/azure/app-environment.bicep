param systemName string 
param environment string // example: d = dev, qa = qa, p = prod
param sequence string = '01'

param location string

param dbSkuName string
param dbSkuTier string

var dbServerName = '${systemName}-rpgdbServer-${environment}${sequence}'
var dbNameCharService = '${systemName}-chardb-${environment}${sequence}'
var dbNameItemService = '${systemName}-itemdb-${environment}${sequence}'

// var appInsightsName = 'insights-${systemName}-${environment}${sequence}'
// var logWorkspaceName = 'workspace-${systemName}-${environment}${sequence}'

// module appInsights './app-insights.bicep' = {
//   name: 'insights'
//   params: {
//     appInsightsName: appInsightsName
//     location: location
//     logWorkspaceName: logWorkspaceName
//   }
// }

module database_server './database-server.bicep' = {
  name: 'database-server'
  params: {
    dbServerName: dbServerName
    location: location
  }
}

module char_database './database.bicep' = {
  name: 'char-database'
  params: {
    dbName: dbNameCharService
    dbServerName: dbServerName
    dbSkuName: dbSkuName
    dbSkuTier: dbSkuTier
    location: location
  }
  dependsOn: [
    database_server
  ]
}

module item_database './database.bicep' = {
  name: 'item-database'
  params: {
    dbName: dbNameItemService
    dbServerName: dbServerName
    dbSkuName: dbSkuName
    dbSkuTier: dbSkuTier
    location: location
  }
  dependsOn: [
    database_server
  ]
}
