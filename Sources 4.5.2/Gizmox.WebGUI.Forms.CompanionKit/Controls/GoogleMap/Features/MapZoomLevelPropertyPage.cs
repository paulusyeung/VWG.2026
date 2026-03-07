using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.GoogleMap.Features
{
    public partial class MapZoomLevelPropertyPage : UserControl
    {
        public MapZoomLevelPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the MapZoomLevelChanged event of the GoogleMap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjGoogleMap_MapZoomLevelChanged(object sender, EventArgs e)
        {
            mobjNumericUpDown.Value = mobjGoogleMap.MapZoomLevel;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Toggles state of MapDoubleClickZooms control
            mobjGoogleMap.MapDoubleClickZooms = mobjCheckBox.Checked;
        }

        /// <summary>
        /// Handles the ValueChanged event of the NumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Sets MaoZoomLevel property and updates GoogleMap control
            mobjGoogleMap.MapZoomLevel = (int)mobjNumericUpDown.Value;
            mobjGoogleMap.Update();
        }

        /// <summary>
        /// Handles the Load event of the MapZoomLevelPropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MapZoomLevelPropertyPage_Load(object sender, EventArgs e)
        {
            //On load initialization
            mobjGoogleMap.MapDoubleClickZooms = false;
            mobjNumericUpDown.Value = mobjGoogleMap.MapZoomLevel;
        }
    }
}