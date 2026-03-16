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
	[MetadataTag("DZ")]
	[Skin(typeof(ZoneSkin))]
	[ToolboxItem(false)]
	public class Zone : ContainerControl, IDescriptable, ISupportInitialize
	{
		internal const int ZONE_WITH_NO_OWNING_FORM_ID = -1;

		private bool mblnRegistered;

		private bool mblnSusspentUIEvents;

		private ZoneType menmZoneType;

		private long mlngOwningFormId;

		private ZoneCloseButton mobjCloseButton;

		private DockedHiddenZonesPanel mobjContainingHiddenPanel;

		private ZoneDescriptor mobjData;

		private ZoneDropDownButton mobjDropDownButton;

		private ZoneHeaderPanel mobjHeaderPanel;

		private DockingManager mobjManager;

		private ZonePinCheckBox mobjPinCheckBox;

		private DockedTabControl mobjTabControl;

		private ZoneHeaderLabel mobjZoneHeaderLabel;

		private Form mobjZonePopupForm;

		private bool mblnHideTabs;

		/// 
		/// Gets or sets the containing hidden panel.
		/// </summary>
		/// 
		/// The containing hidden panel.
		/// </value>
		internal DockedHiddenZonesPanel ContainingHiddenPanel
		{
			get
			{
				return mobjContainingHiddenPanel;
			}
			set
			{
				mobjContainingHiddenPanel = value;
			}
		}

		/// 
		/// Gets the current window.
		/// </summary>
		public DockingWindow CurrentWindow => (mobjTabControl.SelectedTab as DockedTabPage).Window;

		/// 
		/// Gets or sets the docking position.
		/// </summary>
		/// 
		/// The docking position.
		/// </value>
		public DockStyle DockingPosition
		{
			get
			{
				return mobjData.DockingPosition;
			}
			set
			{
				mobjData.DockingPosition = value;
			}
		}

		/// 
		/// Gets the descriptor.
		/// </summary>
		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets the manager.
		/// </summary>
		public DockingManager Manager => mobjManager;

		/// 
		/// Gets or sets the owning form id.
		/// </summary>
		/// 
		/// The owning form id.
		/// </value>
		public long OwningFormId
		{
			get
			{
				return mlngOwningFormId;
			}
			set
			{
				mlngOwningFormId = value;
			}
		}

		/// 
		/// Gets the panel side.
		/// </summary>
		internal int PanelSide => mobjData.PanelSide;

		/// 
		/// Gets the tab control.
		/// </summary>
		internal DockedTabControl TabControl => mobjTabControl;

		/// 
		/// Gets the windows.
		/// </summary>
		public List<DockingWindow> Windows => TabControl.Windows;

		/// 
		/// Gets the zone descriptor internal.
		/// </summary>
		internal ZoneDescriptor ZoneDescriptorInternal => mobjData;

		/// 
		/// Gets or sets the type of the zone.
		/// </summary>
		/// 
		/// The type of the zone.
		/// </value>
		internal ZoneType ZoneType
		{
			get
			{
				return menmZoneType;
			}
			set
			{
				if (menmZoneType != value)
				{
					menmZoneType = value;
					UpdateUI();
				}
			}
		}

		/// 
		/// Gets or sets the zone popup form.
		/// </summary>
		/// 
		/// The zone popup form.
		/// </value>
		public Form ZonePopupForm
		{
			get
			{
				return mobjZonePopupForm;
			}
			set
			{
				mobjZonePopupForm = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [force hide tabs].
		/// </summary>
		/// 
		///   true</c> if [force hide tabs]; otherwise, false</c>.
		/// </value>
		public bool HideTabs
		{
			get
			{
				return mblnHideTabs;
			}
			set
			{
				mblnHideTabs = value;
				SetTabControlTabsAppearance();
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Zone" /> class.
		/// </summary>
		/// <param name="objManager">The obj manager.</param>
		/// <param name="enmZoneType">Type of the enm zone.</param>
		public Zone(DockingManager objManager, ZoneType enmZoneType)
		{
			AllowDrop = true;
			mobjData = new ZoneDescriptor();
			Dock = DockStyle.Fill;
			mobjManager = objManager;
			base.ParentChanged += Zone_ParentChanged;
			menmZoneType = enmZoneType;
			mblnSusspentUIEvents = false;
			mblnRegistered = false;
			mlngOwningFormId = -1L;
			mblnHideTabs = false;
			InitializeComponent();
			PostInitialization();
		}

		/// 
		/// Adds the window.
		/// </summary>
		/// <param name="enmRelation">The enm relation.</param>
		/// <param name="objDockedWindow">The obj docked window.</param>
		internal void AddWindow(Relation enmRelation, params DockingWindow[] objDockedWindow)
		{
			if (ZoneType == ZoneType.Hidden && (objDockedWindow.Length > 1 || Windows.Count == 1))
			{
				throw new Exception("Hidden zone cannot contain more than one window");
			}
			switch (enmRelation)
			{
			case Relation.Above:
			case Relation.Below:
			case Relation.ToTheRight:
			case Relation.ToTheLeft:
			{
				Zone zone = CreateZoneForNewWindow();
				SplitZone(enmRelation, zone, blnIsNewZone: true);
				zone.AddWindow(Relation.Inside, objDockedWindow);
				break;
			}
			case Relation.Inside:
				foreach (DockingWindow objWindow in objDockedWindow)
				{
					mobjTabControl.AddWindow(objWindow);
				}
				break;
			}
		}

		/// 
		/// Updates the UI.
		/// </summary>
		internal void UpdateUI()
		{
			InitializeUIAccordingToZoneType();
		}

		/// 
		/// Notifies the header text chaged.
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		internal void NotifyHeaderTextChanged(DockingWindow objDockedWindow)
		{
			NotifyTabIndexChanged();
		}

		/// 
		/// Notifies the header tool tip changed.
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		internal void NotifyWindowHeaderAttributeChanged(DockingWindow objDockedWindow)
		{
			NotifyTabIndexChanged();
		}

		/// 
		/// Signals the object that initialization is starting.
		/// </summary>
		public void BeginInit()
		{
			mblnSusspentUIEvents = true;
		}

		/// 
		/// Signals the object that initialization is complete.
		/// </summary>
		public void EndInit()
		{
			mblnSusspentUIEvents = false;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			if (objEvent.Type == "AddForm" && int.TryParse(objEvent["DS"], out var result) && int.TryParse(objEvent["REL"], out var result2))
			{
				DockedForm formFromComponentId = Manager.GetFormFromComponentId(objEvent["DS"]);
				if (formFromComponentId == null)
				{
					throw new Exception("Dragged form with ID=" + result + " was not found");
				}
				SplitForm((Relation)result2, formFromComponentId);
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Raises the <see cref="E:ControlAdded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (e.Control is DockedTabControl dockedTabControl)
			{
				dockedTabControl.OwningZone = this;
				((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
				(e.Control as IDescriptable).Descriptor.UpdateFrom(this, null);
			}
		}

		/// 
		/// Raises the <see cref="E:ControlRemoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			if (e.Control is DockedTabControl dockedTabControl)
			{
				dockedTabControl.OwningZone = null;
				if (base.Parent != null)
				{
					base.Parent.Controls.Remove(this);
				}
				else if (ContainingHiddenPanel != null)
				{
					ContainingHiddenPanel.RemoveSingleZoneFromPanel(this);
				}
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			UpdateUI();
			if (!mblnRegistered)
			{
				mblnRegistered = true;
				Manager.RegisterZone(this);
			}
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			((IDescriptable)this).Descriptor.UpdateSelf(this, mobjManager);
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (ZoneType == ZoneType.Hidden)
			{
				DockingWindow currentWindow = CurrentWindow;
				RenderHiddenZoneImageAttribute(objWriter, currentWindow, blnForceRender: false);
				objWriter.WriteAttributeText("TX", currentWindow.Text);
			}
		}

		/// 
		/// Gets the docking position in relation to the root zone.
		/// </summary>
		/// <param name="objRelation">The obj relation.</param>
		/// </returns>
		private DockStyle GetDockingPositionInRelationToRootZone(Relation objRelation)
		{
			if (ZoneType == ZoneType.Root)
			{
				return objRelation switch
				{
					Relation.Above => DockStyle.Top, 
					Relation.Below => DockStyle.Bottom, 
					Relation.ToTheRight => DockStyle.Right, 
					Relation.ToTheLeft => DockStyle.Left, 
					_ => throw new Exception(), 
				};
			}
			return DockingPosition;
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			if (objDescriptor is ZoneDescriptor zoneDescriptor)
			{
				mobjData = zoneDescriptor;
				return;
			}
			throw new ArgumentException("The given descriptor is not of type: " + typeof(ZoneDescriptor).FullName);
		}

		/// 
		/// Resets the descriptors tree.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// <param name="objDockingPosition">The obj docking position.</param>
		void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
		{
			List<DockingWindow> windows = Windows;
			mobjData = ZoneDescriptorInternal.CloneWithoutReferences<ZoneDescriptor>();
			((IDescriptable)TabControl).ResetDescriptorsTree(objType, objDockingPosition);
			ZoneType = objType;
			foreach (DockingWindow item in windows)
			{
				TabControl.AddWindow(item);
			}
			DockingPosition = objDockingPosition;
			TabControl.DockedTabControlDescriptorInternal.UpdateFrom(this, null);
		}

		/// 
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			mobjHeaderPanel = new ZoneHeaderPanel(this);
			mobjCloseButton = new ZoneCloseButton();
			mobjPinCheckBox = new ZonePinCheckBox();
			mobjDropDownButton = new ZoneDropDownButton();
			mobjTabControl = new DockedTabControl(mobjManager);
			mobjZoneHeaderLabel = new ZoneHeaderLabel();
			mobjHeaderPanel.SuspendLayout();
			SuspendLayout();
			mobjZoneHeaderLabel.Dock = DockStyle.Fill;
			mobjZoneHeaderLabel.AutoSize = true;
			mobjZoneHeaderLabel.Location = new Point(242, 136);
			mobjZoneHeaderLabel.Name = "label1";
			mobjZoneHeaderLabel.Size = new Size(35, 13);
			mobjZoneHeaderLabel.TabIndex = 1;
			mobjZoneHeaderLabel.DoubleClick += mobjHeaderPanel_DoubleClick;
			mobjHeaderPanel.Controls.Add(mobjZoneHeaderLabel);
			mobjHeaderPanel.Controls.Add(mobjDropDownButton);
			mobjHeaderPanel.Controls.Add(mobjPinCheckBox);
			mobjHeaderPanel.Controls.Add(mobjCloseButton);
			mobjHeaderPanel.Dock = DockStyle.Top;
			mobjHeaderPanel.Size = new Size(831, 20);
			mobjHeaderPanel.TabIndex = 0;
			mobjCloseButton.Dock = DockStyle.Right;
			mobjCloseButton.Location = new Point(801, 0);
			mobjCloseButton.Name = "button1";
			mobjCloseButton.Size = new Size(16, 27);
			mobjCloseButton.TabIndex = 0;
			mobjCloseButton.UseVisualStyleBackColor = true;
			mobjCloseButton.Click += mobjCloseButton_Click;
			mobjPinCheckBox.Dock = DockStyle.Right;
			mobjPinCheckBox.Location = new Point(771, 0);
			mobjPinCheckBox.Name = "button2";
			mobjPinCheckBox.Size = new Size(100, 27);
			mobjPinCheckBox.UseVisualStyleBackColor = true;
			mobjPinCheckBox.CheckedChanged += mobjPinCheckBox_CheckedChanged;
			mobjDropDownButton.Dock = DockStyle.Right;
			mobjDropDownButton.Location = new Point(745, 0);
			mobjDropDownButton.Name = "button3";
			mobjDropDownButton.Size = new Size(26, 27);
			mobjDropDownButton.TabIndex = 2;
			mobjDropDownButton.UseVisualStyleBackColor = true;
			mobjDropDownButton.Click += mobjMenuButton_Click;
			mobjTabControl.Dock = DockStyle.Fill;
			mobjTabControl.Location = new Point(0, 27);
			mobjTabControl.Name = "tabControl1";
			mobjTabControl.SelectedIndex = 0;
			mobjTabControl.Size = new Size(831, 606);
			mobjTabControl.TabIndex = 1;
			base.Controls.Add(mobjTabControl);
			base.Controls.Add(mobjHeaderPanel);
			mobjHeaderPanel.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Initializes the custom controls.
		/// </summary>
		private void InitializeCustomControls()
		{
			ZoneCloseButtonSkin zoneCloseButtonSkin = SkinFactory.GetSkin(mobjCloseButton) as ZoneCloseButtonSkin;
			ZonePinCheckBoxSkin zonePinCheckBoxSkin = SkinFactory.GetSkin(mobjPinCheckBox) as ZonePinCheckBoxSkin;
			ZoneDropDownButtonSkin zoneDropDownButtonSkin = SkinFactory.GetSkin(mobjDropDownButton) as ZoneDropDownButtonSkin;
			mobjCloseButton.Size = zoneCloseButtonSkin.TotalSize;
			mobjCloseButton.Text = "";
			mobjPinCheckBox.Size = zonePinCheckBoxSkin.TotalSize;
			mobjPinCheckBox.Text = "";
			mobjDropDownButton.Size = zoneDropDownButtonSkin.TotalSize;
			mobjDropDownButton.Text = "";
		}

		/// 
		/// Initializes the dock zone type UI.
		/// </summary>
		private void InitializeDockZoneTypeUI()
		{
			InitializeHeaderPanelVisibility(blnIsVisible: true);
			InitializeCloseButtonVisibility(blnIsVisible: true);
			InitializeDropDownButtonVisibility(blnIsVisible: true);
			InitializePinButtonVisibility(blnIsVisible: true);
			mobjCloseButton.ClientAction = null;
			mobjPinCheckBox.ClientAction = null;
			((IPreventExtraction)mobjTabControl).DisableExtraction(blnDisable: false);
			InitializeTabControlAppearance(blnIsRoot: false);
		}

		/// 
		/// Initializes the pin button visibility.
		/// </summary>
		/// <param name="blnIsVisible">if set to true</c> [BLN is visible].</param>
		private void InitializePinButtonVisibility(bool blnIsVisible)
		{
			mobjPinCheckBox.Visible = blnIsVisible && Manager != null && Manager.ShowPinButton;
		}

		/// 
		/// Initializes the drop down button visibility.
		/// </summary>
		/// <param name="blnIsVisible">if set to true</c> [BLN is visible].</param>
		private void InitializeDropDownButtonVisibility(bool blnIsVisible)
		{
			mobjDropDownButton.Visible = blnIsVisible && Manager != null && Manager.ShowDropDownButton;
		}

		/// 
		/// Initializes the close button visibility.
		/// </summary>
		/// <param name="blnIsVisible">if set to true</c> [BLN is visible].</param>
		private void InitializeCloseButtonVisibility(bool blnIsVisible)
		{
			mobjCloseButton.Visible = blnIsVisible && Manager != null && Manager.AllowCloseWindows;
		}

		/// 
		/// Initializes the header panel visibility.
		/// </summary>
		/// <param name="blnIsVisible">if set to true</c> [BLN is visible].</param>
		private void InitializeHeaderPanelVisibility(bool blnIsVisible)
		{
			mobjHeaderPanel.Visible = blnIsVisible;
		}

		/// 
		/// Initializes the float zone type UI.
		/// </summary>
		private void InitializeFloatZoneTypeUI()
		{
			InitializeHeaderPanelVisibility(blnIsVisible: true);
			InitializeCloseButtonVisibility(blnIsVisible: true);
			InitializeDropDownButtonVisibility(blnIsVisible: true);
			InitializePinButtonVisibility(blnIsVisible: false);
			mobjCloseButton.ClientAction = null;
			mobjPinCheckBox.ClientAction = null;
			((IPreventExtraction)mobjTabControl).DisableExtraction(blnDisable: false);
			InitializeTabControlAppearance(blnIsRoot: false);
		}

		/// 
		/// Initializes the hidden zone type UI.
		/// </summary>
		private void InitializeHiddenZoneTypeUI()
		{
			InitializeHeaderPanelVisibility(blnIsVisible: true);
			InitializeCloseButtonVisibility(blnIsVisible: true);
			InitializeDropDownButtonVisibility(blnIsVisible: true);
			InitializePinButtonVisibility(blnIsVisible: true);
			mobjPinCheckBox.Checked = true;
		}

		/// 
		/// Initializes the type of the root zone.
		/// </summary>
		private void InitializeRootZoneType()
		{
			InitializeHeaderPanelVisibility(blnIsVisible: false);
			mobjTabControl.ShowCloseButton = Manager != null && Manager.AllowCloseWindows;
			mobjTabControl.CloseClick += mobjTabControl_CloseClick;
			((IPreventExtraction)mobjTabControl).DisableExtraction(blnDisable: true);
			InitializeTabControlAppearance(blnIsRoot: true);
		}

		private void InitializeTabControlAppearance(bool blnIsRoot)
		{
			if (!blnIsRoot)
			{
				mobjTabControl.Alignment = TabAlignment.Bottom;
				mobjTabControl.ControlAdded -= mobjTabControl_RootControlAdded;
				mobjTabControl.ControlRemoved -= mobjTabControl_RootControlRemoved;
				mobjTabControl.ControlAdded += mobjTabControl_ControlAdded;
				mobjTabControl.ControlRemoved += mobjTabControl_ControlRemoved;
			}
			else
			{
				mobjTabControl.Alignment = TabAlignment.Top;
				mobjTabControl.ControlAdded -= mobjTabControl_ControlAdded;
				mobjTabControl.ControlRemoved -= mobjTabControl_ControlRemoved;
				mobjTabControl.ControlAdded += mobjTabControl_RootControlAdded;
				mobjTabControl.ControlRemoved += mobjTabControl_RootControlRemoved;
			}
		}

		/// 
		/// Initializes the type of the UI according to zone.
		/// </summary>
		private void InitializeUIAccordingToZoneType()
		{
			BeginInit();
			switch (menmZoneType)
			{
			case ZoneType.Root:
				InitializeRootZoneType();
				break;
			case ZoneType.Dock:
				InitializeDockZoneTypeUI();
				break;
			case ZoneType.Float:
				InitializeFloatZoneTypeUI();
				break;
			case ZoneType.Hidden:
				InitializeHiddenZoneTypeUI();
				break;
			default:
				throw new Exception("Zone type not supported: " + menmZoneType);
			}
			SetTabControlTabsAppearance();
			EndInit();
		}

		/// 
		/// Handles the Click event of the mobjCloseButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjCloseButton_Click(object sender, EventArgs e)
		{
			CloseCurrentWindow();
			CloseZonePopupForm();
		}

		/// 
		/// Closes the current window.
		/// </summary>
		private void CloseCurrentWindow()
		{
			Manager.SwitchWindowsDockState(DockState.Close, CurrentWindow);
		}

		/// 
		/// Closes the zone popup window.
		/// </summary>
		private void CloseZonePopupForm()
		{
			if (mobjZonePopupForm != null)
			{
				mobjZonePopupForm.Close();
			}
		}

		/// 
		/// Handles the DoubleClick event of the mobjHeaderPanel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjHeaderPanel_DoubleClick(object sender, EventArgs e)
		{
			OnHeaderDoubleClick();
			CloseZonePopupForm();
		}

		/// 
		/// Handles the Click event of the mobjMenuButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjMenuButton_Click(object sender, EventArgs e)
		{
			Manager.GetDockedContextMenuStrip(this).Show(mobjDropDownButton, new Point(1, 1), ToolStripDropDownDirection.BelowLeft);
		}

		/// 
		/// Handles the CheckedChanged event of the mobjPinCheckBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjPinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!mblnSusspentUIEvents)
			{
				ToggleAutoHide();
			}
		}

		/// 
		/// Handles the CloseClick event of the mobjTabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjTabControl_CloseClick(object sender, EventArgs e)
		{
			CloseCurrentWindow();
		}

		/// 
		/// Handles the ControlAdded event of the mobjTabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void mobjTabControl_ControlAdded(object sender, ControlEventArgs e)
		{
			SetTabControlTabsAppearance();
		}

		/// 
		/// Handles the ControlRemoved event of the mobjTabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void mobjTabControl_ControlRemoved(object sender, ControlEventArgs e)
		{
			SetTabControlTabsAppearance();
		}

		/// 
		/// Handles the RootControlAdded event of the mobjTabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void mobjTabControl_RootControlAdded(object sender, ControlEventArgs e)
		{
			HandleRootTabControlControlsChanged();
		}

		/// 
		/// Handles the RootControlRemoved event of the mobjTabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void mobjTabControl_RootControlRemoved(object sender, ControlEventArgs e)
		{
			HandleRootTabControlControlsChanged();
		}

		/// 
		/// Handles the root tab control controls changed.
		/// </summary>
		private void HandleRootTabControlControlsChanged()
		{
			if (mobjTabControl.Controls.Count > 0)
			{
				mobjTabControl.ShowCloseButton = true;
			}
			else
			{
				mobjTabControl.ShowCloseButton = false;
			}
		}

		/// 
		/// Posts the initialization.
		/// </summary>
		private void PostInitialization()
		{
			InitializeCustomControls();
		}

		/// 
		/// Removes the and return all windows.
		/// </summary>
		/// </returns>
		internal List<DockingWindow> RemoveAndReturnAllWindows()
		{
			List<DockingWindow> windows = Windows;
			RemoveWindows(Windows.ToArray());
			return windows;
		}

		/// 
		/// Renders the hidden zone image attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objWindow">The obj window.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderHiddenZoneImageAttribute(IAttributeWriter objWriter, DockingWindow objWindow, bool blnForceRender)
		{
			if (objWindow.Image != null || blnForceRender)
			{
				objWriter.WriteAttributeString("IM", objWindow.Image.ToString());
			}
		}

		/// 
		/// Sets the tab control tabs appearance.
		/// </summary>
		private void SetTabControlTabsAppearance()
		{
			if ((mobjTabControl.Controls.Count == 1 && ZoneType != ZoneType.Root) || ZoneType == ZoneType.Hidden || mblnHideTabs)
			{
				mobjTabControl.Appearance = TabAppearance.Logical;
			}
			else
			{
				mobjTabControl.Appearance = TabAppearance.Normal;
			}
		}

		/// 
		/// Splits the zone.
		/// </summary>
		/// <param name="objRelation">The obj relation.</param>
		/// <param name="objZone">The obj zone.</param>
		/// <param name="blnIsNewZone">if set to true</c> [BLN is new zone].</param>
		private void SplitZone(Relation objRelation, Zone objZone, bool blnIsNewZone)
		{
			if (objZone.ZoneType == ZoneType.Root)
			{
				return;
			}
			switch (objRelation)
			{
			case Relation.Above:
			case Relation.Below:
			case Relation.ToTheRight:
			case Relation.ToTheLeft:
			{
				DockStyle dockingPositionInRelationToRootZone = GetDockingPositionInRelationToRootZone(objRelation);
				if (ZoneType == objZone.ZoneType)
				{
					Control logicalParentControl = DockedManagerHelper.GetLogicalParentControl(objZone);
					if (logicalParentControl != null && logicalParentControl is DockedSplitContainer)
					{
						(logicalParentControl as DockedSplitContainer).HardRemovePanel(objZone.PanelSide);
					}
				}
				else if (!blnIsNewZone)
				{
					((IDescriptable)objZone).ResetDescriptorsTree((ZoneType == ZoneType.Root) ? ZoneType.Dock : ZoneType, dockingPositionInRelationToRootZone);
				}
				objZone.DockingPosition = dockingPositionInRelationToRootZone;
				DockedManagerHelper.SplitControl(this, objZone, objRelation, Manager);
				break;
			}
			case Relation.Inside:
			{
				List<DockingWindow> list = objZone.RemoveAndReturnAllWindows();
				AddWindow(Relation.Inside, list.ToArray());
				break;
			}
			default:
				throw new Exception("Unsupported Relation type: " + objRelation);
			}
		}

		/// 
		/// Handles the ParentChanged event of the Zone control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void Zone_ParentChanged(object sender, EventArgs e)
		{
			if (base.Parent != null || ContainingHiddenPanel != null)
			{
				if (ID != 0L && !mblnRegistered)
				{
					Manager.RegisterZone(this);
					mblnRegistered = true;
				}
			}
			else
			{
				Manager.UnRegisterZone(this);
				mblnRegistered = false;
			}
		}

		/// 
		/// Removes the and return all windows.
		/// </summary>
		/// </returns>
		internal DockingWindow RemoveAndReturnCurrentWindow()
		{
			DockingWindow currentWindow = CurrentWindow;
			RemoveWindows(currentWindow);
			return currentWindow;
		}

		/// 
		/// Removes the windows.
		/// </summary>
		/// <param name="arrWindows">The arr windows.</param>
		internal void RemoveWindows(params DockingWindow[] arrWindows)
		{
			foreach (DockingWindow objWindow in arrWindows)
			{
				TabControl.RemoveWindow(objWindow);
			}
		}

		/// 
		/// Creates the zone for new window.
		/// </summary>
		/// </returns>
		internal Zone CreateZoneForNewWindow()
		{
			return new Zone(Manager, (menmZoneType == ZoneType.Root) ? ZoneType.Dock : menmZoneType);
		}

		/// 
		/// Hides the current window.
		/// </summary>
		internal void HideCurrentWindow()
		{
			HideWindow(CurrentWindow);
			CloseZonePopupForm();
		}

		/// 
		/// Hides the window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		internal void HideWindow(DockingWindow objWindow)
		{
			Manager.SwitchWindowsDockState(DockState.Hidden, objWindow);
		}

		/// 
		/// Notifies the tab index changed.
		/// </summary>
		internal void NotifyTabIndexChanged()
		{
			if (mobjTabControl.TabPages.Count > 0)
			{
				DockingWindow window = (mobjTabControl.SelectedItem as DockedTabPage).Window;
				mobjZoneHeaderLabel.Text = window.HeaderText;
				if (!string.IsNullOrEmpty(window.HeaderToolTip))
				{
					mobjZoneHeaderLabel.ToolTip = window.HeaderToolTip;
				}
				else
				{
					mobjZoneHeaderLabel.ToolTip = string.Empty;
				}
			}
			else
			{
				mobjZoneHeaderLabel.Text = string.Empty;
			}
		}

		/// 
		/// Called when [header double click].
		/// </summary>
		internal virtual void OnHeaderDoubleClick()
		{
			List<DockingWindow> windows = Windows;
			DockState objDesiredDockState = ((menmZoneType == ZoneType.Root) ? DockState.Dock : DockingManager.GetDockStateAccordingToZoneType(menmZoneType));
			Manager.SwitchWindowsDockState(objDesiredDockState, windows.ToArray());
		}

		/// 
		/// Splits this zone with a given docked form.
		/// </summary>
		/// <param name="enmRelation">The enm relation.</param>
		/// <param name="objForm">The obj form.</param>
		internal void SplitForm(Relation enmRelation, DockedForm objForm)
		{
			Control control = objForm.Controls[0];
			bool flag = ZoneType != ZoneType.Float;
			DockingWindow[] array = null;
			if (control is Zone)
			{
				Zone zone = control as Zone;
				SplitZone(enmRelation, zone, blnIsNewZone: false);
				if (flag)
				{
					array = zone.Windows.ToArray();
				}
			}
			else
			{
				if (!(control is DockedSplitContainer))
				{
					throw new Exception("The root control inside a DockedForm must be of type: '" + typeof(Zone).FullName + "' this ZoneType = Floating, or " + typeof(DockedSplitContainer).FullName);
				}
				DockedSplitContainer dockedSplitContainer = control as DockedSplitContainer;
				switch (enmRelation)
				{
				case Relation.Above:
				case Relation.Below:
				case Relation.ToTheRight:
				case Relation.ToTheLeft:
					if (flag)
					{
						((IDescriptable)dockedSplitContainer).ResetDescriptorsTree((ZoneType == ZoneType.Root) ? ZoneType.Dock : ZoneType, GetDockingPositionInRelationToRootZone(enmRelation));
						array = dockedSplitContainer.Windows.ToArray();
					}
					DockedManagerHelper.SplitControl(this, control, enmRelation, Manager);
					break;
				case Relation.Inside:
					array = dockedSplitContainer.Windows.ToArray();
					AddWindow(enmRelation, array);
					break;
				}
			}
			if (flag && Manager != null)
			{
				Manager.OnWindowsStateChanged(DockState.Float, (ZoneType != ZoneType.Root) ? DockState.Dock : DockState.Tabbed, array);
			}
		}

		/// 
		/// Switches the state of the current window dock.
		/// </summary>
		/// <param name="objDesiredDockState">State of the obj desired dock.</param>
		internal void SwitchCurrentWindowDockState(DockState objDesiredDockState)
		{
			CloseZonePopupForm();
			Manager.SwitchWindowsDockState(objDesiredDockState, CurrentWindow);
		}

		/// 
		/// Toggles the auto hide.
		/// </summary>
		internal void ToggleAutoHide()
		{
			DockState dockState = DockState.AutoHide;
			if (ZoneType == ZoneType.Dock)
			{
				dockState = DockState.AutoHide;
			}
			else
			{
				if (ZoneType != ZoneType.Hidden)
				{
					throw new Exception($"Zone of type: '{ZoneType}', does not support AutoHide");
				}
				dockState = DockState.Dock;
				CloseZonePopupForm();
			}
			Manager.SwitchWindowsDockState(dockState, Windows.ToArray());
		}

		/// 
		/// Invokes the parent changed.
		/// </summary>
		internal void InvokeParentChanged()
		{
			OnParentChanged(EventArgs.Empty);
		}
	}
}
