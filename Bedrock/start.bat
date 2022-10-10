@echo off

call C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe /target:library dtclient.cs
echo compiled dll 1/2
pause
call C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe  injector.cs
echo compiled dll 1/2

pause
call injector.exe

pause