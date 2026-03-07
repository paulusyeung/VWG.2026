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
    public partial class ClosedForm : global::Gizmox.WebGUI.Forms.Form
    {
        public ClosedForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the form button.
        /// Closes the form.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}