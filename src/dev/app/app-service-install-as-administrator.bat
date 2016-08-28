:install
@echo DMS App Service installing...
@set dir=%~dp0
@set installer=devapp.exe
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe %dir%%installer%
@if %errorlevel%==0 goto build
@echo failed to install app service.
@pause
@exit 1
:build
@echo creating cache folder...
@set cache=%dir%Cache
@if exist %cache% goto startup
@md %cache%
:startup
@echo DMS App Service starting...
@net start "Dev App Service for DMS"
@if %errorlevel%==0 goto done
@echo failed to start app service.
@pause
@exit 2
:done
@echo success to install app service.
@pause
@exit 0