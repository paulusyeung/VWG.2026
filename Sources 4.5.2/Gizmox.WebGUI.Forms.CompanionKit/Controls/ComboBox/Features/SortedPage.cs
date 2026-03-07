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
    public partial class SortedPage : UserControl
    {
        public SortedPage()
        {
            InitializeComponent();

            //Set CheckBox Checked property value to false.
            this.mobjCheckBox.Checked = false;
            
			//Set initially state for controls which related from checked the ComboBox. 
            UpdateControlProperty();

        }
        /// <summary>
        /// Updates initially state for controls which related from checked the ComboBox. 
        /// </summary>
        private void UpdateControlProperty() {
            this.mobjComboBox.Sorted = this.mobjCheckBox.Checked;
            if (this.mobjCheckBox.Checked)
            {
                this.mobjLabel.Text = "Items are sorted";
            }
            else
            {
                this.mobjLabel.Text = "Items are not sorted";
                SetUnsortedArrayString();
            }
        }

        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Updates state for controls which related from checked the ComboBox.
            UpdateControlProperty();
        }

        /// <summary>
        /// Sets unsorted data to ComboBox.
        /// </summary>
        private void SetUnsortedArrayString()
        {
            this.mobjComboBox.Items.Clear();
            this.mobjComboBox.Items.AddRange(new object[] {
            "A item",
            "X item",
            "Y item",
            "I item",
            "J item",
            "K item",
            "L item",
            "M item",
            "N item",
            "O item",
            "B item",
            "C item",
            "T item",
            "U item",
            "V item",
            "D item",
            "E item",
            "F item",
            "G item",
            "P item",
            "Q item",
            "R item",
            "S item",
            "W item",
            "Z item"});
			this.mobjComboBox.SelectedIndex = 0;
        }
    }
}
