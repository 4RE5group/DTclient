@echo off

call C:\Windows\Microsoft.NET\Framework\v3.5\csc.exe /win32icon:icon.ico *.cs
echo compiled injector!

pause
call dtinjector.exe

pause
