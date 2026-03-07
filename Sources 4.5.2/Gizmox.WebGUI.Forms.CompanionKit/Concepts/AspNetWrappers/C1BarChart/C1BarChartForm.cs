using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ComponentOneSampleAppsCS
{
    public partial class C1BarChartForm : Form
    {
        public C1BarChartForm()
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
            //Set Series Label to the new text value
            mobjWrapper.SeriesList[0].Label = mobjTextBox.Text;
            mobjWrapper.AspUpdate();
        }
    }
}