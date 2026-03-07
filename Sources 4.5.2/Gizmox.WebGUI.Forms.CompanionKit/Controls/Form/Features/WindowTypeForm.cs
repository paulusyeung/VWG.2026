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
    public partial class WindowTypeForm : Gizmox.WebGUI.Forms.Form
    {
        /// <summary>
        /// Creates the From type.
        /// </summary>
        /// <param name="_windowType">Name of the Form type</param>
        public WindowTypeForm(string _windowType)
        {
            InitializeComponent();
            // Set name of the form and text for form label.
            this.Text = string.Format("This is {0} Form.", _windowType);
            this.mobjLabel.Text = string.Format("This is {0} Form. Click on button for closing it.", _windowType);
        }

        /// <summary>
        /// Handles Click event of the 'Close' button.
        /// Closes the demonstrated form.
        /// </summary>
        private void mobjCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}