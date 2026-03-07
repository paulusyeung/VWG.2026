using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.NumericUpDown.Functionality
{
    public partial class MaximumPropertyPage : UserControl
    {
        public MaximumPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the MaximumPropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MaximumPropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial value for NumericUpDown that represents 
            // maximum for the demonstrated NumericUpDown.
            this.maximumNumericUpDown.Value = this.demoNumericUpDown.Maximum;
        }

        /// <summary>
        /// Handles the ValueChanged event of the maximumNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void maximumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.demoNumericUpDown.Maximum = this.maximumNumericUpDown.Value;
        }
    }
}