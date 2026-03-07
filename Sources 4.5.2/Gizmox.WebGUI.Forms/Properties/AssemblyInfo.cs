using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("Gizmox.WebGUI.Forms.dll")]
[assembly: AssemblyDescription("Gizmox.WebGUI.Forms.dll")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Gizmox")]
[assembly: AssemblyProduct("Gizmox© Visual WebGUI")]
[assembly: AssemblyCopyright("© Gizmox")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AllowPartiallyTrustedCallers]

//
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

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile(@"..\..\Keys\Gizmox.WebGUI.Forms.snk")]
[assembly: AssemblyKeyName("")]
[assembly: InternalsVisibleTo("Gizmox.WebGUI.Forms.Office, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c777d40ee45be9d4a9926f212611ed2718e85c1740c1400db502c2e54a9a89e31b9f666630dc25cbaf0f888e6e525e4e22f5c6229a7f0d328826bb851566104c023f3b1db9535aa2d8af5dd34695bf1fa32a155f45a6dd2cc9e2617e74fbad65989c1e60cfeb8d46c42e3e2f5630711ac0b2b45b0bfc4453ae9be37ff0a40daf")]
[assembly: InternalsVisibleTo("Gizmox.WebGUI.Forms.Design, PublicKey=002400000480000094000000060200000024000052534131000400000100010091fe4f90bae5ea813785ad4114f9d8b3985b5f47f99eb2a840ed1e867a0a301f894fb8bcfe79c918733c56919896b316ea4a8965275ae27d375ee305bc78b48739056fe4770d1c52f1fd0c0a22cf5a722cf2435396401aed0aa50817517515d472d3f0d22042de914f046bbf365b4598b2e1b04842cd4e354e1b0d3bbbcae4ad")]
[assembly: InternalsVisibleTo("Gizmox.WebGUI.Forms.Professional, PublicKey=002400000480000094000000060200000024000052534131000400000100010029db0bd21c78d28a2a3ee1a779427959c3c46b6c4169702bf42a507c281631e38e227a7ac425a246f0d078063cd7efc1b64678755b78bcc5e44496e8ba718785bc9965d06816e6188353ee214dfb0e262136a815faeb57469345d99ec06ea49ae724c6abde688bc654eaf6410043d1aa930dc5615e2012fa2bd0e838be36cfb7")]
[assembly: InternalsVisibleTo("Gizmox.WebGUI.Emulation, PublicKey=0024000004800000940000000602000000240000525341310004000001000100bbc1a4871fb7f534c79154d609261ff78d29b3ccd199a5954fea86e49866b5bbf8af7c9e02c1bd23a53f73d284192a4cbb58d3b097fb353f9ac2c73bdcbadd96d030992dd2c36906beb8e9ffa97d546f596a3bda0e93d0a689821d47a8c8463c51110e6cd21579e68a2306a754ae311e0a2189abd435ec10938fc6e5d94ed3b3")]
[assembly: InternalsVisibleTo("Gizmox.WebGUI.Emulation.Extensions, PublicKey=0024000004800000940000000602000000240000525341310004000001000100bfb70f58fe6b7bf3423e54f0c6b7bf01c2c3aa6e7ad86075f5378783c46ed5ad040d528db90a8917f9fc588c5b4df49aa2d587dce7cd7239b2752aebf9fbea8395255a6d0601222a1edaf409d5dd78ee496e178066cd35efc739e19c7025499363f49d24a51c9f97376f080da0622ac8086ffbc1e2ce72f42139af943c0cbdc7")]

