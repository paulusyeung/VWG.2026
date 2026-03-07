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

namespace CompanionKit.Controls.ListBox.Features
{
    public partial class SortedPage : UserControl
    {
        public SortedPage()
        {
            InitializeComponent();
            //Set CheckBox Checked property value to false.
            this.mobjIsSorted.Checked = false;
            //Set initially state for controls which related from checked the ComboBox. 
            UpdateControlProperty();
        }
        /// <summary>
        /// Updates initially state for controls which related from checked the ComboBox. 
        /// </summary>
        private void UpdateControlProperty()
        {
            this.mobjListBox.Sorted = this.mobjIsSorted.Checked;
            this.mobjLabel.Text = string.Format("The items are {0}", (this.mobjIsSorted.Checked ? "sorted alphabetically" : "not sorted"));
            if (!this.mobjListBox.Sorted)
            {
                SetUnsortedArrayString();
            }
        }

        /// <summary>
        /// Sets unsorted data to ListBox.
        /// </summary>
        private void SetUnsortedArrayString()
        {
            this.mobjListBox.Items.Clear();
            this.mobjListBox.Items.AddRange(new object[] {
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
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjIsSorted control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIsSorted_CheckedChanged(object sender, EventArgs e)
        {
            //Updates state for controls which related from checked the ComboBox.
            UpdateControlProperty();
        }
    }
}
