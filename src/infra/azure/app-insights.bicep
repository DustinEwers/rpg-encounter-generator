param location string
param appInsightsName string
param logWorkspaceName string

// Analytics Workspace
// https://docs.microsoft.com/en-us/azure/templates/microsoft.operationalinsights/2020-03-01-preview/workspaces?tabs=bicep
resource workspaces_AnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: logWorkspaceName
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
    workspaceCapping: {
      dailyQuotaGb: 1
    }
  }
}

// Application Insights
// https://docs.microsoft.com/en-us/azure/templates/microsoft.insights/2020-02-02-preview/components?tabs=bicep
resource components_ApplicationInsights 'microsoft.insights/components@2020-02-02' = {
  name: appInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: workspaces_AnalyticsWorkspace.id
    IngestionMode: 'LogAnalytics'
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
  }
  dependsOn:[
    workspaces_AnalyticsWorkspace
  ]
}

output InstrumentationKey string = components_ApplicationInsights.properties.InstrumentationKey
output ConnectionString string = components_ApplicationInsights.properties.ConnectionString
