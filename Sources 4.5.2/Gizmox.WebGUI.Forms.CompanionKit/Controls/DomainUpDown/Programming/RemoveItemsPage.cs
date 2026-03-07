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
    public partial class RemoveItemsPage : UserControl
    {
        public RemoveItemsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the RemoveItemsPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RemoveItemsPage_Load(object sender, EventArgs e)
        {
            //Fill up DomainUpDown and ComboBox with string values
            for (int i = 0; i < 30; i++)
            {
                string nameItem = string.Format("Item{0}", i);
                this.mobjRemoveItemComboBox.Items.Add(nameItem);
                this.mobjDomainUpDown.Items.Add(nameItem);
            }

            // Limit upper bound of the NumericUpDown with number of items in DomainUpDown cintrol.
            this.mobjRemoveItemByPositionNumericUpDown.Maximum = this.mobjDomainUpDown.Items.Count - 1;

            this.mobjRemoveItemComboBox.SelectedIndex = 0;
            this.mobjDomainUpDown.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the mobjRemoveItemButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRemoveItemButton_Click(object sender, EventArgs e)
        {
            string removedItem = "";
            if (this.mobjRemoveItemByNameRadioButton.Checked)
            {
                // Check if ComboBox has selected item
                if (this.mobjRemoveItemComboBox.SelectedItem != null)
                {
                    // Remove item by name
                    removedItem = (string)this.mobjRemoveItemComboBox.SelectedItem;
                    this.mobjDomainUpDown.Items.Remove(removedItem);
                }
            }
            else
            {
                // Remove item by position
                int removeItemPosition = decimal.ToInt16(this.mobjRemoveItemByPositionNumericUpDown.Value);
                removedItem = (string)this.mobjDomainUpDown.Items[removeItemPosition];
                this.mobjDomainUpDown.Items.RemoveAt(removeItemPosition);
            }
            this.mobjRemoveItemComboBox.Items.Remove(removedItem);
            if (this.mobjDomainUpDown.Items.Count > 0)
            {
                this.mobjRemoveItemByPositionNumericUpDown.Maximum = this.mobjDomainUpDown.Items.Count - 1;
                this.mobjRemoveItemComboBox.SelectedIndex = 0;
                this.mobjRemoveItemComboBox.Text = (string)this.mobjRemoveItemComboBox.SelectedItem;
                this.mobjDomainUpDown.SelectedIndex = 0;
            }
            else
            {
                this.mobjRemoveItemComboBox.Enabled = false;
                this.mobjRemoveItemComboBox.Text = string.Empty;
                this.mobjRemoveItemByPositionNumericUpDown.Enabled = false;
                this.mobjRemoveItemButton.Enabled = false;
                this.mobjDomainUpDown.Text = "DomainUpDown is empty";
                this.mobjDomainUpDown.Enabled = false;

            }

        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjRemoveItemByNameRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRemoveItemByNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/Disable ComboBox that contain items of the DomainUpDown.
            this.mobjRemoveItemComboBox.Enabled = this.mobjRemoveItemByNameRadioButton.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjRemoveItemByPositionRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRemoveItemByPositionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Enable/Disable NumericUpDown that item indices of the DomainUpDown.
            this.mobjRemoveItemByPositionNumericUpDown.Enabled = this.mobjRemoveItemByPositionRadioButton.Checked;
        }
    }
}
