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
	public class PanelController : ScrollableControlController
	{
		public Gizmox.WebGUI.Forms.Panel WebPanel => base.SourceObject as Gizmox.WebGUI.Forms.Panel;

		public System.Windows.Forms.Panel WinPanel => base.TargetObject as System.Windows.Forms.Panel;

		public ClientPanel WinClientPanel => base.TargetObject as ClientPanel;

		public PanelController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public PanelController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinPanelPanelType();
			SetWinControlBorderStyle();
		}

		protected virtual void SetWinPanelPanelType()
		{
			if (WinClientPanel != null && !base.DesignMode)
			{
				WinClientPanel.PanelType = WebPanel.PanelType;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientPanel();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWinControlAutoSize();
				break;
			case "AutoSizeMode":
				SetWinControlAutoSizeMode();
				break;
			case "BorderStyle":
				SetWinControlBorderStyle();
				break;
			}
		}

		protected override void SetWinControlBorderStyle()
		{
			if (Enum.GetName(typeof(System.Windows.Forms.BorderStyle), WebPanel.BorderStyle) != null)
			{
				WinPanel.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebPanel.BorderStyle, WinPanel.BorderStyle);
			}
		}

		protected override void SetWebControlBorderStyle()
		{
			WebPanel.BorderStyle = (Gizmox.WebGUI.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WinPanel.BorderStyle, WebPanel.BorderStyle);
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWebControlAutoSize();
				break;
			case "AutoSizeMode":
				SetWebControlAutoSizeMode();
				break;
			case "BorderStyle":
				SetWebControlAutoSize();
				break;
			}
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			SetWinControlAutoSize();
			SetWebControlAutoSize();
			SetWinControlAutoSizeMode();
			SetWebControlAutoSizeMode();
		}

		protected new virtual void SetWinControlAutoSize()
		{
			WinPanel.AutoSize = WebPanel.AutoSize;
		}

		protected virtual void SetWebControlAutoSize()
		{
			WebPanel.AutoSize = WinPanel.AutoSize;
		}

		protected virtual void SetWinControlAutoSizeMode()
		{
			WinPanel.AutoSizeMode = (System.Windows.Forms.AutoSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.AutoSizeMode), WebPanel.AutoSizeMode);
		}

		protected virtual void SetWebControlAutoSizeMode()
		{
			WebPanel.AutoSizeMode = (Gizmox.WebGUI.Forms.AutoSizeMode)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.AutoSizeMode), WinPanel.AutoSizeMode);
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}
	}
}
