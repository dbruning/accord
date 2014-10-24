@if "%VS120COMNTOOLS%"=="" goto error_no_VS120COMNTOOLSDIR
@call "%VS120COMNTOOLS%VsDevCmd.bat"

@cd "%HOMEDRIVE%%HOMEPATH%\Documents\Visual Studio 2012\Projects\accord\Sources"
@msbuild "Portable.Accord.NET.sln" /t:Rebuild /p:Configuration=Release;Platform="Any CPU"

@echo .pri > exclude.txt
@echo .mdb >> exclude.txt

@if EXIST Publish (rd /s /q Publish)

@md Publish
@xcopy /k /r /v /y ..\README.md Publish
@xcopy /k /r /v /y ..\License.txt Publish
@copy /a /v /y "Extras\Accord.MachineLearning.GPL\License (GPL).txt" "Publish\License (Accord.MachineLearning.GPL).txt"
@copy /a /v /y "Extras\Accord.Math.NonCommercial\License.txt" "Publish\License (Accord.Math.NonCommercial).txt"

@md "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Audio\bin\Release\Accord.Audio.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Audio.Formats\bin\Release\Accord.Audio.Formats.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Core\bin\Release\Accord.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Formats\bin\Release\Accord.IO.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Imaging\bin\Release\Accord.Imaging.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.MachineLearning\bin\Release\Accord.MachineLearning.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Math\bin\Release\Accord.Math.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Neuro\bin\Release\Accord.Neuro.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Statistics\bin\Release\Accord.Statistics.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Accord.Vision\bin\Release\Accord.Vision.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Extras\Accord.MachineLearning.GPL\bin\Release\Accord.MachineLearning.GPL.* "Publish\PCL\Any CPU"
@xcopy /k /r /v /y /exclude:exclude.txt Extras\Accord.Math.NonCommercial\bin\Release\Accord.Math.Noncommercial.* "Publish\PCL\Any CPU"

@del /f exclude.txt

@goto end

@REM -----------------------------------------------------------------------
:error_no_VS120COMNTOOLSDIR
@echo ERROR: Cannot determine the location of the VS Common Tools folder.
@goto end

:end