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
    public partial class WindowTypePage : UserControl
    {
        /// <summary>
        /// Represents a shortcut on the Modeless From. 
        /// </summary>
        private WindowTypeForm _modelessForm;

        public WindowTypePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the 'Open modeless form' button.
        /// Shows the Modeless Form.
        /// </summary>
        private void mobjOpenModelessFormButton_Click(object sender, EventArgs e)
        {
            _modelessForm = new WindowTypeForm("Modeless");
            _modelessForm.Load += new EventHandler(modelessForm_Load);
            _modelessForm.Closed += new EventHandler(modelessForm_Closed);
            _modelessForm.Show();
        }

        /// <summary>
        /// Handles Load event of the Modeless From.
        /// </summary>
        private void modelessForm_Load(object sender, EventArgs e)
        {
            // Update field that is a shortcut on the Modeless From.
            _modelessForm = sender as WindowTypeForm;
            
            // Disable button that opens new Modeless Form
            this.mobjOpenModelessFormButton.Enabled = false;

        }

        /// <summary>
        /// Handles Closed event of the Modeless Form.
        /// </summary>
        private void modelessForm_Closed(object sender, EventArgs e)
        {
            // Reset value of the field that is a shortcut on the Modeless From.
            _modelessForm = null;
            // Enable button that opens new Modeless Form
            this.mobjOpenModelessFormButton.Enabled = true;
        }

        /// <summary>
        /// Handles Click event of the 'Open modal form' button.
        /// Shows the Modal dialog.
        /// </summary>
        private void mobjOpenModalFormButton_Click(object sender, EventArgs e)
        {
            WindowTypeForm form = new WindowTypeForm("Modal");
            form.ShowDialog();
        }

        /// <summary>
        /// Handles Click event of the 'Open popup form' button.
        /// Shows the Popup Form.
        /// </summary>
        private void mobjOpenPopupFormButton_Click(object sender, EventArgs e)
        {
            WindowTypeForm form = new WindowTypeForm("Popup");
            form.ShowPopup();
        }

        /// <summary>
        /// Handles VisibleChanged event of the example UserControl.
        /// Closes the Modeless Form.
        /// </summary>
        private void WindowTypePage_VisibleChanged(object sender, EventArgs e)
        {
            if (_modelessForm != null)
            {
                _modelessForm.Close();
            }
        }
    }
}