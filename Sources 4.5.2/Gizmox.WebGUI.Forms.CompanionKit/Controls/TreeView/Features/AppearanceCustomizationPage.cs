using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.TreeView.Features
{
    public partial class AppearanceCustomizationPage : UserControl
    {
        public AppearanceCustomizationPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the CheckedChanged event of the mobjLinesCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Changes ShowLines property according to CheckBox state
            mobjTreeView.ShowLines = mobjLinesCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjPlusMinusCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPlusMinusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Changes ShowPlusMinus property according to CheckBox state
            mobjTreeView.ShowPlusMinus = mobjPlusMinusCheckBox.Checked;
        }
    }
}