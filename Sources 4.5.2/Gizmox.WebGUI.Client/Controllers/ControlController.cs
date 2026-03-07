#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel.Design;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ControlController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class ControlController : ComponentController
	{
		#region Class Members
		
		/// <summary>
		///
		/// </summary>
		private ControlCollectionController mobjControlsController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ControlController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			if(!(this.WebControl is ISealedComponent))
			{
				this.mobjControlsController = new ControlCollectionController(Context,objWebControl,this.WebControl.Controls,objWinControl,this.WinControl.Controls);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ControlController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			if(!(this.WebControl is ISealedComponent))
			{
				this.mobjControlsController = new ControlCollectionController(Context,objWebObject,this.WebControl.Controls,this.WinControl,this.WinControl.Controls);
			}
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
            // Needed to be set before initialization to enable anchoring
            if (!DesignInitialization)
            {
                SetWinControlSize();
                SetWinControlLocation();
                SetWinControlMaximumSize();
                SetWinControlMinimumSize();
            }
			base.InitializeController();
			SetWinControlText();
			SetWinControlDock();
			SetWinControlAnchor();
			if (!DesignInitialization)
			{
                try
                {
					this.SuspendNotifications();
                    SetWinControlSize();
                    SetWinControlLocation();
                	SetWinControlMaximumSize();
                	SetWinControlMinimumSize();
                    SetWinControlPadding();
                }
                finally
                {
                    this.ResumeNotifications();
                }
			}
			SetWinControlBackColor();
			SetWinControlForeColor();
			SetWinControlFont();
			SetWinControlEnabled();
			SetWinControlTabIndex();
			SetWinControlTabStop();
			SetWinControlContextMenu();
			SetWinControlBackgroundImage();
            SetWinControlBackgroundImageLayout();
			SetWinControlEnabled();
			SetWinControlVisible();
            SetWinControlBorderStyle();
            SetWinControlAutoSize();
            SetWinControlMargin();
            SetWinControlRightToLeft();
		}

        public override void InitializeNew()
        {
            base.InitializeNew();
            SetWinControlSize();
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			this.WinControl.SuspendLayout();
			if(this.mobjControlsController!=null)
			{
				this.mobjControlsController.Initialize();
			}

            try
            {
	            this.SuspendNotifications();
                this.WinControl.ResumeLayout();
            }
            finally
            {
                this.ResumeNotifications();
            }
		}
		
		/// <summary>
		/// Clears the controller internal collection
		/// </summary>
		public override void Clear()
		{
			base.Clear();
			
			if (this.mobjControlsController != null)
			{
				// Clear control controllers
				mobjControlsController.Clear();
			}
		}

        public override void Terminate()
        {
            base.Terminate();

            if (this.mobjControlsController != null)
            {
                // Clear control controllers
                mobjControlsController.Terminate();
            }
        }
		
		#region Set Property
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlVisible()
		{
			// If not in design mode
			if (!this.DesignMode)
			{
				this.WinControl.Visible = this.WebControl.Visible;
			}
		}

        /// <summary>
        /// Sets the win control margin.
        /// </summary>
        protected virtual void SetWinControlMargin()
		{
            // Set the controls margin
            this.WinControl.Margin = new WinForms.Padding(Convert.ToInt32(this.WebControl.Margin.Left * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Margin.Top * TargetVerticalScaleFactor), Convert.ToInt32(this.WebControl.Margin.Right * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Margin.Bottom * TargetVerticalScaleFactor));
		}

        /// <summary>
        /// Sets the win control padding.
        /// </summary>
        protected virtual void SetWinControlPadding()
        {
            // Set the controls padding
            this.WinControl.Padding = new WinForms.Padding(Convert.ToInt32(this.WebControl.Padding.Left * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Padding.Top * TargetVerticalScaleFactor), Convert.ToInt32(this.WebControl.Padding.Right * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Padding.Bottom * TargetVerticalScaleFactor));
        }

        /// <summary>
		///
		/// </summary>
        protected virtual void SetWinControlDataBindings()
        {
            if (this.DesignMode)
            {
                try
                {
                    this.SuspendNotifications();
                    this.RefreshDesigner();
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
        }
		
		/// <summary>
		///
		/// </summary>
		internal virtual void SetWebControlControls()
		{
			if (this.mobjControlsController != null)
			{
				this.mobjControlsController.SetWebControlControls();
			}
		}

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWebControlTabIndex()
        {
            ((WebForms.Control)this.SourceObject).TabIndex = ((WinForms.Control)this.TargetObject).TabIndex;
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlControls()
		{
			if (this.mobjControlsController != null)
			{
				this.mobjControlsController.SetWinControlControls();
			}
		}

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWinControlBorderStyle()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWebControlBorderStyle()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWinControlLayoutInfo()
        {
            WinForms.TableLayoutPanel objWinTableLayoutPanel = this.WinControl.Parent as WinForms.TableLayoutPanel;
            WebForms.TableLayoutPanel objWebTableLayoutPanel = this.WebControl.Parent as WebForms.TableLayoutPanel;

            if (objWinTableLayoutPanel != null &&
                objWebTableLayoutPanel != null)
            {
                objWinTableLayoutPanel.SetRow(this.WinControl, objWebTableLayoutPanel.GetRow(this.WebControl));
                objWinTableLayoutPanel.SetColumn(this.WinControl, objWebTableLayoutPanel.GetColumn(this.WebControl));
                objWinTableLayoutPanel.SetRowSpan(this.WinControl, objWebTableLayoutPanel.GetRowSpan(this.WebControl));
                objWinTableLayoutPanel.SetColumnSpan(this.WinControl, objWebTableLayoutPanel.GetColumnSpan(this.WebControl));
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlEnabled()
		{
			this.WinControl.Enabled = this.WebControl.Enabled;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlBackgroundImage()
		{
            if (this.WebControl.BackgroundImage != null)
            {
                Image objBackgroundImage = GetWinImageFromResourceHandle(this.WebControl.BackgroundImage);
                if (objBackgroundImage != null)
                {
                    this.WinControl.BackgroundImage = objBackgroundImage;
                }
            }
            else if(this.WinControl.BackgroundImage!=null)
            {
                this.WinControl.BackgroundImage = null;
            }
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinControlBackgroundImageLayout()
        {
            this.WinControl.BackgroundImageLayout = (WinForms.ImageLayout)this.GetConvertedEnum(typeof(WinForms.ImageLayout), this.WebControl.BackgroundImageLayout);            
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlContextMenu()
		{
			if(this.ContextMenuController!=null)
			{
				this.WinControl.ContextMenu = this.ContextMenuController.WinContextMenu;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlTabStop()
		{
			this.WinControl.TabStop = this.WebControl.TabStop;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlTabIndex()
		{
			if(this.WebControl.TabIndex!=-1)
			{
				this.WinControl.TabIndex = this.WebControl.TabIndex;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlFont()
		{
            if (this.WebControl.Font == null)
            {
                this.WinControl.Font = null;
            }
            else
            {
                this.WinControl.Font = new Font(this.WebControl.Font.FontFamily, this.WebControl.Font.Size * TargetVerticalScaleFactor, this.WebControl.Font.Style, this.WebControl.Font.Unit);
            }
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlForeColor()
		{
			this.WinControl.ForeColor = this.WebControl.ForeColor;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlBackColor()
		{
            try
            {
                this.WinControl.BackColor = this.WebControl.BackColor;
            }
            catch { }
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlLocation()
		{
            this.SetWinProperty("Location", new Point(Convert.ToInt32(this.WebControl.Location.X * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Location.Y * TargetVerticalScaleFactor)));
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlSize()
		{
            this.SetWinProperty("Size",new Size(Convert.ToInt32(this.WebControl.Size.Width * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Size.Height * TargetVerticalScaleFactor)));
		}
		
		/// <summary>
        /// Sets the maximum size of the win control.
        /// </summary>
        protected virtual void SetWinControlMaximumSize()
        {
            this.WinControl.MaximumSize = this.WebControl.MaximumSize;
        }
        /// <summary>
        /// Sets the minimum size of the win control.
        /// </summary>
        protected virtual void SetWinControlMinimumSize()
        {
            this.WinControl.MinimumSize = this.WebControl.MinimumSize;
        }
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlAnchor()
		{
			if(this.WebControl.Dock == WebForms.DockStyle.None)
			{
				this.WinControl.Anchor = (WinForms.AnchorStyles)this.GetConvertedEnum(typeof(WinForms.AnchorStyles),this.WebControl.Anchor);
			}
		}
		
		/// <summary>
		///
		/// </summary>
        protected virtual void SetWinControlDock()
        {
            this.WinControl.Dock = (WinForms.DockStyle)this.GetConvertedEnum(typeof(WinForms.DockStyle), this.WebControl.Dock);
        }
		
        
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinControlText()
		{
			this.WinControl.Text = this.WebControl.Text;
		}
		
		
		#endregion Set Property
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
			{
				case "Controls":
				    SetWebControlControls();
                    // If in design mode
                    if (this.DesignMode)
                    {
                        // Fire control changed on the collection owner
                        this.DesignServices.FireWebComponentChanged(this.WebControl, "Controls", this.WebControl.Controls, this.WebControl.Controls);
                    }
				    break;

                case "TabIndex":
                    SetWebControlTabIndex();
                    // If in design mode
                    if (this.DesignMode)
                    {
                        // Fire control changed on the collection owner
                        this.DesignServices.FireWebComponentChanged(this.WebControl, "TabIndex", this.WebControl.TabIndex, this.WebControl.TabIndex);
                    }
                    break;

                case "Width":
                case "Height":
                case "Size":
                    if (this.DesignMode && !this.DesignSuspended && !this.IsNotificationSuspened)
                    {
                        try
                        {
                            this.SuspendNotifications();
                            this.DesignServices.FireWebComponentChanging(this.WebComponent, "Size");
                            object objOldValue = this.WebControl.Size;
                            this.SetWebControlSize();
                            object objNewValue = this.WebControl.Size;

                            if (!Size.Equals(objOldValue, objNewValue))
                            {
                                this.DesignServices.FireWebComponentChanged(this.WebComponent, "Size", objOldValue, objNewValue);
                            }
                        }
                        finally
                        {
                            this.ResumeNotifications();
                        }
                    }
                    break;

                case "Left":
                case "Top":
                case "Location":
                    if (this.DesignMode && !this.DesignSuspended && !this.IsNotificationSuspened)
                    {
                        this.SetWebControlLocation();
                    }
                    break;

                case "Dock":
                    if (this.DesignMode && !this.DesignSuspended && !this.IsNotificationSuspened)
                    {
                        try
                        {
                            this.SuspendNotifications();
                            this.DesignServices.FireWebComponentChanging(this.WebComponent, "Dock");
                            object objOldValue = this.WebControl.Dock;
                            this.SetWebControlDock();
                            object objNewValue = this.WebControl.Dock;
                            this.DesignServices.FireWebComponentChanged(this.WebComponent, "Dock", objOldValue, objNewValue);
                        }
                        finally
                        {
                            this.ResumeNotifications();
                        }
                    }
                    break;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch(objPropertyChangeArgs.Property)
            {
                case "AutoSize":
                    SetWinControlAutoSize();
                    break;
                case "Location":
                    SetWinControlLocation();
                    break;
                case "Size":
                    SetWinControlSize();
                    break;
                case "MinimumSize":
                    SetWinControlMinimumSize();
                    break;
                case "MaximumSize":
                    SetWinControlMaximumSize();
                    break;
                case "Dock":
                    SetWinControlDock();
                    break;
                case "Text":
                    SetWinControlText();
                    break;
                case "Anchor":
                    SetWinControlAnchor();
                    break;
                case "Visible":
                    SetWinControlVisible();
                    break;
                case "Margin":
                    SetWinControlMargin();
                    break;
                case "Padding":
                    SetWinControlPadding();
                    break;
                case "Enabled":
                    SetWinControlEnabled();
                    break;
                case "ForeColor":
                    SetWinControlForeColor();
                    break;
                case "Font":
                    SetWinControlFont();
                    break;
                case "BackColor":
                    SetWinControlBackColor();
                    break;
                case "Controls":
                    SetWinControlControls();
                    break;
                case "BorderStyle":
                    SetWinControlBorderStyle();
                    break;
                case "DataBindings":
                    SetWinControlDataBindings();
                    break;
                case "BackgroundImage":
                    SetWinControlBackgroundImage();
                    break;
                case "BackgroundImageLayout":
                    SetWinControlBackgroundImageLayout();
                    break;                    
                case "Row":
                case "Column":
                case "RowSpan":
                case "ColumnSpan":
                    SetWinControlLayoutInfo();
                    break;
                case "TabIndex":
                    SetWinControlTabIndex();
                    break;
                case "Parent":
                    SetWinControlParent();
                    break;
                case "RightToLeft":
                    SetWinControlRightToLeft();
                    break;
            }
		}

        /// <summary>
        /// Sets the win control right automatic left.
        /// </summary>
        private void SetWinControlRightToLeft()
        {
            this.WinControl.RightToLeft = (System.Windows.Forms.RightToLeft)((int)this.WebControl.RightToLeft);
        }

        /// <summary>
        /// Sets the win control parent.
        /// </summary>
        private void SetWinControlParent()
        {
            // Get winform control's old parent
            WinForms.Control objOldParent = this.WinControl.Parent;

            // Get new parent control's controller
            ControlController objNewParentControlController = this.GetControllerByWebObject(this.WebControl.Parent) as ControlController;

            if (objNewParentControlController != null)
            {
                // Update Parent property to this winform control
                this.SetWinProperty("Parent", objNewParentControlController.WinControl);

                // Fire controls changed on the new webgui parent
                this.DesignServices.FireWebComponentChanged(objNewParentControlController.WebControl, "Controls", objNewParentControlController.WebControl.Controls, objNewParentControlController.WebControl.Controls);

                // Get old parent controller
                ControlController objOldParentControlController = this.GetControllerByWinObject(objOldParent) as ControlController;

                if (objOldParentControlController != null && objOldParentControlController.WebControl != null)
                {
                    // Fire controls changed on the old webgui parent
                    this.DesignServices.FireWebComponentChanged(objOldParentControlController.WebControl, "Controls", objOldParentControlController.WebControl.Controls, objOldParentControlController.WebControl.Controls);
                }
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
			this.WinControl.Click+=new EventHandler(WinControl_Click);
			IObservableLayoutItem objObservableLayoutItem = this.WebComponent as IObservableLayoutItem;
			if(objObservableLayoutItem!=null)
			{
				objObservableLayoutItem.ObservableResumeLayout+=new ObservableResumeLayoutHandler(WebComponent_ObservableResumeLayout);
				objObservableLayoutItem.ObservableSuspendLayout+=new EventHandler(WebComponent_ObservableSuspendLayout);
			}
			
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinControl_Click(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("Click");
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void WebComponent_ObservableResumeLayout(object objSender, ObservableResumeLayoutArgs objArgs)
		{
			this.WinControl.ResumeLayout(objArgs.PerformLayout);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WebComponent_ObservableSuspendLayout(object sender, EventArgs e)
		{
			this.WinControl.SuspendLayout();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();

			this.WinControl.Click-=new EventHandler(WinControl_Click);
			IObservableLayoutItem objObservableLayoutItem = this.WebComponent as IObservableLayoutItem;
			if(objObservableLayoutItem!=null)
			{
				objObservableLayoutItem.ObservableResumeLayout-=new ObservableResumeLayoutHandler(WebComponent_ObservableResumeLayout);
				objObservableLayoutItem.ObservableSuspendLayout-=new EventHandler(WebComponent_ObservableSuspendLayout);
			}
		}


        /// <summary>
        /// Sets the AutoSize property of the web label .
        /// </summary>
        private void SetWebControlAutoSize()
        {
            if (this.WebControl.AutoSize != this.WinControl.AutoSize)
            {
                this.SetWebProperty("AutoSize", this.WinControl.AutoSize);
            }
        }

        protected virtual void SetWinControlAutoSize()
        {
            if (this.WebControl.AutoSize != this.WinControl.AutoSize)
            {
                this.SetWinProperty("AutoSize", this.WebControl.AutoSize);
            }
        }
		
		#endregion Events
		
		#region Desin Time
				
		/// <summary>
		///
		/// </summary>
		internal void SetWebControlDesignTimeValues()
		{
			this.SetWebControlLocation();
			this.SetWebControlSize();
			this.SetWebControlText();
            this.SetWebControlAutoSize();
		}

        /// <summary>
        /// Sets the win control design time values.
        /// </summary>
        internal void SetWinControlDesignTimeValues()
        {
            this.SetWinControlTabIndex();
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWebControlText()
		{
			this.WebControl.Text = this.WinControl.Text;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWebControlSize()
		{
            if (this.WebControl.Size != this.WinControl.Size)
            {
                try
                {
                    this.SuspendNotifications();
                    this.WebControl.Size = new Size(Convert.ToInt32(this.WinControl.Size.Width / TargetHorizontalScaleFactor), Convert.ToInt32(this.WinControl.Size.Height / TargetVerticalScaleFactor));
                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
		}
		
		/// <summary>
		///
		/// </summary>
        protected virtual void SetWebControlLocation()
        {
            if (this.WinControl.Location != this.WebControl.Location)
            {
                try
                {
                    this.SuspendNotifications();

                    this.DesignServices.FireWebComponentChanging(this.WebComponent, "Location");

                    object objOldValue = this.WebControl.Location;
                    this.WebControl.Location = new Point(Convert.ToInt32(this.WinControl.Location.X/TargetHorizontalScaleFactor), Convert.ToInt32(this.WinControl.Location.Y/TargetVerticalScaleFactor));
                    object objNewValue = this.WebControl.Location;

                    this.DesignServices.FireWebComponentChanged(this.WebComponent, "Location", objOldValue, objNewValue);

                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
        }

        private void SetWebControlAnchor()
        {
            this.WebControl.Anchor = (WebForms.AnchorStyles)this.GetConvertedEnum(typeof(WebForms.AnchorStyles), this.WinControl.Anchor);
        }

        private void SetWebControlDock()
        {
            this.WebControl.Dock = (WebForms.DockStyle)this.GetConvertedEnum(typeof(WebForms.DockStyle), this.WinControl.Dock);
            if (this.WinControl.Dock == WinForms.DockStyle.None)
            {
                SetWebControlAnchor();
            }
        }

        /// <summary>
        /// Fires the table layout panel control positions changed event.
        /// </summary>
        private void FireTableLayoutPanelControlPositionsChanged()
        {
            if (!this.DesignInitialization && !this.IsNotificationSuspened)
            {
                if (this.WinControl.Parent is WinForms.TableLayoutPanel &&
                    this.WinControl.Parent != null)
                {
                    ObjectController objObjectController = GetControllerByWinObject(this.WinControl.Parent);

                    if (objObjectController != null)
                    {
                        try
                        {
                            this.SuspendNotifications();
                            objObjectController.FireWinPropertyChanged(new ObservableItemPropertyChangedArgs("ControlPositions", this.TargetObject));
                        }
                        finally
                        {
                            this.ResumeNotifications();
                        }
                    }
                }
            }
        }

		#endregion Desin Time
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Control WebControl
		{
			get
			{
				return base.SourceObject as WebForms.Control;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.Control WinControl
		{
			get
			{
				return base.TargetObject as WinForms.Control;
			}
		}


        /// <summary>
        /// Gets the type of the win parent by web.
        /// </summary>
        /// <param name="objWebParentType">Type of the obj web parent.</param>
        /// <returns></returns>
        protected WinForms.Control GetWinAncestorByWebType(Type objAncestorWebType)
        {
            // Get Win control
            WinForms.Control objControl = this.WinControl;

            // Go over the parent until we get the required type
            while (objControl != null)
            {
                //Get controler by win control
                ControlController objController = this.GetControllerByWinObject(objControl) as ControlController;
                
                //Check that we have the controller
                if (objController != null && objController.WebControl!=null)
                {
                    // Check if the controller's web control is the required one
                    if (objController.WebControl.GetType() == objAncestorWebType)
                    {
                        break;
                    }
                }

                // Point on the control parent
                objControl = objControl.Parent;
            }

            return objControl;

        }
    
		
		#endregion Properties
		
	}
	
	#endregion ControlController Class
	
}
