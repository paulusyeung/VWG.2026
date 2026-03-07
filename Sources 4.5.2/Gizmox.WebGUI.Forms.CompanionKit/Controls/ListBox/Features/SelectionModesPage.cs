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

namespace CompanionKit.Controls.ListBox.Features
{
    public partial class SelectionModesPage : UserControl
    {
        public SelectionModesPage()
        {
            InitializeComponent();

            //Fill ComboBox with SelectionMode values
            mobjModeCB.DataSource = Enum.GetValues(typeof(SelectionMode));
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjModeCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set SelectionMode
            mobjListBox.SelectionMode = (SelectionMode)mobjModeCB.SelectedItem;
        }
    }
}