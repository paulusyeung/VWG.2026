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
	///
	/// </summary>
	[Serializable]
	[DefaultProperty("Text")]
	[DefaultEvent("Click")]
	[ToolboxItem(false)]
	[DesignTimeVisible(false)]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public abstract class ToolStripItem : Component, IDropTarget, IArrangedElement, IComponent, IDisposable, IRegisteredComponentMember, IEventHandler, ISkinable
	{
        // Explicit IArrangedElement implementations (CS0737 fix - SerializableObject.GetValue/SetValue are not public)
        T IArrangedElement.GetValue<T>(Gizmox.WebGUI.Common.Interfaces.SerializableProperty key) => GetValue<T>(key);
        void IArrangedElement.SetValue<T>(Gizmox.WebGUI.Common.Interfaces.SerializableProperty key, T value) => SetValue(key, value);

		private static readonly SerializableProperty mobjParentProperty = SerializableProperty.Register("mobjParent", typeof(ToolStrip), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjOwnerProperty = SerializableProperty.Register("mobjOwner", typeof(ToolStrip), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjFontProperty = SerializableProperty.Register("mobjFont", typeof(Font), typeof(ToolStripItem));

		private static readonly SerializableProperty menmDisplayStyleProperty = SerializableProperty.Register("menmDisplayStyle", typeof(ToolStripItemDisplayStyle), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjBoundsProperty = SerializableProperty.Register("mobjBounds", typeof(Rectangle), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjTagProperty = SerializableProperty.Register("mobjTag", typeof(object), typeof(ToolStripItem));

		private static readonly SerializableProperty mstrTextProperty = SerializableProperty.Register("mstrText", typeof(string), typeof(ToolStripItem));

		private static readonly SerializableProperty menmRightToLeftProperty = SerializableProperty.Register("menmRightToLeft", typeof(RightToLeft), typeof(ToolStripItem));

		private static readonly SerializableProperty mblnEnabledProperty = SerializableProperty.Register("mblnEnabled", typeof(bool), typeof(ToolStripItem));

		private static readonly SerializableProperty mblnDoubleClickEnabledProperty = SerializableProperty.Register("mblnDoubleClickEnabled", typeof(bool), typeof(ToolStripItem));

		private static readonly SerializableProperty menmDockProperty = SerializableProperty.Register("menmDock", typeof(DockStyle), typeof(ToolStripItem));

		private static readonly SerializableProperty menmBackgroundImageLayoutProperty = SerializableProperty.Register("menmBackgroundImageLayout", typeof(ImageLayout), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjBackgroundImageProperty = SerializableProperty.Register("mobjBackgroundImage", typeof(ResourceHandle), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjBackColorProperty = SerializableProperty.Register("mobjBackColor", typeof(Color), typeof(ToolStripItem));

		private static readonly SerializableProperty menmAlignmentProperty = SerializableProperty.Register("menmAlignment", typeof(ToolStripItemAlignment), typeof(ToolStripItem));

		private static readonly SerializableProperty menmAnchorProperty = SerializableProperty.Register("menmAnchor", typeof(AnchorStyles), typeof(ToolStripItem));

		private static readonly SerializableProperty mblnAutoSizeProperty = SerializableProperty.Register("mblnAutoSize", typeof(bool), typeof(ToolStripItem));

		private static readonly SerializableProperty mblnAutoToolTipProperty = SerializableProperty.Register("mblnAutoToolTip", typeof(bool), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjForeColorProperty = SerializableProperty.Register("mobjForeColor", typeof(Color), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjImageProperty = SerializableProperty.Register("mobjImage", typeof(ResourceHandle), typeof(ToolStripItem));

		private static readonly SerializableProperty menmImageAlignProperty = SerializableProperty.Register("menmImageAlign", typeof(ContentAlignment), typeof(ToolStripItem));

		private static readonly SerializableProperty mintImageIndexProperty = SerializableProperty.Register("mintImageIndex", typeof(int), typeof(ToolStripItem), new SerializablePropertyMetadata(-1));

		private static readonly SerializableProperty mstrImageKeyProperty = SerializableProperty.Register("mstrImageKey", typeof(string), typeof(ToolStripItem), new SerializablePropertyMetadata(string.Empty));

		private static readonly SerializableProperty mobjMarginProperty = SerializableProperty.Register("mobjMargin", typeof(Padding), typeof(ToolStripItem));

		private static readonly SerializableProperty menmMergeActionProperty = SerializableProperty.Register("menmMergeAction", typeof(MergeAction), typeof(ToolStripItem));

		private static readonly SerializableProperty mintMergeIndexProperty = SerializableProperty.Register("mintMergeIndex", typeof(int), typeof(ToolStripItem), new SerializablePropertyMetadata(-1));

		private static readonly SerializableProperty mstrNameProperty = SerializableProperty.Register("mstrName", typeof(string), typeof(ToolStripItem));

		private static readonly SerializableProperty mobjPaddingProperty = SerializableProperty.Register("mobjPadding", typeof(Padding), typeof(ToolStripItem));

		private static readonly SerializableProperty menmPlacementProperty = SerializableProperty.Register("menmPlacement", typeof(ToolStripItemPlacement), typeof(ToolStripItem));

		private static readonly SerializableProperty mblnRightToLeftAutoMirrorImageProperty = SerializableProperty.Register("mblnRightToLeftAutoMirrorImage", typeof(bool), typeof(ToolStripItem));

		private static readonly SerializableProperty menmTextAlignProperty = SerializableProperty.Register("menmTextAlign", typeof(ContentAlignment), typeof(ToolStripItem));

		private static readonly SerializableProperty menmTextDirectionProperty = SerializableProperty.Register("menmTextDirection", typeof(ToolStripTextDirection), typeof(ToolStripItem));

		private static readonly SerializableProperty menmTextImageRelationProperty = SerializableProperty.Register("menmTextImageRelation", typeof(TextImageRelation), typeof(ToolStripItem));

		private static readonly SerializableProperty memnImageScalingProperty = SerializableProperty.Register("memnImageScaling", typeof(ToolStripItemImageScaling), typeof(ToolStripItem));

		private static readonly SerializableProperty mstrToolTipTextProperty = SerializableProperty.Register("mstrToolTipText", typeof(string), typeof(ToolStripItem));

		private static readonly SerializableProperty mstrCustomStyleProperty = SerializableProperty.Register("CustomStyle", typeof(string), typeof(ToolStripItem), new SerializablePropertyMetadata(string.Empty));

		private static readonly SerializableEvent AvailableChangedEvent;

		private static readonly SerializableEvent BackColorChangedEvent;

		protected static readonly SerializableEvent ClickEvent;

		private static readonly SerializableEvent DisplayStyleChangedEvent;

		protected static readonly SerializableEvent DoubleClickEvent;

		private static readonly SerializableEvent EnabledChangedEvent;

		private static readonly SerializableEvent ForeColorChangedEvent;

		private static readonly SerializableEvent LocationChangedEvent;

		protected static readonly SerializableEvent MouseDownEvent;

		protected static readonly SerializableEvent MouseUpEvent;

		private static readonly SerializableEvent RightToLeftChangedEvent;

		private static readonly SerializableEvent OwnerChangedEvent;

		private static readonly SerializableEvent VisibleChangedEvent;

		protected static readonly SerializableEvent TextChangedEvent;

		/// 
		/// Gets the available changed handler.
		/// </summary>
		/// The available changed handler.</value>
		private EventHandler AvailableChangedHandler => (EventHandler)GetHandler(AvailableChanged);

		/// 
		/// Gets the back color changed handler.
		/// </summary>
		/// The back color changed handler.</value>
		private EventHandler BackColorChangedHandler => (EventHandler)GetHandler(BackColorChanged);

		/// 
		/// Gets the click handler.
		/// </summary>
		/// The click handler.</value>
		private EventHandler ClickHandler => (EventHandler)GetHandler(ClickEvent);

		/// 
		/// Gets the DisplayStyleChanged handler.
		/// </summary>
		/// The DisplayStyleChanged handler.</value>
		private EventHandler DisplayStyleChangedHandler => (EventHandler)GetHandler(DisplayStyleChanged);

		/// 
		/// Gets the DoubleClick handler.
		/// </summary>
		/// The DoubleClick handler.</value>
		private EventHandler DoubleClickHandler => (EventHandler)GetHandler(DoubleClickEvent);

		/// 
		/// Gets the EnabledChanged handler.
		/// </summary>
		/// The EnabledChanged handler.</value>
		private EventHandler EnabledChangedHandler => (EventHandler)GetHandler(EnabledChanged);

		/// 
		/// Gets the ForeColorChanged handler.
		/// </summary>
		/// The ForeColorChanged handler.</value>
		private EventHandler ForeColorChangedHandler => (EventHandler)GetHandler(ForeColorChanged);

		/// 
		/// Gets the LocationChanged handler.
		/// </summary>
		/// The LocationChanged handler.</value>
		private EventHandler LocationChangedHandler => (EventHandler)GetHandler(LocationChanged);

		/// 
		/// Gets the MouseDown handler.
		/// </summary>
		/// The MouseDown handler.</value>
		private MouseEventHandler MouseDownHandler => (MouseEventHandler)GetHandler(MouseDownEvent);

		/// 
		/// Gets the MouseUp handler.
		/// </summary>
		/// The MouseUp handler.</value>
		private MouseEventHandler MouseUpHandler => (MouseEventHandler)GetHandler(MouseUpEvent);

		/// 
		/// Gets the OwnerChanged handler.
		/// </summary>
		/// The OwnerChanged handler.</value>
		private EventHandler OwnerChangedHandler => (EventHandler)GetHandler(OwnerChanged);

		/// 
		/// Gets the RightToLeftChanged handler.
		/// </summary>
		/// The RightToLeftChanged handler.</value>
		private EventHandler RightToLeftChangedHandler => (EventHandler)GetHandler(RightToLeftChanged);

		/// 
		/// Gets the TextChanged handler.
		/// </summary>
		/// The TextChanged handler.</value>
		private EventHandler TextChangedHandler => (EventHandler)GetHandler(TextChangedEvent);

		/// 
		/// Gets the VisibleChanged handler.
		/// </summary>
		/// The VisibleChanged handler.</value>
		private EventHandler VisibleChangedHandler => (EventHandler)GetHandler(VisibleChanged);

		private ToolStrip mobjParent
		{
			get
			{
				return GetValue(mobjParentProperty, null);
			}
			set
			{
				SetValue(mobjParentProperty, value);
			}
		}

		private ToolStrip mobjOwner
		{
			get
			{
				return GetValue(mobjOwnerProperty, null);
			}
			set
			{
				SetValue(mobjOwnerProperty, value);
			}
		}

		private Font mobjFont
		{
			get
			{
				return GetValue(mobjFontProperty);
			}
			set
			{
				SetValue(mobjFontProperty, value);
			}
		}

		private ToolStripItemDisplayStyle menmDisplayStyle
		{
			get
			{
				return GetValue(menmDisplayStyleProperty);
			}
			set
			{
				SetValue(menmDisplayStyleProperty, value);
			}
		}

		private Rectangle mobjBounds
		{
			get
			{
				return GetValue(mobjBoundsProperty);
			}
			set
			{
				SetValue(mobjBoundsProperty, value);
			}
		}

		private object mobjTag
		{
			get
			{
				return GetValue(mobjTagProperty, null);
			}
			set
			{
				SetValue(mobjTagProperty, value);
			}
		}

		private string mstrText
		{
			get
			{
				return GetValue(mstrTextProperty, string.Empty);
			}
			set
			{
				SetValue(mstrTextProperty, value);
			}
		}

		private RightToLeft menmRightToLeft
		{
			get
			{
				return GetValue(menmRightToLeftProperty);
			}
			set
			{
				SetValue(menmRightToLeftProperty, value);
			}
		}

		internal bool mblnEnabled
		{
			get
			{
				return GetValue(mblnEnabledProperty);
			}
			set
			{
				SetValue(mblnEnabledProperty, value);
			}
		}

		private bool mblnDoubleClickEnabled
		{
			get
			{
				return GetValue(mblnDoubleClickEnabledProperty);
			}
			set
			{
				SetValue(mblnDoubleClickEnabledProperty, value);
			}
		}

		private DockStyle menmDock
		{
			get
			{
				return GetValue(menmDockProperty);
			}
			set
			{
				SetValue(menmDockProperty, value);
			}
		}

		private ImageLayout menmBackgroundImageLayout
		{
			get
			{
				return GetValue(menmBackgroundImageLayoutProperty, ImageLayout.Tile);
			}
			set
			{
				SetValue(menmBackgroundImageLayoutProperty, value);
			}
		}

		private ResourceHandle mobjBackgroundImage
		{
			get
			{
				return GetValue(mobjBackgroundImageProperty, null);
			}
			set
			{
				SetValue(mobjBackgroundImageProperty, value);
			}
		}

		private Color mobjBackColor
		{
			get
			{
				return GetValue(mobjBackColorProperty, Color.Empty);
			}
			set
			{
				SetValue(mobjBackColorProperty, value);
			}
		}

		private ToolStripItemAlignment menmAlignment
		{
			get
			{
				return GetValue(menmAlignmentProperty);
			}
			set
			{
				SetValue(menmAlignmentProperty, value);
			}
		}

		private AnchorStyles menmAnchor
		{
			get
			{
				return GetValue(menmAnchorProperty, AnchorStyles.Left | AnchorStyles.Top);
			}
			set
			{
				SetValue(menmAnchorProperty, value, AnchorStyles.Left | AnchorStyles.Top);
			}
		}

		private bool mblnAutoSize
		{
			get
			{
				return GetValue(mblnAutoSizeProperty);
			}
			set
			{
				SetValue(mblnAutoSizeProperty, value);
			}
		}

		private bool mblnAutoToolTip
		{
			get
			{
				return GetValue(mblnAutoToolTipProperty);
			}
			set
			{
				SetValue(mblnAutoToolTipProperty, value);
			}
		}

		private Color mobjForeColor
		{
			get
			{
				return GetValue(mobjForeColorProperty);
			}
			set
			{
				SetValue(mobjForeColorProperty, value);
			}
		}

		private ResourceHandle mobjImage
		{
			get
			{
				return GetValue(mobjImageProperty, null);
			}
			set
			{
				SetValue(mobjImageProperty, value);
			}
		}

		private ContentAlignment menmImageAlign
		{
			get
			{
				return GetValue(menmImageAlignProperty);
			}
			set
			{
				SetValue(menmImageAlignProperty, value);
			}
		}

		private int mintImageIndex
		{
			get
			{
				return GetValue(mintImageIndexProperty, -1);
			}
			set
			{
				SetValue(mintImageIndexProperty, value);
			}
		}

		private string mstrImageKey
		{
			get
			{
				return GetValue(mstrImageKeyProperty, string.Empty);
			}
			set
			{
				SetValue(mstrImageKeyProperty, value);
			}
		}

		private Padding mobjMargin
		{
			get
			{
				return GetValue(mobjMarginProperty);
			}
			set
			{
				SetValue(mobjMarginProperty, value);
			}
		}

		private MergeAction menmMergeAction
		{
			get
			{
				return GetValue(menmMergeActionProperty, MergeAction.Append);
			}
			set
			{
				SetValue(menmMergeActionProperty, value);
			}
		}

		private int mintMergeIndex
		{
			get
			{
				return GetValue(mintMergeIndexProperty);
			}
			set
			{
				SetValue(mintMergeIndexProperty, value);
			}
		}

		private string mstrName
		{
			get
			{
				return GetValue(mstrNameProperty, string.Empty);
			}
			set
			{
				SetValue(mstrNameProperty, value);
			}
		}

		private Padding mobjPadding
		{
			get
			{
				return GetValue(mobjPaddingProperty);
			}
			set
			{
				SetValue(mobjPaddingProperty, value);
			}
		}

		private ToolStripItemPlacement menmPlacement
		{
			get
			{
				return GetValue(menmPlacementProperty);
			}
			set
			{
				SetValue(menmPlacementProperty, value);
			}
		}

		private bool mblnRightToLeftAutoMirrorImage
		{
			get
			{
				return GetValue(mblnRightToLeftAutoMirrorImageProperty);
			}
			set
			{
				SetValue(mblnRightToLeftAutoMirrorImageProperty, value);
			}
		}

		private ContentAlignment menmTextAlign
		{
			get
			{
				return GetValue(menmTextAlignProperty);
			}
			set
			{
				SetValue(menmTextAlignProperty, value);
			}
		}

		private ToolStripTextDirection menmTextDirection
		{
			get
			{
				return GetValue(menmTextDirectionProperty, ToolStripTextDirection.Inherit);
			}
			set
			{
				SetValue(menmTextDirectionProperty, value);
			}
		}

		private TextImageRelation menmTextImageRelation
		{
			get
			{
				return GetValue(menmTextImageRelationProperty);
			}
			set
			{
				SetValue(menmTextImageRelationProperty, value);
			}
		}

		private string mstrToolTipText
		{
			get
			{
				return GetValue(mstrToolTipTextProperty);
			}
			set
			{
				SetValue(mstrToolTipTextProperty, value);
			}
		}

		private ToolStripItemImageScaling menmImageScaling
		{
			get
			{
				return GetValue(memnImageScalingProperty);
			}
			set
			{
				SetValue(memnImageScalingProperty, value);
			}
		}

		/// 
		/// Gets the font from skin.
		/// </summary>
		/// 
		/// The color of the skin fore.
		/// </value>
		protected virtual Font SkinFont
		{
			get
			{
				Font result = null;
				if (SkinFactory.GetSkin(this) is CommonSkin commonSkin)
				{
					result = commonSkin.Font;
				}
				return result;
			}
		}

		/// 
		/// Gets the forecolor from skin.
		/// </summary>
		/// 
		/// The color of the skin fore.
		/// </value>
		protected virtual Color SkinForeColor
		{
			get
			{
				Color result = Color.Empty;
				if (SkinFactory.GetSkin(this) is CommonSkin commonSkin)
				{
					result = commonSkin.ForeColor;
				}
				return result;
			}
		}

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected virtual int ToolStripItemType => -1;

		/// Gets or sets a value indicating whether the item aligns towards the beginning or end of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Left"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemAlignment"></see> values. </exception> 
		/// 1</filterpriority>
		[SRDescription("ToolStripItemAlignmentDescr")]
		[DefaultValue(ToolStripItemAlignment.Left)]
		[SRCategory("CatLayout")]
		public ToolStripItemAlignment Alignment
		{
			get
			{
				return menmAlignment;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripItemAlignment));
				}
				if (menmAlignment != value)
				{
					menmAlignment = value;
				}
			}
		}

		/// Gets or sets a value indicating whether drag-and-drop and item reordering are handled through events that you implement.</summary> 
		/// true if drag-and-drop operations are allowed in the control; otherwise, false. The default is false.</returns> 
		/// <exception cref="T:System.ArgumentException"> 
		///   <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.AllowDrop"></see> and <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.AllowItemReorder"></see> are both set to true. </exception> 
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
		public new virtual bool AllowDrop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets the edges of the container to which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is bound and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>  is resized with its parent.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value is not one of the <see cref="T:Gizmox.WebGUI.Forms.AnchorStyles"></see> values.</exception> 
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(AnchorStyles.Left | AnchorStyles.Top)]
		public AnchorStyles Anchor
		{
			get
			{
				return menmAnchor;
			}
			set
			{
				if (value != Anchor)
				{
					menmAnchor = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the item is automatically sized.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically sized; otherwise, false. The default value is true.</returns> 
		/// 1</filterpriority>
		[SRDescription("ToolStripItemAutoSizeDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		public bool AutoSize
		{
			get
			{
				return mblnAutoSize;
			}
			set
			{
				if (mblnAutoSize != value)
				{
					mblnAutoSize = value;
					if (!base.DesignMode)
					{
						InvalidateParentLayout();
					}
				}
			}
		}

		/// Gets or sets a value indicating whether to use the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ToolTipText"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> ToolTip. </summary> 
		/// true to use the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property for the ToolTip; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRDescription("ToolStripItemAutoToolTipDescr")]
		[SRCategory("CatBehavior")]
		public bool AutoToolTip
		{
			get
			{
				return mblnAutoToolTip;
			}
			set
			{
				if (mblnAutoToolTip != value)
				{
					mblnAutoToolTip = value;
					UpdateParams(AttributeType.ToolTip);
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> should be placed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is placed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>; otherwise, false.</returns>
		[SRDescription("ToolStripItemAvailableDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Available
		{
			get
			{
				return GetState(ComponentState.Visible);
			}
			set
			{
				if (Available != value)
				{
					SetVisibleCore(value);
				}
			}
		}

		/// Gets or sets the background color for the item.</summary> 
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of the item. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripItemBackColorDescr")]
		public virtual Color BackColor
		{
			get
			{
				if (!mobjBackColor.IsEmpty)
				{
					return mobjBackColor;
				}
				return ((Control)ParentInternal)?.BackColor ?? Color.FromKnownColor(KnownColor.Control);
			}
			set
			{
				Color backColor = BackColor;
				if (!value.IsEmpty)
				{
					mobjBackColor = value;
				}
				if (!backColor.Equals(BackColor))
				{
					OnBackColorChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets the background image.
		/// </summary>
		/// 
		/// The background image.
		/// </value>
		[DefaultValue(null)]
		[SRDescription("ToolStripItemImageDescr")]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		public virtual ResourceHandle BackgroundImage
		{
			get
			{
				return mobjBackgroundImage;
			}
			set
			{
				if (BackgroundImage != value)
				{
					mobjBackgroundImage = value;
					Invalidate();
				}
			}
		}

		/// Gets or sets the background image layout used for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>.</returns> 
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlBackgroundImageLayoutDescr")]
		[DefaultValue(ImageLayout.Tile)]
		[Localizable(true)]
		public virtual ImageLayout BackgroundImageLayout
		{
			get
			{
				return menmBackgroundImageLayout;
			}
			set
			{
				if (BackgroundImageLayout != value)
				{
					if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
					{
						throw new InvalidEnumArgumentException("value", (int)value, typeof(ImageLayout));
					}
					menmBackgroundImageLayout = value;
					Invalidate();
				}
			}
		}

		/// Gets the size and location of the item.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual Rectangle Bounds => mobjBounds;

		/// Gets a value indicating whether the item can be selected.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be selected; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual bool CanSelect => true;

		/// Gets the area where content, such as text and icons, can be placed within a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> without overwriting background borders.</summary> 
		/// A <see cref="T:System.Drawing.Rectangle"></see> containing four integers that represent the location and size of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> contents, excluding its border.</returns> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle ContentRectangle => Rectangle.Empty;

		/// 
		/// Gets or sets the control custom style.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		[SRDescription("ControlCustomStyleDescr")]
		[SRCategory("CatAppearance")]
		public virtual string CustomStyle
		{
			get
			{
				return GetValue(mstrCustomStyleProperty);
			}
			set
			{
				if (SetValue(mstrCustomStyleProperty, value))
				{
					Invalidate();
				}
			}
		}

		/// Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default.</summary> 
		/// false in all cases.</returns>
		protected virtual bool DefaultAutoToolTip => false;

		/// Gets the default margin of an item.</summary>
		/// A <see cref="T:System.Windows.Forms.Padding"></see> representing the margin.</returns>
		protected internal virtual Padding DefaultMargin
		{
			get
			{
				if (Owner != null && Owner is StatusStrip)
				{
					return new Padding(0, 2, 0, 0);
				}
				return new Padding(0, 1, 0, 2);
			}
		}

		/// Gets the internal spacing characteristics of the item.</summary>
		/// One of the <see cref="T:System.Windows.Forms.Padding"></see> values.</returns>
		protected virtual Padding DefaultPadding => Padding.Empty;

		/// Gets a value indicating what is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.ImageAndText"></see>.</returns>
		protected virtual ToolStripItemDisplayStyle DefaultDisplayStyle => ToolStripItemDisplayStyle.ImageAndText;

		/// Gets the internal spacing characteristics of the item.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> values.</returns>
		protected virtual Size DefaultSize => new Size(23, 23);

		/// Gets or sets whether text and images are displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.ImageAndText"></see> .</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemDisplayStyleDescr")]
		[SRCategory("CatAppearance")]
		public virtual ToolStripItemDisplayStyle DisplayStyle
		{
			get
			{
				return menmDisplayStyle;
			}
			set
			{
				if (menmDisplayStyle != value)
				{
					if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
					{
						throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripItemDisplayStyle));
					}
					menmDisplayStyle = value;
					OnDisplayStyleChanged(new EventArgs());
					Owner?.Update();
				}
			}
		}

		/// Gets or sets which <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> borders are docked to its parent control and determines how a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is resized with its parent.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DockStyle.None"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.DockStyle"></see> values.</exception> 
		/// 1</filterpriority>
		[DefaultValue(DockStyle.None)]
		[Browsable(false)]
		public DockStyle Dock
		{
			get
			{
				return menmDock;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 5))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DockStyle));
				}
				if (value != Dock)
				{
					menmDock = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be activated by double-clicking the mouse. </summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> can be activated by double-clicking the mouse; otherwise, false. The default is false.</returns>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("ToolStripItemDoubleClickedEnabledDescr")]
		public bool DoubleClickEnabled
		{
			get
			{
				return mblnDoubleClickEnabled;
			}
			set
			{
				if (mblnDoubleClickEnabled != value)
				{
					mblnDoubleClickEnabled = value;
				}
			}
		}

		/// Gets or sets a value indicating whether the parent control of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is enabled. </summary> 
		/// true if the parent control of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is enabled; otherwise, false. The default is true.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemEnabledDescr")]
		[Localizable(true)]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public virtual bool Enabled
		{
			get
			{
				bool flag = true;
				if (Owner != null)
				{
					flag = Owner.Enabled;
				}
				return mblnEnabled && flag;
			}
			set
			{
				if (mblnEnabled != value)
				{
					mblnEnabled = value;
					OnEnabledChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets the font of the text displayed by the item.</summary> 
		/// The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultFont"></see> property.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripItemFontDescr")]
		[Localizable(true)]
		public virtual Font Font
		{
			get
			{
				if (mobjFont == null)
				{
					Font ownerFont = GetOwnerFont();
					if (ownerFont != null)
					{
						return ownerFont;
					}
				}
				return mobjFont;
			}
			set
			{
				if (mobjFont != value)
				{
					mobjFont = value;
					OnFontChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets or sets the foreground color of the item.</summary> 
		/// The foreground <see cref="T:System.Drawing.Color"></see> of the item. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultForeColor"></see> property.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemForeColorDescr")]
		[SRCategory("CatAppearance")]
		public virtual Color ForeColor
		{
			get
			{
				Color result = mobjForeColor;
				if (!result.IsEmpty)
				{
					return result;
				}
				ToolStrip owner = Owner;
				if (owner != null && owner.HasForeColor)
				{
					Color foreColor = owner.ForeColor;
					if (!foreColor.IsEmpty)
					{
						return foreColor;
					}
				}
				return SkinForeColor;
			}
			set
			{
				Color foreColor = ForeColor;
				if (!value.IsEmpty)
				{
					mobjForeColor = value;
				}
				if (!foreColor.Equals(ForeColor))
				{
					OnForeColorChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the height, in pixels, of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// An <see cref="T:System.Int32"></see> representing the height, in pixels.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Browsable(false)]
		[SRCategory("CatLayout")]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Height
		{
			get
			{
				return Bounds.Height;
			}
			set
			{
				Rectangle bounds = Bounds;
				if (bounds.Height != value)
				{
					SetBounds(bounds.X, bounds.Y, bounds.Width, value);
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// Gets or sets the parent container of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStrip"></see> that is the parent container of the <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		protected internal ToolStrip Parent
		{
			get
			{
				return ParentInternal;
			}
			set
			{
				ParentInternal = value;
			}
		}

		/// 
		/// Gets or sets the context menu code.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ContextMenu ContextMenu
		{
			get
			{
				return base.ContextMenu;
			}
			set
			{
				base.ContextMenu = value;
			}
		}

		/// 
		/// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
		/// </summary>
		/// The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return base.ContextMenuStrip;
			}
			set
			{
				base.ContextMenuStrip = value;
			}
		}

		/// Gets or sets the image that is displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripItemImageDescr")]
		[Localizable(true)]
		public virtual ResourceHandle Image
		{
			get
			{
				ResourceHandle resourceHandle = mobjImage;
				if (resourceHandle == null && Owner != null && Owner.ImageList != null)
				{
					int imageIndex = ImageIndex;
					if (imageIndex >= 0)
					{
						if (imageIndex < Owner.ImageList.Images.Count)
						{
							return mobjImage = (resourceHandle = Owner.ImageList.Images[imageIndex]);
						}
					}
					else
					{
						string imageKey = ImageKey;
						if (!string.IsNullOrEmpty(imageKey))
						{
							return mobjImage = (resourceHandle = Owner.ImageList.Images[imageKey]);
						}
					}
					return null;
				}
				return resourceHandle;
			}
			set
			{
				if (Image != value)
				{
					if (value != null)
					{
						ImageIndex = -1;
					}
					mobjImage = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the alignment of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleLeft"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[DefaultValue(ContentAlignment.MiddleCenter)]
		[SRDescription("ToolStripItemImageAlignDescr")]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		public ContentAlignment ImageAlign
		{
			get
			{
				return menmImageAlign;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 1, 1024))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
				}
				if (menmImageAlign != value)
				{
					menmImageAlign = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the index value of the image that is displayed on the item.</summary> 
		/// The zero-based index of the image in the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ImageList"></see> that is displayed for the item. The default is -1, signifying that the image list is empty.</returns> 
		/// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemImageIndexDescr")]
		[RelatedImageList("Owner.ImageList")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(false)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		public int ImageIndex
		{
			get
			{
				if (Owner != null && mintImageIndex != -1 && Owner.ImageList != null && mintImageIndex >= Owner.ImageList.Images.Count)
				{
					return Owner.ImageList.Images.Count - 1;
				}
				return mintImageIndex;
			}
			set
			{
				if (value < -1)
				{
					object[] arrArgs = new object[3]
					{
						"ImageIndex",
						value.ToString(CultureInfo.CurrentCulture),
						(-1).ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ImageIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (mintImageIndex != value)
				{
					mintImageIndex = value;
					mobjImage = null;
					mstrImageKey = string.Empty;
				}
			}
		}

		/// Gets or sets the key accessor for the image in the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.ImageList"></see> that is displayed on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// A string representing the key of the image.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRCategory("CatBehavior")]
		[Browsable(false)]
		[SRDescription("ToolStripItemImageKeyDescr")]
		[Localizable(true)]
		[RelatedImageList("Owner.ImageList")]
		public string ImageKey
		{
			get
			{
				return mstrImageKey;
			}
			set
			{
				if (mstrImageKey != value)
				{
					mstrImageKey = value;
					mobjImage = null;
					mintImageIndex = -1;
				}
			}
		}

		/// Gets or sets a value indicating whether an image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically resized to fit in a container.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageScaling"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemImageScaling.SizeToFit"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[SRDescription("ToolStripItemImageScalingDescr")]
		[DefaultValue(ToolStripItemImageScaling.SizeToFit)]
		public ToolStripItemImageScaling ImageScaling
		{
			get
			{
				return menmImageScaling;
			}
			set
			{
				if (value != ImageScaling)
				{
					menmImageScaling = value;
					if (!base.DesignMode)
					{
						InvalidateParentLayout();
					}
				}
			}
		}

		/// Gets or sets the color to treat as transparent in a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> image.</summary> 
		/// One of the <see cref="T:System.Drawing.Color"></see> values.</returns> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ImageTransparentColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets a value indicating whether the object has been disposed of.</summary> 
		/// true if the control has been disposed of; otherwise, false.</returns> 
		/// 2</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsDisposed => false;

		/// Gets a value indicating whether the container of the current <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>. </summary> 
		/// true if the container of the current <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public bool IsOnDropDown
		{
			get
			{
				if (ParentInternal != null)
				{
					return ParentInternal.IsDropDown;
				}
				return Owner != null && Owner.IsDropDown;
			}
		}

		/// Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Placement"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemPlacement.Overflow"></see>.</summary> 
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Placement"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemPlacement.Overflow"></see>; otherwise, false.</returns>
		[Browsable(false)]
		public bool IsOnOverflow => Placement == ToolStripItemPlacement.Overflow;

		/// Gets or sets the space between the item and adjacent items.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between the item and adjacent items.</returns> 
		/// 1</filterpriority>
		[SRDescription("ToolStripItemMarginDescr")]
		[SRCategory("CatLayout")]
		public Padding Margin
		{
			get
			{
				return mobjMargin;
			}
			set
			{
				if (Margin != value)
				{
					mobjMargin = value;
				}
			}
		}

		/// Gets or sets how child menus are merged with parent menus. </summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.MergeAction"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.MergeAction.MatchOnly"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.MergeAction"></see> values.</exception> 
		/// 2</filterpriority>
		[SRCategory("CatLayout")]
		[SRDescription("ToolStripMergeActionDescr")]
		[DefaultValue(MergeAction.Append)]
		public MergeAction MergeAction
		{
			get
			{
				return menmMergeAction;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(MergeAction));
				}
				if (menmMergeAction != value)
				{
					menmMergeAction = value;
				}
			}
		}

		/// Gets or sets the position of a merged item within the current <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		/// An integer representing the index of the merged item, if a match is found, or -1 if a match is not found.</returns> 
		/// 2</filterpriority>
		[SRDescription("ToolStripMergeIndexDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(-1)]
		public int MergeIndex
		{
			get
			{
				return mintMergeIndex;
			}
			set
			{
				if (mintMergeIndex != value)
				{
					mintMergeIndex = value;
				}
			}
		}

		/// Gets or sets the name of the item.</summary> 
		/// A string representing the name. The default value is null.</returns> 
		/// 1</filterpriority>
		[DefaultValue(null)]
		[Browsable(false)]
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(mstrName))
				{
					string text = string.Empty;
					if (Site != null && Site.DesignMode)
					{
						text = Site.Name;
					}
					if (text == null)
					{
						text = string.Empty;
					}
					return text;
				}
				return mstrName;
			}
			set
			{
				if (mstrName != value)
				{
					mstrName = value;
				}
			}
		}

		/// Gets or sets whether the item is attached to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> or <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> or can float between the two.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.AsNeeded"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. </exception> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(ToolStripItemOverflow.AsNeeded)]
		[SRDescription("ToolStripItemOverflowDescr")]
		[SRCategory("CatLayout")]
		public ToolStripItemOverflow Overflow
		{
			get
			{
				return ToolStripItemOverflow.AsNeeded;
			}
			set
			{
			}
		}

		/// Gets or sets the owner of this item.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that owns or is to own the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStrip Owner
		{
			get
			{
				return OwnerInternal;
			}
			set
			{
				ToolStrip ownerInternal = OwnerInternal;
				if (ownerInternal != value)
				{
					OwnerInternal = value;
					if (ownerInternal != null)
					{
						ownerInternal.Items.Remove(this);
						ownerInternal.Update();
					}
					if (value != null)
					{
						value.Items.Add(this);
						value.Update();
					}
				}
			}
		}

		/// 
		/// Gets or sets the owner internal.
		/// </summary>
		/// The owner internal.</value>
		private ToolStrip OwnerInternal
		{
			get
			{
				return mobjOwner;
			}
			set
			{
				mobjOwner = value;
			}
		}

		/// Gets the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// The parent <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripItem OwnerItem
		{
			get
			{
				ToolStripDropDown toolStripDropDown = null;
				if (ParentInternal != null)
				{
					toolStripDropDown = ParentInternal as ToolStripDropDown;
				}
				else if (Owner != null)
				{
					toolStripDropDown = Owner as ToolStripDropDown;
				}
				return toolStripDropDown?.OwnerItem;
			}
		}

		/// Gets or sets the internal spacing, in pixels, between the item's contents and its edges.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the item's internal spacing, in pixels.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatLayout")]
		[SRDescription("ToolStripItemPaddingDescr")]
		public virtual Padding Padding
		{
			get
			{
				return mobjPadding;
			}
			set
			{
				if (Padding != value)
				{
					mobjPadding = value;
				}
			}
		}

		/// Gets the current layout of the item.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemPlacement"></see> values.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public ToolStripItemPlacement Placement => menmPlacement;

		/// Gets a value indicating whether the state of the item is pressed. </summary> 
		/// true if the state of the item is pressed; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool Pressed => false;

		/// 
		/// Gets the default right to left.
		/// </summary>
		/// The default right to left.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		private RightToLeft DefaultRightToLeft => RightToLeft.Inherit;

		/// Gets or sets a value indicating whether items are to be placed from right to left and text is to be written from right to left.</summary> 
		/// true if items are to be placed from right to left and text is to be written from right to left; otherwise, false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemRightToLeftDescr")]
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		public virtual RightToLeft RightToLeft
		{
			get
			{
				RightToLeft rightToLeft = menmRightToLeft;
				if (rightToLeft == RightToLeft.Inherit)
				{
					rightToLeft = ((Owner != null) ? Owner.RightToLeft : ((ParentInternal == null) ? DefaultRightToLeft : ParentInternal.RightToLeft));
				}
				return rightToLeft;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("RightToLeft", (int)value, typeof(RightToLeft));
				}
				RightToLeft rightToLeft = RightToLeft;
				if (value != RightToLeft.Inherit)
				{
					menmRightToLeft = value;
				}
				if (rightToLeft != RightToLeft)
				{
					OnRightToLeftChanged(EventArgs.Empty);
				}
			}
		}

		/// Mirrors automatically the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> image when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeft"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Yes"></see>.</summary> 
		/// true to automatically mirror the image; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		[Localizable(true)]
		[SRDescription("ToolStripItemRightToLeftAutoMirrorImageDescr")]
		[SRCategory("CatAppearance")]
		public bool RightToLeftAutoMirrorImage
		{
			get
			{
				return mblnRightToLeftAutoMirrorImage;
			}
			set
			{
				if (mblnRightToLeftAutoMirrorImage != value)
				{
					mblnRightToLeftAutoMirrorImage = value;
					Invalidate();
				}
			}
		}

		/// Gets a value indicating whether the item is selected.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is selected; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool Selected => false;

		/// Gets or sets the size of the item.</summary> 
		/// A <see cref="T:System.Drawing.Size"></see>, representing the width and height of a rectangle.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemSizeDescr")]
		[Localizable(true)]
		[SRCategory("CatLayout")]
		public virtual Size Size
		{
			get
			{
				return Bounds.Size;
			}
			set
			{
				Rectangle bounds = Bounds;
				if (bounds.Size != value)
				{
					bounds.Size = value;
					SetBounds(bounds);
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets a value indicating whether [should render text].
		/// </summary>
		/// true</c> if [should render text]; otherwise, false</c>.</value>
		protected bool ShouldRenderText
		{
			get
			{
				ToolStripItemDisplayStyle displayStyle = DisplayStyle;
				return displayStyle == ToolStripItemDisplayStyle.Text || displayStyle == ToolStripItemDisplayStyle.ImageAndText;
			}
		}

		/// 
		/// Gets a value indicating whether [should render image].
		/// </summary>
		/// true</c> if [should render image]; otherwise, false</c>.</value>
		protected bool ShouldRenderImage
		{
			get
			{
				ToolStripItemDisplayStyle displayStyle = DisplayStyle;
				return displayStyle == ToolStripItemDisplayStyle.Image || displayStyle == ToolStripItemDisplayStyle.ImageAndText;
			}
		}

		/// Gets or sets the object that contains data about the item.</summary> 
		/// An <see cref="T:System.Object"></see> that contains data about the control. The default is null.</returns> 
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[DefaultValue(null)]
		[Bindable(true)]
		[SRDescription("ToolStripItemTagDescr")]
		[TypeConverter(typeof(StringConverter))]
		[Localizable(false)]
		public new object Tag
		{
			get
			{
				return mobjTag;
			}
			set
			{
				if (mobjTag != value)
				{
					mobjTag = value;
				}
			}
		}

		/// Gets or sets the text that is to be displayed on the item.</summary> 
		/// A string representing the item's text. The default value is the empty string ("").</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[Localizable(true)]
		[SRDescription("ToolStripItemTextDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue("")]
		public virtual string Text
		{
			get
			{
				return mstrText;
			}
			set
			{
				if (value != Text)
				{
					mstrText = value;
					OnTextChanged(EventArgs.Empty);
					UpdateParams((AttributeType)6);
				}
			}
		}

		/// 
		/// Gets a value indicating whether to hide item on strip wrapping.
		/// </summary>
		/// true</c> if [hide on wrap]; otherwise, false</c>.</value>
		protected virtual bool HideOnWrap => false;

		/// 
		/// Gets or sets the parent internal.
		/// </summary>
		/// The parent internal.</value>
		internal ToolStrip ParentInternal
		{
			get
			{
				return mobjParent;
			}
			set
			{
				ToolStrip parentInternal = ParentInternal;
				if (mobjParent != value)
				{
					mobjParent = value;
					OnParentChanged(parentInternal, value);
					parentInternal?.Update();
					value?.Update();
				}
			}
		}

		/// Gets or sets the alignment of the text on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripLabel"></see>.</summary> 
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleRight"></see>.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemTextAlignDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(ContentAlignment.MiddleCenter)]
		[Localizable(true)]
		public virtual ContentAlignment TextAlign
		{
			get
			{
				return menmTextAlign;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 1, 1024))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
				}
				if (menmTextAlign != value)
				{
					menmTextAlign = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets the orientation of text used on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripTextDirectionDescr")]
		public virtual ToolStripTextDirection TextDirection
		{
			get
			{
				if (menmTextDirection != ToolStripTextDirection.Inherit)
				{
					return menmTextDirection;
				}
				if (ParentInternal != null)
				{
					return ParentInternal.TextDirection;
				}
				return (Owner == null) ? ToolStripTextDirection.Horizontal : Owner.TextDirection;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripTextDirection));
				}
				menmTextDirection = value;
			}
		}

		/// Gets or sets the position of <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text and image relative to each other.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText"></see>.</returns> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[DefaultValue(TextImageRelation.ImageBeforeText)]
		[Localizable(true)]
		[SRDescription("ToolStripItemTextImageRelationDescr")]
		public TextImageRelation TextImageRelation
		{
			get
			{
				return menmTextImageRelation;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 8))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(TextImageRelation));
				}
				if (value != TextImageRelation)
				{
					menmTextImageRelation = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the text that appears as a <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> for a control.</summary> 
		/// A string representing the ToolTip text.</returns> 
		/// 1</filterpriority>
		[SRDescription("ToolStripItemToolTipTextDescr")]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		public string ToolTipText
		{
			get
			{
				if (!AutoToolTip || !string.IsNullOrEmpty(mstrToolTipText))
				{
					return mstrToolTipText;
				}
				string text = Text;
				if (ClientUtils.ContainsMnemonic(text))
				{
					text = string.Join("", text.Split('&'));
				}
				return text;
			}
			set
			{
				if (mstrToolTipText != value)
				{
					mstrToolTipText = value;
					UpdateParams(AttributeType.ToolTip);
				}
			}
		}

		/// Gets or sets a value indicating whether the item is displayed.</summary> 
		/// true if the item is displayed; otherwise, false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRDescription("ToolStripItemVisibleDescr")]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return ParentInternal != null && ParentInternal.Visible && Available;
			}
			set
			{
				SetVisibleCore(value);
				UpdateParams(AttributeType.Visual);
				ToolStrip owner = Owner;
				if (owner != null)
				{
					owner.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					owner.Update(blnRedrawOnly: true);
				}
			}
		}

		/// Gets or sets the width in pixels of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// An <see cref="T:System.Int32"></see> representing the width in pixels.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		public int Width
		{
			get
			{
				return Bounds.Width;
			}
			set
			{
				Rectangle bounds = Bounds;
				if (bounds.Width != value)
				{
					SetBounds(bounds.X, bounds.Y, value, bounds.Height);
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		ArrangedElementCollection IArrangedElement.Children => new ArrangedElementCollection();

		bool IArrangedElement.ParticipatesInLayout => Visible;

		/// Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
		/// One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. The options are AllSystemSources, AllUrl, FileSystem, HistoryList, RecentlyUsedList, CustomSource, and None. The default is None.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatAccessibility")]
		[DefaultValue(AccessibleRole.Default)]
		[SRDescription("ToolStripItemAccessibleRoleDescr")]
		public AccessibleRole AccessibleRole
		{
			get
			{
				return AccessibleRole.Default;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the member ID.
		/// </summary>
		/// The member ID.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public long MemberID
		{
			get
			{
				ToolStrip owner = Owner;
				if (owner != null && owner.Items.Contains(this))
				{
					return owner.Items.IndexOf(this) + 1;
				}
				return -1L;
			}
			set
			{
			}
		}

		/// 
		/// Gets the owner ID.
		/// </summary>
		/// The owner ID.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public long OwnerID
		{
			get
			{
				if (Owner is ToolStripDropDown { DropDownForm: { } dropDownForm })
				{
					return dropDownForm.GetProxyPropertyValue("ID", dropDownForm.ID);
				}
				ToolStrip owner = Owner;
				return owner?.GetProxyPropertyValue("ID", owner.ID) ?? 0;
			}
		}

		/// 
		/// Gets the theme.
		/// </summary>
		/// The theme.</value>
		string ISkinable.Theme
		{
			get
			{
				if (Context != null)
				{
					return Context.CurrentTheme;
				}
				return string.Empty;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Available"></see> property changes.</summary>
		public event EventHandler AvailableChanged
		{
			add
			{
				AddCriticalHandler(AvailableChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AvailableChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.BackColor"></see> property changes.</summary> 
		/// 1</filterpriority>
		public event EventHandler BackColorChanged
		{
			add
			{
				AddCriticalHandler(BackColorChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(BackColorChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is clicked.</summary> 
		/// 1</filterpriority>
		public virtual event EventHandler Click
		{
			add
			{
				AddCriticalHandler(ClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ClickEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.DisplayStyle"></see> has changed.</summary> 
		/// 1</filterpriority>
		public event EventHandler DisplayStyleChanged
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

		/// Occurs when the item is double-clicked with the mouse.</summary> 
		/// 1</filterpriority>
		public virtual event EventHandler DoubleClick
		{
			add
			{
				AddCriticalHandler(DoubleClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DoubleClickEvent, value);
			}
		}

		/// Occurs when the user drags an item into the client area of this item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event DragEventHandler DragEnter
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the user drags an item and the mouse pointer is no longer over the client area of this item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler DragLeave
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the user drags an item over the client area of this item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event DragEventHandler DragOver
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Enabled"></see> property value has changed.</summary> 
		/// 1</filterpriority>
		public event EventHandler EnabledChanged
		{
			add
			{
				AddCriticalHandler(EnabledChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(EnabledChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.ForeColor"></see> property value changes.</summary> 
		/// 1</filterpriority>
		public event EventHandler ForeColorChanged
		{
			add
			{
				AddCriticalHandler(ForeColorChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ForeColorChangedEvent, value);
			}
		}

		/// Occurs during a drag operation.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event GiveFeedbackEventHandler GiveFeedback
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the location of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is updated.</summary> 
		/// 1</filterpriority>
		public event EventHandler LocationChanged
		{
			add
			{
				AddCriticalHandler(LocationChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LocationChangedEvent, value);
			}
		}

		/// Occurs when the mouse pointer is over the item and a mouse button is pressed.</summary> 
		/// 1</filterpriority>
		public virtual event MouseEventHandler MouseDown
		{
			add
			{
				AddCriticalHandler(MouseDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(MouseDownEvent, value);
			}
		}

		/// Occurs when the mouse pointer enters the item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler MouseEnter
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the mouse pointer hovers over the item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler MouseHover
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the mouse pointer leaves the item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler MouseLeave
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the mouse pointer is moved over the item.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event MouseEventHandler MouseMove
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the mouse pointer is over the item and a mouse button is released.</summary> 
		/// 1</filterpriority>
		public virtual event MouseEventHandler MouseUp
		{
			add
			{
				AddCriticalHandler(MouseUpEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(MouseUpEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Owner"></see> property changes. </summary>
		public event EventHandler OwnerChanged
		{
			add
			{
				AddCriticalHandler(OwnerChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(OwnerChangedEvent, value);
			}
		}

		/// Occurs when the item is redrawn.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event PaintEventHandler Paint
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs during a drag-and-drop operation and allows the drag source to determine whether the drag-and-drop operation should be canceled.</summary> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event QueryContinueDragEventHandler QueryContinueDrag
		{
			add
			{
			}
			remove
			{
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeft"></see> property value changes.</summary> 
		/// 1</filterpriority>
		public event EventHandler RightToLeftChanged
		{
			add
			{
				AddCriticalHandler(RightToLeftChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(RightToLeftChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Text"></see> property changes.</summary> 
		/// 1</filterpriority>
		public virtual event EventHandler TextChanged
		{
			add
			{
				AddCriticalHandler(TextChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(TextChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Visible"></see> property changes.</summary> 
		/// 1</filterpriority>
		public event EventHandler VisibleChanged
		{
			add
			{
				AddCriticalHandler(VisibleChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(VisibleChangedEvent, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class.</summary>
		protected ToolStripItem()
		{
			mobjBounds = Rectangle.Empty;
			menmPlacement = ToolStripItemPlacement.None;
			menmImageAlign = ContentAlignment.MiddleCenter;
			menmTextAlign = ContentAlignment.MiddleCenter;
			menmTextImageRelation = TextImageRelation.ImageBeforeText;
			menmDisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
			ImageScaling = ToolStripItemImageScaling.SizeToFit;
			mblnAutoSize = true;
			mblnEnabled = true;
			mblnDoubleClickEnabled = false;
			SetState(ComponentState.Visible | ComponentState.Enabled, blnValue: true);
			SetState(ComponentState.Selected | ComponentState.AllowDrop, blnValue: false);
			mobjMargin = DefaultMargin;
			Size = DefaultSize;
			DisplayStyle = DefaultDisplayStyle;
			AutoToolTip = DefaultAutoToolTip;
			RegisterSelf();
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class with the specified name, image, and event handler.</summary> 
		/// <param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
		/// <param name="text">A <see cref="T:System.String"></see> representing the name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
		protected ToolStripItem(string text, ResourceHandle image, EventHandler onClick)
			: this(text, image, onClick, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> class with the specified display text, image, event handler, and name. </summary> 
		/// <param name="onClick">The event handler for the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
		/// <param name="image">The ResourceHandle to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param>
		protected ToolStripItem(string text, ResourceHandle image, EventHandler onClick, string name)
			: this()
		{
			Text = text;
			Image = image;
			if (onClick != null)
			{
				Click += onClick;
			}
			Name = name;
		}

		/// Begins a drag-and-drop operation.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see> values.</returns> 
		/// <param name="data">The object to be dragged. </param> 
		/// <param name="allowedEffects">The drag operations that can occur. </param> 
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
		{
			return DragDropEffects.None;
		}

		/// Retrieves the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the container of the current <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the container of the current <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
		/// 1</filterpriority>
		public ToolStrip GetCurrentParent()
		{
			return Parent;
		}

		/// Retrieves the size of a rectangular area into which a control can be fit.</summary> 
		/// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.</returns> 
		/// <param name="objConstrainingSize">The custom-sized area for a control. </param> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public virtual Size GetPreferredSize(Size objConstrainingSize)
		{
			return objConstrainingSize;
		}

		/// 
		/// Gets the preferred size with image.
		/// </summary>
		/// <param name="objSizeWithoutImage">The obj size without image.</param>
		/// </returns>
		protected internal virtual Size GetPreferredSizeByImage(Size objSizeWithoutImage)
		{
			Size result = objSizeWithoutImage;
			if (Image != null && (DisplayStyle == ToolStripItemDisplayStyle.Image || DisplayStyle == ToolStripItemDisplayStyle.ImageAndText))
			{
				int num = 0;
				int num2 = 0;
				switch (ImageScaling)
				{
				case ToolStripItemImageScaling.None:
					num = Image.Height;
					num2 = Image.Width;
					break;
				case ToolStripItemImageScaling.SizeToFit:
				{
					ToolStrip parentInternal = ParentInternal;
					Size size = Size.Empty;
					if (ParentInternal != null)
					{
						size = ParentInternal.ImageScalingSize;
					}
					num = ((parentInternal != null) ? size.Height : 16);
					num2 = ((parentInternal != null) ? size.Width : 16);
					break;
				}
				default:
					throw new NotImplementedException();
				}
				switch (TextImageRelation)
				{
				case TextImageRelation.ImageAboveText:
				case TextImageRelation.TextAboveImage:
					result.Width = Math.Max(objSizeWithoutImage.Width, num2);
					result.Height = objSizeWithoutImage.Height + num;
					break;
				case TextImageRelation.ImageBeforeText:
				case TextImageRelation.TextBeforeImage:
					result.Height = Math.Max(objSizeWithoutImage.Height, num);
					result.Width = objSizeWithoutImage.Width + num2;
					break;
				case TextImageRelation.Overlay:
					result.Width = Math.Max(objSizeWithoutImage.Width, num2);
					result.Height = Math.Max(objSizeWithoutImage.Height, num);
					break;
				default:
					throw new NotImplementedException();
				}
			}
			return result;
		}

		/// 
		/// Applies the size of the font to.
		/// </summary>
		/// <param name="objGivenSize">Size of the obj given.</param>
		/// </returns>
		protected internal virtual Size GetPreferredeSizeByText()
		{
			if (DisplayStyle == ToolStripItemDisplayStyle.ImageAndText || DisplayStyle == ToolStripItemDisplayStyle.Text)
			{
				return GetTextSize(Text);
			}
			return Size.Empty;
		}

		/// 
		/// Gets the size of the text.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// </returns>
		internal Size GetTextSize(string strText)
		{
			Font font = Font;
			if (font == null && ParentInternal != null)
			{
				font = ParentInternal.Font;
			}
			if (font == null)
			{
				if (!(SkinFactory.GetSkin(this) is CommonSkin { Font: not null } commonSkin))
				{
					throw new NullReferenceException("ToolStripItem.ApplyToolStripItemTextToSize: The item does not have a font '" + Name + "'.");
				}
				font = commonSkin.Font;
			}
			return CommonUtils.GetStringMeasurements(strText, font);
		}

		/// 
		/// Applies the size of the button skin to.
		/// </summary>
		/// <param name="objSkin">The obj skin.</param>
		/// <param name="objBaseSize">Size of the obj given.</param>
		/// </returns>
		protected internal Size GetPreferredSizeByButtonSkin(ButtonSkin objSkin, Size objBaseSize)
		{
			if (objSkin != null)
			{
				int buttonImageTextGap = objSkin.ButtonImageTextGap;
				BorderWidth borderWidth = objSkin.BorderWidth;
				Padding padding = objSkin.Padding;
				objBaseSize.Width += borderWidth.Left + borderWidth.Right + buttonImageTextGap + padding.Horizontal;
				objBaseSize.Height += borderWidth.Top + borderWidth.Bottom + buttonImageTextGap + padding.Vertical;
			}
			return objBaseSize;
		}

		/// Invalidates the entire surface of the control and causes the control to be redrawn.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void Invalidate()
		{
			if (ParentInternal != null)
			{
				ParentInternal.Invalidate();
			}
		}

		/// Invalidates the specified region of the control by adding it to the control's update region, which is the area that will be repainted at the next paint operation, and causes a paint message to be sent to the control.</summary> 
		/// <param name="r">A <see cref="T:System.Drawing.Rectangle"></see> that represents the region to invalidate. </param> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void Invalidate(Rectangle r)
		{
			Invalidate();
		}

		/// Sets the size and location of the item.</summary>
		/// <param name="bounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the <see cref="T:System.Windows.Forms.ToolStripItem"></see></param>
		protected internal virtual void SetBounds(Rectangle bounds)
		{
			Rectangle rectangle = mobjBounds;
			mobjBounds = bounds;
			if (mobjBounds != rectangle)
			{
				OnBoundsChanged();
			}
			if (mobjBounds.Location != rectangle.Location)
			{
				OnLocationChanged(EventArgs.Empty);
			}
		}

		internal void SetBounds(int x, int y, int width, int height)
		{
			SetBounds(new Rectangle(x, y, width, height));
		}

		/// Raises the AvailableChanged event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAvailableChanged(EventArgs e)
		{
			AvailableChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.BackColorChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBackColorChanged(EventArgs e)
		{
			Invalidate();
			BackColorChangedHandler?.Invoke(this, e);
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Bounds"></see> property changes.</summary>
		protected virtual void OnBoundsChanged()
		{
		}

		/// 
		/// Raises the <see cref="E:Click" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnClick(EventArgs objEventArgs)
		{
			MouseEventArgs e = objEventArgs as MouseEventArgs;
			if (e == null)
			{
				e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
			}
			OnMouseDown(e);
			ClickHandler?.Invoke(this, objEventArgs);
			OnMouseUp(e);
			Owner?.OnItemClicked(new ToolStripItemClickedEventArgs(this));
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DisplayStyleChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDisplayStyleChanged(EventArgs e)
		{
			DisplayStyleChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DoubleClick"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDoubleClick(EventArgs e)
		{
			DoubleClickHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragEnter"></see> event.</summary> 
		/// <param name="dragEvent">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnDragEnter(DragEventArgs dragEvent)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragLeave"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnDragLeave(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DragOver"></see> event.</summary> 
		/// <param name="dragEvent">A <see cref="T:Gizmox.WebGUI.Forms.DragEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnDragOver(DragEventArgs dragEvent)
		{
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		void IDropTarget.OnDragDrop(DragEventArgs dragEvent)
		{
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		void IDropTarget.OnDragEnter(DragEventArgs dragEvent)
		{
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		void IDropTarget.OnDragLeave(EventArgs e)
		{
		}

		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		void IDropTarget.OnDragOver(DragEventArgs dragEvent)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.EnabledChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnEnabledChanged(EventArgs e)
		{
			EnabledChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.FontChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnFontChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.ForeColorChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Always)]
		protected virtual void OnForeColorChanged(EventArgs e)
		{
			ForeColorChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.GiveFeedback"></see> event.</summary> 
		/// <param name="giveFeedbackEvent">A <see cref="T:Gizmox.WebGUI.Forms.GiveFeedbackEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnGiveFeedback(GiveFeedbackEventArgs giveFeedbackEvent)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.LocationChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnLocationChanged(EventArgs e)
		{
			LocationChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseDown"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseDown(MouseEventArgs e)
		{
			MouseDownHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseEnter"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMouseEnter(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseHover"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMouseHover(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseLeave"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMouseLeave(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseMove"></see> event.</summary> 
		/// <param name="mea">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnMouseMove(MouseEventArgs mea)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.MouseUp"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		protected virtual void OnMouseUp(MouseEventArgs e)
		{
			MouseUpHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.OwnerChanged"></see> event. </summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnOwnerChanged(EventArgs e)
		{
			OwnerChangedHandler?.Invoke(this, e);
			if (Owner != null && menmRightToLeft == RightToLeft.Inherit && RightToLeft != DefaultRightToLeft)
			{
				OnRightToLeftChanged(EventArgs.Empty);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Paint"></see> event.</summary> 
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnPaint(PaintEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.BackColorChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentBackColorChanged(EventArgs e)
		{
			if (mobjBackColor.IsEmpty)
			{
				OnBackColorChanged(e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.</summary> 
		/// <param name="oldParent">The original parent of the item. </param> 
		/// <param name="newParent">The new parent of the item. </param>
		protected virtual void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.ForeColorChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentForeColorChanged(EventArgs e)
		{
			if (mobjForeColor.IsEmpty)
			{
				OnForeColorChanged(e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.QueryContinueDrag"></see> event.</summary> 
		/// <param name="queryContinueDragEvent">A <see cref="T:Gizmox.WebGUI.Forms.QueryContinueDragEventArgs"></see> that contains the event data. </param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs queryContinueDragEvent)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.RightToLeftChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnRightToLeftChanged(EventArgs e)
		{
			RightToLeftChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ParentEnabledChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected internal virtual void OnParentEnabledChanged(EventArgs e)
		{
			OnEnabledChanged(EventArgs.Empty);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.TextChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Always)]
		protected virtual void OnTextChanged(EventArgs e)
		{
			TextChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.VisibleChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnVisibleChanged(EventArgs e)
		{
			VisibleChangedHandler?.Invoke(this, e);
		}

		/// Activates the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> when it is clicked with the mouse.</summary>
		public void PerformClick()
		{
			OnClick(new EventArgs());
		}

		/// This method is not relevant to this class.</summary> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBackColor()
		{
			BackColor = Color.Empty;
		}

		/// This method is not relevant to this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetDisplayStyle()
		{
			DisplayStyle = DefaultDisplayStyle;
		}

		/// This method is not relevant to this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetFont()
		{
			Font = null;
		}

		/// 
		/// Sets the owner.
		/// </summary>
		/// <param name="newOwner">The new owner.</param>
		internal void SetOwner(ToolStrip objNewOwner)
		{
			if (OwnerInternal != objNewOwner)
			{
				Font font = Font;
				ToolStrip parentInternal = (OwnerInternal = objNewOwner);
				ParentInternal = parentInternal;
				OnOwnerChanged(EventArgs.Empty);
				if (font != Font)
				{
					OnFontChanged(EventArgs.Empty);
				}
			}
		}

		/// This method is not relevant to this class.</summary> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetForeColor()
		{
			ForeColor = Color.Empty;
		}

		/// 
		/// Gets the owner font.
		/// </summary>
		/// </returns>
		private Font GetOwnerFont()
		{
			if (Owner != null)
			{
				return Owner.Font;
			}
			return null;
		}

		/// 
		/// Gets the name of the client component.
		/// </summary>
		/// </returns>
		protected override string GetClientComponentName()
		{
			return Name;
		}

		/// 
		/// Gets the client component ID.
		/// </summary>
		/// </returns>
		protected override string GetClientComponentID()
		{
			if (Owner != null)
			{
				return $"{Owner.ID}_{MemberID}";
			}
			return base.GetClientComponentID();
		}

		/// This method is not relevant to this class.</summary>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetImage()
		{
			Image = null;
		}

		/// This method is not relevant to this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetMargin()
		{
			mobjMargin = DefaultMargin;
		}

		/// This method is not relevant to this class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetPadding()
		{
			mobjPadding = DefaultPadding;
		}

		/// This method is not relevant to this class.</summary> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetRightToLeft()
		{
			RightToLeft = RightToLeft.Inherit;
		}

		/// This method is not relevant to this class.</summary> 
		/// 2</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetTextDirection()
		{
			TextDirection = ToolStripTextDirection.Inherit;
		}

		/// Selects the item.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void Select()
		{
			if (CanSelect && Owner == null && ParentInternal == null && !Selected && IsOnDropDown && OwnerItem != null && OwnerItem.IsOnDropDown)
			{
				OwnerItem.Select();
			}
		}

		/// Sets the <see cref="T:System.Windows.Forms.ToolStripItem"></see> to the specified visible state. </summary>
		/// <param name="visible">true to make the <see cref="T:System.Windows.Forms.ToolStripItem"></see> visible; otherwise, false.</param>
		protected virtual void SetVisibleCore(bool visible)
		{
			if (GetState(ComponentState.Visible) != visible)
			{
				SetState(ComponentState.Visible, visible);
				OnAvailableChanged(EventArgs.Empty);
				OnVisibleChanged(EventArgs.Empty);
			}
		}

		/// 
		/// Sets the bounds.
		/// </summary>
		/// <param name="bounds">The bounds.</param>
		/// <param name="specified">The specified.</param>
		void IArrangedElement.SetBounds(Rectangle bounds, BoundsSpecified specified)
		{
			SetBounds(bounds);
		}

		/// 
		/// Gets the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objSerializableProperty">The serializable property.</param>
		/// </returns>
		T IArrangedElement.GetValue<T>(SerializableProperty objSerializableProperty)
		{
			return GetValue(objSerializableProperty);
		}

		/// 
		/// Sets the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objSerializableProperty">The serializable property.</param>
		/// <param name="objValue">The obj value.</param>
		void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue)
		{
			SetValue(objSerializableProperty, objValue);
		}

		/// 
		/// Disposes the specified component.
		/// </summary>
		/// <param name="blnDisposing"></param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing && Owner != null)
			{
				Owner.Items.Remove(this);
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Fires the tool strip item event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		internal void FireToolStripItemEvent(IEvent objEvent)
		{
			FireEvent(objEvent);
		}

		/// 
		/// Pres the render tool strip item.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal virtual void PreRenderToolStripItem(IContext objContext, long lngRequestID)
		{
		}

		/// 
		/// Posts the render tool strip item.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal virtual void PostRenderToolStripItem(IContext objContext, long lngRequestID)
		{
			ResetParams();
		}

		/// 
		/// Renders a tool strip item.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal virtual void RenderToolStripItem(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (IsDirty(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.ControlsPrefix, "TSI", WGConst.ControlsNamespace);
				RenderToolStripItemAttributes(objContext, (IAttributeWriter)objWriter);
				RenderToolStripItemControls(objContext, objWriter, lngRequestID);
				objWriter.WriteEndElement();
			}
			else if (IsDirtyAttributes(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
				RenderToolStripItemUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
				if (Visible)
				{
					RenderToolStripItemControls(objContext, objWriter, lngRequestID);
				}
				objWriter.WriteEndElement();
			}
			else if (Visible)
			{
				RenderToolStripItemControls(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the tool strip item updated attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected virtual void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
		{
			if (IsDirtyAttributes(lngRequestID))
			{
				RenderComponentID(objAttributeWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderTextAlignAttribute(objAttributeWriter);
				RenderImageAlignAttribute(objAttributeWriter);
				RenderImageAttribute(objAttributeWriter, blnForceRender: true);
				RenderForeColorAttribute(objAttributeWriter, blnForceRender: true);
				RenderTextImageRelationAttribute(objAttributeWriter, blnForceRender: true);
				RenderVisibleAttribute(objAttributeWriter, blnForceRender: true);
				RenderAlignmentAttribute(objAttributeWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderEnabledAttribute(objAttributeWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderSizeAttributes(objAttributeWriter, blnForceRender: true);
				RenderAutoSizeAttributes(objAttributeWriter, blnForceRender: true);
				RenderImageScalingAttribute(objAttributeWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
			{
				RenderToolTipAttribute(objAttributeWriter, blnForceRender: false);
			}
		}

		/// 
		/// Renders the tool strip item's controls.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected virtual void RenderToolStripItemControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
		}

		/// 
		/// Renders the tool strip item's attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		protected virtual void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
		{
			RenderComponentAttributes(objContext, objAttributeWriter);
			int toolStripItemType = ToolStripItemType;
			if (toolStripItemType >= 0)
			{
				objAttributeWriter.WriteAttributeString("TP", toolStripItemType.ToString());
			}
			if (HideOnWrap)
			{
				objAttributeWriter.WriteAttributeString("HOW", "1");
			}
			if (CustomStyle != "")
			{
				objAttributeWriter.WriteAttributeString("ES", CustomStyle);
			}
			RenderSizeAttributes(objAttributeWriter, blnForceRender: false);
			RenderAutoSizeAttributes(objAttributeWriter, blnForceRender: false);
			RenderTextAlignAttribute(objAttributeWriter);
			RenderImageAlignAttribute(objAttributeWriter);
			RenderImageAttribute(objAttributeWriter, blnForceRender: false);
			RenderEnabledAttribute(objAttributeWriter, blnForceRender: false);
			RenderVisibleAttribute(objAttributeWriter, blnForceRender: false);
			RenderAlignmentAttribute(objAttributeWriter);
			RenderFontAttribute(objAttributeWriter, blnForceRender: false);
			RenderForeColorAttribute(objAttributeWriter, blnForceRender: false);
			RenderBackColorAttribute(objAttributeWriter, blnForceRender: false);
			RenderTextImageRelationAttribute(objAttributeWriter, blnForceRender: false);
			RenderImageScalingAttribute(objAttributeWriter, blnForceRender: false);
			RenderToolTipAttribute(objAttributeWriter, blnForceRender: false);
		}

		/// 
		/// Renders the tool tip attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderToolTipAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (blnForceRender || !string.IsNullOrEmpty(ToolTipText))
			{
				objAttributeWriter.WriteAttributeString("TL", ToolTipText);
			}
		}

		/// 
		/// Renders the font attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderFontAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (blnForceRender || ShouldRenderFont())
			{
				objAttributeWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(Font));
			}
		}

		/// 
		/// Renders the fore color attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderForeColorAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (blnForceRender || ShouldRenderForeColor())
			{
				objAttributeWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(ForeColor));
			}
		}

		/// 
		/// Renders the back color attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderBackColorAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (blnForceRender || ShouldSerializeBackColor())
			{
				objAttributeWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(BackColor));
			}
		}

		/// 
		/// Renders the size attributes.
		/// </summary>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSizeAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			Size size = Size.Empty;
			if (AutoSize)
			{
				size = GetPreferredSize(Size);
			}
			else
			{
				size.Width = Width;
				size.Height = Height;
			}
			if (size.Width > 0 || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("W", size.Width.ToString());
			}
			if (size.Height > 0 || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("H", size.Height.ToString());
			}
		}

		/// 
		/// Renders the auto size attributes.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderAutoSizeAttributes(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			bool autoSize = AutoSize;
			if (!autoSize || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("AS", autoSize ? "1" : "0");
			}
		}

		/// 
		/// Renders the image attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderImageAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (ShouldRenderImage)
			{
				ResourceHandle image = Image;
				if (image != null || blnForceRender)
				{
					objAttributeWriter.WriteAttributeString("IM", (image != null) ? image.ToString() : string.Empty);
				}
			}
		}

		/// 
		/// Renders the enabled attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderEnabledAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (!mblnEnabled || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("En", mblnEnabled ? "1" : "0");
			}
		}

		/// 
		/// Renders the Visible attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderVisibleAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			bool visible = Visible;
			if (!visible || blnForceRender)
			{
				objAttributeWriter.WriteAttributeString("V", visible ? "1" : "0");
			}
		}

		/// 
		/// Renders the Item align attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		private void RenderAlignmentAttribute(IAttributeWriter objAttributeWriter)
		{
			if (Alignment != ToolStripItemAlignment.Left)
			{
				objAttributeWriter.WriteAttributeString("HA", (Alignment == ToolStripItemAlignment.Left) ? "0" : "1");
			}
		}

		/// 
		/// Renders the text align attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		protected virtual void RenderTextAlignAttribute(IAttributeWriter objAttributeWriter)
		{
			if (ShouldRenderText)
			{
				objAttributeWriter.WriteAttributeString("TA", TextAlign.ToString());
			}
		}

		/// 
		/// Renders the image align attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		private void RenderImageAlignAttribute(IAttributeWriter objAttributeWriter)
		{
			if (ShouldRenderImage)
			{
				objAttributeWriter.WriteAttributeString("IA", ImageAlign.ToString());
			}
		}

		/// 
		/// Renders the text image relation attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderTextImageRelationAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			TextImageRelation textImageRelation = TextImageRelation;
			if (TextImageRelation.ImageBeforeText != textImageRelation || blnForceRender)
			{
				int num = (int)textImageRelation;
				objAttributeWriter.WriteAttributeText("TIR", num.ToString());
			}
		}

		/// 
		/// Renders the text image relation attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderImageScalingAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			ToolStripItemImageScaling imageScaling = ImageScaling;
			if (ToolStripItemImageScaling.SizeToFit != imageScaling || blnForceRender)
			{
				int num = (int)imageScaling;
				objAttributeWriter.WriteAttributeString("IMSC", num.ToString());
			}
		}

		/// 
		/// Renders the component's ID.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderComponentID(IAttributeWriter objWriter)
		{
			long memberID = MemberID;
			if (memberID > 0)
			{
				objWriter.WriteAttributeString("mId", memberID.ToString());
			}
			long ownerID = OwnerID;
			if (ownerID > 0)
			{
				objWriter.WriteAttributeString("oId", ownerID.ToString());
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			bool flag = false;
			ToolStrip owner = Owner;
			if (owner != null)
			{
				flag = owner.IsCriticalEvent(ToolStrip.ItemClickedEvent);
			}
			if (flag || ClickHandler != null || MouseDownHandler != null || MouseUpHandler != null)
			{
				criticalEventsData.Set("CL");
			}
			if (DoubleClickHandler != null)
			{
				criticalEventsData.Set("DCL");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the mouse event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		protected internal MouseEventArgs GetMouseEventArgs(IEvent objEvent)
		{
			return new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
		}

		/// 
		/// Does the on click from event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected internal void DoOnClickFromEvent(IEvent objEvent)
		{
			OnClick(GetMouseEventArgs(objEvent));
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (!(type == "Click"))
			{
				if (type == "DoubleClick")
				{
					OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
					OnDoubleClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				}
			}
			else
			{
				DoOnClickFromEvent(objEvent);
			}
		}

		/// 
		/// Indicates if to render font.
		/// </summary>
		/// </returns>
		private bool ShouldRenderFont()
		{
			if (Font != null)
			{
				return !Font.Equals(SkinFont);
			}
			return false;
		}

		/// 
		/// Checks whether item should render the forecolor.
		/// </summary>
		/// </returns>
		private bool ShouldRenderForeColor()
		{
			return !ForeColor.Equals(SkinForeColor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeBackColor()
		{
			return ContainsValue(mobjBackColorProperty);
		}

		private bool ShouldSerializeDisplayStyle()
		{
			return DisplayStyle != DefaultDisplayStyle;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeFont()
		{
			return ContainsValue(mobjFontProperty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeForeColor()
		{
			return ContainsValue(mobjForeColorProperty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeImage()
		{
			return ContainsValue(mobjImageProperty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeImageIndex()
		{
			return ContainsValue(mintImageIndexProperty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeImageKey()
		{
			return ContainsValue(mstrImageKeyProperty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeImageTransparentColor()
		{
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeMargin()
		{
			return Margin != DefaultMargin;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializePadding()
		{
			return Padding != DefaultPadding;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeRightToLeft()
		{
			return ContainsValue(menmRightToLeftProperty);
		}

		private bool ShouldSerializeTextDirection()
		{
			return ContainsValue(menmTextDirectionProperty);
		}

		private bool ShouldSerializeToolTipText()
		{
			return ContainsValue(mstrToolTipTextProperty);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		private bool ShouldSerializeVisible()
		{
			return !GetState(ComponentState.Visible);
		}

		/// 
		/// Invalidates the parent layout.
		/// </summary>
		private void InvalidateParentLayout()
		{
			if (ParentInternal != null)
			{
				ParentInternal.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: true, blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
				ParentInternal.UpdateStripAttributes(AttributeType.Layout);
				UpdateParams(AttributeType.Layout);
			}
		}

		private void ResetToolTipText()
		{
			RemoveValue(mstrToolTipTextProperty);
		}

		static ToolStripItem()
		{
			AvailableChanged = SerializableEvent.Register("AvailableChanged", typeof(EventHandler), typeof(ToolStripItem));
			BackColorChanged = SerializableEvent.Register("BackColorChanged", typeof(EventHandler), typeof(ToolStripItem));
			ClickEvent = SerializableEvent.Register("ClickEvent", typeof(EventHandler), typeof(ToolStripItem));
			DisplayStyleChanged = SerializableEvent.Register("DisplayStyleChanged", typeof(EventHandler), typeof(ToolStripItem));
			DoubleClickEvent = SerializableEvent.Register("DoubleClick", typeof(EventHandler), typeof(ToolStripItem));
			EnabledChanged = SerializableEvent.Register("EnabledChanged", typeof(EventHandler), typeof(ToolStripItem));
			ForeColorChanged = SerializableEvent.Register("ForeColorChanged", typeof(EventHandler), typeof(ToolStripItem));
			LocationChanged = SerializableEvent.Register("LocationChanged", typeof(EventHandler), typeof(ToolStripItem));
			MouseDownEvent = SerializableEvent.Register("MouseDown", typeof(EventHandler), typeof(ToolStripItem));
			MouseUpEvent = SerializableEvent.Register("MouseUp", typeof(EventHandler), typeof(ToolStripItem));
			RightToLeftChanged = SerializableEvent.Register("RightToLeftChanged", typeof(EventHandler), typeof(ToolStripItem));
			OwnerChanged = SerializableEvent.Register("OwnerChanged", typeof(EventHandler), typeof(ToolStripItem));
			VisibleChanged = SerializableEvent.Register("VisibleChanged", typeof(EventHandler), typeof(ToolStripItem));
			TextChangedEvent = SerializableEvent.Register("TextChanged", typeof(EventHandler), typeof(ToolStripItem));
		}
	}
}
