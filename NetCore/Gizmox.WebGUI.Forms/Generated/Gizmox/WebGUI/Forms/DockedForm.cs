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
	public class DockedForm : Form, IDescriptable, IPreventExtraction
	{
		private bool mblnPreventExtraction;

		private DockedFormDescriptor mobjData;

		private DockingManager mobjManager;

		/// 
		/// Gets the windows.
		/// </summary>
		public List<object> Windows
		{
			get
			{
				Control control = null;
				if (base.Controls.Count > 0)
				{
					control = base.Controls[0];
				}
				if (control != null)
				{
					if (control is Zone)
					{
						return (control as Zone).Windows;
					}
					if (control is DockedSplitContainer)
					{
						return (control as DockedSplitContainer).Windows;
					}
				}
				return null;
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// 
		/// The default size.
		/// </value>
		protected override Size DefaultSize => new Size(300, 300);

		/// 
		/// Gets the docked form descriptor internal.
		/// </summary>
		internal DockedFormDescriptor DockedFormDescriptorInternal => mobjData;

		/// 
		/// Gets the descriptor.
		/// </summary>
		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets the manager.
		/// </summary>
		public DockingManager Manager => mobjManager;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedForm" /> class.
		/// </summary>
		/// <param name="objManager">The obj manager.</param>
		public DockedForm(DockingManager objManager)
		{
			mobjData = new DockedFormDescriptor();
			base.TopLevel = true;
			mobjManager = objManager;
			mblnPreventExtraction = false;
			base.AllowDragTargetsPropagation = false;
		}

		/// 
		/// Called when [window state changed].
		/// </summary>
		/// <param name="enmNewFormWindowState">State of the enm new form window.</param>
		protected override void OnWindowStateChanged(FormWindowState enmNewFormWindowState)
		{
			base.OnWindowStateChanged(enmNewFormWindowState);
			mobjData.UpdateSelf(this, Manager);
		}

		/// 
		/// Occurs when control is created
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			mobjData.OwningFormId = ID;
		}

		/// 
		/// Disables the extraction.
		/// </summary>
		/// <param name="blnDisable">if set to true</c> [BLN disable].</param>
		public void DisableExtraction(bool blnDisable)
		{
			mblnPreventExtraction = blnDisable;
		}

		/// 
		/// Raises the <see cref="E:Closing" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			mobjData.FormClosing();
		}

		/// 
		/// Raises the <see cref="E:ControlAdded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			if (e.Control is IDescriptable)
			{
				base.OnControlAdded(e);
				Show();
				(e.Control as IDescriptable).Descriptor.UpdateFrom(this, null);
				HandleAddingControl(e.Control, blnAddListener: true);
			}
		}

		/// 
		/// Raises the <see cref="E:ControlRemoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			HandleAddingControl(e.Control, blnAddListener: false);
			if (base.Controls.Count == 0 && !mblnPreventExtraction)
			{
				Close();
				Dispose();
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnLocationChanged(LayoutEventArgs e)
		{
			base.OnLocationChanged(e);
			mobjData.UpdateSelf(this, mobjManager);
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			mobjData.UpdateSelf(this, mobjManager);
		}

		/// 
		/// Controls the added listener.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="blnAddListener">if set to true</c> [BLN add listener].</param>
		private void HandleAddingControl(Control objControl, bool blnAddListener)
		{
			if (objControl is DockingWindow && blnAddListener)
			{
				Manager.SetWindowFormMapping(objControl as DockingWindow, mobjData);
				return;
			}
			if (objControl is Zone zone)
			{
				zone.OwningFormId = ID;
				if (blnAddListener)
				{
					zone.ZoneType = ZoneType.Float;
					List<object> list = new List<object><object>();
					Component[] dragTargets = DragTargets;
					foreach (Component component in dragTargets)
					{
						if (component.ID != zone.ID)
						{
							list.Add(component);
						}
					}
					DragTargets = list.ToArray();
				}
				else
				{
					zone.OwningFormId = -1L;
				}
			}
			if (blnAddListener)
			{
				objControl.ControlAdded += objControl_ControlAdded;
				objControl.ControlRemoved += objControl_ControlRemoved;
			}
			else
			{
				objControl.ControlAdded -= objControl_ControlAdded;
				objControl.ControlRemoved -= objControl_ControlRemoved;
			}
			foreach (Control control in objControl.Controls)
			{
				HandleAddingControl(control, blnAddListener);
			}
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			if (objDescriptor is DockedFormDescriptor dockedFormDescriptor)
			{
				base.Size = dockedFormDescriptor.Size;
				base.StartPosition = FormStartPosition.Manual;
				base.Location = dockedFormDescriptor.Location;
				base.WindowState = dockedFormDescriptor.WindowState;
				mobjData = dockedFormDescriptor;
				return;
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
			throw new NotImplementedException();
		}

		/// 
		/// Handles the ControlAdded event of the objControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void objControl_ControlAdded(object sender, ControlEventArgs e)
		{
			HandleAddingControl(e.Control, blnAddListener: true);
		}

		/// 
		/// Handles the ControlRemoved event of the objControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void objControl_ControlRemoved(object sender, ControlEventArgs e)
		{
			HandleAddingControl(e.Control, blnAddListener: false);
		}

		/// 
		/// Sets the drag targets.
		/// </summary>
		/// <param name="arrComponenets">The arr componenets.</param>
		internal void SetDragTargets(Component[] arrComponenets)
		{
			DragTargets = arrComponenets;
		}
	}
}
