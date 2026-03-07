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
    public partial class CalendarFontProperty : UserControl
    {
        public CalendarFontProperty()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Handles Click  event of the Button.
        /// Opens FontDialog dialog box to change font of the DateTimePicker.
        /// </summary>
        private void mobjFontButton_Click(object sender, EventArgs e)
        {
            // Set initial font for the FontDialog dialog box 
            // as a font of the demonstrated DateTimePicker.
            // TODO Changes this.demoDateTimePicker.Font to this.demoDateTimePicker.CalendarFont after fix VWG-6977 issue
            this.mobjDemoFontDialog.Font = this.mobjDemoDateTimePicker.Font;
            this.mobjDemoFontDialog.ShowDialog();
        }

        /// <summary>
        /// Handles Apply event of the FontDialog dialog box.
        /// Sets new font for DataTimePicker and 
        /// updates label that represents Font of the DataTimePicker
        /// </summary>
        private void mobjDemoFontDialog_Apply(object sender, EventArgs e)
        {
            FontDialog fontDialog = sender as FontDialog;

            // Set new font for DataTimePicker and 
            // update label that represents Font of the DataTimePicker
            // TODO Changes this.demoDateTimePicker.Font to this.demoDateTimePicker.CalendarFont after fix VWG-6977 issue
            this.mobjDemoDateTimePicker.Font = this.mobjDemoFontDialog.Font;
            UpdateFontLabel(this.mobjDemoDateTimePicker.Font);
        }

        /// <summary>
        /// Handles Closed event of the FontDialog dialog box.
        /// Set new font for DataTimePicker and 
        /// update label that represents Font of the DataTimePicker
        /// </summary>
        private void mobjDemoFontDialog_Closed(object sender, EventArgs e)
        {
            FontDialog fontDialog = sender as FontDialog;
            if (fontDialog.DialogResult == DialogResult.OK)
            {
                // Set new font for DataTimePicker and 
                // update label that represents Font of the DataTimePicker
                // TODO Changes this.demoDateTimePicker.Font to this.demoDateTimePicker.CalendarFont after fix VWG-6977 issue
                this.mobjDemoDateTimePicker.Font = this.mobjDemoFontDialog.Font;
                UpdateFontLabel(this.mobjDemoDateTimePicker.Font);
            }
        }

        /// <summary>
        /// Updates label that represents font of the DateTimePicker
        /// </summary>
        /// <param name="dataTimerPickerFont">A new fon of the demonstrated DateTimePicker.</param>
        private void UpdateFontLabel(Font dateTimerPickerFont)
        {
            if (dateTimerPickerFont != null)
            {
                this.mobjFontLabel.Text = string.Format("Font: {0}, {1}pt", dateTimerPickerFont.Name, dateTimerPickerFont.Size);
            }
        }

        /// <summary>
        /// Handles Load event of the page' UserControl
        /// </summary>
        private void CalendarFontProperty_Load(object sender, EventArgs e)
        {
            // Set initial font of the DateTimePicker for the represented label
            UpdateFontLabel(this.mobjDemoDateTimePicker.Font);
        }
    }
}