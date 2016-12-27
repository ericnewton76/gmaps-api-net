@ECHO OFF
ECHO.
ECHO.

REM ensure _Build_Output directory exists
mkdir Build 2>NUL

ECHO Checking Tools
pushd Tools
Nuget install packages.config -excludeversion
if errorlevel 1 echo Error:Failed to run NUGET. & popd & goto :END
popd

ECHO.
ECHO.
powershell -Command "& { Start-Transcript -path "./Build/lastbuild.log"; Import-Module ".\Tools\psake\tools\psake.psm1"; Invoke-psake .\build-psake.ps1 %*; Stop-Transcript; }"

REM powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\psake.ps1' %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
exit /B %errorlevel%


:END
color
ECHO.
if errorlevel 1 echo Errors occurred.
echo Done.