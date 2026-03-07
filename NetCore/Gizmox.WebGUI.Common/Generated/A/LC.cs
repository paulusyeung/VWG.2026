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

namespace A
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal static class LC
	{
		private class KC
		{
			private readonly int A;

			private readonly int B;

			private static KC C = new KC();

			public static KC Empty => C;

			public int Width => B;

			public int Height => A;

			private KC()
			{
			}

			private KC(Image objImage)
			{
				A = objImage.Height;
				B = objImage.Width;
			}

			internal static KC Create(ResourceHandle objResourceHandle)
			{
				if (objResourceHandle == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					try
					{
						Image image = objResourceHandle.ToImage();
						if (image != null)
						{
							return new KC(image);
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					catch
					{
					}
				}
				return Empty;
			}
		}

		private static Dictionary<string, KC> A = new Dictionary<string, KC>();

		private static object B = new object();

		private static KC GetResourceData(ResourceHandle objResourceHandle)
		{
			KC value = null;
			if (objResourceHandle == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!objResourceHandle.IsResourceDataSupported)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new NotSupportedException("The resource handle does not support extrating data.");
				}
				string uniqueIdentifier = objResourceHandle.GetUniqueIdentifier();
				if (string.IsNullOrEmpty(uniqueIdentifier))
				{
					throw new NotSupportedException("The resource handle does not have a unique identifer.");
				}
				if (A.TryGetValue(uniqueIdentifier, out value))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object b = B;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(b, ref lockTaken);
						if (A.TryGetValue(uniqueIdentifier, out value))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							value = (A[uniqueIdentifier] = KC.Create(objResourceHandle));
						}
					}
					finally
					{
						if (!lockTaken)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							Monitor.Exit(b);
						}
					}
				}
			}
			return value;
		}

		internal static int GetHeight(ResourceHandle objResourceHandle)
		{
			return GetResourceData(objResourceHandle)?.Height ?? 0;
		}

		internal static int GetWidth(ResourceHandle objResourceHandle)
		{
			KC resourceData = GetResourceData(objResourceHandle);
			if (resourceData == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 0;
			}
			return resourceData.Width;
		}
	}
}
