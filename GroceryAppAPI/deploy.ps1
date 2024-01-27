Start-WebAppPool -Name "GroceryAppAPI"
Stop-WebAppPool -Name "GroceryAppAPI"
Write-Host "[Done] Application Pool stopped successfully" -ForeGroundColor Green
Start-Website -Name "GroceryAppAPI"
Stop-Website -Name "GroceryAppAPI"
Write-Host "[Done] Site stopped successfully" -ForeGroundColor Green
dotnet publish -c Debug --no-build
Write-Host "[Done] Project published in Debug configuration" -ForeGroundColor Green
Start-WebAppPool -Name "GroceryAppAPI"
Write-Host "[Done] Application Pool started successfully" -ForeGroundColor Green
Start-Website -Name "GroceryAppAPI"
Write-Host "[Done] Site started successfully" -ForeGroundColor Green
Write-Host "[Done] API is successfully deployed to IIS Server!" -ForeGroundColor Green