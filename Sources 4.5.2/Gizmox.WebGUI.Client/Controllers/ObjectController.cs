#region Using

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using WebResources = Gizmox.WebGUI.Common.Resources;

using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common.Extensibility;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ObjectController Class

    /// <summary>
    /// Summary description for ObjectController.
    /// </summary>
    
	public class ObjectController : IClientDesigner, IClientObjectController
	{
		#region Class Members
		
		private object mobjWebObject = null;
		
		private object mobjWinObject = null;
		
		private IContext mobjContext = null;
		
		/// <summary>
		/// Indicates if desiner events are suspended
		/// </summary>
		private bool mblnDesignSuspended = false;
		
		/// <summary>
		/// Suspended reference count
		/// </summary>
		private int mintDesignSuspended = 0;
		
		/// <summary>
		/// Design time initialization
		/// </summary>
		private bool mblnDesignInitialization = false;

        private float mfltTargetVerticalScaleFactor = -1.0f;

        private float mfltTargetHorizontalScaleFactor = -1.0f;
		
		private static Hashtable mobjDesignTimeControllers = null;
		
		private static Hashtable mobjDesignTimeControllersSync = null;

        private static Hashtable mobjClientControllers = null;

        private static Hashtable mobjClientControllersSync = null;
		
		#endregion Class Members
		
		#region C'Tor/D'Tor

		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		public ObjectController(IContext objContext, object objWebObject) 
		{
			this.mobjWebObject = objWebObject;
			this.mobjWinObject = null;
            this.mobjContext = objContext;
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		public ObjectController(IContext objContext, object objWebObject,object objWinObject)
		{
            if (objWebObject == null)
            {
                this.mobjWebObject = this.CreateSourceObject(objWinObject);
            }
            else
            {
                this.mobjWebObject = objWebObject;
            }

            if (objWinObject == null)
            {
                this.mobjWinObject = this.CreateTargetObject(objWebObject);
            }
            else
            {
                this.mobjWinObject = objWinObject;
            }

			
			this.mobjContext = objContext;
		}
		
		/// <summary>
		///
		/// </summary>
		static ObjectController()
		{
			mobjDesignTimeControllers = new Hashtable();
			mobjDesignTimeControllersSync = Hashtable.Synchronized(mobjDesignTimeControllers);

            mobjClientControllers = new Hashtable();
            mobjClientControllersSync = Hashtable.Synchronized(mobjClientControllers);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		#region General Methods

        public virtual void UpdateSource()
        {
        }

        public virtual void UpdateTarget()
        {
        }
		
		/// <summary>
		///
		/// </summary>
		public void Initialize()
		{
			this.Initialize(false);
		}

        /// <summary>
        /// Initializes the new.
        /// </summary>
        public virtual void InitializeNew()
        {
        }
		
		/// <summary>
		///
		/// </summary>
		/// <param name="blnDesignInitialization"></param>
		internal void Initialize(bool blnDesignInitialization)
		{
			this.mblnDesignInitialization = blnDesignInitialization;
            try
            {
                this.SuspendDesigner();
                this.InitializeController();
            }
            finally
            {
                // Resume designer.
                this.ResumeDesigner();
            }
			this.mblnDesignInitialization = false;
		}
		
		/// <summary>
		/// Initializes the controller
		/// </summary>
		protected virtual void InitializeController()
		{
			InitializedContained();
			WireEvents();
			
		}
		
		/// <summary>
		/// Initialize contained components
		/// </summary>
		protected virtual void InitializedContained()
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		public void Load()
		{
			this.Load(false);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="blnDesignInitialization"></param>
		internal void Load(bool blnDesignInitialization)
		{
			this.mblnDesignInitialization = blnDesignInitialization;
            try
            {
                this.SuspendDesigner();
                this.LoadController();
            }
            finally
            {
                // Resume designer.
                this.ResumeDesigner();
            }
			this.mblnDesignInitialization = false;
		}
		
		/// <summary>
		/// Loads properties after component is assigned to its parent
		/// </summary>
		protected virtual void LoadController()
		{
		}
		
		/// <summary>
		/// Clears controller internal controllers
		/// </summary>
		public virtual void Clear()
		{
		}
		
		/// <summary>
		/// Terminates the controller
		/// </summary>
		public virtual void Terminate()
		{
			UnwireEvents();
		}
		
		/// <summary>
		/// Fires property changed
		/// </summary>
		/// <param name="strProperty"></param>
		public virtual void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
		}
		
		/// <summary>
		/// Fires property changed
		/// </summary>
		/// <param name="strProperty"></param>
		public virtual void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
		}

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        protected virtual void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        protected virtual void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            //
        }

		/// <summary>
		/// Wires required events for controller to work
		/// </summary>
		protected virtual void WireEvents()
		{
			if (this.DesignMode)
			{
				WireDesignTimeEvents();
			}
		}
		
		/// <summary>
		/// Wires required events for controller to work in design time
		/// </summary>
		protected virtual void WireDesignTimeEvents()
		{
		}
		
		/// <summary>
		/// Unwires wired events
		/// </summary>
		protected virtual void UnwireEvents()
		{
			if (this.DesignMode)
			{
				UnwireDesignTimeEvents();
			}
		}
		
		/// <summary>
		/// Unwires wired design time events
		/// </summary>
		protected virtual void UnwireDesignTimeEvents()
		{
		}

        private bool IsSubclassOf(Type objSubClass, Type objTargetClass)
        {
            bool blnIsSubclassOf = false;

            if (objTargetClass != null && objSubClass != null)
            {
                blnIsSubclassOf = (objTargetClass == objSubClass || objSubClass.IsSubclassOf(objTargetClass));
            }

            return blnIsSubclassOf;
        }

		/// <summary>
		/// Generic create winforms control
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
        protected virtual object CreateTargetObject(object objWebObject)
        {
            // If there is a web object
            if (objWebObject != null)
            {
                Type objWebType = objWebObject.GetType();

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.Form)))
                {
                    return new Forms.ClientForm();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.UserControl)))
                {
                    return new System.Windows.Forms.UserControl();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.TableLayoutPanel)))
                {
                    return new System.Windows.Forms.TableLayoutPanel();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.FlowLayoutPanel)))
                {
                    return new System.Windows.Forms.FlowLayoutPanel();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.ContextMenu)))
                {
                    return new System.Windows.Forms.ContextMenu();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.TabPage)))
                {
                    return new System.Windows.Forms.TabPage();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.Panel)))
                {
                    return new Forms.ClientPanel();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.ListView)))
                {
                    return new Forms.ClientListView();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.ListViewItem)))
                {
                    return new Forms.ClientListViewItem();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.TreeView)))
                {
                    return new Forms.ClientTreeView();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.ColumnHeader)))
                {
                    return new Forms.ClientColumnHeader();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.HtmlBox)))
                {
                    return new System.Windows.Forms.Panel();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.NumericUpDown)))
                {
                    return new System.Windows.Forms.NumericUpDown();
                }

                if (IsSubclassOf(objWebType, typeof(Gizmox.WebGUI.Forms.DomainUpDown)))
                {
                    return new System.Windows.Forms.DomainUpDown();
                }

                string strWinType = objWebType.FullName.Replace("Gizmox.WebGUI.Forms", "System.Windows.Forms").Replace("HtmlBox", "Panel");
                Assembly objWinAssembly = Assembly.Load("System.Windows.Forms");
                if (objWinAssembly != null)
                {

                    Type objWinType = objWinAssembly.GetType(strWinType); ;
                    if (objWinType == null)
                    {
                        objWinType = typeof(ObjectController).Assembly.GetType(strWinType);
                    }

                    if (objWinType != null)
                    {
                        return Activator.CreateInstance(objWinType);
                    }
                }

                if (objWebObject is IControl)
                {
                    return new System.Windows.Forms.Panel();
                }
                else
                {
                    return Activator.CreateInstance(objWebObject.GetType());
                }

            }

            return null;
        }
		
		/// <summary>
		/// Generic create webforms control
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
        protected virtual object CreateSourceObject(object objTargetObject)
        {
            // If there is a web object
            if (objTargetObject != null)
            {
                Type objWinType = objTargetObject.GetType();

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.Form)))
                {
                    return new Gizmox.WebGUI.Forms.Form();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.UserControl)))
                {
                    return new Gizmox.WebGUI.Forms.UserControl();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.TableLayoutPanel)))
                {
                    return new Gizmox.WebGUI.Forms.TableLayoutPanel();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.FlowLayoutPanel)))
                {
                    return new Gizmox.WebGUI.Forms.FlowLayoutPanel();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.TabPage)))
                {
                    return new Gizmox.WebGUI.Forms.TabPage();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.Panel)))
                {
                    return new Gizmox.WebGUI.Forms.Panel();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.ListView)))
                {
                    return new Gizmox.WebGUI.Forms.ListView();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.ListViewItem)))
                {
                    return new Gizmox.WebGUI.Forms.ListViewItem();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.TreeView)))
                {
                    return new Gizmox.WebGUI.Forms.TreeView();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.ColumnHeader)))
                {
                    return new Gizmox.WebGUI.Forms.ColumnHeader();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewComboBoxColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewImageColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewLinkColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewButtonColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewButtonColumn();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewCheckBoxColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewTextBoxColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
                }

                if (IsSubclassOf(objWinType, typeof(System.Windows.Forms.DataGridViewColumn)))
                {
                    return new Gizmox.WebGUI.Forms.DataGridViewColumn();
                }

                string strWebType = objWinType.FullName.Replace("System.Windows.Forms", "Gizmox.WebGUI.Forms");
                Assembly objWebAssembly = Assembly.Load("Gizmox.WebGUI.Forms");
                if (objWebAssembly != null)
                {

                    Type objWebType = objWebAssembly.GetType(strWebType);
                    if (objWebType == null)
                    {
                        objWebType = typeof(ObjectController).Assembly.GetType(strWebType);
                    }

                    if (objWebType != null)
                    {
                        return Activator.CreateInstance(objWebType);
                    }
                }

                return Activator.CreateInstance(objWinType);
            }
         
            return null;
        }

		#endregion General Methods
		
		#region Utility Methods
		
		/// <summary>
		/// Suspend notifictions
		/// </summary>
		protected void SuspendDesigner()
		{
			this.mintDesignSuspended++;
			this.mblnDesignSuspended = true;
		}
		
		/// <summary>
		/// Resume notification
		/// </summary>
		protected void ResumeDesigner()
		{
			this.mintDesignSuspended--;
			if (this.mintDesignSuspended == 0)
			{
				this.mblnDesignSuspended = false;
			}
		}
		
		/// <summary>
		/// Suspend notifictions
		/// </summary>
		protected void SuspendNotifications()
		{
			((IContextNotifications)this.Context).SuspendNotifications();
		}
		
		/// <summary>
		/// Indicates if notifications are suspended
		/// </summary>
		protected bool IsNotificationSuspened
		{
			get
			{
				return ((IContextNotifications)this.Context).IsNotificationSuspened;
			}
		}

		/// <summary>
		/// Resume notification
		/// </summary>
		protected void ResumeNotifications()
		{
			((IContextNotifications)this.Context).ResumeNotifications();
		}

        protected void RefreshDesigner()
        {
            ((IContextServices)this.Context).RefreshDesigner();
        }

		/// <summary>
		/// Gets the mapped WinForms object
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
		protected object GetWinObject(object objWebObject)
		{
			return ((IContextServices)this.Context).GetWinObject(objWebObject);
		}
		
		/// <summary>
		/// Gets the mapped Web object
		/// </summary>
		/// <param name="objWinObject"></param>
		/// <returns></returns>
		protected object GetWebObject(object objWinObject)
		{
			return ((IContextServices)this.Context).GetWebObject(objWinObject);
		}
		
		/// <summary>
		/// Registers a controller
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <param name="objWinObject"></param>
		/// <param name="objController"></param>
		protected void RegisterController(Controllers.ObjectController objController)
		{
			((IContextServices)this.Context).RegisterController(objController);
		}
		
		/// <summary>
		/// Gets a controller using a Web object
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
		protected Controllers.ObjectController GetControllerByWebObject(object objWebObject)
		{
            return ((IContextServices)this.Context).GetControllerByWebObject(objWebObject) as Controllers.ObjectController;
		}
		
		/// <summary>
		/// Gets a controller using a WinForms object
		/// </summary>
		/// <param name="objWinObject"></param>
		/// <returns></returns>
		protected Controllers.ObjectController GetControllerByWinObject(object objWinObject)
		{
            return ((IContextServices)this.Context).GetControllerByWinObject(objWinObject) as Controllers.ObjectController;
		}
		
		/// <summary>
		/// Unregister controller by Web object reference
		/// </summary>
		/// <param name="objWebObject"></param>
		protected void UnregisterControllerByWebObject(object objWebObject)
		{
			((IContextServices)this.Context).UnregisterControllerByWebObject(objWebObject);
		}
		
		/// <summary>
		/// Unregister controller by WinForms object reference
		/// </summary>
		/// <param name="objWinObject"></param>
		protected void UnregisterControllerByWinObject(object objWinObject)
		{
			((IContextServices)this.Context).UnregisterControllerByWinObject(objWinObject);
		}
		
		/// <summary>
		/// Convert enum from one type to another
		/// </summary>
		/// <param name="enmTargetType"></param>
		/// <param name="objValue"></param>
		/// <param name="objDefault"></param>
		/// <returns></returns>
		protected object GetConvertedEnum(Type enmTargetType, object objValue)
		{
			return this.GetConvertedEnum(enmTargetType, objValue, null);
		}
		
		/// <summary>
		/// Convert enum from one type to another with default value for non existing enums
		/// </summary>
		/// <param name="enmTargetType"></param>
		/// <param name="objValue"></param>
		/// <param name="objDefault"></param>
		/// <returns></returns>
		protected object GetConvertedEnum(Type enmTargetType, object objValue, object objDefault)
		{
			try
			{
				if (objValue != null)
				{
					string strValue = objValue.ToString();
					object objReturn = Enum.Parse(enmTargetType, strValue);
					return objReturn;
				}
				else
				{
					return objDefault;
				}
			}
			catch (Exception)
			{
				return objDefault;
			}
		}
		
		
		#endregion Utility Methods
		
		#region IContextResources Members


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objWinImagelist"></param>
        /// <param name="objResourceHandler"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        protected int GetWinImageIndex(WinForms.ImageList objWinImagelist, WebResources.ResourceHandle objResourceHandler, string strKey)
        {
            return ((IContextResources)this.Context).GetWinImageIndex(objWinImagelist, objResourceHandler,strKey );
        }

		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWinImagelist"></param>
		/// <param name="objResourceHandler"></param>
		protected int GetWinImageIndex(WinForms.ImageList objWinImagelist, WebResources.ResourceHandle objResourceHandler)
		{
			return ((IContextResources)this.Context).GetWinImageIndex(objWinImagelist, objResourceHandler);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objGatewayResourceHandle"></param>
		protected Stream GetGatewayResourceStream(WebResources.GatewayResourceHandle objGatewayResourceHandle)
		{
			return ((IContextResources)this.Context).GetGatewayResourceStream(objGatewayResourceHandle);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objResourceHandler"></param>
		protected Image GetWinImageFromResourceHandle(WebResources.ResourceHandle objResourceHandler)
		{
			return ((IContextResources)this.Context).GetWinImageFromResourceHandle(objResourceHandler);
		}
		
		
		#endregion IContextResources Members

        #region IDesignerFilter Members

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


        void System.ComponentModel.Design.IDesignerFilter.PostFilterAttributes(IDictionary attributes)
        {
            this.PostFilterAttributes(attributes);
        }

        void System.ComponentModel.Design.IDesignerFilter.PostFilterEvents(IDictionary events)
        {
            this.PostFilterAttributes(events);
        }

        void System.ComponentModel.Design.IDesignerFilter.PostFilterProperties(IDictionary properties)
        {
            this.PostFilterAttributes(properties);
        }

        void System.ComponentModel.Design.IDesignerFilter.PreFilterAttributes(IDictionary attributes)
        {
            this.PostFilterAttributes(attributes);
        }

        void System.ComponentModel.Design.IDesignerFilter.PreFilterEvents(IDictionary events)
        {
            this.PostFilterAttributes(events);
        }

        void System.ComponentModel.Design.IDesignerFilter.PreFilterProperties(IDictionary properties)
        {
            this.PostFilterAttributes(properties);
        }

        #endregion

        #region IClientDesigner Members

        System.ComponentModel.Design.DesignerVerbCollection IClientDesigner.GetVerbs()
        {
            return this.Verbs;
        }

        /// <summary>
        /// Provides verbs for the designer
        /// </summary>
        protected virtual System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                return new System.ComponentModel.Design.DesignerVerbCollection();
            }
        }

        #endregion
		
		#region Controller Creation Methods
		
		/// <summary>
		/// Creates controller for a web object type
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebType"></param>
		/// <returns></returns>
		internal static ObjectController CreateControllerByWebType(IContext objContext, Type objWebType)
		{
			// Create web object instance
			object objWebObject = Activator.CreateInstance(objWebType);
			if (objWebObject != null)
			{
				// Get design time services
				IClientDesignServices objDesignServices = ((Context)objContext).DesignServices;
				if (objDesignServices != null)
				{
					// Register web component
					IComponent objWebComponent = objWebObject as IComponent;
					if (objWebComponent != null && objWebComponent.Site == null)
					{
						objDesignServices.RegisterWebComponent(objWebComponent);
					}
				}
				
				// Return new component controller
				return CreateControllerByWebObject(objContext, objWebObject);
			}
			else
			{
				return null;
			}
		}
		
		/// <summary>
		/// Creates controller for a web object type attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebType"></param>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
		internal static ObjectController CreateTypeController(IContext objContext, Type objWebType, object objWebObject)
		{

            Type objControllerType = null;
            
            // If is in design mode
            if (((Context)objContext).DesignMode)
            {
                // If not searched the current type
                if (!mobjDesignTimeControllersSync.Contains(objWebType))
                {
                    // Loop all type attributes
                    AttributeCollection objAttributes = TypeDescriptor.GetAttributes(objWebType);
                    foreach (Attribute objAttribute in objAttributes)
                    {
                        // Get design time controller attribute
                        DesignTimeControllerAttribute objDesignControllerAttribute = objAttribute as DesignTimeControllerAttribute;
                        if (objDesignControllerAttribute != null)
                        {
                            // Store design time controller type
                            mobjDesignTimeControllersSync[objWebType] = objControllerType = objDesignControllerAttribute.Type;
                            break;
                        }
                    }

                    // If controller was not found
                    if (objControllerType == null)
                    {
                        // Store null to prevent future searches for this type
                        mobjDesignTimeControllersSync[objWebType] = null;
                    }
                }
                else
                {
                    // Gets the cached controller type
                    objControllerType = mobjDesignTimeControllersSync[objWebType] as Type;
                }
            }
            else
            {
                // If not searched the current type
                if (!mobjClientControllersSync.Contains(objWebType))
                {
                    // Loop all type attributes
                    AttributeCollection objAttributes = TypeDescriptor.GetAttributes(objWebType);
                    foreach (Attribute objAttribute in objAttributes)
                    {
                        // Get design time controller attribute
                        ClientControllerAttribute objDesignControllerAttribute = objAttribute as ClientControllerAttribute;
                        if (objDesignControllerAttribute != null)
                        {
                            // Store design time controller type
                            mobjClientControllersSync[objWebType] = objControllerType = objDesignControllerAttribute.Type;
                            break;
                        }
                    }

                    // If controller was not found
                    if (objControllerType == null)
                    {
                        // Store null to prevent future searches for this type
                        mobjClientControllersSync[objWebType] = null;
                    }
                }
                else
                {
                    // Gets the cached controller type
                    objControllerType = mobjClientControllersSync[objWebType] as Type;
                }
            }
			
			// If found controller type return it
			if (objControllerType != null)
            {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                // Create controller instance
				return Activator.CreateInstance(objControllerType, objContext, objWebObject) as ObjectController;
#else
				// Create controller instance
				return Activator.CreateInstance(objControllerType,new object[]{ objContext, objWebObject}) as ObjectController;
#endif
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// Creates the controller by web object.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebObject">The obj web object.</param>
        /// <returns></returns>
		public static ObjectController CreateControllerByWebObject(IContext objContext, object objWebObject)
		{
			Type objWebType = objWebObject.GetType();
			
			// Try to get controller from attributes.
			// If controller is not found using attributes then use hardcoded implementation.
			ObjectController objTypeController = CreateTypeController(objContext, objWebType, objWebObject);
			if (objTypeController != null)
			{
				return objTypeController;
			}
			else
			{
				
				if (objWebObject is WebForms.ContextMenu)
				{
					return new ContextMenuController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.MainMenu)
				{
					return new MainMenuController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.Form)
				{
					return new FormController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.UserControl)
				{
					return new UserControlController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.TreeView)
				{
					return new TreeViewController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.TreeView)
				{
					return new TreeViewController(objContext, objWebObject);
                }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                if (objWebObject is WebForms.TableLayoutPanel)
				{

					return new TableLayoutPanelController(objContext, objWebObject);
				}
#endif
				if (objWebObject is WebForms.TrackBar)
				{
					return new TrackBarController(objContext, objWebObject);
				}

				if (objWebObject is WebForms.TabControl)
				{
					return new TabControlController(objContext, objWebObject);
				}

				if (objWebObject is WebForms.PictureBox)
				{
					return new PictureBoxController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.DataGridView)
				{
					return new DataGridViewController(objContext, objWebObject);
				}
                if (objWebObject is WebForms.DataGridViewColumn)
                {
                    return new DataGidViewColumnController(objContext, objWebObject);
                }
				if (objWebObject is WebForms.PropertyGrid)
				{
					return new PropertyGridController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.FlowLayoutPanel)
				{
					return new FlowLayoutPanelController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.ToolBar)
				{
					return new ToolBarController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.TextBox)
				{
					return new TextBoxController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.RadioButton)
				{
					return new RadioButtonController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.CheckBox)
				{
					return new CheckBoxController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.Button)
				{
					return new ButtonController(objContext, objWebObject);
				}
				
				if (objWebObject is WebForms.UserControl)
				{
					return new UserControlController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.ListView)
				{
					return new ListViewController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.ColorListBox)
				{
					return new ControlController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.ListBox)
				{
					return new ListBoxController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.ComboBox)
				{
					return new ComboBoxController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.TabPage)
				{
					return new ControlController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.Panel)
				{
					return new PanelController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.Label)
				{
					return new LabelController(objContext, objWebObject);
				}
                if (objWebObject is WebForms.StatusStrip)
                {
                    return new StatusStripController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ContextMenuStrip)
                {
                    return new ContextMenuStripController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripDropDownMenu)
                {
                    return new ToolStripDropDownMenuController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripDropDown)
                {
                    return new ToolStripDropDownController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.MenuStrip)
                {
                    return new MenuStripController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStrip)
                {
                    return new ToolStripController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripContainer)
                {
                    return new ToolStripContainerController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripPanel)
                {
                    return new ToolStripPanelController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripButton)
                {
                    return new ToolStripButtonController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripComboBox)
                {
                    return new ToolStripComboBoxController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripDropDownButton)
                {
                    return new ToolStripDropDownButtonController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripLabel)
                {
                    return new ToolStripLabelController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripMenuItem)
                {
                    return new ToolStripMenuItemController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripProgressBar)
                {
                    return new ToolStripProgressBarController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripSeparator)
                {
                    return new ToolStripSeparatorController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripSplitButton)
                {
                    return new ToolStripSplitButtonController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripStatusLabel)
                {
                    return new ToolStripStatusLabelController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.ToolStripTextBox)
                {
                    return new ToolStripTextBoxController(objContext, objWebObject);
                }
                if (objWebObject is WebForms.Control)
				{
					return new ControlController(objContext, objWebObject);
				}
				if (objWebObject is WebForms.Component)
				{
					return new ObjectController(objContext, objWebObject);
				}

                return new GenericComponentController(objContext, objWebObject);
			}
		}

        /// <summary>
        /// Creates the controller by win object.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWinObject">The obj win object.</param>
        /// <returns></returns>
        public static ObjectController CreateControllerByWinObject(IContext objContext, object objWinObject)
        {
            if (objWinObject is WinForms.ContextMenu)
            {
                return new ContextMenuController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.MainMenu)
            {
                return new MainMenuController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.Form)
            {
                return new FormController(objContext, null, objWinObject as WinForms.Form);
            }
            if (objWinObject is WinForms.UserControl)
            {
                return new UserControlController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.TreeView)
            {
                return new TreeViewController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.TreeView)
            {
                return new TreeViewController(objContext, null, objWinObject);
            }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (objWinObject is WinForms.TableLayoutPanel)
            {

                return new TableLayoutPanelController(objContext, null, objWinObject);
            }
#endif
            if (objWinObject is WinForms.TrackBar)
            {
                return new TrackBarController(objContext, null, objWinObject);
            }

            if (objWinObject is WinForms.TabControl)
            {
                return new TabControlController(objContext, null, objWinObject);
            }

            if (objWinObject is WinForms.PictureBox)
            {
                return new PictureBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.DataGridView)
            {
                return new DataGridViewController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.DataGridViewColumn)
            {
                return new DataGidViewColumnController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.PropertyGrid)
            {
                return new PropertyGridController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.FlowLayoutPanel)
            {
                return new FlowLayoutPanelController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolBar)
            {
                return new ToolBarController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.TextBox)
            {
                return new TextBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.RadioButton)
            {
                return new RadioButtonController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.CheckBox)
            {
                return new CheckBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.Button)
            {
                return new ButtonController(objContext, null, objWinObject);
            }

            if (objWinObject is WinForms.UserControl)
            {
                return new UserControlController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ListView)
            {
                return new ListViewController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ListBox)
            {
                return new ListBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ComboBox)
            {
                return new ComboBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.TabPage)
            {
                return new ControlController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.Panel)
            {
                return new PanelController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.Label)
            {
                return new LabelController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.StatusStrip)
            {
                return new StatusStripController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ContextMenuStrip)
            {
                return new ContextMenuStripController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripDropDownMenu)
            {
                return new ToolStripDropDownMenuController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripDropDown)
            {
                return new ToolStripDropDownController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.MenuStrip)
            {
                return new MenuStripController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStrip)
            {
                return new ToolStripController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripContainer)
            {
                return new ToolStripContainerController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripPanel)
            {
                return new ToolStripPanelController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripButton)
            {
                return new ToolStripButtonController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripDropDownButton)
            {
                return new ToolStripDropDownButtonController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripMenuItem)
            {
                return new ToolStripMenuItemController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripSeparator)
            {
                return new ToolStripSeparatorController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripSplitButton)
            {
                return new ToolStripSplitButtonController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripStatusLabel)
            {
                return new ToolStripStatusLabelController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripLabel)
            {
                return new ToolStripLabelController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripTextBox)
            {
                return new ToolStripTextBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripProgressBar)
            {
                return new ToolStripProgressBarController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.ToolStripComboBox)
            {
                return new ToolStripComboBoxController(objContext, null, objWinObject);
            }
            if (objWinObject is WinForms.Control)
            {
                return new ControlController(objContext, null, objWinObject);
            }

            if (objWinObject is IComponent)
            {
                return new GenericComponentController(objContext, null, (IComponent)objWinObject);
            }
            else
            {
                return new ObjectController(objContext, null, objWinObject);
            }

        }


		#endregion Controller Creation Methods
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		/// Gets a flag indicating if design events should be suspended
		/// </summary>
		protected bool DesignSuspended
		{
			get
			{
				return mblnDesignSuspended;
			}
		}
		
		/// <summary>
		/// Gets a flag indicating if in design time initialization process
		/// </summary>
		protected bool DesignInitialization
		{
			get
			{
				return mblnDesignInitialization;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected IClientDesignServices DesignServices
		{
			get
			{
				return ((Context)this.Context).DesignServices;
			}
		}
		
		/// <summary>
		/// Gets a flag indicating design mode
		/// </summary>
		protected bool DesignMode
		{
			get
			{
				return ((Context)this.Context).DesignMode;
			}
		}
		
		/// <summary>
		/// Gets the current context object
		/// </summary>
		public IContext Context
		{
			get
			{
				return this.mobjContext;
			}
		}
		
		/// <summary>
		/// Gets the controlled web object
		/// </summary>
		public object SourceObject
		{
			get
			{
				return this.mobjWebObject;
			}
		}
		
		/// <summary>
		/// Gets the controlled winforms object
		/// </summary>
        public object TargetObject
        {
            get
            {
                // If winforms object is not initialzed
                if (this.mobjWinObject == null)
                {
                    // Initialize winforms object
                    this.mobjWinObject = CreateTargetObject(this.mobjWebObject);

                    // Set context if posible
                    IContextContainer objContextContainer = this.mobjWinObject as IContextContainer;
                    if (objContextContainer != null)
                    {
                        objContextContainer.Context = this.Context;
                    }
					
					
					
                }
                return this.mobjWinObject;
            }
        }
        /// <summary>
        /// Gets the selectable object.
        /// </summary>
        /// <value>The selectable object.</value>
        public virtual object SelectableObject
        {
            get
            {
                return this.TargetObject;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [use menu deisgner].
        /// </summary>
        /// <value><c>true</c> if [use menu deisgner]; otherwise, <c>false</c>.</value>
        protected virtual bool UseVsMenuDeisgner
        {
            get
            {
                object objTargetObject = this.TargetObject;
                if (objTargetObject != null)
                {
                    return objTargetObject.GetType().Name.IndexOf("Menu") != -1;
                }

                return false;
            }
        }


        /// <summary>
        /// Calculates the target scale factor.
        /// </summary>
        private void CalculateTargetScaleFactor()
        {
            IClientDesignServices objDesignServices = ((Context)this.Context).DesignServices;
            if (objDesignServices != null)
            {
                SizeF objSize = objDesignServices.GetFormScaleFactor(null);
                if (!objSize.IsEmpty)
                {
                    this.mfltTargetHorizontalScaleFactor = objSize.Width;
                    this.mfltTargetVerticalScaleFactor = objSize.Height;
                }
                else
                {
                    this.mfltTargetHorizontalScaleFactor = 1;
                    this.mfltTargetVerticalScaleFactor = 1;
                }
            }           
        }

        /// <summary>
        /// Gets the target vertical scale factor.
        /// </summary>
        protected float TargetVerticalScaleFactor
        {
            get
            {
                if (this.mfltTargetVerticalScaleFactor < 0)
                {                   
                    CalculateTargetScaleFactor();                   
                }

                return this.mfltTargetVerticalScaleFactor;
            }
        }

        /// <summary>
        /// Gets the target horizontal scale factor.
        /// </summary>
        protected float TargetHorizontalScaleFactor
        {
            get
            {
                if (this.mfltTargetHorizontalScaleFactor < 0)
                {                   
                    CalculateTargetScaleFactor();                   
                }

                return this.mfltTargetHorizontalScaleFactor;
            }
        }

		#endregion Properties


        #region IClientObjectController Members

        void IClientObjectController.SetParent(IClientObjectController objController)
        {
            SetParentController((ObjectController)objController);
        }

        object IClientObjectController.SelectableObject
        {
            get
            {
                return this.SelectableObject;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [use menu deisgner].
        /// </summary>
        /// <value><c>true</c> if [use menu deisgner]; otherwise, <c>false</c>.</value>
        bool IClientObjectController.UseVsMenuDeisgner
        {
            get
            {
                return this.UseVsMenuDeisgner;
            }
        }

        protected virtual void SetParentController(ObjectController objController)
        {
        }

        #endregion


        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ReplaceSource(object objSource)
        {
            if (this.DesignMode)
            {
                this.UnregisterControllerByWebObject(mobjWebObject);

                mobjWebObject = objSource;

                this.RegisterController(this);
                

                Initialize(true);
            }
        }
    }
	
	#endregion ObjectController Class
	
}
