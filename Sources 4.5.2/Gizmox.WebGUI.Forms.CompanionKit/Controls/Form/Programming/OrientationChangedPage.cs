using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.Form.Programming
{
    public partial class OrientationChangedPage : UserControl
    {
        public OrientationChangedPage()
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
            //Shows OrientationForm instance
            OrientationForm mobjForm = new OrientationForm();
            mobjForm.WindowState = FormWindowState.Maximized;
            mobjForm.Show();
        }


    }
}