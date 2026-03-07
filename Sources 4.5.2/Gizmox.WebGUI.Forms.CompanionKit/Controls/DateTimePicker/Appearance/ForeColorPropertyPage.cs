using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Appearance
{
    public partial class ForeColorPropertyPage : UserControl
    {
        public ForeColorPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ForeColorPropertyPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ForeColorPropertyPage_Load(object sender, EventArgs e)
        {
            Color mobjDefaultForeColor = this.mobjDemoDateTimePicker.ForeColor;

            //Set DataSource as array of Colors for ComboBox with foreground colors.
            KnownColor[] arrKnownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            Color[] arrColors = new Color[arrKnownColors.Length];
            for (int i = 0; i < arrKnownColors.Length; ++i)
            {
                arrColors[i] = Color.FromKnownColor(arrKnownColors[i]);
            }
            this.mobjForeColorComboBox.DataSource = arrColors;
            this.mobjForeColorComboBox.ColorMember = "Name";
            this.mobjForeColorComboBox.DisplayMember = "Name";
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox that contains of colors.
        /// Sets selected color as foreground colors for DataTimePicker
        /// </summary>
        private void mobjForeColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected color as foreground colors for DataTimePicker
            this.mobjDemoDateTimePicker.ForeColor = (Color)this.mobjForeColorComboBox.SelectedItem;
        }
    }
}