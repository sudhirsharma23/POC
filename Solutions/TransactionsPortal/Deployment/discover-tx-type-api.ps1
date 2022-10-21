$stage='dev'
$api_resp=aws servicediscovery discover-instances --namespace-name teamconnect --service-name backend --profile tmct_n1_default_devops --query-parameters stage=$stage,api-name=transaction-type-api | ConvertFrom-Json
if($api_resp.Instances.Length -eq 1){
    Write-Host "Found API $stage Instance"
    $api_url=$api_resp.Instances[0].Attributes.rid
    Write-Host "API $stage URL: "$api_url
    $content=[System.IO.File]::ReadAllText("service-variables.json").Replace("{tx-report-dev-uri}",$api_url)
    [System.IO.File]::WriteAllText("service-variables.json", $content)
}
$stage='sb'
$api_resp=aws servicediscovery discover-instances --namespace-name teamconnect --service-name backend --profile tmct_n1_default_devops --query-parameters stage=$stage,api-name=transaction-type-api | ConvertFrom-Json
if($api_resp.Instances.Length -eq 1){
    Write-Host "Found API $stage Instance"
    $api_url=$api_resp.Instances[0].Attributes.rid
    Write-Host "API $stage URL: "$api_url
    $content=[System.IO.File]::ReadAllText("service-variables.json").Replace("{tx-report-$stage-uri}",$api_url)
    [System.IO.File]::WriteAllText("service-variables.json", $content)
    Exit 0
}
Write-Host "Not Found API $stage Instance"
Exit 1
