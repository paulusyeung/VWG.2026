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
	internal class NC
	{
		private XmlDocument A;

		private static object B = new object();

		public XmlNodeList PresentationDrawingEngineNodes
		{
			get
			{
				TryLoadResourcesDocument();
				return A.SelectNodes("Resources/PresentationDrawingEngines/PresentationDrawingEngine");
			}
		}

		public XmlNodeList IncludeNodes
		{
			get
			{
				TryLoadResourcesDocument();
				return A.SelectNodes("Resources/Includes/Include");
			}
		}

		public XmlNodeList VisualTemplateNodes
		{
			get
			{
				TryLoadResourcesDocument();
				return A.SelectNodes("Resources/VisualTemplates/VisualTemplate");
			}
		}

		public XmlNodeList ActionNodes
		{
			get
			{
				TryLoadResourcesDocument();
				return A.SelectNodes("Resources/EnterpriseMobileServer/Actions/Action");
			}
		}

		public XmlNodeList ControlNodes
		{
			get
			{
				TryLoadResourcesDocument();
				return A.SelectNodes("Resources/Controls/Control");
			}
		}

		private void TryLoadResourcesDocument()
		{
			if (A != null)
			{
				return;
			}
			/*OpCode not supported: LdMemberToken*/;
			object b = B;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(b, ref lockTaken);
				if (A != null)
				{
					return;
				}
				Stream commonResourceStream = GetCommonResourceStream("Resources.Resources.xml");
				A = new XmlDocument();
				A.Load(commonResourceStream);
				IEnumerator enumerator = A.SelectNodes("Resources/Assemblies/Assembly").GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						Assembly assembly = TryLoadAssembly(CommonUtils.GetFullAssemblyName(((XmlNode)enumerator.Current).Attributes["Name"].Value));
						if (assembly == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						Stream resourceStream = GetResourceStream(assembly, "Resources.Resources.xml");
						if (resourceStream == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.Load(resourceStream);
						MergeResourcesNodes(A, xmlDocument);
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

		private void MergeResourcesNodes(XmlDocument objResourcesDocument, XmlDocument objResourcesAssemblyDocument)
		{
			XmlNodeList xmlNodeList = null;
			xmlNodeList = objResourcesAssemblyDocument.SelectNodes("Resources/Controls/Control");
			MergeResourcesNodes(objResourcesDocument, xmlNodeList, "Controls");
			xmlNodeList = objResourcesAssemblyDocument.SelectNodes("Resources/PresentationDrawingEngines/PresentationDrawingEngine");
			MergeResourcesNodes(objResourcesDocument, xmlNodeList, "PresentationDrawingEngines");
			xmlNodeList = objResourcesAssemblyDocument.SelectNodes("Resources/Includes/Include");
			MergeResourcesNodes(objResourcesDocument, xmlNodeList, "Includes");
			xmlNodeList = objResourcesAssemblyDocument.SelectNodes("Resources/VisualTemplates/VisualTemplate");
			MergeResourcesNodes(objResourcesDocument, xmlNodeList, "VisualTemplates");
			xmlNodeList = objResourcesAssemblyDocument.SelectNodes("Resources/EnterpriseMobileServer/Actions/Action");
			MergeResourcesNodes(objResourcesDocument, xmlNodeList, "EnterpriseMobileServer/Actions");
		}

		private void MergeResourcesNodes(XmlDocument objResourcesDocument, XmlNodeList objSourceNodes, string strParentElementName)
		{
			string[] strParentElements = strParentElementName.Split(new string[1] { "/" }, StringSplitOptions.None);
			XmlNode xmlNode = TryAddContainerElement(objResourcesDocument, strParentElements);
			foreach (XmlNode objSourceNode in objSourceNodes)
			{
				XmlNode newChild = objResourcesDocument.ImportNode(objSourceNode, deep: true);
				xmlNode.AppendChild(newChild);
			}
		}

		private XmlNode TryAddContainerElement(XmlDocument objResourcesDocument, string[] strParentElements)
		{
			XmlElement xmlElement = objResourcesDocument.DocumentElement;
			for (int i = 0; i < strParentElements.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string name = strParentElements[i];
				XmlNodeList elementsByTagName = xmlElement.GetElementsByTagName(name);
				if (elementsByTagName.Count <= 1)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (elementsByTagName.Count == 0)
					{
						XmlElement xmlElement2 = (XmlElement)objResourcesDocument.CreateNode(XmlNodeType.Element, name, objResourcesDocument.NamespaceURI);
						xmlElement.AppendChild(xmlElement2);
						xmlElement = xmlElement2;
					}
					else
					{
						xmlElement = (XmlElement)elementsByTagName[0];
					}
					continue;
				}
				throw new Exception("Application does not support this node structure for merge.");
			}
			return xmlElement;
		}

		internal static Assembly TryLoadAssembly(string strFullAssembly)
		{
			string arg = strFullAssembly;
			int num = strFullAssembly.IndexOf(",");
			if (num <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				arg = strFullAssembly.Substring(0, num);
			}
			Type type = Type.GetType(string.Format("{0}.{1}, {2}", arg, "LoadAssemblyHelper", strFullAssembly));
			if (type == null)
			{
				return null;
			}
			return type.Assembly;
		}

		private Stream GetResourceStream(Assembly objAssembly, string strResourceName)
		{
			return objAssembly.GetManifestResourceStream(objAssembly.FullName.Split(',')[0] + "." + strResourceName);
		}

		private Stream GetCommonResourceStream(string strResourceName)
		{
			Assembly commonAssembly = Config.GetInstance().GetCommonAssembly();
			return commonAssembly.GetManifestResourceStream(commonAssembly.FullName.Split(',')[0] + "." + strResourceName);
		}
	}
}
