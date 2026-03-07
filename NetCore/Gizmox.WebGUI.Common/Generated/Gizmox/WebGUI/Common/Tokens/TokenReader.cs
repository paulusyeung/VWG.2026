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
	public class TokenReader
	{
		private enum HC
		{
			A,
			B,
			C
		}

		private int A;

		private TextReader B;

		private char[] C;

		private int D;

		private int E;

		private int F = 102400;

		private const char G = '\0';

		private Token H;

		private int I = -1;

		private TokenContext J;

		private int K = 1;

		private bool L;

		private bool M;

		private Queue<Token> N = new Queue<Token>();

		protected TokenContext CurrentContext
		{
			get
			{
				return J;
			}
			set
			{
				if (value == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (value.Parent != J)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (value != J.Parent)
					{
						throw new ArgumentOutOfRangeException();
					}
					J = value;
				}
				else
				{
					J = value;
				}
			}
		}

		internal bool FormatedIdentifiersOnly
		{
			get
			{
				return M;
			}
			set
			{
				M = value;
			}
		}

		internal virtual bool FormatedReferencesEnabled
		{
			get
			{
				return L;
			}
			set
			{
				L = value;
			}
		}

		protected int Position => A;

		protected int LineNumber => K;

		public Token PreviousToken => H;

		protected bool EndOfFile => PeekAtIndex(A) == '\0';

		protected bool BeginingOfFile => A == 0;

		protected char CurrentCharecter => PeekAtIndex(A);

		protected char NextCharecter => PeekAtIndex(A + 1);

		protected bool IsPreviousCommentToken
		{
			get
			{
				if (H == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return H.Type == TokenType.Comment;
			}
		}

		protected bool IsPreviousWhitespaceToken
		{
			get
			{
				if (H != null)
				{
					return H.Type == TokenType.Whitespace;
				}
				return false;
			}
		}

		public TokenReader(TokenContext objTokenContext, string strSource)
		{
			if (strSource != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				Init(objTokenContext, new StringReader(strSource));
				return;
			}
			throw new ArgumentNullException("strSource", "The source string be null.");
		}

		public TokenReader(TokenContext objTokenContext, Stream objSource)
		{
			if (objSource != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objSource.Position == 0L)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objSource.Position = 0L;
				}
				Init(objTokenContext, new StreamReader(objSource));
				return;
			}
			throw new ArgumentNullException("objSource", "The source stream be null.");
		}

		public TokenReader(TokenContext objTokenContext, TextReader objSource)
		{
			Init(objTokenContext, objSource);
		}

		private void Init(TokenContext objTokenContext, TextReader objSource)
		{
			if (objTokenContext == null)
			{
				objTokenContext = new TokenContext(null);
			}
			N = new Queue<Token>();
			B = objSource;
			J = objTokenContext;
			C = new char[F];
		}

		protected char PeekAtIndex(int intIndex)
		{
			if (!EnsureBuffer(intIndex))
			{
				/*OpCode not supported: LdMemberToken*/;
				return '\0';
			}
			return PeekBuffer(intIndex);
		}

		private void TruncateBuffer(int intPosition)
		{
		}

		private bool EnsureBuffer(int intIndex)
		{
			return EnsureBuffer(intIndex, 1);
		}

		private bool EnsureBuffer(int intIndex, int intLength)
		{
			if (intIndex >= 0 && intLength >= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (GetBufferState(intIndex, intLength))
				{
				case HC.A:
					throw new Exception("ddd");
				default:
					/*OpCode not supported: LdMemberToken*/;
					return true;
				case HC.C:
					return LoadBuffer(intIndex, intLength);
				}
			}
			return false;
		}

		private bool LoadBuffer(int intIndex)
		{
			return LoadBuffer(intIndex, 1);
		}

		private bool LoadBuffer(int intIndex, int intLength)
		{
			if (intIndex >= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (intLength < 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_011d;
			}
			if (D > intIndex)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_011d;
			}
			int num = D + E - 1;
			int num2 = intIndex + intLength - 1;
			if (num2 > num)
			{
				/*OpCode not supported: LdMemberToken*/;
				int num3 = num2 - num;
				int num4 = -1;
				int num5 = 0;
				while (num3 > 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if ((num4 = B.Read()) == -1)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					num5++;
					if (F > E)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						int num6 = F * 2;
						char[] array = new char[num6];
						C.CopyTo(array, 0);
						C = array;
						F = num6;
					}
					C[E] = (char)num4;
					E++;
					num3--;
				}
				if (num5 == 0)
				{
					if (num3 == intLength)
					{
						return false;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return true;
			}
			return true;
			IL_011d:
			return false;
		}

		private string PeekBuffer(int intIndex, int intLength)
		{
			return ReadBuffer(intIndex, intLength, blnPeek: true);
		}

		private char PeekBuffer(int intIndex)
		{
			if (E <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (D > intIndex)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (D + E >= intIndex)
			{
				return C[intIndex - D];
			}
			return '\0';
		}

		private string ReadBuffer(int intIndex, int intLength)
		{
			return ReadBuffer(intIndex, intLength, blnPeek: false);
		}

		private string ReadBuffer(int intIndex, int intLength, bool blnPeek)
		{
			if (intIndex >= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (intLength < 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_0087;
			}
			if (D > intIndex)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (D + E >= intIndex)
				{
					int num = intIndex - D;
					int length = Math.Min(intLength, E - num);
					string result = new string(C, num, length);
					if (blnPeek)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						OptimizeBuffer();
					}
					return result;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			goto IL_0087;
			IL_0087:
			return string.Empty;
		}

		private void OptimizeBuffer()
		{
		}

		private HC GetBufferState(int intIndex, int intLength)
		{
			if (E <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return HC.C;
			}
			if (intLength >= 1)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				intLength = 1;
			}
			int num = intIndex + intLength - 1;
			if (D <= intIndex)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (D + E - 1 >= intIndex)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (D + E - 1 >= num)
					{
						/*OpCode not supported: LdMemberToken*/;
						return HC.B;
					}
					return HC.C;
				}
				return HC.C;
			}
			return HC.A;
		}

		protected char PeekAtOffset(int intOffset)
		{
			return PeekAtIndex(A + intOffset);
		}

		protected string PeekString(int intLength)
		{
			return PeekString(0, intLength);
		}

		protected string PeekString(int intOffset, int intLength)
		{
			int indexFromOffset = GetIndexFromOffset(intOffset);
			if (!EnsureBuffer(indexFromOffset, intLength))
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			return PeekBuffer(indexFromOffset, intLength);
		}

		private int GetIndexFromOffset(int intOffset)
		{
			return A + intOffset;
		}

		public Token Read()
		{
			return Read(blnExternal: true);
		}

		private Token Read(bool blnExternal)
		{
			Token token = null;
			if (N.Count > 0 && blnExternal)
			{
				token = N.Dequeue();
			}
			else if (EndOfFile)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				token = ReadTokenInternal();
			}
			if (!blnExternal)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (token != null)
			{
				int num = 0;
				while ((num = NormalizeToken(token)) > 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (NormalizeToken(token, num))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					return token;
				}
			}
			return token;
		}

		private Token ReadTokenInternal()
		{
			int position = Position;
			int lineNumber = LineNumber;
			Token token = ReadToken();
			if (token == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				token.Index = position;
				token.LineNumber = lineNumber;
			}
			H = token;
			return token;
		}

		private bool NormalizeToken(Token objToken, int intToBeNormalized)
		{
			if (N.Count >= intToBeNormalized)
			{
				if (intToBeNormalized > 0)
				{
					while (intToBeNormalized > 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						objToken.Concat(N.Dequeue());
						intToBeNormalized--;
					}
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		protected virtual int NormalizeToken(Token objToken)
		{
			return 0;
		}

		protected Token PeekToken(int intOffset)
		{
			if (N.Count > intOffset)
			{
				int num = 0;
				using (Queue<Token>.Enumerator enumerator = N.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						Token current = enumerator.Current;
						if (num != intOffset)
						{
							/*OpCode not supported: LdMemberToken*/;
							num++;
							continue;
						}
						return current;
					}
				}
				return null;
			}
			Token token = null;
			int num2 = intOffset + 1 - N.Count;
			if (num2 <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				while (num2 != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					token = Read(blnExternal: false);
					if (token == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					N.Enqueue(token);
					num2--;
				}
			}
			return token;
		}

		protected string Read(int intLength)
		{
			EnsureBuffer(A, intLength);
			string text = ReadBuffer(A, intLength);
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				A += text.Length;
				int num = 0;
				for (int i = 0; i < text.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (text[i] != '\n')
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						num++;
					}
				}
				K += num;
			}
			return text;
		}

		protected Token CreateToken(TokenContext objTokenContext, TokenType enmType, string strTokenContent)
		{
			if (M)
			{
				switch (enmType)
				{
				case TokenType.CssClassDefinition:
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00ba;
				case TokenType.CssClassReference:
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00ba;
				case TokenType.JsFunctionDeclatation:
					if (IsJsFunctionFormat(strTokenContent))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enmType = TokenType.IgnoredIdentifier;
					}
					break;
				case TokenType.JsVariableDeclatation:
				case TokenType.JsFunctionArgument:
					if (IsJsVariableFormat(strTokenContent))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enmType = TokenType.IgnoredIdentifier;
					}
					break;
				case TokenType.JsIdentifier:
					{
						if (IsJsVariableFormat(strTokenContent))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (IsJsFunctionFormat(strTokenContent))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							enmType = TokenType.IgnoredIdentifier;
						}
						break;
					}
					IL_00ba:
					if (IsCssClassFormat(strTokenContent))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						enmType = TokenType.IgnoredIdentifier;
					}
					break;
				}
			}
			return new Token(objTokenContext, enmType, strTokenContent);
		}

		private bool IsCssClassFormat(string strTokenContent)
		{
			return Regex.IsMatch(strTokenContent, "[A-Z][a-zA-Z0-9]+[\\-][A-Z][a-zA-Z0-9]+");
		}

		private bool IsJsVariableFormat(string strTokenContent)
		{
			return Regex.IsMatch(strTokenContent, "(mobj|obj|mint|int|marr|arr|mstr|str|mcnt|cnt|mbln|bln|mfnc|fnc|lng|mlng)[A-Z][A-Za-z0-9_]*");
		}

		private bool IsJsFunctionFormat(string strTokenContent)
		{
			return Regex.IsMatch(strTokenContent, "[A-Z][A-Za-z0-9]+[_][A-Z][A-Za-z0-9]+");
		}

		protected virtual Token ReadToken()
		{
			Token token = null;
			char currentCharecter = CurrentCharecter;
			if (!IsStartSkinPlaceholder(currentCharecter))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!IsStartLabelPlaceholder(currentCharecter))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (IsStartContextPlaceholder(currentCharecter))
					{
						return CreateToken(CurrentContext, TokenType.ContextPlaceHolder, ReadContextPlaceholder());
					}
					if (!IsURLExtension(currentCharecter, "wgx"))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!IsURLExtension(currentCharecter, "swgx"))
						{
							/*OpCode not supported: LdMemberToken*/;
							if (IsURLExtension(currentCharecter, "dwgx"))
							{
								return CreateToken(CurrentContext, TokenType.UrlExtension, ReadURLExtension("dwgx"));
							}
							if (IsURLExtension(currentCharecter, "png"))
							{
								return CreateToken(CurrentContext, TokenType.UrlExtension, ReadURLExtension("png"));
							}
							if (!IsStartAttributePlaceHolder(currentCharecter))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (!IsStartEventPlaceHolder(currentCharecter))
								{
									/*OpCode not supported: LdMemberToken*/;
									if (IsStartTagsPlcaeHolder(currentCharecter))
									{
										return CreateToken(CurrentContext, TokenType.TagPlaceHolder, ReadTagsPlaceHolder());
									}
									if (!FormatedReferencesEnabled)
									{
										/*OpCode not supported: LdMemberToken*/;
										return ReadGenericToken();
									}
									int num = 0;
									if ((num = IsStartFunctionFormat(currentCharecter)) <= 0)
									{
										/*OpCode not supported: LdMemberToken*/;
										if ((num = IsStartCssClassFormat(currentCharecter)) <= 0)
										{
											/*OpCode not supported: LdMemberToken*/;
											if ((num = IsStartJsVariableFormat(currentCharecter)) <= 0)
											{
												/*OpCode not supported: LdMemberToken*/;
												return ReadGenericToken();
											}
											return CreateToken(CurrentContext, TokenType.JsIdentifier, Read(num));
										}
										return CreateToken(CurrentContext, TokenType.CssClassReference, Read(num));
									}
									return CreateToken(CurrentContext, TokenType.JsIdentifier, Read(num));
								}
								return CreateToken(CurrentContext, TokenType.EventPlaceHolder, ReadEventPlaceHolder());
							}
							return CreateToken(CurrentContext, TokenType.AttributePlaceHolder, ReadAttribtePlaceHolder());
						}
						return CreateToken(CurrentContext, TokenType.UrlExtension, ReadURLExtension("swgx"));
					}
					return CreateToken(CurrentContext, TokenType.UrlExtension, ReadURLExtension("wgx"));
				}
				return CreateToken(CurrentContext, TokenType.LabelPlaceHolder, ReadLabelPlaceholder());
			}
			return CreateToken(CurrentContext, TokenType.SkinPlaceHolder, ReadSkinPlaceholder());
		}

		private int IsStartFunctionFormat(char chrCurrent)
		{
			int result = 0;
			if (chrCurrent != '[')
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!char.IsLetter(chrCurrent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!char.IsUpper(chrCurrent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (char.IsLetterOrDigit(PeekAtOffset(-1)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					int i;
					for (i = 1; IsJsFunctionFormatPart(PeekAtOffset(i)); i++)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (PeekAtOffset(i) != '_')
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!(PeekString(i) != "VWG"))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						i++;
						if (IsJsFunctionFormatSecondPartStart(PeekAtOffset(i)))
						{
							for (; IsJsFunctionFormatPart(PeekAtOffset(i)); i++)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							result = i;
						}
					}
				}
			}
			else if (PeekAtOffset(1) != '$')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				int num = 2;
				char c = PeekAtOffset(num);
				while (true)
				{
					if (c == ']')
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					if (!IsJsIndentifierLetter(c))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					num++;
					c = PeekAtOffset(num);
				}
				if (c != ']')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = num + 1;
				}
			}
			return result;
		}

		private int IsStartCssClassFormat(char chrCurrent)
		{
			int result = 0;
			if (chrCurrent != '[')
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!char.IsLetter(chrCurrent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!char.IsUpper(chrCurrent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (char.IsLetterOrDigit(PeekAtOffset(-1)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					int i;
					for (i = 1; IsCssClassFormatPart(PeekAtOffset(i)); i++)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					if (PeekAtOffset(i) != '-')
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						i++;
						if (IsCssClassFormatSecondPartStart(PeekAtOffset(i)))
						{
							for (; IsCssClassFormatPart(PeekAtOffset(i)); i++)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							result = i;
						}
					}
				}
			}
			else if (PeekAtOffset(1) == '.')
			{
				int num = 2;
				char c = PeekAtOffset(num);
				while (true)
				{
					if (c == ']')
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					if (!IsCssClassLetter(c))
					{
						break;
					}
					num++;
					c = PeekAtOffset(num);
				}
				if (c != ']')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = num + 1;
				}
			}
			return result;
		}

		private bool IsCssClassLetter(char chrCurrent)
		{
			if (!char.IsLetterOrDigit(chrCurrent))
			{
				if (chrCurrent != '_')
				{
					return chrCurrent == '-';
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}

		private bool IsCssClassFormatSecondPartStart(char chrCurrent)
		{
			if (!char.IsLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return char.IsUpper(chrCurrent);
		}

		private bool IsCssClassFormatPart(char chrCurrent)
		{
			return char.IsLetterOrDigit(chrCurrent);
		}

		private bool IsJsFunctionFormatSecondPartStart(char chrCurrent)
		{
			if (!char.IsLetter(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return char.IsUpper(chrCurrent);
		}

		private bool IsJsFunctionFormatPart(char chrCurrent)
		{
			return char.IsLetterOrDigit(chrCurrent);
		}

		private int IsStartJsVariableFormat(char chrCurrent)
		{
			int result = 0;
			if (chrCurrent != '[')
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!char.IsLetter(chrCurrent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (char.IsLower(chrCurrent))
				{
					if (char.IsLetterOrDigit(PeekAtOffset(-1)))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						string text = PeekString(4);
						if (string.IsNullOrEmpty(text))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							bool flag = false;
							string[] fB = JSTokenReader.FB;
							for (int i = 0; i < fB.Length; i++)
							{
								/*OpCode not supported: LdMemberToken*/;
								string value = fB[i];
								if (text.StartsWith(value))
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								int j;
								for (j = 1; IsJsVariableFormatPart(PeekAtOffset(j)); j++)
								{
								}
								result = j;
							}
						}
					}
				}
			}
			else if (PeekAtOffset(1) == '$')
			{
				int num = 2;
				char c = PeekAtOffset(num);
				while (c != ']' && IsJsIndentifierLetter(c))
				{
					/*OpCode not supported: LdMemberToken*/;
					num++;
					c = PeekAtOffset(num);
				}
				if (c != ']')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = num + 1;
				}
			}
			return result;
		}

		private bool IsJsIndentifierLetter(char chrCurrent)
		{
			if (char.IsLetterOrDigit(chrCurrent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrCurrent == '_';
		}

		private bool IsJsVariableFormatPart(char chrValue)
		{
			if (chrValue != 0)
			{
				if (char.IsLetterOrDigit(chrValue))
				{
					/*OpCode not supported: LdMemberToken*/;
					return true;
				}
				return chrValue == '_';
			}
			return false;
		}

		private bool IsStartTagsPlcaeHolder(char chrCurrent)
		{
			if (chrCurrent == 'T')
			{
				return PeekString(5) == "Tags.";
			}
			return false;
		}

		private string ReadTagsPlaceHolder()
		{
			int i;
			for (i = 6; !IsEndOfFileOffset(i) && char.IsLetterOrDigit(PeekAtOffset(i)); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		private bool IsStartAttributePlaceHolder(char chrCurrent)
		{
			if (chrCurrent == 'A')
			{
				return PeekString(5) == "Attr.";
			}
			return false;
		}

		private bool IsStartEventPlaceHolder(char chrCurrent)
		{
			if (!(PeekString(6) == "Event."))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return true;
		}

		private string ReadAttribtePlaceHolder()
		{
			int num = 6;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (!char.IsLetterOrDigit(PeekAtOffset(num)))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			return Read(num);
		}

		private string ReadEventPlaceHolder()
		{
			int i;
			for (i = 6; !IsEndOfFileOffset(i) && char.IsLetterOrDigit(PeekAtOffset(i)); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		private string ReadURLExtension(string strUrlExtension)
		{
			return Read(strUrlExtension.Length + 1);
		}

		private bool IsURLExtension(char chrCurrent, string strUrlExtension)
		{
			if (chrCurrent == '.')
			{
				if (PeekString(1, strUrlExtension.Length) == strUrlExtension)
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		protected Token ReadGenericToken()
		{
			if (I != -1)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			I = A;
			Token token = null;
			int i = I;
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				stringBuilder.Append(Read(1));
				i = Position;
				token = ReadTokenInternal();
				if (token == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					N.Enqueue(token);
				}
				if (token != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (EndOfFile)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (I != -1 && I < i)
			{
				token = CreateToken(CurrentContext, TokenType.Unkown, stringBuilder.ToString());
			}
			I = -1;
			return token;
		}

		private string PeekStringFromIndex(int intIndex, int intLength)
		{
			if (EnsureBuffer(intIndex, intLength))
			{
				return PeekBuffer(intIndex, intLength);
			}
			return string.Empty;
		}

		protected string ReadWhitespace()
		{
			int i;
			for (i = 1; IsWhitespace(PeekAtOffset(i)); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		protected bool IsStartWhitespace(char chrValue)
		{
			if (!IsWhitespace(chrValue, blnExcludeNewLine: false))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return IsPreWhitespace(PeekAtOffset(-1));
		}

		protected virtual bool IsPreWhitespace(char chrValue)
		{
			return true;
		}

		protected bool IsWhitespace(char chrValue)
		{
			return IsWhitespace(chrValue, blnExcludeNewLine: false);
		}

		protected bool IsWhitespace(char chrValue, bool blnExcludeNewLine)
		{
			if (!blnExcludeNewLine)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_002d;
			}
			if (chrValue == '\n')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (chrValue != '\r')
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_002d;
			}
			return false;
			IL_002d:
			switch (chrValue)
			{
			default:
				/*OpCode not supported: LdMemberToken*/;
				if (chrValue < '\u0080')
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return char.GetUnicodeCategory(chrValue) == UnicodeCategory.SpaceSeparator;
			case '\t':
			case '\n':
			case '\v':
			case '\f':
			case '\r':
			case ' ':
			case '\u00a0':
				return true;
			}
		}

		protected bool IsEndOfLine(char chrValue)
		{
			if (chrValue == '\n')
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return chrValue == '\0';
		}

		protected bool IsEndOfFileOffset(int intOffset)
		{
			return PeekAtOffset(intOffset) == '\0';
		}

		protected bool IsStartSkinPlaceholder(char chrCurrentChar)
		{
			if (chrCurrentChar == '[')
			{
				if (PeekString(6) == "[Skin.")
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		protected bool IsEndSkinPlaceholder(int intOffset)
		{
			return PeekAtOffset(intOffset) == ']';
		}

		protected bool IsStartLabelPlaceholder(char chrCurrentChar)
		{
			if (chrCurrentChar != 'L')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekString(7) == "Labels.")
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		protected bool IsStartContextPlaceholder(char chrCurrentChar)
		{
			if (chrCurrentChar != 'C')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (PeekString(8) == "Context.")
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool IsPlaceholder(int intOffset)
		{
			char c = PeekAtOffset(intOffset);
			if (char.IsLetterOrDigit(c))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return c == '.';
		}

		protected string ReadSkinPlaceholder()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (IsEndSkinPlaceholder(num))
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				num++;
			}
			num++;
			return Read(num);
		}

		private string ReadLabelPlaceholder()
		{
			int i;
			for (i = 2; !IsEndOfFileOffset(i) && IsPlaceholder(i); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			return Read(i);
		}

		private string ReadContextPlaceholder()
		{
			int num = 2;
			while (true)
			{
				if (IsEndOfFileOffset(num))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (!IsPlaceholder(num))
				{
					break;
				}
				num++;
			}
			return Read(num);
		}

		public virtual void Reset()
		{
			throw new NotSupportedException();
		}

		public void Dump(string strPath)
		{
			if (!File.Exists(strPath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				File.Delete(strPath);
			}
			Dump(File.OpenWrite(strPath));
		}

		public void Dump(Stream objOutputStream)
		{
			Dump(new StreamWriter(objOutputStream));
		}

		public void Dump(TextWriter objTextWriter)
		{
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(objTextWriter);
			DumpHeader(htmlTextWriter);
			Dump(htmlTextWriter, this, 0);
			DumpFooter(htmlTextWriter);
			htmlTextWriter.Flush();
			htmlTextWriter.Close();
		}

		private void DumpHeader(HtmlTextWriter objWriter)
		{
			objWriter.WriteFullBeginTag("html");
			objWriter.WriteFullBeginTag("head");
			objWriter.WriteEndTag("head");
			objWriter.WriteBeginTag("body");
			objWriter.WriteAttribute("style", "font-size: 10pt; color: black; font-family: 'Courier New';");
			objWriter.Write(">");
		}

		private void DumpFooter(HtmlTextWriter objWriter)
		{
			objWriter.WriteEndTag("body");
			objWriter.WriteEndTag("html");
		}

		private void Dump(HtmlTextWriter objWriter, TokenReader objTokenReader, int intOffset)
		{
			Token token = null;
			while ((token = objTokenReader.Read()) != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				Dump(objWriter, token, intOffset);
			}
		}

		private void Dump(HtmlTextWriter objWriter, Token objToken, int intOffset)
		{
			if (objToken.HasSubTokens)
			{
				/*OpCode not supported: LdMemberToken*/;
				objWriter.WriteBeginTag("span");
				DumpTitle(objWriter, objToken, intOffset);
				DumpStyle(objWriter, objToken);
				objWriter.Write(">");
				Dump(objWriter, objToken.SubTokens, intOffset + objToken.Index);
				objWriter.WriteEndTag("span");
			}
			else
			{
				objWriter.WriteBeginTag("span");
				DumpTitle(objWriter, objToken, intOffset);
				DumpStyle(objWriter, objToken);
				objWriter.Write(">");
				DumpContent(objWriter, objToken);
				objWriter.WriteEndTag("span");
			}
		}

		private void DumpTitle(HtmlTextWriter objWriter, Token objToken, int intOffset)
		{
			objWriter.WriteAttribute("title", HttpUtility.HtmlEncode(objToken.ToString(intOffset)));
		}

		private void DumpStyle(HtmlTextWriter objWriter, Token objToken)
		{
			Color foreColor = objToken.ForeColor;
			Color backColor = objToken.BackColor;
			if (foreColor != Color.Empty)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(backColor != Color.Empty))
			{
				return;
			}
			string arg = string.Empty;
			string arg2 = string.Empty;
			if (foreColor != Color.Empty)
			{
				arg = $"color:{GetWebColor(foreColor)};";
			}
			if (!(backColor != Color.Empty))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				arg2 = $"background-color:{GetWebColor(backColor)};";
			}
			objWriter.WriteAttribute("style", $"{arg}{arg2}");
		}

		public static string GetWebColor(Color color)
		{
			return color.R.ToString("X2", null) + color.G.ToString("X2", null) + color.B.ToString("X2", null);
		}

		private void DumpContent(HtmlTextWriter objWriter, Token objToken)
		{
			string text = HttpUtility.HtmlEncode(objToken.Content);
			text = text.Replace(" ", "&middot;");
			text = text.Replace("\t", "&#182;&middot;&middot;&middot;");
			text = text.Replace("\r", "");
			text = text.Replace("\n", "&#172;<br/>");
			objWriter.Write(text);
		}
	}
}
