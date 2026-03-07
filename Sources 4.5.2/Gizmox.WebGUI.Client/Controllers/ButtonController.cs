#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.IO;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ButtonController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class ButtonController :  ButtonBaseControler
	{
		#region Class Members
		
		private ContextMenuController mobjDropDownMenuController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ButtonController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ButtonController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
            base.InitializeController();
            SetWinButtonDropDownMenu();
            SetWinButtonAutoSizeMode();
		}


		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinButtonDropDownMenu()
		{
			if(this.DropDownMenuController!=null)
			{
				this.WinButton.DropDownMenu = this.DropDownMenuController.WinContextMenu;
			}
		}

        /// <summary>
        /// Sets the win button auto size mode.
        /// </summary>
        protected virtual void SetWinButtonAutoSizeMode()
        {
            this.WinButton.AutoSizeMode = (WinForms.AutoSizeMode)this.GetConvertedEnum(typeof(WinForms.AutoSizeMode), this.WebButton.AutoSizeMode);
        }

		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientButton();
		}


        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "AutoSizeMode":
                    this.SetWinButtonAutoSizeMode();
                    break;
            }
        }

		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		protected ContextMenuController DropDownMenuController
		{
			get
			{
				if(this.mobjDropDownMenuController==null)
				{
					if(this.WebButton!=null && this.WebButton.DropDownMenu!=null)
					{
						WinForms.ContextMenu objWinContextMenu = new WinForms.ContextMenu();
						this.mobjDropDownMenuController = new ContextMenuController(Context,this.WebButton.DropDownMenu,objWinContextMenu);
						this.mobjDropDownMenuController.Initialize();
						RegisterController(this.mobjDropDownMenuController);

                        // Registers the winforms context menu.
                        if (this.WebButton.DropDownMenu.Site != null &&
                            objWinContextMenu != null)
                        {
                            DesignServices.RegisterWinComponent(objWinContextMenu, this.WebButton.DropDownMenu.Site.Name);
                        }
					}
				}
				
				return this.mobjDropDownMenuController;
				
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Button WebButton
		{
			get
			{
				return base.SourceObject as WebForms.Button;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public Forms.ClientButton WinButton
		{
			get
			{
				return base.TargetObject as Forms.ClientButton;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ButtonController Class
	
}
