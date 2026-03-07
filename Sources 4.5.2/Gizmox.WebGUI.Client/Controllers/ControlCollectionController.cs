#region Using

using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Client.Design;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ControlCollectionController Class
	
	/// <summary>
	/// Controls the relations between a webgui component and a winforms component
	/// </summary>
	
	public class ControlCollectionController : ComponentCollectionController
	{
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ControlCollectionController(IContext objContext,object objWebControl,IList objWebControls,object objWinControl,IList objWinControls) :base(objContext,objWebControl,objWebControls,objWinControl,objWinControls)
		{
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		#region General
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override ObjectController CreateObjectControlerBySourceObject(object objWebObject)
		{
			return ObjectController.CreateControllerByWebObject(Context, objWebObject);
		}
		
		/// <summary>
		/// Inizialized contained objects
		/// </summary>
		protected override void InitializeWinObjects()
		{
			// Suspend winforms layout
			this.WinControl.SuspendLayout();
			
			// Apply design time size
            if (this.WebControl is WebForms.Form)
			{
                this.WinControl.ClientSize = new Size(Convert.ToInt32(this.WebLayoutItem.Size.Width * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebLayoutItem.Size.Height * TargetVerticalScaleFactor));
			}
			
			// Initialize winforms objects
			base.InitializeWinObjects();
			
			// Resume layour
			this.WinControl.ResumeLayout();
			
			// Apply runtime design
            if (this.WebControl is WebForms.Form)
			{
                this.WinControl.Size = new Size(Convert.ToInt32(this.WebControl.Size.Width * TargetHorizontalScaleFactor), Convert.ToInt32(this.WebControl.Size.Height * TargetVerticalScaleFactor));
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebObject"></param>
		protected override int OnWebObjectAdded(object objWebObject)
		{
			this.WinControl.SuspendLayout();
			int intIndex = base.OnWebObjectAdded(objWebObject);
			this.WinControl.ResumeLayout();
			return intIndex;
		}
		
		
		#endregion General
		
		#region Design Time Events
		
		/// <summary>
		/// Attach design time events
		/// </summary>
		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			
			// Attach control adding and removing
			this.WinControl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(WinControl_ControlRemoved);
		}
		
		/// <summary>
		/// Handles control removing in desitn time
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinControl_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
		{
			// If notifications are not suspended
			if (!this.IsNotificationSuspened)
			{
				// Get controller
				ControlController objControlController = GetControllerByWinObject(e.Control) as ControlController;
				if (objControlController != null)
				{
					// Try getting the web control's controller in order to perform the "SetWebControlControls" on it.
                    ControlController objWebControlController = this.GetControllerByWebObject(this.WebControl) as ControlController;
                    if (objWebControlController != null)
                    {
                        objWebControlController.SetWebControlControls();
                    }
                    else
                    {
                        SetWebControlControls();
                    }
				}
			}
		}
		
		/// <summary>
		/// Detach design time events
		/// </summary>
		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			
			// Deatach events
			this.WinControl.ControlRemoved -= new System.Windows.Forms.ControlEventHandler(WinControl_ControlRemoved);
		}
		
		/// <summary>
		/// Sets win controls from the web control collection
		/// </summary>
		internal void SetWinControlControls()
		{
			// If controls are valid
            if (this.WebControls != null && this.WinControls != null)
            {
                try
                {
                    // Suspend event notifications
                    this.SuspendNotifications();

                    // Suspend wincontrol layouting
                    this.WinControl.SuspendLayout();

                    // Create winforms controll collection
                    ArrayList objWinControls = new ArrayList(this.WinControls);

                    // Clear winforms colleciton
                    this.WinControls.Clear();

                    // Loop all web controls
                    foreach (WebForms.Control objWebControl in this.WebControls)
                    {
                        // Try to get controller
                        ControlController objControlController = ((IContextServices)this.Context).GetControllerByWebObject(objWebControl) as ControlController;
                        if (objControlController == null)
                        {
                            // Create new controller
                            objControlController = ObjectController.CreateControllerByWebObject(this.Context, objWebControl) as ControlController;
                            if (this.DesignMode)
                            {
                                // Initialize controller
                                objControlController.Initialize();
                                objControlController.Load();

                                // Register controller
                                this.RegisterController(objControlController);

                                // Register winforms component
                                DesignServices.RegisterWinComponent(objControlController.WinControl);
                            }
                        }
                        else
                        {
                            // Remove control from collection
                            objWinControls.Remove(objControlController.TargetObject);
                        }

                        // If valid controller
                        if (objControlController != null)
                        {
                            // Add winforms control
                            this.WinControls.Add(objControlController.WinControl);
                        }
                    }

                    // Loop all winforms control
                    foreach (WinForms.Control objWinControl in objWinControls)
                    {
                        // Try to get controller
                        ControlController objControlController = ((IContextServices)this.Context).GetControllerByWinObject(objWinControl) as ControlController;
                        if (objControlController != null)
                        {
                            // terminate controller
                            objControlController.Terminate();

                            // Unregister controller
                            ((IContextServices)this.Context).UnregisterController(objControlController);
                        }
                    }

                    // Resume wincontrol layouting
                    this.WinControl.ResumeLayout();

                }
                finally
                {
                    this.ResumeNotifications();
                }
            }
		}
        
		
		/// <summary>
		/// Sets web controls from the win control collection
		/// </summary>
		internal void SetWebControlControls()
		{
			// If controls are valid
            if (this.WebControls != null && !this.WebControls.IsReadOnly && this.WinControls != null)
            {
                try
                {
                    // Suspend event notifications
                    this.SuspendNotifications();

                    // Create web controls collection
                    ArrayList objWebControls = new ArrayList(this.WebControls);

                    // Clear web controls
                    this.WebControls.Clear();
                    
                    // Loop all winforms controls
                    foreach (WinForms.Control objWinControl in this.WinControls)
                    {
                        // Try to get controller
                        ControlController objControlController = ((IContextServices)this.Context).GetControllerByWinObject(objWinControl) as ControlController;
                        if (objControlController != null)
                        {
                            // If in design mode
                            if (this.DesignMode)
                            {
                                // If tab index not set
                                if (!objControlController.WebControl.HasTabIndex)
                                {
                                    // Get last tab index
                                    int intNewTabIndex = 0;

                                    // Loop all web controls
                                    foreach (WebForms.Control objWebControl in objWebControls)
                                    {
                                        // if larger tab index
                                        if (intNewTabIndex <= objWebControl.TabIndex)
                                        {
                                            intNewTabIndex = objWebControl.TabIndex + 1;
                                        }
                                    }

                                    // Set tab index
                                    objControlController.WebControl.TabIndex = intNewTabIndex;
                                }
                            }

                            // Add to the web collection
                            this.WebControls.Add(objControlController.WebControl);

                            // If new web control
                            if (!objWebControls.Contains(objControlController.WebControl))
                            {
                                // If in design mode
                                if (this.DesignMode)
                                {
                                    // Set control design time values
                                    objControlController.SetWebControlDesignTimeValues();

                                    // Set win control design time values
                                    objControlController.SetWinControlDesignTimeValues();

                                    // Register web component
                                    this.DesignServices.RegisterWebComponent(objControlController.WebControl);
                                }

                                // Get parent controller
                                ControlController objParentControlController = GetControllerByWinObject(objWinControl.Parent) as ControlController;
                                if (objParentControlController != null)
                                {
                                    // Add control to parent control
                                    objParentControlController.WebControl.Controls.Add(objControlController.WebControl);

                                    // If in design mode
                                    if (this.DesignMode)
                                    {
                                        // Fire control changed on the collection owner
                                        this.DesignServices.FireWebComponentChanged(objParentControlController.WebControl, "Controls", objParentControlController.WebControl.Controls, objParentControlController.WebControl.Controls);
                                    }
                                }
                            }
                            else
                            {
                                // remove from web control collection
                                objWebControls.Remove(objControlController.WebControl);
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
		
		
		#endregion Design Time Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		private IObservableLayoutItem WebLayoutItem
		{
			get
			{
				return base.SourceObject as IObservableLayoutItem;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Control.ControlCollection WebControls
		{
			get
			{
				return base.WebObjects as WebForms.Control.ControlCollection;
			}
		}
		
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
		public WinForms.Control.ControlCollection WinControls
		{
			get
			{
				return base.WinObjects as WinForms.Control.ControlCollection;
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
		
		
		#endregion Properties
		
	}
	
	#endregion ControlCollectionController Class
	
}
