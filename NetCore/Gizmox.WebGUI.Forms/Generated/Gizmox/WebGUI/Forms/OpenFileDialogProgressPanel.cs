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
	/// A Panel control
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	internal class OpenFileDialogProgressPanel : Form
	{
		private IRegisteredComponent mobjContainerComponent;

		private TableLayoutPanel mobjLayout;

		private ProgressBar mobjFileProgress;

		private ProgressBar mobjTotalProgress;

		private Label mobjFileProgressLabel;

		private Label mobjTotalProgressLabel;

		private PictureBox pictureBox1;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.OpenFileDialogProgressPanel" /> class.
		/// </summary>
		/// <param name="objComponent">The object component.</param>
		public OpenFileDialogProgressPanel(IRegisteredComponent objComponent)
		{
			mobjContainerComponent = objComponent;
			InitialzieComponent();
		}

		/// 
		/// Initialzies the component.
		/// </summary>
		private void InitialzieComponent()
		{
			mobjLayout = new TableLayoutPanel();
			mobjFileProgress = new ProgressBar();
			mobjTotalProgress = new ProgressBar();
			mobjFileProgressLabel = new Label();
			mobjTotalProgressLabel = new Label();
			pictureBox1 = new PictureBox();
			mobjLayout.SuspendLayout();
			SuspendLayout();
			mobjLayout.BorderColor = Color.FromArgb(101, 147, 207);
			mobjLayout.ColumnCount = 3;
			mobjLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
			mobjLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80f));
			mobjLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
			mobjLayout.Controls.Add(mobjFileProgress, 1, 2);
			mobjLayout.Controls.Add(mobjTotalProgress, 1, 5);
			mobjLayout.Controls.Add(mobjFileProgressLabel, 1, 1);
			mobjLayout.Controls.Add(mobjTotalProgressLabel, 1, 4);
			mobjLayout.Controls.Add(pictureBox1, 1, 0);
			mobjLayout.Dock = DockStyle.Fill;
			mobjLayout.Location = new Point(0, 0);
			mobjLayout.Name = "tableLayoutPanel1";
			mobjLayout.RowCount = 7;
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60f));
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			mobjLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30f));
			mobjLayout.Size = new Size(620, 474);
			mobjLayout.TabIndex = 0;
			mobjFileProgress.Dock = DockStyle.Fill;
			mobjFileProgress.Location = new Point(62, 195);
			mobjFileProgress.Name = "progressBar1";
			mobjFileProgress.Size = new Size(496, 20);
			mobjFileProgress.TabIndex = 0;
			mobjTotalProgress.Dock = DockStyle.Fill;
			mobjTotalProgress.Location = new Point(62, 278);
			mobjTotalProgress.Name = "progressBar2";
			mobjTotalProgress.Size = new Size(496, 20);
			mobjTotalProgress.TabIndex = 0;
			mobjFileProgressLabel.AutoSize = true;
			mobjFileProgressLabel.Dock = DockStyle.Fill;
			mobjFileProgressLabel.Location = new Point(62, 175);
			mobjFileProgressLabel.Name = "label1";
			mobjFileProgressLabel.Size = new Size(496, 20);
			mobjFileProgressLabel.TabIndex = 0;
			mobjFileProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
			mobjTotalProgressLabel.AutoSize = true;
			mobjTotalProgressLabel.Dock = DockStyle.Fill;
			mobjTotalProgressLabel.Location = new Point(62, 258);
			mobjTotalProgressLabel.Name = "label2";
			mobjTotalProgressLabel.Size = new Size(496, 20);
			mobjTotalProgressLabel.TabIndex = 0;
			mobjTotalProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
			pictureBox1.Dock = DockStyle.Bottom;
			pictureBox1.Location = new Point(62, 99);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(496, 56);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.Image = new SkinResourceHandle(typeof(OpenFileDialogSkin), "Uploading.gif");
			base.Visible = true;
			base.TopLevel = false;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Controls.Add(mobjLayout);
			base.Size = new Size(620, 474);
			mobjLayout.ResumeLayout(blnPerformLayout: false);
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			if (mobjContainerComponent != null && mobjContainerComponent.IsRegistered)
			{
				long iD = mobjContainerComponent.ID;
				mobjFileProgress.ClientId = $"FileProgress_{iD}";
				mobjTotalProgress.ClientId = $"TotalProgress_{iD}";
				mobjFileProgressLabel.ClientId = $"FileLabel_{iD}";
				mobjTotalProgressLabel.ClientId = $"TotalLabel_{iD}";
			}
			base.PreRenderControl(objContext, lngRequestID);
		}
	}
}
