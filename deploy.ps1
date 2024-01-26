cd GroceryAppAPI/
$checkmark = [char]0x2705
Write-Host "$checkmark Starting project build" -ForeGroundColor Green
$dotnetBuildCommand = "dotnet build"
$scriptBlock = [Scriptblock]::Create($dotnetBuildCommand)
$dotnetBuildOutput = Invoke-Command -ScriptBlock $scriptBlock
Stop-WebAppPool -Name "GroceryAppAPI"
Write-Host "$checkmark Application Pool stopped successfully" -ForeGroundColor Green
Stop-Website -Name "GroceryAppAPI"
Write-Host "$checkmark Site stopped successfully" -ForeGroundColor Green
dotnet publish -c Debug
Write-Host "$checkmark Project published in Debug configuration" -ForeGroundColor Green
Start-WebAppPool -Name "GroceryAppAPI"
Write-Host "$checkmark Application Pool started successfully" -ForeGroundColor Green
Start-Website -Name "GroceryAppAPI"
Write-Host "$checkmark Site started successfully" -ForeGroundColor Green
Write-Host "$checkmark IIS Deployment successfull!" -ForeGroundColor Green
cd ../