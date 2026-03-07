using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ProgressBar.Functionality
{
    public partial class IncrementPage : UserControl
    {
        public IncrementPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the button that increments value of the ProgressBar.
        /// </summary>
        private void mobjIncrementButton_Click(object sender, EventArgs e)
        {
            if (this.mobjDemoProgressBar.Value == this.mobjDemoProgressBar.Maximum)
            {
                this.mobjDemoProgressBar.Value = 0;
            }
            // Compute step of increasing ProgressBar value.
            int mintStep = decimal.ToInt16(this.mobjStepProgressBarNumericUpDown.Value);
            if (this.mobjDemoProgressBar.Value + mintStep > this.mobjDemoProgressBar.Maximum)
            {
                mintStep = this.mobjDemoProgressBar.Maximum - this.mobjDemoProgressBar.Value;
            }
            // Increment value of the demonstrated ProgressBar.
            this.mobjDemoProgressBar.Increment(mintStep);
        }

    }
}