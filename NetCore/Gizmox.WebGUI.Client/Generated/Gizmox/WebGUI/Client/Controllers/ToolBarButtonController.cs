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
	public class ToolBarButtonController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ToolBarButton WebToolBarButton => base.SourceObject as Gizmox.WebGUI.Forms.ToolBarButton;

		public System.Windows.Forms.ToolBarButton WinToolBarButton => base.TargetObject as System.Windows.Forms.ToolBarButton;

		public ToolBarButtonController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
		}

		public ToolBarButtonController(IContext objContext, object objWebControl)
			: base(objContext, objWebControl)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolBarButtonText();
			SetWinToolBarButtonToolTipText();
			SetWinToolBarButtonPushed();
			SetWinToolBarButtonStyle();
			SetWinToolBarButtonImageIndex();
			SetWinToolBarButtonImageKey();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinToolBarImageIndex();
		}

		protected virtual void SetWinToolBarImageIndex()
		{
			System.Windows.Forms.ToolBar parent = WinToolBarButton.Parent;
			if (parent == null)
			{
				return;
			}
			if (WebToolBarButton.Image != null)
			{
				if (parent.ImageList == null)
				{
					parent.ImageList = new System.Windows.Forms.ImageList();
				}
				WinToolBarButton.ImageIndex = GetWinImageIndex(parent.ImageList, WebToolBarButton.Image);
			}
			else if (WinToolBarButton.ImageIndex != -1)
			{
				WinToolBarButton.ImageIndex = -1;
			}
		}

		protected virtual void SetWinToolBarButtonText()
		{
			WinToolBarButton.Text = WebToolBarButton.Text;
			System.Windows.Forms.ToolBarButton winToolBarButton = WinToolBarButton;
			if (winToolBarButton != null)
			{
				typeof(System.Windows.Forms.ToolBarButton).InvokeMember("UpdateButton", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, winToolBarButton, new object[3] { true, true, false });
			}
		}

		protected virtual void SetWinToolBarButtonToolTipText()
		{
			WinToolBarButton.ToolTipText = WebToolBarButton.ToolTipText;
		}

		protected virtual void SetWinToolBarButtonPushed()
		{
			WinToolBarButton.Pushed = WebToolBarButton.Pushed;
		}

		protected virtual void SetWinToolBarButtonStyle()
		{
			WinToolBarButton.Style = (System.Windows.Forms.ToolBarButtonStyle)GetConvertedEnum(typeof(System.Windows.Forms.ToolBarButtonStyle), WebToolBarButton.Style);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolBarButton();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinToolBarButtonText();
				break;
			case "Style":
				SetWinToolBarButtonStyle();
				break;
			case "Pushed":
				SetWinToolBarButtonPushed();
				break;
			case "ToolTipText":
				SetWinToolBarButtonToolTipText();
				break;
			case "ImageIndex":
			case "Image":
				SetWinToolBarButtonImageIndex();
				break;
			case "ImageKey":
				SetWinToolBarButtonImageKey();
				break;
			}
		}

		private void SetWinToolBarButtonImageIndex()
		{
			if (WebToolBarButton.Image != null && WinToolBarButton.Parent != null)
			{
				System.Windows.Forms.ToolBar parent = WinToolBarButton.Parent;
				if (parent.ImageList == null)
				{
					parent.ImageList = new System.Windows.Forms.ImageList();
				}
				WinToolBarButton.ImageIndex = GetWinImageIndex(parent.ImageList, WebToolBarButton.Image);
			}
			else if (WinToolBarButton.ImageIndex != -1)
			{
				WinToolBarButton.ImageIndex = -1;
			}
		}

		private void SetWinToolBarButtonImageKey()
		{
			if (WebToolBarButton.Image != null && WinToolBarButton.Parent != null)
			{
				System.Windows.Forms.ToolBar parent = WinToolBarButton.Parent;
				if (parent.ImageList == null)
				{
					parent.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(parent.ImageList, WebToolBarButton.Image, WebToolBarButton.ImageKey) > -1)
				{
					WinToolBarButton.ImageKey = WebToolBarButton.ImageKey;
				}
			}
			else if (WinToolBarButton.ImageKey != string.Empty)
			{
				WinToolBarButton.ImageKey = string.Empty;
			}
		}
	}
}
