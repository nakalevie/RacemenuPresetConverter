REM convert and copy RaceMenu presets to BodySlide slider presets ::

REM path to RaceMenu presets folder (ex. ..\SKSE\Plugins\StorageUtilData\RaceMenuMorphsCBBE\Presets)
set "folderPath=C:\Users\fad3\ModOrganizer\Skyrim Special Edition\overwrite\SKSE\Plugins\StorageUtilData\RaceMenuMorphsCBBE\Presets"

REM path to RaceMenu presets folder (ex. ..\CalienteTools\BodySlide\SliderPresets)
set "outputPath=C:\Users\fad3\ModOrganizer\Skyrim Special Edition\overwrite\CalienteTools\BodySlide\SliderPresets"

REM convert
for %%f in ("%folderPath%\*.*") do (
	REM Arguments
	REM 1 - (required) path to preset you want to convert
	REM 2 - (not required) divide original values for low weight, yes or not
	REM 3 - (not required) divider(whole number or fraction separated by a dot)
    RacemenuPresetConverter.exe "%folderPath%\%%~nxf" "yes" "1.5"
)

REM copy
for %%o in ("exported\*.*") do (
    copy "%%o" "%outputPath%"
)
