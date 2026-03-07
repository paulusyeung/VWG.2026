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

namespace A
{
	internal class QB : VB
	{
		private readonly CC A;

		private readonly Dictionary<string, int> B = new Dictionary<string, int>();

		private readonly List<AC> C = new List<AC>();

		private AC D;

		private AC[] E;

		private string F;

		private string G;

		private string H;

		private ZB I;

		public override CC TypeResolver => A;

		public override QB Document => this;

		public AC[] Types
		{
			get
			{
				if (E != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					E = C.ToArray();
				}
				return E;
			}
		}

		public AC RootType => D;

		public string ClassNamespace => G;

		public string ClassName => F;

		public string Inherits => H;

		internal QB(ZB objReaderSettings)
		{
			if (objReaderSettings == null)
			{
				throw new ArgumentNullException("objReaderSettings");
			}
			I = objReaderSettings;
			A = new CC();
			foreach (KeyValuePair<string, string> @namespace in objReaderSettings.Namespaces)
			{
				base.Namespaces[@namespace.Key] = new TB(@namespace.Value);
			}
		}

		internal void ResiterType(AC objTypeNode)
		{
			if (D != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (C.Contains(objTypeNode))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				E = null;
				C.Add(objTypeNode);
				return;
			}
			D = objTypeNode;
			VB[] nodes = D.Nodes;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (!(nodes[i] is RB { IsExtendedMember: not false } rB))
				{
					continue;
				}
				if (rB.NodeName == "Class")
				{
					if (rB.Value.Length == 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						string text = (string)rB.Value[0].Value;
						if (string.IsNullOrEmpty(text))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							string[] array = text.Split('.');
							if (array.Length == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								G = string.Join(".", array, 0, array.Length - 1);
								F = array[array.Length - 1];
							}
						}
					}
				}
				if (!(rB.NodeName == "Inherits"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (rB.Value.Length != 0)
				{
					H = (string)rB.Value[0].Value;
				}
			}
			if (string.IsNullOrEmpty(H))
			{
				H = objTypeNode.TypeName;
			}
			if (!string.IsNullOrEmpty(F))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (string.IsNullOrEmpty(I.DefaultClassName))
			{
				/*OpCode not supported: LdMemberToken*/;
				F = $"_{objTypeNode.NodeName}";
			}
			else
			{
				F = I.DefaultClassName;
			}
		}

		internal string GetNewID(AC objTypeNode)
		{
			string result = null;
			Type type = objTypeNode.Type;
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string typeName = GetTypeName(type);
				if (!B.TryGetValue(typeName, out var value))
				{
					/*OpCode not supported: LdMemberToken*/;
					value = 1;
				}
				else
				{
					value++;
				}
				B[typeName] = value;
				result = $"{typeName}{value}";
			}
			return result;
		}

		private static string GetTypeName(Type objType)
		{
			string name = objType.Name;
			return $"{name.Substring(0, 1).ToLowerInvariant()}{name.Substring(1)}";
		}
	}
}
