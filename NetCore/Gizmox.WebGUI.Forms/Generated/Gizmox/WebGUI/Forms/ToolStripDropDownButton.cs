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
	/// Represents a control that when clicked displays an associated <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> from which the user can select a single item.</summary>
	[Serializable]
	[Skin(typeof(ToolStripDropDownButtonSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability((ToolStripItemDesignerAvailability)9)]
	public class ToolStripDropDownButton : ToolStripDropDownItem
	{
		private static readonly SerializableProperty mblnShowDropDownArrowProperty = SerializableProperty.Register("mblnShowDropDownArrow", typeof(bool), typeof(ToolStripDropDownButton));

		private bool mblnShowDropDownArrow
		{
			get
			{
				return GetValue(mblnShowDropDownArrowProperty);
			}
			set
			{
				SetValue(mblnShowDropDownArrowProperty, value);
			}
		}

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 3;

		/// Gets or sets a value indicating whether to use the Text property or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ToolTipText"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> ToolTip.</summary> 
		/// true to use the <see cref="P:Gizmox.WebGUI.Forms.Control.Text"></see> property for the ToolTip; otherwise, false. The default is true.</returns>
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

		/// Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default.</summary> 
		/// true in all cases.</returns>
		protected override bool DefaultAutoToolTip => true;

		/// Gets or sets a value indicating whether an arrow is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>, which indicates that further options are available in a drop-down list.</summary> 
		/// true to show an arrow on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripDropDownButtonShowDropDownArrowDescr")]
		[DefaultValue(true)]
		public bool ShowDropDownArrow
		{
			get
			{
				return mblnShowDropDownArrow;
			}
			set
			{
				if (mblnShowDropDownArrow != value)
				{
					mblnShowDropDownArrow = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class. </summary>
		public ToolStripDropDownButton()
		{
			mblnShowDropDownArrow = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text.</summary> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
		public ToolStripDropDownButton(string text)
			: base(text, (ResourceHandle)null, (EventHandler)null)
		{
			mblnShowDropDownArrow = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified image.</summary> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
		public ToolStripDropDownButton(ResourceHandle image)
			: base((string)null, image, (EventHandler)null)
		{
			mblnShowDropDownArrow = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text and image.</summary> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
		public ToolStripDropDownButton(string text, ResourceHandle image)
			: base(text, image, (EventHandler)null)
		{
			mblnShowDropDownArrow = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that displays the specified text and image and raises the Click event.</summary> 
		/// <param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event.</param> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
		public ToolStripDropDownButton(string text, ResourceHandle image, EventHandler onClick)
			: base(text, image, onClick)
		{
			mblnShowDropDownArrow = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class that has the specified name, displays the specified text and image, and raises the Click event.</summary> 
		/// <param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event.</param> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
		public ToolStripDropDownButton(string text, ResourceHandle image, EventHandler onClick, string name)
			: base(text, image, onClick, null)
		{
			mblnShowDropDownArrow = true;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see> class.</summary> 
		/// <param name="dropDownItems">An array of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> containing the items of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
		/// <param name="image">An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param> 
		/// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownButton"></see>.</param>
		public ToolStripDropDownButton(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
			: base(text, image, dropDownItems)
		{
			mblnShowDropDownArrow = true;
		}

		/// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.MouseDown"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			ShowDropDown();
			base.OnMouseDown(e);
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objConstrainingSize">Size of the obj constraining.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objConstrainingSize)
		{
			Size preferredeSizeByText = GetPreferredeSizeByText();
			ButtonSkin buttonSkin = SkinFactory.GetSkin(this) as ButtonSkin;
			if (buttonSkin != null && ShowDropDownArrow)
			{
				preferredeSizeByText.Width += buttonSkin.DropDownImageWidth;
				preferredeSizeByText.Height = Math.Max(preferredeSizeByText.Height, buttonSkin.DropDownImageHeight);
			}
			preferredeSizeByText = base.GetPreferredSizeByImage(preferredeSizeByText);
			return GetPreferredSizeByButtonSkin(buttonSkin, preferredeSizeByText);
		}

		/// 
		/// Renders the tool strip item's attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
		{
			base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
			RenderShowDropDownArrowAttribute(objAttributeWriter, blnForceRender: false);
		}

		/// 
		/// Renders the tool strip item updated attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
		{
			base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderShowDropDownArrowAttribute(objAttributeWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the show drop down arrow attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowDropDownArrowAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			bool showDropDownArrow = ShowDropDownArrow;
			if (!showDropDownArrow || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("SDA", showDropDownArrow ? "1" : "0");
			}
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
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}
	}
}
