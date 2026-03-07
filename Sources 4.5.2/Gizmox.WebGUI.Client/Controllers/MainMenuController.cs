#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region MainMenuController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
    
	public class MainMenuController : MenuController
	{
		#region Class Members
		
		private MenuItemCollectionController mobjMenuItemCollectionController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public MainMenuController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(Context,this.WebMainMenu,this.WebMainMenu.MenuItems,this.WinMainMenu,this.WinMainMenu.MenuItems);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public MainMenuController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(Context,this.WebMainMenu,this.WebMainMenu.MenuItems,this.WinMainMenu,this.WinMainMenu.MenuItems);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

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

        
        public override void Clear()
        {
            base.Clear();

            if (this.mobjMenuItemCollectionController != null)
            {
                // Clear control controllers
                mobjMenuItemCollectionController.Clear();
            }
        }
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.MainMenu();
		}

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjMenuItemCollectionController != null)
            {
                // Clear control controllers
                mobjMenuItemCollectionController.Terminate();
            }
        }
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.MainMenu WebMainMenu
		{
			get
			{
				return base.SourceObject as WebForms.MainMenu;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.MainMenu WinMainMenu
		{
			get
			{
				return base.TargetObject as WinForms.MainMenu;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion MainMenuController Class
	
}
