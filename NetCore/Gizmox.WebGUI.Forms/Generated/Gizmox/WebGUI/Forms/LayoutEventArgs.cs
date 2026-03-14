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
	/// Provides data for the Layout event. This class cannot be inherited.
	/// </summary>
	[Serializable]
	public sealed class LayoutEventArgs : EventArgs
	{
		/// 
		///
		/// </summary>
		private readonly IComponent affectedComponent;

		/// 
		///
		/// </summary>
		private readonly string mstrAffectedProperty;

		/// 
		///
		/// </summary>
		private readonly bool mblnIsClientSource;

		/// 
		///
		/// </summary>
		private readonly bool mblnShouldUpdateSiblings;

		/// 
		///
		/// </summary>
		private readonly bool mblnShouldUpdateParent;

		/// 
		/// Gets the affected component.
		/// </summary>
		/// The affected component.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IComponent AffectedComponent => affectedComponent;

		/// 
		/// Gets the affected control.
		/// </summary>
		/// The affected control.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Control AffectedControl => affectedComponent as Control;

		/// 
		/// Gets the affected property.
		/// </summary>
		/// The affected property.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string AffectedProperty => mstrAffectedProperty;

		/// 
		/// Gets a value indicating whether this event is client source.
		/// </summary>
		/// 
		/// 	true</c> if this event is client source; otherwise, false</c>.
		/// </value>
		public bool IsClientSource => mblnIsClientSource;

		/// 
		/// Gets a value indicating whether should update siblings.
		/// </summary>
		/// 
		/// 	true</c> if should update siblings; otherwise, false</c>.
		/// </value>
		public bool ShouldUpdateSiblings => mblnShouldUpdateSiblings;

		/// 
		/// Gets a value indicating whether [should update parent].
		/// </summary>
		/// true</c> if [should update parent]; otherwise, false</c>.</value>
		public bool ShouldUpdateParent => mblnShouldUpdateParent;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> class.
		/// </summary>
		/// <param name="objAffectedComponent">The affected component.</param>
		/// <param name="strAffectedProperty">The affected property.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public LayoutEventArgs(IComponent objAffectedComponent, string strAffectedProperty)
		{
			affectedComponent = objAffectedComponent;
			mstrAffectedProperty = strAffectedProperty;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> class.
		/// </summary>
		/// <param name="objAffectedControl">The affected control.</param>
		/// <param name="strAffectedProperty">The affected property.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public LayoutEventArgs(Control objAffectedControl, string strAffectedProperty)
			: this((IComponent)objAffectedControl, strAffectedProperty)
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> class.
		/// </summary>
		/// <param name="blnIsClientSource">if set to true</c> is client source.</param>
		/// <param name="blnShouldUpdateSiblings">if set to true</c> should update siblings.</param>
		/// <param name="blnShouldUpdateParent">if set to true</c> [BLN should update parent].</param>
		public LayoutEventArgs(bool blnIsClientSource, bool blnShouldUpdateSiblings, bool blnShouldUpdateParent)
		{
			mblnIsClientSource = blnIsClientSource;
			mblnShouldUpdateSiblings = blnShouldUpdateSiblings;
			mblnShouldUpdateParent = blnShouldUpdateParent;
		}

		/// 
		/// Clones the specified should update siblings.
		/// </summary>
		/// <param name="blnShouldUpdateSiblings">if set to true</c> should update siblings.</param>
		/// <param name="blnShouldUpdateParent">if set to true</c> [BLN should update parent].</param>
		/// </returns>
		public LayoutEventArgs Clone(bool blnShouldUpdateSiblings, bool blnShouldUpdateParent)
		{
			return new LayoutEventArgs(IsClientSource, blnShouldUpdateSiblings, blnShouldUpdateParent);
		}
	}
}
