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
    public partial class EditOverlayForm : Form
    {
        // Field to store overlay item passed
        private GoogleMapMarkerOverlay _overlay;
        // Create delegate
        public delegate void OverlayEdited();
        // Cteate handler to store method passed to the construcor
        public OverlayEdited OverlayEditedHandler;

        public EditOverlayForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overloaded form constructor
        /// </summary>
        /// <param name="overlays">Collection of GoogleMapOverlay objects</param>
        /// <param name="handler">Methos that will be invoked after overlay item is edited</param>
        public EditOverlayForm(GoogleMapMarkerOverlay overlay, OverlayEdited handler)
        {
            InitializeComponent();
            // Save overlay passed to local variable
            this._overlay = overlay;
            // Save method passed to local variable
            this.OverlayEditedHandler = handler;
        }

        /// <summary>
        /// Handles Click event for 'Save' button
        /// </summary>
        private void mobjSaveButton_Click(object sender, EventArgs e)
        {
            // Set local variable for validation result
            bool mblnIsValid = true;
            // Set local variables for coordinates
            double mdblLongitude = 0;
            double mdblLatitude = 0;
            // If set location by coordinates
            if (mobjCoordinatesRadioButton.Checked)
            {
                mdblLongitude = (double) this.mobjLongitudeNUD.Value;
                mdblLatitude = (double) this.mobjLatitudeNUD.Value;
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
                // If overlay located by coordinates
                if (mobjCoordinatesRadioButton.Checked)
                {
                    this._overlay.Address = "";
                    this._overlay.Location = new GoogleMapLocation(mdblLatitude, mdblLongitude);
                }
                // If overlay located by location name / address
                else
                {
                    this._overlay.Location = new GoogleMapLocation();
                    this._overlay.Address = mobjLocationNameAddressTextBox.Text;
                }
                // Set overlay description text
                this._overlay.WindowInfoContent = mobjDescriptionTextBox.Text;
                // Perform delegated method
                this.OverlayEditedHandler();
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
        /// Handles Load event for Form
        /// Loads Overlay item data for editing
        /// </summary>
        private void EditOverlayForm_Load(object sender, EventArgs e)
        {
            if (_overlay.Address == "")
            {
                mobjCoordinatesRadioButton.Checked = true;
                mobjLongitudeNUD.Value = (decimal)_overlay.MapLocation.Longitude;
                mobjLatitudeNUD.Value = (decimal)_overlay.MapLocation.Latitude;
            }
            else
            {
                mobjLocationNameAddressRadioButton.Checked = true;
                mobjLocationNameAddressTextBox.Text = _overlay.Address;
            }

            mobjDescriptionTextBox.Text = _overlay.WindowInfoContent;
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