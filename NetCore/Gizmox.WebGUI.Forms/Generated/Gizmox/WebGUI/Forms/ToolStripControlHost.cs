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
/// Hosts custom controls or Windows Forms controls.</summary>
	[Serializable]
	[Skin(typeof(ToolStripControlHostSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripControlHostController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ProxyComponent(typeof(ProxyToolStripControlHost))]
	public class ToolStripControlHost : ToolStripItem
	{
		private static readonly SerializableProperty mobjControlProperty = SerializableProperty.Register("mobjControl", typeof(Control), typeof(ToolStripControlHost));

		private static readonly SerializableProperty menmControlAlignProperty = SerializableProperty.Register("menmControlAlign", typeof(ContentAlignment), typeof(ToolStripControlHost));

		private static readonly SerializableEvent DisplayStyleChangedEvent;

		private static readonly SerializableEvent EnterEvent;

		private static readonly SerializableEvent GotFocusEvent;

		private static readonly SerializableEvent KeyDownEvent;

		private static readonly SerializableEvent KeyPressEvent;

		private static readonly SerializableEvent KeyUpEvent;

		private static readonly SerializableEvent LeaveEvent;

		private static readonly SerializableEvent LostFocusEvent;

		private static readonly SerializableEvent ValidatedEvent;

		private static readonly SerializableEvent ValidatingEvent;

		private int intSuspendSyncSizeCount;

		/// 
		/// Gets the DisplayStyleChanged handler.
		/// </summary>
		/// The DisplayStyleChanged handler.</value>
		private EventHandler DisplayStyleChangedHandler => (EventHandler)GetHandler(DisplayStyleChangedEvent);

		/// 
		/// Gets the Enter handler.
		/// </summary>
		/// The Enter handler.</value>
		private EventHandler EnterHandler => (EventHandler)GetHandler(EnterEvent);

		/// 
		/// Gets the GotFocus handler.
		/// </summary>
		/// The GotFocus handler.</value>
		private EventHandler GotFocusHandler => (EventHandler)GetHandler(GotFocusEvent);

		/// 
		/// Gets the KeyDown handler.
		/// </summary>
		/// The KeyDown handler.</value>
		private KeyEventHandler KeyDownHandler => GetHandler(KeyDownEvent) as KeyEventHandler;

		/// 
		/// Gets the KeyPress handler.
		/// </summary>
		/// The KeyPress handler.</value>
		private KeyPressEventHandler KeyPressHandler => GetHandler(KeyPressEvent) as KeyPressEventHandler;

		/// 
		/// Gets the key up handler.
		/// </summary>
		private KeyEventHandler KeyUpHandler => GetHandler(KeyUpEvent) as KeyEventHandler;

		/// 
		/// Gets the Leave handler.
		/// </summary>
		/// The Leave handler.</value>
		private EventHandler LeaveHandler => (EventHandler)GetHandler(LeaveEvent);

		/// 
		/// Gets the LostFocus handler.
		/// </summary>
		/// The LostFocus handler.</value>
		private EventHandler LostFocusHandler => (EventHandler)GetHandler(LostFocusEvent);

		/// 
		/// Gets the Validated handler.
		/// </summary>
		/// The Validated handler.</value>
		private EventHandler ValidatedHandler => (EventHandler)GetHandler(ValidatedEvent);

		/// 
		/// Gets the Validating handler.
		/// </summary>
		/// The Validating handler.</value>
		private EventHandler ValidatingHandler => (EventHandler)GetHandler(ValidatingEvent);

		private Control mobjControl
		{
			get
			{
				return GetValue(mobjControlProperty, null);
			}
			set
			{
				SetValue(mobjControlProperty, value);
			}
		}

		private ContentAlignment menmControlAlign
		{
			get
			{
				return GetValue(menmControlAlignProperty);
			}
			set
			{
				SetValue(menmControlAlignProperty, value);
			}
		}

		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override Color BackColor
		{
			get
			{
				return Control.BackColor;
			}
			set
			{
				Control.BackColor = value;
			}
		}

		/// Gets or sets the background image displayed in the control.</summary>
		/// An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		[SRDescription("ToolStripItemImageDescr")]
		[Localizable(true)]
		public override ResourceHandle BackgroundImage
		{
			get
			{
				return Control.BackgroundImage;
			}
			set
			{
				Control.BackgroundImage = value;
			}
		}

		/// Gets or sets the background image layout as defined in the ImageLayout enumeration.</summary>
		/// One of the values of <see cref="T:System.Windows.Forms.ImageLayout"></see>:<see cref="F:System.Windows.Forms.ImageLayout.Center"></see><see cref="F:System.Windows.Forms.ImageLayout.None"></see><see cref="F:System.Windows.Forms.ImageLayout.Stretch"></see><see cref="F:System.Windows.Forms.ImageLayout.Tile"></see> (default)<see cref="F:System.Windows.Forms.ImageLayout.Zoom"></see></returns>
		[SRDescription("ControlBackgroundImageLayoutDescr")]
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[DefaultValue(ImageLayout.Tile)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return Control.BackgroundImageLayout;
			}
			set
			{
				Control.BackgroundImageLayout = value;
			}
		}

		/// Gets a value indicating whether the control can be selected.</summary>
		/// true if the control can be selected; otherwise, false.</returns>
		/// 1</filterpriority>
		public override bool CanSelect
		{
			get
			{
				if (mobjControl == null)
				{
					return false;
				}
				if (!base.DesignMode)
				{
					return Control.CanSelect;
				}
				return true;
			}
		}

		/// Gets or sets a value indicating whether the hosted control causes and raises validation events on other controls when the hosted control receives focus.</summary>
		/// true if the hosted control causes and raises validation events on other controls when the hosted control receives focus; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		[SRDescription("ControlCausesValidationDescr")]
		[SRCategory("CatFocus")]
		public bool CausesValidation
		{
			get
			{
				return Control.CausesValidation;
			}
			set
			{
				Control.CausesValidation = value;
			}
		}

		/// Gets the <see cref="T:System.Windows.Forms.Control"></see> that this <see cref="T:System.Windows.Forms.ToolStripControlHost"></see> is hosting.</summary>
		/// The <see cref="T:System.Windows.Forms.Control"></see> that this <see cref="T:System.Windows.Forms.ToolStripControlHost"></see> is hosting.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Control Control => mobjControl;

		/// Gets or sets the alignment of the control on the form.</summary>
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleCenter"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:System.Windows.Forms.ToolStripControlHost.ControlAlign"></see> property is set to a value that is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[DefaultValue(ContentAlignment.MiddleCenter)]
		public ContentAlignment ControlAlign
		{
			get
			{
				return menmControlAlign;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 1, 1024))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
				}
				if (menmControlAlign != value)
				{
					menmControlAlign = value;
					OnBoundsChanged();
				}
			}
		}

		/// Gets the default size of the control.</summary>
		/// The default <see cref="T:System.Drawing.Size"></see> of the control.</returns>
		protected override Size DefaultSize
		{
			get
			{
				if (Control != null)
				{
					return Control.Size;
				}
				return base.DefaultSize;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripItemDisplayStyle"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new ToolStripItemDisplayStyle DisplayStyle
		{
			get
			{
				return base.DisplayStyle;
			}
			set
			{
				base.DisplayStyle = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if double clicking is enabled; otherwise, false. </returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		public new bool DoubleClickEnabled
		{
			get
			{
				return base.DoubleClickEnabled;
			}
			set
			{
				base.DoubleClickEnabled = value;
			}
		}

		/// Gets or sets a value indicating whether the parent control of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is enabled.</summary>
		/// true if the parent control of the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is enabled; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override bool Enabled
		{
			get
			{
				return Control.Enabled;
			}
			set
			{
				bool flag = (Control.Enabled = value);
				base.mblnEnabled = flag;
			}
		}

		/// Gets a value indicating whether the control has input focus.</summary>
		/// true if the control has input focus; otherwise, false. </returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public virtual bool Focused => Control.Focused;

		/// Gets or sets the font to be used on the hosted control.</summary>
		/// The <see cref="T:System.Drawing.Font"></see> for the hosted control.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override Font Font
		{
			get
			{
				return Control.Font;
			}
			set
			{
				Control.Font = value;
			}
		}

		/// Gets or sets the foreground color of the hosted control.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> representing the foreground color of the hosted control.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override Color ForeColor
		{
			get
			{
				return Control.ForeColor;
			}
			set
			{
				Control.ForeColor = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Drawing.Image"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override ResourceHandle Image
		{
			get
			{
				return base.Image;
			}
			set
			{
				base.Image = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Drawing.ContentAlignment"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new ContentAlignment ImageAlign
		{
			get
			{
				return base.ImageAlign;
			}
			set
			{
				base.ImageAlign = value;
			}
		}

		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override RightToLeft RightToLeft
		{
			get
			{
				if (mobjControl != null)
				{
					return mobjControl.RightToLeft;
				}
				return base.RightToLeft;
			}
			set
			{
				if (mobjControl != null)
				{
					mobjControl.RightToLeft = value;
				}
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if the image is mirrored; otherwise, false.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new bool RightToLeftAutoMirrorImage
		{
			get
			{
				return base.RightToLeftAutoMirrorImage;
			}
			set
			{
				base.RightToLeftAutoMirrorImage = value;
			}
		}

		/// Gets or sets the size of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</summary>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
		public override Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				if (mobjControl != null)
				{
					mobjControl.Size = value;
				}
				base.Size = value;
			}
		}

		/// Gets or sets the text to be displayed on the hosted control.</summary>
		/// A <see cref="T:System.String"></see> representing the text.</returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		public override string Text
		{
			get
			{
				return Control.Text;
			}
			set
			{
				Control.Text = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Windows.Forms.VisualStyles.ContentAlignment"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new ContentAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 5;

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripTextDirection"></see>.</returns>
		[DefaultValue(ToolStripTextDirection.Horizontal)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override ToolStripTextDirection TextDirection
		{
			get
			{
				return base.TextDirection;
			}
			set
			{
				base.TextDirection = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.Windows.Forms.TextImageRelation"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new TextImageRelation TextImageRelation
		{
			get
			{
				return base.TextImageRelation;
			}
			set
			{
				base.TextImageRelation = value;
			}
		}

		/// This event is not relevant to this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler DisplayStyleChanged
		{
			add
			{
				AddCriticalHandler(DisplayStyleChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DisplayStyleChangedEvent, value);
			}
		}

		/// Occurs when the hosted control is entered.</summary>
		[SRDescription("ControlOnEnterDescr")]
		[SRCategory("CatFocus")]
		public event EventHandler Enter
		{
			add
			{
				if (!HasHandler(EnterEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Enter += HandleEnter;
					}
				}
				AddCriticalHandler(EnterEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(EnterEvent, value);
				if (!HasHandler(EnterEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Enter -= HandleEnter;
					}
				}
			}
		}

		/// Occurs when the hosted control receives focus.</summary> 
		/// 1</filterpriority>
		[SRCategory("CatFocus")]
		[SRDescription("ToolStripItemOnGotFocusDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler GotFocus
		{
			add
			{
				if (!HasHandler(GotFocusEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.GotFocus += HandleGotFocus;
					}
				}
				AddCriticalHandler(GotFocusEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(GotFocusEvent, value);
				if (!HasHandler(GotFocusEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.GotFocus -= HandleGotFocus;
					}
				}
			}
		}

		/// Occurs when a key is pressed and held down while the hosted control has focus.</summary> 
		/// 1</filterpriority>
		[SRDescription("ControlOnKeyDownDescr")]
		[SRCategory("CatKey")]
		public event KeyEventHandler KeyDown
		{
			add
			{
				if (!HasHandler(KeyDownEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.KeyDown += HandleKeyDown;
					}
				}
				AddCriticalHandler(KeyDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(KeyDownEvent, value);
				if (!HasHandler(KeyDownEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.KeyDown -= HandleKeyDown;
					}
				}
			}
		}

		/// Occurs when a key is pressed while the hosted control has focus.</summary> 
		/// 1</filterpriority>
		[SRCategory("CatKey")]
		[SRDescription("ControlOnKeyPressDescr")]
		public event KeyPressEventHandler KeyPress
		{
			add
			{
				if (!HasHandler(KeyPressEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.KeyPress += HandleKeyPress;
					}
				}
				AddCriticalHandler(KeyPressEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(KeyPressEvent, value);
				if (!HasHandler(KeyPressEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.KeyPress -= HandleKeyPress;
					}
				}
			}
		}

		/// Occurs when a key is released while the hosted control has focus.</summary> 
		/// 1</filterpriority>
		[SRCategory("CatKey")]
		[SRDescription("ControlOnKeyUpDescr")]
		public event KeyEventHandler KeyUp
		{
			add
			{
				if (!HasHandler(KeyUpEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.KeyUp += HandleKeyUp;
					}
				}
				AddCriticalHandler(KeyUpEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(KeyUpEvent, value);
				if (!HasHandler(KeyUpEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.KeyUp -= HandleKeyUp;
					}
				}
			}
		}

		/// Occurs when the input focus leaves the hosted control.</summary>
		[SRCategory("CatFocus")]
		[SRDescription("ControlOnLeaveDescr")]
		public event EventHandler Leave
		{
			add
			{
				if (!HasHandler(LeaveEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Leave += HandleLeave;
					}
				}
				AddCriticalHandler(LeaveEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LeaveEvent, value);
				if (!HasHandler(LeaveEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Leave -= HandleLeave;
					}
				}
			}
		}

		/// Occurs when the hosted control loses focus.</summary> 
		/// 1</filterpriority>
		[SRDescription("ToolStripItemOnLostFocusDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRCategory("CatFocus")]
		public event EventHandler LostFocus
		{
			add
			{
				if (!HasHandler(LostFocusEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.LostFocus += HandleLostFocus;
					}
				}
				AddCriticalHandler(LostFocusEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LostFocusEvent, value);
				if (!HasHandler(LostFocusEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.LostFocus -= HandleLostFocus;
					}
				}
			}
		}

		/// Occurs after the hosted control has been successfully validated.</summary>
		[SRDescription("ControlOnValidatedDescr")]
		[SRCategory("CatFocus")]
		public event EventHandler Validated
		{
			add
			{
				if (!HasHandler(ValidatedEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Validated += HandleValidated;
					}
				}
				AddCriticalHandler(ValidatedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ValidatedEvent, value);
				if (!HasHandler(ValidatedEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Validated -= HandleValidated;
					}
				}
			}
		}

		/// Occurs while the hosted control is validating.</summary>
		[SRCategory("CatFocus")]
		[SRDescription("ControlOnValidatingDescr")]
		public event CancelEventHandler Validating
		{
			add
			{
				if (!HasHandler(ValidatingEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Validating += HandleValidating;
					}
				}
				AddCriticalHandler(ValidatingEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ValidatingEvent, value);
				if (!HasHandler(ValidatingEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Validating -= HandleValidating;
					}
				}
			}
		}

		/// 
		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.
		/// </summary>
		public override event EventHandler Click
		{
			add
			{
				if (!HasHandler(ToolStripItem.ClickEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Click += HandleClick;
					}
				}
				base.Click += value;
			}
			remove
			{
				base.Click -= value;
				if (!HasHandler(ToolStripItem.ClickEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.Click -= HandleClick;
					}
				}
			}
		}

		/// 
		/// Occurs when the item is double-clicked with the mouse.
		/// </summary>
		public override event EventHandler DoubleClick
		{
			add
			{
				if (!HasHandler(ToolStripItem.DoubleClickEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.DoubleClick += HandleDoubleClick;
					}
				}
				base.DoubleClick += value;
			}
			remove
			{
				base.DoubleClick -= value;
				if (!HasHandler(ToolStripItem.DoubleClickEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.DoubleClick -= HandleDoubleClick;
					}
				}
			}
		}

		/// 
		/// Occurs when the mouse pointer is over the item and a mouse button is pressed.
		/// </summary>
		public override event MouseEventHandler MouseDown
		{
			add
			{
				if (!HasHandler(ToolStripItem.MouseDownEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.MouseDown += HandleMouseDown;
					}
				}
				base.MouseDown += value;
			}
			remove
			{
				base.MouseDown -= value;
				if (!HasHandler(ToolStripItem.MouseDownEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.MouseDown -= HandleMouseDown;
					}
				}
			}
		}

		/// 
		/// Occurs when the mouse pointer is over the item and a mouse button is released.
		/// </summary>
		public override event MouseEventHandler MouseUp
		{
			add
			{
				if (!HasHandler(ToolStripItem.MouseUpEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.MouseUp += HandleMouseUp;
					}
				}
				base.MouseUp += value;
			}
			remove
			{
				base.MouseUp -= value;
				if (!HasHandler(ToolStripItem.MouseUpEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.MouseUp -= HandleMouseUp;
					}
				}
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property changes.
		/// </summary>
		public override event EventHandler TextChanged
		{
			add
			{
				if (!HasHandler(ToolStripItem.TextChangedEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.TextChanged += HandleTextChanged;
					}
				}
				base.TextChanged += value;
			}
			remove
			{
				base.TextChanged -= value;
				if (!HasHandler(ToolStripItem.TextChangedEvent))
				{
					Control control = Control;
					if (control != null)
					{
						control.TextChanged -= HandleTextChanged;
					}
				}
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class that hosts the specified control.</summary> 
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> hosted by this <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class. </param> 
		/// <exception cref="T:System.ArgumentNullException">The control referred to by the c parameter is null.</exception>
		public ToolStripControlHost(Control objControl)
		{
			menmControlAlign = ContentAlignment.MiddleCenter;
			if (objControl == null)
			{
				throw new ArgumentNullException("objControl", "ControlCannotBeNull");
			}
			mobjControl = objControl;
			SyncControlParent();
			objControl.Visible = true;
			SetBounds(objControl.Bounds);
			Rectangle bounds = Bounds;
			objControl.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
			OnSubscribeControlEvents(objControl);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class that hosts the specified control and that has the specified name.</summary> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see>.</param> 
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> hosted by this <see cref="T:Gizmox.WebGUI.Forms.ToolStripControlHost"></see> class.</param>
		public ToolStripControlHost(Control objControl, string name)
			: this(objControl)
		{
			base.Name = name;
		}

		/// 
		/// Pres the render tool strip item.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal override void PreRenderToolStripItem(IContext objContext, long lngRequestID)
		{
			base.PreRenderToolStripItem(objContext, lngRequestID);
			if (Control != null)
			{
				Control.PreRenderControl(objContext, lngRequestID);
			}
		}

		/// 
		/// Posts the render tool strip item.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal override void PostRenderToolStripItem(IContext objContext, long lngRequestID)
		{
			base.PostRenderToolStripItem(objContext, lngRequestID);
			if (Control != null)
			{
				Control.PostRenderControl(objContext, lngRequestID);
			}
		}

		/// 
		/// Gets the preferred size.
		/// </summary>
		/// <param name="objConstrainingSize"></param>
		/// </returns>
		public override Size GetPreferredSize(Size objConstrainingSize)
		{
			if (Control != null)
			{
				Size size = Control.Size;
				Size size2 = Control.GetPreferredSize(size);
				if (size2 == Size.Empty)
				{
					size2 = size;
				}
				if (size2 != Size.Empty)
				{
					if (SkinFactory.GetSkin(this, typeof(ToolStripMenuItemSkin)) is ToolStripMenuItemSkin toolStripMenuItemSkin)
					{
						BorderWidth borderWidth = ((toolStripMenuItemSkin.MenuItemStyle.Border.Style != BorderStyle.None) ? toolStripMenuItemSkin.MenuItemStyle.Border.Width : BorderWidth.Empty);
						size2.Width += borderWidth.Left + borderWidth.Right;
						size2.Height += borderWidth.Top + borderWidth.Bottom;
					}
					return size2;
				}
			}
			return DefaultSize;
		}

		/// 
		/// Renders the tool strip item's controls.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected override void RenderToolStripItemControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			base.RenderToolStripItemControls(objContext, objWriter, lngRequestID);
			Control?.RenderControl(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Bounds"></see> property changes.
		/// </summary>
		protected override void OnBoundsChanged()
		{
			if (Control == null)
			{
				return;
			}
			SuspendSizeSync();
			IArrangedElement control = Control;
			if (control != null)
			{
				Rectangle rectangle = LayoutUtils.Align(LayoutUtils.DeflateRect(Bounds, Padding).Size, Bounds, ControlAlign);
				control.SetBounds(rectangle, BoundsSpecified.None);
				if (rectangle != Control.Bounds)
				{
					Rectangle objBounds = LayoutUtils.Align(Control.Size, Bounds, ControlAlign);
					control.SetBounds(objBounds, BoundsSpecified.None);
				}
				ResumeSizeSync();
				Control.Update();
			}
		}

		/// 
		/// Register a component.
		/// </summary>
		/// <param name="objComponent">Component.</param>
		protected override void RegisterComponent(IRegisteredComponent objComponent)
		{
			base.RegisterComponent(objComponent);
			if (objComponent == this)
			{
				Control control = Control;
				if (control != null)
				{
					base.RegisterComponent(control);
				}
			}
		}

		/// 
		/// Unregister a component.
		/// </summary>
		/// <param name="objComponent">Component.</param>
		protected override void UnRegisterComponent(IRegisteredComponent objComponent)
		{
			base.UnRegisterComponent(objComponent);
			if (objComponent == this)
			{
				Control control = Control;
				if (control != null)
				{
					base.UnRegisterComponent(control);
				}
			}
		}

		private Control.ControlCollection GetControlCollection(ToolStrip objToolStrip)
		{
			return objToolStrip?.Controls;
		}

		private void SyncControlParent()
		{
			GetControlCollection(base.ParentInternal)?.Add(Control);
		}

		/// Gives the focus to a control.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void Focus()
		{
			Control.Focus();
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Enter"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnEnter(EventArgs e)
		{
			EnterHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.GotFocus"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnGotFocus(EventArgs e)
		{
			GotFocusHandler?.Invoke(this, e);
		}

		/// Synchronizes the resizing of the control host with the resizing of the hosted control.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnHostedControlResize(EventArgs e)
		{
			Size = Control.Size;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyDown"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
		protected virtual void OnKeyDown(KeyEventArgs e)
		{
			KeyDownHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyPress"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data.</param>
		protected virtual void OnKeyPress(KeyPressEventArgs e)
		{
			KeyPressHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.KeyUp"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data.</param>
		protected virtual void OnKeyUp(KeyEventArgs e)
		{
			KeyUpHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Leave"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnLeave(EventArgs e)
		{
			LeaveHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.LostFocus"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnLostFocus(EventArgs e)
		{
			LostFocusHandler?.Invoke(this, e);
		}

		private void HandleClick(object sender, EventArgs e)
		{
			OnClick(e);
		}

		private void HandleBackColorChanged(object sender, EventArgs e)
		{
			OnBackColorChanged(e);
		}

		private void HandleDoubleClick(object sender, EventArgs e)
		{
			OnDoubleClick(e);
		}

		private void HandleDragDrop(object sender, DragEventArgs e)
		{
			OnDragDrop(e);
		}

		private void HandleEnabledChanged(object sender, EventArgs e)
		{
			OnEnabledChanged(e);
		}

		private void HandleForeColorChanged(object sender, EventArgs e)
		{
			OnForeColorChanged(e);
		}

		private void HandleGotFocus(object sender, EventArgs e)
		{
			OnGotFocus(e);
		}

		private void HandleLeave(object sender, EventArgs e)
		{
			OnLeave(e);
		}

		private void HandleEnter(object sender, EventArgs e)
		{
			OnEnter(e);
		}

		private void HandleLocationChanged(object sender, EventArgs e)
		{
			OnLocationChanged(e);
		}

		private void HandleLostFocus(object sender, EventArgs e)
		{
			OnLostFocus(e);
		}

		private void HandleKeyDown(object sender, KeyEventArgs e)
		{
			OnKeyDown(e);
		}

		private void HandleKeyPress(object sender, KeyPressEventArgs e)
		{
			OnKeyPress(e);
		}

		private void HandleKeyUp(object sender, KeyEventArgs e)
		{
			OnKeyUp(e);
		}

		private void HandleMouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(e);
		}

		private void HandleMouseUp(object sender, MouseEventArgs e)
		{
			OnMouseUp(e);
		}

		private void HandleResize(object sender, EventArgs e)
		{
			OnHostedControlResize(e);
		}

		private void HandleTextChanged(object sender, EventArgs e)
		{
			OnTextChanged(e);
		}

		private void HandleControlVisibleChanged(object sender, EventArgs e)
		{
			bool participatesInLayout = ((IArrangedElement)Control).ParticipatesInLayout;
			if (((IArrangedElement)this).ParticipatesInLayout != participatesInLayout)
			{
				base.Visible = Control.Visible;
			}
		}

		private void HandleValidated(object sender, EventArgs e)
		{
			OnValidated(e);
		}

		private void HandleValidating(object sender, CancelEventArgs e)
		{
			OnValidating(e);
		}

		/// Subscribes events from the hosted control.</summary> 
		/// <param name="objControl">The control from which to subscribe events.</param>
		protected virtual void OnSubscribeControlEvents(Control objControl)
		{
			if (objControl != null)
			{
				objControl.BackColorChanged += HandleBackColorChanged;
				objControl.DragDrop += HandleDragDrop;
				objControl.EnabledChanged += HandleEnabledChanged;
				objControl.ForeColorChanged += HandleForeColorChanged;
				objControl.LocationChanged += HandleLocationChanged;
				objControl.Resize += HandleResize;
				objControl.VisibleChanged += HandleControlVisibleChanged;
			}
		}

		/// Unsubscribes events from the hosted control.</summary> 
		/// <param name="objControl">The control from which to unsubscribe events.</param>
		protected virtual void OnUnsubscribeControlEvents(Control objControl)
		{
			if (objControl != null)
			{
				objControl.BackColorChanged -= HandleBackColorChanged;
				objControl.DragDrop -= HandleDragDrop;
				objControl.EnabledChanged -= HandleEnabledChanged;
				objControl.ForeColorChanged -= HandleForeColorChanged;
				objControl.LocationChanged -= HandleLocationChanged;
				objControl.Resize -= HandleResize;
				objControl.VisibleChanged -= HandleControlVisibleChanged;
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Validated"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnValidated(EventArgs e)
		{
			ValidatedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripControlHost.Validating"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data.</param>
		protected virtual void OnValidating(CancelEventArgs e)
		{
			ValidatingHandler?.Invoke(this, e);
		}

		/// 
		/// Suspends the size sync.
		/// </summary>
		private void SuspendSizeSync()
		{
			intSuspendSyncSizeCount++;
		}

		/// 
		/// Resumes the size sync.
		/// </summary>
		private void ResumeSizeSync()
		{
			intSuspendSyncSizeCount--;
		}

		/// 
		/// Shoulds the color of the serialize back.
		/// </summary>
		/// </returns>
		internal override bool ShouldSerializeBackColor()
		{
			return Control.ShouldSerializeBackColor();
		}

		/// 
		/// Shoulds the color of the serialize fore.
		/// </summary>
		/// </returns>
		internal override bool ShouldSerializeForeColor()
		{
			return Control.ShouldSerializeForeColor();
		}

		/// 
		/// Shoulds the serialize right to left.
		/// </summary>
		/// </returns>
		internal override bool ShouldSerializeRightToLeft()
		{
			return Control.ShouldSerializeRightToLeft();
		}

		/// 
		/// Shoulds the serialize font.
		/// </summary>
		/// </returns>
		internal override bool ShouldSerializeFont()
		{
			return Control.ShouldSerializeFont();
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			List<object> list = new List<object>();
			list.Add(Control);
			return list;
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.
		/// </summary>
		/// <param name="oldParent">The original parent of the item.</param>
		/// <param name="newParent">The new parent of the item.</param>
		protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
		{
			if (oldParent != null && base.Owner == null && newParent == null && Control != null)
			{
				GetControlCollection(Control.ParentInternal as ToolStrip)?.Remove(Control);
			}
			else
			{
				SyncControlParent();
			}
			base.OnParentChanged(oldParent, newParent);
		}

		static ToolStripControlHost()
		{
			DisplayStyleChangedEvent = SerializableEvent.Register("DisplayStyleChanged", typeof(EventHandler), typeof(ToolStripControlHost));
			EnterEvent = SerializableEvent.Register("Enter", typeof(EventHandler), typeof(ToolStripControlHost));
			GotFocusEvent = SerializableEvent.Register("GotFocus", typeof(EventHandler), typeof(ToolStripControlHost));
			KeyDownEvent = SerializableEvent.Register("KeyDown", typeof(KeyEventHandler), typeof(ToolStripControlHost));
			KeyPressEvent = SerializableEvent.Register("KeyPress", typeof(KeyPressEventHandler), typeof(ToolStripControlHost));
			KeyUpEvent = SerializableEvent.Register("KeyUp", typeof(KeyEventHandler), typeof(ToolStripControlHost));
			LeaveEvent = SerializableEvent.Register("Leave", typeof(EventHandler), typeof(ToolStripControlHost));
			LostFocusEvent = SerializableEvent.Register("LostFocus", typeof(EventHandler), typeof(ToolStripControlHost));
			ValidatedEvent = SerializableEvent.Register("Validated", typeof(EventHandler), typeof(ToolStripControlHost));
			ValidatingEvent = SerializableEvent.Register("Validating", typeof(EventHandler), typeof(ToolStripControlHost));
		}
	}
}
