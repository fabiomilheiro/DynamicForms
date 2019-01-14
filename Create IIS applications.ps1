# The following code will create an IIS site and it associated Application Pool. 
# Please note that you will be required to run PS with elevated permissions. 
# Visit http://ifrahimblog.wordpress.com/2014/02/26/run-powershell-elevated-permissions-import-iis-module/ 

#set-executionpolicy unrestricted

function SetUpIisApp($appName)
{
    Write-Host "Creating IIS application $appName...";
    $fullPath = "$(Get-Location)\$appName";
    
    try
    {
        $appPool = Get-WebAppPoolState -Name $appName;
        Remove-WebAppPool -Name $appName
    }
    catch {}
    
    $appPool = New-WebAppPool -Name $appName -Force
    

    $webApp = Get-WebApplication -Name $appName -Site 'Default web site';
    
    if ($webApp)
    {
        Remove-WebApplication -Name $appName -Site 'Default web site';
    }
    
    $webApp = New-WebApplication -Name $appName -Site 'Default Web Site' -PhysicalPath $fullPath -ApplicationPool $appName -Force;

    Write-Host "Done.";
    Write-Host "";
}

SetUpIisApp -appName 'DynamicForms.Web'
SetUpIisApp -appName 'DynamicForms.ConfigurationApi'
SetUpIisApp -appName 'DynamicForms.DataApi'