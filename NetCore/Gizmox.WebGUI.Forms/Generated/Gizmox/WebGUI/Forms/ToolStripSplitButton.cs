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
/// Represents a combination of a standard button on the left and a drop-down button on the right, or the other way around if the value of <see cref="T:System.Windows.Forms.RightToLeft"></see> is Yes.</summary>
	[Serializable]
	[DefaultEvent("ButtonClick")]
	[Skin(typeof(ToolStripSplitButtonSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability((ToolStripItemDesignerAvailability)9)]
	public class ToolStripSplitButton : ToolStripDropDownItem
	{
		private static readonly SerializableEvent ButtonClickEvent;

		private static readonly SerializableEvent ButtonDoubleClickEvent;

		private static readonly SerializableEvent DefaultItemChangedEvent;

		/// 
		/// Gets the ButtonClick handler.
		/// </summary>
		/// The ButtonClick handler.</value>
		private EventHandler ButtonClickHandler => (EventHandler)GetHandler(ButtonClick);

		/// 
		/// Gets the ButtonDoubleClick handler.
		/// </summary>
		/// The ButtonDoubleClick handler.</value>
		private EventHandler ButtonDoubleClickHandler => (EventHandler)GetHandler(ButtonDoubleClick);

		/// 
		/// Gets the DefaultItemChanged handler.
		/// </summary>
		/// The DefaultItemChanged handler.</value>
		private EventHandler DefaultItemChangedHandler => (EventHandler)GetHandler(DefaultItemChanged);

		/// Gets or sets a value indicating whether default or custom <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
		/// true if default <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		public new bool AutoToolTip
		{
			get
			{
				return base.AutoToolTip;
			}
			set
			{
				base.AutoToolTip = value;
			}
		}

		/// Gets the size and location of the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ButtonBounds => Rectangle.Empty;

		/// Gets a value indicating whether the button portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state. </summary> 
		/// true if the button portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state; otherwise, false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ButtonPressed => false;

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 2;

		/// Gets a value indicating whether the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DropDownButtonPressed"></see> property is true.</summary> 
		/// true if the button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected or whether <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DropDownButtonPressed"></see> is true; otherwise, false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool ButtonSelected => false;

		/// Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default. </summary> 
		/// true in all cases.</returns>
		protected override bool DefaultAutoToolTip => true;

		/// Gets or sets the portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> that is activated when the control is first selected.</summary> 
		/// A Forms.ToolStripItem representing the portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> that is activated when first selected. The default value is null.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripItem DefaultItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets the size and location, in screen coordinates, of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>, in screen coordinates.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Rectangle DropDownButtonBounds => Rectangle.Empty;

		/// Gets a value indicating whether the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state. </summary> 
		/// true if the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state; otherwise, false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool DropDownButtonPressed => base.DropDown.Visible;

		/// Gets a value indicating whether the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected.</summary> 
		/// true if the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool DropDownButtonSelected => false;

		/// The width, in pixels, of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
		/// An <see cref="T:System.Int32"></see> representing the width in pixels.</returns> 
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value is less than zero (0). </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DropDownButtonWidth
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		/// Gets the boundaries of the separator between the standard and drop-down button portions of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the separator.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Rectangle SplitterBounds => Rectangle.Empty;

		/// Occurs when the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is clicked.</summary> 
		/// 1</filterpriority>
		public event EventHandler ButtonClick
		{
			add
			{
				AddCriticalHandler(ButtonClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ButtonClickEvent, value);
			}
		}

		/// Occurs when the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is double-clicked.</summary> 
		/// 1</filterpriority>
		public event EventHandler ButtonDoubleClick
		{
			add
			{
				AddCriticalHandler(ButtonDoubleClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ButtonDoubleClickEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DefaultItem"></see> has changed.</summary> 
		/// 1</filterpriority>
		public event EventHandler DefaultItemChanged
		{
			add
			{
				AddCriticalHandler(DefaultItemChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DefaultItemChangedEvent, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class.</summary>
		public ToolStripSplitButton()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text. </summary> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
		public ToolStripSplitButton(string text)
			: base(text, (ResourceHandle)null, (EventHandler)null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified image. </summary> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
		public ToolStripSplitButton(ResourceHandle image)
			: base((string)null, image, (EventHandler)null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text and image.</summary> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
		public ToolStripSplitButton(string text, ResourceHandle image)
			: base(text, image, (EventHandler)null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified display text, image, and <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event handler.</summary> 
		/// <param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
		public ToolStripSplitButton(string text, ResourceHandle image, EventHandler onClick)
			: base(text, image, onClick)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified display text, image, <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event handler, and name.</summary> 
		/// <param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
		public ToolStripSplitButton(string text, ResourceHandle image, EventHandler onClick, string name)
			: base(text, image, onClick, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text, image, and <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> array.</summary> 
		/// <param name="dropDownItems">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> array of controls.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
		public ToolStripSplitButton(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
			: base(text, image, dropDownItems)
		{
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objConstrainingSize">Size of the obj constraining.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objConstrainingSize)
		{
			Size preferredeSizeByText = GetPreferredeSizeByText();
			ToolStripSplitButtonSkin toolStripSplitButtonSkin = SkinFactory.GetSkin(this) as ToolStripSplitButtonSkin;
			if (toolStripSplitButtonSkin != null)
			{
				preferredeSizeByText.Width = preferredeSizeByText.Width + toolStripSplitButtonSkin.DropDownImageWidth + toolStripSplitButtonSkin.DropDownImageContainerStyle.Border.Width.Left + toolStripSplitButtonSkin.DropDownImageContainerStyle.Border.Width.Right;
			}
			preferredeSizeByText = base.GetPreferredSizeByImage(preferredeSizeByText);
			return GetPreferredSizeByButtonSkin(toolStripSplitButtonSkin, preferredeSizeByText);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (base.DropDownItems.Count > 0)
			{
				criticalEventsData.Set("EXP");
			}
			return criticalEventsData;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.ButtonClick"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnButtonClick(EventArgs e)
		{
			ButtonClickHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.ButtonDoubleClick"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public virtual void OnButtonDoubleClick(EventArgs e)
		{
			ButtonDoubleClickHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.DefaultItemChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDefaultItemChanged(EventArgs e)
		{
			DefaultItemChangedHandler?.Invoke(this, e);
		}

		/// If the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Enabled"></see> property is true, calls the <see cref="M:Gizmox.WebGUI.Forms.ToolStripSplitButton.OnButtonClick(System.EventArgs)"></see> method.</summary>
		public void PerformButtonClick()
		{
			if (Enabled && base.Available)
			{
				PerformClick();
				OnButtonClick(EventArgs.Empty);
			}
		}

		/// This method is not relevant to this class.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Always)]
		public virtual void ResetDropDownButtonWidth()
		{
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "DropDown")
			{
				MouseEventArgs mouseEventArgs = GetMouseEventArgs(objEvent);
				if (mouseEventArgs.Button == MouseButtons.Left)
				{
					ShowDropDown();
				}
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DoubleClick"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			OnButtonDoubleClick(new EventArgs());
		}

		static ToolStripSplitButton()
		{
			ButtonClickEvent = SerializableEvent.Register("ButtonClick", typeof(EventHandler), typeof(ToolStripSplitButton));
			ButtonDoubleClickEvent = SerializableEvent.Register("ButtonDoubleClick", typeof(EventHandler), typeof(ToolStripSplitButton));
			DefaultItemChanged = SerializableEvent.Register("DefaultItemChanged", typeof(EventHandler), typeof(ToolStripSplitButton));
		}
	}
}
