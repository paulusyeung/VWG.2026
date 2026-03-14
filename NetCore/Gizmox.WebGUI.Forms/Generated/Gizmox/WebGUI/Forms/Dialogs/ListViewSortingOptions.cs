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

namespace Gizmox.WebGUI.Forms.Dialogs
{
/// 
	///
	/// </summary>
	[Serializable]
	public class ListViewSortingOptions : Form
	{
		private Label mobjLabelHelp;

		private Panel mobjPanelButtons;

		private Button mobjButtonCancel;

		private Button mobjButtonOK;

		private Panel mobjPanelSortingDirection;

		private ItemChooser mobjItemChooser;

		private RadioButton mobjRadioAscending;

		private RadioButton mobjRadioDecsending;

		private ListView mobjListView;

		private ColumnHeaderSortingData mobjSortedColumns;

		private Hashtable mobjChecked;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Dialogs.ListViewSortingOptions" /> instance.
		/// </summary>
		public ListViewSortingOptions(ListView objListView)
		{
			mobjListView = objListView;
			InitializeComponent();
			mobjSortedColumns = new ColumnHeaderSortingData(mobjListView);
			mobjItemChooser.Items = mobjSortedColumns.SortedColumns;
			mobjItemChooser.Checked = mobjSortedColumns.SortingColumns;
			mobjPanelSortingDirection.Enabled = false;
			mobjChecked = new Hashtable();
			mobjItemChooser.ItemSelected += mobjItemChooser_ItemSelected;
			mobjRadioAscending.CheckedChanged += mobjRadioAscending_CheckedChanged;
			mobjRadioDecsending.CheckedChanged += mobjRadioDecsending_CheckedChanged;
			mobjButtonCancel.Click += mobjButtonCancel_Click;
			mobjButtonOK.Click += mobjButtonOK_Click;
			mobjItemChooser.CheckLabel = WGLabels.Show;
			mobjItemChooser.UncheckLabel = WGLabels.Hide;
			mobjButtonOK.Text = WGLabels.Ok;
			mobjButtonCancel.Text = WGLabels.Cancel;
			mobjButtonOK.Text = WGLabels.Ok;
			mobjButtonCancel.Text = WGLabels.Cancel;
			Text = SR.GetString(Context.CurrentUICulture, "WGLablesSortingOptions");
			mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesSortingInstructions");
			mobjRadioAscending.Text = WGLabels.Ascending;
			mobjRadioDecsending.Text = WGLabels.Decsending;
			if (mobjItemChooser.SelectedItem != null)
			{
				mobjItemChooser_ItemSelected(mobjItemChooser, EventArgs.Empty);
			}
		}

		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjLabelHelp = new Label();
			mobjPanelButtons = new Panel();
			mobjButtonOK = new Button();
			mobjButtonCancel = new Button();
			mobjPanelSortingDirection = new Panel();
			mobjRadioDecsending = new RadioButton();
			mobjRadioAscending = new RadioButton();
			mobjItemChooser = new ItemChooser();
			mobjPanelButtons.SuspendLayout();
			mobjPanelSortingDirection.SuspendLayout();
			SuspendLayout();
			mobjLabelHelp.Dock = DockStyle.Top;
			mobjLabelHelp.Location = new Point(15, 15);
			mobjLabelHelp.Name = "mobjLabelHelp";
			mobjLabelHelp.Size = new Size(312, 49);
			mobjLabelHelp.TabIndex = 0;
			mobjLabelHelp.Text = "Check the columns that you would like to sort by. Use the Move  Up and Move Down buttons to reorder sorting.";
			mobjPanelButtons.Controls.Add(mobjButtonOK);
			mobjPanelButtons.Controls.Add(mobjButtonCancel);
			mobjPanelButtons.Dock = DockStyle.Bottom;
			mobjPanelButtons.Location = new Point(15, 300);
			mobjPanelButtons.Name = "mobjPanelButtons";
			mobjPanelButtons.Size = new Size(312, 35);
			mobjPanelButtons.TabIndex = 1;
			mobjButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			mobjButtonOK.Location = new Point(156, 11);
			mobjButtonOK.Name = "mobjButtonOK";
			mobjButtonOK.TabIndex = 1;
			mobjButtonOK.Text = "OK";
			mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			mobjButtonCancel.Location = new Point(236, 11);
			mobjButtonCancel.Name = "mobjButtonCancel";
			mobjButtonCancel.TabIndex = 0;
			mobjButtonCancel.Text = "Cancel";
			mobjPanelSortingDirection.Controls.Add(mobjRadioDecsending);
			mobjPanelSortingDirection.Controls.Add(mobjRadioAscending);
			mobjPanelSortingDirection.Dock = DockStyle.Bottom;
			mobjPanelSortingDirection.Location = new Point(15, 255);
			mobjPanelSortingDirection.Name = "mobjPanelSortingDirection";
			mobjPanelSortingDirection.Size = new Size(312, 45);
			mobjPanelSortingDirection.TabIndex = 2;
			mobjRadioDecsending.Location = new Point(104, 10);
			mobjRadioDecsending.Name = "mobjRadioDecsending";
			mobjRadioDecsending.Size = new Size(104, 24);
			mobjRadioDecsending.TabIndex = 1;
			mobjRadioDecsending.Text = "Decsending";
			mobjRadioAscending.Location = new Point(0, 10);
			mobjRadioAscending.Name = "mobjRadioAscending";
			mobjRadioAscending.Size = new Size(104, 24);
			mobjRadioAscending.TabIndex = 0;
			mobjRadioAscending.Text = "Acsending";
			mobjItemChooser.Dock = DockStyle.Fill;
			mobjItemChooser.Location = new Point(15, 64);
			mobjItemChooser.Name = "mobjItemChooser";
			mobjItemChooser.Size = new Size(320, 191);
			mobjItemChooser.TabIndex = 3;
			base.ClientSize = new Size(342, 350);
			base.Controls.Add(mobjItemChooser);
			base.Controls.Add(mobjPanelSortingDirection);
			base.Controls.Add(mobjPanelButtons);
			base.Controls.Add(mobjLabelHelp);
			base.DockPadding.All = 15;
			base.Name = "ListViewSortingOptions";
			Text = "Sorting Options";
			mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
			mobjPanelSortingDirection.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjItemChooser_ItemSelected(object sender, EventArgs e)
		{
			if (mobjItemChooser.SelectedItem is ColumnHeader columnHeader)
			{
				mobjPanelSortingDirection.Enabled = true;
				SortOrder sortOrder = SortOrder.None;
				sortOrder = ((mobjChecked[columnHeader] != null) ? ((SortOrder)mobjChecked[columnHeader]) : columnHeader.SortOrder);
				if (sortOrder == SortOrder.None)
				{
					sortOrder = SortOrder.Ascending;
				}
				mobjRadioAscending.Checked = sortOrder == SortOrder.Ascending;
				mobjRadioDecsending.Checked = sortOrder == SortOrder.Descending;
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjRadioAscending_CheckedChanged(object sender, EventArgs e)
		{
			if (mobjItemChooser.SelectedItem is ColumnHeader key && mobjRadioAscending.Checked)
			{
				mobjChecked[key] = SortOrder.Ascending;
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjRadioDecsending_CheckedChanged(object sender, EventArgs e)
		{
			if (mobjItemChooser.SelectedItem is ColumnHeader key && mobjRadioDecsending.Checked)
			{
				mobjChecked[key] = SortOrder.Descending;
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonOK_Click(object sender, EventArgs e)
		{
			foreach (ColumnHeader item in mobjItemChooser.Items)
			{
				item.SortPosition = 1000;
			}
			int num = 0;
			foreach (ColumnHeader item2 in mobjItemChooser.Checked)
			{
				if (mobjChecked[item2] != null)
				{
					item2.SortOrder = (SortOrder)mobjChecked[item2];
				}
				if (item2.SortOrder == SortOrder.None)
				{
					item2.SortOrder = SortOrder.Ascending;
				}
				item2.SortPosition = num;
				num++;
			}
			foreach (ColumnHeader item3 in mobjItemChooser.Items)
			{
				if (item3.SortPosition == 1000)
				{
					item3.SortOrder = SortOrder.None;
					item3.SortPosition = num;
				}
				num++;
			}
			Close();
			mobjListView.Sort();
		}
	}
}
