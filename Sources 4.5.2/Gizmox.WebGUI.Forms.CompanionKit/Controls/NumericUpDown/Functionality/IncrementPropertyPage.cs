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
    public partial class IncrementPropertyPage : UserControl
    {
        public IncrementPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the IncrementPropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void IncrementPropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial value for the NumericUpDown that 
            // represents incremental for the demonstrated NumericUpDown.
            this.incrementalNumericUpDown.Value = this.demoNumericUpDown.Increment;
        }

        /// <summary>
        /// Handles the ValueChanged event of the incrementalNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void incrementalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Set selected incremental for the demonstrated NumericUpDown.
            this.demoNumericUpDown.Increment = this.incrementalNumericUpDown.Value;
        }
    }
}