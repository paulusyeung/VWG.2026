using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    public partial class ResetPropertyPage : UserControl
    {
        public ResetPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Assigns control to PropertyGrid.SelectedObject according to selected comboBox's item
            switch (mobjComboBox.SelectedIndex)
            {
                //Button
                case 0: 
                    mobjPropertyGrid.SelectedObject = mobjButton;
                    break;
                //Panel
                case 1:
                    mobjPropertyGrid.SelectedObject = mobjPanel;
                    break;
            }
        }

        /// <summary>
        /// Handles the Load event of the ResetPropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ResetPropertyPage_Load(object sender, EventArgs e)
        {
            mobjComboBox.SelectedIndex = 0;
        }
    }
}