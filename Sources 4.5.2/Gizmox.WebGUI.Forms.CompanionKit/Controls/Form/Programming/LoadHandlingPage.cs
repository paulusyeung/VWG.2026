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
    public partial class LoadHandlingPage : UserControl
    {
        public LoadHandlingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Opens the demonstrated Form.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            
            LoadEventForm form = new LoadEventForm();

            form.ShowDialog();
        }
    }
}