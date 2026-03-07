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

namespace CompanionKit.Controls.ComboBox.Functionality
{
    public partial class ValueTextChangePage : UserControl
    {
        public ValueTextChangePage()
        {
            InitializeComponent();
            //Set DataSource as array of Colors.
            this.mobjComboBox.DataSource = Enum.GetValues(typeof(KnownColor));
        }

        private void mobjComboBox_TextChanged(object sender, EventArgs e)
        {
            //Set text of tested ComboBox as text of indicator TextBox.
            this.mobjComboBoxTextTextBox.Text = this.mobjComboBox.Text;
        }

        private void mobjComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.mobjComboBox.SelectedValue != null)
            {
                //Set text of tested ComboBox SelectedValue as text of indicator TextBox.
                this.mobjValueTextBox.Text = this.mobjComboBox.SelectedValue.ToString();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjTextTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjTextTextBox.Text))
            {
                mobjComboBox.Text = mobjTextTextBox.Text;
            }
        }
    }
}