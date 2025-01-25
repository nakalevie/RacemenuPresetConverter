:: convert and copy RaceMenu presets to BodySlide slider presets ::

:: path to RaceMenu presets folder (ex. ..\SKSE\Plugins\StorageUtilData\RaceMenuMorphsCBBE\Presets)
set "folderPath=enter_path_here"
:: path to RaceMenu presets folder (ex. ..\CalienteTools\BodySlide\SliderPresets)
set "outputPath=enter_path_here"
:: convert
for %%f in ("%folderPath%\*.*") do (
	:: Arguments
	:: 1 - (required) path to preset you want to convert
	:: 2 - (not required) divide original values for low weight, yes or not
	:: 3 - (not required) divider(whole number or fraction separated by a dot)
    RacemenuPresetConverter.exe "%folderPath%\%%~nxf" "yes" "1.5"
)
:: copy
for %%o in ("exported\*.*") do (
    copy "%%o" "%outputPath%"
)