using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.DomainUpDown.Programming
{
    public partial class AddItemsPage : UserControl
    {
        public AddItemsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            //Get text for added item
            string addedItemText = this.mobjNameAddedItemTextBox.Text;
            //Check whether text for added item isn't empty.
            if (string.IsNullOrEmpty(addedItemText))
            {
                MessageBox.Show("Please input text for added item!");
                return;
            }
            // Insert new item to DomainUpDown
            addedItemText = GetNewItemName(addedItemText);
            this.mobjDomainUpDown.Items.Add(addedItemText);
            this.mobjDomainUpDown.SelectedItem = addedItemText;
        }

        /// <summary>
        /// Gets name for added item. If user entered name is contained in the DomainUpDown, 
        /// then it will change with adds index.
        /// </summary>
        /// <param name="newItemName">User entered item name</param>
        /// <returns></returns>
        private string GetNewItemName(string newItemName)
        {
            string addedItemName = newItemName;
            int i = 1;
            while (this.mobjDomainUpDown.Items.Contains(addedItemName))
            {
                addedItemName = newItemName + i;
                ++i;
            }
            return addedItemName;
        }

        /// <summary>
        /// Handles the Load event of the AddItemsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AddItemsPage_Load(object sender, EventArgs e)
        {
            this.mobjDomainUpDown.SelectedIndex = 0;
        }
    }
}