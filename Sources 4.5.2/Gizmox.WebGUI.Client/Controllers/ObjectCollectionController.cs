#region Using

using System;
using System.Reflection;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Client.Design;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ObjectCollectionController Class
	
	/// <summary>
	/// Controls the relations between a webgui component and a winforms component
	/// </summary>
	
	public abstract class ObjectCollectionController : ObjectController
	{
		#region Class Members
		
		/// <summary>
		/// The web list
		/// </summary>
		private IList mobjWebObjects = null;
		
		/// <summary>
		/// The winforms list
		/// </summary>
		private IList mobjWinObjects = null;
		
		/// <summary>
		/// The owning context
		/// </summary>
		private IContext mobjContext = null;
		
		/// <summary>
		/// Collection of controllers owned by this controller
		/// </summary>
		private ArrayList mobjControllers = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebObject"></param>
		/// <param name="objWebObjects"></param>
		/// <param name="objWinObject"></param>
		/// <param name="objWinObjects"></param>
		public ObjectCollectionController(IContext objContext,object objWebObject,IList objWebObjects,object objWinObject,IList objWinObjects) :base(objContext,objWebObject,objWinObject)
		{
			this.mobjControllers = new ArrayList();
			this.mobjWebObjects = objWebObjects;
			this.mobjWinObjects = objWinObjects;
			this.mobjContext = objContext;
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();

            // Loop all contained controlers
            foreach (ObjectController objController in mobjControllers)
            {
                // Update the controller source object.
                objController.UpdateSource();
            }
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();

            // Loop all contained controlers
            foreach (ObjectController objController in mobjControllers)
            {
                // Update the controller target object.
                objController.UpdateTarget();
            }
        }

		/// <summary>
		/// Initialize the controller
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

            if (!this.WinObjects.IsReadOnly)
            {                
                try
                {
					this.SuspendNotifications();
                    InitializeWinObjects();
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
		}
		
		#region Web list events
		
		/// <summary>
		/// Attach list events
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents();
			
			// If there is an observed list and not in design time
			if (this.WebObservedList != null && !this.DesignMode)
			{
				this.WebObservedList.ObservableItemAdded += new ObservableListEventHandler(WebObservedList_ObservableItemAdded);
				this.WebObservedList.ObservableItemRemoved += new ObservableListEventHandler(WebObservedList_ObservableItemRemoved);
				this.WebObservedList.ObservableListCleared += new EventHandler(WebObservedList_ObservableListCleared);
			}
		}
		
		/// <summary>
		/// If web object was added
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void WebObservedList_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			if (GetControllerByWebObject(objArgs.Item) == null)
			{
				((IContextNotifications)this.Context).NotifyListItemAdded(this, objArgs.Item);
			}
		}
		
		/// <summary>
		/// If web object has been removed
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void WebObservedList_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)this.Context).NotifyListItemRemoved(this, objArgs.Item);
		}
		
		/// <summary>
		/// If web list has been cleared
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WebObservedList_ObservableListCleared(object sender, EventArgs e)
		{
			((IContextNotifications)this.Context).NotifyListCleared(this);
		}
		
		/// <summary>
		/// Fire web item added event
		/// </summary>
		/// <param name="objItem"></param>
		public virtual void FireObservableListItemAdded(object objItem)
		{
			this.OnWebObjectAdded(objItem);
		}
		
		/// <summary>
		/// Fire web item removed event
		/// </summary>
		/// <param name="objItem"></param>
		public virtual void FireObservableListItemRemoved(object objItem)
		{
			this.OnWebObjectRemoved(objItem);
		}
		
		/// <summary>
		/// Fire web list cleared
		/// </summary>
		public virtual void FireObservableListCleared()
		{
			ClearWinObjects();
		}
		
		/// <summary>
		/// Detach from the observed list events
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			
			// If there is an observed list and not in design time
			if (this.WebObservedList != null && !this.DesignMode)
			{
				this.WebObservedList.ObservableItemAdded -= new ObservableListEventHandler(WebObservedList_ObservableItemAdded);
				this.WebObservedList.ObservableItemRemoved -= new ObservableListEventHandler(WebObservedList_ObservableItemRemoved);
				this.WebObservedList.ObservableListCleared -= new EventHandler(WebObservedList_ObservableListCleared);
			}
		}
		
		
		#endregion Web list events
		
		/// <summary>
		/// Initialize the winforms objects
		/// </summary>
		protected virtual void InitializeWinObjects()
		{
            if (this.WebObjects != null && this.WinObjects != null)
            {
                // Clear winforms collection
                this.ClearWinObjects();

                // Check the amount of un erasable win object.
                int intUnErasableObjectsCount = this.WinObjects.Count;

                // Initialize the overrided object index.
                int intOverridedObjectIndex = 0;

                // Loop all web objects
                foreach (object objWebObject in this.WebObjects)
                {
                    // Create a new control controller
                    ObjectController objController = CreateObjectControlerBySourceObject(objWebObject);
                    if (objController != null)
                    {
                        // If there is a valid winform object
                        if (objController.TargetObject != null)
                        {
                            object objWinObject = objController.TargetObject;

                            // Add to controllers collection
                            mobjControllers.Add(objController);

                            // Map controller to both objects
                            if (objController != null)
                            {
                                RegisterController(objController);
                            }

                            // Check if current collection class wishes to override exist win objects and if it does,
                            // check that te overrided object index is lower then the total number of unerasable win objects.
                            if (this.OverrideExistWinObjects && intOverridedObjectIndex < intUnErasableObjectsCount)
                            {
                                this.WinObjects[intOverridedObjectIndex] = objWinObject;
                                intOverridedObjectIndex++;
                            }
                            else
                            {
                                // Add winforms object
                                this.AddWinObject(objWinObject);
                            }

                            // Initialize controller
                            if (objController != null) objController.Initialize();

                            if (objController != null) objController.Load();
                        }
                    }
                }
            }
		}
		
		/// <summary>
		/// Create item object controller
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
        protected virtual ObjectController CreateObjectControlerBySourceObject(object objSoureceObject)
		{
            return new ObjectController(Context, objSoureceObject);
		}

        /// <summary>
        /// Create item object controller
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected virtual ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
        {
            return new ObjectController(Context, null, objTargetObject);
        }
		
		/// <summary>
		/// Clear current collection controller items
		/// </summary>
		public override void Clear()
		{
			base.Clear();
			
			// Remove all controllers
			ClearControllers();
			
			// If there is a winforms object collection
			if (this.WinObjects != null && this.DesignServices != null)
			{
				// Clear all win objects
				foreach (object objWinObject in this.WinObjects)
				{
					// Get component if is one
					IComponent objWinComponent = objWinObject as IComponent;
					if (objWinComponent != null)
					{
						// Unregister winforms component
						DesignServices.UnregisterWinComponent(objWinComponent);
					}
				}
			}
		}
		
		/// <summary>
		/// Clears all containd win objects
		/// </summary>
		protected virtual void ClearWinObjects()
		{
			// Remove all controllers
			ClearControllers();
			
			// If there is a winforms object collection
			if (this.WinObjects != null)
			{
				if (this.DesignMode)
				{
					// Clear all win objects
					foreach (object objWinObject in this.WinObjects)
					{
						// Get component if is one
						IComponent objWinComponent = objWinObject as IComponent;
						if (objWinComponent != null)
						{
							// Unregister winforms component
							DesignServices.UnregisterWinComponent(objWinComponent);
						}
					}
				}
				
				// Clear collection
				this.WinObjects.Clear();
			}
		}


		/// <summary>
		/// Clear all contained controllers
		/// </summary>
		protected virtual void ClearControllers()
		{
			// Loop all contained controlers
			foreach (ObjectController objController in mobjControllers)
			{
				// Remove controller winfrom object
				objController.Clear();
				objController.Terminate();
				
				// Unregister controller
				this.UnregisterControllerByWinObject(objController.TargetObject);
			}
			
			// Clear controller collections
			this.mobjControllers.Clear();
		}
		
		/// <summary>
		/// Add winforms object to collection
		/// </summary>
		/// <param name="objWinObject"></param>
		/// <returns></returns>
		protected virtual int AddWinObject(object objWinObject)
		{
			// If valid collection and item
			if (this.WinObjects != null && objWinObject != null)
			{
				// If design time mode
				if (this.DesignMode)
				{
					// Get winforms component
					System.ComponentModel.IComponent objWinComponent = objWinObject as System.ComponentModel.IComponent;
					if (objWinComponent != null)
					{
						// Component name variable
						string strName = null;
						
						// Get controller
						ObjectController objController = GetControllerByWinObject(objWinObject);
						if (objController != null)
						{
							// Get web component
							System.ComponentModel.IComponent objWebComponent = objController.SourceObject as System.ComponentModel.IComponent;
							if (objWebComponent != null && objWebComponent.Site != null)
							{
								// Set the name from the web component site
								strName = objWebComponent.Site.Name;
							}
						}
						
						// Register the win component with the same name as the web component
						this.DesignServices.RegisterWinComponent(objWinComponent, strName);
					}
					
				}
				
				// Add to the winforms collection
				return this.WinObjects.Add(objWinObject);
			}
			else
			{
				return -1;
			}
		}

        /// <summary>
        /// Sets web controls from the win control collection
        /// </summary>
        internal void SetWebObjectObjects()
        {
            // If controls are valid
            if (this.WebObjects != null && this.WinObjects != null)
            {
                try
                {
                    // Suspend event notifications
                    this.SuspendNotifications();

                    // Create web controls collection
                    ArrayList objWebObjects = new ArrayList(this.WebObjects);

                    // Clear web controls
                    this.WebObjects.Clear();

                    // Loop all winforms controls
                    foreach (object objWinObject in this.WinObjects)
                    {
                        // Try to get controller
                        ObjectController objObjectController = ((IContextServices)this.Context).GetControllerByWinObject(objWinObject) as ObjectController;
                        if (objObjectController == null)
                        {
                            // Create a new controller.
                            objObjectController = this.CreateObjectControlerByTargetObject(objWinObject);
                            if (objObjectController != null)
                            {
                                // Initializes the new controller.
                                objObjectController.Initialize(this.DesignMode);

                                // Register controller
                                ((IContextServices)Context).RegisterController(objObjectController);
                            }
                        }
                        else
                        {
                            // Update source.
                            objObjectController.UpdateSource();
                        }

                        if (objObjectController != null)
                        {
                            // Add to the web collection
                            this.WebObjects.Add(objObjectController.SourceObject);

                            // If new web control
                            if (objWebObjects.Contains(objObjectController.SourceObject))
                            {
                                // remove from web control collection
                                objWebObjects.Remove(objObjectController.SourceObject);
                            }
                        }
                    }
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
        }

        /// <summary>
        /// Sets win controls from the web control collection
        /// </summary>
        internal void SetWinObjectObjects()
        {
            // If controls are valid
            if (this.WinObjects != null && this.WebObjects != null)
            {
                try
                {
                    // Suspend event notifications
                    this.SuspendNotifications();

                    // Create Win controls collection
                    ArrayList objWinObjects = new ArrayList(this.WinObjects);

                    // Clear Win controls
                    this.WinObjectsClear();

                    // Loop all Webforms controls
                    foreach (object objWebObject in this.WebObjects)
                    {
                        // Try to get controller
                        ObjectController objObjectController = ((IContextServices)this.Context).GetControllerByWebObject(objWebObject) as ObjectController;
                        if (objObjectController == null)
                        {
                            // Create a new controller.
                            objObjectController = this.CreateObjectControlerBySourceObject(objWebObject);

                            // Initializes the new controller.
                            objObjectController.Initialize(this.DesignMode);

                            // Register controller
                            ((IContextServices)Context).RegisterController(objObjectController);
                        }
                        else
                        {
                            // Update target.
                            objObjectController.UpdateTarget();
                        }
                        if (objObjectController != null)
                        {
                            // Add to the Win collection
                            this.WinObjects.Add(objObjectController.TargetObject);

                            // If new Win control
                            if (objWinObjects.Contains(objObjectController.TargetObject))
                            {
                                // remove from Win control collection
                                objWinObjects.Remove(objObjectController.TargetObject);
                            }
                        }
                    }
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
        }

        /// <summary>        
        /// a function that clears the winobjects collection        
        /// </summary>
        protected internal virtual void WinObjectsClear()
        {
            this.WinObjects.Clear();
        }
		
		
		/// <summary>
		/// Handle web object added
		/// </summary>
		/// <param name="objWebObject"></param>
		/// <returns></returns>
		protected virtual int OnWebObjectAdded(object objWebObject)
		{
			int intIndex = -1;
			
			// Create a new control controller
			ObjectController objController = CreateObjectControlerBySourceObject(objWebObject);
			if (objController.TargetObject != null)
			{
				object objWinObject = objController.TargetObject;
				
				// Add to controllers collection
				mobjControllers.Add(objController);
				
				// Map controller to both objects
				if (objController != null) RegisterController(objController);
				
				// Initialize controller
				if (objController != null) objController.Initialize();
				
				// Add winforms object
				intIndex = this.AddWinObject(objWinObject);
				
				// Initialize controller
				if (objController != null) objController.Load();
			}
			
			return intIndex;
		}
		
		/// <summary>
		/// Handle web object removed
		/// </summary>
		/// <param name="objWebObject"></param>
		protected virtual void OnWebObjectRemoved(object objWebObject)
		{
			// Get controller
			ObjectController objController = GetControllerByWebObject(objWebObject);
			if (objController != null)
			{
				// Clear controller
				objController.Clear();
				
				// Remove controller from collection
				if (mobjControllers.Contains(objController))
				{
					mobjControllers.Remove(objController);
				}
				
				// Get winforms object
				object objWinObject = objController.TargetObject;
				
				// Remove winforms object from collection
				this.RemoveWinObject(objWinObject);
				
				// Unregister controller
				UnregisterControllerByWebObject(objWebObject);
				
				// Terminate controller
				objController.Terminate();
			}
		}
		
		/// <summary>
		/// Handle winforms object insertion
		/// </summary>
		/// <param name="intIndex"></param>
		/// <param name="objWinObject"></param>
		protected virtual void InsertWinObject(int intIndex, object objWinObject)
		{
			if (this.WinObjects != null && objWinObject != null)
			{
				this.WinObjects.Insert(intIndex, objWinObject);
			}
		}
		
		/// <summary>
		/// Removes a winforms object
		/// </summary>
		/// <param name="objWinObject"></param>
		protected virtual void RemoveWinObject(object objWinObject)
		{
			// If valid collection and item
			if (this.WinObjects != null && objWinObject != null)
			{
				// Remove the winforms object
				this.WinObjects.Remove(objWinObject);
				
				// If in design time mode
				if (this.DesignMode)
				{
					// Get the winforms component
					System.ComponentModel.IComponent objWinComponent = objWinObject as System.ComponentModel.IComponent;
					if (objWinComponent != null)
					{
						// Unregister the component
						this.DesignServices.UnregisterWinComponent(objWinComponent);
					}
				}
			}
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		new public IContext Context
		{
			get
			{
				return this.mobjContext;
			}
		}

        /// <summary>
        /// Gets a value indicating whether [override exist win objects].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [override exist win objects]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool OverrideExistWinObjects
        {
            get
            {
                return false;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		public IList WebObjects
		{
			get
			{
				return this.mobjWebObjects;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public IObservableList WebObservedList
		{
			get
			{
				return this.WebObjects as IObservableList;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public IList WinObjects
		{
			get
			{
				return this.mobjWinObjects;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ObjectCollectionController Class
	
}
