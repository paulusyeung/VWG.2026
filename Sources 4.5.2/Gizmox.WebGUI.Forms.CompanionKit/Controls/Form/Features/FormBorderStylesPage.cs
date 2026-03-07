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
    public partial class FormBorderStylesPage : UserControl
    {
        public FormBorderStylesPage()
        {
            InitializeComponent();
            
            // Fill up with the form border styles.
            this.mobjComboBox.DataSource = Enum.GetValues(typeof(global::Gizmox.WebGUI.Forms.BorderStyle));
        }

        /// <summary>
        /// Handles Click event of the button.
        /// Opens Form with the specified border style.
        /// </summary>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            BorderStyleForm form = new BorderStyleForm();
            form.BorderStyle = (Gizmox.WebGUI.Forms.BorderStyle)this.mobjComboBox.SelectedItem;
            form.ShowDialog();
        }
    }
}