@ECHO OFF

setlocal
if "%NUGET_EXE%" == "" where nuget 2>NUL & if errorlevel 0 if not errorlevel 1 set NUGET_EXE=nuget
if "%NUGET_EXE%" == "" echo ** ERROR: Cant find NUGET.EXE in path & goto :END

if "%BUILD_VERSION%" == "" set BUILD_VERSION=%APPVEYOR_BUILD_VERSION%

set PROJECT=Google.Maps
if "%CONFIGURATION%" == "" set CONFIGURATION=Release



REM mkdir Build 2>NUL
REM mkdir Build\NugetPack 2>NUL
xcopy /I /Y src\%PROJECT%\bin\%CONFIGURATION%\%PROJECT%.* Build\Nuget\lib
if errorlevel 1 goto :END

pushd Build\NugetPack

echo.
echo copy gmaps-api-net.nuspec .
copy ..\..\gmaps-api-net.nuspec .

echo.
echo NUGET_EXE:%NUGET_EXE%
%NUGET_EXE% pack gmaps-api-net.nuspec -version %BUILD_VERSION%

:END
popd