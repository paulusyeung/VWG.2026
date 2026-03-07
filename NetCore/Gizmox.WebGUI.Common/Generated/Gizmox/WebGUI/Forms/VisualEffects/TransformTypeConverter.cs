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
	public class TransformTypeConverter : VisualEffectCommonTypeConverterBase
	{
		public TransformTypeConverter()
			: base(typeof(Transformation))
		{
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
		{
			PropertyDescriptorCollection properties = base.GetProperties(objContext, objValue, arrAttributes);
			PropertyDescriptor propertyDescriptor = properties["TransformType"];
			if (propertyDescriptor == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return properties;
			}
			TransformType transformType = (TransformType)propertyDescriptor.GetValue(objValue);
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			propertyDescriptorCollection.Add(propertyDescriptor);
			switch (transformType)
			{
			case TransformType.Rotate:
				propertyDescriptorCollection.Add(properties["RotationDegrees"]);
				break;
			case TransformType.Matrix:
				propertyDescriptorCollection.Add(properties["Matrix"]);
				break;
			case TransformType.Translate:
				propertyDescriptorCollection.Add(properties["TranslateValues"]);
				break;
			case TransformType.Scale:
				propertyDescriptorCollection.Add(properties["ScaleValues"]);
				break;
			case TransformType.Skew:
				propertyDescriptorCollection.Add(properties["SkewX"]);
				propertyDescriptorCollection.Add(properties["SkewY"]);
				break;
			default:
				throw new NotImplementedException();
			}
			return propertyDescriptorCollection;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string strTransformation)
			{
				/*OpCode not supported: LdMemberToken*/;
				return Transformation.DeserializeString(strTransformation);
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (!(destinationType == null))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(value is Transformation))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Transformation transformation = (Transformation)value;
					if (destinationType == typeof(string))
					{
						return $"{transformation.GetType().Name} - {transformation.TransformType.ToString()}";
					}
					/*OpCode not supported: LdMemberToken*/;
					if (!(destinationType == typeof(InstanceDescriptor)))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						ConstructorInfo constructor = typeof(Transformation).GetConstructor(new Type[7]
						{
							typeof(TransformType),
							typeof(float),
							typeof(Matrix),
							typeof(float?),
							typeof(float?),
							typeof(AxisValue),
							typeof(AxisLengthAndUnits)
						});
						if (constructor != null)
						{
							return new InstanceDescriptor(constructor, new object[7] { transformation.TransformType, transformation.RotationDegrees, transformation.Matrix, transformation.SkewX, transformation.SkewY, transformation.ScaleValues, transformation.TranslateValues });
						}
						/*OpCode not supported: LdMemberToken*/;
					}
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
			throw new ArgumentNullException("destinationType");
		}
	}
}
