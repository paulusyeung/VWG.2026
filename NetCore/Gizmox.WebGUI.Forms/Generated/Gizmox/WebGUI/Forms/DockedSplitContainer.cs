#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class DockedSplitContainer : SplitContainer, IDescriptable, IPreventExtraction
	{
		private bool mblnPreventExtraction;

		private DockedSplitContainerDescriptor mobjData;

		private DockingManager mobjManager;

		/// 
		/// Gets the docked split container descriptor internal.
		/// </summary>
		internal DockedSplitContainerDescriptor DockedSplitContainerDescriptorInternal => mobjData;

		/// 
		/// Gets the descriptor.
		/// </summary>
		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets the windows.
		/// </summary>
		public List<object> Windows
		{
			get
			{
				List list = HandleGetWindowsFromPanel(base.Panel1);
				list.AddRange(HandleGetWindowsFromPanel(base.Panel2));
				return list;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedSplitContainer" /> class.
		/// </summary>
		/// <param name="objManager">The obj manager.</param>
		public DockedSplitContainer(DockingManager objManager)
		{
			mblnPreventExtraction = false;
			mobjManager = objManager;
			base.Dock = DockStyle.Fill;
			mobjData = new DockedSplitContainerDescriptor();
			base.BorderStyle = BorderStyle.None;
			base.Panel1.ControlAdded += Panel1_ControlAdded;
			base.Panel2.ControlAdded += Panel2_ControlAdded;
			base.Panel1.ControlRemoved += Panel1_ControlRemoved;
			base.Panel2.ControlRemoved += Panel2_ControlRemoved;
			base.Panel2Collapsed = true;
		}

		/// 
		/// Raises the <see cref="E:SplitterMoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event data.</param>
		public override void OnSplitterMoved(SplitterEventArgs e)
		{
			base.OnSplitterMoved(e);
			((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
		}

		///  
		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			mobjManager.RegisterSplitContainer(this);
		}

		/// 
		/// Handles the panel.
		/// </summary>
		/// <param name="objPanel">The obj panel.</param>
		/// </returns>
		private List<object> HandleGetWindowsFromPanel(SplitterPanel objPanel)
		{
			List<object> list = new List<object><object>();
			if (objPanel.Controls.Count == 1)
			{
				if (objPanel.Controls[0] is Zone)
				{
					list.AddRange((objPanel.Controls[0] as Zone).Windows);
				}
				else if (objPanel.Controls[0] is DockedSplitContainer)
				{
					list.AddRange((objPanel.Controls[0] as DockedSplitContainer).Windows);
				}
			}
			return list;
		}

		/// 
		/// Hides the panel1.
		/// </summary>
		private void HidePanel1()
		{
			if (base.Panel2Collapsed || base.Panel2.Controls.Count == 0)
			{
				RemoveFromParent();
				return;
			}
			base.Panel1Collapsed = true;
			mobjData.UpdateSelf(this, mobjManager);
		}

		/// 
		/// Hides the panel2.
		/// </summary>
		private void HidePanel2()
		{
			if (base.Panel1Collapsed || base.Panel1.Controls.Count == 0)
			{
				RemoveFromParent();
				return;
			}
			base.Panel2Collapsed = true;
			mobjData.UpdateSelf(this, mobjManager);
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			if (objDescriptor is DockedSplitContainerDescriptor dockedSplitContainerDescriptor)
			{
				try
				{
					base.Orientation = dockedSplitContainerDescriptor.Orientation;
					base.SplitterDistance = dockedSplitContainerDescriptor.SplitterDistance;
					return;
				}
				finally
				{
					mobjData = dockedSplitContainerDescriptor;
					mobjManager.RegisterSplitContainer(this);
				}
			}
			throw new Exception();
		}

		/// 
		/// Resets the descriptors tree.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// <param name="objDockingPosition">The obj docking position.</param>
		void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
		{
			mobjData = mobjData.CloneWithoutReferences();
			mobjManager.RegisterSplitContainer(this);
			if (base.Panel1.Controls.Count == 1)
			{
				IDescriptable descriptable = base.Panel1.Controls[0] as IDescriptable;
				descriptable.ResetDescriptorsTree(objType, objDockingPosition);
				descriptable.Descriptor.UpdateFrom(this, 1);
			}
			if (base.Panel2.Controls.Count == 1)
			{
				IDescriptable descriptable2 = base.Panel2.Controls[0] as IDescriptable;
				descriptable2.ResetDescriptorsTree(objType, objDockingPosition);
				descriptable2.Descriptor.UpdateFrom(this, 2);
			}
		}

		/// 
		/// Disables the extraction.
		/// </summary>
		/// <param name="blnDisable">if set to true</c> [BLN disable].</param>
		void IPreventExtraction.DisableExtraction(bool blnDisable)
		{
			mblnPreventExtraction = blnDisable;
		}

		/// 
		/// Handles the ControlAdded event of the Panel1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void Panel1_ControlAdded(object sender, ControlEventArgs e)
		{
			if (e.Control is IDescriptable)
			{
				Panel1ControlAdded(e.Control);
				return;
			}
			throw new Exception("DockedSplitContainer.Panel1 can contain only zones or other DockingSplitContainers");
		}

		/// 
		/// Handles the ControlRemoved event of the Panel1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void Panel1_ControlRemoved(object sender, ControlEventArgs e)
		{
			if (e.Control is IDescriptable)
			{
				(e.Control as IDescriptable).Descriptor.UpdateFrom(this, 1);
			}
			if (base.Panel1.Controls.Count == 0 && !mblnPreventExtraction)
			{
				HidePanel1();
			}
		}

		/// 
		/// Panel1s the control added.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		private void Panel1ControlAdded(Control objControl)
		{
			ShowPanel1();
			((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
			(objControl as IDescriptable).Descriptor.UpdateFrom(this, 1);
		}

		/// 
		/// Handles the ControlAdded event of the Panel2 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void Panel2_ControlAdded(object sender, ControlEventArgs e)
		{
			if (e.Control is IDescriptable)
			{
				Panel2ControlAdded(e.Control);
				return;
			}
			throw new Exception("DockedSplitContainer.Panel2 can contain only zones or other DockingSplitContainers");
		}

		/// 
		/// Handles the ControlRemoved event of the Panel2 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void Panel2_ControlRemoved(object sender, ControlEventArgs e)
		{
			if (e.Control is IDescriptable)
			{
				(e.Control as IDescriptable).Descriptor.UpdateFrom(this, 2);
			}
			if (base.Panel2.Controls.Count == 0 && !mblnPreventExtraction)
			{
				HidePanel2();
			}
		}

		/// 
		/// Panel2s the control added.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		private void Panel2ControlAdded(Control objControl)
		{
			ShowPanel2();
			((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
			(objControl as IDescriptable).Descriptor.UpdateFrom(this, 2);
		}

		/// 
		/// Removes from parent.
		/// </summary>
		/// </returns>
		private int RemoveFromParent()
		{
			mobjManager.UnregisterSplitContainer(this);
			int childIndex = base.Parent.Controls.GetChildIndex(this);
			base.Parent.Controls.Remove(this);
			return childIndex;
		}

		/// 
		/// Shows the panel1.
		/// </summary>
		private void ShowPanel1()
		{
			base.Panel1Collapsed = false;
			if (base.Panel2.Controls.Count == 0)
			{
				base.Panel2Collapsed = true;
				return;
			}
			base.SplitterDistance = mobjData.SplitterDistance;
			base.Panel2Collapsed = false;
		}

		/// 
		/// Shows the panel2.
		/// </summary>
		private void ShowPanel2()
		{
			base.Panel2Collapsed = false;
			if (base.Panel1.Controls.Count == 0)
			{
				base.Panel1Collapsed = true;
				return;
			}
			base.SplitterDistance = mobjData.SplitterDistance;
			base.Panel1Collapsed = false;
		}

		/// 
		/// Removes the panel.
		/// </summary>
		/// <param name="intPanelSide">The int panel side.</param>
		internal void HardRemovePanel(int intPanelSide)
		{
			Control control = null;
			SplitterPanel splitterPanel = null;
			SplitterPanel splitterPanel2 = null;
			switch (intPanelSide)
			{
			case 1:
				splitterPanel = base.Panel1;
				splitterPanel2 = base.Panel2;
				break;
			case 2:
				splitterPanel = base.Panel2;
				splitterPanel2 = base.Panel1;
				break;
			default:
				throw new Exception();
			}
			if (splitterPanel2.Controls.Count > 0)
			{
				((IPreventExtraction)this).DisableExtraction(blnDisable: true);
				control = splitterPanel2.Controls[0];
				splitterPanel2.Controls.Remove(control);
			}
			splitterPanel.Controls.Clear();
			((IPreventExtraction)this).DisableExtraction(blnDisable: false);
			if (control != null)
			{
				Control parent = base.Parent;
				Control logicalParentControl = DockedManagerHelper.GetLogicalParentControl(this);
				if (logicalParentControl is IPreventExtraction)
				{
					(logicalParentControl as IPreventExtraction).DisableExtraction(blnDisable: true);
				}
				int intNewIndex = RemoveFromParent();
				if (logicalParentControl is IPreventExtraction)
				{
					(logicalParentControl as IPreventExtraction).DisableExtraction(blnDisable: false);
				}
				parent.Controls.Add(control);
				parent.Controls.SetChildIndex(control, intNewIndex);
			}
		}

		/// 
		/// Updates the focused control state
		/// </summary>
		internal override void UpdateFocusedControl()
		{
		}
	}
}
