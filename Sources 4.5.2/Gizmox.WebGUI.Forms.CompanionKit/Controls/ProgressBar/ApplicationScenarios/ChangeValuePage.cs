using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ProgressBar.ApplicationScenarios
{
    public partial class ChangeValuePage : UserControl
    {

        private int mintNumber = 0;

        public ChangeValuePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle Tick event of the timer that increase value of the ProgressBars.
        /// </summary>
        private void mobjIncrementTimer_Tick(object sender, EventArgs e)
        {
            // Compute new value of the the demonstrated ProgressBars
            mintNumber += 1;
            if (mintNumber > 100)
            {
                mintNumber = 0;
            }

            // Set value for the demonstrated ProgressBars
            this.mobjDemoProgressBar.Value = mintNumber;
        }
    }
}