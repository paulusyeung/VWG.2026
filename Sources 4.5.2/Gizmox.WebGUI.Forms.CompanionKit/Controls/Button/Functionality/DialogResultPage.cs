using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;


namespace CompanionKit.Controls.Button.Functionality
{
    public partial class DialogResultPage : UserControl
    {
        public DialogResultPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjOpenButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjOpenButton_Click(object sender, EventArgs e)
        {
            //Show form as dialog
            CustomDialogForm mobjDialogForm = new CustomDialogForm();
            mobjDialogForm.ShowDialog(OnCloseForm);
        }

        /// <summary>
        /// Called when [close form].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        void OnCloseForm(object sender, EventArgs args)
        {
            //Show appropriate message
            CustomDialogForm objForm = (CustomDialogForm)sender;
            if (objForm.DialogResult == DialogResult.Yes)
                MessageBox.Show("'Yes' button has been clicked");
            else if (objForm.DialogResult == DialogResult.No)
                MessageBox.Show("'No' button has been clicked");
        }
    }
}