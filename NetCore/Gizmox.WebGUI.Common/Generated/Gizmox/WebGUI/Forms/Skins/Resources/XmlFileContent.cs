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

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class XmlFileContent : TextContent
	{
		[NonSerialized]
		private int A;

		[NonSerialized]
		private int B;

		public XmlFileContent(Stream objStream)
			: base(objStream)
		{
		}

		protected override void LoadProperties(Stream objStream)
		{
			base.LoadProperties(objStream);
			StringBuilder stringBuilder = new StringBuilder();
			IDictionary<string, string> dictionary = LoadNamespaces(objStream);
			if (dictionary == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IEnumerator<KeyValuePair<string, string>> enumerator = dictionary.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						KeyValuePair<string, string> current = enumerator.Current;
						if (stringBuilder.Length <= 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							stringBuilder.Append("&");
						}
						stringBuilder.Append(HttpUtility.UrlEncode(current.Key));
						stringBuilder.Append("=");
						stringBuilder.Append(HttpUtility.UrlEncode(current.Value));
					}
				}
				finally
				{
					if (enumerator == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enumerator.Dispose();
					}
				}
			}
			WriteProperty(FileProperty.Namespaces, stringBuilder.ToString());
		}

		private IDictionary<string, string> LoadNamespaces(Stream objStream)
		{
			ResetStreamPositionIfNeeded(objStream);
			XPathNavigator xPathNavigator = new XPathDocument(objStream).CreateNavigator();
			xPathNavigator.MoveToChild(XPathNodeType.Element);
			return xPathNavigator.GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);
		}

		protected override void LoadIndexes(Stream objStream)
		{
			base.LoadIndexes(objStream);
		}

		protected override void LoadIndex(TokenType enmTokenType, string strTokenContent, int intTokenIndex, int intTokenLength, int intTokenLine, TokenContext objTokenContext)
		{
			base.LoadIndex(enmTokenType, strTokenContent, intTokenIndex, intTokenLength, intTokenLine, objTokenContext);
		}

		protected override TokenReader CreateTokenReader(Stream objStream)
		{
			return new XmlTokenReader(null, objStream);
		}

		protected bool LoadRootIndex(TokenType enmTokenType, int intTokenIndex, int intTokenLength)
		{
			int a = A;
			if (enmTokenType != TokenType.XmlOpenTagEnd)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (enmTokenType != TokenType.XmlCloseTag)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					A--;
				}
			}
			else
			{
				A++;
			}
			if (a != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (A == 1)
			{
				WriteIndex(FileIndexType.XmlRoot, 0, intTokenIndex + intTokenLength);
				goto IL_00e2;
			}
			if (a != 1)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (A == 0)
				{
					B = intTokenIndex;
					goto IL_00e2;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (A != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (enmTokenType == TokenType.XmlCloseTagEnd)
			{
				if (B > 0)
				{
					WriteIndex(FileIndexType.XmlRoot, B, intTokenIndex - B + intTokenLength);
				}
				goto IL_00e2;
			}
			if (A <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_00e2;
			}
			return false;
			IL_00e2:
			return true;
		}
	}
}
