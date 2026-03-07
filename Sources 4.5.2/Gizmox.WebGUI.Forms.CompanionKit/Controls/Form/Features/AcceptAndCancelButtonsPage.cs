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
    public partial class AcceptAndCancelButtonsPage : UserControl
    {
        public AcceptAndCancelButtonsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event for the button.
        /// Opens the form with assigned accept and cancel buttons.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            AcceptAndCancelButtonsForm mobjAcceptAndCancelForm = new AcceptAndCancelButtonsForm();
            mobjAcceptAndCancelForm.Closed += new System.EventHandler(this.mobjAcceptAndCancelForm_Closed);
            mobjAcceptAndCancelForm.ShowDialog();
        }

        /// <summary>
        /// Handles closed event for the form with assigned accept and cancel buttons.
        /// Check the dialog result for the form and 
        /// shows saving or canceling message according to the dialog result.
        /// </summary>
        private void mobjAcceptAndCancelForm_Closed(object sender, EventArgs e)
        {
            AcceptAndCancelButtonsForm mobjAcceptAndCancelButtonsForm = sender as AcceptAndCancelButtonsForm;
            if (mobjAcceptAndCancelButtonsForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(mobjAcceptAndCancelButtonsForm.GetSavingUserMessage());
            }
            else
            {
                MessageBox.Show("Cancel editing user data...");
            }

        }
    }
}