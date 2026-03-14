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

namespace Gizmox.WebGUI.Forms.Design
{
/// 
	/// The dialog for the visual templates.
	/// </summary>
	[Serializable]
	public class VisualTemplateControlDialog : CommonDialog
	{
		[Serializable]
		protected class VisualTemplateControlForm : CommonDialogForm
		{
			/// 
			/// Required designer variable.
			/// </summary>
			private IContainer components = null;

			private Panel mobjLeftPanel;

			private Splitter mobjSplitter;

			private Splitter mobjSplitter2;

			private Panel mobjRightPanel;

			private Button mbtnOkAction;

			private Button mbtnCancelAction;

			private PropertyGrid mobjPropertyGrid;

			private Panel mobjActionsPanel;

			private Panel mobjDescriptionPanel;

			private Label mobjDescriptionLabel;

			private ListView mobjListOfVisualTemplates;

			private ColumnHeader mobjColumnAppearanceName;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog.VisualTemplateControlForm" /> class.
			/// </summary>
			/// <param name="objVisualizerControlDialog">The object visualizer control dialog.</param>
			public VisualTemplateControlForm(VisualTemplateControlDialog objVisualizerControlDialog)
				: base(objVisualizerControlDialog)
			{
				InitializeComponent();
				base.AcceptButton = mbtnOkAction;
				base.CancelButton = mbtnCancelAction;
				InitializeData();
			}

			/// 
			/// Initializes the data.
			/// </summary>
			private void InitializeData()
			{
				VisualTemplateControlDialog visualTemplateControlDialog = base.CommonDialogOwner as VisualTemplateControlDialog;
				mobjPropertyGrid.Tag = visualTemplateControlDialog.mobjComponent;
				if (visualTemplateControlDialog == null)
				{
					return;
				}
				List controlVisualTemplateTypes = visualTemplateControlDialog.GetControlVisualTemplateTypes();
				VisualTemplate visualTemplate = visualTemplateControlDialog.VisualTemplate;
				ImageList imageList = new ImageList();
				ListViewItem listViewItem = new ListViewItem();
				imageList.Images.Add(VisualTemplate.VisualizerDefaultImage);
				listViewItem.ImageIndex = 0;
				listViewItem.SubItems.Add("None");
				listViewItem.SubItems.Add(string.Empty);
				if (visualTemplate == null)
				{
					listViewItem.Selected = true;
				}
				mobjListOfVisualTemplates.Items.Add(listViewItem);
				if (controlVisualTemplateTypes != null)
				{
					foreach (Type item in controlVisualTemplateTypes)
					{
						ListViewItem listViewItem2 = new ListViewItem();
						VisualTemplate visualTemplate2 = Activator.CreateInstance(item) as VisualTemplate;
						VisualTemplate visualTemplate3 = null;
						if (visualTemplate2 != null && visualTemplateControlDialog.mobjComponent is Control objControl)
						{
							visualTemplate3 = visualTemplate2.GetDefault(objControl);
							if (visualTemplate3 != null && visualTemplate3.GetType() == visualTemplate2.GetType())
							{
								visualTemplate2 = visualTemplate3;
							}
						}
						if (visualTemplate != null && visualTemplate.GetType() == item)
						{
							visualTemplate2 = visualTemplate;
							listViewItem2.Selected = true;
							mobjPropertyGrid.SelectedObject = visualTemplate;
						}
						listViewItem2.Tag = visualTemplate2;
						listViewItem2.SubItems.Add(visualTemplate2.ToString());
						listViewItem2.SubItems.Add(GetVisualTemplateDescription(item));
						ResourceHandle visualizerImage = visualTemplate2.VisualizerImage;
						if (visualizerImage != null)
						{
							imageList.Images.Add(visualizerImage);
						}
						else
						{
							imageList.Images.Add(VisualTemplate.VisualizerDefaultImage);
						}
						listViewItem2.ImageIndex = imageList.Images.Count - 1;
						mobjListOfVisualTemplates.Items.Add(listViewItem2);
					}
				}
				mobjListOfVisualTemplates.LargeImageList = imageList;
				imageList.ImageSize = new Size(200, 150);
				mobjListOfVisualTemplates.Font = new Font("Arial", 16f, FontStyle.Regular, GraphicsUnit.Pixel, 0);
				Text = "Visual templates available for " + visualTemplateControlDialog.mobjControlType.Name;
				UpdateScreen();
			}

			/// 
			/// Gets the visual template description.
			/// </summary>
			/// <param name="objTypeOfVisualTemplate">The obj type of visual template.</param>
			/// </returns>
			private string GetVisualTemplateDescription(Type objTypeOfVisualTemplate)
			{
				VisualTemplateControlDialog visualTemplateControlDialog = base.CommonDialogOwner as VisualTemplateControlDialog;
				return visualTemplateControlDialog.GetVisualTemplateDescription(objTypeOfVisualTemplate);
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
				mobjLeftPanel = new Panel();
				mobjSplitter = new Splitter();
				mobjSplitter2 = new Splitter();
				mobjRightPanel = new Panel();
				mbtnCancelAction = new Button();
				mbtnOkAction = new Button();
				mobjPropertyGrid = new PropertyGrid();
				mobjActionsPanel = new Panel();
				mobjListOfVisualTemplates = new ListView();
				mobjDescriptionPanel = new Panel();
				mobjDescriptionLabel = new Label();
				mobjColumnAppearanceName = new ColumnHeader();
				mobjRightPanel.SuspendLayout();
				mobjActionsPanel.SuspendLayout();
				SuspendLayout();
				mobjLeftPanel.Controls.Add(mobjListOfVisualTemplates);
				mobjLeftPanel.Controls.Add(mobjSplitter2);
				mobjLeftPanel.Controls.Add(mobjDescriptionPanel);
				mobjLeftPanel.Dock = DockStyle.Fill;
				mobjLeftPanel.Location = new Point(0, 0);
				mobjLeftPanel.Name = "panel1";
				mobjLeftPanel.Size = new Size(518, 470);
				mobjLeftPanel.TabIndex = 0;
				mobjSplitter.Location = new Point(518, 0);
				mobjSplitter.Dock = DockStyle.Right;
				mobjSplitter.Name = "splitter1";
				mobjSplitter.Size = new Size(3, 470);
				mobjSplitter.TabIndex = 1;
				mobjSplitter.TabStop = false;
				mobjSplitter2.Location = new Point(518, 0);
				mobjSplitter2.Dock = DockStyle.Bottom;
				mobjSplitter2.Name = "mobjSplitter2";
				mobjSplitter2.Size = new Size(470, 3);
				mobjSplitter2.TabIndex = 1;
				mobjSplitter2.TabStop = false;
				mobjRightPanel.Controls.Add(mobjPropertyGrid);
				mobjRightPanel.Controls.Add(mobjActionsPanel);
				mobjRightPanel.Dock = DockStyle.Right;
				mobjRightPanel.Location = new Point(521, 0);
				mobjRightPanel.Name = "panel2";
				mobjRightPanel.Size = new Size(231, 470);
				mobjRightPanel.TabIndex = 2;
				mbtnCancelAction.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mbtnCancelAction.Location = new Point(157, 11);
				mbtnCancelAction.Name = "mbtnCancelAction";
				mbtnCancelAction.Size = new Size(75, 23);
				mbtnCancelAction.TabIndex = 0;
				mbtnCancelAction.Text = "Cancel";
				mbtnCancelAction.Click += mbtnCancelAction_Click;
				mbtnOkAction.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				mbtnOkAction.Location = new Point(72, 11);
				mbtnOkAction.Name = "mbtnOkAction";
				mbtnOkAction.Size = new Size(75, 23);
				mbtnOkAction.TabIndex = 1;
				mbtnOkAction.Text = "Ok";
				mbtnOkAction.Click += mbtnOkAction_Click;
				mobjPropertyGrid.AutoValidate = AutoValidate.EnablePreventFocusChange;
				mobjPropertyGrid.CategoryForeColor = Color.Empty;
				mobjPropertyGrid.CommandsVisibleIfAvailable = false;
				mobjPropertyGrid.Dock = DockStyle.Fill;
				mobjPropertyGrid.HelpForeColor = Color.Black;
				mobjPropertyGrid.LineColor = Color.Empty;
				mobjPropertyGrid.Location = new Point(0, 0);
				mobjPropertyGrid.Name = "propertyGrid1";
				mobjPropertyGrid.Size = new Size(231, 425);
				mobjPropertyGrid.TabIndex = 2;
				mobjPropertyGrid.ViewBackColor = Color.White;
				mobjPropertyGrid.ViewForeColor = Color.Black;
				mobjActionsPanel.Controls.Add(mbtnOkAction);
				mobjActionsPanel.Controls.Add(mbtnCancelAction);
				mobjActionsPanel.Dock = DockStyle.Bottom;
				mobjActionsPanel.Location = new Point(0, 425);
				mobjActionsPanel.Name = "panel3";
				mobjActionsPanel.Size = new Size(231, 45);
				mobjActionsPanel.TabIndex = 3;
				mobjDescriptionPanel.Controls.Add(mobjDescriptionLabel);
				mobjDescriptionPanel.Dock = DockStyle.Bottom;
				mobjDescriptionPanel.Location = new Point(0, 425);
				mobjDescriptionPanel.Name = "mobjDescriptionPanel";
				mobjDescriptionPanel.Size = new Size(231, 80);
				mobjDescriptionPanel.TabIndex = 3;
				mobjDescriptionLabel.Dock = DockStyle.Fill;
				mobjDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
				mobjDescriptionLabel.Text = "";
				mobjListOfVisualTemplates.DataMember = null;
				mobjListOfVisualTemplates.Columns.AddRange(new ColumnHeader[1] { mobjColumnAppearanceName });
				mobjListOfVisualTemplates.Dock = DockStyle.Fill;
				mobjListOfVisualTemplates.Location = new Point(0, 0);
				mobjListOfVisualTemplates.Name = "listView1";
				mobjListOfVisualTemplates.Size = new Size(518, 470);
				mobjListOfVisualTemplates.MultiSelect = false;
				mobjListOfVisualTemplates.TabIndex = 0;
				mobjListOfVisualTemplates.SelectedIndexChanged += mobjListOfVisualTemplates_SelectedIndexChanged;
				mobjListOfVisualTemplates.View = View.LargeIcon;
				base.Controls.Add(mobjLeftPanel);
				base.Controls.Add(mobjSplitter);
				base.Controls.Add(mobjRightPanel);
				base.Size = new Size(752, 470);
				Text = "VisualizerControl";
				mobjRightPanel.ResumeLayout(blnPerformLayout: false);
				mobjActionsPanel.ResumeLayout(blnPerformLayout: false);
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Handles the SelectedIndexChanged event of the mobjListOfVisualTemplates control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mobjListOfVisualTemplates_SelectedIndexChanged(object sender, EventArgs e)
			{
				UpdateScreen();
			}

			/// 
			/// Updates the screen.
			/// </summary>
			private void UpdateScreen()
			{
				string text = string.Empty;
				ListViewItem selectedItem = mobjListOfVisualTemplates.SelectedItem;
				if (selectedItem != null)
				{
					mobjPropertyGrid.SelectedObject = selectedItem.Tag;
					if (base.CommonDialogOwner is VisualTemplateControlDialog visualTemplateControlDialog)
					{
						visualTemplateControlDialog.VisualTemplate = selectedItem.Tag as VisualTemplate;
					}
					text = selectedItem.SubItems[1].Text;
				}
				mobjDescriptionLabel.Text = text;
			}

			/// 
			/// Handles the Click event of the mbtnCacnelAction control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mbtnCancelAction_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.Cancel;
				Close();
			}

			/// 
			/// Handles the Click event of the mbtnOkAction control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void mbtnOkAction_Click(object sender, EventArgs e)
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private VisualTemplate mobjCurrentControlVisualTemplate = null;

		private Type mobjControlType;

		private Component mobjComponent;

		private string mstrDeviceId;

		private VisualTemplateService mobjVisualTemplateService = new VisualTemplateService();

		/// 
		/// Gets or sets the visual template.
		/// </summary>
		/// 
		/// The visual template.
		/// </value>
		public VisualTemplate VisualTemplate
		{
			get
			{
				return mobjCurrentControlVisualTemplate;
			}
			set
			{
				mobjCurrentControlVisualTemplate = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog" /> class.
		/// </summary>
		/// <param name="objControlType">Type of the object control.</param>
		/// <param name="objCurrentControlVisualTemplate">The object current control visual template.</param>
		/// <param name="objComponent">The object component.</param>
		public VisualTemplateControlDialog(Type objControlType, VisualTemplate objCurrentControlVisualTemplate, Component objComponent)
		{
			mobjControlType = objControlType;
			mobjCurrentControlVisualTemplate = objCurrentControlVisualTemplate;
			mstrDeviceId = null;
			mobjComponent = objComponent;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.VisualTemplateControlDialog" /> class.
		/// </summary>
		/// <param name="objControlType">Type of the object control.</param>
		/// <param name="objCurrentControlVisualTemplate">The object current control visual template.</param>
		/// <param name="objComponent">The object component.</param>
		/// <param name="strDeviceId">The string device unique identifier.</param>
		public VisualTemplateControlDialog(Type objControlType, VisualTemplate objCurrentControlVisualTemplate, Component objComponent, string strDeviceId)
		{
			mobjControlType = objControlType;
			mobjCurrentControlVisualTemplate = objCurrentControlVisualTemplate;
			mstrDeviceId = strDeviceId;
			mobjComponent = objComponent;
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
			return new VisualTemplateControlForm(this);
		}

		/// 
		/// Gets the control visual template types.
		/// </summary>
		/// </returns>
		private List<object> GetControlVisualTemplateTypes()
		{
			return mobjVisualTemplateService.GetVisualTemplates(mobjControlType);
		}

		/// 
		/// Gets the visual template description.
		/// </summary>
		/// <param name="objTypeOfVisualTemplate">The obj type of visual template.</param>
		/// </returns>
		private string GetVisualTemplateDescription(Type objTypeOfVisualTemplate)
		{
			string result = string.Empty;
			if (Attribute.GetCustomAttribute(objTypeOfVisualTemplate, typeof(VisualTemplateAttribute), inherit: true) is VisualTemplateAttribute visualTemplateAttribute)
			{
				result = visualTemplateAttribute.Description;
			}
			return result;
		}
	}
}
