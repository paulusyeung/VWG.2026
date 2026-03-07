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
	[TypeConverter(typeof(TranslateVisualEffectTypeConverter))]
	public class TranslateVisualEffect : VisualEffect
	{
		private TransitionDescriptor mobjTranslateParams;

		private Transformation mobjBeforeTransformation;

		private Transformation mobjAfterTransformation;

		protected TransitionDescriptor TranslateParams => mobjTranslateParams;

		[SRCategory("Basic Behavior")]
		public decimal TransitionDuration
		{
			get
			{
				return mobjTranslateParams.Duration;
			}
			set
			{
				if (value >= 0m)
				{
					mobjTranslateParams.Duration = value;
				}
			}
		}

		[SRCategory("Basic Behavior")]
		public decimal TransitionDelay
		{
			get
			{
				return mobjTranslateParams.Delay;
			}
			set
			{
				mobjTranslateParams.Delay = value;
			}
		}

		[SRCategory("Basic Behavior")]
		public TransitionTimingFunction TransitionTimingFunction
		{
			get
			{
				return mobjTranslateParams.TimingFunction;
			}
			set
			{
				mobjTranslateParams.TimingFunction = value;
			}
		}

		[SRCategory("Transform Data")]
		public AxisLengthAndUnits BeforeTranslate
		{
			get
			{
				return mobjBeforeTransformation.TranslateValues;
			}
			set
			{
				mobjBeforeTransformation.TranslateValues = value;
				BuildBaseValue();
			}
		}

		[SRCategory("Transform Data")]
		public AxisLengthAndUnits AfterTranslate
		{
			get
			{
				return mobjAfterTransformation.TranslateValues;
			}
			set
			{
				mobjAfterTransformation.TranslateValues = value;
				BuildTransitionedValue();
			}
		}

		public TranslateVisualEffect()
		{
			Initialize();
		}

		public TranslateVisualEffect(AxisLengthAndUnits objBeforeTransformation, AxisLengthAndUnits objAfterTransformation, decimal decDuration, decimal decDelay, TransitionTimingFunction enmTransitionTimingFunction)
			: this()
		{
			mobjBeforeTransformation.TranslateValues = objBeforeTransformation;
			mobjAfterTransformation.TranslateValues = objAfterTransformation;
			mobjTranslateParams.Duration = decDuration;
			mobjTranslateParams.Delay = decDelay;
			mobjTranslateParams.TimingFunction = enmTransitionTimingFunction;
			BuildBaseValue();
			BuildTransitionedValue();
		}

		private void Initialize()
		{
			mobjTranslateParams = new TransitionDescriptor();
			mobjBeforeTransformation = new Transformation(TransformType.Translate, 0f, new Matrix(), null, null, new AxisValue(), new AxisLengthAndUnits());
			mobjAfterTransformation = new Transformation(TransformType.Translate, 0f, new Matrix(), null, null, new AxisValue(), new AxisLengthAndUnits());
			mobjTranslateParams.PropertyName = "transform";
			mobjTranslateParams.Duration = 0m;
			mobjTranslateParams.Delay = 0m;
		}

		public override object[] GetConstroctorArguments()
		{
			return new object[5] { BeforeTranslate, AfterTranslate, mobjTranslateParams.Duration, mobjTranslateParams.Delay, mobjTranslateParams.TimingFunction };
		}

		private void BuildBaseValue()
		{
			mobjTranslateParams.BaseValue = mobjBeforeTransformation.ToHtmlString(null);
		}

		private void BuildTransitionedValue()
		{
			mobjTranslateParams.TransitionedValue = mobjAfterTransformation.ToHtmlString(null);
		}

		public override string ToString()
		{
			return CommonUtils.Join("|", GetType().FullName, mobjBeforeTransformation.TranslateValues.SerializeToString(), mobjAfterTransformation.TranslateValues.SerializeToString(), mobjTranslateParams.Duration, mobjTranslateParams.Delay, (int)mobjTranslateParams.TimingFunction) + ";";
		}

		public override string ToString(IContext objContext)
		{
			return string.Empty;
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.CSSTransitions) == CSS3BrowserCapabilities.CSSTransitions;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length == 6)
			{
				mobjBeforeTransformation.TranslateValues = AxisLengthAndUnits.DeserializeString(array[1]);
				mobjAfterTransformation.TranslateValues = AxisLengthAndUnits.DeserializeString(array[2]);
				mobjTranslateParams.Duration = decimal.Parse(array[3]);
				mobjTranslateParams.Delay = decimal.Parse(array[4]);
				mobjTranslateParams.TimingFunction = (TransitionTimingFunction)int.Parse(array[5]);
			}
		}

		protected override string GetPropertyNameByContext(string strPropertyName, IContext objContext)
		{
			string text = "";
			if (!(objContext is IContextParams contextParams))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				switch (contextParams.Browser.ToLower())
				{
				case "ie":
					/*OpCode not supported: LdMemberToken*/;
					text = "-ms-";
					break;
				case "moz":
					/*OpCode not supported: LdMemberToken*/;
					text = "-moz-";
					break;
				case "opera":
					/*OpCode not supported: LdMemberToken*/;
					text = "-o-";
					break;
				case "kit":
					text = "-webkit-";
					break;
				}
			}
			return text + strPropertyName;
		}

		public override object Clone()
		{
			TranslateVisualEffect translateVisualEffect = base.Clone() as TranslateVisualEffect;
			CloneInternal(translateVisualEffect);
			return translateVisualEffect;
		}

		private void CloneInternal(TranslateVisualEffect objNew)
		{
			objNew.mobjBeforeTransformation = (Transformation)mobjBeforeTransformation.Clone();
			objNew.mobjAfterTransformation = (Transformation)mobjAfterTransformation.Clone();
			objNew.mobjTranslateParams = (TransitionDescriptor)mobjTranslateParams.Clone();
		}
	}
}
