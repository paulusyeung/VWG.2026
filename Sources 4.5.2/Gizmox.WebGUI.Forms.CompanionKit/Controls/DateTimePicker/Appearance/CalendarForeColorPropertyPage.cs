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
    public partial class CalendarForeColorPropertyPage : UserControl
    {
        public CalendarForeColorPropertyPage()
        {
            InitializeComponent();
        }

        private void CalendarForeColorPropertyPage_Load(object sender, EventArgs e)
        {
            // TODO Changes this.demoDateTimePicker.ForeColor to this.demoDateTimePicker.CalendarForeColor after fix VWG-6977 issue
            Color defaultForeColor = this.mobjDemoDateTimePicker.ForeColor;

            // Set DataSource as array of Colors for ComboBox with foreground colors.
            KnownColor[] knownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            Color[] colors = new Color[knownColors.Length];
            for (int i = 0; i < knownColors.Length; ++i)
            {
                colors[i] = Color.FromKnownColor(knownColors[i]);
            }
            this.mobjForeColorComboBox.DataSource = colors;
            this.mobjForeColorComboBox.ColorMember = "Name";
            this.mobjForeColorComboBox.DisplayMember = "Name";

            // Set default calendar ForeColor of the DataTimePicker in the ComboBox.
            this.mobjForeColorComboBox.SelectedItem = defaultForeColor;
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox that contains of colors.
        /// Sets selected color as foreground colors for DataTimePicker
        /// </summary>
        private void mobjForeColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected color as foreground colors for DataTimePicker
            // TODO Changes this.demoDateTimePicker.ForeColor to this.demoDateTimePicker.CalendarForeColor after fix VWG-6977 issue
            this.mobjDemoDateTimePicker.ForeColor = (Color)this.mobjForeColorComboBox.SelectedItem;
        }
    }
}