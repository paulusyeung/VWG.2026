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
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[ToolboxItem(false)]
	public class ExtendedColumnHeaders
	{
		private bool mblnExtendedColumnHeaderVisible = false;

		private ObservableCollection<object> mobjExtendedHeaderRows;

		private DataGridView mobjDataGridView;

		private ObservableCollection<object> mobjHeaderControls;

		/// 
		/// Gets or sets a value indicating whether [extended column header visible].
		/// </summary>
		/// 
		/// 	true</c> if [extended column header visible]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool ShowExtendedColumnHeader
		{
			get
			{
				return mblnExtendedColumnHeaderVisible;
			}
			set
			{
				if (mblnExtendedColumnHeaderVisible != value)
				{
					mblnExtendedColumnHeaderVisible = value;
					mobjDataGridView.Update();
				}
			}
		}

		/// 
		/// Gets or sets the extended header rows data and number.
		/// </summary>
		/// 
		/// The extended header rows.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ObservableCollection<object> Rows
		{
			get
			{
				return mobjExtendedHeaderRows;
			}
			set
			{
				mobjExtendedHeaderRows = value;
			}
		}

		/// 
		/// Gets or sets the extended column header cell panels main collection.
		/// </summary>
		/// 
		/// The extended column header cell panels.
		/// </value>
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public ObservableCollection<object> HeaderControls
		{
			get
			{
				if (mobjHeaderControls == null)
				{
					mobjHeaderControls = new ObservableCollection<object>();
					mobjHeaderControls.CollectionChanged += mobjHeaderControls_CollectionChanged;
				}
				return mobjHeaderControls;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ExtendedColumnHeaders" /> class.
		/// </summary>
		/// <param name="objDataGridView">The obj data grid view.</param>
		public ExtendedColumnHeaders(DataGridView objDataGridView)
		{
			mobjDataGridView = objDataGridView;
			InitRowsData();
		}

		/// 
		/// Inits the rows data.
		/// </summary>
		private void InitRowsData()
		{
			mobjExtendedHeaderRows = new ObservableCollection<object>();
			mobjExtendedHeaderRows.CollectionChanged += mobjExtendedHeaderRows_CollectionChanged;
		}

		/// 
		/// Handles the CollectionChanged event of the mobjExtendedHeaderRows control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
		private void mobjExtendedHeaderRows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (mobjDataGridView != null)
			{
				mobjDataGridView.Update();
			}
		}

		/// 
		/// Handles the CollectionChanged event of the mobjHeaderControls control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
		private void mobjHeaderControls_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			DataGridView parentGrid = null;
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				parentGrid = mobjDataGridView;
			}
			if (e.NewItems == null)
			{
				return;
			}
			foreach (ExtendedHeaderUserControl newItem in e.NewItems)
			{
				newItem.ParentGrid = parentGrid;
			}
		}
	}
}
