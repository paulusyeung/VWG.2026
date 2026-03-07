#region Using

using System;
using System.Collections;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Client.Controllers;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Client.Design
{
	#region ClientDesignContext Class
	
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	/// <summary>
	///
	/// </summary>
	
	public class ClientDesignContext
	{
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objDesignServices"></param>
		public static IContext CreateContext(IClientDesignServices objDesignServices)
		{
			return new Context(objDesignServices);
		}

        public static IClientObjectController CreateMenuController(IContext objContext, IComponent objWebComponent)
        {
            if (objWebComponent is WebGUI.Forms.ContextMenu)
            {
                return new ContextMenuController(objContext, objWebComponent);
            }
            else if (objWebComponent is WebGUI.Forms.MenuItem)
            {
                return new MenuItemController(objContext, objWebComponent);
            }
            if (objWebComponent is WebGUI.Forms.MainMenu)
            {
                return new MainMenuController(objContext, objWebComponent);
            }
            else
            {
                return CreateControllerByWebObject(objContext, objWebComponent);
            }
        }

        public static IClientObjectController CreateControllerByWebObject(IContext objContext, object objWebObject)
        {
            return ObjectController.CreateControllerByWebObject(objContext, objWebObject);
        }
		
		#endregion Methods
		
	}
	
	#endregion ClientDesignContext Class
	
}
