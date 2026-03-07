using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ErrorProvider.Features
{
    public partial class ErrorIconAlignmentMethodPage : UserControl
    {
        public ErrorIconAlignmentMethodPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ErrorIconAlignmentMethodPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ErrorIconAlignmentMethodPage_Load(object sender, EventArgs e)
        {
            // Load enum ErrorIconAlignment values into 
            // ComboBox items collection
            mobjIconAlignmentCB.DataSource = Enum.GetValues(typeof(ErrorIconAlignment));
        }

        /// <summary>
        /// Handles the Click event of the mobjShowErrorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowErrorButton_Click(object sender, EventArgs e)
        {
            // Set ErrorIconAlignment value for ErrorProvider
            // using ComboBox selected item value
            mobjErrorProvider.SetIconAlignment(mobjTextBox, (ErrorIconAlignment)mobjIconAlignmentCB.SelectedItem);
            // Set error and message for TextBox control
            mobjErrorProvider.SetError(mobjTextBox, "Error occured");
        }

        /// <summary>
        /// Handles the Click event of the mobjHideErrorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjHideErrorButton_Click(object sender, EventArgs e)
        {
            // Remove error and message from TextBox control
            mobjErrorProvider.SetError(mobjTextBox, "");
        }
    }
}