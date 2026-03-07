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
	[TypeConverter(typeof(AxisLengthAndUnitsTypeConverter))]
	public class AxisLengthAndUnits
	{
		private LengthUnits menmHorizontalLengthUnits;

		private LengthUnits menmVerticalLengthUnits;

		private LengthUnits menmDepthLengthUnits;

		private float? mobjHorizontalLength;

		private float? mobjVerticalLength;

		private float? mobjDepthLength;

		public float? HorizontalLength
		{
			get
			{
				return mobjHorizontalLength;
			}
			set
			{
				mobjHorizontalLength = value;
			}
		}

		public LengthUnits HorizontalLengthUnits
		{
			get
			{
				return menmHorizontalLengthUnits;
			}
			set
			{
				menmHorizontalLengthUnits = value;
			}
		}

		public float? VerticalLength
		{
			get
			{
				return mobjVerticalLength;
			}
			set
			{
				mobjVerticalLength = value;
			}
		}

		public float? DepthLength
		{
			get
			{
				return mobjDepthLength;
			}
			set
			{
				mobjDepthLength = value;
			}
		}

		public LengthUnits VerticalLengthUnits
		{
			get
			{
				return menmVerticalLengthUnits;
			}
			set
			{
				menmVerticalLengthUnits = value;
			}
		}

		[Editor("Gizmox.WebGUI.Forms.Design.Editors.TranslateDepthUnitsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public LengthUnits DepthLengthUnits
		{
			get
			{
				return menmDepthLengthUnits;
			}
			set
			{
				if (value != LengthUnits.Percent)
				{
					/*OpCode not supported: LdMemberToken*/;
					menmDepthLengthUnits = value;
					return;
				}
				throw new InvalidEnumArgumentException("DepthLengthUnits", (int)value, typeof(LengthUnits));
			}
		}

		public AxisLengthAndUnits(LengthUnits enmHorizontalLengthUnits, LengthUnits enmVerticalLengthUnits, float? objHorizontalLength, float? objVerticalLength)
			: this(enmHorizontalLengthUnits, enmVerticalLengthUnits, LengthUnits.Pixel, objHorizontalLength, objVerticalLength, null)
		{
		}

		public AxisLengthAndUnits(LengthUnits enmHorizontalLengthUnits, LengthUnits enmVerticalLengthUnits, LengthUnits enmDepthLengthUnits, float? objHorizontalLength, float? objVerticalLength, float? objDepthlLength)
		{
			menmHorizontalLengthUnits = enmHorizontalLengthUnits;
			menmVerticalLengthUnits = enmVerticalLengthUnits;
			menmDepthLengthUnits = enmDepthLengthUnits;
			mobjHorizontalLength = objHorizontalLength;
			mobjVerticalLength = objVerticalLength;
			mobjDepthLength = objDepthlLength;
		}

		public AxisLengthAndUnits()
		{
		}

		public string SerializeToString()
		{
			string text = "null";
			string text2 = "null";
			string text3 = "null";
			if (!mobjHorizontalLength.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = mobjHorizontalLength.Value.ToString();
			}
			if (!mobjVerticalLength.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text2 = mobjVerticalLength.Value.ToString();
			}
			if (!mobjDepthLength.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text3 = mobjDepthLength.Value.ToString();
			}
			return CommonUtils.Join(",", (int)menmHorizontalLengthUnits, (int)menmVerticalLengthUnits, (int)menmDepthLengthUnits, text, text2, text3);
		}

		internal static AxisLengthAndUnits DeserializeString(string strValues)
		{
			string[] array = strValues.Split(',');
			if (array.Length != 6)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			string empty = string.Empty;
			AxisLengthAndUnits axisLengthAndUnits = new AxisLengthAndUnits();
			int num = int.Parse(array[0]);
			int num2 = int.Parse(array[1]);
			int num3 = int.Parse(array[2]);
			if (!Enum.IsDefined(typeof(LengthUnits), num))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!Enum.IsDefined(typeof(LengthUnits), num2))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Enum.IsDefined(typeof(LengthUnits), num3))
			{
				/*OpCode not supported: LdMemberToken*/;
				axisLengthAndUnits.HorizontalLengthUnits = (LengthUnits)num;
				axisLengthAndUnits.VerticalLengthUnits = (LengthUnits)num2;
				axisLengthAndUnits.DepthLengthUnits = (LengthUnits)num3;
				empty = array[3];
				if (!(empty == "null"))
				{
					/*OpCode not supported: LdMemberToken*/;
					axisLengthAndUnits.mobjHorizontalLength = float.Parse(empty);
				}
				else
				{
					axisLengthAndUnits.mobjHorizontalLength = null;
				}
				empty = array[4];
				if (!(empty == "null"))
				{
					/*OpCode not supported: LdMemberToken*/;
					axisLengthAndUnits.mobjVerticalLength = float.Parse(empty);
				}
				else
				{
					axisLengthAndUnits.mobjVerticalLength = null;
				}
				empty = array[5];
				if (!(empty == "null"))
				{
					/*OpCode not supported: LdMemberToken*/;
					axisLengthAndUnits.mobjDepthLength = float.Parse(empty);
				}
				else
				{
					axisLengthAndUnits.mobjDepthLength = null;
				}
				return axisLengthAndUnits;
			}
			throw new ArgumentException(SR.GetString("LengthUnits_InvalidValue"));
		}
	}
}
