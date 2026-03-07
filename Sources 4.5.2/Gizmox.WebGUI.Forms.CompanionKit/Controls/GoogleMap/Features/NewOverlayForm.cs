#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Google;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.GoogleMap.Features
{
    public partial class NewOverlayForm : Form
    {
        // Field to store overlay collection passed
        private GoogleMapOverlayCollection _overlays;
        // Create delegate
        public delegate void OverlayAdded();
        // Cteate handler to store method passed to the construcor
        public OverlayAdded OverlayAddedHandler;

        public NewOverlayForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overloaded form constructor
        /// </summary>
        /// <param name="overlays">Collection of GoogleMapOverlay objects</param>
        public NewOverlayForm(GoogleMapOverlayCollection overlays, OverlayAdded handler)
        {
            InitializeComponent();
            // Save overlays collection passed to local variable
            this._overlays = overlays;
            // Save method passed to local variable
            this.OverlayAddedHandler = handler;
        }

        /// <summary>
        /// Handles Click event for 'Add' button
        /// </summary>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            // Set local variable for validation result
            bool mblnIsValid = true;
            // Set local variables for coordinates
            double mdblLongitude = 0 ;
            double mdblLatitude = 0;
            // If set location by coordinates
            if (mobjCoordinatesRadioButton.Checked)
            {
                 mdblLongitude = (double)mobjLongitudeNUD.Value;
                 mdblLatitude = (double)mobjLatitudeNUD.Value;
            }
            // If set location by name
            else
            {
                // Validate location name entered
                if (mobjLocationNameAddressTextBox.Text == "")
                {
                    mobjErrorProvider.SetError(mobjLocationNameAddressTextBox, "Please enter location name");
                    mblnIsValid = false;
                }
                else
                {
                    mobjErrorProvider.SetError(mobjLocationNameAddressTextBox, "");
                }
            }
            // Validate description value entered
            if (mobjDescriptionTextBox.Text == "")
            {
                mobjErrorProvider.SetError(mobjDescriptionTextBox, "Please enter description");
                mblnIsValid = false;
            }
            else
            {
                mobjErrorProvider.SetError(mobjDescriptionTextBox, "");
            }
            // If all values entered are valid
            if (mblnIsValid)
            {
                if (mobjCoordinatesRadioButton.Checked)
                {
                    // Add new overlay item by coordinates
                    this._overlays.Add(new GoogleMapMarkerOverlay(mdblLatitude, mdblLongitude, mobjDescriptionTextBox.Text));
                }
                else
                {
                    // Add new overlay item by location name
                    GoogleMapMarkerOverlay newOverlay = new GoogleMapMarkerOverlay();
                    newOverlay.Address = mobjLocationNameAddressTextBox.Text;
                    newOverlay.WindowInfoContent = mobjDescriptionTextBox.Text;
                    this._overlays.Add(newOverlay);
                }
                // Perform delegated method
                this.OverlayAddedHandler();
                // Close window
                this.Close();
            }
        }

        /// <summary>
        /// Handles Click event for 'Cancel' button
        /// </summary>
        private void mobjCancelButton_Click(object sender, EventArgs e)
        {
            // Close window
            this.Close();
        }

        /// <summary>
        /// Handles CheckedChanged event for RadioButton controls
        /// Enables/disables input control accordind to
        /// RadioButton option selected
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mobjCoordinatesRadioButton.Checked)
            {
                mobjLocationNameAddressTextBox.Enabled = false;
                mobjLatitudeNUD.Enabled = true;
                mobjLongitudeNUD.Enabled = true;
            }
            else
            {
                mobjLocationNameAddressTextBox.Enabled = true;
                mobjLatitudeNUD.Enabled = false;
                mobjLongitudeNUD.Enabled = false;
            }
        }
    }
}