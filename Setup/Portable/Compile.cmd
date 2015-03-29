@echo off

echo.
echo Portable Accord.NET Framework all projects Release builder
echo ==========================================================
echo. 
echo This Windows batch file will use Visual Studio 2013 to
echo compile the Release versions of the Portable framework.
echo. 

timeout /T 5

@if "%VS120COMNTOOLS%"=="" goto error_no_VS120COMNTOOLSDIR
@call "%VS120COMNTOOLS%VsDevCmd.bat"

@cd "..\..\Sources"
@msbuild "Portable.Accord.NET.sln" /t:Rebuild /p:Configuration=Release;Platform="Any CPU"

@echo .pri > exclude.txt
@echo .mdb >> exclude.txt

@set PUBLISH=..\Setup\Portable\Publish\
@set PCLDIR=%PUBLISH%lib\portable-net45+netcore45+wpa81\

@if EXIST "%PUBLISH%" (rd /s /q "%PUBLISH%")

@md "%PUBLISH%"
@xcopy /k /r /v /y ..\README.md "%PUBLISH%"
@xcopy /k /r /v /y ..\License.txt "%PUBLISH%"
@copy /a /v /y "Extras\Accord.MachineLearning.GPL\License (GPL).txt" "%PUBLISH%License (Accord.MachineLearning.GPL).txt"
@copy /a /v /y "Extras\Accord.Math.NonCommercial\License.txt" "%PUBLISH%License (Accord.Math.NonCommercial).txt"

@md "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Audio\bin\Release\Accord.Audio.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Audio.Formats\bin\Release\Accord.Audio.Formats.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Core\bin\Release\Accord.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Formats\bin\Release\Accord.IO.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Imaging\bin\Release\Accord.Imaging.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.MachineLearning\bin\Release\Accord.MachineLearning.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Math\bin\Release\Accord.Math.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Neuro\bin\Release\Accord.Neuro.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Statistics\bin\Release\Accord.Statistics.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Vision\bin\Release\Accord.Vision.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Extras\Accord.MachineLearning.GPL\bin\Release\Accord.MachineLearning.GPL.* "%PCLDIR%"
@xcopy /k /r /v /y /exclude:exclude.txt Extras\Accord.Math.NonCommercial\bin\Release\Accord.Math.Noncommercial.* "%PCLDIR%"

@del /f exclude.txt

@goto end

@REM -----------------------------------------------------------------------
:error_no_VS120COMNTOOLSDIR
@echo ERROR: Cannot determine the location of the VS Common Tools folder.
@goto end

:end