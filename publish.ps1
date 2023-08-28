#Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

#publish image
$tag = (git rev-parse --short HEAD)
cd mtgdiscord
write-host "start docker build"
docker build --no-cache -t mtgdiscord -f Dockerfile .
docker tag mtgdiscord docker.io/ryanevans332/mtgdiscord:$tag
write "pushing new image"
docker push docker.io/ryanevans332/mtgdiscord:$tag
cd ..

#publish container
write-host "start publish"
Connect-AzAccount -TenantId 1254c6e5-0d2f-4fbd-81eb-8756981fc06c
$sub = "dab8a9ed-89a6-482b-86ec-f4d0d468c471"
$token = ConvertTo-SecureString -String $env:mtgdiscordbot -AsPlainText -Force
$envvar = New-AzContainerInstanceEnvironmentVariableObject -Name "mtgdiscordbot" -SecureValue $token
$container = New-AzContainerInstanceObject -name "mtgdiscordcontainer" -Image ryanevans332/mtgdiscord:$tag -RequestCpu 1 -RequestMemoryInGb 1 -EnvironmentVariable $envvar
write-host "requesting new container"
New-AzContainerGroup -Name "mtgdiscordcontainer" -ResourceGroupName "mtgdiscord" -Location "West US 3" -Container $container -RestartPolicy "OnFailure"
write-host "done"