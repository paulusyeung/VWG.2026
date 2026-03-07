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

namespace CompanionKit.Controls.ListBox.Functionality
{
    public partial class AddItemPage : UserControl
    {
        public AddItemPage()
        {
            InitializeComponent();
            //Set maximum boundary as count of Items in ListBox for 
            //NumericUpDown that used to define position of added item.
            this.mobjNumericUpDown.Maximum = this.mobjListBox.Items.Count;
        }

        /// <summary>
        /// Handles the Click event of the mobjButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            //Get text for added item
            string addedItemText = this.mobjTextBox.Text;
            //Check whether text for added item isn't empty.
            if (string.IsNullOrEmpty(addedItemText))
            {
                MessageBox.Show("Please input text for added item!");
            }
            //Get position of added item
            int addedItemPlace = decimal.ToInt32(this.mobjNumericUpDown.Value);
            if (addedItemPlace > this.mobjListBox.Items.Count)
            {
                addedItemPlace = this.mobjListBox.Items.Count;
            }
            else if (addedItemPlace < 0)
            {
                addedItemPlace = 0;
            }

            //Insert new item to ListBox
            this.mobjListBox.Items.Insert(addedItemPlace, GetNewItemName(addedItemText));
            //Select added item
            this.mobjListBox.SelectedIndex = addedItemPlace;
            //Update maximum boundary for NumericUpDown
            this.mobjNumericUpDown.Maximum = this.mobjListBox.Items.Count;
        }

        /// <summary>
        /// Gets name for added item. If user entered name is contained in ListBox, then it will change with adds index.
        /// </summary>
        /// <param name="newItemName">User entered item name</param>
        /// <returns></returns>
        private string GetNewItemName(string newItemName)
        {
            string addedItemName = newItemName;
            int i = 1;
            while(this.mobjListBox.Items.Contains(addedItemName))
            {
                addedItemName = newItemName + i;
                ++i;
            }
            return addedItemName;
        }
    }
}