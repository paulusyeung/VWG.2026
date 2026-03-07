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

namespace Gizmox.WebGUI.Common.DeviceRepository
{
	public class MappedFormsLoader
	{
		private MappedFormsLoader()
		{
		}

		public static Dictionary<string, Dictionary<Type, MappedFormInfo>> GetMappedFormsList()
		{
			Dictionary<string, Dictionary<Type, MappedFormInfo>> dictionary = new Dictionary<string, Dictionary<Type, MappedFormInfo>>();
			XmlElement xmlElement = null;
			if (HostRuntime.Config != null)
			{
				xmlElement = HostRuntime.Config.GetSection("FormFactory");
				if (xmlElement == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					IEnumerator enumerator = xmlElement.ChildNodes.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							XmlElement xmlElement2 = (XmlElement)enumerator.Current;
							if (!xmlElement2.Name.Equals("Form", StringComparison.OrdinalIgnoreCase))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							if (!xmlElement2.HasAttribute("Type"))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							Type type = Type.GetType(CommonUtils.GetFullTypeName(xmlElement2.GetAttribute("Type")), throwOnError: false);
							IEnumerator enumerator2 = xmlElement2.ChildNodes.GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									/*OpCode not supported: LdMemberToken*/;
									XmlElement xmlElement3 = (XmlElement)enumerator2.Current;
									if (!xmlElement3.Name.Equals("SubForm", StringComparison.OrdinalIgnoreCase))
									{
										continue;
									}
									if (!xmlElement3.HasAttribute("BrowserId"))
									{
										/*OpCode not supported: LdMemberToken*/;
										continue;
									}
									if (!xmlElement2.HasAttribute("Type"))
									{
										/*OpCode not supported: LdMemberToken*/;
										continue;
									}
									string attribute = xmlElement3.GetAttribute("Theme");
									string attribute2 = xmlElement3.GetAttribute("Type");
									string attribute3 = xmlElement3.GetAttribute("BrowserId");
									if (dictionary.ContainsKey(attribute3))
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										dictionary.Add(attribute3, new Dictionary<Type, MappedFormInfo>());
									}
									if (dictionary[attribute3].ContainsKey(type))
									{
										/*OpCode not supported: LdMemberToken*/;
										throw new DeviceRepositoryException("Error while loading form factory definitions: More then one mapped form for current device.");
									}
									MappedFormInfo value = new MappedFormInfo(attribute2, attribute);
									dictionary[attribute3].Add(type, value);
								}
							}
							finally
							{
								if (!(enumerator2 is IDisposable disposable))
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
					finally
					{
						if (!(enumerator is IDisposable disposable2))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							disposable2.Dispose();
						}
					}
				}
			}
			return dictionary;
		}

		public static string GetFormBrowserId(XmlDocument objConfigFile, string strFormType)
		{
			XmlNode xmlNode = objConfigFile.SelectSingleNode($"//WebGUI/FormFactory/Form/SubForm[@Type='{strFormType}']");
			if (xmlNode == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return xmlNode.Attributes["BrowserId"].Value;
		}
	}
}
