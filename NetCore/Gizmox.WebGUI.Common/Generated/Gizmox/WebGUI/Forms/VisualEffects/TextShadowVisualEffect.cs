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

namespace Gizmox.WebGUI.Forms.VisualEffects
{
	[Serializable]
	[TypeConverter(typeof(TextShadowVisualEffectTypeConverter))]
	public class TextShadowVisualEffect : VisualEffect
	{
		public const string TextShadowAttribute = "text-shadow";

		private int mintBlurDistance = 1;

		private int mintHorizontalShadow = 1;

		private int mintVerticalShadow = 1;

		private Color mobjShadowColor = Color.DarkGray;

		[DefaultValue(1)]
		public int BlurDistance
		{
			get
			{
				return mintBlurDistance;
			}
			set
			{
				mintBlurDistance = value;
			}
		}

		[DefaultValue(1)]
		public int HorizontalShadow
		{
			get
			{
				return mintHorizontalShadow;
			}
			set
			{
				mintHorizontalShadow = value;
			}
		}

		public Color ShadowColor
		{
			get
			{
				return mobjShadowColor;
			}
			set
			{
				mobjShadowColor = value;
			}
		}

		[DefaultValue(1)]
		public int VerticalShadow
		{
			get
			{
				return mintVerticalShadow;
			}
			set
			{
				mintVerticalShadow = value;
			}
		}

		public override bool IsAggregated => true;

		public override string[] Attributes => new string[1] { "text-shadow" };

		public override string[] Values => new string[1] { RenderTextShadowValue() };

		public TextShadowVisualEffect(int intHorizontalShadow, int intVerticalShadow, int intBlurDistance, Color objShadowColor)
		{
			mintHorizontalShadow = intHorizontalShadow;
			mintBlurDistance = intBlurDistance;
			mintVerticalShadow = intVerticalShadow;
			mobjShadowColor = objShadowColor;
		}

		public TextShadowVisualEffect()
		{
		}

		public override object[] GetConstroctorArguments()
		{
			return new object[4] { mintHorizontalShadow, mintVerticalShadow, mintBlurDistance, mobjShadowColor };
		}

		public static implicit operator TextShadowVisualEffect(string strTextShadowVisualEffect)
		{
			TextShadowVisualEffect textShadowVisualEffect = new TextShadowVisualEffect();
			textShadowVisualEffect.InitializeFromString(strTextShadowVisualEffect);
			return textShadowVisualEffect;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			if (string.IsNullOrEmpty(strVisualEffect))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length != 5)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			HorizontalShadow = int.Parse(array[1]);
			VerticalShadow = int.Parse(array[2]);
			BlurDistance = int.Parse(array[3]);
			ShadowColor = ColorTranslator.FromHtml(array[4]);
		}

		public override string ToString()
		{
			return $"{typeof(TextShadowVisualEffect).FullName}|{mintHorizontalShadow}|{mintVerticalShadow}|{mintBlurDistance}|{CommonUtils.GetHtmlColor(mobjShadowColor)};";
		}

		public override string ToString(IContext objContext)
		{
			return string.Format("{0}:{1};", "text-shadow", RenderTextShadowValue());
		}

		private string RenderTextShadowValue()
		{
			return $"{mintHorizontalShadow}px {mintVerticalShadow}px {mintBlurDistance}px {CommonUtils.GetHtmlColor(mobjShadowColor)}";
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.TextShadow) == CSS3BrowserCapabilities.TextShadow;
		}

		public override object Clone()
		{
			TextShadowVisualEffect textShadowVisualEffect = base.Clone() as TextShadowVisualEffect;
			CloneInternal(textShadowVisualEffect);
			return textShadowVisualEffect;
		}

		private void CloneInternal(TextShadowVisualEffect objNew)
		{
			objNew.mintBlurDistance = mintBlurDistance;
			objNew.mintHorizontalShadow = mintHorizontalShadow;
			objNew.mintVerticalShadow = mintVerticalShadow;
			objNew.mobjShadowColor = mobjShadowColor;
		}
	}
}
