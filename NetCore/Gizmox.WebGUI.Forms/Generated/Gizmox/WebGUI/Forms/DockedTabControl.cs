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
	/// A TabControl control
	/// </summary>
	[Serializable]
	[Skin(typeof(DockedTabControlSkin))]
	[ToolboxItem(false)]
	public class DockedTabControl : TabControl, IDescriptable, IPreventExtraction
	{
		private bool mblnPreventExtraction;

		private DockedTabControlDescriptor mobjData;

		private DockingManager mobjManager;

		private Zone mobjOwningZone;

		private Dictionary<DockingWindowName, DockedTabPage> mobjTabPagesIndexByTheirContainedDockedWindowName;

		/// 
		/// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
		/// </summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
		public override ContextMenuStrip ContextMenuStrip
		{
			get
			{
				if (OwningZone != null && OwningZone.Manager != null && base.Controls.Count > 0)
				{
					return OwningZone.Manager.GetDockedContextMenuStrip(OwningZone);
				}
				return base.ContextMenuStrip;
			}
			set
			{
			}
		}

		/// 
		/// Gets the docked tab control descriptor internal.
		/// </summary>
		internal DockedTabControlDescriptor DockedTabControlDescriptorInternal => mobjData;

		/// 
		/// Gets the descriptor.
		/// </summary>
		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets the owning zone.
		/// </summary>
		internal Zone OwningZone
		{
			get
			{
				return mobjOwningZone;
			}
			set
			{
				mobjOwningZone = value;
			}
		}

		/// 
		/// Gets the windows.
		/// </summary>
		public List<DockingWindow> Windows
		{
			get
			{
				List<DockingWindow> list = new List<DockingWindow>();
				foreach (DockedTabPage tabPage in base.TabPages)
				{
					list.Add(tabPage.Window);
				}
				return list;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedTabControl" /> class.
		/// </summary>
		/// <param name="mobjManager">The mobj manager.</param>
		public DockedTabControl(DockingManager mobjManager)
		{
			base.Visible = false;
			CustomStyle = "DockedTabContolSkin";
			base.SelectOnRightClick = true;
			mobjTabPagesIndexByTheirContainedDockedWindowName = new Dictionary<DockingWindowName, DockedTabPage>(DockingWindowName.DockedWindowNameEqulityComparer);
			mobjData = new DockedTabControlDescriptor();
			this.mobjManager = mobjManager;
		}

		/// 
		/// Determines whether [is window selected] [the specified docked window].
		/// </summary>
		/// <param name="dockedWindow">The docked window.</param>
		/// 
		///   true</c> if [is window selected] [the specified docked window]; otherwise, false</c>.
		/// </returns>
		internal bool IsWindowSelected(DockingWindow dockedWindow)
		{
			if (mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(dockedWindow.WindowName, out var value))
			{
				return value.TabIndex == base.SelectedIndex;
			}
			return false;
		}

		/// 
		/// Sets the state of the window selected.
		/// </summary>
		/// <param name="objDockedWindow">The docked window.</param>
		/// <param name="blnSelect">if set to true</c> [value].</param>
		internal void SetWindowSelectedState(DockingWindow objDockedWindow, bool blnSelect)
		{
			if (!mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(objDockedWindow.WindowName, out var value))
			{
				return;
			}
			if (blnSelect)
			{
				base.SelectedIndex = value.TabIndex;
			}
			else if (base.Controls.Count > 1)
			{
				if (value.TabIndex == 0)
				{
					base.SelectedIndex = 1;
				}
				else
				{
					base.SelectedIndex = 0;
				}
			}
		}

		/// 
		/// Raises the <see cref="E:ControlAdded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			if (e.Control is DockedTabPage)
			{
				base.OnControlAdded(e);
				DockedTabPage dockedTabPage = e.Control as DockedTabPage;
				((IDescriptable)dockedTabPage.Window).Descriptor.UpdateFrom(this, mblnPreventExtraction);
				dockedTabPage.Window.OwningTabControl = this;
				base.Visible = true;
				((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
			}
		}

		/// 
		/// Raises the <see cref="E:ControlRemoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			if (e.Control is DockedTabPage)
			{
				base.OnControlRemoved(e);
				DockedTabPage dockedTabPage = e.Control as DockedTabPage;
				HandleWindowRemoved(dockedTabPage.Window);
				dockedTabPage.Window.OwningTabControl = null;
				((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
				if (base.Controls.Count == 0)
				{
					base.Visible = false;
					if (!mblnPreventExtraction)
					{
						base.Parent.Controls.Remove(this);
					}
				}
				return;
			}
			throw new Exception();
		}

		/// 
		/// Handles the window removed.
		/// </summary>
		/// <param name="objDockedWindow">The docked window.</param>
		private void HandleWindowRemoved(DockingWindow objDockedWindow)
		{
			if (mobjManager != null)
			{
				mobjManager.DockedWindows.RemoveWindow(objDockedWindow);
				return;
			}
			throw new Exception();
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.TabControl.SelectedIndexChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			if (OwningZone != null)
			{
				OwningZone.NotifyTabIndexChanged();
				((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
			}
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			mobjData = objDescriptor as DockedTabControlDescriptor;
		}

		/// 
		/// Resets the descriptors tree.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// <param name="objDockingPosition">The obj docking position.</param>
		void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
		{
			((IPreventExtraction)this).DisableExtraction(blnDisable: true);
			List<DockingWindow> windows = Windows;
			foreach (DockingWindow item in windows)
			{
				RemoveWindow(item);
			}
			mobjData = mobjData.CloneWithoutReferences<DockedTabControlDescriptor>();
			((IPreventExtraction)this).DisableExtraction(blnDisable: false);
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
		/// Adds the window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		internal void AddWindow(DockingWindow objWindow)
		{
			if (!mobjTabPagesIndexByTheirContainedDockedWindowName.ContainsKey(objWindow.WindowName))
			{
				DockState dockStateAccordingToZoneType = DockingManager.GetDockStateAccordingToZoneType(OwningZone.ZoneType);
				objWindow.CurrentDockState = dockStateAccordingToZoneType;
				DockedTabPage dockedTabPage = new DockedTabPage(objWindow);
				base.Controls.Add(dockedTabPage);
				if (base.Controls.Count == 1)
				{
					OwningZone.NotifyTabIndexChanged();
				}
				if (!mobjManager.IsInLoadMode || base.Controls.Count == mobjData.SelectedIndex + 1)
				{
					base.SelectedTab = dockedTabPage;
				}
				mobjTabPagesIndexByTheirContainedDockedWindowName.Add(objWindow.WindowName, dockedTabPage);
				mobjManager.AddWindowToCorrectZoneTypeListInManagersDescriptor(objWindow);
			}
		}

		/// 
		/// Removes the window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		internal void RemoveWindow(DockingWindow objWindow)
		{
			RemoveWindow(objWindow.WindowName);
		}

		/// 
		/// Removes the window.
		/// </summary>
		/// <param name="strWindowName">Name of the STR window.</param>
		internal void RemoveWindow(DockingWindowName strWindowName)
		{
			if (mobjTabPagesIndexByTheirContainedDockedWindowName.TryGetValue(strWindowName, out var value))
			{
				mobjManager.RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(value.Window, OwningZone.ZoneType);
				mobjTabPagesIndexByTheirContainedDockedWindowName.Remove(strWindowName);
				value.Controls.Clear();
			}
			else if (!mblnPreventExtraction)
			{
				throw new Exception("This zone does not contain the given window");
			}
		}

		/// 
		/// Windows the image changed.
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		internal void WindowImageChanged(DockingWindow objDockedWindow)
		{
			mobjTabPagesIndexByTheirContainedDockedWindowName[objDockedWindow.WindowName].Image = objDockedWindow.Image;
		}
	}
}
