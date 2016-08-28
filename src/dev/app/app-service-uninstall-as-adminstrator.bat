:stop
@echo DMS App Service stopping...
@net stop "Dev App Service for DMS"
@if %errorlevel%==0 goto uninstall
@echo failed to stop app service.
:uninstall
@echo DMS App Service uninstalling...
@set dir=%~dp0
@set installer=app.exe
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u %dir%%installer%
@if %errorlevel%==0 goto done
@echo failed to uninstall app service.
@pause
@exit 2
:done
@echo success to uninstall app service.
@pause
@exit 0