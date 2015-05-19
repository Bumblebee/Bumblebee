@ECHO OFF

REM Update Nuget
REM ============
nuget.exe update -self

REM Delete Any Artifacts
REM ====================
cd build
ECHO Y | DEL *.nupkg

REM Build the Release Project
REM =========================
cd ..

REM Requests the API Key
REM ====================
SET /p NuGetApiKey= Please enter the project's NuGet API Key: 
nuget.exe setApiKey %NuGetApiKey%

SET package="src\Bumblebee\Bumblebee.csproj"

REM Create the Package
REM ==================
ECHO "Packing/Pushing project found here:  %package%."
nuget.exe pack -OutputDirectory build %package% -Prop Configuration=Release

REM Push to Nuget 
REM =============
cd build
nuget.exe push *.nupkg