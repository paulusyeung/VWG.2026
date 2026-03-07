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

namespace CompanionKit.Controls.RadioButton.Programming
{
    public partial class CheckStateChangedPage : UserControl
    {
        public CheckStateChangedPage()
        {
            InitializeComponent();
            //Update labels text with initial checked state of demonstrated RadioButtons
            UpdateLabelText(this.mobjLabel1, this.mobjRadioButton1);
            UpdateLabelText(this.mobjLabel2, this.mobjRadioButton2);
        }

        private void mobjRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Updates label text, that indicates checked state of demonstrated RadioButton2.
            UpdateLabelText(this.mobjLabel2, this.mobjRadioButton2);
            mobjCheckBox1.Checked = mobjRadioButton1.Checked;
        }

        private void mobjRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Updates label text, that indicates checked state of demonstrated RadioButton1.
            UpdateLabelText(this.mobjLabel1, this.mobjRadioButton1);
            mobjCheckBox2.Checked = mobjRadioButton2.Checked;
        }

        /// <summary>
        /// Updates specified label text, that indicates state of defined RadioButton.
        /// </summary>
        /// <param name="label">label that represents checked state of passed RadioButton</param>
        /// <param name="radioButton">demonstrated RadioButton</param>
        private void UpdateLabelText(Label label, global::Gizmox.WebGUI.Forms.RadioButton radioButton)
        {
            label.Text = String.Format("{0} is {1}!", radioButton.Text, (radioButton.Checked ? "checked" : "unchecked"));
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
             //Changes RadioButton's state according to appropriate checkBox 
             mobjRadioButton1.Checked = mobjCheckBox1.Checked;
             //If current checkBox is checked, then uncheck another one
             if (mobjCheckBox1.Checked)
             {
                mobjCheckBox2.Checked = false;
             }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Changes RadioButton's state according to appropriate checkBox 
            mobjRadioButton2.Checked = mobjCheckBox2.Checked;
            //If current checkBox is checked, then uncheck another one
            if (mobjCheckBox2.Checked)
            {
                mobjCheckBox1.Checked = false;
            }
        }


    }
}