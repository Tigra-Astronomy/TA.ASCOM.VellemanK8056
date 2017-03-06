Push-Location ..\bin\Debug
Add-Type -path .\ASCOM.K8056.Switch.dll
$sw = New-Object ASCOM.K8056.Switch
$sw.Connected = $true
Pop-Location

Function WalkState([bool] $state)
    {
    For ($i=1; $i -lt 8; $i++)
        {
        $sw.SetSwitch($i, $state)
        Start-Sleep -Milliseconds 250
        }
    }

While ($true)
	{
	WalkState($true)
	WalkState($false)
	}

