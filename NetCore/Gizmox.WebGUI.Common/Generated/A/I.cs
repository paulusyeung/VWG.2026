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
	internal class I : HostExceptionFormatter
	{
		private string F;

		protected Exception G;

		protected ArrayList H;

		private bool m_I;

		protected Exception J;

		protected int K;

		protected string L;

		protected string M;

		protected string N;

		protected override string ColoredSquare2Content
		{
			get
			{
				if (F != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					bool flag = true;
					int num = 0;
					for (int num2 = H.Count - 1; num2 >= 0; num2--)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num2 < H.Count - 1)
						{
							stringBuilder.Append("\r\n");
						}
						Exception ex = (Exception)H[num2];
						stringBuilder.Append("[" + H[num2].GetType().Name);
						if (!(ex is ExternalException))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (((ExternalException)ex).ErrorCode == 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							stringBuilder.Append(" (0x" + ((ExternalException)ex).ErrorCode.ToString("x", CultureInfo.CurrentCulture) + ")");
						}
						if (ex.Message == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (ex.Message.Length <= 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							stringBuilder.Append(": " + ex.Message);
						}
						stringBuilder.Append("]\r\n");
						StackTrace stackTrace = new StackTrace(ex, fNeedFileInfo: true);
						for (int i = 0; i < stackTrace.FrameCount; i++)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (!flag)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								num = stringBuilder.Length;
							}
							StackFrame frame = stackTrace.GetFrame(i);
							MethodBase method = frame.GetMethod();
							Type declaringType = method.DeclaringType;
							string text = string.Empty;
							if (!(declaringType != null))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								string text2 = null;
								try
								{
									text2 = declaringType.Assembly.CodeBase;
								}
								catch
								{
								}
								if (text2 == null)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else if (string.Compare(Path.GetDirectoryName(text2), HostRuntime.CodegenDir, StringComparison.OrdinalIgnoreCase) != 0)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else if (frame.GetNativeOffset() > 0)
								{
									m_I = true;
								}
								text = declaringType.Namespace;
							}
							if (text == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								text += ".";
							}
							if (declaringType == null)
							{
								stringBuilder.Append("   " + method.Name + "(");
							}
							else
							{
								stringBuilder.Append("   " + text + declaringType.Name + "." + method.Name + "(");
							}
							ParameterInfo[] parameters = method.GetParameters();
							for (int j = 0; j < parameters.Length; j++)
							{
								/*OpCode not supported: LdMemberToken*/;
								stringBuilder.Append(((j != 0) ? ", " : string.Empty) + parameters[j].ParameterType.Name + " " + parameters[j].Name);
							}
							stringBuilder.Append(")");
							string fileName = frame.GetFileName();
							if (fileName == null)
							{
								/*OpCode not supported: LdMemberToken*/;
								stringBuilder.Append(" +" + frame.GetNativeOffset());
							}
							else if (fileName != null)
							{
								if (M != null)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									M = fileName;
									K = frame.GetFileLineNumber();
								}
								stringBuilder.Append(" in " + fileName + ":" + frame.GetFileLineNumber());
							}
							if (!flag)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								stringBuilder.ToString(num, stringBuilder.Length - num);
							}
							stringBuilder.Append("\r\n");
						}
						flag = false;
					}
					F = HttpUtility.HtmlEncode(stringBuilder.ToString());
				}
				return F;
			}
		}

		protected override string ColoredSquare2Title => "Stack Trace";

		protected override string ColoredSquareContent => null;

		protected override string ColoredSquareTitle => null;

		protected override string Description
		{
			get
			{
				if (L == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return "An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.";
				}
				return L;
			}
		}

		protected override string ErrorTitle
		{
			get
			{
				string message = J.Message;
				if (string.IsNullOrEmpty(message))
				{
					/*OpCode not supported: LdMemberToken*/;
					return "Unhandled Execution Error";
				}
				return HttpUtility.HtmlEncode(message);
			}
		}

		protected override Exception Exception => G;

		protected override string MiscSectionContent
		{
			get
			{
				string fullName = J.GetType().FullName;
				StringBuilder stringBuilder = new StringBuilder(fullName);
				string text = fullName;
				if (J.Message == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string text2 = HttpUtility.HtmlEncode(J.Message);
					stringBuilder.Append(": ");
					stringBuilder.Append(text2);
					text = text + ": " + text2;
				}
				return stringBuilder.ToString();
			}
		}

		protected override string MiscSectionTitle => "Exception Details";

		protected override string PhysicalPath => M;

		protected override string PostMessage => N;

		protected override bool ShowSourceFileInfo => M != null;

		protected override int SourceFileLineNumber => K;

		protected override bool WrapColoredSquareContentLines => M == null;

		internal I(Exception e)
			: this(e, null, null)
		{
		}

		internal I(Exception e, string message, string postMessage)
		{
			H = new ArrayList();
			L = message;
			N = postMessage;
			G = e;
		}

		internal override void PrepareFormatter()
		{
			for (Exception ex = G; ex != null; ex = ex.InnerException)
			{
				/*OpCode not supported: LdMemberToken*/;
				H.Add(ex);
				J = ex;
			}
			F = ColoredSquare2Content;
		}
	}
}
