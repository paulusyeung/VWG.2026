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
	[Serializable]
	public class BrowserRepository : IDeviceRepository, IDesignTimeDeviceRepository, INonSerializable
	{
		[Serializable]
		public class BrowserInfo
		{
			private string mstrBrowserId;

			private string mstrParentId;

			private BrowserInfo mobjParentBrowserInfo;

			private UserAgentMatch mobjUserAgent;

			private List<BrowserInfoTags> mobjIdentification = new List<BrowserInfoTags>();

			private List<BrowserInfoTags> mobjCapture = new List<BrowserInfoTags>();

			private Dictionary<string, string> mobjCapabilities = new Dictionary<string, string>();

			private List<BrowserInfo> mobjChildBrowsers = new List<BrowserInfo>();

			public string this[string CapabilityName, bool blnWithInheritance]
			{
				get
				{
					if (mobjCapabilities == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (mobjCapabilities.ContainsKey(CapabilityName))
						{
							return mobjCapabilities[CapabilityName];
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					if (blnWithInheritance)
					{
						if (mobjParentBrowserInfo != null)
						{
							return mobjParentBrowserInfo[CapabilityName];
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					return null;
				}
			}

			public string this[string CapabilityName] => this[CapabilityName, true];

			public string BrowserId => mstrBrowserId;

			public string ParentId => mstrParentId;

			public BrowserInfo ParentBrowserInfo
			{
				get
				{
					return mobjParentBrowserInfo;
				}
				set
				{
					mobjParentBrowserInfo = value;
				}
			}

			public BrowserInfo()
			{
			}

			public BrowserInfo(XmlElement objBrowser)
			{
				mstrBrowserId = objBrowser.GetAttribute("Id");
				if (!objBrowser.HasAttribute("ParentId"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrParentId = objBrowser.GetAttribute("ParentId");
				}
				IEnumerator enumerator = objBrowser.SelectNodes("Identification/*").GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						XmlElement xmlElement = (XmlElement)enumerator.Current;
						if (!xmlElement.Name.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							if (!xmlElement.HasAttribute("Match"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (mobjUserAgent == null)
							{
								mobjUserAgent = new UserAgentMatch(xmlElement.GetAttribute("Match"));
								mobjIdentification.Add(mobjUserAgent);
							}
							else
							{
								mobjIdentification.Add(new UserAgentMatch(xmlElement.GetAttribute("Match")));
							}
							if (!xmlElement.HasAttribute("NonMatch"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new UserAgentNonMatch(xmlElement.GetAttribute("NonMatch")));
							}
						}
						if (xmlElement.Name.Equals("Header", StringComparison.OrdinalIgnoreCase))
						{
							if (!xmlElement.HasAttribute("Match"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new HeaderMatch(xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("Match")));
							}
							if (!xmlElement.HasAttribute("NonMatch"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new HeaderNonMatch(xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("NonMatch")));
							}
						}
						if (!xmlElement.Name.Equals("Capability", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							if (!xmlElement.HasAttribute("Match"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new CapabilityMatch(this, xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("Match")));
							}
							if (!xmlElement.HasAttribute("NonMatch"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new CapabilityNonMatch(this, xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("NonMatch")));
							}
						}
						if (xmlElement.Name.Equals("SystemCapability", StringComparison.OrdinalIgnoreCase))
						{
							if (!xmlElement.HasAttribute("Match"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new SystemCapabilityMatch(xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("Match")));
							}
							if (!xmlElement.HasAttribute("NonMatch"))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								mobjIdentification.Add(new SystemCapabilityNonMatch(xmlElement.GetAttribute("Name"), xmlElement.GetAttribute("NonMatch")));
							}
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
				enumerator = objBrowser.SelectNodes("Capture/*").GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						XmlElement xmlElement2 = (XmlElement)enumerator.Current;
						if (!xmlElement2.Name.Equals("UserAgent", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!xmlElement2.HasAttribute("Match"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mobjCapture.Add(new UserAgentMatch(xmlElement2.GetAttribute("Match")));
						}
						if (!xmlElement2.Name.Equals("Header", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!xmlElement2.HasAttribute("Match"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mobjCapture.Add(new HeaderMatch(xmlElement2.GetAttribute("Name"), xmlElement2.GetAttribute("Match")));
						}
						if (!xmlElement2.Name.Equals("Capability", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!xmlElement2.HasAttribute("Match"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mobjCapture.Add(new CapabilityMatch(this, xmlElement2.GetAttribute("Name"), xmlElement2.GetAttribute("Match")));
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
				enumerator = objBrowser.SelectNodes("Capabilities/*").GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						XmlElement xmlElement3 = (XmlElement)enumerator.Current;
						if (!xmlElement3.Name.Equals("Capability", StringComparison.OrdinalIgnoreCase))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!xmlElement3.HasAttribute("Name"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!xmlElement3.HasAttribute("Value"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mobjCapabilities.Add(xmlElement3.GetAttribute("Name"), xmlElement3.GetAttribute("Value"));
						}
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable3))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						disposable3.Dispose();
					}
				}
			}

			public bool IsMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				bool flag = true;
				using (List<BrowserInfoTags>.Enumerator enumerator = mobjIdentification.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						BrowserInfoTags current = enumerator.Current;
						flag &= current.IsMatch(objContext, objCurrentCapabilities);
						if (!flag)
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
				}
				return flag;
			}

			internal void AddChildBrowser(BrowserInfo objBrowserInfo)
			{
				objBrowserInfo.ParentBrowserInfo = this;
				mobjChildBrowsers.Add(objBrowserInfo);
			}

			internal List<BrowserInfo> GetChildBrowsers()
			{
				return mobjChildBrowsers;
			}

			internal void SetDynamicCapabilities(HostContext objContext, Dictionary<string, string> objDynamicCapabilities)
			{
				Match match = null;
				if (mobjUserAgent == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					match = mobjUserAgent.GetMatch(objContext, objDynamicCapabilities);
				}
				foreach (string key in mobjCapabilities.Keys)
				{
					string text = mobjCapabilities[key];
					if (text.IndexOf('$') < 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (match == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						string text2 = match.Result(text);
						if (text2.IndexOf('$') >= 0)
						{
							using List<BrowserInfoTags>.Enumerator enumerator2 = mobjCapture.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								BrowserInfoTags current2 = enumerator2.Current;
								if (current2.GetMatch(objContext, objDynamicCapabilities).Success)
								{
									text2 = current2.GetMatch(objContext, objDynamicCapabilities).Result(text);
								}
								if (text2.IndexOf('$') < 0)
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
							}
						}
						text = text2;
					}
					if (!objDynamicCapabilities.ContainsKey(key))
					{
						/*OpCode not supported: LdMemberToken*/;
						objDynamicCapabilities.Add(key, text);
					}
					else
					{
						objDynamicCapabilities[key] = text;
					}
				}
			}
		}

		[Serializable]
		internal abstract class BrowserInfoTags
		{
			private string mstrMatchString;

			protected Regex mobjRegex;

			public string MatchString => mstrMatchString;

			public BrowserInfoTags(string strMatchString)
			{
				mstrMatchString = strMatchString;
			}

			protected void Init()
			{
				if (mobjRegex != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjRegex = new Regex(MatchString);
				}
			}

			public virtual bool IsMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				return GetMatch(objContext, objCurrentCapabilities)?.Success ?? true;
			}

			public abstract Match GetMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities);
		}

		[Serializable]
		internal class UserAgentMatch : BrowserInfoTags
		{
			public UserAgentMatch(string strMatchString)
				: base(strMatchString)
			{
			}

			public override Match GetMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				Init();
				return mobjRegex.Match(objContext.Request.UserAgent);
			}
		}

		[Serializable]
		internal class UserAgentNonMatch : UserAgentMatch
		{
			public UserAgentNonMatch(string strMatchString)
				: base(strMatchString)
			{
			}

			public override bool IsMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				return !base.IsMatch(objContext, objCurrentCapabilities);
			}
		}

		[Serializable]
		internal class HeaderMatch : BrowserInfoTags
		{
			protected string mstrName;

			public HeaderMatch(string strName, string strMatchString)
				: base(strMatchString)
			{
				mstrName = strName;
			}

			public override Match GetMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				Init();
				if (!string.IsNullOrEmpty(objContext.Request.Headers[mstrName]))
				{
					return mobjRegex.Match(objContext.Request.Headers[mstrName]);
				}
				return null;
			}
		}

		[Serializable]
		internal class HeaderNonMatch : HeaderMatch
		{
			public HeaderNonMatch(string strName, string strMatchString)
				: base(strName, strMatchString)
			{
			}

			public override bool IsMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				return !base.IsMatch(objContext, objCurrentCapabilities);
			}
		}

		[Serializable]
		internal class CapabilityMatch : BrowserInfoTags
		{
			protected string mstrName;

			protected BrowserInfo mobjCurrentBrowser;

			public CapabilityMatch(BrowserInfo objCurrentBrowser, string strName, string strMatchString)
				: base(strMatchString)
			{
				mstrName = strName;
				mobjCurrentBrowser = objCurrentBrowser;
			}

			public override Match GetMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				Init();
				if (!objCurrentCapabilities.ContainsKey(mstrName))
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return mobjRegex.Match(objCurrentCapabilities[mstrName]);
			}
		}

		[Serializable]
		internal class CapabilityNonMatch : CapabilityMatch
		{
			public CapabilityNonMatch(BrowserInfo objCurrentBrowser, string strName, string strMatchString)
				: base(objCurrentBrowser, strName, strMatchString)
			{
			}

			public override bool IsMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				return !base.IsMatch(objContext, objCurrentCapabilities);
			}
		}

		[Serializable]
		internal class SystemCapabilityMatch : BrowserInfoTags
		{
			protected string mstrName;

			protected BrowserInfo mobjCurrentBrowser;

			public SystemCapabilityMatch(string strName, string strMatchString)
				: base(strMatchString)
			{
				mstrName = strName;
			}

			public override Match GetMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				Init();
				string[] array = mstrName.Split('.');
				switch (array[0])
				{
				case "IDeviceContext":
				{
					/*OpCode not supported: LdMemberToken*/;
					PropertyInfo property = Type.GetType("Gizmox.WebGUI.Common.Interfaces.Device.IDeviceContext").GetProperty(array[1]);
					if (property != null)
					{
						object value = Type.GetType("Gizmox.WebGUI.Common.Interfaces.Device.IDeviceContext").GetProperty(array[1]).GetValue(objContext.VWGContext, null);
						string input = ((value == null) ? string.Empty : value.ToString());
						return mobjRegex.Match(input);
					}
					break;
				}
				case "HTML5BrowserCapabilities":
					/*OpCode not supported: LdMemberToken*/;
					goto case "CSS3BrowserCapabilities";
				case "MISCBrowserCapabilities":
					/*OpCode not supported: LdMemberToken*/;
					goto case "CSS3BrowserCapabilities";
				case "CSS3BrowserCapabilities":
				{
					int num = (int)Enum.Parse(Type.GetType("Gizmox.WebGUI.Forms." + array[0]), array[1]);
					PropertyInfo property = Type.GetType("Gizmox.WebGUI.Common.Interfaces.IContextParams").GetProperty(array[0]);
					if (!(property != null))
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					int num2 = (int)property.GetValue(objContext.VWGContext, null);
					if (num2 >= 0)
					{
						if ((num2 & num) == num)
						{
							return mobjRegex.Match("1");
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					return mobjRegex.Match("0");
				}
				default:
					return null;
				}
				return null;
			}
		}

		[Serializable]
		internal class SystemCapabilityNonMatch : SystemCapabilityMatch
		{
			public SystemCapabilityNonMatch(string strName, string strMatchString)
				: base(strName, strMatchString)
			{
			}

			public override bool IsMatch(HostContext objContext, Dictionary<string, string> objCurrentCapabilities)
			{
				return !base.IsMatch(objContext, objCurrentCapabilities);
			}
		}

		private bool mblnIsInitialised;

		private List<BrowserInfo> mobjBrowserInfos = new List<BrowserInfo>();

		private Dictionary<string, BrowserInfo> mobjBrowserInfosHash = new Dictionary<string, BrowserInfo>();

		public BrowserRepository()
		{
			Initialize(null);
		}

		private void Initialize(XmlElement objElement)
		{
			if (HostRuntime.Config == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				InitializeBrowsers(objElement);
			}
			else
			{
				objElement = HostRuntime.Config.GetSection("Browsers");
				InitializeBrowsers(objElement);
			}
		}

		private void InitializeBrowsers(XmlElement objElement)
		{
			objElement = MeargeWithInternalBrowsersResource(objElement);
			if (objElement == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string xpath = "Browser";
				List<BrowserInfo> list = new List<BrowserInfo>();
				{
					IEnumerator enumerator = objElement.SelectNodes(xpath).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							BrowserInfo browserInfo = new BrowserInfo((XmlElement)enumerator.Current);
							if (mobjBrowserInfosHash.ContainsKey(browserInfo.BrowserId))
							{
								/*OpCode not supported: LdMemberToken*/;
								throw new Exception("Browsers have duplicate ids.");
							}
							mobjBrowserInfosHash.Add(browserInfo.BrowserId, browserInfo);
							list.Add(browserInfo);
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				using List<BrowserInfo>.Enumerator enumerator2 = list.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					BrowserInfo current = enumerator2.Current;
					if (!string.IsNullOrEmpty(current.ParentId))
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!mobjBrowserInfosHash.ContainsKey(current.ParentId))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mobjBrowserInfosHash[current.ParentId].AddChildBrowser(current);
						}
					}
					else
					{
						mobjBrowserInfos.Add(current);
					}
				}
			}
			mblnIsInitialised = true;
		}

		private XmlElement MeargeWithInternalBrowsersResource(XmlElement objElement)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (!(executingAssembly != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("Gizmox.WebGUI.Common.Resources.Browsers.xml");
				if (manifestResourceStream != null)
				{
					StreamReader txtReader = new StreamReader(manifestResourceStream);
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(txtReader);
					if (objElement == null)
					{
						objElement = xmlDocument.DocumentElement;
					}
					else
					{
						IEnumerator enumerator = xmlDocument.DocumentElement.ChildNodes.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								XmlNode xmlNode = (XmlNode)enumerator.Current;
								XmlAttribute xmlAttribute = xmlNode.Attributes["Id"];
								if (xmlAttribute != null && objElement.SelectSingleNode($"Browser [@Id='{xmlAttribute.Value}']") == null)
								{
									XmlNode newChild = objElement.OwnerDocument.ImportNode(xmlNode, deep: true);
									objElement.AppendChild(newChild);
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
			return objElement;
		}

		public string GetBrowserId(HostContext objContext)
		{
			string result = null;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			bool flag = true;
			int num = 0;
			List<BrowserInfo> childBrowsers = mobjBrowserInfos;
			while (flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				BrowserInfo browserInfo = null;
				if (num < childBrowsers.Count)
				{
					browserInfo = childBrowsers[num];
				}
				else
				{
					flag = false;
				}
				if (browserInfo == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (browserInfo.IsMatch(objContext, dictionary))
				{
					browserInfo.SetDynamicCapabilities(objContext, dictionary);
					result = browserInfo.BrowserId;
					childBrowsers = browserInfo.GetChildBrowsers();
					num = 0;
				}
				else
				{
					num++;
				}
			}
			return result;
		}

		public string GetBrowserParentId(string strBrowserId)
		{
			string result = null;
			if (strBrowserId != null)
			{
				if (!mobjBrowserInfosHash.ContainsKey(strBrowserId))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = mobjBrowserInfosHash[strBrowserId].ParentId;
				}
			}
			return result;
		}

		public Size GetDesignerSize(IClientDesignServices objContext, string BrowserId)
		{
			if (mblnIsInitialised)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				LoadBrowsers(objContext);
			}
			if (BrowserId == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjBrowserInfosHash.ContainsKey(BrowserId))
				{
					BrowserInfo objBrowserInfo = mobjBrowserInfosHash[BrowserId];
					return GetDesignerSize(objBrowserInfo);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return default(Size);
		}

		public Size GetDesignerSize(BrowserInfo objBrowserInfo)
		{
			Size result = default(Size);
			if (objBrowserInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				int result2 = 0;
				int result3 = 0;
				string text = objBrowserInfo["VWGDesignerSize"];
				if (text == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string[] array = text.Split(',');
					if (array.Length != 2)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!int.TryParse(array[1], out result2))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!int.TryParse(array[0], out result3))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result = new Size(result3, result2);
					}
				}
			}
			return result;
		}

		public Size GetDeviceSize(IClientDesignServices objContext, string BrowserId)
		{
			if (mblnIsInitialised)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				LoadBrowsers(objContext);
			}
			if (BrowserId != null)
			{
				if (mobjBrowserInfosHash.ContainsKey(BrowserId))
				{
					BrowserInfo objBrowserInfo = mobjBrowserInfosHash[BrowserId];
					return GetDeviceSize(objBrowserInfo);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return default(Size);
		}

		public Size GetDeviceSize(BrowserInfo objBrowserInfo)
		{
			Size result = default(Size);
			int result2 = 0;
			int result3 = 0;
			string text = objBrowserInfo["VWGDeviceSize"];
			if (text == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string[] array = text.Split(',');
				if (array.Length != 2)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!int.TryParse(array[1], out result2))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!int.TryParse(array[0], out result3))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = new Size(result3, result2);
				}
			}
			return result;
		}

		public SizeF GetDeviceScaleFactor(IClientDesignServices objContext, string strBrowserId)
		{
			if (mblnIsInitialised)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				LoadBrowsers(objContext);
			}
			if (strBrowserId == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (mobjBrowserInfosHash.ContainsKey(strBrowserId))
				{
					BrowserInfo objBrowserInfo = mobjBrowserInfosHash[strBrowserId];
					return GetDeviceScaleFactor(objBrowserInfo);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return SizeF.Empty;
		}

		public SizeF GetDeviceScaleFactor(BrowserInfo objBrowserInfo)
		{
			if (objBrowserInfo != null)
			{
				Size deviceSize = GetDeviceSize(objBrowserInfo);
				Size designerSize = GetDesignerSize(objBrowserInfo);
				if (deviceSize.IsEmpty)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!designerSize.IsEmpty)
					{
						return new SizeF(1f * (float)designerSize.Width / (float)deviceSize.Width, 1f * (float)designerSize.Height / (float)deviceSize.Height);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return SizeF.Empty;
		}

		public SizeF GetDeviceInvertedScaleFactor(BrowserInfo objBrowserInfo)
		{
			if (objBrowserInfo != null)
			{
				Size deviceSize = GetDeviceSize(objBrowserInfo);
				Size designerSize = GetDesignerSize(objBrowserInfo);
				if (deviceSize.IsEmpty)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!designerSize.IsEmpty)
					{
						return new SizeF(1f * (float)deviceSize.Width / (float)designerSize.Width, 1f * (float)deviceSize.Height / (float)designerSize.Height);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return SizeF.Empty;
		}

		public Image GetBackgroundImage(IClientDesignServices objContext, string strBrowserId)
		{
			if (!mblnIsInitialised)
			{
				LoadBrowsers(objContext);
			}
			if (strBrowserId != null)
			{
				if (!mobjBrowserInfosHash.ContainsKey(strBrowserId))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					BrowserInfo browserInfo = mobjBrowserInfosHash[strBrowserId];
					string text = browserInfo["VWGDeviceImage"];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = browserInfo["VWGDeviceImageAssembly"];
						if (!string.IsNullOrEmpty(text2))
						{
							Assembly assembly = null;
							try
							{
								assembly = Assembly.Load(text2);
							}
							catch
							{
							}
							if (assembly != null)
							{
								Stream manifestResourceStream = assembly.GetManifestResourceStream(text);
								if (manifestResourceStream != null)
								{
									return Image.FromStream(manifestResourceStream);
								}
								/*OpCode not supported: LdMemberToken*/;
							}
						}
						else
						{
							string namedDirecotry = objContext.GetNamedDirecotry("Images");
							string text3;
							if (!Path.IsPathRooted(text))
							{
								/*OpCode not supported: LdMemberToken*/;
								text3 = Path.GetFullPath(namedDirecotry + "\\" + text);
							}
							else
							{
								text3 = text;
							}
							if (File.Exists(text3))
							{
								return Image.FromFile(text3);
							}
						}
					}
				}
			}
			return null;
		}

		public void GetMargin(IClientDesignServices objContext, string BrowserId, out int Left, out int Top, out int Right, out int Bottom)
		{
			Left = (Top = (Right = (Bottom = 0)));
			if (mblnIsInitialised)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				LoadBrowsers(objContext);
			}
			if (BrowserId == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!mobjBrowserInfosHash.ContainsKey(BrowserId))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			BrowserInfo objBrowserInfo = mobjBrowserInfosHash[BrowserId];
			GetMargin(objBrowserInfo, 0, out Left, out Top, out Right, out Bottom);
		}

		public void GetMargin(BrowserInfo objBrowserInfo, int intDefault, out int intLeft, out int intTop, out int intRight, out int intBottom)
		{
			intLeft = (intTop = (intRight = (intBottom = intDefault)));
			if (objBrowserInfo == null)
			{
				return;
			}
			string text = objBrowserInfo["VWGDeviceImageMargin"];
			try
			{
				if (text == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				string[] array = text.Split(',');
				if (array.Length == 4)
				{
					_ = new int[4];
					intLeft = int.Parse(array[0]);
					intTop = int.Parse(array[1]);
					intRight = int.Parse(array[2]);
					intBottom = int.Parse(array[3]);
				}
			}
			catch
			{
			}
		}

		private void LoadBrowsers(IClientDesignServices objContext)
		{
			string configurationPath = objContext.GetConfigurationPath(null);
			if (string.IsNullOrEmpty(configurationPath))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(configurationPath);
			XmlElement objElement = xmlDocument.SelectSingleNode("//WebGUI/Browsers") as XmlElement;
			Initialize(objElement);
		}

		public BrowserInfo[] GetBrowserInfos()
		{
			BrowserInfo[] array = new BrowserInfo[mobjBrowserInfosHash.Count];
			if (mobjBrowserInfos == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjBrowserInfosHash.Values.CopyTo(array, 0);
			}
			return array;
		}
	}
}
