::TlbExp.exe /win64 MyMenu.dll
echo 1 typelib "D:\Repos\MinitabApp\MinitabMenu\bin\Release\YAN_MinitabMenu.tlb" > "D:\Repos\MinitabApp\MinitabMenu\Resources\YAN_MinitabMenu.rc"
"C:\Program Files (x86)\Windows Kits\10\bin\10.0.18362.0\x64\rc.exe" "D:\Repos\MinitabApp\MinitabMenu\Resources\YAN_MinitabMenu.rc"
@pause