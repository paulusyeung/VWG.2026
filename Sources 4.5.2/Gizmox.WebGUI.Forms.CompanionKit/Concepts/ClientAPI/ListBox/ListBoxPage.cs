using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ListBox
{
    public partial class ListBoxPage : UserControl
    {
        public ListBoxPage()
        {
            InitializeComponent();
            
        }


        /// <summary>
        /// Handles the Click event of the mobjFillButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjFillButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("fillListBox");
        }

        /// <summary>
        /// Handles the Click event of the mobjClearButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjClearButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("clearListBox");
        }



    }
}