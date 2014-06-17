nuget.exe update -self
ECHO Y | DEL *.nupkg

REM Using an account for bumblebee@meinershagen.net to publish to NuGet.org.  This can be changed in the future.
set /p NuGetApiKey= Please enter the project's NuGet API Key: 
nuget.exe setApiKey %NuGetApiKey%
nuget.exe pack Bumblebee\Bumblebee.csproj
nuget.exe push *.nupkg