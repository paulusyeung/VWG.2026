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
	public class Event : EventArgs, IEvent
	{
		private NameValueCollection mobjParams = null;

		private string mstrType = string.Empty;

		private IRegisteredComponent mobjSource = null;

		private IRegisteredComponent mobjTarget = null;

		private string mstrMember = string.Empty;

		private IContext mobjContext = null;

		public string Type => mstrType;

		public string Value => string.Empty;

		public string Member => mstrMember;

		public string Source => mobjSource.ID.ToString();

		public string Target => (mobjTarget != null) ? mobjTarget.ID.ToString() : "";

		public string this[string strParam]
		{
			get
			{
				if (mobjParams == null)
				{
					return "";
				}
				return mobjParams[strParam];
			}
		}

		public Gizmox.WebGUI.Forms.Keys KeyCode
		{
			get
			{
				if (Contains("KC"))
				{
					return (Gizmox.WebGUI.Forms.Keys)Enum.Parse(typeof(Gizmox.WebGUI.Forms.Keys), this["KC"]);
				}
				return Gizmox.WebGUI.Forms.Keys.None;
			}
		}

		public bool AltKey => this["AK"] == "1";

		public bool ControlKey => this["CK"] == "1";

		public bool ShiftKey => this["SK"] == "1";

		public Point CursorPosition => Point.Empty;

		internal Event(IContext objContext, string strType, IRegisteredComponent objSource)
			: this(objContext, strType, objSource, null, "")
		{
		}

		internal Event(IContext objContext, string strType, IRegisteredComponent objSource, IRegisteredComponent objTarget)
			: this(objContext, strType, objSource, objTarget, "")
		{
		}

		internal Event(IContext objContext, string strType, IRegisteredComponent objSource, IRegisteredComponent objTarget, string strMember)
		{
			mstrType = strType;
			mobjSource = objSource;
			mobjTarget = objTarget;
			mstrMember = strMember;
			mobjContext = objContext;
		}

		public void Fire()
		{
			mobjSource.FireEvent(this);
			((IContextNotifications)mobjContext).SendNotifications();
		}

		public void SetParameter(string strName, string strValue)
		{
			if (mobjParams == null)
			{
				mobjParams = new NameValueCollection();
			}
			mobjParams[strName] = strValue;
		}

		public bool Contains(string strParam)
		{
			if (mobjParams != null)
			{
				return this[strParam] != null;
			}
			return false;
		}
	}
}
