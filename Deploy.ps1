Login-AzureRMAccount
$RG = "Throwaway99"
$LOC = "eastus"

New-AzureRmResourceGroup -Name $RG -Location $LOC 
New-AzureRmResourceGroupDeployment -Name Test -ResourceGroupName $RG -TemplateFile .\functionfromarm.json -Verbose