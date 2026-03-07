#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ContextMenuController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
    
	public class ContextMenuController : MenuController
	{
		#region Class Members
		
		private MenuItemCollectionController mobjMenuItemCollectionController = null;
		
		private object mobjTarget = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ContextMenuController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(Context,this.WebContextMenu,this.WebContextMenu.MenuItems,this.WinContextMenu,this.WinContextMenu.MenuItems);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ContextMenuController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(Context,this.WebContextMenu,this.WebContextMenu.MenuItems,this.WinContextMenu,this.WinContextMenu.MenuItems);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.FireWinPropertyChanged(objPropertyChangeArgs);
        }

		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWinObject"></param>
		public virtual void SetTarget(object objWinObject)
		{
			mobjTarget = objWinObject;
		}

        /// <summary>
        /// Called when [target object property change].
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "VWGNullProperty":
                    if (mobjMenuItemCollectionController != null)
                    {
                        mobjMenuItemCollectionController.SetWebObjectObjects();
                    }
                    break;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		public object GetTarget()
		{
			return mobjTarget;
		}

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjMenuItemCollectionController != null)
            {
                mobjMenuItemCollectionController.Terminate();
            }
        }
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ContextMenu WebContextMenu
		{
			get
			{
				return base.SourceObject as WebForms.ContextMenu;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ContextMenu WinContextMenu
		{
			get
			{
				return base.TargetObject as WinForms.ContextMenu;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ContextMenuController Class
	
}
