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

namespace Gizmox.WebGUI.Common.Tokens.Xml
{
	public class XmlTokenReader : TokenReader
	{
		private bool R;

		private bool S;

		private bool T;

		private bool U;

		private string V = string.Empty;

		public XmlTokenReader(TokenContext objTokenContext, TextReader objSource)
			: base(objTokenContext, objSource)
		{
		}

		public XmlTokenReader(TokenContext objTokenContext, Stream objSource)
			: base(objTokenContext, objSource)
		{
		}

		public XmlTokenReader(TokenContext objTokenContext, string objSource)
			: base(objTokenContext, objSource)
		{
		}

		public override void Reset()
		{
			base.Reset();
			R = false;
			T = false;
			S = false;
			U = false;
		}

		protected override Token ReadToken()
		{
			char currentCharecter = base.CurrentCharecter;
			Token token = null;
			XmlTokenContext xmlTokenContext = null;
			if (!IsInTagName())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsStartTagContent(currentCharecter))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!IsInCloseTag())
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsInOpenTag())
						{
							/*OpCode not supported: LdMemberToken*/;
							if (IsStartWhitespace(currentCharecter))
							{
								token = CreateToken(base.CurrentContext, TokenType.Whitespace, ReadWhitespace());
							}
							else if (!IsStartDoctype(currentCharecter))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (!IsStartComment(currentCharecter))
								{
									/*OpCode not supported: LdMemberToken*/;
									if (IsStartProcessingInstruction(currentCharecter))
									{
										token = CreateToken(base.CurrentContext, TokenType.XmlProcessingInstruction, ReadProcessingInstruction());
									}
									else if (!IsStartCDATA(currentCharecter))
									{
										/*OpCode not supported: LdMemberToken*/;
										if (!IsStartOpenTag(currentCharecter))
										{
											/*OpCode not supported: LdMemberToken*/;
											if (IsStartCloseTag(currentCharecter))
											{
												token = CreateToken(base.CurrentContext, TokenType.XmlCloseTag, Read(2));
												R = true;
												T = true;
											}
											else
											{
												token = base.ReadToken();
											}
										}
										else
										{
											token = CreateToken(base.CurrentContext, TokenType.XmlOpenTag, Read(1));
											R = true;
											S = true;
										}
									}
									else
									{
										token = CreateToken(base.CurrentContext, TokenType.XmlCData, ReadCDATA());
									}
								}
								else
								{
									token = CreateToken(base.CurrentContext, TokenType.Comment, ReadComment());
								}
							}
							else
							{
								token = CreateToken(base.CurrentContext, TokenType.XmlDocType, ReadDoctype());
							}
						}
						else if (!IsMoreThan(currentCharecter))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (IsFullOpenTagEnd(currentCharecter))
							{
								token = CreateToken(base.CurrentContext, TokenType.XmlFullOpenTagEnd, Read(2));
								S = false;
								base.CurrentContext = base.CurrentContext.Parent;
							}
							else if (IsStartAttribute(currentCharecter))
							{
								token = CreateToken(base.CurrentContext, TokenType.XmlAttributeName, ReadTagOrAttributeName());
								V = token.Content;
								if (base.CurrentContext is XmlTokenContext xmlTokenContext2)
								{
									xmlTokenContext2.LastAttributeName = V;
								}
							}
							else if (U)
							{
								if (!IsWhitespace(currentCharecter))
								{
									/*OpCode not supported: LdMemberToken*/;
									token = ReadAttributeValueToken(V, ReadAttributeValue(currentCharecter));
									if (token == null)
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else if (string.IsNullOrEmpty(V))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										if (!(base.CurrentContext is XmlTokenContext xmlTokenContext3))
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else
										{
											xmlTokenContext3.Attributes[V] = token.Content;
										}
										V = string.Empty;
									}
									U = false;
								}
								else
								{
									token = CreateToken(base.CurrentContext, TokenType.Whitespace, ReadWhitespace());
								}
							}
							else if (!IsEqualSign(currentCharecter))
							{
								/*OpCode not supported: LdMemberToken*/;
								token = ((!IsStartWhitespace(currentCharecter)) ? base.ReadToken() : CreateToken(base.CurrentContext, TokenType.Whitespace, ReadWhitespace()));
							}
							else
							{
								token = CreateToken(base.CurrentContext, TokenType.XmlArrtibuteEqulSign, Read(1));
								U = true;
							}
						}
						else
						{
							token = CreateToken(base.CurrentContext, TokenType.XmlOpenTagEnd, Read(1));
							S = false;
						}
					}
					else if (!IsMoreThan(currentCharecter))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsStartWhitespace(currentCharecter))
						{
							/*OpCode not supported: LdMemberToken*/;
							token = base.ReadToken();
						}
						else
						{
							token = CreateToken(base.CurrentContext, TokenType.Whitespace, ReadWhitespace());
						}
					}
					else
					{
						token = CreateToken(base.CurrentContext, TokenType.XmlCloseTagEnd, Read(1));
						T = false;
						base.CurrentContext = base.CurrentContext.Parent;
					}
				}
				else if (!(base.CurrentContext is XmlTokenContext xmlTokenContext4))
				{
					/*OpCode not supported: LdMemberToken*/;
					token = ReadTagContentToken(string.Empty, new NameValueCollection(), ReadTagContent());
				}
				else
				{
					token = ReadTagContentToken(xmlTokenContext4.TagName, xmlTokenContext4.Attributes, ReadTagContent());
				}
			}
			else
			{
				token = CreateToken(base.CurrentContext, TokenType.XmlTagName, ReadTagOrAttributeName());
				if (S)
				{
					base.CurrentContext = new XmlTokenContext(base.CurrentContext, token.Content);
				}
				R = false;
			}
			return token;
		}

		protected virtual Token ReadAttributeValueToken(string strAttributeName, string strAttributeValue)
		{
			return new XmlAttributeToken(base.CurrentContext, TokenType.XmlAttributeValue, strAttributeValue);
		}

		protected virtual Token ReadTagContentToken(string strTagName, NameValueCollection objAttributes, string strTagContent)
		{
			return new XmlContentToken(base.CurrentContext, TokenType.XmlTagContent, strTagContent);
		}

		protected override bool IsPreWhitespace(char chrValue)
		{
			if (chrValue != '>')
			{
				/*OpCode not supported: LdMemberToken*/;
				return IsWhitespace(chrValue);
			}
			return true;
		}

		private string ReadTagContent()
		{
			int num = 1;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndTagContent(num))
				{
					break;
				}
				num++;
			}
			return Read(num);
		}

		private string ReadComment()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndComment(num))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			num++;
			return Read(num);
		}

		private string ReadDoctype()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndDoctype(num))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			num++;
			return Read(num);
		}

		private string ReadAttributeValue(char chrCurrent)
		{
			int num = 1;
			bool flag = IsAttributeValueQuote(chrCurrent);
			bool flag2 = !IsSpace(0);
			int num2;
			if (flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				num2 = chrCurrent;
			}
			else
			{
				num2 = 0;
			}
			char c = (char)num2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (!flag && IsMoreThan(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsFullOpenTagEnd(num))
				{
					break;
				}
				char c2 = PeekAtOffset(num);
				if (flag)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (c2 == c)
					{
						num++;
						break;
					}
				}
				else if (!IsAttributeValueQuote(c2))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!flag2)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (IsSpace(c))
						{
							num--;
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					int num3;
					if (flag2)
					{
						/*OpCode not supported: LdMemberToken*/;
						num3 = 1;
					}
					else
					{
						num3 = ((!IsSpace(num)) ? 1 : 0);
					}
					flag2 = (byte)num3 != 0;
				}
				else
				{
					c = c2;
					flag = true;
				}
				num++;
			}
			return Read(num);
		}

		private bool IsSpace(int intOffset)
		{
			return IsSpace(PeekAtOffset(intOffset));
		}

		private bool IsSpace(char chrCurrent)
		{
			return IsWhitespace(chrCurrent, blnExcludeNewLine: true);
		}

		private bool IsAttributeValueQuote(char chrCurrent)
		{
			if (chrCurrent != '"')
			{
				return chrCurrent == '\'';
			}
			return true;
		}

		private string ReadTagOrAttributeName()
		{
			int i;
			for (i = 1; !IsEndOfFileOffset(i) && IsValidNameLetter(PeekAtOffset(i)); i++)
			{
			}
			return Read(i);
		}

		private string ReadCDATA()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndCDATA(num))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			num++;
			return Read(num);
		}

		private string ReadProcessingInstruction()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndProcessingInstruction(num))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			num++;
			return Read(num);
		}

		private bool IsEndTagContent(int intOffset)
		{
			return IsLessThan(PeekAtOffset(intOffset));
		}

		private bool IsStartTagContent(char chrCurrent)
		{
			if (IsInCloseTag())
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (IsInOpenTag())
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!IsLessThan(chrCurrent))
			{
				return IsMoreThan(PeekAtOffset(-1));
			}
			return false;
		}

		private bool IsInCloseTag()
		{
			return T;
		}

		private bool IsEqualSign(char chrCurrent)
		{
			return chrCurrent == '=';
		}

		protected bool IsInOpenTag()
		{
			return S;
		}

		protected bool IsStartAttribute(char chrCurrent)
		{
			if (!IsValidNameStartLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return true;
		}

		private bool IsStartOpenTag(char chrCurrent)
		{
			if (!IsLessThan(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (IsValidNameStartLetter(PeekAtOffset(1)))
			{
				return true;
			}
			return false;
		}

		private bool IsInTagName()
		{
			return R;
		}

		private bool IsValidNameStartLetter(char chrCurrent)
		{
			if (char.IsLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrCurrent == '_';
		}

		private bool IsValidNameLetter(char chrCurrent)
		{
			if (!IsValidNameStartLetter(chrCurrent))
			{
				if (char.IsDigit(chrCurrent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					switch (chrCurrent)
					{
					case ':':
						/*OpCode not supported: LdMemberToken*/;
						break;
					case '-':
						/*OpCode not supported: LdMemberToken*/;
						break;
					default:
						return chrCurrent == '.';
					}
				}
			}
			return true;
		}

		private bool IsEndCDATA(int intOffset)
		{
			if (!IsMoreThan(PeekAtOffset(intOffset)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekString(intOffset - 2, 3) == "]]>")
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsStartComment(char chrCurrent)
		{
			if (!IsLessThan(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekString(4) == "<!--")
			{
				return true;
			}
			return false;
		}

		private bool IsEndComment(int intOffset)
		{
			if (!IsMoreThan(PeekAtOffset(intOffset)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekString(intOffset - 2, 3) == "-->")
			{
				return true;
			}
			return false;
		}

		private bool IsStartCDATA(char chrCurrent)
		{
			if (!IsLessThan(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekString(9) == "<![CDATA[")
			{
				return true;
			}
			return false;
		}

		private bool IsStartCloseTag(char chrCurrent)
		{
			if (!IsLessThan(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekAtOffset(1) == '/')
			{
				return true;
			}
			return false;
		}

		private bool IsFullOpenTagEnd(int intOffset)
		{
			if (PeekAtOffset(intOffset) != '/')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (IsMoreThan(PeekAtOffset(intOffset + 1)))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsFullOpenTagEnd(char chrCurrent)
		{
			if (chrCurrent == '/' && IsMoreThan(PeekAtOffset(1)))
			{
				return true;
			}
			return false;
		}

		private bool IsEndDoctype(int intOffset)
		{
			return IsMoreThan(PeekAtOffset(intOffset));
		}

		private bool IsStartDoctype(char chrCurrent)
		{
			if (IsLessThan(chrCurrent))
			{
				if (PeekString(9) == "<!DOCTYPE")
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsEndProcessingInstruction(int intOffset)
		{
			if (!IsMoreThan(PeekAtOffset(intOffset)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekAtOffset(intOffset - 1) == '?')
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsStartProcessingInstruction(char chrCurrent)
		{
			if (!IsLessThan(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekAtOffset(1) == '?')
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsLessThan(char chrCurrent)
		{
			return chrCurrent == '<';
		}

		private bool IsMoreThan(int intOffset)
		{
			return IsMoreThan(PeekAtOffset(intOffset));
		}

		private bool IsMoreThan(char chrCurrent)
		{
			return chrCurrent == '>';
		}
	}
}
