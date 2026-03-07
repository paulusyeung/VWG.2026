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

namespace CompanionKit.Controls.CheckBox.Functionality
{
    public partial class ThreeStatePage : UserControl
    {
        public ThreeStatePage()
        {
            InitializeComponent();

            //Populate ComboBox with the values of CheckState property
            mobjStateCombo.DataSource = Enum.GetValues(typeof(CheckState));

            //Update Label showing current CheckState
            UpdateLabelText();
        }

        private void mobjStateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change CheckBox.CheckState according to selected item in ComboBox
            mobjCheckBox.CheckState = (CheckState)mobjStateCombo.SelectedItem;
        }

        /// <summary>
        /// Handles the CheckStateChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            //Change selected item in ComboBox according to current CheckBox.CheckState
            mobjStateCombo.SelectedItem = mobjCheckBox.CheckState;

            //Update Label showing current CheckState
            UpdateLabelText();
        }

        /// <summary>
        /// Updates the label text to show current CheckState property value.
        /// </summary>
        private void UpdateLabelText()
        {
            mobjStateLabel.Text = "CheckBox State: " + mobjCheckBox.CheckState.ToString();
        }
    }
}