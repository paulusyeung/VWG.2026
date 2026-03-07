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

namespace CompanionKit.Controls.Form.Programming
{
    public partial class ActivatingForm : global::Gizmox.WebGUI.Forms.Form
    {
        public ActivatingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Closes the Form.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles Activated event of the form.
        /// Updates text of the form label.
        /// </summary>
        private void ActivatingForm_Activated(object sender, EventArgs e)
        {
            this.mobjLabel.Text = "This form is Activated!";
        }

        /// <summary>
        /// Handles Deactivate event of the form.
        /// Updates text of the form label.
        /// </summary>
        private void ActivatingForm_Deactivate(object sender, EventArgs e)
        {
            this.mobjLabel.Text = "This form is Deactivated!";
        }
    }
}