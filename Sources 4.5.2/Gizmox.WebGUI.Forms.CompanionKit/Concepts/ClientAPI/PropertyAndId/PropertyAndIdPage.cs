using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.PropertyAndId
{
    public partial class PropertyAndIdPage : UserControl
    {
        public PropertyAndIdPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjPrintButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPrintButton_Click(object sender, EventArgs e)
        {
            //Invokes js handling function
            VWGClientContext.Current.Invoke("printProperties");
        }

        /// <summary>
        /// Handles the Click event of the mobjTestButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTestButton_Click(object sender, EventArgs e)
        {
            //Changes button's text on each click
            mobjTestButton.Text = mobjTestButton.Text == "Normal" ? "Flat" : "Normal";

            //Invokes js handling function
            VWGClientContext.Current.Invoke("changeStyle");
        }
    }
}