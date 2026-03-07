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

namespace CompanionKit.Controls.CheckedListBox.Functionality
{
    public partial class AddItemPage : UserControl
    {
        public AddItemPage()
        {
            InitializeComponent();
            //Set maximum boundary as count of Items in CheckedListBox for 
            //NumericUpDown that used to define position of added item.
            this.mobjAddedItemPlace.Maximum = this.mobjCheckedListBox.Items.Count;
        }


        /// <summary>
        /// Gets name for added item. If user entered name is contained in CheckedListBox, then it will change with adds index.
        /// </summary>
        /// <param name="newItemName">User entered item name</param>
        /// <returns></returns>
        private string GetNewItemName(string newItemName)
        {
            string addedItemName = newItemName;
            int i = 1;
            while (this.mobjCheckedListBox.Items.Contains(addedItemName))
            {
                addedItemName = newItemName + i;
                ++i;
            }
            return addedItemName;
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Get text for added item
            string addedItemText = this.mobjAddedItemText.Text;
            //Check whether text for added item isn't empty.
            if (string.IsNullOrEmpty(addedItemText))
            {
                MessageBox.Show("Please input text for added item!");
            }
            //Get position of added item
            int addedItemPlace = decimal.ToInt32(this.mobjAddedItemPlace.Value);
            if (addedItemPlace > this.mobjCheckedListBox.Items.Count)
            {
                addedItemPlace = this.mobjCheckedListBox.Items.Count;
            }
            else if (addedItemPlace < 0)
            {
                addedItemPlace = 0;
            }

            //Insert new item to ListBox
            this.mobjCheckedListBox.Items.Insert(addedItemPlace, GetNewItemName(addedItemText));
            //Select added item
            this.mobjCheckedListBox.SelectedIndex = addedItemPlace;
            //Update maximum boundary for NumericUpDown
            this.mobjAddedItemPlace.Maximum = this.mobjCheckedListBox.Items.Count;
        }

    }
}