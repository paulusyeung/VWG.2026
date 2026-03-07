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
    public partial class OrientationPage : UserControl
    {
        public OrientationPage()
        {
            InitializeComponent();
        }

        private void OrientationPage_Load(object sender, EventArgs e)
        {

            // Fill up the ComboBox with enabled Orientation values.
            Orientation mobjDefaultOrientationTrackBar = this.mobjDemoTrackBar.Orientation;
            this.mobjOrientationTrackBarComboBox.DataSource = Enum.GetValues(typeof(Orientation));
            this.mobjOrientationTrackBarComboBox.SelectedItem = mobjDefaultOrientationTrackBar;
            
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox.
        /// Changes orientation of the TrackBar according to selected value.
        /// </summary>
        private void mobjOrientationTrackBarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mobjDemoTrackBar.Orientation = (Orientation) this.mobjOrientationTrackBarComboBox.SelectedItem;
            switch (this.mobjDemoTrackBar.Orientation)
            {
                case Orientation.Horizontal:
                    this.mobjDemoTrackBar.Parent = this.mobjHorizontalPanel;
                    break;
                case Orientation.Vertical:
                    this.mobjDemoTrackBar.Parent = this.mobjVerticalPanel;
                    break;

            }
        }
    }
}