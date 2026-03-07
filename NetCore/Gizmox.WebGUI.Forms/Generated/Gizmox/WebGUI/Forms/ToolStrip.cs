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
	/// Provides a container for Windows toolbar objects. </summary>
	/// </summary>
	[Serializable]
	[Skin(typeof(ToolStripSkin))]
	[MetadataTag("TSP")]
	[DefaultEvent("ItemClicked")]
	[SRDescription("DescriptionToolStrip")]
	[ComVisible(true)]
	[DefaultProperty("Items")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(ToolStrip), "ToolStrip_45.bmp")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ProxyComponent(typeof(ProxyToolStrip))]
	public class ToolStrip : ScrollableControl, IComponent, IDisposable
	{
		private static readonly SerializableProperty mobjToolStripItemCollectionProperty = SerializableProperty.Register("mobjToolStripItemCollection", typeof(ToolStripItemCollection), typeof(ToolStrip));

		private static readonly SerializableProperty mobjImageScalingSizeProperty = SerializableProperty.Register("mobjImageScalingSize", typeof(Size), typeof(ToolStrip), new SerializablePropertyMetadata());

		private static readonly SerializableProperty mobjImageListProperty = SerializableProperty.Register("mobjImageList", typeof(ImageList), typeof(ToolStrip));

		private static readonly SerializableProperty menmToolStripGripStyleProperty = SerializableProperty.Register("menmToolStripGripStyle", typeof(ToolStripGripStyle), typeof(ToolStrip), new SerializablePropertyMetadata(ToolStripGripStyle.Visible));

		private static readonly SerializableProperty mobjGripMarginProperty = SerializableProperty.Register("mobjGripMargin", typeof(Padding), typeof(ToolStrip));

		private static readonly SerializableProperty menmLayoutStyleProperty = SerializableProperty.Register("menmLayoutStyle", typeof(ToolStripLayoutStyle), typeof(ToolStrip), new SerializablePropertyMetadata(ToolStripLayoutStyle.StackWithOverflow));

		private static readonly SerializableProperty menmOrientationProperty = SerializableProperty.Register("menmOrientation", typeof(Orientation), typeof(ToolStrip));

		private static readonly SerializableProperty mblnAllowMergeProperty = SerializableProperty.Register("mblnAllowMerge", typeof(bool), typeof(ToolStrip), new SerializablePropertyMetadata(true));

		private static readonly SerializableProperty mblnAllowItemReorderProperty = SerializableProperty.Register("mblnAllowItemReorder", typeof(bool), typeof(ToolStrip));

		private static readonly SerializableProperty mblnShowItemToolTipsProperty = SerializableProperty.Register("mblnShowItemToolTips", typeof(bool), typeof(ToolStrip));

		private static readonly SerializableProperty mblnStretchProperty = SerializableProperty.Register("mblnStretch", typeof(bool), typeof(ToolStrip));

		private static readonly SerializableProperty menmToolStripTextDirectionProperty = SerializableProperty.Register("menmToolStripTextDirection", typeof(ToolStripTextDirection), typeof(ToolStrip));

		private static readonly SerializableProperty mblnCanOverflowProperty = SerializableProperty.Register("mblnCanOverflow", typeof(bool), typeof(ToolStrip));

		internal static readonly SerializableEvent ItemClickedEvent = SerializableEvent.Register("ItemClicked", typeof(ToolStripItemClickedEventHandler), typeof(ToolStrip));

		private static readonly SerializableEvent LayoutStyleChangedEvent;

		private static readonly SerializableEvent ItemAddedEvent;

		private static readonly SerializableEvent ItemRemovedEvent;

		/// 
		/// Gets the list of tags that client events are propogated to.
		/// </summary>
		/// 
		/// The client event propogated tags.
		/// </value>
		protected override string ClientEventsPropogationTags => string.Format("WC:{0},WC:{1},WC:{2},WC:{3}", "CB", "T", "TSI", "PB");

		/// 
		/// Gets the size of the skin image scaling.
		/// </summary>
		/// 
		/// The size of the skin image scaling.
		/// </value>
		internal Size SkinImageScalingSize
		{
			get
			{
				if (!(SkinFactory.GetSkin(this) is ToolStripSkin { ImageScalingSize: var imageScalingSize }))
				{
					return Size.Empty;
				}
				return imageScalingSize;
			}
		}

		/// 
		/// Gets the hanlder for the ItemAdded event.
		/// </summary>
		private ToolStripItemEventHandler ItemAddedHandler => (ToolStripItemEventHandler)GetHandler(ItemAdded);

		/// 
		/// Gets the hanlder for the ItemClicked event.
		/// </summary>
		private ToolStripItemClickedEventHandler ItemClickedHandler => (ToolStripItemClickedEventHandler)GetHandler(ItemClickedEvent);

		/// 
		/// Gets the hanlder for the ItemRemoved event.
		/// </summary>
		private ToolStripItemEventHandler ItemRemovedHandler => (ToolStripItemEventHandler)GetHandler(ItemRemoved);

		/// 
		/// Gets the hanlder for the LayoutStyleChanged event.
		/// </summary>
		private EventHandler LayoutStyleChangedHandler => (EventHandler)GetHandler(LayoutStyleChanged);

		private ToolStripItemCollection mobjToolStripItemCollection
		{
			get
			{
				return GetValue(mobjToolStripItemCollectionProperty, null);
			}
			set
			{
				SetValue(mobjToolStripItemCollectionProperty, value);
			}
		}

		private Size mobjImageScalingSize
		{
			get
			{
				return GetValue(mobjImageScalingSizeProperty, SkinImageScalingSize);
			}
			set
			{
				SetValue(mobjImageScalingSizeProperty, value);
			}
		}

		private ImageList mobjImageList
		{
			get
			{
				return GetValue(mobjImageListProperty);
			}
			set
			{
				SetValue(mobjImageListProperty, value);
			}
		}

		private bool mblnCanOverflow
		{
			get
			{
				return GetValue(mblnCanOverflowProperty, objDefault: false);
			}
			set
			{
				SetValue(mblnCanOverflowProperty, value);
			}
		}

		private ToolStripTextDirection menmToolStripTextDirection
		{
			get
			{
				return GetValue(menmToolStripTextDirectionProperty, ToolStripTextDirection.Inherit);
			}
			set
			{
				SetValue(menmToolStripTextDirectionProperty, value);
			}
		}

		private bool mblnStretch
		{
			get
			{
				return GetValue(mblnStretchProperty);
			}
			set
			{
				SetValue(mblnStretchProperty, value);
			}
		}

		private bool mblnShowItemToolTips
		{
			get
			{
				return GetValue(mblnShowItemToolTipsProperty);
			}
			set
			{
				SetValue(mblnShowItemToolTipsProperty, value);
			}
		}

		private bool mblnAllowItemReorder
		{
			get
			{
				return GetValue(mblnAllowItemReorderProperty);
			}
			set
			{
				SetValue(mblnAllowItemReorderProperty, value);
			}
		}

		private bool mblnAllowMerge
		{
			get
			{
				return GetValue(mblnAllowMergeProperty);
			}
			set
			{
				SetValue(mblnAllowMergeProperty, value);
			}
		}

		private Orientation menmOrientation
		{
			get
			{
				return GetValue(menmOrientationProperty);
			}
			set
			{
				SetValue(menmOrientationProperty, value);
			}
		}

		private ToolStripLayoutStyle menmLayoutStyle
		{
			get
			{
				return GetValue(menmLayoutStyleProperty);
			}
			set
			{
				SetValue(menmLayoutStyleProperty, value);
			}
		}

		private Padding mobjGripMargin
		{
			get
			{
				return GetValue(mobjGripMarginProperty);
			}
			set
			{
				SetValue(mobjGripMarginProperty, value);
			}
		}

		private ToolStripGripStyle menmToolStripGripStyle
		{
			get
			{
				return GetValue(menmToolStripGripStyleProperty);
			}
			set
			{
				SetValue(menmToolStripGripStyleProperty, value);
			}
		}

		/// Gets or sets a value indicating whether drag-and-drop and item reordering are handled through events that you implement.</summary> 
		/// true to control drag-and-drop and item reordering through events that you implement; otherwise, false.</returns> 
		/// <exception cref="T:System.ArgumentException"> 
		///   <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
				if (value && AllowItemReorder)
				{
					throw new ArgumentException(SR.GetString("ToolStripAllowItemReorderAndAllowDropCannotBeSetToTrue"));
				}
				base.AllowDrop = value;
			}
		}

		/// Gets or sets a value indicating whether drag-and-drop and item reordering are handled privately by the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class.</summary> 
		/// true to cause the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class to handle drag-and-drop and item reordering automatically; otherwise, false. The default value is false.</returns> 
		/// <exception cref="T:System.ArgumentException"> 
		///   <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[DefaultValue(false)]
		[SRDescription("ToolStripAllowItemReorderDescr")]
		[SRCategory("CatBehavior")]
		public bool AllowItemReorder
		{
			get
			{
				return mblnAllowItemReorder;
			}
			set
			{
				if (mblnAllowItemReorder != value)
				{
					if (AllowDrop && value)
					{
						throw new ArgumentException(SR.GetString("ToolStripAllowItemReorderAndAllowDropCannotBeSetToTrue"));
					}
					mblnAllowItemReorder = value;
				}
			}
		}

		/// Gets or sets a value indicating whether multiple <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>, and other types can be combined. </summary> 
		/// true if combining of types is allowed; otherwise, false. The default is false.</returns> 
		/// 2</filterpriority>
		[SRDescription("ToolStripAllowMergeDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool AllowMerge
		{
			get
			{
				return mblnAllowMerge;
			}
			set
			{
				if (mblnAllowMerge != value)
				{
					mblnAllowMerge = value;
				}
			}
		}

		/// This property is not relevant for this class.</summary> 
		/// true to automatically scroll; otherwise, false.</returns> 
		/// <exception cref="T:System.NotSupportedException">Automatic scrolling is not supported by <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> controls.</exception>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override bool AutoScroll
		{
			get
			{
				return base.AutoScroll;
			}
			set
			{
				throw new NotSupportedException(SR.GetString("ToolStripDoesntSupportAutoScroll"));
			}
		}

		/// This property is not relevant for this class.</summary> 
		/// A <see cref="T:System.Drawing.Size"></see> value.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMargin
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// This property is not relevant for this class.</summary> 
		/// A <see cref="T:System.Drawing.Size"></see> value.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMinSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// This property is not relevant for this class.</summary> 
		/// A <see cref="T:System.Drawing.Point"></see> value.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point AutoScrollPosition
		{
			get
			{
				return Point.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.</summary> 
		/// true if the control adjusts its width to closely fit its contents; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority>
		[DefaultValue(true)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
			}
		}

		/// Gets or sets the background color for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripBackColorDescr")]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// Gets or sets a value indicating whether items in the <see cref="T:System.Windows.Forms.ToolStrip"></see> can be sent to an overflow menu.</summary>
		/// true to send <see cref="T:System.Windows.Forms.ToolStrip"></see> items to an overflow menu; otherwise, false. The default value is true.</returns>
		/// 1</filterpriority>
		[SRDescription("ToolStripCanOverflowDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(true)]
		public bool CanOverflow
		{
			get
			{
				return mblnCanOverflow;
			}
			set
			{
				if (mblnCanOverflow != value)
				{
					mblnCanOverflow = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> causes validation to be performed on any controls that require validation when it receives focus.</summary> 
		/// false in all cases.</returns>
		[Browsable(false)]
		[DefaultValue(false)]
		public new bool CausesValidation
		{
			get
			{
				return base.CausesValidation;
			}
			set
			{
				base.CausesValidation = value;
			}
		}

		/// This property is not relevant for this class.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> representing the collection of controls contained within the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ControlCollection Controls => base.Controls;

		/// Gets or sets the cursor that is displayed when the mouse pointer is over the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor to display when the mouse pointer is over the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Cursor Cursor
		{
			get
			{
				return base.Cursor;
			}
			set
			{
				base.Cursor = value;
			}
		}

		/// Gets the docking location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, indicating which borders are docked to the container.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Top"></see>.</returns>
		protected virtual DockStyle DefaultDock => DockStyle.Top;

		/// Gets or sets a value representing the default direction in which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is displayed relative to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</exception>
		[SRCategory("CatBehavior")]
		[Browsable(false)]
		[SRDescription("ToolStripDefaultDropDownDirectionDescr")]
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ToolStripDropDownDirection DefaultDropDownDirection
		{
			get
			{
				return ToolStripDropDownDirection.Default;
			}
			set
			{
			}
		}

		/// Gets the default spacing, in pixels, between the sizing grip and the edges of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		///  
		///   <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values representing the spacing, in pixels.</returns>
		protected virtual Padding DefaultGripMargin => new Padding(2);

		/// Gets the internal spacing, in pixels, of the contents of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value of (0, 0, 1, 0).</returns>
		protected override Size DefaultSize => new Size(100, 25);

		/// Gets a value indicating whether ToolTips are shown for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> by default.</summary> 
		/// true in all cases.</returns>
		protected virtual bool DefaultShowItemToolTips => true;

		/// Retrieves the current display rectangle.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> representing the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> area for item layout.</returns> 
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
		public new virtual Rectangle DisplayRectangle => Rectangle.Empty;

		/// Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is resized with its parent.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Top"></see>.</returns> 
		/// 1</filterpriority>
		[DefaultValue(DockStyle.Top)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				DockStyle dock = Dock;
				if (value != dock)
				{
					Rectangle bounds = base.Bounds;
					base.Dock = value;
					if ((IsHorizontalDocked(dock) && IsVerticalDocked(value)) || (IsHorizontalDocked(value) && IsVerticalDocked(dock)))
					{
						base.Size = new Size(bounds.Height, bounds.Width);
					}
					UpdateLayoutStyle(value);
					Update();
				}
			}
		}

		/// Gets or sets the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> representing the foreground color.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Browsable(false)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// Gets the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values. Possible values are <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle.Horizontal"></see> and <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle.Vertical"></see>.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public ToolStripGripDisplayStyle GripDisplayStyle
		{
			get
			{
				if (LayoutStyle != ToolStripLayoutStyle.HorizontalStackWithOverflow)
				{
					return ToolStripGripDisplayStyle.Horizontal;
				}
				return ToolStripGripDisplayStyle.Vertical;
			}
		}

		/// Gets or sets the space around the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see>, which represents the spacing.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripGripDisplayStyleDescr")]
		[SRCategory("CatLayout")]
		public Padding GripMargin
		{
			get
			{
				return mobjGripMargin;
			}
			set
			{
				if (mobjGripMargin != value)
				{
					mobjGripMargin = value;
				}
			}
		}

		/// Gets the boundaries of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle.</summary> 
		/// An object of type <see cref="T:System.Drawing.Rectangle"></see>, representing the move handle boundaries. If the boundaries are not visible, the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.GripRectangle"></see> property returns <see cref="F:System.Drawing.Rectangle.Empty"></see>.</returns> 
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
		public Rectangle GripRectangle => Rectangle.Empty;

		/// Gets or sets whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle is visible or hidden.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.ToolStripGripStyle.Visible"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripStyle"></see> values. </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[DefaultValue(ToolStripGripStyle.Visible)]
		[SRDescription("ToolStripGripStyleDescr")]
		[SRCategory("CatAppearance")]
		public ToolStripGripStyle GripStyle
		{
			get
			{
				return menmToolStripGripStyle;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripGripStyle));
				}
				if (menmToolStripGripStyle != value)
				{
					menmToolStripGripStyle = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// This property is not relevant for this class.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStrip"></see> has children; otherwise, false. </returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool HasChildren => base.HasChildren;

		/// This property is not relevant for this class.</summary> 
		/// An instance of the <see cref="T:Gizmox.WebGUI.Forms.HScrollProperties"></see> class, which provides basic properties for an <see cref="T:Gizmox.WebGUI.Forms.HScrollBar"></see>.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public HScrollProperties HorizontalScroll => null;

		/// Gets or sets the image list that contains the image displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> item.</summary> 
		/// An object of type <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripImageListDescr")]
		[Browsable(false)]
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		public ImageList ImageList
		{
			get
			{
				return mobjImageList;
			}
			set
			{
				if (mobjImageList != value)
				{
					mobjImageList = value;
				}
			}
		}

		/// Gets or sets the size, in pixels, of an image used on a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> value representing the size of the image, in pixels. The default is 16 x 16 pixels.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripImageScalingSizeDescr")]
		public Size ImageScalingSize
		{
			get
			{
				return mobjImageScalingSize;
			}
			set
			{
				if (mobjImageScalingSize != value)
				{
					mobjImageScalingSize = value;
					Update();
				}
			}
		}

		/// Gets a value indicating whether the user is currently moving the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> from one <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see> to another. </summary> 
		/// true if the user is currently moving the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> from one <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see> to another; otherwise, false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool IsCurrentlyDragging => false;

		/// Gets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public bool IsDropDown => this is ToolStripDropDown;

		/// Gets all the items that belong to a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>, representing all the elements contained by a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
		/// 1</filterpriority>
		[MergableProperty(false)]
		[SRCategory("CatData")]
		[SRDescription("ToolStripItemsDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("Gizmox.WebGUI.Forms.Design.ToolStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public virtual ToolStripItemCollection Items
		{
			get
			{
				if (mobjToolStripItemCollection == null)
				{
					mobjToolStripItemCollection = CreateItemCollection();
				}
				return mobjToolStripItemCollection;
			}
		}

		/// Passes a reference to the cached <see cref="P:Gizmox.WebGUI.Forms.Control.LayoutEngine"></see> returned by the layout engine interface.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Layout.LayoutEngine"></see> that represents the cached layout engine returned by the layout engine interface.</returns> 
		/// 2</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual LayoutEngine LayoutEngine => null;

		/// Gets or sets layout scheme characteristics.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.LayoutSettings"></see> representing the layout scheme characteristics.</returns> 
		/// 2</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public LayoutSettings LayoutSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating how the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> lays out the items collection.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The possible values are <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Table"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.Flow"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.StackWithOverflow"></see>, <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow"></see>, and <see cref="F:Gizmox.WebGUI.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value of <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see> is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values.</exception> 
		/// 1</filterpriority>
		[SRCategory("CatLayout")]
		[AmbientValue(0)]
		[SRDescription("ToolStripLayoutStyle")]
		public ToolStripLayoutStyle LayoutStyle
		{
			get
			{
				if (menmLayoutStyle == ToolStripLayoutStyle.StackWithOverflow)
				{
					switch (Orientation)
					{
					case Orientation.Horizontal:
						return ToolStripLayoutStyle.HorizontalStackWithOverflow;
					case Orientation.Vertical:
						return ToolStripLayoutStyle.VerticalStackWithOverflow;
					}
				}
				return menmLayoutStyle;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripLayoutStyle));
				}
				if (menmLayoutStyle == value)
				{
					return;
				}
				menmLayoutStyle = value;
				switch (value)
				{
				case ToolStripLayoutStyle.Flow:
					UpdateOrientation(Orientation.Horizontal);
					break;
				case ToolStripLayoutStyle.Table:
					UpdateOrientation(Orientation.Horizontal);
					break;
				default:
					if (value != ToolStripLayoutStyle.StackWithOverflow)
					{
						UpdateOrientation((value == ToolStripLayoutStyle.VerticalStackWithOverflow) ? Orientation.Vertical : Orientation.Horizontal);
					}
					else
					{
						UpdateLayoutStyle(Dock);
					}
					break;
				}
				OnLayoutStyleChanged(EventArgs.Empty);
				InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				Update();
			}
		}

		/// Gets the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Orientation"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>.</returns>
		[Browsable(false)]
		public Orientation Orientation => menmOrientation;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the overflow button for a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> with overflow enabled.</summary> 
		/// An object of type <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> with its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right"></see> and its <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> value set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.Never"></see>.</returns> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripOverflowButton OverflowButton => null;

		/// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the look and feel of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the look and feel of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripRenderer Renderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets or sets the painting styles to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripRenderMode.ManagerRenderMode"></see>.</returns> 
		/// <exception cref="T:System.NotSupportedException"> 
		///   <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripRenderMode.Custom"></see> without the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.Renderer"></see> property being assigned to a new instance of <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see>.</exception> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value being set is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values.</exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripRenderMode RenderMode
		{
			get
			{
				return ToolStripRenderMode.Custom;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether ToolTips are to be displayed on <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> items. </summary> 
		/// true if ToolTips are to be displayed; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatBehavior")]
		[SRDescription("ToolStripShowItemToolTipsDescr")]
		[DefaultValue(true)]
		public bool ShowItemToolTips
		{
			get
			{
				return mblnShowItemToolTips;
			}
			set
			{
				if (mblnShowItemToolTips != value)
				{
					mblnShowItemToolTips = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> stretches from end to end in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> stretches from end to end in its <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>; otherwise, false. The default is false.</returns>
		[SRCategory("CatLayout")]
		[DefaultValue(false)]
		[SRDescription("ToolStripStretchDescr")]
		public virtual bool Stretch
		{
			get
			{
				return mblnStretch;
			}
			set
			{
				if (mblnStretch != value)
				{
					mblnStretch = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the user can give the focus to an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> using the TAB key.</summary> 
		/// true if the user can give the focus to an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> using the TAB key; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatBehavior")]
		[SRDescription("ControlTabStopDescr")]
		[DefaultValue(false)]
		[DispId(-516)]
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
		/// Gets a value indicating whether strip supports menu stickiness.
		/// </summary>
		/// true</c> if [supports stickiness]; otherwise, false</c>.</value>
		protected virtual bool SupportMenuStickiness => false;

		/// Gets or sets the direction in which to draw text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripTextDirection.Horizontal"></see>. </returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values.</exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripTextDirectionDescr")]
		[DefaultValue(ToolStripTextDirection.Horizontal)]
		[SRCategory("CatAppearance")]
		public virtual ToolStripTextDirection TextDirection
		{
			get
			{
				ToolStripTextDirection toolStripTextDirection = menmToolStripTextDirection;
				if (toolStripTextDirection == ToolStripTextDirection.Inherit)
				{
					toolStripTextDirection = ToolStripTextDirection.Horizontal;
				}
				return toolStripTextDirection;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripTextDirection));
				}
				menmToolStripTextDirection = value;
			}
		}

		/// This property is not relevant for this class.</summary> 
		/// An instance of the <see cref="T:Gizmox.WebGUI.Forms.VScrollProperties"></see> class, which provides basic properties for a <see cref="T:Gizmox.WebGUI.Forms.VScrollBar"></see>.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public VScrollProperties VerticalScroll => null;

		/// 
		/// Gets the parent of this component.
		/// </summary>
		public override Component InternalParent
		{
			get
			{
				return base.InternalParent;
			}
			set
			{
				Component internalParent = base.InternalParent;
				if (internalParent == value)
				{
					return;
				}
				if (internalParent != null)
				{
					foreach (ToolStripItem item in Items)
					{
						if (item is ToolStripMenuItem toolStripMenuItem)
						{
							toolStripMenuItem.RemovingFromDOM();
						}
						else
						{
							if (!(item is ToolStripDropDownItem toolStripDropDownItem))
							{
								continue;
							}
							foreach (ToolStripItem dropDownItem in toolStripDropDownItem.DropDownItems)
							{
								if (dropDownItem is ToolStripMenuItem toolStripMenuItem2)
								{
									toolStripMenuItem2.RemovingFromDOM();
								}
							}
						}
					}
				}
				base.InternalParent = value;
				if (value == null)
				{
					return;
				}
				foreach (ToolStripItem item2 in Items)
				{
					if (item2 is ToolStripMenuItem toolStripMenuItem3)
					{
						toolStripMenuItem3.AttachedToDOM();
					}
					else
					{
						if (!(item2 is ToolStripDropDownItem toolStripDropDownItem2))
						{
							continue;
						}
						foreach (ToolStripItem dropDownItem2 in toolStripDropDownItem2.DropDownItems)
						{
							if (dropDownItem2 is ToolStripMenuItem toolStripMenuItem4)
							{
								toolStripMenuItem4.AttachedToDOM();
							}
						}
					}
				}
			}
		}

		/// 
		/// Resizable indication is disabled for ContextMenuStrip
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ResizableOptions Resizable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AutoSize"></see> property has changed.</summary>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SRCategory("CatPropertyChanged")]
		[Browsable(true)]
		[SRDescription("ControlOnAutoSizeChangedDescr")]
		public new event EventHandler AutoSizeChanged
		{
			add
			{
				base.AutoSizeChanged += value;
			}
			remove
			{
				base.AutoSizeChanged -= value;
			}
		}

		/// 
		/// Occurs when the user begins to drag the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> control.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler BeginDrag;

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.CausesValidation"></see> property changes.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new event EventHandler CausesValidationChanged;

		/// 
		/// This event is not relevant for this class.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ControlEventHandler"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event ControlEventHandler ControlAdded
		{
			add
			{
				base.ControlAdded += value;
			}
			remove
			{
				base.ControlAdded -= value;
			}
		}

		/// 
		/// This event is not relevant for this class.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ControlEventHandler"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event ControlEventHandler ControlRemoved
		{
			add
			{
				base.ControlRemoved += value;
			}
			remove
			{
				base.ControlRemoved -= value;
			}
		}

		/// 
		/// Occurs when the value of the <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> property changes.
		/// </summary>
		[Browsable(false)]
		public new event EventHandler CursorChanged
		{
			add
			{
				base.CursorChanged += value;
			}
			remove
			{
				base.CursorChanged -= value;
			}
		}

		/// 
		/// Occurs when the user stops dragging the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> control.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler EndDrag;

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ForeColor"></see> property changes.
		/// </summary>
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
		/// Occurs when a new <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is added to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>.
		/// </summary>
		[SRDescription("ToolStripItemAddedDescr")]
		[SRCategory("CatAppearance")]
		public event ToolStripItemEventHandler ItemAdded
		{
			add
			{
				AddHandler(ItemAddedEvent, value);
			}
			remove
			{
				RemoveHandler(ItemAddedEvent, value);
			}
		}

		/// 
		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.
		/// </summary>
		[SRDescription("ToolStripItemOnClickDescr")]
		[SRCategory("CatAction")]
		public event ToolStripItemClickedEventHandler ItemClicked
		{
			add
			{
				AddHandler(ItemClickedEvent, value);
			}
			remove
			{
				RemoveHandler(ItemClickedEvent, value);
			}
		}

		/// 
		/// Occurs when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is removed from the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see>.
		/// </summary>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripItemRemovedDescr")]
		public event ToolStripItemEventHandler ItemRemoved
		{
			add
			{
				AddHandler(ItemRemovedEvent, value);
			}
			remove
			{
				RemoveHandler(ItemRemovedEvent, value);
			}
		}

		/// Occurs when the layout of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is complete.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler LayoutCompleted;

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see> property changes.
		/// </summary>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripLayoutStyleChangedDescr")]
		public event EventHandler LayoutStyleChanged
		{
			add
			{
				AddHandler(LayoutStyleChangedEvent, value);
			}
			remove
			{
				RemoveHandler(LayoutStyleChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle is painted.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event PaintEventHandler PaintGrip;

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.Renderer"></see> property changes.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler RendererChanged;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class.</summary>
		public ToolStrip()
		{
			SuspendLayout();
			CanOverflow = true;
			TabStop = false;
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, blnValue: true);
			SetStyle(ControlStyles.Selectable, blnValue: false);
			Dock = DefaultDock;
			AutoSize = true;
			CausesValidation = false;
			Size defaultSize = DefaultSize;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ShowItemToolTips = DefaultShowItemToolTips;
			ImageScalingSize = SkinImageScalingSize;
			ResumeLayout(blnPerformLayout: true);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> class with the specified array of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>s.</summary> 
		/// <param name="items">An array of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> objects.</param>
		public ToolStrip(ToolStripItem[] items)
			: this()
		{
			Items.AddRange(items);
		}

		private bool ShouldSerializeDefaultDropDownDirection()
		{
			return false;
		}

		private bool ShouldSerializeGripMargin()
		{
			return ContainsValue(mobjGripMarginProperty);
		}

		private bool ShouldSerializeLayoutStyle()
		{
			return ContainsValue(menmLayoutStyleProperty);
		}

		private bool ShouldSerializeRenderMode()
		{
			return false;
		}

		/// Specifies the visual arrangement for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripLayoutStyle"></see> values. The default is null.</returns> 
		/// <param name="layoutStyle">The visual arrangement to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual LayoutSettings CreateLayoutSettings(ToolStripLayoutStyle layoutStyle)
		{
			return null;
		}

		/// This method is not relevant for this class.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Control"></see>.</returns> 
		/// <param name="point">A <see cref="T:System.Drawing.Point"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Control GetChildAtPoint(Point point)
		{
			return null;
		}

		/// This method is not relevant for this class.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Control"></see>.</returns> 
		/// <param name="skipValue">A <see cref="T:Gizmox.WebGUI.Forms.GetChildAtPointSkip"></see>  value.</param> 
		/// <param name="pt">A <see cref="T:System.Drawing.Point"></see> value.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Control GetChildAtPoint(Point pt, GetChildAtPointSkip skipValue)
		{
			return null;
		}

		/// Returns the item located at the specified x- and y-coordinates of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> client area.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> located at the specified location, or null if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not found.</returns> 
		/// <param name="y">The vertical coordinate, in pixels, from the top edge of the client area. </param> 
		/// <param name="x">The horizontal coordinate, in pixels, from the left edge of the client area. </param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripItem GetItemAt(int x, int y)
		{
			return null;
		}

		/// Returns the item located at the specified point in the client area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> at the specified location, or null if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not found.</returns> 
		/// <param name="point">The <see cref="T:System.Drawing.Point"></see> at which to search for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>. </param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripItem GetItemAt(Point point)
		{
			return null;
		}

		/// Retrieves the next <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> from the specified reference point and moving in the specified direction.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is specified by the start parameter and is next in the order as specified by the direction parameter.</returns> 
		/// <param name="direction">One of the values of <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see> that specifies the direction to move.</param> 
		/// <param name="start">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that is the reference point from which to begin the retrieval of the next item.</param> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value of the direction parameter is not one of the values of <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see>.</exception>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ToolStripItem GetNextItem(ToolStripItem start, ArrowDirection direction)
		{
			return null;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.BeginDrag"></see> event. </summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnBeginDrag(EventArgs e)
		{
		}

		/// 
		/// Updates the strip attributes externally.
		/// </summary>
		/// <param name="attributeType">Type of the attribute.</param>
		internal void UpdateStripAttributes(AttributeType attributeType)
		{
			UpdateParams(attributeType);
		}

		/// 
		/// Updates the orientation.
		/// </summary>
		/// <param name="objNewOrientation">The  new orientation.</param>
		private void UpdateOrientation(Orientation objNewOrientation)
		{
			if (objNewOrientation != Orientation)
			{
				menmOrientation = objNewOrientation;
				UpdateParams(AttributeType.Layout);
			}
		}

		/// 
		/// Updates the layout style.
		/// </summary>
		/// <param name="enmNewDock">The new dock value.</param>
		private void UpdateLayoutStyle(DockStyle enmNewDock)
		{
			if (menmLayoutStyle != ToolStripLayoutStyle.HorizontalStackWithOverflow && menmLayoutStyle != ToolStripLayoutStyle.VerticalStackWithOverflow)
			{
				if (enmNewDock == DockStyle.Left || enmNewDock == DockStyle.Right)
				{
					UpdateOrientation(Orientation.Vertical);
				}
				else
				{
					UpdateOrientation(Orientation.Horizontal);
				}
				OnLayoutStyleChanged(EventArgs.Empty);
			}
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objProposedSize">Size of the obj proposed.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size result = objProposedSize;
			if (base.Skin is ToolStripSkin toolStripSkin)
			{
				Size imageScalingSize = ImageScalingSize;
				bool flag = true;
				DockStyle dock = Dock;
				if (dock != DockStyle.None)
				{
					Size preferredSize = GetPreferredSize(toolStripSkin, objProposedSize);
					if (IsVerticalDocked(dock))
					{
						result.Height = preferredSize.Height;
					}
					else if (IsHorizontalDocked(dock))
					{
						result.Width = preferredSize.Width;
					}
					else if (Dock == DockStyle.Fill)
					{
						result = preferredSize;
					}
				}
				else
				{
					result = GetPreferredSize(toolStripSkin, objProposedSize);
					if (GripStyle == ToolStripGripStyle.Visible)
					{
						result.Width += toolStripSkin.HorizontalGripWidth;
					}
				}
			}
			return result;
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objImageScalingSize">Size of the obj image scaling.</param>
		/// <param name="objToolStripSkin">The obj tool strip skin.</param>
		/// <param name="objProposedSize">The obj size set as default or from designer.</param>
		/// </returns>
		private Size GetPreferredSize(ToolStripSkin objToolStripSkin, Size objProposedSize)
		{
			Size empty = Size.Empty;
			if (Items.Count == 0)
			{
				if (Orientation == Orientation.Vertical)
				{
					empty.Width = objProposedSize.Width;
				}
				else
				{
					empty.Height = objProposedSize.Height;
				}
			}
			else
			{
				foreach (ToolStripItem item in Items)
				{
					if (!item.Visible)
					{
						continue;
					}
					Size size = Size.Empty;
					if (!item.AutoSize)
					{
						size.Height = item.Height;
						size.Width = item.Width;
					}
					else
					{
						size = item.GetPreferredSize(item.Size);
					}
					if (Orientation == Orientation.Horizontal)
					{
						if (size.Height > empty.Height)
						{
							empty.Height = size.Height;
						}
						empty.Width += size.Width;
					}
					else
					{
						if (size.Width > empty.Width)
						{
							empty.Width = size.Width;
						}
						empty.Height += size.Height;
					}
				}
				empty.Height += objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Top) + objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Bottom);
				empty.Width += objToolStripSkin.Padding.Horizontal + objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Left) + objToolStripSkin.GetFrameEdgeSize(objToolStripSkin.FrameStyle, CommonSkin.FrameEdge.Right);
			}
			return empty + Padding.Size;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.EndDrag"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnEndDrag(EventArgs e)
		{
		}

		/// Creates a default <see cref="T:System.Windows.Forms.ToolStripItem"></see> with the specified text, image, and event handler on a new <see cref="T:System.Windows.Forms.ToolStrip"></see> instance.</summary>
		/// A <see cref="M:System.Windows.Forms.ToolStripButton.#ctor(System.String,Gizmox.WebGUI.Common.Resources.ResourceHandle,System.EventHandler)"></see>, or a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see> if the text parameter is a hyphen (-).</returns>
		/// <param name="onClick">An event handler that raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event when the <see cref="T:System.Windows.Forms.ToolStripItem"></see> is clicked.</param>
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</param>
		/// <param name="text">The text to use for the <see cref="T:System.Windows.Forms.ToolStripItem"></see>. If the text parameter is a hyphen (-), this method creates a <see cref="T:System.Windows.Forms.ToolStripSeparator"></see>.</param>
		protected internal virtual ToolStripItem CreateDefaultItem(string text, ResourceHandle image, EventHandler onClick)
		{
			if (text == "-")
			{
				return new ToolStripSeparator();
			}
			return new ToolStripButton(text, image, onClick);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.ItemClicked"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemClickedEventArgs"></see> that contains the event data. </param>
		protected internal virtual void OnItemClicked(ToolStripItemClickedEventArgs e)
		{
			ItemClickedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemAdded"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
		protected internal virtual void OnItemAdded(ToolStripItemEventArgs e)
		{
			ItemAddedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.ToolStrip.ItemRemoved"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> that contains the event data.</param>
		protected internal virtual void OnItemRemoved(ToolStripItemEventArgs e)
		{
			ItemRemovedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.LayoutCompleted"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnLayoutCompleted(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyleChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnLayoutStyleChanged(EventArgs e)
		{
			LayoutStyleChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStrip.RendererChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRendererChanged(EventArgs e)
		{
		}

		/// 
		/// This method is not relevant for this class.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new void ResetMinimumSize()
		{
		}

		/// Controls the return location of the focus.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void RestoreFocus()
		{
		}

		/// This method is not relevant for this class.</summary> 
		/// <param name="y">An <see cref="T:System.Int32"></see>.</param> 
		/// <param name="x">An <see cref="T:System.Int32"></see>.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new void SetAutoScrollMargin(int x, int y)
		{
		}

		/// 
		/// Resets the collection of displayed and overflow items after a layout is done.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void SetDisplayedItems()
		{
		}

		/// Enables you to change the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// <param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> whose <see cref="P:Gizmox.WebGUI.Forms.Control.Parent"></see> property is to be changed. </param> 
		/// <param name="parent">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the parent of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> referred to by the item parameter. </param>
		protected static void SetItemParent(ToolStripItem item, ToolStrip parent)
		{
			item.ParentInternal = parent;
		}

		/// 
		/// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
		/// </summary>
		/// 
		/// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
		/// </returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(", Name: ");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Items: ").Append(Items.Count);
			return stringBuilder.ToString();
		}

		/// 
		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
		/// </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				try
				{
					SuspendLayout();
					if (!Items.IsReadOnly)
					{
						for (int num = Items.Count - 1; num >= 0; num--)
						{
							Items[num].Dispose();
						}
						Items.Clear();
					}
				}
				finally
				{
					ResumeLayout(blnPerformLayout: false);
				}
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			if (mobjToolStripItemCollection != null)
			{
				UnRegisterBatch(mobjToolStripItemCollection);
			}
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			if (mobjToolStripItemCollection != null)
			{
				RegisterBatch(mobjToolStripItemCollection);
			}
		}

		/// 
		/// Raises the <see cref="E:EnabledChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			for (int i = 0; i < Items.Count; i++)
			{
				if (Items[i] != null && Items[i].ParentInternal == this)
				{
					Items[i].OnParentEnabledChanged(e);
				}
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			ToolStripItem toolStripItem = null;
			string member = objEvent.Member;
			if (!string.IsNullOrEmpty(member))
			{
				int result = -1;
				if (int.TryParse(member, out result))
				{
					toolStripItem = Items[result - 1];
				}
			}
			if (toolStripItem != null)
			{
				toolStripItem.FireToolStripItemEvent(objEvent);
			}
			else
			{
				base.FireEvent(objEvent);
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (ToolStripItem item in Items)
			{
				item.RenderToolStripItem(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			foreach (ToolStripItem item in Items)
			{
				item.PreRenderToolStripItem(objContext, lngRequestID);
			}
			base.PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Posts the render control.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal override void PostRenderControl(IContext objContext, long lngRequestID)
		{
			base.PostRenderControl(objContext, lngRequestID);
			foreach (ToolStripItem item in Items)
			{
				item.PostRenderToolStripItem(objContext, lngRequestID);
			}
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("SF", "1");
			RenderWrapContentsAttribute(objWriter, blnForceRender: false);
			RenderShowGripAttribute(objWriter, blnForceRender: false);
			RenderImageSizeAttributes(objWriter, blnForceRender: false);
			RenderOrientationAttribute(objWriter);
			if (SupportMenuStickiness)
			{
				objWriter.WriteAttributeString("SMS", "1");
			}
		}

		/// 
		/// Renders the show grip attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowGripAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			ToolStripGripStyle gripStyle = GripStyle;
			if (gripStyle == ToolStripGripStyle.Hidden || blnForceRender)
			{
				objWriter.WriteAttributeString("SG", (gripStyle == ToolStripGripStyle.Hidden) ? "0" : "1");
			}
		}

		/// 
		/// Renders the image size attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderImageSizeAttributes(IAttributeWriter objWriter, bool blnForceRender)
		{
			Size imageScalingSize = ImageScalingSize;
			objWriter.WriteAttributeString("IH", imageScalingSize.Height.ToString(CultureInfo.InvariantCulture));
			objWriter.WriteAttributeString("IW", imageScalingSize.Width.ToString(CultureInfo.InvariantCulture));
		}

		/// 
		/// Renders the orientation attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderOrientationAttribute(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("ORI", Convert.ToInt32(Orientation).ToString());
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
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderWrapContentsAttribute(objWriter, blnForceRender: true);
				RenderShowGripAttribute(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderImageSizeAttributes(objWriter, blnForceRender: true);
				RenderOrientationAttribute(objWriter);
			}
		}

		/// 
		/// Renders the wrap contents attribute.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderWrapContentsAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool canOverflow = CanOverflow;
			if (blnForceRender || !canOverflow)
			{
				objWriter.WriteAttributeString("WC", canOverflow ? "1" : "0");
			}
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			Type type = Type.GetType(strOffspringTypeName);
			if (type != null && CommonUtils.IsTypeOrSubType(type, typeof(ToolStripItem)))
			{
				return Items;
			}
			return base.GetComponentOffsprings(strOffspringTypeName);
		}

		/// 
		/// Resets the grip margin.
		/// </summary>
		private void ResetGripMargin()
		{
			RemoveValue(mobjGripMarginProperty);
		}

		internal bool ShouldSerializeImageScalingSize()
		{
			return ImageScalingSize != SkinImageScalingSize;
		}

		/// 
		/// Resets the image size.
		/// </summary>
		private void ResetImageScalingSize()
		{
			ImageScalingSize = SkinImageScalingSize;
		}

		/// 
		/// Creates the item collection.
		/// </summary>
		/// </returns>
		protected virtual ToolStripItemCollection CreateItemCollection()
		{
			return new ToolStripItemCollection(this, itemsCollection: true);
		}

		static ToolStrip()
		{
			LayoutStyleChanged = SerializableEvent.Register("LayoutStyleChanged", typeof(EventHandler), typeof(ToolStrip));
			ItemAdded = SerializableEvent.Register("ItemAdded", typeof(ToolStripItemEventHandler), typeof(ToolStrip));
			ItemRemoved = SerializableEvent.Register("ItemRemoved", typeof(ToolStripItemEventHandler), typeof(ToolStrip));
		}
	}
}
