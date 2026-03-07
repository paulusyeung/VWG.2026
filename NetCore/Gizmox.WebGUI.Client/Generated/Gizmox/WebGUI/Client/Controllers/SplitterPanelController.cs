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
	public class SplitterPanelController : PanelController
	{
		public System.Windows.Forms.SplitterPanel TargetSplitterPanel => base.TargetObject as System.Windows.Forms.SplitterPanel;

		public Gizmox.WebGUI.Forms.SplitterPanel SourceSplitterPanel => base.SourceObject as Gizmox.WebGUI.Forms.SplitterPanel;

		public SplitterPanelController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public SplitterPanelController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override void SetWinControlDock()
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinSplitterPanelName();
		}

		private void SetWinSplitterPanelName()
		{
			if (TargetSplitterPanel != null && SourceSplitterPanel != null)
			{
				((System.Windows.Forms.Control)TargetSplitterPanel).Name = ((Gizmox.WebGUI.Forms.Control)SourceSplitterPanel).Name;
			}
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			System.Windows.Forms.SplitContainer owner = null;
			if (objSourceObject != null && objSourceObject is Gizmox.WebGUI.Forms.SplitterPanel && ((Gizmox.WebGUI.Forms.SplitterPanel)objSourceObject).Parent != null && GetControllerByWebObject(((Gizmox.WebGUI.Forms.SplitterPanel)objSourceObject).Parent) is SplitContainerController splitContainerController)
			{
				owner = splitContainerController.TargetSplitContainer;
			}
			return new System.Windows.Forms.SplitterPanel(owner);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Name")
			{
				SetWinSplitterPanelName();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}
	}
}
