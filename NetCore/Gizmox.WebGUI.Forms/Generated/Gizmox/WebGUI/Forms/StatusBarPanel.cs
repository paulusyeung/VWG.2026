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
	/// Represents a panel in a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control. Although the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> control replaces and adds functionality to the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control of previous versions, <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> is retained for both backward compatibility and future use if you choose.
	/// </summary>
	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultProperty("Text")]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	public class StatusBarPanel : Component, ISupportInitialize
	{
		private StatusBarPanelAutoSize menmAutoSize = StatusBarPanelAutoSize.None;

		private HorizontalAlignment menmAlignment = HorizontalAlignment.Left;

		private string mstrText = "";

		private int mintWidth = 100;

		/// 
		/// Gets or sets the width of the status bar panel within the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.
		/// </summary>
		/// The width, in pixels, of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The width specified is less than the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.MinWidth"></see> property. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[SRDescription("StatusBarPanelWidthDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(100)]
		public int Width
		{
			get
			{
				return mintWidth;
			}
			set
			{
				if (mintWidth != value)
				{
					mintWidth = value;
					FireObservableItemPropertyChanged("Width");
					UpdateStatusBar();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the status bar panel is automatically resized.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> values. The default is<see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.None"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned to the property is not a member of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> enumeration. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(1)]
		[SRCategory("CatAppearance")]
		[SRDescription("StatusBarPanelAutoSizeDescr")]
		[RefreshProperties(RefreshProperties.All)]
		public StatusBarPanelAutoSize AutoSize
		{
			get
			{
				return menmAutoSize;
			}
			set
			{
				if (menmAutoSize != value)
				{
					menmAutoSize = value;
					FireObservableItemPropertyChanged("AutoSize");
					UpdateStatusBar();
				}
			}
		}

		/// 
		/// Gets or sets the alignment of text and icons within the status bar panel.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values. The default is<see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned to the property is not a member of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> enumeration. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("StatusBarPanelAlignmentDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(HorizontalAlignment.Left)]
		[Localizable(true)]
		public HorizontalAlignment Alignment
		{
			get
			{
				return menmAlignment;
			}
			set
			{
				if (menmAlignment != value)
				{
					menmAlignment = value;
					FireObservableItemPropertyChanged("Alignment");
					Update();
				}
			}
		}

		/// 
		/// Gets the owner status bar.
		/// </summary>
		/// The owner status bar.</value>
		private StatusBar OwnerStatusBar => InternalParent as StatusBar;

		/// 
		/// Gets or sets the text of the status bar panel.
		/// </summary>
		/// The text displayed in the panel.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[SRDescription("StatusBarPanelTextDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue("")]
		public string Text
		{
			get
			{
				return mstrText;
			}
			set
			{
				if (mstrText != value)
				{
					mstrText = value;
					FireObservableItemPropertyChanged("Text");
					Update();
				}
			}
		}

		/// Gets or sets the minimum allowed width of the status bar panel within the <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> control.</summary>
		/// The minimum width, in pixels, of the <see cref="T:Gizmox.WebGui.Forms.StatusBarPanel"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">A value less than 0 is assigned to the property. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("StatusBarPanelMinWidthDescr")]
		[DefaultValue(10)]
		[RefreshProperties(RefreshProperties.All)]
		public int MinWidth
		{
			get
			{
				return 10;
			}
			set
			{
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> control that hosts the status bar panel.</summary>
		/// The <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> that contains the panel.</returns>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("StatusBarPanelNameDescr")]
		public string Name
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> class.
		/// </summary>
		public StatusBarPanel()
		{
		}

		/// 
		/// Updates the containing status bar.
		/// </summary>
		private void UpdateStatusBar()
		{
			OwnerStatusBar?.Update();
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			StatusBar ownerStatusBar = OwnerStatusBar;
			if (ownerStatusBar != null)
			{
				criticalEventsData.Set(ownerStatusBar.GetStatusBarCriticalEventsData());
			}
			return criticalEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			OwnerStatusBar?.FireStatusBarEvent(objEvent);
		}

		/// 
		/// Renders the panel.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		internal void RenderPanel(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (!IsDirty(lngRequestID))
			{
				return;
			}
			objWriter.WriteStartElement("SP");
			RegisterSelf();
			RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);
			if (menmAlignment != HorizontalAlignment.Left)
			{
				objWriter.WriteAttributeString("HA", menmAlignment.ToString());
			}
			if (InternalParent is StatusBar statusBar)
			{
				if (statusBar.Font != Control.DefaultFont)
				{
					objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(statusBar.Font));
				}
				if (statusBar.BackColor != statusBar.DefaultBackColorInternal)
				{
					objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(statusBar.BackColor));
				}
				if (statusBar.ForeColor != statusBar.DefaultForeColorInternal)
				{
					objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(statusBar.ForeColor));
				}
			}
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			objWriter.WriteAttributeString("AS", ((int)AutoSize).ToString());
			objWriter.WriteAttributeString("W", Width.ToString());
			objWriter.WriteEndElement();
		}

		/// 
		///
		/// </summary>
		public void BeginInit()
		{
		}

		/// 
		///
		/// </summary>
		public void EndInit()
		{
		}
	}
}
