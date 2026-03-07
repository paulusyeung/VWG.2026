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
    public partial class MinimumPropertyPage : UserControl
    {
        public MinimumPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle Tick event of the timer that increase value of the ProgressBars.
        /// </summary>
        private void mobjIncrementTimer_Tick(object sender, EventArgs e)
        {
            // Validate new value of the the demonstrated ProgressBar pay attention on the set range.
            if (this.mobjDemoMin0ProgressBar.Value + this.mobjDemoMin0ProgressBar.Step >= this.mobjDemoMin0ProgressBar.Maximum)
            {
                this.mobjDemoMin0ProgressBar.Value = this.mobjDemoMin0ProgressBar.Minimum;
            }

            // Increase value of the demonstrated ProgressBar on 
            // a value that is set in the ProgressBar.Step property.
            this.mobjDemoMin0ProgressBar.PerformStep();

            // Compute new value of the the demonstrated ProgressBar
            if (this.mobjDemoMin75ProgressBar.Value + this.mobjDemoMin75ProgressBar.Step >= this.mobjDemoMin75ProgressBar.Maximum)
            {
                this.mobjDemoMin75ProgressBar.Value = this.mobjDemoMin75ProgressBar.Minimum;
            }

            // Increase value of the demonstrated ProgressBar on 
            // a value that is set in the ProgressBar.Step property.
            this.mobjDemoMin75ProgressBar.PerformStep();
        }
    }
}