using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ComboBox.Appearance
{
    public partial class DropDownWidthPage : UserControl
    {
        public DropDownWidthPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the DropDownWidthPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DropDownWidthPage_Load(object sender, EventArgs e)
        {
            //Nuds value initialization
            mobjNumericUpDown.Value = mobjComboBox.DropDownWidth;
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Sets DropDownWidth using NUD's value
            mobjComboBox.DropDownWidth = (int)mobjNumericUpDown.Value;
        }
    }
}