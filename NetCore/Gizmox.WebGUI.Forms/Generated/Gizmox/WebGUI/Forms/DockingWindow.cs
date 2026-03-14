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
	public class DockingWindow : UserControl, IDescriptable
	{
		internal static readonly SerializableEvent EVENT_DOCKEDWINDOWNAMECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingWindow));

		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(DockingWindow), new SerializablePropertyMetadata(null));

		private DockedWindowDescriptor mobjData;

		private ResourceHandle mobjImage;

		private DockedTabControl mobjOwningTabControl;

		private DockingManager mobjManager;

		private Size mobjHiddenZonePopupSize;

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		public override DockStyle Dock
		{
			get
			{
				return DockStyle.Fill;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the last state of the dock.
		/// </summary>
		/// 
		/// The last state of the dock.
		/// </value>
		internal DockState LastDockState
		{
			get
			{
				return mobjData.LastDockState;
			}
			set
			{
				mobjData.LastDockState = value;
			}
		}

		/// 
		/// Gets or sets the header text.
		/// </summary>
		/// 
		/// The header text.
		/// </value>
		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public string HeaderText
		{
			get
			{
				return string.IsNullOrEmpty(mobjData.HeaderText) ? Text : mobjData.HeaderText;
			}
			set
			{
				if (mobjData.HeaderText != value)
				{
					mobjData.HeaderText = value;
					if (IsSelectedTab)
					{
						OwningZone.NotifyHeaderTextChanged(this);
					}
				}
			}
		}

		/// 
		/// Gets or sets the header tool tip.
		/// </summary>
		/// 
		/// The header tool tip.
		/// </value>
		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public string HeaderToolTip
		{
			get
			{
				return mobjData.HeaderToolTip;
			}
			set
			{
				if (mobjData.HeaderToolTip != value)
				{
					mobjData.HeaderToolTip = value;
					if (IsSelectedTab)
					{
						OwningZone.NotifyWindowHeaderAttributeChanged(this);
					}
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the tab header tool tip.
		/// </summary>
		/// 
		/// The tab header tool tip.
		/// </value>
		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public string TabHeaderToolTip
		{
			get
			{
				return mobjData.TabHeaderToolTip;
			}
			set
			{
				if (mobjData.TabHeaderToolTip != value)
				{
					mobjData.TabHeaderToolTip = value;
					if (base.Parent != null && base.Parent is DockedTabPage)
					{
						(base.Parent as DockedTabPage).HeaderToolTip = value;
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is selected tab.
		/// </summary>
		/// 
		/// 	true</c> if this instance is selected tab; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsSelectedTab
		{
			get
			{
				if (mobjOwningTabControl != null)
				{
					return mobjOwningTabControl.IsWindowSelected(this);
				}
				return false;
			}
			set
			{
				if (mobjOwningTabControl != null)
				{
					mobjOwningTabControl.SetWindowSelectedState(this, value);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is closed.
		/// </summary>
		/// 
		///   true</c> if closed; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Closed
		{
			get
			{
				return CurrentDockState == DockState.Close;
			}
			set
			{
				if (value)
				{
					Close();
				}
				else
				{
					Show();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is pinned.
		/// </summary>
		/// 
		///   true</c> if pinned; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Pinned
		{
			get
			{
				return CurrentDockState == DockState.AutoHide;
			}
			set
			{
				if (value)
				{
					Pin();
				}
				else
				{
					Unpin();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is docked.
		/// </summary>
		/// 
		///   true</c> if docked; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Docked
		{
			get
			{
				return CurrentDockState == DockState.Dock;
			}
			set
			{
				if (value)
				{
					SetDock();
				}
				else
				{
					SetFloat();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> is floated.
		/// </summary>
		/// 
		///   true</c> if floated; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Floated
		{
			get
			{
				return CurrentDockState == DockState.Float;
			}
			set
			{
				if (value)
				{
					SetFloat();
				}
				else
				{
					SetDock();
				}
			}
		}

		/// 
		/// Gets or sets the state of the current dock.
		/// </summary>
		/// 
		/// The state of the current dock.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DockState CurrentDockState
		{
			get
			{
				return mobjData.CurrentDockState;
			}
			internal set
			{
				mobjData.CurrentDockState = value;
			}
		}

		/// 
		/// Gets the manager.
		/// </summary>
		public DockingManager Manager
		{
			get
			{
				return mobjManager;
			}
			internal set
			{
				mobjManager = value;
			}
		}

		/// 
		/// Gets the docked window descriptor.
		/// </summary>
		internal DockedWindowDescriptor DockedWindowDescriptor => mobjData;

		/// 
		/// Gets the docked window descriptor internal.
		/// </summary>
		internal DockedWindowDescriptor DockedWindowDescriptorInternal => mobjData;

		/// 
		/// Gets the descriptor.
		/// </summary>
		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets or sets the image that is displayed on a button control.
		/// </summary>
		public ResourceHandle Image
		{
			get
			{
				return mobjImage;
			}
			set
			{
				if (value != mobjImage)
				{
					mobjImage = value;
					if (OwningTabControl != null)
					{
						OwningTabControl.WindowImageChanged(this);
					}
				}
			}
		}

		/// 
		/// Gets or sets the name associated with this control.
		/// </summary>
		[Browsable(false)]
		public new string Name
		{
			get
			{
				return WindowName.WindowName;
			}
			set
			{
				if (Name != value)
				{
					base.Name = value;
					WindowName.WindowName = value;
					mobjData.UpdateSelf(this, null);
				}
			}
		}

		/// 
		/// Gets or sets the owning tab control.
		/// </summary>
		/// 
		/// The owning tab control.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		internal DockedTabControl OwningTabControl
		{
			get
			{
				return mobjOwningTabControl;
			}
			set
			{
				mobjOwningTabControl = value;
			}
		}

		/// 
		/// Gets the owning zone.
		/// </summary>
		internal Zone OwningZone
		{
			get
			{
				if (OwningTabControl != null && OwningTabControl.OwningZone != null)
				{
					return OwningTabControl.OwningZone;
				}
				return null;
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// 
		/// Gets or sets the name of the window.
		/// </summary>
		/// 
		/// The name of the window.
		/// </value>
		internal DockingWindowName WindowName
		{
			get
			{
				return mobjData.WindowName;
			}
			set
			{
				Name = value.WindowName;
			}
		}

		/// 
		/// Gets or sets the size of the hidden zone.
		/// </summary>
		/// 
		/// The size of the hidden zone.
		/// </value>
		public Size HiddenZonePopupSize
		{
			get
			{
				return mobjHiddenZonePopupSize;
			}
			set
			{
				mobjHiddenZonePopupSize = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockingWindow" /> class.
		/// </summary>
		public DockingWindow()
		{
			mobjData = new DockedWindowDescriptor(this);
			mobjData.CurrentDockState = DockState.Close;
			InitializeDockedWindow();
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderHeaderToolTip(objWriter, blnForceRender: false);
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderHeaderToolTip(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the header tool tip.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderHeaderToolTip(IAttributeWriter objWriter, bool blnForceRender)
		{
			string headerToolTip = HeaderToolTip;
			if (!string.IsNullOrEmpty(headerToolTip) || blnForceRender)
			{
				objWriter.WriteAttributeString("ZTT", headerToolTip);
			}
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return Text;
		}

		/// 
		/// Conceals the control from the user.
		/// </summary>
		public new void Hide()
		{
			if (Manager != null && CurrentDockState != DockState.Hidden)
			{
				Manager.SwitchWindowsDockState(DockState.Hidden, this);
			}
		}

		/// 
		/// Closes this instance.
		/// </summary>
		public void Close()
		{
			if (Manager != null && CurrentDockState != DockState.Close)
			{
				Manager.SwitchWindowsDockState(DockState.Close, this);
			}
		}

		/// 
		/// Displays the control to the user.
		/// </summary>
		public new void Show()
		{
			switch (CurrentDockState)
			{
			case DockState.AutoHide:
			{
				string empty = string.Empty;
				empty = OwningZone.DockingPosition switch
				{
					DockStyle.Top => "T", 
					DockStyle.Right => "R", 
					DockStyle.Bottom => "B", 
					DockStyle.Left => "L", 
					_ => throw new NotSupportedException(), 
				};
				OwningZone.ContainingHiddenPanel.InvokeMethodInternal("DockedHiddenZonesPanel_ShowZonePopUp", OwningZone.ContainingHiddenPanel.ID, OwningZone.ID, Manager.ID, empty, OwningZone.ContainingHiddenPanel.DockPadding.Right, OwningZone.ContainingHiddenPanel.DockPadding.Left);
				break;
			}
			case DockState.Hidden:
			case DockState.Close:
				Manager.ShowHiddenWindow(this);
				break;
			case DockState.Float:
			case DockState.Dock:
			case DockState.Tabbed:
				IsSelectedTab = true;
				break;
			default:
				throw new NotSupportedException();
			}
		}

		/// 
		/// Pins this instance.
		/// </summary>
		public void Pin()
		{
			if (Manager != null && CurrentDockState == DockState.AutoHide)
			{
				Manager.SwitchWindowsDockState(DockState.Dock, this);
			}
		}

		/// 
		/// Unpins this instance.
		/// </summary>
		public void Unpin()
		{
			if (Manager != null && CurrentDockState == DockState.Dock)
			{
				Manager.SwitchWindowsDockState(DockState.AutoHide, this);
			}
		}

		/// 
		/// Sets the float.
		/// </summary>
		public void SetFloat()
		{
			if (Manager != null && CurrentDockState != DockState.Float)
			{
				Manager.SwitchWindowsDockState(DockState.Float, this);
			}
		}

		/// 
		/// Sets the dock.
		/// </summary>
		public void SetDock()
		{
			if (Manager != null && CurrentDockState != DockState.Dock)
			{
				Manager.SwitchWindowsDockState(DockState.Dock, this);
			}
		}

		/// 
		/// Raises the <see cref="E:TextChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (base.Parent is DockedTabPage)
			{
				base.Parent.Text = Text;
			}
			if (IsSelectedTab)
			{
				OwningZone.NotifyWindowHeaderAttributeChanged(this);
			}
			mobjData.UpdateSelf(this, null);
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			DockedWindowDescriptor dockedWindowDescriptor = objDescriptor as DockedWindowDescriptor;
			WindowName = dockedWindowDescriptor.WindowName;
			Text = dockedWindowDescriptor.Text;
			mobjData = objDescriptor as DockedWindowDescriptor;
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
		/// Initializes the component.
		/// </summary>
		private void InitializeDockedWindow()
		{
			base.Dock = DockStyle.Fill;
		}
	}
}
