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
    public partial class LoadEventForm : global::Gizmox.WebGUI.Forms.Form
    {
        public LoadEventForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Closes the Form.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Handles Load event for the form.
        /// Shows infomation message.
        /// </summary>
        private void LoadEventForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form is loaded!");
        }
    }
}