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
    public partial class PerformStepPage : UserControl
    {
        public PerformStepPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void PerformStepPage_Load(object sender, EventArgs e)
        {
            // set initial step of the ProgressBar in the NumericUpDown that
            // change increment step of the ProgressBar
            this.mobjStepNumericUpDown.Value = this.mobjDemoProgressBar.Step;
        }

        /// <summary>
        /// Handle Tick event of the timer that increase value of the ProgressBars.
        /// </summary>
        private void incrementTimer_Tick(object sender, EventArgs e)
        {
            // Validate new value of the the demonstrated ProgressBar pay attention on the set range.
            if (this.mobjDemoProgressBar.Value + this.mobjDemoProgressBar.Step >= this.mobjDemoProgressBar.Maximum)
            {
                this.mobjDemoProgressBar.Value = this.mobjDemoProgressBar.Minimum;
            }

            // Increase value of the demonstrated ProgressBar on 
            // a value that is set in the ProgressBar.Step property.
            this.mobjDemoProgressBar.PerformStep();
        }

        /// <summary>
        /// Handles ValueChanged event of the ProgressBar control
        /// </summary>
        private void stepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Change step of the demonstrated Progressbar to new value of the NumericUpDown
            this.mobjDemoProgressBar.Step = decimal.ToInt16(this.mobjStepNumericUpDown.Value);
        }
    }
}