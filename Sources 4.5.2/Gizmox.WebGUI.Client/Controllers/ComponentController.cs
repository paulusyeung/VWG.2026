#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Client.Design;
using System.Drawing;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ComponentController Class
	
	/// <summary>
	/// Controls the relations between a webgui component and a winforms component
	/// </summary>
	
	public class ComponentController : GenericComponentController
	{
		#region Class Members
		
		private ContextMenuController mobjContextMenuController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ComponentController(IContext objContext,object objWebComponent,object objWinComponent) : base(objContext,objWebComponent,objWinComponent)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ComponentController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents();
			
			IObservableItem objObservableItem = this.WebComponent as IObservableItem;
			if(objObservableItem!=null && !this.DesignMode)
			{
				objObservableItem.ObservableItemPropertyChanged+=new ObservableItemPropertyChangedHandler(objObservableItem_ObservableItemPropertyChanged);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			
			IObservableItem objObservableItem = this.WebComponent as IObservableItem;
			if (objObservableItem != null && !this.DesignMode)
			{
				objObservableItem.ObservableItemPropertyChanged-=new ObservableItemPropertyChangedHandler(objObservableItem_ObservableItemPropertyChanged);
			}
		}

        /// <summary>
        /// Sets the wincomponet property and fires a changing event
        /// </summary>
        /// <param name="strPropertyName"></param>
        /// <param name="objNewValue"></param>
        protected void SetWinProperty(string strPropertyName, object objNewValue)
        {
            // Suspend designer notifications
            this.SuspendDesigner();
            this.SuspendNotifications();

            try
            {
                // Get the win component
                object objWinComponent = this.WinComponent;
                if (objWinComponent != null)
                {
                    // Get the property info from the component type
                    PropertyInfo objPropertyInfo = objWinComponent.GetType().GetProperty(strPropertyName);
                    if (objPropertyInfo != null)
                    {
                        // If in design mode fire changing event
                        if (this.DesignMode)
                        {
                            this.DesignServices.FireWinComponentChanging(this.WinComponent, strPropertyName);
                        }

                        // get the old valud of the property
                        object objOldValue = objPropertyInfo.GetValue(objWinComponent, new object[] { });

                        // Set the new valud
                        objPropertyInfo.SetValue(objWinComponent, objNewValue, new object[] { });

                        // If in design mode fire changed event
                        if (this.DesignMode)
                        {
                            this.DesignServices.FireWinComponentChanged(this.WinComponent, strPropertyName, objOldValue, objNewValue);
                        }
                    }
                }
            }
            finally
            {
                // Resume designer notifications
                this.ResumeNotifications();
                this.ResumeDesigner();
            }

        }

        /// <summary>
        /// Sets the web property.
        /// </summary>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objNewValue">The obj new value.</param>
        protected void SetWebProperty(string strPropertyName, object objNewValue)
        {
            // Suspend designer notifications
            this.SuspendDesigner();
            this.SuspendNotifications();

            try
            {
                // Get the web component
                object objWebComponent = this.WebComponent;
                if (objWebComponent != null)
                {
                    // Get the property info from the component type
                    PropertyInfo objPropertyInfo = objWebComponent.GetType().GetProperty(strPropertyName);
                    if (objPropertyInfo != null)
                    {
                        // If in design mode fire changing event
                        if (this.DesignMode)
                        {
                            this.DesignServices.FireWebComponentChanging(this.WebComponent, strPropertyName);
                        }

                        // get the old valud of the property
                        object objOldValue = objPropertyInfo.GetValue(objWebComponent, new object[] { });

                        // Set the new valud
                        objPropertyInfo.SetValue(objWebComponent, objNewValue, new object[] { });

                        // If in design mode fire changed event
                        if (this.DesignMode)
                        {
                            this.DesignServices.FireWebComponentChanged(this.WebComponent, strPropertyName, objOldValue, objNewValue);
                        }
                    }
                }
            }
            finally
            {
                // Resume designer notifications
                this.ResumeNotifications();
                this.ResumeDesigner();
            }

        }


        /// <summary>
        /// Replaces the source.
        /// </summary>
        /// <param name="objSource">The obj source.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ReplaceSource(object objSource)
        {
            if (this.DesignMode)
            {
                System.ComponentModel.IComponent objComponent = objSource as System.ComponentModel.IComponent;
                if (objComponent != null)
                {
                    this.DesignServices.RegisterWebComponent(objComponent);

                    objComponent = this.WebComponent;
                    if (objComponent != null)
                    {
                        this.DesignServices.UnregisterWebComponent(objComponent);
                    }

                    base.ReplaceSource(objSource);
                }
            }
        }
		
		
		#endregion Methods
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void objObservableItem_ObservableItemPropertyChanged(object objSender, ObservableItemPropertyChangedArgs objArgs)
		{
			((IContextNotifications)this.Context).NotifyItemPropertyChanged(this,objArgs,true);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
            base.FireWebPropertyChanged(objPropertyChangeArgs);
            OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
            base.FireWinPropertyChanged(objPropertyChangeArgs);
            OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strType"></param>
		protected virtual Event CreateWebEvent(string strType)
		{
			return this.CreateWebEvent(strType,this.SourceObject);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strType"></param>
		/// <param name="objWebSource"></param>
		protected virtual Event CreateWebEvent(string strType,object objWebSource)
		{
			return this.CreateWebEvent(Context,strType,objWebSource,null);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strType"></param>
		/// <param name="objWebSource"></param>
		/// <param name="objWebTarget"></param>
		protected virtual Event CreateWebEvent(string strType,object objWebSource,object objWebTarget)
		{
			return this.CreateWebEvent(Context,strType,objWebSource,objWebTarget);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="strType"></param>
		/// <param name="objWebSource"></param>
		/// <param name="objWebTarget"></param>
		protected virtual Event CreateWebEvent(IContext objContext,string strType,object objWebSource,object objWebTarget)
		{
			IRegisteredComponent objRegisteredComponent = objWebSource as IRegisteredComponent;
			if(objRegisteredComponent!=null)
			{
				return new Event(objContext,strType,objRegisteredComponent,objWebTarget as IRegisteredComponent);
			}
			else
			{
				return null;
			}
		}
		
		
		#endregion Events
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		protected ContextMenuController ContextMenuController
		{
			get
			{
				if(this.mobjContextMenuController==null)
				{
					if(this.WebComponent!=null && this.WebComponent.ContextMenu!=null)
					{
						WinForms.ContextMenu objWinContextMenu = new WinForms.ContextMenu();
						this.mobjContextMenuController = new ContextMenuController(Context,this.WebComponent.ContextMenu,objWinContextMenu);
						this.mobjContextMenuController.InitializeController();
					}
				}
				
				return this.mobjContextMenuController;
				
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Component WebComponent
		{
			get
			{
				return base.SourceObject as WebForms.Component;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public System.ComponentModel.Component WinComponent
		{
			get
			{
				return base.TargetObject as System.ComponentModel.Component;
			}
		}

		#endregion Properties
		
	}
	
	#endregion ComponentController Class
	
}
