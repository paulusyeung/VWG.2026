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

namespace Gizmox.WebGUI.Forms.Skins
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SkinTranslator
	{
		private IContext mobjContext;

		public SkinTranslator(IContext objContext)
		{
			mobjContext = objContext;
		}

		internal static string GetValue(IContext objContext, object objValue, SkinValueDefinition objValueDefinition)
		{
			return GetValue(objContext, objValue, objValueDefinition, blnSupportsMultilineSkinValues: false);
		}

		private static string GetValue(IContext objContext, object objValue, SkinValueDefinition objValueDefinition, bool blnSupportsMultilineSkinValues)
		{
			if (objValue == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			if (!(objValue is SkinValue))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(objValue is Color))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(objValue is Font))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (objValue is string)
						{
							return (string)objValue;
						}
						if (!(objValue is int))
						{
							/*OpCode not supported: LdMemberToken*/;
							TypeConverter converter = TypeDescriptor.GetConverter(objValue);
							if (converter == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (!converter.CanConvertTo(typeof(SkinValue)))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								SkinValue skinValue = (SkinValue)converter.ConvertTo(objValue, typeof(SkinValue));
								if (skinValue != null)
								{
									return skinValue.GetValue(objContext, objValueDefinition);
								}
								/*OpCode not supported: LdMemberToken*/;
							}
							return $"{objValue}";
						}
						return objValue.ToString();
					}
					return GetFont(objContext, (Font)objValue, objValueDefinition);
				}
				return GetColor(objContext, (Color)objValue, objValueDefinition);
			}
			string text = ((SkinValue)objValue).GetValue(objContext, objValueDefinition);
			if (!(!string.IsNullOrEmpty(text) && blnSupportsMultilineSkinValues))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = text.Replace(";", ";\r\n");
			}
			return text;
		}

		internal string GetValue(object objValue, SkinValueDefinition objValueDefinition, bool blnSupportsMultilineSkinValues)
		{
			return GetValue(mobjContext, objValue, objValueDefinition, blnSupportsMultilineSkinValues);
		}

		public static string GetColor(IContext objContext, Color objColor)
		{
			return GetColor(objContext, objColor, SkinValueDefinition.Empty);
		}

		public static string GetColor(IContext objContext, Color objColor, SkinValueDefinition objValueDefinition)
		{
			if (objColor.A != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Format("color:#{0}{1}{2}{3}", objColor.R.ToString("X2", null), objColor.G.ToString("X2", null), objColor.B.ToString("X2", null), objValueDefinition.GetImportantDeclarationValue(objContext));
			}
			return "color:transparent";
		}

		public static string GetFont(IContext objContext, Font objFont)
		{
			return GetFont(objContext, objFont, SkinValueDefinition.Empty);
		}

		public static string GetFont(IContext objContext, Font objFont, SkinValueDefinition objValueDefinition)
		{
			StringBuilder stringBuilder = new StringBuilder("font:");
			if (objFont.Italic)
			{
				stringBuilder.Append("italic ");
			}
			else
			{
				stringBuilder.Append("normal ");
			}
			stringBuilder.Append("normal ");
			if (!objFont.Bold)
			{
				/*OpCode not supported: LdMemberToken*/;
				stringBuilder.Append("normal ");
			}
			else
			{
				stringBuilder.Append("bold ");
			}
			switch (objFont.Unit)
			{
			case GraphicsUnit.Pixel:
				stringBuilder.AppendFormat("{0}px ", objFont.Size.ToString(CultureInfo.InvariantCulture));
				break;
			case GraphicsUnit.Point:
				stringBuilder.AppendFormat("{0}pt ", objFont.Size.ToString(CultureInfo.InvariantCulture));
				break;
			case GraphicsUnit.Inch:
				stringBuilder.AppendFormat("{0}in ", objFont.Size.ToString(CultureInfo.InvariantCulture));
				break;
			case GraphicsUnit.Millimeter:
				stringBuilder.AppendFormat("{0}mm ", objFont.Size.ToString(CultureInfo.InvariantCulture));
				break;
			}
			stringBuilder.AppendFormat("{0} ", objFont.FontFamily.Name);
			string importantDeclarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
			stringBuilder.Append(importantDeclarationValue);
			string text = "none";
			if (objFont.Underline || objFont.Strikeout)
			{
				text = string.Empty;
				if (objFont.Underline)
				{
					text = "underline";
				}
				if (!objFont.Strikeout)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (string.IsNullOrEmpty(text))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text = $"{text} ";
					}
					text = $"{text}line-through{importantDeclarationValue}";
				}
			}
			stringBuilder.Append(";text-decoration:" + text);
			return stringBuilder.ToString();
		}
	}
}
