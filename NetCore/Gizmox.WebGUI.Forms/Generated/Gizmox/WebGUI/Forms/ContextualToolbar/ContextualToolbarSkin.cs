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

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
	/// 
	/// Summary description for ContextualToolbarSkin
	/// </summary>   
	[Serializable]
	public class ContextualToolbarSkin : FormSkin
	{
		/// 
		///
		/// </summary>
		[Serializable]
		public class ContextualToolbarButtonSkinValue : StyleValue
		{
			/// 
			/// Gets or sets the size of the contextual toolbar.
			/// </summary>
			/// 
			/// The size of the contextual toolbar.
			/// </value>
			public virtual Size ContextualToolbarButtonSize
			{
				get
				{
					return GetValue("ContextualToolbarButtonSize", new Size(32, 32));
				}
				set
				{
					SetValue("ContextualToolbarButtonSize", value);
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.StyleValue" /> class.
			/// </summary>
			/// <param name="objPropertyOwner">The property owner.</param>
			/// <param name="strPropertyPrefix">The property prefix.</param>
			public ContextualToolbarButtonSkinValue(CommonSkin objPropertyOwner, string strPropertyPrefix)
				: base(objPropertyOwner, strPropertyPrefix)
			{
			}
		}

		/// 
		/// Gets or sets the contextual toolbar font.
		/// </summary>
		/// 
		/// The contextual toolbar font.
		/// </value>
		[SRDescription("The contextual image font button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarFont
		{
			get
			{
				return GetValue("ContextualToolbarFont", null);
			}
			set
			{
				SetValue("ContextualToolbarFont", value);
			}
		}

		/// 
		/// Gets or sets the color of the contextual toolbar fore.
		/// </summary>
		/// 
		/// The color of the contextual toolbar fore.
		/// </value>
		[SRDescription("The contextual image forecolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarForeColor
		{
			get
			{
				return GetValue("ContextualToolbarForeColor", null);
			}
			set
			{
				SetValue("ContextualToolbarForeColor", value);
			}
		}

		/// 
		/// Gets or sets the color of the contextual toolbar fore.
		/// </summary>
		/// 
		/// The color of the contextual toolbar fore.
		/// </value>
		[SRDescription("The contextual image backcolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarBackColor
		{
			get
			{
				return GetValue("ContextualToolbarBackColor", null);
			}
			set
			{
				SetValue("ContextualToolbarBackColor", value);
			}
		}

		/// 
		/// Gets or sets the contextual toolbar dock.
		/// </summary>
		/// 
		/// The contextual toolbar dock.
		/// </value>
		[SRDescription("The contextual image forecolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarDock
		{
			get
			{
				return GetValue("ContextualToolbarDock", null);
			}
			set
			{
				SetValue("ContextualToolbarDock", value);
			}
		}

		/// 
		/// Gets or sets the contextual toolbar dock.
		/// </summary>
		/// 
		/// The contextual toolbar dock.
		/// </value>
		[SRDescription("The contextual image forecolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarDelete
		{
			get
			{
				return GetValue("ContextualToolbarDelete", null);
			}
			set
			{
				SetValue("ContextualToolbarDelete", value);
			}
		}

		/// 
		/// Gets or sets the contextual toolbar action.
		/// </summary>
		/// 
		/// The contextual toolbar dock.
		/// </value>
		[SRDescription("The contextual image forecolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarActions
		{
			get
			{
				return GetValue("ContextualToolbarActions", null);
			}
			set
			{
				SetValue("ContextualToolbarActions", value);
			}
		}

		/// 
		/// Gets or sets the contextual toolbar dock.
		/// </summary>
		/// 
		/// The contextual toolbar dock.
		/// </value>
		[SRDescription("The contextual image forecolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarAnchor
		{
			get
			{
				return GetValue("ContextualToolbarAnchor", null);
			}
			set
			{
				SetValue("ContextualToolbarAnchor", value);
			}
		}

		/// 
		/// Gets or sets the contextual toolbar visual templates.
		/// </summary>
		/// 
		/// The contextual toolbar dock.
		/// </value>
		[SRDescription("The contextual image forecolor button image.")]
		[SRCategory("Images")]
		public virtual ImageResourceReference ContextualToolbarVisualTemplates
		{
			get
			{
				return GetValue("ContextualToolbarVisualTemplates", null);
			}
			set
			{
				SetValue("ContextualToolbarVisualTemplates", value);
			}
		}

		/// 
		/// Gets or sets the size of the contextual toolbar.
		/// </summary>
		/// 
		/// The size of the contextual toolbar.
		/// </value>
		public virtual Size ContextualToolbarSize
		{
			get
			{
				return GetValue("ContextualToolbarSize", new Size(150, 38));
			}
			set
			{
				SetValue("ContextualToolbarSize", value);
			}
		}

		/// 
		/// Gets the contextual toolbar container LTR style.
		/// </summary>
		/// 
		/// The contextual toolbar container LTR style.
		/// </value>
		[SRDescription("Sets the buttons container style of the contextualtoolbar.")]
		public StyleValue ContextualToolbarContainerLTRStyle => new StyleValue(this, "ContextualToolbarContainerLTRStyle");

		/// 
		/// Gets the contextual toolbar container RTL style.
		/// </summary>
		/// 
		/// The contextual toolbar container RTL style.
		/// </value>
		[SRDescription("Sets the buttons container style of the contextualtoolbar.")]
		public StyleValue ContextualToolbarContainerRTLStyle => new StyleValue(this, "ContextualToolbarContainerRTLStyle");

		/// 
		/// Gets the contextual toolbar container.
		/// </summary>
		/// 
		/// The contextual toolbar container.
		/// </value>
		public BidirectionalSkinValue<object> ContextualToolbarContainer => new BidirectionalSkinValue<object>(this, ContextualToolbarContainerLTRStyle, ContextualToolbarContainerRTLStyle);

		/// 
		/// Gets the contextual toolbar container style.
		/// </summary>
		/// 
		/// The contextual toolbar container.
		/// </value>
		[SRDescription("Sets a single button style.")]
		public ContextualToolbarButtonSkinValue ContextualToolbarButton => new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButton");

		/// 
		/// Gets the contextual toolbar container style.
		/// </summary>
		/// 
		/// The contextual toolbar container.
		/// </value>
		[SRDescription("Sets a single button LTR style.")]
		public ContextualToolbarButtonSkinValue ContextualToolbarButtonFirstLTRStyle => new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButtonFirstLTRStyle");

		/// 
		/// Gets the contextual toolbar button first RTL style.
		/// </summary>
		/// 
		/// The contextual toolbar button first RTL style.
		/// </value>
		[SRDescription("Sets a single button RTL style.")]
		public ContextualToolbarButtonSkinValue ContextualToolbarButtonFirstRTLStyle => new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButtonFirstRTLStyle");

		/// 
		/// Gets the contextual toolbar button first.
		/// </summary>
		/// 
		/// The contextual toolbar button first.
		/// </value>
		public BidirectionalSkinValue<object> ContextualToolbarButtonFirst => new BidirectionalSkinValue<object>(this, ContextualToolbarButtonFirstLTRStyle, ContextualToolbarButtonFirstRTLStyle);

		/// 
		/// Gets the contextual toolbar container style.
		/// </summary>
		/// 
		/// The contextual toolbar container.
		/// </value>
		[SRDescription("Sets a single button style.")]
		public ContextualToolbarButtonSkinValue ContextualToolbarButtonHover => new ContextualToolbarButtonSkinValue(this, "ContextualToolbarButtonHover");

		/// 
		/// Gets the width of the contextual toolbar button.
		/// </summary>
		/// 
		/// The width of the contextual toolbar button.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public int ContextualToolbarButtonWidth => ContextualToolbarButton.ContextualToolbarButtonSize.Width;

		/// 
		/// Gets the height of the contextual toolbar button.
		/// </summary>
		/// 
		/// The height of the contextual toolbar button.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public int ContextualToolbarButtonHeight => ContextualToolbarButton.ContextualToolbarButtonSize.Height;

		/// 
		/// Gets the width of the contextual toolbar button.
		/// </summary>
		/// 
		/// The width of the contextual toolbar button.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public int ContextualToolbarButtonHoverWidth => ContextualToolbarButtonHover.ContextualToolbarButtonSize.Width;

		/// 
		/// Gets the height of the contextual toolbar button.
		/// </summary>
		/// 
		/// The height of the contextual toolbar button.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public int ContextualToolbarButtonHoverHeight => ContextualToolbarButtonHover.ContextualToolbarButtonSize.Height;

		/// 
		/// Gets the height of the contextual toolbar button image.
		/// </summary>
		/// 
		/// The height of the contextual toolbar button image.
		/// </value>
		public int ContextualToolbarButtonImageHeight
		{
			get
			{
				return GetValue("ContextualToolbarButtonImageHeight", GetImageHeight(ContextualToolbarFont, DefaultContextualToolbarButtonImageHeight));
			}
			set
			{
				SetValue("ContextualToolbarButtonImageHeight", value);
			}
		}

		/// 
		/// Gets the default height of the contextual toolbar button image.
		/// </summary>
		/// 
		/// The default height of the contextual toolbar button image.
		/// </value>
		protected virtual int DefaultContextualToolbarButtonImageHeight => 30;

		/// 
		/// Gets the width of the contextual toolbar button image.
		/// </summary>
		/// 
		/// The width of the contextual toolbar button image.
		/// </value>
		public int ContextualToolbarButtonImageWidth
		{
			get
			{
				return GetValue("ContextualToolbarButtonImageWidth", GetImageHeight(ContextualToolbarFont, DefaultContextualToolbarButtonImageWidth));
			}
			set
			{
				SetValue("ContextualToolbarButtonImageWidth", value);
			}
		}

		/// 
		/// Gets the default width of the contextual toolbar button image.
		/// </summary>
		/// 
		/// The default width of the contextual toolbar button image.
		/// </value>
		protected virtual int DefaultContextualToolbarButtonImageWidth => 30;

		private void InitializeComponent()
		{
		}

		/// 
		/// Resets the height of the contextual toolbar button image.
		/// </summary>
		private void ResetContextualToolbarButtonImageHeight()
		{
			Reset("ContextualToolbarButtonImageHeight");
		}

		/// 
		/// Resets the width of the contextual toolbar button image.
		/// </summary>
		private void ResetContextualToolbarButtonImageWidth()
		{
			Reset("ContextualToolbarButtonImageWidth");
		}
	}
}
