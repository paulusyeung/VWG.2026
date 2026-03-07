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
	public class ScriptContent : TextFileContent
	{
		protected enum CodeBlockType
		{
			Parenthesis,
			Brackets,
			Braces,
			Page
		}

		protected class CodeBlockInfo
		{
			private readonly string A;

			private readonly CodeBlockType B;

			public string Keyword => A;

			public CodeBlockType Type => B;

			internal CodeBlockInfo(string strCodeBlockKeyword, CodeBlockType enmCodeBlockType)
			{
				A = strCodeBlockKeyword;
				B = enmCodeBlockType;
			}
		}

		[NonSerialized]
		private bool H;

		[NonSerialized]
		private bool I;

		[NonSerialized]
		private bool J;

		[NonSerialized]
		private string K = string.Empty;

		[NonSerialized]
		private Stack<CodeBlockInfo> L;

		private CodeBlockInfo CurrentCodeBlock => L.Peek();

		public ScriptContent(Stream objStream)
			: base(objStream)
		{
		}

		protected override TokenReader CreateTokenReader(Stream objStream)
		{
			return new JSTokenReader(null, objStream);
		}

		protected override void LoadIndexes(Stream objStream)
		{
			ResetIndexingStatus();
			base.LoadIndexes(objStream);
		}

		private void ResetIndexingStatus()
		{
			L = new Stack<CodeBlockInfo>();
			L.Push(new CodeBlockInfo(string.Empty, CodeBlockType.Page));
			K = string.Empty;
		}

		protected override void LoadIndex(TokenType enmTokenType, string strTokenContent, int intTokenIndex, int intTokenLength, int intTokenLine, TokenContext objTokenContext)
		{
			string text = strTokenContent.Replace("\\\"", string.Empty);
			int length = text.Length;
			if (J)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if ((length - text.Replace("\"", string.Empty).Length) % 2 != 1)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				I = !I;
			}
			if (I)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if ((length - text.Replace("'", string.Empty).Length) % 2 == 1)
			{
				J = !J;
			}
			TrackCodeBlocks(enmTokenType, strTokenContent);
			if (I)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (J)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!H)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (enmTokenType != TokenType.JsKeyword)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (strTokenContent == "in")
					{
						H = false;
					}
					if (!H)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						switch (enmTokenType)
						{
						case TokenType.Unkown:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strTokenContent == "."))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								H = false;
							}
							break;
						case TokenType.Whitespace:
							/*OpCode not supported: LdMemberToken*/;
							break;
						case TokenType.JsStartBlock:
						case TokenType.JsStartFunctionBlock:
						case TokenType.JsEndFunctionBlock:
						case TokenType.JsEndBlock:
						case TokenType.JsStartParenthesis:
						case TokenType.JsEndParenthesis:
						case TokenType.JsStartFunctionParenthesis:
						case TokenType.JsEndFunctionParenthesis:
						case TokenType.JsSemicolon:
						case TokenType.JsOperator:
						case TokenType.JsStartBracket:
						case TokenType.JsEndBracket:
							H = false;
							break;
						default:
							RegisterLoadIndexScriptBlockError(intTokenLine, intTokenIndex);
							H = false;
							break;
						case TokenType.Comment:
							break;
						}
					}
				}
				if (H)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (enmTokenType <= TokenType.JsKeyword)
					{
						if (enmTokenType != TokenType.JsIdentifier)
						{
							if (enmTokenType != TokenType.JsVariableDeclatation)
							{
								if (enmTokenType == TokenType.JsKeyword)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (strTokenContent == "false")
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else if (!(strTokenContent == "true"))
									{
										goto IL_02f9;
									}
									H = true;
								}
								goto IL_02f9;
							}
							/*OpCode not supported: LdMemberToken*/;
						}
						goto IL_0252;
					}
					if (enmTokenType > TokenType.JsEndParenthesis)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (enmTokenType == TokenType.JsEndFunctionParenthesis)
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0292;
						}
						if (enmTokenType == TokenType.JsEndBracket)
						{
							goto IL_0252;
						}
					}
					else
					{
						if (enmTokenType == TokenType.JsNumber)
						{
							goto IL_0252;
						}
						if (enmTokenType == TokenType.JsEndParenthesis)
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0292;
						}
					}
				}
			}
			goto IL_02f9;
			IL_02f9:
			CloseCodeBlockIfNeeded(enmTokenType);
			if (enmTokenType > TokenType.CssClassReference)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (enmTokenType)
				{
				case TokenType.JsVariableDeclatation:
					WriteIndex(FileIndexType.ScriptVariableDeclatation, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsIdentifier:
					WriteIndex(FileIndexType.ScriptIdentifier, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsFunctionDeclatation:
					WriteIndex(FileIndexType.ScriptFunctionDeclatation, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsFunctionArgument:
					WriteIndex(FileIndexType.ScriptFunctionArgument, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsStartFunctionParenthesis:
					WriteIndex(FileIndexType.ScriptStartFunctionParenthesis, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsEndFunctionParenthesis:
					WriteIndex(FileIndexType.ScriptEndFunctionParenthesis, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsStartFunctionBlock:
					WriteIndex(FileIndexType.ScriptStartFunctionBlock, intTokenIndex, intTokenLength);
					return;
				case TokenType.JsEndFunctionBlock:
					WriteIndex(FileIndexType.ScriptEndFunctionBlock, intTokenIndex, intTokenLength);
					return;
				}
			}
			else
			{
				switch (enmTokenType)
				{
				case TokenType.CssClassDefinition:
					/*OpCode not supported: LdMemberToken*/;
					WriteIndex(FileIndexType.CssClassDefinition, intTokenIndex, intTokenLength);
					return;
				case TokenType.CssClassReference:
					/*OpCode not supported: LdMemberToken*/;
					WriteIndex(FileIndexType.CssClassReference, intTokenIndex, intTokenLength);
					return;
				}
			}
			base.LoadIndex(enmTokenType, strTokenContent, intTokenIndex, intTokenLength, intTokenLine, objTokenContext);
			return;
			IL_0292:
			switch (CurrentCodeBlock.Keyword)
			{
			case "if":
				/*OpCode not supported: LdMemberToken*/;
				break;
			case "for":
				/*OpCode not supported: LdMemberToken*/;
				break;
			default:
				H = true;
				break;
			case "switch":
			case "foreach":
				break;
			}
			goto IL_02f9;
			IL_0252:
			H = true;
			goto IL_02f9;
		}

		private void TrackCodeBlocks(TokenType enmTokenType, string strTokenContent)
		{
			switch (enmTokenType)
			{
			case TokenType.JsStartBracket:
				/*OpCode not supported: LdMemberToken*/;
				L.Push(new CodeBlockInfo(K, CodeBlockType.Brackets));
				break;
			case TokenType.JsStartBlock:
			case TokenType.JsStartFunctionBlock:
				L.Push(new CodeBlockInfo(K, CodeBlockType.Braces));
				break;
			case TokenType.JsStartParenthesis:
			case TokenType.JsStartFunctionParenthesis:
				L.Push(new CodeBlockInfo(K, CodeBlockType.Parenthesis));
				break;
			}
			if (enmTokenType <= TokenType.Comment)
			{
				switch (enmTokenType)
				{
				case TokenType.Unkown:
					/*OpCode not supported: LdMemberToken*/;
					return;
				case TokenType.Comment:
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
			}
			else
			{
				switch (enmTokenType)
				{
				case TokenType.JsKeyword:
					K = strTokenContent;
					return;
				case TokenType.Whitespace:
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			K = string.Empty;
		}

		private void CloseCodeBlockIfNeeded(TokenType enmTokenType)
		{
			switch (enmTokenType)
			{
			default:
				/*OpCode not supported: LdMemberToken*/;
				break;
			case TokenType.JsEndFunctionBlock:
			case TokenType.JsEndBlock:
			case TokenType.JsEndParenthesis:
			case TokenType.JsEndFunctionParenthesis:
			case TokenType.JsEndBracket:
				L.Pop();
				break;
			case TokenType.JsStartParenthesis:
			case TokenType.JsStartFunctionParenthesis:
				break;
			}
		}

		private void RegisterLoadIndexScriptBlockError(int intTokenLine, int intTokenIndex)
		{
			WriteIndex(FileIndexType.ScriptMissingSemicolon, intTokenIndex, 0);
		}
	}
}
