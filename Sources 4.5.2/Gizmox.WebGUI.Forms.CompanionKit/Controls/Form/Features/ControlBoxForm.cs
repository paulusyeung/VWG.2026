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
    public partial class ControlBoxForm : global::Gizmox.WebGUI.Forms.Form
    { 
        public ControlBoxForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Toggles ControlBox visibility
            this.ControlBox = ((Gizmox.WebGUI.Forms.CheckBox)sender).Checked;
            //Toggles close button visibility
            this.mobjCloseButton.Visible = !((Gizmox.WebGUI.Forms.CheckBox)sender).Checked;
        }

        /// <summary>
        /// Handles the Click event of the objCloseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCloseButton_Click(object sender, EventArgs e)
        {
            //Closes form
            this.Close();
        }
    }
}