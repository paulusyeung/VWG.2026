using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    public class DockedForm : Form, IDescriptable, IPreventExtraction
    {
		#region Fields (3) 

        private bool mblnPreventExtraction;
        private DockedFormDescriptor mobjData;
        private DockingManager mobjManager;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedForm"/> class.
        /// </summary>
        /// <param name="objManager">The obj manager.</param>
        public DockedForm(DockingManager objManager)
        {
            this.mobjData = new DockedFormDescriptor();
            this.TopLevel = true;
            this.mobjManager = objManager;
            this.mblnPreventExtraction = false;
            this.AllowDragTargetsPropagation = false;
        }

		#endregion Constructors 

		#region Properties (4) 

        /// <summary>
        /// Gets the windows.
        /// </summary>
        public List<DockingWindow> Windows
        {
            get
            {
                Control objControl = null;

                if (this.Controls.Count > 0)
                {
                    objControl = this.Controls[0];
                }

                if (objControl != null)
                {
                    if (objControl is Zone)
                    {
                        return (objControl as Zone).Windows;
                    }
                    else if (objControl is DockedSplitContainer)
                    {
                        return (objControl as DockedSplitContainer).Windows;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>
        /// The default size.
        /// </value>
        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return new System.Drawing.Size(300,300);
            }
        }

        /// <summary>
        /// Gets the docked form descriptor internal.
        /// </summary>
        internal DockedFormDescriptor DockedFormDescriptorInternal
        {
            get { return mobjData; }
        }

        /// <summary>
        /// Gets the descriptor.
        /// </summary>
        DockedObjectDescriptor IDescriptable.Descriptor
        {
            get { return mobjData; }
        }

        /// <summary>
        /// Gets the manager.
        /// </summary>
        public DockingManager Manager
        {
            get { return mobjManager; }
        }

		#endregion Properties 

		#region Methods (13) 

        /// <summary>
        /// Called when [window state changed].
        /// </summary>
        /// <param name="enmNewFormWindowState">State of the enm new form window.</param>
        protected override void OnWindowStateChanged(FormWindowState enmNewFormWindowState)
        {
            base.OnWindowStateChanged(enmNewFormWindowState);
            
            this.mobjData.UpdateSelf(this, this.Manager);
        }

		// Public Methods (1) 

        /// <summary>
        /// Occurs when control is created
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.mobjData.OwningFormId = this.ID;
        }

        /// <summary>
        /// Disables the extraction.
        /// </summary>
        /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
        public void DisableExtraction(bool blnDisable)
        {
            this.mblnPreventExtraction = blnDisable;
        }
		// Protected Methods (5) 

        /// <summary>
        /// Raises the <see cref="E:Closing"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            this.mobjData.FormClosing();
        }

        /// <summary>
        /// Raises the <see cref="E:ControlAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is IDescriptable)
            {
                base.OnControlAdded(e);

                // If this form has any controls, show it. - An owner is set by default by the DockingManager
                this.Show();

                // Update the Descriptable control
                (e.Control as IDescriptable).Descriptor.UpdateFrom(this, null);

                // Attach a control added listener for the newly added control
                HandleAddingControl(e.Control,true);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            // Remove the control added listener from the control
            HandleAddingControl(e.Control, false);

            // Close this window if it has no items
            if (this.Controls.Count == 0 && !mblnPreventExtraction)
            {
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLocationChanged(LayoutEventArgs e)
        {
            base.OnLocationChanged(e);

            // Update the Descriptor params
            this.mobjData.UpdateSelf(this, this.mobjManager);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Update the Descriptor params
            this.mobjData.UpdateSelf(this, this.mobjManager);
        }
		// Private Methods (6) 

        /// <summary>
        /// Controls the added listener.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="blnAddListener">if set to <c>true</c> [BLN add listener].</param>
        private void HandleAddingControl(Control objControl, bool blnAddListener)
        {
            if (objControl is DockingWindow && blnAddListener)
            {
                // Registrer this form as the window's owner
                this.Manager.SetWindowFormMapping(objControl as DockingWindow, this.mobjData);
            }
            else
            {
                Zone objZone = (objControl as Zone);

                // Check if the given control is a zone
                if (objZone != null)
                {
                    // Set the zone's owner form with this form's ID
                    objZone.OwningFormId = this.ID;
                    if (blnAddListener)
                    {
                        // Switch zone's type to be a Floating zone
                        objZone.ZoneType = ZoneType.Float;

                        // Create an empty list for the drag tagets
                        List<Component> objDragTargets = new List<Component>();

                        // Go through each of the drag targets
                        foreach (Component objConponent in this.DragTargets)
                        {
                            // If a target's ID is equal to the added zone, don't add it to the list
                            if (objConponent.ID != objZone.ID)
                            {
                                objDragTargets.Add(objConponent);
                            }
                        }

                        // Set the new drag targets list
                        this.DragTargets = objDragTargets.ToArray();
                    }
                    else
                    {
                        // If the zone is removed, the the owning form to -1
                        objZone.OwningFormId = Zone.ZONE_WITH_NO_OWNING_FORM_ID;
                    }
                }

                
                if (blnAddListener)
                {
                    // Add an event listener to the control for added controls
                    objControl.ControlAdded += new ControlEventHandler(objControl_ControlAdded);
                    objControl.ControlRemoved += new ControlEventHandler(objControl_ControlRemoved);
                }
                else
                {
                    // Remove the event listener to the control for added controls
                    objControl.ControlAdded -= new ControlEventHandler(objControl_ControlAdded);
                    objControl.ControlRemoved -= new ControlEventHandler(objControl_ControlRemoved);
                }

                // Recursivly add listeners to the child controls
                foreach (Control objInnerControl in objControl.Controls)
                {
                    HandleAddingControl(objInnerControl, blnAddListener);
                }
            }
        }

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            DockedFormDescriptor objFormDescriptor = objDescriptor as DockedFormDescriptor;
            if (objFormDescriptor != null)
            {
                // Get the size
                this.Size = objFormDescriptor.Size;

                // Set start position to menual in orderfor the form to be open in a given position
                this.StartPosition = FormStartPosition.Manual;

                // Get the location
                this.Location = objFormDescriptor.Location;

                this.WindowState = objFormDescriptor.WindowState;

                // Set the descriptor's referance
                this.mobjData = objFormDescriptor;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Resets the descriptors tree.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <param name="objDockingPosition">The obj docking position.</param>
        void IDescriptable.ResetDescriptorsTree(ZoneType objType, DockStyle objDockingPosition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles the ControlAdded event of the objControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void objControl_ControlAdded(object sender, ControlEventArgs e)
        {
            HandleAddingControl(e.Control, true);
        }

        /// <summary>
        /// Handles the ControlRemoved event of the objControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void objControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            HandleAddingControl(e.Control, false);
        }
		// Internal Methods (1) 

        /// <summary>
        /// Sets the drag targets.
        /// </summary>
        /// <param name="arrComponenets">The arr componenets.</param>
        internal void SetDragTargets(Component[] arrComponenets)
        {
            this.DragTargets = arrComponenets;
        }

		#endregion Methods
    }
}
