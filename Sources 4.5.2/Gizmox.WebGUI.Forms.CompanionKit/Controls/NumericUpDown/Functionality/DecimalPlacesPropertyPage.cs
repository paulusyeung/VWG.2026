using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.NumericUpDown.Functionality
{
    public partial class DecimalPlacesPropertyPage : UserControl
    {
        public DecimalPlacesPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the DecimalPlacesPropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DecimalPlacesPropertyPage_Load(object sender, EventArgs e)
        {
            // Set initial current value for NumericUpDown that 
            // represents decimal places for demonstrated NumericUpDown.
            this.decimalPlacesNumericUpDown.Value = this.demoNumericUpDown.DecimalPlaces;
        }

        /// <summary>
        /// Handles the ValueChanged event of the decimalPlacesNumericUpDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void decimalPlacesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int decimalPlaces = decimal.ToInt16(this.decimalPlacesNumericUpDown.Value);
            this.demoNumericUpDown.DecimalPlaces = decimalPlaces;
            // Set incremental value for demonstrated NumericUpDown
            this.demoNumericUpDown.Increment = (decimal)(1.0/Math.Pow(10, decimalPlaces));
        }

    }
}