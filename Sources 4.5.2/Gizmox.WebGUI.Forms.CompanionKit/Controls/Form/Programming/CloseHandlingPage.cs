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
    public partial class CloseHandlingPage : UserControl
    {
        public CloseHandlingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Opens the demonstrated form.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            ClosedForm form = new ClosedForm();
            form.Closed += new EventHandler(form_Closed);
            form.ShowDialog();

        }

        /// <summary>
        /// Handles Closed event for the demonstrated form.
        /// </summary>
        private void form_Closed(object sender, EventArgs e)
        {
            Gizmox.WebGUI.Forms.Form form = sender as Gizmox.WebGUI.Forms.Form;
            MessageBox.Show(string.Format("Form {0} is closed!", form.Text));
        }
    }
}