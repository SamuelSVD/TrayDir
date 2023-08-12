"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ..\TrayDir\TrayDir.csproj /property:Configuration=Release
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ..\TrayDir\TrayDir.csproj /property:Configuration=Release(x64)

"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" installer_32bit.iss

mkdir _Temp_
mkdir _Temp_\TrayDir_32bit
mkdir _Temp_\TrayDir_64bit

xcopy ..\TrayDir\bin\Release _Temp_\TrayDir_32bit /E
xcopy ..\TrayDir\bin\Release(x64) _Temp_\TrayDir_64bit /E

del _Temp_\TrayDir_32bit\config.xml
del _Temp_\TrayDir_32bit\TrayDir.application
del _Temp_\TrayDir_32bit\TrayDir.exe.config
del _Temp_\TrayDir_32bit\TrayDir.exe.manifest
del _Temp_\TrayDir_32bit\TrayDir.pdb
del _Temp_\TrayDir_32bit\TrayDir.chm

rmdir _Temp_\TrayDir_32bit\app.publish /S /Q

del _Temp_\TrayDir_64bit\config.xml
del _Temp_\TrayDir_64bit\TrayDir.application
del _Temp_\TrayDir_64bit\TrayDir.exe.config
del _Temp_\TrayDir_64bit\TrayDir.exe.manifest
del _Temp_\TrayDir_64bit\TrayDir.pdb
del _Temp_\TrayDir_64bit\TrayDir.chm

rmdir _Temp_\TrayDir_64bit\app.publish /S /Q

cd _Temp_\TrayDir_32bit\
"C:\Program Files\7-Zip\7z.exe" a ..\..\bin\TrayDir_32bit.zip "*"
cd ..\..

cd _Temp_\TrayDir_64bit\
"C:\Program Files\7-Zip\7z.exe" a ..\..\bin\TrayDir_64bit.zip "*"
cd ..\..

rmdir _Temp_ /S /Q