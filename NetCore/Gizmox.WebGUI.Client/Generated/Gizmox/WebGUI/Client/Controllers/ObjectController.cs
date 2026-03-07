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

namespace Gizmox.WebGUI.Client.Controllers
{
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
}
