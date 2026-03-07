#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ToolBarController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
	
	public class ToolBarController : ControlController
	{
		#region Class Members
		
		private ToolBarItemCollectionController mobjToolBarItemCollectionController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ToolBarController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			mobjToolBarItemCollectionController = new ToolBarItemCollectionController(Context,this.WebToolBar,this.WebToolBar.Buttons,this.WinToolBar,this.WinToolBar.Buttons);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ToolBarController(IContext objContext,object objWebControl) :base(objContext,objWebControl)
		{
			mobjToolBarItemCollectionController = new ToolBarItemCollectionController(Context,this.WebToolBar,this.WebToolBar.Buttons,this.WinToolBar,this.WinToolBar.Buttons);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController ();

			this.WinToolBar.Appearance = WinForms.ToolBarAppearance.Flat;
            SetWinToolBarTextAlign();
            SetWinToolBarButtonSize();
            SetWinToolBarButtons();
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinToolBarTextAlign()
        {
            this.WinToolBar.TextAlign = (WinForms.ToolBarTextAlign)this.GetConvertedEnum(typeof(WinForms.ToolBarTextAlign), this.WebToolBar.TextAlign); 
        }

        /// <summary>
        /// Sets the size of the win tool bar button.
        /// </summary>
        private void SetWinToolBarButtonSize()
        {
            this.WinToolBar.ButtonSize = this.WebToolBar.ButtonSize;
        }

		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			mobjToolBarItemCollectionController.Initialize();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
			
			this.WinToolBar.ButtonClick+=new System.Windows.Forms.ToolBarButtonClickEventHandler(WinToolBar_ButtonClick);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			ToolBarButtonController objButtonController = GetControllerByWinObject(e.Button) as ToolBarButtonController;
			if(objButtonController!=null)
			{
				Event objEvent = CreateWebEvent("Click",objButtonController.SourceObject);
				objEvent.Fire();
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinToolBar.ButtonClick-=new System.Windows.Forms.ToolBarButtonClickEventHandler(WinToolBar_ButtonClick);
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ToolBar();
		}

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch(objPropertyChangeArgs.Property)
            {
                case "ButtonSize":
                    SetWinToolBarButtonSize();
                    break;
                case "TextAlign":
                    SetWinToolBarTextAlign();
                    break;
                case "Buttons":
                    SetWinToolBarButtons();
                    break;
            }
        }

        /// <summary>
        /// Clears the controller internal collection
        /// </summary>
        public override void Clear()
        {
            base.Clear();

            if (this.mobjToolBarItemCollectionController != null)
            {
                // Clear control controllers
                mobjToolBarItemCollectionController.Clear();
            }
        }

        /// <summary>
        /// Sets the win tool bar buttons.
        /// </summary>
        private void SetWinToolBarButtons()
        {
            mobjToolBarItemCollectionController.SetWinObjectObjects();
        }

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjToolBarItemCollectionController != null)
            {
                mobjToolBarItemCollectionController.Terminate();
            }
        }

		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ToolBar WebToolBar
		{
			get
			{
				return base.SourceObject as WebForms.ToolBar;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ToolBar WinToolBar
		{
			get
			{
				return base.TargetObject as WinForms.ToolBar;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ToolBarController Class
	
}
