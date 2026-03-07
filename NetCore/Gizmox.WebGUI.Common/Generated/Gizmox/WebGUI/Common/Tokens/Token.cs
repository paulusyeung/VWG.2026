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

namespace Gizmox.WebGUI.Common.Tokens
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Token
	{
		private TokenType A;

		private string B;

		private int C;

		private int D;

		private int E;

		private TokenContext F;

		public TokenType Type => A;

		public string Content => B;

		public int Index
		{
			get
			{
				return C;
			}
			internal set
			{
				C = value;
			}
		}

		public int LineNumber
		{
			get
			{
				return E;
			}
			internal set
			{
				E = value;
			}
		}

		public int Length => B.Length;

		public TokenContext Context => F;

		public virtual TokenReader SubTokens => null;

		public bool HasSubTokens => SubTokens != null;

		internal virtual bool FormatedReferencesEnabled
		{
			get
			{
				if (SubTokens == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return SubTokens.FormatedReferencesEnabled;
			}
			set
			{
				if (SubTokens == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					SubTokens.FormatedReferencesEnabled = value;
				}
			}
		}

		internal Color BackColor
		{
			get
			{
				TokenType a = A;
				if (a > TokenType.Whitespace)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (a)
					{
					case TokenType.JQTFunctionDeclatation:
						/*OpCode not supported: LdMemberToken*/;
						break;
					case TokenType.JQTFunctionReference:
						/*OpCode not supported: LdMemberToken*/;
						break;
					case TokenType.XsltTemplateDefinition:
					case TokenType.XsltTemplateReference:
					case TokenType.XsltParamDefinition:
					case TokenType.XsltVariableDefinition:
					case TokenType.XsltMemberReference:
					case TokenType.JsIdentifier:
					case TokenType.JsFunctionDeclatation:
					case TokenType.JsVariableDeclatation:
					case TokenType.JsFunctionArgument:
						break;
					default:
						goto IL_00e6;
					}
				}
				else
				{
					switch (a)
					{
					case TokenType.Whitespace:
						/*OpCode not supported: LdMemberToken*/;
						return Color.LightGray;
					case TokenType.SkinPlaceHolder:
					case TokenType.LabelPlaceHolder:
					case TokenType.ContextPlaceHolder:
					case TokenType.AttributePlaceHolder:
					case TokenType.EventPlaceHolder:
					case TokenType.TagPlaceHolder:
					case TokenType.UrlExtension:
						return Color.Yellow;
					case TokenType.CssClassDefinition:
					case TokenType.CssClassReference:
						break;
					default:
						goto IL_00e6;
					}
				}
				return Color.Yellow;
				IL_00e6:
				return Color.Empty;
			}
		}

		internal Color ForeColor
		{
			get
			{
				switch (A)
				{
				case TokenType.JsOperator:
					return Color.Purple;
				case TokenType.Comment:
					return Color.Green;
				case TokenType.XmlAttributeValue:
					return Color.Blue;
				case TokenType.XmlOpenTag:
				case TokenType.XmlCloseTag:
				case TokenType.XmlCloseTagEnd:
				case TokenType.XmlFullOpenTagEnd:
				case TokenType.XmlOpenTagEnd:
					return Color.Blue;
				case TokenType.CssStyleValue:
				case TokenType.XmlAttributeName:
					return Color.Red;
				case TokenType.CssStyleName:
				case TokenType.XmlTagName:
					return Color.Brown;
				case TokenType.XmlProcessingInstruction:
					return Color.Purple;
				case TokenType.SkinPlaceHolder:
				case TokenType.LabelPlaceHolder:
				case TokenType.ContextPlaceHolder:
				case TokenType.AttributePlaceHolder:
				case TokenType.EventPlaceHolder:
				case TokenType.TagPlaceHolder:
					return Color.DeepPink;
				case TokenType.CssClassDefinition:
				case TokenType.CssClassReference:
				case TokenType.CssTagNameSelector:
				case TokenType.CssIdentifier:
				case TokenType.XsltTemplateDefinition:
				case TokenType.XsltTemplateReference:
				case TokenType.XsltParamDefinition:
				case TokenType.XsltVariableDefinition:
				case TokenType.XsltMemberReference:
				case TokenType.JsIdentifier:
				case TokenType.JsFunctionDeclatation:
				case TokenType.JsVariableDeclatation:
				case TokenType.JsFunctionArgument:
				case TokenType.JsKeyword:
				case TokenType.JQTFunctionDeclatation:
				case TokenType.JQTFunctionReference:
					return Color.Blue;
				case TokenType.UrlExtension:
				case TokenType.JsString:
					return Color.Brown;
				case TokenType.JsRegularExpression:
					return Color.Cyan;
				default:
					return Color.Empty;
				}
			}
		}

		internal Token(TokenContext objContext, TokenType enmType, string strContent)
		{
			Init(objContext, enmType, strContent);
		}

		internal void Init(TokenContext objContext, TokenType enmType, string strContent)
		{
			A = enmType;
			B = strContent;
			F = objContext;
		}

		internal void Concat(Token objToken)
		{
			D += objToken.Length;
			B += objToken.Content;
		}

		public override string ToString()
		{
			return ToString(0);
		}

		public string ToString(int intOffset)
		{
			if (Context != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return $"{Type},Index={Index + intOffset},Length={Length},Line={LineNumber},Context={Context}";
			}
			return $"{Type},Index={Index + intOffset},Length={Length},Line={LineNumber}";
		}
	}
}
