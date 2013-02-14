@ECHO OFF

setlocal

set version=%1

.\_build-tools\nuget.exe push _build_output\Working\Nuget\gmaps-api-net.%version%.nupkg