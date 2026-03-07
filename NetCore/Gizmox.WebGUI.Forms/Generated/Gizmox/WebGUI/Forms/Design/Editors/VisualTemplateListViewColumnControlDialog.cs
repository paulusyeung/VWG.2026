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

namespace Gizmox.WebGUI.Forms.Design.Editors
{
	/// 
	/// The dialog form for column ordter.
	/// </summary>
	[Serializable]
	public class VisualTemplateListViewColumnControlDialog : CommonDialog
	{
		[Serializable]
		protected class VisualTemplateListViewColumnControlForm : CommonDialogForm
		{
			private Label mobjLabelHelp;

			private Button mobjButtonCancel;

			private Button mobjButtonOK;

			private Panel mobjPanelButtons;

			private ItemChooser mobjItemChooser;

			private ListView.ColumnHeaderCollection mobjColumns;

			private ListView mobjListView;

			private string mstrColumnOrder;

			/// 
			/// Creates a new <see cref="!:ListViewColumnOptions" /> instance.
			/// </summary>
			/// <param name="objListView">List<object> view.</param>
			public VisualTemplateListViewColumnControlForm(VisualTemplateListViewColumnControlDialog objVisualizerControlDialog)
				: base(objVisualizerControlDialog)
			{
				mobjListView = objVisualizerControlDialog.mobjListView;
				mstrColumnOrder = objVisualizerControlDialog.mstrCurrentColumnOrderAppearance;
				InitializeComponent();
				base.AcceptButton = mobjButtonOK;
				base.CancelButton = mobjButtonCancel;
				if (mobjListView != null)
				{
					mobjColumns = mobjListView.Columns;
					ArrayList arrayList = new ArrayList();
					if (mstrColumnOrder != null)
					{
						string[] array = mstrColumnOrder.Split('|');
						string[] array2 = array;
						foreach (string s in array2)
						{
							if (int.TryParse(s, out var result))
							{
								arrayList.Add(mobjColumns[result]);
							}
						}
					}
					ArrayList arrayList2 = new ArrayList(arrayList);
					foreach (ColumnHeader mobjColumn in mobjColumns)
					{
						if (!arrayList2.Contains(mobjColumn))
						{
							arrayList2.Add(mobjColumn);
						}
					}
					mobjItemChooser.Items = arrayList2;
					mobjItemChooser.Checked = arrayList;
				}
				mobjButtonOK.Click += mobjButtonOK_Click;
				mobjItemChooser.CheckLabel = WGLabels.Show;
				mobjItemChooser.UncheckLabel = WGLabels.Hide;
				mobjItemChooser.MoveDownLabel = WGLabels.MoveDown;
				mobjItemChooser.MoveUpLabel = WGLabels.MoveUp;
				mobjButtonOK.Text = WGLabels.Ok;
				mobjButtonCancel.Text = WGLabels.Cancel;
				Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnOptions");
				mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsInstructions");
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
				mobjItemChooser = new ItemChooser();
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
				mobjItemChooser.Dock = DockStyle.Fill;
				mobjItemChooser.Location = new Point(15, 64);
				mobjItemChooser.Name = "mobjItemChooser";
				mobjItemChooser.Size = new Size(320, 191);
				mobjItemChooser.TabIndex = 3;
				base.ClientSize = new Size(342, 350);
				base.Controls.Add(mobjItemChooser);
				base.Controls.Add(mobjPanelButtons);
				base.Controls.Add(mobjLabelHelp);
				base.DockPadding.All = 15;
				base.Name = "ListViewColumnOptions";
				Text = "ListViewColumnOptions";
				mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
				mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Handle OK button click
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void mobjButtonOK_Click(object sender, EventArgs e)
			{
				ArrayList arrayList = new ArrayList(mobjItemChooser.Checked);
				StringBuilder stringBuilder = new StringBuilder();
				foreach (ColumnHeader item in mobjItemChooser.Items)
				{
					if (arrayList.Contains(item))
					{
						stringBuilder.Append($"{item.Index}|");
					}
				}
				((VisualTemplateListViewColumnControlDialog)base.CommonDialogOwner).mstrCurrentColumnOrderAppearance = stringBuilder.ToString().Trim('|');
				base.DialogResult = DialogResult.OK;
			}
		}

		private ListView mobjListView;

		private string mstrCurrentColumnOrderAppearance;

		/// 
		/// Gets or sets the ListView column order.
		/// </summary>
		/// 
		/// The ListView column order.
		/// </value>
		public string ListViewColumnOrder
		{
			get
			{
				return mstrCurrentColumnOrderAppearance;
			}
			set
			{
				mstrCurrentColumnOrderAppearance = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.Editors.VisualTemplateListViewColumnControlDialog" /> class.
		/// </summary>
		/// <param name="objListView">The object ListView.</param>
		/// <param name="strCurrentColumnOrderAppearance">The string current column order appearance.</param>
		public VisualTemplateListViewColumnControlDialog(ListView objListView, string strCurrentColumnOrderAppearance)
		{
			mobjListView = objListView;
			mstrCurrentColumnOrderAppearance = strCurrentColumnOrderAppearance;
		}

		/// 
		/// When overridden in a derived class, resets the properties of a common dialog box to their default values.
		/// </summary>
		public override void Reset()
		{
		}

		/// 
		/// Creates a dialog for instance for the current common dialog
		/// </summary>
		/// </returns>
		protected override CommonDialogForm CreateForm()
		{
			return new VisualTemplateListViewColumnControlForm(this);
		}
	}
}
