:register
@set dir=%~dp0
@set lib=OPCDAAuto.dll
@regsvr32 %dir%%installer%
@if %errorlevel%==0 goto done
@echo failed to register library.
@pause
@exit 1
:done
@echo success to register library.
@pause
@exit 0