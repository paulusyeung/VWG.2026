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

namespace Gizmox.WebGUI.Hosting
{
	public abstract class HostExceptionFormatter
	{
		private StringCollection A;

		private StringCollection B;

		protected const string BeginLeftToRightTag = "<div dir=\"ltr\">";

		private const string C = "                      </pre></code>\r\n\r\n                  </td>\r\n               </tr>\r\n            </table>\r\n\r\n            \r\n\r\n</div>\r\n";

		protected const string EndLeftToRightTag = "</div>";

		private const string D = "<br><div class=\"expandable\" onclick=\"OnToggleTOCLevel1('{0}')\">{1}:</div>\r\n<div id=\"{0}\" style=\"display: none;\">\r\n            <br><table width=100% bgcolor=\"#ffffcc\">\r\n               <tr>\r\n                  <td>\r\n                      <code><pre>\r\n\r\n";

		private const string E = "\r\n        <script type=\"text/javascript\">\r\n        function OnToggleTOCLevel1(level2ID)\r\n        {\r\n        var elemLevel2 = document.getElementById(level2ID);\r\n        if (elemLevel2.style.display == 'none')\r\n        {\r\n            elemLevel2.style.display = '';\r\n        }\r\n        else {\r\n            elemLevel2.style.display = 'none';\r\n        }\r\n        }\r\n        </script>\r\n                            ";

		protected virtual StringCollection AdaptiveMiscContent
		{
			get
			{
				if (A == null)
				{
					A = new StringCollection();
				}
				return A;
			}
		}

		protected virtual StringCollection AdaptiveStackTrace
		{
			get
			{
				if (B == null)
				{
					B = new StringCollection();
				}
				return B;
			}
		}

		internal virtual bool CanBeShownToAllUsers => false;

		protected virtual string ColoredSquare2Content => null;

		protected virtual string ColoredSquare2Description => null;

		protected virtual string ColoredSquare2Title => null;

		protected virtual string ColoredSquareContent => null;

		protected virtual string ColoredSquareDescription => null;

		protected virtual string ColoredSquareTitle => null;

		protected abstract string Description { get; }

		protected abstract string ErrorTitle { get; }

		protected virtual Exception Exception => null;

		protected static bool IsTextRightToLeft => CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;

		protected abstract string MiscSectionContent { get; }

		protected abstract string MiscSectionTitle { get; }

		protected virtual string PhysicalPath => null;

		protected virtual string PostMessage => null;

		protected abstract bool ShowSourceFileInfo { get; }

		protected virtual int SourceFileLineNumber => 0;

		protected virtual string VirtualPath => null;

		protected virtual bool WrapColoredSquareContentLines => false;

		private string FormatStaticErrorMessage(string errorBeginTemplate, string errorEndTemplate)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = $"Server Error in '{HostRuntime.AppDomainAppVirtualPath}' Application.";
			stringBuilder.Append(string.Format(CultureInfo.CurrentCulture, errorBeginTemplate, new object[2] { text, ErrorTitle }));
			stringBuilder.Append("Description: " + Description);
			stringBuilder.Append("<br/>\r\n");
			string miscSectionTitle = MiscSectionTitle;
			if (miscSectionTitle != null)
			{
				if (miscSectionTitle.Length <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append(miscSectionTitle);
					stringBuilder.Append("<br/>\r\n");
				}
			}
			StringCollection adaptiveMiscContent = AdaptiveMiscContent;
			if (adaptiveMiscContent == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (adaptiveMiscContent.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				StringEnumerator enumerator = adaptiveMiscContent.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						stringBuilder.Append(current);
						stringBuilder.Append("<br/>\r\n");
					}
				}
				finally
				{
					if (enumerator is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
			}
			string displayPath = GetDisplayPath();
			if (string.IsNullOrEmpty(displayPath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string value = "Source File: " + displayPath;
				stringBuilder.Append(value);
				stringBuilder.Append("<br/>\r\n");
				value = "Line: " + SourceFileLineNumber;
				stringBuilder.Append(value);
				stringBuilder.Append("<br/>\r\n");
			}
			StringCollection adaptiveStackTrace = AdaptiveStackTrace;
			if (adaptiveStackTrace == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (adaptiveStackTrace.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				StringEnumerator enumerator = adaptiveStackTrace.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						string current2 = enumerator.Current;
						stringBuilder.Append(current2);
						stringBuilder.Append("<br/>\r\n");
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable2))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						disposable2.Dispose();
					}
				}
			}
			stringBuilder.Append(errorEndTemplate);
			return stringBuilder.ToString();
		}

		private string GetDisplayPath()
		{
			if (VirtualPath == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (PhysicalPath == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return PhysicalPath;
			}
			return VirtualPath;
		}

		internal string GetErrorMessage()
		{
			return GetErrorMessage(HostContext.Current, dontShowSensitiveInfo: true);
		}

		internal virtual string GetErrorMessage(HostContext context, bool dontShowSensitiveInfo)
		{
			return GetHtmlErrorMessage(dontShowSensitiveInfo);
		}

		internal string GetHtmlErrorMessage()
		{
			return GetHtmlErrorMessage(dontShowSensitiveInfo: true);
		}

		internal string GetHtmlErrorMessage(bool dontShowSensitiveInfo)
		{
			PrepareFormatter();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<html");
			if (!IsTextRightToLeft)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append(" dir=\"rtl\"");
			}
			stringBuilder.Append(">\r\n");
			stringBuilder.Append("    <head>\r\n");
			stringBuilder.Append("        <title>" + ErrorTitle + "</title>\r\n");
			stringBuilder.Append("        <style>\r\n");
			stringBuilder.Append("         body {font-family:\"Verdana\";font-weight:normal;font-size: .7em;color:black;} \r\n");
			stringBuilder.Append("         p {font-family:\"Verdana\";font-weight:normal;color:black;margin-top: -5px}\r\n");
			stringBuilder.Append("         b {font-family:\"Verdana\";font-weight:bold;color:black;margin-top: -5px}\r\n");
			stringBuilder.Append("         H1 { font-family:\"Verdana\";font-weight:normal;font-size:18pt;color:red }\r\n");
			stringBuilder.Append("         H2 { font-family:\"Verdana\";font-weight:normal;font-size:14pt;color:maroon }\r\n");
			stringBuilder.Append("         pre {font-family:\"Lucida Console\";font-size: .9em}\r\n");
			stringBuilder.Append("         .marker {font-weight: bold; color: black;text-decoration: none;}\r\n");
			stringBuilder.Append("         .version {color: gray;}\r\n");
			stringBuilder.Append("         .error {margin-bottom: 10px;}\r\n");
			stringBuilder.Append("         .expandable { text-decoration:underline; font-weight:bold; color:navy; cursor:hand; }\r\n");
			stringBuilder.Append("        </style>\r\n");
			stringBuilder.Append("    </head>\r\n\r\n");
			stringBuilder.Append("    <body bgcolor=\"white\">\r\n\r\n");
			stringBuilder.Append("            <span><H1>" + $"Server Error in '{HostRuntime.AppDomainAppVirtualPath}' Application." + "<hr width=100% size=1 color=silver></H1>\r\n\r\n");
			stringBuilder.Append("            <h2> <i>" + ErrorTitle + "</i> </h2></span>\r\n\r\n");
			stringBuilder.Append("            <font face=\"Arial, Helvetica, Geneva, SunSans-Regular, sans-serif \">\r\n\r\n");
			stringBuilder.Append("            <b> Description: </b>" + Description + "\r\n");
			stringBuilder.Append("            <br><br>\r\n\r\n");
			if (MiscSectionTitle == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("            <b> " + MiscSectionTitle + ": </b>" + MiscSectionContent + "<br><br>\r\n\r\n");
			}
			WriteColoredSquare(stringBuilder, ColoredSquareTitle, ColoredSquareDescription, ColoredSquareContent, WrapColoredSquareContentLines);
			if (ShowSourceFileInfo)
			{
				string text = GetDisplayPath();
				if (text == null)
				{
					text = "none";
				}
				stringBuilder.Append("            <b> " + "File:" + " </b> " + text + "<b> &nbsp;&nbsp; Line: </b> " + SourceFileLineNumber + "\r\n");
				stringBuilder.Append("            <br><br>\r\n\r\n");
			}
			if (dontShowSensitiveInfo)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Exception != null)
			{
				for (Exception ex = Exception; ex != null; ex = ex.InnerException)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text2 = null;
					string text3 = null;
					if (ex is FileNotFoundException ex2)
					{
						text2 = ex2.FusionLog;
						text3 = ex2.FileName;
					}
					if (!(ex is FileLoadException ex3))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text2 = ex3.FusionLog;
						text3 = ex3.FileName;
					}
					if (!(ex is BadImageFormatException ex4))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text2 = ex4.FusionLog;
						text3 = ex4.FileName;
					}
					if (!string.IsNullOrEmpty(text2))
					{
						WriteColoredSquare(stringBuilder, "Assembly Load Trace", $"The following information can be helpful to determine why the assembly '{text3}' could not be loaded.", HttpUtility.HtmlEncode(text2), wrapContentLines: false);
						break;
					}
				}
			}
			WriteColoredSquare(stringBuilder, ColoredSquare2Title, ColoredSquare2Description, ColoredSquare2Content, wrapContentLines: false);
			stringBuilder.Append("    </body>\r\n");
			stringBuilder.Append("</html>\r\n");
			stringBuilder.Append(PostMessage);
			return stringBuilder.ToString();
		}

		internal static string GetVirtualPathFromHttpLinePragma(string linePragma)
		{
			if (!string.IsNullOrEmpty(linePragma))
			{
				try
				{
					Uri uri = new Uri(linePragma);
					if (uri.Scheme == Uri.UriSchemeHttp)
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0043;
					}
					if (uri.Scheme == Uri.UriSchemeHttps)
					{
						goto IL_0043;
					}
					goto end_IL_0008;
					IL_0043:
					return uri.LocalPath;
					end_IL_0008:;
				}
				catch
				{
				}
			}
			return null;
		}

		internal static string MakeHttpLinePragma(string virtualPath)
		{
			string text = "http://server";
			if (virtualPath == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (virtualPath.StartsWith("/", StringComparison.Ordinal))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text += "/";
			}
			return new Uri(text + virtualPath).ToString();
		}

		internal virtual void PrepareFormatter()
		{
			if (A == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				A.Clear();
			}
			if (B == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				B.Clear();
			}
		}

		protected string WrapWithLeftToRightTextFormatIfNeeded(string content)
		{
			if (IsTextRightToLeft)
			{
				content = "<div dir=\"ltr\">" + content + "</div>";
			}
			return content;
		}

		private void WriteColoredSquare(StringBuilder sb, string title, string description, string content, bool wrapContentLines)
		{
			if (title == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			sb.Append("            <b>" + title + ":</b> " + description + "<br><br>\r\n\r\n");
			sb.Append("            <table width=100% bgcolor=\"#ffffcc\">\r\n");
			sb.Append("               <tr>\r\n");
			sb.Append("                  <td>\r\n");
			sb.Append("                      <code>");
			if (wrapContentLines)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				sb.Append("<pre>");
			}
			sb.Append("\r\n\r\n");
			sb.Append(content);
			if (wrapContentLines)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				sb.Append("</pre>");
			}
			sb.Append("</code>\r\n\r\n");
			sb.Append("                  </td>\r\n");
			sb.Append("               </tr>\r\n");
			sb.Append("            </table>\r\n\r\n");
			sb.Append("            <br>\r\n\r\n");
		}
	}
}
