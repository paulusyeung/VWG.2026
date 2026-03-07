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
	[TypeConverter(typeof(GradientBackgroundVisualEffectTypeConverter))]
	public class GradientBackgroundVisualEffect : VisualEffect
	{
		private GradientType menmGradientType;

		private HorizontalDirection menmToPositionHorizontal;

		private VerticalDirection menmToPositionVertical;

		private float? mintDegrees;

		private GradientStop[] mobjGradientStops;

		private RadialShape? menmRadialShape;

		private LengthUnits menmRadialPositionHorizontalUnits;

		private LengthUnits menmRadialPositionVerticalUnits;

		private ExtentKeyword? menmExtentKeyword;

		private float? mobjRadialHorizontalLocation;

		private float? mobjRadialVerticalLocation;

		[Category("Radial Gradient")]
		public RadialShape? RadialShape
		{
			get
			{
				return menmRadialShape;
			}
			set
			{
				menmRadialShape = value;
			}
		}

		[Category("Radial Gradient")]
		public LengthUnits RadialPositionHorizontalUnits
		{
			get
			{
				return menmRadialPositionHorizontalUnits;
			}
			set
			{
				menmRadialPositionHorizontalUnits = value;
			}
		}

		[Category("Radial Gradient")]
		public LengthUnits RadialPositionVerticalUnits
		{
			get
			{
				return menmRadialPositionVerticalUnits;
			}
			set
			{
				menmRadialPositionVerticalUnits = value;
			}
		}

		[Category("Radial Gradient")]
		public ExtentKeyword? RadialExtentKeyword
		{
			get
			{
				return menmExtentKeyword;
			}
			set
			{
				menmExtentKeyword = value;
			}
		}

		[Category("Radial Gradient")]
		public float? RadialHorizontalLocation
		{
			get
			{
				return mobjRadialHorizontalLocation;
			}
			set
			{
				mobjRadialHorizontalLocation = value;
			}
		}

		[Category("Radial Gradient")]
		public float? RadialVerticalLocation
		{
			get
			{
				return mobjRadialVerticalLocation;
			}
			set
			{
				mobjRadialVerticalLocation = value;
			}
		}

		[Category("Linear Gradient")]
		public float? GradientAngle
		{
			get
			{
				return mintDegrees;
			}
			set
			{
				ToPositionVertical = VerticalDirection.None;
				ToPositionHorizontal = HorizontalDirection.None;
				mintDegrees = value;
			}
		}

		[Category("Common Gradient")]
		public GradientStop[] GradientStops
		{
			get
			{
				return mobjGradientStops;
			}
			set
			{
				mobjGradientStops = value;
			}
		}

		[Category("Common Gradient")]
		public GradientType GradientType
		{
			get
			{
				return menmGradientType;
			}
			set
			{
				if (menmGradientType != value)
				{
					menmGradientType = value;
					ResetProperties();
				}
			}
		}

		[Editor("Gizmox.WebGUI.Forms.Design.Editors.GradientToPositionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[Category("Linear Gradient")]
		public HorizontalDirection ToPositionHorizontal
		{
			get
			{
				return menmToPositionHorizontal;
			}
			set
			{
				menmToPositionHorizontal = value;
				ResetAngleIfNeeded();
			}
		}

		[Editor("Gizmox.WebGUI.Forms.Design.Editors.GradientToPositionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[Category("Linear Gradient")]
		public VerticalDirection ToPositionVertical
		{
			get
			{
				return menmToPositionVertical;
			}
			set
			{
				menmToPositionVertical = value;
				ResetAngleIfNeeded();
			}
		}

		protected internal override bool IsValid => GradientStops.Length > 1;

		public GradientBackgroundVisualEffect(GradientType enmGradientType, float? intDegrees, HorizontalDirection enmToPositionHorizontal, VerticalDirection enmToPositionVertical, GradientStop[] objGradientStops, RadialShape? enmRadialShape, LengthUnits enmRadialPositionHorizontalUnits, LengthUnits enmRadialPositionVerticalUnits, ExtentKeyword? enmExtentKeyword, float? objRadialHorizontalLocation, float? objRadialVerticalLocation)
		{
			menmGradientType = enmGradientType;
			mintDegrees = intDegrees;
			menmToPositionHorizontal = enmToPositionHorizontal;
			menmToPositionVertical = enmToPositionVertical;
			mobjGradientStops = objGradientStops;
			if (mobjGradientStops != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjGradientStops = new GradientStop[0];
			}
			menmRadialShape = enmRadialShape;
			menmRadialPositionHorizontalUnits = enmRadialPositionHorizontalUnits;
			menmRadialPositionVerticalUnits = enmRadialPositionVerticalUnits;
			menmExtentKeyword = enmExtentKeyword;
			mobjRadialHorizontalLocation = objRadialHorizontalLocation;
			mobjRadialVerticalLocation = objRadialVerticalLocation;
		}

		public GradientBackgroundVisualEffect()
		{
			menmToPositionHorizontal = HorizontalDirection.None;
			menmToPositionVertical = VerticalDirection.None;
			mobjGradientStops = new GradientStop[0];
			menmRadialShape = Gizmox.WebGUI.Forms.VisualEffects.RadialShape.Circle;
			menmExtentKeyword = ExtentKeyword.FarthestCorner;
		}

		protected internal override List<Type> GetConstructorTypes()
		{
			List<Type> list = new List<Type>();
			list.AddRange(new Type[11]
			{
				typeof(GradientType),
				typeof(float?),
				typeof(HorizontalDirection),
				typeof(VerticalDirection),
				typeof(GradientStop[]),
				typeof(RadialShape?),
				typeof(LengthUnits),
				typeof(LengthUnits),
				typeof(ExtentKeyword?),
				typeof(float?),
				typeof(float?)
			});
			return list;
		}

		public override object[] GetConstroctorArguments()
		{
			return new object[11]
			{
				GradientType, GradientAngle, ToPositionHorizontal, ToPositionVertical, GradientStops, RadialShape, RadialPositionHorizontalUnits, RadialPositionVerticalUnits, RadialExtentKeyword, RadialHorizontalLocation,
				RadialVerticalLocation
			};
		}

		public static implicit operator GradientBackgroundVisualEffect(string strGradientBackgroundVisualEffect)
		{
			GradientBackgroundVisualEffect gradientBackgroundVisualEffect = new GradientBackgroundVisualEffect();
			gradientBackgroundVisualEffect.InitializeFromString(strGradientBackgroundVisualEffect);
			return gradientBackgroundVisualEffect;
		}

		public override string ToString()
		{
			string text = "null";
			string text2 = "null";
			string text3 = "null";
			string text4 = "null";
			string text5 = "null";
			if (!GradientAngle.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = GradientAngle.Value.ToString();
			}
			if (RadialShape.HasValue)
			{
				text2 = ((int)RadialShape.Value).ToString();
			}
			if (!RadialExtentKeyword.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text3 = ((int)RadialExtentKeyword.Value).ToString();
			}
			if (!RadialHorizontalLocation.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text4 = ((int)RadialHorizontalLocation.Value).ToString();
			}
			if (!RadialVerticalLocation.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text5 = ((int)RadialVerticalLocation.Value).ToString();
			}
			return CommonUtils.Join("|", GetType().FullName, (int)GradientType, text, (int)ToPositionHorizontal, (int)ToPositionVertical, StringifyGradientStops(), text2, (int)RadialPositionHorizontalUnits, (int)RadialPositionVerticalUnits, text3, text4, text5) + ";";
		}

		public override string ToString(IContext objContext)
		{
			string basePropertyPrefixByContext = GetBasePropertyPrefixByContext(objContext);
			string text = string.Empty;
			if (!(basePropertyPrefixByContext == "-webkit-"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text += GenerateWebKitGredientOldVersion();
				if (!string.IsNullOrEmpty(text))
				{
					text += ";";
				}
			}
			return text + GenerateGredient(basePropertyPrefixByContext) + ";";
		}

		private string GenerateGredient(string strBrowserPrefix)
		{
			return GradientType switch
			{
				GradientType.Linear => GenerateLinearString("background:" + strBrowserPrefix + "linear-gradient({0}{1});"), 
				GradientType.Radial => GenerateRadialString("background:" + strBrowserPrefix + "radial-gradient({0});"), 
				GradientType.RepeatingLinearGradient => GenerateLinearString("background:" + strBrowserPrefix + "repeating-linear-gradient({0}{1});"), 
				GradientType.RepeatingRadialGradient => GenerateRadialString("background:" + strBrowserPrefix + "repeating-radial-gradient({0});"), 
				_ => throw new NotImplementedException(), 
			};
		}

		private string GenerateWebKitGredientOldVersion()
		{
			string result = string.Empty;
			switch (GradientType)
			{
			case GradientType.Linear:
				result = $"background:-webkit-linear-gradient({GenerateDirectionSegment(blnRenderWebkitOldVersion: true)}{GenerateColorSegments()})";
				break;
			default:
				throw new NotImplementedException();
			case GradientType.Radial:
			case GradientType.RepeatingLinearGradient:
			case GradientType.RepeatingRadialGradient:
				break;
			}
			return result;
		}

		private string GenerateColorSegments()
		{
			List<object> list = new List<object>();
			GradientStop[] gradientStops = GradientStops;
			for (int i = 0; i < gradientStops.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				GradientStop gradientStop = gradientStops[i];
				object arg = string.Empty;
				object arg2 = string.Empty;
				if (!gradientStop.StopPosition.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					arg2 = VisualEffectCommon.GetUnitString(gradientStop.Unit);
					arg = " " + gradientStop.StopPosition.Value;
				}
				list.Add($"{CommonUtils.GetHtmlColor(gradientStop.GradientColor)}{arg}{arg2}");
			}
			return CommonUtils.Join(",", list.ToArray());
		}

		private string GenerateDirectionSegment(bool blnRenderWebkitOldVersion)
		{
			string result = string.Empty;
			string text2;
			string arg;
			object arg2;
			if (ToPositionHorizontal == HorizontalDirection.None && ToPositionVertical == VerticalDirection.None)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (GradientAngle.HasValue)
				{
					result = $"{GradientAngle}deg,";
				}
			}
			else
			{
				if (blnRenderWebkitOldVersion)
				{
					string text = string.Empty;
					text2 = string.Empty;
					switch (ToPositionVertical)
					{
					case VerticalDirection.Top:
						text2 = "bottom";
						break;
					case VerticalDirection.Bottom:
						text2 = "top";
						break;
					case VerticalDirection.Center:
						text2 = "center";
						break;
					}
					switch (ToPositionHorizontal)
					{
					case HorizontalDirection.Left:
						text = "right";
						break;
					case HorizontalDirection.Right:
						text = "left";
						break;
					case HorizontalDirection.Center:
						text = "center";
						break;
					}
					arg = text;
					if (string.IsNullOrEmpty(text))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!string.IsNullOrEmpty(text2))
					{
						/*OpCode not supported: LdMemberToken*/;
						arg2 = " ";
						goto IL_00e5;
					}
					arg2 = string.Empty;
					goto IL_00e5;
				}
				/*OpCode not supported: LdMemberToken*/;
				string arg3;
				if (ToPositionHorizontal == HorizontalDirection.None)
				{
					/*OpCode not supported: LdMemberToken*/;
					arg3 = string.Empty;
				}
				else
				{
					arg3 = ToPositionHorizontal.ToString().ToLower();
				}
				string arg4;
				if (ToPositionVertical == VerticalDirection.None)
				{
					/*OpCode not supported: LdMemberToken*/;
					arg4 = string.Empty;
				}
				else
				{
					arg4 = ToPositionVertical.ToString().ToLower();
				}
				result = $"to {arg3} {arg4},";
			}
			goto IL_01a0;
			IL_00e5:
			result = $"{arg}{arg2}{text2},";
			goto IL_01a0;
			IL_01a0:
			return result;
		}

		private string GenerateLinearString(string strCssGradientTemplate)
		{
			return string.Format(strCssGradientTemplate, GenerateDirectionSegment(blnRenderWebkitOldVersion: false), GenerateColorSegments());
		}

		private string GenerateRadialString(string strCssGradientTemplate)
		{
			return string.Format(strCssGradientTemplate, $"{GenerateLocationString()}{GenerateShapeString()}{GenerateColorSegments()}");
		}

		private string GenerateShapeString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!RadialShape.HasValue && !RadialExtentKeyword.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!RadialShape.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append(RadialShape.Value.ToString().ToLower());
					if (!RadialExtentKeyword.HasValue)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						stringBuilder.Append(" ");
					}
				}
				if (!RadialExtentKeyword.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append(GetExtentKeywordString());
				}
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString();
		}

		private string GetExtentKeywordString()
		{
			return RadialExtentKeyword.Value switch
			{
				ExtentKeyword.ClosestCorner => "closest-corner", 
				ExtentKeyword.ClosestSide => "closest-side", 
				ExtentKeyword.FarthestCorner => "farthest-corner", 
				ExtentKeyword.FarthestSide => "farthest-side", 
				_ => throw new NotImplementedException(), 
			};
		}

		private string GenerateLocationString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (RadialVerticalLocation.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!RadialHorizontalLocation.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_00fd;
			}
			if (!RadialHorizontalLocation.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
				stringBuilder.Append("center");
			}
			else
			{
				stringBuilder.Append(RadialHorizontalLocation.Value);
				stringBuilder.Append(VisualEffectCommon.GetUnitString(RadialPositionHorizontalUnits));
			}
			if (RadialVerticalLocation.HasValue)
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(RadialVerticalLocation.Value);
				stringBuilder.Append(VisualEffectCommon.GetUnitString(RadialPositionVerticalUnits));
			}
			stringBuilder.Append(",");
			goto IL_00fd;
			IL_00fd:
			return stringBuilder.ToString();
		}

		private GradientStop[] ParseGradientStops(string strGradientStops)
		{
			List<GradientStop> list = new List<GradientStop>();
			string[] array = strGradientStops.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string[] array2 = array[i].Split(' ');
				if (array2.Length != 3)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				float? intStopOccurance = null;
				if (!(array2[0] != "null"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					intStopOccurance = float.Parse(array2[0]);
				}
				GradientStop item = new GradientStop(intStopOccurance, Color.FromArgb(int.Parse(array2[2])), (LengthUnits)int.Parse(array2[1]));
				list.Add(item);
			}
			return list.ToArray();
		}

		private void ResetAngleIfNeeded()
		{
			if (ToPositionHorizontal != HorizontalDirection.None)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (ToPositionVertical == VerticalDirection.None)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mintDegrees = null;
		}

		private void ResetProperties()
		{
			RadialHorizontalLocation = null;
			RadialVerticalLocation = null;
			RadialPositionHorizontalUnits = LengthUnits.Pixel;
			RadialPositionVerticalUnits = LengthUnits.Pixel;
			RadialShape = Gizmox.WebGUI.Forms.VisualEffects.RadialShape.Circle;
			RadialExtentKeyword = ExtentKeyword.FarthestCorner;
			GradientAngle = null;
			ToPositionHorizontal = HorizontalDirection.None;
			ToPositionVertical = VerticalDirection.None;
		}

		private object StringifyGradientStops()
		{
			List<object> list = new List<object>();
			GradientStop[] gradientStops = GradientStops;
			foreach (GradientStop gradientStop in gradientStops)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (!gradientStop.StopPosition.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					stringBuilder.Append("null");
				}
				else
				{
					stringBuilder.Append(gradientStop.StopPosition.Value);
				}
				stringBuilder.Append(" ");
				stringBuilder.Append((int)gradientStop.Unit);
				stringBuilder.Append(" ");
				stringBuilder.Append(gradientStop.GradientColor.ToArgb());
				list.Add(stringBuilder.ToString());
			}
			return CommonUtils.Join(",", list.ToArray());
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length != 12)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			GradientType = (GradientType)int.Parse(array[1]);
			string text = array[2];
			if (!(text == "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
				GradientAngle = int.Parse(text);
			}
			else
			{
				GradientAngle = null;
			}
			ToPositionHorizontal = (HorizontalDirection)int.Parse(array[3]);
			ToPositionVertical = (VerticalDirection)int.Parse(array[4]);
			GradientStops = ParseGradientStops(array[5]);
			text = array[6];
			if (!(text == "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
				RadialShape = (RadialShape)int.Parse(text);
			}
			else
			{
				RadialShape = null;
			}
			RadialPositionHorizontalUnits = (LengthUnits)int.Parse(array[7]);
			RadialPositionVerticalUnits = (LengthUnits)int.Parse(array[8]);
			text = array[9];
			if (!(text == "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
				RadialExtentKeyword = (ExtentKeyword)int.Parse(text);
			}
			else
			{
				RadialExtentKeyword = null;
			}
			text = array[10];
			if (!(text == "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
				RadialHorizontalLocation = float.Parse(text);
			}
			else
			{
				RadialHorizontalLocation = null;
			}
			text = array[11];
			if (!(text == "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
				RadialVerticalLocation = float.Parse(text);
			}
			else
			{
				RadialVerticalLocation = null;
			}
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.CSSGradients) == CSS3BrowserCapabilities.CSSGradients;
		}

		public override object Clone()
		{
			GradientBackgroundVisualEffect gradientBackgroundVisualEffect = base.Clone() as GradientBackgroundVisualEffect;
			CloneInternal(gradientBackgroundVisualEffect);
			return gradientBackgroundVisualEffect;
		}

		private void CloneInternal(GradientBackgroundVisualEffect objNew)
		{
			GradientStop[] array = null;
			if (mobjGradientStops != null)
			{
				List<GradientStop> list = new List<GradientStop>(mobjGradientStops.Length);
				GradientStop[] array2 = mobjGradientStops;
				for (int i = 0; i < array2.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					GradientStop gradientStop = array2[i];
					list.Add(new GradientStop(gradientStop.StopPosition, gradientStop.GradientColor, gradientStop.Unit));
				}
				array = list.ToArray();
			}
			objNew.menmGradientType = menmGradientType;
			objNew.menmToPositionHorizontal = menmToPositionHorizontal;
			objNew.menmToPositionVertical = menmToPositionVertical;
			objNew.mintDegrees = mintDegrees;
			objNew.mobjGradientStops = array;
			objNew.menmRadialShape = menmRadialShape;
			objNew.menmRadialPositionHorizontalUnits = menmRadialPositionHorizontalUnits;
			objNew.menmRadialPositionVerticalUnits = menmRadialPositionVerticalUnits;
			objNew.menmExtentKeyword = menmExtentKeyword;
			objNew.mobjRadialHorizontalLocation = mobjRadialHorizontalLocation;
			objNew.mobjRadialVerticalLocation = mobjRadialVerticalLocation;
		}
	}
}
