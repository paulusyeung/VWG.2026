#region Using

using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;


using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using System.Runtime.InteropServices;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Common.Interfaces.Emulation;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Reletive aligment of a aligned dialog.
    /// </summary>
    public enum DialogAlignment
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Above
        /// </summary>
        Above,
        /// <summary>
        /// Left
        /// </summary>
        Left,
        /// <summary>
        /// Right
        /// </summary>
        Right,
        /// <summary>
        /// Below
        /// </summary>
        Below,
        /// <summary>
        /// Custom
        /// </summary>
        Custom
    }

    /// <summary>
    /// FormBorderStyle
    /// </summary>
    public enum FormBorderStyle
    {
        /// <summary>
        /// Fixed3D
        /// </summary>
        Fixed3D = 2,
        /// <summary>
        /// FixedDialog
        /// </summary>
        FixedDialog = 3,
        /// <summary>
        /// FixedSingle
        /// </summary>
        FixedSingle = 1,
        /// <summary>
        /// FixedToolWindow
        /// </summary>
        FixedToolWindow = 5,
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Sizable
        /// </summary>
        Sizable = 4,
        /// <summary>
        /// SizableToolWindow
        /// </summary>
        SizableToolWindow = 6
    }


    /// <summary>
    /// 
    /// </summary>
    public enum FormStyle
    {
        /// <summary>
        /// Dialog
        /// </summary>
        Dialog,
        /// <summary>
        /// Application
        /// </summary>
        Application
    }

    /// <summary>Specifies the reason that a form was closed.</summary>
    /// <filterpriority>2</filterpriority>
    public enum CloseReason
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// WindowsShutDown
        /// </summary>
        [Obsolete("Not implemented by design.")]
        WindowsShutDown,
        /// <summary>
        /// MdiFormClosing
        /// </summary>
        MdiFormClosing,
        /// <summary>
        /// UserClosing
        /// </summary>
        UserClosing,
        /// <summary>
        /// TaskManagerClosing
        /// </summary>
        [Obsolete("Not implemented by design.")]
        TaskManagerClosing,
        /// <summary>
        /// FormOwnerClosing
        /// </summary>
        FormOwnerClosing,
        /// <summary>
        /// ApplicationExitCall
        /// </summary>
        [Obsolete("Not implemented by design.")]
        ApplicationExitCall
    }





    #endregion

    #region Form Class

    /// <summary>
    /// Represents a window or dialog box that makes up an application's user interface.  
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmapAttribute(typeof(Form), "Forms.Form.bmp")]
    [DesignerCategory("Form")]
#if WG_NET46
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#elif WG_NET452
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#elif WG_NET451
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#elif WG_NET45
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#elif WG_NET40
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#elif WG_NET35
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#elif WG_NET2
    [InitializationEvent("Load")]
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#else
    [Designer("Gizmox.WebGUI.Forms.Design.FormDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
#endif
    [DesignTimeVisible(false)]

    [DefaultEvent("Load")]
    [Serializable()]
    [MetadataTag(WGTags.Form), Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.FormSkin)), ProxyComponent(typeof(ProxyForm))]
    public class Form : ContainerControl, IForm, IFormParams, IObservableList
    {
        /// <summary>
        /// Provides a property reference to TransparencyKey property.
        /// </summary>
        private static SerializableProperty TransparencyKeyProperty = SerializableProperty.Register("TransparencyKey", typeof(Color), typeof(Form), new SerializablePropertyMetadata(Color.Empty));



        /// <summary>
        /// Provides a property reference to Header property.
        /// </summary>
        private static SerializableProperty HeaderProperty = SerializableProperty.Register("Header", typeof(Control), typeof(Form), new SerializablePropertyMetadata(null));



        /// <summary>
        /// Provides a property reference to Icon property.
        /// </summary>
        private static SerializableProperty IconProperty = SerializableProperty.Register("Icon", typeof(ResourceHandle), typeof(Form), new SerializablePropertyMetadata(null));



        /// <summary>
        /// Provides a property reference to MdiClient property.
        /// </summary>
        private static SerializableProperty MdiClientProperty = SerializableProperty.Register("MdiClient", typeof(MdiClient), typeof(Form), new SerializablePropertyMetadata(null));



        /// <summary>
        /// Provides a property reference to OwnerProperty property.
        /// </summary>
        private static SerializableProperty OwnerProperty = SerializableProperty.Register("OwnerProperty", typeof(Form), typeof(Form), new SerializablePropertyMetadata(null));



        /// <summary>
        /// Provides a property reference to DialogType property.
        /// </summary>
        private static SerializableProperty DialogTypeProperty = SerializableProperty.Register("DialogType", typeof(DialogTypes), typeof(Form), new SerializablePropertyMetadata(DialogTypes.MainWindow));



        /// <summary>
        /// Provides a property reference to AcceptButton property.
        /// </summary>
        private static SerializableProperty AcceptButtonProperty = SerializableProperty.Register("AcceptButton", typeof(IButtonControl), typeof(Form), new SerializablePropertyMetadata(null));



        /// <summary>
        /// Provides a property reference to BeforeUnloadMessage property.
        /// </summary>
        private static SerializableProperty BeforeUnloadMessageProperty = SerializableProperty.Register("BeforeUnloadMessage", typeof(string), typeof(Form), new SerializablePropertyMetadata(string.Empty));



        /// <summary>
        /// Provides a property reference to CancelButton property.
        /// </summary>
        private static SerializableProperty CancelButtonProperty = SerializableProperty.Register("CancelButton", typeof(IButtonControl), typeof(Form), new SerializablePropertyMetadata(null));


        /// <summary>
        /// Provides a property reference to DialogResult property.
        /// </summary>
        private static SerializableProperty DialogResultProperty = SerializableProperty.Register("DialogResult", typeof(DialogResult), typeof(Form), new SerializablePropertyMetadata(DialogResult.None));



        /// <summary>
        /// Provides a property reference to DialogAlignment property.
        /// </summary>
        private static SerializableProperty DialogAlignmentProperty = SerializableProperty.Register("DialogAlignment", typeof(DialogAlignment), typeof(Form), new SerializablePropertyMetadata(DialogAlignment.Below));



        /// <summary>
        /// Provides a property reference to AlignmentId property.
        /// </summary>
        private static SerializableProperty AlignmentIdProperty = SerializableProperty.Register("AlignmentId", typeof(string), typeof(Form), new SerializablePropertyMetadata("0"));



        /// <summary>
        /// Provides a property reference to MemberAlignmentId property.
        /// </summary>
        private static SerializableProperty MemberAlignmentIdProperty = SerializableProperty.Register("MemberAlignmentId", typeof(string), typeof(Form), new SerializablePropertyMetadata("0"));



        /// <summary>
        /// Provides a property reference to StartPosition property.
        /// </summary>
        private static SerializableProperty StartPositionProperty = SerializableProperty.Register("StartPosition", typeof(FormStartPosition), typeof(Form), new SerializablePropertyMetadata(FormStartPosition.WindowsDefaultLocation));



        /// <summary>
        /// Provides a property reference to FormBorderStyle property.
        /// </summary>
        private static SerializableProperty FormBorderStyleProperty = SerializableProperty.Register("FormBorderStyle", typeof(FormBorderStyle), typeof(Form), new SerializablePropertyMetadata(FormBorderStyle.Sizable));



        /// <summary>
        /// Provides a property reference to WindowState property.
        /// </summary>
        private static SerializableProperty WindowStateProperty = SerializableProperty.Register("WindowState", typeof(FormWindowState), typeof(Form), new SerializablePropertyMetadata(FormWindowState.Normal));



        /// <summary>
        /// Provides a property reference to FormStyle property.
        /// </summary>
        private static SerializableProperty FormStyleProperty = SerializableProperty.Register("FormStyle", typeof(FormStyle), typeof(Form), new SerializablePropertyMetadata(FormStyle.Dialog));

        /// <summary>
        /// Provides the entrance visual effect property
        /// </summary>
        private static SerializableProperty EntranceVisualEffectProperty = SerializableProperty.Register("EntranceVisualEffect", typeof(VisualEffect), typeof(Form), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides the exit visual effect property
        /// </summary>
        private static SerializableProperty ExitVisualEffectProperty = SerializableProperty.Register("ExitVisualEffect", typeof(VisualEffect), typeof(Form), new SerializablePropertyMetadata(null));


        /// <summary>
        /// Provides a property reference to MdiParent property.
        /// </summary>
        private static SerializableProperty MdiParentProperty = SerializableProperty.Register("MdiParent", typeof(Form), typeof(Form), new SerializablePropertyMetadata(null));


        /// <summary>
        /// Provides a property reference to Menu property.
        /// </summary>
        private static SerializableProperty MenuProperty = SerializableProperty.Register("Menu", typeof(MainMenu), typeof(Form), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to MainMenuStrip property.
        /// </summary>
        private static SerializableProperty MainMenuStripProperty = SerializableProperty.Register("MainMenuStrip", typeof(MenuStrip), typeof(Form), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ClientStorage property.
        /// </summary>
        private static SerializableProperty ClientStorageProperty = SerializableProperty.Register("ClientStorage", typeof(ClientStorage), typeof(Form), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to GeoLocationData property.
        /// </summary>
        private static SerializableProperty GeoLocationDataProperty = SerializableProperty.Register("GeoLocationData", typeof(GeoLocationData), typeof(Form), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to Shortcuts property.
        /// </summary>
        private static SerializableProperty ShortcutsProperty = SerializableProperty.Register("Shortcuts", typeof(ShortcutsContainer), typeof(Form), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to FormRestoredWindowState property.
        /// </summary>
        private static SerializableProperty FormRestoredWindowStateProperty = SerializableProperty.Register("FormRestoredWindowState", typeof(FormWindowState), typeof(Form), new SerializablePropertyMetadata(FormWindowState.Normal));

        /// <summary>
        /// Provides a property reference to FormRestoredSize property.
        /// </summary>
        private static SerializableProperty FormRestoredSizeProperty = SerializableProperty.Register("FormRestoredSize", typeof(Size), typeof(Form), new SerializablePropertyMetadata(Size.Empty));

        /// <summary>
        /// Provides a property reference to FormRestoredLocation property.
        /// </summary>
        private static SerializableProperty FormRestoredLocationProperty = SerializableProperty.Register("FormRestoredLocation", typeof(Point), typeof(Form), new SerializablePropertyMetadata(Point.Empty));

        /// <summary>
        /// Provides a property reference to ActivateOnShow property.
        /// </summary>
        private static SerializableProperty ActivateOnShowProperty = SerializableProperty.Register("ActivateOnShow", typeof(bool), typeof(Form), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ControlBox property.
        /// </summary>
        private static SerializableProperty ControlBoxProperty = SerializableProperty.Register("ControlBox", typeof(bool), typeof(Form), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to KeyPreview property.
        /// </summary>
        private static SerializableProperty KeyPreviewProperty = SerializableProperty.Register("KeyPreview", typeof(bool), typeof(Form), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to HelpButton property.
        /// </summary>
        private static SerializableProperty HelpButtonProperty = SerializableProperty.Register("HelpButton", typeof(bool), typeof(Form), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to ClosedDelegate property.
        /// </summary>
        private static SerializableProperty ClosedDelegateProperty = SerializableProperty.Register("ClosedDelegate", typeof(EventHandler), typeof(Form), new SerializablePropertyMetadata(null));

        #region Class Members

        #region Events

        /// <summary>
        /// The form load event
        /// </summary>
        public event EventHandler Load
        {
            add
            {
                this.AddHandler(Form.LoadEvent, value);
            }
            remove
            {
                this.RemoveHandler(Form.LoadEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Load event.
        /// </summary>
        private EventHandler LoadHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Form.LoadEvent);
            }
        }

        /// <summary>
        /// The Load event registration.
        /// </summary>
        private static readonly SerializableEvent LoadEvent = SerializableEvent.Register("Load", typeof(EventHandler), typeof(Form));



        /// <summary>
        /// Occurs when the form is closed.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never), SRCategory("CatBehavior"), SRDescription("FormOnClosedDescr"), Browsable(false)]
        public event EventHandler Closed
        {
            add
            {
                this.AddCriticalHandler(Form.ClosedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.ClosedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Closed event.
        /// </summary>
        private EventHandler ClosedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Form.ClosedEvent);
            }
        }

        /// <summary>
        /// The Closed event registration.
        /// </summary>
        private static readonly SerializableEvent ClosedEvent = SerializableEvent.Register("Closed", typeof(EventHandler), typeof(Form));



        /// <summary>
        /// Occurs when the form is closing.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), EditorBrowsable(EditorBrowsableState.Never), SRDescription("FormOnClosingDescr"), Browsable(false)]
        public event CancelEventHandler Closing
        {
            add
            {
                this.AddCriticalHandler(Form.ClosingEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.ClosingEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Closing event.
        /// </summary>
        private CancelEventHandler ClosingHandler
        {
            get
            {
                return (CancelEventHandler)this.GetHandler(Form.ClosingEvent);
            }
        }

        /// <summary>
        /// The Closing event registration.
        /// </summary>
        private static readonly SerializableEvent ClosingEvent = SerializableEvent.Register("Closing", typeof(CancelEventHandler), typeof(Form));

        /// <summary>Occurs before the form is closed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("FormOnFormClosingDescr"), SRCategory("CatBehavior")]
        public event FormClosingEventHandler FormClosing
        {
            add
            {
                this.AddCriticalHandler(Form.FormClosingEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.FormClosingEvent, value);
            }
        }

        /// <summary>
        /// Gets the form closing handler.
        /// </summary>
        /// <value>The form closing handler.</value>
        private FormClosingEventHandler FormClosingHandler
        {
            get
            {
                return (FormClosingEventHandler)this.GetHandler(Form.FormClosingEvent);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly SerializableEvent FormClosingEvent = SerializableEvent.Register("FormClosing", typeof(FormClosingEventHandler), typeof(Form));



        /// <summary>Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.FormClosing"></see> event.</summary>
        /// <filterpriority>2</filterpriority>
        public delegate void FormClosingEventHandler(object sender, FormClosingEventArgs e);

        /// <summary>Occurs after the form is closed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("FormOnFormClosedDescr")]
        public event FormClosedEventHandler FormClosed
        {
            add
            {
                this.AddCriticalHandler(Form.FormClosedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.FormClosedEvent, value);
            }
        }

        /// <summary>Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.FormClosed"></see> event.</summary>
        /// <filterpriority>2</filterpriority>
        public delegate void FormClosedEventHandler(object sender, FormClosedEventArgs e);

        /// <summary>
        /// The Closed event registration.
        /// </summary>
        private static readonly SerializableEvent FormClosedEvent = SerializableEvent.Register("FormClosed", typeof(FormClosedEventHandler), typeof(Form));

        /// <summary>
        /// Gets the hanlder for the Closed event.
        /// </summary>
        private FormClosedEventHandler FormClosedHandler
        {
            get
            {
                return (FormClosedEventHandler)this.GetHandler(Form.FormClosedEvent);
            }
        }

        /// <summary>
        /// Occurs when the form is activated in code or by the user.
        /// </summary>
        public event EventHandler Activated
        {
            add
            {
                this.AddCriticalHandler(Form.ActivatedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.ActivatedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Activated event.
        /// </summary>
        private EventHandler ActivatedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Form.ActivatedEvent);
            }
        }

        /// <summary>
        /// The Activated event registration.
        /// </summary>
        private static readonly SerializableEvent ActivatedEvent = SerializableEvent.Register("Activated", typeof(EventHandler), typeof(Form));




        /// <devdoc>
        ///    <para>Occurs when the form loses focus and is not the active form.</para>
        /// </devdoc> 
        [SRDescription("FormOnDeactivateDescr"), SRCategory("CatFocus")]
        public event EventHandler Deactivate
        {
            add
            {
                this.AddCriticalHandler(Form.DeactivateEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.DeactivateEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Deactivate event.
        /// </summary>
        private EventHandler DeactivateHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Form.DeactivateEvent);
            }
        }

        /// <summary>
        /// The Deactivate event registration.
        /// </summary>
        private static readonly SerializableEvent DeactivateEvent = SerializableEvent.Register("Deactivate", typeof(EventHandler), typeof(Form));


        /// <summary>
        /// 
        /// </summary>
        private static readonly SerializableEvent OrientationChangedEvent = SerializableEvent.Register("OrientationChange", typeof(OrientationChangedEventHandler), typeof(Form));

        /// <summary>Represents the method that handles a <see cref="E:Gizmox.WebGui.Forms.Form.OrientationChanged"></see> event.</summary>
        /// <filterpriority>2</filterpriority>
        public delegate void OrientationChangedEventHandler(object sender, OrientationChangedEventArgs e);

        /// <summary>
        /// Occurs when orientation is changed.
        /// </summary>
        [SRCategory("Mobile Devices"), Description("OrientationChange Happens when moblie device orientation is changed from landscape to  portrait.")]
        public event OrientationChangedEventHandler OrientationChanged
        {
            add
            {
                this.AddCriticalHandler(Form.OrientationChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Form.OrientationChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client orientation changed].
        /// </summary>
        [SRDescription("Occurs when oblie device orientation is changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientOrientationChanged
        {
            add
            {
                this.AddClientHandler("OrientationChange", value);
            }
            remove
            {
                this.RemoveClientHandler("OrientationChange", value);
            }
        }

        /// <summary>
        /// Gets the orientation change handler.
        /// </summary>
        private OrientationChangedEventHandler OrientationChangedHandler
        {
            get
            {
                return (OrientationChangedEventHandler)this.GetHandler(Form.OrientationChangedEvent);
            }
        }

        /// <summary>
        /// The GeographicLocationChanged event registration.
        /// </summary>
        private static readonly SerializableEvent GeographicLocationChangedEvent = SerializableEvent.Register("GeographicLocationChanged", typeof(GeographicLocationChangedEventHandler), typeof(Form));

        /// <summary>
        /// Occurs when [location changed].
        /// </summary>
        public event GeographicLocationChangedEventHandler GeographicLocationChanged
        {
            add
            {
                // Validates the geo location capability.
                ValidateGeoLocationCapability();

                this.AddHandler(Form.GeographicLocationChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Form.GeographicLocationChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client geographic location changed].
        /// </summary>
        [SRDescription("Occurs when device geolocation changes in client mode."), Category("Client")]
        public event ClientEventHandler ClientGeographicLocationChanged
        {
            add
            {
                this.AddClientHandler("GeoLocationChanged", value);
            }
            remove
            {
                this.RemoveClientHandler("GeoLocationChanged", value);
            }
        }

        /// <summary>
        /// Gets the geographic location changed handler.
        /// </summary>
        private GeographicLocationChangedEventHandler GeographicLocationChangedHandler
        {
            get
            {
                return (GeographicLocationChangedEventHandler)this.GetHandler(Form.GeographicLocationChangedEvent);
            }
        }

        #endregion

        /// <summary>
        /// The current context object
        /// </summary>
        [NonSerialized()]
        private IContext mobjContext = null;

        /// <summary>
        /// The form owned forms
        /// </summary>
        [NonSerialized()]
        private FormCollection mobjOwnedForms = null;

        private event EventHandler mobjPreRender;

        private HtmlBox mobjUnauthorizedAccessHtmlBox = null;

        /// <summary>
        /// Gets the security stopper html box.
        /// </summary>
        /// <value>
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

        #endregion

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="Form"/> instance.
        /// </summary>
        public Form(IContext objContext)
        {
            InitializeForm(objContext);
        }

        /// <summary>
        /// Creates a new <see cref="Form"/> instance.
        /// </summary>
        public Form()
        {
            // TODO: Find a better way
            // Not valid in design mode
            try
            {
                InitializeForm(VWGContext.Current);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                this.CalledOnLoad = false;
                this.CalledMakeVisible = false;
                this.CalledCreateControl = false;

                MainMenu objMainMenu = this.Menu;
                if ((objMainMenu != null) && (objMainMenu.Form == this))
                {
                    objMainMenu.Dispose();
                    this.Menu = null;
                }
            }
            else
            {
                base.Dispose(blnDisposing);
            }
        }

        /// <summary>
        /// Validates the geo location capability.
        /// </summary>
        private void ValidateGeoLocationCapability()
        {
            if (!this.DesignMode)
            {
                IContextParams objContextParams = this.Context as IContextParams;
                if (objContextParams != null)
                {
                    if ((objContextParams.MISCBrowserCapabilities & MISCBrowserCapabilities.Geolocation) != MISCBrowserCapabilities.Geolocation)
                    {
                        throw new NotSupportedException("Your browser does not support geographic location services.");
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the form.
        /// </summary>
        /// <param name="objContext">The current context.</param>
        private void InitializeForm(IContext objContext)
        {
            // Set local reference
            this.SetContextInternal(objContext);

            // Set visibility intarnally to false
            this.VisibleIntenal = false;

            // Create a local geo-location data.
            this.GeographicLocation = new GeoLocationData();

            // In runtime - register geo-location data changing.
            if (!this.DesignMode)
            {
                this.GeographicLocation.GeoLocationDataChanged += new EventHandler(OnGeoLocationDataChanged);
            }

            // Set the default form state
            this.SetState(FormState.MinimizeBox | FormState.MaximizeBox | FormState.CloseBox, true);

            // Set form as top level by default.
            this.SetTopLevel(true);
        }

        #endregion

        #region Methods

        #region Serialization Methods

        /// <summary>
        /// The amount of fields the form needs to serialize
        /// </summary>
        private const int mintFormSerializableFieldCount = 1;

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                // Get the base requirements and add the form fields
                int intSerializableDataInitialSize = base.SerializableDataInitialSize + mintFormSerializableFieldCount;

                // Add the form collection required capacity
                intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjOwnedForms);

                return intSerializableDataInitialSize;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the form state
            mintFormState = objReader.ReadInt32();

            // Read the owned form array
            object[] arrForms = objReader.ReadArray();

            // If there are forms
            if (arrForms.Length > 0)
            {
                // Create the form collection with the initial items
                mobjOwnedForms = new FormCollection(this, arrForms);
            }
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the form state
            objWriter.WriteInt32(mintFormState);

            // Write the owned form array
            objWriter.WriteArray(mobjOwnedForms);
        }

        #endregion

        #region State Methods

        private object mobjAligmentComponent;
        private IIdentifiedComponent mobjAlignmentMemberComponent;

        /// <summary>
        /// The form state
        /// </summary>
        [NonSerialized]
        private int mintFormState = 0;


        [Flags]
        internal enum FormState : int
        {
            /// <summary>
            /// The is active form flag
            /// </summary>
            IsActiveForm = 1,

            /// <summary>
            /// The called on load flag
            /// </summary>
            CalledOnLoad = 2,

            /// <summary>
            /// The called make visible flag
            /// </summary>
            CalledMakeVisible = 4,

            /// <summary>
            /// The called create control flag
            /// </summary>
            CalledCreateControlProperty = 8,

            /// <summary>
            /// The maximize box flag
            /// </summary>
            MaximizeBox = 16,

            /// <summary>
            /// The minimize box flag
            /// </summary>
            MinimizeBox = 32,

            /// <summary>
            /// The is closed flag
            /// </summary>
            IsClosed = 64,

            /// <summary>
            /// The form moved flag
            /// </summary>
            Moved = 128,

            /// <summary>
            /// The is modal active flag
            /// </summary>
            IsModalActive = 256,

            /// <summary>
            /// The Close box flag
            /// </summary>
            CloseBox = 512
        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="enmState">State of the enm.</param>
        /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
        internal void SetState(FormState enmState, bool blnValue)
        {
            this.mintFormState = blnValue ? (this.mintFormState | ((int)enmState)) : (this.mintFormState & ~((int)enmState));
        }

        /// <summary>
        /// Sets the state with check.
        /// </summary>
        /// <param name="enmState">State of the enm.</param>
        /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
        /// <returns></returns>
        internal bool SetStateWithCheck(FormState enmState, bool blnValue)
        {
            // Check if the value had changed
            if (GetState(enmState) != blnValue)
            {
                SetState(enmState, blnValue);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Called when [geo location data changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnGeoLocationDataChanged(object sender, EventArgs e)
        {
            this.UpdateParams(AttributeType.GeographicLocation);
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="enmState">State of the enm.</param>
        /// <returns></returns>
        internal bool GetState(FormState enmState)
        {
            return ((this.mintFormState & ((int)enmState)) != 0);
        }

        #endregion

        #region Render

        /// <summary>
        /// Checks if the current control needs rendering and 
        /// continues to process sub tree/
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // If this Form has a parent control
            if (this.Parent != null)
            {
                base.RenderControl(objContext, objWriter, lngRequestID);
            }
            else
            {
                // write control element tags
                objWriter.WriteStartElement(((IServerResponse)objContext.Response).GeneralNamespacePrefix, this.MetadataTag, ((IServerResponse)objContext.Response).GeneralNamespaceUrl);

                // if control is dirty
                if (IsDirty(lngRequestID))
                {
                    // add generic attributes
                    RenderAttributes(objContext, (IAttributeWriter)objWriter);

                    // Render component client events
                    RenderComponentClientEvents(objContext, objWriter, lngRequestID);
                }
                else
                {
                    RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
                }

                // render control
                Render(objContext, objWriter, lngRequestID);

                // close control element tag
                objWriter.WriteEndElement();
            }
        }

        /// <summary>
        /// Updates the params internal.
        /// </summary>
        /// <param name="enmAttributeType">Type of the enm attribute.</param>
        internal void UpdateParamsInternal(AttributeType enmAttributeType)
        {
            this.UpdateParams(enmAttributeType);
        }

        /// <summary>
        /// Renders the theme.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected override void RenderThemeAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            if (VWGContext.Current.SupportsMultipleThemes)
            {
                if (TopLevel && this.Theme == "Inherit")
                {
                    objWriter.WriteAttributeString(WGAttributes.Theme, VWGContext.Current.CurrentTheme);
                }
                else
                {
                    base.RenderThemeAttribute(objContext, objWriter, blnForceRender);
                }
            }
        }

        /// <summary>
        /// Activates a child control. Optionally specifies the direction in the tab order to select the control from.
        /// </summary>
        /// <param name="blnDirected"></param>
        /// <param name="blnForward"></param>
        protected override void Select(bool blnDirected, bool blnForward)
        {
            this.SelectInternal(blnDirected, blnForward);
        }

        /// <summary>
        /// Selects the internal.
        /// </summary>
        /// <param name="blnDirected">if set to <c>true</c> [BLN directed].</param>
        /// <param name="blnForward">if set to <c>true</c> [BLN forward].</param>
        private void SelectInternal(bool blnDirected, bool blnForward)
        {
            if (blnDirected)
            {
                base.SelectNextControl(null, blnForward, true, true, false);
            }

            if (this.TopLevel)
            {
                // Bring window to top through client invokation.
                this.InvokeMethodWithId("Forms_BringWindowToTop");

                // Activate the form
                this.ActivateForm(true);
            }
            else if (!this.IsMdiChild)
            {
                // Get parent form and if exists - set this form as active control.
                Form objParentFormInternal = base.ParentFormInternal;
                if (objParentFormInternal != null)
                {
                    objParentFormInternal.ActiveControl = this;
                }
            }
        }

        /// <summary>
        /// Focuses the internal.
        /// </summary>
        /// <returns></returns>
        internal override bool FocusInternal()
        {
            if (this.TopLevel)
            {
                // Bring window to top through client invokation.
                this.InvokeMethodWithId("Forms_BringWindowToTop");

                // Activate the form
                this.ActivateForm(true);
            }

            return base.FocusInternal();
        }

        /// <summary>
        /// Renders Form window state.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderFormWindowState(IAttributeWriter objWriter)
        {
            // Get local window state.
            FormWindowState enmFormWindowState = this.WindowState;

            // Render window state.
            objWriter.WriteAttributeString(WGAttributes.WindowState, ((int)enmFormWindowState).ToString());

            // If current window state is minimized.
            if (enmFormWindowState == FormWindowState.Minimized)
            {
                // Render restored window state so we will be able to restore it from the minimized state.
                objWriter.WriteAttributeString(WGAttributes.RestoredWindowState, ((int)this.FormRestoredWindowState).ToString());
            }
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            // If this Form has a parent control
            if (this.Parent != null)
            {
                base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
            }
            else
            {
                // Check layout attribute type.
                if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
                {
                    // Renders the form rectangle.
                    this.RenderFormRectangle(objWriter, this.StartPosition, this.Location, this.Size);
                }

                // Updating the enabled field.
                if (IsDirtyAttributes(lngRequestID, AttributeType.Enabled))
                {
                    objWriter.WriteAttributeString(WGAttributes.Enabled, Enabled ? "1" : "0");
                }

                // Check control attribute type.
                if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
                {
                    // Render form's text.
                    objWriter.WriteAttributeText(WGAttributes.Text, this.Text);

                    // Renders the form buttons.
                    this.RenderFormButtons(objWriter, true);
                }

                // Check redraw attribute type.
                if (IsDirtyAttributes(lngRequestID, AttributeType.Redraw))
                {
                    // render form window state
                    RenderFormWindowState(objWriter);

                    objWriter.WriteAttributeString(WGAttributes.FormBorderStyle, ((int)this.FormBorderStyle).ToString());
                }

                // Check redraw extended type.
                if (IsDirtyAttributes(lngRequestID, AttributeType.Extended))
                {
                    // Render ControlBox attribute
                    this.RenderControlBoxAttribute(objWriter, true);

                    // Renders the form boxes.
                    this.RenderFormBoxes(objWriter, true);
                }

                // Check if GeographicLocation attributes should be updated.
                if (this.IsDirtyAttributes(lngRequestID, AttributeType.GeographicLocation))
                {
                    // Renders geo-location attributes.
                    this.RenderGeoLocationAttributes(objContext, objWriter, true);
                }

                // Check if VisualEffect attributes should be updated.
                if (this.IsDirtyAttributes(lngRequestID, AttributeType.VisualEffect))
                {
                    this.RenderEntranceVisualEffect(objContext, objWriter, true);
                    this.RenderExitVisualEffect(objContext, objWriter, true);
                }

                base.RenderComponentAttributes(Context, (IAttributeWriter)objWriter);
            }
        }

        /// <summary>
        /// Renders the form.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        void IForm.RenderForm(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            this.RenderControl(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Pre-render form.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        void IForm.PreRenderForm(IContext objContext, long lngRequestID)
        {
            this.PreRenderControl(objContext, lngRequestID);

            // Pre render owned forms.
            this.PreRenderForms(objContext, lngRequestID);

            OnPreRendered(EventArgs.Empty);
        }

        /// <summary>
        /// Raises after PreRenderForm has completed.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPreRendered(EventArgs e)
        {
            if (mobjPreRender != null)
            {
                mobjPreRender(this, e);
            }
        }

        /// <summary>
        /// Posts the render form.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        void IForm.PostRenderForm(IContext objContext, long lngRequestID)
        {
            this.PostRenderControl(objContext, lngRequestID);

            // Post render owned forms.
            this.PostRenderForms(objContext, lngRequestID);
        }

        /// <summary>
        /// Pre-render forms.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        private void PreRenderForms(IContext objContext, long lngRequestID)
        {
            // Get owned forms .
            Form[] arrOwnedForms = this.OwnedForms;

            // Loop all owned forms 
            foreach (IForm objForm in arrOwnedForms)
            {
                // render child window
                objForm.PreRenderForm(objContext, lngRequestID);
            }
        }

        /// <summary>
        /// Posts the render forms.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        private void PostRenderForms(IContext objContext, long lngRequestID)
        {
            // Get owned forms .
            Form[] arrOwnedForms = this.OwnedForms;

            // Loop all owned forms 
            foreach (IForm objForm in arrOwnedForms)
            {
                // render child window
                objForm.PostRenderForm(objContext, lngRequestID);
            }
        }

        /// <summary>
        /// Renders the form rectangle.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="enmFormStartPosition">The form start position.</param>
        /// <param name="objLocation">The location of the form.</param>
        /// <param name="objSize">Size of the form.</param>
        private void RenderFormRectangle(IAttributeWriter objWriter, FormStartPosition enmFormStartPosition, Point objLocation, Size objSize)
        {
            // Validate recieved arguments.
            if (objLocation != null && objSize != null)
            {
                // Render form size.
                objWriter.WriteAttributeString(WGAttributes.Height, objSize.Height.ToString());
                objWriter.WriteAttributeString(WGAttributes.Width, objSize.Width.ToString());

                if (this.DialogType != DialogTypes.PopupWindow)
                {
                    // Get restored size.
                    Size objFormRestoredSize = this.FormRestoredSize;
                    if (objFormRestoredSize != Size.Empty)
                    {
                        objWriter.WriteAttributeString(WGAttributes.RestoredHeight, objFormRestoredSize.Height.ToString());
                        objWriter.WriteAttributeString(WGAttributes.RestoredWidth, objFormRestoredSize.Width.ToString());
                    }
                }
                // Check if location should be rendered.
                if (enmFormStartPosition == FormStartPosition.Manual || this.Moved)
                {
                    // Render form location.
                    objWriter.WriteAttributeString(WGAttributes.Left, objLocation.X.ToString());
                    objWriter.WriteAttributeString(WGAttributes.Top, objLocation.Y.ToString());
                }

                // Get restored position.
                Point objFormRestoredLocation = this.FormRestoredLocation;
                if (objFormRestoredLocation != Point.Empty)
                {
                    objWriter.WriteAttributeString(WGAttributes.RestoredLeft, objFormRestoredLocation.X.ToString());
                    objWriter.WriteAttributeString(WGAttributes.RestoredTop, objFormRestoredLocation.Y.ToString());
                }
            }
        }

        /// <summary>
        /// Renders the forms attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // If this Form has no parent control
            if (this.Parent == null)
            {
                // Reder the min max size if the form has no parent
                RenderMinMaxSizeAttributes(objContext, objWriter);

                // Indicates if form is a root mashup control
                bool blnMashup = false;

                // If is root form
                if (this.IsRootForm)
                {
                    // Try to get mashup arguments
                    IMashupArguments objMashupArguments = this.Context.Arguments as IMashupArguments;
                    if (objMashupArguments != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Mashup, ((int)objMashupArguments.Type).ToString());
                        objWriter.WriteAttributeString(WGAttributes.Height, "400");
                        objWriter.WriteAttributeString(WGAttributes.Width, "400");
                        objWriter.WriteAttributeString(WGAttributes.Left, "100");
                        objWriter.WriteAttributeString(WGAttributes.Top, "10");
                        blnMashup = true;
                    }
                }

                // Get form start position.
                FormStartPosition enmStartPosition = this.StartPosition;

                // Check if is not mashup            
                if (!blnMashup)
                {
                    // Renders the form rectangle.
                    this.RenderFormRectangle(objWriter, enmStartPosition, new Point(this.LayoutLeft, this.LayoutTop), this.Size);
                }

                objWriter.WriteAttributeString(WGAttributes.Redraw, "1");
                objWriter.WriteAttributeString(WGAttributes.Type, this.DialogType.ToString());
                if ((enmStartPosition == FormStartPosition.CenterParent || enmStartPosition == FormStartPosition.CenterScreen) && !this.Moved)
                {
                    objWriter.WriteAttributeString(WGAttributes.FormStartPosition, ((int)enmStartPosition).ToString());
                }

                // render form window state
                RenderFormWindowState(objWriter);

                objWriter.WriteAttributeString(WGAttributes.Style, this.FormStyle == FormStyle.Dialog ? "0" : "1");

                string strBeforeUnloadMessage = this.BeforeUnloadMessage;
                if (strBeforeUnloadMessage != string.Empty)
                {
                    objWriter.WriteAttributeString(WGAttributes.BeforeUnloadMessage, strBeforeUnloadMessage);
                }

                if (this.IsWindowSized)
                {
                    objWriter.WriteAttributeString(WGAttributes.IsWindowSized, "1");
                }

                // Renders the form buttons.
                this.RenderFormButtons(objWriter, false);

                // If should show modal mask
                if (!this.ModalMask)
                {
                    objWriter.WriteAttributeString(WGAttributes.ShowModalMask, "0");
                }

                // Get the alignment type
                DialogAlignment enmDialogAlignment = this.DialogAlignment;

                // Get the control id to align to
                string strAlignmentId;
                string strMemberAlignmentId;
                GetRenderAlignmentComponentIds(out strAlignmentId, out strMemberAlignmentId);

                // If there is a valid alignment control id and aligment definition
                if (strAlignmentId != "0" && !string.IsNullOrEmpty(strAlignmentId) && enmDialogAlignment != DialogAlignment.None)
                {
                    // If is a member alignment we need to send the full member id
                    if (strMemberAlignmentId != "0" && !string.IsNullOrEmpty(strMemberAlignmentId))
                    {
                        // Set align to as full member id
                        objWriter.WriteAttributeString(WGAttributes.AlignTo, strAlignmentId + "_" + strMemberAlignmentId);
                    }
                    else
                    {
                        // Set align to control id
                        objWriter.WriteAttributeString(WGAttributes.AlignTo, strAlignmentId);
                    }
                    objWriter.WriteAttributeString(WGAttributes.AlignType, enmDialogAlignment.ToString()[0].ToString());
                }

                // Get the current Mdi parent
                Form objMdiParent = this.MdiParent;

                // If we found an mdi oarent
                if (objMdiParent != null)
                {
                    IControl objControl = objMdiParent as IControl;
                    if (objControl != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.MdiParent, objControl.ID.ToString());
                    }
                }

                if (this.IsMdiContainer)
                {
                    objWriter.WriteAttributeString(WGAttributes.IsMdiContainer, "1");
                }
            }

            // Form attributes
            objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);

            // Render Form Icon
            ResourceHandle objIcon = this.GetProxyPropertyValue<ResourceHandle>("Icon", this.Icon);
            if (objIcon != null)
            {
                objWriter.WriteAttributeString(WGAttributes.Icon, objIcon.ToString());
            }

            objWriter.WriteAttributeString(WGAttributes.FormBorderStyle, ((int)this.FormBorderStyle).ToString());

            // Renders the form boxes.
            this.RenderFormBoxes(objWriter, false);

            // Renders geo-location attributes.
            RenderGeoLocationAttributes(objContext, objWriter, false);

            // Render ControlBox attribute
            RenderControlBoxAttribute(objWriter, false);

            RenderEntranceVisualEffect(objContext, objWriter, false);

            RenderExitVisualEffect(objContext, objWriter, false);

            // Render default attributes
            base.RenderAttributes(objContext, objWriter);
        }

        /// <summary>
        /// Returns aligment component ids for rendering.
        /// </summary>
        private void GetRenderAlignmentComponentIds(out string strComponentId, out string strMemberId)
        {
            strComponentId = "";
            strMemberId = "";
            if (mobjAligmentComponent == null) { return; }

            Component objComponent = mobjAligmentComponent as Component;
            IRegisteredComponentMember objComponentMember = mobjAligmentComponent as IRegisteredComponentMember;
            if (objComponent == null && objComponentMember == null) { return; }

            if (objComponentMember == null)
            {
                IIdentifiedComponent objIdentifiedComponent = mobjAlignmentMemberComponent as IIdentifiedComponent;
                if (objIdentifiedComponent != null)
                {
                    strMemberId = objIdentifiedComponent.ID;
                }
            }
            else
            {
                objComponent = (VWGContext.Current as ISessionRegistry).GetRegisteredComponent(objComponentMember.OwnerID) as Component;
                strMemberId = objComponentMember.MemberID.ToString();
            }

            ProxyComponent objProxyForm = null;

            // NOTE: objComponent.Form will be null for NonState ProxyComponents.
            if (objComponent.Form != null)
            {
                objProxyForm = objComponent.Form.ProxyComponent;
            }
            
            // If there is no proxy form.
            if (objProxyForm == null)
            {
                strComponentId = objComponent.ID.ToString();
            }
            else
            {
                // If there is proxy form.
                ProxyComponent objProxyComponentOfSource = GetVisibleProxyComponentOfSource(objProxyForm, objComponent.ID);
                if (objProxyComponentOfSource != null)
                {
                    strComponentId = objProxyComponentOfSource.ID.ToString();
                }
            }
        }

        /// <summary>
        /// Returns visible proxy component by source component.
        /// </summary>
        private ProxyComponent GetVisibleProxyComponentOfSource(ProxyComponent objProxyComponent, long objSourceComponentId)
        {
            // If current proxy has the right source id and it is visible, return it.
            Component objCurrentSourceComponent = objProxyComponent.SourceComponent;
            if (objCurrentSourceComponent != null && objCurrentSourceComponent.ID == objSourceComponentId) 
            {
                // NOTE: We will check for visible only here, because we want to reduce Visible logic executions.
                if (objProxyComponent.Visible)
                {
                    return objProxyComponent; 
                }                
            }

            // Loop recursively on all the child components
            foreach (ProxyComponent objChildProxyComponent in objProxyComponent.Components)
            {
                ProxyComponent objResult = GetVisibleProxyComponentOfSource(objChildProxyComponent, objSourceComponentId);
                if (objResult != null)
                {
                    return objResult;
                }
            }

            return null;
        }

        /// <summary>
        /// Renders the enabled attribute.
        /// </summary>
        /// <param name="objWriter">The object writer.</param>
        protected override void RenderEnabledAttribute(IAttributeWriter objWriter)
        {
            if (Context.Config.FormsSecurityEnabled)
            {
                // Show security waver if needed.
                IContextParams objContextParams = this.Context as IContextParams;

                // In ReadOnly mode, form is disabled.
                if (objContextParams.GetFormAccessMode(this) == FormAccessMode.ReadOnly)
                {
                    objWriter.WriteAttributeString(WGAttributes.Enabled, "0");
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

        /// <summary>
        /// Renders the entrance visual effect.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderEntranceVisualEffect(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            RenderFullScreenNavigationEffect(this.EntranceEffect, WGAttributes.BeforeEntranceEffect, WGAttributes.AfterEntranceEffect, objContext, objWriter, blnForceRender);
        }

        /// <summary>
        /// Renders the exit visual effect.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderExitVisualEffect(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            RenderFullScreenNavigationEffect(this.ExitEffect, WGAttributes.BeforeExitEffect, WGAttributes.AfterExitEffect, objContext, objWriter, blnForceRender);
        }

        /// <summary>
        /// Renders the full screen navigation effect.
        /// </summary>
        /// <param name="objEffectToRender">The effect to render.</param>
        /// <param name="strBeforeEffectAttributeName">Name of the before-effect attribute.</param>
        /// <param name="strAfterEffectAttributeName">Name of the after-effect attribute.</param>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [forced to render].</param>
        private void RenderFullScreenNavigationEffect(VisualEffect objEffectToRender, string strBeforeEffectAttributeName, string strAfterEffectAttributeName, IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            // If the effect exists, and application is in full screen mode..
            if ((objEffectToRender != null || blnForceRender) && Context.FullScreenMode && (this.TopLevel || this.IsMdiChild) && this.DialogType != DialogTypes.PopupWindow)
            {
                // Render initial effect state, if exists.
                string strBeforeString = objEffectToRender is TranslateVisualEffect ? objEffectToRender.GetBeforeToString(objContext, true) : objEffectToRender.ToString(objContext);

                if (!string.IsNullOrEmpty(strBeforeString))
                {
                    objWriter.WriteAttributeText(strBeforeEffectAttributeName, strBeforeString);
                }

                // Render final effect state, if exists.
                string strAfterString = objEffectToRender.GetAfterToString(objContext, true);

                if (!string.IsNullOrEmpty(strAfterString))
                {
                    objWriter.WriteAttributeText(strAfterEffectAttributeName, strAfterString);
                }
            }
        }

        /// <summary>
        /// Renders the control box attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderControlBoxAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnControlBox = this.ControlBox;

            if (!blnControlBox || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ControlBox, blnControlBox ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the form buttons.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderFormButtons(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnHasAcceptButton = (this.AcceptButton != null);

            if (blnHasAcceptButton || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.AcceptButton, blnHasAcceptButton ? "1" : "0");
                objWriter.WriteAttributeString(WGAttributes.AcceptCotnrolId, this.AcceptButton is Control ? (this.AcceptButton as Control).ID.ToString() : "0");
            }

            bool blnHasCancelButton = (this.CancelButton != null);

            if (blnHasCancelButton || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.CancelButton, blnHasCancelButton ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the form boxes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderFormBoxes(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.ControlBox)
            {
                bool blnHasMaximizeBox = this.MaximizeBox;

                if (blnHasMaximizeBox || blnForceRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.Maximize, blnHasMaximizeBox ? "1" : "0");
                }

                bool blnHasMinimizeBox = this.MinimizeBox;

                if (blnHasMinimizeBox || blnForceRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.Minimize, blnHasMinimizeBox ? "1" : "0");
                }

                bool blnHasCloseBox = this.CloseBox;

                if (!blnHasCloseBox || blnForceRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.Close, blnHasCloseBox ? "1" : "0");
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is root form.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is root form; otherwise, <c>false</c>.
        /// </value>
        private bool IsRootForm
        {
            get
            {
                return this.Context.MainForm == this;
            }
        }

        /// <summary>
        /// Render the form content
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (Context.Config.FormsSecurityEnabled)
            {
                // Show security waver if needed.
                IContextParams objContextParams = Context as IContextParams;

                // In access Denied mode, form content is not rendered. Show security message instead.
                if (objContextParams.GetFormAccessMode(this) == FormAccessMode.Denied)
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

        /// <summary>
        /// Renders the unauthorized access HTML box.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        /// <param name="lngRequestID">The LNG request unique identifier.</param>
        private void RenderUnauthorizedAccessHtmlBox(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            this.UnauthorizedAccessHtmlBox.RenderControl(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request unique identifier.</param>
        private void RenderContent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // If this Form has a parent control
            if (this.Parent != null)
            {
                base.Render(objContext, objWriter, lngRequestID);
            }
            else
            {
                if (IsDirty(lngRequestID))
                {
                    // render controls
                    RenderControls(objContext, objWriter, 0);

                    // Renders the client storatge.
                    RenderClientStoratge(objContext, objWriter, lngRequestID);
                }
                else
                {
                    // render controls
                    RenderControls(objContext, objWriter, lngRequestID);
                }

                // render sub forms
                RenderForms(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Renders the client storatge.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        private void RenderClientStoratge(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            ClientStorage objClientStorage = this.ClientStorage;
            if (objClientStorage != null)
            {
                objClientStorage.Render(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Renders the geo-location data.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForcRender">if set to <c>true</c> [BLN forc render].</param>
        private void RenderGeoLocationAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForcRender)
        {
            // Define variables with default geo-location data.
            bool blnRepeatCheck = false;
            bool blnEnableHighAccuracy = false;
            double? dblMaximumAge = null;
            double? dblTimeout = null;

            // Try get local geo-location data.
            GeoLocationData objGeoLocation = this.GeographicLocation;
            if (objGeoLocation != null)
            {
                blnRepeatCheck = objGeoLocation.RepeatCheck;
                blnEnableHighAccuracy = objGeoLocation.EnableHighAccuracy;
                dblMaximumAge = objGeoLocation.MaximumAge;
                dblTimeout = objGeoLocation.Timeout;
            }

            // Render the RepeatCheck attribute - if needed.
            if (blnForcRender || blnRepeatCheck)
            {
                objWriter.WriteAttributeString(WGAttributes.RepeatCheck, blnRepeatCheck ? "1" : "0");
            }

            // Render the EnableHighAccuracy attribute - if needed.
            if (blnForcRender || blnEnableHighAccuracy)
            {
                objWriter.WriteAttributeString(WGAttributes.EnableHighAccuracy, blnEnableHighAccuracy ? "1" : "0");
            }

            // Render the MaximumAge attribute - if needed.
            if (blnForcRender || dblMaximumAge != null)
            {
                objWriter.WriteAttributeString(WGAttributes.MaximumAge, dblMaximumAge.ToString());
            }

            // Render the Timeout attribute - if needed.
            if (blnForcRender || dblTimeout != null)
            {
                objWriter.WriteAttributeString(WGAttributes.Timeout, dblTimeout.ToString());
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            ProxyComponent objProxyComponent = this.ProxyComponent;

            if (objProxyComponent == null)
            {
                // Render shortcuts if exists
                ShortcutsContainer objShortcuts = this.GetValue<ShortcutsContainer>(Form.ShortcutsProperty);
                if (objShortcuts != null)
                {
                    objShortcuts.RenderControl(objContext, objWriter, lngRequestID);
                }

                // If this Form has no parent control
                if (this.Parent == null)
                {
                    // Render the header control if exists
                    Control objHeader = this.Header;
                    if (objHeader != null)
                    {
                        RenderHeader(objHeader, objContext, objWriter, lngRequestID);
                    }
                }

                // Render main menu if exists
                MainMenu objMenu = this.Menu;
                if (objMenu != null)
                {
                    ((IRenderableComponent)objMenu).RenderComponent(objContext, objWriter, lngRequestID);
                }
            }

            // Define flags.
            MdiClient objMdiClient = null;
            bool blnHasFillingControl = false;

            // Loop all sub controls.
            foreach (Control objControl in this.Controls)
            {
                // Check if this control is an mdi client in order to render it last.
                if (objControl is MdiClient)
                {
                    // Preserve mdi client.
                    objMdiClient = objControl as MdiClient;
                }
                else
                {
                    // Render control.
                    blnHasFillingControl = objControl.Dock == DockStyle.Fill;
                }

                // Check if both flags has been fileld.
                if (objMdiClient != null && blnHasFillingControl)
                {
                    break;
                }
            }

            if (objProxyComponent == null)
            {
                // Check if an mdi client has been found.
                if (objMdiClient != null && blnHasFillingControl)
                {
                    // Render mdi client.
                    objMdiClient.RenderControl(objContext, objWriter, lngRequestID);
                }
            }

            // Call base controls render
            base.RenderControls(objContext, objWriter, lngRequestID);

            if (objProxyComponent == null)
            {
                // Check if an mdi client has been found.
                if (objMdiClient != null && !blnHasFillingControl)
                {
                    // Render mdi client.
                    objMdiClient.RenderControl(objContext, objWriter, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Renders the form header control
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        private void RenderHeader(Control objHeader, IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Set the header's docking to top, render it and then return its docking back to it original value.
            DockStyle enmOriginalDockStyle = objHeader.Dock;
            AnchorStyles enmOriginalAnchorStyle = objHeader.Anchor;

            // Set the header docking to top
            objHeader.Dock = DockStyle.Top;

            // Render the component 
            ((IRenderableComponent)objHeader).RenderComponent(objContext, objWriter, lngRequestID);

            // Return the docking and anchoring back to the original values
            objHeader.Dock = enmOriginalDockStyle;
            objHeader.Anchor = enmOriginalAnchorStyle;
        }

        /// <summary>
        /// Renders the child forms.
        /// </summary>
        /// <param name="objContext">context.</param>
        /// <param name="objWriter">writer.</param>
        /// <param name="lngRequestID">last updated marker.</param>
        internal void RenderForms(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // loop all child forms
            Form[] arrOwnedForms = OwnedForms;
            foreach (Form objForm in arrOwnedForms)
            {
                // If the form is not top level, it will be drawened as a control of its container.
                if (objForm.TopLevel || objForm.MdiParent != null)
                {
                    // render child window
                    objForm.RenderControl(objContext, objWriter, lngRequestID);
                }
            }
        }

        #endregion

        #region Controls

        /// <summary>
        ///  Gets or sets the MainMenu that is displayed in the form.  
        /// </summary>
        public MainMenu Menu
        {
            get
            {
                // Returns a value form property store.
                return this.GetValue<MainMenu>(Form.MenuProperty);
            }
            set
            {
                // Get the main menu
                MainMenu objOldMainMenu = this.Menu;

                // Set new main menu in propertyStore 
                if (this.SetValue<MainMenu>(Form.MenuProperty, value))
                {
                    //unregister menu if exists
                    if (objOldMainMenu != null)
                    {
                        this.UnRegisterComponent(((IRegisteredComponent)objOldMainMenu));
                    }

                    if (value != null)
                    {
                        // Set new main menu properties
                        value.Dock = DockStyle.Top;

                        // Set the internal parent as this form
                        value.InternalParent = this;

                        //Register new main menu 
                        this.RegisterComponent(((IRegisteredComponent)value));
                    }

                    // Update form to reflect changes
                    Update();
                }
            }
        }

        /// <summary>Gets or sets the primary menu container for the form.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGui.Forms.MenuStrip"></see> that represents the container for the menu structure of the form. The default is null.</returns>
        [SRCategory("CatWindowStyle"), TypeConverter(typeof(ReferenceConverter)), DefaultValue((string)null), SRDescription("FormMenuStripDescr")]
        public MenuStrip MainMenuStrip
        {
            get
            {
                // Returns a value form property store.
                return this.GetValue<MenuStrip>(Form.MainMenuStripProperty);
            }
            set
            {
                // Get the main menu
                MenuStrip objPreviousMenuStrip = this.MainMenuStrip;

                // Set new main menu in propertyStore 
                if (this.SetValue<MenuStrip>(Form.MainMenuStripProperty, value))
                {
                    // Unregister menu if exists
                    if (objPreviousMenuStrip != null)
                    {
                        this.UnRegisterComponent(((IRegisteredComponent)objPreviousMenuStrip));
                    }

                    if (value != null)
                    {
                        // Set the internal parent as this form
                        value.InternalParent = this;

                        //Register new main menu 
                        this.RegisterComponent(((IRegisteredComponent)value));
                    }

                    // Update form to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the client storage.
        /// </summary>
        /// <value>
        /// The client storage.
        /// </value>
        [SRCategory("Client"), TypeConverter(typeof(ReferenceConverter)), DefaultValue((string)null), SRDescription("ClientStorageDescr")]
        public ClientStorage ClientStorage
        {
            get
            {
                // Returns a value form property store.
                return this.GetValue<ClientStorage>(Form.ClientStorageProperty);
            }
            set
            {
                // Get the main menu
                ClientStorage objClientStorage = this.ClientStorage;

                // Set new main menu in propertyStore 
                if (this.SetValue<ClientStorage>(Form.ClientStorageProperty, value))
                {
                    // Update form to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// A data which defines the geographic location services.
        /// </summary>
        /// <value>
        /// The geo location.
        /// </value>
        [Category("Misc"), Description("A data which defines the geographic location services.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GeoLocationData GeographicLocation
        {
            get
            {
                return this.GetValue<GeoLocationData>(Form.GeoLocationDataProperty);
            }
            set
            {
                if (this.SetValue<GeoLocationData>(Form.GeoLocationDataProperty, value))
                {
                    // Flag that geo-location information is dirty.
                    this.UpdateParams(AttributeType.GeographicLocation);
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the control collection for the control.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"/> assigned to the control.
        /// </returns>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new ControlCollection(this);
        }


        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="objTarget">The obj target.</param>
        /// <param name="strMember">The STR member.</param>
        /// <param name="arrArgs">The arr args.</param>
        internal void InvokeMethod(Component objTarget, string strMember, object[] arrArgs)
        {
            IContextMethodInvoker objInvoker = Context as IContextMethodInvoker;
            if (objInvoker != null)
            {
                objInvoker.InvokeMethod(objTarget as ISkinable, InvokationUniqueness.None, strMember, arrArgs);
            }
        }


        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            Type objOffspringType = Type.GetType(strOffspringTypeName);
            if (objOffspringType != null)
            {
                if (CommonUtils.IsTypeOrSubType(objOffspringType, typeof(MainMenu)))
                {
                    List<MainMenu> objList = new List<MainMenu>();
                    objList.Add(this.Menu);
                    return objList;
                }
            }

            return base.GetComponentOffsprings(strOffspringTypeName);
        }


        #endregion

        #region Owned Forms

        /// <summary>
        /// Closes this window.
        /// </summary>
        public void Close()
        {
            Close(false, false, false);
        }

        /// <summary>
        /// Closes this window.
        /// </summary>
        /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
        /// <param name="blnSuspendCloseEvent">if set to <c>true</c> - came from visible
        /// the closed event shouldn't be raised.</param>
        /// <param name="blnFormOwnerClosing">if set to <c>true</c> [BLN form owner closing].</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool Close(bool blnClientSource, bool blnSuspendCloseEvent, bool blnFormOwnerClosing)
        {
            if (!this.GetState(FormState.IsClosed))
            {
                // A flag indicating if closing process is not canceled
                bool blnClosing = true;

                CloseReason objCloseReason;

                // Check if owner has caused this close.
                if (blnFormOwnerClosing)
                {
                    objCloseReason = CloseReason.FormOwnerClosing;
                }
                // Check if this is mdi child.
                else if (this.IsMdiChild)
                {
                    objCloseReason = CloseReason.MdiFormClosing;
                }
                else
                {
                    objCloseReason = CloseReason.UserClosing;
                }

                // Check if close event should be suspend
                if (!blnSuspendCloseEvent)
                {
                    // Before closing 
                    if (ClosingHandler != null || FormClosingHandler != null)
                    {
                        // Create the Closing and FormClosing cancel event arguments
                        FormClosingEventArgs e = new FormClosingEventArgs(objCloseReason, false);
                        CancelEventArgs objCancelEventArgs = new CancelEventArgs(false);

                        // Raise Closing and FormClosing
                        this.OnClosing(objCancelEventArgs);
                        this.OnFormClosing(e);

                        // If Closing or FormClosing was canceled
                        if (e.Cancel || objCancelEventArgs.Cancel)
                        {
                            if (this.DialogType == DialogTypes.PopupWindow)
                            {
                                throw new Exception("Closing popup windows cannot be cancelled");
                            }
                            return false;
                        }
                    }
                }

                // Close all child forms
                Form[] arrOwnedForms = OwnedForms;
                if (arrOwnedForms.Length > 0)
                {
                    foreach (Form objChildForm in arrOwnedForms)
                    {
                        blnClosing &= objChildForm.Close(blnClientSource, blnSuspendCloseEvent, true);
                    }
                }

                // If closing is canceled and is client source
                if (!blnClosing && blnClientSource)
                {
                    // If a child has refused closing
                    this.Update();

                    return false;
                }

                // If its modal window and the dialog result is none (default) 
                // then change it to Cancel
                if (objCloseReason == CloseReason.UserClosing &&
                    this.Modal &&
                    this.DialogResult == DialogResult.None)
                {
                    this.DialogResult = DialogResult.Cancel;
                }

                // Recursivly reset the created flag for this control and all of it's childrens.
                this.ResetCreatedFlag();

                // If this Form has a parent control
                Control objParentControl = this.Parent;
                if (objParentControl != null)
                {
                    // Remove this form from its parent.
                    objParentControl.Controls.Remove(this);
                }

                // Unregister form for navitation
                ((IFormResolver)this.Context).UnRegisterForm(this);

                // If there is an owner form
                Form objOwnerForm = this.Owner;
                if (objOwnerForm != null)
                {
                    // Check if this form is active.
                    if (this.Context.ActiveForm == this)
                    {
                        // If we close popup then active form should be the owner form
                        if (this.DialogType == DialogTypes.PopupWindow)
                        {
                            // Activate owner form
                            this.Context.ActiveForm = objOwnerForm;
                        }
                        else
                        {
                            // Gets the top most owned form.
                            Form objTopMostOwnedForm = objOwnerForm.GetTopMostOwnedForm(this);
                            if (objTopMostOwnedForm != null)
                            {
                                // Activate top most owner form.
                                this.Context.ActiveForm = objTopMostOwnedForm;
                            }
                        }

                        // Deactivate this form.
                        this.Active = false;

                        // Check if context active form is not equal to this form.
                        if (this.Context.ActiveForm != this)
                        {
                            // Set context active form as active
                            this.Context.ActiveForm.Active = true;
                        }
                    }

                    // Remove this form from its owner.
                    objOwnerForm.RemoveForm(this, blnSuspendCloseEvent);

                }
                else
                {
                    this.FireClosed();

                    FormClosedEventArgs objFormClosedEventArgs = new FormClosedEventArgs(CloseReason.UserClosing);
                    this.FireFormClosed(objFormClosedEventArgs);
                }

                // If modality is active
                if (this.GetState(FormState.IsModalActive))
                {
                    // Get the threading service
                    IContextThreadingService objThreadingService = this.Context.GetThreadingService();

                    // If there is a valid threading service
                    if (objThreadingService != null)
                    {
                        // Realease this dialog
                        objThreadingService.ReleaseDialog(this);
                    }

                    // Indicate that modal is active
                    this.SetState(FormState.IsModalActive, false);
                }

                // Flag the this form is closed.
                this.SetState(FormState.IsClosed, true);
            }


            IContextParams objContextParams = this.Context as IContextParams;
            if (objContextParams != null)
            {
                // Try to get the main emulator form.
                IEmulatorForm objEmulatorForm = objContextParams.EmulatorForm;
                if (objEmulatorForm != null)
                {
                    objEmulatorForm.OnFormClosed(this);
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the top most owned form.
        /// </summary>
        /// <param name="objExcludedOwnedForm">The excluded form.</param>
        /// <returns></returns>
        private Form GetTopMostOwnedForm(Form objExcludedOwnedForm)
        {
            // Define a top most owned form as this form (if this form should not be excluded).
            Form objTopMostOwnedForm = (this != objExcludedOwnedForm ? this : null);

            // Get owned forms.
            Form[] arrOwnedForms = this.OwnedForms;

            // Validate owned forms array.
            if (arrOwnedForms != null && arrOwnedForms.Length > 0)
            {
                // Loop all owned forms - in reverse.
                for (int intFormIndex = arrOwnedForms.Length - 1; intFormIndex >= 0; intFormIndex--)
                {
                    // Get current owned form.
                    Form objOwnedForm = arrOwnedForms[intFormIndex];
                    if (objOwnedForm != null)
                    {
                        // Check that current owned form should not be excluded.
                        if (objOwnedForm != objExcludedOwnedForm && objOwnedForm.TopLevel)
                        {
                            // Try getting current owned form's top most owned form.
                            Form objOwnedFormTopMostOwnedForm = objOwnedForm.GetTopMostOwnedForm(objExcludedOwnedForm);
                            if (objOwnedFormTopMostOwnedForm != null)
                            {
                                // Presere the top most owned form.
                                objTopMostOwnedForm = objOwnedFormTopMostOwnedForm;
                                break;
                            }
                        }
                    }
                }
            }

            // Return the top most owned form.
            return objTopMostOwnedForm;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public DialogResult ShowDialog(Form objForm)
        {
            return this.ShowDialog(objForm, null);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="objForm">The obj form.</param>
        /// <param name="objClosedDelegate">The obj closed delegate.</param>
        /// <returns></returns>
        public DialogResult ShowDialog(Form objForm, EventHandler objClosedDelegate)
        {
            return this.ShowDialog(objForm, DialogTypes.ModalWindow, objClosedDelegate);
        }

        /// <summary>
        /// Shows the specified obj closed delegate.
        /// </summary>
        /// <param name="objClosedDelegate">The obj closed delegate.</param>
        public void Show(EventHandler objClosedDelegate)
        {
            if (this.Context.Config.IsFeatureEnabled("ModalWindows", false))
            {
                ShowDialog(DialogTypes.ModalWindow, objClosedDelegate);
            }
            else
            {
                ShowDialog(DialogTypes.ModalessWindow, objClosedDelegate);
            }
        }

        /// <summary>
        /// Shows the specified obj owner.
        /// </summary>
        /// <param name="objOwner">The obj owner.</param>
        /// <param name="objClosedDelegate">The obj closed delegate.</param>
        public void Show(IWin32Window objOwner, EventHandler objClosedDelegate)
        {
            // Try casting IWin32Window to a form.
            Form objOwnerForm = objOwner as Form;
            if (objOwnerForm != null)
            {
                // Show dialog base on recieved IWin32Window.
                this.ShowDialog(objOwnerForm, objClosedDelegate);
            }
            else
            {
                // Try casting IWin32Window to a control.
                Control objOwnerControl = objOwner as Control;
                if (objOwnerControl != null)
                {
                    // Try get control's form.
                    objOwnerForm = objOwnerControl.Form;
                    if (objOwnerForm != null)
                    {
                        // Show dialog base on recieved conrtol's form.
                        this.ShowDialog(objOwnerForm, objClosedDelegate);
                    }
                    else
                    {
                        // Execute default show.
                        this.Show(objClosedDelegate);
                    }
                }
            }
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public override void Show()
        {
            this.Show(null as EventHandler);
        }

        /// <summary>
        /// Shows the specified owner.
        /// </summary>
        /// <param name="objOwner">The owner.</param>
        public void Show(IWin32Window objOwner)
        {
            this.Show(objOwner, null);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="objOwnerForm">The obj owner form.</param>
        /// <param name="enmDialogType">Type of the enm dialog.</param>
        /// <param name="objClosedDelegate">The obj closed delegate.</param>
        /// <returns></returns>
        private DialogResult ShowDialog(Form objOwnerForm, DialogTypes enmDialogType, EventHandler objClosedDelegate)
        {
            if (objClosedDelegate != null)
            {
                // Preserve a local closed delegate.
                this.ClosedDelegate = objClosedDelegate;

            }

            // Loop all of this form's siblings and close the one which are popup.
            if (enmDialogType == DialogTypes.PopupWindow)
            {
                if (objOwnerForm != null)
                {
                    ArrayList objForms = new ArrayList(objOwnerForm.OwnedFormsCollection);

                    for (int intIndex = objForms.Count - 1; intIndex >= 0; intIndex--)
                    {
                        Form objChild = objForms[intIndex] as Form;
                        if (objChild != null && objChild.DialogType == DialogTypes.PopupWindow)
                        {
                            objChild.Close();
                        }
                    }
                }
            }

            // Clear dialog result old value
            this.DialogResult = DialogResult.None;

            // Check if this form is closed.
            bool blnIsFormClosed = this.GetState(FormState.IsClosed);

            // If owner form is not self
            if (objOwnerForm != this)
            {
                // If verbose tracing is enabled
                if (CommonSwitches.TraceVerbose)
                {
                    VerboseRecord.Write(this, "Server/Actions", "ShowDialog", "Shows the currnet dialog in a " + enmDialogType.ToString() + " style.");
                }

                this.DialogType = enmDialogType;

                // Check if this form is a top-level form or MDI child.
                if (this.TopLevel || this.IsMdiChild)
                {
                    // Ensure that owner form does not contain this form.
                    if (!objOwnerForm.OwnedFormsCollection.Contains(this))
                    {
                        // add the current child 
                        objOwnerForm.OwnedFormsCollection.Add(this);
                    }
                }

                // Check if a none modal window.
                if (enmDialogType != DialogTypes.ModalWindow)
                {
                    //get the current mdi parent
                    Form objMdiParent = objOwnerForm.MdiParent;
                    if (objMdiParent != null)
                    {
                        this.MdiParent = objMdiParent;
                    }
                }

                // update the child window
                Update();

                // register this form
                RegisterSelf();

                // Initialize the CalledOnLoad flag. 
                this.CalledOnLoad = false;

                // Initialize the CalledMakeVisible flag. 
                this.CalledMakeVisible = false;

                // Set form visible
                this.InternalVisible = true;

                // Check that this form was not closed during load event.
                if (blnIsFormClosed || !this.GetState(FormState.IsClosed))
                {
                    // Create form control
                    this.CreateControl();

                    // Check if this form has no parent.
                    if (this.Parent == null)
                    {
                        // Set ActivateOnShow flag
                        this.ActivateOnShow = true;
                    }
                }
            }

            // Register form for navitation
            ((IFormResolver)this.Context).RegisterForm(this);

            // Check that this form was not closed during load event.
            if (blnIsFormClosed || !this.GetState(FormState.IsClosed))
            {
                // If is a modal window 
                if (enmDialogType == DialogTypes.ModalWindow)
                {
                    // Indicate that modal is active
                    this.SetState(FormState.IsModalActive, true);

                    // Get the context threading service
                    IContextThreadingService objContextThreadingService = this.Context.GetThreadingService();

                    // If there is a valid context threading service
                    if (objContextThreadingService != null)
                    {
                        // Get current request proccessing state.
                        RequestProcessingState enmRequestProcessingState = this.Context.RequestProcessingState;

                        switch (enmRequestProcessingState)
                        {
                            case RequestProcessingState.PostRrenderResponse:
                            case RequestProcessingState.PreRenderResponse:
                            case RequestProcessingState.RenderResponse:

                                // Unregister form for navitation
                                ((IFormResolver)this.Context).UnRegisterForm(this);

                                throw new Exception(string.Format("Cannot perform modal dialog emulation through {0} state.", enmRequestProcessingState.ToString()));
                            default:
                                // Get the dialog result
                                objContextThreadingService.GetDialogResult(this);
                                break;
                        }
                    }
                }

                // Flag that form is not closed.
                this.SetState(FormState.IsClosed, false);
            }

            IContextParams objContextParams = this.Context as IContextParams;
            if (objContextParams != null)
            {
                // Try to get the main emulator form.
                IEmulatorForm objEmulatorForm = objContextParams.EmulatorForm;
                if (objEmulatorForm != null)
                {
                    objEmulatorForm.OnFormShowed(this);
                }
            }

            // Return the default value
            return this.DialogResult;
        }

        /// <summary>
        /// Pre-render control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
        {
            // Check if we need to set form as active form
            if (this.ActivateOnShow)
            {
                // Clear ActivateOnShow flag
                this.ActivateOnShow = false;

                // Activate form
                this.ActivateForm(false);
            }

            base.PreRenderControl(objContext, lngRequestID);
        }

        /// <summary>
        /// Activates the form.
        /// </summary>
        /// <param name="blnUpdatePosition">if set to <c>true</c> [BLN update position].</param>
        internal void ActivateForm(bool blnUpdatePosition)
        {
            // Check if position should be updated.
            if (blnUpdatePosition)
            {
                // Validate owner.
                if (this.Owner != null)
                {
                    // Check if this form index is less then the last form in the owner's form collectin.
                    if (this.Owner.OwnedFormsCollection.IndexOf(this) < this.Owner.OwnedFormsCollection.Count - 1)
                    {
                        // Set this form's position to last.
                        this.Owner.OwnedFormsCollection.SetFormPosition(this, this.Owner.OwnedFormsCollection.Count - 1);
                    }
                }
            }

            // Get current active form
            IForm objCurrentActiveForm = this.Context.ActiveForm;

            // Check if this form is not defined as the active form.
            if (objCurrentActiveForm != this)
            {
                if (objCurrentActiveForm != null)
                {
                    // Set the active form as deactivated.
                    objCurrentActiveForm.Active = false;
                }

                // Define this form as the active form. 
                this.Context.ActiveForm = this;
            }

            // Check the active property.
            if (!this.Active)
            {
                // Set the active property to a true value.
                this.Active = true;
            }
        }

        /// <summary>
        /// Occurs when control is created
        /// </summary>
        protected override void OnCreateControl()
        {
            this.CalledCreateControl = true;
            base.OnCreateControl();

            // check control is registered
            RegisterSelf();

            // If verbose tracing is enabled
            if (CommonSwitches.TraceVerbose)
            {
                VerboseRecord.Write(this, "Server/Events", "Load", "Invoking event handler.");
            }

            // Get trace time
            long lngTimeMarker = DateTime.Now.Ticks;

            if (this.CalledMakeVisible && !this.CalledOnLoad)
            {
                this.CalledOnLoad = true;
                this.OnLoad(EventArgs.Empty);
            }

            // if tracing is enabled
            if (CommonSwitches.TraceEnabled && CommonSwitches.TraceInfo)
            {
                TraceRecord.Write(new EventTraceRecord("Load", this, lngTimeMarker));
            }
        }


        /// <summary>
        /// </summary>
        /// <returns></returns>
        internal override bool CanSelectCore()
        {
            return ((base.GetStyle(ControlStyles.Selectable) && base.Enabled) && base.Visible);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="objClosedDelegate">The obj closed delegate.</param>
        /// <returns></returns>
        public virtual DialogResult ShowDialog(EventHandler objClosedDelegate)
        {
            return ShowDialog(DialogTypes.ModalWindow, objClosedDelegate);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns></returns>
        public virtual DialogResult ShowDialog()
        {
            return ShowDialog(DialogTypes.ModalWindow, null);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="enmDialogTypes">The enm dialog types.</param>
        /// <param name="objClosedDelegate">The obj closed delegate.</param>
        /// <returns></returns>
        private DialogResult ShowDialog(DialogTypes enmDialogTypes, EventHandler objClosedDelegate)
        {
            DialogResult enmDialogResult = DialogResult.None;

            // Check if a none top level form is being shown as modal window.
            if (enmDialogTypes == DialogTypes.ModalWindow && !this.TopLevel)
            {
                throw new InvalidOperationException(SR.GetString("ShowDialogOnNonTopLevel", new object[] { "Show" }));
            }

            // Define an empty owner form.
            Form objOwnerForm = null;

            // Try get the mdi parent.
            Form objFormMdiParent = this.MdiParent;
            if (objFormMdiParent != null)
            {
                // In case of modaless form.
                if (enmDialogTypes == DialogTypes.ModalessWindow)
                {
                    // Set mdi parent as owner.
                    objOwnerForm = objFormMdiParent;
                }
            }
            // In case of none modaless form.
            else if (enmDialogTypes != DialogTypes.ModalessWindow)
            {
                // Gets the owner form for a new dialog.
                objOwnerForm = GetOwnerForm(enmDialogTypes);
            }

            // If has an valid owner.
            if (objOwnerForm != null)
            {
                // Open as dialog.
                enmDialogResult = ShowDialog(objOwnerForm, enmDialogTypes, objClosedDelegate);
            }
            else
            {
                if (this.Created && this.Owner != null &&
                    this.Context != null && this.Context is IContextMethodInvoker)
                {
                    // Invoke script that will locate this form on top.
                    ((IContextMethodInvoker)this.Context).InvokeMethod(this, InvokationUniqueness.Component, "Forms_BringWindowToTop", this.ID);

                    // Set form's position to last.
                    this.Owner.OwnedFormsCollection.SetFormPosition(this, this.Owner.OwnedFormsCollection.Count - 1);
                }

                // Try getting a main form.
                Form objMainForm = this.Context.MainForm as Form;
                if (objMainForm != null)
                {
                    // Open as dialog with main form as owner.
                    enmDialogResult = ShowDialog(objMainForm, enmDialogTypes, objClosedDelegate);
                }
                else
                {
                    // Set current form as active and main form
                    this.Context.MainForm = this;
                    this.Context.ActiveForm = this;

                    // Create the form control
                    this.CreateControl();

                    // Raise event if needed
                    EventHandler objEventHandler = this.ActivatedHandler;
                    if (objEventHandler != null)
                    {
                        objEventHandler(this, new EventArgs());
                    }
                }

            }

            return enmDialogResult;
        }

        /// <summary>
        /// Shows a the form as a dialog.
        /// </summary>
        private DialogResult ShowDialog(DialogTypes enmDialogTypes)
        {
            return this.ShowDialog(enmDialogTypes, null);
        }

        /// <summary>
        /// Gets an owner form for a newly created form.
        /// </summary>
        /// <param name="enmNewDialogTypes">The enm new dialog types.</param>
        /// <returns></returns>
        private Form GetOwnerForm(DialogTypes enmNewDialogTypes)
        {
            // Get active form.
            Form objOwnerForm = this.Context.ActiveForm as Form;
            if (objOwnerForm != null)
            {
                // In case that a none popup window is being shown and the active form is a popup window.
                if (enmNewDialogTypes != DialogTypes.PopupWindow &&
                    objOwnerForm.DialogType == DialogTypes.PopupWindow)
                {
                    // Preserve a reference to the popup window.
                    Form objPopupForm = objOwnerForm;

                    // Loops inorder to find the first popup owner form.
                    while (objPopupForm != null &&
                            objPopupForm.Owner != null &&
                            objPopupForm.Owner.DialogType == DialogTypes.PopupWindow)
                    {
                        objPopupForm = objPopupForm.Owner;
                    }

                    // Validate that the popup window is not empty.
                    if (objPopupForm != null)
                    {
                        // Check if the popup window has an owner form.
                        if (objPopupForm.Owner != null)
                        {
                            // Set the popup's owner form as the active form.
                            this.Context.ActiveForm = objOwnerForm = objPopupForm.Owner;
                        }

                        // Close popup window.
                        objPopupForm.Close();
                    }
                }
                else
                {
                    // Try getting owner's top most owned modal form.
                    Form objOwnerTopMostOwnedModalForm = objOwnerForm.TopMostOwnedModalForm;
                    if (objOwnerTopMostOwnedModalForm != null)
                    {
                        // Set the active form for new dialog
                        objOwnerForm = objOwnerTopMostOwnedModalForm;
                    }
                }
            }

            return objOwnerForm;
        }

        /// <summary>
        /// Displays the form as a popup window.
        /// </summary>
        public DialogResult ShowPopup()
        {
            this.DialogAlignment = DialogAlignment.None;
            mobjAligmentComponent = null;
            mobjAlignmentMemberComponent = null;

            return ShowDialog(DialogTypes.PopupWindow);
        }

        /// <summary>
        /// Displays the form as a popup window.
        /// </summary>
        public DialogResult ShowPopup(Form objForm)
        {
            this.DialogAlignment = DialogAlignment.None;
            mobjAligmentComponent = null;
            mobjAlignmentMemberComponent = null;

            return ShowDialog(objForm, DialogTypes.PopupWindow, null);
        }

        /// <summary>
        /// Displays the form as a popup window.
        /// </summary>
        public DialogResult ShowPopup(Component objComponent)
        {
            return ShowPopup(objComponent, DialogAlignment.Below);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objComponent"></param>
        /// <param name="enmAlignment"></param>
        /// <returns></returns>
        public DialogResult ShowPopup(Component objComponent, DialogAlignment enmAlignment)
        {
            return ShowPopup(objComponent, null, enmAlignment);
        }

        /// <summary>
        /// Used by combobox
        /// </summary>
        /// <param name="objForm"></param>
        /// <param name="objComponent">IRegisteredComponent</param>
        /// <param name="enmAlignment">DialogAlignment</param>
        /// <returns></returns>
        public DialogResult ShowPopup(Form objForm, IRegisteredComponent objComponent, DialogAlignment enmAlignment)
        {
            // Set alignment
            this.DialogAlignment = enmAlignment;

            // Set alignment component.
            this.mobjAligmentComponent = objComponent;
            this.mobjAlignmentMemberComponent = null;

            return ShowDialog(GetValidOwnerForm(objForm), DialogTypes.PopupWindow, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objForm"></param>
        /// <param name="objComponent">IRegisteredComponentMember</param>
        /// <param name="enmAlignment">DialogAlignment</param>
        /// <returns></returns>
        public DialogResult ShowPopup(Form objForm, IRegisteredComponentMember objComponent, DialogAlignment enmAlignment)
        {
            // Set alignment
            this.DialogAlignment = enmAlignment;

            // Set alignment component.
            this.mobjAligmentComponent = objComponent;
            this.mobjAlignmentMemberComponent = null;

            return ShowDialog(objForm, DialogTypes.PopupWindow, null);
        }

        /// <summary>
        /// Displays the form as a popup window.
        /// </summary>
        public DialogResult ShowPopup(Component objSourceComponent, IIdentifiedComponent objMemberComponent, DialogAlignment enmAlignment)
        {
            // Set alignment
            this.DialogAlignment = enmAlignment;

            // Set alignment components.
            this.mobjAligmentComponent = objSourceComponent;
            this.mobjAlignmentMemberComponent = objMemberComponent;

            // Show popup with a proper owner form.
            return ShowDialog(GetValidOwnerForm(objSourceComponent.Form), DialogTypes.PopupWindow, null);
        }

        /// <summary>
        /// Gets the valid owner form.
        /// </summary>
        /// <param name="objOwnerForm">The owner form.</param>
        /// <returns></returns>
        internal static Form GetValidOwnerForm(Form objOwnerForm)
        {
            // Loops while owner form is not top level.
            while (objOwnerForm != null && !objOwnerForm.TopLevel && !objOwnerForm.IsMdiChild)
            {
                // Get owner form internal parent.
                Component objParent = objOwnerForm.InternalParent;
                if (objParent != null)
                {
                    // Get parent's form.
                    objOwnerForm = objParent.Form;
                }
                else
                {
                    // Set null owner form so that loop will be break.
                    objOwnerForm = null;
                }
            }

            return objOwnerForm;
        }

        /// <summary>Removes an owned form from this form.</summary>
        /// <param name="objOwnedForm">A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> representing the form to remove from the list of owned forms for this form. </param>
        /// <filterpriority>1</filterpriority>
        public void RemoveOwnedForm(Form objOwnedForm)
        {
            if (objOwnedForm != null)
            {
                if (objOwnedForm.OwnerInternal != null)
                {
                    objOwnedForm.Owner = null;
                }
                else
                {
                    Form[] arrSource = this.OwnedForms;
                    int integer = this.OwnedFormsCollection.Count;
                    if (arrSource != null)
                    {
                        for (int i = 0; i < integer; i++)
                        {
                            if (objOwnedForm.Equals(arrSource[i]))
                            {
                                arrSource[i] = null;
                                if ((i + 1) < integer)
                                {
                                    Array.Copy(arrSource, i + 1, arrSource, i, (integer - i) - 1);
                                    arrSource[integer - 1] = null;
                                }
                                integer--;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Adds an owned form to this form.</summary>
        /// <param name="objOwnedForm">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that this form will own. </param>
        /// <filterpriority>1</filterpriority>
        public void AddOwnedForm(Form objOwnedForm)
        {
            if (objOwnedForm != null)
            {
                if (objOwnedForm.OwnerInternal != this)
                {
                    objOwnedForm.Owner = this;
                }
                else
                {
                    // Get owned forms collection.
                    FormCollection objOwnedFormsCollection = this.OwnedFormsCollection;
                    if (objOwnedFormsCollection != null)
                    {
                        // Check if new owned form is not allready contained in owned forms collection.
                        if (!objOwnedFormsCollection.Contains(objOwnedForm))
                        {
                            // Add new owned form to owned forms collection.
                            objOwnedFormsCollection.Add(objOwnedForm);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the visible core.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
        protected override void SetVisibleCore(bool blnValue)
        {
            // Get visible state
            bool blnVisibleCore = GetVisibleCore();

            // Get DialogResult
            DialogResult enmDialogResult = this.DialogResult;

            if ((blnVisibleCore != blnValue) || (enmDialogResult != DialogResult.OK))
            {
                if ((blnVisibleCore == blnValue) && (!blnValue || this.CalledMakeVisible))
                {
                    base.SetVisibleCore(blnValue);
                }
                else
                {
                    if (blnValue)
                    {
                        this.CalledMakeVisible = true;
                        if (this.CalledCreateControl)
                        {
                            if (!this.CalledOnLoad)
                            {
                                this.CalledOnLoad = true;
                                this.OnLoad(EventArgs.Empty);
                                if (enmDialogResult != DialogResult.None)
                                {
                                    blnValue = false;
                                }
                            }
                        }
                    }

                    base.SetVisibleCore(blnValue);

                    if (blnValue)
                    {
                        if (!this.IsMdiChild && ((this.WindowState == FormWindowState.Maximized) || this.TopMost))
                        {
                            // Check if active control is null.
                            if (base.ActiveControl == null)
                            {
                                // Select next active control.
                                base.SelectNextControlInternal(null, true, true, true, false);

                                // Focus active control.
                                base.FocusActiveControlInternal();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes a form.
        /// </summary>
        /// <param name="objForm">Form.</param>
        /// <param name="blnSuspendCloseEvent">if set to <c>true</c> [BLN suspend close event].</param>
        internal void RemoveForm(Form objForm, bool blnSuspendCloseEvent)
        {
            // unregister this window
            objForm.UnRegisterSelf();

            // Set invisible
            objForm.InternalVisible = false;

            // remove the current child
            OwnedFormsCollection.Remove(objForm);

            //If the form close came from setting a form as unvisible
            //the closed event shouldn't be raised
            if (!blnSuspendCloseEvent)
            {
                // Raise the closed event
                objForm.FireClosed();

                FormClosedEventArgs objFormClosedEventArgs = null;
                if (objForm.IsMdiChild)
                {
                    objFormClosedEventArgs = new FormClosedEventArgs(CloseReason.MdiFormClosing);
                }
                else
                {
                    objFormClosedEventArgs = new FormClosedEventArgs(CloseReason.FormOwnerClosing);
                }

                // Raise the FormClosed event
                objForm.FireFormClosed(objFormClosedEventArgs);
            }

            // Firing the close delegate event (Modality)
            objForm.FireClosedDelegate();

            // if the current form is the parent clear parent reference
            if (objForm.OwnerInternal == this)
            {
                // clear parent form
                objForm.OwnerInternal = null;
            }


        }

        /// <summary>
        /// Fires the closed delegate.
        /// </summary>
        private void FireClosedDelegate()
        {
            EventHandler objEventHandler = this.ClosedDelegate;

            if (objEventHandler != null)
            {
                this.ClosedDelegate = null;

                objEventHandler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fires the closed event.
        /// </summary>
        internal void FireClosed()
        {
            // Raise a close event if there are clients
            OnClosed(EventArgs.Empty);
        }

        /// <summary>
        /// Fires the form closed.
        /// </summary>
        /// <param name="objFormClosedEventArgs">The <see cref="Gizmox.WebGUI.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        internal void FireFormClosed(FormClosedEventArgs objFormClosedEventArgs)
        {
            // Raise a form close event if there are clients
            OnFormClosed(objFormClosedEventArgs);
        }

        /// <summary>
        /// Causes all of the child controls within a control that support validation to validate their data.
        /// </summary>
        /// <param name="validationConstraints">Tells <see cref="M:Gizmox.WebGui.Forms.ContainerControl.ValidateChildren(Gizmox.WebGui.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
        /// <returns>
        /// true if all of the children validated successfully; otherwise, false.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            return base.ValidateChildren(validationConstraints);
        }


        /// <summary>
        /// Orientations the change fired.
        /// Checking of current handlers and owned forms handlers.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal protected virtual void OnOrientationChanged(IEvent objEvent)
        {
            OrientationChangedEventHandler objEventHandler = this.OrientationChangedHandler;
            if (objEventHandler != null)
            {
                int intOrientation;
                if (int.TryParse(objEvent[WGAttributes.Orientation], out intOrientation))
                {
                    objEventHandler(this, new OrientationChangedEventArgs(intOrientation));
                }
                else
                {
                    objEventHandler(this, new OrientationChangedEventArgs(null));
                }

            }

            foreach (Form objOwnedForm in this.OwnedForms)
            {
                objOwnedForm.OnOrientationChanged(objEvent);
            }
        }
        #endregion

        #region Event Methods

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLoad(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.LoadHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Closed"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnClosed(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ClosedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:FormClosed"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnFormClosed(FormClosedEventArgs e)
        {
            // Terminates contained timers.
            this.TerminateRegisteredTimers();

            // Raise event if needed
            FormClosedEventHandler objEventHandler = this.FormClosedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.FormClosing"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.FormClosingEventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnFormClosing(FormClosingEventArgs e)
        {
            // Raise event if needed
            FormClosingEventHandler objEventHandler = this.FormClosingHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>
        /// Raises the <see cref="E:Closing"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnClosing(CancelEventArgs e)
        {
            // Raise event if needed
            CancelEventHandler objEventHandler = this.ClosingHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGui.Forms.Form.Activated"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnActivated(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.ActivatedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Afters the control removed.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="objOldParent">The old parent.</param>
        internal override void AfterControlRemoved(Control objControl, Control objOldParent)
        {
            base.AfterControlRemoved(objControl, objOldParent);
            if (objControl == this.AcceptButton)
            {
                this.AcceptButton = null;
            }
            if (objControl == this.CancelButton)
            {
                this.CancelButton = null;
            }
            if (objControl == this.MdiClient)
            {
                this.MdiClient = null;
            }
        }

        /// <devdoc>
        /// <para>Raises the Deactivate event.</para> 
        /// </devdoc>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDeactivate(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.DeactivateHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            Control objHeader = this.Header;
            MainMenu objMainMenu = this.Menu;

            // Register the Menu
            if (objMainMenu != null)
            {
                RegisterComponent(objMainMenu);
            }

            // Register the Header
            if (objHeader != null)
            {
                RegisterComponent(objHeader);
            }

        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            Control objHeader = this.Header;
            MainMenu objMainMenu = this.Menu;

            // Unregister the Menu
            if (objMainMenu != null)
            {
                UnRegisterComponent(objMainMenu);
            }

            // Unregister the Header
            if (objHeader != null)
            {
                UnRegisterComponent(objHeader);
            }
        }

        /// <summary>
        /// Performs the layout.
        /// </summary>
        /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
        protected internal override void PerformLayout(bool blnForceLayout)
        {
            // In case of layout forcing - perform layout on owned forms.
            if (blnForceLayout)
            {
                // Get owned forms.
                Form[] arrOwnedForms = this.OwnedForms;

                // Loop owned forms.
                foreach (Form objForm in arrOwnedForms)
                {
                    // Check that owned form has no parent.
                    if (objForm.Parent == null)
                    {
                        // Perform owned form layout.
                        objForm.PerformLayout(blnForceLayout);
                    }
                }
            }

            base.PerformLayout(blnForceLayout);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLocationChanged(LayoutEventArgs e)
        {
            base.OnLocationChanged(e);

            if (e.IsClientSource)
            {
                // Update state that the form has moved
                this.Moved = true;
            }
        }

        #endregion

        #endregion

        #region Properties


        /// <summary>
        /// Gets the initial size of the serializable filed storage.
        /// </summary>
        /// <value>The initial size of the serializable filed storage.</value>
        protected internal override int SerializableFieldStorageInitialSize
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Gets the form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.
        /// </summary>
        /// <returns>The form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.</returns>
        /// <value></value>
        internal ShortcutsContainer Shortcuts
        {
            get
            {
                //Get ShortcutsContainer from propertyStore
                ShortcutsContainer objShortcuts = this.GetValue<ShortcutsContainer>(Form.ShortcutsProperty);

                //Id not defined, create new and set at propertyStore
                if (objShortcuts == null)
                {
                    objShortcuts = new ShortcutsContainer();
                    objShortcuts.InternalParent = this;
                    this.SetValue<ShortcutsContainer>(Form.ShortcutsProperty, objShortcuts);
                }
                //Return the form ShortcutsContainer from propertyStore if existed and a new ShortcutsContainer otherwise.
                return objShortcuts;
            }
        }

        /// <summary>Gets or sets the current multiple document interface (MDI) parent form of this form.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that represents the MDI parent form.</returns>
        /// <exception cref="T:System.Exception">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is not marked as an MDI container.-or- The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is both a child and an MDI container form.-or- The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> assigned to this property is located on a different thread. </exception>
        [SRCategory("CatWindowStyle"), SRDescription("FormMDIParentDescr"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form MdiParent
        {
            get
            {
                return this.MdiParentInternal;
            }
            set
            {
                this.MdiParentInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the MDI parent internal.
        /// </summary>
        /// <value>The MDI parent internal.</value>
        private Form MdiParentInternal
        {
            get
            {
                return GetValue<Form>(Form.MdiParentProperty);
            }
            set
            {
                Form objMdiParentForm = this.MdiParentInternal;
                if ((value != objMdiParentForm) || ((value == null) && (this.ParentInternal != null)))
                {
                    bool blnVisibleState = base.Visible;
                    base.Visible = false;
                    try
                    {
                        if (value == null)
                        {
                            base.SetTopLevel(true);
                        }
                        else
                        {
                            if (this.IsMdiContainer)
                            {
                                throw new ArgumentException(SR.GetString("FormMDIParentAndChild"), "value");
                            }
                            if (!value.IsMdiContainer)
                            {
                                throw new ArgumentException(SR.GetString("MDIParentNotContainer"), "value");
                            }
                            this.Dock = DockStyle.None;
                            this.SetState(ControlState.TopLevel, false);
                            this.SetValue<Form>(Form.MdiParentProperty, value);
                        }
                    }
                    finally
                    {
                        base.Visible = blnVisibleState;
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is closed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is closed; otherwise, <c>false</c>.
        /// </value>
        bool IForm.IsClosed
        {
            get
            {
                return this.GetState(FormState.IsClosed);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is modal active.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is modal active; otherwise, <c>false</c>.
        /// </value>
        bool IForm.IsModalActive
        {
            get
            {
                return this.GetState(FormState.IsModalActive);
            }
        }

        /// <summary>Gets or sets the style of the size grip to display in the lower-right corner of the form.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.SizeGripStyle"></see> that represents the style of the size grip to display. The default is <see cref="F:System.Windows.Forms.SizeGripStyle.Auto"></see></returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is outside the range of valid values. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(SizeGripStyle.Auto), SRDescription("FormSizeGripStyleDescr"), SRCategory("CatWindowStyle")]
        public SizeGripStyle SizeGripStyle
        {
            get
            {
                return SizeGripStyle.Auto;
            }
            set
            { }
        }

        /// <summary>Gets or sets a value indicating whether right-to-left mirror placement is turned on.</summary>
        /// <returns>true if right-to-left mirror placement is turned on; otherwise, false for standard child control placement. The default is false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ControlRightToLeftLayoutDescr"), Localizable(true), DefaultValue(false), SRCategory("CatAppearance")]
        public virtual bool RightToLeftLayout
        {
            get
            {
                return false;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Common.Interfaces.IForm"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        bool IForm.Active
        {
            get
            {
                return this.Active;
            }
            set
            {
                this.Active = value;
            }
        }

        /// <summary>
        /// Gets the forms.
        /// </summary>
        /// <value>The forms.</value>
        IForm[] IForm.Forms
        {
            get
            {
                IForm[] arrForms = null;

                // Get the forms collection to an array
                FormCollection objForms = this.OwnedFormsCollection;
                if (objForms != null && objForms.Count > 0)
                {
                    arrForms = (IForm[])(new ArrayList(objForms)).ToArray(typeof(IForm));
                }

                return arrForms;
            }
        }

        /// <summary>
        /// Gets or sets the name associated with this control.
        /// </summary>
        /// <value></value>
        string IForm.Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the form main menu
        /// </summary>
        IMainMenu IForm.Menu
        {
            get
            {
                return this.Menu;
            }
            set
            {
                MainMenu objMainMenu = value as MainMenu;
                if (objMainMenu != null)
                {
                    this.Menu = objMainMenu;
                }
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGui.Forms.Control"></see> and its child controls and optionally releases the managed resources.
        /// </summary>
        void IForm.Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// Calculate size invluding borders
        /// </summary>
        [Browsable(false)]
        protected virtual bool IsWindowSized
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the form is a multiple document interface (MDI) child form.</summary>
        /// <returns>true if the form is an MDI child form; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("FormIsMDIChildDescr"), SRCategory("CatWindowStyle")]
        public bool IsMdiChild
        {
            get
            {
                return (this.MdiParent != null);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use WG namespace.
        /// </summary>
        /// <value><c>true</c> if to use WG namespace; otherwise, <c>false</c>.</value>
        internal override bool UseWGNamespace
        {
            get
            {
                return this.TopLevel;
            }
        }

        /// <summary>Gets or sets a value indicating whether the form is a container for multiple document interface (MDI) child forms.</summary>
        /// <returns>true if the form is a container for MDI child forms; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatWindowStyle"), SRDescription("FormIsMDIContainerDescr"), DefaultValue(false)]
        public bool IsMdiContainer
        {
            get
            {
                return this.MdiClient != null;
            }
            set
            {
                // If value is diffrent
                if (value != this.IsMdiContainer)
                {
                    if (value)
                    {
                        MdiClient objMdiClient = this.MdiClient = new MdiClient();
                        base.Controls.Add(objMdiClient);
                    }
                    else
                    {
                        if (this.IsMdiContainer)
                        {
                            base.Controls.Remove(this.MdiClient);
                            this.MdiClient = null;
                        }
                    }
                    base.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the form style.
        /// </summary>
        /// <value></value>
        public FormStyle FormStyle
        {
            get
            {
                // Get the value From PropertyStore
                return this.GetValue<FormStyle>(Form.FormStyleProperty);
            }
            set
            {
                // If value different from current value
                if (this.SetValue<FormStyle>(Form.FormStyleProperty, value))
                {
                    // Update the form to reflect changes
                    Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the entrance visual effect.
        /// </summary>
        /// <value>
        /// The entrance visual effect.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        [MergableProperty(false)]
        [SRCategory("CatAppearance"), SRDescription("EntranceEffectDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public VisualEffect EntranceEffect
        {
            get
            {
                return GetValue<VisualEffect>(Form.EntranceVisualEffectProperty, DefaultEntranceEffect);
            }
            set
            {
                if (SetValue<VisualEffect>(Form.EntranceVisualEffectProperty, value))
                {
                    this.UpdateParams(AttributeType.VisualEffect);
                }
            }
        }

        /// <summary>
        /// Determines whether to serialize the entrance effect.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeEntranceEffect()
        {
            return EntranceEffect != DefaultEntranceEffect;
        }

        /// <summary>
        /// Resets the entrance effect.
        /// </summary>
        private void ResetEntranceEffect()
        {
            EntranceEffect = DefaultEntranceEffect;
        }

        /// <summary>
        /// Gets or sets the exit visual effect.
        /// </summary>
        /// <value>
        /// The exit visual effect.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        [MergableProperty(false)]
        [SRCategory("CatAppearance"), SRDescription("ExitEffectDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public VisualEffect ExitEffect
        {
            get
            {
                return GetValue<VisualEffect>(Form.ExitVisualEffectProperty, DefaultExitEffect);
            }
            set
            {
                if (SetValue<VisualEffect>(Form.ExitVisualEffectProperty, value))
                {
                    this.UpdateParams(AttributeType.VisualEffect);
                }
            }
        }

        /// <summary>
        /// Determines whether to serialize the Exit effect.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeExitEffect()
        {
            return ExitEffect != DefaultExitEffect;
        }

        /// <summary>
        /// Resets the Exit effect.
        /// </summary>
        private void ResetExitEffect()
        {
            ExitEffect = DefaultExitEffect;
        }

        /// <summary>
        /// Gets the default exit effect.
        /// </summary>
        /// <value>
        /// The default exit effect.
        /// </value>
        protected virtual VisualEffect DefaultExitEffect
        {
            get
            {
                return new TranslateVisualEffect(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, null),
                new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100, null), 0.25m, 0, TransitionTimingFunction.EaseInOut);
            }
        }

        /// <summary>
        /// Gets the default entrance effect.
        /// </summary>
        /// <value>
        /// The default entrance effect.
        /// </value>
        protected virtual VisualEffect DefaultEntranceEffect
        {
            get
            {
                return new TranslateVisualEffect(new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 100, null),
                new AxisLengthAndUnits(LengthUnits.Percent, LengthUnits.Percent, 0, null), 0.25m, 0, TransitionTimingFunction.EaseInOut);
            }
        }

        /// <summary>
        /// Gets or sets the restored window state before it was minimized.
        /// </summary>
        /// <value>The last state of the form window.</value>
        private FormWindowState FormRestoredWindowState
        {
            get
            {
                return this.GetValue<FormWindowState>(Form.FormRestoredWindowStateProperty);
            }
            set
            {
                this.SetValue<FormWindowState>(Form.FormRestoredWindowStateProperty, value);
            }
        }

        /// <summary>
        /// Gets the size of a minimized form.
        /// </summary>
        /// <value>The size of a minimized form.</value>
        private Size FormMinimizedSize
        {
            get
            {
                Size objFormMinimizedSize = Size.Empty;

                if (this.MdiParent != null)
                {
                    // Get form skin.
                    FormSkin objFormSkin = SkinFactory.GetSkin(this, typeof(FormSkin)) as FormSkin;
                    if (objFormSkin != null)
                    {
                        // Get minimized mdi form size out of form skin.
                        objFormMinimizedSize = objFormSkin.MinimizedMdiFormSize;
                    }
                }
                else
                {
                    // Get task bar skin.
                    TaskBarSkin objTaskBarSkin = SkinFactory.GetSkin(this, typeof(TaskBarSkin)) as TaskBarSkin;
                    if (objTaskBarSkin != null)
                    {
                        // Build form's minimize size as for task bar item size.
                        objFormMinimizedSize = new Size(objTaskBarSkin.ItemWidth, objTaskBarSkin.ItemHeight);
                    }
                }

                return objFormMinimizedSize;
            }
        }

        /// <summary>
        /// Gets or sets the size of the form before it was maximized.
        /// </summary>
        /// <value>The size of the form restored.</value>
        private Size FormRestoredSize
        {
            get
            {
                return this.GetValue<Size>(Form.FormRestoredSizeProperty);
            }
            set
            {
                this.SetValue<Size>(Form.FormRestoredSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the location of the form before it was maximized.
        /// </summary>
        /// <value>The form restored location.</value>
        private Point FormRestoredLocation
        {
            get
            {
                return this.GetValue<Point>(Form.FormRestoredLocationProperty);
            }
            set
            {
                this.SetValue<Point>(Form.FormRestoredLocationProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the state of the window.
        /// </summary>
        /// <value></value>
        [DefaultValue(FormWindowState.Normal), SRDescription("FormWindowStateDescr"), SRCategory("CatLayout")]
        public FormWindowState WindowState
        {
            get
            {
                //Get FormWindowState from propertyStore
                return this.GetValue<FormWindowState>(Form.WindowStateProperty);
            }
            set
            {
                // Set window state.
                this.SetWindowState(value);
            }
        }

        /// <summary>
        /// Sets the state of the window.
        /// </summary>
        /// <param name="enmNewFormWindowState">New window state of the form.</param>
        private void SetWindowState(FormWindowState enmNewFormWindowState)
        {
            OnWindowStateChanged(enmNewFormWindowState);
        }

        /// <summary>
        /// Called when [window state changed].
        /// </summary>
        /// <param name="enmNewFormWindowState">State of the enm new form window.</param>
        protected virtual void OnWindowStateChanged(FormWindowState enmNewFormWindowState)
        {
            // Get current window state.
            FormWindowState enmCurrentFormWindowState = this.WindowState;

            // Check if window state had changed
            if (enmCurrentFormWindowState != enmNewFormWindowState)
            {
                if (this.Parent == null)
                {
                    // Check the new window state.
                    switch (enmNewFormWindowState)
                    {
                        case FormWindowState.Maximized:
                            // In case of maximizing from normal state.
                            if (enmCurrentFormWindowState == FormWindowState.Normal)
                            {
                                // Preserve restored sizes and positions.
                                this.FormRestoredSize = this.Size;
                                this.FormRestoredLocation = this.Location;
                            }

                            // Define a parent size.
                            Size objParentSize = Size.Empty;

                            // Check if this form has a valid mdi parent.
                            if (this.MdiParent != null)
                            {
                                // Get mdi parent's size.
                                objParentSize = this.MdiParent.Size;
                            }
                            // Validate context.
                            else if (this.Context != null)
                            {
                                // Try getting main form.
                                Form objMainForm = this.Context.MainForm as Form;
                                if (objMainForm != null)
                                {
                                    // Get main form size.
                                    objParentSize = objMainForm.Size;
                                }
                            }

                            // Validate calculated parent size.
                            if (objParentSize != Size.Empty)
                            {
                                // Set size as for parent size.
                                this.Size = objParentSize;
                            }

                            // Set location to top left corner.
                            this.Location = new Point(0, 0);

                            /* First we change the dimentions and then set the value - When in Maximized state the size/location cannot be changed due to logic in SetBounds method
                               and that is why we first set the value and then set the state */
                            this.SetValue<FormWindowState>(Form.WindowStateProperty, enmNewFormWindowState);
                            break;

                        case FormWindowState.Normal:
                            /* First we set the value and then update size/location - If we got here, it means that the state was previously Maximum or Minimum. In these states the size/location cannot be changed
                               due to logic in SetBounds method */
                            this.SetValue<FormWindowState>(Form.WindowStateProperty, enmNewFormWindowState);

                            // Validate restored size.
                            if (this.FormRestoredSize != Size.Empty)
                            {
                                // Set form's size.
                                this.Size = this.FormRestoredSize;

                                // Clear restored size.
                                this.FormRestoredSize = Size.Empty;
                            }

                            // Validate restored location.
                            if (this.FormRestoredLocation != Point.Empty)
                            {
                                // Set form's location.
                                this.Location = this.FormRestoredLocation;

                                // Clear restored location.
                                this.FormRestoredLocation = Point.Empty;
                            }
                            break;

                        case FormWindowState.Minimized:
                            // In case of minimizing from normal state.
                            if (enmCurrentFormWindowState == FormWindowState.Normal)
                            {
                                // Preserve restored sizes and positions.
                                this.FormRestoredSize = this.Size;
                                this.FormRestoredLocation = this.Location;
                            }

                            // Preserve previous window state so we will be able to restore it.
                            this.FormRestoredWindowState = enmCurrentFormWindowState;

                            // Set form size to its minimized size.
                            this.Size = this.FormMinimizedSize;

                            // Check if this form does not have a valid mdi parent.
                            if (this.MdiParent == null)
                            {
                                // Set location to top left corner.
                                this.Location = new Point(0, 0);
                            }

                            /* First we change the dimentions and then set the value - When in Minimized state the size/location cannot be changed due to logic in SetBounds method
                               and that is why we first set the value and then set the state */
                            this.SetValue<FormWindowState>(Form.WindowStateProperty, enmNewFormWindowState);

                            break;
                    }

                    // Update the control to reflect changes
                    this.UpdateParams(AttributeType.Redraw);
                }

                // Raise the window state changed
                FireObservableItemPropertyChanged("WindowState");
            }
        }

        /// <summary>
        /// Gets or sets the form border style.
        /// </summary>
        /// <value></value>
        [DefaultValue(FormBorderStyle.Sizable), SRCategory("CatAppearance"), SRDescription("FormBorderStyleDescr")]
        public FormBorderStyle FormBorderStyle
        {
            get
            {
                return this.GetValue<FormBorderStyle>(Form.FormBorderStyleProperty);
            }
            set
            {
                // Check if form border style had changed
                if (this.SetValue<FormBorderStyle>(Form.FormBorderStyleProperty, value))
                {
                    // Update the control to reflect changes
                    this.UpdateParams(AttributeType.Redraw);

                    // Raise the window state changed
                    FireObservableItemPropertyChanged("FormBorderStyle");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [minimize box].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [minimize box]; otherwise, <c>false</c>.
        /// </value>
        [SRCategory("CatWindowStyle"), DefaultValue(true), SRDescription("FormMinimizeBoxDescr")]
        public bool MinimizeBox
        {
            get
            {
                return this.GetState(FormState.MinimizeBox);
            }
            set
            {
                // If the value had changed
                if (this.SetStateWithCheck(FormState.MinimizeBox, value))
                {
                    // Raise minimized box changed
                    FireObservableItemPropertyChanged("MinimizeBox");

                    // Update extended attribute.
                    this.UpdateParams(AttributeType.Extended);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a form has a modal mask when modal.
        /// </summary>
        /// <value><c>true</c> if a form has a modal mask when modal; otherwise, <c>false</c>.</value>
        [SRCategory("CatWindowStyle"), DefaultValue(true), SRDescription("FormModalMaskDescr")]
        public bool ModalMask
        {
            get
            {
                return this.GetValue<bool>(Form.ModalMaskProperty);
            }
            set
            {
                this.SetValue<bool>(Form.ModalMaskProperty, value);
            }
        }

        /// <summary>
        /// The ModalMask property registration.
        /// </summary>
        private static readonly SerializableProperty ModalMaskProperty = SerializableProperty.Register("ModalMask", typeof(bool), typeof(Form), new SerializablePropertyMetadata(true));



        /// <summary>
        /// Gets or sets a value indicating whether [maximize box].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [maximize box]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("FormMaximizeBoxDescr"), SRCategory("CatWindowStyle"), DefaultValue(true)]
        public bool MaximizeBox
        {
            get
            {
                return this.GetState(FormState.MaximizeBox);
            }
            set
            {
                // If the value had changed
                if (this.SetStateWithCheck(FormState.MaximizeBox, value))
                {
                    // Raise masmized box changed
                    FireObservableItemPropertyChanged("MaximizeBox");

                    // Update extended attribute.
                    this.UpdateParams(AttributeType.Extended);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [close box].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [close box]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("FormCloseBoxDescr"), SRCategory("CatWindowStyle"), DefaultValue(true)]
        public bool CloseBox
        {
            get
            {
                return this.GetState(FormState.CloseBox);
            }
            set
            {
                // If the value had changed
                if (this.SetStateWithCheck(FormState.CloseBox, value))
                {
                    // Raise Close box changed
                    FireObservableItemPropertyChanged("CloseBox");

                    // Update extended attribute.
                    this.UpdateParams(AttributeType.Extended);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show in taskbar].
        /// Not implemented by design
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show in taskbar]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true), SRDescription("FormShowInTaskbarDescr"), SRCategory("CatWindowStyle")]
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
        /// <summary>
        /// Gets or sets The starting position of the window
        /// </summary>
        /// <value></value>
        [SRDescription("FormStartPositionDescr"), DefaultValue(2), Localizable(true), SRCategory("CatLayout")]
        public FormStartPosition StartPosition
        {
            get
            {
                return this.GetValue<FormStartPosition>(Form.StartPositionProperty);
            }
            set
            {
                if (this.SetValue<FormStartPosition>(Form.StartPositionProperty, value))
                {
                    FireObservableItemPropertyChanged("StartPosition");
                }
            }
        }

        /// <summary>
        /// Gets or sets the dialog Alignment.
        /// </summary>
        /// <value></value>
        private DialogAlignment DialogAlignment
        {
            get
            {
                return this.GetValue<DialogAlignment>(Form.DialogAlignmentProperty);
            }
            set
            {
                this.SetValue<DialogAlignment>(Form.DialogAlignmentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value></value>
        public DialogResult DialogResult
        {
            get
            {
                return GetValue<DialogResult>(Form.DialogResultProperty);
            }
            set
            {
                this.SetValue<DialogResult>(Form.DialogResultProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the button on the form that is clicked when the user presses the ESC key.
        /// </summary>
        public IButtonControl CancelButton
        {
            get
            {
                // Get the value From PropertyStore
                return this.GetValue<IButtonControl>(Form.CancelButtonProperty);
            }
            set
            {
                //If value different from current value
                if (this.SetValue<IButtonControl>(Form.CancelButtonProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);

                    if ((value != null) && (value.DialogResult == DialogResult.None))
                    {
                        value.DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the before unload message.
        /// </summary>
        /// <value>The before unload message.</value>
        [Localizable(true)]
        [DefaultValue("")]
        public string BeforeUnloadMessage
        {
            get
            {
                return GetValue<string>(Form.BeforeUnloadMessageProperty);
            }
            set
            {
                // If the value is null set it to the default - an empty string.
                if (value == null)
                {
                    value = string.Empty;
                }

                // If value has changed
                if (SetValue<string>(Form.BeforeUnloadMessageProperty, value))
                {
                    // Update form to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the button on the form that is clicked when the user presses the ENTER key.
        /// </summary>
        public IButtonControl AcceptButton
        {
            get
            {
                // Get the value From PropertyStore
                return this.GetValue<IButtonControl>(Form.AcceptButtonProperty);
            }
            set
            {
                // If value has changed
                if (this.SetValue<IButtonControl>(Form.AcceptButtonProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Sets the visible internal.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> set visible.</param>
        internal override void SetVisibleInternal(bool blnValue)
        {
            if (this.TopLevel)
            {
                if (this.Visible != blnValue)
                {
                    IContext objContext = VWGContext.Current;

                    if (blnValue)
                    {
                        // Set visibility before showing dialog/creating control
                        base.SetVisibleInternal(blnValue);

                        if (objContext != null && objContext.MainForm != this)
                        {
                            this.Show();
                        }
                        else
                        {
                            this.CreateControl();
                        }
                    }
                    else
                    {
                        if (objContext != null)
                        {
                            if (objContext.MainForm != this && objContext.MainForm != null)
                            {
                                Close(false, true, false);
                            }
                        }

                        // Set visibility
                        base.SetVisibleInternal(blnValue);
                    }
                }
            }
            else
            {
                // Set visibility
                base.SetVisibleInternal(blnValue);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [top most].
        /// </summary>
        /// <value><c>true</c> if [top most]; otherwise, <c>false</c>.</value>
        [SRDescription("FormTopMostDescr"), SRCategory("CatWindowStyle"), DefaultValue(false)]
        public bool TopMost
        {
            get
            {
                if (!this.DesignMode && this.Context != null)
                {

                    return (this.Context.ActiveForm == this);
                }

                return false;
            }
            set
            {
            }
        }

        /// <summary>
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



        /// <summary>
        /// Gets or sets a value indicating whether [called on load].
        /// </summary>
        /// <value><c>true</c> if [called on load]; otherwise, <c>false</c>.</value>
        private bool CalledOnLoad
        {
            get
            {
                return this.GetState(FormState.CalledOnLoad);
            }
            set
            {
                this.SetState(FormState.CalledOnLoad, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [called make visible].
        /// </summary>
        /// <value><c>true</c> if [called make visible]; otherwise, <c>false</c>.</value>
        private bool CalledMakeVisible
        {
            get
            {
                return this.GetState(FormState.CalledMakeVisible);
            }
            set
            {
                this.SetState(FormState.CalledMakeVisible, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [called create control].
        /// </summary>
        /// <value><c>true</c> if [called create control]; otherwise, <c>false</c>.</value>
        private bool CalledCreateControl
        {
            get
            {
                return this.GetState(FormState.CalledCreateControlProperty);
            }
            set
            {
                this.SetState(FormState.CalledCreateControlProperty, value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the form was moved.
        /// </summary>
        /// <value><c>true</c> if moved; otherwise, <c>false</c>.</value>
        private bool Moved
        {
            get
            {
                return this.GetState(FormState.Moved);
            }
            set
            {
                this.SetState(FormState.Moved, value);
            }
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value></value>
        public override IContext Context
        {
            get
            {
                if (this.TopLevel)
                {
                    // Try to get the context from the local context
                    IContext objContext = mobjContext as IContext;

                    // If context was not found
                    if (objContext == null)
                    {
                        // Get context from the static context and cache it to prevent multiple calls
                        mobjContext = objContext = VWGContext.Current;
                    }

                    return objContext;
                }

                return base.Context;
            }
        }

        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <value></value>
        internal void SetContextInternal(IContext objContext)
        {
            // Set current window context
            mobjContext = objContext;

            // Loop all child forms and set context
            Form[] arrOwnedForms = OwnedForms;
            foreach (Form objForm in arrOwnedForms)
            {
                // Set the internal context to the child forms
                objForm.SetContextInternal(objContext);
            }
        }

        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <param name="objContext">The context.</param>
        void IForm.SetContext(IContext objContext)
        {
            if (objContext != null)
            {
                this.SetContextInternal(objContext);
            }
        }

        /// <summary>
        /// Clears the context.
        /// </summary>
        void IForm.ClearContext()
        {
            // Clear the current context
            this.SetContextInternal(null);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this window is modal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is modal; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Modal
        {
            get
            {
                switch (this.DialogType)
                {
                    case DialogTypes.ModalessWindow: return false;
                    case DialogTypes.ModalWindow: return true;
                    case DialogTypes.PopupWindow: return false;
                    default: return false;
                }
            }
        }

        /// <devdoc> 
        ///     Retrieves true if this form is currently active. 
        /// </devdoc>
        internal bool Active
        {
            get
            {
                Form parentForm = ParentFormInternal;
                if (parentForm == null)
                {
                    // Get the value indicating id this is an active form
                    return GetState(FormState.IsActiveForm);
                }
                return (parentForm.ActiveControl == this && parentForm.Active);
            }

            set
            {
                // Set the is active form flag and do actions only if value had updated
                if (this.SetStateWithCheck(FormState.IsActiveForm, value))
                {
                    if (value)
                    {
                        if (!ValidationCancelled)
                        {
                            if (ActiveControl == null)
                            {
                                SelectNextControlInternal(null, true, true, true, false);
                            }

                            InnerMostActiveContainerControl.FocusActiveControlInternal();
                        }
                        OnActivated(EventArgs.Empty);
                    }
                    else
                    {
                        OnDeactivate(EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the parent container of this control.
        /// </summary>
        /// <value></value>
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
                    this.Owner = null;
                }
                base.ParentInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display the form as a top-level window.
        /// </summary>
        /// <value><c>true</c> if [top level]; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool TopLevel
        {
            get
            {
                return base.GetTopLevel();
            }
            set
            {
                if ((!value && this.IsMdiContainer) && !base.DesignMode)
                {
                    throw new ArgumentException(SR.GetString("MDIContainerMustBeTopLevel"), "value");
                }
                base.SetTopLevel(value);
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DialogTypes DialogType
        {
            get
            {
                return this.GetValue<DialogTypes>(Form.DialogTypeProperty);
            }
            internal set
            {
                this.SetValue<DialogTypes>(Form.DialogTypeProperty, value);
            }
        }

        /// <summary>Gets or sets the form that owns this form.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> that represents the form that is the owner of this form.</returns>
        /// <exception cref="T:System.Exception">A top-level window cannot have an owner. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), SRDescription("FormOwnerDescr"), SRCategory("CatWindowStyle")]
        public Form Owner
        {
            get
            {
                return this.OwnerInternal;
            }
            set
            {
                Form objOwnerInternal = this.OwnerInternal;
                if (objOwnerInternal != value)
                {
                    if ((value != null) && !this.TopLevel)
                    {
                        throw new ArgumentException(SR.GetString("NonTopLevelCantHaveOwner"), "value");
                    }
                    Control.CheckParentingCycle(this, value);
                    Control.CheckParentingCycle(value, this);
                    this.SetValue<Form>(Form.OwnerProperty, null);
                    if (objOwnerInternal != null)
                    {
                        objOwnerInternal.RemoveOwnedForm(this);
                    }
                    this.OwnerInternal = value;

                    if (value != null)
                    {
                        value.AddOwnedForm(this);
                    }
                }
            }
        }

        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), SRDescription("ControlTabStopDescr"), DefaultValue(true), DispId(-516), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        override public bool TabStop
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

        /// <summary>Gets or sets the tab order of the control within its container.</summary>
        /// <returns>An <see cref="T:System.Int32"></see> containing the index of the control within the set of controls within its container that is included in the tab order.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public int TabIndex
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

        /// <summary>
        /// Gets or sets the parent window.
        /// </summary>
        /// <value></value>
        internal Form OwnerInternal
        {
            get
            {
                return this.GetValue<Form>(Form.OwnerProperty);
            }
            set
            {
                this.SetValue<Form>(Form.OwnerProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the closed delegate.
        /// </summary>
        /// <value>
        /// The closed delegate.
        /// </value>
        private EventHandler ClosedDelegate
        {
            get
            {
                return this.GetValue<EventHandler>(Form.ClosedDelegateProperty);
            }
            set
            {
                this.SetValue<EventHandler>(Form.ClosedDelegateProperty, value);
            }
        }

        /// <summary>
        /// Gets the child forms.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Form[] OwnedForms
        {
            get
            {
                if (mobjOwnedForms == null)
                {
                    return new Form[] { };
                }
                else
                {
                    ArrayList objForms = new ArrayList(mobjOwnedForms);
                    return (Form[])objForms.ToArray(typeof(Form));
                }
            }
        }

        /// <summary>
        /// Gets the form FormCollection from propertyStore if existed and a new FormCollection otherwise.
        /// </summary>
        /// <returns>The form FormCollection from propertyStore if existed and a new FormCollection otherwise.</returns>
        /// <value></value>
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

        /// <summary>
        /// Gets a value indicating whether this instance has windows.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has windows; otherwise, <c>false</c>.
        /// </value>
        internal bool HasWindows
        {
            get
            {
                FormCollection objForms = this.OwnedFormsCollection;
                if (objForms != null)
                {
                    return objForms.Count > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has modal windows.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has modal windows; otherwise, <c>false</c>.
        /// </value>
        internal bool HasModalWindows
        {
            get
            {
                return (this.OwnedModalForm != null);
            }
        }

        /// <summary>
        /// Gets the owned modal form.
        /// </summary>
        /// <value>The owned modal form.</value>
        private Form OwnedModalForm
        {
            get
            {
                Form objOwnedModalForm = null;

                // Get the owned forms collection 
                FormCollection arrOwnedForms = this.OwnedFormsCollection;
                if (arrOwnedForms != null)
                {
                    // If there are ownned forms.
                    if (arrOwnedForms.Count > 0)
                    {
                        // Loop the forms
                        foreach (Form objOwnedForm in arrOwnedForms)
                        {
                            // If is a modal top level dialog
                            if (objOwnedForm.TopLevel && objOwnedForm.DialogType == DialogTypes.ModalWindow)
                            {
                                objOwnedModalForm = objOwnedForm;
                            }
                        }
                    }
                }

                return objOwnedModalForm;
            }
        }

        /// <summary>
        /// Gets the top most owned modal form.
        /// </summary>
        /// <value>The top most owned modal form.</value>
        private Form TopMostOwnedModalForm
        {
            get
            {
                Form objTopMostOwnedModalForm = null;

                // Get owned modal form.
                Form objOwnedModalForm = this.OwnedModalForm;
                if (objOwnedModalForm != null)
                {
                    // Check if owned modal form does not have an owned modal form.
                    if ((objTopMostOwnedModalForm = objOwnedModalForm.TopMostOwnedModalForm) == null)
                    {
                        // Set top most owned form to the first owned modal form.
                        objTopMostOwnedModalForm = objOwnedModalForm;
                    }
                }

                return objTopMostOwnedModalForm;
            }
        }

        /// <summary>
        /// Gets or sets the form Mdi client
        /// </summary>
        public MdiClient MdiClient
        {
            get
            {
                // Get value from PropertyStore
                return this.GetValue<MdiClient>(Form.MdiClientProperty);
            }
            internal set
            {
                this.SetValue<MdiClient>(Form.MdiClientProperty, value);
            }
        }

        /// <summary>
        /// Gets the form Mdi children
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Form[] MdiChildren
        {
            get
            {
                // Check if MDI client exists
                if (this.MdiClient != null)
                {
                    // Get value from MDI client 
                    return this.MdiClient.MdiChildren;
                }
                return new Form[0];
            }
        }

        /// <summary>
        /// Gets the form active Mdi child
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Form ActiveMdiChild
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the form icon
        /// </summary>
        [ProxyBrowsable(true)]
        public ResourceHandle Icon
        {
            get
            {
                // Get value from PropertyStore
                return this.GetValue<ResourceHandle>(Form.IconProperty);
            }
            set
            {
                this.SetValue<ResourceHandle>(Form.IconProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the auto scale base.
        /// Not implemented.
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsEventsEnabled
        {
            get
            {
                return this.Visible;
            }
        }

        /// <summary>
        /// Gets or sets the form header control.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public Control Header
        {
            get
            {

                return this.GetValue<Control>(Form.HeaderProperty);
            }
            set
            {
                // If header is diffrent than 
                if (this.SetValue<Control>(Form.HeaderProperty, value))
                {
                    // If there is a header control
                    if (value != null)
                    {
                        // Set the header panel internal parent
                        value.InternalParent = this;
                    }
                }

            }
        }

        /// <summary>
        /// Gets or sets the color that will represent transparent areas of the form. 
        /// Not implemented by design.
        /// </summary>
        /// <value>The transparency key.</value>
        [Obsolete("Not implemented by design")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TransparencyKey
        {
            get
            {
                return GetValue<Color>(Form.TransparencyKeyProperty);
            }
            set
            {
                SetValue<Color>(Form.TransparencyKeyProperty, value);
            }
        }

        /// <summary>
        /// Gets a flag indicating if should serialize the transparency key.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeTransparencyKey()
        {
            return this.TransparencyKey != Color.Empty;
        }

        /// <summary>
        /// Shoulds the serialize geo location data.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeGeoLocationData()
        {
            return !GeoLocationData.Empty.Equals(this.GeographicLocation);
        }

        /// <summary>
        /// Resets the geo location data.
        /// </summary>
        private void ResetGeoLocationData()
        {
            this.GeographicLocation = GeoLocationData.Empty;
        }

        /// <summary>
        /// Check if conrtol should be rendered.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        protected override bool ShouldRenderControl(Control objControl)
        {
            return !(objControl is MdiClient);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [activate on pre render].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [activate on show]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool ActivateOnShow
        {
            get
            {
                return GetValue<bool>(Form.ActivateOnShowProperty);
            }
            set
            {
                SetValue<bool>(Form.ActivateOnShowProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a control box is displayed in the caption bar of the form.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the form displays a control box in the upper left corner of the form; otherwise, <c>false</c>. The default is true.
        /// </value>
        [SRCategory("CatWindowStyle"), DefaultValue(true), SRDescription("FormControlBoxDescr")]
        public bool ControlBox
        {
            get
            {
                return this.GetValue<bool>(Form.ControlBoxProperty);
            }
            set
            {
                if (this.SetValue<bool>(Form.ControlBoxProperty, value))
                {
                    UpdateParams(AttributeType.Extended);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [key preview].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [key preview]; otherwise, <c>false</c>.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool KeyPreview
        {
            get
            {
                return this.GetValue<bool>(Form.KeyPreviewProperty);
            }
            set
            {
                this.SetValue<bool>(Form.KeyPreviewProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [help button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [help button]; otherwise, <c>false</c>.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool HelpButton
        {
            get
            {
                return this.GetValue<bool>(Form.HelpButtonProperty);
            }
            set
            {
                this.SetValue<bool>(Form.HelpButtonProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether an icon is displayed in the caption bar of the form.</summary>
        /// <returns>true if the form displays an icon in the caption bar; otherwise, false. The default is true.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatWindowStyle"), SRDescription("FormShowIconDescr"), DefaultValue(true)]
        public bool ShowIcon
        {
            get
            {
                return true;
            }
            set
            { }
        }


        /// <summary>Gets or sets the opacity level of the form.</summary>
        /// <returns>The level of opacity for the form. The default is 1.00.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue((double)1.0), SRDescription("FormOpacityDescr"), SRCategory("CatWindowStyle")]
        public double Opacity
        {
            get
            {
                return 1.0;
            }
            set
            { }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control" /> is resizable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if resizable; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        [Obsolete("Use FormBorderStyle property to change resizable functionality")]
        public override ResizableOptions Resizable
        {
            get
            {
                // A not top level forms should act as a panel
                if (TopLevel == false)
                {
                    return base.Resizable;
                }
                return null;
            }
            set
            {
                if (TopLevel == false)
                {
                    base.Resizable = value;
                }
            }
        }


        #endregion

        #region Events

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            // If is a modal dialog 
            if (this.DialogType == DialogTypes.ModalWindow)
            {
                // If modal emulation mode is on
                if (ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread")
                {
                    // Force closing to be critical
                    objEvents.Set(WGEvents.Closed);
                }
            }

            if (this.ClosedHandler != null || this.FormClosedHandler != null || this.ClosedDelegate != null)
            {
                objEvents.Set(WGEvents.Closed);
            }

            if (this.ClosingHandler != null || this.FormClosingHandler != null)
            {
                objEvents.Set(WGEvents.Closing);
            }

            if (this.ActivatedHandler != null)
            {
                objEvents.Set(WGEvents.Activated);
            }

            if (this.DeactivateHandler != null)
            {
                objEvents.Set(WGEvents.Deactivate);
            }

            if (this.OrientationChangedHandler != null)
            {
                objEvents.Set(WGEvents.OrientationChanged);
            }

            if (this.GeographicLocationChangedHandler != null)
            {
                objEvents.Set(WGEvents.PositionChanged);
            }

            return objEvents;
        }

        /// <summary>
        /// Sets the specified bounds of the control to the specified location and size.
        /// </summary>
        /// <param name="intLeft">The int left.</param>
        /// <param name="intTop">The int top.</param>
        /// <param name="intWidth">Width of the int layout.</param>
        /// <param name="intHeight">Height of the int layout.</param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
        /// <returns></returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
        {
            // Save the given dimentions for restoring purposes
            if (this.WindowState != FormWindowState.Normal)
            {
                Point objRestoreLocation = this.FormRestoredLocation;
                Size objRestoreSize = this.FormRestoredSize;

                if ((enmSpecified & BoundsSpecified.X) != BoundsSpecified.None)
                {
                    objRestoreLocation.X = intLeft;
                }
                if ((enmSpecified & BoundsSpecified.Y) != BoundsSpecified.None)
                {
                    objRestoreLocation.Y = intTop;
                }
                if ((enmSpecified & BoundsSpecified.Width) != BoundsSpecified.None)
                {
                    objRestoreSize.Width = intWidth;
                }
                if ((enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None)
                {
                    objRestoreSize.Height = intHeight;
                }

                this.FormRestoredSize = objRestoreSize;
                this.FormRestoredLocation = objRestoreLocation;
            }
            else
            {
                // When the state is Max/Min the actual size is not changed (Here we must make sure that 'this.WindowState' is in the correct state)
                return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified);
            }

            return false;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.ClosedDelegate != null || this.HasClientHandler("OnUnload"))
            {
                objEvents.Set(WGEvents.Closed);
                objEvents.Set(WGEvents.Closing);
            }

            if (this.HasClientHandler("Activated"))
            {
                objEvents.Set(WGEvents.Activated);
            }

            if (this.HasClientHandler("OrientationChange"))
            {
                objEvents.Set(WGEvents.OrientationChanged);
            }

            if (this.HasClientHandler("GeoLocationChanged"))
            {
                objEvents.Set(WGEvents.PositionChanged);
            }

            return objEvents;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            // Select event type
            switch (objEvent.Type)
            {
                case "OnClose":
                    // After closing the browsers mainform, context should be marked pending temination
                    // if this context is not used during pending termination time frame this context
                    // will be terminated
                    ((IContextTerminate)this.Context).SetPendingTermination();
                    break;
                case "OnUnload":
                    this.Context.ActiveForm = this;
                    Close(true, false, false);
                    break;
                case "WindowStateChange":
                    if (objEvent.Contains(WGAttributes.WindowState))
                    {
                        // Set window state.
                        this.SetWindowState((FormWindowState)Enum.Parse(typeof(FormWindowState), objEvent[WGAttributes.WindowState]));
                    }
                    break;
                case "Shortcut":
                    //this.Shortcuts is never returned as null
                    IRegisteredComponent objComponent = this.Shortcuts[objEvent[WGAttributes.Value]];
                    if (objComponent != null)
                    {
                        objComponent.FireEvent(objEvent);
                    }
                    break;
                case "OnAccept":
                    // Check if there is an accept button.
                    IButtonControl objAcceptButton = this.AcceptButton;
                    if (objAcceptButton != null)
                    {
                        // Check control enabled
                        Control mobjAcceptControl = objAcceptButton as Control;
                        if (mobjAcceptControl.Enabled && mobjAcceptControl.Visible)
                        {
                            // Execute the click event
                            objAcceptButton.PerformClick();
                        }
                    }
                    break;
                case "OnCancel":
                    // Check if there is a cancel button.
                    IButtonControl objCancelButton = this.CancelButton;
                    if (objCancelButton != null)
                    {
                        // If the control is enabled
                        Control mobjCancelControl = objCancelButton as Control;
                        if (mobjCancelControl.Enabled && mobjCancelControl.Visible)
                        {
                            // Execute the click event
                            objCancelButton.PerformClick(); ;
                        }
                    }
                    break;
                case "Activated":
                    // Activate the form
                    this.ActivateForm(true);

                    break;

                case "ShowServerExplorer":
                    if (CommonSwitches.EnableClientShortcuts)
                    {
                        ServerExplorer objServerExplorerForm = new ServerExplorer();
                        objServerExplorerForm.SetRootComponent(Context.MainForm);
                        objServerExplorerForm.ShowDialog();
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

        /// <summary>
        /// Handles the geographic location changed.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        private void HandleGeographicLocationChanged(IEvent objEvent)
        {
            if (objEvent != null)
            {
                // Try getting error code and message from event arguments.
                string strErrorCode = objEvent[WGAttributes.ErrorCode];
                string strErrorMessage = objEvent[WGAttributes.ErrorMessage];

                if (!string.IsNullOrEmpty(strErrorCode) || !string.IsNullOrEmpty(strErrorMessage))
                {
                    // Throw the geo-location error to user.
                    throw new Exception(string.Format("Geographic location error (code {0}):\n{1}", strErrorCode, strErrorMessage));
                }
                else
                {
                    double dblLatitude;
                    double dblLongitude;

                    // Try getting latitude and longtitude from event arguments.
                    if (CommonUtils.TryParse(objEvent[WGAttributes.Latitude], out dblLatitude) &&
                        CommonUtils.TryParse(objEvent[WGAttributes.Longitude], out dblLongitude))
                    {
                        // Raise the GeoLocationChanged event.
                        this.OnGeographicLocationChanged(new GeographicLocationChangedEventArgs(new GeoLocation(dblLatitude, dblLongitude)));
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:GeographicLocationChanged"/> event.
        /// </summary>
        /// <param name="objGeoLocationChangedEventArgs">The <see cref="Gizmox.WebGUI.Forms.GeographicLocationChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnGeographicLocationChanged(GeographicLocationChangedEventArgs objGeoLocationChangedEventArgs)
        {
            if (this.GeographicLocationChangedHandler != null)
            {
                this.GeographicLocationChangedHandler(this, objGeoLocationChangedEventArgs);
            }
        }

        #endregion

        #region IObservableList Members

        internal void OnFormAdded(Form objForm)
        {
            // Raise event if needed
            ObservableListEventHandler objEventHandler = this.ObservableItemAddedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new ObservableListEventArgs(objForm));
            }
        }

        internal void OnFormRemoved(Form objForm)
        {
            // Raise event if needed
            ObservableListEventHandler objEventHandler = this.ObservableItemRemovedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new ObservableListEventArgs(objForm));
            }
        }

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableListEventHandler ObservableItemAdded
        {
            add
            {
                this.AddHandler(Form.ObservableItemAddedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Form.ObservableItemAddedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ObservableItemAdded event.
        /// </summary>
        private ObservableListEventHandler ObservableItemAddedHandler
        {
            get
            {
                return (ObservableListEventHandler)this.GetHandler(Form.ObservableItemAddedEvent);
            }
        }

        /// <summary>
        /// The ObservableItemAdded event registration.
        /// </summary>
        private static readonly SerializableEvent ObservableItemAddedEvent = SerializableEvent.Register("ObservableItemAdded", typeof(ObservableListEventHandler), typeof(Form));



        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableListEventHandler ObservableItemInserted
        {
            add
            {
                this.AddHandler(Form.ObservableItemInsertedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Form.ObservableItemInsertedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ObservableItemInserted event.
        /// </summary>
        private ObservableListEventHandler ObservableItemInsertedHandler
        {
            get
            {
                return (ObservableListEventHandler)this.GetHandler(Form.ObservableItemInsertedEvent);
            }
        }

        /// <summary>
        /// The ObservableItemInserted event registration.
        /// </summary>
        private static readonly SerializableEvent ObservableItemInsertedEvent = SerializableEvent.Register("ObservableItemInserted", typeof(ObservableListEventHandler), typeof(Form));



        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableListEventHandler ObservableItemRemoved
        {
            add
            {
                this.AddHandler(Form.ObservableItemRemovedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Form.ObservableItemRemovedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ObservableItemRemoved event.
        /// </summary>
        private ObservableListEventHandler ObservableItemRemovedHandler
        {
            get
            {
                return (ObservableListEventHandler)this.GetHandler(Form.ObservableItemRemovedEvent);
            }
        }

        /// <summary>
        /// The ObservableItemRemoved event registration.
        /// </summary>
        private static readonly SerializableEvent ObservableItemRemovedEvent = SerializableEvent.Register("ObservableItemRemoved", typeof(ObservableListEventHandler), typeof(Form));



        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event EventHandler ObservableListCleared
        {
            add
            {
                this.AddHandler(Form.ObservableListClearedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Form.ObservableListClearedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ObservableListCleared event.
        /// </summary>
        private EventHandler ObservableListClearedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Form.ObservableListClearedEvent);
            }
        }

        /// <summary>
        /// The ObservableListCleared event registration.
        /// </summary>
        private static readonly SerializableEvent ObservableListClearedEvent = SerializableEvent.Register("ObservableListCleared", typeof(EventHandler), typeof(Form));



        #endregion

        #region ControlCollection


        /// <summary>Represents a collection of controls on the form.</summary>
        [Serializable]
        public class ControlCollection : Control.ControlCollection
        {
            private Form mobjOwner;

            /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Form.ControlCollection"></see> class.</summary>
            /// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to contain the controls added to the control collection. </param>
            public ControlCollection(Form objOwner)
                : base(objOwner)
            {
                mobjOwner = objOwner;
            }

            /// <summary>
            /// Adds the specified control to the control collection.
            /// </summary>
            /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection. </param>
            public override void Add(Control objValue)
            {
                if ((objValue is MdiClient) && (mobjOwner.MdiClient == null))
                {
                    mobjOwner.MdiClient = (MdiClient)objValue;
                }
                base.Add(objValue);
            }

            /// <summary>Removes the specified control from the control collection.</summary>
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

        #endregion ControlCollection

        #region Client Members


        /// <summary>
        /// Occurs when the client loads and provides online preperations for entering client mode.
        /// </summary>
        /// <value>
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
                this.AddClientHandler("ClientPreload", value);
            }
            remove
            {
                this.RemoveClientHandler("ClientPreload", value);
            }
        }


        /// <summary>
        /// Occurs when client mode is initialized
        /// </summary>
        /// <value>
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
                this.AddClientHandler("OfflineInitializing", value);
            }
            remove
            {
                this.RemoveClientHandler("OfflineInitializing", value);
            }
        }

        /// <summary>
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
                this.AddClientHandler("OfflineConfirming", value);
            }
            remove
            {
                this.RemoveClientHandler("OfflineConfirming", value);
            }
        }

        /// <summary>
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
                this.AddClientHandler("OnUnload", value);
            }
            remove
            {
                this.RemoveClientHandler("OnUnload", value);
            }
        }

        /// <summary>
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
                this.AddClientHandler("Activated", value);
            }
            remove
            {
                this.RemoveClientHandler("Activated", value);
            }
        }

        /// <summary>
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
                this.AddClientHandler("Resize", value);
            }
            remove
            {
                this.RemoveClientHandler("Resize", value);
            }
        }

        /// <summary>
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
                this.AddClientHandler("Move", value);
            }
            remove
            {
                this.RemoveClientHandler("Move", value);
            }
        }

        #endregion

        #region IFormParams

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

        #endregion
    }

    #endregion

    #region FormCollection Class

    /// <summary>
    /// A form collection class
    /// </summary>

    [Serializable()]
    internal class FormCollection : CollectionBase
    {

        #region private members

        /// <summary>
        /// InternalParent form
        /// </summary>
        private Form mobjParent = null;

        private bool mblnHasModal = false;

        private Form mobjModalForm = null;

        #endregion

        #region C'Tor\D'Tor


        /// <summary>
        /// Initializes a new instance of the <see cref="FormCollection"/> class.
        /// </summary>
        /// <param name="objParent">The parent.</param>
        internal FormCollection(Form objParent)
        {
            mobjParent = objParent;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FormCollection"/> class.
        /// </summary>
        /// <param name="objParent">The parent.</param>
        /// <param name="objForms">The forms.</param>
        internal FormCollection(Form objParent, object[] arrForms)
        {
            mobjParent = objParent;

            this.InnerList.AddRange(arrForms);
        }



        #endregion

        #region Methods

        /// <summary>
        /// Containses the specified form.
        /// </summary>
        /// <param name="objForm">form.</param>
        /// <returns></returns>
        public bool Contains(Form objForm)
        {
            return List.Contains(objForm);
        }

        /// <summary>
        /// Adds the specified obj form.
        /// </summary>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        internal int Add(Form objForm)
        {
            if (HasModal && objForm.Modal)
            {
                return -1;
            }
            else
            {
                // set the form parent
                objForm.OwnerInternal = mobjParent;

                // if the current form is modal
                if (!objForm.TopLevel && objForm.Modal)
                {
                    mblnHasModal = true;
                    mobjModalForm = objForm;
                }

                // return form index
                int intIndex = List.Add(objForm);
                mobjParent.OnFormAdded(objForm);
                return intIndex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objForm"></param>
        internal void Remove(Form objForm)
        {
            // if the current form is modal
            if (objForm.Modal)
            {
                mblnHasModal = false;
                mobjModalForm = null;
            }

            if (List.Contains(objForm))
            {
                // remove current window from list
                List.Remove(objForm);
                mobjParent.OnFormRemoved(objForm);
            }
        }

        /// <summary>
        /// Set form's position.
        /// </summary>
        /// <param name="objForm">The form.</param>
        /// <param name="intIndex">Index of the form.</param>
        internal void SetFormPosition(Form objForm, int intIndex)
        {
            // Validate received form.
            if (objForm != null && this.List.Contains(objForm))
            {
                // Validate recieved index.
                if (this.List.IndexOf(objForm) != intIndex &&
                    intIndex >= 0 && intIndex < this.List.Count)
                {
                    // Remove form from its current location.
                    this.List.Remove(objForm);

                    // Inset the form to its new location.
                    this.List.Insert(intIndex, objForm);
                }
            }
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="objForm">The obj form.</param>
        /// <returns></returns>
        public int IndexOf(Form objForm)
        {
            return this.InnerList.IndexOf(objForm);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this window has modal child window.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has modal; otherwise, <c>false</c>.
        /// </value>
        public bool HasModal
        {
            get
            {
                return mblnHasModal;
            }
        }

        #endregion


    }

    #endregion

    #region FormClosedEventArgs Class

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.Form.FormClosed"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    public class FormClosedEventArgs : EventArgs
    {
        private CloseReason mobjCloseReason;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.FormClosedEventArgs"></see> class.</summary>
        /// <param name="objCloseReason">A <see cref="T:Gizmox.WebGui.Forms.CloseReason"></see> value that represents the reason why the form was closed.</param>
        public FormClosedEventArgs(CloseReason objCloseReason)
        {
            this.mobjCloseReason = objCloseReason;
        }

        /// <summary>Gets a value that indicates why the form was closed. </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGui.Forms.CloseReason"></see> enumerated values. </returns>
        /// <filterpriority>1</filterpriority>
        public CloseReason CloseReason
        {
            get
            {
                return this.mobjCloseReason;
            }
        }
    }


    #endregion

    #region FormClosingEventArgs Class

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.Form.FormClosing"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable]
    public class FormClosingEventArgs : CancelEventArgs
    {
        private CloseReason mobjCloseReason;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.FormClosingEventArgs"></see> class.</summary>
        /// <param name="objCloseReason">A <see cref="T:Gizmox.WebGui.Forms.CloseReason"></see> value that represents the reason why the form is being closed.</param>
        /// <param name="blnCancel">true to cancel the event; otherwise, false.</param>
        public FormClosingEventArgs(CloseReason objCloseReason, bool blnCancel)
            : base(blnCancel)
        {
            this.mobjCloseReason = objCloseReason;
        }

        /// <summary>Gets a value that indicates why the form is being closed.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGui.Forms.CloseReason"></see> enumerated values. </returns>
        /// <filterpriority>1</filterpriority>
        public CloseReason CloseReason
        {
            get
            {
                return this.mobjCloseReason;
            }
        }
    }

    #endregion

    #region  OrientationChangedEventArgs Class

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGui.Forms.Form.OrientationChanged"></see> event.</summary>
    public class OrientationChangedEventArgs : EventArgs
    {
        private int? mintOrientation;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGui.Forms.OrientationChangeEventArgs"></see> class.
        /// </summary>
        /// <param name="intOrientation">The int? orientation.</param>
        public OrientationChangedEventArgs(int? intOrientation)
        {
            this.mintOrientation = intOrientation;
        }

        /// <summary>
        /// Gets a value that indicates the orientation of the form.
        /// Reutrns a nullable int representin the orientation degrees.
        /// </summary>       
        public int? Orientation
        {
            get
            {
                return this.mintOrientation;
            }
        }
    }


    #endregion
}
