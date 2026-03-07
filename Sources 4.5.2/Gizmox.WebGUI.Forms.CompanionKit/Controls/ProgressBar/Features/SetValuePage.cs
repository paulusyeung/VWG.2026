using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ProgressBar.Features
{
    public partial class SetValuePage : UserControl
    {
        public SetValuePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles ValueChanged event of the TrackBar that changes of the ProgressBar.
        /// </summary>
        private void mobjChangevalueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // Set a new value of the TrackBar for the ProgressBar.
            this.mobjDemoProgressBar.Value = this.mobjChangevalueTrackBar.Value;
        }

        /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void SetValuePage_Load(object sender, EventArgs e)
        {
            // Set initial value for TrackBar that changes value for progress bar.
            this.mobjChangevalueTrackBar.Value = this.mobjDemoProgressBar.Value;
            this.mobjChangevalueTrackBar.Minimum = this.mobjDemoProgressBar.Minimum;
            this.mobjChangevalueTrackBar.Maximum = this.mobjDemoProgressBar.Maximum;
            this.mobjChangevalueTrackBar.TickFrequency = this.mobjDemoProgressBar.Step;
        }
    }
}