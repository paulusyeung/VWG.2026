#region Using

using System;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.Threading;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region FormController Class
	
	/// <summary>
	/// Controls the relations between a webgui form and a winforms form
	/// </summary>
	
	public class FormController : ScrollableControlController
	{
		#region Class Members
		
		private MainMenuController mobjMainMenuController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public FormController(IContext objContext,WebForms.Form objWebForm,WinForms.Form objWinForm) :base(objContext,objWebForm,objWinForm)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public FormController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
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
			SetWinFormMainMenu();

            this.WinForm.SuspendLayout();
			SetWinFormFormBorderStyle();
            this.WinForm.ResumeLayout(false);

			SetWinFormMaximizeBox();
			SetWinFormMinimizeBox();            
            SetWinStartPosition();
            SetWinIsMdiContainer();
		}

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWinStartPosition()
        {
            this.WinForm.StartPosition = (WinForms.FormStartPosition)GetConvertedEnum(typeof(WinForms.FormStartPosition), this.WebForm.StartPosition);
        }        

		/// <summary>
		///
		/// </summary>
		public override void Terminate()
		{
			base.Terminate ();
			
			if(this.mobjMainMenuController!=null)
			{
				this.mobjMainMenuController.Terminate();
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained();
			
			foreach(WebForms.Form objWebForm in this.WebForm.OwnedForms)
			{
				WinForms.Form objWinForm = CreateWinForm(objWebForm);
				
				FormController objController = new FormController(Context,objWebForm,objWinForm);
				
				RegisterController(objController);
				
				objController.InitializeController();
				
				objWinForm.ShowDialog(this.WinForm);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents();
			this.WinForm.Activated+=new EventHandler(WinForm_Activated);
			this.WinForm.Closed+=new EventHandler(WinForm_Closed);

            

			if(ObservableList!=null)
			{
				ObservableList.ObservableItemAdded+=new ObservableListEventHandler(ObservableList_ObservableItemAdded);
				ObservableList.ObservableItemRemoved+=new ObservableListEventHandler(ObservableList_ObservableItemRemoved);
			}
		}

 
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinForm_Closed(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("OnUnload");
			if(objEvent!=null)
			{
				objEvent.Fire();
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinForm_Activated(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("SetActive");
			if(objEvent!=null)
			{
				objEvent.Fire();
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		internal void FireFormAdded(object objWebObject)
		{
			WebForms.Form objWebForm = objWebObject as WebForms.Form;
			
			WinForms.Form objWinForm = CreateWinForm(objWebForm);
			
			FormController objController = new FormController(Context,objWebForm,objWinForm);
			
			RegisterController(objController);
			
			objController.InitializeController();
			
			objWinForm.ShowInTaskbar = false;
			
			
			
			objWinForm.ShowDialog(this.WinForm);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void ObservableList_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)this.Context).NotifyFormAdded(this,objArgs.Item);
			
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		internal void FireFormRemoved(object objWebObject)
		{
			WinForms.Form objWinForm = GetWinObject(objWebObject) as WinForms.Form;
			
			objWinForm.Close();
			
			UnregisterControllerByWinObject(objWinForm);
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void ObservableList_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
		{
			((IContextNotifications)this.Context).NotifyFormRemoved(this,objArgs.Item);
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			this.WinForm.Activated-=new EventHandler(WinForm_Activated);
			this.WinForm.Closed-=new EventHandler(WinForm_Closed);
            
			if(ObservableList!=null)
			{
				ObservableList.ObservableItemAdded-=new ObservableListEventHandler(ObservableList_ObservableItemAdded);
				ObservableList.ObservableItemRemoved-=new ObservableListEventHandler(ObservableList_ObservableItemRemoved);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebForm"></param>
		protected virtual WinForms.Form CreateWinForm(object objWebForm)
		{
			return new Forms.ClientForm();
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientForm();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void LoadController()
		{
			base.LoadController();
			
			// This will cause the load event
			this.WebForm.Visible = true;
		}
        
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange (objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
				case "MaximizeBox":
				    SetWinFormMaximizeBox();
				    break;
				case "MinimizeBox":
				    SetWinFormMinimizeBox();
				    break;
				case "FormBorderStyle":
				    SetWinFormFormBorderStyle();
				    break;
                case "StartPosition":
                    SetWinStartPosition();
                    break;
                case "IsMdiContainer":
                    SetWinIsMdiContainer();
                    break;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        internal override void SetWebControlControls()
        {
            //get previous IsMdiContainer value
            bool blnIsMdiContainer = this.WebForm.IsMdiContainer;

            // Define refrences to the winforms accebt and cancel buttons.
            WinForms.Button objWinAcceptButton = null;
            WinForms.Button objWinCancelButton = null;

            // Loop all web controls.
            foreach (WebForms.Control objWebControl in this.WebForm.Controls)
            {
                // Check if the control's form reffers to the current control with accept or cancel button properties.
                if (objWebControl.Form.AcceptButton == objWebControl ||
                    objWebControl.Form.CancelButton == objWebControl)
                {
                    // Try getting a controler for the handled control.
                    ObjectController objObjectController = this.GetControllerByWebObject(objWebControl);
                    if (objObjectController != null)
                    {
                        // In case of reffering the accept button.
                        if (objWebControl.Form.AcceptButton == objWebControl)
                        {
                            // Preserve reference to the target of the recieved controler.
                            objWinAcceptButton = objObjectController.TargetObject as WinForms.Button;
                        }
                        // In case of reffering the cancel button.
                        else if (objWebControl.Form.CancelButton == objWebControl)
                        {
                            // Preserve reference to the target of the recieved controler.
                            objWinCancelButton = objObjectController.TargetObject as WinForms.Button;
                        }
                    }
                }
            }

            // call base SetWebControlControls
            base.SetWebControlControls();

            if(blnIsMdiContainer)
            {
                //return previous IsMdiContainer value
                this.WebForm.IsMdiContainer = true;
            }

            //return AcceptButton and CancelButton if needed
            if (objWinAcceptButton != null || objWinCancelButton != null)
            {
                // Loop all winforms controls
                foreach (WinForms.Control objWinControl in this.WinForm.Controls)
                {
                    // Try to get controller
                    ControlController objControlController = this.GetControllerByWinObject(objWinControl) as ControlController;
                    if (objControlController != null)
                    {
                        // Vallidate the new web control's form.
                        if (objControlController.WebControl.Form != null)
                        {
                            // Check if the current win control is the preserved accept button.
                            if (objWinControl == objWinAcceptButton)
                            {
                                // Update the new web control's form "AcceptButton" property.
                                objControlController.WebControl.Form.AcceptButton = objControlController.WebControl as WebForms.IButtonControl;
                            }
                            // Check if the current win control is the preserved cancel button.
                            else if (objWinControl == objWinCancelButton)
                            {
                                // Update the new web control's form "CancelButton" property.
                                objControlController.WebControl.Form.CancelButton = objControlController.WebControl as WebForms.IButtonControl;
                            }
                        }
                    }
                }
            }
        }
		
		#region Set Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWinControlDock()
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWinControlVisible()
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWinControlLocation()
		{
			if (!this.DesignMode)
			{
				base.SetWinControlLocation();
			}
		}

        /// <summary>
        /// </summary>
        protected override void SetWebControlLocation()
        {
            if (!this.DesignMode)
            {
                base.SetWebControlLocation();
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWinControlAnchor()
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWebControlSize()
		{
            this.WebForm.Size = new System.Drawing.Size(Convert.ToInt32(this.WinForm.Size.Width / TargetHorizontalScaleFactor), Convert.ToInt32(this.WinForm.Size.Height / TargetVerticalScaleFactor));
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void SetWinControlSize()
		{
            this.WinForm.ClientSize = new System.Drawing.Size(Convert.ToInt32(this.WebForm.Size.Width * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebForm.Size.Height * TargetVerticalScaleFactor));
		}
        /// <summary>
        /// Sets the maximum size of the win control.
        /// </summary>
        protected override void SetWinControlMaximumSize()
        {
            this.WinForm.MaximumSize = this.WebForm.MaximumSize;
        }
        /// <summary>
        /// Sets the minimum size of the win control.
        /// </summary>
        protected override void SetWinControlMinimumSize()
        {
            this.WinForm.MinimumSize = this.WebForm.MinimumSize;
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinFormMaximizeBox()
		{
			this.WinForm.MaximizeBox = this.WebForm.MaximizeBox;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinFormMinimizeBox()
		{
			this.WinForm.MinimizeBox = this.WebForm.MinimizeBox;
		}

        /// <summary>
        /// Sets the winform form IsMdiContainer property.
        /// </summary>
        protected virtual void SetWinIsMdiContainer()
		{
            this.WinForm.IsMdiContainer = this.WebForm.IsMdiContainer;
		}
        
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinFormFormBorderStyle()
		{
            // If not in design mode sync form border style
            if (!this.DesignMode)
            {
                this.WinForm.FormBorderStyle = (WinForms.FormBorderStyle)GetConvertedEnum(typeof(WinForms.FormBorderStyle), this.WebForm.FormBorderStyle);
            }
            else
            {
                // In design mode we do not want to see the form ever
                this.WinForm.FormBorderStyle = WinForms.FormBorderStyle.None;
            }
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinFormMainMenu()
		{
			WebForms.MainMenu objWebMainMenu = this.WebForm.Menu;
			if(objWebMainMenu!=null)
			{
				WinForms.MainMenu objWinMainMenu =  new WinForms.MainMenu();
				this.WinForm.Menu = objWinMainMenu;
				mobjMainMenuController = new MainMenuController(Context,objWebMainMenu,objWinMainMenu);
				mobjMainMenuController.Initialize();
			}
		}
		
		
		#endregion Set Methods
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		protected IObservableList ObservableList
		{
			get
			{
				return base.SourceObject as IObservableList;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Form WebForm
		{
			get
			{
				return base.SourceObject as WebForms.Form;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.Form WinForm
		{
			get
			{
				return base.TargetObject as WinForms.Form;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion FormController Class
	
}
