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
	[TypeConverter(typeof(BoxShadowVisualEffectTypeConverter))]
	public class BoxShadowVisualEffect : VisualEffect
	{
		public const string BoxShadowAttribute = "box-shadow";

		private int mintHorizontalShadow = 1;

		private int mintVerticalShadow = 1;

		private int mintBlurDistance = 1;

		private int mintSpreadDistance = 1;

		private Color mobjShadowColor = Color.DarkGray;

		private bool mblnInset;

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

		[DefaultValue(1)]
		public int BlurDistance
		{
			get
			{
				return mintBlurDistance;
			}
			set
			{
				if (value < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mintBlurDistance = value;
				}
			}
		}

		[DefaultValue(1)]
		public int SpreadDistance
		{
			get
			{
				return mintSpreadDistance;
			}
			set
			{
				mintSpreadDistance = value;
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

		[DefaultValue(false)]
		public bool Inset
		{
			get
			{
				return mblnInset;
			}
			set
			{
				mblnInset = value;
			}
		}

		public override bool IsAggregated => true;

		public override string[] Attributes => new string[1] { "box-shadow" };

		public override string[] Values => new string[1] { RenderShadowValue() };

		public BoxShadowVisualEffect()
		{
		}

		public BoxShadowVisualEffect(int intHorizontalShadow, int intVerticalShadow, int intBlurDistance, int intSpreadDistance, Color objShadowColor, bool blnInset)
		{
			mintHorizontalShadow = intHorizontalShadow;
			mintBlurDistance = intBlurDistance;
			mintSpreadDistance = intSpreadDistance;
			mintVerticalShadow = intVerticalShadow;
			mobjShadowColor = objShadowColor;
			mblnInset = blnInset;
		}

		public override object[] GetConstroctorArguments()
		{
			return new object[6] { mintHorizontalShadow, mintVerticalShadow, mintBlurDistance, mintSpreadDistance, mobjShadowColor, mblnInset };
		}

		public override string ToString(IContext objContext)
		{
			return string.Format("{0}:{1};", "box-shadow", RenderShadowValue());
		}

		public string RenderShadowValue()
		{
			object obj;
			if (Inset)
			{
				/*OpCode not supported: LdMemberToken*/;
				obj = "inset";
			}
			else
			{
				obj = string.Empty;
			}
			string text = (string)obj;
			return $"{mintHorizontalShadow}px {mintVerticalShadow}px {mintBlurDistance}px {mintSpreadDistance}px {CommonUtils.GetHtmlColor(mobjShadowColor)} {text}";
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BoxShadow) == CSS3BrowserCapabilities.BoxShadow;
		}

		public override string ToString()
		{
			object[] obj = new object[7]
			{
				typeof(BoxShadowVisualEffect).FullName,
				mintHorizontalShadow,
				mintVerticalShadow,
				mintBlurDistance,
				mintSpreadDistance,
				CommonUtils.GetHtmlColor(mobjShadowColor),
				null
			};
			object obj2;
			if (Inset)
			{
				/*OpCode not supported: LdMemberToken*/;
				obj2 = "1";
			}
			else
			{
				obj2 = "0";
			}
			obj[6] = obj2;
			return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6};", obj);
		}

		public static implicit operator BoxShadowVisualEffect(string strBoxShadowVisualEffect)
		{
			BoxShadowVisualEffect boxShadowVisualEffect = new BoxShadowVisualEffect();
			boxShadowVisualEffect.InitializeFromString(strBoxShadowVisualEffect);
			return boxShadowVisualEffect;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			if (string.IsNullOrEmpty(strVisualEffect))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length == 7)
			{
				HorizontalShadow = int.Parse(array[1]);
				VerticalShadow = int.Parse(array[2]);
				BlurDistance = int.Parse(array[3]);
				SpreadDistance = int.Parse(array[4]);
				ShadowColor = ColorTranslator.FromHtml(array[5]);
				int inset;
				if (array[6] == "1")
				{
					/*OpCode not supported: LdMemberToken*/;
					inset = 1;
				}
				else
				{
					inset = 0;
				}
				Inset = (byte)inset != 0;
			}
		}

		public override object Clone()
		{
			BoxShadowVisualEffect boxShadowVisualEffect = base.Clone() as BoxShadowVisualEffect;
			CloneInternal(boxShadowVisualEffect);
			return boxShadowVisualEffect;
		}

		private void CloneInternal(BoxShadowVisualEffect objNew)
		{
			objNew.mblnInset = mblnInset;
			objNew.mintBlurDistance = mintBlurDistance;
			objNew.mintHorizontalShadow = mintHorizontalShadow;
			objNew.mintSpreadDistance = mintSpreadDistance;
			objNew.mintVerticalShadow = mintVerticalShadow;
			objNew.mobjShadowColor = mobjShadowColor;
		}
	}
}
