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

namespace CompanionKit.Controls.Button.Functionality
{
    public partial class DropDownMenuPage : UserControl
    {
        public DropDownMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the menuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            MessageBox.Show(string.Format("Menu Item '{0}' has been clicked!", menuItem.Text));
        }
    }
}