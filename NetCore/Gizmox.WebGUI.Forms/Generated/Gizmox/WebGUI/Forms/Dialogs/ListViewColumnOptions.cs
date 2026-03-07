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
	/// The columens options dialog
	/// </summary>
	[Serializable]
	public class ListViewColumnOptions : Form
	{
		private Label mobjLabelHelp;

		private Button mobjButtonCancel;

		private Button mobjButtonOK;

		private Panel mobjPanelButtons;

		private Panel mobjPanelColumnWidth;

		private Button mobjButtonMoveUp;

		private Button mobjButtonMoveDown;

		private Button mobjButtonShow;

		private Button mobjButtonHide;

		private Label mobjLabelWidth1;

		private TextBox mobjTextColumnWidth;

		private Label mobjLabelWidth2;

		private ItemChooser mobjItemChooser;

		private ListView.ColumnHeaderCollection mobjColumns;

		private ListView mobjListView;

		private Hashtable mobjColumnWidth;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Dialogs.ListViewColumnOptions" /> instance.
		/// </summary>
		/// <param name="objListView">List<object> view.</param>
		public ListViewColumnOptions(ListView objListView)
		{
			mobjListView = objListView;
			InitializeComponent();
			mobjListView = objListView;
			mobjColumns = objListView.Columns;
			mobjColumnWidth = new Hashtable();
			mobjItemChooser.Items = mobjColumns.SortedColumns;
			mobjItemChooser.Checked = mobjColumns.VisibleColumns;
			try
			{
				mobjTextColumnWidth.Text = GetColumnWidth((ColumnHeader)mobjItemChooser.SelectedItem);
			}
			catch (Exception)
			{
			}
			mobjItemChooser.ItemSelected += mobjItemChooser_ItemSelected;
			mobjButtonCancel.Click += mobjButtonCancel_Click;
			mobjButtonOK.Click += mobjButtonOK_Click;
			mobjItemChooser.CheckLabel = WGLabels.Show;
			mobjItemChooser.UncheckLabel = WGLabels.Hide;
			mobjItemChooser.MoveDownLabel = WGLabels.MoveDown;
			mobjItemChooser.MoveUpLabel = WGLabels.MoveUp;
			mobjButtonOK.Text = WGLabels.Ok;
			mobjButtonCancel.Text = WGLabels.Cancel;
			Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnOptions");
			mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsInstructions");
			mobjLabelWidth1.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsStringA");
			mobjLabelWidth2.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsStringB");
			mobjTextColumnWidth.TextChanged += mobjTextColumnWidth_TextChanged;
		}

		/// 
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			mobjLabelHelp = new Label();
			mobjPanelButtons = new Panel();
			mobjButtonCancel = new Button();
			mobjButtonOK = new Button();
			mobjPanelColumnWidth = new Panel();
			mobjLabelWidth1 = new Label();
			mobjTextColumnWidth = new TextBox();
			mobjLabelWidth2 = new Label();
			mobjItemChooser = new ItemChooser();
			mobjPanelColumnWidth.SuspendLayout();
			mobjPanelButtons.SuspendLayout();
			SuspendLayout();
			mobjPanelButtons.Controls.Add(mobjButtonOK);
			mobjPanelButtons.Controls.Add(mobjButtonCancel);
			mobjPanelButtons.Dock = DockStyle.Bottom;
			mobjPanelButtons.Location = new Point(15, 300);
			mobjPanelButtons.Name = "mobjPanelButtons";
			mobjPanelButtons.Size = new Size(312, 35);
			mobjPanelButtons.TabIndex = 1;
			mobjLabelHelp.Dock = DockStyle.Top;
			mobjLabelHelp.Location = new Point(15, 15);
			mobjLabelHelp.Name = "mobjLabelHelp";
			mobjLabelHelp.Size = new Size(312, 49);
			mobjLabelHelp.TabIndex = 0;
			mobjLabelHelp.Text = "Check the columns that you would like to make visible. Use the Move  Up and Move Down buttons to reorder the columns.";
			mobjButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			mobjButtonCancel.Location = new Point(236, 11);
			mobjButtonCancel.Name = "mobjButtonCancel";
			mobjButtonCancel.TabIndex = 0;
			mobjButtonCancel.Text = "Cancel";
			mobjButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			mobjButtonOK.Location = new Point(156, 11);
			mobjButtonOK.Name = "mobjButtonOK";
			mobjButtonOK.TabIndex = 1;
			mobjButtonOK.Text = "OK";
			mobjPanelColumnWidth.Controls.Add(mobjLabelWidth2);
			mobjPanelColumnWidth.Controls.Add(mobjTextColumnWidth);
			mobjPanelColumnWidth.Controls.Add(mobjLabelWidth1);
			mobjPanelColumnWidth.Dock = DockStyle.Bottom;
			mobjPanelColumnWidth.Location = new Point(15, 255);
			mobjPanelColumnWidth.Name = "mobjPanelColumnWidth";
			mobjPanelColumnWidth.Size = new Size(312, 45);
			mobjPanelColumnWidth.TabIndex = 2;
			mobjItemChooser.Dock = DockStyle.Fill;
			mobjItemChooser.Location = new Point(15, 64);
			mobjItemChooser.Name = "mobjItemChooser";
			mobjItemChooser.Size = new Size(320, 191);
			mobjItemChooser.TabIndex = 3;
			mobjLabelWidth1.Location = new Point(8, 16);
			mobjLabelWidth1.Name = "mobjLabelWidth1";
			mobjLabelWidth1.Size = new Size(168, 16);
			mobjLabelWidth1.TabIndex = 0;
			mobjLabelWidth1.Text = "The selected column should be";
			mobjTextColumnWidth.Location = new Point(166, 13);
			mobjTextColumnWidth.Name = "mobjTextColumnWidth";
			mobjTextColumnWidth.Size = new Size(32, 20);
			mobjTextColumnWidth.TabIndex = 1;
			mobjTextColumnWidth.Text = "";
			mobjLabelWidth2.Location = new Point(208, 16);
			mobjLabelWidth2.Name = "mobjLabelWidth2";
			mobjLabelWidth2.Size = new Size(100, 16);
			mobjLabelWidth2.TabIndex = 2;
			mobjLabelWidth2.Text = "pixels wide.";
			base.ClientSize = new Size(342, 350);
			base.Controls.Add(mobjItemChooser);
			base.Controls.Add(mobjPanelColumnWidth);
			base.Controls.Add(mobjPanelButtons);
			base.Controls.Add(mobjLabelHelp);
			base.DockPadding.All = 15;
			base.Name = "ListViewColumnOptions";
			Text = "ListViewColumnOptions";
			mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
			mobjPanelColumnWidth.ResumeLayout(blnPerformLayout: false);
			mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
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
		/// Handle OK button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonOK_Click(object sender, EventArgs e)
		{
			int num = 0;
			ArrayList arrayList = new ArrayList(mobjItemChooser.Checked);
			foreach (ColumnHeader item in mobjItemChooser.Items)
			{
				if (mobjColumnWidth[item] != null)
				{
					item.Width = int.Parse((string)mobjColumnWidth[item]);
				}
				item.Visible = arrayList.Contains(item);
				item.DisplayIndexInternal = num;
				num++;
			}
			mobjColumns.UpdateColumns();
			Close();
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjItemChooser_ItemSelected(object sender, EventArgs e)
		{
			mobjTextColumnWidth.Text = GetColumnWidth((ColumnHeader)mobjItemChooser.SelectedItem);
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjTextColumnWidth_TextChanged(object sender, EventArgs e)
		{
			ColumnHeader columnHeader = (ColumnHeader)mobjItemChooser.SelectedItem;
			string text = mobjTextColumnWidth.Text;
			try
			{
				int num = int.Parse(text);
				mobjColumnWidth[columnHeader] = num.ToString();
			}
			catch (Exception)
			{
				mobjTextColumnWidth.Text = GetColumnWidth(columnHeader);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objColumnHeader"></param>
		private string GetColumnWidth(ColumnHeader objColumnHeader)
		{
			if (mobjColumnWidth[objColumnHeader] != null)
			{
				return (string)mobjColumnWidth[objColumnHeader];
			}
			return objColumnHeader.Width.ToString();
		}
	}
}
