# The following code will create an IIS site and it associated Application Pool. 
# Please note that you will be required to run PS with elevated permissions. 
# Visit http://ifrahimblog.wordpress.com/2014/02/26/run-powershell-elevated-permissions-import-iis-module/ 

#set-executionpolicy unrestricted

function DeleteIisApp($appName) {
    Write-Host "Deleting IIS application $appName...";
    $fullPath = "$(Get-Location)\$appName";
    
    try
    {
        $appPool = Get-WebAppPoolState $appName;
        Remove-WebAppPool -Name $appName;
    }
    catch{}

    $webApp = Get-WebApplication -Name $appName -Site 'Default web site';
    
    if ($webApp) {
        Remove-WebApplication -Name $appName -Site 'Default web site';
    }

    Write-Host "Done.";
    Write-Host "";
}

DeleteIisApp -appName 'DynamicForms.Web'
DeleteIisApp -appName 'DynamicForms.ConfigurationApi'
DeleteIisApp -appName 'DynamicForms.DataApi'