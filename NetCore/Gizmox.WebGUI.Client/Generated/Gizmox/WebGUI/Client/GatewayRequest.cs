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
	internal class GatewayRequest : HttpWorkerRequest
	{
		public override string GetFilePath()
		{
			return "/gateway.aspx";
		}

		public override string GetUriPath()
		{
			return null;
		}

		public override string GetQueryString()
		{
			return "";
		}

		public string GetRawUrl()
		{
			return "http://clientgateway.com/gateway.aspx";
		}

		public override string GetHttpVerbName()
		{
			return "GET";
		}

		public override string GetHttpVersion()
		{
			return "1.1";
		}

		public override string GetRemoteAddress()
		{
			return "";
		}

		public override int GetRemotePort()
		{
			return 80;
		}

		public override string GetLocalAddress()
		{
			return "";
		}

		public override int GetLocalPort()
		{
			return 0;
		}

		public override void SendStatus(int statusCode, string statusDescription)
		{
		}

		public override void SendKnownResponseHeader(int index, string value)
		{
		}

		public override void SendUnknownResponseHeader(string name, string value)
		{
		}

		public override void SendResponseFromMemory(byte[] data, int length)
		{
		}

		public override void SendResponseFromFile(IntPtr handle, long offset, long length)
		{
		}

		public override void SendResponseFromFile(string filename, long offset, long length)
		{
		}

		public override void FlushResponse(bool finalFlush)
		{
		}

		public override void EndOfRequest()
		{
		}
	}
}
