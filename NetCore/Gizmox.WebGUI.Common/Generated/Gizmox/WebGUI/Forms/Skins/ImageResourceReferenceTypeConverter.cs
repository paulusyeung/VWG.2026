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

namespace Gizmox.WebGUI.Forms.Skins
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ImageResourceReferenceTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (!(sourceType == typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return base.CanConvertFrom(context, sourceType);
			}
			return true;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (!(destinationType == typeof(string)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return base.CanConvertTo(context, destinationType);
			}
			return true;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				if (value is ImageResourceReference imageResourceReference)
				{
					if (context != null)
					{
						return imageResourceReference.ResourceName;
					}
					return imageResourceReference.ResourceData;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
			{
				return ImageResourceReference.Empty;
			}
			if (!(value is string))
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_009b;
			}
			string text = (string)value;
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(text == SkinResourceReference.mstrEmptyString))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (context == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new ImageResourceReference(text);
				}
				Skin skinFromInstance = GetSkinFromInstance(context);
				if (skinFromInstance == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_009b;
				}
				return new ImageResourceReference(skinFromInstance.SkinType.FullName, text);
			}
			return ImageResourceReference.Empty;
			IL_009b:
			return base.ConvertFrom(context, culture, value);
		}

		private Skin GetSkinFromInstance(ITypeDescriptorContext objContext)
		{
			Skin skin = null;
			if (objContext != null)
			{
				if (!(objContext.Instance is ISkinContainer skinContainer))
				{
					/*OpCode not supported: LdMemberToken*/;
					skin = objContext.Instance as Skin;
				}
				else
				{
					skin = skinContainer.Skin;
				}
				if (skin != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(objContext.GetService(typeof(IContainer)) is IContainer container))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (container.Components.Count <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					skin = container.Components[0] as Skin;
				}
				if (skin == null)
				{
					if (!(objContext.GetService(typeof(ISelectionService)) is ISelectionService selectionService))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						IEnumerator enumerator = selectionService.GetSelectedComponents().GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								skin = enumerator.Current as Skin;
								if (skin != null)
								{
									break;
								}
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								disposable.Dispose();
							}
						}
					}
				}
			}
			return skin;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
		{
			List<string> list = new List<string>();
			list.Add(SkinResourceReference.mstrEmptyString);
			if (objContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Skin skinFromInstance = GetSkinFromInstance(objContext);
				if (skinFromInstance != null)
				{
					Dictionary<string, SkinResource> resources = skinFromInstance.Resources;
					foreach (string key in resources.Keys)
					{
						if (!(resources[key] is ImageResource))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(key);
						}
					}
				}
			}
			list.Sort();
			return new StandardValuesCollection(list);
		}
	}
}
