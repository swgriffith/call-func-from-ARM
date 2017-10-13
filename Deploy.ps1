Login-AzureRMAccount
$RG = "<ResourceGroup>"
$LOC = "<Location>"

New-AzureRmResourceGroup -Name $RG -Location $LOC 
New-AzureRmResourceGroupDeployment -Name Test -ResourceGroupName $RG -TemplateFile .\functionfromarm.json -Verbose