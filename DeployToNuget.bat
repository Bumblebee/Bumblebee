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
dotnet pack %package% -c Release -o ..\..\build

REM Push to Nuget 
REM =============
cd build
nuget.exe push *.nupkg
cd ..