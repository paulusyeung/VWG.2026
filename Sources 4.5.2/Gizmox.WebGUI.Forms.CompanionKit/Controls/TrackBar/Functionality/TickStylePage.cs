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
    public partial class TickStylePage : UserControl
    {
        public TickStylePage()
        {
            InitializeComponent();
        }

        private void TickStylePage_Load(object sender, EventArgs e)
        {
            // Fill up the ComboBox with enabled TickStyle values.
            TickStyle defaultTrackBarTickStyle = this.mobjDemoTrackBar.TickStyle;
            this.mobjTickStyleComboBox.DataSource = Enum.GetValues(typeof(TickStyle));
            this.mobjTickStyleComboBox.SelectedItem = defaultTrackBarTickStyle;
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox.
        /// Changes tick style of the TrackBar according to selected value.
        /// </summary>
        private void mobjTickStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mobjDemoTrackBar.TickStyle = (TickStyle)this.mobjTickStyleComboBox.SelectedItem;
        }
    }
}