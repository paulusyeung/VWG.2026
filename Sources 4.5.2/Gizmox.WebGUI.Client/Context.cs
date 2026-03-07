#region Using

using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.Collections.Specialized;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Configuration;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Client.Controllers;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion Using

namespace Gizmox.WebGUI.Client
{
    #region Update Commands

    /// <summary>
    ///
    /// </summary>

    internal class UpdateCommand
    {
        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal virtual void Fire()
        {
        }


        #endregion Methods

    }
    /// <summary>
    ///
    /// </summary>

    internal class UpdatePropertyCommand : UpdateCommand
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectController"></param>
        /// <param name="strProperty"></param>
        /// <param name="blnWebEvent"></param>
        internal UpdatePropertyCommand(Controllers.ObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangeArgs, bool blnWebEvent)
        {
            mobjObjectController = objObjectController;
            mobjPropertyChangeArgs = objPropertyChangeArgs;
            mblnIsWebEvent = blnWebEvent;
        }


        #endregion C'Tor / D'Tor

        #region Class Members

        private Controllers.ObjectController mobjObjectController;

        private ObservableItemPropertyChangedArgs mobjPropertyChangeArgs;

        private bool mblnIsWebEvent = false;


        #endregion Class Members

        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal override void Fire()
        {
            if (mblnIsWebEvent)
            {
                mobjObjectController.FireWebPropertyChanged(mobjPropertyChangeArgs);
            }
            else
            {
                mobjObjectController.FireWinPropertyChanged(mobjPropertyChangeArgs);
            }
        }


        #endregion Methods

    }
    /// <summary>
    ///
    /// </summary>

    internal class UpdateListItemAddedCommand : UpdateCommand
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        /// <param name="objItem"></param>
        internal UpdateListItemAddedCommand(Controllers.ObjectCollectionController objObjectCollectionController, object objItem)
        {
            mobjObjectCollectionController = objObjectCollectionController;
            mobjItem = objItem;
        }


        #endregion C'Tor / D'Tor

        #region Class Members

        private Controllers.ObjectCollectionController mobjObjectCollectionController;

        private object mobjItem;


        #endregion Class Members

        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal override void Fire()
        {
            mobjObjectCollectionController.FireObservableListItemAdded(mobjItem);
        }


        #endregion Methods

    }
    /// <summary>
    ///
    /// </summary>

    internal class UpdateFormAddedCommand : UpdateCommand
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objFormController"></param>
        /// <param name="objItem"></param>
        internal UpdateFormAddedCommand(Controllers.FormController objFormController, object objItem)
        {
            mobjFormController = objFormController;
            mobjItem = objItem;
        }


        #endregion C'Tor / D'Tor

        #region Class Members

        private Controllers.FormController mobjFormController;

        private object mobjItem;


        #endregion Class Members

        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal override void Fire()
        {
            mobjFormController.FireFormAdded(mobjItem);
        }


        #endregion Methods

    }
    /// <summary>
    ///
    /// </summary>

    internal class UpdateFormRemovedCommand : UpdateCommand
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objFormController"></param>
        /// <param name="objItem"></param>
        internal UpdateFormRemovedCommand(Controllers.FormController objFormController, object objItem)
        {
            mobjFormController = objFormController;
            mobjItem = objItem;
        }


        #endregion C'Tor / D'Tor

        #region Class Members

        private Controllers.FormController mobjFormController;

        private object mobjItem;


        #endregion Class Members

        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal override void Fire()
        {
            mobjFormController.FireFormRemoved(mobjItem);
        }


        #endregion Methods

    }
    /// <summary>
    ///
    /// </summary>

    internal class UpdateListItemRemovedCommand : UpdateCommand
    {
        #region Class Members

        private Controllers.ObjectCollectionController mobjObjectCollectionController;

        private object mobjItem;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        /// <param name="objItem"></param>
        internal UpdateListItemRemovedCommand(Controllers.ObjectCollectionController objObjectCollectionController, object objItem)
        {
            mobjObjectCollectionController = objObjectCollectionController;
            mobjItem = objItem;
        }


        #endregion C'Tor / D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal override void Fire()
        {
            mobjObjectCollectionController.FireObservableListItemRemoved(mobjItem);
        }


        #endregion Methods

    }
    /// <summary>
    ///
    /// </summary>

    internal class UpdateListClearedCommand : UpdateCommand
    {
        #region Class Members

        private Controllers.ObjectCollectionController mobjObjectCollectionController;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        internal UpdateListClearedCommand(Controllers.ObjectCollectionController objObjectCollectionController)
        {
            mobjObjectCollectionController = objObjectCollectionController;

        }


        #endregion C'Tor / D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        internal override void Fire()
        {
            mobjObjectCollectionController.FireObservableListCleared();
        }


        #endregion Methods

    }

    #endregion Update Commands

    #region Context Class

    /// <summary>
    /// Represents a Web request
    /// </summary>

    internal class Context : IContext, IContextTerminate, IContextMethodInvoker, ITimerHandlerContainer, IContextServices, IContextNotifications, IContextResources, IClinetDesignContext, IContextParams, IContextCommonDialogHandler, IClientDesignServices, ISessionRegistry
    {
        #region Class Members

        /// <summary>
        /// The available themes.
        /// </summary>
        private ReadOnlyCollection<string> marrAvailableThemes;

        /// <summary>
        /// The current http context
        /// </summary>
        private object mobjHttpContext = null;

        /// <summary>
        /// The current response object
        /// </summary>
        private Request mobjRequest = null;

        /// <summary>
        ///
        /// </summary>
        private Hashtable mobjContextParams = null;

        /// <summary>
        /// The current response object
        /// </summary>
        private Response mobjResponse = null;

        /// <summary>
        /// The current session object
        /// </summary>
        private Session mobjSession = null;

        /// <summary>
        /// The current application object
        /// </summary>
        private Application mobjApplication = null;

        /// <summary>
        /// The current cookies object
        /// </summary>
        private ICookies mobjCookies = null;

        /// <summary>
        ///
        /// </summary>
        private IForm mobjMainForm = null;

        /// <summary>
        ///
        /// </summary>
        private IForm mobjSuspendedMainForm = null;

        /// <summary>
        ///
        /// </summary>
        private IForm mobjActiveForm = null;

        /// <summary>
        ///
        /// </summary>
        private IForm mobjSuspendedActiveForm = null;

        /// <summary>
        /// The emulator form
        /// </summary>
        private IEmulatorForm mobjEmulatorForm = null;

        private IEmulationDevice mobjEmulationDevice = null;

        private IProxyMasterPage mobjActiveProxyMasterPage = null;

        private Dictionary<string, IProxyMasterPage> mobjNameProxyMasterPageMap = new Dictionary<string, IProxyMasterPage>();

        /// <summary>
        /// Static members
        /// </summary>
        private static Config mobjConfig = null;

        /// <summary>
        /// Application arguments
        /// </summary>
        private NameValueCollection mobjArgumentsProvider = null;

        /// <summary>
        /// Results provider
        /// </summary>
        private NameValueCollection mobjResultsProvider = null;

        private Hashtable mobjWebControllers = null;

        private Hashtable mobjWinControllers = null;

        /// <summary>
        /// The single tone server object
        /// </summary>
        private static IServer mobjServer = null;

        /// <summary>
        /// A flag indicating closing form mode
        /// </summary>
        private bool mblnClosingMainForm = false;

        private Queue mobjUpdateCommands = null;

        private IClientDesignServices mobjClientDesignServices = null;

        /// <summary>
        /// A flag indicating if notification are suspended
        /// </summary>
        private int mintNotificationSuspended = 0;

        /// <summary>
        /// 
        /// </summary>
        private int mintResizingSuspended = 0;

        /// <summary>
        /// Browser capabilities enumerator to use in forking etc
        /// </summary>
        private CSS3BrowserCapabilities menmCSS3BrowserCapabilities = CSS3BrowserCapabilities.Empty;

        /// <summary>
        /// Browser capabilities enumerator to use in forking etc
        /// </summary>
        private HTML5BrowserCapabilities menmHTML5BrowserCapabilities = HTML5BrowserCapabilities.Empty;

        /// <summary>
        /// Browser capabilities enumerator to use in forking etc
        /// </summary>
        private MISCBrowserCapabilities menmMISCBrowserCapabilities = MISCBrowserCapabilities.Empty;

        #endregion Class Members

        #region C'Tor

        /// <summary>
        /// Context constructor
        /// </summary>
        internal Context()
            : this(null)
        {

        }

        /// <summary>
        /// Context constructor
        /// </summary>
        internal Context(IClientDesignServices objClientDesignServices)
        {
            mobjContextParams = new Hashtable();
            mobjWebControllers = new Hashtable();
            mobjWinControllers = new Hashtable();
            mobjUpdateCommands = new Queue();

            mobjClientDesignServices = objClientDesignServices;
        }


        #endregion C'Tor

        #region Properties

        #region Context Server Objects

        /// <summary>
        /// The WebGUI.Web configuration
        /// </summary>
        public Config Config
        {
            get
            {
                // if config not loaded or this is design-time
                if (mobjConfig == null || CommonUtils.IsDesignMode)
                {
                    mobjConfig = Config.GetInstance();

                    if (mobjConfig == null)
                    {
                        mobjConfig = this.DesignServices.GetConfiguration();
                    }
                }

                // return the configuration object
                return mobjConfig;
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal static Config GetConfig()
        {
            // if config not loaded
            if (mobjConfig == null)
            {
                mobjConfig = Gizmox.WebGUI.Common.Configuration.Config.GetInstance(); ;
            }

            // return the configuration objecy
            return mobjConfig;
        }

        /// <summary>
        /// WebGUI Request object
        /// </summary>
        public IRequest Request
        {
            get
            {
                // Create a request object if not present
                if (mobjRequest == null)
                {
                    mobjRequest = new Request(this);
                }

                return mobjRequest;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public IServer Server
        {
            get
            {
                if (mobjServer == null)
                {
                    mobjServer = new Server();
                }
                return mobjServer;
            }
        }

        /// <summary>
        /// WebGUI Response object
        /// </summary>
        public IResponse Response
        {
            get
            {
                if (mobjResponse == null)
                {
                    mobjResponse = new Response(this);
                }

                return mobjResponse;
            }
        }

        /// <summary>
        /// WebGUI Cookies object
        /// </summary>
        public ICookies Cookies
        {
            get
            {
                if (mobjCookies == null)
                {
                    mobjCookies = new Cookies();
                }

                return mobjCookies;
            }
        }

        /// <summary>
        /// WebGUI application object
        /// </summary>
        public IApplication Application
        {
            get
            {
                // If application was not found
                if (mobjApplication == null)
                {
                    // Try to get application from application state
                    mobjApplication = new Application(this);
                }

                return mobjApplication;
            }
        }

        /// <summary>
        /// The current http context
        /// </summary>
        public System.Web.HttpContext HttpContext
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <value></value>
        public ISession Session
        {
            get
            {
                // Try to get session local
                if (mobjSession == null)
                {
                    mobjSession = new Session(this);
                }

                // Return the found session
                return mobjSession;
            }
        }


        #endregion Context Server Objects

        #region Context Logon Related

        /// <summary>
        /// Gets or sets a value indicating whether this session is logged on.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this session is logged on; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoggedOn
        {
            get
            {
                return Session.IsLoggedOn;
            }
            set
            {
                Session.IsLoggedOn = value;
            }
        }


        #endregion Context Logon Related

        #region Context Forms Related

        /// <summary>
        /// Gets the active form.
        /// </summary>
        /// <value></value>
        public IForm ActiveForm
        {
            get
            {
                return mobjActiveForm;
            }
            set
            {
                mobjActiveForm = value;
            }
        }

        /// <summary>
        /// Gets the active form.
        /// </summary>
        /// <value></value>
        public IForm SuspendedActiveForm
        {
            get
            {
                return mobjSuspendedActiveForm;
            }
            set
            {
                mobjSuspendedActiveForm = value;
            }
        }

        /// <summary>
        /// Gets or sets the current main form.
        /// </summary>
        /// <value></value>
        public IForm MainForm
        {
            get
            {
                return mobjMainForm;
            }
            set
            {
                mobjMainForm = value;
            }
        }

        /// <summary>
        /// Gets or sets the current main form.
        /// </summary>
        /// <value></value>
        public IForm SuspendedMainForm
        {
            get
            {
                return mobjSuspendedMainForm;
            }
            set
            {
                mobjSuspendedMainForm = value;
            }
        }

        /// <summary>
        /// Gets or sets the current links stack.
        /// </summary>
        /// <value></value>
        internal Stack LinkStack
        {
            get
            {

                return null;
            }
        }

        /// <summary>
        /// Opens the link.
        /// </summary>
        /// <param name="objLink">link.</param>
        public void OpenLink(ILink objLink)
        {

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objLink"></param>
        /// <param name="objLinkParameters"></param>
        public void OpenLink(ILink objLink, ILinkParameters objLinkParameters)
        {

        }

        /// <summary>
        /// Gets or sets the current logon form.
        /// </summary>
        /// <value></value>
        public IForm LogonForm
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets the current referrer.
        /// </summary>
        /// <value></value>
        public string Referrer
        {
            get
            {
                return null;
            }
            set
            {

            }
        }


        #endregion Context Forms Related

        #region Context Command Related


        #endregion Context Command Related

        #region Router Properties

        /// <summary>
        /// Gets or sets the current UI culture.
        /// </summary>
        /// <value></value>
        public CultureInfo CurrentUICulture
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        /// <summary>
        /// Gets the state of the request processing.
        /// </summary>
        /// <value>
        /// The state of the request processing.
        /// </value>
        public RequestProcessingState RequestProcessingState
        {
            get
            {
                return RequestProcessingState.None;
            }
        }

        /// <summary>
        /// The current selected theme.
        /// </summary>
        public string CurrentTheme
        {
            get
            {
                string strTheme = "Default";

                if (Config != null)
                {
                    strTheme = Config.DefaultTheme;
                }

                return strTheme;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets available themes.
        /// </summary>
        public ReadOnlyCollection<string> AvailableThemes
        {
            get
            {
                if (marrAvailableThemes == null)
                {
                    List<string> arrAvailableThemes = new List<string>();
                    foreach (string strTheme in Config.GetInstance().AvailableThemes)
                    {
                        arrAvailableThemes.Add(strTheme);
                    }

                    marrAvailableThemes = new ReadOnlyCollection<string>(arrAvailableThemes);
                }

                return marrAvailableThemes;
            }
            set
            {
                marrAvailableThemes = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [multiple available themes].
        /// </summary>
        /// <value>
        /// <c>true</c> if [multiple available themes]; otherwise, <c>false</c>.
        /// </value>
        public bool SupportsMultipleThemes
        {
            get
            {
                if (this.AvailableThemes.Count > 1)
                {
                    return true;
                }
                else if (this.AvailableThemes.Count == 1)
                {
                    return this.AvailableThemes[0] != Config.GetInstance().DefaultTheme;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether in [full screen mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [full screen mode]; otherwise, <c>false</c>.
        /// </value>
        public bool FullScreenMode
        {
            get
            {
                return false;
            }
            set
            {

            }
        }


        #endregion Router Properties

        #region General

        /// <summary>
        /// Returns the application running mode
        /// </summary>
        public WebForms.ExecutionMode ExecutionMode
        {
            get
            {
                return WebForms.ExecutionMode.Client;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool DesignMode
        {
            get
            {
                return mobjClientDesignServices != null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public IClientDesignServices DesignServices
        {
            get
            {
                return mobjClientDesignServices;
            }
        }

        /// <summary>
        /// Gets a value indicating whether right to left mode is on.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if right to left mode is on; otherwise, <c>false</c>.
        /// </value>
        public bool RightToLeft
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether should apply mirroring.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should apply mirroring; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldApplyMirroring
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// Gets the presentation.
        /// </summary>
        /// <value>The presentation.</value>
        public Presentation Presentation
        {
            get
            {
                return Presentation.Agnostic;
            }
        }

        /// <summary>
        /// Gets the presentation engine.
        /// </summary>
        /// <value>The presentation engine.</value>
        public PresentationEngine PresentationEngine
        {
            get
            {
                return PresentationEngine.Agnostic;
            }
        }

        #endregion General

        #endregion Properties

        #region Methods

        #region IContextNotifications Members

        /// <summary>
        /// Enqueue update command
        /// </summary>
        /// <param name="objUpdateCommand"></param>
        private void EnqueueCommand(UpdateCommand objUpdateCommand)
        {
            // If not notification suspended
            if (!((IContextNotifications)this).IsNotificationSuspened)
            {
                // Enqueue update command
                mobjUpdateCommands.Enqueue(objUpdateCommand);

                // If in design mode send notifications
                if (this.DesignMode)
                {
                    ((IContextNotifications)this).SendNotifications();
                }
            }
        }

        /// <summary>
        /// Suspend notification
        /// </summary>
        void IContextNotifications.SuspendNotifications()
        {
            mintNotificationSuspended++;
        }

        /// <summary>
        /// Indicates if notifications are suspended
        /// </summary>
        bool IContextNotifications.IsNotificationSuspened
        {
            get
            {
                return mintNotificationSuspended > 0;
            }
        }

        /// <summary>
        /// Resume notifications
        /// </summary>
        void IContextNotifications.ResumeNotifications()
        {
            mintNotificationSuspended--;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        /// <param name="objItem"></param>
        void IContextNotifications.NotifyListItemAdded(Controllers.ObjectCollectionController objObjectCollectionController, object objItem)
        {
            EnqueueCommand(new UpdateListItemAddedCommand(objObjectCollectionController, objItem));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        /// <param name="objItem"></param>
        void IContextNotifications.NotifyListItemRemoved(Controllers.ObjectCollectionController objObjectCollectionController, object objItem)
        {
            EnqueueCommand(new UpdateListItemRemovedCommand(objObjectCollectionController, objItem));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        void IContextNotifications.NotifyListCleared(Controllers.ObjectCollectionController objObjectCollectionController)
        {
            EnqueueCommand(new UpdateListClearedCommand(objObjectCollectionController));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectController"></param>
        /// <param name="strProperty"></param>
        /// <param name="blnWebEvent"></param>
        void IContextNotifications.NotifyItemPropertyChanged(Controllers.ObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangeArgs, bool blnWebEvent)
        {
            EnqueueCommand(new UpdatePropertyCommand(objObjectController, objPropertyChangeArgs, blnWebEvent));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objFormController"></param>
        /// <param name="objWebForm"></param>
        void IContextNotifications.NotifyFormAdded(Controllers.FormController objFormController, object objWebForm)
        {
            EnqueueCommand(new UpdateFormAddedCommand(objFormController, objWebForm));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objFormController"></param>
        /// <param name="objWebForm"></param>
        void IContextNotifications.NotifyFormRemoved(Controllers.FormController objFormController, object objWebForm)
        {
            EnqueueCommand(new UpdateFormRemovedCommand(objFormController, objWebForm));
        }

        /// <summary>
        /// Send update notification to all controllers
        /// </summary>
        void IContextNotifications.SendNotifications()
        {
            // Update command reference
            UpdateCommand objUpdateCommand = null;

            // If there are update commands in queue
            if (this.mobjUpdateCommands.Count > 0)
            {
                // Get first update command
                objUpdateCommand = (UpdateCommand)this.mobjUpdateCommands.Dequeue();
            }

            // If update command is not null
            while (objUpdateCommand != null)
            {
                // Fire update command
                objUpdateCommand.Fire();

                // Get next update command or clear command refernece to break loop
                if (this.mobjUpdateCommands.Count > 0)
                {
                    // Get next update command
                    objUpdateCommand = (UpdateCommand)this.mobjUpdateCommands.Dequeue();
                }
                else
                {
                    objUpdateCommand = null;
                }
            }

            // If main form exists
            if (this.MainForm != null)
            {
                // If is a logon form
                if (this.MainForm is Gizmox.WebGUI.Common.Interfaces.ILogonForm)
                {
                    // If is logen on
                    if (this.IsLoggedOn)
                    {
                        // clear all upadate commands
                        this.mobjUpdateCommands.Clear();

                        // Get the windows form
                        WinForms.Form objWinForm = ((IContextServices)this).GetWinObject(this.MainForm) as WinForms.Form;
                        if (objWinForm != null)
                        {
                            // If not in closing mode
                            if (!mblnClosingMainForm)
                            {
                                // Set closing mode
                                mblnClosingMainForm = true;

                                // Close main form
                                objWinForm.Close();

                                // Terminate all controllers
                                TerminateControllers();

                                this.MainForm = null;

                                // Relese closing mode
                                mblnClosingMainForm = false;
                            }
                        }
                    }
                }
                // If the main form is closed
                else if (this.MainForm.IsClosed)
                {
                    // Get the windows form
                    WinForms.Form objWinForm = ((IContextServices)this).GetWinObject(this.MainForm) as WinForms.Form;
                    if (objWinForm != null)
                    {
                        // If not in closing mode
                        if (!mblnClosingMainForm)
                        {
                            // Set closing mode
                            mblnClosingMainForm = true;

                            // Close main form
                            objWinForm.Close();

                            // Terminate all controllers
                            TerminateControllers();

                            // Relese closing mode
                            mblnClosingMainForm = false;
                        }
                    }
                }
            }
        }


        #endregion IContextNotifications Members

        /// <summary>
        /// Terminate all working controllers
        /// </summary>
        private void TerminateControllers()
        {
            // Loop all controllers
            foreach (Controllers.ObjectController objController in this.mobjWebControllers.Values)
            {
                // Terminate current controller
                objController.Terminate();
            }

            // Clear all controllers
            mobjWebControllers.Clear();
            mobjWinControllers.Clear();
        }

        #region IContextServices Members

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        object IContextServices.GetWinObject(object objWebObject)
        {
            if (objWebObject != null)
            {
                Controllers.ObjectController objController = this.mobjWebControllers[objWebObject] as Controllers.ObjectController;
                if (objController != null)
                {
                    return objController.TargetObject;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinObject"></param>
        object IContextServices.GetWebObject(object objWinObject)
        {
            if (objWinObject != null)
            {
                Controllers.ObjectController objController = this.mobjWinControllers[objWinObject] as Controllers.ObjectController;
                if (objController != null)
                {
                    return objController.SourceObject;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objController"></param>
        void IContextServices.RegisterController(IClientObjectController objController)
        {
            this.mobjWebControllers[objController.SourceObject] = objController;
            this.mobjWinControllers[objController.TargetObject] = objController;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objController"></param>
        void IContextServices.UnregisterController(IClientObjectController objController)
        {
            this.mobjWebControllers.Remove(objController.SourceObject);
            this.mobjWinControllers.Remove(objController.TargetObject);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        IClientObjectController IContextServices.GetControllerByWebObject(object objWebObject)
        {
            return this.mobjWebControllers[objWebObject] as IClientObjectController;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinObject"></param>
        IClientObjectController IContextServices.CreateControllerByWinObject(object objWinObject)
        {
            return ObjectController.CreateControllerByWinObject(this, objWinObject);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinObject"></param>
        IClientObjectController IContextServices.CreateControllerByWebObject(object objWebObject)
        {
            return ObjectController.CreateControllerByWebObject(this, objWebObject);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinObject"></param>
        IClientObjectController IContextServices.GetControllerByWinObject(object objWinObject)
        {
            return this.mobjWinControllers[objWinObject] as IClientObjectController;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebObject"></param>
        void IContextServices.UnregisterControllerByWebObject(object objWebObject)
        {
            Controllers.ObjectController objController = this.mobjWebControllers[objWebObject] as Controllers.ObjectController;
            if (objController != null)
            {
                this.mobjWebControllers.Remove(objWebObject);
                this.mobjWinControllers.Remove(objController.TargetObject);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinObject"></param>
        void IContextServices.UnregisterControllerByWinObject(object objWinObject)
        {
            Controllers.ObjectController objController = this.mobjWinControllers[objWinObject] as Controllers.ObjectController;
            if (objController != null)
            {
                this.mobjWebControllers.Remove(objController.SourceObject);
                this.mobjWinControllers.Remove(objWinObject);
            }
        }

        /// <summary>
        ///
        /// </summary>
        void IContextServices.RefreshDesigner()
        {
            if (mobjClientDesignServices != null)
            {
                mobjClientDesignServices.RefreshDesigner();
            }
        }


        #endregion IContextServices Members

        /// <summary>
        /// Gets or sets a context parameter
        /// </summary>
        public object this[string strKey]
        {
            get
            {
                return mobjContextParams[strKey];
            }
            set
            {
                mobjContextParams[strKey] = value;
            }
        }

        /// <summary>
        /// Retunrs the current context arguments
        /// </summary>
        public NameValueCollection Arguments
        {
            get
            {
                if (mobjArgumentsProvider == null)
                {
                    mobjArgumentsProvider = new Providers.ArgumentsProvider();
                }
                return mobjArgumentsProvider;
            }
            set
            {
                mobjArgumentsProvider = value;
            }
        }

        /// <summary>
        /// Gets the current context results.
        /// </summary>
        /// <value></value>
        public NameValueCollection Results
        {
            get
            {
                if (mobjResultsProvider == null)
                {
                    mobjResultsProvider = new Providers.ResultsProvider();
                }
                return mobjResultsProvider;
            }
        }



        /// <summary>
        /// Terminates this form context.
        /// </summary>
        void IContextTerminate.Terminate(bool blnForce)
        {

        }


        /// <summary>
        /// Set pending termination for current context
        /// </summary>
        void IContextTerminate.SetPendingTermination()
        {
        }

        /// <summary>
        /// Clears pending termination for current context
        /// </summary>
        void IContextTerminate.ClearPendingTermination()
        {
        }

        /// <summary>
        /// Gets the value of the websockets connectionId (has no use in Client Context)
        /// </summary>
        string IContextParams.WebSocketConnectionId
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets the name of the current page.
        /// </summary>
        /// <value>
        /// The name of the current page.
        /// </value>
        string IContextParams.CurrentPageName
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the system pages.
        /// </summary>
        /// <value>
        /// The system pages.
        /// </value>
        ICollection<string> IContextParams.SystemPages
        {

            get
            {
                return null;
            }
        }

        /// <summary>
        /// Redirects the browser to a diffrent url
        /// </summary>
        /// <param name="url"></param>
        public void Redirect(string url)
        {
        }

        /// <summary>
        /// Transfers the current application to the specified form
        /// </summary>
        /// <param name="objForm">The form to transfer to.</param>
        /// <remarks>
        /// Transfer closes the current form and provides a diffrent form.
        /// </remarks>
        public void Transfer(IForm objForm)
        {
        }

        /// <summary>
        /// Terminates the current context.
        /// </summary>
        /// <param name="blnLogOff">if set to <c>true</c> [BLN log off].</param>
        public void Terminate(bool blnLogOff)
        {
        }

        #endregion Methods

        #region IContextMethodInvoker Members

        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="objTarget">target.</param>
        /// <param name="strMember">member.</param>
        /// <param name="arrArgs">args.</param>
        void IContextMethodInvoker.InvokeMethod(ISkinable objTarget, InvokationUniqueness enmUniqueness, string strMember, params object[] arrArgs)
        {

        }

        /// <summary>
        /// Get the client method name
        /// </summary>
        /// <param name="objTarget">The component</param>
        /// <param name="strMember">The method member name</param>
        /// <returns></returns>
        string IContextMethodInvoker.GetMethodName(ISkinable objTarget, string strMember)
        {
            return strMember;
        }


        #endregion IContextMethodInvoker Members

        #region ITimerHandlerContainer Members

        /// <summary>
        ///
        /// </summary>
        ITimerHandler ITimerHandlerContainer.Timers
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        bool ITimerHandlerContainer.HasTimers
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Invoke all required timers
        /// </summary>
        /// <param name="lngCurrentTicks"></param>
        int ITimerHandlerContainer.InvokeTimers(long lngCurrentTicks)
        {
            return 0;
        }


        #endregion ITimerHandlerContainer Members

        #region Resource Services

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinImagelist"></param>
        /// <param name="objResourceHandler"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        int IContextResources.GetWinImageIndex(WinForms.ImageList objWinImagelist, ResourceHandle objResourceHandler, string strKey)
        {
            Image objWinImage = ((IContextResources)this).GetWinImageFromResourceHandle(objResourceHandler);
            if (objWinImage != null)
            {
                if (objWinImagelist != null)
                {
                    if (strKey != null)
                    {
                        objWinImagelist.Images.Add(strKey, objWinImage);
                    }
                    else
                    {
                        objWinImagelist.Images.Add(objWinImage);
                    }

                    return objWinImagelist.Images.Count - 1;
                }
            }

            return -1;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinImagelist"></param>
        /// <param name="objResourceHandler"></param>
        /// <returns></returns>
        int IContextResources.GetWinImageIndex(WinForms.ImageList objWinImagelist, ResourceHandle objResourceHandler)
        {
            return ((IContextResources)this).GetWinImageIndex(objWinImagelist, objResourceHandler, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objGatewayResourceHandle"></param>
        /// <returns></returns>
        Stream IContextResources.GetGatewayResourceStream(GatewayResourceHandle objGatewayResourceHandle)
        {
            try
            {
                IGatewayControl objGatewayControl = objGatewayResourceHandle.Component as IGatewayControl;
                if (objGatewayControl != null)
                {
                    System.Web.HttpWorkerRequest objHttpWorkerRequest = new GatewayRequest();
                    System.Web.HttpContext.Current = new System.Web.HttpContext(objHttpWorkerRequest);
                    GatewayStream objGatewayStream = new GatewayStream(System.Web.HttpContext.Current.Response.Filter);
                    System.Web.HttpContext.Current.Response.Filter = objGatewayStream;
                    IGatewayHandler objGatewayHandler = objGatewayControl.GetGatewayHandler(this, objGatewayResourceHandle.Action);
                    if (objGatewayHandler != null)
                    {
                        objGatewayHandler.ProcessGatewayRequest(this, objGatewayResourceHandle.Component);
                    }
                    System.Web.HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current = null;
                    objGatewayStream.Position = 0;
                    return objGatewayStream;
                }
            }
            catch
            {
            }
            return null;
        }

        /// <summary>
        /// Gets the named directory.
        /// </summary>
        /// <param name="strDirectoryName">The directory name.</param>
        /// <returns></returns>
        private string GetNamedDirectory(string strDirectoryName)
        {
            if (this.DesignServices != null)
            {
                return this.DesignServices.GetNamedDirecotry(strDirectoryName);
            }
            else
            {
                return Config.GetDirectory(strDirectoryName);
            }
        }

        /// <summary>
        /// Gets a image form a resource hand;e
        /// </summary>
        /// <param name="objResourceHandler"></param>
        /// <returns></returns>
        Image IContextResources.GetWinImageFromResourceHandle(ResourceHandle objResourceHandler)
        {
            if (objResourceHandler != null)
            {
                string strNamedDirectory = null;

                // For Icon and Image handles, the handler needs the path of the image
                if (objResourceHandler is IconResourceHandle)
                {
                    strNamedDirectory = this.GetNamedDirectory("Icons");
                }

                if (objResourceHandler is ImageResourceHandle)
                {
                    strNamedDirectory = this.GetNamedDirectory("Images");
                }

                // Get images from path
                if (!string.IsNullOrEmpty(strNamedDirectory))
                {
                    DirectoryInfo objDirectoryInfo = new DirectoryInfo(strNamedDirectory);
                    if (objDirectoryInfo != null)
                    {

                        Stream objStream = objResourceHandler.GetPhysicalResourceHandleStream(objDirectoryInfo);
                        if (objStream != null)
                        {
                            return Image.FromStream(objStream);
                        }
                    }
                }

                // if Type resource handle, get the image
                TypeResourceHandle objTypeResource = objResourceHandler as TypeResourceHandle;
                if (objTypeResource != null)
                {
                    return objTypeResource.ToImage();
                }

                // Url resource handle logic
                UrlResourceHandle objUrlResourceHandle = objResourceHandler as UrlResourceHandle;
                if (objUrlResourceHandle != null)
                {
                    System.Net.HttpWebRequest objRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(objUrlResourceHandle.File);
                    objRequest.Method = "GET";

                    System.Net.WebResponse objWebResponse = objRequest.GetResponse();
                    if (objWebResponse != null)
                    {
                        Stream objResponseStream = objWebResponse.GetResponseStream();
                        if (objResponseStream != null)
                        {
                            return Image.FromStream(objResponseStream);
                        }
                    }

                }

                // Gateway resource handle logic
                GatewayResourceHandle objGatewayResourceHandle = objResourceHandler as GatewayResourceHandle;
                if (objGatewayResourceHandle != null)
                {
                    Stream objResourceStream = ((IContextResources)this).GetGatewayResourceStream(objGatewayResourceHandle);
                    if (objResourceStream != null)
                    {
                        return Image.FromStream(objResourceStream);
                    }
                }
                }

            return null;
        }


        #endregion Resource Services

        #region IClinetDesignContext Members

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
        IClientObjectController IClinetDesignContext.CreateControllerByWebObject(IContext objContext, object objWebObject)
        {
            return ObjectController.CreateControllerByWebObject(objContext, objWebObject) as IClientObjectController;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebType"></param>
        IClientObjectController IClinetDesignContext.CreateControllerByWebType(IContext objContext, Type objWebType)
        {
            return ObjectController.CreateControllerByWebType(objContext, objWebType) as IClientObjectController;
        }

        /// <summary>
        /// Initialized controller for design time usage
        /// </summary>
        /// <param name="objObjectController"></param>
        void IClinetDesignContext.InitializeController(IClientObjectController objObjectController)
        {
            ObjectController objInstanceObjectController = objObjectController as ObjectController;
            if (objInstanceObjectController != null)
            {
                objInstanceObjectController.Initialize(true);
                objInstanceObjectController.Load(true);
            }
        }


        bool IClinetDesignContext.IsNotificationSuspened
        {
            get
            {
                return ((IContextNotifications)this).IsNotificationSuspened;
            }
        }

        void IClinetDesignContext.NotifyItemPropertyChanged(IClientObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangedArgs, bool blnWebEvent)
        {
            ((IContextNotifications)this).NotifyItemPropertyChanged((ObjectController)objObjectController, objPropertyChangedArgs, blnWebEvent);
        }



        #endregion IClinetDesignContext Members


        #region IContextParams Members

        string IContextParams.Browser
        {
            get
            {
                return "WinForms";
            }
        }

        private WinForms.Screen CurrentScreen
        {
            get
            {
                return WinForms.Screen.PrimaryScreen;
            }
        }

        /// <summary>
        /// Gets the startup device orientation.
        /// </summary>
        DeviceOrientation IContextParams.StartupDeviceOrientation
        {
            get { return DeviceOrientation.Landscape; }
        }

        int IContextParams.ScreenAvailableHeight
        {
            get { return this.CurrentScreen.WorkingArea.Height; }
        }

        int IContextParams.ScreenAvailableWidth
        {
            get { return this.CurrentScreen.WorkingArea.Width; }
        }

        int IContextParams.ScreenHeight
        {
            get { return this.CurrentScreen.Bounds.Height; }
            set { }
        }

        int IContextParams.ScreenWidth
        {
            get { return this.CurrentScreen.Bounds.Width; }
            set { }
        }

        int IContextParams.ScreenDevicePixelRatio
        {
            get { return -1; }
        }

        string[] IContextParams.PreloadedResources
        {
            get
            {
                return null;
            }
        }

        CSS3BrowserCapabilities IContextParams.CSS3BrowserCapabilities
        {
            get { return this.menmCSS3BrowserCapabilities; }
            set { }
        }

        HTML5BrowserCapabilities IContextParams.HTML5BrowserCapabilities
        {
            get { return this.menmHTML5BrowserCapabilities; }
            set { }
        }

        MISCBrowserCapabilities IContextParams.MISCBrowserCapabilities
        {
            get { return this.menmMISCBrowserCapabilities; }
            set { }
        }

        public bool IsPngSupport
        {
            get
            {
                return (((IContextParams)this).MISCBrowserCapabilities & MISCBrowserCapabilities.PngSupport) == MISCBrowserCapabilities.PngSupport;
            }
        }

        private Graphics mobjMeasurementGraphics = null;

        Graphics IContextParams.MeasurementGraphics
        {
            get
            {
                if (mobjMeasurementGraphics == null)
                {
                    Bitmap objMeasurementBitmap = new Bitmap(1, 1);
                    mobjMeasurementGraphics = Graphics.FromImage(objMeasurementBitmap);
                }
                return mobjMeasurementGraphics;
            }
        }

        int IContextParams.ScreenColorDepth
        {
            get
            {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                return this.CurrentScreen.BitsPerPixel;
#else
				return 32;
#endif
            }
        }

        /// <summary>
        /// Gets or sets the modifier keys.
        /// </summary>
        /// <value>
        /// The modifier keys.
        /// </value>
        Keys IContextParams.ModifierKeys
        {
            get
            {
                return Keys.None;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        Point IContextParams.CursorPosition
        {
            get
            {
                return Point.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the SSO logon authentication.
        /// </summary>
        /// <value>
        /// The SSO logon authentication.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        NameValueCollection IContextParams.SSOData
        {
            get
            {

                return null;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets the last render.
        /// </summary>
        long IContextParams.LastRender
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the browser id.
        /// </summary>
        /// <value>
        /// The browser id.
        /// </value>
        string IContextParams.BrowserId
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the emulator form.
        /// </summary>
        /// <value>
        /// The emulator form.
        /// </value>
        IEmulatorForm IContextParams.EmulatorForm
        {
            get
            {
                return mobjEmulatorForm;
            }
            set
            {
                mobjEmulatorForm = value;
            }
        }

        /// <summary>
        /// Gets or sets the emulation device.
        /// </summary>
        IEmulationDevice IContextParams.EmulationDevice
        {
            get
            {
                return mobjEmulationDevice;
            }
            set
            {
                mobjEmulationDevice = value;
            }
        }

        /// <summary>
        /// Gets or sets the active proxy master page.
        /// </summary>
        IProxyMasterPage IContextParams.ActiveProxyMasterPage
        {
            get
            {
                return mobjActiveProxyMasterPage;
            }
            set
            {
                mobjActiveProxyMasterPage = value;
            }
        }

        /// <summary>
        /// Gets a map between master page name and the master page object.
        /// </summary>
        Dictionary<string, IProxyMasterPage> IContextParams.NameProxyMasterPageMap
        {
            get
            {
                return mobjNameProxyMasterPageMap;
            }
        }

        /// <summary>
        /// Gets the form access mode.
        /// </summary>
        /// <param name="objForm">The form.</param>
        /// <returns></returns>
        FormAccessMode IContextParams.GetFormAccessMode(IForm objForm)
        {
            return FormAccessMode.FullControl;
        }

        /// <summary>
        /// Creates the form. Empty Implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrArguments">The arr arguments.</param>
        /// <returns></returns>
        IForm IContext.CreateForm<T>(params object[] arrArguments)
        {
            return null;
        }

        /// <summary>
        /// Gets or sets the contextual toolbar.
        /// </summary>
        /// <value>
        /// The contextual toolbar.
        /// </value>
        IForm IContextParams.ContextualToolbar
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Invokes the component message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ComponentMessageEventArgs" /> instance containing the event data.</param>
        void IContextParams.InvokeComponentMessage(object sender, ComponentMessageEventArgs e)
        {
        }

        #endregion


        #region IContextCommonDialogHandler Members

        /// <summary>
        /// Handles commong dialog execution
        /// </summary>
        /// <param name="objCommonDialog"></param>
        /// <param name="objOwner"></param>
        /// <param name="objCloseHandler"></param>
        /// <param name="objDirectHandler"></param>
        public void ShowDialog(ICommonDialog objCommonDialog, IForm objOwner, EventHandler objCloseHandler, EventHandler objDirectHandler)
        {
            ContextCommonDialogHandler objCommonDialogHander = new ContextCommonDialogHandler();

            // Get the winforms form
            WinForms.Form objWinForm = ((IContextServices)this).GetWinObject(objOwner != null ? objOwner : this.ActiveForm) as WinForms.Form;
            if (objWinForm != null)
            {
                // Show winforms dialog
                objCommonDialogHander.ShowDialog(objCommonDialog, objWinForm, objCloseHandler, objDirectHandler);
            }
            else
            {
                throw new Exception("Can not find winforms owner.");
            }
        }

        #endregion

        #region IClientDesignServices Members

        void IClientDesignServices.FireWebComponentChanged(object objSource, string strPropertyName, object objOldValue, object objNewValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.FireWebComponentChanging(object objSource, string strPropertyName)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        void IClientDesignServices.FireWinComponentChanged(object objSource, string strPropertyName, object objOldValue, object objNewValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.FireWinComponentChanging(object objSource, string strPropertyName)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        Config IClientDesignServices.GetConfiguration()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IClientDesignServices.GetNamedDirecotry(string strDirectoryName)
        {
            return mobjClientDesignServices.GetNamedDirecotry(strDirectoryName);
        }

        ICollection IClientDesignServices.GetSelectedWebComponents()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        ICollection IClientDesignServices.GetSelectedWinComponents()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        bool IClientDesignServices.IsRegisteredWebComponent(IComponent objWebComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        bool IClientDesignServices.IsRegisteredWinComponent(IComponent objWinComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RefreshDesigner()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RegisterWebComponent(IComponent objContainerComponent, IComponent objWebComponent, string strName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RegisterWebComponent(IComponent objContainerComponent, IComponent objWebComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RegisterWebComponent(IComponent objWebComponent, string strName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RegisterWebComponent(IComponent objWebComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RegisterWinComponent(IComponent objWinComponent, string strName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.RegisterWinComponent(IComponent objWinComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.SelectWebComponent(IComponent objWebComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.UnregisterWebComponent(IComponent objWebComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IClientDesignServices.UnregisterWinComponent(IComponent objWinComponent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        IDesignTimeDeviceRepository IClientDesignServices.DesignTimeDeviceRepository
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        SizeF IClientDesignServices.GetFormScaleFactor(string strBrowserId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IClientDesignServices.GetBrowserId(string strFormStrongTypeName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IClientDesignServices.GetConfigurationPath(string strConfig)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IClinetDesignContext Members


        /// <summary>
        /// </summary>
        void IClinetDesignContext.ResumeNotifications()
        {
            ((IContextNotifications)this).ResumeNotifications();
        }

        /// <summary>
        /// </summary>
        void IClinetDesignContext.SuspendNotifications()
        {
            ((IContextNotifications)this).SuspendNotifications();
        }

        #endregion



        #region ISessionRegistry Members

        /// <summary>
        /// Component registry hashtable (holds id to component relation).
        /// </summary>
        private Hashtable mobjComponentRegistry = new Hashtable();


        /// <summary>
        /// The session id counter
        /// </summary>
        private long mintCurrentId = 1;


        /// <summary>
        ///
        /// </summary>
        int ISessionRegistry.Count
        {
            get
            {
                return mobjComponentRegistry.Count;
            }
        }

        /// <summary>
        ///
        /// </summary>
        IEnumerator ISessionRegistry.GetEnumerator()
        {
            return mobjComponentRegistry.GetEnumerator();
        }

        /// <summary>
        /// Registers a component.
        /// </summary>
        /// <param name="objComponent">component.</param>
        public void RegisterComponent(IRegisteredComponent objComponent)
        {
            // Check if component is already registered
            if (!objComponent.IsRegistered)
            {
                // Assign new guid
                if ((objComponent.RegisteredState & RegisteredState.Identified) != RegisteredState.Identified)
                {
                    objComponent.ID = mintCurrentId++;
                }


                // Add to component registry
                mobjComponentRegistry.Add(objComponent.ID.ToString(), objComponent);

                // Register the context menu if there is one
                objComponent.RegisterContextMenu();

                // If the component is a control
                IControl objControl = objComponent as IControl;
                if (objControl != null)
                {
                    RegisterBatch(objControl.Controls);
                }

                IRegisteredComponentContainer objContainer = objComponent as IRegisteredComponentContainer;
                if (objContainer != null)
                {
                    if (objContainer.ContainedComponents != null)
                    {
                        RegisterBatch(objContainer.ContainedComponents);
                    }
                }

                // Flag as registered component
                objComponent.IsRegistered = true;
            }
        }

        /// <summary>
        /// Unregisters a component.
        /// </summary>
        /// <param name="objComponent">component.</param>
        public void UnRegisterComponent(IRegisteredComponent objComponent)
        {
            // If the component is registered
            if (objComponent.IsRegistered)
            {
                // Remove component from registry
                mobjComponentRegistry.Remove(objComponent.ID.ToString());

                // Set non registered component
                objComponent.IsRegistered = false;

                // Unregister componen menu if needed
                objComponent.UnregisterContextMenu();

                objComponent.UnregisterComponents();


            }
        }

        /// <summary>
        /// Registers the component batch.
        /// </summary>
        /// <param name="objCollection">Obj collection.</param>
        public void RegisterBatch(ICollection objCollection)
        {
            // Loop and register all components
            foreach (IRegisteredComponent objComponent in objCollection)
            {
                RegisterComponent(objComponent);
            }
        }

        /// <summary>
        /// Unregister component batch.
        /// </summary>
        /// <param name="objCollection">Obj collection.</param>
        public void UnRegisterBatch(ICollection objCollection)
        {
            // Loop and un register all components
            foreach (IRegisteredComponent objComponent in objCollection)
            {
                UnRegisterComponent(objComponent);
            }
        }

        /// <summary>
        /// Gets a registered component.
        /// </summary>
        /// <param name="strComponentId">component id.</param>
        /// <returns></returns>
        public IRegisteredComponent GetRegisteredComponent(string strComponentId)
        {
            // Search component in registry
            return mobjComponentRegistry[strComponentId] as IRegisteredComponent;
        }

        /// <summary>
        /// Gets a registered component.
        /// </summary>
        /// <param name="lngComponentId">component id.</param>
        /// <returns></returns>
        public IRegisteredComponent GetRegisteredComponent(long lngComponentId)
        {
            // Search component in registry
            return mobjComponentRegistry[lngComponentId.ToString()] as IRegisteredComponent;
        }



        #endregion

        #region IContext Members


        /// <summary>
        /// The current request host context.
        /// </summary>
        /// <value></value>
        public Gizmox.WebGUI.Hosting.HostContext HostContext
        {
            get
            {
                return null;
            }
        }

        public event ComponentMessageEventHandler ComponentMessage;

        IDeviceIntegrator IContext.DeviceIntegrator
        {
            get
            {
                return null;
            }
        }



        #endregion

        #region IContext Members


        public IContextThreadingService GetThreadingService()
        {
            return null;
        }

        #endregion

        public Common.WebSockets.WebSocketService WebSocketService        {
            get
            {
               return null;
            }
            set
            {
            }
        }
    }

    #endregion Context Class


    internal class ContextCommonDialogHandler : ICommonDialogHandler
    {

        private EventHandler mobjDirectEventHandler = null;

        private EventHandler mobjCloseEventHandler = null;

        private ICommonDialog mobjCommonDialog = null;

        private WebForms.DialogResult mobjWebDialogResult = WebForms.DialogResult.None;

        public ContextCommonDialogHandler()
        {
        }


        public void ShowDialog(ICommonDialog objCommonDialog, WinForms.Form objOwner, EventHandler objCloseHandler, EventHandler objDirectHandler)
        {
            // Set local variables
            mobjDirectEventHandler = objDirectHandler;
            mobjCloseEventHandler = objCloseHandler;
            mobjCommonDialog = objCommonDialog;

            WebForms.FontDialog objFontDialog = objCommonDialog as WebForms.FontDialog;
            if (objFontDialog != null)
            {
                ShowFontDialog(objFontDialog, objOwner);
            }

            WebForms.ColorDialog objColorDialog = objCommonDialog as WebForms.ColorDialog;
            if (objColorDialog != null)
            {
                ShowColorDialog(objColorDialog, objOwner);
            }

            WebForms.OpenFileDialog objOpenFileDialog = objCommonDialog as WebForms.OpenFileDialog;
            if (objOpenFileDialog != null)
            {
                ShowOpenFileDialog(objOpenFileDialog, objOwner);
            }

            WebForms.FolderBrowserDialog objFolderBrowserDialog = objCommonDialog as WebForms.FolderBrowserDialog;
            if (objFolderBrowserDialog != null)
            {
                ShowFolderBrowserDialog(objFolderBrowserDialog, objOwner);
            }
        }

        private void ShowFolderBrowserDialog(WebForms.FolderBrowserDialog objOpenFileDialog, WinForms.Form objOwner)
        {
            WinForms.FolderBrowserDialog objWinFolderBrowserDialog = new WinForms.FolderBrowserDialog();

            // Set the winforms dialog properties as for the webgui dialog.
            CopyCommonProperties(objOpenFileDialog, objWinFolderBrowserDialog);

            // Show the color dialog.
            objWinFolderBrowserDialog.ShowDialog(objOwner);


            if (objWinFolderBrowserDialog.SelectedPath != objOpenFileDialog.SelectedPath)
            {
                objOpenFileDialog.SelectedPath = objWinFolderBrowserDialog.SelectedPath;
                mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            }
            OnDialogClosed();
        }

        private void ShowColorDialog(WebForms.ColorDialog objWebColorDialog, WinForms.Form objOwner)
        {
            WinForms.ColorDialog objWinColorDialog = new WinForms.ColorDialog();

            // Set the winforms dialog properties as for the webgui dialog.
            CopyCommonProperties(objWebColorDialog, objWinColorDialog);

            // Show the color dialog.
            objWinColorDialog.ShowDialog(objOwner);


            if (objWinColorDialog.Color != objWebColorDialog.Color)
            {
                objWebColorDialog.Color = objWinColorDialog.Color;
                mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            }
            OnDialogClosed();
        }

        private void ShowFontDialog(WebForms.FontDialog objWebFontDialog, WinForms.Form objOwner)
        {
            WinForms.FontDialog objWinFontDialog = new WinForms.FontDialog();

            // Set the winforms dialog properties as for the webgui dialog.
            CopyCommonProperties(objWebFontDialog, objWinFontDialog);

            // Register the apply event.
            objWinFontDialog.Apply += new EventHandler(objWinFontDialog_Apply);

            // Show the font dialog.
            objWinFontDialog.ShowDialog(objOwner);

            if (objWinFontDialog.Font != objWebFontDialog.Font)
            {
                objWebFontDialog.Font = objWinFontDialog.Font;
                mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
            }
            OnDialogClosed();
        }

        void objWinFontDialog_Apply(object sender, EventArgs e)
        {
            mobjCommonDialog.OnApply();
        }

        private void ShowOpenFileDialog(WebForms.OpenFileDialog objWebOpenFileDialog, WinForms.Form objOwner)
        {
            WinForms.OpenFileDialog objWinOpenFileDialog = new WinForms.OpenFileDialog();

            // Set the winforms dialog properties as for the webgui dialog.
            CopyCommonProperties(objWebOpenFileDialog, objWinOpenFileDialog);

            // Set FileOK event
            objWinOpenFileDialog.FileOk += new CancelEventHandler(objWinOpenFileDialog_FileOk);

            // Show the open file dialog.
            objWinOpenFileDialog.ShowDialog(objOwner);

            // Checks that the winforms dialog was submited.
            if (mobjWebDialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
            {
                // Clear previous files from the webgui dialog.
                objWebOpenFileDialog.Files.Clear();

                // Add selected files from the winforms dialog to the webgui dialog.
                foreach (string strWinFile in objWinOpenFileDialog.FileNames)
                {
                    objWebOpenFileDialog.Files.Add(strWinFile, PhysicalFileHandle.Create(strWinFile));
                }
            }

            OnDialogClosed();
        }

        /// <summary>
        /// Copy common properties from source object to target object.
        /// </summary>
        /// <param name="objSource"></param>
        /// <param name="objTarget"></param>
        private void CopyCommonProperties(object objSource, object objTarget)
        {
            if (objSource != null &&
                objTarget != null)
            {
                // Get source and target types.
                Type objSourceType = objSource.GetType();
                Type objTargetType = objTarget.GetType();

                if (objSourceType != null &&
                    objTargetType != null)
                {
                    // Get source properties
                    PropertyInfo[] objSourcePropertyInfos = objSourceType.GetProperties();

                    if (objSourcePropertyInfos != null)
                    {
                        // Runs over source properties.
                        foreach (PropertyInfo objSourcePropertyInfo in objSourcePropertyInfos)
                        {
                            // get active source property from target object.
                            PropertyInfo objTargetPropertyInfo = objTargetType.GetProperty(objSourcePropertyInfo.Name);

                            // Checks that target property exists, not read only and from the same type as the source property.
                            if (objTargetPropertyInfo != null &&
                                objTargetPropertyInfo.CanWrite &&
                                objTargetPropertyInfo.PropertyType == objSourcePropertyInfo.PropertyType)
                            {
                                // Get the property value from the source object.
                                object objPropertyValue = objSourceType.InvokeMember(objSourcePropertyInfo.Name, BindingFlags.GetProperty, null, objSource, null);

                                // Set the property value to the target object.
                                objTargetType.InvokeMember(objTargetPropertyInfo.Name, BindingFlags.SetProperty, null, objTarget, new object[] { objPropertyValue });
                            }
                        }
                    }
                }
            }
        }

        void objWinOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
        }

        private void OnDialogClosed()
        {
            if (mobjCloseEventHandler != null)
            {
                mobjCloseEventHandler(this, Event.Empty);
            }
        }

        #region ICommonDialogHandler Members

        WebForms.DialogResult ICommonDialogHandler.DialogResult
        {
            get
            {
                return mobjWebDialogResult;
            }
        }

        EventHandler ICommonDialogHandler.DirectHandler
        {
            get
            {
                return mobjDirectEventHandler;
            }
        }

        #endregion
    }


    #region Context Interfaces



    #region IContextContainer Interface

    /// <summary>
    /// Defines a context contained object (Used to provide context for controls)
    /// </summary>
    public interface IContextContainer
    {
        #region Properties

        /// <summary>
        ///
        /// </summary>
        IContext Context
        {
            get;
            set;
        }


        #endregion Properties

    }

    #endregion IContextContainer Interface

    #region IContextNotifications Interface

    public interface IContextNotifications
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        void SuspendNotifications();

        /// <summary>
        ///
        /// </summary>
        void ResumeNotifications();

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        /// <param name="objItem"></param>
        void NotifyListItemAdded(Controllers.ObjectCollectionController objObjectCollectionController, object objItem);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        /// <param name="objItem"></param>
        void NotifyListItemRemoved(Controllers.ObjectCollectionController objObjectCollectionController, object objItem);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectCollectionController"></param>
        void NotifyListCleared(Controllers.ObjectCollectionController objObjectCollectionController);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObjectController"></param>
        /// <param name="strProperty"></param>
        /// <param name="blnWebEvent"></param>
        void NotifyItemPropertyChanged(Controllers.ObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangeArgs, bool blnWebEvent);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objFormController"></param>
        /// <param name="objWebForm"></param>
        void NotifyFormAdded(Controllers.FormController objFormController, object objWebForm);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objFormController"></param>
        /// <param name="objWebForm"></param>
        void NotifyFormRemoved(Controllers.FormController objFormController, object objWebForm);

        /// <summary>
        /// Send update notification to all controllers
        /// </summary>
        void SendNotifications();


        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        ///
        /// </summary>
        bool IsNotificationSuspened
        {
            get;
        }

        #endregion Properties

    }

    #endregion IContextNotifications Interface

    #region IContextResources Interface

    public interface IContextResources
    {
        #region C'Tor / D'Tor


        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinImagelist"></param>
        /// <param name="objResourceHandler"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        int GetWinImageIndex(WinForms.ImageList objWinImagelist, ResourceHandle objResourceHandler, string strKey);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWinImagelist"></param>
        /// <param name="objResourceHandler"></param>
        /// <returns></returns>
        int GetWinImageIndex(WinForms.ImageList objWinImagelist, ResourceHandle objResourceHandler);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objGatewayResourceHandle"></param>
        /// <returns></returns>
        Stream GetGatewayResourceStream(GatewayResourceHandle objGatewayResourceHandle);

        /// <summary>
        /// Gets a image form a resource hand;e
        /// </summary>
        /// <param name="objResourceHandler"></param>
        /// <returns></returns>
        Image GetWinImageFromResourceHandle(ResourceHandle objResourceHandler);


        #endregion C'Tor / D'Tor

    }

    #endregion IContextResources Interface

    #endregion Context Interfaces

}
