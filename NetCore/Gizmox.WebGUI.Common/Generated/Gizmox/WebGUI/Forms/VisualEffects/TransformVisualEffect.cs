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
	public class TransformVisualEffect : VisualEffect
	{
		private Transformation[] marrTransformations;

		private Location mobjOrigin;

		[Category("Transformation Origin")]
		public Location Origin
		{
			get
			{
				return mobjOrigin;
			}
			set
			{
				mobjOrigin = value;
			}
		}

		[Category("Transformations")]
		public Transformation[] Transformations
		{
			get
			{
				return marrTransformations;
			}
			set
			{
				marrTransformations = value;
			}
		}

		public TransformVisualEffect(Transformation[] arrTransformations, Location objOrigin)
		{
			marrTransformations = arrTransformations;
			if (marrTransformations != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				marrTransformations = new Transformation[0];
			}
			mobjOrigin = objOrigin;
		}

		public TransformVisualEffect()
		{
			marrTransformations = new Transformation[0];
			mobjOrigin = new Location();
		}

		public override object[] GetConstroctorArguments()
		{
			return new object[2] { marrTransformations, mobjOrigin };
		}

		public override string ToString()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			Transformation[] array = marrTransformations;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Transformation transformation = array[i];
				text = text + text2 + transformation.SerializeToString();
				text2 = "+";
			}
			return CommonUtils.Join("|", typeof(TransformVisualEffect).FullName, text, mobjOrigin.SerializeToString()) + ";";
		}

		public override string ToString(IContext objContext)
		{
			string basePropertyPrefixByContext = GetBasePropertyPrefixByContext(objContext);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(basePropertyPrefixByContext);
			stringBuilder.Append("transform:");
			Transformation[] array = marrTransformations;
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Transformation transformation = array[i];
				stringBuilder.Append(transformation.ToHtmlString(objContext));
				stringBuilder.Append(" ");
			}
			stringBuilder.Append(";");
			string value = mobjOrigin.ToHtmlString();
			if (string.IsNullOrEmpty(value))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append(basePropertyPrefixByContext);
				stringBuilder.Append(value);
				stringBuilder.Append(";");
			}
			return stringBuilder.ToString();
		}

		public static implicit operator TransformVisualEffect(string strTransformationVisualEffect)
		{
			TransformVisualEffect transformVisualEffect = new TransformVisualEffect();
			transformVisualEffect.InitializeFromString(strTransformationVisualEffect);
			return transformVisualEffect;
		}

		private Location ParseOrigin(string strOrigin)
		{
			return Location.DeserializeString(strOrigin);
		}

		private Transformation[] ParseTransformations(string strTransformations)
		{
			List<Transformation> list = new List<Transformation>();
			string[] array = strTransformations.Split(new string[1] { "+" }, StringSplitOptions.None);
			foreach (string strTransformation in array)
			{
				list.Add(Transformation.DeserializeString(strTransformation));
			}
			return list.ToArray();
		}

		protected internal override List<Type> GetConstructorTypes()
		{
			List<Type> list = new List<Type>();
			list.AddRange(new Type[2]
			{
				typeof(Transformation[]),
				typeof(Location)
			});
			return list;
		}

		protected internal override void InitializeFromString(string strVisualEffect)
		{
			string[] array = strVisualEffect.Split(new string[1] { "|" }, StringSplitOptions.None);
			if (array.Length != 3)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			marrTransformations = ParseTransformations(array[1]);
			mobjOrigin = ParseOrigin(array[2]);
		}

		protected internal override bool IsSupported(IContext objContext)
		{
			if (objContext is IContextParams contextParams)
			{
				return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.CSSTransforms) == CSS3BrowserCapabilities.CSSTransforms;
			}
			return false;
		}

		public override object Clone()
		{
			TransformVisualEffect transformVisualEffect = base.Clone() as TransformVisualEffect;
			CloneInternal(transformVisualEffect);
			return transformVisualEffect;
		}

		private void CloneInternal(TransformVisualEffect objNew)
		{
			if (marrTransformations.Length == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				List<Transformation> list = new List<Transformation>(marrTransformations.Length);
				Transformation[] array = marrTransformations;
				for (int i = 0; i < array.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					Transformation item = array[i].Clone() as Transformation;
					list.Add(item);
				}
				objNew.marrTransformations = list.ToArray();
			}
			objNew.mobjOrigin = new Location(mobjOrigin.HorizontalDirection, mobjOrigin.HorizontalUnits, mobjOrigin.VerticalDirection, mobjOrigin.VerticalUnits, mobjOrigin.HorizontalLength, mobjOrigin.VerticalLength);
		}
	}
}
