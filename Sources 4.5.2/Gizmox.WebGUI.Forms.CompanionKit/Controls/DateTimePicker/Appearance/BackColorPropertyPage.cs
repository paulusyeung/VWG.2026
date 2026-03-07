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
    public partial class BackColorPropertyPage : UserControl
    {
        public BackColorPropertyPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the page' UserControl
        /// </summary>
        private void BackColorPropertyPage_Load(object sender, EventArgs e)
        {
            
            Color defaultBackColor = this.mobjDemoDateTimePicker.BackColor;

            //Set DataSource as array of Colors for ComboBox with background colors.
            KnownColor[] knownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            Color[] colors = new Color[knownColors.Length];
            for (int i = 0; i < knownColors.Length; ++i)
            {
                colors[i] = Color.FromKnownColor(knownColors[i]);
            }
            this.mobjBackColorComboBox.DataSource = colors;
            this.mobjBackColorComboBox.ColorMember = "Name";
            this.mobjBackColorComboBox.DisplayMember = "Name";

            // Set default back color of the DataTimePicker in the ComboBox.
            this.mobjBackColorComboBox.SelectedItem = defaultBackColor;
            

        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the  ComboBox that contains color.
        /// Sets selected colors as background colors for DataTimePick
        /// </summary>
        private void mobjBackColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected colors as background colors for DataTimePicker
            this.mobjDemoDateTimePicker.BackColor = (Color)this.mobjBackColorComboBox.SelectedItem;
        }
    }
}