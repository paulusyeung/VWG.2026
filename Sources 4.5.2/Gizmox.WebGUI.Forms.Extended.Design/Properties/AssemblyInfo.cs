using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Gizmox.WebGUI.Forms.Extended.Design.dll")]
[assembly: AssemblyDescription("Gizmox.WebGUI.Forms.Extended.Design.dll")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Gizmox")]
[assembly: AssemblyProduct("Gizmox© Visual WebGUI")]
[assembly: AssemblyCopyright("© Gizmox")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("854ae1b3-3798-47b6-afa5-2d0d4f95aed2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
#endif

#if WG_NET46
[assembly: AssemblyVersion("4.6.5701.0")]
#elif WG_NET452
[assembly: AssemblyVersion("4.5.25701.0")]
#elif WG_NET451
[assembly: AssemblyVersion("4.5.15701.0")]
#elif WG_NET45
[assembly: AssemblyVersion("4.5.5701.0")]
#elif WG_NET40
[assembly: AssemblyVersion("4.0.5701.0")]
#elif WG_NET35
[assembly: AssemblyVersion("3.0.5701.0")]
#else
[assembly: AssemblyVersion("2.0.5701.0")]
#endif
[assembly: AssemblyFileVersion("1.0.*")]
