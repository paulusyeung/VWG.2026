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
	public class TabPageController : ControlController
	{
		public Gizmox.WebGUI.Forms.TabPage WebTabPage => base.SourceObject as Gizmox.WebGUI.Forms.TabPage;

		public System.Windows.Forms.TabPage WinTabPage => base.TargetObject as System.Windows.Forms.TabPage;

		public TabPageController(IContext objContext, object objWebTabPage, object objWinTabPage)
			: base(objContext, objWebTabPage, objWinTabPage)
		{
		}

		public TabPageController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTabPageImageIndex();
			SetWinTabPageImageKey();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TabPage();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinTabPage.SizeChanged += WinTabPage_SizeChanged;
		}

		private void WinTabPage_SizeChanged(object sender, EventArgs e)
		{
			SetWebControlSize();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinTabPage.SizeChanged -= WinTabPage_SizeChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ImageKey":
				SetWinTabPageImageKey();
				break;
			case "Image":
			case "ImageIndex":
				SetWinTabPageImageIndex();
				break;
			}
		}

		protected virtual void SetWinTabPageImageKey()
		{
			if (WebTabPage.Image != null && WinTabPage.Parent != null)
			{
				System.Windows.Forms.TabControl tabControl = (System.Windows.Forms.TabControl)WinTabPage.Parent;
				if (tabControl.ImageList == null)
				{
					tabControl.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(tabControl.ImageList, WebTabPage.Image, WebTabPage.ImageKey) > -1)
				{
					WinTabPage.ImageKey = WebTabPage.ImageKey;
				}
			}
			else if (WinTabPage.ImageKey != string.Empty)
			{
				WinTabPage.ImageKey = string.Empty;
			}
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinTabPageImageIndex();
		}

		protected virtual void SetWinTabPageImageIndex()
		{
			if (WebTabPage.Image != null && WinTabPage.Parent != null)
			{
				System.Windows.Forms.TabControl tabControl = (System.Windows.Forms.TabControl)WinTabPage.Parent;
				if (tabControl.ImageList == null)
				{
					tabControl.ImageList = new System.Windows.Forms.ImageList();
				}
				WinTabPage.ImageIndex = GetWinImageIndex(tabControl.ImageList, WebTabPage.Image);
			}
			else if (WinTabPage.ImageIndex != -1)
			{
				WinTabPage.ImageIndex = -1;
			}
		}
	}
}
