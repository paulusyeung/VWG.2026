using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client
{
	internal class EmbededResource
	{
		private string mstrResource = string.Empty;

		private Assembly mobjAssembly = null;

		public bool IsValid => ResourceInfo != null;

		public ManifestResourceInfo ResourceInfo
		{
			get
			{
				if (mobjAssembly != null)
				{
					return mobjAssembly.GetManifestResourceInfo(mstrResource);
				}
				return null;
			}
		}

		internal EmbededResource(Assembly objAssembly, string strResource)
		{
			mobjAssembly = objAssembly;
			if (objAssembly != null)
			{
				mstrResource = objAssembly.FullName.Split(',')[0] + "." + strResource;
			}
		}

		public Stream ToStream()
		{
			return mobjAssembly.GetManifestResourceStream(mstrResource);
		}

		public XmlDocument ToXml()
		{
			XmlDocument xmlDocument = new XmlDocument();
			Stream stream = ToStream();
			try
			{
				xmlDocument.Load(stream);
			}
			catch (Exception ex)
			{
				stream.Close();
				throw new Exception(mstrResource + ": " + ex.Message, ex);
			}
			stream.Close();
			return xmlDocument;
		}

		public override string ToString()
		{
			StreamReader streamReader = new StreamReader(ToStream());
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			return result;
		}

		public void WriteToStream(Stream objOutputStream)
		{
			Stream stream = ToStream();
			if (stream != null)
			{
				byte[] array = new byte[stream.Length];
				stream.Read(array, 0, (int)stream.Length);
				objOutputStream.Write(array, 0, array.Length);
				objOutputStream.Flush();
				stream.Close();
			}
		}
	}
}
