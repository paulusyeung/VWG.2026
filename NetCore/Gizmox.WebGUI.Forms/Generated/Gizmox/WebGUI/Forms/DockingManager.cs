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
	[MetadataTag("DM")]
	[Skin(typeof(DockingManagerSkin))]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(DockingManager), "Professional.DockedManager.DockingManager_45.png")]
	public class DockingManager : ContainerControl, IDescriptable
	{
		/// 
		///
		/// </summary>
		private struct RemovedWindowsData
		{
			private DockingWindow[] mobjWindows;

			private DockState mobjDesiredDockState;

			private DockState menmPreviousDockState;

			private bool mblnHasDockingStateInfo;

			private bool mblnHasFloatingStateInfo;

			private DockStyle menmUnpinPosition;

			/// 
			/// Gets or sets the unpin position.
			/// </summary>
			/// 
			/// The unpin position.
			/// </value>
			public DockStyle UnpinPosition
			{
				get
				{
					return menmUnpinPosition;
				}
				set
				{
					menmUnpinPosition = value;
				}
			}

			/// 
			/// Gets or sets a value indicating whether this instance has floating state info.
			/// </summary>
			/// 
			/// 	true</c> if this instance has floating state info; otherwise, false</c>.
			/// </value>
			public bool HasFloatingStateInfo
			{
				get
				{
					return mblnHasFloatingStateInfo;
				}
				set
				{
					mblnHasFloatingStateInfo = value;
				}
			}

			/// 
			/// Gets or sets a value indicating whether this instance has docking state info.
			/// </summary>
			/// 
			/// 	true</c> if this instance has docking state info; otherwise, false</c>.
			/// </value>
			public bool HasDockingStateInfo
			{
				get
				{
					return mblnHasDockingStateInfo;
				}
				set
				{
					mblnHasDockingStateInfo = value;
				}
			}

			/// 
			/// Gets or sets the state of the previous dock.
			/// </summary>
			/// 
			/// The state of the previous dock.
			/// </value>
			public DockState PreviousDockState
			{
				get
				{
					return menmPreviousDockState;
				}
				set
				{
					menmPreviousDockState = value;
				}
			}

			/// 
			/// Gets or sets the state of the desired dock.
			/// </summary>
			/// 
			/// The state of the desired dock.
			/// </value>
			public DockState DesiredDockState
			{
				get
				{
					return mobjDesiredDockState;
				}
				set
				{
					mobjDesiredDockState = value;
				}
			}

			/// 
			/// Gets or sets the windows.
			/// </summary>
			/// 
			/// The windows.
			/// </value>
			public DockingWindow[] Windows
			{
				get
				{
					return mobjWindows;
				}
				set
				{
					mobjWindows = value;
				}
			}
		}

		internal static readonly SerializableEvent EVENT_TABBEDWINDOWSELECTED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));

		internal static readonly SerializableEvent EVENT_TABBEDWINDOWCLOSED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));

		internal static readonly SerializableEvent EVENT_DOCKINGWINDOWLOADED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));

		internal static readonly SerializableEvent EVENT_WINDOWSSTATECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DockingManager));

		private List<object> mobjAllZones;

		private List<object> mobjLiveFormsIds;

		private DockedManagerDescriptor mobjData;

		private DockedContextMenuStrip mobjDockedContextMenuStrip;

		private Dictionary<DockedSplitContainerDescriptor, DockedSplitContainer> mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor;

		private Zone mobjRootZone = null;

		private DockedHiddenZonesPanel mobjRightPanel;

		private DockedHiddenZonesPanel mobjTopPanel;

		private DockedHiddenZonesPanel mobjBottomPanel;

		private DockedHiddenZonesPanel mobjLeftPanel;

		private DockedWindowsCollection mobjDockedWindowsCollection;

		private Dictionary<string, long> mobjDockedFormsIdsIndexByDockedFormsUniqueId;

		private bool mblnIsInLoadMode;

		/// 
		/// Gets a value indicating whether this instance is in load mode.
		/// </summary>
		/// 
		/// 	true</c> if this instance is in load mode; otherwise, false</c>.
		/// </value>
		internal bool IsInLoadMode
		{
			get
			{
				return mblnIsInLoadMode;
			}
			private set
			{
				mblnIsInLoadMode = value;
			}
		}

		/// 
		/// Gets or sets the pin animation speed.
		/// </summary>
		/// 
		/// The pin animation speed.
		/// </value>
		public int PinAnimationSpeed
		{
			get
			{
				return mobjData.PinAnimationSpeed;
			}
			set
			{
				if (mobjData.PinAnimationSpeed != value)
				{
					mobjData.PinAnimationSpeed = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets the docked windows.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public DockedWindowsCollection DockedWindows => mobjDockedWindowsCollection;

		/// 
		/// Gets or sets a value indicating whether [show close button].
		/// </summary>
		/// 
		///   true</c> if [show close button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool AllowFloatingWindows
		{
			get
			{
				return mobjData.AllowFloatingWindows;
			}
			set
			{
				mobjData.AllowFloatingWindows = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow tabbed documents].
		/// </summary>
		/// 
		///   true</c> if [allow tabbed documents]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool AllowTabbedDocuments
		{
			get
			{
				return mobjData.AllowTabbedDocuments;
			}
			set
			{
				mobjData.AllowTabbedDocuments = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show close button].
		/// </summary>
		/// 
		///   true</c> if [show close button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[Browsable(false)]
		public bool AllowCloseWindows
		{
			get
			{
				return mobjData.AllowCloseWindows;
			}
			set
			{
				if (mobjData.AllowCloseWindows != value)
				{
					mobjData.AllowCloseWindows = value;
					UpdateZonesUI();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show close button].
		/// </summary>
		/// 
		///   true</c> if [show close button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[Browsable(false)]
		[Obsolete("Use AllowCloseWindows property instead")]
		public bool ShowCloseButton
		{
			get
			{
				return AllowCloseWindows;
			}
			set
			{
				AllowCloseWindows = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show minimize button].
		/// </summary>
		/// 
		///   true</c> if [show minimize button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool ShowMinimizeButton
		{
			get
			{
				return mobjData.ShowMinimizeButton;
			}
			set
			{
				if (mobjData.ShowMinimizeButton != value)
				{
					mobjData.ShowMinimizeButton = value;
					InitializeAllLiveFormsUI();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show maximize button].
		/// </summary>
		/// 
		///   true</c> if [show maximize button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool ShowMaximizeButton
		{
			get
			{
				return mobjData.ShowMaximizeButton;
			}
			set
			{
				if (mobjData.ShowMaximizeButton != value)
				{
					mobjData.ShowMaximizeButton = value;
					InitializeAllLiveFormsUI();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show pin button].
		/// </summary>
		/// 
		///   true</c> if [show pin button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool ShowPinButton
		{
			get
			{
				return mobjData.ShowPinButton;
			}
			set
			{
				if (mobjData.ShowPinButton != value)
				{
					mobjData.ShowPinButton = value;
					UpdateZonesUI();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show drop down button].
		/// </summary>
		/// 
		///   true</c> if [show drop down button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool ShowDropDownButton
		{
			get
			{
				return mobjData.ShowDropDownButton;
			}
			set
			{
				if (mobjData.ShowDropDownButton != value)
				{
					mobjData.ShowDropDownButton = value;
					UpdateZonesUI();
				}
			}
		}

		/// 
		/// Gets the docked context menu strip.
		/// </summary>
		private DockedContextMenuStrip DockedContextMenuStrip
		{
			get
			{
				if (mobjDockedContextMenuStrip == null)
				{
					mobjDockedContextMenuStrip = new DockedContextMenuStrip(this);
				}
				return mobjDockedContextMenuStrip;
			}
		}

		/// 
		/// Gets the hidden panel.
		/// </summary>
		internal DockedHiddenZonesPanel HiddenPanel
		{
			get
			{
				if (mobjLeftPanel != null)
				{
					return mobjLeftPanel;
				}
				return new DockedHiddenZonesPanel(null);
			}
		}

		/// 
		/// Gets the root zone.
		/// </summary>
		internal Zone RootZone
		{
			get
			{
				return mobjRootZone;
			}
			private set
			{
				mobjRootZone = value;
			}
		}

		/// 
		/// Gets the docked panels padding.
		/// </summary>
		/// 
		/// The docked panels padding.
		/// </value>
		internal Padding DockedPanelsPadding => new Padding((mobjLeftPanel != null && mobjLeftPanel.Visible) ? (mobjLeftPanel.Width + Padding.Left + BorderWidth.Left) : (Padding.Left + BorderWidth.Left), (mobjTopPanel != null && mobjTopPanel.Visible) ? (mobjTopPanel.Height + Padding.Top + BorderWidth.Top) : (Padding.Top + BorderWidth.Top), (mobjRightPanel != null && mobjRightPanel.Visible) ? (mobjRightPanel.Width + Padding.Right + BorderWidth.Right) : (Padding.Right + BorderWidth.Right), (mobjBottomPanel != null && mobjBottomPanel.Visible) ? (mobjBottomPanel.Height + Padding.Bottom + BorderWidth.Bottom) : (Padding.Bottom + BorderWidth.Bottom));

		/// 
		/// Hides the main content tabs not enabling to switch between open windows/tabs.
		/// </summary>
		[DefaultValue(false)]
		public bool HideRootZoneTabHeaders
		{
			get
			{
				if (mobjRootZone != null)
				{
					return mobjRootZone.HideTabs;
				}
				return false;
			}
			set
			{
				if (mobjRootZone != null)
				{
					mobjRootZone.HideTabs = value;
				}
			}
		}

		/// 
		/// Gets the descriptor.
		/// </summary>
		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets the docked manager descriptor internal.
		/// </summary>
		internal DockedManagerDescriptor DockedManagerDescriptorInternal => mobjData;

		/// 
		/// Occurs when [tabbed window closed].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a tabbed window is closed")]
		public event TabbedWindowClosedEventHandler TabbedWindowClosed
		{
			add
			{
				if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWCLOSED) == 0)
				{
					RootZone.TabControl.ControlRemoved += TabControl_ControlRemoved;
				}
				AddHandler(EVENT_TABBEDWINDOWCLOSED, value);
			}
			remove
			{
				RemoveHandler(EVENT_TABBEDWINDOWCLOSED, value);
				if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWCLOSED) == 0)
				{
					RootZone.TabControl.ControlRemoved -= TabControl_ControlRemoved;
				}
			}
		}

		/// 
		/// Occurs when [docking window loaded].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a DockingWindow is loaded from the LoadData operation")]
		public event DockingWindowLoadedEventHandler DockingWindowLoaded
		{
			add
			{
				AddHandler(EVENT_DOCKINGWINDOWLOADED, value);
			}
			remove
			{
				RemoveHandler(EVENT_DOCKINGWINDOWLOADED, value);
			}
		}

		/// 
		/// Occurs when [windows state changed].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when window's state is changed")]
		public event WindowsStateChangedEventHandler WindowsStateChanged
		{
			add
			{
				AddHandler(EVENT_WINDOWSSTATECHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_WINDOWSSTATECHANGED, value);
			}
		}

		/// 
		/// Occurs when [tabbed window selected].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a tabbed window is selected")]
		public event TabbedWindowSelectedEventHandler TabbedWindowSelected
		{
			add
			{
				if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWSELECTED) == 0)
				{
					RootZone.TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
				}
				AddHandler(EVENT_TABBEDWINDOWSELECTED, value);
			}
			remove
			{
				RemoveHandler(EVENT_TABBEDWINDOWSELECTED, value);
				if (GetTabbedWindowSelectedEventCount(EVENT_TABBEDWINDOWSELECTED) == 0)
				{
					RootZone.TabControl.SelectedIndexChanged -= TabControl_SelectedIndexChanged;
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockingManager" /> class.
		/// </summary>
		public DockingManager()
		{
			InitializeDockedManager(null);
		}

		/// 
		/// Closes all floating windows.
		/// </summary>
		public void CloseAllFloatingWindows()
		{
			IEnumerable enumerable = CopyCollection(mobjLiveFormsIds);
			foreach (long item in enumerable)
			{
				GetFormFromComponentId(item)?.Close();
			}
		}

		/// 
		/// Initializes all live forms UI.
		/// </summary>
		private void InitializeAllLiveFormsUI()
		{
			foreach (long mobjLiveFormsId in mobjLiveFormsIds)
			{
				DockedForm formFromComponentId = GetFormFromComponentId(mobjLiveFormsId);
				InitializeFormUI(formFromComponentId);
			}
		}

		/// 
		/// Initializes the form UI.
		/// </summary>
		/// <param name="objLiveForm">The obj live form.</param>
		private void InitializeFormUI(DockedForm objForm)
		{
			objForm.MinimizeBox = ShowMinimizeButton;
			objForm.MaximizeBox = ShowMaximizeButton;
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderHiddenZoneExpansionSpeed(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the hidden zone expansion speed.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderHiddenZoneExpansionSpeed(IAttributeWriter objWriter, bool blnForceRender)
		{
			int pinAnimationSpeed = PinAnimationSpeed;
			if (pinAnimationSpeed != (SkinFactory.GetSkin(mobjRightPanel) as DockedHiddenZonesPanelSkin).HiddenZoneItemExpantionAnimationDuration || blnForceRender)
			{
				objWriter.WriteAttributeString("ZAS", pinAnimationSpeed.ToString());
			}
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
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderHiddenZoneExpansionSpeed(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Gets the docked context menu strip.
		/// </summary>
		/// <param name="mobjOwningZone">The mobj owning zone.</param>
		/// </returns>
		internal ContextMenuStrip GetDockedContextMenuStrip(Zone mobjOwningZone)
		{
			return DockedContextMenuStrip.SetZone(mobjOwningZone);
		}

		/// 
		/// Docks the windows in root position.
		/// </summary>
		/// <param name="enmRelation">The enm relation.</param>
		/// <param name="objDockedWindows">The obj docked windows.</param>
		private void DockWindowsInRootPosition(Relation enmRelation, params DockingWindow[] objDockedWindows)
		{
			if (enmRelation == Relation.Inside)
			{
				SwitchWindowsDockState(DockState.Tabbed, objDockedWindows);
				return;
			}
			int intControlIndex;
			Control descriptableControl = DockedManagerHelper.GetDescriptableControl(this, out intControlIndex);
			Zone zone = new Zone(this, ZoneType.Dock);
			DockedManagerHelper.SplitControl(descriptableControl, zone, enmRelation, this);
			zone.AddWindow(Relation.Inside, objDockedWindows);
			switch (enmRelation)
			{
			case Relation.Above:
				zone.DockingPosition = DockStyle.Top;
				break;
			case Relation.Below:
				zone.DockingPosition = DockStyle.Bottom;
				break;
			case Relation.ToTheRight:
				zone.DockingPosition = DockStyle.Right;
				break;
			case Relation.ToTheLeft:
				zone.DockingPosition = DockStyle.Left;
				break;
			default:
				throw new Exception();
			}
		}

		/// 
		/// Closes all.
		/// </summary>
		public void CloseAll()
		{
			IEnumerable enumerable = CopyCollection(DockedWindows.WindowsIndexByWindowName.Values);
			foreach (DockingWindow item in enumerable)
			{
				item.Close();
			}
		}

		/// 
		/// Shows all.
		/// </summary>
		public void ShowAll()
		{
			IEnumerable enumerable = CopyCollection(DockedWindows.HiddenWindowsIndexByWindowName.Values);
			foreach (DockingWindow item in enumerable)
			{
				item.Show();
			}
		}

		/// 
		/// Copies the collection.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="collection">The collection.</param>
		/// </returns>
		private IEnumerable CopyCollection(ICollection collection)
		{
			T[] array = new T[collection.Count];
			collection.CopyTo(array, 0);
			return array;
		}

		/// 
		/// Unpins all.
		/// </summary>
		public void UnpinAll()
		{
			List<object> list = new List<object><object>();
			foreach (Zone mobjAllZone in mobjAllZones)
			{
				if (mobjAllZone.ZoneType == ZoneType.Dock)
				{
					list.Add(mobjAllZone);
				}
			}
			foreach (Zone item in list)
			{
				item.ToggleAutoHide();
			}
		}

		/// 
		/// Pins all.
		/// </summary>
		public void PinAll()
		{
			IEnumerable enumerable = CopyCollection(DockedWindows.WindowsIndexByWindowName.Values);
			foreach (DockingWindow item in enumerable)
			{
				if (item.CurrentDockState == DockState.AutoHide)
				{
					SwitchWindowsDockState(DockState.Dock, item);
				}
			}
		}

		/// 
		/// Shows the hidden window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		internal void ShowHiddenWindow(DockingWindow objWindow)
		{
			if (DockedWindows.HiddenWindowsIndexByWindowName.TryGetValue(objWindow.WindowName, out var value))
			{
				RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(objWindow, ZoneType.Hidden);
				AddWindow(value.LastDockState, DockStyle.Fill, objWindow);
			}
		}

		/// 
		/// Gets the tabbed window selected event count.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private int GetTabbedWindowSelectedEventCount(SerializableEvent objEvent)
		{
			Delegate handler = GetHandler(objEvent);
			if ((object)handler != null)
			{
				return handler.GetInvocationList().Length;
			}
			return 0;
		}

		/// 
		/// Handles the ControlRemoved event of the TabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		private void TabControl_ControlRemoved(object sender, ControlEventArgs e)
		{
			OnTabbedWindowClosed((e.Control as DockedTabPage).Window);
		}

		/// 
		/// Called when [tabbed window closed].
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		private void OnTabbedWindowClosed(DockingWindow objDockedWindow)
		{
			if (GetHandler(EVENT_TABBEDWINDOWCLOSED) is TabbedWindowClosedEventHandler tabbedWindowClosedEventHandler)
			{
				tabbedWindowClosedEventHandler(this, new TabbedWindowClosedEventArgs(objDockedWindow));
			}
		}

		/// 
		/// Called when [docking window loaded].
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		private void OnDockingWindowLoaded(DockingWindow objDockedWindow)
		{
			if (GetHandler(EVENT_DOCKINGWINDOWLOADED) is DockingWindowLoadedEventHandler dockingWindowLoadedEventHandler)
			{
				dockingWindowLoadedEventHandler(this, new DockingWindowLoadedEventArgs(objDockedWindow));
			}
		}

		/// 
		/// Called when [windows state changed].
		/// </summary>
		/// <param name="enmPreviousDockState">State of the enm previous dock.</param>
		/// <param name="enmNewDockState">State of the enm new dock.</param>
		/// <param name="arrChangedWindows">The arr changed windows.</param>
		internal void OnWindowsStateChanged(DockState enmPreviousDockState, DockState enmNewDockState, DockingWindow[] arrChangedWindows)
		{
			if (GetHandler(EVENT_WINDOWSSTATECHANGED) is WindowsStateChangedEventHandler windowsStateChangedEventHandler)
			{
				windowsStateChangedEventHandler(this, new WindowsStateChangedEventArgs(enmPreviousDockState, enmNewDockState, arrChangedWindows));
			}
		}

		/// 
		/// Handles the SelectedIndexChanged event of the TabControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is DockedTabControl { SelectedItem: not null } dockedTabControl)
			{
				OnTabbedWindowSelected((dockedTabControl.SelectedItem as DockedTabPage).Window);
			}
		}

		/// 
		/// Called when [tabbed window selected].
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		private void OnTabbedWindowSelected(DockingWindow objDockedWindow)
		{
			if (GetHandler(EVENT_TABBEDWINDOWSELECTED) is TabbedWindowSelectedEventHandler tabbedWindowSelectedEventHandler)
			{
				tabbedWindowSelectedEventHandler(this, new TabbedWindowSelectedEventArgs(objDockedWindow));
			}
		}

		/// 
		/// Switches the state of the window dock.
		/// </summary>
		/// <param name="objDesiredDockState">State of the obj desired dock.</param>
		/// <param name="objWindows">The windows.</param>
		internal void SwitchWindowsDockState(DockState objDesiredDockState, params DockingWindow[] objWindows)
		{
			Relation enmDockInRootRelation = Relation.Inside;
			DockingWindow dockingWindow = null;
			if (objWindows.Length != 0)
			{
				dockingWindow = objWindows[0];
			}
			RemovedWindowsData removedWindowsData = RemoveWindowFromPreviousDockState(objDesiredDockState, dockingWindow, objWindows);
			bool flag = removedWindowsData.DesiredDockState == DockState.Dock && !removedWindowsData.HasDockingStateInfo && removedWindowsData.PreviousDockState == DockState.AutoHide;
			if (flag)
			{
				enmDockInRootRelation = removedWindowsData.UnpinPosition switch
				{
					DockStyle.Top => Relation.Above, 
					DockStyle.Right => Relation.ToTheRight, 
					DockStyle.Bottom => Relation.Below, 
					DockStyle.Left => Relation.ToTheLeft, 
					_ => throw new Exception("Relation cannot be: " + removedWindowsData.UnpinPosition), 
				};
			}
			AddWindow(removedWindowsData.DesiredDockState, removedWindowsData.UnpinPosition, flag, enmDockInRootRelation, removedWindowsData.Windows);
			if (removedWindowsData.PreviousDockState == DockState.AutoHide && (removedWindowsData.DesiredDockState == DockState.Dock || removedWindowsData.DesiredDockState == DockState.Float))
			{
				dockingWindow.IsSelectedTab = true;
			}
			OnWindowsStateChanged(removedWindowsData.PreviousDockState, removedWindowsData.DesiredDockState, removedWindowsData.Windows);
		}

		/// 
		/// Removes the state of the window from previous dock.
		/// </summary>
		/// <param name="objDesiredDockState">State of the obj desired dock.</param>
		/// <param name="objFirstWindow">The obj first window.</param>
		/// <param name="objWindows">The obj windows.</param>
		/// <param name="enmPosition">The enm position.</param>
		/// </returns>
		private RemovedWindowsData RemoveWindowFromPreviousDockState(DockState objDesiredDockState, DockingWindow objFirstWindow, DockingWindow[] objWindows)
		{
			RemovedWindowsData result = new RemovedWindowsData
			{
				DesiredDockState = objDesiredDockState,
				PreviousDockState = objFirstWindow.CurrentDockState,
				HasDockingStateInfo = mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.ContainsKey(objFirstWindow.WindowName),
				HasFloatingStateInfo = mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.ContainsKey(objFirstWindow.WindowName),
				UnpinPosition = DockStyle.Fill
			};
			if (objFirstWindow.CurrentDockState == DockState.AutoHide)
			{
				if (objFirstWindow.OwningZone == null)
				{
					throw new Exception("Hidden window must be contained in a Hidden zone");
				}
				result.UnpinPosition = objFirstWindow.OwningZone.DockingPosition;
				if (objDesiredDockState == DockState.Dock || objDesiredDockState == DockState.Float)
				{
					objWindows = objFirstWindow.OwningZone.ContainingHiddenPanel.RemoveAndReturnHiddenWindows(objFirstWindow).ToArray();
				}
				else
				{
					objFirstWindow.OwningZone.ContainingHiddenPanel.RemoveHiddenZone(objFirstWindow.OwningZone);
				}
			}
			else if (objFirstWindow.OwningZone != null)
			{
				result.UnpinPosition = objFirstWindow.OwningZone.DockingPosition;
				objFirstWindow.OwningZone.RemoveWindows(objWindows);
			}
			else
			{
				DockingWindow[] array = objWindows;
				foreach (DockingWindow objWindow in array)
				{
					DockedWindows.RemoveWindow(objWindow);
				}
			}
			result.Windows = objWindows;
			return result;
		}

		/// 
		/// Adds the auto hidden windows.
		/// </summary>
		/// <param name="objZoneDockingPosition">The obj zone docking position.</param>
		/// <param name="objWindows">The obj windows.</param>
		public void AddAutoHiddenWindows(DockStyle objZoneDockingPosition, params DockingWindow[] objWindows)
		{
			AddWindow(DockState.AutoHide, objZoneDockingPosition, objWindows);
		}

		/// 
		/// Adds the docked windows.
		/// </summary>
		/// <param name="objWindows">The obj windows.</param>
		public void AddDockedWindows(params DockingWindow[] objWindows)
		{
			AddWindow(DockState.Dock, DockStyle.Fill, objWindows);
		}

		/// 
		/// Adds the docked windows in root position.
		/// </summary>
		/// <param name="enmRelation">The enm relation.</param>
		/// <param name="objWindows">The obj windows.</param>
		public void AddDockedWindowsInRootPosition(Relation enmRelation, params DockingWindow[] objWindows)
		{
			AddWindow(DockState.Dock, DockStyle.Fill, blnIsDockInRootPosition: true, enmRelation, objWindows);
		}

		/// 
		/// Adds the float windows.
		/// </summary>
		/// <param name="objWindows">The obj windows.</param>
		public void AddFloatWindows(params DockingWindow[] objWindows)
		{
			AddWindow(DockState.Float, DockStyle.Fill, objWindows);
		}

		/// 
		/// Adds the tabbed windows.
		/// </summary>
		/// <param name="objWindows">The obj windows.</param>
		public void AddTabbedWindows(params DockingWindow[] objWindows)
		{
			AddWindow(DockState.Tabbed, DockStyle.Fill, objWindows);
		}

		/// 
		/// Adds the window.
		/// </summary>
		/// <param name="objDockState">State of the obj dock.</param>
		/// <param name="objZoneDockingPosition">The obj zone docking position.</param>
		/// <param name="objWindows">The obj windows.</param>
		internal void AddWindow(DockState objDockState, DockStyle objZoneDockingPosition, params DockingWindow[] objWindows)
		{
			AddWindow(objDockState, objZoneDockingPosition, blnIsDockInRootPosition: false, Relation.Above, objWindows);
		}

		/// 
		/// Adds the window.
		/// </summary>
		/// <param name="objDockState">State of the obj dock.</param>
		/// <param name="objZoneDockingPosition">The obj zone docking position.</param>
		/// <param name="blnIsDockInRootPosition">if set to true</c> [BLN is dock in root position].</param>
		/// <param name="enmDockInRootRelation">The enm dock in root relation.</param>
		/// <param name="objWindows">The obj windows.</param>
		internal void AddWindow(DockState objDockState, DockStyle objZoneDockingPosition, bool blnIsDockInRootPosition, Relation enmDockInRootRelation, params DockingWindow[] objWindows)
		{
			switch (objDockState)
			{
			case DockState.Float:
				foreach (DockingWindow dockingWindow5 in objWindows)
				{
					DockedWindows.AddWindowIfDoesntExist(dockingWindow5);
					DockedWindows.RemoveHiddenWindow(dockingWindow5);
					dockingWindow5.Manager = this;
					AddFloatWindow(dockingWindow5);
				}
				break;
			case DockState.Dock:
				if (blnIsDockInRootPosition)
				{
					foreach (DockingWindow dockingWindow in objWindows)
					{
						DockedWindows.AddWindowIfDoesntExist(dockingWindow);
						DockedWindows.RemoveHiddenWindow(dockingWindow);
						dockingWindow.Manager = this;
					}
					DockWindowsInRootPosition(enmDockInRootRelation, objWindows);
				}
				else
				{
					foreach (DockingWindow dockingWindow2 in objWindows)
					{
						DockedWindows.AddWindowIfDoesntExist(dockingWindow2);
						DockedWindows.RemoveHiddenWindow(dockingWindow2);
						dockingWindow2.Manager = this;
						AddDockedWindow(dockingWindow2);
					}
				}
				break;
			case DockState.Tabbed:
				foreach (DockingWindow dockingWindow3 in objWindows)
				{
					DockedWindows.AddWindowIfDoesntExist(dockingWindow3);
					DockedWindows.RemoveHiddenWindow(dockingWindow3);
					dockingWindow3.Manager = this;
					RootZone.AddWindow(Relation.Inside, dockingWindow3);
				}
				break;
			case DockState.AutoHide:
				foreach (DockingWindow dockingWindow4 in objWindows)
				{
					DockedWindows.AddWindowIfDoesntExist(dockingWindow4);
					DockedWindows.RemoveHiddenWindow(dockingWindow4);
					dockingWindow4.Manager = this;
				}
				AutoHideWindows(objZoneDockingPosition, objWindows);
				break;
			case DockState.Hidden:
				foreach (DockingWindow objWindow2 in objWindows)
				{
					DockedWindows.AddWindowIfDoesntExist(objWindow2);
					DockedWindows.AddHiddenWindow(objWindow2);
					SetWindowDockState(objWindow2, DockState.Hidden);
					AddWindowToCorrectZoneTypeListInManagersDescriptor(objWindow2);
				}
				break;
			case DockState.Close:
				foreach (DockingWindow objWindow in objWindows)
				{
					DockedWindows.AddHiddenWindow(objWindow);
					SetWindowDockState(objWindow, DockState.Close);
				}
				break;
			default:
				throw new NotImplementedException($"Adding windows of type '{objDockState.ToString()}' is not supported.");
			}
		}

		/// 
		/// Sets the state of the window dock.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		/// <param name="enmDockState">State of the dock.</param>
		private void SetWindowDockState(DockingWindow objWindow, DockState enmDockState)
		{
			objWindow.Manager = this;
			objWindow.CurrentDockState = enmDockState;
		}

		/// 
		/// Loads the data.
		/// </summary>
		/// <param name="objData">The obj data.</param>
		public void LoadData(byte[] objData)
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				memoryStream.Write(objData, 0, objData.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				mobjData = (DockedManagerDescriptor)binaryFormatter.Deserialize(memoryStream);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				memoryStream.Close();
			}
			IsInLoadMode = true;
			base.Controls.Clear();
			CloseAllFloatingWindows();
			InitializeDockedManager(mobjData);
			LoadWindows(mobjData.RemoveAndReturnRootWindows(), DockState.Tabbed, DockStyle.Fill);
			LoadWindows(mobjData.RemoveAndReturnDockedWindowsDescriptors(), DockState.Dock, DockStyle.Fill);
			LoadAutoHiddenWindows(mobjData.LeftHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Left);
			LoadAutoHiddenWindows(mobjData.TopHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Top);
			LoadAutoHiddenWindows(mobjData.RightHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Right);
			LoadAutoHiddenWindows(mobjData.BottomHiddenWindowsDescriptor.RemoveAndReturnWindowsDescriptorsGroupsForLoad(), DockStyle.Bottom);
			LoadHiddenWindows(mobjData.RemoveAndReturnHiddenWindowsDescriptors());
			LoadWindows(mobjData.RemoveAndReturnFloatWindowsDescriptors(), DockState.Float, DockStyle.None);
			IsInLoadMode = false;
		}

		/// 
		/// Loads the hidden windows.
		/// </summary>
		/// <param name="objHiddenWindows">The obj hidden windows.</param>
		private void LoadHiddenWindows(List<object> objHiddenWindows)
		{
			LoadWindows(objHiddenWindows, DockState.Hidden, DockStyle.Fill);
		}

		/// 
		/// Saves the data.
		/// </summary>
		/// </returns>
		public byte[] SaveData()
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(memoryStream, mobjData);
			memoryStream.Close();
			return memoryStream.ToArray();
		}

		/// 
		/// Raises the <see cref="E:ControlAdded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (e.Control is IDescriptable descriptable)
			{
				if (e.Control is DockingWindow dockingWindow)
				{
					AddWindow(DockState.Tabbed, DockStyle.Fill, dockingWindow);
				}
				descriptable.Descriptor.UpdateFrom(this, null);
				return;
			}
			throw new Exception(GetType().Name + ": Supprots only DockingWindow or DockingSplitContaineror RootZone. Added type: " + e.Control.GetType().Name);
		}

		/// 
		/// Adds a window to the docked position.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		private void AddDockedWindow(DockingWindow objWindow)
		{
			if (mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.TryGetValue(objWindow.WindowName, out var value))
			{
				List descriptorTrace = DockedManagerHelper.GetDescriptorTrace(value, blnWithCurrent: false);
				DockedManagerHelper.LoadWindowFromTrace(this, objWindow, descriptorTrace, this, DockState.Dock);
			}
			else
			{
				SwitchWindowsDockState(DockState.Tabbed, objWindow);
			}
		}

		/// 
		/// Adds the float window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		private void AddFloatWindow(DockingWindow objWindow)
		{
			List list = null;
			if (mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.TryGetValue(objWindow.WindowName, out var value))
			{
				list = DockedManagerHelper.GetDescriptorTrace(value, blnWithCurrent: false);
			}
			if (list != null)
			{
				DockedManagerHelper.LoadWindowFromTrace(this, objWindow, list, this, DockState.Float);
				return;
			}
			DockedForm dockedForm = CreateNewForm(null);
			Zone zone = new Zone(this, ZoneType.Float);
			dockedForm.Controls.Add(zone);
			zone.AddWindow(Relation.Inside, objWindow);
		}

		/// 
		/// Gets all zones as components list.
		/// </summary>
		/// </returns>
		private Component[] GetAllZonesAsComponentsList(long lngFormId)
		{
			List<object> list = new List<object><object>();
			foreach (Zone mobjAllZone in mobjAllZones)
			{
				if (mobjAllZone.OwningFormId != lngFormId)
				{
					list.Add(mobjAllZone);
				}
			}
			return list.ToArray();
		}

		/// 
		/// Initializes the componenet.
		/// </summary>
		private void InitializeComponenet(DockedManagerDescriptor objDescriptor)
		{
			mobjRootZone = new Zone(this, ZoneType.Root);
			mobjTopPanel = new DockedHiddenZonesPanel(this);
			mobjRightPanel = new DockedHiddenZonesPanel(this);
			mobjBottomPanel = new DockedHiddenZonesPanel(this);
			mobjLeftPanel = new DockedHiddenZonesPanel(this);
			mobjTopPanel.Dock = DockStyle.Top;
			mobjTopPanel.BackColor = Color.Transparent;
			mobjRightPanel.Dock = DockStyle.Right;
			mobjRightPanel.BackColor = Color.Transparent;
			mobjBottomPanel.Dock = DockStyle.Bottom;
			mobjBottomPanel.BackColor = Color.Transparent;
			mobjLeftPanel.Dock = DockStyle.Left;
			mobjLeftPanel.BackColor = Color.Transparent;
			mobjRootZone.Dock = DockStyle.Fill;
			mobjRootZone.DockingPosition = DockStyle.None;
			if (objDescriptor == null)
			{
				base.Controls.Add(mobjRootZone);
			}
			else
			{
				DockedManagerHelper.EnterRootZone(mobjRootZone, this);
			}
			base.Controls.Add(mobjRightPanel);
			base.Controls.Add(mobjLeftPanel);
			base.Controls.Add(mobjBottomPanel);
			base.Controls.Add(mobjTopPanel);
		}

		/// 
		/// Initializes the descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		private void InitializeDescriptor(DockedManagerDescriptor objDescriptor)
		{
			if (objDescriptor == null)
			{
				mobjData = new DockedManagerDescriptor(this);
			}
			else
			{
				((IDescriptable)this).Load((DockedObjectDescriptor)mobjData);
			}
		}

		/// 
		/// Initializes the docked form.
		/// </summary>
		/// <param name="objDocekdForm">The obj docekd form.</param>
		private void InitializeDockedForm(DockedForm objDocekdForm)
		{
			((IDescriptable)objDocekdForm).Descriptor.UpdateFrom(this, null);
			InitializeFormUI(objDocekdForm);
			objDocekdForm.Load += objDocekdForm_Load;
			objDocekdForm.FormClosed += objDocekdForm_FormClosed;
			objDocekdForm.Owner = base.ParentForm;
		}

		/// 
		/// Initializes the docked manager.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		private void InitializeDockedManager(DockedManagerDescriptor objDescriptor)
		{
			mobjAllZones = new List<object>();
			mobjDockedWindowsCollection = CreateCollection();
			mobjDockedWindowsCollection.Manager = this;
			InitializeDescriptor(objDescriptor);
			mobjLiveFormsIds = new List<object>();
			mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor = new Dictionary<DockedSplitContainerDescriptor, DockedSplitContainer>();
			mobjDockedFormsIdsIndexByDockedFormsUniqueId = new Dictionary<string, long>();
			InitializeComponenet(objDescriptor);
			InitializeHiddenPanelsAndRootZoneDescriptorsReferences(objDescriptor);
			InitializeVWGSizes();
		}

		/// 
		/// Creates the collection.
		/// </summary>
		/// </returns>
		protected virtual DockedWindowsCollection CreateCollection()
		{
			return new DockedWindowsCollection();
		}

		/// 
		/// Initializes the hidden panels descriptors referances.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		private void InitializeHiddenPanelsAndRootZoneDescriptorsReferences(DockedManagerDescriptor objDescriptor)
		{
			if (objDescriptor != null)
			{
				((IDescriptable)mobjTopPanel).Load((DockedObjectDescriptor)objDescriptor.TopHiddenWindowsDescriptor);
				((IDescriptable)mobjRightPanel).Load((DockedObjectDescriptor)objDescriptor.RightHiddenWindowsDescriptor);
				((IDescriptable)mobjLeftPanel).Load((DockedObjectDescriptor)objDescriptor.LeftHiddenWindowsDescriptor);
				((IDescriptable)mobjBottomPanel).Load((DockedObjectDescriptor)objDescriptor.BottomHiddenWindowsDescriptor);
			}
			else
			{
				mobjData.TopHiddenWindowsDescriptor = mobjTopPanel.DockedHiddenPanelDescriptor;
				mobjData.RightHiddenWindowsDescriptor = mobjRightPanel.DockedHiddenPanelDescriptor;
				mobjData.LeftHiddenWindowsDescriptor = mobjLeftPanel.DockedHiddenPanelDescriptor;
				mobjData.BottomHiddenWindowsDescriptor = mobjBottomPanel.DockedHiddenPanelDescriptor;
			}
			mobjData.RootZoneDescriptor = mobjRootZone.ZoneDescriptorInternal;
		}

		/// 
		/// Initializes the VWG sizes.
		/// </summary>
		private void InitializeVWGSizes()
		{
			DockedHiddenZonesPanelSkin dockedHiddenZonesPanelSkin = SkinFactory.GetSkin(mobjTopPanel) as DockedHiddenZonesPanelSkin;
			mobjTopPanel.Size = new Size(0, dockedHiddenZonesPanelSkin.PanelThickness);
			mobjBottomPanel.Size = new Size(0, dockedHiddenZonesPanelSkin.PanelThickness);
			mobjLeftPanel.Size = new Size(dockedHiddenZonesPanelSkin.PanelThickness, 0);
			mobjRightPanel.Size = new Size(dockedHiddenZonesPanelSkin.PanelThickness, 0);
		}

		/// 
		/// Loads the hidden windows.
		/// </summary>
		/// <param name="objWindowDescriptorsGroups">The obj window descriptors groups.</param>
		/// <param name="objDockStyle">The obj dock style.</param>
		private void LoadAutoHiddenWindows(List<List<object>> objWindowDescriptorsGroups, DockStyle objDockStyle)
		{
			if (objWindowDescriptorsGroups == null)
			{
				return;
			}
			foreach (List<object> objWindowDescriptorsGroup in objWindowDescriptorsGroups)
			{
				LoadWindows(objWindowDescriptorsGroup, DockState.AutoHide, objDockStyle);
			}
		}

		/// 
		/// Loads the windows.
		/// </summary>
		/// <param name="objDockedWindowDescriptors">The docked window descriptors.</param>
		/// <param name="objDockState">The dock state .</param>
		/// <param name="objDockStyle">The dock style.</param>
		private void LoadWindows(List<object> objDockedWindowDescriptors, DockState objDockState, DockStyle objDockStyle)
		{
			List<object> list = new List<object><object>();
			foreach (DockedWindowDescriptor objDockedWindowDescriptor in objDockedWindowDescriptors)
			{
				Type windowType = objDockedWindowDescriptor.WindowType;
				try
				{
					DockingWindow dockingWindow = (DockingWindow)Activator.CreateInstance(windowType);
					((IDescriptable)dockingWindow).Load((DockedObjectDescriptor)objDockedWindowDescriptor);
					OnDockingWindowLoaded(dockingWindow);
					list.Add(dockingWindow);
				}
				catch
				{
				}
			}
			if (list.Count > 0)
			{
				AddWindow(objDockState, objDockStyle, list.ToArray());
			}
		}

		/// 
		/// Handles the FormClosed event of the objDocekdForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.FormClosedEventArgs" /> instance containing the event data.</param>
		private void objDocekdForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			DockedForm dockedForm = sender as DockedForm;
			List windows = dockedForm.Windows;
			if (windows != null)
			{
				DockingWindow[] array = windows.ToArray();
				DockingWindow[] array2 = array;
				foreach (DockingWindow dockingWindow in array2)
				{
					dockingWindow.Close();
				}
			}
			mobjLiveFormsIds.Remove(dockedForm.ID);
		}

		/// 
		/// Handles the Load event of the objDocekdForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objDocekdForm_Load(object sender, EventArgs e)
		{
			DockedForm dockedForm = sender as DockedForm;
			mobjLiveFormsIds.Add(dockedForm.ID);
			dockedForm.SetDragTargets(GetAllZonesAsComponentsList(dockedForm.ID));
		}

		/// 
		/// Refreshes the drag targets.
		/// </summary>
		private void RefreshFormsDragTargets()
		{
			foreach (long mobjLiveFormsId in mobjLiveFormsIds)
			{
				GetFormFromComponentId(mobjLiveFormsId)?.SetDragTargets(GetAllZonesAsComponentsList(mobjLiveFormsId));
			}
		}

		/// 
		/// Updates the hidden panels dimentions.
		/// </summary>
		internal void UpdateHiddenPanelsDimentions()
		{
			DockedHiddenZonesPanelSkin dockedHiddenZonesPanelSkin = SkinFactory.GetSkin(mobjTopPanel) as DockedHiddenZonesPanelSkin;
			if (mobjRightPanel.Visible)
			{
				mobjTopPanel.DockPadding.Right = dockedHiddenZonesPanelSkin.PanelThickness;
				mobjBottomPanel.DockPadding.Right = dockedHiddenZonesPanelSkin.PanelThickness;
			}
			else
			{
				mobjTopPanel.DockPadding.Right = 0;
				mobjBottomPanel.DockPadding.Right = 0;
				mobjBottomPanel.DockPadding.Left = dockedHiddenZonesPanelSkin.PanelThickness;
			}
			if (mobjLeftPanel.Visible)
			{
				mobjBottomPanel.DockPadding.Left = dockedHiddenZonesPanelSkin.PanelThickness;
				mobjTopPanel.DockPadding.Left = dockedHiddenZonesPanelSkin.PanelThickness;
			}
			else
			{
				mobjBottomPanel.DockPadding.Left = 0;
				mobjTopPanel.DockPadding.Left = 0;
			}
		}

		/// 
		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			Form.Closing += Form_Closing;
		}

		/// 
		/// Handles the Closing event of the Form control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
		private void Form_Closing(object sender, CancelEventArgs e)
		{
			CloseAllFloatingWindows();
		}

		/// 
		/// Creates the new form.
		/// </summary>
		/// <param name="objFormDescriptor">The obj form descriptor.</param>
		/// </returns>
		internal DockedForm CreateNewForm(DockedFormDescriptor objFormDescriptor)
		{
			DockedForm dockedForm = new DockedForm(this);
			InitializeDockedForm(dockedForm);
			if (objFormDescriptor != null)
			{
				((IDescriptable)dockedForm).Load((DockedObjectDescriptor)objFormDescriptor);
			}
			return dockedForm;
		}

		/// 
		/// Gets the form from component id.
		/// </summary>
		/// <param name="lngFormId">The LNG form id.</param>
		/// </returns>
		internal DockedForm GetFormFromComponentId(long lngFormId)
		{
			return ((ISessionRegistry)Context).GetRegisteredComponent(lngFormId) as DockedForm;
		}

		/// 
		/// Gets the form from component id.
		/// </summary>
		/// <param name="strFormId">The STR form id.</param>
		/// </returns>
		internal DockedForm GetFormFromComponentId(string strFormId)
		{
			return GetFormFromComponentId(long.Parse(strFormId));
		}

		/// 
		/// Gets the form from descriptor.
		/// </summary>
		/// <param name="objFormDescriptor">The obj form descriptor.</param>
		/// </returns>
		internal DockedForm GetFormFromDescriptor(DockedFormDescriptor objFormDescriptor)
		{
			DockedForm dockedForm = null;
			if (objFormDescriptor != null && mobjLiveFormsIds.Contains(objFormDescriptor.OwningFormId))
			{
				dockedForm = GetFormFromComponentId(objFormDescriptor.OwningFormId);
			}
			if (dockedForm == null)
			{
				dockedForm = CreateNewForm(objFormDescriptor);
			}
			return dockedForm;
		}

		/// 
		/// Handles the window logical location changed.
		/// </summary>
		/// <param name="objWindowDescriptor">The obj window descriptor.</param>
		/// <param name="objDockedTabControl">The obj docked tab control descriptor.</param>
		/// <param name="objZone">The obj zone.</param>
		internal void HandleWindowStateChanged(DockedWindowDescriptor objWindowDescriptor, DockedTabControl objDockedTabControl)
		{
			DockedTabControlDescriptor dockedTabControlDescriptorInternal = objDockedTabControl.DockedTabControlDescriptorInternal;
			Zone owningZone = objDockedTabControl.OwningZone;
			switch (owningZone.ZoneType)
			{
			case ZoneType.Root:
				break;
			case ZoneType.Dock:
				TryRemoveFromLastDockStatePosition(mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName, objWindowDescriptor, dockedTabControlDescriptorInternal);
				break;
			case ZoneType.Float:
				TryRemoveFromLastDockStatePosition(mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName, objWindowDescriptor, dockedTabControlDescriptorInternal);
				break;
			case ZoneType.Hidden:
				break;
			}
		}

		/// 
		/// Tries the remove from last dock state position.
		/// </summary>
		/// <param name="objWindowPalceHoldersByDockState">State of the obj window palce holders by dock.</param>
		/// <param name="objWindowDescriptor">The obj window descriptor.</param>
		/// <param name="objDockedTabControlDescriptor">The obj docked tab control descriptor.</param>
		private void TryRemoveFromLastDockStatePosition(Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> objWindowPalceHoldersByDockState, DockedWindowDescriptor objWindowDescriptor, DockedTabControlDescriptor objDockedTabControlDescriptor)
		{
			if (objWindowPalceHoldersByDockState.TryGetValue(objWindowDescriptor.WindowName, out var value) && value.ParentDescriptor is DockedTabControlDescriptor dockedTabControlDescriptor && dockedTabControlDescriptor != objDockedTabControlDescriptor)
			{
				dockedTabControlDescriptor.RemoveWindow(objWindowDescriptor);
			}
		}

		/// 
		/// Notifies the zone empty.
		/// </summary>
		/// <param name="objDockedSplitContainerDescriptor">The obj docked split container descriptor.</param>
		/// <param name="intPanelSide">The int panel side.</param>
		internal void NotifyZoneEmpty(DockedSplitContainerDescriptor objDockedSplitContainerDescriptor, int intPanelSide)
		{
			if (mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.TryGetValue(objDockedSplitContainerDescriptor, out var value))
			{
				value.HardRemovePanel(intPanelSide);
				return;
			}
			throw new Exception($"mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor does not contain the given split container descriptor");
		}

		/// 
		/// Registers the place holder.
		/// </summary>
		/// <param name="enmZoneType">Type of the enm zone.</param>
		/// <param name="objWindowDescriptor">The obj window descriptor.</param>
		/// </returns>
		internal DockedWindowPlaceHolderDescriptor RegisterPlaceHolder(ZoneType enmZoneType, DockedWindowDescriptor objWindowDescriptor)
		{
			Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> dictionary = null;
			switch (enmZoneType)
			{
			case ZoneType.Dock:
				dictionary = mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName;
				break;
			case ZoneType.Float:
				dictionary = mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName;
				break;
			default:
				throw new Exception();
			case ZoneType.Root:
			case ZoneType.Hidden:
				break;
			}
			DockedWindowPlaceHolderDescriptor dockedWindowPlaceHolderDescriptor = null;
			if (dictionary != null)
			{
				dockedWindowPlaceHolderDescriptor = new DockedWindowPlaceHolderDescriptor(objWindowDescriptor, enmZoneType);
				if (!dictionary.ContainsKey(objWindowDescriptor.WindowName))
				{
					dictionary.Add(objWindowDescriptor.WindowName, dockedWindowPlaceHolderDescriptor);
				}
				else
				{
					dictionary[objWindowDescriptor.WindowName] = dockedWindowPlaceHolderDescriptor;
				}
			}
			return dockedWindowPlaceHolderDescriptor;
		}

		/// 
		/// Registers the split container.
		/// </summary>
		/// <param name="objDockedSplitContainer">The obj docked split container.</param>
		internal void RegisterSplitContainer(DockedSplitContainer objDockedSplitContainer)
		{
			DockedSplitContainerDescriptor dockedSplitContainerDescriptorInternal = objDockedSplitContainer.DockedSplitContainerDescriptorInternal;
			if (mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.ContainsKey(dockedSplitContainerDescriptorInternal))
			{
				mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor[dockedSplitContainerDescriptorInternal] = objDockedSplitContainer;
			}
			else
			{
				mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.Add(dockedSplitContainerDescriptorInternal, objDockedSplitContainer);
			}
		}

		/// 
		/// Registers the zone.
		/// </summary>
		/// <param name="objZone">The obj zone.</param>
		internal void RegisterZone(Zone objZone)
		{
			mobjAllZones.Add(objZone);
			RefreshFormsDragTargets();
		}

		/// 
		/// Unregisters the window.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		/// <param name="enmZoneType">Type of the enm zone.</param>
		internal void RemoveWindowFromCorrectZoneTypeListInManagersDescriptor(DockingWindow objWindow, ZoneType enmZoneType)
		{
			mobjData.UnregisterWindow(objWindow.DockedWindowDescriptorInternal);
		}

		/// 
		/// Adds the window to correct zone type list in managers descriptor.
		/// </summary>
		/// <param name="objWindow">The obj window.</param>
		/// <param name="enmZoneType">Type of the enm zone.</param>
		internal void AddWindowToCorrectZoneTypeListInManagersDescriptor(DockingWindow objWindow)
		{
			mobjData.RegiserWindow(objWindow.DockedWindowDescriptorInternal);
		}

		/// 
		/// Sets the window form owner.
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		/// <param name="objDockedFormDescriptor">The obj docked form descriptor.</param>
		internal void SetWindowFormMapping(DockingWindow objDockedWindow, DockedFormDescriptor objDockedFormDescriptor)
		{
			if (mobjData.FormDescriptorIndexByWindowName.ContainsKey(objDockedWindow.WindowName))
			{
				mobjData.FormDescriptorIndexByWindowName[objDockedWindow.WindowName] = objDockedFormDescriptor;
			}
			else
			{
				mobjData.FormDescriptorIndexByWindowName.Add(objDockedWindow.WindowName, objDockedFormDescriptor);
			}
		}

		/// 
		/// Unpins the windows.
		/// </summary>
		/// <param name="objWindows">The obj windows.</param>
		/// <param name="enmPanelSide">The enm panel side.</param>
		internal void AutoHideWindows(DockStyle enmPanelSide, params DockingWindow[] objWindows)
		{
			List<object> list = new List<object><object>();
			foreach (DockingWindow dockingWindow in objWindows)
			{
				Zone zone = new Zone(this, ZoneType.Hidden);
				zone.DockingPosition = enmPanelSide;
				zone.AddWindow(Relation.Inside, dockingWindow);
				list.Add(zone);
			}
			switch (enmPanelSide)
			{
			case DockStyle.Bottom:
				mobjBottomPanel.AddNewZones(list);
				break;
			case DockStyle.Left:
				mobjLeftPanel.AddNewZones(list);
				break;
			case DockStyle.Right:
				mobjRightPanel.AddNewZones(list);
				break;
			case DockStyle.Top:
				mobjTopPanel.AddNewZones(list);
				break;
			default:
				throw new Exception();
			}
		}

		/// 
		/// Unregisters the place holder.
		/// </summary>
		/// <param name="objDockedWindowPlaceHolderDescriptor">The obj docked window place holder descriptor.</param>
		internal void UnregisterPlaceHolder(DockedWindowPlaceHolderDescriptor objDockedWindowPlaceHolderDescriptor)
		{
			switch (objDockedWindowPlaceHolderDescriptor.ZoneType)
			{
			case ZoneType.Dock:
				if (!mobjData.WindowPlaceHoldersForDockedZonesIndexByWindowName.Remove(objDockedWindowPlaceHolderDescriptor.WindowName))
				{
					throw new Exception();
				}
				break;
			case ZoneType.Float:
				if (!mobjData.WindowPlaceHoldersForFloatZonesIndexByWindowName.Remove(objDockedWindowPlaceHolderDescriptor.WindowName))
				{
					throw new Exception();
				}
				break;
			case ZoneType.Hidden:
				break;
			default:
				throw new Exception();
			}
		}

		/// 
		/// Unregisters the split container.
		/// </summary>
		/// <param name="objDockedSplitContainer">The obj docked split container.</param>
		internal void UnregisterSplitContainer(DockedSplitContainer objDockedSplitContainer)
		{
			mobjDockedSplitContainersIndexByDockedSplitContainerDescriptor.Remove(objDockedSplitContainer.DockedSplitContainerDescriptorInternal);
		}

		/// 
		/// Uns the register zone.
		/// </summary>
		/// <param name="zone">The zone.</param>
		internal void UnRegisterZone(Zone zone)
		{
			mobjAllZones.Remove(zone);
			RefreshFormsDragTargets();
		}

		/// 
		/// Updates the zones UI.
		/// </summary>
		private void UpdateZonesUI()
		{
			foreach (Zone mobjAllZone in mobjAllZones)
			{
				mobjAllZone.UpdateUI();
			}
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			mobjData = objDescriptor as DockedManagerDescriptor;
			objDescriptor.UpdateSelf(this, this);
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
		/// Gets the type of the dock state according to zone.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// </returns>
		internal static DockState GetDockStateAccordingToZoneType(ZoneType objType)
		{
			return objType switch
			{
				ZoneType.Root => DockState.Tabbed, 
				ZoneType.Dock => DockState.Dock, 
				ZoneType.Float => DockState.Float, 
				ZoneType.Hidden => DockState.AutoHide, 
				_ => throw new NotSupportedException("ZoneType not supported: '" + objType.ToString() + "'"), 
			};
		}
	}
}
