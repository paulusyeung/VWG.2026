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

namespace Gizmox.WebGUI.Client.Forms
{
	internal class ApplicationForm : ClientForm
	{
		private Context mobjContext = null;

		[NonSerialized]
		private Container components = null;

		internal ApplicationForm(Type objType, Context objContext)
		{
			mobjContext = objContext;
			InitializeComponent(objType);
		}

		private void InitializeComponent(System.Type objType)
		{
			Gizmox.WebGUI.Common.Global.Context = this.mobjContext;
			if (System.Activator.CreateInstance(objType) is Gizmox.WebGUI.Forms.Form form)
			{
				form.Visible = true;
				Gizmox.WebGUI.Client.Controllers.FormController formController = new Gizmox.WebGUI.Client.Controllers.FormController(this.mobjContext, form, this);
				this.mobjContext.MainForm = form;
				((Gizmox.WebGUI.Client.Design.IContextServices)this.mobjContext).RegisterController((Gizmox.WebGUI.Client.Design.IClientObjectController)formController);
				formController.Initialize();
				formController.Load();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
