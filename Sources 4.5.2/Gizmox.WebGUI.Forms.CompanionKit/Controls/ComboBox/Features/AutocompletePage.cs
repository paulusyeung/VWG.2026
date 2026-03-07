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

namespace CompanionKit.Controls.ComboBox.Features
{
    public partial class AutocompletePage : UserControl
    {
        public AutocompletePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjAutoCompleteComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAutoCompleteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets combobox's AutoComplete mode according to selected option
            switch (mobjAutoCompleteComboBox.SelectedIndex)
            { 
                //None
                case 0:
                    this.mobjComboBox.AutoCompleteMode = AutoCompleteMode.None;
                    break;
                //Suggest
                case 1:
                    this.mobjComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                    break;
                //Append
                case 2:
                    this.mobjComboBox.AutoCompleteMode = AutoCompleteMode.Append;
                    break;
                //SuggestAppend
                case 3:
                    this.mobjComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    break;
            }
        }
    }
}