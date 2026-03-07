#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.Form.Features
{
    public partial class MDIParentForm : Gizmox.WebGUI.Forms.Form
    {
       
        //TODO: check after fix issue VWG-4758, remove the field.
        /// <summary>
        /// Represents List of MDI Child Forms
        /// </summary>
        private List<Gizmox.WebGUI.Forms.Form> MdiChildren = new List<Gizmox.WebGUI.Forms.Form>();
       
        //TODO: check after fix issue VWG-5954, remove the field.
        /// <summary>
        /// Represents shourtcut on the active MDI Child Form
        /// </summary>
        private Gizmox.WebGUI.Forms.Form activeForm = null;

        public MDIParentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of 'Open MDI Child Form' menu item.
        /// Opens the MDI Child Form with MDI Parent as this Form.
        /// </summary>
        private void mobjOpenMDIChildFormMenuItem_Click(object sender, EventArgs e)
        {
            MDIChildForm mdiChild = new MDIChildForm();
            MDIChildForm.idxChildForm++;
            mdiChild.MdiParent = this;
            mdiChild.Closed += new System.EventHandler(OnCloseMdiForm);

            //TODO: check after fix issue VWG-5954, remove the registering of the following two handler.
            mdiChild.Activated += new System.EventHandler(this.MDIChildForm_Activated);
            mdiChild.Deactivate += new System.EventHandler(this.MDIChildForm_Deactivated);
            mdiChild.Load += new System.EventHandler(this.MDIChildForm_Load);
            MdiChildren.Add(mdiChild);
            mdiChild.Show();
        }

        /// <summary>
        /// Handles Activated event of the MDI Child Form.
        /// </summary>
        private void MDIChildForm_Activated(object sender, EventArgs e)
        {
            activeForm = sender as global::Gizmox.WebGUI.Forms.Form;
        }

        /// <summary>
        /// Handles Deactivated event of the MDI Child Form.
        /// </summary>
        private void MDIChildForm_Deactivated(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handles Closed event of MDI Child Form
        /// </summary>
        public void OnCloseMdiForm(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Form closedMDIFrom = sender as Gizmox.WebGUI.Forms.Form;
            
            // Remove closed MDI Child form from list, that contains all MDI Children
            MdiChildren.Remove(closedMDIFrom);

            // Update enable status of menu items according to number of MDI Child Forms
            if (MdiChildren.Count > 0)
            {
                setMenuItemEnable(mobjCloseActiveMDIChildFormMenuItem, true);
                setMenuItemEnable(mobjCloseAllMDIChildFormsMenuItem, true);
            }
            else
            {
                setMenuItemEnable(mobjCloseActiveMDIChildFormMenuItem, false);
                setMenuItemEnable(mobjCloseAllMDIChildFormsMenuItem, false);
            }
        }

        /// <summary>
        /// Handles Load event of MDI Child Form
        /// Updates enable status of menu items according to number of MDI Child Forms.
        /// </summary>
        private void MDIChildForm_Load(object sender, EventArgs e)
        {
            setMenuItemEnable(mobjCloseActiveMDIChildFormMenuItem, true);
            setMenuItemEnable(mobjCloseAllMDIChildFormsMenuItem, true);
        }

        /// <summary>
        /// Sets enable status for <code>menuItem</code> menu item according to 
        /// value of the parameter <code>isEnable</code>.
        /// </summary>
        /// <param name="menuItem">The menu item</param>
        /// <param name="isEnable">Indicates whether the menu items should be enable</param>
        private void setMenuItemEnable(MenuItem menuItem, bool isEnable)
        {
            if (menuItem.Enabled != isEnable)
            {
                menuItem.Enabled = isEnable;
            }
        }

        /// <summary>
        /// Handles Click event of 'Close Active MDI Child Form' menu item.
        /// Closes the active MDI Child Form.
        /// </summary>
        private void mobjCloseActiveMDIChildFormMenuItem_Click(object sender, EventArgs e)
        {
            if (this.activeForm != null)
            {
                this.activeForm.Close();
            }
        }

        /// <summary>
        /// Handles click event for 'Close All MDI Child Forms' menu item.
        /// </summary>
        private void mobjCloseAllMDIChildFormsMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Gizmox.WebGUI.Forms.Form form in MdiChildren.ToArray())
            {
                form.Close();
            }
        }
    }
}