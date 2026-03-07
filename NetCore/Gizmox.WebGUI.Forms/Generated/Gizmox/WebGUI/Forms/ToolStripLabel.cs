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
	/// Represents a nonselectable <see cref="T:System.Windows.Forms.ToolStripItem"></see> that renders text and images and can display hyperlinks.</summary>
	[Serializable]
	[Skin(typeof(ToolStripLabelSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripLabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
	public class ToolStripLabel : ToolStripItem
	{
		private static readonly SerializableProperty mblnIsLinkProperty = SerializableProperty.Register("mblnIsLink", typeof(bool), typeof(ToolStripLabel));

		private bool mblnIsLink
		{
			get
			{
				return GetValue(mblnIsLinkProperty);
			}
			set
			{
				SetValue(mblnIsLinkProperty, value);
			}
		}

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 1;

		/// Gets or sets the color used to display an active link.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color to display an active link. The default color is specified by the system. Typically, this color is Color.Red.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ActiveLinkColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets a value indicating the selectable state of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
		/// false in all cases.</returns> 
		/// 1</filterpriority>
		public override bool CanSelect
		{
			get
			{
				if (!IsLink)
				{
					return base.DesignMode;
				}
				return true;
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is a hyperlink. </summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> is a hyperlink; otherwise, false. The default is false.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("ToolStripLabelIsLinkDescr")]
		public bool IsLink
		{
			get
			{
				return mblnIsLink;
			}
			set
			{
				if (mblnIsLink != value)
				{
					mblnIsLink = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets a value that represents the behavior of a link.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.LinkBehavior"></see> values. The default is LinkBehavior.SystemDefault.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public LinkBehavior LinkBehavior
		{
			get
			{
				return LinkBehavior.AlwaysUnderline;
			}
			set
			{
			}
		}

		/// Gets or sets the color used when displaying a normal link.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to displaying a normal link. The default color is specified by the system. Typically, this color is Color.Blue.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color LinkColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether a link should be displayed as though it were visited.</summary> 
		/// true if links should display as though they were visited; otherwise, false. The default is false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool LinkVisited
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets the color used when displaying a link that that has been previously visited.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to display links that have been visited. The default color is specified by the system. Typically, this color is Color.Purple.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color VisitedLinkColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class.</summary>
		public ToolStripLabel()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text to display.</summary> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
		public ToolStripLabel(string text)
			: base(text, null, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the image to display.</summary> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
		public ToolStripLabel(ResourceHandle image)
			: base(null, image, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display.</summary> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
		public ToolStripLabel(string text, ResourceHandle image)
			: base(text, image, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display and whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link.</summary> 
		/// <param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
		public ToolStripLabel(string text, ResourceHandle image, bool isLink)
			: this(text, image, isLink, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display, whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link, and providing a <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</summary> 
		/// <param name="onClick">A <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</param> 
		/// <param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
		public ToolStripLabel(string text, ResourceHandle image, bool isLink, EventHandler onClick)
			: this(text, image, isLink, null, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> class, specifying the text and image to display, whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link, and providing a <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler and name for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
		/// <param name="onClick">A <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event handler.</param> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
		/// <param name="isLink">true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see> acts as a link; otherwise, false. </param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</param>
		public ToolStripLabel(string text, ResourceHandle image, bool isLink, EventHandler onClick, string name)
			: base(text, image, null, null)
		{
			IsLink = isLink;
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fit.
		/// </summary>
		/// <param name="objConstrainingSize">The custom-sized area for a control.</param>
		/// 
		/// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
		/// </returns>
		/// 
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   </PermissionSet>
		public override Size GetPreferredSize(Size objConstrainingSize)
		{
			return base.GetPreferredSizeByImage(GetPreferredeSizeByText());
		}

		/// 
		/// Renders the tool strip item's attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
		{
			base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
			RenderTextAttributes(objAttributeWriter, blnForceRender: false);
			RenderLinkStateAttribute(objAttributeWriter, blnForceRender: false);
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
				RenderTextAttributes(objAttributeWriter, blnForceRender: true);
				RenderLinkStateAttribute(objAttributeWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the text attributes.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderTextAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (!base.ShouldRenderText)
			{
				return;
			}
			string text = Text;
			if (!string.IsNullOrEmpty(text) || blnForceRender)
			{
				objAttributeWriter.WriteAttributeText("VLB", text);
				if (IsLink)
				{
					objAttributeWriter.WriteAttributeText("TX", text);
				}
			}
		}

		/// 
		/// Renders the link state attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderLinkStateAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			bool isLink = IsLink;
			if (isLink || blnForceRender)
			{
				objAttributeWriter.WriteAttributeText("LS", isLink ? "1" : "0");
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeActiveLinkColor()
		{
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeLinkColor()
		{
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeVisitedLinkColor()
		{
			return false;
		}
	}
}
