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
	public class DataGridViewGroupingHeader : UserControl
	{
		private string mstrDataPropertyName = string.Empty;

		private string mstrCurrentValue = string.Empty;

		private BindingSource mobjRowBindingSource = null;

		private DataGridViewRow mobjOwnerRow = null;

		/// 
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private Label mobjHeaderLabel;

		internal event GroupHeaderFormattingEventHandler GroupHeaderFormatting;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewGroupingHeader" /> class.
		/// </summary>
		public DataGridViewGroupingHeader()
		{
			InitializeComponent();
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewGroupingHeader" /> class.
		/// </summary>
		/// <param name="strDataPropertyName">Name of the STR data property.</param>
		/// <param name="strCurrentValue">The STR current value.</param>
		/// <param name="objRowBindingSource">The obj row binding source.</param>
		public DataGridViewGroupingHeader(string strDataPropertyName, string strCurrentValue, BindingSource objRowBindingSource, DataGridViewRow objRow)
			: this()
		{
			mobjOwnerRow = objRow;
			InitializeHeader(strDataPropertyName, strCurrentValue, objRowBindingSource);
		}

		/// 
		/// Initializes the header.
		/// </summary>
		/// <param name="strDataPropertyName">Name of the STR data property.</param>
		/// <param name="strCurrentValue">The STR current value.</param>
		/// <param name="objRowBindingSource">The obj row binding source.</param>
		private void InitializeHeader(string strDataPropertyName, string strCurrentValue, BindingSource objRowBindingSource)
		{
			mstrDataPropertyName = strDataPropertyName;
			mstrCurrentValue = strCurrentValue;
			mobjRowBindingSource = objRowBindingSource;
			UpdateHeader();
			if (mobjRowBindingSource != null)
			{
				mobjRowBindingSource.ListChanged += OnListChanged;
			}
		}

		/// 
		/// Handles the ListChanged event of the objRowBindingSource control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.ComponentModel.ListChangedEventArgs" /> instance containing the event data.</param>
		private void OnListChanged(object sender, ListChangedEventArgs e)
		{
			UpdateHeader();
		}

		/// 
		/// Updates the header.
		/// </summary>
		private void UpdateHeader()
		{
			int num = ((mobjRowBindingSource != null) ? mobjRowBindingSource.Count : (-1));
			if (mobjOwnerRow.DataGridView == null)
			{
				return;
			}
			if (num == 0)
			{
				mobjOwnerRow.DataGridView.CurrentCell = null;
				mobjOwnerRow.SetVisibleInternal(blnValue: false);
				return;
			}
			GroupHeaderFormattingEventArgs e = mobjOwnerRow.DataGridView.OnGroupHeaderFormatting(mobjHeaderLabel, mstrDataPropertyName, mstrCurrentValue, num, mobjOwnerRow);
			if (!e.FormattingApplied)
			{
				FormatLabelByDefault(mobjHeaderLabel, mstrDataPropertyName, mstrCurrentValue, num);
			}
		}

		/// 
		/// Formats the label by default.
		/// </summary>
		/// <param name="objHeaderLabel">The obj header label.</param>
		/// <param name="strDataPropertyName">Name of the STR data property.</param>
		/// <param name="strValue">The STR value.</param>
		/// <param name="intCount">The int count.</param>
		private void FormatLabelByDefault(Label objHeaderLabel, string strDataPropertyName, string strValue, int intCount)
		{
			objHeaderLabel.BackColor = Color.Gray;
			objHeaderLabel.BorderStyle = BorderStyle.Fixed3D;
			objHeaderLabel.Dock = DockStyle.Fill;
			objHeaderLabel.Location = new Point(0, 0);
			objHeaderLabel.TabIndex = 0;
			if (intCount >= 0)
			{
				objHeaderLabel.Text = string.Format("{0}: {1} ({2} item{3})", mstrDataPropertyName, (!string.IsNullOrEmpty(mstrCurrentValue)) ? ("'" + mstrCurrentValue + "'") : "NULL", intCount.ToString(), (intCount > 1) ? "s" : string.Empty);
			}
			else
			{
				objHeaderLabel.Text = string.Format("{0}: {1}", mstrDataPropertyName, (!string.IsNullOrEmpty(mstrCurrentValue)) ? ("'" + mstrCurrentValue + "'") : "NULL");
			}
		}

		/// 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjHeaderLabel = new Label();
			SuspendLayout();
			mobjHeaderLabel.BackColor = Color.Gray;
			mobjHeaderLabel.BorderStyle = BorderStyle.Fixed3D;
			mobjHeaderLabel.Dock = DockStyle.Fill;
			mobjHeaderLabel.Location = new Point(0, 0);
			mobjHeaderLabel.Name = "mobjHeaderLabel";
			mobjHeaderLabel.Size = new Size(296, 40);
			mobjHeaderLabel.TabIndex = 0;
			base.Controls.Add(mobjHeaderLabel);
			base.Size = new Size(296, 40);
			Text = "DataGridViewGroupingHeader";
			ResumeLayout(blnPerformLayout: false);
		}
	}
}
