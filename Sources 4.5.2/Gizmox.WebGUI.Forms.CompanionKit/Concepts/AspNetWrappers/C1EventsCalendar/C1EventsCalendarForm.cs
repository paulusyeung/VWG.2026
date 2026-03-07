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
    public partial class C1EventsCalendarForm : Form
    {
        public C1EventsCalendarForm()
        {
            InitializeComponent();
            //Set default theme for wrapper
            mobjWrapper.Theme = "aristo";
        }

        /// <summary>
        /// Fires when Themes is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ThemeChanged(object sender, EventArgs e)
        {
            //Change ViewType Label text to reflect current ViewType property
            mobjViewTypeLabel.Text = "ViewType: " + mobjWrapper.ViewType.ToString().ToLower();
            mobjViewTypeLabel.Update();
            //Define RadioButton sender
            RadioButton mobjRB = sender as RadioButton;
            //Set Theme property to an appropriate theme
            if (mobjRB.Checked)
                mobjWrapper.Theme = mobjRB.Text;
        }
    }
}