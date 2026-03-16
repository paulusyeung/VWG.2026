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
	public class StatusBarPanelController : ComponentController
	{
		public System.Windows.Forms.StatusBarPanel WebStatusBarPanel => base.SourceObject as System.Windows.Forms.StatusBarPanel;

		public System.Windows.Forms.StatusBarPanel WinStatusBarPanel => base.TargetObject as System.Windows.Forms.StatusBarPanel;

		public StatusBarPanelController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public StatusBarPanelController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinStatusBarPanelText();
			SetWinStatusBarPanelWidth();
			SetWinStatusBarPanelAutoSize();
			SetWinStatusBarPanelAlignment();
		}

		protected virtual void SetWinStatusBarPanelText()
		{
			WinStatusBarPanel.Text = WebStatusBarPanel.Text;
		}

		protected virtual void SetWinStatusBarPanelWidth()
		{
			WinStatusBarPanel.Width = Convert.ToInt32((float)WebStatusBarPanel.Width * base.TargetHorizontalScaleFactor);
		}

		protected virtual void SetWinStatusBarPanelAutoSize()
		{
			WinStatusBarPanel.AutoSize = (System.Windows.Forms.StatusBarPanelAutoSize)GetConvertedEnum(typeof(System.Windows.Forms.StatusBarPanelAutoSize), WebStatusBarPanel.AutoSize);
		}

		protected virtual void SetWinStatusBarPanelAlignment()
		{
			WinStatusBarPanel.Alignment = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebStatusBarPanel.Alignment);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.StatusBarPanel();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinStatusBarPanelText();
				break;
			case "Width":
				SetWinStatusBarPanelWidth();
				break;
			case "AutoSize":
				SetWinStatusBarPanelAutoSize();
				break;
			case "Alignment":
				SetWinStatusBarPanelAlignment();
				break;
			}
		}
	}
}


