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
	/// Represents a window or dialog box that makes up an application's user interface.  
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[ToolboxBitmap(typeof(Form), "Forms.Form.bmp")]
	[DesignerCategory("Form")]
	[InitializationEvent("Load")]
	[Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design", typeof(IRootDesigner))]
	[DesignTimeVisible(false)]
	[DefaultEvent("Load")]
	[MetadataTag("F")]
	[Skin(typeof(FormSkin))]
	[ProxyComponent(typeof(ProxyForm))]
	public class Form : ContainerControl, IForm, IWin32Window, IControl, IEventHandler, IRegisteredComponent, IFormParams, IObservableList
	{
		/// Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.FormClosing"></see> event.</summary>
		/// 2</filterpriority>
		public delegate void FormClosingEventHandler(object sender, FormClosingEventArgs e);

		/// Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.FormClosed"></see> event.</summary>
		/// 2</filterpriority>
		public delegate void FormClosedEventHandler(object sender, FormClosedEventArgs e);

		/// Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.OrientationChanged"></see> event.</summary>
		/// 2</filterpriority>
		public delegate void OrientationChangedEventHandler(object sender, OrientationChangedEventArgs e);

		[Flags]
		internal enum FormState
		{
			/// 
			/// The is active form flag
			/// </summary>
			IsActiveForm = 1,
			/// 
			/// The called on load flag
			/// </summary>
			CalledOnLoad = 2,
			/// 
			/// The called make visible flag
			/// </summary>
			CalledMakeVisible = 4,
			/// 
			/// The called create control flag
			/// </summary>
			CalledCreateControlProperty = 8,
			/// 
			/// The maximize box flag
			/// </summary>
			MaximizeBox = 0x10,
			/// 
			/// The minimize box flag
			/// </summary>
			MinimizeBox = 0x20,
			/// 
			/// The is closed flag
			/// </summary>
			IsClosed = 0x40,
			/// 
			/// The form moved flag
			/// </summary>
			Moved = 0x80,
			/// 
			/// The is modal active flag
			/// </summary>
			IsModalActive = 0x100,
			/// 
			/// The Close box flag
			/// </summary>
			CloseBox = 0x200
		}

		/// Represents a collection of controls on the form.</summary>
		[Serializable]
		public new class ControlCollection : Control.ControlCollection
		{
			private Form mobjOwner;

			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Form.ControlCollection"></see> class.</summary>
			/// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to contain the controls added to the control collection. </param>
			public ControlCollection(Form objOwner)
				: base(objOwner)
			{
				mobjOwner = objOwner;
			}

			/// 
			/// Adds the specified control to the control collection.
			/// </summary>
			/// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection. </param>
			public override void Add(Control objValue)
			{
				if (objValue is MdiClient && mobjOwner.MdiClient == null)
				{
					mobjOwner.MdiClient = (MdiClient)objValue;
				}
				base.Add(objValue);
			}

			/// Removes the specified control from the control collection.</summary>
			/// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove from the <see cref="T:Gizmox.WebGUI.Forms.Form.ControlCollection"></see>. </param>
			public override void Remove(Control objValue)
			{
				if (objValue == mobjOwner.MdiClient)
				{
					mobjOwner.MdiClient = null;
				}
				base.Remove(objValue);
			}
		}

		/// 
		/// Provides a property reference to TransparencyKey property.
		/// </summary>
		private static SerializableProperty TransparencyKeyProperty = SerializableProperty.Register("TransparencyKey", typeof(Color), typeof(Form), new SerializablePropertyMetadata(Color.Empty));

		/// 
		/// Provides a property reference to Header property.
		/// </summary>
		private static SerializableProperty HeaderProperty = SerializableProperty.Register("Header", typeof(Control), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to Icon property.
		/// </summary>
		private static SerializableProperty IconProperty = SerializableProperty.Register("Icon", typeof(ResourceHandle), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to MdiClient property.
		/// </summary>
		private static SerializableProperty MdiClientProperty = SerializableProperty.Register("MdiClient", typeof(MdiClient), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to OwnerProperty property.
		/// </summary>
		private static SerializableProperty OwnerProperty = SerializableProperty.Register("OwnerProperty", typeof(Form), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to DialogType property.
		/// </summary>
		private static SerializableProperty DialogTypeProperty = SerializableProperty.Register("DialogType", typeof(DialogTypes), typeof(Form), new SerializablePropertyMetadata(DialogTypes.MainWindow));

		/// 
		/// Provides a property reference to AcceptButton property.
		/// </summary>
		private static SerializableProperty AcceptButtonProperty = SerializableProperty.Register("AcceptButton", typeof(IButtonControl), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to BeforeUnloadMessage property.
		/// </summary>
		private static SerializableProperty BeforeUnloadMessageProperty = SerializableProperty.Register("BeforeUnloadMessage", typeof(string), typeof(Form), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to CancelButton property.
		/// </summary>
		private static SerializableProperty CancelButtonProperty = SerializableProperty.Register("CancelButton", typeof(IButtonControl), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to DialogResult property.
		/// </summary>
		private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof(DialogResult), typeof(Form), new SerializablePropertyMetadata(DialogResult.None));

		/// 
		/// Provides a property reference to DialogAlignment property.
		/// </summary>
		private static SerializableProperty DialogAlignmentProperty = SerializableProperty.Register("DialogAlignment", typeof(DialogAlignment), typeof(Form), new SerializablePropertyMetadata(DialogAlignment.Below));

		/// 
		/// Provides a property reference to AlignmentId property.
		/// </summary>
		private static SerializableProperty AlignmentIdProperty = SerializableProperty.Register("AlignmentId", typeof(string), typeof(Form), new SerializablePropertyMetadata("0"));

		/// 
		/// Provides a property reference to MemberAlignmentId property.
		/// </summary>
		private static SerializableProperty MemberAlignmentIdProperty = SerializableProperty.Register("MemberAlignmentId", typeof(string), typeof(Form), new SerializablePropertyMetadata("0"));

		/// 
		/// Provides a property reference to StartPosition property.
		/// </summary>
		private static SerializableProperty StartPositionProperty = SerializableProperty.Register("StartPosition", typeof(FormStartPosition), typeof(Form), new SerializablePropertyMetadata(FormStartPosition.WindowsDefaultLocation));

		/// 
		/// Provides a property reference to FormBorderStyle property.
		/// </summary>
		private static SerializableProperty FormBorderStyleProperty = SerializableProperty.Register("FormBorderStyle", typeof(FormBorderStyle), typeof(Form), new SerializablePropertyMetadata(FormBorderStyle.Sizable));

		/// 
		/// Provides a property reference to WindowState property.
		/// </summary>
		private static SerializableProperty WindowStateProperty = SerializableProperty.Register("WindowState", typeof(FormWindowState), typeof(Form), new SerializablePropertyMetadata(FormWindowState.Normal));

		/// 
		/// Provides a property reference to FormStyle property.
		/// </summary>
		private static SerializableProperty FormStyleProperty = SerializableProperty.Register("FormStyle", typeof(FormStyle), typeof(Form), new SerializablePropertyMetadata(FormStyle.Dialog));

		/// 
		/// Provides the entrance visual effect property
		/// </summary>
		private static SerializableProperty EntranceVisualEffectProperty = SerializableProperty.Register("EntranceVisualEffect", typeof(VisualEffect), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides the exit visual effect property
		/// </summary>
		private static SerializableProperty ExitVisualEffectProperty = SerializableProperty.Register("ExitVisualEffect", typeof(VisualEffect), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to MdiParent property.
		/// </summary>
		private static SerializableProperty MdiParentProperty = SerializableProperty.Register("MdiParent", typeof(Form), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to Menu property.
		/// </summary>
		private static SerializableProperty MenuProperty = SerializableProperty.Register("Menu", typeof(MainMenu), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to MainMenuStrip property.
		/// </summary>
		private static SerializableProperty MainMenuStripProperty = SerializableProperty.Register("MainMenuStrip", typeof(MenuStrip), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ClientStorage property.
		/// </summary>
		private static SerializableProperty ClientStorageProperty = SerializableProperty.Register("ClientStorage", typeof(ClientStorage), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to GeoLocationData property.
		/// </summary>
		private static SerializableProperty GeoLocationDataProperty = SerializableProperty.Register("GeoLocationData", typeof(GeoLocationData), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to Shortcuts property.
		/// </summary>
		private static SerializableProperty ShortcutsProperty = SerializableProperty.Register("Shortcuts", typeof(ShortcutsContainer), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to FormRestoredWindowState property.
		/// </summary>
		private static SerializableProperty FormRestoredWindowStateProperty = SerializableProperty.Register("FormRestoredWindowState", typeof(FormWindowState), typeof(Form), new SerializablePropertyMetadata(FormWindowState.Normal));

		/// 
		/// Provides a property reference to FormRestoredSize property.
		/// </summary>
		private static SerializableProperty FormRestoredSizeProperty = SerializableProperty.Register("FormRestoredSize", typeof(Size), typeof(Form), new SerializablePropertyMetadata(Size.Empty));

		/// 
		/// Provides a property reference to FormRestoredLocation property.
		/// </summary>
		private static SerializableProperty FormRestoredLocationProperty = SerializableProperty.Register("FormRestoredLocation", typeof(Point), typeof(Form), new SerializablePropertyMetadata(Point.Empty));

		/// 
		/// Provides a property reference to ActivateOnShow property.
		/// </summary>
		private static SerializableProperty ActivateOnShowProperty = SerializableProperty.Register("ActivateOnShow", typeof(bool), typeof(Form), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ControlBox property.
		/// </summary>
		private static SerializableProperty ControlBoxProperty = SerializableProperty.Register("ControlBox", typeof(bool), typeof(Form), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to KeyPreview property.
		/// </summary>
		private static SerializableProperty KeyPreviewProperty = SerializableProperty.Register("KeyPreview", typeof(bool), typeof(Form), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to HelpButton property.
		/// </summary>
		private static SerializableProperty HelpButtonProperty = SerializableProperty.Register("HelpButton", typeof(bool), typeof(Form), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ClosedDelegate property.
		/// </summary>
		private static SerializableProperty ClosedDelegateProperty = SerializableProperty.Register("ClosedDelegate", typeof(EventHandler), typeof(Form), new SerializablePropertyMetadata(null));

		/// 
		/// The Load event registration.
		/// </summary>
		private static readonly SerializableEvent LoadEvent;

		/// 
		/// The Closed event registration.
		/// </summary>
		private static readonly SerializableEvent ClosedEvent;

		/// 
		/// The Closing event registration.
		/// </summary>
		private static readonly SerializableEvent ClosingEvent;

		/// 
		///
		/// </summary>
		private static readonly SerializableEvent FormClosingEvent;

		/// 
		/// The Closed event registration.
		/// </summary>
		private static readonly SerializableEvent FormClosedEvent;

		/// 
		/// The Activated event registration.
		/// </summary>
		private static readonly SerializableEvent ActivatedEvent;

		/// 
		/// The Deactivate event registration.
		/// </summary>
		private static readonly SerializableEvent DeactivateEvent;

		/// 
		///
		/// </summary>
		private static readonly SerializableEvent OrientationChangedEvent;

		/// 
		/// The GeographicLocationChanged event registration.
		/// </summary>
		private static readonly SerializableEvent GeographicLocationChangedEvent;

		/// 
		/// The current context object
		/// </summary>
		[NonSerialized]
		private IContext mobjContext = null;

		/// 
		/// The form owned forms
		/// </summary>
		[NonSerialized]
		private FormCollection mobjOwnedForms = null;

		private HtmlBox mobjUnauthorizedAccessHtmlBox = null;

		/// 
		/// The amount of fields the form needs to serialize
		/// </summary>
		private const int mintFormSerializableFieldCount = 1;

		private object mobjAligmentComponent;

		private IIdentifiedComponent mobjAlignmentMemberComponent;

		/// 
		/// The form state
		/// </summary>
		[NonSerialized]
		private int mintFormState = 0;

		/// 
		/// The ModalMask property registration.
		/// </summary>
		private static readonly SerializableProperty ModalMaskProperty;

		/// 
		/// The ObservableItemAdded event registration.
		/// </summary>
		private static readonly SerializableEvent ObservableItemAddedEvent;

		/// 
		/// The ObservableItemInserted event registration.
		/// </summary>
		private static readonly SerializableEvent ObservableItemInsertedEvent;

		/// 
		/// The ObservableItemRemoved event registration.
		/// </summary>
		private static readonly SerializableEvent ObservableItemRemovedEvent;

		/// 
		/// The ObservableListCleared event registration.
		/// </summary>
		private static readonly SerializableEvent ObservableListClearedEvent;

		/// 
		/// Gets the hanlder for the Load event.
		/// </summary>
		private EventHandler LoadHandler => (EventHandler)GetHandler(LoadEvent);

		/// 
		/// Gets the hanlder for the Closed event.
		/// </summary>
		private EventHandler ClosedHandler => (EventHandler)GetHandler(ClosedEvent);

		/// 
		/// Gets the hanlder for the Closing event.
		/// </summary>
		private CancelEventHandler ClosingHandler => (CancelEventHandler)GetHandler(ClosingEvent);

		/// 
		/// Gets the form closing handler.
		/// </summary>
		/// The form closing handler.</value>
		private FormClosingEventHandler FormClosingHandler => (FormClosingEventHandler)GetHandler(FormClosingEvent);

		/// 
		/// Gets the hanlder for the Closed event.
		/// </summary>
		private FormClosedEventHandler FormClosedHandler => (FormClosedEventHandler)GetHandler(FormClosedEvent);

		/// 
		/// Gets the hanlder for the Activated event.
		/// </summary>
		private EventHandler ActivatedHandler => (EventHandler)GetHandler(ActivatedEvent);

		/// 
		/// Gets the hanlder for the Deactivate event.
		/// </summary>
		private EventHandler DeactivateHandler => (EventHandler)GetHandler(DeactivateEvent);

		/// 
		/// Gets the orientation change handler.
		/// </summary>
		private OrientationChangedEventHandler OrientationChangedHandler => (OrientationChangedEventHandler)GetHandler(OrientationChangedEvent);

		/// 
		/// Gets the geographic location changed handler.
		/// </summary>
		private GeographicLocationChangedEventHandler GeographicLocationChangedHandler => (GeographicLocationChangedEventHandler)GetHandler(GeographicLocationChangedEvent);

		/// 
		/// Gets the security stopper html box.
		/// </summary>
		/// 
		/// The security stopper.
		/// </value>
		private HtmlBox UnauthorizedAccessHtmlBox
		{
			get
			{
				if (mobjUnauthorizedAccessHtmlBox == null)
				{
					mobjUnauthorizedAccessHtmlBox = new HtmlBox();
					mobjUnauthorizedAccessHtmlBox.Dock = DockStyle.Fill;
					mobjUnauthorizedAccessHtmlBox.Url = "Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.Commons.Messages.Unauthorized.html.wgx";
				}
				return mobjUnauthorizedAccessHtmlBox;
			}
		}

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize
		{
			get
			{
				int num = base.SerializableDataInitialSize + 1;
				return num + SerializationWriter.GetRequiredCapacity(mobjOwnedForms);
			}
		}

		/// 
		/// Gets a value indicating whether this instance is root form.
		/// </summary>
		/// 
		/// 	true</c> if this instance is root form; otherwise, false</c>.
		/// </value>
		private bool IsRootForm => Context.MainForm == this;

		/// 
		///  Gets or sets the MainMenu that is displayed in the form.  
		/// </summary>
		public MainMenu Menu
		{
			get
			{
				return GetValue(MenuProperty);
			}
			set
			{
				MainMenu menu = Menu;
				if (SetValue(MenuProperty, value))
				{
					if (menu != null)
					{
						UnRegisterComponent(menu);
					}
					if (value != null)
					{
						value.Dock = DockStyle.Top;
						value.InternalParent = this;
						RegisterComponent(value);
					}
					Update();
				}
			}
		}

		/// Gets or sets the primary menu container for the form.</summary>
		/// A <see cref="T:Gizmox.WebGui.Forms.MenuStrip"></see> that represents the container for the menu structure of the form. The default is null.</returns>
		[SRCategory("CatWindowStyle")]
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		[SRDescription("FormMenuStripDescr")]
		public MenuStrip MainMenuStrip
		{
			get
			{
				return GetValue(MainMenuStripProperty);
			}
			set
			{
				MenuStrip mainMenuStrip = MainMenuStrip;
				if (SetValue(MainMenuStripProperty, value))
				{
					if (mainMenuStrip != null)
					{
						UnRegisterComponent(mainMenuStrip);
					}
					if (value != null)
					{
						value.InternalParent = this;
						RegisterComponent(value);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the client storage.
		/// </summary>
		/// 
		/// The client storage.
		/// </value>
		[SRCategory("Client")]
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		[SRDescription("ClientStorageDescr")]
		public ClientStorage ClientStorage
		{
			get
			{
				return GetValue(ClientStorageProperty);
			}
			set
			{
				ClientStorage clientStorage = ClientStorage;
				if (SetValue(ClientStorageProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// A data which defines the geographic location services.
		/// </summary>
		/// 
		/// The geo location.
		/// </value>
		[Category("Misc")]
		[Description("A data which defines the geographic location services.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public GeoLocationData GeographicLocation
		{
			get
			{
				return GetValue(GeoLocationDataProperty);
			}
			set
			{
				if (SetValue(GeoLocationDataProperty, value))
				{
					UpdateParams(AttributeType.GeographicLocation);
				}
			}
		}

		/// 
		/// Gets the initial size of the serializable filed storage.
		/// </summary>
		/// The initial size of the serializable filed storage.</value>
		protected override int SerializableFieldStorageInitialSize { get
			{
				return 20;
			}
		}

		/// 
		/// Gets the form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.
		/// </summary>
		/// The form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.</returns>
		/// </value>
		internal ShortcutsContainer Shortcuts
		{
			get
			{
				ShortcutsContainer shortcutsContainer = GetValue(ShortcutsProperty);
				if (shortcutsContainer == null)
				{
					shortcutsContainer = new ShortcutsContainer();
					shortcutsContainer.InternalParent = this;
					SetValue(ShortcutsProperty, shortcutsContainer);
				}
				return shortcutsContainer;
			}
		}

		/// Gets or sets the current multiple document interface (MDI) parent form of this form.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that represents the MDI parent form.</returns>
		/// <exception cref="T:System.Exception">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is not marked as an MDI container.-or- The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is both a child and an MDI container form.-or- The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is located on a different thread. </exception>
		[SRCategory("CatWindowStyle")]
		[SRDescription("FormMDIParentDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Form MdiParent
		{
			get
			{
				return MdiParentInternal;
			}
			set
			{
				MdiParentInternal = value;
			}
		}

		/// 
		/// Gets or sets the MDI parent internal.
		/// </summary>
		/// The MDI parent internal.</value>
		private Form MdiParentInternal
		{
			get
			{
				return GetValue(MdiParentProperty);
			}
			set
			{
				Form mdiParentInternal = MdiParentInternal;
				if (value == mdiParentInternal && (value != null || ParentInternal == null))
				{
					return;
				}
				bool visible = base.Visible;
				base.Visible = false;
				try
				{
					if (value == null)
					{
						SetTopLevel(blnValue: true);
						return;
					}
					if (IsMdiContainer)
					{
						throw new ArgumentException(SR.GetString("FormMDIParentAndChild"), "value");
					}
					if (!value.IsMdiContainer)
					{
						throw new ArgumentException(SR.GetString("MDIParentNotContainer"), "value");
					}
					Dock = DockStyle.None;
					SetState(ControlState.TopLevel, blnValue: false);
					SetValue(MdiParentProperty, value);
				}
				finally
				{
					base.Visible = visible;
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance is closed.
		/// </summary>
		/// 
		/// 	true</c> if this instance is closed; otherwise, false</c>.
		/// </value>
		bool IForm.IsClosed => GetState(FormState.IsClosed);

		/// 
		/// Gets a value indicating whether this instance is modal active.
		/// </summary>
		/// 
		/// 	true</c> if this instance is modal active; otherwise, false</c>.
		/// </value>
		bool IForm.IsModalActive => GetState(FormState.IsModalActive);

		/// Gets or sets the style of the size grip to display in the lower-right corner of the form.</summary>
		/// A <see cref="T:System.Windows.Forms.SizeGripStyle"></see> that represents the style of the size grip to display. The default is <see cref="F:System.Windows.Forms.SizeGripStyle.Auto"></see></returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values. </exception>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(SizeGripStyle.Auto)]
		[SRDescription("FormSizeGripStyleDescr")]
		[SRCategory("CatWindowStyle")]
		public SizeGripStyle SizeGripStyle
		{
			get
			{
				return SizeGripStyle.Auto;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether right-to-left mirror placement is turned on.</summary>
		/// true if right-to-left mirror placement is turned on; otherwise, false for standard child control placement. The default is false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ControlRightToLeftLayoutDescr")]
		[Localizable(true)]
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		public virtual bool RightToLeftLayout
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Common.Interfaces.IForm" /> is active.
		/// </summary>
		/// true</c> if active; otherwise, false</c>.</value>
		bool IForm.Active
		{
			get
			{
				return Active;
			}
			set
			{
				Active = value;
			}
		}

		/// 
		/// Gets the forms.
		/// </summary>
		/// The forms.</value>
		IForm[] IForm.Forms
		{
			get
			{
				IForm[] result = null;
				FormCollection ownedFormsCollection = OwnedFormsCollection;
				if (ownedFormsCollection != null && ownedFormsCollection.Count > 0)
				{
					result = (IForm[])new ArrayList(ownedFormsCollection).ToArray(typeof(IForm));
				}
				return result;
			}
		}

		/// 
		/// Gets or sets the name associated with this control.
		/// </summary>
		/// </value>
		string IForm.Name => base.Name;

		/// 
		/// Gets the form main menu
		/// </summary>
		IMainMenu IForm.Menu
		{
			get
			{
				return Menu;
			}
			set
			{
				if (value is MainMenu menu)
				{
					Menu = menu;
				}
			}
		}

		/// 
		/// Calculate size invluding borders
		/// </summary>
		[Browsable(false)]
		protected virtual bool IsWindowSized => false;

		/// Gets a value indicating whether the form is a multiple document interface (MDI) child form.</summary>
		/// true if the form is an MDI child form; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("FormIsMDIChildDescr")]
		[SRCategory("CatWindowStyle")]
		public bool IsMdiChild => MdiParent != null;

		/// 
		/// Gets or sets a value indicating whether to use WG namespace.
		/// </summary>
		/// true</c> if to use WG namespace; otherwise, false</c>.</value>
		internal override bool UseWGNamespace => TopLevel;

		/// Gets or sets a value indicating whether the form is a container for multiple document interface (MDI) child forms.</summary>
		/// true if the form is a container for MDI child forms; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatWindowStyle")]
		[SRDescription("FormIsMDIContainerDescr")]
		[DefaultValue(false)]
		public bool IsMdiContainer
		{
			get
			{
				return MdiClient != null;
			}
			set
			{
				if (value != IsMdiContainer)
				{
					if (value)
					{
						MdiClient mdiClient = (MdiClient = new MdiClient());
						MdiClient objValue = mdiClient;
						base.Controls.Add(objValue);
					}
					else if (IsMdiContainer)
					{
						base.Controls.Remove(MdiClient);
						MdiClient = null;
					}
					Invalidate();
				}
			}
		}

		/// 
		/// Gets or sets the form style.
		/// </summary>
		/// </value>
		public FormStyle FormStyle
		{
			get
			{
				return GetValue(FormStyleProperty);
			}
			set
			{
				if (SetValue(FormStyleProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the entrance visual effect.
		/// </summary>
		/// 
		/// The entrance visual effect.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[MergableProperty(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("EntranceEffectDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public VisualEffect EntranceEffect
		{
			get
			{
				return GetValue(EntranceVisualEffectProperty, DefaultEntranceEffect);
			}
			set
			{
				if (SetValue(EntranceVisualEffectProperty, value))
				{
					UpdateParams(AttributeType.VisualEffect);
				}
			}
		}

		/// 
		/// Gets or sets the exit visual effect.
		/// </summary>
		/// 
		/// The exit visual effect.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[MergableProperty(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("ExitEffectDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public VisualEffect ExitEffect
		{
			get
			{
				return GetValue(ExitVisualEffectProperty, DefaultExitEffect);
			}
			set
			{
				if (SetValue(ExitVisualEffectProperty, value))
				{
					UpdateParams(AttributeType.VisualEffect);
				}
			}
		}

		/// 
		/// Gets the default exit effect.
		/// </summary>
		/// 
		/// The default exit effect.
		/// </value>
		protected virtual VisualEffect DefaultExitEffect => new TranslateVisualEffect(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0f, null), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100f, null), 0.25m, 0m, TransitionTimingFunction.EaseInOut);

		/// 
		/// Gets the default entrance effect.
		/// </summary>
		/// 
		/// The default entrance effect.
		/// </value>
		protected virtual VisualEffect DefaultEntranceEffect => new TranslateVisualEffect(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100f, null), new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0f, null), 0.25m, 0m, TransitionTimingFunction.EaseInOut);

		/// 
		/// Gets or sets the restored window state before it was minimized.
		/// </summary>
		/// The last state of the form window.</value>
		private FormWindowState FormRestoredWindowState
		{
			get
			{
				return GetValue(FormRestoredWindowStateProperty);
			}
			set
			{
				SetValue(FormRestoredWindowStateProperty, value);
			}
		}

		/// 
		/// Gets the size of a minimized form.
		/// </summary>
		/// The size of a minimized form.</value>
		private Size FormMinimizedSize
		{
			get
			{
				Size result = Size.Empty;
				if (MdiParent != null)
				{
					if (SkinFactory.GetSkin(this, typeof(FormSkin)) is FormSkin formSkin)
					{
						result = formSkin.MinimizedMdiFormSize;
					}
				}
				else if (SkinFactory.GetSkin(this, typeof(TaskBarSkin)) is TaskBarSkin taskBarSkin)
				{
					result = new Size(taskBarSkin.ItemWidth, taskBarSkin.ItemHeight);
				}
				return result;
			}
		}

		/// 
		/// Gets or sets the size of the form before it was maximized.
		/// </summary>
		/// The size of the form restored.</value>
		private Size FormRestoredSize
		{
			get
			{
				return GetValue(FormRestoredSizeProperty);
			}
			set
			{
				SetValue(FormRestoredSizeProperty, value);
			}
		}

		/// 
		/// Gets or sets the location of the form before it was maximized.
		/// </summary>
		/// The form restored location.</value>
		private Point FormRestoredLocation
		{
			get
			{
				return GetValue(FormRestoredLocationProperty);
			}
			set
			{
				SetValue(FormRestoredLocationProperty, value);
			}
		}

		/// 
		/// Gets or sets the state of the window.
		/// </summary>
		/// </value>
		[DefaultValue(FormWindowState.Normal)]
		[SRDescription("FormWindowStateDescr")]
		[SRCategory("CatLayout")]
		public FormWindowState WindowState
		{
			get
			{
				return GetValue(WindowStateProperty);
			}
			set
			{
				SetWindowState(value);
			}
		}

		/// 
		/// Gets or sets the form border style.
		/// </summary>
		/// </value>
		[DefaultValue(FormBorderStyle.Sizable)]
		[SRCategory("CatAppearance")]
		[SRDescription("FormBorderStyleDescr")]
		public FormBorderStyle FormBorderStyle
		{
			get
			{
				return GetValue(FormBorderStyleProperty);
			}
			set
			{
				if (SetValue(FormBorderStyleProperty, value))
				{
					UpdateParams(AttributeType.Redraw);
					FireObservableItemPropertyChanged("FormBorderStyle");
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [minimize box].
		/// </summary>
		/// 
		/// 	true</c> if [minimize box]; otherwise, false</c>.
		/// </value>
		[SRCategory("CatWindowStyle")]
		[DefaultValue(true)]
		[SRDescription("FormMinimizeBoxDescr")]
		public bool MinimizeBox
		{
			get
			{
				return GetState(FormState.MinimizeBox);
			}
			set
			{
				if (SetStateWithCheck(FormState.MinimizeBox, value))
				{
					FireObservableItemPropertyChanged("MinimizeBox");
					UpdateParams(AttributeType.Extended);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether a form has a modal mask when modal.
		/// </summary>
		/// true</c> if a form has a modal mask when modal; otherwise, false</c>.</value>
		[SRCategory("CatWindowStyle")]
		[DefaultValue(true)]
		[SRDescription("FormModalMaskDescr")]
		public bool ModalMask
		{
			get
			{
				return GetValue(ModalMaskProperty);
			}
			set
			{
				SetValue(ModalMaskProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [maximize box].
		/// </summary>
		/// 
		/// 	true</c> if [maximize box]; otherwise, false</c>.
		/// </value>
		[SRDescription("FormMaximizeBoxDescr")]
		[SRCategory("CatWindowStyle")]
		[DefaultValue(true)]
		public bool MaximizeBox
		{
			get
			{
				return GetState(FormState.MaximizeBox);
			}
			set
			{
				if (SetStateWithCheck(FormState.MaximizeBox, value))
				{
					FireObservableItemPropertyChanged("MaximizeBox");
					UpdateParams(AttributeType.Extended);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [close box].
		/// </summary>
		/// 
		///   true</c> if [close box]; otherwise, false</c>.
		/// </value>
		[SRDescription("FormCloseBoxDescr")]
		[SRCategory("CatWindowStyle")]
		[DefaultValue(true)]
		public bool CloseBox
		{
			get
			{
				return GetState(FormState.CloseBox);
			}
			set
			{
				if (SetStateWithCheck(FormState.CloseBox, value))
				{
					FireObservableItemPropertyChanged("CloseBox");
					UpdateParams(AttributeType.Extended);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show in taskbar].
		/// Not implemented by design
		/// </summary>
		/// 
		/// 	true</c> if [show in taskbar]; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[SRDescription("FormShowInTaskbarDescr")]
		[SRCategory("CatWindowStyle")]
		[Obsolete("Not implemented by design")]
		public bool ShowInTaskbar
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets The starting position of the window
		/// </summary>
		/// </value>
		[SRDescription("FormStartPositionDescr")]
		[DefaultValue(2)]
		[Localizable(true)]
		[SRCategory("CatLayout")]
		public FormStartPosition StartPosition
		{
			get
			{
				return GetValue(StartPositionProperty);
			}
			set
			{
				if (SetValue(StartPositionProperty, value))
				{
					FireObservableItemPropertyChanged("StartPosition");
				}
			}
		}

		/// 
		/// Gets or sets the dialog Alignment.
		/// </summary>
		/// </value>
		private DialogAlignment DialogAlignment
		{
			get
			{
				return GetValue(DialogAlignmentProperty);
			}
			set
			{
				SetValue(DialogAlignmentProperty, value);
			}
		}

		/// 
		/// Gets or sets the dialog result.
		/// </summary>
		/// </value>
		public DialogResult DialogResult
		{
			get
			{
				return GetValue(DialogResultProperty);
			}
			set
			{
				SetValue(DialogResultProperty, value);
			}
		}

		/// 
		/// Gets or sets the button on the form that is clicked when the user presses the ESC key.
		/// </summary>
		public IButtonControl CancelButton
		{
			get
			{
				return GetValue(CancelButtonProperty);
			}
			set
			{
				if (SetValue(CancelButtonProperty, value))
				{
					UpdateParams(AttributeType.Control);
					if (value != null && value.DialogResult == DialogResult.None)
					{
						value.DialogResult = DialogResult.Cancel;
					}
				}
			}
		}

		/// 
		/// Gets or sets the before unload message.
		/// </summary>
		/// The before unload message.</value>
		[Localizable(true)]
		[DefaultValue("")]
		public string BeforeUnloadMessage
		{
			get
			{
				return GetValue(BeforeUnloadMessageProperty);
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				if (SetValue(BeforeUnloadMessageProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the button on the form that is clicked when the user presses the ENTER key.
		/// </summary>
		public IButtonControl AcceptButton
		{
			get
			{
				return GetValue(AcceptButtonProperty);
			}
			set
			{
				if (SetValue(AcceptButtonProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [top most].
		/// </summary>
		/// true</c> if [top most]; otherwise, false</c>.</value>
		[SRDescription("FormTopMostDescr")]
		[SRCategory("CatWindowStyle")]
		[DefaultValue(false)]
		public bool TopMost
		{
			get
			{
				if (!base.DesignMode && Context != null)
				{
					return Context.ActiveForm == this;
				}
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Gets/Sets visibility internally
		/// </summary>
		internal bool InternalVisible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.SetVisibleInternal(value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [called on load].
		/// </summary>
		/// true</c> if [called on load]; otherwise, false</c>.</value>
		private bool CalledOnLoad
		{
			get
			{
				return GetState(FormState.CalledOnLoad);
			}
			set
			{
				SetState(FormState.CalledOnLoad, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [called make visible].
		/// </summary>
		/// true</c> if [called make visible]; otherwise, false</c>.</value>
		private bool CalledMakeVisible
		{
			get
			{
				return GetState(FormState.CalledMakeVisible);
			}
			set
			{
				SetState(FormState.CalledMakeVisible, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [called create control].
		/// </summary>
		/// true</c> if [called create control]; otherwise, false</c>.</value>
		private bool CalledCreateControl
		{
			get
			{
				return GetState(FormState.CalledCreateControlProperty);
			}
			set
			{
				SetState(FormState.CalledCreateControlProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether the form was moved.
		/// </summary>
		/// true</c> if moved; otherwise, false</c>.</value>
		private bool Moved
		{
			get
			{
				return GetState(FormState.Moved);
			}
			set
			{
				SetState(FormState.Moved, value);
			}
		}

		/// 
		/// Gets the context.
		/// </summary>
		/// </value>
		public override IContext Context
		{
			get
			{
				if (TopLevel)
				{
					IContext context = mobjContext;
					if (context == null)
					{
						context = (mobjContext = VWGContext.Current);
					}
					return context;
				}
				return base.Context;
			}
		}

		/// 
		/// Gets or sets a value indicating whether this window is modal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is modal; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Modal => DialogType switch
		{
			DialogTypes.ModalessWindow => false, 
			DialogTypes.ModalWindow => true, 
			DialogTypes.PopupWindow => false, 
			_ => false, 
		};

		///  
		///     Retrieves true if this form is currently active. 
		/// </devdoc>
		internal bool Active
		{
			get
			{
				Form parentFormInternal = base.ParentFormInternal;
				if (parentFormInternal == null)
				{
					return GetState(FormState.IsActiveForm);
				}
				return parentFormInternal.ActiveControl == this && parentFormInternal.Active;
			}
			set
			{
				if (!SetStateWithCheck(FormState.IsActiveForm, value))
				{
					return;
				}
				if (value)
				{
					if (!base.ValidationCancelled)
					{
						if (base.ActiveControl == null)
						{
							SelectNextControlInternal(null, blnForward: true, blnTabStopOnly: true, blnNested: true, blnWrap: false);
						}
						base.InnerMostActiveContainerControl.FocusActiveControlInternal();
					}
					OnActivated(EventArgs.Empty);
				}
				else
				{
					OnDeactivate(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets the parent container of this control.
		/// </summary>
		/// </value>
		internal override Control ParentInternal
		{
			get
			{
				return base.ParentInternal;
			}
			set
			{
				if (value != null)
				{
					Owner = null;
				}
				base.ParentInternal = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether to display the form as a top-level window.
		/// </summary>
		/// true</c> if [top level]; otherwise, false</c>.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool TopLevel
		{
			get
			{
				return GetTopLevel();
			}
			set
			{
				if (!value && IsMdiContainer && !base.DesignMode)
				{
					throw new ArgumentException(SR.GetString("MDIContainerMustBeTopLevel"), "value");
				}
				SetTopLevel(value);
			}
		}

		/// 
		/// Gets or sets the type.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DialogTypes DialogType
		{
			get
			{
				return GetValue(DialogTypeProperty);
			}
			internal set
			{
				SetValue(DialogTypeProperty, value);
			}
		}

		/// Gets or sets the form that owns this form.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that represents the form that is the owner of this form.</returns>
		/// <exception cref="T:System.Exception">A top-level window cannot have an owner. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("FormOwnerDescr")]
		[SRCategory("CatWindowStyle")]
		public Form Owner
		{
			get
			{
				return OwnerInternal;
			}
			set
			{
				Form ownerInternal = OwnerInternal;
				if (ownerInternal != value)
				{
					if (value != null && !TopLevel)
					{
						throw new ArgumentException(SR.GetString("NonTopLevelCantHaveOwner"), "value");
					}
					Control.CheckParentingCycle(this, value);
					Control.CheckParentingCycle(value, this);
					SetValue(OwnerProperty, null);
					ownerInternal?.RemoveOwnedForm(this);
					OwnerInternal = value;
					value?.AddOwnedForm(this);
				}
			}
		}

		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[SRDescription("ControlTabStopDescr")]
		[DefaultValue(true)]
		[DispId(-516)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool TabStop
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

		/// Gets or sets the tab order of the control within its container.</summary>
		/// An <see cref="T:System.Int32"></see> containing the index of the control within the set of controls within its container that is included in the tab order.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		/// Gets or sets the parent window.
		/// </summary>
		/// </value>
		internal Form OwnerInternal
		{
			get
			{
				return GetValue(OwnerProperty);
			}
			set
			{
				SetValue(OwnerProperty, value);
			}
		}

		/// 
		/// Gets or sets the closed delegate.
		/// </summary>
		/// 
		/// The closed delegate.
		/// </value>
		private EventHandler ClosedDelegate
		{
			get
			{
				return GetValue(ClosedDelegateProperty);
			}
			set
			{
				SetValue(ClosedDelegateProperty, value);
			}
		}

		/// 
		/// Gets the child forms.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Form[] OwnedForms
		{
			get
			{
				if (mobjOwnedForms == null)
				{
					return new Form[0];
				}
				ArrayList arrayList = new ArrayList(mobjOwnedForms);
				return (Form[])arrayList.ToArray(typeof(Form));
			}
		}

		/// 
		/// Gets the form FormCollection from propertyStore if existed and a new FormCollection otherwise.
		/// </summary>
		/// The form FormCollection from propertyStore if existed and a new FormCollection otherwise.</returns>
		/// </value>
		internal FormCollection OwnedFormsCollection
		{
			get
			{
				if (mobjOwnedForms == null)
				{
					mobjOwnedForms = new FormCollection(this);
				}
				return mobjOwnedForms;
			}
		}

		/// 
		/// Gets a value indicating whether this instance has windows.
		/// </summary>
		/// 
		/// 	true</c> if this instance has windows; otherwise, false</c>.
		/// </value>
		internal bool HasWindows
		{
			get
			{
				FormCollection ownedFormsCollection = OwnedFormsCollection;
				if (ownedFormsCollection != null)
				{
					return ownedFormsCollection.Count > 0;
				}
				return false;
			}
		}

		/// 
		/// Gets a value indicating whether this instance has modal windows.
		/// </summary>
		/// 
		/// 	true</c> if this instance has modal windows; otherwise, false</c>.
		/// </value>
		internal bool HasModalWindows => OwnedModalForm != null;

		/// 
		/// Gets the owned modal form.
		/// </summary>
		/// The owned modal form.</value>
		private Form OwnedModalForm
		{
			get
			{
				Form result = null;
				FormCollection ownedFormsCollection = OwnedFormsCollection;
				if (ownedFormsCollection != null && ownedFormsCollection.Count > 0)
				{
					foreach (Form item in ownedFormsCollection)
					{
						if (item.TopLevel && item.DialogType == DialogTypes.ModalWindow)
						{
							result = item;
						}
					}
				}
				return result;
			}
		}

		/// 
		/// Gets the top most owned modal form.
		/// </summary>
		/// The top most owned modal form.</value>
		private Form TopMostOwnedModalForm
		{
			get
			{
				Form result = null;
				Form ownedModalForm = OwnedModalForm;
				if (ownedModalForm != null && (result = ownedModalForm.TopMostOwnedModalForm) == null)
				{
					result = ownedModalForm;
				}
				return result;
			}
		}

		/// 
		/// Gets or sets the form Mdi client
		/// </summary>
		public MdiClient MdiClient
		{
			get
			{
				return GetValue(MdiClientProperty);
			}
			internal set
			{
				SetValue(MdiClientProperty, value);
			}
		}

		/// 
		/// Gets the form Mdi children
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form[] MdiChildren
		{
			get
			{
				if (MdiClient != null)
				{
					return MdiClient.MdiChildren;
				}
				return new Form[0];
			}
		}

		/// 
		/// Gets the form active Mdi child
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form ActiveMdiChild => null;

		/// 
		/// Gets or sets the form icon
		/// </summary>
		[ProxyBrowsable(true)]
		public ResourceHandle Icon
		{
			get
			{
				return GetValue(IconProperty);
			}
			set
			{
				SetValue(IconProperty, value);
			}
		}

		/// 
		/// Gets or sets the size of the auto scale base.
		/// Not implemented.
		/// </summary>
		/// </value>
		[Obsolete("Not implemented.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public Size AutoScaleBaseSize
		{
			get
			{
				return new Size(5, 3);
			}
			set
			{
			}
		}

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// 
		/// 	true</c> if this instance is events enabled; otherwise, false</c>.
		/// </value>        
		/// false if one of the controls is hidden or disabled.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsEventsEnabled => base.Visible;

		/// 
		/// Gets or sets the form header control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public Control Header
		{
			get
			{
				return GetValue(HeaderProperty);
			}
			set
			{
				if (SetValue(HeaderProperty, value) && value != null)
				{
					value.InternalParent = this;
				}
			}
		}

		/// 
		/// Gets or sets the color that will represent transparent areas of the form. 
		/// Not implemented by design.
		/// </summary>
		/// The transparency key.</value>
		[Obsolete("Not implemented by design")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Color TransparencyKey
		{
			get
			{
				return GetValue(TransparencyKeyProperty);
			}
			set
			{
				SetValue(TransparencyKeyProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [activate on pre render].
		/// </summary>
		/// 
		/// 	true</c> if [activate on show]; otherwise, false</c>.
		/// </value>
		protected virtual bool ActivateOnShow
		{
			get
			{
				return GetValue(ActivateOnShowProperty);
			}
			set
			{
				SetValue(ActivateOnShowProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether a control box is displayed in the caption bar of the form.
		/// </summary>
		/// 
		///   true</c> if the form displays a control box in the upper left corner of the form; otherwise, false</c>. The default is true.
		/// </value>
		[SRCategory("CatWindowStyle")]
		[DefaultValue(true)]
		[SRDescription("FormControlBoxDescr")]
		public bool ControlBox
		{
			get
			{
				return GetValue(ControlBoxProperty);
			}
			set
			{
				if (SetValue(ControlBoxProperty, value))
				{
					UpdateParams(AttributeType.Extended);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [key preview].
		/// </summary>
		/// 
		///   true</c> if [key preview]; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool KeyPreview
		{
			get
			{
				return GetValue(KeyPreviewProperty);
			}
			set
			{
				SetValue(KeyPreviewProperty, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [help button].
		/// </summary>
		/// 
		///   true</c> if [help button]; otherwise, false</c>.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HelpButton
		{
			get
			{
				return GetValue(HelpButtonProperty);
			}
			set
			{
				SetValue(HelpButtonProperty, value);
			}
		}

		/// Gets or sets a value indicating whether an icon is displayed in the caption bar of the form.</summary>
		/// true if the form displays an icon in the caption bar; otherwise, false. The default is true.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatWindowStyle")]
		[SRDescription("FormShowIconDescr")]
		[DefaultValue(true)]
		public bool ShowIcon
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// Gets or sets the opacity level of the form.</summary>
		/// The level of opacity for the form. The default is 1.00.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(1.0)]
		[SRDescription("FormOpacityDescr")]
		[SRCategory("CatWindowStyle")]
		public double Opacity
		{
			get
			{
				return 1.0;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is resizable.
		/// </summary>
		/// 
		///   true</c> if resizable; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		[Obsolete("Use FormBorderStyle property to change resizable functionality")]
		public override ResizableOptions Resizable
		{
			get
			{
				if (!TopLevel)
				{
					return base.Resizable;
				}
				return null;
			}
			set
			{
				if (!TopLevel)
				{
					base.Resizable = value;
				}
			}
		}

		/// 
		/// Gets the hanlder for the ObservableItemAdded event.
		/// </summary>
		private ObservableListEventHandler ObservableItemAddedHandler => (ObservableListEventHandler)GetHandler(ObservableItemAddedEvent);

		/// 
		/// Gets the hanlder for the ObservableItemInserted event.
		/// </summary>
		private ObservableListEventHandler ObservableItemInsertedHandler => (ObservableListEventHandler)GetHandler(ObservableItemInsertedEvent);

		/// 
		/// Gets the hanlder for the ObservableItemRemoved event.
		/// </summary>
		private ObservableListEventHandler ObservableItemRemovedHandler => (ObservableListEventHandler)GetHandler(ObservableItemRemovedEvent);

		/// 
		/// Gets the hanlder for the ObservableListCleared event.
		/// </summary>
		private EventHandler ObservableListClearedHandler => (EventHandler)GetHandler(ObservableListClearedEvent);

		IProxyForm IFormParams.ProxyForm
		{
			get
			{
				return ProxyComponent as IProxyForm;
			}
			set
			{
				ProxyComponent = value as ProxyComponent;
			}
		}

		/// 
		/// The form load event
		/// </summary>
		public event EventHandler Load
		{
			add
			{
				AddHandler(LoadEvent, value);
			}
			remove
			{
				RemoveHandler(LoadEvent, value);
			}
		}

		/// 
		/// Occurs when the form is closed.
		/// </summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[SRDescription("FormOnClosedDescr")]
		[Browsable(false)]
		public event EventHandler Closed
		{
			add
			{
				AddCriticalHandler(ClosedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ClosedEvent, value);
			}
		}

		/// 
		/// Occurs when the form is closing.
		/// </summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("FormOnClosingDescr")]
		[Browsable(false)]
		public event CancelEventHandler Closing
		{
			add
			{
				AddCriticalHandler(ClosingEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ClosingEvent, value);
			}
		}

		/// Occurs before the form is closed.</summary>
		/// 1</filterpriority>
		[SRDescription("FormOnFormClosingDescr")]
		[SRCategory("CatBehavior")]
		public event FormClosingEventHandler FormClosing
		{
			add
			{
				AddCriticalHandler(FormClosingEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(FormClosingEvent, value);
			}
		}

		/// Occurs after the form is closed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("FormOnFormClosedDescr")]
		public event FormClosedEventHandler FormClosed
		{
			add
			{
				AddCriticalHandler(FormClosedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(FormClosedEvent, value);
			}
		}

		/// 
		/// Occurs when the form is activated in code or by the user.
		/// </summary>
		public event EventHandler Activated
		{
			add
			{
				AddCriticalHandler(ActivatedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ActivatedEvent, value);
			}
		}

		/// 
		///    Occurs when the form loses focus and is not the active form.</para>
		/// </devdoc> 
		[SRDescription("FormOnDeactivateDescr")]
		[SRCategory("CatFocus")]
		public event EventHandler Deactivate
		{
			add
			{
				AddCriticalHandler(DeactivateEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DeactivateEvent, value);
			}
		}

		/// 
		/// Occurs when orientation is changed.
		/// </summary>
		[SRCategory("Mobile Devices")]
		[Description("OrientationChange Happens when moblie device orientation is changed from landscape to  portrait.")]
		public event OrientationChangedEventHandler OrientationChanged
		{
			add
			{
				AddCriticalHandler(OrientationChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(OrientationChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client orientation changed].
		/// </summary>
		[SRDescription("Occurs when oblie device orientation is changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientOrientationChanged
		{
			add
			{
				AddClientHandler("OrientationChange", value);
			}
			remove
			{
				RemoveClientHandler("OrientationChange", value);
			}
		}

		/// 
		/// Occurs when [location changed].
		/// </summary>
		public event GeographicLocationChangedEventHandler GeographicLocationChanged
		{
			add
			{
				ValidateGeoLocationCapability();
				AddHandler(GeographicLocationChangedEvent, value);
			}
			remove
			{
				RemoveHandler(GeographicLocationChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client geographic location changed].
		/// </summary>
		[SRDescription("Occurs when device geolocation changes in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientGeographicLocationChanged
		{
			add
			{
				AddClientHandler("GeoLocationChanged", value);
			}
			remove
			{
				RemoveClientHandler("GeoLocationChanged", value);
			}
		}

		private event EventHandler mobjPreRender;

		/// 
		/// Occurs when [observable item added].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableListEventHandler ObservableItemAdded
		{
			add
			{
				AddHandler(ObservableItemAddedEvent, value);
			}
			remove
			{
				RemoveHandler(ObservableItemAddedEvent, value);
			}
		}

		/// 
		/// Occurs when [observable item inserted].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableListEventHandler ObservableItemInserted
		{
			add
			{
				AddHandler(ObservableItemInsertedEvent, value);
			}
			remove
			{
				RemoveHandler(ObservableItemInsertedEvent, value);
			}
		}

		/// 
		/// Occurs when [observable item removed].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableListEventHandler ObservableItemRemoved
		{
			add
			{
				AddHandler(ObservableItemRemovedEvent, value);
			}
			remove
			{
				RemoveHandler(ObservableItemRemovedEvent, value);
			}
		}

		/// 
		/// Occurs when [observable list cleared].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event EventHandler ObservableListCleared
		{
			add
			{
				AddHandler(ObservableListClearedEvent, value);
			}
			remove
			{
				RemoveHandler(ObservableListClearedEvent, value);
			}
		}

		/// 
		/// Occurs when the client loads and provides online preperations for entering client mode.
		/// </summary>
		/// 
		/// The client mode preload handlers.
		/// </value>
		[Category("Client")]
		[Description("Occurs when the client loads and provides online preperations for entering client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientPreload
		{
			add
			{
				AddClientHandler("ClientPreload", value);
			}
			remove
			{
				RemoveClientHandler("ClientPreload", value);
			}
		}

		/// 
		/// Occurs when client mode is initialized
		/// </summary>
		/// 
		/// The client mode initialized handlers.
		/// </value>
		[Category("Client")]
		[Description("Occurs after the application changed to offline mode, and offline initializing should be performed.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler OfflineInitializing
		{
			add
			{
				AddClientHandler("OfflineInitializing", value);
			}
			remove
			{
				RemoveClientHandler("OfflineInitializing", value);
			}
		}

		/// 
		/// Occurs when [client confirming].
		/// </summary>
		[Category("Client")]
		[Description("Occurs when confirming offline mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler OfflineConfirming
		{
			add
			{
				AddClientHandler("OfflineConfirming", value);
			}
			remove
			{
				RemoveClientHandler("OfflineConfirming", value);
			}
		}

		/// 
		/// Occurs when [client closed].
		/// </summary>
		[Category("Client")]
		[Description("Occurs when form closed in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientClosed
		{
			add
			{
				AddClientHandler("OnUnload", value);
			}
			remove
			{
				RemoveClientHandler("OnUnload", value);
			}
		}

		/// 
		/// Occurs when [client activated].
		/// </summary>
		[Category("Client")]
		[Description("Occurs when form activated in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientActivated
		{
			add
			{
				AddClientHandler("Activated", value);
			}
			remove
			{
				RemoveClientHandler("Activated", value);
			}
		}

		/// 
		/// Occurs when [client resize].
		/// </summary>
		[Category("Client")]
		[Description("Occurs when the form resized and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientResize
		{
			add
			{
				AddClientHandler("Resize", value);
			}
			remove
			{
				RemoveClientHandler("Resize", value);
			}
		}

		/// 
		/// Occurs when [client move].
		/// </summary>
		[Category("Client")]
		[Description("Occurs when the form moved and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientMove
		{
			add
			{
				AddClientHandler("Move", value);
			}
			remove
			{
				RemoveClientHandler("Move", value);
			}
		}

		event EventHandler IFormParams.PreRendered
		{
			add
			{
				mobjPreRender += value;
			}
			remove
			{
				mobjPreRender -= value;
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Form" /> instance.
		/// </summary>
		public Form(IContext objContext)
		{
			InitializeForm(objContext);
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Form" /> instance.
		/// </summary>
		public Form()
		{
			try
			{
				InitializeForm(VWGContext.Current);
			}
			catch (Exception)
			{
			}
		}

		/// 
		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
		/// </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				CalledOnLoad = false;
				CalledMakeVisible = false;
				CalledCreateControl = false;
				MainMenu menu = Menu;
				if (menu != null && menu.Form == this)
				{
					menu.Dispose();
					Menu = null;
				}
			}
			else
			{
				base.Dispose(blnDisposing);
			}
		}

		/// 
		/// Validates the geo location capability.
		/// </summary>
		private void ValidateGeoLocationCapability()
		{
			if (!base.DesignMode && Context is IContextParams contextParams && (contextParams.MISCBrowserCapabilities & MISCBrowserCapabilities.Geolocation) != MISCBrowserCapabilities.Geolocation)
			{
				throw new NotSupportedException("Your browser does not support geographic location services.");
			}
		}

		/// 
		/// Initializes the form.
		/// </summary>
		/// <param name="objContext">The current context.</param>
		private void InitializeForm(IContext objContext)
		{
			SetContextInternal(objContext);
			base.VisibleIntenal = false;
			GeographicLocation = new GeoLocationData();
			if (!base.DesignMode)
			{
				GeographicLocation.GeoLocationDataChanged += OnGeoLocationDataChanged;
			}
			SetState(FormState.MaximizeBox | FormState.MinimizeBox | FormState.CloseBox, blnValue: true);
			SetTopLevel(blnValue: true);
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mintFormState = objReader.ReadInt32();
			object[] array = objReader.ReadArray();
			if (array.Length != 0)
			{
				mobjOwnedForms = new FormCollection(this, array);
			}
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteInt32(mintFormState);
			objWriter.WriteArray(mobjOwnedForms);
		}

		/// 
		/// Sets the state.
		/// </summary>
		/// <param name="enmState">State of the enm.</param>
		/// <param name="blnValue">if set to true</c> [BLN value].</param>
		internal void SetState(FormState enmState, bool blnValue)
		{
			mintFormState = (blnValue ? (mintFormState | (int)enmState) : (mintFormState & (int)(~enmState)));
		}

		/// 
		/// Sets the state with check.
		/// </summary>
		/// <param name="enmState">State of the enm.</param>
		/// <param name="blnValue">if set to true</c> [BLN value].</param>
		/// </returns>
		internal bool SetStateWithCheck(FormState enmState, bool blnValue)
		{
			if (GetState(enmState) != blnValue)
			{
				SetState(enmState, blnValue);
				return true;
			}
			return false;
		}

		private void OnGeoLocationDataChanged(object sender, EventArgs e)
		{
			UpdateParams(AttributeType.GeographicLocation);
		}

		/// 
		/// Gets the state.
		/// </summary>
		/// <param name="enmState">State of the enm.</param>
		/// </returns>
		internal bool GetState(FormState enmState)
		{
			return ((uint)mintFormState & (uint)enmState) != 0;
		}

		/// 
		/// Checks if the current control needs rendering and 
		/// continues to process sub tree/
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (base.Parent != null)
			{
				base.RenderControl(objContext, objWriter, lngRequestID);
				return;
			}
			objWriter.WriteStartElement(((IServerResponse)objContext.Response).GeneralNamespacePrefix, base.MetadataTag, ((IServerResponse)objContext.Response).GeneralNamespaceUrl);
			if (IsDirty(lngRequestID))
			{
				RenderAttributes(objContext, (IAttributeWriter)objWriter);
				RenderComponentClientEvents(objContext, objWriter, lngRequestID);
			}
			else
			{
				RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
			}
			Render(objContext, objWriter, lngRequestID);
			objWriter.WriteEndElement();
		}

		/// 
		/// Updates the params internal.
		/// </summary>
		/// <param name="enmAttributeType">Type of the enm attribute.</param>
		internal new void UpdateParamsInternal(AttributeType enmAttributeType)
		{
			UpdateParams(enmAttributeType);
		}

		/// 
		/// Renders the theme.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected override void RenderThemeAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if (VWGContext.Current.SupportsMultipleThemes)
			{
				if (TopLevel && Theme == "Inherit")
				{
					objWriter.WriteAttributeString("TH", VWGContext.Current.CurrentTheme);
				}
				else
				{
					base.RenderThemeAttribute(objContext, objWriter, blnForceRender);
				}
			}
		}

		/// 
		/// Activates a child control. Optionally specifies the direction in the tab order to select the control from.
		/// </summary>
		/// <param name="blnDirected"></param>
		/// <param name="blnForward"></param>
		protected override void Select(bool blnDirected, bool blnForward)
		{
			SelectInternal(blnDirected, blnForward);
		}

		/// 
		/// Selects the internal.
		/// </summary>
		/// <param name="blnDirected">if set to true</c> [BLN directed].</param>
		/// <param name="blnForward">if set to true</c> [BLN forward].</param>
		private void SelectInternal(bool blnDirected, bool blnForward)
		{
			if (blnDirected)
			{
				SelectNextControl(null, blnForward, blnTabStopOnly: true, blnNested: true, blnWrap: false);
			}
			if (TopLevel)
			{
				InvokeMethodWithId("Forms_BringWindowToTop");
				ActivateForm(blnUpdatePosition: true);
			}
			else if (!IsMdiChild)
			{
				Form parentFormInternal = base.ParentFormInternal;
				if (parentFormInternal != null)
				{
					parentFormInternal.ActiveControl = this;
				}
			}
		}

		/// 
		/// Focuses the internal.
		/// </summary>
		/// </returns>
		internal override bool FocusInternal()
		{
			if (TopLevel)
			{
				InvokeMethodWithId("Forms_BringWindowToTop");
				ActivateForm(blnUpdatePosition: true);
			}
			return base.FocusInternal();
		}

		/// 
		/// Renders Form window state.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderFormWindowState(IAttributeWriter objWriter)
		{
			FormWindowState windowState = WindowState;
			int num = (int)windowState;
			objWriter.WriteAttributeString("WS", num.ToString());
			if (windowState == FormWindowState.Minimized)
			{
				objWriter.WriteAttributeString("RWS", ((int)FormRestoredWindowState).ToString());
			}
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			if (base.Parent != null)
			{
				base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
				return;
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderFormRectangle(objWriter, StartPosition, base.Location, base.Size);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Enabled))
			{
				objWriter.WriteAttributeString("En", Enabled ? "1" : "0");
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("TX", Text);
				RenderFormButtons(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Redraw))
			{
				RenderFormWindowState(objWriter);
				objWriter.WriteAttributeString("FBS", ((int)FormBorderStyle).ToString());
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Extended))
			{
				RenderControlBoxAttribute(objWriter, blnForceRender: true);
				RenderFormBoxes(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.GeographicLocation))
			{
				RenderGeoLocationAttributes(objContext, objWriter, blnForcRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.VisualEffect))
			{
				RenderEntranceVisualEffect(objContext, objWriter, blnForceRender: true);
				RenderExitVisualEffect(objContext, objWriter, blnForceRender: true);
			}
			RenderComponentAttributes(Context, objWriter);
		}

		/// 
		/// Renders the form.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		void IForm.RenderForm(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RenderControl(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Pre-render form.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		void IForm.PreRenderForm(IContext objContext, long lngRequestID)
		{
			PreRenderControl(objContext, lngRequestID);
			PreRenderForms(objContext, lngRequestID);
			OnPreRendered(EventArgs.Empty);
		}

		/// 
		/// Raises after PreRenderForm has completed.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnPreRendered(EventArgs e)
		{
			if (this.mobjPreRender != null)
			{
				this.mobjPreRender(this, e);
			}
		}

		/// 
		/// Posts the render form.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		void IForm.PostRenderForm(IContext objContext, long lngRequestID)
		{
			PostRenderControl(objContext, lngRequestID);
			PostRenderForms(objContext, lngRequestID);
		}

		/// 
		/// Pre-render forms.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void PreRenderForms(IContext objContext, long lngRequestID)
		{
			Form[] ownedForms = OwnedForms;
			Form[] array = ownedForms;
			foreach (IForm form in array)
			{
				form.PreRenderForm(objContext, lngRequestID);
			}
		}

		/// 
		/// Posts the render forms.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void PostRenderForms(IContext objContext, long lngRequestID)
		{
			Form[] ownedForms = OwnedForms;
			Form[] array = ownedForms;
			foreach (IForm form in array)
			{
				form.PostRenderForm(objContext, lngRequestID);
			}
		}

		/// 
		/// Renders the form rectangle.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="enmFormStartPosition">The form start position.</param>
		/// <param name="objLocation">The location of the form.</param>
		/// <param name="objSize">Size of the form.</param>
		private void RenderFormRectangle(IAttributeWriter objWriter, FormStartPosition enmFormStartPosition, Point objLocation, Size objSize)
		{
			bool flag = true;
			objWriter.WriteAttributeString("H", objSize.Height.ToString());
			objWriter.WriteAttributeString("W", objSize.Width.ToString());
			if (DialogType != DialogTypes.PopupWindow)
			{
				Size formRestoredSize = FormRestoredSize;
				if (formRestoredSize != Size.Empty)
				{
					objWriter.WriteAttributeString("RH", formRestoredSize.Height.ToString());
					objWriter.WriteAttributeString("RW", formRestoredSize.Width.ToString());
				}
			}
			if (enmFormStartPosition == FormStartPosition.Manual || Moved)
			{
				objWriter.WriteAttributeString("L", objLocation.X.ToString());
				objWriter.WriteAttributeString("T", objLocation.Y.ToString());
			}
			Point formRestoredLocation = FormRestoredLocation;
			if (formRestoredLocation != Point.Empty)
			{
				objWriter.WriteAttributeString("RL", formRestoredLocation.X.ToString());
				objWriter.WriteAttributeString("RT", formRestoredLocation.Y.ToString());
			}
		}

		/// 
		/// Renders the forms attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			if (base.Parent == null)
			{
				RenderMinMaxSizeAttributes(objContext, objWriter);
				bool flag = false;
				if (IsRootForm && Context.Arguments is IMashupArguments mashupArguments)
				{
					objWriter.WriteAttributeString("MP", ((int)mashupArguments.Type).ToString());
					objWriter.WriteAttributeString("H", "400");
					objWriter.WriteAttributeString("W", "400");
					objWriter.WriteAttributeString("L", "100");
					objWriter.WriteAttributeString("T", "10");
					flag = true;
				}
				FormStartPosition startPosition = StartPosition;
				if (!flag)
				{
					RenderFormRectangle(objWriter, startPosition, new Point(base.LayoutLeft, base.LayoutTop), base.Size);
				}
				objWriter.WriteAttributeString("RD", "1");
				objWriter.WriteAttributeString("TP", DialogType.ToString());
				if ((startPosition == FormStartPosition.CenterParent || startPosition == FormStartPosition.CenterScreen) && !Moved)
				{
					int num = (int)startPosition;
					objWriter.WriteAttributeString("FSP", num.ToString());
				}
				RenderFormWindowState(objWriter);
				objWriter.WriteAttributeString("S", (FormStyle == FormStyle.Dialog) ? "0" : "1");
				string beforeUnloadMessage = BeforeUnloadMessage;
				if (beforeUnloadMessage != string.Empty)
				{
					objWriter.WriteAttributeString("BUM", beforeUnloadMessage);
				}
				if (IsWindowSized)
				{
					objWriter.WriteAttributeString("IWS", "1");
				}
				RenderFormButtons(objWriter, blnForceRender: false);
				if (!ModalMask)
				{
					objWriter.WriteAttributeString("SMM", "0");
				}
				DialogAlignment dialogAlignment = DialogAlignment;
				GetRenderAlignmentComponentIds(out var strComponentId, out var strMemberId);
				if (strComponentId != "0" && !string.IsNullOrEmpty(strComponentId) && dialogAlignment != DialogAlignment.None)
				{
					if (strMemberId != "0" && !string.IsNullOrEmpty(strMemberId))
					{
						objWriter.WriteAttributeString("AT", strComponentId + "_" + strMemberId);
					}
					else
					{
						objWriter.WriteAttributeString("AT", strComponentId);
					}
					objWriter.WriteAttributeString("ATP", dialogAlignment.ToString()[0].ToString());
				}
				Form mdiParent = MdiParent;
				if (mdiParent != null)
				{
					IControl control = mdiParent;
					if (control != null)
					{
						objWriter.WriteAttributeString("MDP", control.ID.ToString());
					}
				}
				if (IsMdiContainer)
				{
					objWriter.WriteAttributeString("IMC", "1");
				}
			}
			objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			ResourceHandle proxyPropertyValue = GetProxyPropertyValue("Icon", Icon);
			if (proxyPropertyValue != null)
			{
				objWriter.WriteAttributeString("I", proxyPropertyValue.ToString());
			}
			objWriter.WriteAttributeString("FBS", ((int)FormBorderStyle).ToString());
			RenderFormBoxes(objWriter, blnForceRender: false);
			RenderGeoLocationAttributes(objContext, objWriter, blnForcRender: false);
			RenderControlBoxAttribute(objWriter, blnForceRender: false);
			RenderEntranceVisualEffect(objContext, objWriter, blnForceRender: false);
			RenderExitVisualEffect(objContext, objWriter, blnForceRender: false);
			base.RenderAttributes(objContext, objWriter);
		}

		/// 
		/// Returns aligment component ids for rendering.
		/// </summary>
		private void GetRenderAlignmentComponentIds(out string strComponentId, out string strMemberId)
		{
			strComponentId = "";
			strMemberId = "";
			if (mobjAligmentComponent == null)
			{
				return;
			}
			Component component = mobjAligmentComponent as Component;
			IRegisteredComponentMember registeredComponentMember = mobjAligmentComponent as IRegisteredComponentMember;
			if (component == null && registeredComponentMember == null)
			{
				return;
			}
			if (registeredComponentMember == null)
			{
				IIdentifiedComponent identifiedComponent = mobjAlignmentMemberComponent;
				if (identifiedComponent != null)
				{
					strMemberId = identifiedComponent.ID;
				}
			}
			else
			{
				component = (VWGContext.Current as ISessionRegistry).GetRegisteredComponent(registeredComponentMember.OwnerID) as Component;
				strMemberId = registeredComponentMember.MemberID.ToString();
			}
			ProxyComponent proxyComponent = null;
			if (component.Form != null)
			{
				proxyComponent = component.Form.ProxyComponent;
			}
			if (proxyComponent == null)
			{
				strComponentId = component.ID.ToString();
				return;
			}
			ProxyComponent visibleProxyComponentOfSource = GetVisibleProxyComponentOfSource(proxyComponent, component.ID);
			if (visibleProxyComponentOfSource != null)
			{
				strComponentId = visibleProxyComponentOfSource.ID.ToString();
			}
		}

		/// 
		/// Returns visible proxy component by source component.
		/// </summary>
		private ProxyComponent GetVisibleProxyComponentOfSource(ProxyComponent objProxyComponent, long objSourceComponentId)
		{
			Component sourceComponent = objProxyComponent.SourceComponent;
			if (sourceComponent != null && sourceComponent.ID == objSourceComponentId && objProxyComponent.Visible)
			{
				return objProxyComponent;
			}
			foreach (ProxyComponent component in objProxyComponent.Components)
			{
				ProxyComponent visibleProxyComponentOfSource = GetVisibleProxyComponentOfSource(component, objSourceComponentId);
				if (visibleProxyComponentOfSource != null)
				{
					return visibleProxyComponentOfSource;
				}
			}
			return null;
		}

		/// 
		/// Renders the enabled attribute.
		/// </summary>
		/// <param name="objWriter">The object writer.</param>
		protected override void RenderEnabledAttribute(IAttributeWriter objWriter)
		{
			if (Context.Config.FormsSecurityEnabled)
			{
				IContextParams contextParams = Context as IContextParams;
				if (contextParams.GetFormAccessMode(this) == FormAccessMode.ReadOnly)
				{
					objWriter.WriteAttributeString("En", "0");
				}
				else
				{
					base.RenderEnabledAttribute(objWriter);
				}
			}
			else
			{
				base.RenderEnabledAttribute(objWriter);
			}
		}

		/// 
		/// Renders the entrance visual effect.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderEntranceVisualEffect(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			RenderFullScreenNavigationEffect(EntranceEffect, "BEE", "AEE", objContext, objWriter, blnForceRender);
		}

		/// 
		/// Renders the exit visual effect.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderExitVisualEffect(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			RenderFullScreenNavigationEffect(ExitEffect, "BXE", "AXE", objContext, objWriter, blnForceRender);
		}

		/// 
		/// Renders the full screen navigation effect.
		/// </summary>
		/// <param name="objEffectToRender">The effect to render.</param>
		/// <param name="strBeforeEffectAttributeName">Name of the before-effect attribute.</param>
		/// <param name="strAfterEffectAttributeName">Name of the after-effect attribute.</param>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [forced to render].</param>
		private void RenderFullScreenNavigationEffect(VisualEffect objEffectToRender, string strBeforeEffectAttributeName, string strAfterEffectAttributeName, IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if ((objEffectToRender != null || blnForceRender) && Context.FullScreenMode && (TopLevel || IsMdiChild) && DialogType != DialogTypes.PopupWindow)
			{
				string text = ((objEffectToRender is TranslateVisualEffect) ? objEffectToRender.GetBeforeToString(objContext, blnIsInRenderMode: true) : objEffectToRender.ToString(objContext));
				if (!string.IsNullOrEmpty(text))
				{
					objWriter.WriteAttributeText(strBeforeEffectAttributeName, text);
				}
				string afterToString = objEffectToRender.GetAfterToString(objContext, blnIsInRenderMode: true);
				if (!string.IsNullOrEmpty(afterToString))
				{
					objWriter.WriteAttributeText(strAfterEffectAttributeName, afterToString);
				}
			}
		}

		/// 
		/// Renders the control box attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderControlBoxAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool controlBox = ControlBox;
			if (!controlBox || blnForceRender)
			{
				objWriter.WriteAttributeString("CBX", controlBox ? "1" : "0");
			}
		}

		/// 
		/// Renders the form buttons.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderFormButtons(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool flag = AcceptButton != null;
			if (flag || blnForceRender)
			{
				objWriter.WriteAttributeString("FAB", flag ? "1" : "0");
				objWriter.WriteAttributeString("ACI", (AcceptButton is Control) ? (AcceptButton as Control).ID.ToString() : "0");
			}
			bool flag2 = CancelButton != null;
			if (flag2 || blnForceRender)
			{
				objWriter.WriteAttributeString("FCB", flag2 ? "1" : "0");
			}
		}

		/// 
		/// Renders the form boxes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderFormBoxes(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (ControlBox)
			{
				bool maximizeBox = MaximizeBox;
				if (maximizeBox || blnForceRender)
				{
					objWriter.WriteAttributeString("MXE", maximizeBox ? "1" : "0");
				}
				bool minimizeBox = MinimizeBox;
				if (minimizeBox || blnForceRender)
				{
					objWriter.WriteAttributeString("MNE", minimizeBox ? "1" : "0");
				}
				bool closeBox = CloseBox;
				if (!closeBox || blnForceRender)
				{
					objWriter.WriteAttributeString("CE", closeBox ? "1" : "0");
				}
			}
		}

		/// 
		/// Render the form content
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (Context.Config.FormsSecurityEnabled)
			{
				IContextParams contextParams = Context as IContextParams;
				if (contextParams.GetFormAccessMode(this) == FormAccessMode.Denied)
				{
					RenderUnauthorizedAccessHtmlBox(objContext, objWriter, lngRequestID);
				}
				else
				{
					RenderContent(objContext, objWriter, lngRequestID);
				}
			}
			else
			{
				RenderContent(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the unauthorized access HTML box.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		/// <param name="lngRequestID">The LNG request unique identifier.</param>
		private void RenderUnauthorizedAccessHtmlBox(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			UnauthorizedAccessHtmlBox.RenderControl(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the content.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request unique identifier.</param>
		private void RenderContent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (base.Parent != null)
			{
				base.Render(objContext, objWriter, lngRequestID);
				return;
			}
			if (IsDirty(lngRequestID))
			{
				RenderControls(objContext, objWriter, 0L);
				RenderClientStoratge(objContext, objWriter, lngRequestID);
			}
			else
			{
				RenderControls(objContext, objWriter, lngRequestID);
			}
			RenderForms(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the client storatge.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void RenderClientStoratge(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			ClientStorage?.Render(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the geo-location data.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForcRender">if set to true</c> [BLN forc render].</param>
		private void RenderGeoLocationAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForcRender)
		{
			bool flag = false;
			bool flag2 = false;
			double? num = null;
			double? num2 = null;
			GeoLocationData geographicLocation = GeographicLocation;
			if (geographicLocation != null)
			{
				flag = geographicLocation.RepeatCheck;
				flag2 = geographicLocation.EnableHighAccuracy;
				num = geographicLocation.MaximumAge;
				num2 = geographicLocation.Timeout;
			}
			if (blnForcRender || flag)
			{
				objWriter.WriteAttributeString("RCK", flag ? "1" : "0");
			}
			if (blnForcRender || flag2)
			{
				objWriter.WriteAttributeString("EHA", flag2 ? "1" : "0");
			}
			if (blnForcRender || num.HasValue)
			{
				objWriter.WriteAttributeString("MAG", num.ToString());
			}
			if (blnForcRender || num2.HasValue)
			{
				objWriter.WriteAttributeString("TOT", num2.ToString());
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
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent == null)
			{
				GetValue(ShortcutsProperty)?.RenderControl(objContext, objWriter, lngRequestID);
				if (base.Parent == null)
				{
					Control header = Header;
					if (header != null)
					{
						RenderHeader(header, objContext, objWriter, lngRequestID);
					}
				}
				((IRenderableComponent)Menu)?.RenderComponent(objContext, objWriter, lngRequestID);
			}
			MdiClient mdiClient = null;
			bool flag = false;
			foreach (Control control in base.Controls)
			{
				if (control is MdiClient)
				{
					mdiClient = control as MdiClient;
				}
				else
				{
					flag = control.Dock == DockStyle.Fill;
				}
				if (mdiClient != null && flag)
				{
					break;
				}
			}
			if (proxyComponent == null && mdiClient != null && flag)
			{
				mdiClient.RenderControl(objContext, objWriter, lngRequestID);
			}
			base.RenderControls(objContext, objWriter, lngRequestID);
			if (proxyComponent == null && mdiClient != null && !flag)
			{
				mdiClient.RenderControl(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the form header control
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		private void RenderHeader(Control objHeader, IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			DockStyle dock = objHeader.Dock;
			AnchorStyles anchor = objHeader.Anchor;
			objHeader.Dock = DockStyle.Top;
			((IRenderableComponent)objHeader).RenderComponent(objContext, objWriter, lngRequestID);
			objHeader.Dock = dock;
			objHeader.Anchor = anchor;
		}

		/// 
		/// Renders the child forms.
		/// </summary>
		/// <param name="objContext">context.</param>
		/// <param name="objWriter">writer.</param>
		/// <param name="lngRequestID">last updated marker.</param>
		internal void RenderForms(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			Form[] ownedForms = OwnedForms;
			Form[] array = ownedForms;
			foreach (Form form in array)
			{
				if (form.TopLevel || form.MdiParent != null)
				{
					form.RenderControl(objContext, objWriter, lngRequestID);
				}
			}
		}

		/// 
		/// Creates a new instance of the control collection for the control.
		/// </summary>
		/// 
		/// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection" /> assigned to the control.
		/// </returns>
		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}

		/// 
		/// Invokes the method.
		/// </summary>
		/// <param name="objTarget">The obj target.</param>
		/// <param name="strMember">The STR member.</param>
		/// <param name="arrArgs">The arr args.</param>
		internal void InvokeMethod(Component objTarget, string strMember, object[] arrArgs)
		{
			if (Context is IContextMethodInvoker contextMethodInvoker)
			{
				contextMethodInvoker.InvokeMethod(objTarget as ISkinable, InvokationUniqueness.None, strMember, arrArgs);
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
			if (type != null && CommonUtils.IsTypeOrSubType(type, typeof(MainMenu)))
			{
				List<object> list = new List<object>();
				list.Add(Menu);
				return list;
			}
			return base.GetComponentOffsprings(strOffspringTypeName);
		}

		/// 
		/// Closes this window.
		/// </summary>
		public void Close()
		{
			Close(blnClientSource: false, blnSuspendCloseEvent: false, blnFormOwnerClosing: false);
		}

		/// 
		/// Closes this window.
		/// </summary>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// <param name="blnSuspendCloseEvent">if set to true</c> - came from visible
		/// the closed event shouldn't be raised.</param>
		/// <param name="blnFormOwnerClosing">if set to true</c> [BLN form owner closing].</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool Close(bool blnClientSource, bool blnSuspendCloseEvent, bool blnFormOwnerClosing)
		{
			if (!GetState(FormState.IsClosed))
			{
				bool flag = true;
				CloseReason closeReason = (blnFormOwnerClosing ? CloseReason.FormOwnerClosing : ((!IsMdiChild) ? CloseReason.UserClosing : CloseReason.MdiFormClosing));
				if (!blnSuspendCloseEvent && (ClosingHandler != null || FormClosingHandler != null))
				{
					FormClosingEventArgs e = new FormClosingEventArgs(closeReason, blnCancel: false);
					CancelEventArgs e2 = new CancelEventArgs(cancel: false);
					OnClosing(e2);
					OnFormClosing(e);
					if (e.Cancel || e2.Cancel)
					{
						if (DialogType == DialogTypes.PopupWindow)
						{
							throw new Exception("Closing popup windows cannot be cancelled");
						}
						return false;
					}
				}
				Form[] ownedForms = OwnedForms;
				if (ownedForms.Length != 0)
				{
					Form[] array = ownedForms;
					foreach (Form form in array)
					{
						flag &= form.Close(blnClientSource, blnSuspendCloseEvent, blnFormOwnerClosing: true);
					}
				}
				if (!flag && blnClientSource)
				{
					Update();
					return false;
				}
				if (closeReason == CloseReason.UserClosing && Modal && DialogResult == DialogResult.None)
				{
					DialogResult = DialogResult.Cancel;
				}
				ResetCreatedFlag();
				base.Parent?.Controls.Remove(this);
				((IFormResolver)Context).UnRegisterForm(this);
				Form owner = Owner;
				if (owner != null)
				{
					if (Context.ActiveForm == this)
					{
						if (DialogType == DialogTypes.PopupWindow)
						{
							Context.ActiveForm = owner;
						}
						else
						{
							Form topMostOwnedForm = owner.GetTopMostOwnedForm(this);
							if (topMostOwnedForm != null)
							{
								Context.ActiveForm = topMostOwnedForm;
							}
						}
						Active = false;
						if (Context.ActiveForm != this)
						{
							Context.ActiveForm.Active = true;
						}
					}
					owner.RemoveForm(this, blnSuspendCloseEvent);
				}
				else
				{
					FireClosed();
					FormClosedEventArgs objFormClosedEventArgs = new FormClosedEventArgs(CloseReason.UserClosing);
					FireFormClosed(objFormClosedEventArgs);
				}
				if (GetState(FormState.IsModalActive))
				{
					Context.GetThreadingService()?.ReleaseDialog(this);
					SetState(FormState.IsModalActive, blnValue: false);
				}
				SetState(FormState.IsClosed, blnValue: true);
			}
			if (Context is IContextParams { EmulatorForm: { } emulatorForm })
			{
				emulatorForm.OnFormClosed(this);
			}
			return true;
		}

		/// 
		/// Gets the top most owned form.
		/// </summary>
		/// <param name="objExcludedOwnedForm">The excluded form.</param>
		/// </returns>
		private Form GetTopMostOwnedForm(Form objExcludedOwnedForm)
		{
			Form result = ((this != objExcludedOwnedForm) ? this : null);
			Form[] ownedForms = OwnedForms;
			if (ownedForms != null && ownedForms.Length != 0)
			{
				for (int num = ownedForms.Length - 1; num >= 0; num--)
				{
					Form form = ownedForms[num];
					if (form != null && form != objExcludedOwnedForm && form.TopLevel)
					{
						Form topMostOwnedForm = form.GetTopMostOwnedForm(objExcludedOwnedForm);
						if (topMostOwnedForm != null)
						{
							result = topMostOwnedForm;
							break;
						}
					}
				}
			}
			return result;
		}

		/// 
		/// Shows the dialog.
		/// </summary>
		/// <param name="objForm">The obj form.</param>
		/// </returns>
		public DialogResult ShowDialog(Form objForm)
		{
			return ShowDialog(objForm, null);
		}

		/// 
		/// Shows the dialog.
		/// </summary>
		/// <param name="objForm">The obj form.</param>
		/// <param name="objClosedDelegate">The obj closed delegate.</param>
		/// </returns>
		public DialogResult ShowDialog(Form objForm, EventHandler objClosedDelegate)
		{
			return ShowDialog(objForm, DialogTypes.ModalWindow, objClosedDelegate);
		}

		/// 
		/// Shows the specified obj closed delegate.
		/// </summary>
		/// <param name="objClosedDelegate">The obj closed delegate.</param>
		public void Show(EventHandler objClosedDelegate)
		{
			if (Context.Config.IsFeatureEnabled("ModalWindows", false))
			{
				ShowDialog(DialogTypes.ModalWindow, objClosedDelegate);
			}
			else
			{
				ShowDialog(DialogTypes.ModalessWindow, objClosedDelegate);
			}
		}

		/// 
		/// Shows the specified obj owner.
		/// </summary>
		/// <param name="objOwner">The obj owner.</param>
		/// <param name="objClosedDelegate">The obj closed delegate.</param>
		public void Show(IWin32Window objOwner, EventHandler objClosedDelegate)
		{
			if (objOwner is Form objForm)
			{
				ShowDialog(objForm, objClosedDelegate);
			}
			else if (objOwner is Control { Form: var form })
			{
				if (form != null)
				{
					ShowDialog(form, objClosedDelegate);
				}
				else
				{
					Show(objClosedDelegate);
				}
			}
		}

		/// 
		/// Displays the control to the user.
		/// </summary>
		public override void Show()
		{
			Show((EventHandler)null);
		}

		/// 
		/// Shows the specified owner.
		/// </summary>
		/// <param name="objOwner">The owner.</param>
		public void Show(IWin32Window objOwner)
		{
			Show(objOwner, null);
		}

		/// 
		/// Shows the dialog.
		/// </summary>
		/// <param name="objOwnerForm">The obj owner form.</param>
		/// <param name="enmDialogType">Type of the enm dialog.</param>
		/// <param name="objClosedDelegate">The obj closed delegate.</param>
		/// </returns>
		private DialogResult ShowDialog(Form objOwnerForm, DialogTypes enmDialogType, EventHandler objClosedDelegate)
		{
			if (objClosedDelegate != null)
			{
				ClosedDelegate = objClosedDelegate;
			}
			if (enmDialogType == DialogTypes.PopupWindow && objOwnerForm != null)
			{
				ArrayList arrayList = new ArrayList(objOwnerForm.OwnedFormsCollection);
				for (int num = arrayList.Count - 1; num >= 0; num--)
				{
					if (arrayList[num] is Form { DialogType: DialogTypes.PopupWindow } form)
					{
						form.Close();
					}
				}
			}
			DialogResult = DialogResult.None;
			bool state = GetState(FormState.IsClosed);
			if (objOwnerForm != this)
			{
				if (CommonSwitches.TraceVerbose)
				{
					VerboseRecord.Write(this, "Server/Actions", "ShowDialog", "Shows the currnet dialog in a " + enmDialogType.ToString() + " style.");
				}
				DialogType = enmDialogType;
				if ((TopLevel || IsMdiChild) && !objOwnerForm.OwnedFormsCollection.Contains(this))
				{
					objOwnerForm.OwnedFormsCollection.Add(this);
				}
				if (enmDialogType != DialogTypes.ModalWindow)
				{
					Form mdiParent = objOwnerForm.MdiParent;
					if (mdiParent != null)
					{
						MdiParent = mdiParent;
					}
				}
				Update();
				RegisterSelf();
				CalledOnLoad = false;
				CalledMakeVisible = false;
				InternalVisible = true;
				if (state || !GetState(FormState.IsClosed))
				{
					CreateControl();
					if (base.Parent == null)
					{
						ActivateOnShow = true;
					}
				}
			}
			((IFormResolver)Context).RegisterForm(this);
			if (state || !GetState(FormState.IsClosed))
			{
				if (enmDialogType == DialogTypes.ModalWindow)
				{
					SetState(FormState.IsModalActive, blnValue: true);
					IContextThreadingService threadingService = Context.GetThreadingService();
					if (threadingService != null)
					{
						RequestProcessingState requestProcessingState = Context.RequestProcessingState;
						switch (requestProcessingState)
						{
						case RequestProcessingState.PreRenderResponse:
						case RequestProcessingState.RenderResponse:
						case RequestProcessingState.PostRrenderResponse:
							((IFormResolver)Context).UnRegisterForm(this);
							throw new Exception($"Cannot perform modal dialog emulation through {requestProcessingState.ToString()} state.");
						}
						threadingService.GetDialogResult(this);
					}
				}
				SetState(FormState.IsClosed, blnValue: false);
			}
			if (Context is IContextParams { EmulatorForm: { } emulatorForm })
			{
				emulatorForm.OnFormShowed(this);
			}
			return DialogResult;
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			if (ActivateOnShow)
			{
				ActivateOnShow = false;
				ActivateForm(blnUpdatePosition: false);
			}
			base.PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Activates the form.
		/// </summary>
		/// <param name="blnUpdatePosition">if set to true</c> [BLN update position].</param>
		internal void ActivateForm(bool blnUpdatePosition)
		{
			if (blnUpdatePosition && Owner != null && Owner.OwnedFormsCollection.IndexOf(this) < Owner.OwnedFormsCollection.Count - 1)
			{
				Owner.OwnedFormsCollection.SetFormPosition(this, Owner.OwnedFormsCollection.Count - 1);
			}
			IForm activeForm = Context.ActiveForm;
			if (activeForm != this)
			{
				if (activeForm != null)
				{
					activeForm.Active = false;
				}
				Context.ActiveForm = this;
			}
			if (!Active)
			{
				Active = true;
			}
		}

		/// 
		/// Occurs when control is created
		/// </summary>
		protected override void OnCreateControl()
		{
			CalledCreateControl = true;
			base.OnCreateControl();
			RegisterSelf();
			if (CommonSwitches.TraceVerbose)
			{
				VerboseRecord.Write(this, "Server/Events", "Load", "Invoking event handler.");
			}
			long ticks = DateTime.Now.Ticks;
			if (CalledMakeVisible && !CalledOnLoad)
			{
				CalledOnLoad = true;
				OnLoad(EventArgs.Empty);
			}
			if (CommonSwitches.TraceEnabled && CommonSwitches.TraceInfo)
			{
				TraceRecord.Write(new EventTraceRecord("Load", this, ticks));
			}
		}

		/// 
		/// </summary>
		/// </returns>
		internal override bool CanSelectCore()
		{
			return GetStyle(ControlStyles.Selectable) && base.Enabled && base.Visible;
		}

		/// 
		/// Shows the dialog.
		/// </summary>
		/// <param name="objClosedDelegate">The obj closed delegate.</param>
		/// </returns>
		public virtual DialogResult ShowDialog(EventHandler objClosedDelegate)
		{
			return ShowDialog(DialogTypes.ModalWindow, objClosedDelegate);
		}

		/// 
		/// Shows the dialog.
		/// </summary>
		/// </returns>
		public virtual DialogResult ShowDialog()
		{
			return ShowDialog(DialogTypes.ModalWindow, null);
		}

		/// 
		/// Shows the dialog.
		/// </summary>
		/// <param name="enmDialogTypes">The enm dialog types.</param>
		/// <param name="objClosedDelegate">The obj closed delegate.</param>
		/// </returns>
		private DialogResult ShowDialog(DialogTypes enmDialogTypes, EventHandler objClosedDelegate)
		{
			DialogResult result = DialogResult.None;
			if (enmDialogTypes == DialogTypes.ModalWindow && !TopLevel)
			{
				throw new InvalidOperationException(SR.GetString("ShowDialogOnNonTopLevel", "Show"));
			}
			Form form = null;
			Form mdiParent = MdiParent;
			if (mdiParent != null)
			{
				if (enmDialogTypes == DialogTypes.ModalessWindow)
				{
					form = mdiParent;
				}
			}
			else if (enmDialogTypes != DialogTypes.ModalessWindow)
			{
				form = GetOwnerForm(enmDialogTypes);
			}
			if (form != null)
			{
				result = ShowDialog(form, enmDialogTypes, objClosedDelegate);
			}
			else
			{
				if (base.Created && Owner != null && Context != null && Context is IContextMethodInvoker)
				{
					((IContextMethodInvoker)Context).InvokeMethod(this, InvokationUniqueness.Component, "Forms_BringWindowToTop", ID);
					Owner.OwnedFormsCollection.SetFormPosition(this, Owner.OwnedFormsCollection.Count - 1);
				}
				if (Context.MainForm is Form objOwnerForm)
				{
					result = ShowDialog(objOwnerForm, enmDialogTypes, objClosedDelegate);
				}
				else
				{
					Context.MainForm = this;
					Context.ActiveForm = this;
					CreateControl();
					ActivatedHandler?.Invoke(this, new EventArgs());
				}
			}
			return result;
		}

		/// 
		/// Shows a the form as a dialog.
		/// </summary>
		private DialogResult ShowDialog(DialogTypes enmDialogTypes)
		{
			return ShowDialog(enmDialogTypes, null);
		}

		/// 
		/// Gets an owner form for a newly created form.
		/// </summary>
		/// <param name="enmNewDialogTypes">The enm new dialog types.</param>
		/// </returns>
		private Form GetOwnerForm(DialogTypes enmNewDialogTypes)
		{
			Form form = Context.ActiveForm as Form;
			if (form != null)
			{
				if (enmNewDialogTypes != DialogTypes.PopupWindow && form.DialogType == DialogTypes.PopupWindow)
				{
					Form form2 = form;
					while (form2 != null && form2.Owner != null && form2.Owner.DialogType == DialogTypes.PopupWindow)
					{
						form2 = form2.Owner;
					}
					if (form2 != null)
					{
						if (form2.Owner != null)
						{
							form = (Form)(Context.ActiveForm = form2.Owner);
						}
						form2.Close();
					}
				}
				else
				{
					Form topMostOwnedModalForm = form.TopMostOwnedModalForm;
					if (topMostOwnedModalForm != null)
					{
						form = topMostOwnedModalForm;
					}
				}
			}
			return form;
		}

		/// 
		/// Displays the form as a popup window.
		/// </summary>
		public DialogResult ShowPopup()
		{
			DialogAlignment = DialogAlignment.None;
			mobjAligmentComponent = null;
			mobjAlignmentMemberComponent = null;
			return ShowDialog(DialogTypes.PopupWindow);
		}

		/// 
		/// Displays the form as a popup window.
		/// </summary>
		public DialogResult ShowPopup(Form objForm)
		{
			DialogAlignment = DialogAlignment.None;
			mobjAligmentComponent = null;
			mobjAlignmentMemberComponent = null;
			return ShowDialog(objForm, DialogTypes.PopupWindow, null);
		}

		/// 
		/// Displays the form as a popup window.
		/// </summary>
		public DialogResult ShowPopup(Component objComponent)
		{
			return ShowPopup(objComponent, DialogAlignment.Below);
		}

		/// 
		///
		/// </summary>
		/// <param name="objComponent"></param>
		/// <param name="enmAlignment"></param>
		/// </returns>
		public DialogResult ShowPopup(Component objComponent, DialogAlignment enmAlignment)
		{
			return ShowPopup(objComponent, null, enmAlignment);
		}

		/// 
		/// Used by combobox
		/// </summary>
		/// <param name="objForm"></param>
		/// <param name="objComponent">IRegisteredComponent</param>
		/// <param name="enmAlignment">DialogAlignment</param>
		/// </returns>
		public DialogResult ShowPopup(Form objForm, IRegisteredComponent objComponent, DialogAlignment enmAlignment)
		{
			DialogAlignment = enmAlignment;
			mobjAligmentComponent = objComponent;
			mobjAlignmentMemberComponent = null;
			return ShowDialog(GetValidOwnerForm(objForm), DialogTypes.PopupWindow, null);
		}

		/// 
		///
		/// </summary>
		/// <param name="objForm"></param>
		/// <param name="objComponent">IRegisteredComponentMember</param>
		/// <param name="enmAlignment">DialogAlignment</param>
		/// </returns>
		public DialogResult ShowPopup(Form objForm, IRegisteredComponentMember objComponent, DialogAlignment enmAlignment)
		{
			DialogAlignment = enmAlignment;
			mobjAligmentComponent = objComponent;
			mobjAlignmentMemberComponent = null;
			return ShowDialog(objForm, DialogTypes.PopupWindow, null);
		}

		/// 
		/// Displays the form as a popup window.
		/// </summary>
		public DialogResult ShowPopup(Component objSourceComponent, IIdentifiedComponent objMemberComponent, DialogAlignment enmAlignment)
		{
			DialogAlignment = enmAlignment;
			mobjAligmentComponent = objSourceComponent;
			mobjAlignmentMemberComponent = objMemberComponent;
			return ShowDialog(GetValidOwnerForm(objSourceComponent.Form), DialogTypes.PopupWindow, null);
		}

		/// 
		/// Gets the valid owner form.
		/// </summary>
		/// <param name="objOwnerForm">The owner form.</param>
		/// </returns>
		internal static Form GetValidOwnerForm(Form objOwnerForm)
		{
			while (objOwnerForm != null && !objOwnerForm.TopLevel && !objOwnerForm.IsMdiChild)
			{
				objOwnerForm = objOwnerForm.InternalParent?.Form;
			}
			return objOwnerForm;
		}

		/// Removes an owned form from this form.</summary>
		/// <param name="objOwnedForm">A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> representing the form to remove from the list of owned forms for this form. </param>
		/// 1</filterpriority>
		public void RemoveOwnedForm(Form objOwnedForm)
		{
			if (objOwnedForm == null)
			{
				return;
			}
			if (objOwnedForm.OwnerInternal != null)
			{
				objOwnedForm.Owner = null;
				return;
			}
			Form[] ownedForms = OwnedForms;
			int num = OwnedFormsCollection.Count;
			if (ownedForms == null)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				if (objOwnedForm.Equals(ownedForms[i]))
				{
					ownedForms[i] = null;
					if (i + 1 < num)
					{
						Array.Copy(ownedForms, i + 1, ownedForms, i, num - i - 1);
						ownedForms[num - 1] = null;
					}
					num--;
				}
			}
		}

		/// Adds an owned form to this form.</summary>
		/// <param name="objOwnedForm">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that this form will own. </param>
		/// 1</filterpriority>
		public void AddOwnedForm(Form objOwnedForm)
		{
			if (objOwnedForm == null)
			{
				return;
			}
			if (objOwnedForm.OwnerInternal != this)
			{
				objOwnedForm.Owner = this;
				return;
			}
			FormCollection ownedFormsCollection = OwnedFormsCollection;
			if (ownedFormsCollection != null && !ownedFormsCollection.Contains(objOwnedForm))
			{
				ownedFormsCollection.Add(objOwnedForm);
			}
		}

		/// 
		/// Sets the visible core.
		/// </summary>
		/// <param name="blnValue">if set to true</c> [BLN value].</param>
		protected override void SetVisibleCore(bool blnValue)
		{
			bool visibleCore = GetVisibleCore();
			DialogResult dialogResult = DialogResult;
			if (visibleCore == blnValue && dialogResult == DialogResult.OK)
			{
				return;
			}
			if (visibleCore == blnValue && (!blnValue || CalledMakeVisible))
			{
				base.SetVisibleCore(blnValue);
				return;
			}
			if (blnValue)
			{
				CalledMakeVisible = true;
				if (CalledCreateControl && !CalledOnLoad)
				{
					CalledOnLoad = true;
					OnLoad(EventArgs.Empty);
					if (dialogResult != DialogResult.None)
					{
						blnValue = false;
					}
				}
			}
			base.SetVisibleCore(blnValue);
			if (blnValue && !IsMdiChild && (WindowState == FormWindowState.Maximized || TopMost) && base.ActiveControl == null)
			{
				SelectNextControlInternal(null, blnForward: true, blnTabStopOnly: true, blnNested: true, blnWrap: false);
				FocusActiveControlInternal();
			}
		}

		/// 
		/// Removes a form.
		/// </summary>
		/// <param name="objForm">Form.</param>
		/// <param name="blnSuspendCloseEvent">if set to true</c> [BLN suspend close event].</param>
		internal void RemoveForm(Form objForm, bool blnSuspendCloseEvent)
		{
			objForm.UnRegisterSelf();
			objForm.InternalVisible = false;
			OwnedFormsCollection.Remove(objForm);
			if (!blnSuspendCloseEvent)
			{
				objForm.FireClosed();
				FormClosedEventArgs e = null;
				e = ((!objForm.IsMdiChild) ? new FormClosedEventArgs(CloseReason.FormOwnerClosing) : new FormClosedEventArgs(CloseReason.MdiFormClosing));
				objForm.FireFormClosed(e);
			}
			objForm.FireClosedDelegate();
			if (objForm.OwnerInternal == this)
			{
				objForm.OwnerInternal = null;
			}
		}

		/// 
		/// Fires the closed delegate.
		/// </summary>
		private void FireClosedDelegate()
		{
			EventHandler closedDelegate = ClosedDelegate;
			if (closedDelegate != null)
			{
				ClosedDelegate = null;
				closedDelegate(this, EventArgs.Empty);
			}
		}

		/// 
		/// Fires the closed event.
		/// </summary>
		internal void FireClosed()
		{
			OnClosed(EventArgs.Empty);
		}

		/// 
		/// Fires the form closed.
		/// </summary>
		/// <param name="objFormClosedEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.FormClosedEventArgs" /> instance containing the event data.</param>
		internal void FireFormClosed(FormClosedEventArgs objFormClosedEventArgs)
		{
			OnFormClosed(objFormClosedEventArgs);
		}

		/// 
		/// Causes all of the child controls within a control that support validation to validate their data.
		/// </summary>
		/// <param name="validationConstraints">Tells <see cref="M:Gizmox.WebGui.Forms.ContainerControl.ValidateChildren(Gizmox.WebGui.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
		/// 
		/// true if all of the children validated successfully; otherwise, false.
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		public override bool ValidateChildren(ValidationConstraints validationConstraints)
		{
			return base.ValidateChildren(validationConstraints);
		}

		/// 
		/// Orientations the change fired.
		/// Checking of current handlers and owned forms handlers.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		protected internal virtual void OnOrientationChanged(IEvent objEvent)
		{
			OrientationChangedEventHandler orientationChangedHandler = OrientationChangedHandler;
			if (orientationChangedHandler != null)
			{
				if (int.TryParse(objEvent["ORI"], out var result))
				{
					orientationChangedHandler(this, new OrientationChangedEventArgs(result));
				}
				else
				{
					orientationChangedHandler(this, new OrientationChangedEventArgs(null));
				}
			}
			Form[] ownedForms = OwnedForms;
			foreach (Form form in ownedForms)
			{
				form.OnOrientationChanged(objEvent);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLoad(EventArgs e)
		{
			LoadHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Closed" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnClosed(EventArgs e)
		{
			ClosedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:FormClosed" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.FormClosedEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnFormClosed(FormClosedEventArgs e)
		{
			TerminateRegisteredTimers();
			FormClosedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.FormClosing"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.FormClosingEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnFormClosing(FormClosingEventArgs e)
		{
			FormClosingHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Closing" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnClosing(CancelEventArgs e)
		{
			ClosingHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGui.Forms.Form.Activated"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnActivated(EventArgs e)
		{
			ActivatedHandler?.Invoke(this, e);
		}

		/// 
		/// Afters the control removed.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="objOldParent">The old parent.</param>
		internal override void AfterControlRemoved(Control objControl, Control objOldParent)
		{
			base.AfterControlRemoved(objControl, objOldParent);
			if (objControl == AcceptButton)
			{
				AcceptButton = null;
			}
			if (objControl == CancelButton)
			{
				CancelButton = null;
			}
			if (objControl == MdiClient)
			{
				MdiClient = null;
			}
		}

		/// 
		/// Raises the Deactivate event.</para> 
		/// </devdoc>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDeactivate(EventArgs e)
		{
			DeactivateHandler?.Invoke(this, e);
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			Control header = Header;
			MainMenu menu = Menu;
			if (menu != null)
			{
				RegisterComponent(menu);
			}
			if (header != null)
			{
				RegisterComponent(header);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			Control header = Header;
			MainMenu menu = Menu;
			if (menu != null)
			{
				UnRegisterComponent(menu);
			}
			if (header != null)
			{
				UnRegisterComponent(header);
			}
		}

		/// 
		/// Performs the layout.
		/// </summary>
		/// <param name="blnForceLayout">if set to true</c> [BLN force layout].</param>
		protected internal override void PerformLayout(bool blnForceLayout)
		{
			if (blnForceLayout)
			{
				Form[] ownedForms = OwnedForms;
				Form[] array = ownedForms;
				foreach (Form form in array)
				{
					if (form.Parent == null)
					{
						form.PerformLayout(blnForceLayout);
					}
				}
			}
			base.PerformLayout(blnForceLayout);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnLocationChanged(LayoutEventArgs e)
		{
			base.OnLocationChanged(e);
			if (e.IsClientSource)
			{
				Moved = true;
			}
		}

		/// 
		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGui.Forms.Control"></see> and its child controls and optionally releases the managed resources.
		/// </summary>
		void IForm.Dispose()
		{
			Dispose();
		}

		/// 
		/// Determines whether to serialize the entrance effect.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeEntranceEffect()
		{
			return EntranceEffect != DefaultEntranceEffect;
		}

		/// 
		/// Resets the entrance effect.
		/// </summary>
		private void ResetEntranceEffect()
		{
			EntranceEffect = DefaultEntranceEffect;
		}

		/// 
		/// Determines whether to serialize the Exit effect.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeExitEffect()
		{
			return ExitEffect != DefaultExitEffect;
		}

		/// 
		/// Resets the Exit effect.
		/// </summary>
		private void ResetExitEffect()
		{
			ExitEffect = DefaultExitEffect;
		}

		/// 
		/// Sets the state of the window.
		/// </summary>
		/// <param name="enmNewFormWindowState">New window state of the form.</param>
		private void SetWindowState(FormWindowState enmNewFormWindowState)
		{
			OnWindowStateChanged(enmNewFormWindowState);
		}

		/// 
		/// Called when [window state changed].
		/// </summary>
		/// <param name="enmNewFormWindowState">State of the enm new form window.</param>
		protected virtual void OnWindowStateChanged(FormWindowState enmNewFormWindowState)
		{
			FormWindowState windowState = WindowState;
			if (windowState == enmNewFormWindowState)
			{
				return;
			}
			if (base.Parent == null)
			{
				switch (enmNewFormWindowState)
				{
				case FormWindowState.Maximized:
				{
					if (windowState == FormWindowState.Normal)
					{
						FormRestoredSize = base.Size;
						FormRestoredLocation = base.Location;
					}
					Size size = Size.Empty;
					if (MdiParent != null)
					{
						size = MdiParent.Size;
					}
					else if (Context != null && Context.MainForm is Form form)
					{
						size = form.Size;
					}
					if (size != Size.Empty)
					{
						base.Size = size;
					}
					base.Location = new Point(0, 0);
					SetValue(WindowStateProperty, enmNewFormWindowState);
					break;
				}
				case FormWindowState.Normal:
					SetValue(WindowStateProperty, enmNewFormWindowState);
					if (FormRestoredSize != Size.Empty)
					{
						base.Size = FormRestoredSize;
						FormRestoredSize = Size.Empty;
					}
					if (FormRestoredLocation != Point.Empty)
					{
						base.Location = FormRestoredLocation;
						FormRestoredLocation = Point.Empty;
					}
					break;
				case FormWindowState.Minimized:
					if (windowState == FormWindowState.Normal)
					{
						FormRestoredSize = base.Size;
						FormRestoredLocation = base.Location;
					}
					FormRestoredWindowState = windowState;
					base.Size = FormMinimizedSize;
					if (MdiParent == null)
					{
						base.Location = new Point(0, 0);
					}
					SetValue(WindowStateProperty, enmNewFormWindowState);
					break;
				}
				UpdateParams(AttributeType.Redraw);
			}
			FireObservableItemPropertyChanged("WindowState");
		}

		/// 
		/// Sets the visible internal.
		/// </summary>
		/// <param name="blnValue">if set to true</c> set visible.</param>
		internal override void SetVisibleInternal(bool blnValue)
		{
			if (TopLevel)
			{
				if (base.Visible == blnValue)
				{
					return;
				}
				IContext current = VWGContext.Current;
				if (blnValue)
				{
					base.SetVisibleInternal(blnValue);
					if (current != null && current.MainForm != this)
					{
						Show();
					}
					else
					{
						CreateControl();
					}
				}
				else
				{
					if (current != null && current.MainForm != this && current.MainForm != null)
					{
						Close(blnClientSource: false, blnSuspendCloseEvent: true, blnFormOwnerClosing: false);
					}
					base.SetVisibleInternal(blnValue);
				}
			}
			else
			{
				base.SetVisibleInternal(blnValue);
			}
		}

		/// 
		/// Sets the context.
		/// </summary>
		/// </value>
		internal void SetContextInternal(IContext objContext)
		{
			mobjContext = objContext;
			Form[] ownedForms = OwnedForms;
			Form[] array = ownedForms;
			foreach (Form form in array)
			{
				form.SetContextInternal(objContext);
			}
		}

		/// 
		/// Sets the context.
		/// </summary>
		/// <param name="objContext">The context.</param>
		void IForm.SetContext(IContext objContext)
		{
			if (objContext != null)
			{
				SetContextInternal(objContext);
			}
		}

		/// 
		/// Clears the context.
		/// </summary>
		void IForm.ClearContext()
		{
			SetContextInternal(null);
		}

		/// 
		/// Gets a flag indicating if should serialize the transparency key.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeTransparencyKey()
		{
			return TransparencyKey != Color.Empty;
		}

		/// 
		/// Shoulds the serialize geo location data.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeGeoLocationData()
		{
			return !GeoLocationData.Empty.Equals(GeographicLocation);
		}

		/// 
		/// Resets the geo location data.
		/// </summary>
		private void ResetGeoLocationData()
		{
			GeographicLocation = GeoLocationData.Empty;
		}

		/// 
		/// Check if conrtol should be rendered.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		protected override bool ShouldRenderControl(Control objControl)
		{
			return !(objControl is MdiClient);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (DialogType == DialogTypes.ModalWindow && ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread")
			{
				criticalEventsData.Set("CLO");
			}
			if (ClosedHandler != null || FormClosedHandler != null || ClosedDelegate != null)
			{
				criticalEventsData.Set("CLO");
			}
			if (ClosingHandler != null || FormClosingHandler != null)
			{
				criticalEventsData.Set("CLI");
			}
			if (ActivatedHandler != null)
			{
				criticalEventsData.Set("AC");
			}
			if (DeactivateHandler != null)
			{
				criticalEventsData.Set("DAT");
			}
			if (OrientationChangedHandler != null)
			{
				criticalEventsData.Set("OC");
			}
			if (GeographicLocationChangedHandler != null)
			{
				criticalEventsData.Set("PC");
			}
			return criticalEventsData;
		}

		/// 
		/// Sets the specified bounds of the control to the specified location and size.
		/// </summary>
		/// <param name="intLeft">The int left.</param>
		/// <param name="intTop">The int top.</param>
		/// <param name="intWidth">Width of the int layout.</param>
		/// <param name="intHeight">Height of the int layout.</param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
		/// </returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
		{
			if (WindowState != FormWindowState.Normal)
			{
				Point formRestoredLocation = FormRestoredLocation;
				Size formRestoredSize = FormRestoredSize;
				if ((enmSpecified & BoundsSpecified.X) != BoundsSpecified.None)
				{
					formRestoredLocation.X = intLeft;
				}
				if ((enmSpecified & BoundsSpecified.Y) != BoundsSpecified.None)
				{
					formRestoredLocation.Y = intTop;
				}
				if ((enmSpecified & BoundsSpecified.Width) != BoundsSpecified.None)
				{
					formRestoredSize.Width = intWidth;
				}
				if ((enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None)
				{
					formRestoredSize.Height = intHeight;
				}
				FormRestoredSize = formRestoredSize;
				FormRestoredLocation = formRestoredLocation;
				return false;
			}
			return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified);
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (ClosedDelegate != null || HasClientHandler("OnUnload"))
			{
				criticalClientEventsData.Set("CLO");
				criticalClientEventsData.Set("CLI");
			}
			if (HasClientHandler("Activated"))
			{
				criticalClientEventsData.Set("AC");
			}
			if (HasClientHandler("OrientationChange"))
			{
				criticalClientEventsData.Set("OC");
			}
			if (HasClientHandler("GeoLocationChanged"))
			{
				criticalClientEventsData.Set("PC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "OnClose":
				((IContextTerminate)Context).SetPendingTermination();
				break;
			case "OnUnload":
				Context.ActiveForm = this;
				Close(blnClientSource: true, blnSuspendCloseEvent: false, blnFormOwnerClosing: false);
				break;
			case "WindowStateChange":
				if (objEvent.Contains("WS"))
				{
					SetWindowState((FormWindowState)Enum.Parse(typeof(FormWindowState), objEvent["WS"]));
				}
				break;
			case "Shortcut":
				Shortcuts[objEvent["VLB"]]?.FireEvent(objEvent);
				break;
			case "OnAccept":
			{
				IButtonControl acceptButton = AcceptButton;
				if (acceptButton != null)
				{
					Control control2 = acceptButton as Control;
					if (control2.Enabled && control2.Visible)
					{
						acceptButton.PerformClick();
					}
				}
				break;
			}
			case "OnCancel":
			{
				IButtonControl cancelButton = CancelButton;
				if (cancelButton != null)
				{
					Control control = cancelButton as Control;
					if (control.Enabled && control.Visible)
					{
						cancelButton.PerformClick();
					}
				}
				break;
			}
			case "Activated":
				ActivateForm(blnUpdatePosition: true);
				break;
			case "ShowServerExplorer":
				if (CommonSwitches.EnableClientShortcuts)
				{
					ServerExplorer serverExplorer = new ServerExplorer();
					serverExplorer.SetRootComponent(Context.MainForm);
					serverExplorer.ShowDialog();
				}
				break;
			case "OrientationChange":
				OnOrientationChanged(objEvent);
				break;
			case "GeoLocationChanged":
				HandleGeographicLocationChanged(objEvent);
				break;
			}
		}

		/// 
		/// Handles the geographic location changed.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		private void HandleGeographicLocationChanged(IEvent objEvent)
		{
			if (objEvent != null)
			{
				string text = objEvent["ECD"];
				string text2 = objEvent["EM"];
				if (!string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(text2))
				{
					throw new Exception($"Geographic location error (code {text}):\n{text2}");
				}
				if (CommonUtils.TryParse(objEvent["LAT"], out double dblValue) && CommonUtils.TryParse(objEvent["LNG"], out double dblValue2))
				{
					OnGeographicLocationChanged(new GeographicLocationChangedEventArgs(new GeoLocation(dblValue, dblValue2)));
				}
			}
		}

		/// 
		/// Raises the <see cref="E:GeographicLocationChanged" /> event.
		/// </summary>
		/// <param name="objGeoLocationChangedEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.GeographicLocationChangedEventArgs" /> instance containing the event data.</param>
		protected virtual void OnGeographicLocationChanged(GeographicLocationChangedEventArgs objGeoLocationChangedEventArgs)
		{
			if (GeographicLocationChangedHandler != null)
			{
				GeographicLocationChangedHandler(this, objGeoLocationChangedEventArgs);
			}
		}

		internal void OnFormAdded(Form objForm)
		{
			ObservableItemAddedHandler?.Invoke(this, new ObservableListEventArgs(objForm));
		}

		internal void OnFormRemoved(Form objForm)
		{
			ObservableItemRemovedHandler?.Invoke(this, new ObservableListEventArgs(objForm));
		}

		static Form()
		{
			LoadEvent = SerializableEvent.Register("Load", typeof(EventHandler), typeof(Form));
			ClosedEvent = SerializableEvent.Register("Closed", typeof(EventHandler), typeof(Form));
			ClosingEvent = SerializableEvent.Register("Closing", typeof(CancelEventHandler), typeof(Form));
			FormClosingEvent = SerializableEvent.Register("FormClosing", typeof(FormClosingEventHandler), typeof(Form));
			FormClosedEvent = SerializableEvent.Register("FormClosed", typeof(FormClosedEventHandler), typeof(Form));
			ActivatedEvent = SerializableEvent.Register("Activated", typeof(EventHandler), typeof(Form));
			DeactivateEvent = SerializableEvent.Register("Deactivate", typeof(EventHandler), typeof(Form));
			OrientationChangedEvent = SerializableEvent.Register("OrientationChange", typeof(OrientationChangedEventHandler), typeof(Form));
			GeographicLocationChangedEvent = SerializableEvent.Register("GeographicLocationChanged", typeof(GeographicLocationChangedEventHandler), typeof(Form));
			ModalMaskProperty = SerializableProperty.Register("ModalMask", typeof(bool), typeof(Form), new SerializablePropertyMetadata(true));
			ObservableItemAddedEvent = SerializableEvent.Register("ObservableItemAdded", typeof(ObservableListEventHandler), typeof(Form));
			ObservableItemInsertedEvent = SerializableEvent.Register("ObservableItemInserted", typeof(ObservableListEventHandler), typeof(Form));
			ObservableItemRemovedEvent = SerializableEvent.Register("ObservableItemRemoved", typeof(ObservableListEventHandler), typeof(Form));
			ObservableListClearedEvent = SerializableEvent.Register("ObservableListCleared", typeof(EventHandler), typeof(Form));
		}
	}
}
