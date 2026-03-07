using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.NumericUpDown.Programming
{
    public partial class NumericValuesPage : UserControl
    {
        public NumericValuesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ValueChanged event of the demoNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void demoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Update text of label that represents current value of the demonstrated NumericUpDown
            this.currentValueLabel.Text = string.Format("Current value - {0}", this.demoNumericUpDown.Value.ToString());
        }

        /// <summary>
        /// Handles the Load event of the NumericValuesPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void NumericValuesPage_Load(object sender, EventArgs e)
        {
            // Update text of label that represents current value of the demonstrated NumericUpDown
            this.currentValueLabel.Text = string.Format("Current value - {0}", this.demoNumericUpDown.Value.ToString());
        }
    }
}