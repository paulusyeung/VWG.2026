#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region MenuItemController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
    
	public class MenuItemController : MenuController
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
		public MenuItemController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(Context,this.WebMenuItem,this.WebMenuItem.MenuItems,this.WinMenuItem,this.WinMenuItem.MenuItems);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public MenuItemController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			mobjMenuItemCollectionController = new MenuItemCollectionController(Context,this.WebMenuItem,this.WebMenuItem.MenuItems,this.WinMenuItem,this.WinMenuItem.MenuItems);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    SetWinMenuItemText(true);
                    break;
                case "Index":
                    SetWinMenuItemIndex(true);
                    break;
            }
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

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    SetWebMenuItemText();
                    break;
            }
        }
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController ();

			SetWinMenuItemText();
            SetWinMenuItemIndex();
		}

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();

            SetWebMenuItemIndex();
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			mobjMenuItemCollectionController.Initialize();
		}



        /// <summary>
        /// Sets the index of the win menu item.
        /// </summary>
        /// <param name="blnFireWinComponentChanged">if set to <c>true</c> [BLN fire win component changed].</param>
        private void SetWinMenuItemIndex(bool blnFireWinComponentChanged)
        {
            if (blnFireWinComponentChanged)
            {
                this.SetWinProperty("Index", this.WebMenuItem.Index);
            }
            else
            {
                this.WinMenuItem.Index = this.WebMenuItem.Index;
            }
        }

        /// <summary>
        /// Sets the win menu item text.
        /// </summary>
        /// <param name="blnFireWinComponentChanged">if set to <c>true</c> [BLN fire win component changed].</param>
        private void SetWinMenuItemText(bool blnFireWinComponentChanged)
        {
            if (blnFireWinComponentChanged)
            {
                this.SetWinProperty("Text", this.WebMenuItem.Text);
            }
            else
            {
                this.WinMenuItem.Text = this.WebMenuItem.Text;
            }
        }

        /// <summary>
        /// Sets the index of the win menu item.
        /// </summary>
        protected virtual void SetWinMenuItemIndex()
        {
            SetWinMenuItemIndex(false);
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebMenuItemText()
        {
            this.SetWebProperty("Text", this.WinMenuItem.Text);
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebMenuItemIndex()
        {
            this.SetWebProperty("Index", this.WinMenuItem.Index);
        }

		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinMenuItemText()
		{
            SetWinMenuItemText(false);
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
			this.WinMenuItem.Click+=new EventHandler(WinMenuItem_Click);
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();

			this.WinMenuItem.Click-=new EventHandler(WinMenuItem_Click);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinMenuItem_Click(object sender, EventArgs e)
		{
			MenuItemController objControler = GetControllerByWinObject(sender) as MenuItemController;
			if(objControler!=null)
			{
				Event objEvent = CreateWebEvent("MenuClick",GetParentOwner(objControler.WebMenuItem),objControler.WebMenuItem);
				objEvent.Fire();
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objMenu"></param>
		private object GetParentOwner(WebForms.MenuItem objMenu)
		{
			if(objMenu.Parent!=null)
			{
				if(objMenu.Parent is WebForms.ContextMenu)
				{
					ContextMenuController objContextMenuController = GetControllerByWebObject(objMenu.Parent) as ContextMenuController;
					if(objContextMenuController!=null && objContextMenuController.GetTarget()!=null)
					{
						return GetWebObject(objContextMenuController.GetTarget());
					}
					return objMenu.Parent.InternalParent;
				}
				else if(objMenu.Parent is WebForms.MenuItem)
				{
					return GetParentOwner((WebForms.MenuItem)objMenu.Parent);
				}
				else
				{
					return null;
				}
			}
			else
			{
				return objMenu.InternalParent;
			}
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.MenuItem();
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

        public override void Terminate()
        {
            base.Terminate();

            // Check if the winforms menu item is still contained in its parent and remove it.
            if (this.WinMenuItem != null &&
                this.WinMenuItem.Parent != null &&
                this.WinMenuItem.Parent.MenuItems.Contains(this.WinMenuItem))
            {
                try
                {
                    this.SuspendNotifications();
                    this.WinMenuItem.Parent.MenuItems.Remove(this.WinMenuItem);
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }

            // Clear control controllers
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
		public WebForms.MenuItem WebMenuItem
		{
			get
			{
				return base.SourceObject as WebForms.MenuItem;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.MenuItem WinMenuItem
		{
			get
			{
				return base.TargetObject as WinForms.MenuItem;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion MenuItemController Class
	
}
