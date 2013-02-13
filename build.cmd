@ECHO OFF
ECHO.
ECHO.

REM ensure _Build_Output directory exists
mkdir _build_output >NUL

powershell -Command "& { [Console]::WindowWidth = 150; [Console]::WindowHeight = 50; Start-Transcript -path "./_build_output/lastbuild.log"; Import-Module ".\_build-tools\PSake.4.2.0.1\tools\psake.psm1"; Invoke-psake .\build-psake.ps1 %*; Stop-Transcript; }"
pause