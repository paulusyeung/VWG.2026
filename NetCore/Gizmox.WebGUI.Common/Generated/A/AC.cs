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
	internal class AC : VB
	{
		private Type AB;

		private string BB = string.Empty;

		private bool CB;

		public string FullTypeName
		{
			get
			{
				TB tB = base.Namespace;
				if (tB == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return $"{tB.Namespace}.{base.NodeName}, {tB.Assembly}";
			}
		}

		public string TypeName
		{
			get
			{
				TB tB = base.Namespace;
				if (tB == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return $"{tB.Namespace}.{base.NodeName}";
			}
		}

		public Type Type
		{
			get
			{
				if (AB == null)
				{
					AB = TypeResolver.GetType(this);
				}
				return AB;
			}
		}

		public string ID => BB;

		public bool GenerateMember => CB;

		public bool GenerateSuspendLayout
		{
			get
			{
				Type type = Type;
				if (!(type != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					while (type != null)
					{
						if (!(type.Name == "ScrollableControl"))
						{
							/*OpCode not supported: LdMemberToken*/;
							type = type.BaseType;
							continue;
						}
						return true;
					}
				}
				return false;
			}
		}

		public bool ImplementsIAddChild
		{
			get
			{
				Type type = Type;
				if (!(type != null))
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return typeof(IAddChild).IsAssignableFrom(type);
			}
		}

		public RB[] Members
		{
			get
			{
				List<RB> list = new List<RB>();
				IEnumerator<VB> enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(enumerator.Current is RB item))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(item);
						}
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
				return list.ToArray();
			}
		}

		public AC[] Children
		{
			get
			{
				List<AC> list = new List<AC>();
				IEnumerator<VB> enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(enumerator.Current is AC item))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(item);
						}
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
				return list.ToArray();
			}
		}

		internal AC(VB objParentNode, XmlTextReader objReader)
			: base(objParentNode, objReader)
		{
		}

		protected override void OnIntializing(QB objDocument)
		{
			base.OnIntializing(objDocument);
			if (!string.IsNullOrEmpty(BB))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				BB = GetNewIDFromName();
				if (!string.IsNullOrEmpty(BB))
				{
					CB = true;
				}
				else
				{
					BB = objDocument.GetNewID(this);
					CB = false;
				}
			}
			objDocument.ResiterType(this);
		}

		public override string ToString()
		{
			return $"Type:{FullTypeName}";
		}

		protected override WB GetState(XamlParseExceptionCollection objExceptions, bool blnThrowOnValidation)
		{
			Type type = Type;
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				XamlParseException ex = new XamlParseException($"Type '{TypeName}' could not be resolved.", base.LineNumber, base.LinePosition);
				if (!blnThrowOnValidation)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (objExceptions == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						objExceptions.Add(ex);
					}
					return WB.B;
				}
				throw ex;
			}
			if (!TypeResolver.IsCreatable(type))
			{
				/*OpCode not supported: LdMemberToken*/;
				XamlParseException ex2 = new XamlParseException($"Type '{type.FullName}' does not contain a public parameterless constructor.", base.LineNumber, base.LinePosition);
				if (!blnThrowOnValidation)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (objExceptions == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						objExceptions.Add(ex2);
					}
					return WB.B;
				}
				throw ex2;
			}
			return WB.C;
		}

		private string GetNewIDFromName()
		{
			RB[] members = Members;
			for (int i = 0; i < members.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				RB rB = members[i];
				if (rB.State != WB.C || !(rB.MemberName == "Name"))
				{
					continue;
				}
				SB[] value = rB.Value;
				if (value.Length == 1)
				{
					string text = value[0].Value as string;
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return null;
		}
	}
}
