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
    public partial class MinimumPropertypage : UserControl
    {
        public MinimumPropertypage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the MinimumPropertypage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MinimumPropertypage_Load(object sender, EventArgs e)
        {
            // Set initial value for NumericUpDown that represents 
            // minimum for the demonstrated NumericUpDown.
            this.minimumNumericUpDown.Value = this.demoNumericUpDown.Minimum;
        }

        /// <summary>
        /// Handles the ValueChanged event of the minimumNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void minimumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.demoNumericUpDown.Minimum = this.minimumNumericUpDown.Value;
        }

    }
}