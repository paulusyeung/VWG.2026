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
	/// Describes a Docked object inside the Docke Manager
	/// </summary>
	[Serializable]
	public abstract class DockedObjectDescriptor
	{
		private DockedObjectDescriptor mobjParentDescriptor;

		/// 
		/// Gets the container.
		/// </summary>
		internal DockedObjectDescriptor ParentDescriptor => mobjParentDescriptor;

		/// 
		/// Gets the manager.
		/// </summary>
		public virtual DockingManager Manager
		{
			get
			{
				if (ParentDescriptor != null)
				{
					return ParentDescriptor.Manager;
				}
				return null;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is in load mode.
		/// </summary>
		/// 
		/// 	true</c> if this instance is in load mode; otherwise, false</c>.
		/// </value>
		protected internal bool IsInLoadMode => Manager != null && Manager.IsInLoadMode;

		/// 
		/// Determines whether this instance [can update from] the specified obj type.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// 
		///   true</c> if this instance [can update from] the specified obj type; otherwise, false</c>.
		/// </returns>
		internal virtual bool CanUpdateFrom(Type objType)
		{
			return false;
		}

		/// 
		/// Clones the without references.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// </returns>
		internal virtual T CloneWithoutReferences() where T : DockedObjectDescriptor
		{
			return null;
		}

		/// 
		/// Sets the container.
		/// </summary>
		/// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
		internal void SetContainer(DockedObjectDescriptor objDockedObjectDescriptor)
		{
			mobjParentDescriptor = objDockedObjectDescriptor;
		}

		/// 
		/// Updates from.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objExtraData">The obj extra data.</param>
		internal void UpdateFrom(Control objControl, object objExtraData)
		{
			if (!CanUpdateFrom(objControl.GetType()))
			{
				return;
			}
			if (objControl is DockedTabControl)
			{
				UpdateFromTabControl(objControl as DockedTabControl, (bool)objExtraData);
			}
			else if (objControl is DockingManager)
			{
				UpdateFromDockedManager(objControl as DockingManager);
			}
			else if (objControl is DockedSplitContainer)
			{
				UpdateFromDockedSplitContainer(objControl as DockedSplitContainer, (int)objExtraData);
			}
			else if (objControl is Zone)
			{
				UpdateFromZone(objControl as Zone);
			}
			else if (objControl is DockingWindow)
			{
				UpdateFromDockedWindow(objControl as DockingWindow);
			}
			else if (objControl is DockedForm)
			{
				UpdateFromDockedForm(objControl as DockedForm);
			}
			else
			{
				if (!(objControl is DockedHiddenZonesPanel))
				{
					throw new Exception();
				}
				UpdateFromDockedHiddenZonesPanel(objControl as DockedHiddenZonesPanel);
			}
			if (objControl is IDescriptable)
			{
				SetContainer((objControl as IDescriptable).Descriptor);
			}
			else
			{
				mobjParentDescriptor = null;
			}
		}

		/// 
		/// Updates from docked form.
		/// </summary>
		/// <param name="dockedForm">The docked form.</param>
		internal virtual void UpdateFromDockedForm(DockedForm dockedForm)
		{
		}

		/// 
		/// Updates from docked hidden zones panel.
		/// </summary>
		/// <param name="dockedHiddenZonesPanel">The docked hidden zones panel.</param>
		internal virtual void UpdateFromDockedHiddenZonesPanel(DockedHiddenZonesPanel dockedHiddenZonesPanel)
		{
		}

		/// 
		/// Updates from docked manager.
		/// </summary>
		/// <param name="objDockedManager">The obj docked manager.</param>
		internal virtual void UpdateFromDockedManager(DockingManager objDockedManager)
		{
		}

		/// 
		/// Updates from docked split container.
		/// </summary>
		/// <param name="objDockedSplitContainer">The obj docked split container.</param>
		/// <param name="intPanelSide">The int panel side.</param>
		internal virtual void UpdateFromDockedSplitContainer(DockedSplitContainer objDockedSplitContainer, int intPanelSide)
		{
		}

		/// 
		/// Updates from docked window.
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		internal virtual void UpdateFromDockedWindow(DockingWindow objDockedWindow)
		{
		}

		/// 
		/// Updates from tab control.
		/// </summary>
		/// <param name="objDockedTabControl">The obj docked tab control.</param>
		/// <param name="blnPreventExtraction">if set to true</c> [BLN prevent extraction].</param>
		internal virtual void UpdateFromTabControl(DockedTabControl objDockedTabControl, bool blnPreventExtraction)
		{
		}

		/// 
		/// Updates from zone.
		/// </summary>
		/// <param name="zone">The zone.</param>
		internal virtual void UpdateFromZone(Zone zone)
		{
		}

		/// 
		/// Updates the self.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		internal virtual void UpdateSelf(Control objControl, DockingManager objManager)
		{
		}
	}
}
