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

namespace Gizmox.WebGUI.Forms.Administration.CustomComponents
{
/// 
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[Browsable(false)]
	public class AdministrationFooterPanel : Panel
	{
		/// 
		///
		/// </summary>
		[Serializable]
		private class StatusLabel : Label
		{
			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationFooterPanel.StatusLabel" /> class.
			/// </summary>
			public StatusLabel()
			{
				base.AutoSize = true;
				base.TextAlign = ContentAlignment.MiddleCenter;
				Dock = DockStyle.Left;
			}
		}

		/// 
		/// The mobj labels
		/// </summary>
		private List<object> mobjLabels;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Administration.CustomComponents.AdministrationFooterPanel" /> class.
		/// </summary>
		public AdministrationFooterPanel()
		{
			mobjLabels = new List<object>();
		}

		/// 
		/// Sets the labels.
		/// </summary>
		/// <param name="objDatas">The object datas.</param>
		public void SetLabels(List<object> objDatas)
		{
			if (objDatas != null)
			{
				while (objDatas.Count > mobjLabels.Count)
				{
					Label label = new StatusLabel();
					mobjLabels.Insert(0, label);
					base.Controls.Add(label);
				}
				int num = 0;
				foreach (StatusData objData in objDatas)
				{
					UpdateLabel(objData, mobjLabels[num]);
					num++;
				}
				for (int i = num; i < mobjLabels.Count; i++)
				{
					mobjLabels[i].Visible = false;
				}
				return;
			}
			foreach (Label mobjLabel in mobjLabels)
			{
				mobjLabel.Visible = false;
			}
		}

		/// 
		/// Updates the label.
		/// </summary>
		/// <param name="objData">The object data.</param>
		/// <param name="objLabel">The label.</param>
		private void UpdateLabel(StatusData objData, Label objLabel)
		{
			objLabel.Visible = true;
			objLabel.Text = objData.Text;
			Font font = objData.Font;
			if (font != null)
			{
				objLabel.Font = font;
			}
			else
			{
				objLabel.Font = base.DefaultControlFont;
			}
		}
	}
}
