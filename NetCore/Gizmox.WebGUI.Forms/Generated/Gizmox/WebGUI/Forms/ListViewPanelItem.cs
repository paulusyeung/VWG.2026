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
	/// Represents a list view item that can have a panel
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	public class ListViewPanelItem : ListViewItem
	{
		/// 
		/// The panel control
		/// </summary>
		private Control mobjPanel = null;

		/// 
		/// Gets or sets the panel.
		/// </summary>
		/// The panel.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Control Panel => mobjPanel;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel control.</param>
		public ListViewPanelItem(Control objPanel)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel control.</param>
		/// <param name="strText">The text of the first sub item.</param>
		public ListViewPanelItem(Control objPanel, string strText)
			: base(strText)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel control.</param>
		/// <param name="arrItems">The sub items.</param>
		public ListViewPanelItem(Control objPanel, string[] arrItems)
			: base(arrItems)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel control.</param>
		/// <param name="strText">The text of the first sub item.</param>
		/// <param name="intImageIndex">The index of the image in the image list.</param>
		public ListViewPanelItem(Control objPanel, string strText, int intImageIndex)
			: base(strText, intImageIndex)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel control.</param>
		/// <param name="arrItems">The sub items.</param>
		/// <param name="intImageIndex">The index of the image in the image list.</param>
		public ListViewPanelItem(Control objPanel, string[] arrItems, int intImageIndex)
			: base(arrItems, intImageIndex)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel control.</param>
		/// <param name="arrSubItems">The sub items.</param>
		/// <param name="intImageIndex">The index of the image in the image list.</param>
		public ListViewPanelItem(Control objPanel, ListViewSubItem[] arrSubItems, int intImageIndex)
			: base(arrSubItems, intImageIndex)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewPanelItem" /> class.
		/// </summary>
		/// <param name="objPanel">The panel.</param>
		/// <param name="arrItems">The items.</param>
		/// <param name="intImageIndex">Index of the int image.</param>
		/// <param name="objForeColor">Color of the obj fore.</param>
		/// <param name="objBackColor">Color of the obj back.</param>
		/// <param name="objFont">The obj font.</param>
		public ListViewPanelItem(Control objPanel, string[] arrItems, int intImageIndex, Color objForeColor, Color objBackColor, Font objFont)
			: base(arrItems, intImageIndex, objForeColor, objBackColor, objFont)
		{
			SetItemPanel(objPanel);
		}

		/// 
		/// Set the item panel
		/// </summary>
		/// <param name="objPanel"></param>
		private void SetItemPanel(Control objPanel)
		{
			if (objPanel == null)
			{
				throw new ArgumentException("ListViewItem panel cannot be null.", "objPanel");
			}
			objPanel.Dock = DockStyle.Top;
			objPanel.TabIndex = 1;
			mobjPanel = objPanel;
		}

		/// 
		/// Renders the dirty item.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objProcessor">The processor.</param>
		/// <param name="lngRequestID">The request id.</param>
		internal override void RenderDirtyItem(IContext objContext, IResponseWriter objWriter, ListView.ItemRenderingProcessor objProcessor, long lngRequestID)
		{
			base.RenderDirtyItem(objContext, objWriter, objProcessor, lngRequestID);
			if (objProcessor.View == View.Details)
			{
				if (objProcessor.FullListRedraw)
				{
					objWriter.WriteStartElement("LVP");
					((IRenderableComponent)Panel).RenderComponent(objContext, objWriter, lngRequestID);
					objWriter.WriteEndElement();
				}
				else
				{
					((IRenderableComponent)Panel).RenderComponent(objContext, objWriter, lngRequestID);
				}
			}
		}
	}
}
