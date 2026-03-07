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
	public class FormController : ScrollableControlController
	{
		private MainMenuController mobjMainMenuController = null;

		protected IObservableList ObservableList => base.SourceObject as IObservableList;

		public Gizmox.WebGUI.Forms.Form WebForm => base.SourceObject as Gizmox.WebGUI.Forms.Form;

		public System.Windows.Forms.Form WinForm => base.TargetObject as System.Windows.Forms.Form;

		public FormController(IContext objContext, Gizmox.WebGUI.Forms.Form objWebForm, System.Windows.Forms.Form objWinForm)
			: base(objContext, objWebForm, objWinForm)
		{
		}

		public FormController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinFormMainMenu();
			WinForm.SuspendLayout();
			SetWinFormFormBorderStyle();
			WinForm.ResumeLayout(performLayout: false);
			SetWinFormMaximizeBox();
			SetWinFormMinimizeBox();
			SetWinStartPosition();
			SetWinIsMdiContainer();
		}

		protected virtual void SetWinStartPosition()
		{
			WinForm.StartPosition = (System.Windows.Forms.FormStartPosition)GetConvertedEnum(typeof(System.Windows.Forms.FormStartPosition), WebForm.StartPosition);
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjMainMenuController != null)
			{
				mobjMainMenuController.Terminate();
			}
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			Gizmox.WebGUI.Forms.Form[] ownedForms = WebForm.OwnedForms;
			foreach (Gizmox.WebGUI.Forms.Form objWebForm in ownedForms)
			{
				System.Windows.Forms.Form form = CreateWinForm(objWebForm);
				FormController formController = new FormController(base.Context, objWebForm, form);
				RegisterController(formController);
				formController.InitializeController();
				form.ShowDialog(WinForm);
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinForm.Activated += WinForm_Activated;
			WinForm.Closed += WinForm_Closed;
			if (ObservableList != null)
			{
				ObservableList.ObservableItemAdded += ObservableList_ObservableItemAdded;
				ObservableList.ObservableItemRemoved += ObservableList_ObservableItemRemoved;
			}
		}

		private void WinForm_Closed(object sender, EventArgs e)
		{
			CreateWebEvent("OnUnload")?.Fire();
		}

		private void WinForm_Activated(object sender, EventArgs e)
		{
			CreateWebEvent("SetActive")?.Fire();
		}

		internal void FireFormAdded(object objWebObject)
		{
			Gizmox.WebGUI.Forms.Form objWebForm = objWebObject as Gizmox.WebGUI.Forms.Form;
			System.Windows.Forms.Form form = CreateWinForm(objWebForm);
			FormController formController = new FormController(base.Context, objWebForm, form);
			RegisterController(formController);
			formController.InitializeController();
			form.ShowInTaskbar = false;
			form.ShowDialog(WinForm);
		}

		private void ObservableList_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)base.Context).NotifyFormAdded(this, objArgs.Item);
		}

		internal void FireFormRemoved(object objWebObject)
		{
			System.Windows.Forms.Form form = GetWinObject(objWebObject) as System.Windows.Forms.Form;
			form.Close();
			UnregisterControllerByWinObject(form);
		}

		private void ObservableList_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)base.Context).NotifyFormRemoved(this, objArgs.Item);
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinForm.Activated -= WinForm_Activated;
			WinForm.Closed -= WinForm_Closed;
			if (ObservableList != null)
			{
				ObservableList.ObservableItemAdded -= ObservableList_ObservableItemAdded;
				ObservableList.ObservableItemRemoved -= ObservableList_ObservableItemRemoved;
			}
		}

		protected virtual System.Windows.Forms.Form CreateWinForm(object objWebForm)
		{
			return new ClientForm();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientForm();
		}

		protected override void LoadController()
		{
			base.LoadController();
			WebForm.Visible = true;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "MaximizeBox":
				SetWinFormMaximizeBox();
				break;
			case "MinimizeBox":
				SetWinFormMinimizeBox();
				break;
			case "FormBorderStyle":
				SetWinFormFormBorderStyle();
				break;
			case "StartPosition":
				SetWinStartPosition();
				break;
			case "IsMdiContainer":
				SetWinIsMdiContainer();
				break;
			}
		}

		internal override void SetWebControlControls()
		{
			bool isMdiContainer = WebForm.IsMdiContainer;
			System.Windows.Forms.Button button = null;
			System.Windows.Forms.Button button2 = null;
			foreach (Gizmox.WebGUI.Forms.Control control3 in WebForm.Controls)
			{
				if (control3.Form.AcceptButton != control3 && control3.Form.CancelButton != control3)
				{
					continue;
				}
				ObjectController controllerByWebObject = GetControllerByWebObject(control3);
				if (controllerByWebObject != null)
				{
					if (control3.Form.AcceptButton == control3)
					{
						button = controllerByWebObject.TargetObject as System.Windows.Forms.Button;
					}
					else if (control3.Form.CancelButton == control3)
					{
						button2 = controllerByWebObject.TargetObject as System.Windows.Forms.Button;
					}
				}
			}
			base.SetWebControlControls();
			if (isMdiContainer)
			{
				WebForm.IsMdiContainer = true;
			}
			if (button == null && button2 == null)
			{
				return;
			}
			foreach (System.Windows.Forms.Control control4 in WinForm.Controls)
			{
				if (GetControllerByWinObject(control4) is ControlController controlController && controlController.WebControl.Form != null)
				{
					if (control4 == button)
					{
						controlController.WebControl.Form.AcceptButton = controlController.WebControl as Gizmox.WebGUI.Forms.IButtonControl;
					}
					else if (control4 == button2)
					{
						controlController.WebControl.Form.CancelButton = controlController.WebControl as Gizmox.WebGUI.Forms.IButtonControl;
					}
				}
			}
		}

		protected override void SetWinControlDock()
		{
		}

		protected override void SetWinControlVisible()
		{
		}

		protected override void SetWinControlLocation()
		{
			if (!base.DesignMode)
			{
				base.SetWinControlLocation();
			}
		}

		protected override void SetWebControlLocation()
		{
			if (!base.DesignMode)
			{
				base.SetWebControlLocation();
			}
		}

		protected override void SetWinControlAnchor()
		{
		}

		protected override void SetWebControlSize()
		{
			WebForm.Size = new Size(Convert.ToInt32((float)WinForm.Size.Width / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WinForm.Size.Height / base.TargetVerticalScaleFactor));
		}

		protected override void SetWinControlSize()
		{
			WinForm.ClientSize = new Size(Convert.ToInt32((float)WebForm.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebForm.Size.Height * base.TargetVerticalScaleFactor));
		}

		protected override void SetWinControlMaximumSize()
		{
			WinForm.MaximumSize = WebForm.MaximumSize;
		}

		protected override void SetWinControlMinimumSize()
		{
			WinForm.MinimumSize = WebForm.MinimumSize;
		}

		protected virtual void SetWinFormMaximizeBox()
		{
			WinForm.MaximizeBox = WebForm.MaximizeBox;
		}

		protected virtual void SetWinFormMinimizeBox()
		{
			WinForm.MinimizeBox = WebForm.MinimizeBox;
		}

		protected virtual void SetWinIsMdiContainer()
		{
			WinForm.IsMdiContainer = WebForm.IsMdiContainer;
		}

		protected virtual void SetWinFormFormBorderStyle()
		{
			if (!base.DesignMode)
			{
				WinForm.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.FormBorderStyle), WebForm.FormBorderStyle);
			}
			else
			{
				WinForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			}
		}

		protected virtual void SetWinFormMainMenu()
		{
			Gizmox.WebGUI.Forms.MainMenu menu = WebForm.Menu;
			if (menu != null)
			{
				System.Windows.Forms.MainMenu mainMenu = new System.Windows.Forms.MainMenu();
				WinForm.Menu = mainMenu;
				mobjMainMenuController = new MainMenuController(base.Context, menu, mainMenu);
				mobjMainMenuController.Initialize();
			}
		}
	}
}
