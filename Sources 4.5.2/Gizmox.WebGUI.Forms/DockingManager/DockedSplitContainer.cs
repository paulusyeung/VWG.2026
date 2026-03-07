using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ToolboxItem(false)]
    public class DockedSplitContainer : SplitContainer, IDescriptable, IPreventExtraction
    {
		#region Fields (3) 

        private bool mblnPreventExtraction;
        private DockedSplitContainerDescriptor mobjData;
        private DockingManager mobjManager;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedSplitContainer"/> class.
        /// </summary>
        /// <param name="objManager">The obj manager.</param>
        public DockedSplitContainer(DockingManager objManager)
        {
            this.mblnPreventExtraction = false;
            this.mobjManager = objManager;
            this.Dock = DockStyle.Fill;
            this.mobjData = new DockedSplitContainerDescriptor();

            this.BorderStyle = Forms.BorderStyle.None;

            this.Panel1.ControlAdded += new ControlEventHandler(Panel1_ControlAdded);
            this.Panel2.ControlAdded += new ControlEventHandler(Panel2_ControlAdded);

            this.Panel1.ControlRemoved += new ControlEventHandler(Panel1_ControlRemoved);
            this.Panel2.ControlRemoved += new ControlEventHandler(Panel2_ControlRemoved);

            this.Panel2Collapsed = true;
        }

		#endregion Constructors 

		#region Properties (4) 

        /// <summary>
        /// Gets the docked split container descriptor internal.
        /// </summary>
        internal DockedSplitContainerDescriptor DockedSplitContainerDescriptorInternal 
        {
            get { return this.mobjData; }
        }

        /// <summary>
        /// Gets the descriptor.
        /// </summary>
        DockedObjectDescriptor IDescriptable.Descriptor
        {
            get { return this.mobjData; }
        }

        /// <summary>
        /// Gets the windows.
        /// </summary>
        public List<DockingWindow> Windows
        { 
            get 
            {
                // Get windows from panel 1
                List<DockingWindow> objWindowsList = HandleGetWindowsFromPanel(Panel1);

                // Get Windows from panel 2
                objWindowsList.AddRange(HandleGetWindowsFromPanel(Panel2));

                return objWindowsList; 
            } 
        }

		#endregion Properties 

		#region Methods (22) 

		// Public Methods (1) 

        /// <summary>
        /// Raises the <see cref="E:SplitterMoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.SplitterEventArgs"/> instance containing the event data.</param>
        public override void OnSplitterMoved(SplitterEventArgs e)
        {
            base.OnSplitterMoved(e);
            (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);
        }
		// Protected Methods (1) 

        /// <summary> 
        /// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.mobjManager.RegisterSplitContainer(this);
        }
		// Private Methods (16) 


        /// <summary>
        /// Handles the panel.
        /// </summary>
        /// <param name="objPanel">The obj panel.</param>
        /// <returns></returns>
        private List<DockingWindow> HandleGetWindowsFromPanel(SplitterPanel objPanel)
        {
            List<DockingWindow> objWindowsList = new List<DockingWindow>();

            if (objPanel.Controls.Count == 1)
            {
                if (objPanel.Controls[0] is Zone)
                {
                    objWindowsList.AddRange((objPanel.Controls[0] as Zone).Windows);
                }
                else if ((objPanel.Controls[0] is DockedSplitContainer))
                {
                    objWindowsList.AddRange((objPanel.Controls[0] as DockedSplitContainer).Windows);
                }
            }

            return objWindowsList;
        }

        ///// <summary>
        ///// Hides the panel.
        ///// </summary>
        ///// <param name="objPanelToHide">The obj panel to hide.</param>
        ///// <param name="objOtherPanel">The obj other panel.</param>
        //private void HidePanel(SplitterPanel objPanelToHide, SplitterPanel objOtherPanel)
        //{
        //    // if the other panel is collapsed or has no values, remove this split container from the Controls hierarchy
        //    if ((objOtherPanel.Collapsed || objOtherPanel.Controls.Count == 0))
        //    {
        //        RemoveFromParent();
        //    }
        //    else
        //    {
        //        // hide this panel
        //        objPanelToHide.Collapsed = true;
        //        this.mobjData.UpdateSelf(this, this.mobjManager);
        //    }
        //}

        /// <summary>
        /// Hides the panel1.
        /// </summary>
        private void HidePanel1()
        {
            // Check if panel 1 is also hidden
            if ((this.Panel2Collapsed || Panel2.Controls.Count == 0))
            {
                RemoveFromParent();
            }
            else
            {
                this.Panel1Collapsed = true;
                this.mobjData.UpdateSelf(this, this.mobjManager);
            }
        }

        /// <summary>
        /// Hides the panel2.
        /// </summary>
        private void HidePanel2()
        {
            // Check if panel 1 is also hidden
            if ((this.Panel1Collapsed || Panel1.Controls.Count == 0))
            {
                RemoveFromParent();
            }
            else
            {
                this.Panel2Collapsed = true;
                this.mobjData.UpdateSelf(this, this.mobjManager);
            }
        }

        /// <summary>
        /// Loads the specified descriptor.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        void IDescriptable.Load(DockedObjectDescriptor objDescriptor)
        {
            // Get the descriptor with its correct Type
            DockedSplitContainerDescriptor objDockedSplitContainerDescriptor = objDescriptor as DockedSplitContainerDescriptor;

            if (objDockedSplitContainerDescriptor != null)
            {
                try
                {
                    // Set orientation
                    this.Orientation = objDockedSplitContainerDescriptor.Orientation;

                    // Set the splitter distance
                    this.SplitterDistance = objDockedSplitContainerDescriptor.SplitterDistance;
                }
                finally
                {
                    // finally set the data
                    this.mobjData = objDockedSplitContainerDescriptor;

                    // Register
                    mobjManager.RegisterSplitContainer(this);   
                }
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
            this.mobjData = this.mobjData.CloneWithoutReferences<DockedSplitContainerDescriptor>();

            // Register the new descriptor
            this.mobjManager.RegisterSplitContainer(this);

            // Reset the panels' descriptors
            if (this.Panel1.Controls.Count == 1)
            {
                IDescriptable objPanel1Control = this.Panel1.Controls[0] as IDescriptable;
                objPanel1Control.ResetDescriptorsTree(objType, objDockingPosition);
                objPanel1Control.Descriptor.UpdateFrom(this, 1);
            }
            if (this.Panel2.Controls.Count == 1)
            {
                IDescriptable objPanel2Control = this.Panel2.Controls[0] as IDescriptable;
                objPanel2Control.ResetDescriptorsTree(objType, objDockingPosition);
                objPanel2Control.Descriptor.UpdateFrom(this, 2);
            }
        }

        /// <summary>
        /// Disables the extraction.
        /// </summary>
        /// <param name="blnDisable">if set to <c>true</c> [BLN disable].</param>
        void IPreventExtraction.DisableExtraction(bool blnDisable)
        {
            mblnPreventExtraction = blnDisable;
        }

        /// <summary>
        /// Handles the ControlAdded event of the Panel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is IDescriptable)
            {
                Panel1ControlAdded(e.Control);
            }
            else
            {
                throw new Exception("DockedSplitContainer.Panel1 can contain only zones or other DockingSplitContainers");
            }
        }

        /// <summary>
        /// Handles the ControlRemoved event of the Panel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void Panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is IDescriptable)
            {
                (e.Control as IDescriptable).Descriptor.UpdateFrom(this, 1);
            }

            if (Panel1.Controls.Count == 0 && !mblnPreventExtraction)
            {
                HidePanel1();
            }
        }

        /// <summary>
        /// Panel1s the control added.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        private void Panel1ControlAdded(Control objControl)
        {
            ShowPanel1();

            (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);
            (objControl as IDescriptable).Descriptor.UpdateFrom(this, 1);
        }

        /// <summary>
        /// Handles the ControlAdded event of the Panel2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void Panel2_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is IDescriptable)
            {
                Panel2ControlAdded(e.Control);
            }
            else
            {
                throw new Exception("DockedSplitContainer.Panel2 can contain only zones or other DockingSplitContainers");
            }
        }

        /// <summary>
        /// Handles the ControlRemoved event of the Panel2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        void Panel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is IDescriptable)
            {
                (e.Control as IDescriptable).Descriptor.UpdateFrom(this, 2);
            }

            if (Panel2.Controls.Count == 0 && !mblnPreventExtraction)
            {
                HidePanel2();
            }
        }

        /// <summary>
        /// Panel2s the control added.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        private void Panel2ControlAdded(Control objControl)
        {
            ShowPanel2();

            (this as IDescriptable).Descriptor.UpdateSelf(this, this.mobjManager);
            (objControl as IDescriptable).Descriptor.UpdateFrom(this, 2);
        }

        /// <summary>
        /// Removes from parent.
        /// </summary>
        /// <returns></returns>
        private int RemoveFromParent()
        {
            this.mobjManager.UnregisterSplitContainer(this);
            int intControlIndex = this.Parent.Controls.GetChildIndex(this);
            this.Parent.Controls.Remove(this);

            return intControlIndex;
        }

        /// <summary>
        /// Shows the panel1.
        /// </summary>
        private void ShowPanel1()
        {
            this.Panel1Collapsed = false;
             
            if (Panel2.Controls.Count == 0)
            {
                Panel2Collapsed = true;
            }
            else
            {
                this.SplitterDistance = this.mobjData.SplitterDistance;
                Panel2Collapsed = false;
            }
        }

        /// <summary>
        /// Shows the panel2.
        /// </summary>
        private void ShowPanel2()
        {
            this.Panel2Collapsed = false;

            if (Panel1.Controls.Count == 0)
            {
                Panel1Collapsed = true;
            }
            else
            {
                this.SplitterDistance = this.mobjData.SplitterDistance;
                Panel1Collapsed = false;
            }
        }
		// Internal Methods (4) 

        /// <summary>
        /// Removes the panel.
        /// </summary>
        /// <param name="intPanelSide">The int panel side.</param>
        internal void HardRemovePanel(int intPanelSide)
        {
            // The control on the other side of the given panel side
            Control objControlInOtherPanel = null;

            SplitterPanel objRemovingPanel = null;
            SplitterPanel objOtherSidePanel = null;

            if (intPanelSide == 1)
            {
                objRemovingPanel = this.Panel1;
                objOtherSidePanel = this.Panel2;
            }
            else if (intPanelSide == 2)
            {
                objRemovingPanel = this.Panel2;
                objOtherSidePanel = this.Panel1;
            }
            else
            {
                throw new Exception();
            }

            // Check if the othe panel has any controls
            if (objOtherSidePanel.Controls.Count > 0)
            {
                // Disable this split container's automatic extraction
                (this as IPreventExtraction).DisableExtraction(true);

                // Get the control from the other panel
                objControlInOtherPanel = objOtherSidePanel.Controls[0];

                // Remove the other control from the other panel
                objOtherSidePanel.Controls.Remove(objControlInOtherPanel);
            }

            // Remove the controls from the given panel
            objRemovingPanel.Controls.Clear();

            // Re-enable the automatic extraction
            (this as IPreventExtraction).DisableExtraction(false);

            // if the othe side had a 
            if (objControlInOtherPanel != null)
            {
                // Get the parent control
                Control objParent = this.Parent;

                // Get the Descriptable parent control
                Control objLogicalParent = DockedManagerHelper.GetLogicalParentControl(this);

                // Try to disable the self-removing logic in the descriptable control
                if (objLogicalParent is IPreventExtraction) (objLogicalParent as IPreventExtraction).DisableExtraction(true);

                // Remove this splitter from its parent
                int intParentIndex = this.RemoveFromParent();

                // Re-enable the removing logic
                if (objLogicalParent is IPreventExtraction) (objLogicalParent as IPreventExtraction).DisableExtraction(false);

                // Add the control from the other parent to the parent
                objParent.Controls.Add(objControlInOtherPanel);

                // Set its index
                objParent.Controls.SetChildIndex(objControlInOtherPanel, intParentIndex);
            }
        }

        /// <summary>
        /// Updates the focused control state
        /// </summary>
        internal override void UpdateFocusedControl()
        { }

		#endregion Methods 
    }
}