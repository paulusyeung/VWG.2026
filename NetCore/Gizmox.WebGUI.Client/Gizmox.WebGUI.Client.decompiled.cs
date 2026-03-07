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

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyProductVersion("10.0.5 e")]
[assembly: AssemblyTitle("Gizmox.WebGUI.Client.dll")]
[assembly: AssemblyDescription("Gizmox.WebGUI.Client.dll")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Gizmox")]
[assembly: AssemblyProduct("Gizmox© Visual WebGUI")]
[assembly: AssemblyCopyright("© Gizmox")]
[assembly: AssemblyTrademark("")]
[assembly: AllowPartiallyTrustedCallers]
[assembly: ComVisible(false)]
[assembly: Guid("dca9ed41-fad1-4a1c-a3e6-dd7fac638af8")]
[assembly: SecurityRules(SecurityRuleSet.Level1)]
[assembly: AssemblyFileVersion("1.0.*")]
[assembly: TargetFramework(".NETFramework,Version=v4.5.2", FrameworkDisplayName = ".NET Framework 4.5.2")]
[assembly: AssemblyVersion("4.5.25701.0")]
namespace Gizmox.WebGUI.Client
{
	public class Application : NameObjectCollectionBase, IApplication, ICollection, IEnumerable, INonSerializable
	{
		private Context mobjContext = null;

		object IApplication.this[string strName]
		{
			get
			{
				return BaseGet(strName);
			}
			set
			{
				BaseSet(strName, value);
			}
		}

		object IApplication.this[int intIndex] => BaseGet(intIndex);

		internal Application(IContext objContext)
		{
			mobjContext = (Context)objContext;
		}

		public static void Run(Type objApplicationType)
		{
			Run(objApplicationType, null);
		}

		public static void Run(Type objApplicationType, Type objLoginType)
		{
			System.Windows.Forms.Application.ThreadException += Application_ThreadException;
			Context context = new Context();
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.DoEvents();
			if (objLoginType != null)
			{
				System.Windows.Forms.Application.Run(new ApplicationForm(objLoginType, context));
				if (!context.Session.IsLoggedOn)
				{
					return;
				}
			}
			System.Windows.Forms.Application.Run(new ApplicationForm(objApplicationType, context));
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
		}
	}
	internal class UpdateCommand
	{
		internal virtual void Fire()
		{
		}
	}
	internal class UpdatePropertyCommand : UpdateCommand
	{
		private ObjectController mobjObjectController;

		private ObservableItemPropertyChangedArgs mobjPropertyChangeArgs;

		private bool mblnIsWebEvent = false;

		internal UpdatePropertyCommand(ObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangeArgs, bool blnWebEvent)
		{
			mobjObjectController = objObjectController;
			mobjPropertyChangeArgs = objPropertyChangeArgs;
			mblnIsWebEvent = blnWebEvent;
		}

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
	}
	internal class UpdateListItemAddedCommand : UpdateCommand
	{
		private ObjectCollectionController mobjObjectCollectionController;

		private object mobjItem;

		internal UpdateListItemAddedCommand(ObjectCollectionController objObjectCollectionController, object objItem)
		{
			mobjObjectCollectionController = objObjectCollectionController;
			mobjItem = objItem;
		}

		internal override void Fire()
		{
			mobjObjectCollectionController.FireObservableListItemAdded(mobjItem);
		}
	}
	internal class UpdateFormAddedCommand : UpdateCommand
	{
		private FormController mobjFormController;

		private object mobjItem;

		internal UpdateFormAddedCommand(FormController objFormController, object objItem)
		{
			mobjFormController = objFormController;
			mobjItem = objItem;
		}

		internal override void Fire()
		{
			mobjFormController.FireFormAdded(mobjItem);
		}
	}
	internal class UpdateFormRemovedCommand : UpdateCommand
	{
		private FormController mobjFormController;

		private object mobjItem;

		internal UpdateFormRemovedCommand(FormController objFormController, object objItem)
		{
			mobjFormController = objFormController;
			mobjItem = objItem;
		}

		internal override void Fire()
		{
			mobjFormController.FireFormRemoved(mobjItem);
		}
	}
	internal class UpdateListItemRemovedCommand : UpdateCommand
	{
		private ObjectCollectionController mobjObjectCollectionController;

		private object mobjItem;

		internal UpdateListItemRemovedCommand(ObjectCollectionController objObjectCollectionController, object objItem)
		{
			mobjObjectCollectionController = objObjectCollectionController;
			mobjItem = objItem;
		}

		internal override void Fire()
		{
			mobjObjectCollectionController.FireObservableListItemRemoved(mobjItem);
		}
	}
	internal class UpdateListClearedCommand : UpdateCommand
	{
		private ObjectCollectionController mobjObjectCollectionController;

		internal UpdateListClearedCommand(ObjectCollectionController objObjectCollectionController)
		{
			mobjObjectCollectionController = objObjectCollectionController;
		}

		internal override void Fire()
		{
			mobjObjectCollectionController.FireObservableListCleared();
		}
	}
	internal class Context : IContext, INonSerializable, IContextTerminate, IContextMethodInvoker, ITimerHandlerContainer, IContextServices, IContextNotifications, IContextResources, IClinetDesignContext, IContextParams, IContextCommonDialogHandler, IClientDesignServices, ISessionRegistry
	{
		private ReadOnlyCollectionGen_ marrAvailableThemes;

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

		public ReadOnlyCollectionGen_ AvailableThemes
		{
			get
			{
				if (marrAvailableThemes == null)
				{
					ListGen_ list = new ListGen_();
					foreach (string availableTheme in Config.GetInstance().AvailableThemes)
					{
						list.Add(availableTheme);
					}
					marrAvailableThemes = new ReadOnlyCollectionGen_(list);
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

		ICollectionGen_ IContextParams.SystemPages => null;

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

		IForm IContext.CreateFormGen_(params object[] arrArguments)
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
	internal class ContextCommonDialogHandler : ICommonDialogHandler
	{
		private EventHandler mobjDirectEventHandler = null;

		private EventHandler mobjCloseEventHandler = null;

		private ICommonDialog mobjCommonDialog = null;

		private Gizmox.WebGUI.Forms.DialogResult mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.None;

		Gizmox.WebGUI.Forms.DialogResult ICommonDialogHandler.DialogResult => mobjWebDialogResult;

		EventHandler ICommonDialogHandler.DirectHandler => mobjDirectEventHandler;

		public void ShowDialog(ICommonDialog objCommonDialog, System.Windows.Forms.Form objOwner, EventHandler objCloseHandler, EventHandler objDirectHandler)
		{
			mobjDirectEventHandler = objDirectHandler;
			mobjCloseEventHandler = objCloseHandler;
			mobjCommonDialog = objCommonDialog;
			if (objCommonDialog is Gizmox.WebGUI.Forms.FontDialog objWebFontDialog)
			{
				ShowFontDialog(objWebFontDialog, objOwner);
			}
			if (objCommonDialog is Gizmox.WebGUI.Forms.ColorDialog objWebColorDialog)
			{
				ShowColorDialog(objWebColorDialog, objOwner);
			}
			if (objCommonDialog is Gizmox.WebGUI.Forms.OpenFileDialog objWebOpenFileDialog)
			{
				ShowOpenFileDialog(objWebOpenFileDialog, objOwner);
			}
			if (objCommonDialog is Gizmox.WebGUI.Forms.FolderBrowserDialog objOpenFileDialog)
			{
				ShowFolderBrowserDialog(objOpenFileDialog, objOwner);
			}
		}

		private void ShowFolderBrowserDialog(Gizmox.WebGUI.Forms.FolderBrowserDialog objOpenFileDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			CopyCommonProperties(objOpenFileDialog, folderBrowserDialog);
			folderBrowserDialog.ShowDialog(objOwner);
			if (folderBrowserDialog.SelectedPath != objOpenFileDialog.SelectedPath)
			{
				objOpenFileDialog.SelectedPath = folderBrowserDialog.SelectedPath;
				mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
			}
			OnDialogClosed();
		}

		private void ShowColorDialog(Gizmox.WebGUI.Forms.ColorDialog objWebColorDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
			CopyCommonProperties(objWebColorDialog, colorDialog);
			colorDialog.ShowDialog(objOwner);
			if (colorDialog.Color != objWebColorDialog.Color)
			{
				objWebColorDialog.Color = colorDialog.Color;
				mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
			}
			OnDialogClosed();
		}

		private void ShowFontDialog(Gizmox.WebGUI.Forms.FontDialog objWebFontDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.FontDialog fontDialog = new System.Windows.Forms.FontDialog();
			CopyCommonProperties(objWebFontDialog, fontDialog);
			fontDialog.Apply += objWinFontDialog_Apply;
			fontDialog.ShowDialog(objOwner);
			if (fontDialog.Font != objWebFontDialog.Font)
			{
				objWebFontDialog.Font = fontDialog.Font;
				mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
			}
			OnDialogClosed();
		}

		private void objWinFontDialog_Apply(object sender, EventArgs e)
		{
			mobjCommonDialog.OnApply();
		}

		private void ShowOpenFileDialog(Gizmox.WebGUI.Forms.OpenFileDialog objWebOpenFileDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
			CopyCommonProperties(objWebOpenFileDialog, openFileDialog);
			openFileDialog.FileOk += objWinOpenFileDialog_FileOk;
			openFileDialog.ShowDialog(objOwner);
			if (mobjWebDialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
			{
				objWebOpenFileDialog.Files.Clear();
				string[] fileNames = openFileDialog.FileNames;
				foreach (string text in fileNames)
				{
					objWebOpenFileDialog.Files.Add(text, PhysicalFileHandle.Create(text));
				}
			}
			OnDialogClosed();
		}

		private void CopyCommonProperties(object objSource, object objTarget)
		{
			if (objSource == null || objTarget == null)
			{
				return;
			}
			Type type = objSource.GetType();
			Type type2 = objTarget.GetType();
			if (!(type != null) || !(type2 != null))
			{
				return;
			}
			PropertyInfo[] properties = type.GetProperties();
			if (properties == null)
			{
				return;
			}
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				PropertyInfo property = type2.GetProperty(propertyInfo.Name);
				if (property != null && property.CanWrite && property.PropertyType == propertyInfo.PropertyType)
				{
					object obj = type.InvokeMember(propertyInfo.Name, BindingFlags.GetProperty, null, objSource, null);
					type2.InvokeMember(property.Name, BindingFlags.SetProperty, null, objTarget, new object[1] { obj });
				}
			}
		}

		private void objWinOpenFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
		}

		private void OnDialogClosed()
		{
			if (mobjCloseEventHandler != null)
			{
				mobjCloseEventHandler(this, EventArgs.Empty);
			}
		}
	}
	public interface IContextContainer
	{
		IContext Context { get; set; }
	}
	public interface IContextNotifications
	{
		bool IsNotificationSuspened { get; }

		void SuspendNotifications();

		void ResumeNotifications();

		void NotifyListItemAdded(ObjectCollectionController objObjectCollectionController, object objItem);

		void NotifyListItemRemoved(ObjectCollectionController objObjectCollectionController, object objItem);

		void NotifyListCleared(ObjectCollectionController objObjectCollectionController);

		void NotifyItemPropertyChanged(ObjectController objObjectController, ObservableItemPropertyChangedArgs objPropertyChangeArgs, bool blnWebEvent);

		void NotifyFormAdded(FormController objFormController, object objWebForm);

		void NotifyFormRemoved(FormController objFormController, object objWebForm);

		void SendNotifications();
	}
	public interface IContextResources
	{
		int GetWinImageIndex(System.Windows.Forms.ImageList objWinImagelist, ResourceHandle objResourceHandler, string strKey);

		int GetWinImageIndex(System.Windows.Forms.ImageList objWinImagelist, ResourceHandle objResourceHandler);

		Stream GetGatewayResourceStream(GatewayResourceHandle objGatewayResourceHandle);

		Image GetWinImageFromResourceHandle(ResourceHandle objResourceHandler);
	}
	internal class Cookies : ICookies
	{
		public string this[string strKey]
		{
			get
			{
				string text = System.Windows.Forms.Application.CommonAppDataRegistry.GetValue($"COOKIE_{strKey}") as string;
				if (text == null)
				{
					text = "";
				}
				return text;
			}
			set
			{
				System.Windows.Forms.Application.CommonAppDataRegistry.SetValue($"COOKIE_{strKey}", value);
			}
		}

		internal Cookies()
		{
		}
	}
	internal class EmbededResource
	{
		private string mstrResource = string.Empty;

		private Assembly mobjAssembly = null;

		public bool IsValid => ResourceInfo != null;

		public ManifestResourceInfo ResourceInfo
		{
			get
			{
				if (mobjAssembly != null)
				{
					return mobjAssembly.GetManifestResourceInfo(mstrResource);
				}
				return null;
			}
		}

		internal EmbededResource(Assembly objAssembly, string strResource)
		{
			mobjAssembly = objAssembly;
			if (objAssembly != null)
			{
				mstrResource = objAssembly.FullName.Split(',')[0] + "." + strResource;
			}
		}

		public Stream ToStream()
		{
			return mobjAssembly.GetManifestResourceStream(mstrResource);
		}

		public XmlDocument ToXml()
		{
			XmlDocument xmlDocument = new XmlDocument();
			Stream stream = ToStream();
			try
			{
				xmlDocument.Load(stream);
			}
			catch (Exception ex)
			{
				stream.Close();
				throw new Exception(mstrResource + ": " + ex.Message, ex);
			}
			stream.Close();
			return xmlDocument;
		}

		public override string ToString()
		{
			StreamReader streamReader = new StreamReader(ToStream());
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			return result;
		}

		public void WriteToStream(Stream objOutputStream)
		{
			Stream stream = ToStream();
			if (stream != null)
			{
				byte[] array = new byte[stream.Length];
				stream.Read(array, 0, (int)stream.Length);
				objOutputStream.Write(array, 0, array.Length);
				objOutputStream.Flush();
				stream.Close();
			}
		}
	}
	public class Event : EventArgs, IEvent
	{
		private NameValueCollection mobjParams = null;

		private string mstrType = string.Empty;

		private IRegisteredComponent mobjSource = null;

		private IRegisteredComponent mobjTarget = null;

		private string mstrMember = string.Empty;

		private IContext mobjContext = null;

		public string Type => mstrType;

		public string Value => string.Empty;

		public string Member => mstrMember;

		public string Source => mobjSource.ID.ToString();

		public string Target => (mobjTarget != null) ? mobjTarget.ID.ToString() : "";

		public string this[string strParam]
		{
			get
			{
				if (mobjParams == null)
				{
					return "";
				}
				return mobjParams[strParam];
			}
		}

		public Gizmox.WebGUI.Forms.Keys KeyCode
		{
			get
			{
				if (Contains("KC"))
				{
					return (Gizmox.WebGUI.Forms.Keys)Enum.Parse(typeof(Gizmox.WebGUI.Forms.Keys), this["KC"]);
				}
				return Gizmox.WebGUI.Forms.Keys.None;
			}
		}

		public bool AltKey => this["AK"] == "1";

		public bool ControlKey => this["CK"] == "1";

		public bool ShiftKey => this["SK"] == "1";

		public Point CursorPosition => Point.Empty;

		internal Event(IContext objContext, string strType, IRegisteredComponent objSource)
			: this(objContext, strType, objSource, null, "")
		{
		}

		internal Event(IContext objContext, string strType, IRegisteredComponent objSource, IRegisteredComponent objTarget)
			: this(objContext, strType, objSource, objTarget, "")
		{
		}

		internal Event(IContext objContext, string strType, IRegisteredComponent objSource, IRegisteredComponent objTarget, string strMember)
		{
			mstrType = strType;
			mobjSource = objSource;
			mobjTarget = objTarget;
			mstrMember = strMember;
			mobjContext = objContext;
		}

		public void Fire()
		{
			mobjSource.FireEvent(this);
			((IContextNotifications)mobjContext).SendNotifications();
		}

		public void SetParameter(string strName, string strValue)
		{
			if (mobjParams == null)
			{
				mobjParams = new NameValueCollection();
			}
			mobjParams[strName] = strValue;
		}

		public bool Contains(string strParam)
		{
			if (mobjParams != null)
			{
				return this[strParam] != null;
			}
			return false;
		}
	}
	internal class EventCollection : QueueGen_, IEventCollection, ICollection, IEnumerable
	{
		internal EventCollection()
		{
		}

		IEvent IEventCollection.Dequeue()
		{
			return Dequeue();
		}

		IEvent IEventCollection.Peek()
		{
			return Peek();
		}

		void IEventCollection.Enqueue(IEvent objEvent)
		{
			Enqueue(objEvent);
		}
	}
	internal class GatewayRequest : HttpWorkerRequest
	{
		public override string GetUriPath()
		{
			return null;
		}

		public override string GetQueryString()
		{
			return "";
		}

		public override string GetRawUrl()
		{
			return "http://clientgateway.com/gateway.aspx";
		}

		public override string GetHttpVerbName()
		{
			return "GET";
		}

		public override string GetHttpVersion()
		{
			return "1.1";
		}

		public override string GetRemoteAddress()
		{
			return "";
		}

		public override int GetRemotePort()
		{
			return 80;
		}

		public override string GetLocalAddress()
		{
			return "";
		}

		public override int GetLocalPort()
		{
			return 0;
		}

		public override void SendStatus(int statusCode, string statusDescription)
		{
		}

		public override void SendKnownResponseHeader(int index, string value)
		{
		}

		public override void SendUnknownResponseHeader(string name, string value)
		{
		}

		public override void SendResponseFromMemory(byte[] data, int length)
		{
		}

		public override void SendResponseFromFile(IntPtr handle, long offset, long length)
		{
		}

		public override void SendResponseFromFile(string filename, long offset, long length)
		{
		}

		public override void FlushResponse(bool finalFlush)
		{
		}

		public override void EndOfRequest()
		{
		}
	}
	internal class GatewayStream : MemoryStream
	{
		private Stream mobjMainStream;

		public override bool CanRead => true;

		public override bool CanWrite => true;

		public override bool CanSeek => true;

		public GatewayStream(Stream objMainStream)
		{
			mobjMainStream = objMainStream;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			base.Write(buffer, offset, count);
			mobjMainStream.Write(buffer, offset, count);
		}

		public override void WriteByte(byte value)
		{
			base.WriteByte(value);
			mobjMainStream.WriteByte(value);
		}

		public override void Flush()
		{
			base.Flush();
			mobjMainStream.Flush();
		}

		public override void Close()
		{
			base.Close();
			mobjMainStream.Close();
		}
	}
	internal class Request : IRequest, INonSerializable
	{
		private Context mobjContext = null;

		internal Request(IContext objContext)
		{
			mobjContext = (Context)objContext;
		}
	}
	internal class Response : IResponse, INonSerializable
	{
		private Context mobjContext = null;

		private Context Context => mobjContext;

		internal Response(IContext objContext)
		{
			mobjContext = (Context)objContext;
		}
	}
	internal class Server : IServer, INonSerializable
	{
		internal Server()
		{
		}

		public string MapPath(string strPath)
		{
			return strPath;
		}
	}
	internal class ClientSwitches
	{
		private static BooleanSwitch mblnDisableObscuringSwitch;

		private static BooleanSwitch mblnShowEventsSwitch;

		private static BooleanSwitch mblnShowClientErrorsSwitch;

		private static BooleanSwitch mblnDisableCachingSwitch;

		public static BooleanSwitch ShowEvents => mblnShowEventsSwitch;

		static ClientSwitches()
		{
			mblnShowEventsSwitch = new BooleanSwitch("VWG_ShowEventsSwitch", "Show client side event alerts.");
		}
	}
	internal class Session : ISession
	{
		private Hashtable mobjObjects = null;

		private bool mblnIsLoggedOn = false;

		private bool mblnRightToLeft = false;

		private Context mobjContext = null;

		private int mintTraceLimit = -1;

		public string SessionID => "1";

		public bool IsLoggedOn
		{
			get
			{
				return mblnIsLoggedOn;
			}
			set
			{
				mblnIsLoggedOn = value;
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

		public object this[string strProperty]
		{
			get
			{
				return mobjObjects[strProperty];
			}
			set
			{
				mobjObjects[strProperty] = value;
			}
		}

		internal Session(IContext objContext)
		{
			mobjObjects = new Hashtable();
			if (CommonSwitches.TraceEnabled)
			{
				mintTraceLimit = CommonSwitches.TraceThreshold;
			}
			mobjContext = (Context)objContext;
		}
	}
}
namespace Gizmox.WebGUI.Client.Providers
{
	internal class ArgumentsProvider : NameValueCollection
	{
		public ArgumentsProvider()
		{
		}

		public ArgumentsProvider(string[] arrArguments)
		{
		}
	}
	internal class ResultsProvider : NameValueCollection
	{
	}
}
namespace Gizmox.WebGUI.Client.Forms
{
	internal class ApplicationForm : ClientForm
	{
		private Context mobjContext = null;

		[NonSerialized]
		private Container components = null;

		internal ApplicationForm(Type objType, Context objContext)
		{
			mobjContext = objContext;
			InitializeComponent(objType);
		}

		private void InitializeComponent(System.Type objType)
		{
			Gizmox.WebGUI.Common.Global.Context = this.mobjContext;
			if (System.Activator.CreateInstance(objType) is Gizmox.WebGUI.Forms.Form form)
			{
				form.Visible = true;
				Gizmox.WebGUI.Client.Controllers.FormController formController = new Gizmox.WebGUI.Client.Controllers.FormController(this.mobjContext, form, this);
				this.mobjContext.MainForm = form;
				((Gizmox.WebGUI.Client.Design.IContextServices)this.mobjContext).RegisterController((Gizmox.WebGUI.Client.Design.IClientObjectController)formController);
				formController.Initialize();
				formController.Load();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
	public class ClientButton : System.Windows.Forms.Button, IContextContainer
	{
		private System.Windows.Forms.ContextMenu mobjDropDownMenu = null;

		private IContext mobjContext = null;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public System.Windows.Forms.ContextMenu DropDownMenu
		{
			get
			{
				return mobjDropDownMenu;
			}
			set
			{
				mobjDropDownMenu = value;
			}
		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (mobjDropDownMenu != null && e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				IContextServices contextServices = (IContextServices)((IContextContainer)this).Context;
				if (contextServices != null && contextServices.GetControllerByWinObject(mobjDropDownMenu) is ContextMenuController contextMenuController)
				{
					contextMenuController.SetTarget(this);
					mobjDropDownMenu.Show(this, new Point(0, base.Height));
				}
			}
		}
	}
	public class ClientColumnHeader : System.Windows.Forms.ColumnHeader
	{
	}
	public class ClientDomainUpDown : System.Windows.Forms.DomainUpDown, IContextContainer
	{
		private IContext mobjContext = null;

		private IContainer components = null;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}
	}
	public class ClientForm : System.Windows.Forms.Form
	{
		[NonSerialized]
		private Container components = null;

		public ClientForm()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			base.ClientSize = new System.Drawing.Size(292, 266);
			base.Name = "ClientForm";
			this.Text = "Form";
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);
		}
	}
	public class ClientHtmlBox : WebBrowser
	{
		private string mstrHtml = "";

		private string mstrTempDir = null;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
			}
		}

		public override System.Windows.Forms.RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
			}
		}

		public override System.Windows.Forms.Cursor Cursor
		{
			get
			{
				return base.Cursor;
			}
			set
			{
			}
		}

		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
			}
		}

		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
			}
		}

		public override System.Windows.Forms.ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
			}
		}

		public string Html
		{
			get
			{
				return mstrHtml;
			}
			set
			{
				if (mstrHtml != value)
				{
					mstrHtml = value;
					File.WriteAllText(TempFile, mstrHtml);
					base.Url = new Uri($"file://{TempFile}");
				}
			}
		}

		private string TempDirectory
		{
			get
			{
				if (mstrTempDir == null)
				{
					mstrTempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
					Directory.CreateDirectory(mstrTempDir);
				}
				return mstrTempDir;
			}
		}

		private string TempFile => Path.Combine(TempDirectory, "Index.htm");

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			try
			{
				if (mstrTempDir != null && Directory.Exists(mstrTempDir))
				{
					Directory.Delete(mstrTempDir, recursive: true);
					mstrTempDir = null;
				}
			}
			catch (Exception)
			{
			}
			base.Dispose(disposing);
		}
	}
	public class ClientListView : System.Windows.Forms.ListView, IContextContainer
	{
		private IContext mobjContext = null;

		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		public ClientListView()
		{
			base.MouseUp += ClientListView_MouseUp;
			base.FullRowSelect = true;
		}

		private void ClientListView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right && GetItemAt(e.X, e.Y) is ClientListViewItem { ContextMenu: not null } clientListViewItem)
			{
				IContextServices contextServices = (IContextServices)((IContextContainer)this).Context;
				if (contextServices != null && contextServices.GetControllerByWinObject(clientListViewItem.ContextMenu) is ContextMenuController contextMenuController)
				{
					contextMenuController.SetTarget(clientListViewItem);
					clientListViewItem.ContextMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}
	}
	public class ClientListViewItem : System.Windows.Forms.ListViewItem
	{
		private System.Windows.Forms.ContextMenu mobjContextMenu = null;

		public System.Windows.Forms.ContextMenu ContextMenu
		{
			get
			{
				return mobjContextMenu;
			}
			set
			{
				mobjContextMenu = value;
			}
		}
	}
	[ProvideProperty("NewStyleActive", typeof(System.Windows.Forms.MenuItem))]
	[ProvideProperty("MenuGlyph", typeof(System.Windows.Forms.MenuItem))]
	[ToolboxBitmap(typeof(ClientMenuStyleProvider), "images.ClientMenuStyleProvider.bmp")]
	internal class ClientMenuStyleProvider : System.ComponentModel.Component, IExtenderProvider
	{
		internal class MenuItemInfo
		{
			public bool NewStyle;

			public Image Glyph;

			public MenuItemInfo(bool newstyle, Image glyph)
			{
				NewStyle = newstyle;
				Glyph = glyph;
			}
		}

		internal class DrawItemInfo
		{
			public Image Glyph;

			public bool HotLight;

			public bool Selected;

			public bool Disabled;

			public bool Checked;

			public Rectangle Rct;

			public System.Windows.Forms.MenuItem Item;

			public bool IsTopItem => Item.Parent == Item.Parent.GetMainMenu();

			public System.Windows.Forms.MainMenu MainMenu => Item.Parent.GetMainMenu();

			public DrawItemInfo(object sender, DrawItemEventArgs e, Image glyph)
			{
				Item = (System.Windows.Forms.MenuItem)sender;
				Glyph = glyph;
				Disabled = (e.State & DrawItemState.Disabled) == DrawItemState.Disabled;
				Selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				Checked = (e.State & DrawItemState.Checked) == DrawItemState.Checked;
				HotLight = (e.State & DrawItemState.HotLight) == DrawItemState.HotLight;
				Rct = e.Bounds;
			}
		}

		private Container components;

		private Hashtable _menuitems;

		private System.Windows.Forms.Form _owner = null;

		private IntPtr _hook = IntPtr.Zero;

		private Win32.HookProc _hookprc = null;

		private MenuHook lastHook = null;

		private StringFormat fmt = new StringFormat();

		private Size _marginSize = new Size(23, 22);

		private int _lastwidth = 0;

		private LinearGradientBrush lnbrs = new LinearGradientBrush(new Point(0, 0), new Point(1, 0), Color.Black, Color.White);

		private Pen border = new Pen(Color.Black);

		private SolidBrush hotbrs = new SolidBrush(Color.White);

		private Color[][] _cols = new Color[4][]
		{
			new Color[3]
			{
				Color.FromArgb(227, 239, 255),
				Color.FromArgb(203, 225, 252),
				Color.FromArgb(135, 173, 228)
			},
			new Color[2]
			{
				Color.FromArgb(195, 218, 249),
				Color.FromArgb(158, 190, 245)
			},
			new Color[2]
			{
				Color.FromArgb(255, 238, 194),
				Color.FromArgb(255, 214, 154)
			},
			new Color[2]
			{
				Color.FromArgb(246, 246, 246),
				Color.FromArgb(0, 0, 128)
			}
		};

		private ColorBlend[] _blends = new ColorBlend[2];

		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (Site != null)
				{
					IDesignerHost designerHost = (IDesignerHost)Site.GetService(typeof(IDesignerHost));
					if (designerHost != null && designerHost.RootComponent is System.Windows.Forms.Form)
					{
						OwnerForm = (System.Windows.Forms.Form)designerHost.RootComponent;
					}
				}
			}
		}

		[Browsable(false)]
		public System.Windows.Forms.Form OwnerForm
		{
			get
			{
				return _owner;
			}
			set
			{
				if (_hook != IntPtr.Zero)
				{
					Win32.UnhookWindowsHookEx(_hook);
					_hook = IntPtr.Zero;
				}
				_owner = value;
				if (_owner != null)
				{
					if (_hookprc == null)
					{
						_hookprc = OnHookProc;
					}
					_hook = Win32.SetWindowsHookEx(4, _hookprc, IntPtr.Zero, Win32.GetWindowThreadProcessId(_owner.Handle, 0));
				}
			}
		}

		[Browsable(false)]
		public LinearGradientBrush MarginBrush
		{
			get
			{
				_blends[1].Colors = _cols[0];
				lnbrs.InterpolationColors = _blends[1];
				lnbrs.Transform = new Matrix(_marginSize.Width, 0f, 0f, 1f, 1f, 0f);
				return lnbrs;
			}
		}

		[Browsable(false)]
		public int MarginWidth => _marginSize.Width;

		[Browsable(false)]
		public Pen BorderPen
		{
			get
			{
				border.Color = _cols[3][1];
				return border;
			}
		}

		[Browsable(false)]
		public Pen BackgroundPen
		{
			get
			{
				border.Color = _cols[3][0];
				return border;
			}
		}

		[Browsable(false)]
		public SolidBrush BackGroundBrush
		{
			get
			{
				hotbrs.Color = _cols[3][0];
				return hotbrs;
			}
		}

		[DefaultValue(typeof(Color), "0,0,128")]
		[Category("Colors")]
		[Description("the color of the border of the selection frame and the popup menu itself")]
		public Color BorderColor
		{
			get
			{
				return _cols[3][1];
			}
			set
			{
				_cols[3][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "255,238,194")]
		[Category("Colors")]
		[Description("specifies the lighter color of a preselected menuitem")]
		public Color HotLightGradientLight
		{
			get
			{
				return _cols[2][0];
			}
			set
			{
				_cols[2][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "255,214,154")]
		[Category("Colors")]
		[Description("specifies the darker color of a preselected menuitem")]
		public Color HotLightGradientDark
		{
			get
			{
				return _cols[2][1];
			}
			set
			{
				_cols[2][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "195,218,249")]
		[Category("Colors")]
		[Description("the color on the right side of a mainmenu")]
		public Color BandGradientLight
		{
			get
			{
				return _cols[1][0];
			}
			set
			{
				_cols[1][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "158,190,245")]
		[Category("Colors")]
		[Description("the color on the left side of a mainmenu")]
		public Color BandGradientDark
		{
			get
			{
				return _cols[1][1];
			}
			set
			{
				_cols[1][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "227,239,255")]
		[Category("Colors")]
		[Description("sets or gets the lighter color of the image-band next to each menuitem")]
		public Color ItemGradientLight
		{
			get
			{
				return _cols[0][0];
			}
			set
			{
				_cols[0][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "203,225,252")]
		[Category("Colors")]
		[Description("sets or gets the middle color of the image-band next to each menuitem")]
		public Color ItemGradientMiddle
		{
			get
			{
				return _cols[0][1];
			}
			set
			{
				_cols[0][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "135,173,228")]
		[Category("Colors")]
		[Description("sets or gets the darker color of the image-band next to each menuitem")]
		public Color ItemGradientDark
		{
			get
			{
				return _cols[0][2];
			}
			set
			{
				_cols[0][2] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "246,246,246")]
		[Category("Colors")]
		[Description("sets or gets the background color of each contextmenu")]
		public Color MenuBackground
		{
			get
			{
				return _cols[3][0];
			}
			set
			{
				_cols[3][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Size), "23,22")]
		[Category("Appearance")]
		[Description("sets or gets the size of the image band next to each contextmenu item")]
		public Size BandSize
		{
			get
			{
				return _marginSize;
			}
			set
			{
				if (value.Height < 16)
				{
					value.Height = 16;
				}
				if (value.Width < 16)
				{
					value.Width = 16;
				}
				_marginSize = value;
			}
		}

		public ClientMenuStyleProvider()
		{
			components = new Container();
			_menuitems = new Hashtable();
			fmt.HotkeyPrefix = HotkeyPrefix.Show;
			_blends[0] = new ColorBlend();
			_blends[0].Positions = new float[2] { 0f, 1f };
			_blends[0].Colors = _cols[1];
			_blends[1] = new ColorBlend();
			_blends[1].Positions = new float[3] { 0f, 0.5f, 1f };
			_blends[1].Colors = _cols[0];
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		bool IExtenderProvider.CanExtend(object target)
		{
			return target is System.Windows.Forms.MenuItem;
		}

		private void control_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			System.Windows.Forms.MenuItem menuItem = (System.Windows.Forms.MenuItem)sender;
			if (menuItem.Text == "-")
			{
				e.ItemHeight = 3;
				return;
			}
			string text = menuItem.Text.Replace("&", "");
			if (menuItem.Shortcut != System.Windows.Forms.Shortcut.None && menuItem.ShowShortcut)
			{
				text += GetShortcutString((System.Windows.Forms.Keys)menuItem.Shortcut);
			}
			int num = (int)e.Graphics.MeasureString(text, menuItem.DefaultItem ? new Font(SystemInformation.MenuFont, FontStyle.Bold) : SystemInformation.MenuFont, PointF.Empty, fmt).Width;
			if (menuItem.Parent == menuItem.Parent.GetMainMenu())
			{
				e.ItemHeight = 16;
				e.ItemWidth = num + 2;
			}
			else
			{
				e.ItemHeight = _marginSize.Height;
				e.ItemWidth = num + 45 + _marginSize.Width;
			}
		}

		private void control_DrawItem(object sender, DrawItemEventArgs e)
		{
			DrawItemInfo drawItemInfo = new DrawItemInfo(sender, e, GetMenuGlyph((System.Windows.Forms.MenuItem)sender));
			border.Color = _cols[3][1];
			if (drawItemInfo.IsTopItem)
			{
				System.Windows.Forms.Form form = drawItemInfo.MainMenu.GetForm();
				int num = form.ClientSize.Width + (form.Width - form.ClientSize.Width) / 2;
				_blends[0].Colors = _cols[1];
				lnbrs.InterpolationColors = _blends[0];
				lnbrs.Transform = new Matrix(0f - (float)num, 0f, 0f, 1f, 0f, 0f);
				if (e.Index >= drawItemInfo.MainMenu.MenuItems.Count - 1 || drawItemInfo.MainMenu.MenuItems[e.Index + 1].BarBreak)
				{
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, num - drawItemInfo.Rct.X, drawItemInfo.Rct.Height);
				}
				else
				{
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct);
				}
				_lastwidth = 0;
				if (drawItemInfo.Selected)
				{
					_lastwidth = e.Bounds.Width;
				}
				drawItemInfo.Rct.Width--;
				drawItemInfo.Rct.Height--;
				lnbrs.Transform = new Matrix(0f, drawItemInfo.Rct.Height + 1, 1f, 0f, 0f, drawItemInfo.Rct.Y);
				if (drawItemInfo.Selected && !drawItemInfo.Item.IsParent)
				{
					drawItemInfo.HotLight = true;
				}
				if (drawItemInfo.HotLight && !drawItemInfo.Disabled)
				{
					_blends[0].Colors = _cols[2];
					lnbrs.InterpolationColors = _blends[0];
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct);
					e.Graphics.DrawRectangle(border, drawItemInfo.Rct);
				}
				else if (drawItemInfo.Selected && !drawItemInfo.Disabled)
				{
					_blends[1].Colors = _cols[0];
					lnbrs.InterpolationColors = _blends[1];
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct);
					e.Graphics.DrawLines(border, new Point[4]
					{
						new Point(drawItemInfo.Rct.X, drawItemInfo.Rct.Bottom),
						new Point(drawItemInfo.Rct.X, drawItemInfo.Rct.Y),
						new Point(drawItemInfo.Rct.Right, drawItemInfo.Rct.Y),
						new Point(drawItemInfo.Rct.Right, drawItemInfo.Rct.Bottom)
					});
				}
				if (drawItemInfo.Item.Text != "")
				{
					SizeF sizeF = e.Graphics.MeasureString(drawItemInfo.Item.Text.Replace("&", ""), e.Font);
					e.Graphics.DrawString(drawItemInfo.Item.Text, e.Font, drawItemInfo.Disabled ? Brushes.Gray : Brushes.Black, drawItemInfo.Rct.X + (drawItemInfo.Rct.Width - (int)sizeF.Width) / 2, drawItemInfo.Rct.Y + (drawItemInfo.Rct.Height - (int)sizeF.Height) / 2, fmt);
				}
				return;
			}
			_blends[1].Colors = _cols[0];
			lnbrs.InterpolationColors = _blends[1];
			lnbrs.Transform = new Matrix(_marginSize.Width, 0f, 0f, 1f, (float)drawItemInfo.Rct.X - 1f, 0f);
			e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, _marginSize.Width, drawItemInfo.Rct.Height);
			hotbrs.Color = _cols[3][0];
			e.Graphics.FillRectangle(hotbrs, drawItemInfo.Rct.X + _marginSize.Width, drawItemInfo.Rct.Y, drawItemInfo.Rct.Width - _marginSize.Width, drawItemInfo.Rct.Height);
			if (drawItemInfo.Item.Text == "-")
			{
				border.Color = _cols[0][2];
				e.Graphics.DrawLine(border, drawItemInfo.Rct.X + _marginSize.Width + 2, drawItemInfo.Rct.Y + drawItemInfo.Rct.Height / 2, drawItemInfo.Rct.Right, drawItemInfo.Rct.Y + drawItemInfo.Rct.Height / 2);
				return;
			}
			if (drawItemInfo.Selected && !drawItemInfo.Disabled)
			{
				hotbrs.Color = _cols[2][0];
				e.Graphics.FillRectangle(hotbrs, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, drawItemInfo.Rct.Width - 1, drawItemInfo.Rct.Height - 1);
				e.Graphics.DrawRectangle(border, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, drawItemInfo.Rct.Width - 1, drawItemInfo.Rct.Height - 1);
			}
			if (drawItemInfo.Checked)
			{
				int num2 = _marginSize.Width / 2;
				int num3 = _marginSize.Height / 2;
				hotbrs.Color = _cols[2][1];
				e.Graphics.FillRectangle(hotbrs, drawItemInfo.Rct.X + 1, drawItemInfo.Rct.Y + 1, _marginSize.Width - 4, _marginSize.Height - 3);
				e.Graphics.DrawRectangle(border, drawItemInfo.Rct.X + 1, drawItemInfo.Rct.Y + 1, _marginSize.Width - 4, _marginSize.Height - 3);
				if (drawItemInfo.Glyph == null)
				{
					e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					if (!drawItemInfo.Item.RadioCheck)
					{
						e.Graphics.FillPolygon(Brushes.Black, new Point[6]
						{
							new Point(drawItemInfo.Rct.X + num2 - 4, drawItemInfo.Rct.Y + num3 + 1),
							new Point(drawItemInfo.Rct.X + num2 - 1, drawItemInfo.Rct.Y + num3 + 3),
							new Point(drawItemInfo.Rct.X + num2 + 3, drawItemInfo.Rct.Y + num3 - 1),
							new Point(drawItemInfo.Rct.X + num2 + 3, drawItemInfo.Rct.Y + num3 - 3),
							new Point(drawItemInfo.Rct.X + num2 - 1, drawItemInfo.Rct.Y + num3 + 1),
							new Point(drawItemInfo.Rct.X + num2 - 4, drawItemInfo.Rct.Y + num3 - 1)
						});
					}
					else
					{
						e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
						e.Graphics.FillEllipse(Brushes.Black, drawItemInfo.Rct.X + num2 - 4, drawItemInfo.Rct.Y + num3 - 4, 7, 7);
					}
					e.Graphics.SmoothingMode = SmoothingMode.Default;
				}
			}
			if (drawItemInfo.Glyph != null)
			{
				if (!drawItemInfo.Disabled)
				{
					e.Graphics.DrawImageUnscaled(drawItemInfo.Glyph, drawItemInfo.Rct.X + (_marginSize.Width - drawItemInfo.Glyph.Width) / 2, drawItemInfo.Rct.Y + (_marginSize.Height - drawItemInfo.Glyph.Height) / 2);
				}
				else
				{
					ControlPaint.DrawImageDisabled(e.Graphics, drawItemInfo.Glyph, drawItemInfo.Rct.X + (_marginSize.Width - drawItemInfo.Glyph.Width) / 2, drawItemInfo.Rct.Y + (_marginSize.Height - drawItemInfo.Glyph.Height) / 2, Color.Transparent);
				}
			}
			Font font = (drawItemInfo.Item.DefaultItem ? new Font(e.Font, FontStyle.Bold) : SystemInformation.MenuFont);
			if (drawItemInfo.Item.Text != "")
			{
				SizeF sizeF2 = e.Graphics.MeasureString(drawItemInfo.Item.Text, font);
				e.Graphics.DrawString(drawItemInfo.Item.Text, font, drawItemInfo.Disabled ? Brushes.Gray : Brushes.Black, drawItemInfo.Rct.X + _marginSize.Width + 5, drawItemInfo.Rct.Y + (drawItemInfo.Rct.Height - (int)sizeF2.Height) / 2, fmt);
			}
			if (drawItemInfo.Item.Shortcut != System.Windows.Forms.Shortcut.None && drawItemInfo.Item.ShowShortcut)
			{
				string shortcutString = GetShortcutString((System.Windows.Forms.Keys)drawItemInfo.Item.Shortcut);
				SizeF sizeF2 = e.Graphics.MeasureString(shortcutString, font);
				e.Graphics.DrawString(shortcutString, font, drawItemInfo.Disabled ? Brushes.Gray : Brushes.Black, drawItemInfo.Rct.Right - (int)sizeF2.Width - 16, drawItemInfo.Rct.Y + (drawItemInfo.Rct.Height - (int)sizeF2.Height) / 2);
			}
		}

		[Description("Specifies wheter NewStyle-Drawing is enabled or not")]
		[Browsable(false)]
		public bool GetNewStyleActive(System.Windows.Forms.MenuItem control)
		{
			return true;
		}

		public void SetNewStyleActive(System.Windows.Forms.MenuItem control, bool value)
		{
			if (!value)
			{
				if (_menuitems.Contains(control))
				{
					_menuitems.Remove(control);
				}
				control.OwnerDraw = false;
				control.MeasureItem -= control_MeasureItem;
				control.DrawItem -= control_DrawItem;
			}
			else
			{
				if (!_menuitems.Contains(control))
				{
					_menuitems.Add(control, new MenuItemInfo(newstyle: true, null));
				}
				else
				{
					((MenuItemInfo)_menuitems[control]).NewStyle = true;
				}
				control.OwnerDraw = true;
				control.MeasureItem += control_MeasureItem;
				control.DrawItem += control_DrawItem;
			}
		}

		[Description("Specifies the image displayed next to the MenuItem")]
		[DefaultValue(null)]
		public Image GetMenuGlyph(System.Windows.Forms.MenuItem control)
		{
			return ((MenuItemInfo)_menuitems[control])?.Glyph;
		}

		public void SetMenuGlyph(System.Windows.Forms.MenuItem control, Image value)
		{
			if (value == null)
			{
				if (_menuitems.Contains(control))
				{
					((MenuItemInfo)_menuitems[control]).Glyph = null;
					if (!((MenuItemInfo)_menuitems[control]).NewStyle)
					{
						_menuitems.Remove(control);
					}
				}
			}
			else if (!_menuitems.Contains(control))
			{
				_menuitems.Add(control, new MenuItemInfo(newstyle: true, value));
				control.OwnerDraw = true;
				control.MeasureItem += control_MeasureItem;
				control.DrawItem += control_DrawItem;
			}
			else
			{
				((MenuItemInfo)_menuitems[control]).Glyph = value;
			}
		}

		private int OnHookProc(int code, IntPtr wparam, ref Win32.CWPSTRUCT cwp)
		{
			if (code == 0)
			{
				switch (cwp.message)
				{
				case 1:
				{
					StringBuilder stringBuilder = new StringBuilder(64);
					int className = Win32.GetClassName(cwp.hwnd, stringBuilder, stringBuilder.Capacity);
					string strA = stringBuilder.ToString();
					if (string.Compare(strA, "#32768", ignoreCase: false) == 0)
					{
						lastHook = new MenuHook(this, _lastwidth);
						lastHook.AssignHandle(cwp.hwnd);
						_lastwidth = 0;
					}
					break;
				}
				case 2:
					if (cwp.hwnd == _owner.Handle && _hook != IntPtr.Zero)
					{
						Win32.UnhookWindowsHookEx(_hook);
						_hook = IntPtr.Zero;
					}
					break;
				}
			}
			return Win32.CallNextHookEx(_hook, code, wparam, ref cwp);
		}

		private string GetShortcutString(System.Windows.Forms.Keys shortcut)
		{
			return TypeDescriptor.GetConverter(typeof(System.Windows.Forms.Keys)).ConvertToString(shortcut);
		}
	}
	internal class MenuHook : NativeWindow
	{
		private ClientMenuStyleProvider _parent = null;

		private int _lastwidth = 0;

		public MenuHook(ClientMenuStyleProvider parent, int lastwidth)
		{
			if (parent == null)
			{
				throw new ArgumentNullException();
			}
			_parent = parent;
			_lastwidth = lastwidth;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 70:
			{
				Win32.WINDOWPOS structure2 = (Win32.WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(Win32.WINDOWPOS));
				if ((structure2.flags & 1) == 0)
				{
					structure2.cx -= 2;
					structure2.cy -= 2;
				}
				Marshal.StructureToPtr(structure2, m.LParam, fDeleteOld: true);
				m.Result = IntPtr.Zero;
				break;
			}
			case 133:
			{
				IntPtr windowDC = Win32.GetWindowDC(m.HWnd);
				Graphics graphics = Graphics.FromHdc(windowDC);
				DrawBorder(graphics);
				Win32.ReleaseDC(m.HWnd, windowDC);
				graphics.Dispose();
				m.Result = IntPtr.Zero;
				break;
			}
			case 131:
			{
				Win32.NCCALCSIZE_PARAMS structure = (Win32.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(Win32.NCCALCSIZE_PARAMS));
				structure.r1.Left += 2;
				structure.r1.Top += 2;
				structure.r1.Right -= 2;
				structure.r1.Bottom -= 2;
				Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: true);
				m.Result = new IntPtr(768);
				break;
			}
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void DrawBorder(Graphics gr)
		{
			Rectangle rectangle = Rectangle.Round(gr.VisibleClipBounds);
			rectangle.Width--;
			rectangle.Height--;
			int marginWidth = _parent.MarginWidth;
			gr.FillRectangle(_parent.MarginBrush, rectangle.X + 1, rectangle.Y + 1, 1, rectangle.Height - 1);
			gr.FillRectangle(_parent.BackGroundBrush, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, 1);
			gr.FillRectangle(_parent.BackGroundBrush, rectangle.X + 1, rectangle.Bottom - 1, rectangle.Width - 1, 1);
			gr.FillRectangle(_parent.BackGroundBrush, rectangle.Right - 1, rectangle.Y + 1, 1, rectangle.Height);
			gr.DrawLine(_parent.BackgroundPen, rectangle.X + 1, rectangle.Y, rectangle.X + _lastwidth - 2, rectangle.Y);
			gr.DrawLine(_parent.BorderPen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Bottom);
			gr.DrawLine(_parent.BorderPen, rectangle.X, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
			gr.DrawLine(_parent.BorderPen, rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Y);
			gr.DrawLine(_parent.BorderPen, rectangle.Right, rectangle.Y, rectangle.X + _lastwidth - 1, rectangle.Y);
		}
	}
	internal abstract class Win32
	{
		public struct NCCALCSIZE_PARAMS
		{
			public RECT r1;

			public RECT r2;

			public RECT r3;

			public IntPtr lppos;
		}

		public struct RECT
		{
			internal int Left;

			internal int Top;

			internal int Right;

			internal int Bottom;
		}

		public struct CWPSTRUCT
		{
			public IntPtr lparam;

			public IntPtr wparam;

			public int message;

			public IntPtr hwnd;
		}

		public struct WINDOWPOS
		{
			internal int hwnd;

			internal int hWndInsertAfter;

			internal int x;

			internal int y;

			internal int cx;

			internal int cy;

			internal int flags;
		}

		public delegate int HookProc(int code, IntPtr wparam, ref CWPSTRUCT cwp);

		public const int WH_CALLWNDPROC = 4;

		public const int WM_CREATE = 1;

		public const int WM_DESTROY = 2;

		public const int WM_NCPAINT = 133;

		public const int WM_PRINT = 791;

		public const int WM_WINDOWPOSCHANGING = 70;

		public const int SWP_NOSIZE = 1;

		public const int WM_NCCALCSIZE = 131;

		public const int WVR_REDRAW = 768;

		public const int WVR_HREDRAW = 256;

		public const int WVR_VREDRAW = 512;

		public const int SWP_NOMOVE = 2;

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int CallNextHookEx(IntPtr hookHandle, int code, IntPtr wparam, ref CWPSTRUCT cwp);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetClassNameA", ExactSpelling = true, SetLastError = true)]
		public static extern int GetClassName(IntPtr hwnd, StringBuilder className, int maxCount);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetWindowDC(IntPtr hwnd);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindowThreadProcessId(IntPtr hwnd, int ID);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetWindowsHookExA", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr SetWindowsHookEx(int type, HookProc hook, IntPtr instance, int threadID);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool UnhookWindowsHookEx(IntPtr hookHandle);
	}
	public class ClientNumericUpDown : System.Windows.Forms.NumericUpDown, IContextContainer
	{
		private IContext mobjContext = null;

		private IContainer components = null;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}
	}
	public class ClientPanel : System.Windows.Forms.Panel
	{
		private PanelType menmPanelType = PanelType.Normal;

		public PanelType PanelType
		{
			get
			{
				return menmPanelType;
			}
			set
			{
				menmPanelType = value;
				Invalidate(invalidateChildren: true);
			}
		}

		private Font HeaderFont => new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);

		public override Rectangle DisplayRectangle
		{
			get
			{
				if (menmPanelType == PanelType.Titled)
				{
					Rectangle displayRectangle = base.DisplayRectangle;
					return new Rectangle(displayRectangle.Left + 1, displayRectangle.Top + 26, displayRectangle.Right - displayRectangle.Left - 2, displayRectangle.Bottom - displayRectangle.Top - 28);
				}
				return base.DisplayRectangle;
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (menmPanelType == PanelType.Titled)
				{
					Invalidate(invalidateChildren: false);
				}
			}
		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			if (menmPanelType == PanelType.Titled)
			{
				Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
				e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);
				e.Graphics.DrawRectangle(new Pen(Color.DarkBlue, 1f), 0, 0, base.Width - 1, base.Height - 1);
				LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, 30), Color.Blue, Color.DarkBlue);
				Rectangle rect2 = new Rectangle(1, 1, base.Width - 2, 25);
				e.Graphics.FillRectangle(brush, rect2);
				SolidBrush brush2 = new SolidBrush(Color.White);
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Near;
				RectangleF layoutRectangle = new RectangleF(5f, 5f, base.Width - 7, HeaderFont.Height);
				e.Graphics.DrawString(Text, HeaderFont, brush2, layoutRectangle, stringFormat);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (menmPanelType == PanelType.Titled)
			{
				Invalidate(invalidateChildren: false);
			}
		}
	}
	public class ClientStackPanel : System.Windows.Forms.Panel
	{
		private Dictionary<System.Windows.Forms.Control, Size> marrControlSizes = new Dictionary<System.Windows.Forms.Control, Size>();

		private System.Windows.Forms.Orientation menmOrientation = System.Windows.Forms.Orientation.Vertical;

		public System.Windows.Forms.Orientation Orientation
		{
			get
			{
				return menmOrientation;
			}
			set
			{
				if (menmOrientation == value)
				{
					return;
				}
				menmOrientation = value;
				foreach (System.Windows.Forms.Control control in base.Controls)
				{
					ApplyControlSize(control);
					ApplyControlDockStyle(control);
				}
			}
		}

		protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
		{
			base.OnControlAdded(e);
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				marrControlSizes.Add(control, control.Size);
				control.DockChanged += OnContainedControlDockChanged;
				ApplyControlDockStyle(control);
			}
		}

		private void OnContainedControlDockChanged(object sender, EventArgs e)
		{
			if (sender is System.Windows.Forms.Control objControl)
			{
				ApplyControlDockStyle(objControl);
			}
		}

		protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				control.DockChanged -= OnContainedControlDockChanged;
				if (marrControlSizes.ContainsKey(control))
				{
					marrControlSizes.Remove(control);
				}
			}
		}

		private void ApplyControlDockStyle(System.Windows.Forms.Control objControl)
		{
			if (objControl != null)
			{
				objControl.SuspendLayout();
				objControl.Dock = ((Orientation == System.Windows.Forms.Orientation.Vertical) ? System.Windows.Forms.DockStyle.Top : System.Windows.Forms.DockStyle.Left);
				objControl.ResumeLayout();
			}
		}

		private void ApplyControlSize(System.Windows.Forms.Control objControl)
		{
			if (objControl != null)
			{
				Size size = marrControlSizes[objControl];
				bool flag = true;
				objControl.SuspendLayout();
				switch (Orientation)
				{
				case System.Windows.Forms.Orientation.Horizontal:
					objControl.Width = size.Width;
					break;
				case System.Windows.Forms.Orientation.Vertical:
					objControl.Height = size.Height;
					break;
				}
				objControl.ResumeLayout();
			}
		}
	}
	public class ClientTreeNode : System.Windows.Forms.TreeNode
	{
		private System.Windows.Forms.ContextMenu mobjContextMenu = null;

		public bool HasNodes
		{
			get
			{
				return base.Nodes.Count > 0;
			}
			set
			{
				if (base.Nodes.Count == 0 && value)
				{
					System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode();
					treeNode.Tag = "$$TEMP";
					base.Nodes.Add(treeNode);
				}
			}
		}

		public bool HasDummyNodes => base.Nodes.Count > 0 && base.Nodes[0].Tag == "$$TEMP";

		public new System.Windows.Forms.ContextMenu ContextMenu
		{
			get
			{
				return mobjContextMenu;
			}
			set
			{
				mobjContextMenu = value;
			}
		}
	}
	public class ClientTreeView : System.Windows.Forms.TreeView, IContextContainer
	{
		private IContext mobjContext = null;

		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		public ClientTreeView()
		{
			base.MouseUp += ClientTreeView_MouseUp;
		}

		private void ClientTreeView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right && GetNodeAt(e.X, e.Y) is ClientTreeNode { ContextMenu: not null } clientTreeNode)
			{
				IContextServices contextServices = (IContextServices)((IContextContainer)this).Context;
				if (contextServices != null && contextServices.GetControllerByWinObject(clientTreeNode.ContextMenu) is ContextMenuController contextMenuController)
				{
					contextMenuController.SetTarget(clientTreeNode);
					clientTreeNode.ContextMenu.Show(this, new Point(e.X, e.Y));
				}
			}
		}
	}
	public class ClientUpDown : System.Windows.Forms.UpDownBase, IContextContainer
	{
		private IContext mobjContext = null;

		private IContainer components = null;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		IContext IContextContainer.Context
		{
			get
			{
				return mobjContext;
			}
			set
			{
				mobjContext = value;
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		public override void DownButton()
		{
		}

		public override void UpButton()
		{
		}

		protected override void UpdateEditText()
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}
	}
}
namespace Gizmox.WebGUI.Client.Design
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClientDesignContext
	{
		public static IContext CreateContext(IClientDesignServices objDesignServices)
		{
			return new Context(objDesignServices);
		}

		public static IClientObjectController CreateMenuController(IContext objContext, IComponent objWebComponent)
		{
			if (objWebComponent is Gizmox.WebGUI.Forms.ContextMenu)
			{
				return new ContextMenuController(objContext, objWebComponent);
			}
			if (objWebComponent is Gizmox.WebGUI.Forms.MenuItem)
			{
				return new MenuItemController(objContext, objWebComponent);
			}
			if (objWebComponent is Gizmox.WebGUI.Forms.MainMenu)
			{
				return new MainMenuController(objContext, objWebComponent);
			}
			return CreateControllerByWebObject(objContext, objWebComponent);
		}

		public static IClientObjectController CreateControllerByWebObject(IContext objContext, object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(objContext, objWebObject);
		}
	}
}
namespace Gizmox.WebGUI.Client.Controllers
{
	public class BindingNavigatorController : ToolBarController
	{
		public Gizmox.WebGUI.Forms.BindingNavigator WebBindingNavigator => base.SourceObject as Gizmox.WebGUI.Forms.BindingNavigator;

		public System.Windows.Forms.BindingNavigator WinBindingNavigator => base.TargetObject as System.Windows.Forms.BindingNavigator;

		public BindingNavigatorController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
		}

		public BindingNavigatorController(IContext objContext, object objWebControl)
			: base(objContext, objWebControl)
		{
		}
	}
	public class ButtonBaseControler : ControlController
	{
		public Gizmox.WebGUI.Forms.ButtonBase WebButtonBase => base.SourceObject as Gizmox.WebGUI.Forms.ButtonBase;

		public System.Windows.Forms.ButtonBase WinButtonBase => base.TargetObject as System.Windows.Forms.ButtonBase;

		public ButtonBaseControler(IContext objContext, object objWebButtonBase, object objWinButtonBase)
			: base(objContext, objWebButtonBase, objWinButtonBase)
		{
		}

		public ButtonBaseControler(IContext objContext, object objWebButtonBase)
			: base(objContext, objWebButtonBase)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinButtonBaseTextImageRelation();
			SetWinButtonBaseImage();
			SetWinButtonBaseImageIndex();
			SetWinButtonBaseImageKey();
			SetWinButtonBaseImageAlign();
			SetWinButtonBaseUseVisualStyleBackColor();
			SetWinButtonBaseTextAlign();
		}

		private void SetWinButtonBaseTextAlign()
		{
			WinButtonBase.TextAlign = WebButtonBase.TextAlign;
		}

		private void SetWebButtonBaseUseVisualStyleBackColor()
		{
			WebButtonBase.UseVisualStyleBackColor = WinButtonBase.UseVisualStyleBackColor;
		}

		private void SetWinButtonBaseUseVisualStyleBackColor()
		{
			WinButtonBase.UseVisualStyleBackColor = WebButtonBase.UseVisualStyleBackColor;
		}

		protected virtual void SetWinButtonBaseTextImageRelation()
		{
			WinButtonBase.TextImageRelation = (System.Windows.Forms.TextImageRelation)GetConvertedEnum(typeof(System.Windows.Forms.TextImageRelation), WebButtonBase.TextImageRelation);
		}

		protected virtual void SetWinButtonBaseImageAlign()
		{
			WinButtonBase.ImageAlign = (ContentAlignment)GetConvertedEnum(typeof(ContentAlignment), WebButtonBase.ImageAlign);
		}

		protected virtual void SetWinButtonBaseImageIndex()
		{
			if (WebButtonBase.ImageIndex != -1)
			{
				if (WinButtonBase.ImageList == null)
				{
					WinButtonBase.ImageList = new System.Windows.Forms.ImageList();
				}
				WinButtonBase.ImageIndex = GetWinImageIndex(WinButtonBase.ImageList, WebButtonBase.Image);
			}
			else if (WinButtonBase.ImageIndex != -1)
			{
				WinButtonBase.ImageIndex = -1;
			}
		}

		protected virtual void SetWinButtonBaseImageKey()
		{
			if (WebButtonBase.ImageKey != string.Empty)
			{
				if (WinButtonBase.ImageList == null)
				{
					WinButtonBase.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(WinButtonBase.ImageList, WebButtonBase.Image, WebButtonBase.ImageKey) > -1)
				{
					WinButtonBase.ImageKey = WebButtonBase.ImageKey;
				}
			}
			else if (WinButtonBase.ImageKey != string.Empty)
			{
				WinButtonBase.ImageKey = string.Empty;
			}
		}

		protected virtual void SetWinButtonBaseImage()
		{
			if (WebButtonBase.Image != null)
			{
				WinButtonBase.Image = GetWinImageFromResourceHandle(WebButtonBase.Image);
			}
			else if (WinButtonBase.Image != null)
			{
				WinButtonBase.Image = null;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Image":
				SetWinButtonBaseImage();
				break;
			case "ImageIndex":
				SetWinButtonBaseImageIndex();
				break;
			case "ImageKey":
				SetWinButtonBaseImageKey();
				break;
			case "TextImageRelation":
				SetWinButtonBaseTextImageRelation();
				break;
			case "ImageAlign":
				SetWinButtonBaseImageAlign();
				break;
			case "UseVisualStyleBackColor":
				SetWinButtonBaseUseVisualStyleBackColor();
				break;
			case "TextAlign":
				SetWinButtonBaseTextAlign();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "UseVisualStyleBackColor")
			{
				SetWebButtonBaseUseVisualStyleBackColor();
			}
		}
	}
	public class ButtonController : ButtonBaseControler
	{
		private ContextMenuController mobjDropDownMenuController = null;

		protected ContextMenuController DropDownMenuController
		{
			get
			{
				if (mobjDropDownMenuController == null && WebButton != null && WebButton.DropDownMenu != null)
				{
					System.Windows.Forms.ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
					mobjDropDownMenuController = new ContextMenuController(base.Context, WebButton.DropDownMenu, contextMenu);
					mobjDropDownMenuController.Initialize();
					RegisterController(mobjDropDownMenuController);
					if (WebButton.DropDownMenu.Site != null && contextMenu != null)
					{
						base.DesignServices.RegisterWinComponent(contextMenu, WebButton.DropDownMenu.Site.Name);
					}
				}
				return mobjDropDownMenuController;
			}
		}

		public Gizmox.WebGUI.Forms.Button WebButton => base.SourceObject as Gizmox.WebGUI.Forms.Button;

		public ClientButton WinButton => base.TargetObject as ClientButton;

		public ButtonController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public ButtonController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinButtonDropDownMenu();
			SetWinButtonAutoSizeMode();
		}

		protected virtual void SetWinButtonDropDownMenu()
		{
			if (DropDownMenuController != null)
			{
				WinButton.DropDownMenu = DropDownMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinButtonAutoSizeMode()
		{
			WinButton.AutoSizeMode = (System.Windows.Forms.AutoSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.AutoSizeMode), WebButton.AutoSizeMode);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientButton();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "AutoSizeMode")
			{
				SetWinButtonAutoSizeMode();
			}
		}
	}
	public class CheckBoxController : ButtonBaseControler
	{
		public Gizmox.WebGUI.Forms.CheckBox WebCheckBox => base.SourceObject as Gizmox.WebGUI.Forms.CheckBox;

		public System.Windows.Forms.CheckBox WinCheckBox => base.TargetObject as System.Windows.Forms.CheckBox;

		public CheckBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public CheckBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinCheckBoxChecked();
			SetWinCheckBoxThreeState();
			SetWinCheckBoxCheckState();
			SetWinAppearance();
			SetWinCheckAlign();
		}

		protected virtual void SetWinCheckBoxChecked()
		{
			WinCheckBox.Checked = WebCheckBox.Checked;
		}

		protected virtual void SetWinCheckBoxThreeState()
		{
			WinCheckBox.ThreeState = WebCheckBox.ThreeState;
		}

		protected virtual void SetWinCheckBoxCheckState()
		{
			WinCheckBox.CheckState = (System.Windows.Forms.CheckState)GetConvertedEnum(typeof(System.Windows.Forms.CheckState), WebCheckBox.CheckState);
		}

		protected virtual void SetWinAppearance()
		{
			object convertedEnum = GetConvertedEnum(typeof(System.Windows.Forms.Appearance), WebCheckBox.Appearance);
			if (convertedEnum != null)
			{
				WinCheckBox.Appearance = (System.Windows.Forms.Appearance)convertedEnum;
			}
		}

		protected virtual void SetWinCheckAlign()
		{
			WinCheckBox.CheckAlign = WebCheckBox.CheckAlign;
		}

		protected virtual void SetWebCheckAlign()
		{
			WebCheckBox.CheckAlign = WinCheckBox.CheckAlign;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.CheckBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinCheckBox.Click += WinCheckBox_CheckedChanged;
		}

		private void WinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("Checked", WinCheckBox.Checked ? "1" : "0");
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinCheckBox.Click -= WinCheckBox_CheckedChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Checked":
				SetWinCheckBoxChecked();
				break;
			case "ThreeState":
				SetWinCheckBoxThreeState();
				break;
			case "CheckState":
				SetWinCheckBoxCheckState();
				break;
			case "CheckAlign":
				SetWinCheckAlign();
				break;
			case "Appearance":
				SetWinAppearance();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "CheckAlign")
			{
				SetWebCheckAlign();
			}
		}
	}
	public class CheckedListBoxController : ListBoxController
	{
		public Gizmox.WebGUI.Forms.CheckedListBox WebCheckedListBox => base.SourceObject as Gizmox.WebGUI.Forms.CheckedListBox;

		public System.Windows.Forms.CheckedListBox WinCheckedListBox => base.TargetObject as System.Windows.Forms.CheckedListBox;

		public CheckedListBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public CheckedListBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinCheckOnClick();
		}

		protected virtual void SetWinCheckOnClick()
		{
			WinCheckedListBox.CheckOnClick = WebCheckedListBox.CheckOnClick;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.CheckedListBox();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "CheckOnClick")
			{
				SetWinCheckOnClick();
			}
		}
	}
	public class ComboBoxController : ListControlController
	{
		private ItemsCollectionController mobjItemsCollectionController = null;

		public Gizmox.WebGUI.Forms.ComboBox WebComboBox => base.SourceObject as Gizmox.WebGUI.Forms.ComboBox;

		public System.Windows.Forms.ComboBox WinComboBox => base.TargetObject as System.Windows.Forms.ComboBox;

		public ComboBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebComboBox, WebComboBox.Items, WinComboBox, WinComboBox.Items);
		}

		public ComboBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebComboBox, WebComboBox.Items, WinComboBox, WinComboBox.Items);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "DropDownStyle"))
			{
				if (property == "Items")
				{
					SetWinComboBoxItems();
				}
			}
			else
			{
				SetWinComboDropDownStyle();
			}
		}

		private void SetWinComboBoxItems()
		{
			if (WinComboBox != null && WebComboBox != null)
			{
				WinComboBox.Items.Clear();
				object[] array = new object[WebComboBox.Items.Count];
				WebComboBox.Items.CopyTo(array, 0);
				WinComboBox.Items.AddRange(array);
			}
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinComboBox.SizeChanged += WinComboBox_SizeChanged;
		}

		private void WinComboBox_SizeChanged(object sender, EventArgs e)
		{
			SetWebControlSize();
		}

		public override void InitializeNew()
		{
			base.InitializeNew();
			if (WebComboBox != null)
			{
				WebComboBox.FormattingEnabled = true;
			}
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinComboBox.SizeChanged -= WinComboBox_SizeChanged;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DropDownStyle")
			{
				SetWebComboDropDownStyle();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinComboDropDownStyle();
			SetWinComboBoxItems();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjItemsCollectionController.Initialize();
		}

		protected override void SetWebControlText()
		{
		}

		protected virtual void SetWinComboDropDownStyle()
		{
			WinComboBox.DropDownStyle = (System.Windows.Forms.ComboBoxStyle)GetConvertedEnum(typeof(System.Windows.Forms.ComboBoxStyle), WebComboBox.DropDownStyle);
		}

		protected virtual void SetWebComboDropDownStyle()
		{
			WebComboBox.DropDownStyle = (Gizmox.WebGUI.Forms.ComboBoxStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.ComboBoxStyle), WinComboBox.DropDownStyle);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ComboBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinComboBox.SelectedIndexChanged += WinListBox_SelectedIndexChanged;
		}

		private void WinListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("VLB", WinComboBox.SelectedIndex.ToString());
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinComboBox.SelectedIndexChanged -= WinListBox_SelectedIndexChanged;
		}
	}
	public class ComponentController : GenericComponentController
	{
		private ContextMenuController mobjContextMenuController = null;

		protected ContextMenuController ContextMenuController
		{
			get
			{
				if (mobjContextMenuController == null && WebComponent != null && WebComponent.ContextMenu != null)
				{
					System.Windows.Forms.ContextMenu objWinControl = new System.Windows.Forms.ContextMenu();
					mobjContextMenuController = new ContextMenuController(base.Context, WebComponent.ContextMenu, objWinControl);
					mobjContextMenuController.InitializeController();
				}
				return mobjContextMenuController;
			}
		}

		public Gizmox.WebGUI.Forms.Component WebComponent => base.SourceObject as Gizmox.WebGUI.Forms.Component;

		public System.ComponentModel.Component WinComponent => base.TargetObject as System.ComponentModel.Component;

		public ComponentController(IContext objContext, object objWebComponent, object objWinComponent)
			: base(objContext, objWebComponent, objWinComponent)
		{
		}

		public ComponentController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			IObservableItem webComponent = WebComponent;
			if (webComponent != null && !base.DesignMode)
			{
				webComponent.ObservableItemPropertyChanged += objObservableItem_ObservableItemPropertyChanged;
			}
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			IObservableItem webComponent = WebComponent;
			if (webComponent != null && !base.DesignMode)
			{
				webComponent.ObservableItemPropertyChanged -= objObservableItem_ObservableItemPropertyChanged;
			}
		}

		protected void SetWinProperty(string strPropertyName, object objNewValue)
		{
			SuspendDesigner();
			SuspendNotifications();
			try
			{
				object winComponent = WinComponent;
				if (winComponent == null)
				{
					return;
				}
				PropertyInfo property = winComponent.GetType().GetProperty(strPropertyName);
				if (property != null)
				{
					if (base.DesignMode)
					{
						base.DesignServices.FireWinComponentChanging(WinComponent, strPropertyName);
					}
					object value = property.GetValue(winComponent, new object[0]);
					property.SetValue(winComponent, objNewValue, new object[0]);
					if (base.DesignMode)
					{
						base.DesignServices.FireWinComponentChanged(WinComponent, strPropertyName, value, objNewValue);
					}
				}
			}
			finally
			{
				ResumeNotifications();
				ResumeDesigner();
			}
		}

		protected void SetWebProperty(string strPropertyName, object objNewValue)
		{
			SuspendDesigner();
			SuspendNotifications();
			try
			{
				object webComponent = WebComponent;
				if (webComponent == null)
				{
					return;
				}
				PropertyInfo property = webComponent.GetType().GetProperty(strPropertyName);
				if (property != null)
				{
					if (base.DesignMode)
					{
						base.DesignServices.FireWebComponentChanging(WebComponent, strPropertyName);
					}
					object value = property.GetValue(webComponent, new object[0]);
					property.SetValue(webComponent, objNewValue, new object[0]);
					if (base.DesignMode)
					{
						base.DesignServices.FireWebComponentChanged(WebComponent, strPropertyName, value, objNewValue);
					}
				}
			}
			finally
			{
				ResumeNotifications();
				ResumeDesigner();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void ReplaceSource(object objSource)
		{
			if (base.DesignMode && objSource is IComponent objWebComponent)
			{
				base.DesignServices.RegisterWebComponent(objWebComponent);
				IComponent webComponent = WebComponent;
				if (webComponent != null)
				{
					base.DesignServices.UnregisterWebComponent(webComponent);
				}
				base.ReplaceSource(objSource);
			}
		}

		private void objObservableItem_ObservableItemPropertyChanged(object objSender, ObservableItemPropertyChangedArgs objArgs)
		{
			((IContextNotifications)base.Context).NotifyItemPropertyChanged(this, objArgs, blnWebEvent: true);
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
			OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected virtual Event CreateWebEvent(string strType)
		{
			return CreateWebEvent(strType, base.SourceObject);
		}

		protected virtual Event CreateWebEvent(string strType, object objWebSource)
		{
			return CreateWebEvent(base.Context, strType, objWebSource, null);
		}

		protected virtual Event CreateWebEvent(string strType, object objWebSource, object objWebTarget)
		{
			return CreateWebEvent(base.Context, strType, objWebSource, objWebTarget);
		}

		protected virtual Event CreateWebEvent(IContext objContext, string strType, object objWebSource, object objWebTarget)
		{
			if (objWebSource is IRegisteredComponent objSource)
			{
				return new Event(objContext, strType, objSource, objWebTarget as IRegisteredComponent);
			}
			return null;
		}
	}
	public class ContainerControlController : ScrollableControlController
	{
		public new Gizmox.WebGUI.Forms.ScrollableControl WebScrollableControl => base.SourceObject as Gizmox.WebGUI.Forms.ScrollableControl;

		public new System.Windows.Forms.ScrollableControl WinScrollableControl => base.TargetObject as System.Windows.Forms.ScrollableControl;

		public ContainerControlController(IContext objContext, object objWebContainerControl, object objWinContainerControl)
			: base(objContext, objWebContainerControl, objWinContainerControl)
		{
		}

		public ContainerControlController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
	}
	public class ContextMenuController : MenuController
	{
		private MenuItemCollectionController mobjMenuItemCollectionController = null;

		private object mobjTarget = null;

		public Gizmox.WebGUI.Forms.ContextMenu WebContextMenu => base.SourceObject as Gizmox.WebGUI.Forms.ContextMenu;

		public System.Windows.Forms.ContextMenu WinContextMenu => base.TargetObject as System.Windows.Forms.ContextMenu;

		public ContextMenuController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebContextMenu, WebContextMenu.MenuItems, WinContextMenu, WinContextMenu.MenuItems);
		}

		public ContextMenuController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebContextMenu, WebContextMenu.MenuItems, WinContextMenu, WinContextMenu.MenuItems);
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
		}

		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}

		public virtual void SetTarget(object objWinObject)
		{
			mobjTarget = objWinObject;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "VWGNullProperty" && mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.SetWebObjectObjects();
			}
		}

		public object GetTarget()
		{
			return mobjTarget;
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Terminate();
			}
		}
	}
	public class ContextMenuStripController : ToolStripDropDownMenuController
	{
		protected override bool UseVsMenuDeisgner => false;

		private Gizmox.WebGUI.Forms.ContextMenuStrip WebContextMenuStrip => base.WebControl as Gizmox.WebGUI.Forms.ContextMenuStrip;

		private System.Windows.Forms.ContextMenuStrip WinContextMenuStrip => base.WinControl as System.Windows.Forms.ContextMenuStrip;

		public ContextMenuStripController(IContext objContext, object objWebContextMenuStrip, object objWinContextMenuStrip)
			: base(objContext, objWebContextMenuStrip, objWinContextMenuStrip)
		{
		}

		public ContextMenuStripController(IContext objContext, object objWebContextMenuStrip)
			: base(objContext, objWebContextMenuStrip)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinContextMenuStripShowCheckMargin();
			SetWinContextMenuStripShowImageMargin();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ContextMenuStrip();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "ShowCheckMargin"))
			{
				if (property == "ShowImageMargin")
				{
					SetWinContextMenuStripShowImageMargin();
				}
			}
			else
			{
				SetWinContextMenuStripShowCheckMargin();
			}
		}

		private void SetWinContextMenuStripShowImageMargin()
		{
			if (WebContextMenuStrip != null && WinContextMenuStrip != null)
			{
				WinContextMenuStrip.ShowImageMargin = WebContextMenuStrip.ShowImageMargin;
			}
		}

		private void SetWinContextMenuStripShowCheckMargin()
		{
			if (WebContextMenuStrip != null && WinContextMenuStrip != null)
			{
				WinContextMenuStrip.ShowCheckMargin = WebContextMenuStrip.ShowCheckMargin;
			}
		}

		protected override void SetWinControlBackColor()
		{
			if (WinContextMenuStrip != null && WebContextMenuStrip != null && WebContextMenuStrip.BackColor != Color.Transparent)
			{
				base.SetWinControlBackColor();
			}
		}
	}
	public class ControlCollectionController : ComponentCollectionController
	{
		private IObservableLayoutItem WebLayoutItem => base.SourceObject as IObservableLayoutItem;

		public Gizmox.WebGUI.Forms.Control.ControlCollection WebControls => base.WebObjects as Gizmox.WebGUI.Forms.Control.ControlCollection;

		public Gizmox.WebGUI.Forms.Control WebControl => base.SourceObject as Gizmox.WebGUI.Forms.Control;

		public System.Windows.Forms.Control.ControlCollection WinControls => base.WinObjects as System.Windows.Forms.Control.ControlCollection;

		public System.Windows.Forms.Control WinControl => base.TargetObject as System.Windows.Forms.Control;

		public ControlCollectionController(IContext objContext, object objWebControl, IList objWebControls, object objWinControl, IList objWinControls)
			: base(objContext, objWebControl, objWebControls, objWinControl, objWinControls)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(base.Context, objWebObject);
		}

		protected override void InitializeWinObjects()
		{
			WinControl.SuspendLayout();
			if (WebControl is Gizmox.WebGUI.Forms.Form)
			{
				WinControl.ClientSize = new Size(Convert.ToInt32((float)WebLayoutItem.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebLayoutItem.Size.Height * base.TargetVerticalScaleFactor));
			}
			base.InitializeWinObjects();
			WinControl.ResumeLayout();
			if (WebControl is Gizmox.WebGUI.Forms.Form)
			{
				WinControl.Size = new Size(Convert.ToInt32((float)WebControl.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Size.Height * base.TargetVerticalScaleFactor));
			}
		}

		protected override int OnWebObjectAdded(object objWebObject)
		{
			WinControl.SuspendLayout();
			int result = base.OnWebObjectAdded(objWebObject);
			WinControl.ResumeLayout();
			return result;
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinControl.ControlRemoved += WinControl_ControlRemoved;
		}

		private void WinControl_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			if (!base.IsNotificationSuspened && GetControllerByWinObject(e.Control) is ControlController)
			{
				if (GetControllerByWebObject(WebControl) is ControlController controlController2)
				{
					controlController2.SetWebControlControls();
				}
				else
				{
					SetWebControlControls();
				}
			}
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinControl.ControlRemoved -= WinControl_ControlRemoved;
		}

		internal void SetWinControlControls()
		{
			if (WebControls == null || WinControls == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				WinControl.SuspendLayout();
				ArrayList arrayList = new ArrayList(WinControls);
				WinControls.Clear();
				foreach (Gizmox.WebGUI.Forms.Control webControl in WebControls)
				{
					ControlController controlController = ((IContextServices)base.Context).GetControllerByWebObject(webControl) as ControlController;
					if (controlController == null)
					{
						controlController = ObjectController.CreateControllerByWebObject(base.Context, webControl) as ControlController;
						if (base.DesignMode)
						{
							controlController.Initialize();
							controlController.Load();
							RegisterController(controlController);
							base.DesignServices.RegisterWinComponent(controlController.WinControl);
						}
					}
					else
					{
						arrayList.Remove(controlController.TargetObject);
					}
					if (controlController != null)
					{
						WinControls.Add(controlController.WinControl);
					}
				}
				foreach (System.Windows.Forms.Control item in arrayList)
				{
					if (((IContextServices)base.Context).GetControllerByWinObject(item) is ControlController controlController2)
					{
						controlController2.Terminate();
						((IContextServices)base.Context).UnregisterController(controlController2);
					}
				}
				WinControl.ResumeLayout();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		internal void SetWebControlControls()
		{
			if (WebControls == null || WebControls.IsReadOnly || WinControls == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				ArrayList arrayList = new ArrayList(WebControls);
				WebControls.Clear();
				foreach (System.Windows.Forms.Control winControl in WinControls)
				{
					if (!(((IContextServices)base.Context).GetControllerByWinObject(winControl) is ControlController controlController))
					{
						continue;
					}
					if (base.DesignMode && !controlController.WebControl.HasTabIndex)
					{
						int num = 0;
						foreach (Gizmox.WebGUI.Forms.Control item in arrayList)
						{
							if (num <= item.TabIndex)
							{
								num = item.TabIndex + 1;
							}
						}
						controlController.WebControl.TabIndex = num;
					}
					WebControls.Add(controlController.WebControl);
					if (!arrayList.Contains(controlController.WebControl))
					{
						if (base.DesignMode)
						{
							controlController.SetWebControlDesignTimeValues();
							controlController.SetWinControlDesignTimeValues();
							base.DesignServices.RegisterWebComponent(controlController.WebControl);
						}
						if (GetControllerByWinObject(winControl.Parent) is ControlController controlController2)
						{
							controlController2.WebControl.Controls.Add(controlController.WebControl);
							if (base.DesignMode)
							{
								base.DesignServices.FireWebComponentChanged(controlController2.WebControl, "Controls", controlController2.WebControl.Controls, controlController2.WebControl.Controls);
							}
						}
					}
					else
					{
						arrayList.Remove(controlController.WebControl);
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}
	}
	public class ControlController : ComponentController
	{
		private ControlCollectionController mobjControlsController = null;

		public Gizmox.WebGUI.Forms.Control WebControl => base.SourceObject as Gizmox.WebGUI.Forms.Control;

		public System.Windows.Forms.Control WinControl => base.TargetObject as System.Windows.Forms.Control;

		public ControlController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			if (!(WebControl is ISealedComponent))
			{
				mobjControlsController = new ControlCollectionController(base.Context, objWebControl, WebControl.Controls, objWinControl, WinControl.Controls);
			}
		}

		public ControlController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			if (!(WebControl is ISealedComponent))
			{
				mobjControlsController = new ControlCollectionController(base.Context, objWebObject, WebControl.Controls, WinControl, WinControl.Controls);
			}
		}

		protected override void InitializeController()
		{
			if (!base.DesignInitialization)
			{
				SetWinControlSize();
				SetWinControlLocation();
				SetWinControlMaximumSize();
				SetWinControlMinimumSize();
			}
			base.InitializeController();
			SetWinControlText();
			SetWinControlDock();
			SetWinControlAnchor();
			if (!base.DesignInitialization)
			{
				try
				{
					SuspendNotifications();
					SetWinControlSize();
					SetWinControlLocation();
					SetWinControlMaximumSize();
					SetWinControlMinimumSize();
					SetWinControlPadding();
				}
				finally
				{
					ResumeNotifications();
				}
			}
			SetWinControlBackColor();
			SetWinControlForeColor();
			SetWinControlFont();
			SetWinControlEnabled();
			SetWinControlTabIndex();
			SetWinControlTabStop();
			SetWinControlContextMenu();
			SetWinControlBackgroundImage();
			SetWinControlBackgroundImageLayout();
			SetWinControlEnabled();
			SetWinControlVisible();
			SetWinControlBorderStyle();
			SetWinControlAutoSize();
			SetWinControlMargin();
			SetWinControlRightToLeft();
		}

		public override void InitializeNew()
		{
			base.InitializeNew();
			SetWinControlSize();
		}

		protected override void InitializedContained()
		{
			WinControl.SuspendLayout();
			if (mobjControlsController != null)
			{
				mobjControlsController.Initialize();
			}
			try
			{
				SuspendNotifications();
				WinControl.ResumeLayout();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjControlsController != null)
			{
				mobjControlsController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjControlsController != null)
			{
				mobjControlsController.Terminate();
			}
		}

		protected virtual void SetWinControlVisible()
		{
			if (!base.DesignMode)
			{
				WinControl.Visible = WebControl.Visible;
			}
		}

		protected virtual void SetWinControlMargin()
		{
			WinControl.Margin = new System.Windows.Forms.Padding(Convert.ToInt32((float)WebControl.Margin.Left * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Margin.Top * base.TargetVerticalScaleFactor), Convert.ToInt32((float)WebControl.Margin.Right * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Margin.Bottom * base.TargetVerticalScaleFactor));
		}

		protected virtual void SetWinControlPadding()
		{
			WinControl.Padding = new System.Windows.Forms.Padding(Convert.ToInt32((float)WebControl.Padding.Left * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Padding.Top * base.TargetVerticalScaleFactor), Convert.ToInt32((float)WebControl.Padding.Right * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Padding.Bottom * base.TargetVerticalScaleFactor));
		}

		protected virtual void SetWinControlDataBindings()
		{
			if (base.DesignMode)
			{
				try
				{
					SuspendNotifications();
					RefreshDesigner();
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		internal virtual void SetWebControlControls()
		{
			if (mobjControlsController != null)
			{
				mobjControlsController.SetWebControlControls();
			}
		}

		protected virtual void SetWebControlTabIndex()
		{
			((Gizmox.WebGUI.Forms.Control)base.SourceObject).TabIndex = ((System.Windows.Forms.Control)base.TargetObject).TabIndex;
		}

		protected virtual void SetWinControlControls()
		{
			if (mobjControlsController != null)
			{
				mobjControlsController.SetWinControlControls();
			}
		}

		protected virtual void SetWinControlBorderStyle()
		{
		}

		protected virtual void SetWebControlBorderStyle()
		{
		}

		protected virtual void SetWinControlLayoutInfo()
		{
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel = WinControl.Parent as System.Windows.Forms.TableLayoutPanel;
			Gizmox.WebGUI.Forms.TableLayoutPanel tableLayoutPanel2 = WebControl.Parent as Gizmox.WebGUI.Forms.TableLayoutPanel;
			if (tableLayoutPanel != null && tableLayoutPanel2 != null)
			{
				tableLayoutPanel.SetRow(WinControl, tableLayoutPanel2.GetRow(WebControl));
				tableLayoutPanel.SetColumn(WinControl, tableLayoutPanel2.GetColumn(WebControl));
				tableLayoutPanel.SetRowSpan(WinControl, tableLayoutPanel2.GetRowSpan(WebControl));
				tableLayoutPanel.SetColumnSpan(WinControl, tableLayoutPanel2.GetColumnSpan(WebControl));
			}
		}

		protected virtual void SetWinControlEnabled()
		{
			WinControl.Enabled = WebControl.Enabled;
		}

		protected virtual void SetWinControlBackgroundImage()
		{
			if (WebControl.BackgroundImage != null)
			{
				Image winImageFromResourceHandle = GetWinImageFromResourceHandle(WebControl.BackgroundImage);
				if (winImageFromResourceHandle != null)
				{
					WinControl.BackgroundImage = winImageFromResourceHandle;
				}
			}
			else if (WinControl.BackgroundImage != null)
			{
				WinControl.BackgroundImage = null;
			}
		}

		protected virtual void SetWinControlBackgroundImageLayout()
		{
			WinControl.BackgroundImageLayout = (System.Windows.Forms.ImageLayout)GetConvertedEnum(typeof(System.Windows.Forms.ImageLayout), WebControl.BackgroundImageLayout);
		}

		protected virtual void SetWinControlContextMenu()
		{
			if (base.ContextMenuController != null)
			{
				WinControl.ContextMenu = base.ContextMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinControlTabStop()
		{
			WinControl.TabStop = WebControl.TabStop;
		}

		protected virtual void SetWinControlTabIndex()
		{
			if (WebControl.TabIndex != -1)
			{
				WinControl.TabIndex = WebControl.TabIndex;
			}
		}

		protected virtual void SetWinControlFont()
		{
			if (WebControl.Font == null)
			{
				WinControl.Font = null;
			}
			else
			{
				WinControl.Font = new Font(WebControl.Font.FontFamily, WebControl.Font.Size * base.TargetVerticalScaleFactor, WebControl.Font.Style, WebControl.Font.Unit);
			}
		}

		protected virtual void SetWinControlForeColor()
		{
			WinControl.ForeColor = WebControl.ForeColor;
		}

		protected virtual void SetWinControlBackColor()
		{
			try
			{
				WinControl.BackColor = WebControl.BackColor;
			}
			catch
			{
			}
		}

		protected virtual void SetWinControlLocation()
		{
			SetWinProperty("Location", new Point(Convert.ToInt32((float)WebControl.Location.X * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Location.Y * base.TargetVerticalScaleFactor)));
		}

		protected virtual void SetWinControlSize()
		{
			SetWinProperty("Size", new Size(Convert.ToInt32((float)WebControl.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebControl.Size.Height * base.TargetVerticalScaleFactor)));
		}

		protected virtual void SetWinControlMaximumSize()
		{
			WinControl.MaximumSize = WebControl.MaximumSize;
		}

		protected virtual void SetWinControlMinimumSize()
		{
			WinControl.MinimumSize = WebControl.MinimumSize;
		}

		protected virtual void SetWinControlAnchor()
		{
			if (WebControl.Dock == Gizmox.WebGUI.Forms.DockStyle.None)
			{
				WinControl.Anchor = (System.Windows.Forms.AnchorStyles)GetConvertedEnum(typeof(System.Windows.Forms.AnchorStyles), WebControl.Anchor);
			}
		}

		protected virtual void SetWinControlDock()
		{
			WinControl.Dock = (System.Windows.Forms.DockStyle)GetConvertedEnum(typeof(System.Windows.Forms.DockStyle), WebControl.Dock);
		}

		protected virtual void SetWinControlText()
		{
			WinControl.Text = WebControl.Text;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Controls":
				SetWebControlControls();
				if (base.DesignMode)
				{
					base.DesignServices.FireWebComponentChanged(WebControl, "Controls", WebControl.Controls, WebControl.Controls);
				}
				break;
			case "TabIndex":
				SetWebControlTabIndex();
				if (base.DesignMode)
				{
					base.DesignServices.FireWebComponentChanged(WebControl, "TabIndex", WebControl.TabIndex, WebControl.TabIndex);
				}
				break;
			case "Width":
			case "Height":
			case "Size":
				if (!base.DesignMode || base.DesignSuspended || base.IsNotificationSuspened)
				{
					break;
				}
				try
				{
					SuspendNotifications();
					base.DesignServices.FireWebComponentChanging(base.WebComponent, "Size");
					object obj = WebControl.Size;
					SetWebControlSize();
					object obj2 = WebControl.Size;
					if (!object.Equals(obj, obj2))
					{
						base.DesignServices.FireWebComponentChanged(base.WebComponent, "Size", obj, obj2);
					}
					break;
				}
				finally
				{
					ResumeNotifications();
				}
			case "Left":
			case "Top":
			case "Location":
				if (base.DesignMode && !base.DesignSuspended && !base.IsNotificationSuspened)
				{
					SetWebControlLocation();
				}
				break;
			case "Dock":
				if (base.DesignMode && !base.DesignSuspended && !base.IsNotificationSuspened)
				{
					try
					{
						SuspendNotifications();
						base.DesignServices.FireWebComponentChanging(base.WebComponent, "Dock");
						object objOldValue = WebControl.Dock;
						SetWebControlDock();
						object objNewValue = WebControl.Dock;
						base.DesignServices.FireWebComponentChanged(base.WebComponent, "Dock", objOldValue, objNewValue);
						break;
					}
					finally
					{
						ResumeNotifications();
					}
				}
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWinControlAutoSize();
				break;
			case "Location":
				SetWinControlLocation();
				break;
			case "Size":
				SetWinControlSize();
				break;
			case "MinimumSize":
				SetWinControlMinimumSize();
				break;
			case "MaximumSize":
				SetWinControlMaximumSize();
				break;
			case "Dock":
				SetWinControlDock();
				break;
			case "Text":
				SetWinControlText();
				break;
			case "Anchor":
				SetWinControlAnchor();
				break;
			case "Visible":
				SetWinControlVisible();
				break;
			case "Margin":
				SetWinControlMargin();
				break;
			case "Padding":
				SetWinControlPadding();
				break;
			case "Enabled":
				SetWinControlEnabled();
				break;
			case "ForeColor":
				SetWinControlForeColor();
				break;
			case "Font":
				SetWinControlFont();
				break;
			case "BackColor":
				SetWinControlBackColor();
				break;
			case "Controls":
				SetWinControlControls();
				break;
			case "BorderStyle":
				SetWinControlBorderStyle();
				break;
			case "DataBindings":
				SetWinControlDataBindings();
				break;
			case "BackgroundImage":
				SetWinControlBackgroundImage();
				break;
			case "BackgroundImageLayout":
				SetWinControlBackgroundImageLayout();
				break;
			case "Row":
			case "Column":
			case "RowSpan":
			case "ColumnSpan":
				SetWinControlLayoutInfo();
				break;
			case "TabIndex":
				SetWinControlTabIndex();
				break;
			case "Parent":
				SetWinControlParent();
				break;
			case "RightToLeft":
				SetWinControlRightToLeft();
				break;
			}
		}

		private void SetWinControlRightToLeft()
		{
			WinControl.RightToLeft = (System.Windows.Forms.RightToLeft)WebControl.RightToLeft;
		}

		private void SetWinControlParent()
		{
			System.Windows.Forms.Control parent = WinControl.Parent;
			if (GetControllerByWebObject(WebControl.Parent) is ControlController controlController)
			{
				SetWinProperty("Parent", controlController.WinControl);
				base.DesignServices.FireWebComponentChanged(controlController.WebControl, "Controls", controlController.WebControl.Controls, controlController.WebControl.Controls);
				if (GetControllerByWinObject(parent) is ControlController { WebControl: not null } controlController2)
				{
					base.DesignServices.FireWebComponentChanged(controlController2.WebControl, "Controls", controlController2.WebControl.Controls, controlController2.WebControl.Controls);
				}
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinControl.Click += WinControl_Click;
			if (base.WebComponent is IObservableLayoutItem observableLayoutItem)
			{
				observableLayoutItem.ObservableResumeLayout += WebComponent_ObservableResumeLayout;
				observableLayoutItem.ObservableSuspendLayout += WebComponent_ObservableSuspendLayout;
			}
		}

		private void WinControl_Click(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("Click");
			obj.Fire();
		}

		private void WebComponent_ObservableResumeLayout(object objSender, ObservableResumeLayoutArgs objArgs)
		{
			WinControl.ResumeLayout(objArgs.PerformLayout);
		}

		private void WebComponent_ObservableSuspendLayout(object sender, EventArgs e)
		{
			WinControl.SuspendLayout();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinControl.Click -= WinControl_Click;
			if (base.WebComponent is IObservableLayoutItem observableLayoutItem)
			{
				observableLayoutItem.ObservableResumeLayout -= WebComponent_ObservableResumeLayout;
				observableLayoutItem.ObservableSuspendLayout -= WebComponent_ObservableSuspendLayout;
			}
		}

		private void SetWebControlAutoSize()
		{
			if (WebControl.AutoSize != WinControl.AutoSize)
			{
				SetWebProperty("AutoSize", WinControl.AutoSize);
			}
		}

		protected virtual void SetWinControlAutoSize()
		{
			if (WebControl.AutoSize != WinControl.AutoSize)
			{
				SetWinProperty("AutoSize", WebControl.AutoSize);
			}
		}

		internal void SetWebControlDesignTimeValues()
		{
			SetWebControlLocation();
			SetWebControlSize();
			SetWebControlText();
			SetWebControlAutoSize();
		}

		internal void SetWinControlDesignTimeValues()
		{
			SetWinControlTabIndex();
		}

		protected virtual void SetWebControlText()
		{
			WebControl.Text = WinControl.Text;
		}

		protected virtual void SetWebControlSize()
		{
			if (WebControl.Size != WinControl.Size)
			{
				try
				{
					SuspendNotifications();
					WebControl.Size = new Size(Convert.ToInt32((float)WinControl.Size.Width / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WinControl.Size.Height / base.TargetVerticalScaleFactor));
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		protected virtual void SetWebControlLocation()
		{
			if (WinControl.Location != WebControl.Location)
			{
				try
				{
					SuspendNotifications();
					base.DesignServices.FireWebComponentChanging(base.WebComponent, "Location");
					object objOldValue = WebControl.Location;
					WebControl.Location = new Point(Convert.ToInt32((float)WinControl.Location.X / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WinControl.Location.Y / base.TargetVerticalScaleFactor));
					object objNewValue = WebControl.Location;
					base.DesignServices.FireWebComponentChanged(base.WebComponent, "Location", objOldValue, objNewValue);
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		private void SetWebControlAnchor()
		{
			WebControl.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.AnchorStyles), WinControl.Anchor);
		}

		private void SetWebControlDock()
		{
			WebControl.Dock = (Gizmox.WebGUI.Forms.DockStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.DockStyle), WinControl.Dock);
			if (WinControl.Dock == System.Windows.Forms.DockStyle.None)
			{
				SetWebControlAnchor();
			}
		}

		private void FireTableLayoutPanelControlPositionsChanged()
		{
			if (base.DesignInitialization || base.IsNotificationSuspened || !(WinControl.Parent is System.Windows.Forms.TableLayoutPanel) || WinControl.Parent == null)
			{
				return;
			}
			ObjectController controllerByWinObject = GetControllerByWinObject(WinControl.Parent);
			if (controllerByWinObject != null)
			{
				try
				{
					SuspendNotifications();
					controllerByWinObject.FireWinPropertyChanged(new ObservableItemPropertyChangedArgs("ControlPositions", base.TargetObject));
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		protected System.Windows.Forms.Control GetWinAncestorByWebType(Type objAncestorWebType)
		{
			System.Windows.Forms.Control control = WinControl;
			while (control != null && (!(GetControllerByWinObject(control) is ControlController { WebControl: not null } controlController) || !(controlController.WebControl.GetType() == objAncestorWebType)))
			{
				control = control.Parent;
			}
			return control;
		}
	}
	public abstract class ComponentCollectionController : ObjectCollectionController
	{
		private IList mobjWebObjects = null;

		private IList mobjWinObjects = null;

		private IContext mobjContext = null;

		private ArrayList mobjControllers = null;

		public ComponentCollectionController(IContext objContext, object objWebObject, IList objWebObjects, object objWinObject, IList objWinObjects)
			: base(objContext, objWebObject, objWebObjects, objWinObject, objWinObjects)
		{
		}

		public override void Terminate()
		{
			base.Terminate();
			if (!base.DesignMode)
			{
				return;
			}
			ArrayList arrayList = new ArrayList(base.WebObjects);
			if (arrayList != null)
			{
				foreach (object item in arrayList)
				{
					if (item is IComponent objWebComponent)
					{
						base.DesignServices.UnregisterWebComponent(objWebComponent);
					}
					GetControllerByWebObject(item)?.Terminate();
				}
			}
			ArrayList arrayList2 = new ArrayList(base.WinObjects);
			if (arrayList2 == null)
			{
				return;
			}
			foreach (object item2 in arrayList2)
			{
				if (item2 is IComponent objWinComponent)
				{
					base.DesignServices.UnregisterWinComponent(objWinComponent);
				}
			}
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objSoureceObject)
		{
			ObjectController objectController = null;
			if (objSoureceObject != null)
			{
				Type type = objSoureceObject.GetType();
				objectController = ObjectController.CreateTypeController(base.Context, type, objSoureceObject);
			}
			if (objectController == null)
			{
				return base.CreateObjectControlerBySourceObject(objSoureceObject);
			}
			return objectController;
		}
	}
	public class DomainUpDownController : UpDownBaseController
	{
		public Gizmox.WebGUI.Forms.DomainUpDown WebDomainUpDown => base.SourceObject as Gizmox.WebGUI.Forms.DomainUpDown;

		public System.Windows.Forms.DomainUpDown WinDomainUpDown => base.TargetObject as System.Windows.Forms.DomainUpDown;

		public DomainUpDownController(IContext objContext, object objWebUpDown)
			: base(objContext, objWebUpDown)
		{
		}

		public DomainUpDownController(IContext objContext, object objWebUpDown, object objWinUpDown)
			: base(objContext, objWebUpDown, objWinUpDown)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinDomainUpDownSorted();
			SetWinDomainUpDownWrap();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Sorted"))
			{
				if (property == "Wrap")
				{
					SetWinDomainUpDownWrap();
				}
			}
			else
			{
				SetWinDomainUpDownSorted();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientDomainUpDown();
		}

		protected virtual void SetWinDomainUpDownSorted()
		{
			WinDomainUpDown.Sorted = WebDomainUpDown.Sorted;
		}

		protected virtual void SetWinDomainUpDownWrap()
		{
			WinDomainUpDown.Wrap = WebDomainUpDown.Wrap;
		}
	}
	public class ListControlController : ControlController
	{
		public Gizmox.WebGUI.Forms.ListControl WebListControl => base.SourceObject as Gizmox.WebGUI.Forms.ListControl;

		public System.Windows.Forms.ListControl WinListControl => base.TargetObject as System.Windows.Forms.ListControl;

		public ListControlController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public ListControlController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinListControlFormattingEnabled();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "FormattingEnabled")
			{
				SetWinListControlFormattingEnabled();
			}
		}

		private void SetWinListControlFormattingEnabled()
		{
			WinListControl.FormattingEnabled = WebListControl.FormattingEnabled;
		}
	}
	public class ListViewGroupCollectionController : ObjectCollectionController
	{
		public Gizmox.WebGUI.Forms.ListViewGroupCollection WebListViewGroups => base.WebObjects as Gizmox.WebGUI.Forms.ListViewGroupCollection;

		public Gizmox.WebGUI.Forms.ListView WebListView => base.SourceObject as Gizmox.WebGUI.Forms.ListView;

		public System.Windows.Forms.ListViewGroupCollection WinListViewGroups => base.WinObjects as System.Windows.Forms.ListViewGroupCollection;

		public System.Windows.Forms.ListView WinListView => base.TargetObject as System.Windows.Forms.ListView;

		public ListViewGroupCollectionController(IContext objContext, object objWebListView, IList objWebGroups, object objWinListView, IList objWinGroups)
			: base(objContext, objWebListView, objWebGroups, objWinListView, objWinGroups)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new ListViewGroupController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListViewGroup();
		}

		protected override void InitializeWinObjects()
		{
			base.InitializeWinObjects();
		}
	}
	public class ListViewGroupController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ListViewGroup WebListViewGroup => base.SourceObject as Gizmox.WebGUI.Forms.ListViewGroup;

		public System.Windows.Forms.ListViewGroup WinListViewGroup => base.TargetObject as System.Windows.Forms.ListViewGroup;

		public ListViewGroupController(IContext objContext, object objWebListViewGroup, object objWinListViewGroup)
			: base(objContext, objWebListViewGroup, objWinListViewGroup)
		{
		}

		public ListViewGroupController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinListViewGroupHeader();
			SetWinHeaderAlignment();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinListViewGroupHeader();
			SetWinHeaderAlignment();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Header"))
			{
				if (property == "HeaderAlignment")
				{
					SetWinHeaderAlignment();
				}
			}
			else
			{
				SetWinListViewGroupHeader();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Header")
			{
				SetWebListViewGroupHeader();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebListViewGroupHeader();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListViewGroup();
		}

		protected virtual void SetWinListViewGroupHeader()
		{
			WinListViewGroup.Header = WebListViewGroup.Header;
		}

		protected virtual void SetWebListViewGroupHeader()
		{
			WebListViewGroup.Header = WinListViewGroup.Header;
		}

		protected virtual void SetWinHeaderAlignment()
		{
			WinListViewGroup.HeaderAlignment = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebListViewGroup.HeaderAlignment);
		}
	}
	public class ListViewItemController : ComponentController
	{
		private ContextMenuController mobjContextMenuController = null;

		private ListViewSubItemCollectionController mobjListViewSubItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ListViewItem WebListViewItem => base.SourceObject as Gizmox.WebGUI.Forms.ListViewItem;

		public ClientListViewItem WinListViewItem => base.TargetObject as ClientListViewItem;

		protected new ContextMenuController ContextMenuController
		{
			get
			{
				if (mobjContextMenuController == null && base.WebComponent != null && base.WebComponent.ContextMenu != null)
				{
					mobjContextMenuController = GetControllerByWebObject(base.WebComponent.ContextMenu) as ContextMenuController;
					if (mobjContextMenuController == null)
					{
						System.Windows.Forms.ContextMenu objWinControl = new System.Windows.Forms.ContextMenu();
						mobjContextMenuController = new ContextMenuController(base.Context, base.WebComponent.ContextMenu, objWinControl);
						mobjContextMenuController.Initialize();
						RegisterController(mobjContextMenuController);
					}
				}
				return mobjContextMenuController;
			}
		}

		public ListViewItemController(IContext objContext, object objWebListViewItem, object objWinListViewItem)
			: base(objContext, objWebListViewItem, objWinListViewItem)
		{
			mobjListViewSubItemCollectionController = new ListViewSubItemCollectionController(objContext, WebListViewItem, WebListViewItem.SubItems, WinListViewItem, WinListViewItem.SubItems);
		}

		public ListViewItemController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjListViewSubItemCollectionController = new ListViewSubItemCollectionController(objContext, WebListViewItem, WebListViewItem.SubItems, WinListViewItem, WinListViewItem.SubItems);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinListViewItemText();
			SetWinListViewItemForeColor();
			SetWinListViewItemBackColor();
			SetWinListViewItemSubItems();
			SetWinListViewItemContextMenu();
			SetWinListViewItemGroup();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinListViewItemText();
			SetWinListViewItemForeColor();
			SetWinListViewItemBackColor();
			SetWinListViewItemImageIndex();
			SetWinListViewItemImageKey();
			SetWinListViewItemContextMenu();
			SetWinListViewItemGroup();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinListViewItemText();
			SetWinListViewItemForeColor();
			SetWinListViewItemBackColor();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinListViewItemText();
				break;
			case "SubItems":
				SetWinListViewItemSubItems();
				break;
			case "ImageKey":
				SetWinListViewItemImageKey();
				break;
			case "ImageIndex":
				SetWinListViewItemImageIndex();
				break;
			case "Group":
				SetWinListViewItemGroup();
				break;
			case "BackColor":
				SetWinListViewItemBackColor();
				break;
			case "ForeColor":
				SetWinListViewItemForeColor();
				break;
			}
		}

		private void SetWinListViewItemImageIndex()
		{
			if (WebListViewItem.ImageIndex != -1)
			{
				if (WinListViewItem.ListView != null)
				{
					if (WinListViewItem.ListView.SmallImageList == null)
					{
						WinListViewItem.ListView.SmallImageList = new System.Windows.Forms.ImageList();
					}
					WinListViewItem.ImageIndex = GetWinImageIndex(WinListViewItem.ListView.SmallImageList, WebListViewItem.SmallImage);
				}
			}
			else if (WinListViewItem.ImageIndex != -1)
			{
				WinListViewItem.ImageIndex = -1;
			}
		}

		private void SetWinListViewItemImageKey()
		{
			if (WebListViewItem.ImageKey != string.Empty)
			{
				if (WinListViewItem.ListView != null)
				{
					if (WinListViewItem.ListView.SmallImageList == null)
					{
						WinListViewItem.ListView.SmallImageList = new System.Windows.Forms.ImageList();
					}
					if (GetWinImageIndex(WinListViewItem.ListView.SmallImageList, WebListViewItem.SmallImage, WebListViewItem.ImageKey) > -1)
					{
						WinListViewItem.ImageKey = WebListViewItem.ImageKey;
					}
					else if (WinListViewItem.ImageKey != string.Empty)
					{
						WinListViewItem.ImageKey = string.Empty;
					}
				}
			}
			else if (WinListViewItem.ImageKey != string.Empty)
			{
				WinListViewItem.ImageKey = string.Empty;
			}
		}

		private void SetWebListViewItemImageIndex()
		{
			WebListViewItem.ImageIndex = WinListViewItem.ImageIndex;
		}

		private void SetWebListViewItemImageKey()
		{
			WebListViewItem.ImageKey = WinListViewItem.ImageKey;
		}

		private void SetWinListViewItemSubItems()
		{
			mobjListViewSubItemCollectionController.SetWinObjectObjects();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWebListViewItemText();
				break;
			case "SubItems":
				SetWebListViewItemSubItems();
				break;
			case "ImageKey":
				SetWebListViewItemImageKey();
				break;
			case "ImageIndex":
				SetWebListViewItemImageIndex();
				break;
			}
		}

		private void SetWebListViewItemSubItems()
		{
			mobjListViewSubItemCollectionController.SetWebObjectObjects();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebListViewItemText();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjListViewSubItemCollectionController.Initialize();
		}

		protected virtual void SetWinListViewItemContextMenu()
		{
			if (ContextMenuController != null)
			{
				WinListViewItem.ContextMenu = ContextMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinListViewItemGroup()
		{
			if (WebListViewItem.Group != null)
			{
				ObjectController controllerByWebObject = GetControllerByWebObject(WebListViewItem.Group);
				if (controllerByWebObject != null)
				{
					WinListViewItem.Group = controllerByWebObject.TargetObject as System.Windows.Forms.ListViewGroup;
				}
			}
			else
			{
				WinListViewItem.Group = null;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientListViewItem();
		}

		protected virtual void SetWinListViewItemText()
		{
			WinListViewItem.Text = WebListViewItem.Text;
		}

		protected virtual void SetWinListViewItemBackColor()
		{
			WinListViewItem.BackColor = WebListViewItem.BackColor;
		}

		protected virtual void SetWinListViewItemForeColor()
		{
			WinListViewItem.ForeColor = WebListViewItem.ForeColor;
		}

		protected virtual void SetWebListViewItemText()
		{
			WebListViewItem.Text = WinListViewItem.Text;
		}
	}
	public class ListViewSubItemCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItemCollection WebListViewSubItemCollection => base.WebObjects as Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItemCollection;

		public Gizmox.WebGUI.Forms.ListView WebListView => base.SourceObject as Gizmox.WebGUI.Forms.ListView;

		public System.Windows.Forms.ListViewItem.ListViewSubItemCollection WinListViewSubItemCollection => base.WinObjects as System.Windows.Forms.ListViewItem.ListViewSubItemCollection;

		public System.Windows.Forms.ListView WinListView => base.TargetObject as System.Windows.Forms.ListView;

		public ListViewSubItemCollectionController(IContext objContext, object objWebListViewItem, IList objWebSubItems, object objWinListViewItem, IList objWinSubItems)
			: base(objContext, objWebListViewItem, objWebSubItems, objWinListViewItem, objWinSubItems)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new ListViewSubItemController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListViewItem.ListViewSubItem();
		}
	}
	public class MaskedTextBoxController : TextBoxBaseController
	{
		public Gizmox.WebGUI.Forms.MaskedTextBox WebMaskedTextBox => base.SourceObject as Gizmox.WebGUI.Forms.MaskedTextBox;

		public System.Windows.Forms.MaskedTextBox WinMaskedTextBox => base.TargetObject as System.Windows.Forms.MaskedTextBox;

		public MaskedTextBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public MaskedTextBoxController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinMaskedTextBoxMask();
			SetWinMaskedTextBoxTextMaskFormat();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebControlText();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Mask":
				SetWinMaskedTextBoxMask();
				break;
			case "TextMaskFormat":
				SetWinMaskedTextBoxTextMaskFormat();
				break;
			case "PasswordChar":
				SetWinMaskedTextBoxPasswordChar();
				break;
			}
		}

		protected void SetWinMaskedTextBoxTextMaskFormat()
		{
			WinMaskedTextBox.TextMaskFormat = (System.Windows.Forms.MaskFormat)GetConvertedEnum(typeof(System.Windows.Forms.MaskFormat), WebMaskedTextBox.TextMaskFormat, WinMaskedTextBox.TextMaskFormat);
		}

		protected void SetWinMaskedTextBoxMask()
		{
			WinMaskedTextBox.Mask = WebMaskedTextBox.Mask;
		}

		private void SetWinMaskedTextBoxPasswordChar()
		{
			WinMaskedTextBox.PasswordChar = WebMaskedTextBox.PasswordChar;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.MaskedTextBox();
		}
	}
	public class MenuController : ComponentController
	{
		public MenuController(IContext objContext, object objWebComponent, object objWinComponent)
			: base(objContext, objWebComponent, objWinComponent)
		{
		}

		public MenuController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}
	}
	public class DataGidViewButtonColumnController : DataGidViewColumnController
	{
		public DataGidViewButtonColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewButtonColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewButtonColumn();
		}

		protected override void SetWinColumnWidth()
		{
			base.SetWinColumnWidth();
		}
	}
	public class DataGidViewCheckBoxColumnController : DataGidViewColumnController
	{
		public DataGidViewCheckBoxColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewCheckBoxColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewCheckBoxColumn();
		}

		protected override void SetWinColumnWidth()
		{
			base.SetWinColumnWidth();
		}
	}
	public class DataGidViewColumnCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.DataGridViewColumnCollection WebDataGridViewColumnCollection => base.WebObjects as Gizmox.WebGUI.Forms.DataGridViewColumnCollection;

		public Gizmox.WebGUI.Forms.DataGridView WebDataGridView => base.SourceObject as Gizmox.WebGUI.Forms.DataGridView;

		public System.Windows.Forms.DataGridViewColumnCollection WinDataGridViewColumnCollection => base.WinObjects as System.Windows.Forms.DataGridViewColumnCollection;

		public System.Windows.Forms.DataGridView WinDataGridView => base.TargetObject as System.Windows.Forms.DataGridView;

		public DataGidViewColumnCollectionController(IContext objContext, object objWebDataGridView, IList objWebColumns, object objWinDataGridView, IList objWinColumns)
			: base(objContext, objWebDataGridView, objWebColumns, objWinDataGridView, objWinColumns)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewColumn();
		}

		protected override void InitializeWinObjects()
		{
			base.InitializeWinObjects();
		}
	}
	public class DataGidViewColumnController : ComponentController
	{
		public Gizmox.WebGUI.Forms.DataGridViewColumn WebColumn => base.SourceObject as Gizmox.WebGUI.Forms.DataGridViewColumn;

		public System.Windows.Forms.DataGridViewColumn WinColumn => base.TargetObject as System.Windows.Forms.DataGridViewColumn;

		public DataGidViewColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebColumnHeaderText();
			SetWebColumnName();
			SetWebColumnWidth();
			SetWebColumnDataPropertyName();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinColumnDataPropertyName();
			SetWinColumnDefaultCellStyle();
			SetWinColumnHeaderCellValue();
			SetWinColumnWidth();
			SetWinColumnName();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinColumnDataPropertyName();
			SetWinColumnDefaultCellStyle();
			SetWinColumnHeaderCellValue();
			SetWinColumnWidth();
			SetWinColumnName();
			SetWinColumnAutoSizeMode();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "HeaderText":
				SetWebColumnHeaderText();
				break;
			case "Name":
				SetWebColumnName();
				break;
			case "Width":
				SetWebColumnWidth();
				break;
			case "DataPropertyName":
				SetWebColumnDataPropertyName();
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DefaultCellStyle":
				SetWinColumnDefaultCellStyle();
				break;
			case "HeaderText":
				SetWinColumnHeaderCellValue();
				break;
			case "Name":
				SetWinColumnName();
				break;
			case "Width":
				SetWinColumnWidth();
				break;
			case "DataPropertyName":
				SetWinColumnDataPropertyName();
				break;
			case "AutoSizeMode":
				SetWinColumnAutoSizeMode();
				break;
			}
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "HeaderText"))
			{
				if (property == "Width")
				{
					SetWinColumnWidth();
				}
			}
			else
			{
				SetWinColumnHeaderCellValue();
			}
		}

		protected void SetWinColumnDefaultCellStyle()
		{
			if (WebColumn != null && WebColumn.DefaultCellStyle != null && WinColumn != null)
			{
				if (WinColumn.DefaultCellStyle == null)
				{
					WinColumn.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				WinColumn.DefaultCellStyle.Alignment = (System.Windows.Forms.DataGridViewContentAlignment)Enum.Parse(typeof(System.Windows.Forms.DataGridViewContentAlignment), WebColumn.DefaultCellStyle.Alignment.ToString());
				WinColumn.DefaultCellStyle.BackColor = WebColumn.DefaultCellStyle.BackColor;
				WinColumn.DefaultCellStyle.DataSourceNullValue = WebColumn.DefaultCellStyle.DataSourceNullValue;
				if (WebColumn.DefaultCellStyle.Font == null)
				{
					WinColumn.DefaultCellStyle.Font = null;
				}
				else
				{
					WinColumn.DefaultCellStyle.Font = new Font(WebColumn.DefaultCellStyle.Font.FontFamily, WebColumn.DefaultCellStyle.Font.Size * base.TargetVerticalScaleFactor);
				}
				WinColumn.DefaultCellStyle.ForeColor = WebColumn.DefaultCellStyle.ForeColor;
				WinColumn.DefaultCellStyle.Format = WebColumn.DefaultCellStyle.Format;
				WinColumn.DefaultCellStyle.FormatProvider = WebColumn.DefaultCellStyle.FormatProvider;
				WinColumn.DefaultCellStyle.NullValue = WebColumn.DefaultCellStyle.NullValue;
				WinColumn.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(WebColumn.DefaultCellStyle.Padding.Left, WebColumn.DefaultCellStyle.Padding.Top, WebColumn.DefaultCellStyle.Padding.Right, WebColumn.DefaultCellStyle.Padding.Bottom);
				WinColumn.DefaultCellStyle.SelectionBackColor = WebColumn.DefaultCellStyle.SelectionBackColor;
				WinColumn.DefaultCellStyle.SelectionForeColor = WebColumn.DefaultCellStyle.SelectionForeColor;
				WinColumn.DefaultCellStyle.Tag = WebColumn.DefaultCellStyle.Tag;
				WinColumn.DefaultCellStyle.WrapMode = (System.Windows.Forms.DataGridViewTriState)Enum.Parse(typeof(System.Windows.Forms.DataGridViewTriState), WebColumn.DefaultCellStyle.WrapMode.ToString());
			}
		}

		protected virtual void SetWinColumnDataPropertyName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.DataPropertyName = WebColumn.DataPropertyName;
			}
		}

		private void SetWinColumnAutoSizeMode()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.AutoSizeMode = (System.Windows.Forms.DataGridViewAutoSizeColumnMode)GetConvertedEnum(typeof(System.Windows.Forms.DataGridViewAutoSizeColumnMode), WebColumn.AutoSizeMode, WinColumn.AutoSizeMode);
			}
		}

		protected virtual void SetWinColumnName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.Name = WebColumn.Name;
			}
		}

		protected virtual void SetWinColumnHeaderCellValue()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.HeaderCell.Value = WebColumn.HeaderCell.Value;
			}
		}

		protected virtual void SetWebColumnDataPropertyName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.DataPropertyName = WinColumn.DataPropertyName;
			}
		}

		protected virtual void SetWebColumnWidth()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.Width = Convert.ToInt32((float)WinColumn.Width / base.TargetHorizontalScaleFactor);
			}
		}

		protected virtual void SetWebColumnName()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.Name = WinColumn.Name;
			}
		}

		protected virtual void SetWebColumnHeaderText()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WebColumn.HeaderText = WinColumn.HeaderText;
			}
		}

		protected virtual void SetWinColumnWidth()
		{
			if (WebColumn != null && WinColumn != null)
			{
				WinColumn.Width = Convert.ToInt32((float)WebColumn.Width * base.TargetHorizontalScaleFactor);
			}
		}
	}
	public class DataGidViewComboBoxColumnController : DataGidViewColumnController
	{
		public Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn WebDataGridViewComboBoxColumn => base.SourceObject as Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn;

		public System.Windows.Forms.DataGridViewComboBoxColumn WinDataGridViewComboBoxColumn => base.TargetObject as System.Windows.Forms.DataGridViewComboBoxColumn;

		public DataGidViewComboBoxColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewComboBoxColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinDataGridViewComboBoxColumnDataSource();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewComboBoxColumn();
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DataSource")
			{
				SetWinDataGridViewComboBoxColumnDataSource();
			}
		}

		protected virtual void SetWinDataGridViewComboBoxColumnDataSource()
		{
			bool flag = true;
			object dataSource = WebDataGridViewComboBoxColumn.DataSource;
			object obj = dataSource;
			if (dataSource != null && dataSource is Gizmox.WebGUI.Forms.BindingSource)
			{
				ObjectController controllerByWebObject = GetControllerByWebObject(dataSource);
				if (controllerByWebObject != null)
				{
					obj = controllerByWebObject.TargetObject;
				}
				else
				{
					flag = false;
				}
			}
			if (flag && WinDataGridViewComboBoxColumn.DataSource != obj)
			{
				WinDataGridViewComboBoxColumn.DataSource = obj;
				RefreshDesigner();
			}
		}
	}
	public class DataGidViewImageColumnController : DataGidViewColumnController
	{
		public DataGidViewImageColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewImageColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewImageColumn();
		}

		protected override void SetWinColumnWidth()
		{
			base.SetWinColumnWidth();
		}
	}
	public class DataGidViewLinkColumnController : DataGidViewColumnController
	{
		public DataGidViewLinkColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewLinkColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinColumnActiveLinkColor();
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "ActiveLinkColor")
			{
				SetWinColumnActiveLinkColor();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewLinkColumn();
		}

		protected virtual void SetWinColumnActiveLinkColor()
		{
			((System.Windows.Forms.DataGridViewLinkColumn)base.WinColumn).ActiveLinkColor = ((Gizmox.WebGUI.Forms.DataGridViewLinkColumn)base.WebColumn).ActiveLinkColor;
		}

		protected override void SetWinColumnWidth()
		{
			base.SetWinColumnWidth();
		}
	}
	public class DataGidViewTextBoxColumnController : DataGidViewColumnController
	{
		public DataGidViewTextBoxColumnController(IContext objContext, object objWebColumn, object objWinColumn)
			: base(objContext, objWebColumn, objWinColumn)
		{
		}

		public DataGidViewTextBoxColumnController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DataGridViewTextBoxColumn();
		}

		protected override void SetWinColumnWidth()
		{
			base.SetWinColumnWidth();
		}
	}
	public class MenuStripController : ToolStripController
	{
		protected override bool UseVsMenuDeisgner => false;

		public MenuStripController(IContext objContext, object objWebMenuStrip, object objWinMenuStrip)
			: base(objContext, objWebMenuStrip, objWinMenuStrip)
		{
		}

		public MenuStripController(IContext objContext, object objWebMenuStrip)
			: base(objContext, objWebMenuStrip)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.MenuStrip();
		}
	}
	public class NavigationTabsController : TabControlController
	{
		public NavigationTabsController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public NavigationTabsController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			base.WinTabControl.ControlAdded += WinTabControl_ControlAdded;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			base.WinTabControl.ControlAdded -= WinTabControl_ControlAdded;
		}

		private void WinTabControl_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			if (e.Control == null || base.WinTabControl == null || base.WebTabControl == null)
			{
				return;
			}
			bool flag = false;
			StackTrace stackTrace = new StackTrace();
			if (stackTrace != null)
			{
				for (int i = 0; i < stackTrace.FrameCount; i++)
				{
					MethodBase method = stackTrace.GetFrame(i).GetMethod();
					if (method != null)
					{
						string name = method.Name;
						string fullName = method.DeclaringType.FullName;
						if (name == "InitializeNewComponent" && fullName == "System.Windows.Forms.Design.TabControlDesigner")
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				base.WinTabControl.Controls.Remove(e.Control);
				if (GetControllerByWinObject(e.Control) is TabPageController { WebTabPage: not null } tabPageController)
				{
					base.WebTabControl.TabPages.Remove(tabPageController.WebTabPage);
					base.DesignServices.UnregisterWebComponent(tabPageController.WebTabPage);
				}
			}
		}
	}
	public class NumericUpDownController : UpDownBaseController
	{
		public Gizmox.WebGUI.Forms.NumericUpDown WebNumericUpDown => base.SourceObject as Gizmox.WebGUI.Forms.NumericUpDown;

		public System.Windows.Forms.NumericUpDown WinNumericUpDown => base.TargetObject as System.Windows.Forms.NumericUpDown;

		public NumericUpDownController(IContext objContext, object objWebUpDown)
			: base(objContext, objWebUpDown)
		{
		}

		public NumericUpDownController(IContext objContext, object objWebUpDown, object objWinUpDown)
			: base(objContext, objWebUpDown, objWinUpDown)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinNumericUpDownMinimum();
			SetWinNumericUpDownMaximum();
			SetWinNumericUpDownThousandsSeparator();
			SetWinNumericUpDownIncrement();
			SetWinNumericUpDownValue();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Minimum":
				SetWinNumericUpDownMinimum();
				break;
			case "Maximum":
				SetWinNumericUpDownMaximum();
				break;
			case "ThousandsSeparator":
				SetWinNumericUpDownThousandsSeparator();
				break;
			case "Increment":
				SetWinNumericUpDownIncrement();
				break;
			case "Value":
				SetWinNumericUpDownValue();
				break;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientNumericUpDown();
		}

		protected virtual void SetWinNumericUpDownMinimum()
		{
			WinNumericUpDown.Minimum = WebNumericUpDown.Minimum;
		}

		protected virtual void SetWinNumericUpDownMaximum()
		{
			WinNumericUpDown.Maximum = WebNumericUpDown.Maximum;
		}

		protected virtual void SetWinNumericUpDownIncrement()
		{
			WinNumericUpDown.Increment = WebNumericUpDown.Increment;
		}

		protected virtual void SetWinNumericUpDownThousandsSeparator()
		{
			WinNumericUpDown.ThousandsSeparator = WebNumericUpDown.ThousandsSeparator;
		}

		protected virtual void SetWinNumericUpDownValue()
		{
			WinNumericUpDown.Value = WebNumericUpDown.Value;
		}
	}
	public class ProgressBarController : ControlController
	{
		public Gizmox.WebGUI.Forms.ProgressBar WebProgressBar => base.SourceObject as Gizmox.WebGUI.Forms.ProgressBar;

		public System.Windows.Forms.ProgressBar WinProgressBar => base.TargetObject as System.Windows.Forms.ProgressBar;

		public ProgressBarController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public ProgressBarController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinProgressBarValue();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ProgressBar();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Value")
			{
				SetWinProgressBarValue();
			}
		}

		private void SetWinProgressBarValue()
		{
			if (WinProgressBar.Value != WebProgressBar.Value)
			{
				WinProgressBar.Value = WebProgressBar.Value;
			}
		}
	}
	public class RichTextBoxController : TextBoxBaseController
	{
		public Gizmox.WebGUI.Forms.RichTextBox WebRichTextBox => base.SourceObject as Gizmox.WebGUI.Forms.RichTextBox;

		public System.Windows.Forms.RichTextBox WinRichTextBox => base.TargetObject as System.Windows.Forms.RichTextBox;

		public RichTextBoxController(IContext objContext, object objWebRichTextBox, object objWinRichTextBox)
			: base(objContext, objWebRichTextBox, objWinRichTextBox)
		{
		}

		public RichTextBoxController(IContext objContext, object objWebRichTextBox)
			: base(objContext, objWebRichTextBox)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.RichTextBox();
		}

		protected override void SetWebControlText()
		{
		}
	}
	public class SplitContainerController : ControlController
	{
		private SplitterPanelController mobjSplitterPanel1Controller = null;

		private SplitterPanelController mobjSplitterPanel2Controller = null;

		public System.Windows.Forms.SplitContainer TargetSplitContainer => base.TargetObject as System.Windows.Forms.SplitContainer;

		public Gizmox.WebGUI.Forms.SplitContainer SourceSplitContainer => base.SourceObject as Gizmox.WebGUI.Forms.SplitContainer;

		public SplitContainerController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
			mobjSplitterPanel1Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel1, TargetSplitContainer.Panel1);
			mobjSplitterPanel2Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel2, TargetSplitContainer.Panel2);
		}

		public SplitContainerController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
			mobjSplitterPanel1Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel1, TargetSplitContainer.Panel1);
			mobjSplitterPanel2Controller = new SplitterPanelController(objContext, SourceSplitContainer.Panel2, TargetSplitContainer.Panel2);
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjSplitterPanel1Controller.Initialize();
			mobjSplitterPanel2Controller.Initialize();
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return new System.Windows.Forms.SplitContainer();
		}

		internal override void SetWebControlControls()
		{
		}

		protected override void SetWinControlControls()
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void InitializeController()
		{
			SetTargetSplitContainerFixedPanel();
			base.InitializeController();
			if (base.DesignMode)
			{
				RegisterController(mobjSplitterPanel1Controller);
				RegisterController(mobjSplitterPanel2Controller);
			}
			SetTargetSplitContainerPanel1Collapsed();
			SetTargetSplitContainerPanel1MinSize();
			SetTargetSplitContainerPanel2Collapsed();
			SetTargetSplitContainerPanel2MinSize();
			SetTargetSplitContainerSplitterIncrement();
			SetTargetSplitContainerSplitterWidth();
			TargetSplitContainer.SuspendLayout();
			TargetSplitContainer.Panel1.SuspendLayout();
			TargetSplitContainer.Panel2.SuspendLayout();
			SetTargetSplitContainerOrientation();
			SetTargetSplitContainerSplitterDistance();
			TargetSplitContainer.Panel1.ResumeLayout(performLayout: false);
			TargetSplitContainer.Panel2.ResumeLayout(performLayout: false);
			TargetSplitContainer.ResumeLayout(performLayout: false);
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjSplitterPanel1Controller != null)
			{
				mobjSplitterPanel1Controller.Terminate();
			}
			if (mobjSplitterPanel2Controller != null)
			{
				mobjSplitterPanel2Controller.Terminate();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "SplitterDistance":
				SetSourceSplitContainerSplitterDistance();
				break;
			case "Orientation":
				SetSourceSplitContainerOrientation();
				break;
			case "Panel1Collapsed":
				SetSourceSplitContainerPanel1Collapsed();
				break;
			case "Panel1MinSize":
				SetSourceSplitContainerPanel1MinSize();
				break;
			case "Panel2Collapsed":
				SetSourceSplitContainerPanel2Collapsed();
				break;
			case "Panel2MinSize":
				SetSourceSplitContainerPanel2MinSize();
				break;
			case "SplitterIncrement":
				SetSourceSplitContainerSplitterIncrement();
				break;
			case "SplitterWidth":
				SetSourceSplitContainerSplitterWidth();
				break;
			case "FixedPanel":
				SetSourceSplitContainerFixedPanel();
				break;
			default:
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "SplitterDistance":
				SetTargetSplitContainerSplitterDistance();
				break;
			case "Orientation":
				SetTargetSplitContainerOrientation();
				break;
			case "Panel1Collapsed":
				SetTargetSplitContainerPanel1Collapsed();
				break;
			case "Panel1MinSize":
				SetTargetSplitContainerPanel1MinSize();
				break;
			case "Panel2Collapsed":
				SetTargetSplitContainerPanel2Collapsed();
				break;
			case "Panel2MinSize":
				SetTargetSplitContainerPanel2MinSize();
				break;
			case "SplitterIncrement":
				SetTargetSplitContainerSplitterIncrement();
				break;
			case "SplitterWidth":
				SetTargetSplitContainerSplitterWidth();
				break;
			case "FixedPanel":
				SetTargetSplitContainerFixedPanel();
				break;
			default:
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected virtual void SetTargetSplitContainerSplitterDistance()
		{
			TargetSplitContainer.SplitterDistance = SourceSplitContainer.SplitterDistance;
		}

		protected virtual void SetTargetSplitContainerOrientation()
		{
			TargetSplitContainer.Orientation = (System.Windows.Forms.Orientation)GetConvertedEnum(typeof(System.Windows.Forms.Orientation), SourceSplitContainer.Orientation);
		}

		protected virtual void SetTargetSplitContainerPanel1Collapsed()
		{
			TargetSplitContainer.Panel1Collapsed = SourceSplitContainer.Panel1Collapsed;
		}

		protected virtual void SetTargetSplitContainerPanel1MinSize()
		{
			TargetSplitContainer.Panel1MinSize = SourceSplitContainer.Panel1MinSize;
		}

		protected virtual void SetTargetSplitContainerPanel2Collapsed()
		{
			TargetSplitContainer.Panel2Collapsed = SourceSplitContainer.Panel2Collapsed;
		}

		protected virtual void SetTargetSplitContainerPanel2MinSize()
		{
			TargetSplitContainer.Panel2MinSize = SourceSplitContainer.Panel2MinSize;
		}

		protected virtual void SetTargetSplitContainerSplitterIncrement()
		{
			TargetSplitContainer.SplitterIncrement = SourceSplitContainer.SplitterIncrement;
		}

		protected virtual void SetTargetSplitContainerSplitterWidth()
		{
			TargetSplitContainer.SplitterWidth = SourceSplitContainer.SplitterWidth;
		}

		protected virtual void SetTargetSplitContainerFixedPanel()
		{
			TargetSplitContainer.FixedPanel = (System.Windows.Forms.FixedPanel)GetConvertedEnum(typeof(System.Windows.Forms.FixedPanel), SourceSplitContainer.FixedPanel);
		}

		private void SetSourceSplitContainerSplitterDistance()
		{
			SourceSplitContainer.SplitterDistance = TargetSplitContainer.SplitterDistance;
		}

		protected virtual void SetSourceSplitContainerOrientation()
		{
			SourceSplitContainer.Orientation = (Gizmox.WebGUI.Forms.Orientation)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.Orientation), TargetSplitContainer.Orientation);
		}

		protected virtual void SetSourceSplitContainerPanel1Collapsed()
		{
			SourceSplitContainer.Panel1Collapsed = TargetSplitContainer.Panel1Collapsed;
		}

		protected virtual void SetSourceSplitContainerPanel1MinSize()
		{
			SourceSplitContainer.Panel1MinSize = TargetSplitContainer.Panel1MinSize;
		}

		protected virtual void SetSourceSplitContainerPanel2Collapsed()
		{
			SourceSplitContainer.Panel2Collapsed = TargetSplitContainer.Panel2Collapsed;
		}

		protected virtual void SetSourceSplitContainerPanel2MinSize()
		{
			SourceSplitContainer.Panel2MinSize = TargetSplitContainer.Panel2MinSize;
		}

		protected virtual void SetSourceSplitContainerSplitterIncrement()
		{
			SourceSplitContainer.SplitterIncrement = TargetSplitContainer.SplitterIncrement;
		}

		protected virtual void SetSourceSplitContainerSplitterWidth()
		{
			SourceSplitContainer.SplitterWidth = TargetSplitContainer.SplitterWidth;
		}

		protected virtual void SetSourceSplitContainerFixedPanel()
		{
			SourceSplitContainer.FixedPanel = (Gizmox.WebGUI.Forms.FixedPanel)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.FixedPanel), TargetSplitContainer.FixedPanel);
		}
	}
	public class SplitterPanelController : PanelController
	{
		public System.Windows.Forms.SplitterPanel TargetSplitterPanel => base.TargetObject as System.Windows.Forms.SplitterPanel;

		public Gizmox.WebGUI.Forms.SplitterPanel SourceSplitterPanel => base.SourceObject as Gizmox.WebGUI.Forms.SplitterPanel;

		public SplitterPanelController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public SplitterPanelController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override void SetWinControlDock()
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinSplitterPanelName();
		}

		private void SetWinSplitterPanelName()
		{
			if (TargetSplitterPanel != null && SourceSplitterPanel != null)
			{
				((System.Windows.Forms.Control)TargetSplitterPanel).Name = ((Gizmox.WebGUI.Forms.Control)SourceSplitterPanel).Name;
			}
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			System.Windows.Forms.SplitContainer owner = null;
			if (objSourceObject != null && objSourceObject is Gizmox.WebGUI.Forms.SplitterPanel && ((Gizmox.WebGUI.Forms.SplitterPanel)objSourceObject).Parent != null && GetControllerByWebObject(((Gizmox.WebGUI.Forms.SplitterPanel)objSourceObject).Parent) is SplitContainerController splitContainerController)
			{
				owner = splitContainerController.TargetSplitContainer;
			}
			return new System.Windows.Forms.SplitterPanel(owner);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Name")
			{
				SetWinSplitterPanelName();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}
	}
	public class StackPanelController : PanelController
	{
		public StackPanelController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public StackPanelController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		public object GetPropertyValue(object objInstance, string strProperty)
		{
			return GetPropertyValue(objInstance, strProperty, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		public string GetPropertyValue(object objInstance, string strProperty, string strDefault)
		{
			object propertyValue = GetPropertyValue(objInstance, strProperty);
			if (propertyValue != null)
			{
				TypeConverter converter = TypeDescriptor.GetConverter(propertyValue.GetType());
				if (converter != null && converter.CanConvertTo(typeof(string)))
				{
					return converter.ConvertToInvariantString(propertyValue);
				}
			}
			return strDefault;
		}

		public object GetPropertyValue(object objInstance, string strProperty, BindingFlags enmBindingFlags)
		{
			if (objInstance != null)
			{
				PropertyInfo property = objInstance.GetType().GetProperty(strProperty, enmBindingFlags);
				if (property != null)
				{
					object obj = null;
					try
					{
						obj = property.GetValue(objInstance, new object[0]);
					}
					catch (TargetInvocationException ex)
					{
						if (ex.InnerException != null)
						{
							throw ex.InnerException;
						}
						throw ex;
					}
					return obj;
				}
			}
			return null;
		}

		public void SetPropertyValue(object objInstance, string strProperty, object objValue)
		{
			if (objInstance != null)
			{
				PropertyInfo property = objInstance.GetType().GetProperty(strProperty);
				if (property != null)
				{
					property.SetValue(objInstance, objValue, new object[0]);
				}
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientStackPanel();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinStackPanelOrientation();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Orientation")
			{
				SetWinStackPanelOrientation();
			}
		}

		private void SetWinStackPanelOrientation()
		{
			if (base.SourceObject != null && base.TargetObject != null)
			{
				object propertyValue = GetPropertyValue(base.SourceObject, "Orientation");
				if (propertyValue != null)
				{
					SuspendNotifications();
					SetPropertyValue(base.TargetObject, "Orientation", propertyValue);
					ResumeNotifications();
				}
			}
		}
	}
	public class StatusBarPanelController : ComponentController
	{
		public Gizmox.WebGUI.Forms.StatusBarPanel WebStatusBarPanel => base.SourceObject as Gizmox.WebGUI.Forms.StatusBarPanel;

		public System.Windows.Forms.StatusBarPanel WinStatusBarPanel => base.TargetObject as System.Windows.Forms.StatusBarPanel;

		public StatusBarPanelController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public StatusBarPanelController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinStatusBarPanelText();
			SetWinStatusBarPanelWidth();
			SetWinStatusBarPanelAutoSize();
			SetWinStatusBarPanelAlignment();
		}

		protected virtual void SetWinStatusBarPanelText()
		{
			WinStatusBarPanel.Text = WebStatusBarPanel.Text;
		}

		protected virtual void SetWinStatusBarPanelWidth()
		{
			WinStatusBarPanel.Width = Convert.ToInt32((float)WebStatusBarPanel.Width * base.TargetHorizontalScaleFactor);
		}

		protected virtual void SetWinStatusBarPanelAutoSize()
		{
			WinStatusBarPanel.AutoSize = (System.Windows.Forms.StatusBarPanelAutoSize)GetConvertedEnum(typeof(System.Windows.Forms.StatusBarPanelAutoSize), WebStatusBarPanel.AutoSize);
		}

		protected virtual void SetWinStatusBarPanelAlignment()
		{
			WinStatusBarPanel.Alignment = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebStatusBarPanel.Alignment);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.StatusBarPanel();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinStatusBarPanelText();
				break;
			case "Width":
				SetWinStatusBarPanelWidth();
				break;
			case "AutoSize":
				SetWinStatusBarPanelAutoSize();
				break;
			case "Alignment":
				SetWinStatusBarPanelAlignment();
				break;
			}
		}
	}
	public class StatusPanelCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.StatusBar.StatusBarPanelCollection WebStatusPanelItems => base.WebObjects as Gizmox.WebGUI.Forms.StatusBar.StatusBarPanelCollection;

		public System.Windows.Forms.StatusBar.StatusBarPanelCollection WinStatusPanelItems => base.WebObjects as System.Windows.Forms.StatusBar.StatusBarPanelCollection;

		public Gizmox.WebGUI.Forms.StatusBar WebStatusBar => base.SourceObject as Gizmox.WebGUI.Forms.StatusBar;

		public System.Windows.Forms.StatusBar WinStatusBar => base.TargetObject as System.Windows.Forms.StatusBar;

		public StatusPanelCollectionController(IContext objContext, object objWebTreeNode, IList objWebTreeNodes, object objWinTreeNode, IList objWinTreeNodes)
			: base(objContext, objWebTreeNode, objWebTreeNodes, objWinTreeNode, objWinTreeNodes)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new StatusBarPanelController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.StatusBarPanel();
		}
	}
	public class StatusBarController : ControlController
	{
		private StatusPanelCollectionController mobjStatusPanelCollectionController = null;

		public Gizmox.WebGUI.Forms.StatusBar WebStatusBar => base.SourceObject as Gizmox.WebGUI.Forms.StatusBar;

		public System.Windows.Forms.StatusBar WinStatusBar => base.TargetObject as System.Windows.Forms.StatusBar;

		public StatusBarController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
			mobjStatusPanelCollectionController = new StatusPanelCollectionController(base.Context, objWebObject, WebStatusBar.Panels, WinStatusBar, WinStatusBar.Panels);
		}

		public StatusBarController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjStatusPanelCollectionController = new StatusPanelCollectionController(base.Context, objWebObject, WebStatusBar.Panels, WinStatusBar, WinStatusBar.Panels);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinStatusBarShowPanels();
		}

		protected override void InitializedContained()
		{
			mobjStatusPanelCollectionController.Initialize();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.StatusBar();
		}

		protected virtual void SetWinStatusBarShowPanels()
		{
			WinStatusBar.ShowPanels = WebStatusBar.ShowPanels;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "ShowPanels"))
			{
				if (property == "Panels")
				{
					InitializedContained();
				}
			}
			else
			{
				SetWinStatusBarShowPanels();
			}
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjStatusPanelCollectionController != null)
			{
				mobjStatusPanelCollectionController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjStatusPanelCollectionController != null)
			{
				mobjStatusPanelCollectionController.Terminate();
			}
		}
	}
	public class DateTimePickerController : ControlController
	{
		public Gizmox.WebGUI.Forms.DateTimePicker WebDateTimePicker => base.SourceObject as Gizmox.WebGUI.Forms.DateTimePicker;

		public System.Windows.Forms.DateTimePicker WinDateTimePicker => base.TargetObject as System.Windows.Forms.DateTimePicker;

		public DateTimePickerController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public DateTimePickerController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinDateTimePickerCustomFormat();
			SetWinDateTimePickerFormat();
			SetWinDateTimePickerShowCheckBox();
			SetWinDateTimePickerShowUpDown();
			SetWinDateTimePickerChecked();
		}

		protected override void SetWebControlText()
		{
		}

		protected override void SetWinControlText()
		{
		}

		protected virtual void SetWinDateTimePickerShowCheckBox()
		{
			if (WinDateTimePicker.ShowCheckBox != WebDateTimePicker.ShowCheckBox)
			{
				WinDateTimePicker.ShowCheckBox = WebDateTimePicker.ShowCheckBox;
			}
		}

		protected virtual void SetWinDateTimePickerShowUpDown()
		{
			if (WinDateTimePicker.ShowUpDown != WebDateTimePicker.ShowUpDown)
			{
				WinDateTimePicker.ShowUpDown = WebDateTimePicker.ShowUpDown;
			}
		}

		protected virtual void SetWinDateTimePickerChecked()
		{
			if (WinDateTimePicker.Checked != WebDateTimePicker.Checked)
			{
				WinDateTimePicker.Checked = WebDateTimePicker.Checked;
			}
		}

		protected virtual void SetWinDateTimePickerCustomFormat()
		{
			if (WebDateTimePicker.Format == Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom)
			{
				WinDateTimePicker.CustomFormat = WebDateTimePicker.CustomFormat;
			}
		}

		protected virtual void SetWinDateTimePickerFormat()
		{
			WinDateTimePicker.Format = (System.Windows.Forms.DateTimePickerFormat)GetConvertedEnum(typeof(System.Windows.Forms.DateTimePickerFormat), WebDateTimePicker.Format);
		}

		protected virtual void SetWinDateTimePickerValue()
		{
			WinDateTimePicker.Value = WebDateTimePicker.Value;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.DateTimePicker();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ShowUpDown":
				SetWinDateTimePickerShowUpDown();
				break;
			case "Checked":
				SetWinDateTimePickerChecked();
				break;
			case "ShowCheckBox":
				SetWinDateTimePickerShowCheckBox();
				break;
			case "CustomFormat":
				SetWinDateTimePickerCustomFormat();
				break;
			case "Format":
				SetWinDateTimePickerFormat();
				break;
			case "Value":
				SetWinDateTimePickerValue();
				break;
			}
		}
	}
	public class LinkLabelController : LabelController
	{
		public Gizmox.WebGUI.Forms.LinkLabel WebLinkLabel => base.SourceObject as Gizmox.WebGUI.Forms.LinkLabel;

		public System.Windows.Forms.LinkLabel WinLinkLabel => base.TargetObject as System.Windows.Forms.LinkLabel;

		public LinkLabelController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public LinkLabelController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinLinkLabelLinkColor();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.LinkLabel();
		}

		protected virtual void SetWinLinkLabelLinkColor()
		{
			WinLinkLabel.LinkColor = WebLinkLabel.LinkColor;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "LinkColor")
			{
				SetWinLinkLabelLinkColor();
			}
		}
	}
	public class GroupBoxController : ControlController
	{
		public GroupBoxController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public GroupBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.GroupBox();
		}
	}
	public class PlaceHolderController : ControlController
	{
		public PlaceHolderController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public PlaceHolderController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			System.Windows.Forms.Button button = new System.Windows.Forms.Button();
			button.BackColor = SystemColors.ButtonHighlight;
			button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			return button;
		}

		protected override void SetWebControlText()
		{
		}

		internal override void SetWebControlControls()
		{
		}

		protected override void SetWinControlText()
		{
			SetWinControlTextAndTooltip();
		}

		protected virtual void SetWinControlTextAndTooltip()
		{
			base.WinControl.Text = $"{base.WebControl.Name}\n({base.WebControl.GetType().Name})";
			System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
			toolTip.SetToolTip(base.WinControl, base.WebControl.GetType().FullName);
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Name")
			{
				SetWinControlTextAndTooltip();
			}
			base.FireWebPropertyChanged(objPropertyChangeArgs);
		}
	}
	public class HtmlBoxController : PlaceHolderController
	{
		protected HtmlBox WebHtmlBox => base.WebComponent as HtmlBox;

		protected ClientHtmlBox WinHtmlBox => base.WinComponent as ClientHtmlBox;

		public HtmlBoxController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public HtmlBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinHtmlBoxContent();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientHtmlBox();
		}

		protected override void SetWinControlTextAndTooltip()
		{
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Content")
			{
				SetWinHtmlBoxContent();
			}
		}

		protected virtual void SetWinHtmlBoxContent()
		{
			switch (WebHtmlBox.Type)
			{
			case HtmlBoxType.HTML:
				WinHtmlBox.Html = WebHtmlBox.Html;
				break;
			case HtmlBoxType.URL:
				break;
			case HtmlBoxType.UNC:
				break;
			case HtmlBoxType.RESOURCE:
				break;
			}
		}

		protected override void SetWinControlText()
		{
		}
	}
	public class GenericComponentController : ObjectController
	{
		public IComponent WebGenericComponent => base.SourceObject as IComponent;

		public IComponent WinGenericComponent => base.TargetObject as IComponent;

		public GenericComponentController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public GenericComponentController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}
	}
	public class LabelController : ControlController
	{
		public Gizmox.WebGUI.Forms.Label WebLabel => base.SourceObject as Gizmox.WebGUI.Forms.Label;

		public System.Windows.Forms.Label WinLabel => base.TargetObject as System.Windows.Forms.Label;

		public LabelController(IContext objContext, object objWebLabel, object objWinLabel)
			: base(objContext, objWebLabel, objWinLabel)
		{
		}

		public LabelController(IContext objContext, object objWebLabel)
			: base(objContext, objWebLabel)
		{
		}

		protected override void SetWinControlBorderStyle()
		{
			if (Enum.GetName(typeof(System.Windows.Forms.BorderStyle), WebLabel.BorderStyle) != null)
			{
				WinLabel.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebLabel.BorderStyle, WinLabel.BorderStyle);
			}
		}

		protected virtual void SetWinLabelImage()
		{
			if (WebLabel.Image != null)
			{
				WinLabel.Image = GetWinImageFromResourceHandle(WebLabel.Image);
			}
			else
			{
				WinLabel.Image = null;
			}
		}

		protected virtual void SetWinLabelImageIndex()
		{
			if (WebLabel.Image != null)
			{
				if (WinLabel.ImageList == null)
				{
					WinLabel.ImageList = new System.Windows.Forms.ImageList();
				}
				WinLabel.ImageIndex = GetWinImageIndex(WinLabel.ImageList, WebLabel.Image);
			}
			else
			{
				WinLabel.ImageIndex = -1;
			}
		}

		protected virtual void SetWinLabelImageKey()
		{
			if (WebLabel.Image != null)
			{
				if (WinLabel.ImageList == null)
				{
					WinLabel.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(WinLabel.ImageList, WebLabel.Image, WebLabel.ImageKey) > -1)
				{
					WinLabel.ImageKey = WebLabel.ImageKey;
				}
			}
			else
			{
				WinLabel.ImageKey = string.Empty;
			}
		}

		private void SetWinLabelImageAlign()
		{
			WinLabel.ImageAlign = (ContentAlignment)GetConvertedEnum(typeof(ContentAlignment), WebLabel.ImageAlign);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinLabelTextAlign();
			SetWinLabelImage();
			SetWinLabelImageIndex();
			SetWinLabelImageKey();
			SetWinLabelImageAlign();
		}

		protected virtual void SetWinLabelTextAlign()
		{
			WinLabel.TextAlign = WebLabel.TextAlign;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.Label();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "TextAlign":
				SetWinLabelTextAlign();
				break;
			case "Image":
				SetWinLabelImage();
				break;
			case "ImageIndex":
				SetWinLabelImageIndex();
				break;
			case "ImageKey":
				SetWinLabelImageKey();
				break;
			case "ImageAlign":
				SetWinLabelImageAlign();
				break;
			}
		}
	}
	public class DataGridViewController : ControlController
	{
		private DataGidViewColumnCollectionController mobjDataGidViewColumnCollectionController = null;

		public Gizmox.WebGUI.Forms.DataGridView WebDataGridView => base.SourceObject as Gizmox.WebGUI.Forms.DataGridView;

		public System.Windows.Forms.DataGridView WinDataGridView => base.TargetObject as System.Windows.Forms.DataGridView;

		public DataGridViewController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
			mobjDataGidViewColumnCollectionController = new DataGidViewColumnCollectionController(objContext, WebDataGridView, WebDataGridView.Columns, WinDataGridView, WinDataGridView.Columns);
		}

		public DataGridViewController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjDataGidViewColumnCollectionController = new DataGidViewColumnCollectionController(objContext, WebDataGridView, WebDataGridView.Columns, WinDataGridView, WinDataGridView.Columns);
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.Terminate();
			}
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.Clear();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinDataGridViewColumns();
			SetWinDataGridViewDefaultCellStyle();
			SetWinColumnHeadersDefaultCellStyle();
			SetWinRowHeadersDefaultCellStyle();
			SetWinRowsDefaultCellStyle();
			SetWinAlternatingRowsDefaultCellStyle();
			SetWinDataGridViewRowHeaderWidth();
			SetWinDataGridViewColumnHeadersVisible();
			SetWinDataGridViewColumnHeadersHeight();
			SetWinDataGridViewAutoSizeColumns();
			SetWinDataGridViewColumnHeadersHeightSizeMode();
			SetWinDataGridViewAllowUserToAddRows();
		}

		private void SetWinDataGridViewCellStyle(System.Windows.Forms.DataGridViewCellStyle objWinDataGridViewCellStyle, Gizmox.WebGUI.Forms.DataGridViewCellStyle objWebDataGridViewCellStyle)
		{
			objWinDataGridViewCellStyle.Alignment = (System.Windows.Forms.DataGridViewContentAlignment)Enum.Parse(typeof(System.Windows.Forms.DataGridViewContentAlignment), objWebDataGridViewCellStyle.Alignment.ToString());
			objWinDataGridViewCellStyle.BackColor = objWebDataGridViewCellStyle.BackColor;
			objWinDataGridViewCellStyle.DataSourceNullValue = objWebDataGridViewCellStyle.DataSourceNullValue;
			if (objWebDataGridViewCellStyle.Font == null)
			{
				objWinDataGridViewCellStyle.Font = null;
			}
			else
			{
				objWinDataGridViewCellStyle.Font = new Font(objWebDataGridViewCellStyle.Font.FontFamily, objWebDataGridViewCellStyle.Font.Size * base.TargetVerticalScaleFactor);
			}
			objWinDataGridViewCellStyle.ForeColor = objWebDataGridViewCellStyle.ForeColor;
			objWinDataGridViewCellStyle.Format = objWebDataGridViewCellStyle.Format;
			objWinDataGridViewCellStyle.FormatProvider = objWebDataGridViewCellStyle.FormatProvider;
			objWinDataGridViewCellStyle.NullValue = objWebDataGridViewCellStyle.NullValue;
			objWinDataGridViewCellStyle.Padding = new System.Windows.Forms.Padding(objWebDataGridViewCellStyle.Padding.Left, objWebDataGridViewCellStyle.Padding.Top, objWebDataGridViewCellStyle.Padding.Right, objWebDataGridViewCellStyle.Padding.Bottom);
			objWinDataGridViewCellStyle.SelectionBackColor = objWebDataGridViewCellStyle.SelectionBackColor;
			objWinDataGridViewCellStyle.SelectionForeColor = objWebDataGridViewCellStyle.SelectionForeColor;
			objWinDataGridViewCellStyle.Tag = objWebDataGridViewCellStyle.Tag;
			objWinDataGridViewCellStyle.WrapMode = (System.Windows.Forms.DataGridViewTriState)Enum.Parse(typeof(System.Windows.Forms.DataGridViewTriState), objWebDataGridViewCellStyle.WrapMode.ToString());
		}

		protected void SetWinDataGridViewDefaultCellStyle()
		{
			if (WebDataGridView.DefaultCellStyle != null)
			{
				if (WinDataGridView.DefaultCellStyle == null)
				{
					WinDataGridView.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.DefaultCellStyle, WebDataGridView.DefaultCellStyle);
			}
		}

		protected void SetWinAlternatingRowsDefaultCellStyle()
		{
			if (WebDataGridView.AlternatingRowsDefaultCellStyle != null)
			{
				if (WinDataGridView.AlternatingRowsDefaultCellStyle == null)
				{
					WinDataGridView.AlternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.AlternatingRowsDefaultCellStyle, WebDataGridView.AlternatingRowsDefaultCellStyle);
			}
		}

		protected void SetWinColumnHeadersDefaultCellStyle()
		{
			if (WebDataGridView.ColumnHeadersDefaultCellStyle != null)
			{
				if (WinDataGridView.ColumnHeadersDefaultCellStyle == null)
				{
					WinDataGridView.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.ColumnHeadersDefaultCellStyle, WebDataGridView.ColumnHeadersDefaultCellStyle);
			}
		}

		protected void SetWinRowHeadersDefaultCellStyle()
		{
			if (WebDataGridView.RowHeadersDefaultCellStyle != null)
			{
				if (WinDataGridView.RowHeadersDefaultCellStyle == null)
				{
					WinDataGridView.RowHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.RowHeadersDefaultCellStyle, WebDataGridView.RowHeadersDefaultCellStyle);
			}
		}

		protected void SetWinRowsDefaultCellStyle()
		{
			if (WebDataGridView.RowsDefaultCellStyle != null)
			{
				if (WinDataGridView.RowsDefaultCellStyle == null)
				{
					WinDataGridView.RowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
				}
				SetWinDataGridViewCellStyle(WinDataGridView.RowsDefaultCellStyle, WebDataGridView.RowsDefaultCellStyle);
			}
		}

		protected virtual void SetWinDataGridViewDataSource()
		{
			if (WebDataGridView.DataSource is Gizmox.WebGUI.Forms.BindingSource bindingSource)
			{
				if (!(WinDataGridView.DataSource is System.Windows.Forms.BindingSource bindingSource2) || bindingSource2.DataSource != bindingSource.DataSource || bindingSource2.DataMember != bindingSource.DataMember)
				{
					WinDataGridView.DataSource = new System.Windows.Forms.BindingSource(bindingSource.DataSource, bindingSource.DataMember);
					RefreshDesigner();
				}
			}
			else if (WinDataGridView.DataSource != WebDataGridView.DataSource)
			{
				WinDataGridView.DataSource = WebDataGridView.DataSource;
				RefreshDesigner();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new DataGridView();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			if (WinDataGridView != null)
			{
				WinDataGridView.DataSourceChanged += WinDataGridView_DataSourceChanged;
				WinDataGridView.AutoGenerateColumnsChanged += WinDataGridView_AutoGenerateColumnsChanged;
				WinDataGridView.ColumnHeadersHeightSizeModeChanged += WinDataGridView_ColumnHeadersHeightSizeModeChanged;
			}
		}

		private void WinDataGridView_ColumnHeadersHeightSizeModeChanged(object sender, System.Windows.Forms.DataGridViewAutoSizeModeEventArgs e)
		{
			SetWebDataGridViewColumnHeadersHeightSizeMode();
		}

		private void WinDataGridView_AutoGenerateColumnsChanged(object sender, EventArgs e)
		{
			SetWebDataGridViewAutoGenerateColumns();
		}

		private void WinDataGridView_DataSourceChanged(object sender, EventArgs e)
		{
			SetWebDataGridViewColumns();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			if (WinDataGridView != null)
			{
				WinDataGridView.DataSourceChanged -= WinDataGridView_DataSourceChanged;
				WinDataGridView.AutoGenerateColumnsChanged -= WinDataGridView_AutoGenerateColumnsChanged;
				WinDataGridView.ColumnHeadersHeightSizeModeChanged -= WinDataGridView_ColumnHeadersHeightSizeModeChanged;
			}
		}

		protected override void InitializedContained()
		{
			mobjDataGidViewColumnCollectionController.Initialize();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Columns")
			{
				SetWebDataGridViewColumns();
			}
		}

		private void SetWebDataGridViewAutoGenerateColumns()
		{
			if (WinDataGridView != null && WebDataGridView != null)
			{
				WebDataGridView.AutoGenerateColumns = WinDataGridView.AutoGenerateColumns;
			}
		}

		private void SetWebDataGridViewColumns()
		{
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.SetWebObjectObjects();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DataSource":
				SetWinDataGridViewDataSource();
				break;
			case "DefaultCellStyle":
				SetWinDataGridViewDefaultCellStyle();
				break;
			case "ColumnHeadersDefaultCellStyle":
				SetWinColumnHeadersDefaultCellStyle();
				break;
			case "RowHeadersDefaultCellStyle":
				SetWinRowHeadersDefaultCellStyle();
				break;
			case "RowsDefaultCellStyle":
				SetWinRowsDefaultCellStyle();
				break;
			case "AlternatingRowsDefaultCellStyle":
				SetWinAlternatingRowsDefaultCellStyle();
				break;
			case "Columns":
				SetWinDataGridViewColumns();
				break;
			case "RowHeadersWidth":
				SetWinDataGridViewRowHeaderWidth();
				break;
			case "ColumnHeadersVisible":
				SetWinDataGridViewColumnHeadersVisible();
				break;
			case "ColumnHeadersHeight":
				SetWinDataGridViewColumnHeadersHeight();
				break;
			case "AutoSizeColumnsMode":
				SetWinDataGridViewAutoSizeColumns();
				break;
			case "ColumnHeadersHeightSizeMode":
				SetWinDataGridViewColumnHeadersHeightSizeMode();
				break;
			case "AllowUserToAddRows":
				SetWinDataGridViewAllowUserToAddRows();
				break;
			}
		}

		private void SetWinDataGridViewAllowUserToAddRows()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.AllowUserToAddRows = WebDataGridView.AllowUserToAddRows;
			}
		}

		private void SetWinDataGridViewColumns()
		{
			if (mobjDataGidViewColumnCollectionController != null)
			{
				mobjDataGidViewColumnCollectionController.SetWinObjectObjects();
			}
		}

		private void SetWinDataGridViewRowHeaderWidth()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.RowHeadersWidth = WebDataGridView.RowHeadersWidth;
			}
		}

		private void SetWinDataGridViewColumnHeadersHeight()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.ColumnHeadersHeight = WebDataGridView.ColumnHeadersHeight;
			}
		}

		private void SetWinDataGridViewColumnHeadersVisible()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.ColumnHeadersVisible = WebDataGridView.ColumnHeadersVisible;
			}
		}

		private void SetWinDataGridViewAutoSizeColumns()
		{
			if (WinDataGridView != null)
			{
				WinDataGridView.AutoSizeColumnsMode = (System.Windows.Forms.DataGridViewAutoSizeColumnsMode)GetConvertedEnum(typeof(System.Windows.Forms.DataGridViewAutoSizeColumnsMode), WebDataGridView.AutoSizeColumnsMode, WinDataGridView.AutoSizeColumnsMode);
			}
		}

		private void SetWinDataGridViewColumnHeadersHeightSizeMode()
		{
			if (WinDataGridView != null)
			{
				System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode dataGridViewColumnHeadersHeightSizeMode = (System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode), WebDataGridView.ColumnHeadersHeightSizeMode, WinDataGridView.ColumnHeadersHeightSizeMode);
				if (WinDataGridView.ColumnHeadersHeightSizeMode != dataGridViewColumnHeadersHeightSizeMode)
				{
					WinDataGridView.ColumnHeadersHeightSizeMode = dataGridViewColumnHeadersHeightSizeMode;
				}
			}
		}

		private void SetWebDataGridViewColumnHeadersHeightSizeMode()
		{
			if (WebDataGridView != null)
			{
				Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode dataGridViewColumnHeadersHeightSizeMode = (Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode), WinDataGridView.ColumnHeadersHeightSizeMode, WebDataGridView.ColumnHeadersHeightSizeMode);
				if (WebDataGridView.ColumnHeadersHeightSizeMode != dataGridViewColumnHeadersHeightSizeMode)
				{
					WebDataGridView.ColumnHeadersHeightSizeMode = dataGridViewColumnHeadersHeightSizeMode;
				}
			}
		}
	}
	[Designer(typeof(ControlDesigner))]
	internal class DataGridView : System.Windows.Forms.DataGridView
	{
	}
	public class FlowLayoutPanelController : PanelController
	{
		public Gizmox.WebGUI.Forms.FlowLayoutPanel WebFlowLayoutPanel => base.SourceObject as Gizmox.WebGUI.Forms.FlowLayoutPanel;

		public System.Windows.Forms.FlowLayoutPanel WinFlowLayoutPanel => base.TargetObject as System.Windows.Forms.FlowLayoutPanel;

		public FlowLayoutPanelController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public FlowLayoutPanelController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinFlowLayoutPanelFlowDirection();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (!(property == "FlowDirection"))
			{
				if (property == "WrapContents")
				{
					SetWinFlowLayoutPanelWrapContents();
				}
				else
				{
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				}
			}
			else
			{
				SetWinFlowLayoutPanelFlowDirection();
			}
		}

		private void SetWinFlowLayoutPanelWrapContents()
		{
			WinFlowLayoutPanel.WrapContents = WebFlowLayoutPanel.WrapContents;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "FlowDirection")
			{
				SetWebFlowLayoutPanelFlowDirection();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetWinFlowLayoutPanelFlowDirection()
		{
			System.Windows.Forms.FlowDirection flowDirection = (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.RightToLeft) > (Gizmox.WebGUI.Forms.FlowDirection)0) ? System.Windows.Forms.FlowDirection.RightToLeft : (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.LeftToRight) <= (Gizmox.WebGUI.Forms.FlowDirection)0) ? (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.BottomUp) <= (Gizmox.WebGUI.Forms.FlowDirection)0) ? System.Windows.Forms.FlowDirection.TopDown : System.Windows.Forms.FlowDirection.BottomUp) : System.Windows.Forms.FlowDirection.LeftToRight));
			WinFlowLayoutPanel.FlowDirection = flowDirection;
		}

		protected virtual void SetWebFlowLayoutPanelFlowDirection()
		{
			Gizmox.WebGUI.Forms.FlowDirection flowDirection = (((WebFlowLayoutPanel.FlowDirection & Gizmox.WebGUI.Forms.FlowDirection.TopDown) > (Gizmox.WebGUI.Forms.FlowDirection)0) ? Gizmox.WebGUI.Forms.FlowDirection.RightToLeft : (((WebFlowLayoutPanel.FlowDirection & (Gizmox.WebGUI.Forms.FlowDirection)0) > (Gizmox.WebGUI.Forms.FlowDirection)0) ? Gizmox.WebGUI.Forms.FlowDirection.LeftToRight : (((WebFlowLayoutPanel.FlowDirection & (Gizmox.WebGUI.Forms.FlowDirection)3) <= (Gizmox.WebGUI.Forms.FlowDirection)0) ? Gizmox.WebGUI.Forms.FlowDirection.TopDown : Gizmox.WebGUI.Forms.FlowDirection.BottomUp)));
			WebFlowLayoutPanel.FlowDirection = flowDirection;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.FlowLayoutPanel();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}
	}
	public class FormController : ScrollableControlController
	{
		private MainMenuController mobjMainMenuController = null;

		protected IObservableList ObservableList => base.SourceObject as IObservableList;

		public Gizmox.WebGUI.Forms.Form WebForm => base.SourceObject as Gizmox.WebGUI.Forms.Form;

		public System.Windows.Forms.Form WinForm => base.TargetObject as System.Windows.Forms.Form;

		public FormController(IContext objContext, Gizmox.WebGUI.Forms.Form objWebForm, System.Windows.Forms.Form objWinForm)
			: base(objContext, objWebForm, objWinForm)
		{
		}

		public FormController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinFormMainMenu();
			WinForm.SuspendLayout();
			SetWinFormFormBorderStyle();
			WinForm.ResumeLayout(performLayout: false);
			SetWinFormMaximizeBox();
			SetWinFormMinimizeBox();
			SetWinStartPosition();
			SetWinIsMdiContainer();
		}

		protected virtual void SetWinStartPosition()
		{
			WinForm.StartPosition = (System.Windows.Forms.FormStartPosition)GetConvertedEnum(typeof(System.Windows.Forms.FormStartPosition), WebForm.StartPosition);
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjMainMenuController != null)
			{
				mobjMainMenuController.Terminate();
			}
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			Gizmox.WebGUI.Forms.Form[] ownedForms = WebForm.OwnedForms;
			foreach (Gizmox.WebGUI.Forms.Form objWebForm in ownedForms)
			{
				System.Windows.Forms.Form form = CreateWinForm(objWebForm);
				FormController formController = new FormController(base.Context, objWebForm, form);
				RegisterController(formController);
				formController.InitializeController();
				form.ShowDialog(WinForm);
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinForm.Activated += WinForm_Activated;
			WinForm.Closed += WinForm_Closed;
			if (ObservableList != null)
			{
				ObservableList.ObservableItemAdded += ObservableList_ObservableItemAdded;
				ObservableList.ObservableItemRemoved += ObservableList_ObservableItemRemoved;
			}
		}

		private void WinForm_Closed(object sender, EventArgs e)
		{
			CreateWebEvent("OnUnload")?.Fire();
		}

		private void WinForm_Activated(object sender, EventArgs e)
		{
			CreateWebEvent("SetActive")?.Fire();
		}

		internal void FireFormAdded(object objWebObject)
		{
			Gizmox.WebGUI.Forms.Form objWebForm = objWebObject as Gizmox.WebGUI.Forms.Form;
			System.Windows.Forms.Form form = CreateWinForm(objWebForm);
			FormController formController = new FormController(base.Context, objWebForm, form);
			RegisterController(formController);
			formController.InitializeController();
			form.ShowInTaskbar = false;
			form.ShowDialog(WinForm);
		}

		private void ObservableList_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)base.Context).NotifyFormAdded(this, objArgs.Item);
		}

		internal void FireFormRemoved(object objWebObject)
		{
			System.Windows.Forms.Form form = GetWinObject(objWebObject) as System.Windows.Forms.Form;
			form.Close();
			UnregisterControllerByWinObject(form);
		}

		private void ObservableList_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)base.Context).NotifyFormRemoved(this, objArgs.Item);
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinForm.Activated -= WinForm_Activated;
			WinForm.Closed -= WinForm_Closed;
			if (ObservableList != null)
			{
				ObservableList.ObservableItemAdded -= ObservableList_ObservableItemAdded;
				ObservableList.ObservableItemRemoved -= ObservableList_ObservableItemRemoved;
			}
		}

		protected virtual System.Windows.Forms.Form CreateWinForm(object objWebForm)
		{
			return new ClientForm();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientForm();
		}

		protected override void LoadController()
		{
			base.LoadController();
			WebForm.Visible = true;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "MaximizeBox":
				SetWinFormMaximizeBox();
				break;
			case "MinimizeBox":
				SetWinFormMinimizeBox();
				break;
			case "FormBorderStyle":
				SetWinFormFormBorderStyle();
				break;
			case "StartPosition":
				SetWinStartPosition();
				break;
			case "IsMdiContainer":
				SetWinIsMdiContainer();
				break;
			}
		}

		internal override void SetWebControlControls()
		{
			bool isMdiContainer = WebForm.IsMdiContainer;
			System.Windows.Forms.Button button = null;
			System.Windows.Forms.Button button2 = null;
			foreach (Gizmox.WebGUI.Forms.Control control3 in WebForm.Controls)
			{
				if (control3.Form.AcceptButton != control3 && control3.Form.CancelButton != control3)
				{
					continue;
				}
				ObjectController controllerByWebObject = GetControllerByWebObject(control3);
				if (controllerByWebObject != null)
				{
					if (control3.Form.AcceptButton == control3)
					{
						button = controllerByWebObject.TargetObject as System.Windows.Forms.Button;
					}
					else if (control3.Form.CancelButton == control3)
					{
						button2 = controllerByWebObject.TargetObject as System.Windows.Forms.Button;
					}
				}
			}
			base.SetWebControlControls();
			if (isMdiContainer)
			{
				WebForm.IsMdiContainer = true;
			}
			if (button == null && button2 == null)
			{
				return;
			}
			foreach (System.Windows.Forms.Control control4 in WinForm.Controls)
			{
				if (GetControllerByWinObject(control4) is ControlController controlController && controlController.WebControl.Form != null)
				{
					if (control4 == button)
					{
						controlController.WebControl.Form.AcceptButton = controlController.WebControl as Gizmox.WebGUI.Forms.IButtonControl;
					}
					else if (control4 == button2)
					{
						controlController.WebControl.Form.CancelButton = controlController.WebControl as Gizmox.WebGUI.Forms.IButtonControl;
					}
				}
			}
		}

		protected override void SetWinControlDock()
		{
		}

		protected override void SetWinControlVisible()
		{
		}

		protected override void SetWinControlLocation()
		{
			if (!base.DesignMode)
			{
				base.SetWinControlLocation();
			}
		}

		protected override void SetWebControlLocation()
		{
			if (!base.DesignMode)
			{
				base.SetWebControlLocation();
			}
		}

		protected override void SetWinControlAnchor()
		{
		}

		protected override void SetWebControlSize()
		{
			WebForm.Size = new Size(Convert.ToInt32((float)WinForm.Size.Width / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WinForm.Size.Height / base.TargetVerticalScaleFactor));
		}

		protected override void SetWinControlSize()
		{
			WinForm.ClientSize = new Size(Convert.ToInt32((float)WebForm.Size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)WebForm.Size.Height * base.TargetVerticalScaleFactor));
		}

		protected override void SetWinControlMaximumSize()
		{
			WinForm.MaximumSize = WebForm.MaximumSize;
		}

		protected override void SetWinControlMinimumSize()
		{
			WinForm.MinimumSize = WebForm.MinimumSize;
		}

		protected virtual void SetWinFormMaximizeBox()
		{
			WinForm.MaximizeBox = WebForm.MaximizeBox;
		}

		protected virtual void SetWinFormMinimizeBox()
		{
			WinForm.MinimizeBox = WebForm.MinimizeBox;
		}

		protected virtual void SetWinIsMdiContainer()
		{
			WinForm.IsMdiContainer = WebForm.IsMdiContainer;
		}

		protected virtual void SetWinFormFormBorderStyle()
		{
			if (!base.DesignMode)
			{
				WinForm.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.FormBorderStyle), WebForm.FormBorderStyle);
			}
			else
			{
				WinForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			}
		}

		protected virtual void SetWinFormMainMenu()
		{
			Gizmox.WebGUI.Forms.MainMenu menu = WebForm.Menu;
			if (menu != null)
			{
				System.Windows.Forms.MainMenu mainMenu = new System.Windows.Forms.MainMenu();
				WinForm.Menu = mainMenu;
				mobjMainMenuController = new MainMenuController(base.Context, menu, mainMenu);
				mobjMainMenuController.Initialize();
			}
		}
	}
	public class ItemsCollectionController : ObjectCollectionController
	{
		public ItemsCollectionController(IContext objContext, object objWebTreeNode, IList objWebTreeNodes, object objWinTreeNode, IList objWinTreeNodes)
			: base(objContext, objWebTreeNode, objWebTreeNodes, objWinTreeNode, objWinTreeNodes)
		{
		}

		protected override void InitializeWinObjects()
		{
			if (base.WebObjects == null || base.WebObjects == null)
			{
				return;
			}
			ClearWinObjects();
			foreach (object webObject in base.WebObjects)
			{
				AddWinObject(webObject);
			}
		}

		protected override int OnWebObjectAdded(object objWebObject)
		{
			int num = -1;
			return AddWinObject(objWebObject);
		}

		protected override void OnWebObjectRemoved(object objWebObject)
		{
			RemoveWinObject(objWebObject);
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return null;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return objWebObject;
		}
	}
	public class ListBoxController : ListControlController
	{
		private ItemsCollectionController mobjItemsCollectionController = null;

		public Gizmox.WebGUI.Forms.ListBox WebListBox => base.SourceObject as Gizmox.WebGUI.Forms.ListBox;

		public System.Windows.Forms.ListBox WinListBox => base.TargetObject as System.Windows.Forms.ListBox;

		public ListBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebListBox, WebListBox.Items, WinListBox, WinListBox.Items);
		}

		public ListBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebListBox, WebListBox.Items, WinListBox, WinListBox.Items);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjItemsCollectionController.Initialize();
			SetWinListBoxDataSource();
			SetWinListBoxItems();
		}

		protected virtual void SetWinListBoxDataSource()
		{
			if (WebListBox.DataSource != null)
			{
				WinListBox.DisplayMember = WebListBox.DisplayMember;
				WinListBox.DataSource = WebListBox.DataSource;
			}
		}

		protected virtual void SetSorted()
		{
			if (WebListBox != null && WinListBox != null)
			{
				WinListBox.Sorted = WebListBox.Sorted;
			}
		}

		protected virtual void SetWinListBoxItems()
		{
			if (WebListBox.DataSource != null)
			{
				return;
			}
			WinListBox.Items.Clear();
			foreach (object item in WebListBox.Items)
			{
				WinListBox.Items.Add(item);
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinListBox.SelectedIndexChanged += WinListBox_SelectedIndexChanged;
		}

		private void WinListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int selectedIndex in WinListBox.SelectedIndices)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(selectedIndex.ToString());
			}
			Event obj = CreateWebEvent("SelectionChange");
			obj.SetParameter("Indexes", stringBuilder.ToString());
			obj.SetParameter("Incremental", "0");
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinListBox.SelectedIndexChanged -= WinListBox_SelectedIndexChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DataSource":
				SetWinListBoxDataSource();
				break;
			case "Items":
				SetWinListBoxItems();
				break;
			case "Sorted":
				SetSorted();
				break;
			}
		}
	}
	public class ListViewColumnHeaderCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection WebListViewColumnHeaders => base.WebObjects as Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection;

		public Gizmox.WebGUI.Forms.ListView WebListView => base.SourceObject as Gizmox.WebGUI.Forms.ListView;

		public System.Windows.Forms.ListView.ColumnHeaderCollection WinListViewColumnHeaders => base.WinObjects as System.Windows.Forms.ListView.ColumnHeaderCollection;

		public System.Windows.Forms.ListView WinListView => base.TargetObject as System.Windows.Forms.ListView;

		public ListViewColumnHeaderCollectionController(IContext objContext, object objWebListView, IList objWebColumnHeaders, object objWinListView, IList objWinColumnHeaders)
			: base(objContext, objWebListView, objWebColumnHeaders, objWinListView, objWinColumnHeaders)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new ListViewColumnHeaderController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ColumnHeader();
		}

		protected override void InitializeWinObjects()
		{
			base.InitializeWinObjects();
		}
	}
	public class ListViewColumnHeaderController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ColumnHeader WebColumnHeader => base.SourceObject as Gizmox.WebGUI.Forms.ColumnHeader;

		public System.Windows.Forms.ColumnHeader WinColumnHeader => base.TargetObject as System.Windows.Forms.ColumnHeader;

		public ListViewColumnHeaderController(IContext objContext, object objWebListView, object objWinListView)
			: base(objContext, objWebListView, objWinListView)
		{
		}

		public ListViewColumnHeaderController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinColumnHeaderText();
			SetWinColumnHeaderWidth();
			SetWinColumnHeaderImageKey();
			SetWinColumnHeaderImageIndex();
		}

		private void SetWinColumnHeaderImageIndex()
		{
			EnsureWinListViewImageList();
			WinColumnHeader.ImageIndex = GetWinImageIndex(WinColumnHeader.ImageList, WebColumnHeader.Image);
		}

		private void EnsureWinListViewImageList()
		{
			if (WebColumnHeader.Image != null && WinColumnHeader.ListView != null && WinColumnHeader.ListView.SmallImageList == null)
			{
				WinColumnHeader.ListView.SmallImageList = new System.Windows.Forms.ImageList();
			}
		}

		private void SetWinColumnHeaderImageKey()
		{
			EnsureWinListViewImageList();
			if (GetWinImageIndex(WinColumnHeader.ImageList, WebColumnHeader.Image, WebColumnHeader.ImageKey) > -1)
			{
				WinColumnHeader.ImageKey = WebColumnHeader.ImageKey;
			}
			else
			{
				WinColumnHeader.ImageKey = string.Empty;
			}
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinColumnHeaderText();
				break;
			case "Width":
				SetWinColumnHeaderWidth();
				break;
			case "ImageKey":
				SetWinColumnHeaderImageKey();
				break;
			case "ImageIndex":
				SetWinColumnHeaderImageIndex();
				break;
			}
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Width")
			{
				SetWebColumnHeaderWidth();
			}
		}

		protected virtual void SetWinColumnHeaderText()
		{
			WinColumnHeader.Text = WebColumnHeader.Text;
		}

		protected virtual void SetWinColumnHeaderWidth()
		{
			WinColumnHeader.Width = Convert.ToInt32((float)WebColumnHeader.Width * base.TargetHorizontalScaleFactor);
		}

		protected virtual void SetWebColumnHeaderWidth()
		{
			SetWebProperty("Width", Convert.ToInt32((float)WinColumnHeader.Width / base.TargetHorizontalScaleFactor));
		}
	}
	public class ListViewController : ControlController
	{
		private ListViewColumnHeaderCollectionController mobjColumnHeaderCollectionController = null;

		private ListViewItemCollectionController mobjItemCollectionController = null;

		private ListViewGroupCollectionController mobjGroupCollectionController = null;

		public Gizmox.WebGUI.Forms.ListView WebListView => base.SourceObject as Gizmox.WebGUI.Forms.ListView;

		public System.Windows.Forms.ListView WinListView => base.TargetObject as System.Windows.Forms.ListView;

		public ListViewController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjColumnHeaderCollectionController = new ListViewColumnHeaderCollectionController(base.Context, WebListView, WebListView.Columns, WinListView, WinListView.Columns);
			mobjItemCollectionController = new ListViewItemCollectionController(base.Context, WebListView, WebListView.Items, WinListView, WinListView.Items);
			mobjGroupCollectionController = new ListViewGroupCollectionController(base.Context, WebListView, WebListView.Groups, WinListView, WinListView.Groups);
		}

		public ListViewController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjColumnHeaderCollectionController = new ListViewColumnHeaderCollectionController(base.Context, WebListView, WebListView.Columns, WinListView, WinListView.Columns);
			mobjItemCollectionController = new ListViewItemCollectionController(base.Context, WebListView, WebListView.Items, WinListView, WinListView.Items);
			mobjGroupCollectionController = new ListViewGroupCollectionController(base.Context, WebListView, WebListView.Groups, WinListView, WinListView.Groups);
		}

		protected override void InitializedContained()
		{
			mobjColumnHeaderCollectionController.Initialize();
			mobjGroupCollectionController.Initialize();
			mobjItemCollectionController.Initialize();
		}

		protected override void InitializeController()
		{
			SetWinListViewView();
			base.InitializeController();
			SetWinListViewCheckBoxes();
			SetWinListViewScrollable();
			SetWinGroups();
			SetWinShowGroups();
			SetWinGridLines();
			SetWinItems();
		}

		protected virtual void SetWinShowGroups()
		{
			WinListView.ShowGroups = WebListView.ShowGroups;
		}

		protected virtual void SetWinListViewView()
		{
			object convertedEnum = GetConvertedEnum(typeof(System.Windows.Forms.View), WebListView.View);
			if (convertedEnum != null)
			{
				WinListView.View = (System.Windows.Forms.View)convertedEnum;
			}
		}

		protected override void SetWinControlBorderStyle()
		{
			WinListView.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebListView.BorderStyle, WinListView.BorderStyle);
		}

		protected virtual void SetWebListViewScrollable()
		{
			WebListView.Scrollable = WinListView.Scrollable;
		}

		protected virtual void SetWinListViewCheckBoxes()
		{
			WinListView.CheckBoxes = WebListView.CheckBoxes;
		}

		protected virtual void SetWebListViewColumnHeaderWidth(Gizmox.WebGUI.Forms.ColumnHeader objWebColumnHeader, System.Windows.Forms.ColumnHeader objWinColumnHeader)
		{
			try
			{
				SuspendNotifications();
				objWebColumnHeader.Width = Convert.ToInt32((float)objWinColumnHeader.Width / base.TargetHorizontalScaleFactor);
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "CheckBoxes":
				SetWinListViewCheckBoxes();
				break;
			case "Columns":
				InitializedContained();
				break;
			case "Scrollable":
				SetWinListViewScrollable();
				break;
			case "View":
				SetWinListViewView();
				break;
			case "Items":
				SetWinItems();
				break;
			case "ShowGroups":
				SetWinShowGroups();
				break;
			case "GridLines":
				SetWinGridLines();
				break;
			case "Groups":
				SetWinGroups();
				break;
			}
		}

		private void SetWinGridLines()
		{
			WinListView.GridLines = WebListView.GridLines;
		}

		private void SetWinGroups()
		{
			mobjGroupCollectionController.SetWinObjectObjects();
		}

		private void SetWebGroups()
		{
			mobjGroupCollectionController.SetWebObjectObjects();
		}

		private void SetWinItems()
		{
			mobjItemCollectionController.SetWinObjectObjects();
		}

		private void SetWebItems()
		{
			mobjItemCollectionController.SetWebObjectObjects();
		}

		private void SetWinListViewScrollable()
		{
			WinListView.Scrollable = WebListView.Scrollable;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Scrollable":
				SetWebListViewScrollable();
				break;
			case "View":
				SetWebListViewView();
				break;
			case "Items":
				SetWebItems();
				break;
			}
		}

		private void SetWebListViewView()
		{
			WebListView.View = (Gizmox.WebGUI.Forms.View)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.View), WinListView.View);
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinListView.SelectedIndexChanged += WinListView_SelectedIndexChanged;
			WinListView.DoubleClick += WinListView_DoubleClick;
		}

		private void WinListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int selectedIndex in WinListView.SelectedIndices)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(selectedIndex.ToString());
			}
			Event obj = CreateWebEvent("SelectionChange");
			obj.SetParameter("Indexes", stringBuilder.ToString());
			obj.SetParameter("Incremental", "0");
			obj.Fire();
		}

		private void WinListView_DoubleClick(object sender, EventArgs e)
		{
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinListView.SelectedIndexChanged -= WinListView_SelectedIndexChanged;
			WinListView.DoubleClick -= WinListView_DoubleClick;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientListView();
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjColumnHeaderCollectionController != null)
			{
				mobjColumnHeaderCollectionController.Terminate();
			}
			if (mobjItemCollectionController != null)
			{
				mobjItemCollectionController.Terminate();
			}
			if (mobjGroupCollectionController != null)
			{
				mobjGroupCollectionController.Terminate();
			}
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinListView.ColumnWidthChanged += WinListView_ColumnWidthChanged;
		}

		private void WinListView_ColumnWidthChanged(object sender, System.Windows.Forms.ColumnWidthChangedEventArgs e)
		{
			if (base.IsNotificationSuspened)
			{
				return;
			}
			System.Windows.Forms.ColumnHeader columnHeader = WinListView.Columns[e.ColumnIndex];
			if (columnHeader == null)
			{
				return;
			}
			ObjectController controllerByWinObject = GetControllerByWinObject(columnHeader);
			if (controllerByWinObject != null)
			{
				Gizmox.WebGUI.Forms.ColumnHeader columnHeader2 = (Gizmox.WebGUI.Forms.ColumnHeader)controllerByWinObject.SourceObject;
				if (columnHeader2 != null && columnHeader.Width != columnHeader2.Width)
				{
					controllerByWinObject.FireWinPropertyChanged(new ObservableItemPropertyChangedArgs("Width"));
				}
			}
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinListView.ColumnWidthChanged -= WinListView_ColumnWidthChanged;
		}
	}
	public class ListViewItemCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.ListView.ListViewItemCollection WebListViewItems => base.WebObjects as Gizmox.WebGUI.Forms.ListView.ListViewItemCollection;

		public Gizmox.WebGUI.Forms.ListView WebListView => base.SourceObject as Gizmox.WebGUI.Forms.ListView;

		public System.Windows.Forms.ListView.ListViewItemCollection WinListItems => base.WinObjects as System.Windows.Forms.ListView.ListViewItemCollection;

		public System.Windows.Forms.ListView WinListView => base.TargetObject as System.Windows.Forms.ListView;

		public ListViewItemCollectionController(IContext objContext, object objWebListView, IList objWebColumnHeaders, object objWinListView, IList objWinColumnHeaders)
			: base(objContext, objWebListView, objWebColumnHeaders, objWinListView, objWinColumnHeaders)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new ListViewItemController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientListViewItem();
		}
	}
	public class ListViewSubItemController : ComponentController
	{
		private ContextMenuController mobjContextMenuController = null;

		public Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem WebListViewSubItem => base.SourceObject as Gizmox.WebGUI.Forms.ListViewItem.ListViewSubItem;

		public System.Windows.Forms.ListViewItem.ListViewSubItem WinListViewSubItem => base.TargetObject as System.Windows.Forms.ListViewItem.ListViewSubItem;

		public ListViewSubItemController(IContext objContext, object objWebListViewSubItem, object objWinListViewSubItem)
			: base(objContext, objWebListViewSubItem, objWinListViewSubItem)
		{
		}

		public ListViewSubItemController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinListViewSubItemText();
			SetWinListViewSubItemForeColor();
			SetWinListViewSubItemBackColor();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetWinListViewSubItemText();
			SetWinListViewSubItemForeColor();
			SetWinListViewSubItemBackColor();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinListViewSubItemText();
				break;
			case "BackColor":
				SetWinListViewSubItemBackColor();
				break;
			case "ForeColor":
				SetWinListViewSubItemForeColor();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebListViewSubItemText();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebListViewSubItemText();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ListViewItem.ListViewSubItem();
		}

		protected virtual void SetWinListViewSubItemText()
		{
			WinListViewSubItem.Text = WebListViewSubItem.Text;
		}

		protected virtual void SetWebListViewSubItemText()
		{
			WebListViewSubItem.Text = WinListViewSubItem.Text;
		}

		protected virtual void SetWinListViewSubItemBackColor()
		{
			WinListViewSubItem.BackColor = WebListViewSubItem.BackColor;
		}

		protected virtual void SetWinListViewSubItemForeColor()
		{
			WinListViewSubItem.ForeColor = WebListViewSubItem.ForeColor;
		}
	}
	public class MainMenuController : MenuController
	{
		private MenuItemCollectionController mobjMenuItemCollectionController = null;

		public Gizmox.WebGUI.Forms.MainMenu WebMainMenu => base.SourceObject as Gizmox.WebGUI.Forms.MainMenu;

		public System.Windows.Forms.MainMenu WinMainMenu => base.TargetObject as System.Windows.Forms.MainMenu;

		public MainMenuController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebMainMenu, WebMainMenu.MenuItems, WinMainMenu, WinMainMenu.MenuItems);
		}

		public MainMenuController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebMainMenu, WebMainMenu.MenuItems, WinMainMenu, WinMainMenu.MenuItems);
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "VWGNullProperty" && mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.SetWebObjectObjects();
			}
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
		}

		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Clear();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.MainMenu();
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Terminate();
			}
		}
	}
	public class MenuItemCollectionController : ComponentCollectionController
	{
		private ClientMenuStyleProvider mobjSpecialMenuProvider = null;

		public MenuItemCollection WebMenuItemCollection => base.SourceObject as MenuItemCollection;

		public System.Windows.Forms.Menu.MenuItemCollection WinMenuItemCollection => base.TargetObject as System.Windows.Forms.Menu.MenuItemCollection;

		public MenuItemCollectionController(IContext objContext, object objWebMenuItem, IList objWebMenuItems, object objWinMenuItem, IList objWinMenuItems)
			: base(objContext, objWebMenuItem, objWebMenuItems, objWinMenuItem, objWinMenuItems)
		{
			mobjSpecialMenuProvider = new ClientMenuStyleProvider();
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new MenuItemController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			System.Windows.Forms.MenuItem menuItem = new System.Windows.Forms.MenuItem();
			menuItem.OwnerDraw = true;
			mobjSpecialMenuProvider.SetNewStyleActive(menuItem, value: true);
			return menuItem;
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}
	}
	public class MenuItemController : MenuController
	{
		private MenuItemCollectionController mobjMenuItemCollectionController = null;

		public Gizmox.WebGUI.Forms.MenuItem WebMenuItem => base.SourceObject as Gizmox.WebGUI.Forms.MenuItem;

		public System.Windows.Forms.MenuItem WinMenuItem => base.TargetObject as System.Windows.Forms.MenuItem;

		public MenuItemController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebMenuItem, WebMenuItem.MenuItems, WinMenuItem, WinMenuItem.MenuItems);
		}

		public MenuItemController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(base.Context, WebMenuItem, WebMenuItem.MenuItems, WinMenuItem, WinMenuItem.MenuItems);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Text"))
			{
				if (property == "Index")
				{
					SetWinMenuItemIndex(blnFireWinComponentChanged: true);
				}
			}
			else
			{
				SetWinMenuItemText(blnFireWinComponentChanged: true);
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWebMenuItemText();
				break;
			case "Index":
				SetWebMenuItemIndex();
				break;
			case "VWGNullProperty":
				if (mobjMenuItemCollectionController != null)
				{
					mobjMenuItemCollectionController.SetWebObjectObjects();
				}
				break;
			}
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebMenuItemText();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinMenuItemText();
			SetWinMenuItemIndex();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetWebMenuItemIndex();
		}

		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}

		private void SetWinMenuItemIndex(bool blnFireWinComponentChanged)
		{
			if (blnFireWinComponentChanged)
			{
				SetWinProperty("Index", WebMenuItem.Index);
			}
			else
			{
				WinMenuItem.Index = WebMenuItem.Index;
			}
		}

		private void SetWinMenuItemText(bool blnFireWinComponentChanged)
		{
			if (blnFireWinComponentChanged)
			{
				SetWinProperty("Text", WebMenuItem.Text);
			}
			else
			{
				WinMenuItem.Text = WebMenuItem.Text;
			}
		}

		protected virtual void SetWinMenuItemIndex()
		{
			SetWinMenuItemIndex(blnFireWinComponentChanged: false);
		}

		protected virtual void SetWebMenuItemText()
		{
			SetWebProperty("Text", WinMenuItem.Text);
		}

		protected virtual void SetWebMenuItemIndex()
		{
			SetWebProperty("Index", WinMenuItem.Index);
		}

		protected virtual void SetWinMenuItemText()
		{
			SetWinMenuItemText(blnFireWinComponentChanged: false);
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinMenuItem.Click += WinMenuItem_Click;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinMenuItem.Click -= WinMenuItem_Click;
		}

		private void WinMenuItem_Click(object sender, EventArgs e)
		{
			if (GetControllerByWinObject(sender) is MenuItemController menuItemController)
			{
				Event obj = CreateWebEvent("MenuClick", GetParentOwner(menuItemController.WebMenuItem), menuItemController.WebMenuItem);
				obj.Fire();
			}
		}

		private object GetParentOwner(Gizmox.WebGUI.Forms.MenuItem objMenu)
		{
			if (objMenu.Parent != null)
			{
				if (objMenu.Parent is Gizmox.WebGUI.Forms.ContextMenu)
				{
					if (GetControllerByWebObject(objMenu.Parent) is ContextMenuController contextMenuController && contextMenuController.GetTarget() != null)
					{
						return GetWebObject(contextMenuController.GetTarget());
					}
					return objMenu.Parent.InternalParent;
				}
				if (objMenu.Parent is Gizmox.WebGUI.Forms.MenuItem)
				{
					return GetParentOwner((Gizmox.WebGUI.Forms.MenuItem)objMenu.Parent);
				}
				return null;
			}
			return objMenu.InternalParent;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.MenuItem();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (WinMenuItem != null && WinMenuItem.Parent != null && WinMenuItem.Parent.MenuItems.Contains(WinMenuItem))
			{
				try
				{
					SuspendNotifications();
					WinMenuItem.Parent.MenuItems.Remove(WinMenuItem);
				}
				finally
				{
					ResumeNotifications();
				}
			}
			if (mobjMenuItemCollectionController != null)
			{
				mobjMenuItemCollectionController.Terminate();
			}
		}
	}
	public abstract class ObjectCollectionController : ObjectController
	{
		private IList mobjWebObjects = null;

		private IList mobjWinObjects = null;

		private IContext mobjContext = null;

		private ArrayList mobjControllers = null;

		public new IContext Context => mobjContext;

		protected virtual bool OverrideExistWinObjects => false;

		public IList WebObjects => mobjWebObjects;

		public IObservableList WebObservedList => WebObjects as IObservableList;

		public IList WinObjects => mobjWinObjects;

		public ObjectCollectionController(IContext objContext, object objWebObject, IList objWebObjects, object objWinObject, IList objWinObjects)
			: base(objContext, objWebObject, objWinObject)
		{
			mobjControllers = new ArrayList();
			mobjWebObjects = objWebObjects;
			mobjWinObjects = objWinObjects;
			mobjContext = objContext;
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			foreach (ObjectController mobjController in mobjControllers)
			{
				mobjController.UpdateSource();
			}
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			foreach (ObjectController mobjController in mobjControllers)
			{
				mobjController.UpdateTarget();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			if (!WinObjects.IsReadOnly)
			{
				try
				{
					SuspendNotifications();
					InitializeWinObjects();
				}
				finally
				{
					ResumeNotifications();
				}
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			if (WebObservedList != null && !base.DesignMode)
			{
				WebObservedList.ObservableItemAdded += WebObservedList_ObservableItemAdded;
				WebObservedList.ObservableItemRemoved += WebObservedList_ObservableItemRemoved;
				WebObservedList.ObservableListCleared += WebObservedList_ObservableListCleared;
			}
		}

		private void WebObservedList_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			if (GetControllerByWebObject(objArgs.Item) == null)
			{
				((IContextNotifications)Context).NotifyListItemAdded(this, objArgs.Item);
			}
		}

		private void WebObservedList_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)Context).NotifyListItemRemoved(this, objArgs.Item);
		}

		private void WebObservedList_ObservableListCleared(object sender, EventArgs e)
		{
			((IContextNotifications)Context).NotifyListCleared(this);
		}

		public virtual void FireObservableListItemAdded(object objItem)
		{
			OnWebObjectAdded(objItem);
		}

		public virtual void FireObservableListItemRemoved(object objItem)
		{
			OnWebObjectRemoved(objItem);
		}

		public virtual void FireObservableListCleared()
		{
			ClearWinObjects();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			if (WebObservedList != null && !base.DesignMode)
			{
				WebObservedList.ObservableItemAdded -= WebObservedList_ObservableItemAdded;
				WebObservedList.ObservableItemRemoved -= WebObservedList_ObservableItemRemoved;
				WebObservedList.ObservableListCleared -= WebObservedList_ObservableListCleared;
			}
		}

		protected virtual void InitializeWinObjects()
		{
			if (WebObjects == null || WinObjects == null)
			{
				return;
			}
			ClearWinObjects();
			int count = WinObjects.Count;
			int num = 0;
			foreach (object webObject in WebObjects)
			{
				ObjectController objectController = CreateObjectControlerBySourceObject(webObject);
				if (objectController != null && objectController.TargetObject != null)
				{
					object targetObject = objectController.TargetObject;
					mobjControllers.Add(objectController);
					if (objectController != null)
					{
						RegisterController(objectController);
					}
					if (OverrideExistWinObjects && num < count)
					{
						WinObjects[num] = targetObject;
						num++;
					}
					else
					{
						AddWinObject(targetObject);
					}
					objectController?.Initialize();
					objectController?.Load();
				}
			}
		}

		protected virtual ObjectController CreateObjectControlerBySourceObject(object objSoureceObject)
		{
			return new ObjectController(Context, objSoureceObject);
		}

		protected virtual ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
		{
			return new ObjectController(Context, null, objTargetObject);
		}

		public override void Clear()
		{
			base.Clear();
			ClearControllers();
			if (WinObjects == null || base.DesignServices == null)
			{
				return;
			}
			foreach (object winObject in WinObjects)
			{
				if (winObject is IComponent objWinComponent)
				{
					base.DesignServices.UnregisterWinComponent(objWinComponent);
				}
			}
		}

		protected virtual void ClearWinObjects()
		{
			ClearControllers();
			if (WinObjects == null)
			{
				return;
			}
			if (base.DesignMode)
			{
				foreach (object winObject in WinObjects)
				{
					if (winObject is IComponent objWinComponent)
					{
						base.DesignServices.UnregisterWinComponent(objWinComponent);
					}
				}
			}
			WinObjects.Clear();
		}

		protected virtual void ClearControllers()
		{
			foreach (ObjectController mobjController in mobjControllers)
			{
				mobjController.Clear();
				mobjController.Terminate();
				UnregisterControllerByWinObject(mobjController.TargetObject);
			}
			mobjControllers.Clear();
		}

		protected virtual int AddWinObject(object objWinObject)
		{
			if (WinObjects != null && objWinObject != null)
			{
				if (base.DesignMode && objWinObject is IComponent objWinComponent)
				{
					string strName = null;
					ObjectController controllerByWinObject = GetControllerByWinObject(objWinObject);
					if (controllerByWinObject != null && controllerByWinObject.SourceObject is IComponent { Site: not null } component)
					{
						strName = component.Site.Name;
					}
					base.DesignServices.RegisterWinComponent(objWinComponent, strName);
				}
				return WinObjects.Add(objWinObject);
			}
			return -1;
		}

		internal void SetWebObjectObjects()
		{
			if (WebObjects == null || WinObjects == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				ArrayList arrayList = new ArrayList(WebObjects);
				WebObjects.Clear();
				foreach (object winObject in WinObjects)
				{
					ObjectController objectController = ((IContextServices)Context).GetControllerByWinObject(winObject) as ObjectController;
					if (objectController == null)
					{
						objectController = CreateObjectControlerByTargetObject(winObject);
						if (objectController != null)
						{
							objectController.Initialize(base.DesignMode);
							((IContextServices)Context).RegisterController(objectController);
						}
					}
					else
					{
						objectController.UpdateSource();
					}
					if (objectController != null)
					{
						WebObjects.Add(objectController.SourceObject);
						if (arrayList.Contains(objectController.SourceObject))
						{
							arrayList.Remove(objectController.SourceObject);
						}
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		internal void SetWinObjectObjects()
		{
			if (WinObjects == null || WebObjects == null)
			{
				return;
			}
			try
			{
				SuspendNotifications();
				ArrayList arrayList = new ArrayList(WinObjects);
				WinObjectsClear();
				foreach (object webObject in WebObjects)
				{
					ObjectController objectController = ((IContextServices)Context).GetControllerByWebObject(webObject) as ObjectController;
					if (objectController == null)
					{
						objectController = CreateObjectControlerBySourceObject(webObject);
						objectController.Initialize(base.DesignMode);
						((IContextServices)Context).RegisterController(objectController);
					}
					else
					{
						objectController.UpdateTarget();
					}
					if (objectController != null)
					{
						WinObjects.Add(objectController.TargetObject);
						if (arrayList.Contains(objectController.TargetObject))
						{
							arrayList.Remove(objectController.TargetObject);
						}
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected internal virtual void WinObjectsClear()
		{
			WinObjects.Clear();
		}

		protected virtual int OnWebObjectAdded(object objWebObject)
		{
			int result = -1;
			ObjectController objectController = CreateObjectControlerBySourceObject(objWebObject);
			if (objectController.TargetObject != null)
			{
				object targetObject = objectController.TargetObject;
				mobjControllers.Add(objectController);
				if (objectController != null)
				{
					RegisterController(objectController);
				}
				objectController?.Initialize();
				result = AddWinObject(targetObject);
				objectController?.Load();
			}
			return result;
		}

		protected virtual void OnWebObjectRemoved(object objWebObject)
		{
			ObjectController controllerByWebObject = GetControllerByWebObject(objWebObject);
			if (controllerByWebObject != null)
			{
				controllerByWebObject.Clear();
				if (mobjControllers.Contains(controllerByWebObject))
				{
					mobjControllers.Remove(controllerByWebObject);
				}
				object targetObject = controllerByWebObject.TargetObject;
				RemoveWinObject(targetObject);
				UnregisterControllerByWebObject(objWebObject);
				controllerByWebObject.Terminate();
			}
		}

		protected virtual void InsertWinObject(int intIndex, object objWinObject)
		{
			if (WinObjects != null && objWinObject != null)
			{
				WinObjects.Insert(intIndex, objWinObject);
			}
		}

		protected virtual void RemoveWinObject(object objWinObject)
		{
			if (WinObjects != null && objWinObject != null)
			{
				WinObjects.Remove(objWinObject);
				if (base.DesignMode && objWinObject is IComponent objWinComponent)
				{
					base.DesignServices.UnregisterWinComponent(objWinComponent);
				}
			}
		}
	}
	public class ObjectController : IClientDesigner, IDesignerFilter, IClientObjectController
	{
		private object mobjWebObject = null;

		private object mobjWinObject = null;

		private IContext mobjContext = null;

		private bool mblnDesignSuspended = false;

		private int mintDesignSuspended = 0;

		private bool mblnDesignInitialization = false;

		private float mfltTargetVerticalScaleFactor = -1f;

		private float mfltTargetHorizontalScaleFactor = -1f;

		private static Hashtable mobjDesignTimeControllers;

		private static Hashtable mobjDesignTimeControllersSync;

		private static Hashtable mobjClientControllers;

		private static Hashtable mobjClientControllersSync;

		protected bool IsNotificationSuspened => ((IContextNotifications)Context).IsNotificationSuspened;

		protected virtual DesignerVerbCollection Verbs => new DesignerVerbCollection();

		protected bool DesignSuspended => mblnDesignSuspended;

		protected bool DesignInitialization => mblnDesignInitialization;

		protected IClientDesignServices DesignServices => ((Context)Context).DesignServices;

		protected bool DesignMode => ((Context)Context).DesignMode;

		public IContext Context => mobjContext;

		public object SourceObject => mobjWebObject;

		public object TargetObject
		{
			get
			{
				if (mobjWinObject == null)
				{
					mobjWinObject = CreateTargetObject(mobjWebObject);
					if (mobjWinObject is IContextContainer contextContainer)
					{
						contextContainer.Context = Context;
					}
				}
				return mobjWinObject;
			}
		}

		public virtual object SelectableObject => TargetObject;

		protected virtual bool UseVsMenuDeisgner
		{
			get
			{
				object targetObject = TargetObject;
				if (targetObject != null)
				{
					return targetObject.GetType().Name.IndexOf("Menu") != -1;
				}
				return false;
			}
		}

		protected float TargetVerticalScaleFactor
		{
			get
			{
				if (mfltTargetVerticalScaleFactor < 0f)
				{
					CalculateTargetScaleFactor();
				}
				return mfltTargetVerticalScaleFactor;
			}
		}

		protected float TargetHorizontalScaleFactor
		{
			get
			{
				if (mfltTargetHorizontalScaleFactor < 0f)
				{
					CalculateTargetScaleFactor();
				}
				return mfltTargetHorizontalScaleFactor;
			}
		}

		object IClientObjectController.SelectableObject => SelectableObject;

		bool IClientObjectController.UseVsMenuDeisgner => UseVsMenuDeisgner;

		public ObjectController(IContext objContext, object objWebObject)
		{
			mobjWebObject = objWebObject;
			mobjWinObject = null;
			mobjContext = objContext;
		}

		public ObjectController(IContext objContext, object objWebObject, object objWinObject)
		{
			if (objWebObject == null)
			{
				mobjWebObject = CreateSourceObject(objWinObject);
			}
			else
			{
				mobjWebObject = objWebObject;
			}
			if (objWinObject == null)
			{
				mobjWinObject = CreateTargetObject(objWebObject);
			}
			else
			{
				mobjWinObject = objWinObject;
			}
			mobjContext = objContext;
		}

		static ObjectController()
		{
			mobjDesignTimeControllers = null;
			mobjDesignTimeControllersSync = null;
			mobjClientControllers = null;
			mobjClientControllersSync = null;
			mobjDesignTimeControllers = new Hashtable();
			mobjDesignTimeControllersSync = Hashtable.Synchronized(mobjDesignTimeControllers);
			mobjClientControllers = new Hashtable();
			mobjClientControllersSync = Hashtable.Synchronized(mobjClientControllers);
		}

		public virtual void UpdateSource()
		{
		}

		public virtual void UpdateTarget()
		{
		}

		public void Initialize()
		{
			Initialize(blnDesignInitialization: false);
		}

		public virtual void InitializeNew()
		{
		}

		internal void Initialize(bool blnDesignInitialization)
		{
			mblnDesignInitialization = blnDesignInitialization;
			try
			{
				SuspendDesigner();
				InitializeController();
			}
			finally
			{
				ResumeDesigner();
			}
			mblnDesignInitialization = false;
		}

		protected virtual void InitializeController()
		{
			InitializedContained();
			WireEvents();
		}

		protected virtual void InitializedContained()
		{
		}

		public void Load()
		{
			Load(blnDesignInitialization: false);
		}

		internal void Load(bool blnDesignInitialization)
		{
			mblnDesignInitialization = blnDesignInitialization;
			try
			{
				SuspendDesigner();
				LoadController();
			}
			finally
			{
				ResumeDesigner();
			}
			mblnDesignInitialization = false;
		}

		protected virtual void LoadController()
		{
		}

		public virtual void Clear()
		{
		}

		public virtual void Terminate()
		{
			UnwireEvents();
		}

		public virtual void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
		}

		public virtual void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
		}

		protected virtual void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
		}

		protected virtual void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
		}

		protected virtual void WireEvents()
		{
			if (DesignMode)
			{
				WireDesignTimeEvents();
			}
		}

		protected virtual void WireDesignTimeEvents()
		{
		}

		protected virtual void UnwireEvents()
		{
			if (DesignMode)
			{
				UnwireDesignTimeEvents();
			}
		}

		protected virtual void UnwireDesignTimeEvents()
		{
		}

		private bool IsSubclassOf(Type objSubClass, Type objTargetClass)
		{
			bool result = false;
			if (objTargetClass != null && objSubClass != null)
			{
				result = objTargetClass == objSubClass || objSubClass.IsSubclassOf(objTargetClass);
			}
			return result;
		}

		protected virtual object CreateTargetObject(object objWebObject)
		{
			if (objWebObject != null)
			{
				Type type = objWebObject.GetType();
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.Form)))
				{
					return new ClientForm();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.UserControl)))
				{
					return new System.Windows.Forms.UserControl();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.TableLayoutPanel)))
				{
					return new System.Windows.Forms.TableLayoutPanel();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.FlowLayoutPanel)))
				{
					return new System.Windows.Forms.FlowLayoutPanel();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.ContextMenu)))
				{
					return new System.Windows.Forms.ContextMenu();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.TabPage)))
				{
					return new System.Windows.Forms.TabPage();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.Panel)))
				{
					return new ClientPanel();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.ListView)))
				{
					return new ClientListView();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.ListViewItem)))
				{
					return new ClientListViewItem();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.TreeView)))
				{
					return new ClientTreeView();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.ColumnHeader)))
				{
					return new ClientColumnHeader();
				}
				if (IsSubclassOf(type, typeof(HtmlBox)))
				{
					return new System.Windows.Forms.Panel();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.NumericUpDown)))
				{
					return new System.Windows.Forms.NumericUpDown();
				}
				if (IsSubclassOf(type, typeof(Gizmox.WebGUI.Forms.DomainUpDown)))
				{
					return new System.Windows.Forms.DomainUpDown();
				}
				string name = type.FullName.Replace("Gizmox.WebGUI.Forms", "System.Windows.Forms").Replace("HtmlBox", "Panel");
				Assembly assembly = Assembly.Load("System.Windows.Forms");
				if (assembly != null)
				{
					Type type2 = assembly.GetType(name);
					if (type2 == null)
					{
						type2 = typeof(ObjectController).Assembly.GetType(name);
					}
					if (type2 != null)
					{
						return Activator.CreateInstance(type2);
					}
				}
				if (objWebObject is IControl)
				{
					return new System.Windows.Forms.Panel();
				}
				return Activator.CreateInstance(objWebObject.GetType());
			}
			return null;
		}

		protected virtual object CreateSourceObject(object objTargetObject)
		{
			if (objTargetObject != null)
			{
				Type type = objTargetObject.GetType();
				if (IsSubclassOf(type, typeof(System.Windows.Forms.Form)))
				{
					return new Gizmox.WebGUI.Forms.Form();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.UserControl)))
				{
					return new Gizmox.WebGUI.Forms.UserControl();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.TableLayoutPanel)))
				{
					return new Gizmox.WebGUI.Forms.TableLayoutPanel();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.FlowLayoutPanel)))
				{
					return new Gizmox.WebGUI.Forms.FlowLayoutPanel();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.TabPage)))
				{
					return new Gizmox.WebGUI.Forms.TabPage();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.Panel)))
				{
					return new Gizmox.WebGUI.Forms.Panel();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.ListView)))
				{
					return new Gizmox.WebGUI.Forms.ListView();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.ListViewItem)))
				{
					return new Gizmox.WebGUI.Forms.ListViewItem();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.TreeView)))
				{
					return new Gizmox.WebGUI.Forms.TreeView();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.ColumnHeader)))
				{
					return new Gizmox.WebGUI.Forms.ColumnHeader();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewComboBoxColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewImageColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewLinkColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewButtonColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewButtonColumn();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewCheckBoxColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewTextBoxColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
				}
				if (IsSubclassOf(type, typeof(System.Windows.Forms.DataGridViewColumn)))
				{
					return new Gizmox.WebGUI.Forms.DataGridViewColumn();
				}
				string name = type.FullName.Replace("System.Windows.Forms", "Gizmox.WebGUI.Forms");
				Assembly assembly = Assembly.Load("Gizmox.WebGUI.Forms");
				if (assembly != null)
				{
					Type type2 = assembly.GetType(name);
					if (type2 == null)
					{
						type2 = typeof(ObjectController).Assembly.GetType(name);
					}
					if (type2 != null)
					{
						return Activator.CreateInstance(type2);
					}
				}
				return Activator.CreateInstance(type);
			}
			return null;
		}

		protected void SuspendDesigner()
		{
			mintDesignSuspended++;
			mblnDesignSuspended = true;
		}

		protected void ResumeDesigner()
		{
			mintDesignSuspended--;
			if (mintDesignSuspended == 0)
			{
				mblnDesignSuspended = false;
			}
		}

		protected void SuspendNotifications()
		{
			((IContextNotifications)Context).SuspendNotifications();
		}

		protected void ResumeNotifications()
		{
			((IContextNotifications)Context).ResumeNotifications();
		}

		protected void RefreshDesigner()
		{
			((IContextServices)Context).RefreshDesigner();
		}

		protected object GetWinObject(object objWebObject)
		{
			return ((IContextServices)Context).GetWinObject(objWebObject);
		}

		protected object GetWebObject(object objWinObject)
		{
			return ((IContextServices)Context).GetWebObject(objWinObject);
		}

		protected void RegisterController(ObjectController objController)
		{
			((IContextServices)Context).RegisterController(objController);
		}

		protected ObjectController GetControllerByWebObject(object objWebObject)
		{
			return ((IContextServices)Context).GetControllerByWebObject(objWebObject) as ObjectController;
		}

		protected ObjectController GetControllerByWinObject(object objWinObject)
		{
			return ((IContextServices)Context).GetControllerByWinObject(objWinObject) as ObjectController;
		}

		protected void UnregisterControllerByWebObject(object objWebObject)
		{
			((IContextServices)Context).UnregisterControllerByWebObject(objWebObject);
		}

		protected void UnregisterControllerByWinObject(object objWinObject)
		{
			((IContextServices)Context).UnregisterControllerByWinObject(objWinObject);
		}

		protected object GetConvertedEnum(Type enmTargetType, object objValue)
		{
			return GetConvertedEnum(enmTargetType, objValue, null);
		}

		protected object GetConvertedEnum(Type enmTargetType, object objValue, object objDefault)
		{
			try
			{
				if (objValue != null)
				{
					string value = objValue.ToString();
					return Enum.Parse(enmTargetType, value);
				}
				return objDefault;
			}
			catch (Exception)
			{
				return objDefault;
			}
		}

		protected int GetWinImageIndex(System.Windows.Forms.ImageList objWinImagelist, ResourceHandle objResourceHandler, string strKey)
		{
			return ((IContextResources)Context).GetWinImageIndex(objWinImagelist, objResourceHandler, strKey);
		}

		protected int GetWinImageIndex(System.Windows.Forms.ImageList objWinImagelist, ResourceHandle objResourceHandler)
		{
			return ((IContextResources)Context).GetWinImageIndex(objWinImagelist, objResourceHandler);
		}

		protected Stream GetGatewayResourceStream(GatewayResourceHandle objGatewayResourceHandle)
		{
			return ((IContextResources)Context).GetGatewayResourceStream(objGatewayResourceHandle);
		}

		protected Image GetWinImageFromResourceHandle(ResourceHandle objResourceHandler)
		{
			return ((IContextResources)Context).GetWinImageFromResourceHandle(objResourceHandler);
		}

		protected virtual void PostFilterAttributes(IDictionary attributes)
		{
		}

		protected virtual void PostFilterEvents(IDictionary events)
		{
		}

		protected virtual void PostFilterProperties(IDictionary properties)
		{
		}

		protected virtual void PreFilterAttributes(IDictionary attributes)
		{
		}

		protected virtual void PreFilterEvents(IDictionary events)
		{
		}

		protected virtual void PreFilterProperties(IDictionary properties)
		{
		}

		void IDesignerFilter.PostFilterAttributes(IDictionary attributes)
		{
			PostFilterAttributes(attributes);
		}

		void IDesignerFilter.PostFilterEvents(IDictionary events)
		{
			PostFilterAttributes(events);
		}

		void IDesignerFilter.PostFilterProperties(IDictionary properties)
		{
			PostFilterAttributes(properties);
		}

		void IDesignerFilter.PreFilterAttributes(IDictionary attributes)
		{
			PostFilterAttributes(attributes);
		}

		void IDesignerFilter.PreFilterEvents(IDictionary events)
		{
			PostFilterAttributes(events);
		}

		void IDesignerFilter.PreFilterProperties(IDictionary properties)
		{
			PostFilterAttributes(properties);
		}

		DesignerVerbCollection IClientDesigner.GetVerbs()
		{
			return Verbs;
		}

		internal static ObjectController CreateControllerByWebType(IContext objContext, Type objWebType)
		{
			object obj = Activator.CreateInstance(objWebType);
			if (obj != null)
			{
				IClientDesignServices designServices = ((Context)objContext).DesignServices;
				if (designServices != null && obj is IComponent { Site: null } component)
				{
					designServices.RegisterWebComponent(component);
				}
				return CreateControllerByWebObject(objContext, obj);
			}
			return null;
		}

		internal static ObjectController CreateTypeController(IContext objContext, Type objWebType, object objWebObject)
		{
			Type type = null;
			if (((Context)objContext).DesignMode)
			{
				if (!mobjDesignTimeControllersSync.Contains(objWebType))
				{
					AttributeCollection attributes = TypeDescriptor.GetAttributes(objWebType);
					foreach (Attribute item in attributes)
					{
						if (item is DesignTimeControllerAttribute designTimeControllerAttribute)
						{
							type = (Type)(mobjDesignTimeControllersSync[objWebType] = designTimeControllerAttribute.Type);
							break;
						}
					}
					if (type == null)
					{
						mobjDesignTimeControllersSync[objWebType] = null;
					}
				}
				else
				{
					type = mobjDesignTimeControllersSync[objWebType] as Type;
				}
			}
			else if (!mobjClientControllersSync.Contains(objWebType))
			{
				AttributeCollection attributes2 = TypeDescriptor.GetAttributes(objWebType);
				foreach (Attribute item2 in attributes2)
				{
					if (item2 is ClientControllerAttribute clientControllerAttribute)
					{
						type = (Type)(mobjClientControllersSync[objWebType] = clientControllerAttribute.Type);
						break;
					}
				}
				if (type == null)
				{
					mobjClientControllersSync[objWebType] = null;
				}
			}
			else
			{
				type = mobjClientControllersSync[objWebType] as Type;
			}
			if (type != null)
			{
				return Activator.CreateInstance(type, objContext, objWebObject) as ObjectController;
			}
			return null;
		}

		public static ObjectController CreateControllerByWebObject(IContext objContext, object objWebObject)
		{
			Type type = objWebObject.GetType();
			ObjectController objectController = CreateTypeController(objContext, type, objWebObject);
			if (objectController != null)
			{
				return objectController;
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ContextMenu)
			{
				return new ContextMenuController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.MainMenu)
			{
				return new MainMenuController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.Form)
			{
				return new FormController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.UserControl)
			{
				return new UserControlController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TreeView)
			{
				return new TreeViewController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TreeView)
			{
				return new TreeViewController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TableLayoutPanel)
			{
				return new TableLayoutPanelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TrackBar)
			{
				return new TrackBarController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TabControl)
			{
				return new TabControlController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.PictureBox)
			{
				return new PictureBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.DataGridView)
			{
				return new DataGridViewController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.DataGridViewColumn)
			{
				return new DataGidViewColumnController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.PropertyGrid)
			{
				return new PropertyGridController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.FlowLayoutPanel)
			{
				return new FlowLayoutPanelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolBar)
			{
				return new ToolBarController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TextBox)
			{
				return new TextBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.RadioButton)
			{
				return new RadioButtonController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.CheckBox)
			{
				return new CheckBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.Button)
			{
				return new ButtonController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.UserControl)
			{
				return new UserControlController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ListView)
			{
				return new ListViewController(objContext, objWebObject);
			}
			if (objWebObject is ColorListBox)
			{
				return new ControlController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ListBox)
			{
				return new ListBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ComboBox)
			{
				return new ComboBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.TabPage)
			{
				return new ControlController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.Panel)
			{
				return new PanelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.Label)
			{
				return new LabelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.StatusStrip)
			{
				return new StatusStripController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ContextMenuStrip)
			{
				return new ContextMenuStripController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownMenu)
			{
				return new ToolStripDropDownMenuController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDown)
			{
				return new ToolStripDropDownController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.MenuStrip)
			{
				return new MenuStripController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStrip)
			{
				return new ToolStripController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripContainer)
			{
				return new ToolStripContainerController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripPanel)
			{
				return new ToolStripPanelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripButton)
			{
				return new ToolStripButtonController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripComboBox)
			{
				return new ToolStripComboBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownButton)
			{
				return new ToolStripDropDownButtonController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripLabel)
			{
				return new ToolStripLabelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripMenuItem)
			{
				return new ToolStripMenuItemController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripProgressBar)
			{
				return new ToolStripProgressBarController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSeparator)
			{
				return new ToolStripSeparatorController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSplitButton)
			{
				return new ToolStripSplitButtonController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripStatusLabel)
			{
				return new ToolStripStatusLabelController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripTextBox)
			{
				return new ToolStripTextBoxController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.Control)
			{
				return new ControlController(objContext, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.Component)
			{
				return new ObjectController(objContext, objWebObject);
			}
			return new GenericComponentController(objContext, objWebObject);
		}

		public static ObjectController CreateControllerByWinObject(IContext objContext, object objWinObject)
		{
			if (objWinObject is System.Windows.Forms.ContextMenu)
			{
				return new ContextMenuController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.MainMenu)
			{
				return new MainMenuController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.Form)
			{
				return new FormController(objContext, null, objWinObject as System.Windows.Forms.Form);
			}
			if (objWinObject is System.Windows.Forms.UserControl)
			{
				return new UserControlController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TreeView)
			{
				return new TreeViewController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TreeView)
			{
				return new TreeViewController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TableLayoutPanel)
			{
				return new TableLayoutPanelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TrackBar)
			{
				return new TrackBarController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TabControl)
			{
				return new TabControlController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.PictureBox)
			{
				return new PictureBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.DataGridView)
			{
				return new DataGridViewController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.DataGridViewColumn)
			{
				return new DataGidViewColumnController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.PropertyGrid)
			{
				return new PropertyGridController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.FlowLayoutPanel)
			{
				return new FlowLayoutPanelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolBar)
			{
				return new ToolBarController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TextBox)
			{
				return new TextBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.RadioButton)
			{
				return new RadioButtonController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.CheckBox)
			{
				return new CheckBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.Button)
			{
				return new ButtonController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.UserControl)
			{
				return new UserControlController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ListView)
			{
				return new ListViewController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ListBox)
			{
				return new ListBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ComboBox)
			{
				return new ComboBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.TabPage)
			{
				return new ControlController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.Panel)
			{
				return new PanelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.Label)
			{
				return new LabelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.StatusStrip)
			{
				return new StatusStripController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ContextMenuStrip)
			{
				return new ContextMenuStripController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripDropDownMenu)
			{
				return new ToolStripDropDownMenuController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripDropDown)
			{
				return new ToolStripDropDownController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.MenuStrip)
			{
				return new MenuStripController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStrip)
			{
				return new ToolStripController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripContainer)
			{
				return new ToolStripContainerController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripPanel)
			{
				return new ToolStripPanelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripButton)
			{
				return new ToolStripButtonController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripDropDownButton)
			{
				return new ToolStripDropDownButtonController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripMenuItem)
			{
				return new ToolStripMenuItemController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripSeparator)
			{
				return new ToolStripSeparatorController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripSplitButton)
			{
				return new ToolStripSplitButtonController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripStatusLabel)
			{
				return new ToolStripStatusLabelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripLabel)
			{
				return new ToolStripLabelController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripTextBox)
			{
				return new ToolStripTextBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripProgressBar)
			{
				return new ToolStripProgressBarController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.ToolStripComboBox)
			{
				return new ToolStripComboBoxController(objContext, null, objWinObject);
			}
			if (objWinObject is System.Windows.Forms.Control)
			{
				return new ControlController(objContext, null, objWinObject);
			}
			if (objWinObject is IComponent)
			{
				return new GenericComponentController(objContext, null, (IComponent)objWinObject);
			}
			return new ObjectController(objContext, null, objWinObject);
		}

		private void CalculateTargetScaleFactor()
		{
			IClientDesignServices designServices = ((Context)Context).DesignServices;
			if (designServices != null)
			{
				SizeF formScaleFactor = designServices.GetFormScaleFactor(null);
				if (!formScaleFactor.IsEmpty)
				{
					mfltTargetHorizontalScaleFactor = formScaleFactor.Width;
					mfltTargetVerticalScaleFactor = formScaleFactor.Height;
				}
				else
				{
					mfltTargetHorizontalScaleFactor = 1f;
					mfltTargetVerticalScaleFactor = 1f;
				}
			}
		}

		void IClientObjectController.SetParent(IClientObjectController objController)
		{
			SetParentController((ObjectController)objController);
		}

		protected virtual void SetParentController(ObjectController objController)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ReplaceSource(object objSource)
		{
			if (DesignMode)
			{
				UnregisterControllerByWebObject(mobjWebObject);
				mobjWebObject = objSource;
				RegisterController(this);
				Initialize(blnDesignInitialization: true);
			}
		}
	}
	public class PanelController : ScrollableControlController
	{
		public Gizmox.WebGUI.Forms.Panel WebPanel => base.SourceObject as Gizmox.WebGUI.Forms.Panel;

		public System.Windows.Forms.Panel WinPanel => base.TargetObject as System.Windows.Forms.Panel;

		public ClientPanel WinClientPanel => base.TargetObject as ClientPanel;

		public PanelController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public PanelController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinPanelPanelType();
			SetWinControlBorderStyle();
		}

		protected virtual void SetWinPanelPanelType()
		{
			if (WinClientPanel != null && !base.DesignMode)
			{
				WinClientPanel.PanelType = WebPanel.PanelType;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientPanel();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWinControlAutoSize();
				break;
			case "AutoSizeMode":
				SetWinControlAutoSizeMode();
				break;
			case "BorderStyle":
				SetWinControlBorderStyle();
				break;
			}
		}

		protected override void SetWinControlBorderStyle()
		{
			if (Enum.GetName(typeof(System.Windows.Forms.BorderStyle), WebPanel.BorderStyle) != null)
			{
				WinPanel.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebPanel.BorderStyle, WinPanel.BorderStyle);
			}
		}

		protected override void SetWebControlBorderStyle()
		{
			WebPanel.BorderStyle = (Gizmox.WebGUI.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WinPanel.BorderStyle, WebPanel.BorderStyle);
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWebControlAutoSize();
				break;
			case "AutoSizeMode":
				SetWebControlAutoSizeMode();
				break;
			case "BorderStyle":
				SetWebControlAutoSize();
				break;
			}
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			SetWinControlAutoSize();
			SetWebControlAutoSize();
			SetWinControlAutoSizeMode();
			SetWebControlAutoSizeMode();
		}

		protected new virtual void SetWinControlAutoSize()
		{
			WinPanel.AutoSize = WebPanel.AutoSize;
		}

		protected virtual void SetWebControlAutoSize()
		{
			WebPanel.AutoSize = WinPanel.AutoSize;
		}

		protected virtual void SetWinControlAutoSizeMode()
		{
			WinPanel.AutoSizeMode = (System.Windows.Forms.AutoSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.AutoSizeMode), WebPanel.AutoSizeMode);
		}

		protected virtual void SetWebControlAutoSizeMode()
		{
			WebPanel.AutoSizeMode = (Gizmox.WebGUI.Forms.AutoSizeMode)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.AutoSizeMode), WinPanel.AutoSizeMode);
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}
	}
	public class PictureBoxController : ControlController
	{
		public Gizmox.WebGUI.Forms.PictureBox WebPictureBox => base.SourceObject as Gizmox.WebGUI.Forms.PictureBox;

		public System.Windows.Forms.PictureBox WinPictureBox => base.TargetObject as System.Windows.Forms.PictureBox;

		public PictureBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public PictureBoxController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinPictureBoxImage();
			SetWinPictureBoxSizeMode();
		}

		protected virtual void SetWinPictureBoxImage()
		{
			if (WebPictureBox.Image != null)
			{
				WinPictureBox.Image = GetWinImageFromResourceHandle(WebPictureBox.Image);
			}
			else
			{
				WinPictureBox.Image = null;
			}
		}

		protected virtual void SetWinPictureBoxSizeMode()
		{
			WinPictureBox.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.PictureBoxSizeMode), WebPictureBox.SizeMode, WebPictureBox.SizeMode);
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinPictureBox.SizeModeChanged -= WinPictureBox_SizeModeChanged;
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinPictureBox.SizeModeChanged += WinPictureBox_SizeModeChanged;
		}

		private void WinPictureBox_SizeModeChanged(object sender, EventArgs e)
		{
			if (WinPictureBox.SizeMode == System.Windows.Forms.PictureBoxSizeMode.AutoSize)
			{
				SetWebControlSize();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.PictureBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "Image"))
			{
				if (property == "SizeMode")
				{
					SetWinPictureBoxSizeMode();
				}
			}
			else
			{
				SetWinPictureBoxImage();
			}
		}
	}
	public class PropertyGridController : ControlController
	{
		public Gizmox.WebGUI.Forms.PropertyGrid WebPropertyGrid => base.SourceObject as Gizmox.WebGUI.Forms.PropertyGrid;

		public System.Windows.Forms.PropertyGrid WinPropertyGrid => base.TargetObject as System.Windows.Forms.PropertyGrid;

		public PropertyGridController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public PropertyGridController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinPropertyGridSelectedObjects();
			SetWinPropertyGridHelpVisible();
			SetWinPropertyGridPropertySort();
		}

		protected virtual void SetWinPropertyGridHelpVisible()
		{
			WinPropertyGrid.HelpVisible = WebPropertyGrid.HelpVisible;
		}

		protected virtual void SetWinPropertyGridSelectedObjects()
		{
			WinPropertyGrid.SelectedObjects = WebPropertyGrid.SelectedObjects;
		}

		private void SetWinPropertyGridPropertySort()
		{
			WinPropertyGrid.PropertySort = (System.Windows.Forms.PropertySort)GetConvertedEnum(typeof(System.Windows.Forms.PropertySort), WebPropertyGrid.PropertySort);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.PropertyGrid();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "SelectedObjects":
				SetWinPropertyGridSelectedObjects();
				break;
			case "SelectedObject":
				SetWinPropertyGridSelectedObjects();
				break;
			case "HelpVisible":
				SetWinPropertyGridHelpVisible();
				break;
			case "PropertySort":
				SetWinPropertyGridPropertySort();
				break;
			}
		}
	}
	public class RadioButtonController : ButtonBaseControler
	{
		public Gizmox.WebGUI.Forms.RadioButton WebRadioButton => base.SourceObject as Gizmox.WebGUI.Forms.RadioButton;

		public System.Windows.Forms.RadioButton WinRadioButton => base.TargetObject as System.Windows.Forms.RadioButton;

		public RadioButtonController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
		}

		public RadioButtonController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinRadioButtonChecked();
			SetWinCheckAlign();
			SetWinAppearance();
		}

		protected virtual void SetWinCheckAlign()
		{
			WinRadioButton.CheckAlign = WebRadioButton.CheckAlign;
		}

		protected virtual void SetWinAppearance()
		{
			WinRadioButton.Appearance = (System.Windows.Forms.Appearance)GetConvertedEnum(typeof(System.Windows.Forms.Appearance), WebRadioButton.Appearance);
		}

		protected virtual void SetWebCheckAlign()
		{
			WebRadioButton.CheckAlign = WinRadioButton.CheckAlign;
		}

		protected virtual void SetWinRadioButtonChecked()
		{
			WinRadioButton.Checked = WebRadioButton.Checked;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.RadioButton();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinRadioButton.CheckedChanged += WinCheckBox_CheckedChanged;
		}

		private void WinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinRadioButton.CheckedChanged -= WinCheckBox_CheckedChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Checked":
				SetWinRadioButtonChecked();
				break;
			case "CheckAlign":
				SetWinCheckAlign();
				break;
			case "Appearance":
				SetWinAppearance();
				break;
			}
		}
	}
	public class ScrollableControlController : ControlController
	{
		public Gizmox.WebGUI.Forms.ScrollableControl WebScrollableControl => base.SourceObject as Gizmox.WebGUI.Forms.ScrollableControl;

		public System.Windows.Forms.ScrollableControl WinScrollableControl => base.TargetObject as System.Windows.Forms.ScrollableControl;

		public ScrollableControlController(IContext objContext, object objWebScrollableControl, object objWinScrollableControl)
			: base(objContext, objWebScrollableControl, objWinScrollableControl)
		{
		}

		public ScrollableControlController(IContext objContext, object objWebScrollableControl)
			: base(objContext, objWebScrollableControl)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinScrollableControlAutoScroll();
			SuspendNotifications();
			try
			{
				SetWinScrollableControlDockPadding();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetWinScrollableControlAutoScroll()
		{
			WinScrollableControl.AutoScroll = WebScrollableControl.AutoScroll;
		}

		protected void SetWinScrollableControlDockPadding()
		{
			WinScrollableControl.DockPadding.Bottom = WebScrollableControl.DockPadding.Bottom;
			WinScrollableControl.DockPadding.Top = WebScrollableControl.DockPadding.Top;
			WinScrollableControl.DockPadding.Right = WebScrollableControl.DockPadding.Right;
			WinScrollableControl.DockPadding.Left = WebScrollableControl.DockPadding.Left;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ScrollableControl();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "DockPadding":
				SetWinScrollableControlDockPadding();
				break;
			case "AutoScroll":
				SetWinScrollableControlAutoScroll();
				break;
			case "Unknown":
				SetWinScrollableControlDockPadding();
				break;
			}
		}
	}
	public class StatusStripController : ToolStripController
	{
		public StatusStripController(IContext objContext, object objWebStatusStrip, object objWinStatusStrip)
			: base(objContext, objWebStatusStrip, objWinStatusStrip)
		{
		}

		public StatusStripController(IContext objContext, object objWebStatusStrip)
			: base(objContext, objWebStatusStrip)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.StatusStrip();
		}
	}
	public class TabControlController : ControlController
	{
		public Gizmox.WebGUI.Forms.TabControl WebTabControl => base.SourceObject as Gizmox.WebGUI.Forms.TabControl;

		public System.Windows.Forms.TabControl WinTabControl => base.TargetObject as System.Windows.Forms.TabControl;

		public TabControlController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public TabControlController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTabControlSelectedIndex();
		}

		protected virtual void SetWinTabControlSelectedIndex()
		{
			WinTabControl.SelectedIndex = WebTabControl.SelectedIndex;
		}

		protected virtual void SetTargetTabControlSelectedIndex()
		{
			WinTabControl.Multiline = WebTabControl.Multiline;
		}

		protected virtual void SetSourceTabControlSelectedIndex()
		{
			WebTabControl.Multiline = WinTabControl.Multiline;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "SelectedIndex":
				SetWinTabControlSelectedIndex();
				break;
			case "TabPages":
				SetWinControlControls();
				break;
			case "Multiline":
				SetTargetTabControlSelectedIndex();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Multiline")
			{
				SetSourceTabControlSelectedIndex();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TabControl();
		}
	}
	public class ColumnStyleController : TableLayoutStyleController
	{
		public System.Windows.Forms.ColumnStyle TargetColumnStyle => base.TargetObject as System.Windows.Forms.ColumnStyle;

		public Gizmox.WebGUI.Forms.ColumnStyle SourceColumnStyle => base.SourceObject as Gizmox.WebGUI.Forms.ColumnStyle;

		public ColumnStyleController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public ColumnStyleController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			Gizmox.WebGUI.Forms.ColumnStyle columnStyle = objSourceObject as Gizmox.WebGUI.Forms.ColumnStyle;
			return new System.Windows.Forms.ColumnStyle((System.Windows.Forms.SizeType)GetConvertedEnum(typeof(System.Windows.Forms.SizeType), columnStyle.SizeType), columnStyle.Width);
		}

		protected override object CreateSourceObject(object objTargetObject)
		{
			System.Windows.Forms.ColumnStyle columnStyle = objTargetObject as System.Windows.Forms.ColumnStyle;
			return new Gizmox.WebGUI.Forms.ColumnStyle((Gizmox.WebGUI.Forms.SizeType)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.SizeType), columnStyle.SizeType), columnStyle.Width);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			if (base.DesignInitialization)
			{
				SetSourceColumnStyleWidth();
			}
			else
			{
				SetTargetColumnStyleWidth();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetSourceColumnStyleWidth();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetTargetColumnStyleWidth();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Width")
			{
				SetSourceColumnStyleWidth();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Width")
			{
				SetTargetColumnStyleWidth();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetSourceColumnStyleWidth()
		{
			SourceColumnStyle.Width = TargetColumnStyle.Width;
		}

		protected virtual void SetTargetColumnStyleWidth()
		{
			TargetColumnStyle.Width = SourceColumnStyle.Width;
		}
	}
	public abstract class LayoutSettingsController : ObjectController
	{
		public System.Windows.Forms.LayoutSettings TargetLayoutSettings => base.TargetObject as System.Windows.Forms.LayoutSettings;

		public Gizmox.WebGUI.Forms.LayoutSettings SourceLayoutSettings => base.SourceObject as Gizmox.WebGUI.Forms.LayoutSettings;

		public LayoutSettingsController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public LayoutSettingsController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return base.CreateTargetObject(objSourceObject);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}
	}
	public class RowStyleController : TableLayoutStyleController
	{
		public System.Windows.Forms.RowStyle TargetRowStyle => base.TargetObject as System.Windows.Forms.RowStyle;

		public Gizmox.WebGUI.Forms.RowStyle SourceRowStyle => base.SourceObject as Gizmox.WebGUI.Forms.RowStyle;

		public RowStyleController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public RowStyleController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			Gizmox.WebGUI.Forms.RowStyle rowStyle = objSourceObject as Gizmox.WebGUI.Forms.RowStyle;
			return new System.Windows.Forms.RowStyle((System.Windows.Forms.SizeType)GetConvertedEnum(typeof(System.Windows.Forms.SizeType), rowStyle.SizeType), rowStyle.Height);
		}

		protected override object CreateSourceObject(object objTargetObject)
		{
			System.Windows.Forms.RowStyle rowStyle = objTargetObject as System.Windows.Forms.RowStyle;
			return new Gizmox.WebGUI.Forms.RowStyle((Gizmox.WebGUI.Forms.SizeType)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.SizeType), rowStyle.SizeType), rowStyle.Height);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			if (base.DesignInitialization)
			{
				SetSourceRowStyleHeight();
			}
			else
			{
				SetTargetRowStyleHeight();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetSourceRowStyleHeight();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetTargetRowStyleHeight();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Height")
			{
				SetSourceRowStyleHeight();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Height")
			{
				SetTargetRowStyleHeight();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetSourceRowStyleHeight()
		{
			SourceRowStyle.Height = TargetRowStyle.Height;
		}

		protected virtual void SetTargetRowStyleHeight()
		{
			TargetRowStyle.Height = SourceRowStyle.Height;
		}
	}
	public class TableLayoutColumnStyleCollectionController : TableLayoutStyleCollectionController
	{
		public System.Windows.Forms.TableLayoutColumnStyleCollection TargetTableLayoutColumnStyleCollection => base.TargetObject as System.Windows.Forms.TableLayoutColumnStyleCollection;

		public Gizmox.WebGUI.Forms.TableLayoutColumnStyleCollection SourceTableLayoutColumnStyleCollection => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutColumnStyleCollection;

		public TableLayoutColumnStyleCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList)
			: base(objContext, objSourceObject, objSourceList, objTargetObject, objTargetList)
		{
		}

		protected override ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
		{
			return new ColumnStyleController(base.Context, null, objTargetObject);
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
			return new ColumnStyleController(base.Context, objSourceObject);
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return new System.Windows.Forms.ColumnStyle();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}
	}
	public class TableLayoutControlCollectionController : ControlCollectionController
	{
		public System.Windows.Forms.TableLayoutControlCollection TargetTableLayoutControlCollection => base.TargetObject as System.Windows.Forms.TableLayoutControlCollection;

		public Gizmox.WebGUI.Forms.TableLayoutControlCollection SourceTableLayoutControlCollection => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutControlCollection;

		public TableLayoutControlCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList)
			: base(objContext, objSourceObject, objSourceList, objTargetObject, objTargetList)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
			return base.CreateObjectControlerBySourceObject(objSourceObject);
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return base.CreateTargetObject(objSourceObject);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
	}
	public class TableLayoutPanelController : ControlController
	{
		private TableLayoutRowStyleCollectionController mobjRowStylesController = null;

		private TableLayoutColumnStyleCollectionController mobjColumnStylesController = null;

		private TableLayoutSettingsController mobjTableLayoutSettingsController = null;

		public System.Windows.Forms.TableLayoutPanel TargetTableLayoutPanel => base.TargetObject as System.Windows.Forms.TableLayoutPanel;

		public Gizmox.WebGUI.Forms.TableLayoutPanel SourceTableLayoutPanel => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutPanel;

		public TableLayoutPanelController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.RowStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.ColumnStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.ColumnStyles);
			mobjTableLayoutSettingsController = new TableLayoutSettingsController(objContext, SourceTableLayoutPanel.LayoutSettings, TargetTableLayoutPanel.LayoutSettings);
		}

		public TableLayoutPanelController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.RowStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutPanel, SourceTableLayoutPanel.ColumnStyles, TargetTableLayoutPanel, TargetTableLayoutPanel.ColumnStyles);
			mobjTableLayoutSettingsController = new TableLayoutSettingsController(objContext, SourceTableLayoutPanel.LayoutSettings, TargetTableLayoutPanel.LayoutSettings);
		}

		protected override void InitializedContained()
		{
			try
			{
				SuspendNotifications();
				base.InitializedContained();
				mobjColumnStylesController.Initialize();
				mobjRowStylesController.Initialize();
				mobjTableLayoutSettingsController.Initialize();
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return new System.Windows.Forms.TableLayoutPanel();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			try
			{
				TargetTableLayoutPanel.SuspendLayout();
				SetTargetTableLayoutPanelBorderStyle();
				SetTargetTableLayoutPanelGrowStyle();
				SetTargetTableLayoutPanelControlsPositions();
				SetTargetTableLayoutPanelColumnStyles();
				SetTargetTableLayoutPanelRowStyles();
				SetTargetTableLayoutPanelColumnCount();
				SetTargetTableLayoutPanelRowCount();
				SetTargetTableLayoutPanelCellBorderStyle();
			}
			finally
			{
				TargetTableLayoutPanel.ResumeLayout(performLayout: false);
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjColumnStylesController != null)
			{
				mobjColumnStylesController.Terminate();
			}
			if (mobjRowStylesController != null)
			{
				mobjRowStylesController.Terminate();
			}
			if (mobjTableLayoutSettingsController != null)
			{
				mobjTableLayoutSettingsController.Terminate();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "BorderStyle":
				SetSourceTableLayoutPanelBorderStyle();
				break;
			case "CellBorderStyle":
				SetSourceTableLayoutPanelCellBorderStyle();
				break;
			case "ColumnCount":
				SetSourceTableLayoutPanelColumnCount();
				break;
			case "GrowStyle":
				SetSourceTableLayoutPanelGrowStyle();
				break;
			case "RowCount":
				SetSourceTableLayoutPanelRowCount();
				break;
			case "ControlPositions":
				SetSourceTableLayoutPanelControlPositions((System.Windows.Forms.Control)objPropertyChangeArgs.Subject);
				break;
			case "RowStyles":
			case "ColumnStyles":
				SetSourceTableLayoutPanelRowStyles();
				SetSourceTableLayoutPanelColumnStyles();
				break;
			case "Controls":
				try
				{
					SuspendNotifications();
					base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
					break;
				}
				finally
				{
					ResumeNotifications();
				}
			default:
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "BorderStyle":
				SetTargetTableLayoutPanelBorderStyle();
				break;
			case "CellBorderStyle":
				SetTargetTableLayoutPanelCellBorderStyle();
				break;
			case "ColumnCount":
				SetTargetTableLayoutPanelColumnCount();
				break;
			case "GrowStyle":
				SetTargetTableLayoutPanelGrowStyle();
				break;
			case "RowCount":
				SetTargetTableLayoutPanelRowCount();
				break;
			case "RowStyles":
				SetTargetTableLayoutPanelRowStyles();
				break;
			case "ColumnStyles":
				SetTargetTableLayoutPanelColumnStyles();
				break;
			case "Controls":
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				SetTargetTableLayoutPanelControlsPositions();
				break;
			default:
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlAdded += TableLayoutPanelController_ControlAdded;
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlRemoved += TableLayoutPanelController_ControlRemoved;
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlAdded -= TableLayoutPanelController_ControlAdded;
			((System.Windows.Forms.TableLayoutPanel)base.WinComponent).ControlRemoved -= TableLayoutPanelController_ControlRemoved;
		}

		private void TableLayoutPanelController_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				control.LocationChanged -= objControl_LocationChanged;
			}
		}

		private void TableLayoutPanelController_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			System.Windows.Forms.Control control = e.Control;
			if (control != null)
			{
				control.LocationChanged += objControl_LocationChanged;
			}
		}

		private void objControl_LocationChanged(object sender, EventArgs e)
		{
			if (sender is System.Windows.Forms.Control sourceTableLayoutPanelControlPositions)
			{
				SetSourceTableLayoutPanelControlPositions(sourceTableLayoutPanelControlPositions);
			}
		}

		protected virtual void SetTargetTableLayoutPanelControlsPositions()
		{
			try
			{
				SuspendNotifications();
				if (SourceTableLayoutPanel == null || SourceTableLayoutPanel.Controls == null)
				{
					return;
				}
				foreach (Gizmox.WebGUI.Forms.Control control in SourceTableLayoutPanel.Controls)
				{
					if (GetControllerByWebObject(control) is ControlController objControlController)
					{
						SetTargetTableLayoutPanelCellPosition(control, objControlController);
						SetTargetTableLayoutPanelColumnSpan(control, objControlController);
						SetTargetTableLayoutPanelRowSpan(control, objControlController);
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetTargetTableLayoutPanelColumnStyles()
		{
			mobjColumnStylesController.SetWinObjectObjects();
		}

		protected virtual void SetTargetTableLayoutPanelRowStyles()
		{
			mobjRowStylesController.SetWinObjectObjects();
		}

		protected virtual void SetTargetTableLayoutPanelBorderStyle()
		{
			TargetTableLayoutPanel.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), SourceTableLayoutPanel.BorderStyle);
		}

		protected virtual void SetTargetTableLayoutPanelCellBorderStyle()
		{
			TargetTableLayoutPanel.CellBorderStyle = (System.Windows.Forms.TableLayoutPanelCellBorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.TableLayoutPanelCellBorderStyle), SourceTableLayoutPanel.CellBorderStyle);
		}

		protected virtual void SetTargetTableLayoutPanelColumnCount()
		{
			SetWinProperty("ColumnCount", SourceTableLayoutPanel.ColumnCount);
		}

		protected virtual void SetTargetTableLayoutPanelGrowStyle()
		{
			TargetTableLayoutPanel.GrowStyle = (System.Windows.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(System.Windows.Forms.TableLayoutPanelGrowStyle), SourceTableLayoutPanel.GrowStyle);
		}

		protected virtual void SetTargetTableLayoutPanelRowCount()
		{
			SetWinProperty("RowCount", SourceTableLayoutPanel.RowCount);
		}

		protected virtual void SetTargetTableLayoutPanelCellPosition(object objSubject, ControlController objControlController)
		{
			Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition cellPosition = SourceTableLayoutPanel.GetCellPosition((Gizmox.WebGUI.Forms.Control)objSubject);
			bool flag = true;
			TargetTableLayoutPanel.SetCellPosition((System.Windows.Forms.Control)objControlController.TargetObject, new System.Windows.Forms.TableLayoutPanelCellPosition(cellPosition.Column, cellPosition.Row));
		}

		protected virtual void SetTargetTableLayoutPanelColumn(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetColumn((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetColumn((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetTargetTableLayoutPanelRow(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetRow((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetRow((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetTargetTableLayoutPanelColumnSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetColumnSpan((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetColumnSpan((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetTargetTableLayoutPanelRowSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				TargetTableLayoutPanel.SetRowSpan((System.Windows.Forms.Control)objControlController.TargetObject, SourceTableLayoutPanel.GetRowSpan((Gizmox.WebGUI.Forms.Control)objSubject));
			}
		}

		protected virtual void SetSourceTableLayoutPanelBorderStyle()
		{
			SourceTableLayoutPanel.BorderStyle = (Gizmox.WebGUI.Forms.BorderStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.BorderStyle), TargetTableLayoutPanel.BorderStyle);
		}

		protected virtual void SetSourceTableLayoutPanelCellBorderStyle()
		{
			SourceTableLayoutPanel.CellBorderStyle = (Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle), TargetTableLayoutPanel.CellBorderStyle);
		}

		protected virtual void SetSourceTableLayoutPanelColumnCount()
		{
			SourceTableLayoutPanel.ColumnCount = TargetTableLayoutPanel.ColumnCount;
		}

		protected virtual void SetSourceTableLayoutPanelGrowStyle()
		{
			SourceTableLayoutPanel.GrowStyle = (Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle), TargetTableLayoutPanel.GrowStyle);
		}

		protected virtual void SetSourceTableLayoutPanelRowCount()
		{
			SourceTableLayoutPanel.RowCount = TargetTableLayoutPanel.RowCount;
		}

		protected virtual void SetSourceTableLayoutPanelColumnStyles()
		{
			mobjColumnStylesController.SetWebObjectObjects();
		}

		protected virtual void SetSourceTableLayoutPanelRowStyles()
		{
			mobjRowStylesController.SetWebObjectObjects();
		}

		protected virtual void SetSourceTableLayoutPanelControlsPositions()
		{
			try
			{
				SuspendNotifications();
				if (TargetTableLayoutPanel == null || TargetTableLayoutPanel.Controls == null)
				{
					return;
				}
				foreach (System.Windows.Forms.Control control in TargetTableLayoutPanel.Controls)
				{
					if (GetControllerByWinObject(control) is ControlController objControlController)
					{
						SetSourceTableLayoutPanelCellPosition(control, objControlController);
						SetSourceTableLayoutPanelColumnSpan(control, objControlController);
						SetSourceTableLayoutPanelRowSpan(control, objControlController);
					}
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetSourceTableLayoutPanelControlPositions(System.Windows.Forms.Control objControl)
		{
			try
			{
				SuspendNotifications();
				if (SourceTableLayoutPanel != null && SourceTableLayoutPanel.Controls != null && GetControllerByWinObject(objControl) is ControlController objControlController)
				{
					SetSourceTableLayoutPanelCellPosition(objControl, objControlController);
					SetSourceTableLayoutPanelColumnSpan(objControl, objControlController);
					SetSourceTableLayoutPanelRowSpan(objControl, objControlController);
				}
			}
			finally
			{
				ResumeNotifications();
			}
		}

		protected virtual void SetSourceTableLayoutPanelCellPosition(object objSubject, ControlController objControlController)
		{
			System.Windows.Forms.TableLayoutPanelCellPosition cellPosition = TargetTableLayoutPanel.GetCellPosition((System.Windows.Forms.Control)objSubject);
			bool flag = true;
			Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition cellPosition2 = SourceTableLayoutPanel.GetCellPosition((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject);
			if (cellPosition2.Column != cellPosition.Column || cellPosition2.Row != cellPosition.Row)
			{
				SourceTableLayoutPanel.SetCellPosition((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject, new Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition(cellPosition.Column, cellPosition.Row));
			}
		}

		protected virtual void SetSourceTableLayoutPanelColumnSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				int columnSpan = TargetTableLayoutPanel.GetColumnSpan((System.Windows.Forms.Control)objSubject);
				int columnSpan2 = SourceTableLayoutPanel.GetColumnSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject);
				if (columnSpan2 != columnSpan)
				{
					SourceTableLayoutPanel.SetColumnSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject, columnSpan);
				}
			}
		}

		protected virtual void SetSourceTableLayoutPanelRowSpan(object objSubject, ControlController objControlController)
		{
			if (objSubject != null)
			{
				int rowSpan = TargetTableLayoutPanel.GetRowSpan((System.Windows.Forms.Control)objSubject);
				int rowSpan2 = SourceTableLayoutPanel.GetRowSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject);
				if (rowSpan2 != rowSpan)
				{
					SourceTableLayoutPanel.SetRowSpan((Gizmox.WebGUI.Forms.Control)objControlController.SourceObject, rowSpan);
				}
			}
		}
	}
	public class TableLayoutRowStyleCollectionController : TableLayoutStyleCollectionController
	{
		public System.Windows.Forms.TableLayoutRowStyleCollection TargetTableLayoutRowStyleCollection => base.TargetObject as System.Windows.Forms.TableLayoutRowStyleCollection;

		public Gizmox.WebGUI.Forms.TableLayoutRowStyleCollection SourceTableLayoutRowStyleCollection => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutRowStyleCollection;

		public TableLayoutRowStyleCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList)
			: base(objContext, objSourceObject, objSourceList, objTargetObject, objTargetList)
		{
		}

		protected override ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
		{
			return new RowStyleController(base.Context, null, objTargetObject);
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
			return new RowStyleController(base.Context, objSourceObject);
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return new System.Windows.Forms.RowStyle();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}
	}
	public class TableLayoutSettingsController : LayoutSettingsController
	{
		private TableLayoutRowStyleCollectionController mobjRowStylesController = null;

		private TableLayoutColumnStyleCollectionController mobjColumnStylesController = null;

		public System.Windows.Forms.TableLayoutSettings TargetTableLayoutSettings => base.TargetObject as System.Windows.Forms.TableLayoutSettings;

		public Gizmox.WebGUI.Forms.TableLayoutSettings SourceTableLayoutSettings => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutSettings;

		public TableLayoutSettingsController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.RowStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.ColumnStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.ColumnStyles);
		}

		public TableLayoutSettingsController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.RowStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.ColumnStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.ColumnStyles);
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjRowStylesController.Initialize();
			mobjColumnStylesController.Initialize();
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return base.CreateTargetObject(objSourceObject);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetTargetTableLayoutSettingsColumnCount();
			SetTargetTableLayoutSettingsRowCount();
			SetTargetTableLayoutSettingsGrowStyle();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "ColumnCount":
				SetSourceTableLayoutSettingsColumnCount();
				break;
			case "RowCount":
				SetSourceTableLayoutSettingsRowCount();
				break;
			case "GrowStyle":
				SetSourceTableLayoutSettingsGrowStyle();
				break;
			default:
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "ColumnCount":
				SetTargetTableLayoutSettingsColumnCount();
				break;
			case "RowCount":
				SetTargetTableLayoutSettingsRowCount();
				break;
			case "GrowStyle":
				SetTargetTableLayoutSettingsGrowStyle();
				break;
			default:
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected virtual void SetSourceTableLayoutSettingsColumnCount()
		{
			SourceTableLayoutSettings.ColumnCount = TargetTableLayoutSettings.ColumnCount;
		}

		protected virtual void SetTargetTableLayoutSettingsColumnCount()
		{
			TargetTableLayoutSettings.ColumnCount = SourceTableLayoutSettings.ColumnCount;
		}

		protected virtual void SetSourceTableLayoutSettingsRowCount()
		{
			SourceTableLayoutSettings.RowCount = TargetTableLayoutSettings.RowCount;
		}

		protected virtual void SetTargetTableLayoutSettingsRowCount()
		{
			TargetTableLayoutSettings.RowCount = SourceTableLayoutSettings.RowCount;
		}

		protected virtual void SetSourceTableLayoutSettingsGrowStyle()
		{
			SourceTableLayoutSettings.GrowStyle = (Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle), TargetTableLayoutSettings.GrowStyle);
		}

		protected virtual void SetTargetTableLayoutSettingsGrowStyle()
		{
			TargetTableLayoutSettings.GrowStyle = (System.Windows.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(System.Windows.Forms.TableLayoutPanelGrowStyle), SourceTableLayoutSettings.GrowStyle);
		}
	}
	public class TableLayoutStyleCollectionController : ObjectCollectionController
	{
		public System.Windows.Forms.TableLayoutStyleCollection TargetTableLayoutStyleCollection => base.TargetObject as System.Windows.Forms.TableLayoutStyleCollection;

		public Gizmox.WebGUI.Forms.TableLayoutStyleCollection SourceTableLayoutStyleCollection => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutStyleCollection;

		protected override bool OverrideExistWinObjects => true;

		public TableLayoutStyleCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList)
			: base(objContext, objSourceObject, objSourceList, objTargetObject, objTargetList)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
			return new TableLayoutStyleController(base.Context, objSourceObject);
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			if (objSourceObject is Gizmox.WebGUI.Forms.RowStyle)
			{
				return new System.Windows.Forms.RowStyle();
			}
			if (objSourceObject is Gizmox.WebGUI.Forms.ColumnStyle)
			{
				return new System.Windows.Forms.ColumnStyle();
			}
			return null;
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}
	}
	public class TableLayoutStyleController : ObjectController
	{
		public System.Windows.Forms.TableLayoutStyle TargetTableLayoutStyle => base.TargetObject as System.Windows.Forms.TableLayoutStyle;

		public Gizmox.WebGUI.Forms.TableLayoutStyle SourceTableLayoutStyle => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutStyle;

		public TableLayoutStyleController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public TableLayoutStyleController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return base.CreateTargetObject(objSourceObject);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetTargetTableLayoutStyleSizeType();
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetSourceTableLayoutStyleSizeType();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetTargetTableLayoutStyleSizeType();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "SizeType")
			{
				SetSourceTableLayoutStyleSizeType();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "SizeType")
			{
				SetTargetTableLayoutStyleSizeType();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetSourceTableLayoutStyleSizeType()
		{
			SourceTableLayoutStyle.SizeType = (Gizmox.WebGUI.Forms.SizeType)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.SizeType), TargetTableLayoutStyle.SizeType);
		}

		protected virtual void SetTargetTableLayoutStyleSizeType()
		{
			TargetTableLayoutStyle.SizeType = (System.Windows.Forms.SizeType)GetConvertedEnum(typeof(System.Windows.Forms.SizeType), SourceTableLayoutStyle.SizeType);
		}
	}
	public class TabPageController : ControlController
	{
		public Gizmox.WebGUI.Forms.TabPage WebTabPage => base.SourceObject as Gizmox.WebGUI.Forms.TabPage;

		public System.Windows.Forms.TabPage WinTabPage => base.TargetObject as System.Windows.Forms.TabPage;

		public TabPageController(IContext objContext, object objWebTabPage, object objWinTabPage)
			: base(objContext, objWebTabPage, objWinTabPage)
		{
		}

		public TabPageController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTabPageImageIndex();
			SetWinTabPageImageKey();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TabPage();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinTabPage.SizeChanged += WinTabPage_SizeChanged;
		}

		private void WinTabPage_SizeChanged(object sender, EventArgs e)
		{
			SetWebControlSize();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinTabPage.SizeChanged -= WinTabPage_SizeChanged;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ImageKey":
				SetWinTabPageImageKey();
				break;
			case "Image":
			case "ImageIndex":
				SetWinTabPageImageIndex();
				break;
			}
		}

		protected virtual void SetWinTabPageImageKey()
		{
			if (WebTabPage.Image != null && WinTabPage.Parent != null)
			{
				System.Windows.Forms.TabControl tabControl = (System.Windows.Forms.TabControl)WinTabPage.Parent;
				if (tabControl.ImageList == null)
				{
					tabControl.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(tabControl.ImageList, WebTabPage.Image, WebTabPage.ImageKey) > -1)
				{
					WinTabPage.ImageKey = WebTabPage.ImageKey;
				}
			}
			else if (WinTabPage.ImageKey != string.Empty)
			{
				WinTabPage.ImageKey = string.Empty;
			}
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinTabPageImageIndex();
		}

		protected virtual void SetWinTabPageImageIndex()
		{
			if (WebTabPage.Image != null && WinTabPage.Parent != null)
			{
				System.Windows.Forms.TabControl tabControl = (System.Windows.Forms.TabControl)WinTabPage.Parent;
				if (tabControl.ImageList == null)
				{
					tabControl.ImageList = new System.Windows.Forms.ImageList();
				}
				WinTabPage.ImageIndex = GetWinImageIndex(tabControl.ImageList, WebTabPage.Image);
			}
			else if (WinTabPage.ImageIndex != -1)
			{
				WinTabPage.ImageIndex = -1;
			}
		}
	}
	public class TextBoxBaseController : ControlController
	{
		public Gizmox.WebGUI.Forms.TextBoxBase WebTextBoxBase => base.SourceObject as Gizmox.WebGUI.Forms.TextBoxBase;

		public System.Windows.Forms.TextBoxBase WinTextBoxBase => base.TargetObject as System.Windows.Forms.TextBoxBase;

		public TextBoxBaseController(IContext objContext, object objWebTextBoxBase, object objWinTextBoxBase)
			: base(objContext, objWebTextBoxBase, objWinTextBoxBase)
		{
		}

		public TextBoxBaseController(IContext objContext, object objWebTextBoxBase)
			: base(objContext, objWebTextBoxBase)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTextBoxBaseMultiline();
			SetWinTextBoxBaseReadOnly();
			SetWinControlBorderStyle();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Multiline":
				SetWinTextBoxBaseMultiline();
				break;
			case "ReadOnly":
				SetWinTextBoxBaseReadOnly();
				break;
			case "BorderStyle":
				SetWinControlBorderStyle();
				break;
			case "Lines":
				SetWinTextBoxBaseLines();
				break;
			}
		}

		protected virtual void SetWinTextBoxBaseLines()
		{
			WinTextBoxBase.Lines = WebTextBoxBase.Lines;
		}

		protected override void SetWinControlBorderStyle()
		{
			WinTextBoxBase.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebTextBoxBase.BorderStyle, WinTextBoxBase.BorderStyle);
		}

		protected virtual void SetWinTextBoxBaseMultiline()
		{
			if (WinTextBoxBase.Multiline != WebTextBoxBase.Multiline)
			{
				WinTextBoxBase.Multiline = WebTextBoxBase.Multiline;
			}
		}

		protected virtual void SetWinTextBoxBaseReadOnly()
		{
			WinTextBoxBase.ReadOnly = WebTextBoxBase.ReadOnly;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinTextBoxBase.KeyUp -= WinTextBoxBase_KeyUp;
			WinTextBoxBase.MultilineChanged -= WinTextBoxBase_MultilineChanged;
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinTextBoxBase.KeyUp += WinTextBoxBase_KeyUp;
			WinTextBoxBase.MultilineChanged += WinTextBoxBase_MultilineChanged;
		}

		private void WinTextBoxBase_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Return)
			{
				Event obj = CreateWebEvent("EnterKeyDown");
				obj.Fire();
			}
		}

		private void WinTextBoxBase_MultilineChanged(object sender, EventArgs e)
		{
			if (WinTextBoxBase.Multiline)
			{
				SetWebControlSize();
			}
		}
	}
	public class TextBoxController : TextBoxBaseController
	{
		public Gizmox.WebGUI.Forms.TextBox WebTextBox => base.SourceObject as Gizmox.WebGUI.Forms.TextBox;

		public System.Windows.Forms.TextBox WinTextBox => base.TargetObject as System.Windows.Forms.TextBox;

		public TextBoxController(IContext objContext, object objWebTextBox, object objWinTextBox)
			: base(objContext, objWebTextBox, objWinTextBox)
		{
		}

		public TextBoxController(IContext objContext, object objWebTextBox)
			: base(objContext, objWebTextBox)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTextBoxPasswordChar();
			SetWinTextBoxScrollbars();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "PasswordChar"))
			{
				if (property == "ScrollBars")
				{
					SetWinTextBoxScrollbars();
				}
			}
			else
			{
				SetWinTextBoxPasswordChar();
			}
		}

		protected virtual void SetWinTextBoxScrollbars()
		{
			WinTextBox.ScrollBars = (System.Windows.Forms.ScrollBars)GetConvertedEnum(typeof(System.Windows.Forms.ScrollBars), WebTextBox.ScrollBars, WinTextBox.ScrollBars);
		}

		protected virtual void SetWinTextBoxPasswordChar()
		{
			WinTextBox.PasswordChar = WebTextBox.PasswordChar;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TextBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinTextBox.TextChanged += WinTextBox_TextChanged;
		}

		private void WinTextBox_TextChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("TX", WinTextBox.Text);
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinTextBox.TextChanged -= WinTextBox_TextChanged;
		}
	}
	public class ToolBarButtonController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ToolBarButton WebToolBarButton => base.SourceObject as Gizmox.WebGUI.Forms.ToolBarButton;

		public System.Windows.Forms.ToolBarButton WinToolBarButton => base.TargetObject as System.Windows.Forms.ToolBarButton;

		public ToolBarButtonController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
		}

		public ToolBarButtonController(IContext objContext, object objWebControl)
			: base(objContext, objWebControl)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolBarButtonText();
			SetWinToolBarButtonToolTipText();
			SetWinToolBarButtonPushed();
			SetWinToolBarButtonStyle();
			SetWinToolBarButtonImageIndex();
			SetWinToolBarButtonImageKey();
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWinToolBarImageIndex();
		}

		protected virtual void SetWinToolBarImageIndex()
		{
			System.Windows.Forms.ToolBar parent = WinToolBarButton.Parent;
			if (parent == null)
			{
				return;
			}
			if (WebToolBarButton.Image != null)
			{
				if (parent.ImageList == null)
				{
					parent.ImageList = new System.Windows.Forms.ImageList();
				}
				WinToolBarButton.ImageIndex = GetWinImageIndex(parent.ImageList, WebToolBarButton.Image);
			}
			else if (WinToolBarButton.ImageIndex != -1)
			{
				WinToolBarButton.ImageIndex = -1;
			}
		}

		protected virtual void SetWinToolBarButtonText()
		{
			WinToolBarButton.Text = WebToolBarButton.Text;
			System.Windows.Forms.ToolBarButton winToolBarButton = WinToolBarButton;
			if (winToolBarButton != null)
			{
				typeof(System.Windows.Forms.ToolBarButton).InvokeMember("UpdateButton", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, winToolBarButton, new object[3] { true, true, false });
			}
		}

		protected virtual void SetWinToolBarButtonToolTipText()
		{
			WinToolBarButton.ToolTipText = WebToolBarButton.ToolTipText;
		}

		protected virtual void SetWinToolBarButtonPushed()
		{
			WinToolBarButton.Pushed = WebToolBarButton.Pushed;
		}

		protected virtual void SetWinToolBarButtonStyle()
		{
			WinToolBarButton.Style = (System.Windows.Forms.ToolBarButtonStyle)GetConvertedEnum(typeof(System.Windows.Forms.ToolBarButtonStyle), WebToolBarButton.Style);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolBarButton();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Text":
				SetWinToolBarButtonText();
				break;
			case "Style":
				SetWinToolBarButtonStyle();
				break;
			case "Pushed":
				SetWinToolBarButtonPushed();
				break;
			case "ToolTipText":
				SetWinToolBarButtonToolTipText();
				break;
			case "ImageIndex":
			case "Image":
				SetWinToolBarButtonImageIndex();
				break;
			case "ImageKey":
				SetWinToolBarButtonImageKey();
				break;
			}
		}

		private void SetWinToolBarButtonImageIndex()
		{
			if (WebToolBarButton.Image != null && WinToolBarButton.Parent != null)
			{
				System.Windows.Forms.ToolBar parent = WinToolBarButton.Parent;
				if (parent.ImageList == null)
				{
					parent.ImageList = new System.Windows.Forms.ImageList();
				}
				WinToolBarButton.ImageIndex = GetWinImageIndex(parent.ImageList, WebToolBarButton.Image);
			}
			else if (WinToolBarButton.ImageIndex != -1)
			{
				WinToolBarButton.ImageIndex = -1;
			}
		}

		private void SetWinToolBarButtonImageKey()
		{
			if (WebToolBarButton.Image != null && WinToolBarButton.Parent != null)
			{
				System.Windows.Forms.ToolBar parent = WinToolBarButton.Parent;
				if (parent.ImageList == null)
				{
					parent.ImageList = new System.Windows.Forms.ImageList();
				}
				if (GetWinImageIndex(parent.ImageList, WebToolBarButton.Image, WebToolBarButton.ImageKey) > -1)
				{
					WinToolBarButton.ImageKey = WebToolBarButton.ImageKey;
				}
			}
			else if (WinToolBarButton.ImageKey != string.Empty)
			{
				WinToolBarButton.ImageKey = string.Empty;
			}
		}
	}
	public class ToolBarController : ControlController
	{
		private ToolBarItemCollectionController mobjToolBarItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ToolBar WebToolBar => base.SourceObject as Gizmox.WebGUI.Forms.ToolBar;

		public System.Windows.Forms.ToolBar WinToolBar => base.TargetObject as System.Windows.Forms.ToolBar;

		public ToolBarController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
			mobjToolBarItemCollectionController = new ToolBarItemCollectionController(base.Context, WebToolBar, WebToolBar.Buttons, WinToolBar, WinToolBar.Buttons);
		}

		public ToolBarController(IContext objContext, object objWebControl)
			: base(objContext, objWebControl)
		{
			mobjToolBarItemCollectionController = new ToolBarItemCollectionController(base.Context, WebToolBar, WebToolBar.Buttons, WinToolBar, WinToolBar.Buttons);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			WinToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			SetWinToolBarTextAlign();
			SetWinToolBarButtonSize();
			SetWinToolBarButtons();
		}

		protected virtual void SetWinToolBarTextAlign()
		{
			WinToolBar.TextAlign = (System.Windows.Forms.ToolBarTextAlign)GetConvertedEnum(typeof(System.Windows.Forms.ToolBarTextAlign), WebToolBar.TextAlign);
		}

		private void SetWinToolBarButtonSize()
		{
			WinToolBar.ButtonSize = WebToolBar.ButtonSize;
		}

		protected override void InitializedContained()
		{
			mobjToolBarItemCollectionController.Initialize();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinToolBar.ButtonClick += WinToolBar_ButtonClick;
		}

		private void WinToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (GetControllerByWinObject(e.Button) is ToolBarButtonController toolBarButtonController)
			{
				Event obj = CreateWebEvent("Click", toolBarButtonController.SourceObject);
				obj.Fire();
			}
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinToolBar.ButtonClick -= WinToolBar_ButtonClick;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolBar();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ButtonSize":
				SetWinToolBarButtonSize();
				break;
			case "TextAlign":
				SetWinToolBarTextAlign();
				break;
			case "Buttons":
				SetWinToolBarButtons();
				break;
			}
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjToolBarItemCollectionController != null)
			{
				mobjToolBarItemCollectionController.Clear();
			}
		}

		private void SetWinToolBarButtons()
		{
			mobjToolBarItemCollectionController.SetWinObjectObjects();
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjToolBarItemCollectionController != null)
			{
				mobjToolBarItemCollectionController.Terminate();
			}
		}
	}
	public class ToolBarItemCollectionController : ComponentCollectionController
	{
		public ToolBarItemCollection WebToolBarItems => base.WebObjects as ToolBarItemCollection;

		public Gizmox.WebGUI.Forms.ToolBar WebToolBar => base.SourceObject as Gizmox.WebGUI.Forms.ToolBar;

		public System.Windows.Forms.ToolBar WinToolBar => base.TargetObject as System.Windows.Forms.ToolBar;

		public ToolBarItemCollectionController(IContext objContext, object objWebTreeNode, IList objWebTreeNodes, object objWinTreeNode, IList objWinTreeNodes)
			: base(objContext, objWebTreeNode, objWebTreeNodes, objWinTreeNode, objWinTreeNodes)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new ToolBarButtonController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolBarButton();
		}
	}
	public class ToolStripButtonController : ToolStripItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripButton WebToolStripButton => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripButton;

		public System.Windows.Forms.ToolStripButton WinToolStripButton => base.TargetObject as System.Windows.Forms.ToolStripButton;

		public ToolStripButtonController(IContext objContext, object objWebToolStripButton, object objWinToolStripButton)
			: base(objContext, objWebToolStripButton, objWinToolStripButton)
		{
		}

		public ToolStripButtonController(IContext objContext, object objWebToolStripButton)
			: base(objContext, objWebToolStripButton)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripButton();
		}
	}
	public class ToolStripComboBoxController : ToolStripControlHostController
	{
		public Gizmox.WebGUI.Forms.ToolStripComboBox WebToolStripComboBox => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripComboBox;

		public System.Windows.Forms.ToolStripComboBox WinToolStripComboBox => base.TargetObject as System.Windows.Forms.ToolStripComboBox;

		public ToolStripComboBoxController(IContext objContext, object objWebToolStripComboBox, object objWinToolStripComboBox)
			: base(objContext, objWebToolStripComboBox, objWinToolStripComboBox)
		{
		}

		public ToolStripComboBoxController(IContext objContext, object objWebToolStripComboBox)
			: base(objContext, objWebToolStripComboBox)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripComboBox();
		}
	}
	public class ToolStripContainerController : ContainerControlController
	{
		public ToolStripContainerController(IContext objContext, object objWebToolStripContainer, object objWinToolStripContainer)
			: base(objContext, objWebToolStripContainer, objWinToolStripContainer)
		{
		}

		public ToolStripContainerController(IContext objContext, object objWebToolStripContainer)
			: base(objContext, objWebToolStripContainer)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripContainer();
		}
	}
	public class ToolStripContentPanelController : PanelController
	{
		public ToolStripContentPanelController(IContext objContext, object objWebToolStripContentPanel, object objWinToolStripContentPanel)
			: base(objContext, objWebToolStripContentPanel, objWinToolStripContentPanel)
		{
		}

		public ToolStripContentPanelController(IContext objContext, object objWebToolStripContentPanel)
			: base(objContext, objWebToolStripContentPanel)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripContentPanel();
		}
	}
	public class ToolStripControlHostController : ToolStripItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripControlHost WebToolStripControlHost => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripControlHost;

		public System.Windows.Forms.ToolStripControlHost WinToolStripControlHost => base.TargetObject as System.Windows.Forms.ToolStripControlHost;

		public ToolStripControlHostController(IContext objContext, object objWebToolStripControlHost, object objWinToolStripControlHost)
			: base(objContext, objWebToolStripControlHost, objWinToolStripControlHost)
		{
		}

		public ToolStripControlHostController(IContext objContext, object objWebToolStripControlHost)
			: base(objContext, objWebToolStripControlHost)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return null;
		}
	}
	public class ToolStripController : ScrollableControlController
	{
		private ToolStripItemCollectionController mobjToolStripItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ToolStrip WebToolStrip => base.SourceObject as Gizmox.WebGUI.Forms.ToolStrip;

		public System.Windows.Forms.ToolStrip WinToolStrip => base.TargetObject as System.Windows.Forms.ToolStrip;

		public ToolStripController(IContext objContext, object objWebToolStrip, object objWinToolStrip)
			: base(objContext, objWebToolStrip, objWinToolStrip)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStrip, WebToolStrip.Items, WinToolStrip, WinToolStrip.Items);
		}

		public ToolStripController(IContext objContext, object objWebToolStrip)
			: base(objContext, objWebToolStrip)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStrip, WebToolStrip.Items, WinToolStrip, WinToolStrip.Items);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStrip();
		}

		protected override void SetWinScrollableControlAutoScroll()
		{
		}

		protected override void InitializedContained()
		{
			mobjToolStripItemCollectionController.Initialize();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjToolStripItemCollectionController != null)
			{
				mobjToolStripItemCollectionController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjToolStripItemCollectionController != null)
			{
				mobjToolStripItemCollectionController.Terminate();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Items":
				SetWinToolStripItems();
				break;
			case "GripStyle":
				SetWinToolStripGripStyle();
				break;
			case "CanOverflow":
				SetWinToolStripCanOverflow();
				break;
			case "ImageScalingSize":
				SetWinToolStripImageScalingSize();
				break;
			}
		}

		private void SetWinToolStripImageScalingSize()
		{
			if (WinToolStrip != null && WebToolStrip != null)
			{
				WinToolStrip.ImageScalingSize = WebToolStrip.ImageScalingSize;
			}
		}

		private void SetWinToolStripCanOverflow()
		{
			if (WinToolStrip != null && WebToolStrip != null)
			{
				WinToolStrip.CanOverflow = WebToolStrip.CanOverflow;
			}
		}

		private void SetWinToolStripGripStyle()
		{
			if (WinToolStrip != null && WebToolStrip != null)
			{
				WinToolStrip.GripStyle = (System.Windows.Forms.ToolStripGripStyle)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripGripStyle), WebToolStrip.GripStyle);
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Items")
			{
				SetWebToolStripItems();
			}
		}

		private void SetWinToolStripItems()
		{
			mobjToolStripItemCollectionController.SetWinObjectObjects();
		}

		private void SetWebToolStripItems()
		{
			mobjToolStripItemCollectionController.SetWebObjectObjects();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripItems();
			SetWinToolStripCanOverflow();
			SetWinToolStripImageScalingSize();
		}
	}
	public class ToolStripDropDownButtonController : ToolStripDropDownItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripDropDownButton WebToolStripDropDownButton => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripDropDownButton;

		public System.Windows.Forms.ToolStripDropDownButton WinToolStripDropDownButton => base.TargetObject as System.Windows.Forms.ToolStripDropDownButton;

		public ToolStripDropDownButtonController(IContext objContext, object objWebToolStripDropDownButton, object objWinToolStripDropDownButton)
			: base(objContext, objWebToolStripDropDownButton, objWinToolStripDropDownButton)
		{
		}

		public ToolStripDropDownButtonController(IContext objContext, object objWebToolStripDropDownButton)
			: base(objContext, objWebToolStripDropDownButton)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripDropDownButton();
		}
	}
	public class ToolStripDropDownController : ToolStripController
	{
		public ToolStripDropDownController(IContext objContext, object objWebToolStripDropDown, object objWinToolStripDropDown)
			: base(objContext, objWebToolStripDropDown, objWinToolStripDropDown)
		{
		}

		public ToolStripDropDownController(IContext objContext, object objWebToolStripDropDown)
			: base(objContext, objWebToolStripDropDown)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripDropDown();
		}
	}
	public class ToolStripDropDownItemController : ToolStripItemController
	{
		private ToolStripItemCollectionController mobjToolStripItemCollectionController = null;

		public Gizmox.WebGUI.Forms.ToolStripDropDownItem WebToolStripDropDownItem => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripDropDownItem;

		public System.Windows.Forms.ToolStripDropDownItem WinToolStripDropDownItem => base.TargetObject as System.Windows.Forms.ToolStripDropDownItem;

		public ToolStripDropDownItemController(IContext objContext, object objWebToolStripDropDownItem, object objWinToolStripDropDownItem)
			: base(objContext, objWebToolStripDropDownItem, objWinToolStripDropDownItem)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStripDropDownItem, WebToolStripDropDownItem.DropDownItems, WinToolStripDropDownItem, WinToolStripDropDownItem.DropDownItems);
		}

		public ToolStripDropDownItemController(IContext objContext, object objWebToolStripDropDownItem)
			: base(objContext, objWebToolStripDropDownItem)
		{
			mobjToolStripItemCollectionController = new ToolStripItemCollectionController(base.Context, WebToolStripDropDownItem, WebToolStripDropDownItem.DropDownItems, WinToolStripDropDownItem, WinToolStripDropDownItem.DropDownItems);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return null;
		}

		protected override void InitializedContained()
		{
			mobjToolStripItemCollectionController.Initialize();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjToolStripItemCollectionController != null)
			{
				mobjToolStripItemCollectionController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjToolStripItemCollectionController != null)
			{
				mobjToolStripItemCollectionController.Terminate();
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DropDownItems")
			{
				SetWinToolStripDropDownItemDropDownItems();
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DropDownItems")
			{
				SetWebToolStripDropDownItemDropDownItems();
			}
		}

		private void SetWinToolStripDropDownItemDropDownItems()
		{
			mobjToolStripItemCollectionController.SetWinObjectObjects();
		}

		private void SetWebToolStripDropDownItemDropDownItems()
		{
			mobjToolStripItemCollectionController.SetWebObjectObjects();
		}
	}
	public class ToolStripDropDownMenuController : ToolStripDropDownController
	{
		public ToolStripDropDownMenuController(IContext objContext, object objWebToolStripDropDownMenu, object objWinToolStripDropDownMenu)
			: base(objContext, objWebToolStripDropDownMenu, objWinToolStripDropDownMenu)
		{
		}

		public ToolStripDropDownMenuController(IContext objContext, object objWebToolStripDropDownMenu)
			: base(objContext, objWebToolStripDropDownMenu)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripDropDownMenu();
		}
	}
	public class ToolStripItemCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.ToolStripItemCollection WebToolStripItems => base.WebObjects as Gizmox.WebGUI.Forms.ToolStripItemCollection;

		public Gizmox.WebGUI.Forms.ToolStrip WebToolStrip => base.SourceObject as Gizmox.WebGUI.Forms.ToolStrip;

		public System.Windows.Forms.ToolStrip WinToolStrip => base.TargetObject as System.Windows.Forms.ToolStrip;

		public ToolStripItemCollectionController(IContext objContext, object objWebObject, IList objWebObjects, object objWinObject, IList objWinObjectItems)
			: base(objContext, objWebObject, objWebObjects, objWinObject, objWinObjectItems)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripButton)
			{
				return new ToolStripButtonController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSplitButton)
			{
				return new ToolStripSplitButtonController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownButton)
			{
				return new ToolStripDropDownButtonController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripLabel)
			{
				return new ToolStripLabelController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripComboBox)
			{
				return new ToolStripComboBoxController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripProgressBar)
			{
				return new ToolStripProgressBarController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripTextBox)
			{
				return new ToolStripTextBoxController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripStatusLabel)
			{
				return new ToolStripStatusLabelController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripMenuItem)
			{
				return new ToolStripMenuItemController(base.Context, objWebObject);
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSeparator)
			{
				return new ToolStripSeparatorController(base.Context, objWebObject);
			}
			return new ToolStripItemController(base.Context, objWebObject);
		}

		protected override ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
		{
			if (objTargetObject is System.Windows.Forms.ToolStripButton)
			{
				return new ToolStripButtonController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripSplitButton)
			{
				return new ToolStripSplitButtonController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripDropDownButton)
			{
				return new ToolStripDropDownButtonController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripLabel)
			{
				return new ToolStripLabelController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripComboBox)
			{
				return new ToolStripComboBoxController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripProgressBar)
			{
				return new ToolStripProgressBarController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripTextBox)
			{
				return new ToolStripTextBoxController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripStatusLabel)
			{
				return new ToolStripStatusLabelController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripMenuItem)
			{
				return new ToolStripMenuItemController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripSeparator)
			{
				return new ToolStripSeparatorController(base.Context, objTargetObject);
			}
			if (objTargetObject is System.Windows.Forms.ToolStripControlHost)
			{
				return null;
			}
			if (objTargetObject is System.Windows.Forms.ToolStripDropDownItem)
			{
				return null;
			}
			if (objTargetObject is System.Windows.Forms.ToolStripItem)
			{
				return null;
			}
			return base.CreateObjectControlerByTargetObject(objTargetObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripButton)
			{
				return new System.Windows.Forms.ToolStripButton();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripSplitButton)
			{
				return new System.Windows.Forms.ToolStripSplitButton();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownButton)
			{
				return new System.Windows.Forms.ToolStripDropDownButton();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripLabel)
			{
				return new System.Windows.Forms.ToolStripLabel();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripComboBox)
			{
				return new System.Windows.Forms.ToolStripComboBox();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripProgressBar)
			{
				return new System.Windows.Forms.ToolStripProgressBar();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripTextBox)
			{
				return new System.Windows.Forms.ToolStripTextBox();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripStatusLabel)
			{
				return new System.Windows.Forms.ToolStripStatusLabel();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripMenuItem)
			{
				return new System.Windows.Forms.ToolStripMenuItem();
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripControlHost)
			{
				return null;
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripDropDownItem)
			{
				return null;
			}
			if (objWebObject is Gizmox.WebGUI.Forms.ToolStripItem)
			{
				return null;
			}
			return base.CreateTargetObject(objWebObject);
		}

		protected override void ClearWinObjects()
		{
			ClearControllers();
			if (base.WinObjects != null)
			{
				if (base.DesignMode)
				{
					WinObjectsClear(blnIsInDesignMode: true);
				}
				else
				{
					base.WinObjects.Clear();
				}
			}
		}

		protected internal override void WinObjectsClear()
		{
			WinObjectsClear(blnIsInDesignMode: false);
		}

		private void WinObjectsClear(bool blnIsInDesignMode)
		{
			ArrayList arrayList = new ArrayList();
			foreach (object winObject in base.WinObjects)
			{
				if (winObject.GetType().Name != "DesignerToolStripControlHost")
				{
					if (blnIsInDesignMode && winObject is IComponent objWinComponent)
					{
						base.DesignServices.UnregisterWinComponent(objWinComponent);
					}
					arrayList.Add(winObject);
				}
			}
			foreach (object item in arrayList)
			{
				base.WinObjects.Remove(item);
			}
		}
	}
	public class ToolStripItemController : ComponentController
	{
		public Gizmox.WebGUI.Forms.ToolStripItem WebToolStripItem => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripItem;

		public System.Windows.Forms.ToolStripItem WinToolStripItem => base.TargetObject as System.Windows.Forms.ToolStripItem;

		public ToolStripItemController(IContext objContext, object objWebToolStripItem, object objWinToolStripItem)
			: base(objContext, objWebToolStripItem, objWinToolStripItem)
		{
		}

		public ToolStripItemController(IContext objContext, object objWebToolStripItem)
			: base(objContext, objWebToolStripItem)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return null;
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "AutoSize":
				SetWinToolStripItemAutoSize();
				break;
			case "Alignment":
				SetWinToolStripItemAlignment();
				break;
			case "Anchor":
				SetWinToolStripItemAnchor();
				break;
			case "Available":
				SetWinToolStripItemAvailable();
				break;
			case "BackColor":
				SetWinToolStripItemBackColor();
				break;
			case "BackgroundImage":
				SetWinToolStripItemBackgroundImage();
				break;
			case "BackgroundImageLayout":
				SetWinToolStripItemBackgroundImageLayout();
				break;
			case "DisplayStyle":
				SetWinToolStripItemDisplayStyle();
				break;
			case "Dock":
				SetWinToolStripItemDock();
				break;
			case "Enabled":
				SetWinToolStripItemEnabled();
				break;
			case "Font":
				SetWinToolStripItemFont();
				break;
			case "ForeColor":
				SetWinToolStripItemForeColor();
				break;
			case "Height":
				SetWinToolStripItemHeight();
				break;
			case "Image":
				SetWinToolStripItemImage();
				break;
			case "ImageAlign":
				SetWinToolStripItemImageAlign();
				break;
			case "ImageIndex":
				SetWinToolStripItemImageIndex();
				break;
			case "ImageKey":
				SetWinToolStripItemImageKey();
				break;
			case "ImageScaling":
				SetWinToolStripItemImageScaling();
				break;
			case "MergeAction":
				SetWinToolStripItemMergeAction();
				break;
			case "MergeIndex":
				SetWinToolStripItemMergeIndex();
				break;
			case "Name":
				SetWinToolStripItemName();
				break;
			case "Padding":
				SetWinToolStripItemPadding();
				break;
			case "RightToLeft":
				SetWinToolStripItemRightToLeft();
				break;
			case "RightToLeftAutoMirrorImage":
				SetWinToolStripItemRightToLeftAutoMirrorImage();
				break;
			case "Size":
				SetWinToolStripItemSize();
				break;
			case "Text":
				SetWinToolStripItemText();
				break;
			case "TextAlign":
				SetWinToolStripItemTextAlign();
				break;
			case "TextDirection":
				SetWinToolStripItemTextDirection();
				break;
			case "TextImageRelation":
				SetWinToolStripItemTextImageRelation();
				break;
			case "ToolTipText":
				SetWinToolStripItemToolTipText();
				break;
			case "Width":
				SetWinToolStripItemWidth();
				break;
			}
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Text")
			{
				SetWebToolStripItemText();
			}
		}

		protected override void LoadController()
		{
			base.LoadController();
			SetWebToolStripItemName();
		}

		private void SetWebToolStripItemText()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WebToolStripItem.Text = WinToolStripItem.Text;
			}
		}

		private void SetWebToolStripItemName()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WebToolStripItem.Name = WinToolStripItem.Name;
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripItemAutoSize();
			SetWinToolStripItemAlignment();
			SetWinToolStripItemAnchor();
			SetWinToolStripItemAvailable();
			SetWinToolStripItemBackColor();
			SetWinToolStripItemBackgroundImage();
			SetWinToolStripItemBackgroundImageLayout();
			SetWinToolStripItemDisplayStyle();
			SetWinToolStripItemDock();
			SetWinToolStripItemEnabled();
			SetWinToolStripItemFont();
			SetWinToolStripItemForeColor();
			SetWinToolStripItemImageAlign();
			SetWinToolStripItemImageIndex();
			SetWinToolStripItemImageKey();
			SetWinToolStripItemImageScaling();
			SetWinToolStripItemImage();
			SetWinToolStripItemMergeAction();
			SetWinToolStripItemMergeIndex();
			SetWinToolStripItemName();
			SetWinToolStripItemPadding();
			SetWinToolStripItemRightToLeft();
			SetWinToolStripItemRightToLeftAutoMirrorImage();
			SetWinToolStripItemSize();
			SetWinToolStripItemText();
			SetWinToolStripItemTextAlign();
			SetWinToolStripItemTextDirection();
			SetWinToolStripItemTextImageRelation();
			SetWinToolStripItemToolTipText();
			InitializeWinToolStripItemVisiblity();
		}

		protected virtual void SetWinToolStripItemAutoSize()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.AutoSize = WebToolStripItem.AutoSize;
			}
		}

		protected virtual void SetWinToolStripItemAlignment()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Alignment = (System.Windows.Forms.ToolStripItemAlignment)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripItemAlignment), WebToolStripItem.Alignment);
			}
		}

		protected virtual void SetWinToolStripItemAnchor()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Anchor = (System.Windows.Forms.AnchorStyles)GetConvertedEnum(typeof(System.Windows.Forms.AnchorStyles), WebToolStripItem.Anchor);
			}
		}

		protected virtual void SetWinToolStripItemAvailable()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Available = WebToolStripItem.Available;
			}
		}

		protected virtual void SetWinToolStripItemBackColor()
		{
			if (WinToolStripItem != null && WebToolStripItem != null && WebToolStripItem.BackColor != Color.Transparent)
			{
				WinToolStripItem.BackColor = WebToolStripItem.BackColor;
			}
		}

		protected virtual void SetWinToolStripItemBackgroundImage()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.BackgroundImage = GetWinImageFromResourceHandle(WebToolStripItem.BackgroundImage);
			}
		}

		protected virtual void SetWinToolStripItemBackgroundImageLayout()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.BackgroundImageLayout = (System.Windows.Forms.ImageLayout)GetConvertedEnum(typeof(System.Windows.Forms.ImageLayout), WebToolStripItem.BackgroundImageLayout);
			}
		}

		protected virtual void SetWinToolStripItemDisplayStyle()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.DisplayStyle = (System.Windows.Forms.ToolStripItemDisplayStyle)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripItemDisplayStyle), WebToolStripItem.DisplayStyle);
			}
		}

		protected virtual void SetWinToolStripItemDock()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Dock = (System.Windows.Forms.DockStyle)GetConvertedEnum(typeof(System.Windows.Forms.DockStyle), WebToolStripItem.Dock);
			}
		}

		protected virtual void SetWinToolStripItemEnabled()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Enabled = WebToolStripItem.Enabled;
			}
		}

		protected virtual void SetWinToolStripItemFont()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				if (WebToolStripItem.Font == null)
				{
					WinToolStripItem.Font = null;
				}
				else
				{
					WinToolStripItem.Font = new Font(WebToolStripItem.Font.FontFamily, WebToolStripItem.Font.Size * base.TargetVerticalScaleFactor);
				}
			}
		}

		protected virtual void SetWinToolStripItemForeColor()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ForeColor = WebToolStripItem.ForeColor;
			}
		}

		protected virtual void SetWinToolStripItemHeight()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Height = Convert.ToInt32((float)WebToolStripItem.Height * base.TargetVerticalScaleFactor);
			}
		}

		protected virtual void SetWinToolStripItemImage()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Image = GetWinImageFromResourceHandle(WebToolStripItem.Image);
			}
		}

		protected virtual void SetWinToolStripItemImageAlign()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageAlign = WebToolStripItem.ImageAlign;
			}
		}

		protected virtual void SetWinToolStripItemImageIndex()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageIndex = WebToolStripItem.ImageIndex;
			}
		}

		protected virtual void SetWinToolStripItemImageKey()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageKey = WebToolStripItem.ImageKey;
			}
		}

		protected virtual void SetWinToolStripItemImageScaling()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ImageScaling = (System.Windows.Forms.ToolStripItemImageScaling)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripItemImageScaling), WebToolStripItem.ImageScaling);
			}
		}

		protected virtual void SetWinToolStripItemMergeAction()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.MergeAction = (System.Windows.Forms.MergeAction)GetConvertedEnum(typeof(System.Windows.Forms.MergeAction), WebToolStripItem.MergeAction);
			}
		}

		protected virtual void SetWinToolStripItemMergeIndex()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.MergeIndex = WebToolStripItem.MergeIndex;
			}
		}

		protected virtual void SetWinToolStripItemName()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Name = WebToolStripItem.Name;
			}
		}

		protected virtual void SetWinToolStripItemPadding()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				Gizmox.WebGUI.Forms.Padding padding = WebToolStripItem.Padding;
				bool flag = true;
				WinToolStripItem.Padding = new System.Windows.Forms.Padding(padding.Left, padding.Top, padding.Right, padding.Bottom);
			}
		}

		protected virtual void SetWinToolStripItemRightToLeft()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.RightToLeft = (System.Windows.Forms.RightToLeft)GetConvertedEnum(typeof(System.Windows.Forms.RightToLeft), WebToolStripItem.RightToLeft);
			}
		}

		protected virtual void SetWinToolStripItemRightToLeftAutoMirrorImage()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.RightToLeftAutoMirrorImage = WebToolStripItem.RightToLeftAutoMirrorImage;
			}
		}

		protected virtual void SetWinToolStripItemSize()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				Size size = WebToolStripItem.Size;
				WinToolStripItem.Size = new Size(Convert.ToInt32((float)size.Width * base.TargetHorizontalScaleFactor), Convert.ToInt32((float)size.Height * base.TargetVerticalScaleFactor));
			}
		}

		protected virtual void SetWinToolStripItemText()
		{
			if (WinToolStripItem != null && WebToolStripItem != null && WinToolStripItem.Text != WebToolStripItem.Text)
			{
				WinToolStripItem.Text = WebToolStripItem.Text;
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinToolStripItem.TextChanged += WinToolStripItem_TextChanged;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinToolStripItem.TextChanged -= WinToolStripItem_TextChanged;
		}

		private void WinToolStripItem_TextChanged(object sender, EventArgs e)
		{
			if (WinToolStripItem != null && WebToolStripItem != null && WinToolStripItem.AutoSize)
			{
				Size preferredSize = WinToolStripItem.GetPreferredSize(WinToolStripItem.Size);
				WebToolStripItem.Size = new Size(Convert.ToInt32((float)preferredSize.Width / base.TargetHorizontalScaleFactor), Convert.ToInt32((float)preferredSize.Height / base.TargetVerticalScaleFactor));
			}
		}

		protected virtual void SetWinToolStripItemTextAlign()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.TextAlign = WebToolStripItem.TextAlign;
			}
		}

		protected virtual void SetWinToolStripItemTextDirection()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.TextDirection = (System.Windows.Forms.ToolStripTextDirection)GetConvertedEnum(typeof(System.Windows.Forms.ToolStripTextDirection), WebToolStripItem.TextDirection);
			}
		}

		protected virtual void SetWinToolStripItemTextImageRelation()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.TextImageRelation = (System.Windows.Forms.TextImageRelation)GetConvertedEnum(typeof(System.Windows.Forms.TextImageRelation), WebToolStripItem.TextImageRelation);
			}
		}

		protected virtual void SetWinToolStripItemToolTipText()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.ToolTipText = WebToolStripItem.ToolTipText;
			}
		}

		protected virtual void InitializeWinToolStripItemVisiblity()
		{
			if (WinToolStripItem != null)
			{
				WinToolStripItem.Visible = true;
			}
		}

		protected virtual void SetWinToolStripItemWidth()
		{
			if (WinToolStripItem != null && WebToolStripItem != null)
			{
				WinToolStripItem.Width = Convert.ToInt32((float)WebToolStripItem.Width * base.TargetHorizontalScaleFactor);
			}
		}
	}
	public class ToolStripLabelController : ToolStripItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripLabel WebToolStripLabel => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripLabel;

		public System.Windows.Forms.ToolStripLabel WinToolStripLabel => base.TargetObject as System.Windows.Forms.ToolStripLabel;

		public ToolStripLabelController(IContext objContext, object objWebToolStripLabel, object objWinToolStripLabel)
			: base(objContext, objWebToolStripLabel, objWinToolStripLabel)
		{
		}

		public ToolStripLabelController(IContext objContext, object objWebToolStripLabel)
			: base(objContext, objWebToolStripLabel)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripLabel();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripLabelIsLink();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "IsLink")
			{
				SetWinToolStripLabelIsLink();
			}
		}

		protected virtual void SetWinToolStripLabelIsLink()
		{
			WinToolStripLabel.IsLink = WebToolStripLabel.IsLink;
		}
	}
	public class ToolStripMenuItemController : ToolStripDropDownItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripMenuItem WebToolStripMenuItem => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripMenuItem;

		public System.Windows.Forms.ToolStripMenuItem WinToolStripMenuItem => base.TargetObject as System.Windows.Forms.ToolStripMenuItem;

		protected override bool UseVsMenuDeisgner => false;

		public ToolStripMenuItemController(IContext objContext, object objWebToolStripMenuItem, object objWinToolStripMenuItem)
			: base(objContext, objWebToolStripMenuItem, objWinToolStripMenuItem)
		{
		}

		public ToolStripMenuItemController(IContext objContext, object objWebToolStripMenuItem)
			: base(objContext, objWebToolStripMenuItem)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripMenuItem();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripMenuItemChecked();
			SetWinToolStripMenuItemCheckState();
			SetWinToolStripMenuItemShortcutKeys();
		}

		private void SetWinToolStripMenuItemChecked()
		{
			if (WebToolStripMenuItem != null && WinToolStripMenuItem != null)
			{
				WinToolStripMenuItem.Checked = WebToolStripMenuItem.Checked;
			}
		}

		private void SetWinToolStripMenuItemCheckState()
		{
			if (WebToolStripMenuItem != null && WinToolStripMenuItem != null)
			{
				WinToolStripMenuItem.CheckState = (System.Windows.Forms.CheckState)Enum.Parse(typeof(System.Windows.Forms.CheckState), WebToolStripMenuItem.CheckState.ToString());
				WinToolStripMenuItem.Invalidate();
			}
		}

		private void SetWinToolStripMenuItemShortcutKeys()
		{
			if (WebToolStripMenuItem != null && WinToolStripMenuItem != null)
			{
				WinToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), ((int)WebToolStripMenuItem.ShortcutKeys).ToString());
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Checked":
				SetWinToolStripMenuItemChecked();
				break;
			case "CheckState":
				SetWinToolStripMenuItemCheckState();
				break;
			case "ShortcutKeys":
				SetWinToolStripMenuItemShortcutKeys();
				break;
			}
		}
	}
	public class ToolStripPanelController : ContainerControlController
	{
		public ToolStripPanelController(IContext objContext, object objWebToolStripPanel, object objWinToolStripPanel)
			: base(objContext, objWebToolStripPanel, objWinToolStripPanel)
		{
		}

		public ToolStripPanelController(IContext objContext, object objWebToolStripPanel)
			: base(objContext, objWebToolStripPanel)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripPanel();
		}
	}
	public class ToolStripProgressBarController : ToolStripControlHostController
	{
		public Gizmox.WebGUI.Forms.ToolStripProgressBar WebToolStripProgressBar => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripProgressBar;

		public System.Windows.Forms.ToolStripProgressBar WinToolStripProgressBar => base.TargetObject as System.Windows.Forms.ToolStripProgressBar;

		public ToolStripProgressBarController(IContext objContext, object objWebToolStripProgressBar, object objWinToolStripProgressBar)
			: base(objContext, objWebToolStripProgressBar, objWinToolStripProgressBar)
		{
		}

		public ToolStripProgressBarController(IContext objContext, object objWebToolStripProgressBar)
			: base(objContext, objWebToolStripProgressBar)
		{
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Value")
			{
				SetWinToolStripProgressBarValue();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripProgressBar();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripProgressBarValue();
		}

		private void SetWinToolStripProgressBarValue()
		{
			if (WinToolStripProgressBar != null && WebToolStripProgressBar != null)
			{
				WinToolStripProgressBar.Value = WebToolStripProgressBar.Value;
			}
		}
	}
	public class ToolStripSeparatorController : ToolStripItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripSeparator WebToolStripSeparator => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripSeparator;

		public System.Windows.Forms.ToolStripSeparator WinToolStripSeparator => base.TargetObject as System.Windows.Forms.ToolStripSeparator;

		public ToolStripSeparatorController(IContext objContext, object objWebToolStripSeparator, object objWinToolStripSeparator)
			: base(objContext, objWebToolStripSeparator, objWinToolStripSeparator)
		{
		}

		public ToolStripSeparatorController(IContext objContext, object objWebToolStripSeparator)
			: base(objContext, objWebToolStripSeparator)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripSeparator();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
		}
	}
	public class ToolStripSplitButtonController : ToolStripDropDownItemController
	{
		public Gizmox.WebGUI.Forms.ToolStripSplitButton WebToolStripSplitButton => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripSplitButton;

		public System.Windows.Forms.ToolStripSplitButton WinToolStripSplitButton => base.TargetObject as System.Windows.Forms.ToolStripSplitButton;

		public ToolStripSplitButtonController(IContext objContext, object objWebToolStripSplitButton, object objWinToolStripSplitButton)
			: base(objContext, objWebToolStripSplitButton, objWinToolStripSplitButton)
		{
		}

		public ToolStripSplitButtonController(IContext objContext, object objWebToolStripSplitButton)
			: base(objContext, objWebToolStripSplitButton)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripSplitButton();
		}
	}
	public class ToolStripStatusLabelController : ToolStripLabelController
	{
		public Gizmox.WebGUI.Forms.ToolStripStatusLabel WebToolStripStatusLabel => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripStatusLabel;

		public System.Windows.Forms.ToolStripStatusLabel WinToolStripStatusLabel => base.TargetObject as System.Windows.Forms.ToolStripStatusLabel;

		public ToolStripStatusLabelController(IContext objContext, object objWebToolStripStatusLabel, object objWinToolStripStatusLabel)
			: base(objContext, objWebToolStripStatusLabel, objWinToolStripStatusLabel)
		{
		}

		public ToolStripStatusLabelController(IContext objContext, object objWebToolStripStatusLabel)
			: base(objContext, objWebToolStripStatusLabel)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripStatusLabel();
		}
	}
	public class ToolStripTextBoxController : ToolStripControlHostController
	{
		public Gizmox.WebGUI.Forms.ToolStripTextBox WebToolStripTextBox => base.SourceObject as Gizmox.WebGUI.Forms.ToolStripTextBox;

		public System.Windows.Forms.ToolStripTextBox WinToolStripTextBox => base.TargetObject as System.Windows.Forms.ToolStripTextBox;

		public ToolStripTextBoxController(IContext objContext, object objWebToolStripTextBox, object objWinToolStripTextBox)
			: base(objContext, objWebToolStripTextBox, objWinToolStripTextBox)
		{
		}

		public ToolStripTextBoxController(IContext objContext, object objWebToolStripTextBox)
			: base(objContext, objWebToolStripTextBox)
		{
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ToolStripTextBox();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinToolStripItemTextBoxTextAlign();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "TextBoxTextAlign")
			{
				SetWinToolStripItemTextBoxTextAlign();
			}
		}

		protected virtual void SetWinToolStripItemTextBoxTextAlign()
		{
			if (WinToolStripTextBox != null && WebToolStripTextBox != null)
			{
				WinToolStripTextBox.TextBoxTextAlign = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebToolStripTextBox.TextBoxTextAlign);
			}
		}
	}
	public class TrackBarController : ControlController
	{
		private bool mblnOrientationInitialized = false;

		public Gizmox.WebGUI.Forms.TrackBar WebTrackBar => base.SourceObject as Gizmox.WebGUI.Forms.TrackBar;

		public System.Windows.Forms.TrackBar WinTrackBar => base.TargetObject as System.Windows.Forms.TrackBar;

		public TrackBarController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public TrackBarController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTrackBarMaximum();
			SetWinTrackBarMinimum();
			SetWinTrackBarValue();
			SetWinTrackBarOrientation();
			mblnOrientationInitialized = true;
			SetWinControlSize();
			SetWinTrackBarTickFrequency();
			SetWinTrackBarTickStyle();
		}

		protected override void SetWinControlSize()
		{
			if (mblnOrientationInitialized)
			{
				base.SetWinControlSize();
			}
		}

		protected virtual void SetWinTrackBarTickStyle()
		{
			WinTrackBar.TickStyle = (System.Windows.Forms.TickStyle)GetConvertedEnum(typeof(System.Windows.Forms.TickStyle), WebTrackBar.TickStyle);
		}

		protected virtual void SetWinTrackBarTickFrequency()
		{
			WinTrackBar.TickFrequency = WebTrackBar.TickFrequency;
		}

		protected virtual void SetWinTrackBarOrientation()
		{
			SetWinProperty("Orientation", (System.Windows.Forms.Orientation)GetConvertedEnum(typeof(System.Windows.Forms.Orientation), WebTrackBar.Orientation));
		}

		protected virtual void SetWinTrackBarMaximum()
		{
			WinTrackBar.Maximum = WebTrackBar.Maximum;
		}

		protected virtual void SetWinTrackBarMinimum()
		{
			WinTrackBar.Minimum = WebTrackBar.Minimum;
		}

		protected virtual void SetWinTrackBarValue()
		{
			WinTrackBar.Value = WebTrackBar.Value;
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.TrackBar();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			if (!base.DesignMode)
			{
				WinTrackBar.ValueChanged += WinTrackBar_ValueChanged;
			}
		}

		private void WinTrackBar_ValueChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("VLB", WinTrackBar.Value.ToString());
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			if (!base.DesignMode)
			{
				WinTrackBar.ValueChanged -= WinTrackBar_ValueChanged;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "Value":
				SetWinTrackBarValue();
				break;
			case "Minimum":
				SetWinTrackBarMinimum();
				break;
			case "Maximum":
				SetWinTrackBarMaximum();
				break;
			case "Orientation":
				SetWinTrackBarOrientation();
				break;
			case "TickFrequency":
				SetWinTrackBarTickFrequency();
				break;
			case "TickStyle":
				SetWinTrackBarTickStyle();
				break;
			}
		}
	}
	public class TreeNodeCollectionController : ComponentCollectionController
	{
		public Gizmox.WebGUI.Forms.TreeNodeCollection WebTreeNodes => base.WebObjects as Gizmox.WebGUI.Forms.TreeNodeCollection;

		public Gizmox.WebGUI.Forms.TreeNode WebTreeNode => base.SourceObject as Gizmox.WebGUI.Forms.TreeNode;

		public Gizmox.WebGUI.Forms.TreeView WebTreeView => base.SourceObject as Gizmox.WebGUI.Forms.TreeView;

		public System.Windows.Forms.TreeNodeCollection WinTreeNodes => base.WinObjects as System.Windows.Forms.TreeNodeCollection;

		public ClientTreeNode WinTreeNode => base.TargetObject as ClientTreeNode;

		public ClientTreeView WinTreeView => base.TargetObject as ClientTreeView;

		public TreeNodeCollectionController(IContext objContext, object objWebObject, IList objWebTreeNodes, object objWinObject, IList objWinTreeNodes)
			: base(objContext, objWebObject, objWebTreeNodes, objWinObject, objWinTreeNodes)
		{
		}

		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return new TreeNodeController(base.Context, objWebObject);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientTreeNode();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
		}
	}
	public class TreeNodeController : ComponentController
	{
		private TreeNodeCollectionController mobjTreeNodesController = null;

		private ContextMenuController mobjContextMenuController = null;

		public Gizmox.WebGUI.Forms.TreeNode WebTreeNode => base.SourceObject as Gizmox.WebGUI.Forms.TreeNode;

		public ClientTreeNode WinTreeNode => base.TargetObject as ClientTreeNode;

		public new Gizmox.WebGUI.Forms.Component WebComponent => base.SourceObject as Gizmox.WebGUI.Forms.Component;

		protected new ContextMenuController ContextMenuController
		{
			get
			{
				if (mobjContextMenuController == null && WebComponent != null && WebComponent.ContextMenu != null)
				{
					System.Windows.Forms.ContextMenu objWinControl = new System.Windows.Forms.ContextMenu();
					mobjContextMenuController = new ContextMenuController(base.Context, WebComponent.ContextMenu, objWinControl);
					mobjContextMenuController.Initialize();
				}
				return mobjContextMenuController;
			}
		}

		public TreeNodeController(IContext objContext, object objWebTreeNode, object objWinTreeNode)
			: base(objContext, objWebTreeNode, objWinTreeNode)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, WebTreeNode, WebTreeNode.Nodes, WinTreeNode, WinTreeNode.Nodes);
		}

		public TreeNodeController(IContext objContext, object objWebTreeNode)
			: base(objContext, objWebTreeNode)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, WebTreeNode, WebTreeNode.Nodes, WinTreeNode, WinTreeNode.Nodes);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ImageIndex":
				SetWinTreeNodeImageIndex();
				break;
			case "ImageKey":
				SetWinTreeNodeImageKey();
				break;
			case "Text":
				SetWinTreeNodeText();
				break;
			}
		}

		private void SetWinTreeNodeImageKey()
		{
			if (WebTreeNode.ImageKey != string.Empty)
			{
				if (WinTreeNode.TreeView != null)
				{
					if (WinTreeNode.TreeView.ImageList == null)
					{
						WinTreeNode.TreeView.ImageList = new System.Windows.Forms.ImageList();
					}
					if (GetWinImageIndex(WinTreeNode.TreeView.ImageList, WebTreeNode.Image, WebTreeNode.ImageKey) > -1)
					{
						WinTreeNode.ImageKey = WebTreeNode.ImageKey;
					}
				}
			}
			else
			{
				WinTreeNode.ImageKey = string.Empty;
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTreeNodeText();
			SetWinTreeNodeHasNodes();
			SetWinTreeNodeContextMenu();
			SetWinTreeNodeImageIndex();
			SetWinTreeNodeImageKey();
		}

		protected override void InitializedContained()
		{
			mobjTreeNodesController.Initialize();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientTreeNode();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjTreeNodesController != null)
			{
				mobjTreeNodesController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjTreeNodesController != null)
			{
				mobjTreeNodesController.Terminate();
			}
		}

		protected virtual void SetWinTreeNodeContextMenu()
		{
			if (ContextMenuController != null)
			{
				WinTreeNode.ContextMenu = ContextMenuController.WinContextMenu;
			}
		}

		protected virtual void SetWinTreeNodeText()
		{
			WinTreeNode.Text = WebTreeNode.Text;
		}

		protected virtual void SetWinTreeNodeHasNodes()
		{
			WinTreeNode.HasNodes = WebTreeNode.HasNodes;
		}

		protected virtual void SetWinTreeNodeImageIndex()
		{
			if (WebTreeNode.ImageIndex != -1)
			{
				if (WinTreeNode.TreeView != null)
				{
					if (WinTreeNode.TreeView.ImageList == null)
					{
						WinTreeNode.TreeView.ImageList = new System.Windows.Forms.ImageList();
					}
					WinTreeNode.ImageIndex = GetWinImageIndex(WinTreeNode.TreeView.ImageList, WebTreeNode.Image);
				}
			}
			else if (WinTreeNode.ImageIndex != -1)
			{
				WinTreeNode.ImageIndex = -1;
			}
		}
	}
	public class TreeViewController : ControlController
	{
		private TreeNodeCollectionController mobjTreeNodesController = null;

		public Gizmox.WebGUI.Forms.TreeView WebTreeView => base.SourceObject as Gizmox.WebGUI.Forms.TreeView;

		public System.Windows.Forms.TreeView WinTreeView => base.TargetObject as System.Windows.Forms.TreeView;

		public TreeViewController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, objWebTreeView, WebTreeView.Nodes, WinTreeView, WinTreeView.Nodes);
		}

		public TreeViewController(IContext objContext, object objWebTreeView)
			: base(objContext, objWebTreeView)
		{
			mobjTreeNodesController = new TreeNodeCollectionController(base.Context, objWebTreeView, WebTreeView.Nodes, WinTreeView, WinTreeView.Nodes);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinTreeViewCheckBoxes();
			SetWinTreeViewShowLines();
			SetWinNodes();
			SetWinTreeViewImageIndex();
			SetWinTreeViewImageKey();
			SetWinTreeViewItemHeight();
		}

		protected virtual void SetWinTreeViewCheckBoxes()
		{
			WinTreeView.CheckBoxes = WebTreeView.CheckBoxes;
		}

		protected virtual void SetWinTreeViewShowLines()
		{
			WinTreeView.ShowLines = WebTreeView.ShowLines;
		}

		protected override void SetWinControlBorderStyle()
		{
			WinTreeView.BorderStyle = (System.Windows.Forms.BorderStyle)GetConvertedEnum(typeof(System.Windows.Forms.BorderStyle), WebTreeView.BorderStyle, WinTreeView.BorderStyle);
		}

		protected override void InitializedContained()
		{
			WinTreeView.BeginUpdate();
			WinTreeView.SuspendLayout();
			mobjTreeNodesController.Initialize();
			if (GetWinObject(WebTreeView.SelectedNode) is System.Windows.Forms.TreeNode selectedNode)
			{
				WinTreeView.SelectedNode = selectedNode;
			}
			WinTreeView.EndUpdate();
			WinTreeView.ResumeLayout();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "CheckBoxes":
				SetWinTreeViewCheckBoxes();
				break;
			case "ShowLines":
				SetWinTreeViewShowLines();
				break;
			case "Nodes":
				SetWinNodes();
				break;
			case "ImageIndex":
				SetWinTreeViewImageIndex();
				break;
			case "ImageKey":
				SetWinTreeViewImageKey();
				break;
			case "ItemHeight":
				SetWinTreeViewItemHeight();
				break;
			}
		}

		private void SetWinTreeViewItemHeight()
		{
			if (WebTreeView.HasItemHeight)
			{
				WinTreeView.ItemHeight = WebTreeView.ItemHeight;
			}
			else
			{
				typeof(System.Windows.Forms.TreeView).GetMethod("ResetItemHeight", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod).Invoke(WinTreeView, null);
			}
		}

		private void SetWinTreeViewImageIndex()
		{
			WinTreeView.ImageIndex = WebTreeView.ImageIndex;
		}

		private void SetWinTreeViewImageKey()
		{
			WinTreeView.ImageKey = WebTreeView.ImageKey;
		}

		private void SetWinNodes()
		{
			mobjTreeNodesController.SetWinObjectObjects();
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientTreeView();
		}

		public override void Clear()
		{
			base.Clear();
			if (mobjTreeNodesController != null)
			{
				mobjTreeNodesController.Clear();
			}
		}

		public override void Terminate()
		{
			base.Terminate();
			if (mobjTreeNodesController != null)
			{
				mobjTreeNodesController.Terminate();
			}
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinTreeView.BeforeSelect += WinTreeView_BeforeSelect;
			WinTreeView.AfterSelect += WebTreeView_AfterSelect;
			WinTreeView.BeforeExpand += WebTreeView_BeforeExpand;
		}

		private void WebTreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if (GetControllerByWinObject(e.Node) is TreeNodeController treeNodeController)
			{
				Event obj = CreateWebEvent("Expand", treeNodeController.SourceObject);
				obj.Fire();
				if (treeNodeController.WinTreeNode.HasDummyNodes)
				{
					treeNodeController.Initialize();
				}
			}
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinTreeView.BeforeSelect -= WinTreeView_BeforeSelect;
			WinTreeView.AfterSelect -= WebTreeView_AfterSelect;
			WinTreeView.BeforeExpand -= WebTreeView_BeforeExpand;
		}

		private void WinTreeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			ObjectController controllerByWinObject = GetControllerByWinObject(e.Node);
			if (controllerByWinObject != null)
			{
				Event obj = CreateWebEvent("Action", controllerByWinObject.SourceObject);
				obj.SetParameter("Action", "Click");
				obj.Fire();
			}
		}

		private void WebTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			ObjectController controllerByWinObject = GetControllerByWinObject(e.Node);
			if (controllerByWinObject != null)
			{
				Event obj = CreateWebEvent("Action", controllerByWinObject.SourceObject);
				obj.SetParameter("Action", "Click");
				obj.Fire();
			}
		}
	}
	public class UpDownBaseController : ControlController
	{
		public Gizmox.WebGUI.Forms.UpDownBase WebUpDownBase => base.SourceObject as Gizmox.WebGUI.Forms.UpDownBase;

		public System.Windows.Forms.UpDownBase WinUpDownBase => base.TargetObject as System.Windows.Forms.UpDownBase;

		public UpDownBaseController(IContext objContext, object objWebUpDown)
			: base(objContext, objWebUpDown)
		{
		}

		public UpDownBaseController(IContext objContext, object objWebUpDown, object objWinUpDown)
			: base(objContext, objWebUpDown, objWinUpDown)
		{
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinControlReadOnly();
			SetWinControlTextAlign();
			SetWinControlUpDownAlign();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			switch (objPropertyChangeArgs.Property)
			{
			case "ReadOnly":
				SetWinControlReadOnly();
				break;
			case "TextAlign":
				SetWinControlTextAlign();
				break;
			case "UpDownAlign":
				SetWinControlUpDownAlign();
				break;
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return base.CreateTargetObject(objWebObject);
		}

		protected virtual void SetWinControlReadOnly()
		{
			WinUpDownBase.ReadOnly = WebUpDownBase.ReadOnly;
		}

		protected virtual void SetWinControlTextAlign()
		{
			WinUpDownBase.TextAlign = (System.Windows.Forms.HorizontalAlignment)GetConvertedEnum(typeof(System.Windows.Forms.HorizontalAlignment), WebUpDownBase.TextAlign);
		}

		protected virtual void SetWinControlUpDownAlign()
		{
			WinUpDownBase.UpDownAlign = (System.Windows.Forms.LeftRightAlignment)GetConvertedEnum(typeof(System.Windows.Forms.LeftRightAlignment), WebUpDownBase.UpDownAlign);
		}
	}
	public class UserControlController : ContainerControlController
	{
		private IObservableLayoutItem WebLayoutItem => base.SourceObject as IObservableLayoutItem;

		public Gizmox.WebGUI.Forms.UserControl WebUserControl => base.SourceObject as Gizmox.WebGUI.Forms.UserControl;

		public System.Windows.Forms.UserControl WinUserControl => base.TargetObject as System.Windows.Forms.UserControl;

		public UserControlController(IContext objContext, object objWebControl, object objWinControl)
			: base(objContext, objWebControl, objWinControl)
		{
		}

		public UserControlController(IContext objContext, object objWebControl)
			: base(objContext, objWebControl)
		{
		}

		public override void InitializeNew()
		{
			base.InitializeNew();
			base.WinControl.SuspendLayout();
			if (base.WebControl is Gizmox.WebGUI.Forms.UserControl)
			{
				base.WinControl.ClientSize = WebLayoutItem.Size;
			}
			base.WinControl.ResumeLayout();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinUserControlAutoSizeMode();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "AutoSizeMode")
			{
				SetWinUserControlAutoSizeMode();
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.UserControl();
		}

		protected override void SetWinControlLocation()
		{
			if (WebUserControl.Parent != null)
			{
				base.SetWinControlLocation();
			}
		}

		protected virtual void SetWinUserControlAutoSizeMode()
		{
			WinUserControl.AutoSizeMode = (System.Windows.Forms.AutoSizeMode)GetConvertedEnum(typeof(System.Windows.Forms.AutoSizeMode), WebUserControl.AutoSizeMode);
		}
	}
	public class WorkspaceTabsController : TabControlController
	{
		public WorkspaceTabsController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public WorkspaceTabsController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			base.WinTabControl.ControlAdded += WinTabControl_ControlAdded;
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			base.WinTabControl.ControlAdded -= WinTabControl_ControlAdded;
		}

		private void WinTabControl_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			if (e.Control == null || base.WinTabControl == null || base.WebTabControl == null)
			{
				return;
			}
			bool flag = false;
			StackTrace stackTrace = new StackTrace();
			if (stackTrace != null)
			{
				for (int i = 0; i < stackTrace.FrameCount; i++)
				{
					MethodBase method = stackTrace.GetFrame(i).GetMethod();
					if (method != null)
					{
						string name = method.Name;
						string fullName = method.DeclaringType.FullName;
						if (name == "InitializeNewComponent" && fullName == "System.Windows.Forms.Design.TabControlDesigner")
						{
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				base.WinTabControl.Controls.Remove(e.Control);
				if (GetControllerByWinObject(e.Control) is TabPageController { WebTabPage: not null } tabPageController)
				{
					base.WebTabControl.TabPages.Remove(tabPageController.WebTabPage);
					base.DesignServices.UnregisterWebComponent(tabPageController.WebTabPage);
				}
			}
		}
	}
}
