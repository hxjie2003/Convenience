@ECHO OFF
copy D8SAIII.dll %SystemRoot%\System32\
copy dcrf32.dll %SystemRoot%\System32\
%SystemRoot%\System32\regsvr32.exe HTCardMan.dll
