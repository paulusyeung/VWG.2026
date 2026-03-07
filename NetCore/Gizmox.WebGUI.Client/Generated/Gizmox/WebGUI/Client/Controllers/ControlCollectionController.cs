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
	public class ControlCollectionController : ComponentCollectionController
	{
		private IObservableLayoutItem WebLayoutItem => base.SourceObject as IObservableLayoutItem;

		public Gizmox.WebGUI.Forms.Control.ControlCollection WebControls => base.WebObjects as Gizmox.WebGUI.Forms.Control.ControlCollection;

		public Gizmox.WebGUI.Forms.Control WebControl => base.SourceObject as Gizmox.WebGUI.Forms.Control;

		public System.Windows.Forms.Control.ControlCollection WinControls => base.WinObjects as System.Windows.Forms.Control.ControlCollection;

		public System.Windows.Forms.Control WinControl => base.TargetObject as System.Windows.Forms.Control;

		public ControlCollectionController(IContext objContext, object objWebControl, IList objWebControls, object objWinControl, IList objWinControls)
			: base(objContext, objWebControl, objWebControls, objWinControl, objWinControls)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(base.Context, objWebObject);
		}

		protected override void InitializeWinObjects()
		{
			WinControl.SuspendLayout();
			if (WebControl is Gizmox.WebGUI.Forms.Form)
			{
				WinControl.ClientSize = new Size(Convert.ToInt32((float)WebLayoutItem.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebLayoutItem.Size.Height * base.TargetVerticalScaleFactor));
			}
			base.InitializeWinObjects();
			WinControl.ResumeLayout();
			if (WebControl is Gizmox.WebGUI.Forms.Form)
			{
				WinControl.Size = new Size(Convert.ToInt32((float)WebControl.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Size.Height * base.TargetVerticalScaleFactor));
			}
		}

		protected override int OnWebObjectAdded(object objWebObject)
		{
			WinControl.SuspendLayout();
			int result = base.OnWebObjectAdded(objWebObject);
			WinControl.ResumeLayout();
			return result;
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinControl.ControlRemoved += WinControl_ControlRemoved;
		}

		private void WinControl_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			if (!base.IsNotificationSuspened && GetControllerByWinObject(e.Control) is ControlController)
			{
				if (GetControllerByWebObject(WebControl) is ControlController controlController2)
				{
					controlController2.SetWebControlControls();
				}
				else
				{
					SetWebControlControls();
				}
			}
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinControl.ControlRemoved -= WinControl_ControlRemoved;
		}

		internal void SetWinControlControls()
		{
			if (WebControls == null || WinControls == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				WinControl.SuspendLayout();
				ArrayList arrayList = new ArrayList(WinControls);
				WinControls.Clear();
				foreach (Gizmox.WebGUI.Forms.Control webControl in WebControls)
				{
					ControlController controlController = ((IContextServices)base.Context).GetControllerByWebObject(webControl) as ControlController;
					if (controlController == null)
					{
						controlController = ObjectController.CreateControllerByWebObject(base.Context, webControl) as ControlController;
						if (base.DesignMode)
						{
							controlController.Initialize();
							controlController.Load();
							RegisterController(controlController);
							base.DesignServices.RegisterWinComponent(controlController.WinControl);
						}
					}
					else
					{
						arrayList.Remove(controlController.TargetObject);
					}
					if (controlController != null)
					{
						WinControls.Add(controlController.WinControl);
					}
				}
				foreach (System.Windows.Forms.Control item in arrayList)
				{
					if (((IContextServices)base.Context).GetControllerByWinObject(item) is ControlController controlController2)
					{
						controlController2.Terminate();
						((IContextServices)base.Context).UnregisterController(controlController2);
					}
				}
				WinControl.ResumeLayout();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		internal void SetWebControlControls()
		{
			if (WebControls == null || WebControls.IsReadOnly || WinControls == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				ArrayList arrayList = new ArrayList(WebControls);
				WebControls.Clear();
				foreach (System.Windows.Forms.Control winControl in WinControls)
				{
					if (!(((IContextServices)base.Context).GetControllerByWinObject(winControl) is ControlController controlController))
					{
						continue;
					}
					if (base.DesignMode && !controlController.WebControl.HasTabIndex)
					{
						int num = 0;
						foreach (Gizmox.WebGUI.Forms.Control item in arrayList)
						{
							if (num <= item.TabIndex)
							{
								num = item.TabIndex + 1;
							}
						}
						controlController.WebControl.TabIndex = num;
					}
					WebControls.Add(controlController.WebControl);
					if (!arrayList.Contains(controlController.WebControl))
					{
						if (base.DesignMode)
						{
							controlController.SetWebControlDesignTimeValues();
							controlController.SetWinControlDesignTimeValues();
							base.DesignServices.RegisterWebComponent(controlController.WebControl);
						}
						if (GetControllerByWinObject(winControl.Parent) is ControlController controlController2)
						{
							controlController2.WebControl.Controls.Add(controlController.WebControl);
							if (base.DesignMode)
							{
								base.DesignServices.FireWebComponentChanged(controlController2.WebControl, "Controls", controlController2.WebControl.Controls, controlController2.WebControl.Controls);
							}
						}
					}
					else
					{
						arrayList.Remove(controlController.WebControl);
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}
	}
}
