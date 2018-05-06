@ECHO OFF

REM Update Nuget
REM ============
nuget.exe update -self

REM Delete Any Artifacts
REM ====================
if exist build (
	rd /s/q build
)

mkdir build

REM Requests the API Key
REM ====================
SET /p NuGetApiKey= Please enter the project's NuGet API Key: 
nuget.exe setApiKey %NuGetApiKey%

SET package=".\src\Bumblebee\Bumblebee.csproj"

REM Create the Package
REM ==================
ECHO "Restoring project found here:  %package%."
nuget.exe restore %package%

ECHO "Packing/Pushing project found here:  %package%."
dotnet build %package% -c Release
dotnet pack %package% --no-build -o ..\..\build -c Release

REM Push to Nuget 
REM =============
REM cd build
REM ..\nuget.exe push *.nupkg
REM cd ..