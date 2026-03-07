using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Charts;

namespace CompanionKit.Controls.Chart.Features
{
    public partial class ThemePropertyPage : UserControl
    {
        public ThemePropertyPage()
        {
            InitializeComponent();
            // Set chart and bind chart data
            InitializeChart();
            // Fill ComboBox items collection with ThemeTypes enum values
            mobjThemesComboBox.DataSource = Enum.GetValues(typeof(ThemeTypes));
            // Set selected item for ComboBox control
            mobjThemesComboBox.SelectedItem = mobjChart.Theme;
        }

        /// <summary>
        /// Setups the chart and binds chart data
        /// </summary>
        private void InitializeChart()
        {
            // Set theme for chart
            mobjChart.Theme = ThemeTypes.Theme1;
            // Create X axis
            AxisX x = new AxisX();
            x.Title = "OS Name";
            // Create Y axis
            AxisY y = new AxisY();
            y.Title = "U.S. Smartphone Market Share";
            y.Suffix = "%";
            // Setup chart
            mobjChart.Title = new Title("U.S. Smartphone Market Share, May 2011");
            mobjChart.AxisX = x;
            mobjChart.AxisY = y;
            // Create new data series for chart
            DataSeries ds = new DataSeries();
            // Setup dataseries
            ds.Name = "Percent usage";
            ds.RenderAs = DisplayTypes.Pie;
            ds.MarkerScale = 0.8;
            ds.ToolTipText = "Percent usage: #YValue";
            // Add points to data series
            ds.Add("Android OS", 36);
            ds.Add("Apple iOS", 26);
            ds.Add("RIM BlackBerry OS", 23);
            ds.Add("Windows Mobile", 9);
            ds.Add("HP WebOS", 2);
            ds.Add("Symbian OS", 2);
            ds.Add("Windows Phone 7", 1);
            ds.Add("Palm OS", 1);
            // Add dataseries to chart data
            mobjChart.Data.Add(ds);
            // Update chart
            mobjChart.Update();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjThemesComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjThemesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set theme for chart from combobox selected item
            mobjChart.Theme = (ThemeTypes)mobjThemesComboBox.SelectedItem;
            // Update chart
            mobjChart.Update();
        }
    }
}