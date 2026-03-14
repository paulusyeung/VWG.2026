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

namespace Gizmox.WebGUI.Forms.Controls
{
/// 
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class ItemChooser : UserControl
	{
		private Button mobjButtonMoveUp;

		private Button mobjButtonMoveDown;

		private Button mobjButtonShow;

		private Panel mobjPanelButtons;

		private Button mobjButtonHide;

		private CheckedListBox mobjListItems;

		/// 
		/// Gets the selected item.
		/// </summary>
		/// </value>
		public object SelectedItem => mobjListItems.SelectedItem;

		/// 
		/// Gets or sets the items collection.
		/// </summary>
		/// </value>
		public ICollection Items
		{
			get
			{
				return mobjListItems.Items;
			}
			set
			{
				mobjListItems.Items.AddRange(value);
				if (mobjListItems.Items.Count > 0)
				{
					mobjListItems.SelectedIndex = 0;
				}
			}
		}

		/// 
		/// Gets or sets the checked collection.
		/// </summary>
		/// </value>
		public ICollection Checked
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (object item in mobjListItems.Items)
				{
					int num = mobjListItems.Items.IndexOf(item);
					if (num != -1 && mobjListItems.GetItemChecked(num))
					{
						arrayList.Add(item);
					}
				}
				return arrayList;
			}
			set
			{
				foreach (object item in value)
				{
					int num = mobjListItems.Items.IndexOf(item);
					if (num != -1)
					{
						mobjListItems.SetItemChecked(num, blnChecked: true);
					}
				}
			}
		}

		/// 
		/// Gets or sets the check label.
		/// </summary>
		/// </value>
		public string CheckLabel
		{
			get
			{
				return mobjButtonShow.Text;
			}
			set
			{
				mobjButtonShow.Text = value;
			}
		}

		/// 
		/// Gets or sets the uncheck label.
		/// </summary>
		/// </value>
		public string UncheckLabel
		{
			get
			{
				return mobjButtonHide.Text;
			}
			set
			{
				mobjButtonHide.Text = value;
			}
		}

		/// 
		/// Gets or sets the moveup label.
		/// </summary>
		/// </value>
		public string MoveUpLabel
		{
			get
			{
				return mobjButtonMoveUp.Text;
			}
			set
			{
				mobjButtonMoveUp.Text = value;
			}
		}

		/// 
		/// Gets or sets the move down label.
		/// </summary>
		/// </value>
		public string MoveDownLabel
		{
			get
			{
				return mobjButtonMoveDown.Text;
			}
			set
			{
				mobjButtonMoveDown.Text = value;
			}
		}

		/// 
		/// Occurs when an item is selected
		/// </summary>
		public event EventHandler ItemSelected;

		/// 
		/// Occurs when an item is checked
		/// </summary>
		public event ItemCheckHandler ItemCheck;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Controls.ItemChooser" /> instance.
		/// </summary>
		public ItemChooser()
		{
			InitializeComponent();
			mobjButtonMoveUp.Click += mobjButtonMoveUp_Click;
			mobjButtonMoveDown.Click += mobjButtonMoveDown_Click;
			mobjButtonShow.Click += mobjButtonShow_Click;
			mobjButtonHide.Click += mobjButtonHide_Click;
			mobjListItems.SelectedIndexChanged += mobjListItems_SelectedIndexChanged;
			mobjListItems.ItemCheck += mobjListItems_ItemCheck;
			mobjButtonHide.Text = WGLabels.Hide;
			mobjButtonMoveDown.Text = WGLabels.MoveDown;
			mobjButtonMoveUp.Text = WGLabels.MoveUp;
			mobjButtonShow.Text = WGLabels.Show;
			mobjListItems.DisplayMember = "Text";
		}

		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjListItems = new CheckedListBox();
			mobjPanelButtons = new Panel();
			mobjButtonMoveUp = new Button();
			mobjButtonMoveDown = new Button();
			mobjButtonShow = new Button();
			mobjButtonHide = new Button();
			mobjPanelButtons.SuspendLayout();
			SuspendLayout();
			mobjListItems.Dock = DockStyle.Fill;
			mobjListItems.Location = new Point(0, 0);
			mobjListItems.Name = "mobjListItems";
			mobjListItems.Size = new Size(821, 454);
			mobjListItems.TabIndex = 0;
			mobjPanelButtons.Controls.Add(mobjButtonHide);
			mobjPanelButtons.Controls.Add(mobjButtonShow);
			mobjPanelButtons.Controls.Add(mobjButtonMoveDown);
			mobjPanelButtons.Controls.Add(mobjButtonMoveUp);
			mobjPanelButtons.Dock = DockStyle.Right;
			mobjPanelButtons.Location = new Point(710, 0);
			mobjPanelButtons.Name = "mobjPanelButtons";
			mobjPanelButtons.Size = new Size(111, 454);
			mobjPanelButtons.TabIndex = 1;
			mobjButtonHide.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			mobjButtonHide.Location = new Point(4, 87);
			mobjButtonHide.Name = "mobjButtonHide";
			mobjButtonHide.Size = new Size(103, 23);
			mobjButtonHide.TabIndex = 3;
			mobjButtonHide.Text = "Hide";
			mobjButtonShow.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			mobjButtonShow.Location = new Point(4, 58);
			mobjButtonShow.Name = "mobjButtonShow";
			mobjButtonShow.Size = new Size(103, 23);
			mobjButtonShow.TabIndex = 2;
			mobjButtonShow.Text = "Show";
			mobjButtonMoveDown.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			mobjButtonMoveDown.Location = new Point(4, 29);
			mobjButtonMoveDown.Name = "mobjButtonMoveDown";
			mobjButtonMoveDown.Size = new Size(103, 23);
			mobjButtonMoveDown.TabIndex = 1;
			mobjButtonMoveDown.Text = "Move Down";
			mobjButtonMoveUp.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
			mobjButtonMoveUp.Location = new Point(4, 0);
			mobjButtonMoveUp.Name = "mobjButtonMoveUp";
			mobjButtonMoveUp.Size = new Size(103, 23);
			mobjButtonMoveUp.TabIndex = 0;
			mobjButtonMoveUp.Text = "Move Up";
			base.Controls.Add(mobjListItems);
			base.Controls.Add(mobjPanelButtons);
			base.Name = "ItemChooser";
			base.Size = new Size(320, 190);
			mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Updates the state of the buttons.
		/// </summary>
		public void UpdateButtonsState()
		{
			int selectedIndex = mobjListItems.SelectedIndex;
			int num = mobjListItems.Items.Count - 1;
			bool itemChecked = mobjListItems.GetItemChecked(selectedIndex);
			mobjButtonMoveUp.Enabled = selectedIndex != 0;
			mobjButtonMoveDown.Enabled = selectedIndex != num;
			mobjButtonHide.Enabled = itemChecked;
			mobjButtonShow.Enabled = !itemChecked;
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonHide_Click(object sender, EventArgs e)
		{
			mobjListItems.SetItemChecked(mobjListItems.SelectedIndex, blnChecked: false);
			UpdateButtonsState();
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonShow_Click(object sender, EventArgs e)
		{
			mobjListItems.SetItemChecked(mobjListItems.SelectedIndex, blnChecked: true);
			UpdateButtonsState();
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonMoveUp_Click(object sender, EventArgs e)
		{
			if (mobjListItems.SelectedIndex > 0)
			{
				mobjListItems.SwapItems(mobjListItems.SelectedIndex, mobjListItems.SelectedIndex - 1);
			}
			UpdateButtonsState();
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonMoveDown_Click(object sender, EventArgs e)
		{
			if (mobjListItems.SelectedIndex < mobjListItems.Items.Count - 1)
			{
				mobjListItems.SwapItems(mobjListItems.SelectedIndex, mobjListItems.SelectedIndex + 1);
			}
			UpdateButtonsState();
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjListItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateButtonsState();
			if (this.ItemSelected != null)
			{
				this.ItemSelected(this, new EventArgs());
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void mobjListItems_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
		{
			if (this.ItemCheck != null)
			{
				this.ItemCheck(objSender, objArgs);
			}
			UpdateButtonsState();
		}
	}
}
