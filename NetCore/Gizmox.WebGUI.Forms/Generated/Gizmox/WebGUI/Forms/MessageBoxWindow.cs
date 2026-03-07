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
	/// Implementation of MessageBoxWindow class.
	/// </summary>
	[Serializable]
	public class MessageBoxWindow : Form
	{
		[Serializable]
		[ToolboxItem(false)]
		internal class MessageBoxButton : Button
		{
			private bool mblnUserClick = false;

			public bool UserClick
			{
				get
				{
					return mblnUserClick;
				}
				set
				{
					mblnUserClick = value;
				}
			}

			protected override void FireEvent(IEvent objEvent)
			{
				if (objEvent.Type == "Click")
				{
					mblnUserClick = true;
				}
				base.FireEvent(objEvent);
				if (objEvent.Type == "Click")
				{
					mblnUserClick = false;
				}
			}
		}

		private TableLayoutPanel mobjButtonsLayout;

		private Panel mobjIconLayout;

		private PictureBox mobjIcon;

		private Label mobjLabelText;

		private Button mobjButton1;

		private Button mobjButton2;

		private Button mobjButton3;

		private MessageBoxDefaultButton menmDefaultButton;

		/// 
		/// Required designer variable.
		/// </summary>
		[NonSerialized]
		private Container components = null;

		private double mintXFactor = 5.7;

		private double mintYFactor = 15.0;

		private MessageBoxButtons menmButtons;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MessageBoxWindow" /> instance.
		/// </summary>
		internal MessageBoxWindow(string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions)
			: this((Form)Global.Context.ActiveForm, strText, strCaption, enmButtons, enmIcon, enmDefaultButton, enmOptions)
		{
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MessageBoxWindow" /> instance.
		/// </summary>
		internal MessageBoxWindow(Form objOwner, string strText, string strCaption, MessageBoxButtons enmButtons, MessageBoxIcon enmIcon, MessageBoxDefaultButton enmDefaultButton, MessageBoxOptions enmOptions)
			: base(objOwner.Context)
		{
			InitializeComponent();
			menmButtons = enmButtons;
			menmDefaultButton = enmDefaultButton;
			int num = 0;
			AddTableLayoutRowStyle(mobjButtonsLayout, new RowStyle(SizeType.Absolute, 26f));
			AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Percent, 50f));
			num++;
			base.AcceptButton = (base.CancelButton = null);
			mobjButton1 = new MessageBoxButton();
			switch (menmButtons)
			{
			case MessageBoxButtons.OK:
				mobjButton1.Text = WGLabels.Ok;
				mobjButton1.DialogResult = DialogResult.OK;
				base.AcceptButton = mobjButton1;
				base.CancelButton = mobjButton1;
				break;
			case MessageBoxButtons.OKCancel:
				mobjButton1.Text = WGLabels.Ok;
				mobjButton1.DialogResult = DialogResult.OK;
				base.AcceptButton = mobjButton1;
				break;
			case MessageBoxButtons.AbortRetryIgnore:
				mobjButton1.Text = WGLabels.Abort;
				mobjButton1.DialogResult = DialogResult.Abort;
				break;
			case MessageBoxButtons.RetryCancel:
				mobjButton1.Text = WGLabels.Retry;
				mobjButton1.DialogResult = DialogResult.Retry;
				break;
			case MessageBoxButtons.YesNoCancel:
			case MessageBoxButtons.YesNo:
				mobjButton1.Text = WGLabels.Yes;
				mobjButton1.DialogResult = DialogResult.Yes;
				mobjButton3 = null;
				break;
			}
			AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 76f));
			mobjButtonsLayout.Controls.Add(mobjButton1, 1, 0);
			if (menmButtons != MessageBoxButtons.OK)
			{
				num++;
				mobjButton2 = new MessageBoxButton();
				switch (menmButtons)
				{
				case MessageBoxButtons.OKCancel:
				case MessageBoxButtons.RetryCancel:
					mobjButton2.Text = WGLabels.Cancel;
					mobjButton2.DialogResult = DialogResult.Cancel;
					base.CancelButton = mobjButton2;
					break;
				case MessageBoxButtons.AbortRetryIgnore:
					mobjButton2.Text = WGLabels.Retry;
					mobjButton2.DialogResult = DialogResult.Retry;
					break;
				case MessageBoxButtons.YesNoCancel:
				case MessageBoxButtons.YesNo:
					mobjButton2.Text = WGLabels.No;
					mobjButton2.DialogResult = DialogResult.No;
					break;
				}
				AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 6f));
				AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 76f));
				mobjButtonsLayout.Controls.Add(mobjButton2, 3, 0);
			}
			if (menmButtons == MessageBoxButtons.AbortRetryIgnore || menmButtons == MessageBoxButtons.YesNoCancel)
			{
				num++;
				mobjButton3 = new MessageBoxButton();
				switch (menmButtons)
				{
				case MessageBoxButtons.AbortRetryIgnore:
					mobjButton3.Text = WGLabels.Ignore;
					mobjButton3.DialogResult = DialogResult.Ignore;
					break;
				case MessageBoxButtons.YesNoCancel:
					mobjButton3.Text = WGLabels.Cancel;
					mobjButton3.DialogResult = DialogResult.Cancel;
					base.CancelButton = mobjButton3;
					break;
				}
				AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 6f));
				AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Absolute, 76f));
				mobjButtonsLayout.Controls.Add(mobjButton3, 5, 0);
			}
			AddTableLayoutColumnStyle(mobjButtonsLayout, new ColumnStyle(SizeType.Percent, 50f));
			if (enmIcon != MessageBoxIcon.None)
			{
				mobjLabelText.Text = enmIcon.ToString();
				mobjIcon.Image = new SkinResourceHandle(typeof(MessageBox), enmIcon.ToString() + ".gif");
			}
			else
			{
				base.Controls.Remove(mobjIconLayout);
			}
			mobjLabelText.Text = strText;
			Text = strCaption;
			if (Context != null && Context.MainForm != null)
			{
				objOwner = Context.MainForm as Form;
			}
			Size stringMeasurements = CommonUtils.GetStringMeasurements(strText, mobjLabelText.Font, objOwner.Width - ((enmIcon != MessageBoxIcon.None) ? mobjIcon.Width : 0));
			int width = Math.Max(GetMinimalWidthForButtonsLayout(), stringMeasurements.Width) + ((enmIcon != MessageBoxIcon.None) ? mobjIconLayout.Width : 0) + Padding.All * 2;
			int height = mobjButtonsLayout.Height + Math.Max((enmIcon != MessageBoxIcon.None) ? mobjIcon.Height : 0, stringMeasurements.Height) + 50;
			SuspendLayout();
			base.Size = new Size(width, height);
			base.ClientSize = new Size(width, height);
			ResumeLayout(blnPerformLayout: false);
			if (enmButtons == MessageBoxButtons.YesNo || enmButtons == MessageBoxButtons.AbortRetryIgnore)
			{
				base.CloseBox = false;
			}
			base.Load += Form_Load;
		}

		private void Form_Load(object sender, EventArgs e)
		{
			Button button = null;
			switch (menmDefaultButton)
			{
			case MessageBoxDefaultButton.Button1:
				button = mobjButton1;
				break;
			case MessageBoxDefaultButton.Button2:
				button = mobjButton2;
				break;
			case MessageBoxDefaultButton.Button3:
				button = mobjButton3;
				break;
			}
			button?.Focus();
		}

		/// 
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjButtonsLayout = new TableLayoutPanel();
			mobjIconLayout = new Panel();
			mobjIcon = new PictureBox();
			mobjLabelText = new Label();
			mobjIconLayout.SuspendLayout();
			SuspendLayout();
			mobjButtonsLayout.Dock = DockStyle.Bottom;
			mobjButtonsLayout.Location = new Point(10, 85);
			mobjButtonsLayout.Name = "mobjButtonsLayout";
			mobjButtonsLayout.Size = new Size(460, 26);
			mobjButtonsLayout.TabIndex = 0;
			mobjIconLayout.Controls.Add(mobjIcon);
			mobjIconLayout.Dock = DockStyle.Left;
			mobjIconLayout.Location = new Point(10, 10);
			mobjIconLayout.Name = "mobjIconLayout";
			mobjIconLayout.Size = new Size(50, 75);
			mobjIconLayout.TabIndex = 1;
			mobjIcon.Location = new Point(9, 15);
			mobjIcon.Name = "mobjIcon";
			mobjIcon.Size = new Size(32, 32);
			mobjIcon.TabIndex = 0;
			mobjIcon.TabStop = false;
			mobjLabelText.Dock = DockStyle.Fill;
			mobjLabelText.Location = new Point(60, 10);
			mobjLabelText.Name = "mobjLabelText";
			mobjLabelText.Size = new Size(410, 75);
			mobjLabelText.TabIndex = 2;
			mobjLabelText.TextAlign = ContentAlignment.MiddleLeft;
			mobjLabelText.UseMnemonic = false;
			base.ClientSize = new Size(480, 125);
			base.Controls.Add(mobjLabelText);
			base.Controls.Add(mobjIconLayout);
			base.Controls.Add(mobjButtonsLayout);
			base.DockPadding.All = 10;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MessageBoxWindow";
			mobjIconLayout.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Adds the table layout column style.
		/// </summary>
		/// <param name="objTableLayoutPanel">The obj table layout panel.</param>
		/// <param name="objColumnStyle">The obj column style.</param>
		private void AddTableLayoutColumnStyle(TableLayoutPanel objTableLayoutPanel, ColumnStyle objColumnStyle)
		{
			if (objTableLayoutPanel != null && objColumnStyle != null)
			{
				objTableLayoutPanel.ColumnStyles.Add(objColumnStyle);
				objTableLayoutPanel.ColumnCount++;
			}
		}

		/// 
		/// Adds the table layout row style.
		/// </summary>
		/// <param name="objTableLayoutPanel">The obj table layout panel.</param>
		/// <param name="objRowStyle">The obj row style.</param>
		private void AddTableLayoutRowStyle(TableLayoutPanel objTableLayoutPanel, RowStyle objRowStyle)
		{
			if (objTableLayoutPanel != null && objRowStyle != null)
			{
				objTableLayoutPanel.RowStyles.Add(objRowStyle);
				objTableLayoutPanel.RowCount++;
			}
		}

		/// 
		/// Gets the minimal width for the buttons layout.
		/// </summary>
		/// </returns>
		private int GetMinimalWidthForButtonsLayout()
		{
			int num = 0;
			if (mobjButtonsLayout != null)
			{
				foreach (ColumnStyle item in (IEnumerable)mobjButtonsLayout.ColumnStyles)
				{
					num += Convert.ToInt32(item.Width);
				}
			}
			return num;
		}
	}
}
