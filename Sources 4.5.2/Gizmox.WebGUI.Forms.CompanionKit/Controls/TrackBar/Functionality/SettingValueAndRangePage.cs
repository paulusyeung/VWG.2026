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
    public partial class SettingValueAndRangePage : UserControl
    {
        public SettingValueAndRangePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles ValueChanged event of the TrackBar. 
        /// Changes value of the 'TrackBar value' NumericUpDown to a new value of the TrackBar.
        /// </summary>
        private void mobjDemoTrackBar_ValueChanged(object sender, EventArgs e)
        {
            this.mobjValueTrackBarNumericUpDown.Value = this.mobjDemoTrackBar.Value;
        }

        /// <summary>
        /// Handles ValueChanged event of the 'TrackBar value' NumericUpDown. 
        /// Changes value of the TrackBar to a new value of the 'TrackBar value' NumericUpDown.
        /// </summary>
        private void mobjValueTrackBarNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.mobjDemoTrackBar.Value = decimal.ToInt32(this.mobjValueTrackBarNumericUpDown.Value);
        }

        /// <summary>
        /// Handles ValueChanged event NumericupDown that sets minimum value for 
        /// the demonstrated TrackBar. If value of the TrackBar is less than a 
        /// new minimum value, the value will be changed to a new minimum value.
        /// </summary>
        private void mobjMinTrackBarNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.mobjMaxTrackBarNumericUpDown.Value < this.mobjMinTrackBarNumericUpDown.Value)
            {
                this.mobjMinTrackBarNumericUpDown.Value = this.mobjMaxTrackBarNumericUpDown.Value;
            }
            this.mobjDemoTrackBar.Minimum = decimal.ToInt32(this.mobjMinTrackBarNumericUpDown.Value);
            this.mobjValueTrackBarNumericUpDown.Minimum = this.mobjMinTrackBarNumericUpDown.Value;
            //if (this.demoTrackBar.Value < this.demoTrackBar.Minimum)
            //{
            //    this.demoTrackBar.Value = this.demoTrackBar.Minimum;
            //}
        }

        /// <summary>
        /// Handles ValueChanged event NumericupDown that sets maximum value for 
        /// the demonstrated TrackBar. If value of the TrackBar is more than a 
        /// new maximum value, the value will be changed to a new maximum value.
        /// </summary>
        private void mobjMaxTrackBarNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.mobjMaxTrackBarNumericUpDown.Value < this.mobjMinTrackBarNumericUpDown.Value)
            {
                this.mobjMaxTrackBarNumericUpDown.Value = this.mobjMinTrackBarNumericUpDown.Value;
            }
            this.mobjDemoTrackBar.Maximum = decimal.ToInt32(this.mobjMaxTrackBarNumericUpDown.Value);
            this.mobjValueTrackBarNumericUpDown.Maximum = this.mobjMaxTrackBarNumericUpDown.Value;
            //if (this.demoTrackBar.Value > this.demoTrackBar.Maximum)
            //{
            //    this.demoTrackBar.Value = this.demoTrackBar.Maximum;
            //}

        }

        private void SettingValueAndRangePage_Load(object sender, EventArgs e)
        {
            // Set initial values for NumericUpDown 
            this.mobjMinTrackBarNumericUpDown.Value = this.mobjDemoTrackBar.Minimum;
            this.mobjMaxTrackBarNumericUpDown.Value = this.mobjDemoTrackBar.Maximum;
            this.mobjValueTrackBarNumericUpDown.Value = this.mobjDemoTrackBar.Value;
            this.mobjValueTrackBarNumericUpDown.Minimum = this.mobjDemoTrackBar.Minimum;
            this.mobjValueTrackBarNumericUpDown.Maximum = this.mobjDemoTrackBar.Maximum;
        }
    }
}
