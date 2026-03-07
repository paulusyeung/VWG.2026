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

namespace CompanionKit.Controls.TrackBar.Functionality
{
    public partial class BoundsPage : UserControl
    {
        public BoundsPage()
        {
            InitializeComponent();

            // Set initial values for NumericUpDown and ToolTip.
            this.mobjMinBoundNumUpDown.Value = this.mobjDemoTrackBar.Minimum;
            this.mobjMaxBoundNumUpDown.Value = this.mobjDemoTrackBar.Maximum;
            this.mobjTrackBarToolTip.SetToolTip(this.mobjDemoTrackBar, string.Format("Value: {0}", this.mobjDemoTrackBar.Value));
        }
        /// <summary>
        /// Handles ValueChanged event NumericupDown that sets minimum value for 
        /// the demonstrated TrackBar. If value of the TrackBar is less than a 
        /// new minimum value, the value will be changed to a new minimum value.
        /// </summary>
        private void mobjMinBoundNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.mobjDemoTrackBar.Minimum = decimal.ToInt32(this.mobjMinBoundNumUpDown.Value);
            this.mobjMaxBoundNumUpDown.Minimum = this.mobjMinBoundNumUpDown.Value;
            if (this.mobjDemoTrackBar.Value < this.mobjDemoTrackBar.Minimum)
            {
                this.mobjDemoTrackBar.Value = this.mobjDemoTrackBar.Minimum;
            }
        }

        /// <summary>
        /// Handles ValueChanged event NumericupDown that sets maximum value for 
        /// the demonstrated TrackBar. If value of the TrackBar is more than a 
        /// new maximum value, the value will be changed to a new maximum value.
        /// </summary>
        private void mobjMaxBoundNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.mobjDemoTrackBar.Maximum = decimal.ToInt32(this.mobjMaxBoundNumUpDown.Value);
            this.mobjMinBoundNumUpDown.Maximum = this.mobjMaxBoundNumUpDown.Value;
            if (this.mobjDemoTrackBar.Value > this.mobjDemoTrackBar.Maximum)
            {
                this.mobjDemoTrackBar.Value = this.mobjDemoTrackBar.Maximum;
            }
        }

        /// <summary>
        /// Handles ValueChanged event of the TrackBar. 
        /// Changes text of the textBox to a new value of the TrackBar.
        /// </summary>
        private void mobjDemoTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.mobjTrackBarToolTip.SetToolTip(this.mobjDemoTrackBar, string.Format("Value: {0}", this.mobjDemoTrackBar.Value));
            this.mobjTextBox.Text = this.mobjDemoTrackBar.Value.ToString();
        }
    }
}