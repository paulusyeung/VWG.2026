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
	/// Provides a menu system for a form.</summary>
	/// 1</filterpriority>
	[Serializable]
	[MetadataTag("MSP")]
	[Skin(typeof(MenuStripSkin))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[SRDescription("DescriptionMenuStrip")]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(StatusStrip), "MenuStrip_45.bmp")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.MenuStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class MenuStrip : ToolStrip
	{
		/// 
		///
		/// </summary>
		private static readonly SerializableProperty mblnShowDropDownItemsOnEnterProperty = SerializableProperty.Register("mblnShowDropDownItemsOnEnter", typeof(bool), typeof(MenuStrip), new SerializablePropertyMetadata(false));

		/// 
		/// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.
		/// </summary>
		/// </value>
		/// An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.MenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public override ToolStripItemCollection Items => base.Items;

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.MenuStrip"></see> supports overflow functionality. </summary>
		/// true if the <see cref="T:System.Windows.Forms.MenuStrip"></see> supports overflow functionality; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[SRDescription("ToolStripCanOverflowDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(false)]
		public new bool CanOverflow
		{
			get
			{
				return base.CanOverflow;
			}
			set
			{
				base.CanOverflow = value;
			}
		}

		/// Gets the default spacing, in pixels, between the sizing grip and the edges of the <see cref="T:System.Windows.Forms.MenuStrip"></see>.</summary>
		/// <see cref="T:System.Windows.Forms.Padding"></see> values representing the spacing, in pixels.</returns>
		protected override Padding DefaultGripMargin => new Padding(2, 2, 0, 2);

		/// Gets the spacing, in pixels, between the left, right, top, and bottom edges of the <see cref="T:System.Windows.Forms.MenuStrip"></see> from the edges of the form.</summary>
		/// A <see cref="T:System.Windows.Forms.Padding"></see> that represents the spacing. The default is {Left=6, Top=2, Right=0, Bottom=2}.</returns>
		protected override Padding DefaultPadding
		{
			get
			{
				if (base.Skin is MenuStripSkin menuStripSkin)
				{
					if (GripStyle == ToolStripGripStyle.Visible)
					{
						return menuStripSkin.PaddingWithGrip;
					}
					return menuStripSkin.PaddingWithOutGrip;
				}
				if (GripStyle == ToolStripGripStyle.Visible)
				{
					return new Padding(3, 2, 0, 2);
				}
				return new Padding(6, 2, 0, 2);
			}
		}

		/// 
		/// Gets a value indicating whether strip supports menu stickiness.
		/// </summary>
		/// true</c> if [supports stickiness]; otherwise, false</c>.</value>
		protected override bool SupportMenuStickiness => true;

		/// 
		/// Gets or sets a value indicating whether [show items drop down on enter].
		/// </summary>
		/// 
		/// 	true</c> if [show items drop down on enter]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool ShowDropDownItemsOnEnter
		{
			get
			{
				return mblnShowDropDownItemsOnEnter;
			}
			set
			{
				if (mblnShowDropDownItemsOnEnter != value)
				{
					mblnShowDropDownItemsOnEnter = value;
					UpdateParams(AttributeType.Extended);
				}
			}
		}

		/// Gets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see> by default.</summary>
		/// false in all cases.</returns>
		protected override bool DefaultShowItemToolTips => false;

		/// Gets the horizontal and vertical dimensions, in pixels, of the <see cref="T:System.Windows.Forms.MenuStrip"></see> when it is first created.</summary>
		/// A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> value representing the <see cref="T:System.Windows.Forms.MenuStrip"></see> horizontal and vertical dimensions, in pixels. The default is 200 x 21 pixels.</returns>
		protected override Size DefaultSize => new Size(200, 24);

		/// Gets or sets the visibility of the grip used to reposition the control.</summary>
		/// One of the <see cref="T:System.Windows.Forms.ToolStripGripStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ToolStripGripStyle.Hidden"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(ToolStripGripStyle.Hidden)]
		public new ToolStripGripStyle GripStyle
		{
			get
			{
				return base.GripStyle;
			}
			set
			{
				base.GripStyle = value;
			}
		}

		/// Gets or sets the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> that is used to display a list of Multiple-document interface (MDI) child forms.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> that represents the menu item displaying a list of MDI child forms that are open in the application.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripMenuItem MdiWindowListItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see>. </summary>
		/// true if ToolTips are shown for the <see cref="T:System.Windows.Forms.MenuStrip"></see>; otherwise, false. The default is false.</returns>
		[SRDescription("ToolStripShowItemToolTipsDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public new bool ShowItemToolTips
		{
			get
			{
				return base.ShowItemToolTips;
			}
			set
			{
				base.ShowItemToolTips = value;
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.MenuStrip"></see> stretches from end to end in its container. </summary>
		/// true if the <see cref="T:System.Windows.Forms.MenuStrip"></see> stretches from end to end in its container; otherwise, false. The default is true.</returns>
		[SRDescription("ToolStripStretchDescr")]
		[DefaultValue(true)]
		[SRCategory("CatLayout")]
		public new bool Stretch
		{
			get
			{
				return base.Stretch;
			}
			set
			{
				base.Stretch = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [MBLN show items drop down on enter].
		/// </summary>
		/// 
		/// 	true</c> if [MBLN show items drop down on enter]; otherwise, false</c>.
		/// </value>
		private bool mblnShowDropDownItemsOnEnter
		{
			get
			{
				return GetValue(mblnShowDropDownItemsOnEnterProperty);
			}
			set
			{
				SetValue(mblnShowDropDownItemsOnEnterProperty, value);
			}
		}

		/// Occurs when the user accesses the menu with the keyboard or mouse. </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler MenuActivate;

		/// Occurs when the <see cref="T:System.Windows.Forms.MenuStrip"></see> is deactivated.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler MenuDeactivate;

		/// Initializes a new instance of the <see cref="T:System.Windows.Forms.MenuStrip"></see> class. </summary>
		public MenuStrip()
		{
			CanOverflow = false;
			GripStyle = ToolStripGripStyle.Hidden;
			Stretch = true;
		}

		/// Creates a <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="M:System.Windows.Forms.ToolStripMenuItem.#ctor(System.String,System.Drawing.Image,System.EventHandler)"></see>, or a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see> if the text parameter is a hyphen (-).</returns>
		/// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event when the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> is clicked.</param>
		/// <param name="image">The <see cref="T:System.Drawing.Image"></see> to display on the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>.</param>
		/// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>. If the text parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see>.</param>
		protected internal override ToolStripItem CreateDefaultItem(string text, ResourceHandle image, EventHandler onClick)
		{
			if (text == "-")
			{
				return new ToolStripSeparator();
			}
			return new ToolStripMenuItem(text, image, onClick);
		}

		/// Raises the <see cref="E:System.Windows.Forms.MenuStrip.MenuActivate"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMenuActivate(EventArgs e)
		{
		}

		/// Raises the <see cref="E:System.Windows.Forms.MenuStrip.MenuDeactivate"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMenuDeactivate(EventArgs e)
		{
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderShowDropDownItemsOnEnterAttribute(objWriter, blnForceRender: false);
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Extended))
			{
				RenderShowDropDownItemsOnEnterAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the show items drop down on enter attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowDropDownItemsOnEnterAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool showDropDownItemsOnEnter = ShowDropDownItemsOnEnter;
			if (showDropDownItemsOnEnter || blnForceRender)
			{
				objWriter.WriteAttributeString("SDOE", showDropDownItemsOnEnter ? "1" : "0");
			}
		}
	}
}
