using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client
{
	internal class Context : IContext, INonSerializable, IContextTerminate, IContextMethodInvoker, ITimerHandlerContainer, IContextServices, IContextNotifications, IContextResources, IClinetDesignContext, IContextParams, IContextCommonDialogHandler, IClientDesignServices, ISessionRegistry
	{
		private ReadOnlyCollection<object> marrAvailableThemes;

		private object mobjHttpContext = null;

		private Request mobjRequest = null;

		private Hashtable mobjContextParams = null;

		private Response mobjResponse = null;

		private Session mobjSession = null;

		private Application mobjApplication = null;

		private ICookies mobjCookies = null;

		private IForm mobjMainForm = null;

		private IForm mobjSuspendedMainForm = null;

		private IForm mobjActiveForm = null;

		private IForm mobjSuspendedActiveForm = null;

		private IEmulatorForm mobjEmulatorForm = null;

		private IEmulationDevice mobjEmulationDevice = null;

		private IProxyMasterPage mobjActiveProxyMasterPage = null;

		private Dictionary<string, IProxyMasterPage> mobjNameProxyMasterPageMap = new Dictionary<string, IProxyMasterPage>();

		private static Config mobjConfig = null;

		private NameValueCollection mobjArgumentsProvider = null;

		private NameValueCollection mobjResultsProvider = null;

		private Hashtable mobjWebControllers = null;

		private Hashtable mobjWinControllers = null;

		private static IServer mobjServer = null;

		private bool mblnClosingMainForm = false;

		private Queue mobjUpdateCommands = null;

		private IClientDesignServices mobjClientDesignServices = null;

		private int mintNotificationSuspended = 0;

		private int mintResizingSuspended = 0;

		private CSS3BrowserCapabilities menmCSS3BrowserCapabilities = CSS3BrowserCapabilities.Empty;

		private HTML5BrowserCapabilities menmHTML5BrowserCapabilities = HTML5BrowserCapabilities.Empty;

		private MISCBrowserCapabilities menmMISCBrowserCapabilities = MISCBrowserCapabilities.Empty;

		private Graphics mobjMeasurementGraphics = null;

		private Hashtable mobjComponentRegistry = new Hashtable();

		private long mintCurrentId = 1L;

		public Config Config
		{
			get
			{
				if (mobjConfig == null || CommonUtils.IsDesignMode)
				{
					mobjConfig = Config.GetInstance();
					if (mobjConfig == null)
					{
						mobjConfig = DesignServices.GetConfiguration();
					}
				}
				return mobjConfig;
			}
		}

		public IRequest Request
		{
			get
			{
				if (mobjRequest == null)
				{
					mobjRequest = new Request(this);
				}
				return mobjRequest;
			}
		}

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

		public IApplication Application
		{
			get
			{
				if (mobjApplication == null)
				{
					mobjApplication = new Application(this);
				}
				return mobjApplication;
			}
		}

		public HttpContext HttpContext => null;

		public ISession Session
		{
			get
			{
				if (mobjSession == null)
				{
					mobjSession = new Session(this);
				}
				return mobjSession;
			}
		}

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

		internal Stack LinkStack => null;

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

		public CultureInfo CurrentUICulture
		{
			get
			{
				return Thread.CurrentThread.CurrentUICulture;
			}
			set
			{
				Thread.CurrentThread.CurrentUICulture = value;
			}
		}

		public RequestProcessingState RequestProcessingState => RequestProcessingState.None;

		public string CurrentTheme
		{
			get
			{
				string result = "Default";
				if (Config != null)
				{
					result = Config.DefaultTheme;
				}
				return result;
			}
			set
			{
			}
		}

		public ReadOnlyCollection<object> AvailableThemes
		{
			get
			{
				if (marrAvailableThemes == null)
				{
					List<object> list = new List();
					foreach (string availableTheme in Config.GetInstance().AvailableThemes)
					{
						list.Add(availableTheme);
					}
					marrAvailableThemes = new ReadOnlyCollection(list);
				}
				return marrAvailableThemes;
			}
			set
			{
				marrAvailableThemes = value;
			}
		}

		public bool SupportsMultipleThemes
		{
			get
			{
				if (AvailableThemes.Count > 1)
				{
					return true;
				}
				if (AvailableThemes.Count == 1)
				{
					return AvailableThemes[0] != Config.GetInstance().DefaultTheme;
				}
				return false;
			}
		}

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

		public ExecutionMode ExecutionMode => ExecutionMode.Client;

		public bool DesignMode => mobjClientDesignServices != null;

		public IClientDesignServices DesignServices => mobjClientDesignServices;

		public bool RightToLeft => false;

		public bool ShouldApplyMirroring => false;

		public Presentation Presentation => Presentation.Agnostic;

		public PresentationEngine PresentationEngine => PresentationEngine.Agnostic;

		bool IContextNotifications.IsNotificationSuspened => mintNotificationSuspended > 0;

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

		public NameValueCollection Arguments
		{
			get
			{
				if (mobjArgumentsProvider == null)
				{
					mobjArgumentsProvider = new ArgumentsProvider();
				}
				return mobjArgumentsProvider;
			}
			set
			{
				mobjArgumentsProvider = value;
			}
		}

		public NameValueCollection Results
		{
			get
			{
				if (mobjResultsProvider == null)
				{
					mobjResultsProvider = new ResultsProvider();
				}
				return mobjResultsProvider;
			}
		}

		string IContextParams.WebSocketConnectionId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		string IContextParams.CurrentPageName => null;

		ICollection<object> IContextParams.SystemPages => null;

		ITimerHandler ITimerHandlerContainer.Timers => null;

		bool ITimerHandlerContainer.HasTimers => false;

		bool IClinetDesignContext.IsNotificationSuspened => ((IContextNotifications)this).IsNotificationSuspened;

		string IContextParams.Browser => "WinForms";

		private System.Windows.Forms.Screen CurrentScreen => System.Windows.Forms.Screen.PrimaryScreen;

		DeviceOrientation IContextParams.StartupDeviceOrientation => DeviceOrientation.Landscape;

		int IContextParams.ScreenAvailableHeight => CurrentScreen.WorkingArea.Height;

		int IContextParams.ScreenAvailableWidth => CurrentScreen.WorkingArea.Width;

		int IContextParams.ScreenHeight
		{
			get
			{
				return CurrentScreen.Bounds.Height;
			}
			set
			{
			}
		}

		int IContextParams.ScreenWidth
		{
			get
			{
				return CurrentScreen.Bounds.Width;
			}
			set
			{
			}
		}

		int IContextParams.ScreenDevicePixelRatio => -1;

		string[] IContextParams.PreloadedResources => null;

		CSS3BrowserCapabilities IContextParams.CSS3BrowserCapabilities
		{
			get
			{
				return menmCSS3BrowserCapabilities;
			}
			set
			{
			}
		}

		HTML5BrowserCapabilities IContextParams.HTML5BrowserCapabilities
		{
			get
			{
				return menmHTML5BrowserCapabilities;
			}
			set
			{
			}
		}

		MISCBrowserCapabilities IContextParams.MISCBrowserCapabilities
		{
			get
			{
				return menmMISCBrowserCapabilities;
			}
			set
			{
			}
		}

		public bool IsPngSupport => (((IContextParams)this).MISCBrowserCapabilities & MISCBrowserCapabilities.PngSupport) == MISCBrowserCapabilities.PngSupport;

		Graphics IContextParams.MeasurementGraphics
		{
			get
			{
				if (mobjMeasurementGraphics == null)
				{
					Bitmap image = new Bitmap(1, 1);
					mobjMeasurementGraphics = Graphics.FromImage(image);
				}
				return mobjMeasurementGraphics;
			}
		}

		int IContextParams.ScreenColorDepth => CurrentScreen.BitsPerPixel;

		Gizmox.WebGUI.Forms.Keys IContextParams.ModifierKeys
		{
			get
			{
				return Gizmox.WebGUI.Forms.Keys.None;
			}
			set
			{
			}
		}

		Point IContextParams.CursorPosition => Point.Empty;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
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

		long IContextParams.LastRender => 0L;

		string IContextParams.BrowserId => null;

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

		Dictionary<string, IProxyMasterPage> IContextParams.NameProxyMasterPageMap => mobjNameProxyMasterPageMap;

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

		IDesignTimeDeviceRepository IClientDesignServices.DesignTimeDeviceRepository
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		int ISessionRegistry.Count => mobjComponentRegistry.Count;

		public HostContext HostContext => null;

		IDeviceIntegrator IContext.DeviceIntegrator => null;

		public WebSocketService WebSocketService
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event ComponentMessageEventHandler ComponentMessage;

		internal Context()
			: this(null)
		{
		}

		internal Context(IClientDesignServices objClientDesignServices)
		{
			mobjContextParams = new Hashtable();
			mobjWebControllers = new Hashtable();
			mobjWinControllers = new Hashtable();
			mobjUpdateCommands = new Queue();
			mobjClientDesignServices = objClientDesignServices;
		}

		internal static Config GetConfig()
		{
			if (mobjConfig == null)
			{
				mobjConfig = Config.GetInstance();
			}
			return mobjConfig;
		}

		public void OpenLink(ILink objLink)
		{
		}

		public void OpenLink(ILink objLink, ILinkParameters objLinkParameters)
		{
		}

		private void EnqueueCommand(UpdateCommand objUpdateCommand)
		{
			if (!((IContextNotifications)this).IsNotificationSuspened)
			{
				mobjUpdateCommands.Enqueue(objUpdateCommand);
				if (DesignMode)
				{
					((IContextNotifications)this).SendNotifications();
				}
			}
		}

		void IContextNotifications.SuspendNotifications()
		{
			mintNotificationSuspended++;
		}

		void IContextNotifications.ResumeNotifications()
		{
			mintNotificationSuspended--;
		}

		void IContextNotifications.NotifyListItemAdded(ObjectCollectionController objObjectCollectionController, object objItem)
		{
			EnqueueCommand(new UpdateListItemAddedCommand(objObjectCollectionController, objItem));
		}

		void IContextNotifications.NotifyListItemRemoved(ObjectCollectionController objObjectCollectionController, object objItem)
		{
			EnqueueCommand(new UpdateListItemRemovedCommand(objObjectCollectionController, objItem));
		}

		void IContextNotifications.NotifyListCleared(ObjectCollectionController objObjectCollectionController)
		{
			EnqueueCommand(new UpdateListClearedCommand(objObjectCollectionController));
		}

		void IContextNotifications.NotifyItemPropertyChanged(ObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangeArgs, bool blnWebEvent)
		{
			EnqueueCommand(new UpdatePropertyCommand(objObjectController, objPropertyChangeArgs, blnWebEvent));
		}

		void IContextNotifications.NotifyFormAdded(FormController objFormController, object objWebForm)
		{
			EnqueueCommand(new UpdateFormAddedCommand(objFormController, objWebForm));
		}

		void IContextNotifications.NotifyFormRemoved(FormController objFormController, object objWebForm)
		{
			EnqueueCommand(new UpdateFormRemovedCommand(objFormController, objWebForm));
		}

		void IContextNotifications.SendNotifications()
		{
			UpdateCommand updateCommand = null;
			if (mobjUpdateCommands.Count > 0)
			{
				updateCommand = (UpdateCommand)mobjUpdateCommands.Dequeue();
			}
			while (updateCommand != null)
			{
				updateCommand.Fire();
				updateCommand = ((mobjUpdateCommands.Count <= 0) ? null : ((UpdateCommand)mobjUpdateCommands.Dequeue()));
			}
			if (MainForm == null)
			{
				return;
			}
			if (MainForm is ILogonForm)
			{
				if (IsLoggedOn)
				{
					mobjUpdateCommands.Clear();
					if (((IContextServices)this).GetWinObject((object)MainForm) is System.Windows.Forms.Form form && !mblnClosingMainForm)
					{
						mblnClosingMainForm = true;
						form.Close();
						TerminateControllers();
						MainForm = null;
						mblnClosingMainForm = false;
					}
				}
			}
			else if (MainForm.IsClosed && ((IContextServices)this).GetWinObject((object)MainForm) is System.Windows.Forms.Form form2 && !mblnClosingMainForm)
			{
				mblnClosingMainForm = true;
				form2.Close();
				TerminateControllers();
				mblnClosingMainForm = false;
			}
		}

		private void TerminateControllers()
		{
			foreach (ObjectController value in mobjWebControllers.Values)
			{
				value.Terminate();
			}
			mobjWebControllers.Clear();
			mobjWinControllers.Clear();
		}

		object IContextServices.GetWinObject(object objWebObject)
		{
			if (objWebObject != null)
			{
				if (!(mobjWebControllers[objWebObject] is ObjectController { TargetObject: var targetObject }))
				{
					return null;
				}
				return targetObject;
			}
			return null;
		}

		object IContextServices.GetWebObject(object objWinObject)
		{
			if (objWinObject != null)
			{
				if (!(mobjWinControllers[objWinObject] is ObjectController { SourceObject: var sourceObject }))
				{
					return null;
				}
				return sourceObject;
			}
			return null;
		}

		void IContextServices.RegisterController(IClientObjectController objController)
		{
			mobjWebControllers[objController.SourceObject] = objController;
			mobjWinControllers[objController.TargetObject] = objController;
		}

		void IContextServices.UnregisterController(IClientObjectController objController)
		{
			mobjWebControllers.Remove(objController.SourceObject);
			mobjWinControllers.Remove(objController.TargetObject);
		}

		IClientObjectController IContextServices.GetControllerByWebObject(object objWebObject)
		{
			return mobjWebControllers[objWebObject] as IClientObjectController;
		}

		IClientObjectController IContextServices.CreateControllerByWinObject(object objWinObject)
		{
			return ObjectController.CreateControllerByWinObject(this, objWinObject);
		}

		IClientObjectController IContextServices.CreateControllerByWebObject(object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(this, objWebObject);
		}

		IClientObjectController IContextServices.GetControllerByWinObject(object objWinObject)
		{
			return mobjWinControllers[objWinObject] as IClientObjectController;
		}

		void IContextServices.UnregisterControllerByWebObject(object objWebObject)
		{
			if (mobjWebControllers[objWebObject] is ObjectController objectController)
			{
				mobjWebControllers.Remove(objWebObject);
				mobjWinControllers.Remove(objectController.TargetObject);
			}
		}

		void IContextServices.UnregisterControllerByWinObject(object objWinObject)
		{
			if (mobjWinControllers[objWinObject] is ObjectController objectController)
			{
				mobjWebControllers.Remove(objectController.SourceObject);
				mobjWinControllers.Remove(objWinObject);
			}
		}

		void IContextServices.RefreshDesigner()
		{
			if (mobjClientDesignServices != null)
			{
				mobjClientDesignServices.RefreshDesigner();
			}
		}

		void IContextTerminate.Terminate(bool blnForce)
		{
		}

		void IContextTerminate.SetPendingTermination()
		{
		}

		void IContextTerminate.ClearPendingTermination()
		{
		}

		public void Redirect(string url)
		{
		}

		public void Transfer(IForm objForm)
		{
		}

		public void Terminate(bool blnLogOff)
		{
		}

		void IContextMethodInvoker.InvokeMethod(ISkinable objTarget, InvokationUniqueness enmUniqueness, string strMember, params object[] arrArgs)
		{
		}

		string IContextMethodInvoker.GetMethodName(ISkinable objTarget, string strMember)
		{
			return strMember;
		}

		int ITimerHandlerContainer.InvokeTimers(long lngCurrentTicks)
		{
			return 0;
		}

		int IContextResources.GetWinImageIndex(System.Windows.Forms.ImageList objWinImagelist, ResourceHandle objResourceHandler, string strKey)
		{
			Image winImageFromResourceHandle = ((IContextResources)this).GetWinImageFromResourceHandle(objResourceHandler);
			if (winImageFromResourceHandle != null && objWinImagelist != null)
			{
				if (strKey != null)
				{
					objWinImagelist.Images.Add(strKey, winImageFromResourceHandle);
				}
				else
				{
					objWinImagelist.Images.Add(winImageFromResourceHandle);
				}
				return objWinImagelist.Images.Count - 1;
			}
			return -1;
		}

		int IContextResources.GetWinImageIndex(System.Windows.Forms.ImageList objWinImagelist, ResourceHandle objResourceHandler)
		{
			return ((IContextResources)this).GetWinImageIndex(objWinImagelist, objResourceHandler, (string)null);
		}

		Stream IContextResources.GetGatewayResourceStream(GatewayResourceHandle objGatewayResourceHandle)
		{
			try
			{
				if (objGatewayResourceHandle.Component is IGatewayControl gatewayControl)
				{
					HttpWorkerRequest wr = new GatewayRequest();
					HttpContext.Current = new HttpContext(wr);
					GatewayStream gatewayStream = new GatewayStream(HttpContext.Current.Response.Filter);
					HttpContext.Current.Response.Filter = gatewayStream;
					gatewayControl.GetGatewayHandler(this, objGatewayResourceHandle.Action)?.ProcessGatewayRequest(this, objGatewayResourceHandle.Component);
					HttpContext.Current.Response.Flush();
					HttpContext.Current = null;
					gatewayStream.Position = 0L;
					return gatewayStream;
				}
			}
			catch
			{
			}
			return null;
		}

		private string GetNamedDirectory(string strDirectoryName)
		{
			if (DesignServices != null)
			{
				return DesignServices.GetNamedDirecotry(strDirectoryName);
			}
			return Config.GetDirectory(strDirectoryName);
		}

		Image IContextResources.GetWinImageFromResourceHandle(ResourceHandle objResourceHandler)
		{
			if (objResourceHandler != null)
			{
				string text = null;
				if (objResourceHandler is IconResourceHandle)
				{
					text = GetNamedDirectory("Icons");
				}
				if (objResourceHandler is ImageResourceHandle)
				{
					text = GetNamedDirectory("Images");
				}
				if (!string.IsNullOrEmpty(text))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text);
					if (directoryInfo != null)
					{
						Stream physicalResourceHandleStream = objResourceHandler.GetPhysicalResourceHandleStream(directoryInfo);
						if (physicalResourceHandleStream != null)
						{
							return Image.FromStream(physicalResourceHandleStream);
						}
					}
				}
				if (objResourceHandler is TypeResourceHandle typeResourceHandle)
				{
					return typeResourceHandle.ToImage();
				}
				if (objResourceHandler is UrlResourceHandle urlResourceHandle)
				{
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(urlResourceHandle.File);
					httpWebRequest.Method = "GET";
					WebResponse response = httpWebRequest.GetResponse();
					if (response != null)
					{
						Stream responseStream = response.GetResponseStream();
						if (responseStream != null)
						{
							return Image.FromStream(responseStream);
						}
					}
				}
				if (objResourceHandler is GatewayResourceHandle objGatewayResourceHandle)
				{
					Stream gatewayResourceStream = ((IContextResources)this).GetGatewayResourceStream(objGatewayResourceHandle);
					if (gatewayResourceStream != null)
					{
						return Image.FromStream(gatewayResourceStream);
					}
				}
			}
			return null;
		}

		IClientObjectController IClinetDesignContext.CreateControllerByWebObject(IContext objContext, object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(objContext, objWebObject);
		}

		IClientObjectController IClinetDesignContext.CreateControllerByWebType(IContext objContext, Type objWebType)
		{
			return ObjectController.CreateControllerByWebType(objContext, objWebType);
		}

		void IClinetDesignContext.InitializeController(IClientObjectController objObjectController)
		{
			if (objObjectController is ObjectController objectController)
			{
				objectController.Initialize(blnDesignInitialization: true);
				objectController.Load(blnDesignInitialization: true);
			}
		}

		void IClinetDesignContext.NotifyItemPropertyChanged(IClientObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangedArgs, bool blnWebEvent)
		{
			((IContextNotifications)this).NotifyItemPropertyChanged((ObjectController)objObjectController, objPropertyChangedArgs, blnWebEvent);
		}

		FormAccessMode IContextParams.GetFormAccessMode(IForm objForm)
		{
			return FormAccessMode.FullControl;
		}

		IForm IContext.CreateForm(params object[] arrArguments)
		{
			return null;
		}

		void IContextParams.InvokeComponentMessage(object sender, ComponentMessageEventArgs e)
		{
		}

		public void ShowDialog(ICommonDialog objCommonDialog, IForm objOwner, EventHandler objCloseHandler, EventHandler objDirectHandler)
		{
			ContextCommonDialogHandler contextCommonDialogHandler = new ContextCommonDialogHandler();
			if (((IContextServices)this).GetWinObject((object)((objOwner != null) ? objOwner : ActiveForm)) is System.Windows.Forms.Form objOwner2)
			{
				contextCommonDialogHandler.ShowDialog(objCommonDialog, objOwner2, objCloseHandler, objDirectHandler);
				return;
			}
			throw new Exception("Can not find winforms owner.");
		}

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

		void IClinetDesignContext.ResumeNotifications()
		{
			((IContextNotifications)this).ResumeNotifications();
		}

		void IClinetDesignContext.SuspendNotifications()
		{
			((IContextNotifications)this).SuspendNotifications();
		}

		IEnumerator ISessionRegistry.GetEnumerator()
		{
			return mobjComponentRegistry.GetEnumerator();
		}

		public void RegisterComponent(IRegisteredComponent objComponent)
		{
			if (!objComponent.IsRegistered)
			{
				if ((objComponent.RegisteredState & RegisteredState.Identified) != RegisteredState.Identified)
				{
					objComponent.ID = mintCurrentId++;
				}
				mobjComponentRegistry.Add(objComponent.ID.ToString(), objComponent);
				objComponent.RegisterContextMenu();
				if (objComponent is IControl control)
				{
					RegisterBatch(control.Controls);
				}
				if (objComponent is IRegisteredComponentContainer { ContainedComponents: not null } registeredComponentContainer)
				{
					RegisterBatch(registeredComponentContainer.ContainedComponents);
				}
				objComponent.IsRegistered = true;
			}
		}

		public void UnRegisterComponent(IRegisteredComponent objComponent)
		{
			if (objComponent.IsRegistered)
			{
				mobjComponentRegistry.Remove(objComponent.ID.ToString());
				objComponent.IsRegistered = false;
				objComponent.UnregisterContextMenu();
				objComponent.UnregisterComponents();
			}
		}

		public void RegisterBatch(ICollection objCollection)
		{
			foreach (IRegisteredComponent item in objCollection)
			{
				RegisterComponent(item);
			}
		}

		public void UnRegisterBatch(ICollection objCollection)
		{
			foreach (IRegisteredComponent item in objCollection)
			{
				UnRegisterComponent(item);
			}
		}

		public IRegisteredComponent GetRegisteredComponent(string strComponentId)
		{
			return mobjComponentRegistry[strComponentId] as IRegisteredComponent;
		}

		public IRegisteredComponent GetRegisteredComponent(long lngComponentId)
		{
			return mobjComponentRegistry[lngComponentId.ToString()] as IRegisteredComponent;
		}

		public IContextThreadingService GetThreadingService()
		{
			return null;
		}
	}
}
