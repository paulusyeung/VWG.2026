using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms.CompanionKit.Controls.GoogleMap.Features;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Google;

namespace CompanionKit.Controls.GoogleMap.Features
{
    public partial class OverLaysPropertyPage : UserControl
    {
        public OverLaysPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event for Page
        /// </summary>
        private void OverLaysPropertyPage_Load(object sender, EventArgs e)
        {
            // Add overlays to GoogleMap
            mobjGoogleMap.MapOverlays.Add(new GoogleMapMarkerOverlay(37.819722, -122.478611, "Golden Gate Bridge"));
            mobjGoogleMap.MapOverlays.Add(new GoogleMapMarkerOverlay(37.814111, -122.478615, "Happy fisher"));
            // Load ListBox items
            LoadListBoxItems();
        }

        /// <summary>
        /// Loads all GoogleMap overlays to ListBox items collection
        /// </summary>
        private void LoadListBoxItems()
        {
            // Clear ListBox items collection
            mobjOverlaysLabel.Items.Clear();
            // Update map
            mobjGoogleMap.UpdateOverlays();

            foreach (GoogleMapMarkerOverlay overlay in mobjGoogleMap.MapOverlays)
            {
                // Add overlay as ListBox item
                mobjOverlaysLabel.Items.Add(overlay);
            }
        }        

        /// <summary>
        /// Handles Click event for 'Set Location' button
        /// </summary>
        private void mobjSetMapLocationButton_Click(object sender, EventArgs e)
        {
            // Set local variable for validation result
            bool mblnIsValid = true;
            // Set local variables for coordinates
            double mdblLongitude = 0;
            double mdblLatitude = 0;
            // If set location by coordinates
            if (mobjCoordinatesRadioButton.Checked)
            {
                mdblLongitude =(double) this.mobjLongitudeNUD.Value;
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
            // If all values entered are valid
            if (mblnIsValid)
            {
                // If locate by coordinates
                if (mobjCoordinatesRadioButton.Checked)
                {
                    // Set location for GoogleMap control
                    mobjGoogleMap.MapLocation = new GoogleMapLocation(mdblLatitude, mdblLongitude);
                }
                // If locate by location name / address
                else
                {
                    // Set location for GoogleMap control
                    mobjGoogleMap.MapAddress = mobjLocationNameAddressTextBox.Text;
                }
                // Update input controls values for location coordinates
                mobjLongitudeNUD.Value = Convert.ToDecimal(mobjGoogleMap.MapLocation.Longitude);
                mobjLatitudeNUD.Value = Convert.ToDecimal(mobjGoogleMap.MapLocation.Latitude);
            }
        }

        /// <summary>
        /// Handles Click event for 'Add' button
        /// </summary>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            // Create and open form for adding new overlay item
            NewOverlayForm mobjNewOverlayForm = new NewOverlayForm(this.mobjGoogleMap.MapOverlays, LoadListBoxItems);
            mobjNewOverlayForm.ShowDialog();            
        }

        /// <summary>
        /// Handles Click event for 'Edit' button
        /// </summary>
        private void mobjEditButton_Click(object sender, EventArgs e)
        {
            // If ListBox has selected item
            if (mobjOverlaysLabel.SelectedItem != null)
            {
                // Create and open form for editing overlay item
                EditOverlayForm mobjEditOverlayForm = new EditOverlayForm((GoogleMapMarkerOverlay)mobjOverlaysLabel.SelectedItem, LoadListBoxItems);
                mobjEditOverlayForm.ShowDialog();
            }            
        }

        /// <summary>
        /// Handles Click event for 'Remove' button
        /// </summary>
        private void mobjRemoveButton_Click(object sender, EventArgs e)
        {
            //  If ListBox has selected item
            if (mobjOverlaysLabel.SelectedItem != null)
            {
                // Remove selected overlay item
                mobjGoogleMap.MapOverlays.Remove((GoogleMapMarkerOverlay)mobjOverlaysLabel.SelectedItem);
                // Refresh ListBox control
                LoadListBoxItems();
            }            
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