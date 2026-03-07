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

namespace ComponentOneSampleAppsCS
{
    public partial class C1LineChartForm : Form
    {
        public C1LineChartForm()
        {
            InitializeComponent();
            //Set default theme for wrapper
            mobjWrapper.Theme = "aristo";
        }

        /// <summary>
        /// Handles the Click event of the mobjSetButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSetButton_Click(object sender, EventArgs e)
        {
            //Define new random value
            Random mobjRandom = new Random();
            //Set Y Data to random values
            mobjWrapper.SeriesList[0].Data.Y.Values[0].DoubleValue = 10 + mobjRandom.Next(40);
            mobjWrapper.SeriesList[0].Data.Y.Values[1].DoubleValue = 10 + mobjRandom.Next(40);
            mobjWrapper.SeriesList[0].Data.Y.Values[2].DoubleValue = 10 + mobjRandom.Next(40);
            mobjWrapper.SeriesList[0].Data.Y.Values[3].DoubleValue = 10 + mobjRandom.Next(40);
            mobjWrapper.SeriesList[0].Data.Y.Values[4].DoubleValue = 10 + mobjRandom.Next(40);
            //Update the wrapper
            mobjWrapper.AspUpdate();
        }
    }
}