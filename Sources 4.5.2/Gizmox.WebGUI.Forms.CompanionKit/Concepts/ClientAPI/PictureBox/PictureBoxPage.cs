using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.PictureBox
{
    public partial class PictureBoxPage : UserControl
    {
        public PictureBoxPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("onSelectedChanged");
        }

    }
}