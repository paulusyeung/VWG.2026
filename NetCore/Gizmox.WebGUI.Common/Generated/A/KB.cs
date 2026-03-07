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
	internal class KB : MB
	{
		[Serializable]
		internal class ReadOnlyMembersCollection : NameValueCollection
		{
			public ReadOnlyMembersCollection(NameValueCollection objMembers)
				: base(objMembers)
			{
				base.IsReadOnly = true;
			}
		}

		private MB A;

		private readonly string B;

		private NameValueCollection C;

		private NameValueCollection D;

		private NameValueCollection E;

		LB MB.Variables => Variables;

		public virtual LB Variables
		{
			get
			{
				if (Parent == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return Parent.Variables;
			}
		}

		protected virtual bool IsCodeScope => false;

		public ReadOnlyMembersCollection ScriptMembers
		{
			get
			{
				if (D != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new ReadOnlyMembersCollection(D);
				}
				return null;
			}
		}

		public ReadOnlyMembersCollection CssMembers
		{
			get
			{
				if (C != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new ReadOnlyMembersCollection(C);
				}
				return null;
			}
		}

		public ReadOnlyMembersCollection XsltMembers
		{
			get
			{
				if (E != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new ReadOnlyMembersCollection(E);
				}
				return null;
			}
		}

		public MB Parent => A;

		public virtual string ID => B;

		public virtual MB Global
		{
			get
			{
				if (A == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return A.Global;
			}
		}

		public virtual bool IsGlobal => false;

		public KB()
		{
			B = string.Empty;
		}

		public KB(int intID)
		{
			B = GenerateID(intID);
		}

		void MB.RegisterGlobalResource(FileIndexType enmMemberType, string strMember, CompilerActions enmCompilerActions)
		{
			RegisterGlobalResource(enmMemberType, strMember, enmCompilerActions);
		}

		protected void RegisterGlobalResource(FileIndexType enmMemberType, string strMember, CompilerActions enmCompilerActions)
		{
			if (!SkinFactory.IsCompilerEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(Global is GlobalScope globalScope))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((MB)globalScope).RegisterResource(enmMemberType, strMember, enmCompilerActions);
			}
		}

		void MB.RegisterResource(FileIndexType enmMemberType, string strMember, CompilerActions enmCompilerActions)
		{
			RegisterResource(enmMemberType, strMember, enmCompilerActions);
		}

		protected void RegisterResource(FileIndexType enmMemberType, string strMember, CompilerActions enmCompilerActions)
		{
			if (!SkinFactory.IsCompilerEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (enmMemberType > FileIndexType.ScriptVariableDeclatation)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (enmMemberType)
				{
				case FileIndexType.CssClassDefinition:
					/*OpCode not supported: LdMemberToken*/;
					RegisterCssMember(GetClassNamePart(strMember), enmCompilerActions);
					return;
				case FileIndexType.XsltTemplateDefinition:
					/*OpCode not supported: LdMemberToken*/;
					RegisterXsltMember(strMember, enmCompilerActions);
					return;
				default:
					return;
				case FileIndexType.JQTFunctionDeclatation:
					break;
				}
			}
			else
			{
				if (enmMemberType != FileIndexType.ScriptFunctionDeclatation)
				{
					switch (enmMemberType)
					{
					case FileIndexType.ScriptFunctionArgument:
						/*OpCode not supported: LdMemberToken*/;
						break;
					default:
						return;
					case FileIndexType.ScriptVariableDeclatation:
						break;
					}
					if (!IsGlobal)
					{
						/*OpCode not supported: LdMemberToken*/;
						RegisterGlobalResource(enmMemberType, strMember, enmCompilerActions);
					}
					else
					{
						RegisterScriptMember(strMember, enmCompilerActions);
					}
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			RegisterScriptMember(strMember, enmCompilerActions);
		}

		string MB.GetMemberValue(FileIndexType enmMemberType, string strMember)
		{
			return GetMemberValue(enmMemberType, strMember);
		}

		protected virtual string GetMemberValue(FileIndexType enmMemberType, string strMember)
		{
			switch (enmMemberType)
			{
			default:
				/*OpCode not supported: LdMemberToken*/;
				break;
			case FileIndexType.ScriptFunctionDeclatation:
			case FileIndexType.ScriptFunctionArgument:
			case FileIndexType.ScriptIdentifier:
			case FileIndexType.ScriptVariableDeclatation:
			case FileIndexType.JQTFunctionDeclatation:
			case FileIndexType.JQTFunctionReference:
				return GetScriptMemberValue(strMember);
			case FileIndexType.CssClassReference:
			case FileIndexType.CssClassDefinition:
				return GetCssMemberValue(GetClassNamePart(strMember), GetClassStatePart(strMember));
			case FileIndexType.XsltTemplateDefinition:
			case FileIndexType.XsltTemplateReference:
				return GetXsltMemberValue(strMember);
			case FileIndexType.XmlRoot:
			case FileIndexType.ScriptMissingSemicolon:
			case FileIndexType.XsltMemberReference:
			case FileIndexType.XsltParamDefinition:
				break;
			}
			return strMember;
		}

		private string GetXsltMemberValue(string strMember)
		{
			if (E == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string text = E[strMember];
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(Parent is KB kB))
			{
				/*OpCode not supported: LdMemberToken*/;
				return strMember;
			}
			return kB.GetXsltMemberValue(strMember);
		}

		protected string GetCssMemberValue(string strMember, string strState)
		{
			if (C == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string text = C[strMember];
				if (!string.IsNullOrEmpty(text))
				{
					if (string.IsNullOrEmpty(strState))
					{
						/*OpCode not supported: LdMemberToken*/;
						return text;
					}
					return $"{text}_{strState}";
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(Parent is KB kB))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (string.IsNullOrEmpty(strState))
				{
					/*OpCode not supported: LdMemberToken*/;
					return strMember;
				}
				return $"{strMember}_{strState}";
			}
			return kB.GetCssMemberValue(strMember, strState);
		}

		protected string GetScriptMemberValue(string strMember)
		{
			if (D != null)
			{
				string text = D[strMember];
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (Parent is KB kB)
			{
				return kB.GetScriptMemberValue(strMember);
			}
			return strMember;
		}

		private void RegisterMember(NameValueCollection objMembers, string strPrefix, string strMember, CompilerActions enmCompilerActions)
		{
			if (objMembers[strMember] != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string value = strMember;
			if (!ConfigHelper.IsObscuringEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if ((enmCompilerActions & CompilerActions.ApplyObscuring) == CompilerActions.ApplyObscuring)
				{
					value = $"{strPrefix}{ID}{objMembers.Count + 1}";
					goto IL_010c;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (IsCodeScope)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				SortedList<string, bool> nonObscuredScopingCache = GetNonObscuredScopingCache();
				if (nonObscuredScopingCache == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!nonObscuredScopingCache.ContainsKey(strMember))
				{
					/*OpCode not supported: LdMemberToken*/;
					lock (nonObscuredScopingCache)
					{
						if (!nonObscuredScopingCache.ContainsKey(strMember))
						{
							/*OpCode not supported: LdMemberToken*/;
							nonObscuredScopingCache.Add(strMember, value: true);
						}
						else
						{
							value = $"{strMember}_{ID}";
						}
					}
				}
				else
				{
					value = $"{strMember}_{ID}";
				}
			}
			goto IL_010c;
			IL_010c:
			objMembers[strMember] = value;
		}

		private SortedList<string, bool> GetNonObscuredScopingCache()
		{
			if (!(Global is GlobalScope globalScope))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return globalScope.NonObscuredScopingCache;
		}

		private void RegisterXsltMember(string strMember, CompilerActions enmCompilerActions)
		{
			if (E == null)
			{
				E = new NameValueCollection();
			}
			RegisterMember(E, "x", strMember, enmCompilerActions);
		}

		private void RegisterScriptMember(string strMember, CompilerActions enmCompilerActions)
		{
			if (D != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				D = new NameValueCollection();
			}
			RegisterMember(D, "s", strMember, enmCompilerActions);
		}

		private void RegisterCssMember(string strMember, CompilerActions enmCompilerActions)
		{
			if (C == null)
			{
				C = new NameValueCollection();
			}
			RegisterMember(C, "c", GetClassNamePart(strMember), enmCompilerActions);
		}

		protected string GetClassNamePart(string strMember)
		{
			int num = strMember.IndexOf('_');
			if (num <= -1)
			{
				/*OpCode not supported: LdMemberToken*/;
				return strMember;
			}
			return strMember.Substring(0, num);
		}

		protected string GetClassStatePart(string strMember)
		{
			int num = strMember.IndexOf('_');
			if (num <= -1)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return strMember.Substring(num + 1);
		}

		internal void SetParent(KB objScopeParent)
		{
			A = objScopeParent;
		}

		private string GenerateID(int intScopeID)
		{
			if (intScopeID <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			string text = "";
			int num = 0;
			int num2 = intScopeID;
			while (true)
			{
				num = num2 % 26;
				num2 /= 26;
				text = Convert.ToChar(97 + num) + text;
				if (num2 == 0)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return text;
		}
	}
}
