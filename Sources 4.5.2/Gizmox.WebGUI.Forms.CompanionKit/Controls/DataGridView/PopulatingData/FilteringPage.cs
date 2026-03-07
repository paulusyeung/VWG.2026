using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DataGridView.PopulatingData
{
    public partial class FilteringPage : UserControl
    {
        public FilteringPage()
        {
            InitializeComponent();
            //Fill up table adapter with data from table
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjFilterHeadersRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjFilterHeadersRB_CheckedChanged(object sender, EventArgs e)
        {
            //Clear all DGV filters
            mobjDGV.ClearAllFilters();

            //Show or hide filter row, MaxFilterOptions label and NumericUpDown
            mobjDGV.ShowFilterRow = mobjFilterRowRB.Checked;
            mobjMaxFilterLbl.Visible = mobjFilterRowRB.Checked;
            mobjMaxFilterNUD.Visible = mobjFilterRowRB.Checked;

            //If Filters in headers are chosen
            if (mobjFilterHeadersRB.Checked)
            {
                //Define MaxFilterOptions value
                mobjDGV.MaxFilterOptions = 1000;

                //Create filters in headers - simple for three columns and custom for one 'Region' column
                HeaderFilterInfo CustomerIDInfo = new HeaderFilterInfo("CustomerID", false);
                mobjDGV.HeadersFilterInfo.Add(CustomerIDInfo);
                HeaderFilterInfo CompanyNameInfo = new HeaderFilterInfo("CompanyName", false);
                mobjDGV.HeadersFilterInfo.Add(CompanyNameInfo);
                HeaderFilterInfo ContactNameInfo = new HeaderFilterInfo("ContactName", false);
                mobjDGV.HeadersFilterInfo.Add(ContactNameInfo);
                HeaderFilterInfo RegionInfo = new HeaderFilterInfo("Region", true);
                mobjDGV.HeadersFilterInfo.Add(RegionInfo);

                //Define Info Label text
                mobjInfoLabel.Text = "Filter values by column using filters in headers of first 3 columns. Click custom filter in header of 'Region' column and then 'YES' to clear all filters in DataGridView (CustomHeaderFilterClicked event is fired).";

            }
            //If Filter row is chosen
            else
            {
                //Define MaxFilterOptions value
                mobjDGV.MaxFilterOptions = Convert.ToInt32(mobjMaxFilterNUD.Value);
                //Clear filters in headers
                mobjDGV.HeadersFilterInfo.Clear();
                //Define Info Label text
                mobjInfoLabel.Text = "Use FilterRow to filter values by column in DataGridView.";
            }
        }

        /// <summary>
        /// Handles the CustomHeaderFilterClicked event of the mobjDGV control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="CustomFilterApplyingEventArgs"/> instance containing the event data.</param>
        private void mobjDGV_CustomHeaderFilterClicked(object objSender, CustomFilterApplyingEventArgs objArgs)
        {
            //Show Message if Custom filter in header is clicked
            MessageBox.Show("Clear all filters?", "Confirm", MessageBoxButtons.YesNo, message_Closed);
        }

        /// <summary>
        /// Handles the Closed event of the message control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void message_Closed(object sender, EventArgs e)
        {
            //If user confirms clearing all filters
            if (((Gizmox.WebGUI.Forms.Form)sender).DialogResult == DialogResult.Yes)
            {
                mobjDGV.ClearAllFilters();
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjMaxFilterNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaxFilterNUD_ValueChanged(object sender, EventArgs e)
        {
            //Define MaxFilterOptions value
            mobjDGV.MaxFilterOptions = Convert.ToInt32(mobjMaxFilterNUD.Value);
        }
    }
}