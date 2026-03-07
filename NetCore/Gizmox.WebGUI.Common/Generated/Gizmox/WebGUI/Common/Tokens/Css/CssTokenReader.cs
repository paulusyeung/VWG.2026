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

namespace Gizmox.WebGUI.Common.Tokens.Css
{
	public class CssTokenReader : TokenReader
	{
		private bool KB;

		public CssTokenReader(TokenContext objTokenContext, TextReader objSource)
			: base(objTokenContext, objSource)
		{
		}

		public CssTokenReader(TokenContext objTokenContext, Stream objSource)
			: base(objTokenContext, objSource)
		{
		}

		public CssTokenReader(TokenContext objTokenContext, string objSource)
			: base(objTokenContext, objSource)
		{
		}

		protected override Token ReadToken()
		{
			char currentCharecter = base.CurrentCharecter;
			Token token = null;
			if (!IsStartCssValue())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsStartSkinPlaceholder(currentCharecter))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (IsImportStart(currentCharecter))
					{
						return CreateToken(base.CurrentContext, TokenType.CssImport, ReadImport());
					}
					if (!IsStartWhitespace(currentCharecter))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (IsStartBlockComment(currentCharecter))
						{
							return CreateToken(base.CurrentContext, TokenType.Comment, ReadBlockComment());
						}
						if (!IsClassDot(currentCharecter))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (IsPoundKey(currentCharecter))
							{
								return CreateToken(base.CurrentContext, TokenType.CssPoundKey, Read(1));
							}
							if (!IsStartIdentifier(currentCharecter))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (IsStartClassBlock(currentCharecter))
								{
									KB = true;
									return CreateToken(base.CurrentContext, TokenType.CssStartBlock, Read(1));
								}
								if (!IsEndClassBlock(currentCharecter))
								{
									/*OpCode not supported: LdMemberToken*/;
									if (!IsSemicolomn(currentCharecter))
									{
										/*OpCode not supported: LdMemberToken*/;
										if (!IsColon(currentCharecter))
										{
											/*OpCode not supported: LdMemberToken*/;
											return base.ReadToken();
										}
										return CreateToken(base.CurrentContext, TokenType.CssColon, Read(1));
									}
									return CreateToken(base.CurrentContext, TokenType.CssSemiColon, Read(1));
								}
								KB = false;
								return CreateToken(base.CurrentContext, TokenType.CssEndBlock, Read(1));
							}
							if (!KB)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (!IsClassName())
								{
									/*OpCode not supported: LdMemberToken*/;
									if (!IsElementID())
									{
										/*OpCode not supported: LdMemberToken*/;
										if (!IsTagName())
										{
											/*OpCode not supported: LdMemberToken*/;
											return CreateToken(base.CurrentContext, TokenType.CssIdentifier, ReadIdentifier());
										}
										return CreateToken(base.CurrentContext, TokenType.CssTagNameSelector, ReadIdentifier());
									}
									return CreateToken(base.CurrentContext, TokenType.CssElementSelector, ReadIdentifier());
								}
								return CreateToken(base.CurrentContext, TokenType.CssClassDefinition, ReadIdentifier());
							}
							return CreateToken(base.CurrentContext, TokenType.CssStyleName, ReadIdentifier());
						}
						return CreateToken(base.CurrentContext, TokenType.CssDot, Read(1));
					}
					return CreateToken(base.CurrentContext, TokenType.Whitespace, ReadWhitespace());
				}
				return CreateToken(base.CurrentContext, TokenType.SkinPlaceHolder, ReadSkinPlaceholder());
			}
			return new CssValueToken(base.CurrentContext, TokenType.CssStyleValue, ReadCssValue());
		}

		protected override bool IsPreWhitespace(char chrValue)
		{
			if (base.IsPreviousCommentToken)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!base.IsPreviousWhitespaceToken)
			{
				/*OpCode not supported: LdMemberToken*/;
				if ((uint)chrValue > 32u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (chrValue == ';')
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (chrValue == '{')
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (chrValue != '}')
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0097;
					}
				}
				else if (chrValue == '\t')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (chrValue == '\n')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (chrValue != ' ')
					{
						goto IL_0097;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return true;
			}
			return true;
			IL_0097:
			return false;
		}

		private bool IsClassDot(char chrCurrent)
		{
			if (KB)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return chrCurrent == '.';
		}

		private string ReadImport()
		{
			int i;
			for (i = 1; !IsSemicolomn(PeekAtOffset(i)); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			i++;
			return Read(i);
		}

		private string ReadCssValue()
		{
			int num = 1;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndCssValue(PeekAtOffset(num)))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			return Read(num);
		}

		private string ReadBlockComment()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndBlockComment(num))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			return Read(num);
		}

		private string ReadIdentifier()
		{
			int i;
			for (i = 1; IsPartIdentifier(PeekAtOffset(i)); i++)
			{
			}
			return Read(i);
		}

		private bool IsImportStart(char chrCurrent)
		{
			return chrCurrent == '@';
		}

		private bool IsColon(char chrCurrent)
		{
			return chrCurrent == ':';
		}

		private bool IsSemicolomn(char chrCurrent)
		{
			return chrCurrent == ';';
		}

		private bool IsPoundKey(char chrCurrent)
		{
			return chrCurrent == '#';
		}

		private bool IsClassName()
		{
			if (KB)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (base.Position >= 1)
				{
					return PeekAtOffset(-1) == '.';
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsTagName()
		{
			if (!KB)
			{
				if (base.Position > 1)
				{
					return PeekAtOffset(-1) == ' ';
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsElementID()
		{
			if (base.Position <= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return PeekAtOffset(-1) == '#';
		}

		private bool IsStartCssValue()
		{
			if (!KB)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (base.Position > 1)
				{
					return PeekAtOffset(-1) == ':';
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsEndCssValue(char chrCurrent)
		{
			if (chrCurrent == ';')
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrCurrent == '}';
		}

		private bool IsEndClassBlock(char chrCurrent)
		{
			return chrCurrent == '}';
		}

		private bool IsStartClassBlock(char chrCurrent)
		{
			return chrCurrent == '{';
		}

		private bool IsEndBlockComment(int intOffset)
		{
			if (PeekAtOffset(intOffset - 2) == '*')
			{
				return PeekAtOffset(intOffset - 1) == '/';
			}
			return false;
		}

		private bool IsStartBlockComment(char chrCurrent)
		{
			if (chrCurrent != '/')
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return PeekAtOffset(1) == '*';
		}

		private bool IsStartIdentifier(char chrCurrent)
		{
			if (char.IsLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return IsExtendedCharecterOfIdentifier(chrCurrent);
		}

		private bool IsPartIdentifier(char chrCurrent)
		{
			if (char.IsLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!char.IsDigit(chrCurrent))
				{
					return IsExtendedCharecterOfIdentifier(chrCurrent);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}

		private bool IsExtendedCharecterOfIdentifier(char chrCurrent)
		{
			if (chrCurrent != '_')
			{
				return chrCurrent == '-';
			}
			return true;
		}

		public override void Reset()
		{
			base.Reset();
			KB = false;
		}
	}
}
