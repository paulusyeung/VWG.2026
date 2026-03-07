Note:
This project is included to provide a a single place to reference external 
applications. You should use the bin directory to reference these external 
project. You can also add the bin directory to the VS registry keys so these 
assemblies will apear in the add reference dialog within VS.


To make your VS have these assemblies in the add reference dialog, you should
add the full bin\2.0\ folder path to the assemblies registry as following:

Add the following key
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\AssemblyFolders\Visual WebGui DEV

And the set the (Default) string to 
[The bin\2.0\ full folder path]