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
    public partial class View3DPropertyPage : UserControl
    {
        public View3DPropertyPage()
        {
            InitializeComponent();
            // Setup chart and bind chart data
            InitializeChart();
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
            y.Title = "Percent Usage";
            y.Suffix = "%";
            // Setup chart
            mobjChart.Title = new Title("Usage share of operating systems, May 2011");
            mobjChart.AxisX = x;
            mobjChart.AxisY = y;
            // Create new data series for chart
            DataSeries ds = new DataSeries();
            // Setup dataseries
            ds.Name = "Operation Systems";
            ds.RenderAs = DisplayTypes.Column;
            ds.LabelEnabled = true;
            // Add points to data series
            ds.Add("Windows XP", 40.26);
            ds.Add("Windows 7", 27.49);
            ds.Add("Windows Vista", 13.95);
            ds.Add("Mac OS X", 7.12);
            ds.Add("iOS", 2.20);
            ds.Add("Linux", 1.82);
            // Add dataseries to chart data
            mobjChart.Data.Add(ds);
            // Create new data series for chart
            ds = new DataSeries();
            // Set dataseries
            ds.Name = "Percent Usage Apr 2011";
            ds.RenderAs = DisplayTypes.Line;
            ds.MarkerScale = 0.8;
            ds.ToolTipText = "Percent Usage, Apr 2011: #YValue";
            // Add points to data series
            DataPoint dp = new DataPoint();
            dp.YValue = 38.37;
            ds.Add(dp);

            dp = new DataPoint();
            dp.YValue = 29.19;
            ds.Add(dp);

            dp = new DataPoint();
            dp.YValue = 13.27;
            ds.Add(dp);

            dp = new DataPoint();
            dp.YValue = 7.54;
            ds.Add(dp);

            dp = new DataPoint();
            dp.YValue = 2.80;
            ds.Add(dp);

            dp = new DataPoint();
            dp.YValue = 1.10;
            ds.Add(dp);
            // Add dataseries to chart data
            mobjChart.Data.Add(ds);
            // Update chart
            mobjChart.Update();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjView3DCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjView3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Swith chart View3D property value
            mobjChart.View3D = mobjView3DCheckBox.Checked;
            // Update chart
            mobjChart.Update();
        }


    }
}