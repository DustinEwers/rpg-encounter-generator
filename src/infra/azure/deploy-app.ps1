param (
    [Parameter(Mandatory=$true)]
    [string] $ResourceGroupName,

    [Parameter(Mandatory=$true)]
    [string] $Location,

    [Parameter(Mandatory=$true)]
    [string] $EnvironmentConfigFile
)

$deploymentNumber = get-date -Format "yyyyMMddhhmmss"

az group create `
    --name $ResourceGroupName `
    --location $Location

az deployment group create `
    --name "rpggen-$deploymentNumber-deployment" `
    --resource-group $ResourceGroupName `
    --template-file app-environment.bicep `
    --parameters "@./$EnvironmentConfigFile"