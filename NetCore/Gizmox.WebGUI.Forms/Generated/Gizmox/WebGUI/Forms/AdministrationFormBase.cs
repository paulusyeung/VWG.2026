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
	internal abstract class AdministrationFormBase : Form, IAdministrationForm
	{
		/// 
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		private PictureBox mobjLogo;

		private PictureBox mobjFooterLogo;

		private AdministrationFooterPanel mobjFooterPanelTop;

		private Panel mobjTopPanel;

		private Panel mobjFooterPanel;

		private AdministrationHeaderLabel mobjHeaderLabel;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.AdministrationFormBase" /> class.
		/// </summary>
		public AdministrationFormBase()
		{
			ContentChangeNotifierUserControl content = GetContent();
			if (content != null)
			{
				content.Dock = DockStyle.Fill;
				base.Controls.Add(content);
				InitializeComponent();
				content.ContentChanged += objContent_ContentChanged;
				content.Load += objContent_Load;
				return;
			}
			throw new Exception();
		}

		/// 
		/// Handles the Load event of the objContent control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objContent_Load(object sender, EventArgs e)
		{
			UpdateContent(sender as ContentChangeNotifierUserControl);
			if (Context.Arguments["hosted"] != null && Context.Arguments["hosted"] == "1")
			{
				HidePanels();
			}
		}

		/// 
		/// Hide the header and footer panels
		/// </summary>
		protected void HidePanels()
		{
			mobjFooterPanel.Visible = false;
			mobjTopPanel.Visible = false;
		}

		/// 
		/// Objects the content_ content changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The e.</param>
		private void objContent_ContentChanged(object sender, EventArgs e)
		{
			UpdateContent(sender as ContentChangeNotifierUserControl);
		}

		/// 
		/// Updates the content.
		/// </summary>
		/// <param name="objControl">The object control.</param>
		private void UpdateContent(ContentChangeNotifierUserControl objControl)
		{
			string text = string.Empty;
			List labels = null;
			if (objControl != null)
			{
				text = objControl.GetCurrentContentName();
				labels = objControl.GetStatus();
			}
			mobjHeaderLabel.Text = text;
			mobjFooterPanelTop.SetLabels(labels);
		}

		/// 
		/// Gets the content.
		/// </summary>
		/// </returns>
		public abstract ContentChangeNotifierUserControl GetContent();

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

		private void InitializeComponent()
		{
			mobjLogo = new PictureBox();
			mobjFooterLogo = new PictureBox();
			mobjTopPanel = new Panel();
			mobjFooterPanelTop = new AdministrationFooterPanel();
			mobjFooterPanel = new Panel();
			mobjHeaderLabel = new AdministrationHeaderLabel();
			mobjFooterPanelTop.Height = 30;
			mobjFooterPanelTop.Controls.Add(mobjFooterLogo);
			mobjFooterPanelTop.Dock = DockStyle.Top;
			mobjFooterPanelTop.BorderWidth = new BorderWidth(0, 0, 0, 1);
			mobjFooterPanelTop.BorderColor = Color.LightGray;
			mobjFooterPanelTop.BorderStyle = BorderStyle.FixedSingle;
			mobjFooterPanelTop.DockPadding.Right = 50;
			mobjFooterPanelTop.DockPadding.Left = 3;
			mobjFooterPanelTop.DockPadding.Top = 3;
			mobjFooterLogo.Image = new AssemblyResourceHandle(typeof(AdministrationFormBase), "Resources.LogoBottom.png");
			mobjFooterLogo.Dock = DockStyle.Right;
			mobjFooterLogo.Width = 216;
			mobjHeaderLabel.Dock = DockStyle.Fill;
			mobjHeaderLabel.TextAlign = ContentAlignment.BottomLeft;
			mobjLogo.Image = new AssemblyResourceHandle(typeof(AdministrationFormBase), "Resources.LogoTop.png");
			mobjLogo.Dock = DockStyle.Left;
			mobjLogo.Width = 236;
			mobjFooterPanel.Dock = DockStyle.Bottom;
			mobjFooterPanel.Height = 50;
			mobjFooterPanel.Controls.Add(mobjFooterPanelTop);
			mobjTopPanel.Dock = DockStyle.Top;
			mobjTopPanel.Height = 64;
			mobjTopPanel.Controls.Add(mobjHeaderLabel);
			mobjTopPanel.Controls.Add(mobjLogo);
			mobjTopPanel.VisualEffect = new BoxShadowVisualEffect(0, 5, 35, 0, Color.FromArgb(1, 68, 68, 68), blnInset: false);
			mobjTopPanel.DockPadding.Top = 17;
			mobjTopPanel.DockPadding.Bottom = 17;
			mobjTopPanel.DockPadding.Left = 50;
			Text = "Administration";
			base.Controls.Add(mobjTopPanel);
			base.Controls.Add(mobjFooterPanel);
		}
	}
}
