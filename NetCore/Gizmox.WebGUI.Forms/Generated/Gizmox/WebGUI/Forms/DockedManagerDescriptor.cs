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
	internal class DockedManagerDescriptor : DockedObjectDescriptor
	{
		[NonSerialized]
		private DockingManager mobjManager;

		private List<DockedWindowDescriptor> mobjRootZoneWindows;

		private DockedHiddenZonePanelDescriptor mobjBottomHiddenWindowsDescriptor;

		private DockedHiddenZonePanelDescriptor mobjLeftHiddenWindowsDescriptor;

		private DockedHiddenZonePanelDescriptor mobjRightHiddenWindowsDescriptor;

		private DockedHiddenZonePanelDescriptor mobjTopHiddenWindowsDescriptor;

		private List<DockedWindowDescriptor> mobjDockedWindowsDescriptor;

		private List<DockedWindowDescriptor> mobjFloatedWindowsDescriptor;

		private List<DockedWindowDescriptor> mobjHiddenWindowsDescriptor;

		private bool mblnAllowShowDropDownButton;

		private bool mblnAllowTabbedDocuments;

		private bool mblnAllowCloseWindows;

		private bool mblnAllowFloatinWindows;

		private bool mblnAllowShowPinButton;

		private bool mblnShowMinimizeButton;

		private bool mblnShowMaximizeButton;

		private Dictionary<DockingWindowName, DockedFormDescriptor> mobjFormDescriptorIndexByWindowName;

		private ZoneDescriptor mobjRootZoneDescriptor;

		private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjWindowPlaceHoldersForDockedZonesIndexByWindowName;

		private Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> mobjWindowPlaceHoldersForFloatZonesIndexByWindowName;

		private int mintPinAnimationSpeed;

		/// 
		/// Gets or sets the bottom hidden windows descriptor.
		/// </summary>
		/// 
		/// The bottom hidden windows descriptor.
		/// </value>
		public DockedHiddenZonePanelDescriptor BottomHiddenWindowsDescriptor
		{
			get
			{
				return mobjBottomHiddenWindowsDescriptor;
			}
			set
			{
				mobjBottomHiddenWindowsDescriptor = value;
			}
		}

		/// 
		/// Gets the docked windows descriptor.
		/// </summary>
		internal List<DockedWindowDescriptor> DockedWindowsDescriptor => mobjDockedWindowsDescriptor;

		/// 
		/// Gets or sets the floated windows descriptor.
		/// </summary>
		/// 
		/// The floated windows descriptor.
		/// </value>
		public List<DockedWindowDescriptor> FloatedWindowsDescriptor => mobjFloatedWindowsDescriptor;

		/// 
		/// Gets the hidden windows descriptor.
		/// </summary>
		internal List<DockedWindowDescriptor> HiddenWindowsDescriptor => mobjHiddenWindowsDescriptor;

		/// 
		/// Gets or sets the name of the form descriptor index by window.
		/// </summary>
		/// 
		/// The name of the form descriptor index by window.
		/// </value>
		internal Dictionary<DockingWindowName, DockedFormDescriptor> FormDescriptorIndexByWindowName
		{
			get
			{
				return mobjFormDescriptorIndexByWindowName;
			}
			set
			{
				mobjFormDescriptorIndexByWindowName = value;
			}
		}

		/// 
		/// Gets or sets the left hidden windows descriptor.
		/// </summary>
		/// 
		/// The left hidden windows descriptor.
		/// </value>
		public DockedHiddenZonePanelDescriptor LeftHiddenWindowsDescriptor
		{
			get
			{
				return mobjLeftHiddenWindowsDescriptor;
			}
			set
			{
				mobjLeftHiddenWindowsDescriptor = value;
			}
		}

		/// 
		/// Gets the manager.
		/// </summary>
		public override DockingManager Manager => mobjManager;

		/// 
		/// Gets or sets the right hidden windows descriptor.
		/// </summary>
		/// 
		/// The right hidden windows descriptor.
		/// </value>
		public DockedHiddenZonePanelDescriptor RightHiddenWindowsDescriptor
		{
			get
			{
				return mobjRightHiddenWindowsDescriptor;
			}
			set
			{
				mobjRightHiddenWindowsDescriptor = value;
			}
		}

		/// 
		/// Gets or sets the root zone descriptor.
		/// </summary>
		/// 
		/// The root zone descriptor.
		/// </value>
		internal ZoneDescriptor RootZoneDescriptor
		{
			get
			{
				return mobjRootZoneDescriptor;
			}
			set
			{
				mobjRootZoneDescriptor = value;
			}
		}

		/// 
		/// Gets or sets the top hidden windows descriptor.
		/// </summary>
		/// 
		/// The top hidden windows descriptor.
		/// </value>
		public DockedHiddenZonePanelDescriptor TopHiddenWindowsDescriptor
		{
			get
			{
				return mobjTopHiddenWindowsDescriptor;
			}
			set
			{
				mobjTopHiddenWindowsDescriptor = value;
			}
		}

		/// 
		/// Gets or sets the name of the window place holders for docked zones index by window.
		/// </summary>
		/// 
		/// The name of the window place holders for docked zones index by window.
		/// </value>
		internal Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> WindowPlaceHoldersForDockedZonesIndexByWindowName
		{
			get
			{
				return mobjWindowPlaceHoldersForDockedZonesIndexByWindowName;
			}
			set
			{
				mobjWindowPlaceHoldersForDockedZonesIndexByWindowName = value;
			}
		}

		/// 
		/// Gets or sets the name of the window place holders for float zones index by window.
		/// </summary>
		/// 
		/// The name of the window place holders for float zones index by window.
		/// </value>
		internal Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor> WindowPlaceHoldersForFloatZonesIndexByWindowName
		{
			get
			{
				return mobjWindowPlaceHoldersForFloatZonesIndexByWindowName;
			}
			set
			{
				mobjWindowPlaceHoldersForFloatZonesIndexByWindowName = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow floating windows].
		/// </summary>
		/// 
		/// 	true</c> if [allow allow floating windows]; otherwise, false</c>.
		/// </value>
		internal bool AllowFloatingWindows
		{
			get
			{
				return mblnAllowFloatinWindows;
			}
			set
			{
				mblnAllowFloatinWindows = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow close windows].
		/// </summary>
		/// 
		/// 	true</c> if [allow close windows]; otherwise, false</c>.
		/// </value>
		internal bool AllowCloseWindows
		{
			get
			{
				return mblnAllowCloseWindows;
			}
			set
			{
				mblnAllowCloseWindows = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow tabbed documents].
		/// </summary>
		/// 
		/// 	true</c> if [allow tabbed documents]; otherwise, false</c>.
		/// </value>
		internal bool AllowTabbedDocuments
		{
			get
			{
				return mblnAllowTabbedDocuments;
			}
			set
			{
				mblnAllowTabbedDocuments = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow show pin button].
		/// </summary>
		/// 
		///   true</c> if [allow show pin button]; otherwise, false</c>.
		/// </value>
		internal bool ShowPinButton
		{
			get
			{
				return mblnAllowShowPinButton;
			}
			set
			{
				mblnAllowShowPinButton = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow show drop down button].
		/// </summary>
		/// 
		/// 	true</c> if [allow show drop down button]; otherwise, false</c>.
		/// </value>
		internal bool ShowDropDownButton
		{
			get
			{
				return mblnAllowShowDropDownButton;
			}
			set
			{
				mblnAllowShowDropDownButton = value;
			}
		}

		/// 
		/// Gets or sets the pin animation speed.
		/// </summary>
		/// 
		/// The pin animation speed.
		/// </value>
		internal int PinAnimationSpeed
		{
			get
			{
				return mintPinAnimationSpeed;
			}
			set
			{
				mintPinAnimationSpeed = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show minimize button].
		/// </summary>
		/// 
		///   true</c> if [show minimize button]; otherwise, false</c>.
		/// </value>
		internal bool ShowMinimizeButton
		{
			get
			{
				return mblnShowMinimizeButton;
			}
			set
			{
				mblnShowMinimizeButton = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show maximize button].
		/// </summary>
		/// 
		///   true</c> if [show maximize button]; otherwise, false</c>.
		/// </value>
		internal bool ShowMaximizeButton
		{
			get
			{
				return mblnShowMaximizeButton;
			}
			set
			{
				mblnShowMaximizeButton = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedManagerDescriptor" /> class.
		/// </summary>
		internal DockedManagerDescriptor(DockingManager objManager)
		{
			mobjManager = objManager;
			mobjRootZoneWindows = new List<DockedWindowDescriptor>();
			mobjFloatedWindowsDescriptor = new List<DockedWindowDescriptor>();
			mobjDockedWindowsDescriptor = new List<DockedWindowDescriptor>();
			mobjHiddenWindowsDescriptor = new List<DockedWindowDescriptor>();
			mobjFormDescriptorIndexByWindowName = new Dictionary<DockingWindowName, DockedFormDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
			mobjWindowPlaceHoldersForDockedZonesIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
			mobjWindowPlaceHoldersForFloatZonesIndexByWindowName = new Dictionary<DockingWindowName, DockedWindowPlaceHolderDescriptor>(DockingWindowName.DockedWindowNameEqulityComparer);
			mobjTopHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
			mobjRightHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
			mobjBottomHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
			mobjLeftHiddenWindowsDescriptor = new DockedHiddenZonePanelDescriptor();
			mblnAllowShowDropDownButton = true;
			mblnAllowFloatinWindows = true;
			mblnAllowCloseWindows = true;
			mblnAllowShowPinButton = true;
			mblnShowMinimizeButton = true;
			mblnShowMaximizeButton = true;
			mintPinAnimationSpeed = (SkinFactory.GetSkin(objManager.HiddenPanel) as DockedHiddenZonesPanelSkin).HiddenZoneItemExpantionAnimationDuration;
		}

		/// 
		/// Regisers the window.
		/// </summary>
		/// <param name="objWindowDescriptor">The docked window descriptor.</param>
		/// <param name="enmZoneType">Type of the enm zone.</param>
		internal void RegiserWindow(DockedWindowDescriptor objWindowDescriptor)
		{
			switch (objWindowDescriptor.CurrentDockState)
			{
			case DockState.Float:
				mobjFloatedWindowsDescriptor.Add(objWindowDescriptor);
				break;
			case DockState.Dock:
				mobjDockedWindowsDescriptor.Add(objWindowDescriptor);
				break;
			case DockState.Tabbed:
				mobjRootZoneWindows.Add(objWindowDescriptor);
				break;
			case DockState.Hidden:
				mobjHiddenWindowsDescriptor.Add(objWindowDescriptor);
				break;
			case DockState.AutoHide:
			case DockState.Close:
				break;
			default:
				throw new Exception();
			}
		}

		/// 
		/// Removes the and return docked windows descriptors.
		/// </summary>
		/// </returns>
		internal List<DockedWindowDescriptor> RemoveAndReturnDockedWindowsDescriptors()
		{
			List<DockedWindowDescriptor> result = mobjDockedWindowsDescriptor;
			mobjDockedWindowsDescriptor = new List<DockedWindowDescriptor>();
			return result;
		}

		/// 
		/// Removes the and return docked windows descriptors.
		/// </summary>
		/// </returns>
		internal List<DockedWindowDescriptor> RemoveAndReturnRootWindows()
		{
			List<DockedWindowDescriptor> result = mobjRootZoneWindows;
			mobjRootZoneWindows = new List<DockedWindowDescriptor>();
			return result;
		}

		/// 
		/// Removes the and return float windows descriptors.
		/// </summary>
		/// </returns>
		internal List<DockedWindowDescriptor> RemoveAndReturnFloatWindowsDescriptors()
		{
			List<DockedWindowDescriptor> result = mobjFloatedWindowsDescriptor;
			mobjFloatedWindowsDescriptor = new List<DockedWindowDescriptor>();
			return result;
		}

		/// 
		/// Removes the and return hidden windows descriptors.
		/// </summary>
		/// </returns>
		internal List<DockedWindowDescriptor> RemoveAndReturnHiddenWindowsDescriptors()
		{
			List<DockedWindowDescriptor> result = mobjHiddenWindowsDescriptor;
			mobjHiddenWindowsDescriptor = new List<DockedWindowDescriptor>();
			return result;
		}

		/// 
		/// Unregisters the window.
		/// </summary>
		/// <param name="objWindowDescriptor">The docked window descriptor.</param>
		/// <param name="enmZoneType">Type of the enm zone.</param>
		internal void UnregisterWindow(DockedWindowDescriptor objWindowDescriptor)
		{
			switch (objWindowDescriptor.CurrentDockState)
			{
			case DockState.Float:
				mobjFloatedWindowsDescriptor.Remove(objWindowDescriptor);
				break;
			case DockState.Dock:
				mobjDockedWindowsDescriptor.Remove(objWindowDescriptor);
				break;
			case DockState.Tabbed:
				mobjRootZoneWindows.Remove(objWindowDescriptor);
				break;
			case DockState.Hidden:
				mobjHiddenWindowsDescriptor.Remove(objWindowDescriptor);
				break;
			case DockState.AutoHide:
			case DockState.Close:
				break;
			default:
				throw new Exception();
			}
		}

		/// 
		/// Updates the self.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		internal override void UpdateSelf(Control objControl, DockingManager objDockedManager)
		{
			mobjManager = objDockedManager;
		}
	}
}
