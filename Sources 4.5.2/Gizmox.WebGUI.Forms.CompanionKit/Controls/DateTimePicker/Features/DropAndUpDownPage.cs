using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DateTimePicker.Features
{
    public partial class DropAndUpDownPage : UserControl
    {
        public DropAndUpDownPage()
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
            //Handles all available options of DateTimePicker's buttons structure            
            switch (mobjComboBox.SelectedIndex)
            {
                //DropDown
                case 0:
                    mobjDateTimePicker.ShowUpDown = false;
                    mobjDateTimePicker.ShowBothEditButtons = false;
                    break;
                //UpDown
                case 1:
                    mobjDateTimePicker.ShowUpDown = true;
                    mobjDateTimePicker.ShowBothEditButtons = false;
                    break;
                //Both
                case 2:
                    mobjDateTimePicker.ShowUpDown = true;
                    mobjDateTimePicker.ShowBothEditButtons = true;
                    break;
            }
        }
    }

}