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
	public class TransitionDescriptor : ICloneable
	{
		private TransitionTimingFunction menmTimingFunction;

		private Dictionary<TransitionTimingFunction, string> mdicTimingFunctionCSSName;

		private decimal mlngDelay;

		private decimal mlngDuration;

		private string mstrBaseValue;

		private string mstrPropertyName = string.Empty;

		private string mstrTransitionedValue;

		private string mstrValuePattern = "{0}";

		private string mstrDurationPattern = "{0}s";

		private string mstrDelayPattern = "{0}s";

		private bool mblnIsRendered;

		private bool mblnIsRenderOnce = true;

		public string BaseValue
		{
			get
			{
				return mstrBaseValue;
			}
			set
			{
				mstrBaseValue = value;
			}
		}

		public decimal Delay
		{
			get
			{
				return mlngDelay;
			}
			set
			{
				mlngDelay = value;
			}
		}

		public decimal Duration
		{
			get
			{
				return mlngDuration;
			}
			set
			{
				mlngDuration = value;
			}
		}

		public string PropertyName
		{
			get
			{
				return mstrPropertyName;
			}
			set
			{
				mstrPropertyName = value;
			}
		}

		public TransitionTimingFunction TimingFunction
		{
			get
			{
				return menmTimingFunction;
			}
			set
			{
				menmTimingFunction = value;
			}
		}

		public string TransitionedValue
		{
			get
			{
				return mstrTransitionedValue;
			}
			set
			{
				mstrTransitionedValue = value;
			}
		}

		public string ValuePattern
		{
			get
			{
				return mstrValuePattern;
			}
			set
			{
				mstrValuePattern = value;
			}
		}

		public string DelayPattern
		{
			get
			{
				return mstrDelayPattern;
			}
			set
			{
				mstrDelayPattern = value;
			}
		}

		public string DurationPattern
		{
			get
			{
				return mstrDurationPattern;
			}
			set
			{
				mstrDurationPattern = value;
			}
		}

		public bool IsRenderOnce
		{
			get
			{
				return mblnIsRenderOnce;
			}
			set
			{
				mblnIsRenderOnce = value;
			}
		}

		public bool IsRendered
		{
			get
			{
				return mblnIsRendered;
			}
			set
			{
				mblnIsRendered = value;
			}
		}

		public TransitionDescriptor()
		{
			Init();
		}

		public void Init()
		{
			mdicTimingFunctionCSSName = new Dictionary<TransitionTimingFunction, string>();
			mdicTimingFunctionCSSName.Add(TransitionTimingFunction.Ease, "ease");
			mdicTimingFunctionCSSName.Add(TransitionTimingFunction.Linear, "linear");
			mdicTimingFunctionCSSName.Add(TransitionTimingFunction.EaseIn, "ease-in");
			mdicTimingFunctionCSSName.Add(TransitionTimingFunction.EaseInOut, "ease-in-out");
			mdicTimingFunctionCSSName.Add(TransitionTimingFunction.EaseOut, "ease-out");
			mdicTimingFunctionCSSName.Add(TransitionTimingFunction.CubicBezier, "cubicbezier");
		}

		internal string GetTimingFunctionName()
		{
			return mdicTimingFunctionCSSName[TimingFunction];
		}

		public object Clone()
		{
			return new TransitionDescriptor
			{
				BaseValue = BaseValue,
				Delay = Delay,
				DelayPattern = DelayPattern,
				Duration = Duration,
				DurationPattern = DurationPattern,
				IsRendered = IsRendered,
				IsRenderOnce = IsRenderOnce,
				PropertyName = PropertyName,
				TimingFunction = TimingFunction,
				TransitionedValue = TransitionedValue,
				ValuePattern = ValuePattern
			};
		}
	}
}
