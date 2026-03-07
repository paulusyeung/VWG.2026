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
    public partial class C1ReportViewerForm : Form
    {
        public C1ReportViewerForm()
        {
            InitializeComponent();
            //Set default theme for wrapper
            mobjWrapper.Theme = "aristo";
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ThemeChanged(object sender, EventArgs e)
        {
            //Define RadioButton sender
            RadioButton mobjRB = sender as RadioButton;
            //Set Theme property to an appropriate theme
            if (mobjRB.Checked)
                mobjWrapper.Theme = mobjRB.Text;
        }
    }
}