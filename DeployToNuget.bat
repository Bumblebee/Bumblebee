@ECHO OFF

IF "%1"=="" (
	GOTO Blank
) ELSE (
	SET project=%1
	GOTO Specific
)

:Blank
SET project=Bumblebee
GOTO Specific

:Specific
nuget.exe update -self
ECHO Y | DEL *.nupkg

SET /p NuGetApiKey= Please enter the project's NuGet API Key: 
nuget.exe setApiKey %NuGetApiKey%

SET package="%project%\%project%.csproj"

ECHO "Packing/Pushing project found here:  %package%."
nuget.exe pack %package%

nuget.exe push *.nupkg