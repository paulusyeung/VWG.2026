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

namespace Gizmox.WebGUI.Common.Tokens.Xslt
{
	public class XsltTokenReader : XmlTokenReader
	{
		public XsltTokenReader(TokenContext objTokenContext, TextReader objSource)
			: base(objTokenContext, objSource)
		{
		}

		public XsltTokenReader(TokenContext objTokenContext, Stream objSource)
			: base(objTokenContext, objSource)
		{
		}

		public XsltTokenReader(TokenContext objTokenContext, string objSource)
			: base(objTokenContext, objSource)
		{
		}

		protected override Token ReadTagContentToken(string strTagName, NameValueCollection objAttributes, string strTagContent)
		{
			return new XsltContentToken(base.CurrentContext, TokenType.XmlTagContent, strTagContent);
		}

		protected override Token ReadAttributeValueToken(string strAttributeName, string strAttributeValue)
		{
			if (!(base.CurrentContext is XmlTokenContext xmlTokenContext))
			{
				/*OpCode not supported: LdMemberToken*/;
				return base.ReadAttributeValueToken(strAttributeName, strAttributeValue);
			}
			if (!(strAttributeName == "name"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (xmlTokenContext.TagName == "xsl:template")
				{
					return new XsltNameAttributeToken(xmlTokenContext, TokenType.XsltTemplateDefinition, strAttributeValue);
				}
				if (xmlTokenContext.TagName == "xsl:call-template")
				{
					return new XsltNameAttributeToken(xmlTokenContext, TokenType.XsltTemplateReference, strAttributeValue);
				}
				/*OpCode not supported: LdMemberToken*/;
				if (xmlTokenContext.TagName == "xsl:param")
				{
					return new XsltNameAttributeToken(xmlTokenContext, TokenType.XsltParamDefinition, strAttributeValue);
				}
				/*OpCode not supported: LdMemberToken*/;
				if (xmlTokenContext.TagName == "xsl:variable")
				{
					return new XsltNameAttributeToken(xmlTokenContext, TokenType.XsltVariableDefinition, strAttributeValue);
				}
				/*OpCode not supported: LdMemberToken*/;
				if (xmlTokenContext.TagName == "xsl:with-param")
				{
					return new XsltNameAttributeToken(xmlTokenContext, TokenType.XsltMemberReference, strAttributeValue);
				}
			}
			return new XsltAttributeToken(xmlTokenContext, TokenType.XmlAttributeValue, strAttributeValue);
		}

		protected override Token ReadToken()
		{
			Token token = null;
			char currentCharecter = base.CurrentCharecter;
			if (!IsStartMigrationWriteOpenTag(currentCharecter))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (IsStartMigrationIgnoreTag(currentCharecter))
				{
					return CreateToken(base.CurrentContext, TokenType.XsltMigrationNode, ReadMigrationIgnoreNode());
				}
				if (!IsInOpenTag())
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (IsStartMigrationAttribute(currentCharecter))
				{
					return CreateToken(base.CurrentContext, TokenType.XsltMigrationAttribute, ReadMigrationAttribute());
				}
				return base.ReadToken();
			}
			return CreateToken(base.CurrentContext, TokenType.XsltMigrationNode, ReadMigrationWriteNode());
		}

		private string ReadMigrationIgnoreNode()
		{
			if (PeekString(19) == "</migration-ignore>")
			{
				return Read(19);
			}
			int i;
			for (i = 17; PeekAtOffset(i) != '>'; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i + 1);
		}

		private bool IsStartMigrationIgnoreTag(char chrCurrent)
		{
			if (PeekString(17) == "<migration-ignore")
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return PeekString(19) == "</migration-ignore>";
		}

		private string ReadMigrationAttribute()
		{
			int intLength = 10;
			int num = 0;
			while (num < 2)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (PeekAtOffset(intLength++) != '"')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					num++;
				}
			}
			return Read(intLength);
		}

		private bool IsStartMigrationAttribute(char chrCurrent)
		{
			if (!IsStartAttribute(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return PeekString(10) == "migration-";
		}

		private string ReadMigrationWriteNode()
		{
			int i;
			for (i = 17; PeekString(i, 18) != "</migration-write>"; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i + 18);
		}

		private bool IsStartMigrationWriteOpenTag(char chrCurrent)
		{
			return PeekString(16) == "<migration-write";
		}
	}
}
