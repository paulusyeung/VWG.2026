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
	internal class TC
	{
		internal static byte[] A(Stream A)
		{
			byte b = (byte)A.ReadByte();
			byte[] array = new byte[A.Length - 1];
			A.Read(array, 0, array.Length);
			if ((b & 1) == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				byte[] array2 = new byte[8];
				Buffer.BlockCopy(array, 0, array2, 0, 8);
				dESCryptoServiceProvider.IV = array2;
				byte[] array3 = new byte[8];
				Buffer.BlockCopy(array, 8, array3, 0, 8);
				bool flag = true;
				byte[] array4 = array3;
				for (int i = 0; i < array4.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (array4[i] != 0)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					array3 = Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();
				}
				dESCryptoServiceProvider.Key = array3;
				array = dESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 16, array.Length - 16);
			}
			if ((b & 2) == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				try
				{
					MemoryStream memoryStream = new MemoryStream(array);
					DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
					MemoryStream memoryStream2 = new MemoryStream((int)memoryStream.Length * 2);
					int num = 1000;
					byte[] buffer = new byte[num];
					while (true)
					{
						int num2 = deflateStream.Read(buffer, 0, num);
						if (num2 <= 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							memoryStream2.Write(buffer, 0, num2);
						}
						if (num2 < num)
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					array = memoryStream2.ToArray();
				}
				catch (Exception)
				{
				}
			}
			return array;
		}
	}
}
