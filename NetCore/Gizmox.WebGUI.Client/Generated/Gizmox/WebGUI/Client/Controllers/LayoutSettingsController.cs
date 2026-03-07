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

namespace Gizmox.WebGUI.Client.Controllers
{
	public abstract class LayoutSettingsController : ObjectController
	{
		public System.Windows.Forms.LayoutSettings TargetLayoutSettings => base.TargetObject as System.Windows.Forms.LayoutSettings;

		public Gizmox.WebGUI.Forms.LayoutSettings SourceLayoutSettings => base.SourceObject as Gizmox.WebGUI.Forms.LayoutSettings;

		public LayoutSettingsController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public LayoutSettingsController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return base.CreateTargetObject(objSourceObject);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}
	}
}
