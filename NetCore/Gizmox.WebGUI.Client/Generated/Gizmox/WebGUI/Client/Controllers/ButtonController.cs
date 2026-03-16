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
	public class ButtonController : ButtonBaseControler
	{
		private ContextMenuController mobjDropDownMenuController = null;

		protected ContextMenuController DropDownMenuController
		{
			get
			{
				if (mobjDropDownMenuController == null && WebButton != null && WebButton.DropDownMenu != null)
				{
					System.Windows.Forms.ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
					mobjDropDownMenuController = new ContextMenuController(base.Context, WebButton.DropDownMenu, contextMenu);
					mobjDropDownMenuController.Initialize();
					RegisterController(mobjDropDownMenuController);
					if (WebButton.DropDownMenu.Site != null && contextMenu != null)
					{
						base.DesignServices.RegisterWinComponent(contextMenu, WebButton.DropDownMenu.Site.Name);
					}
				}
				return mobjDropDownMenuController;
			}
		}

		public Gizmox.WebGUI.Forms.Button WebButton => base.SourceObject as Gizmox.WebGUI.Forms.Button;

		public ClientButton WinButton => base.TargetObject as ClientButton;

		public ButtonController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public ButtonController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinButtonDropDownMenu();
			SetWinButtonAutoSizeMode();
		}

		protected virtual void SetWinButtonDropDownMenu()
		{
			if (DropDownMenuController != null)
			{
				WinButton.DropDownMenu = DropDownMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinButtonAutoSizeMode()
		{
			WinButton.AutoSizeMode = (System.Windows.Forms.AutoSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.AutoSizeMode), WebButton.AutoSizeMode);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientButton();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "AutoSizeMode")
			{
				SetWinButtonAutoSizeMode();
			}
		}
	}
}


