#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.VSIntegration
{
	public static class ProjectHelper
	{
		private class QC : IXmlNamespaceResolver
		{
			private static string A = "http://schemas.microsoft.com/developer/msbuild/2003";

			public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope)
			{
				return new Dictionary<string, string> { ["x"] = A };
			}

			public string LookupNamespace(string prefix)
			{
				if (!(prefix == "x"))
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return A;
			}

			public string LookupPrefix(string namespaceName)
			{
				if (!(namespaceName == A))
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return "x";
			}
		}

		public static bool IsApplicationProject(string strProjectTypeGuids)
		{
			return IsApplicationProjectInternal(GetNormalizedGuids(strProjectTypeGuids));
		}

		public static bool IsLibraryProject(string strProjectTypeGuids, string strOutputType)
		{
			return IsLibraryProjectInternal(GetNormalizedGuids(strProjectTypeGuids), strOutputType);
		}

		internal static string UpgradeProjectTypeGuids(string strProjectTypeGuids, string strOutputType)
		{
			return UpgradeProjectTypeGuidsInternal(GetNormalizedGuids(strProjectTypeGuids), strOutputType);
		}

		internal static bool ShouldUpgradeProjectTypeGuids(string strProjectTypeGuids, string strOutputType)
		{
			return ShouldUpgradeProjectTypeGuidsInternal(GetNormalizedGuids(strProjectTypeGuids), strOutputType);
		}

		public static bool ShouldUpgrageProjectAt(string strProjectPath)
		{
			if (!ShouldUpgradeProjectTypeGuids(GetProjectGuids(strProjectPath), GetProjectOutputType(strProjectPath)))
			{
				return ShouldUpgradeProjectImportsInternal(strProjectPath);
			}
			return true;
		}

		public static bool IsCommunityApplication(string strProjectTypeGuids)
		{
			return IsCommunityApplicationInternal(GetNormalizedGuids(strProjectTypeGuids));
		}

		public static bool IsProfesionalApplication(string strProjectTypeGuids)
		{
			return IsProfesionalApplicationInternal(GetNormalizedGuids(strProjectTypeGuids));
		}

		public static bool IsCommunityLibrary(string strProjectTypeGuids)
		{
			return IsCommunityLibraryInternal(GetNormalizedGuids(strProjectTypeGuids));
		}

		public static bool IsProfesionalLibrary(string strProjectTypeGuids)
		{
			return IsProfesionalLibraryInternal(GetNormalizedGuids(strProjectTypeGuids));
		}

		public static string GetProjectExtensionProperty(string strProjectPath, string strPropertyName)
		{
			string result = null;
			XPathDocument xPathDocument = new XPathDocument(strProjectPath);
			if (xPathDocument == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
				if (xPathNavigator == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					XPathNavigator xPathNavigator2 = xPathNavigator.SelectSingleNode($"x:Project/x:ProjectExtensions/x:VisualWebGui/x:Properties/x:{strPropertyName}", new QC());
					if (xPathNavigator2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result = xPathNavigator2.Value;
					}
				}
			}
			return result;
		}

		public static string GetProjectGuids(string strProjectPath)
		{
			string text = null;
			XPathDocument xPathDocument = new XPathDocument(strProjectPath);
			if (xPathDocument == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
				if (xPathNavigator != null)
				{
					XPathNavigator xPathNavigator2 = xPathNavigator.SelectSingleNode("x:Project/x:PropertyGroup/x:ProjectTypeGuids", new QC());
					if (xPathNavigator2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text = xPathNavigator2.Value;
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!strProjectPath.ToLowerInvariant().EndsWith(".vbproj"))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!strProjectPath.ToLowerInvariant().EndsWith(".csproj"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text = "{fae04ec0-301f-11d3-bf4b-00c04f79efbc}";
				}
			}
			else
			{
				text = "{f184b08f-c81c-45f6-a57f-5abd9991f28f}";
			}
			return text;
		}

		private static string GetProjectOutputType(string strProjectPath)
		{
			string result = null;
			XPathDocument xPathDocument = new XPathDocument(strProjectPath);
			if (xPathDocument == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
				if (xPathNavigator == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					XPathNavigator xPathNavigator2 = xPathNavigator.SelectSingleNode("x:Project/x:PropertyGroup/x:OutputType", new QC());
					if (xPathNavigator2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result = xPathNavigator2.Value;
					}
				}
			}
			return result;
		}

		private static bool ShouldUpgradeProjectImportsInternal(string strProjectPath)
		{
			XPathDocument xPathDocument = new XPathDocument(strProjectPath);
			if (xPathDocument == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
				if (xPathNavigator == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (xPathNavigator.SelectSingleNode("x:Project/x:Import[contains(@Project, '\\Gizmox.VWGApplication.targets')]", new QC()) != null)
					{
						return false;
					}
					/*OpCode not supported: LdMemberToken*/;
					if (xPathNavigator.SelectSingleNode("x:Project/x:Import[contains(@Project, '\\Gizmox.VWGLibrary.targets')]", new QC()) != null)
					{
						return false;
					}
				}
			}
			return true;
		}

		private static string UpgradeProjectTypeGuidsInternal(string strProjectTypeGuids, string strOutputType)
		{
			if (!IsLibraryProjectInternal(strProjectTypeGuids, strOutputType))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsApplicationProject(strProjectTypeGuids))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!IsCommunityApplicationInternal(strProjectTypeGuids))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						strProjectTypeGuids = RemoveCommunityApplicationGuidInternal(strProjectTypeGuids);
					}
					if (IsProfesionalApplicationInternal(strProjectTypeGuids))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						strProjectTypeGuids = AddProfesionalApplicationGuidInternal(strProjectTypeGuids);
					}
				}
			}
			else
			{
				if (IsCommunityLibraryInternal(strProjectTypeGuids))
				{
					strProjectTypeGuids = RemoveCommunityLibraryGuidInternal(strProjectTypeGuids);
				}
				if (!IsProfesionalLibraryInternal(strProjectTypeGuids))
				{
					strProjectTypeGuids = AddProfesionalLibraryInternal(strProjectTypeGuids);
				}
			}
			return strProjectTypeGuids;
		}

		private static string AddProfesionalApplicationGuidInternal(string strProjectTypeGuids)
		{
			return AddGuidInternal(strProjectTypeGuids, "563295b5-8906-4a76-be2d-ff8e711c1204");
		}

		private static string RemoveCommunityApplicationGuidInternal(string strProjectTypeGuids)
		{
			return RemoveGuidInternal(strProjectTypeGuids, "f5ed058f-53ad-4941-a0b0-20df0ece52fd");
		}

		private static string AddCommunityApplicationGuidInternal(string strProjectTypeGuids)
		{
			return AddGuidInternal(strProjectTypeGuids, "f5ed058f-53ad-4941-a0b0-20df0ece52fd");
		}

		private static string AddProfesionalLibraryInternal(string strProjectTypeGuids)
		{
			return AddGuidInternal(strProjectTypeGuids, "80d85812-7475-4db8-9a61-dd0ef1ebd354");
		}

		private static string RemoveCommunityLibraryGuidInternal(string strProjectTypeGuids)
		{
			return RemoveGuidInternal(strProjectTypeGuids, "569088d8-91ea-4684-b013-9dbdbb8f40e3");
		}

		private static string AddCommunityLibraryGuidInternal(string strProjectTypeGuids)
		{
			return AddGuidInternal(strProjectTypeGuids, "569088d8-91ea-4684-b013-9dbdbb8f40e3");
		}

		private static string AddGuidInternal(string strProjectTypeGuids, string strGuidToAdd)
		{
			return string.Format("{0};{1}", "{" + strGuidToAdd + "}", strProjectTypeGuids);
		}

		private static string RemoveGuidInternal(string strProjectTypeGuids, string strGuidToRemove)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = strProjectTypeGuids.Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = array[i];
				if (!(text.Trim('{', '}').ToLowerInvariant() != strGuidToRemove.ToLowerInvariant()))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(text);
			}
			return stringBuilder.ToString();
		}

		private static bool ShouldUpgradeProjectTypeGuidsInternal(string strProjectTypeGuids, string strOutputType)
		{
			if (!IsLibraryProjectInternal(strProjectTypeGuids, strOutputType))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsApplicationProject(strProjectTypeGuids))
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return !IsProfesionalApplicationInternal(strProjectTypeGuids);
			}
			return !IsProfesionalLibraryInternal(strProjectTypeGuids);
		}

		private static bool IsApplicationProjectInternal(string strProjectTypeGuids)
		{
			return strProjectTypeGuids.Contains("349c5851-65df-11da-9384-00065b846f21");
		}

		private static bool IsLibraryProjectInternal(string strProjectTypeGuids, string strOutputType)
		{
			if (!(strOutputType == "Library"))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return !strProjectTypeGuids.Contains("349c5851-65df-11da-9384-00065b846f21");
		}

		private static bool IsCommunityApplicationInternal(string strProjectTypeGuids)
		{
			return strProjectTypeGuids.Contains("f5ed058f-53ad-4941-a0b0-20df0ece52fd");
		}

		private static bool IsProfesionalApplicationInternal(string strProjectTypeGuids)
		{
			return strProjectTypeGuids.Contains("563295b5-8906-4a76-be2d-ff8e711c1204");
		}

		private static bool IsCommunityLibraryInternal(string strProjectTypeGuids)
		{
			return strProjectTypeGuids.Contains("569088d8-91ea-4684-b013-9dbdbb8f40e3");
		}

		private static bool IsProfesionalLibraryInternal(string strProjectTypeGuids)
		{
			return strProjectTypeGuids.Contains("80d85812-7475-4db8-9a61-dd0ef1ebd354");
		}

		private static string GetNormalizedGuids(string strProjectGuids)
		{
			if (strProjectGuids != null)
			{
				return strProjectGuids.ToLowerInvariant();
			}
			return string.Empty;
		}
	}
}
