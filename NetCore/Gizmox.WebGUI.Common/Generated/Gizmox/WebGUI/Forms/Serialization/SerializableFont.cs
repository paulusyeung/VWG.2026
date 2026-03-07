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

namespace Gizmox.WebGUI.Forms.Serialization
{
	[Serializable]
	public class SerializableFont : ISerializationWrapper, ISerializable
	{
		private readonly Font mobjFont;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Bold => mobjFont.Bold;

		[Browsable(false)]
		public SerializableFontFamily FontFamily => (SerializableFontFamily)mobjFont.FontFamily;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public byte GdiCharSet => mobjFont.GdiCharSet;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool GdiVerticalFont => mobjFont.GdiVerticalFont;

		[Browsable(false)]
		public int Height => CommonUtils.GetFontHeight(mobjFont);

		[Browsable(false)]
		public bool IsSystemFont => mobjFont.IsSystemFont;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Italic => mobjFont.Italic;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Editor("System.Drawing.Design.FontNameEditor, System.Drawing.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[TypeConverter(typeof(FontConverter.FontNameConverter))]
		public string Name => mobjFont.Name;

		[Browsable(false)]
		public string OriginalFontName => mobjFont.OriginalFontName;

		public float Size => mobjFont.Size;

		[Browsable(false)]
		public float SizeInPoints => mobjFont.SizeInPoints;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Strikeout => mobjFont.Strikeout;

		[Browsable(false)]
		public FontStyle Style => mobjFont.Style;

		[Browsable(false)]
		public string SystemFontName => mobjFont.SystemFontName;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Underline => mobjFont.Underline;

		[TypeConverter(typeof(FontConverter.FontUnitConverter))]
		public GraphicsUnit Unit => mobjFont.Unit;

		object ISerializationWrapper.Value => mobjFont;

		public SerializableFont(Font objFont)
		{
			mobjFont = objFont;
		}

		private SerializableFont(SerializationInfo info, StreamingContext context)
		{
			string text = null;
			float emSize = -1f;
			FontStyle style = FontStyle.Regular;
			GraphicsUnit unit = GraphicsUnit.Point;
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!string.Equals(enumerator.Name, "Name", StringComparison.OrdinalIgnoreCase))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!string.Equals(enumerator.Name, "Size", StringComparison.OrdinalIgnoreCase))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (string.Equals(enumerator.Name, "Style", StringComparison.OrdinalIgnoreCase))
						{
							style = (FontStyle)enumerator.Value;
						}
						else if (!string.Equals(enumerator.Name, "Unit", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							unit = (GraphicsUnit)enumerator.Value;
						}
					}
					else
					{
						emSize = (float)enumerator.Value;
					}
				}
				else
				{
					text = (string)enumerator.Value;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
				mobjFont = null;
			}
			else
			{
				mobjFont = new Font(text, emSize, style, unit);
			}
		}

		public SerializableFont(Font prototype, FontStyle newStyle)
		{
			mobjFont = new Font(prototype, newStyle);
		}

		public SerializableFont(FontFamily family, float emSize)
		{
			mobjFont = new Font(family, emSize);
		}

		public SerializableFont(string familyName, float emSize)
		{
			mobjFont = new Font(familyName, emSize);
		}

		public SerializableFont(FontFamily family, float emSize, FontStyle style)
		{
			mobjFont = new Font(family, emSize, style);
		}

		public SerializableFont(FontFamily family, float emSize, GraphicsUnit unit)
		{
			mobjFont = new Font(family, emSize, unit);
		}

		public SerializableFont(string familyName, float emSize, FontStyle style)
		{
			mobjFont = new Font(familyName, emSize, style);
		}

		public SerializableFont(string familyName, float emSize, GraphicsUnit unit)
		{
			mobjFont = new Font(familyName, emSize, unit);
		}

		public SerializableFont(FontFamily family, float emSize, FontStyle style, GraphicsUnit unit)
		{
			mobjFont = new Font(family, emSize, style, unit);
		}

		public SerializableFont(string familyName, float emSize, FontStyle style, GraphicsUnit unit)
		{
			mobjFont = new Font(familyName, emSize, style, unit);
		}

		public SerializableFont(FontFamily family, float emSize, FontStyle style, GraphicsUnit unit, byte gdiCharSet)
		{
			mobjFont = new Font(family, emSize, style, unit, gdiCharSet);
		}

		public SerializableFont(string familyName, float emSize, FontStyle style, GraphicsUnit unit, byte gdiCharSet)
		{
			mobjFont = new Font(familyName, emSize, style, unit, gdiCharSet);
		}

		public SerializableFont(FontFamily family, float emSize, FontStyle style, GraphicsUnit unit, byte gdiCharSet, bool gdiVerticalFont)
		{
			mobjFont = new Font(family, emSize, style, unit, gdiCharSet, gdiVerticalFont);
		}

		public SerializableFont(string familyName, float emSize, FontStyle style, GraphicsUnit unit, byte gdiCharSet, bool gdiVerticalFont)
		{
			mobjFont = new Font(familyName, emSize, style, unit, gdiCharSet, gdiVerticalFont);
		}

		public object Clone()
		{
			return new SerializableFont(mobjFont);
		}

		public void Dispose()
		{
			mobjFont.Dispose();
		}

		public static SerializableFont FromHdc(IntPtr hdc)
		{
			return (SerializableFont)Font.FromHdc(hdc);
		}

		public static SerializableFont FromHfont(IntPtr hfont)
		{
			return (SerializableFont)Font.FromHfont(hfont);
		}

		public static SerializableFont FromLogFont(object lf)
		{
			return (SerializableFont)Font.FromLogFont(lf);
		}

		public static SerializableFont FromLogFont(object lf, IntPtr hdc)
		{
			return (SerializableFont)Font.FromLogFont(lf, hdc);
		}

		public override int GetHashCode()
		{
			return mobjFont.GetHashCode();
		}

		public float GetHeight()
		{
			return mobjFont.GetHeight();
		}

		public float GetHeight(Graphics graphics)
		{
			return mobjFont.GetHeight(graphics);
		}

		public float GetHeight(float dpi)
		{
			return mobjFont.GetHeight(dpi);
		}

		public IntPtr ToHfont()
		{
			return mobjFont.ToHfont();
		}

		public void ToLogFont(object logFont)
		{
			mobjFont.ToLogFont(logFont);
		}

		public void ToLogFont(object logFont, Graphics graphics)
		{
			mobjFont.ToLogFont(logFont, graphics);
		}

		public override string ToString()
		{
			return mobjFont.ToString();
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (mobjFont != null)
			{
				string value;
				if (string.IsNullOrEmpty(mobjFont.OriginalFontName))
				{
					/*OpCode not supported: LdMemberToken*/;
					value = mobjFont.Name;
				}
				else
				{
					value = mobjFont.OriginalFontName;
				}
				info.AddValue("Name", value);
				info.AddValue("Size", mobjFont.Size);
				info.AddValue("Style", mobjFont.Style);
				info.AddValue("Unit", mobjFont.Unit);
			}
		}

		public static implicit operator Font(SerializableFont objSerializableFont)
		{
			if (objSerializableFont == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return objSerializableFont.mobjFont;
		}

		public static explicit operator SerializableFont(Font objFont)
		{
			if (objFont == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return new SerializableFont(objFont);
		}
	}
}
