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
	public class DockedContextMenuStrip : ContextMenuStrip
	{
		private ToolStripMenuItem mobjAutoHideButton;

		private ToolStripMenuItem mobjDockButton;

		private ToolStripMenuItem mobjFloatButton;

		private ToolStripMenuItem mobjHideButton;

		private ToolStripMenuItem mobjDockCurrentToRoot;

		private ToolStripMenuItem mobjDockAllToRoot;

		private ToolStripMenuItem mobjDockCurrentRight;

		private ToolStripMenuItem mobjDockCurrentBottom;

		private ToolStripMenuItem mobjDockCurrentLeft;

		private ToolStripMenuItem mobjDockCurrentTop;

		private ToolStripSeparator mobjSeperator;

		private ToolStripMenuItem mobjDockAllRight;

		private ToolStripMenuItem mobjDockAllBottom;

		private ToolStripMenuItem mobjDockAllLeft;

		private ToolStripMenuItem mobjDockAllTop;

		private DockingManager mobjManager;

		private ToolStripMenuItem mobjTabDocumentButton;

		private Zone mobjZone;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedContextMenuStrip" /> class.
		/// </summary>
		public DockedContextMenuStrip(DockingManager objManager)
		{
			mobjManager = objManager;
			InitializeConponent();
		}

		/// 
		/// Shows the specified zone's Context menu.
		/// </summary>
		/// <param name="objZone">The obj zone.</param>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objPosition">The obj position.</param>
		/// <param name="objDirection">The obj direction.</param>
		public void Show(Zone objZone, Control objControl, Point objPosition, ToolStripDropDownDirection objDirection)
		{
			SetZone(objZone);
			Show(objControl, objPosition, objDirection);
		}

		/// 
		/// Initializes the conponent.
		/// </summary>
		private void InitializeConponent()
		{
			mobjFloatButton = new ToolStripMenuItem();
			mobjDockButton = new ToolStripMenuItem();
			mobjTabDocumentButton = new ToolStripMenuItem();
			mobjAutoHideButton = new ToolStripMenuItem();
			mobjHideButton = new ToolStripMenuItem();
			mobjDockCurrentToRoot = new ToolStripMenuItem();
			mobjDockAllToRoot = new ToolStripMenuItem();
			mobjDockCurrentRight = new ToolStripMenuItem();
			mobjDockCurrentBottom = new ToolStripMenuItem();
			mobjDockCurrentLeft = new ToolStripMenuItem();
			mobjDockCurrentTop = new ToolStripMenuItem();
			mobjSeperator = new ToolStripSeparator();
			mobjDockAllRight = new ToolStripMenuItem();
			mobjDockAllBottom = new ToolStripMenuItem();
			mobjDockAllLeft = new ToolStripMenuItem();
			mobjDockAllTop = new ToolStripMenuItem();
			mobjFloatButton.Click += mobjFloatButton_Click;
			mobjFloatButton.Text = SR.GetString("WGFloating");
			mobjDockButton.Click += mobjDockButton_Click;
			mobjDockButton.Text = SR.GetString("WGDockable");
			mobjTabDocumentButton.Click += mobjTabDocumentButton_Click;
			mobjTabDocumentButton.Text = SR.GetString("WGTabbedDocument");
			mobjAutoHideButton.Click += mobjAutoHideButton_Click;
			mobjAutoHideButton.Text = SR.GetString("WGAutoHide");
			mobjHideButton.Click += mobjHideButton_Click;
			mobjHideButton.Text = SR.GetString("WGHide");
			mobjDockCurrentToRoot.Text = SR.GetString("WGGloballyDockCurrentWindow");
			mobjDockCurrentToRoot.DropDownItems.AddRange(new ToolStripItem[4] { mobjDockCurrentRight, mobjDockCurrentBottom, mobjDockCurrentLeft, mobjDockCurrentTop });
			mobjDockAllToRoot.Text = SR.GetString("WGGloballyDockAllWindow");
			mobjDockAllToRoot.DropDownItems.AddRange(new ToolStripItem[4] { mobjDockAllRight, mobjDockAllBottom, mobjDockAllLeft, mobjDockAllTop });
			ResourceHandle image = new SkinResourceHandle(typeof(ZoneSkin), "Top_Global16x16.png");
			ResourceHandle image2 = new SkinResourceHandle(typeof(ZoneSkin), "Right_Global16x16.png");
			ResourceHandle image3 = new SkinResourceHandle(typeof(ZoneSkin), "Bottom_Global16x16.png");
			ResourceHandle image4 = new SkinResourceHandle(typeof(ZoneSkin), "Left_Global16x16.png");
			mobjDockCurrentRight.Text = SR.GetString("WGRight");
			mobjDockCurrentRight.Tag = Relation.ToTheRight;
			mobjDockCurrentRight.Click += mobjDockCurrent_Click;
			mobjDockCurrentRight.Image = image2;
			mobjDockCurrentBottom.Text = SR.GetString("WGBottom");
			mobjDockCurrentBottom.Tag = Relation.Below;
			mobjDockCurrentBottom.Click += mobjDockCurrent_Click;
			mobjDockCurrentBottom.Image = image3;
			mobjDockCurrentLeft.Text = SR.GetString("WGLeft");
			mobjDockCurrentLeft.Tag = Relation.ToTheLeft;
			mobjDockCurrentLeft.Click += mobjDockCurrent_Click;
			mobjDockCurrentLeft.Image = image4;
			mobjDockCurrentTop.Text = SR.GetString("WGTop");
			mobjDockCurrentTop.Tag = Relation.Above;
			mobjDockCurrentTop.Click += mobjDockCurrent_Click;
			mobjDockCurrentTop.Image = image;
			mobjDockAllRight.Text = SR.GetString("WGRight");
			mobjDockAllRight.Tag = Relation.ToTheRight;
			mobjDockAllRight.Click += mobjDockAll_Click;
			mobjDockAllRight.Image = image2;
			mobjDockAllBottom.Text = SR.GetString("WGBottom");
			mobjDockAllBottom.Tag = Relation.Below;
			mobjDockAllBottom.Click += mobjDockAll_Click;
			mobjDockAllBottom.Image = image3;
			mobjDockAllLeft.Text = SR.GetString("WGLeft");
			mobjDockAllLeft.Tag = Relation.ToTheLeft;
			mobjDockAllLeft.Click += mobjDockAll_Click;
			mobjDockAllLeft.Image = image4;
			mobjDockAllTop.Text = SR.GetString("WGTop");
			mobjDockAllTop.Tag = Relation.Above;
			mobjDockAllTop.Click += mobjDockAll_Click;
			mobjDockAllTop.Image = image;
			Items.Add(mobjFloatButton);
			Items.Add(mobjDockButton);
			Items.Add(mobjTabDocumentButton);
			Items.Add(mobjAutoHideButton);
			Items.Add(mobjHideButton);
			Items.Add(mobjDockCurrentToRoot);
			Items.Add(mobjDockAllToRoot);
		}

		/// 
		/// Handles the Click event of the mobjDockAll control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjDockAll_Click(object sender, EventArgs e)
		{
			List list = mobjZone.RemoveAndReturnAllWindows();
			mobjManager.AddDockedWindowsInRootPosition((Relation)(sender as ToolStripMenuItem).Tag, list.ToArray());
		}

		/// 
		/// Handles the Click event of the mobjDockCurrent control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjDockCurrent_Click(object sender, EventArgs e)
		{
			mobjManager.AddDockedWindowsInRootPosition((Relation)(sender as ToolStripMenuItem).Tag, mobjZone.RemoveAndReturnCurrentWindow());
		}

		/// 
		///
		/// Initializes the items.
		/// </summary>
		private void InitializeItems()
		{
			switch (mobjZone.ZoneType)
			{
			case ZoneType.Dock:
				mobjFloatButton.Enabled = true;
				mobjDockButton.Enabled = false;
				mobjTabDocumentButton.Enabled = true;
				mobjAutoHideButton.Enabled = true;
				mobjHideButton.Enabled = true;
				mobjDockCurrentToRoot.Visible = true;
				mobjDockAllToRoot.Visible = true;
				break;
			case ZoneType.Float:
				mobjFloatButton.Enabled = false;
				mobjDockButton.Enabled = true;
				mobjTabDocumentButton.Enabled = true;
				mobjAutoHideButton.Enabled = false;
				mobjHideButton.Enabled = true;
				mobjDockCurrentToRoot.Visible = true;
				mobjDockAllToRoot.Visible = true;
				break;
			case ZoneType.Hidden:
				mobjFloatButton.Enabled = true;
				mobjDockButton.Enabled = true;
				mobjTabDocumentButton.Enabled = true;
				mobjAutoHideButton.Enabled = false;
				mobjHideButton.Enabled = true;
				mobjDockCurrentToRoot.Visible = false;
				mobjDockAllToRoot.Visible = false;
				break;
			case ZoneType.Root:
				mobjFloatButton.Enabled = true;
				mobjDockButton.Enabled = true;
				mobjTabDocumentButton.Enabled = false;
				mobjAutoHideButton.Enabled = false;
				mobjHideButton.Enabled = true;
				mobjDockCurrentToRoot.Visible = true;
				mobjDockAllToRoot.Visible = true;
				break;
			default:
				throw new Exception();
			}
			mobjFloatButton.Visible = mobjManager.AllowFloatingWindows;
			mobjTabDocumentButton.Visible = mobjManager.AllowTabbedDocuments;
			mobjHideButton.Visible = mobjManager.AllowCloseWindows;
		}

		/// 
		/// Handles the Click event of the mobjAutoHideButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjAutoHideButton_Click(object sender, EventArgs e)
		{
			Close();
			mobjZone.ToggleAutoHide();
		}

		/// 
		/// Handles the Click event of the mobjDockButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjDockButton_Click(object sender, EventArgs e)
		{
			Close();
			mobjZone.SwitchCurrentWindowDockState(DockState.Dock);
		}

		/// 
		/// Handles the Click event of the mobjFloatButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjFloatButton_Click(object sender, EventArgs e)
		{
			Close();
			mobjZone.SwitchCurrentWindowDockState(DockState.Float);
		}

		/// 
		/// Handles the Click event of the mobjHideButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjHideButton_Click(object sender, EventArgs e)
		{
			Close();
			mobjZone.HideCurrentWindow();
		}

		/// 
		/// Handles the Click event of the mobjTabDocumentButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void mobjTabDocumentButton_Click(object sender, EventArgs e)
		{
			Close();
			mobjZone.SwitchCurrentWindowDockState(DockState.Tabbed);
		}

		/// 
		/// Sets the zone.
		/// </summary>
		/// <param name="objZone">The obj zone.</param>
		/// </returns>
		internal DockedContextMenuStrip SetZone(Zone objZone)
		{
			mobjZone = objZone;
			InitializeItems();
			if (mobjZone.Windows.Count > 1)
			{
				mobjDockAllToRoot.Enabled = true;
			}
			else
			{
				mobjDockAllToRoot.Enabled = false;
			}
			return this;
		}
	}
}
