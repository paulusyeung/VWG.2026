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
	[TypeConverter(typeof(BorderRadiusVisualEffectConverter))]
	public class BorderRadiusVisualEffect : VisualEffect
	{
		private bool mblnAll;

		private int mintBorderRadiusTopLeft;

		private int mintBorderRadiusTopRight;

		private int mintBorderRadiusBottomLeft;

		private int mintBorderRadiusBottomRight;

		public int BorderRadiusAll
		{
			get
			{
				if (IsAll)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintBorderRadiusTopLeft;
				}
				return -1;
			}
			set
			{
				if (mblnAll && mintBorderRadiusTopLeft == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnAll = true;
				mintBorderRadiusBottomRight = (mintBorderRadiusBottomLeft = (mintBorderRadiusTopRight = (mintBorderRadiusTopLeft = value)));
			}
		}

		internal bool IsAll => mblnAll;

		public int BorderRadiusTopLeft
		{
			get
			{
				return mintBorderRadiusTopLeft;
			}
			set
			{
				if (mblnAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderRadiusTopLeft == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnAll = false;
				mintBorderRadiusTopLeft = value;
			}
		}

		public int BorderRadiusTopRight
		{
			get
			{
				if (!mblnAll)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintBorderRadiusTopRight;
				}
				return mintBorderRadiusTopLeft;
			}
			set
			{
				if (mblnAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderRadiusTopRight == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnAll = false;
				mintBorderRadiusTopRight = value;
			}
		}

		public int BorderRadiusBottomLeft
		{
			get
			{
				if (mblnAll)
				{
					return mintBorderRadiusTopLeft;
				}
				return mintBorderRadiusBottomLeft;
			}
			set
			{
				if (mblnAll)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mintBorderRadiusBottomLeft == value)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				mblnAll = false;
				mintBorderRadiusBottomLeft = value;
			}
		}

		public int BorderRadiusBottomRight
		{
			get
			{
				if (!mblnAll)
				{
					/*OpCode not supported: LdMemberToken*/;
					return mintBorderRadiusBottomRight;
				}
				return mintBorderRadiusTopLeft;
			}
			set
			{
				if (mblnAll || mintBorderRadiusBottomRight != value)
				{
					mblnAll = false;
					mintBorderRadiusBottomRight = value;
				}
			}
		}

		public BorderRadiusVisualEffect(int intTopLeft, int intTopRight, int intBottomLeft, int intBottomRight)
		{
			mintBorderRadiusTopLeft = intTopLeft;
			mintBorderRadiusTopRight = intTopRight;
			mintBorderRadiusBottomLeft = intBottomLeft;
			mintBorderRadiusBottomRight = intBottomRight;
			int num;
			if (mintBorderRadiusTopLeft != mintBorderRadiusTopRight)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mintBorderRadiusTopLeft == mintBorderRadiusBottomLeft)
				{
					num = ((mintBorderRadiusTopLeft == mintBorderRadiusBottomRight) ? 1 : 0);
					goto IL_0065;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			num = 0;
			goto IL_0065;
			IL_0065:
			mblnAll = (byte)num != 0;
		}

		public BorderRadiusVisualEffect(int intBorderRadiusAll)
		{
			mblnAll = true;
			mintBorderRadiusBottomRight = (mintBorderRadiusBottomLeft = (mintBorderRadiusTopRight = (mintBorderRadiusTopLeft = intBorderRadiusAll)));
		}

		public BorderRadiusVisualEffect()
		{
			mblnAll = true;
			mintBorderRadiusTopLeft = (mintBorderRadiusTopRight = (mintBorderRadiusBottomLeft = (mintBorderRadiusBottomRight = 0)));
		}

		public static implicit operator BorderRadiusVisualEffect(string strBorderRadiusVisualEffect)
		{
			BorderRadiusVisualEffect borderRadiusVisualEffect = new BorderRadiusVisualEffect();
			borderRadiusVisualEffect.InitializeFromString(strBorderRadiusVisualEffect);
			return borderRadiusVisualEffect;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length != 5)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (array.Length != 2)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					BorderRadiusAll = int.Parse(array[1]);
				}
			}
			else
			{
				BorderRadiusTopLeft = int.Parse(array[1]);
				BorderRadiusTopRight = int.Parse(array[2]);
				BorderRadiusBottomRight = int.Parse(array[3]);
				BorderRadiusBottomLeft = int.Parse(array[4]);
			}
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (objContext is IContextParams contextParams)
			{
				return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.BorderRadius) == CSS3BrowserCapabilities.BorderRadius;
			}
			return false;
		}

		public override object[] GetConstroctorArguments()
		{
			if (BorderRadiusAll < 0)
			{
				return new object[4] { BorderRadiusTopLeft, BorderRadiusTopRight, BorderRadiusBottomLeft, BorderRadiusBottomRight };
			}
			return new object[1] { BorderRadiusAll };
		}

		public override string ToString()
		{
			if (BorderRadiusAll != BorderRadiusTopRight)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (BorderRadiusAll != BorderRadiusBottomLeft)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (BorderRadiusAll == BorderRadiusBottomRight)
				{
					return $"{typeof(BorderRadiusVisualEffect).FullName}|{BorderRadiusAll};";
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return $"{typeof(BorderRadiusVisualEffect).FullName}|{BorderRadiusTopLeft}|{BorderRadiusTopRight}|{BorderRadiusBottomRight}|{BorderRadiusBottomLeft};";
		}

		public override string ToString(IContext objContext)
		{
			if (BorderRadiusAll != BorderRadiusTopRight)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (BorderRadiusAll == BorderRadiusBottomLeft)
			{
				if (BorderRadiusAll == BorderRadiusBottomRight)
				{
					return $"border-radius: {BorderRadiusAll}px;";
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return $"border-radius: {BorderRadiusTopLeft}px {BorderRadiusTopRight}px {BorderRadiusBottomRight}px {BorderRadiusBottomLeft}px;";
		}

		public override object Clone()
		{
			BorderRadiusVisualEffect borderRadiusVisualEffect = base.Clone() as BorderRadiusVisualEffect;
			CloneInternal(borderRadiusVisualEffect);
			return borderRadiusVisualEffect;
		}

		private void CloneInternal(BorderRadiusVisualEffect objNew)
		{
			objNew.mblnAll = mblnAll;
			objNew.mintBorderRadiusTopLeft = mintBorderRadiusTopLeft;
			objNew.mintBorderRadiusTopRight = mintBorderRadiusTopRight;
			objNew.mintBorderRadiusBottomLeft = mintBorderRadiusBottomLeft;
			objNew.mintBorderRadiusBottomRight = mintBorderRadiusBottomRight;
		}
	}
}
