using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.Form.Features
{
    public partial class ControlBoxPage : UserControl
    {
        public ControlBoxPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            //Creates and open dialog form instance
            ControlBoxForm mobjControlBoxForm = new ControlBoxForm();
            mobjControlBoxForm.ShowDialog();
        }

    }
}