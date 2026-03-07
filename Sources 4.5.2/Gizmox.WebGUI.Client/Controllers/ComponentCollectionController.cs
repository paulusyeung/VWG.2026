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
	#region ComponentCollectionController Class
	
	/// <summary>
	/// Controls the relations between a webgui component and a winforms component
	/// </summary>
	
	public abstract class ComponentCollectionController : ObjectCollectionController
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
		public ComponentCollectionController(IContext objContext,object objWebObject,IList objWebObjects,object objWinObject,IList objWinObjects) :base(objContext, objWebObject, objWebObjects, objWinObject, objWinObjects)
		{

		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// Terminates the controller
        /// </summary>
        public override void Terminate()
        {
            base.Terminate();

            if (this.DesignMode)
            {
                // Create Web controls collection
                ArrayList objWebObjects = new ArrayList(this.WebObjects);

                // If there is a winforms object collection
                if (objWebObjects != null)
                {
                    // Clear all win objects
                    foreach (object objWebObject in objWebObjects)
                    {
                        // Get component if is one
                        IComponent objWebComponent = objWebObject as IComponent;
                        if (objWebComponent != null)
                        {
                            // Unregister web component
                            DesignServices.UnregisterWebComponent(objWebComponent);
                        }

                        ObjectController objController = GetControllerByWebObject(objWebObject);
                        if (objController != null)
                        {
                            objController.Terminate();
                        }
                    }
                }

                // Create Win controls collection
                ArrayList objWinObjects = new ArrayList(this.WinObjects);

                // If there is a winforms object collection
                if (objWinObjects != null)
                {
                    // Clear all win objects
                    foreach (object objWinObject in objWinObjects)
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
        }

        /// <summary>
        /// Create item object controller
        /// </summary>
        /// <param name="objSoureceObject"></param>
        /// <returns></returns>
        protected override ObjectController CreateObjectControlerBySourceObject(object objSoureceObject)
        {
            ObjectController objController = null;
            if (objSoureceObject != null)
            {
                // Get source type
                Type objSoureceType = objSoureceObject.GetType();

                // Try to get controller
                objController = ObjectController.CreateTypeController(this.Context, objSoureceType, objSoureceObject);
            }
            if (objController == null)
            {
                // return base controller
                return base.CreateObjectControlerBySourceObject(objSoureceObject);
            }
            else
            {
                return objController;
            }
        }


		#endregion Methods

		
	}
	
	#endregion ComponentCollectionController Class
	
}
