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

namespace Gizmox.WebGUI.Common.Tokens.JS
{
	public class JSTokenReader : TokenReader
	{
		private int X;

		private bool Y;

		private bool Z;

		private bool AB;

		private bool BB;

		private bool CB;

		private TokenType DB;

		private Dictionary<int, bool> EB = new Dictionary<int, bool>();

		internal static string[] FB = new string[14]
		{
			"mobj", "obj", "mint", "int", "marr", "arr", "mstr", "str", "mcnt", "cnt",
			"mbln", "bln", "mfnc", "fnc"
		};

		public JSTokenReader(TokenContext objTokenContext, TextReader objSource)
			: base(objTokenContext, objSource)
		{
		}

		public JSTokenReader(TokenContext objTokenContext, Stream objSource)
			: base(objTokenContext, objSource)
		{
		}

		public JSTokenReader(TokenContext objTokenContext, string objSource)
			: base(objTokenContext, objSource)
		{
		}

		protected override Token ReadToken()
		{
			char currentCharecter = base.CurrentCharecter;
			Token token = null;
			int num = 0;
			if (IsStartWhitespace(currentCharecter))
			{
				token = CreateToken(base.CurrentContext, TokenType.Whitespace, ReadWhitespace());
			}
			else if ((num = TryToReadRegularExpression(currentCharecter)) <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsExternalStringStart(currentCharecter))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!IsExternalStringEnd(currentCharecter))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsAttributeScriptIndicator(currentCharecter))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (IsStartOfIdentifier(currentCharecter))
							{
								string strIdentifier = ReadIdentifier();
								token = HandleIdentifier(strIdentifier);
							}
							else if (IsNumber(currentCharecter))
							{
								token = CreateToken(base.CurrentContext, TokenType.JsNumber, ReadNumber());
							}
							else if (!IsStartLineComment(currentCharecter))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (IsStartBlockComment(currentCharecter))
								{
									token = CreateToken(base.CurrentContext, TokenType.Comment, ReadBlockComment());
								}
								else if (!IsStartQuoteString(currentCharecter))
								{
									/*OpCode not supported: LdMemberToken*/;
									if (!IsStartCommaString(currentCharecter))
									{
										/*OpCode not supported: LdMemberToken*/;
										if (IsStartScriptBlock(currentCharecter))
										{
											X++;
											if (AB)
											{
												AB = false;
												EB[X] = true;
												token = CreateToken(base.CurrentContext, TokenType.JsStartFunctionBlock, Read(1));
											}
											else
											{
												token = CreateToken(base.CurrentContext, TokenType.JsStartBlock, Read(1));
											}
										}
										else if (!IsEndScriptBlock(currentCharecter))
										{
											/*OpCode not supported: LdMemberToken*/;
											if (IsStartParenthesisBlock(currentCharecter))
											{
												if (!Y)
												{
													/*OpCode not supported: LdMemberToken*/;
													token = CreateToken(base.CurrentContext, TokenType.JsStartParenthesis, Read(1));
												}
												else
												{
													Z = true;
													token = CreateToken(base.CurrentContext, TokenType.JsStartFunctionParenthesis, Read(1));
												}
											}
											else if (!IsEndParenthesisBlock(currentCharecter))
											{
												/*OpCode not supported: LdMemberToken*/;
												if (!IsSemicolomn(currentCharecter))
												{
													/*OpCode not supported: LdMemberToken*/;
													if (!IsStartBracket(currentCharecter))
													{
														/*OpCode not supported: LdMemberToken*/;
														token = (IsEndBracket(currentCharecter) ? CreateToken(base.CurrentContext, TokenType.JsEndBracket, Read(1)) : ((!IsOperatorStart(currentCharecter)) ? base.ReadToken() : CreateToken(base.CurrentContext, TokenType.JsOperator, ReadOperator())));
													}
													else
													{
														token = CreateToken(base.CurrentContext, TokenType.JsStartBracket, Read(1));
													}
												}
												else
												{
													if (AB)
													{
														AB = false;
													}
													token = CreateToken(base.CurrentContext, TokenType.JsSemicolon, Read(1));
												}
											}
											else if (Y)
											{
												Y = false;
												Z = false;
												AB = true;
												token = CreateToken(base.CurrentContext, TokenType.JsEndFunctionParenthesis, Read(1));
											}
											else
											{
												token = CreateToken(base.CurrentContext, TokenType.JsEndParenthesis, Read(1));
											}
										}
										else if (EB.ContainsKey(X))
										{
											EB.Remove(X);
											X--;
											token = CreateToken(base.CurrentContext, TokenType.JsEndFunctionBlock, Read(1));
										}
										else
										{
											X--;
											token = CreateToken(base.CurrentContext, TokenType.JsEndBlock, Read(1));
										}
									}
									else
									{
										token = new JSStringToken(base.CurrentContext, TokenType.JsString, ReadCommaString());
									}
								}
								else
								{
									token = new JSStringToken(base.CurrentContext, TokenType.JsString, ReadQuoteString());
								}
							}
							else
							{
								token = CreateToken(base.CurrentContext, TokenType.Comment, ReadLineComment());
							}
						}
						else
						{
							token = CreateToken(base.CurrentContext, TokenType.Unkown, ReadAttributeScriptIndicator());
						}
					}
					else
					{
						token = CreateToken(base.CurrentContext, TokenType.Unkown, Read(1));
					}
				}
				else
				{
					BB = true;
					token = CreateToken(base.CurrentContext, TokenType.Unkown, Read(1));
				}
			}
			else
			{
				token = CreateToken(base.CurrentContext, TokenType.JsRegularExpression, Read(num));
			}
			if (token == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (token.Type == TokenType.Unkown)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (token.Type == TokenType.Whitespace)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (token.Type == TokenType.Comment)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				DB = token.Type;
			}
			return token;
		}

		protected virtual Token HandleIdentifier(string strIdentifier)
		{
			Token token = null;
			if (!CB)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsFunction(strIdentifier))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!IsKeyword(strIdentifier))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsReserved(strIdentifier))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (!Y)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								if (!Z)
								{
									token = CreateToken(base.CurrentContext, TokenType.JsFunctionDeclatation, strIdentifier);
									goto IL_0135;
								}
								/*OpCode not supported: LdMemberToken*/;
							}
							if (!Y)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (Z)
							{
								token = CreateToken(base.CurrentContext, TokenType.JsFunctionArgument, strIdentifier);
								goto IL_0135;
							}
							token = CreateToken(base.CurrentContext, TokenType.JsIdentifier, strIdentifier);
						}
						else
						{
							token = CreateToken(base.CurrentContext, TokenType.JsReserved, strIdentifier);
						}
					}
					else
					{
						token = CreateToken(base.CurrentContext, TokenType.JsKeyword, strIdentifier);
					}
				}
				else
				{
					Y = true;
					token = CreateToken(base.CurrentContext, TokenType.JsKeyword, strIdentifier);
				}
			}
			else
			{
				token = CreateToken(base.CurrentContext, TokenType.JsVariableDeclatation, strIdentifier);
				CB = false;
			}
			goto IL_0135;
			IL_0135:
			if (!(strIdentifier == "var"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CB = true;
			}
			return token;
		}

		private int TryToReadRegularExpression(char chrCurrent)
		{
			int i = 0;
			if (chrCurrent != '/')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekAtOffset(1) == '/')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekAtOffset(1) == '*')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!PreTokenIsValidForRegEx())
				{
					return 0;
				}
				i = 1;
				int num = 0;
				bool flag = false;
				for (; !IsEndRegularExpression(i, num > 0); i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!IsInvalidRegularExpressionEnd(i))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsRegularExpressionEscape(i))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (flag)
							{
								/*OpCode not supported: LdMemberToken*/;
								flag = false;
							}
							else if (!IsRegularExpressionStartSection(i))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (IsRegularExpressionEndSection(i))
								{
									num--;
								}
							}
							else
							{
								num++;
							}
						}
						else
						{
							flag = true;
						}
						continue;
					}
					return 0;
				}
				for (i++; IsRegularExpressionAttributes(i); i++)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return i;
		}

		private bool PreTokenIsValidForRegEx()
		{
			switch (DB)
			{
			case TokenType.IgnoredIdentifier:
				/*OpCode not supported: LdMemberToken*/;
				break;
			case TokenType.JsIdentifier:
				/*OpCode not supported: LdMemberToken*/;
				break;
			default:
				/*OpCode not supported: LdMemberToken*/;
				return true;
			case TokenType.JsNumber:
				break;
			}
			return false;
		}

		private bool IsRegularExpressionAttributes(int intOffset)
		{
			switch (PeekAtOffset(intOffset))
			{
			case 'g':
				/*OpCode not supported: LdMemberToken*/;
				break;
			case 'i':
				/*OpCode not supported: LdMemberToken*/;
				break;
			default:
				/*OpCode not supported: LdMemberToken*/;
				return false;
			case 'm':
				break;
			}
			return true;
		}

		private bool IsRegularExpressionEndSection(int intOffset)
		{
			char c = PeekAtOffset(intOffset);
			if (c == ']')
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return c == ')';
		}

		private bool IsRegularExpressionStartSection(int intOffset)
		{
			char c = PeekAtOffset(intOffset);
			if (c != '[')
			{
				return c == '(';
			}
			return true;
		}

		private bool IsRegularExpressionEscape(int intOffset)
		{
			return PeekAtOffset(intOffset) == '\\';
		}

		private bool IsEndRegularExpression(int intOffset, bool blnIsInSection)
		{
			if (blnIsInSection)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return PeekAtOffset(intOffset) == '/';
		}

		private bool IsInvalidRegularExpressionEnd(int intOffset)
		{
			char c = PeekAtOffset(intOffset);
			if (c == '\0')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (c == '\n')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (c != '\r')
			{
				return false;
			}
			return true;
		}

		protected override int NormalizeToken(Token objToken)
		{
			if (objToken.Type != TokenType.Comment)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Token token = PeekToken(0);
				if (token == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (token.Type != TokenType.Whitespace)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Token token2 = PeekToken(1);
					if (token2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (token2.Type == TokenType.Comment)
						{
							return 2;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
				}
			}
			return base.NormalizeToken(objToken);
		}

		private string ReadAttributeScriptIndicator()
		{
			return Read(12);
		}

		private string ReadCommaString()
		{
			int num = 1;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndCommaString(num))
				{
					break;
				}
				num++;
			}
			num++;
			return Read(num);
		}

		protected string ReadQuoteString()
		{
			int i;
			for (i = 1; !IsEndOfFileOffset(i) && !IsEndQuoteString(i); i++)
			{
			}
			i++;
			return Read(i);
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

		private string ReadLineComment()
		{
			int i;
			for (i = 1; !IsEndOfFileOffset(i) && !IsEndOfLine(PeekAtOffset(i)); i++)
			{
			}
			return Read(i);
		}

		private string ReadNumber()
		{
			int i;
			for (i = 1; IsNumber(PeekAtOffset(i), i); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		private string ReadIdentifier()
		{
			int i;
			for (i = 1; IsPartOfIdentifier(PeekAtOffset(i)); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		private bool IsExternalStringStart(char chrCurrent)
		{
			if (base.Position != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (chrCurrent == '"')
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrCurrent == '\'';
		}

		private bool IsExternalStringEnd(char chrCurrent)
		{
			if (!IsEndOfFileOffset(1))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (chrCurrent == '"')
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrCurrent == '\'';
		}

		private bool IsAttributeScriptIndicator(char chrCurrent)
		{
			if (chrCurrent != '"')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (base.Position != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (PeekString(12) == "\"javascript:")
			{
				return true;
			}
			return false;
		}

		private bool IsEndBlockComment(int intOffset)
		{
			if (PeekAtOffset(intOffset - 2) != '*')
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return PeekAtOffset(intOffset - 1) == '/';
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

		private bool IsStartLineComment(char chrCurrent)
		{
			if (chrCurrent == '/')
			{
				return PeekAtOffset(1) == '/';
			}
			return false;
		}

		private bool IsStartOfIdentifier(char chrCurrent)
		{
			if (IsExtendedCharecterOfIdentifier(chrCurrent))
			{
				return true;
			}
			if (!char.IsLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (!base.BeginingOfFile)
			{
				char c = PeekAtOffset(-1);
				if (c == '\\')
				{
					return false;
				}
			}
			return true;
		}

		private bool IsExtendedCharecterOfIdentifier(char chrCurrent)
		{
			if (chrCurrent == '_')
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrCurrent == '$';
		}

		private bool IsPartOfIdentifier(char chrCurrent)
		{
			if (!char.IsLetterOrDigit(chrCurrent))
			{
				return IsExtendedCharecterOfIdentifier(chrCurrent);
			}
			return true;
		}

		private bool IsNumber(char chrCurrent)
		{
			return IsNumber(chrCurrent, 0);
		}

		private bool IsNumber(char chrCurrent, int intPosition)
		{
			if (!char.IsDigit(chrCurrent))
			{
				if (intPosition == 1)
				{
					return chrCurrent == 'x';
				}
				return false;
			}
			return true;
		}

		protected bool IsStartQuoteString(char chrCurrent)
		{
			if (chrCurrent == '"')
			{
				return !IsFirstOrLastPosition();
			}
			return false;
		}

		private bool IsFirstOrLastPosition()
		{
			if (base.EndOfFile)
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return base.BeginingOfFile;
		}

		private bool IsEndQuoteString(int intOffset)
		{
			if (PeekAtOffset(intOffset) != '"')
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (PeekAtOffset(intOffset - 1) != '\\')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekAtOffset(intOffset - 2) != '\\')
				{
					return false;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}

		private bool IsEndCommaString(int intOffset)
		{
			if (PeekAtOffset(intOffset) != '\'')
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			if (PeekAtOffset(intOffset - 1) != '\\')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekAtOffset(intOffset - 2) != '\\')
				{
					return false;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}

		private bool IsStartCommaString(char chrCurrent)
		{
			if (chrCurrent != '\'')
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return !IsFirstOrLastPosition();
		}

		private bool IsEndScriptBlock(char chrCurrent)
		{
			return chrCurrent == '}';
		}

		private bool IsStartScriptBlock(char chrCurrent)
		{
			return chrCurrent == '{';
		}

		private bool IsEndParenthesisBlock(char chrCurrent)
		{
			return chrCurrent == ')';
		}

		private bool IsStartParenthesisBlock(char chrCurrent)
		{
			return chrCurrent == '(';
		}

		private bool IsSemicolomn(char chrCurrent)
		{
			return chrCurrent == ';';
		}

		private bool IsReserved(string strWord)
		{
			uint num = SC.ComputeStringHash(strWord);
			if (num <= 2330063653u)
			{
				if (num > 980246363)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 1432994735)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 1615808600)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "String")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0345;
							}
						}
						else if (num == 2330063653u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "parentWindow")
							{
								goto IL_0345;
							}
						}
					}
					else if (num == 995259257)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "Date")
						{
							goto IL_0345;
						}
					}
					else if (num == 1432994735 && strWord == "Math")
					{
						goto IL_0345;
					}
				}
				else if (num > 685433770)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num == 876513898)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "isNaN")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0345;
						}
					}
					else if (num == 980246363 && strWord == "propmpt")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0345;
					}
				}
				else if (num == 147992079)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "eval")
					{
						goto IL_0345;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (num == 685433770 && strWord == "ActiveXObject")
				{
					goto IL_0345;
				}
			}
			else if (num <= 2708649949u)
			{
				if (num > 2652972038u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num != 2704835779u)
					{
						if (num == 2708649949u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "window")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0345;
							}
						}
					}
					else if (strWord == "replace")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0345;
					}
				}
				else if (num == 2518895572u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "document")
					{
						goto IL_0345;
					}
				}
				else if (num == 2652972038u && strWord == "escape")
				{
					goto IL_0345;
				}
			}
			else if (num > 3528346163u)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num == 3851314394u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "Object")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0345;
					}
				}
				else if (num == 3939368189u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "parent")
					{
						goto IL_0345;
					}
				}
			}
			else if (num == 3083032825u)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (strWord == "alert")
				{
					goto IL_0345;
				}
			}
			else if (num == 3528346163u)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (strWord == "XMLHttpRequest")
				{
					goto IL_0345;
				}
			}
			return false;
			IL_0345:
			return true;
		}

		private bool IsFunction(string strWord)
		{
			return strWord == "function";
		}

		private string ReadOperator()
		{
			int i;
			for (i = 1; IsOperator(PeekAtOffset(i)); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		private bool IsOperatorStart(char chrValue)
		{
			return IsOperator(chrValue);
		}

		private bool IsOperator(char chrValue)
		{
			switch (chrValue)
			{
			default:
				/*OpCode not supported: LdMemberToken*/;
				break;
			case '!':
			case '%':
			case '&':
			case '*':
			case '+':
			case ',':
			case '-':
			case '.':
			case '/':
			case ':':
			case '<':
			case '=':
			case '>':
			case '?':
			case '|':
				return true;
			case '"':
			case '#':
			case '$':
			case '\'':
			case '(':
			case ')':
			case ';':
				break;
			}
			return false;
		}

		private bool IsStartBracket(char chrCurrent)
		{
			if (chrCurrent != '[')
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (0u | (IsStartSkinPlaceholder(chrCurrent) ? 1u : 0u) | (IsStartLabelPlaceholder(chrCurrent) ? 1u : 0u) | (IsStartContextPlaceholder(chrCurrent) ? 1u : 0u)) == 0;
		}

		private bool IsEndBracket(char chrCurrent)
		{
			return chrCurrent == ']';
		}

		protected override bool IsPreWhitespace(char chrValue)
		{
			if (base.IsPreviousCommentToken)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!base.IsPreviousWhitespaceToken)
			{
				switch (chrValue)
				{
				case ']':
					/*OpCode not supported: LdMemberToken*/;
					goto case '\t';
				case '{':
					/*OpCode not supported: LdMemberToken*/;
					goto case '\t';
				default:
					/*OpCode not supported: LdMemberToken*/;
					break;
				case '\t':
				case '\n':
				case '\r':
				case ' ':
				case '!':
				case '(':
				case ')':
				case '*':
				case '+':
				case ',':
				case '-':
				case '.':
				case ':':
				case ';':
				case '=':
				case '[':
				case '}':
					return true;
				case '\0':
				case '\u0001':
				case '\u0002':
				case '\u0003':
				case '\u0004':
				case '\u0005':
				case '\u0006':
				case '\a':
				case '\b':
				case '\v':
				case '\f':
				case '\u000e':
				case '\u000f':
				case '\u0010':
				case '\u0011':
				case '\u0012':
				case '\u0013':
				case '\u0014':
				case '\u0015':
				case '\u0016':
				case '\u0017':
				case '\u0018':
				case '\u0019':
				case '\u001a':
				case '\u001b':
				case '\u001c':
				case '\u001d':
				case '\u001e':
				case '\u001f':
				case '"':
				case '#':
				case '$':
				case '%':
				case '&':
				case '\'':
				case '/':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
				case '<':
				case '>':
				case '?':
				case '@':
				case 'A':
				case 'B':
				case 'C':
				case 'D':
				case 'E':
				case 'F':
				case 'G':
				case 'H':
				case 'I':
				case 'J':
				case 'K':
				case 'L':
				case 'M':
				case 'N':
				case 'O':
				case 'P':
				case 'Q':
				case 'R':
				case 'S':
				case 'T':
				case 'U':
				case 'V':
				case 'W':
				case 'X':
				case 'Y':
				case 'Z':
				case '\\':
					break;
				}
				return false;
			}
			return true;
		}

		private bool IsKeyword(string strWord)
		{
			uint num = SC.ComputeStringHash(strWord);
			if (num > 2246981567u)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 2823553821u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 3378807160u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num > 3660305025u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (num > 4121104358u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (num == 4152230356u)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (strWord == "super")
									{
										/*OpCode not supported: LdMemberToken*/;
										goto IL_0ea8;
									}
								}
								else if (num == 4211608755u)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (strWord == "export")
									{
										/*OpCode not supported: LdMemberToken*/;
										goto IL_0ea8;
									}
								}
							}
							else if (num == 4044535323u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "synchronized")
								{
									goto IL_0ea8;
								}
							}
							else if (num == 4121104358u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "goto")
								{
									goto IL_0ea8;
								}
							}
						}
						else if (num > 3432027008u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (num == 3532702267u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "static")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
							else if (num == 3660305025u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "this")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
						}
						else if (num == 3402529440u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "namespace")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (num == 3432027008u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "public")
							{
								goto IL_0ea8;
							}
						}
					}
					else if (num <= 2977070660u)
					{
						if (num > 2887626766u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (num == 2901640080u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "for")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
							else if (num == 2977070660u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "continue")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
						}
						else if (num != 2872970239u)
						{
							if (num == 2887626766u && strWord == "try")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (strWord == "class")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num > 3183434736u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 3270303571u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "long")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (num == 3378807160u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "break")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
					}
					else if (num != 3122818005u)
					{
						if (num == 3183434736u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "else")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
					}
					else if (strWord == "short")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num > 2593171616u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 2642794062u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num <= 2699759368u)
						{
							if (num == 2664841801u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "function")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
							else if (num == 2699759368u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "double")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
						}
						else if (num != 2797886853u)
						{
							if (num == 2823553821u && strWord == "char")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (strWord == "float")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num > 2618047400u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 2635014687u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "implements")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (num == 2642794062u && strWord == "extends")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num == 2602907825u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "case")
						{
							goto IL_0ea8;
						}
					}
					else if (num == 2618047400u && strWord == "finally")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num > 2470140894u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 2497774445u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 2515107422u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "int")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (num == 2593171616u)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "typeof")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
					}
					else if (num == 2480955249u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "switch")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num == 2497774445u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "volatile")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
				}
				else if (num <= 2325638003u)
				{
					if (num != 2317739966u)
					{
						if (num == 2325638003u && strWord == "abstract")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (strWord == "var")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num == 2436574203u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "package")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num == 2470140894u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "default")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
			}
			else if (num > 1303515621)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 1683620383)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 1996966820)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num <= 2171383808u)
						{
							if (num == 2054714927)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "throw")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
							else if (num == 2171383808u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "enum")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
						}
						else if (num != 2229948720u)
						{
							if (num == 2246981567u)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (strWord == "return")
								{
									/*OpCode not supported: LdMemberToken*/;
									goto IL_0ea8;
								}
							}
						}
						else if (strWord == "interface")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num > 1716507092)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 1740784714)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "delete")
							{
								goto IL_0ea8;
							}
						}
						else if (num == 1996966820)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "null")
							{
								goto IL_0ea8;
							}
						}
					}
					else if (num == 1710517951)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "boolean")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num == 1716507092)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "const")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
				}
				else if (num > 1584460349)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 1646057492)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 1657474316)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "private")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
						else if (num == 1683620383 && strWord == "byte")
						{
							goto IL_0ea8;
						}
					}
					else if (num == 1612397662)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "debugger")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num == 1646057492)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "do")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
				}
				else if (num <= 1469170932)
				{
					if (num == 1312329493)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "is")
						{
							goto IL_0ea8;
						}
					}
					else if (num == 1469170932 && strWord == "use")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num == 1579491469)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "as")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num == 1584460349 && strWord == "transient")
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_0ea8;
				}
			}
			else if (num <= 508850813)
			{
				if (num > 231090382)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 362463927)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 439074547)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "instanceof")
							{
								goto IL_0ea8;
							}
						}
						else if (num == 508850813)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strWord == "protected")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0ea8;
							}
						}
					}
					else if (num == 288002260)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "import")
						{
							goto IL_0ea8;
						}
					}
					else if (num == 362463927)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "final")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
				}
				else if (num == 184981848)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "false")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num == 206241385)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "with")
					{
						goto IL_0ea8;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (num == 231090382)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "while")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
			}
			else if (num > 959999494)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 1116268876)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num == 1219850847)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "void")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
					else if (num == 1303515621)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "true")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
				}
				else if (num == 1094220446)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strWord == "in")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0ea8;
					}
				}
				else if (num == 1116268876 && strWord == "catch")
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_0ea8;
				}
			}
			else if (num > 664949460)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num != 681154065)
				{
					if (num == 959999494)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (strWord == "if")
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0ea8;
						}
					}
				}
				else if (strWord == "new")
				{
					goto IL_0ea8;
				}
			}
			else if (num == 608588554)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (strWord == "native")
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_0ea8;
				}
			}
			else if (num == 664949460)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (strWord == "throws")
				{
					goto IL_0ea8;
				}
			}
			return false;
			IL_0ea8:
			return true;
		}
	}
}
