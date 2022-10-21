$list = aws servicediscovery list-namespaces --profile tmct_n1_default_devops --query Namespaces[*].Name | ConvertFrom-Json

Foreach($t in $list)
{
	if($t -eq "teamconnect")
	{
		write-host "found teamconnect namespace"
		Exit 0
	}
}
write-host "teamconnect namespace not found"
Exit 1	

