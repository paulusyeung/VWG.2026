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
	/// Represents a Windows picture box control for displaying an image.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(PictureBox), "PictureBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.PictureBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.PictureBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultBindingProperty("Image")]
	[DefaultProperty("Image")]
	[SRDescription("DescriptionPictureBox")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("PBX")]
	[Skin(typeof(PictureBoxSkin))]
	public class PictureBox : Control, ISupportInitialize
	{
		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(PictureBox));

		/// 
		/// Provides a property reference to PictureBoxSizeMode property.
		/// </summary>
		private static SerializableProperty PictureBoxSizeModeProperty = SerializableProperty.Register("PictureBoxSizeMode", typeof(PictureBoxSizeMode), typeof(PictureBox));

		/// 
		/// Indicates how the image is displayed.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.PictureBoxSizeMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.PictureBoxSizeMode.Normal"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.PictureBoxSizeMode"></see> values. </exception>
		[DefaultValue(PictureBoxSizeMode.Normal)]
		[Localizable(true)]
		[SRDescription("PictureBoxSizeModeDescr")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public PictureBoxSizeMode SizeMode
		{
			get
			{
				return GetValue(PictureBoxSizeModeProperty, PictureBoxSizeMode.Normal);
			}
			set
			{
				if (SizeMode != value)
				{
					if (value != PictureBoxSizeMode.Normal)
					{
						SetValue(PictureBoxSizeModeProperty, value);
					}
					else
					{
						RemoveValue(PictureBoxSizeModeProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// 
		/// Gets or sets the tab index.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		/// 
		/// Gets or sets the image that is displayed by <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see>.
		/// </summary>
		/// The <see cref="T:System.Drawing.Image"></see> to display.</returns>
		[SRDescription("PictureBoxImageDescr")]
		[Localizable(true)]
		[Bindable(true)]
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		[ProxyBrowsable(true)]
		public ResourceHandle Image
		{
			get
			{
				return GetValue(ImageProperty, null);
			}
			set
			{
				if (Image != value)
				{
					if (value != null)
					{
						SetValue(ImageProperty, value);
					}
					else
					{
						RemoveValue(ImageProperty);
					}
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether an image is loaded synchronously.</summary>
		/// true if an image-loading operation is done synchronously, otherwise, false. The default is false.</returns>
		/// 2</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[SRCategory("CatAsynchronous")]
		[SRDescription("PictureBoxWaitOnLoadDescr")]
		[DefaultValue(false)]
		public bool WaitOnLoad
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets the image displayed in the <see cref="T:System.Windows.Forms.PictureBox"></see> control while the main image is loading.</summary>
		/// The <see cref="T:System.Drawing.Image"></see> displayed in the picture box control while the main image is loading.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatAsynchronous")]
		[Localizable(true)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("PictureBoxInitialImageDescr")]
		public ResourceHandle InitialImage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.CausesValidation"></see> property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler CausesValidationChanged
		{
			add
			{
				base.CausesValidationChanged += value;
			}
			remove
			{
				base.CausesValidationChanged -= value;
			}
		}

		/// 
		/// Occurs when the control is entered.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler Enter
		{
			add
			{
				base.Enter += value;
			}
			remove
			{
				base.Enter -= value;
			}
		}

		/// 
		/// Occurs when the FontChanged property changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler FontChanged
		{
			add
			{
				base.FontChanged += value;
			}
			remove
			{
				base.FontChanged -= value;
			}
		}

		/// 
		/// Occurs when the ForeColorChanged property changes.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler ForeColorChanged
		{
			add
			{
				base.ForeColorChanged += value;
			}
			remove
			{
				base.ForeColorChanged -= value;
			}
		}

		/// 
		/// Occurs on key down.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event KeyEventHandler KeyDown
		{
			add
			{
				base.KeyDown += value;
			}
			remove
			{
				base.KeyDown -= value;
			}
		}

		/// 
		/// Occurs on key press.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event KeyPressEventHandler KeyPress
		{
			add
			{
				base.KeyPress += value;
			}
			remove
			{
				base.KeyPress -= value;
			}
		}

		/// 
		/// Occurs on key up.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event KeyEventHandler KeyUp
		{
			add
			{
				base.KeyUp += value;
			}
			remove
			{
				base.KeyUp -= value;
			}
		}

		/// 
		/// Occurs when the input focus leaves the control.
		/// Not implemented by design.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler Leave
		{
			add
			{
				base.Leave += value;
			}
			remove
			{
				base.Leave -= value;
			}
		}

		/// 
		/// Occurs when the Text property value changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler TextChanged
		{
			add
			{
				base.TextChanged += value;
			}
			remove
			{
				base.TextChanged -= value;
			}
		}

		/// 
		/// Occurs when [client key down].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event ClientEventHandler ClientKeyDown
		{
			add
			{
				base.ClientKeyDown += value;
			}
			remove
			{
				base.ClientKeyDown -= value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PictureBox"></see> class.
		/// </summary>
		public PictureBox()
		{
			base.Size = new Size(64, 105);
			SetStyle(ControlStyles.Opaque | ControlStyles.Selectable, blnValue: false);
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, blnValue: true);
			TabStop = false;
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("IMS", ((int)SizeMode).ToString());
			ResourceHandle proxyPropertyValue = GetProxyPropertyValue("Image", Image);
			if (proxyPropertyValue != null)
			{
				objWriter.WriteAttributeString("IM", proxyPropertyValue.ToString());
			}
		}

		/// 
		/// Loads the specified URL.
		/// </summary>
		/// <param name="strUrl">The URL.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAsynchronous")]
		[SRDescription("PictureBoxLoad1Descr")]
		public void Load(string strUrl)
		{
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new PictureBoxRenderer(this);
		}

		void ISupportInitialize.BeginInit()
		{
		}

		void ISupportInitialize.EndInit()
		{
		}
	}
}
