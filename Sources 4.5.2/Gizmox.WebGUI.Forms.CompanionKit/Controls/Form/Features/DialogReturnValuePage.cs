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
    public partial class DialogReturnValuePage : UserControl
    {
        public DialogReturnValuePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Opens a form with register closed event. 
        /// And the form defines dialog result value while closing.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            DialogReturnValueForm mobjDialogWithReturnValueForm = new DialogReturnValueForm();
            mobjDialogWithReturnValueForm.Closed += new System.EventHandler(this.mobjDialogWithReturnValueForm_Closed);
            mobjDialogWithReturnValueForm.ShowDialog();
        }

        /// <summary>
        /// Handles Closed event for the form with defined dialog result. 
        /// Shows message that informs about the form dialog result.
        /// </summary>
        private void mobjDialogWithReturnValueForm_Closed(object sender, EventArgs e)
        {
            DialogReturnValueForm mobjDialogWithReturnValueForm = sender as DialogReturnValueForm;
            if (mobjDialogWithReturnValueForm.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(string.Format("Saving {0} user with E-mail: {1} and Phone: {2}!",
                mobjDialogWithReturnValueForm.UserFullName, mobjDialogWithReturnValueForm.Email, mobjDialogWithReturnValueForm.Phone));
            }
            else
            {
                MessageBox.Show("Cancel editing user data...");
            }

        }

    }
}