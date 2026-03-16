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
	[Skin(typeof(DockedHiddenZonesPanelSkin))]
	[ToolboxItem(false)]
	internal class DockedHiddenZonesPanel : Panel, IDescriptable
	{
		private DockedHiddenZonePanelDescriptor mobjData;

		private DockingManager mobjManager;

		private List<List<Zone>> mobjAllZoneGroups;

		private Dictionary<DockingWindowName, List<Zone>> mobjZonesIndexByWindowName;

		private Dictionary<long, Zone> mobjZonesIndexByZoneID;

		/// 
		/// Gets the docked hidden panel descriptor.
		/// </summary>
		public DockedHiddenZonePanelDescriptor DockedHiddenPanelDescriptor => mobjData;

		/// 
		/// Gets the docked hidden zone panel descriptor.
		/// </summary>
		public DockedHiddenZonePanelDescriptor DockedHiddenZonePanelDescriptor => mobjData;

		DockedObjectDescriptor IDescriptable.Descriptor => mobjData;

		/// 
		/// Gets or sets the name of the zones index by window.
		/// </summary>
		/// 
		/// The name of the zones index by window.
		/// </value>
		internal Dictionary<DockingWindowName, List<Zone>> ZonesIndexByWindowName
		{
			get
			{
				return mobjZonesIndexByWindowName;
			}
			set
			{
				mobjZonesIndexByWindowName = value;
			}
		}

		/// 
		/// Gets or sets the unique zone groups.
		/// </summary>
		/// 
		/// The unique zone groups.
		/// </value>
		public List<List<Zone>> AllZoneGroups
		{
			get
			{
				return mobjAllZoneGroups;
			}
			set
			{
				mobjAllZoneGroups = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DockedHiddenZonesPanel" /> class.
		/// </summary>
		/// <param name="objManager">The obj manager.</param>
		public DockedHiddenZonesPanel(DockingManager objManager)
		{
			mobjData = new DockedHiddenZonePanelDescriptor();
			mobjAllZoneGroups = new List<List<Zone>>();
			mobjManager = objManager;
			mobjZonesIndexByWindowName = new Dictionary<DockingWindowName, List<Zone>>(DockingWindowName.DockedWindowNameEqulityComparer);
			mobjZonesIndexByZoneID = new Dictionary<long, Zone>();
			base.Visible = false;
			CustomStyle = "DockedHiddenZonesPanelSkin";
		}

		/// 
		/// Invokes the method internal.
		/// </summary>
		/// <param name="strMember">The STR member.</param>
		/// <param name="arrArgs">The arr args.</param>
		internal void InvokeMethodInternal(string strMember, params object[] arrArgs)
		{
			InvokeMethod(strMember, arrArgs);
		}

		/// 
		/// Loads the specified descriptor.
		/// </summary>
		/// <param name="objDescriptor">The obj descriptor.</param>
		void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
		{
			mobjData = objDescriptor as DockedHiddenZonePanelDescriptor;
		}

		/// 
		/// Resets the descriptors tree.
		/// </summary>
		/// <param name="objType">Type of the obj.</param>
		/// <param name="objDockingPosition">The obj docking position.</param>
		void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
		{
			throw new NotImplementedException();
		}

		/// 
		/// Adds the new zones.
		/// </summary>
		/// <param name="objHiddenZones">The obj hidden zones.</param>
		internal void AddNewZones(List<Zone> objHiddenZones)
		{
			foreach (Zone objHiddenZone in objHiddenZones)
			{
				if (objHiddenZone.ZoneType != ZoneType.Hidden)
				{
					throw new Exception("DockedHiddenZonesPanel.AddNewZones - Cannot accept zone of ZoneType=" + objHiddenZone.ZoneType);
				}
				DockingWindow currentWindow = objHiddenZone.CurrentWindow;
				objHiddenZone.ContainingHiddenPanel = this;
				mobjZonesIndexByWindowName.Add(currentWindow.WindowName, objHiddenZones);
				mobjZonesIndexByZoneID.Add(objHiddenZone.ID, objHiddenZone);
				objHiddenZone.InvokeParentChanged();
				base.Visible = true;
				mobjManager.UpdateHiddenPanelsDimentions();
				Update();
			}
			AllZoneGroups.Add(objHiddenZones);
			mobjData.UpdateSelf(this, mobjManager);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (Zone value in mobjZonesIndexByZoneID.Values)
			{
				RenderZoneAttributes(value, objWriter);
			}
		}

		/// 
		/// Renders the zone attributes.
		/// </summary>
		/// <param name="objZone">The obj zone.</param>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderZoneAttributes(Zone objZone, IResponseWriter objWriter)
		{
			if (objZone == null)
			{
				return;
			}
			DockingWindow currentWindow = objZone.CurrentWindow;
			if (currentWindow != null)
			{
				objWriter.WriteStartElement("DZH");
				objWriter.WriteAttributeString("DZI", objZone.ID.ToString());
				objWriter.WriteAttributeString("LEN", GetHiddenZoneItemQuareEdgeLength(currentWindow).ToString());
				objWriter.WriteAttributeString("TX", currentWindow.Text);
				if (currentWindow.Image != null)
				{
					objWriter.WriteAttributeString("IM", currentWindow.Image.ToString());
				}
				objWriter.WriteEndElement();
			}
		}

		/// 
		/// Gets the length of the hidden zone item quare edge.
		/// </summary>
		/// <param name="strItemText">The string item text.</param>
		/// </returns>
		private int GetHiddenZoneItemQuareEdgeLength(DockingWindow objDockingWindow)
		{
			DockedHiddenZonesPanelSkin dockedHiddenZonesPanelSkin = base.Skin as DockedHiddenZonesPanelSkin;
			Size stringMeasurements = CommonUtils.GetStringMeasurements(objDockingWindow.Text, dockedHiddenZonesPanelSkin.FontData);
			stringMeasurements.Width += dockedHiddenZonesPanelSkin.HiddenZoneItemStyleHorizontalPadding;
			if (objDockingWindow.Image != null)
			{
				stringMeasurements.Width += dockedHiddenZonesPanelSkin.HiddenZoneItemImageWidth;
				stringMeasurements.Height = Math.Max(stringMeasurements.Height, dockedHiddenZonesPanelSkin.HiddenZoneItemImageWidth);
			}
			return Math.Max(stringMeasurements.Width, stringMeasurements.Height);
		}

		/// 
		/// Pins the specified obj docked window.
		/// </summary>
		/// <param name="objDockedWindow">The obj docked window.</param>
		/// </returns>
		internal List<DockingWindow> RemoveAndReturnHiddenWindows(DockingWindow objDockedWindow)
		{
			List<Zone> list = mobjZonesIndexByWindowName[objDockedWindow.WindowName];
			mobjAllZoneGroups.Remove(list);
			List<DockingWindow> list2 = new List<DockingWindow>();
			Zone[] array = list.ToArray();
			Zone[] array2 = array;
			foreach (Zone zone in array2)
			{
				DockingWindow currentWindow = zone.CurrentWindow;
				mobjZonesIndexByWindowName.Remove(currentWindow.WindowName);
				RemoveSingleZoneFromPanel(zone);
				zone.RemoveWindows(currentWindow);
				list2.Add(currentWindow);
			}
			mobjData.UpdateSelf(this, mobjManager);
			return list2;
		}

		/// 
		/// Removes a single hidden zone. 
		/// </summary>
		/// <param name="objHiddenZone">The obj hidden zone.</param>
		internal void RemoveHiddenZone(Zone objHiddenZone)
		{
			DockingWindowName windowName = objHiddenZone.CurrentWindow.WindowName;
			mobjZonesIndexByWindowName[windowName].Remove(objHiddenZone);
			mobjZonesIndexByWindowName.Remove(windowName);
			objHiddenZone.RemoveWindows(objHiddenZone.CurrentWindow);
			mobjData.UpdateSelf(this, mobjManager);
			RemoveSingleZoneFromPanel(objHiddenZone);
		}

		/// 
		/// Removes the single zone from panel.
		/// </summary>
		/// <param name="objHiddenZone">The obj hidden zone.</param>
		internal void RemoveSingleZoneFromPanel(Zone objHiddenZone)
		{
			mobjZonesIndexByZoneID.Remove(objHiddenZone.ID);
			objHiddenZone.ContainingHiddenPanel = null;
			if (mobjZonesIndexByZoneID.Count == 0)
			{
				base.Visible = false;
				mobjManager.UpdateHiddenPanelsDimentions();
			}
			Update();
			objHiddenZone.InvokeParentChanged();
		}

		/// 
		/// Shows the hidden zone popup form.
		/// </summary>
		/// <param name="objZone">The obj zone.</param>
		private void ShowHiddenZonePopupForm(Zone objZone)
		{
			if (objZone == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			int top = 0;
			int left = 0;
			int num3 = 0;
			Padding dockedPanelsPadding = mobjManager.DockedPanelsPadding;
			int num4 = mobjManager.Width - dockedPanelsPadding.Left - dockedPanelsPadding.Right;
			int num5 = mobjManager.Height - dockedPanelsPadding.Top - dockedPanelsPadding.Bottom;
			DockingWindow currentWindow = objZone.CurrentWindow;
			Size size = Size.Empty;
			if (currentWindow != null)
			{
				size = currentWindow.HiddenZonePopupSize;
			}
			if (size.IsEmpty)
			{
				if (SkinFactory.GetSkin(this) is DockedHiddenZonesPanelSkin dockedHiddenZonesPanelSkin)
				{
					num3 = dockedHiddenZonesPanelSkin.HiddenZoneItemExpantionWidth;
				}
			}
			else
			{
				switch (Dock)
				{
				case DockStyle.Top:
				case DockStyle.Bottom:
					num3 = size.Height;
					break;
				case DockStyle.Right:
				case DockStyle.Left:
					num3 = size.Width;
					break;
				}
			}
			switch (Dock)
			{
			case DockStyle.Top:
				num2 = num4;
				num = ((num3 > num5) ? num5 : num3);
				top = dockedPanelsPadding.Top;
				left = dockedPanelsPadding.Left;
				break;
			case DockStyle.Bottom:
				num2 = num4;
				num = ((num3 > num5) ? num5 : num3);
				top = num5 + dockedPanelsPadding.Top - num;
				left = dockedPanelsPadding.Left;
				break;
			case DockStyle.Left:
				num2 = ((num3 > num4) ? num4 : num3);
				num = num5;
				top = dockedPanelsPadding.Top;
				left = dockedPanelsPadding.Left;
				break;
			case DockStyle.Right:
				num2 = ((num3 > num4) ? num4 : num3);
				num = num5;
				top = dockedPanelsPadding.Top;
				left = num4 + dockedPanelsPadding.Left - num2;
				break;
			}
			HiddenZonePopupForm hiddenZonePopupForm = new HiddenZonePopupForm();
			hiddenZonePopupForm.Size = new Size(num2, num);
			hiddenZonePopupForm.StartPosition = FormStartPosition.Manual;
			hiddenZonePopupForm.Top = top;
			hiddenZonePopupForm.Left = left;
			hiddenZonePopupForm.Load += HiddenZonePopupForm_Load;
			hiddenZonePopupForm.Closed += HiddenZonePopupForm_Closed;
			hiddenZonePopupForm.ContainedZone = objZone;
			objZone.ZonePopupForm = hiddenZonePopupForm;
			hiddenZonePopupForm.Controls.Add(objZone);
			hiddenZonePopupForm.ShowPopup(mobjManager, DialogAlignment.Custom);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "ShowZonePopUp" && long.TryParse(objEvent["ZoneId"], out var result) && mobjZonesIndexByZoneID.TryGetValue(result, out var value))
			{
				ShowHiddenZonePopupForm(value);
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Handles the Load event of the zone pop up form.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void HiddenZonePopupForm_Load(object sender, EventArgs e)
		{
			if (sender is HiddenZonePopupForm { ContainedZone: not null } hiddenZonePopupForm)
			{
				InvokeMethodInternal("DockedHiddenZonesPanel_OnZonePopUpFormLoad", ID.ToString(), hiddenZonePopupForm.ContainedZone.ID.ToString());
			}
		}

		/// 
		/// Handles the Closed event of the zone pop up form.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void HiddenZonePopupForm_Closed(object sender, EventArgs e)
		{
			if (sender is HiddenZonePopupForm { ContainedZone: not null } hiddenZonePopupForm)
			{
				InvokeMethodInternal("DockedHiddenZonesPanel_OnZonePopUpFormClosed", ID.ToString(), hiddenZonePopupForm.ContainedZone.ID.ToString());
			}
		}
	}
}
