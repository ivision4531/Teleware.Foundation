cd /d pkgs
dotnet nuget push * -k nuget -s http://10.0.7.71:8484/api/v2/package

pause