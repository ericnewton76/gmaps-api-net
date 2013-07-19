@ECHO OFF
if "%1" == "" goto :USAGE

setlocal

set version=%1
set filename=gmaps-api-net.%version%.nupkg
set path=Build\Nuget\%filename%

if not exist "%path%" echo Warning: no file matches '%path%' & goto :END

.\Tools\nuget.exe push %path%

goto :END

:USAGE
echo %0 [version]
echo.
echo Example: %0 1.0.0.0
echo.
echo File must exist

:END
