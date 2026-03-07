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

namespace CompanionKit.Controls.TrackBar.Programming
{
    public partial class ServerSideEventsPage : UserControl
    {
        public ServerSideEventsPage()
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

        private void ServerSideEventsPage_Load(object sender, EventArgs e)
        {
            // Set initial value for NumericUpDown 
            this.mobjValueTrackBarNumericUpDown.Value = this.mobjDemoTrackBar.Value;
        }

        
    }
}