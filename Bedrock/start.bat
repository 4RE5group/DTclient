@echo off

call U:\j.clementmassonna\MinGW\bin\g++ dtclient.cpp -o dtclient
echo compiled dll 1/2
pause
call C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe  injector.cs
echo compiled dll 1/2

pause
call injector.exe

pause