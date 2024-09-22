echo Copying files to mods folder
mkdir %2\Mods\BlacksmithingSkill\BlacksmithingSkillCode
copy %1\BlacksmithingSkillCode.dll %2\Mods\BlacksmithingSkill\BlacksmithingSkillCode\BlacksmithingSkillCode.dll
copy %1\manifest.json %2\Mods\BlacksmithingSkill\BlacksmithingSkillCode\manifest.json
xcopy "%~1\[CP] BlacksmithingSkill" "%~2\Mods\BlacksmithingSkill\[CP] BlacksmithingSkill\" /e
xcopy "%~1\assets" "%~2\Mods\BlacksmithingSkill\BlacksmithingSkillCode\assets\" /e
xcopy "%~1\i18n" "%~2\Mods\BlacksmithingSkill\BlacksmithingSkillCode\i18n\" /e