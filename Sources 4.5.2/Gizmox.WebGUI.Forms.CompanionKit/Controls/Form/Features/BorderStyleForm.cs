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
    public partial class BorderStyleForm : global::Gizmox.WebGUI.Forms.Form
    {
        public BorderStyleForm()
        {
            InitializeComponent();

            this.BorderWidth = 1;
            this.BorderColor = Color.Red;
        }

        /// <summary>
        /// Handles Click event for 'Ok' button.
        /// Closes the form and set 'OK' dialog result for Form.
        /// </summary>
        private void mobjOkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles Load event of the Form
        /// </summary>
        private void BorderStyleForm_Load(object sender, EventArgs e)
        {
            // Fill up ComboBox with form border styles.
            BorderStyle defaultBorderStyle = this.BorderStyle;
            this.mobjComboBox.DataSource = Enum.GetValues(typeof(Gizmox.WebGUI.Forms.BorderStyle));
            this.mobjComboBox.SelectedItem = defaultBorderStyle;
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox with form border styles.
        /// </summary>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change a border style for the form.
            this.BorderStyle = (Gizmox.WebGUI.Forms.BorderStyle)this.mobjComboBox.SelectedItem;
        }
    }
}