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
	public class ControlController : ComponentController
	{
		private ControlCollectionController mobjControlsController = null;

		public Gizmox.WebGUI.Forms.Control WebControl => base.SourceObject as Gizmox.WebGUI.Forms.Control;

		public System.Windows.Forms.Control WinControl => base.TargetObject as System.Windows.Forms.Control;

		public ControlController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			if (!(WebControl is ISealedComponent))
			{
				mobjControlsController = new ControlCollectionController(base.Context, objWebControl, WebControl.Controls, objWinControl, WinControl.Controls);
			}
		}

		public ControlController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			if (!(WebControl is ISealedComponent))
			{
				mobjControlsController = new ControlCollectionController(base.Context, objWebObject, WebControl.Controls, WinControl, WinControl.Controls);
			}
		}

		protected override void InitializeController()
		{
			if (!base.DesignInitialization)
			{
				SetWinControlSize();
				SetWinControlLocation();
				SetWinControlMaximumSize();
				SetWinControlMinimumSize();
			}
			base.InitializeController();
			SetWinControlText();
			SetWinControlDock();
			SetWinControlAnchor();
			if (!base.DesignInitialization)
			{
				try
				{
					SuspendNotifications();
					SetWinControlSize();
					SetWinControlLocation();
					SetWinControlMaximumSize();
					SetWinControlMinimumSize();
					SetWinControlPadding();
				}
				finally
				{
					ResumeNotifications();
				}
			}
			SetWinControlBackColor();
			SetWinControlForeColor();
			SetWinControlFont();
			SetWinControlEnabled();
			SetWinControlTabIndex();
			SetWinControlTabStop();
			SetWinControlContextMenu();
			SetWinControlBackgroundImage();
			SetWinControlBackgroundImageLayout();
			SetWinControlEnabled();
			SetWinControlVisible();
			SetWinControlBorderStyle();
			SetWinControlAutoSize();
			SetWinControlMargin();
			SetWinControlRightToLeft();
		}

		public override void InitializeNew()
		{
			base.InitializeNew();
			SetWinControlSize();
		}

		protected override void InitializedContained()
		{
			WinControl.SuspendLayout();
			if (mobjControlsController != null)
			{
				mobjControlsController.Initialize();
			}
			try
			{
				SuspendNotifications();
				WinControl.ResumeLayout();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjControlsController != null)
			{
				mobjControlsController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjControlsController != null)
			{
				mobjControlsController.Terminate();
			}
		}

		protected virtual void SetWinControlVisible()
		{
			if (!base.DesignMode)
			{
				WinControl.Visible = WebControl.Visible;
			}
		}

		protected virtual void SetWinControlMargin()
		{
			WinControl.Margin = new System.Windows.Forms.Padding(Convert.ToInt32((float)WebControl.Margin.Left * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Margin.Top * base.TargetVerticalScaleFactor), Convert.ToInt32((float)WebControl.Margin.Right * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Margin.Bottom * base.TargetVerticalScaleFactor));
		}

		protected virtual void SetWinControlPadding()
		{
			WinControl.Padding = new System.Windows.Forms.Padding(Convert.ToInt32((float)WebControl.Padding.Left * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Padding.Top * base.TargetVerticalScaleFactor), Convert.ToInt32((float)WebControl.Padding.Right * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Padding.Bottom * base.TargetVerticalScaleFactor));
		}

		protected virtual void SetWinControlDataBindings()
		{
			if (base.DesignMode)
			{
				try
				{
					SuspendNotifications();
					RefreshDesigner();
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		internal virtual void SetWebControlControls()
		{
			if (mobjControlsController != null)
			{
				mobjControlsController.SetWebControlControls();
			}
		}

		protected virtual void SetWebControlTabIndex()
		{
			((Gizmox.WebGUI.Forms.Control)base.SourceObject).TabIndex = ((System.Windows.Forms.Control)base.TargetObject).TabIndex;
		}

		protected virtual void SetWinControlControls()
		{
			if (mobjControlsController != null)
			{
				mobjControlsController.SetWinControlControls();
			}
		}

		protected virtual void SetWinControlBorderStyle()
		{
		}

		protected virtual void SetWebControlBorderStyle()
		{
		}

		protected virtual void SetWinControlLayoutInfo()
		{
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel = WinControl.Parent as System.Windows.Forms.TableLayoutPanel;
			Gizmox.WebGUI.Forms.TableLayoutPanel tableLayoutPanel2 = WebControl.Parent as Gizmox.WebGUI.Forms.TableLayoutPanel;
			if (tableLayoutPanel != null && tableLayoutPanel2 != null)
			{
				tableLayoutPanel.SetRow(WinControl, tableLayoutPanel2.GetRow(WebControl));
				tableLayoutPanel.SetColumn(WinControl, tableLayoutPanel2.GetColumn(WebControl));
				tableLayoutPanel.SetRowSpan(WinControl, tableLayoutPanel2.GetRowSpan(WebControl));
				tableLayoutPanel.SetColumnSpan(WinControl, tableLayoutPanel2.GetColumnSpan(WebControl));
			}
		}

		protected virtual void SetWinControlEnabled()
		{
			WinControl.Enabled = WebControl.Enabled;
		}

		protected virtual void SetWinControlBackgroundImage()
		{
			if (WebControl.BackgroundImage != null)
			{
				Image winImageFromResourceHandle = GetWinImageFromResourceHandle(WebControl.BackgroundImage);
				if (winImageFromResourceHandle != null)
				{
					WinControl.BackgroundImage = winImageFromResourceHandle;
				}
			}
			else if (WinControl.BackgroundImage != null)
			{
				WinControl.BackgroundImage = null;
			}
		}

		protected virtual void SetWinControlBackgroundImageLayout()
		{
			WinControl.BackgroundImageLayout = (System.Windows.Forms.ImageLayout)GetConvertedEnum(typeof(System.Windows.Forms.ImageLayout), WebControl.BackgroundImageLayout);
		}

		protected virtual void SetWinControlContextMenu()
		{
			if (base.ContextMenuController != null)
			{
				// .NET 8 WinForms does not expose the legacy Control.ContextMenu property.
				// Keep this as a no-op until context menu bridging is implemented.
			}
		}

		protected virtual void SetWinControlTabStop()
		{
			WinControl.TabStop = WebControl.TabStop;
		}

		protected virtual void SetWinControlTabIndex()
		{
			if (WebControl.TabIndex != -1)
			{
				WinControl.TabIndex = WebControl.TabIndex;
			}
		}

		protected virtual void SetWinControlFont()
		{
			if (WebControl.Font == null)
			{
				WinControl.Font = null;
			}
			else
			{
				WinControl.Font = new Font(WebControl.Font.FontFamily, WebControl.Font.Size * base.TargetVerticalScaleFactor, WebControl.Font.Style, WebControl.Font.Unit);
			}
		}

		protected virtual void SetWinControlForeColor()
		{
			WinControl.ForeColor = WebControl.ForeColor;
		}

		protected virtual void SetWinControlBackColor()
		{
			try
			{
				WinControl.BackColor = WebControl.BackColor;
			}
			catch
			{
			}
		}

		protected virtual void SetWinControlLocation()
		{
			SetWinProperty("Location", new Point(Convert.ToInt32((float)WebControl.Location.X * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Location.Y * base.TargetVerticalScaleFactor)));
		}

		protected virtual void SetWinControlSize()
		{
			SetWinProperty("Size", new Size(Convert.ToInt32((float)WebControl.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Size.Height * base.TargetVerticalScaleFactor)));
		}

		protected virtual void SetWinControlMaximumSize()
		{
			WinControl.MaximumSize = WebControl.MaximumSize;
		}

		protected virtual void SetWinControlMinimumSize()
		{
			WinControl.MinimumSize = WebControl.MinimumSize;
		}

		protected virtual void SetWinControlAnchor()
		{
			if (WebControl.Dock == Gizmox.WebGUI.Forms.DockStyle.None)
			{
				WinControl.Anchor = (System.Windows.Forms.AnchorStyles)GetConvertedEnum(typeof(System.Windows.Forms.AnchorStyles), WebControl.Anchor);
			}
		}

		protected virtual void SetWinControlDock()
		{
			WinControl.Dock = (System.Windows.Forms.DockStyle)GetConvertedEnum(typeof(System.Windows.Forms.DockStyle), WebControl.Dock);
		}

		protected virtual void SetWinControlText()
		{
			WinControl.Text = WebControl.Text;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Controls":
				SetWebControlControls();
				if (base.DesignMode)
				{
					base.DesignServices.FireWebComponentChanged(WebControl, "Controls", WebControl.Controls, WebControl.Controls);
				}
				break;
			case "TabIndex":
				SetWebControlTabIndex();
				if (base.DesignMode)
				{
					base.DesignServices.FireWebComponentChanged(WebControl, "TabIndex", WebControl.TabIndex, WebControl.TabIndex);
				}
				break;
			case "Width":
			case "Height":
			case "Size":
				if (!base.DesignMode || base.DesignSuspended || base.IsNotificationSuspened)
				{
					break;
				}
				try
				{
					SuspendNotifications();
					base.DesignServices.FireWebComponentChanging(base.WebComponent, "Size");
					object obj = WebControl.Size;
					SetWebControlSize();
					object obj2 = WebControl.Size;
					if (!object.Equals(obj, obj2))
					{
						base.DesignServices.FireWebComponentChanged(base.WebComponent, "Size", obj, obj2);
					}
					break;
				}
				finally
				{
					ResumeNotifications();
				}
			case "Left":
			case "Top":
			case "Location":
				if (base.DesignMode && !base.DesignSuspended && !base.IsNotificationSuspened)
				{
					SetWebControlLocation();
				}
				break;
			case "Dock":
				if (base.DesignMode && !base.DesignSuspended && !base.IsNotificationSuspened)
				{
					try
					{
						SuspendNotifications();
						base.DesignServices.FireWebComponentChanging(base.WebComponent, "Dock");
						object objOldValue = WebControl.Dock;
						SetWebControlDock();
						object objNewValue = WebControl.Dock;
						base.DesignServices.FireWebComponentChanged(base.WebComponent, "Dock", objOldValue, objNewValue);
						break;
					}
					finally
					{
						ResumeNotifications();
					}
				}
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWinControlAutoSize();
				break;
			case "Location":
				SetWinControlLocation();
				break;
			case "Size":
				SetWinControlSize();
				break;
			case "MinimumSize":
				SetWinControlMinimumSize();
				break;
			case "MaximumSize":
				SetWinControlMaximumSize();
				break;
			case "Dock":
				SetWinControlDock();
				break;
			case "Text":
				SetWinControlText();
				break;
			case "Anchor":
				SetWinControlAnchor();
				break;
			case "Visible":
				SetWinControlVisible();
				break;
			case "Margin":
				SetWinControlMargin();
				break;
			case "Padding":
				SetWinControlPadding();
				break;
			case "Enabled":
				SetWinControlEnabled();
				break;
			case "ForeColor":
				SetWinControlForeColor();
				break;
			case "Font":
				SetWinControlFont();
				break;
			case "BackColor":
				SetWinControlBackColor();
				break;
			case "Controls":
				SetWinControlControls();
				break;
			case "BorderStyle":
				SetWinControlBorderStyle();
				break;
			case "DataBindings":
				SetWinControlDataBindings();
				break;
			case "BackgroundImage":
				SetWinControlBackgroundImage();
				break;
			case "BackgroundImageLayout":
				SetWinControlBackgroundImageLayout();
				break;
			case "Row":
			case "Column":
			case "RowSpan":
			case "ColumnSpan":
				SetWinControlLayoutInfo();
				break;
			case "TabIndex":
				SetWinControlTabIndex();
				break;
			case "Parent":
				SetWinControlParent();
				break;
			case "RightToLeft":
				SetWinControlRightToLeft();
				break;
			}
		}

		private void SetWinControlRightToLeft()
		{
			WinControl.RightToLeft = (System.Windows.Forms.RightToLeft)WebControl.RightToLeft;
		}

		private void SetWinControlParent()
		{
			System.Windows.Forms.Control parent = WinControl.Parent;
			if (GetControllerByWebObject(WebControl.Parent) is ControlController controlController)
			{
				SetWinProperty("Parent", controlController.WinControl);
				base.DesignServices.FireWebComponentChanged(controlController.WebControl, "Controls", controlController.WebControl.Controls, controlController.WebControl.Controls);
				if (GetControllerByWinObject(parent) is ControlController { WebControl: not null } controlController2)
				{
					base.DesignServices.FireWebComponentChanged(controlController2.WebControl, "Controls", controlController2.WebControl.Controls, controlController2.WebControl.Controls);
				}
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinControl.Click += WinControl_Click;
			if (base.WebComponent is IObservableLayoutItem observableLayoutItem)
			{
				observableLayoutItem.ObservableResumeLayout += WebComponent_ObservableResumeLayout;
				observableLayoutItem.ObservableSuspendLayout += WebComponent_ObservableSuspendLayout;
			}
		}

		private void WinControl_Click(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("Click");
			obj.Fire();
		}

		private void WebComponent_ObservableResumeLayout(object objSender, ObservableResumeLayoutArgs objArgs)
		{
			WinControl.ResumeLayout(objArgs.PerformLayout);
		}

		private void WebComponent_ObservableSuspendLayout(object sender, EventArgs e)
		{
			WinControl.SuspendLayout();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinControl.Click -= WinControl_Click;
			if (base.WebComponent is IObservableLayoutItem observableLayoutItem)
			{
				observableLayoutItem.ObservableResumeLayout -= WebComponent_ObservableResumeLayout;
				observableLayoutItem.ObservableSuspendLayout -= WebComponent_ObservableSuspendLayout;
			}
		}

		private void SetWebControlAutoSize()
		{
			if (WebControl.AutoSize != WinControl.AutoSize)
			{
				SetWebProperty("AutoSize", WinControl.AutoSize);
			}
		}

		protected virtual void SetWinControlAutoSize()
		{
			if (WebControl.AutoSize != WinControl.AutoSize)
			{
				SetWinProperty("AutoSize", WebControl.AutoSize);
			}
		}

		internal void SetWebControlDesignTimeValues()
		{
			SetWebControlLocation();
			SetWebControlSize();
			SetWebControlText();
			SetWebControlAutoSize();
		}

		internal void SetWinControlDesignTimeValues()
		{
			SetWinControlTabIndex();
		}

		protected virtual void SetWebControlText()
		{
			WebControl.Text = WinControl.Text;
		}

		protected virtual void SetWebControlSize()
		{
			if (WebControl.Size != WinControl.Size)
			{
				try
				{
					SuspendNotifications();
					WebControl.Size = new Size(Convert.ToInt32((float)WinControl.Size.Width / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WinControl.Size.Height / base.TargetVerticalScaleFactor));
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		protected virtual void SetWebControlLocation()
		{
			if (WinControl.Location != WebControl.Location)
			{
				try
				{
					SuspendNotifications();
					base.DesignServices.FireWebComponentChanging(base.WebComponent, "Location");
					object objOldValue = WebControl.Location;
					WebControl.Location = new Point(Convert.ToInt32((float)WinControl.Location.X / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WinControl.Location.Y / base.TargetVerticalScaleFactor));
					object objNewValue = WebControl.Location;
					base.DesignServices.FireWebComponentChanged(base.WebComponent, "Location", objOldValue, objNewValue);
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		private void SetWebControlAnchor()
		{
			WebControl.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.AnchorStyles), WinControl.Anchor);
		}

		private void SetWebControlDock()
		{
			WebControl.Dock = (Gizmox.WebGUI.Forms.DockStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.DockStyle), WinControl.Dock);
			if (WinControl.Dock == System.Windows.Forms.DockStyle.None)
			{
				SetWebControlAnchor();
			}
		}

		private void FireTableLayoutPanelControlPositionsChanged()
		{
			if (base.DesignInitialization || base.IsNotificationSuspened || !(WinControl.Parent is System.Windows.Forms.TableLayoutPanel) || WinControl.Parent == null)
			{
				return;
			}
			ObjectController controllerByWinObject = GetControllerByWinObject(WinControl.Parent);
			if (controllerByWinObject != null)
			{
				try
				{
					SuspendNotifications();
					controllerByWinObject.FireWinPropertyChanged(new ObservableItemPropertyChangedArgs("ControlPositions", base.TargetObject));
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		protected System.Windows.Forms.Control GetWinAncestorByWebType(Type objAncestorWebType)
		{
			System.Windows.Forms.Control control = WinControl;
			while (control != null && (!(GetControllerByWinObject(control) is ControlController { WebControl: not null } controlController) || !(controlController.WebControl.GetType() == objAncestorWebType)))
			{
				control = control.Parent;
			}
			return control;
		}
	}
}
