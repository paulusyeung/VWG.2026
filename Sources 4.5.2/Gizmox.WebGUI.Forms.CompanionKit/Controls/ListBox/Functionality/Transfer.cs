#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;

#endregion

namespace CompanionKit.Controls.ListBox.Functionality
{
    public partial class Transfer : UserControl
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            //Add selected items of the left ListBox into the right ListBox
            this.mobjListBox2.Items.AddRange(this.mobjListBox1.SelectedItems);

            //Remove selected items from the left ListBox 
            string[] selectedItems = new string[this.mobjListBox1.SelectedItems.Count];
            this.mobjListBox1.SelectedItems.CopyTo(selectedItems, 0);
            foreach (object selectedItem in selectedItems)
            {
                this.mobjListBox1.Items.Remove(selectedItem);
            }
            
            UpdatedEnableStatusForTransferedButtons();
            
        }

        /// <summary>
        /// Handles the Click event of the btnAllToRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAllToRight_Click(object sender, EventArgs e)
        {
            //Add all items of the left ListBox into the right ListBox
            this.mobjListBox2.Items.AddRange(this.mobjListBox1.Items);
            //Remove all items from the left ListBox 
            this.mobjListBox1.Items.Clear();
            UpdatedEnableStatusForTransferedButtons();
        }

        /// <summary>
        /// Handles the Click event of the btnToLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnToLeft_Click(object sender, EventArgs e)
        {
            //Add selected items of the right ListBox into the left ListBox
            this.mobjListBox1.Items.AddRange(this.mobjListBox2.SelectedItems);
            
            //Remove selected items from the right ListBox 
            string[] selectedItems = new string[this.mobjListBox2.SelectedItems.Count];
            this.mobjListBox2.SelectedItems.CopyTo(selectedItems, 0);
            foreach (object selectedItem in selectedItems)
            {
                this.mobjListBox2.Items.Remove(selectedItem);
            }
            UpdatedEnableStatusForTransferedButtons();
        }

        /// <summary>
        /// Handles the Click event of the btnAllToLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAllToLeft_Click(object sender, EventArgs e)
        {
            //Add all items of the right ListBox into the left ListBox
            this.mobjListBox1.Items.AddRange(this.mobjListBox2.Items);
            //Remove all items from the left ListBox 
            this.mobjListBox2.Items.Clear();
            UpdatedEnableStatusForTransferedButtons();
        }

        /// <summary>
        /// Handles the Load event of the Transfer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Transfer_Load(object sender, EventArgs e)
        {
            //Set initial enable state for buttons that transfer 
            //item between left and right ListBoxes
            UpdatedEnableStatusForTransferedButtons();
        }

        /// <summary>
        /// Updates enable state for buttons that transfer item between left and right ListBoxes
        /// </summary>
        private void UpdatedEnableStatusForTransferedButtons()
        {
            if (mobjListBox1.Items.Count > 0 && !this.btnAllToRight.Enabled)
            {
                this.btnAllToRight.Enabled = true;
            }

            if (mobjListBox1.Items.Count < 1 && this.btnAllToRight.Enabled)
            {
                this.btnAllToRight.Enabled = false;
            }

            if (mobjListBox1.SelectedItems.Count > 0 && !this.btnToRight.Enabled)
            {
                this.btnToRight.Enabled = true;
            }

            if (mobjListBox1.SelectedItems.Count < 1 && this.btnToRight.Enabled)
            {
                this.btnToRight.Enabled = false;
            }

            if (mobjListBox2.Items.Count > 0 && !this.btnAllToLeft.Enabled)
            {
                this.btnAllToLeft.Enabled = true;
            }

            if (mobjListBox2.Items.Count < 1 && this.btnAllToLeft.Enabled)
            {
                this.btnAllToLeft.Enabled = false;
            }

            if (mobjListBox2.SelectedItems.Count > 0 && !this.btnToLeft.Enabled)
            {
                this.btnToLeft.Enabled = true;
            }

            if (mobjListBox2.SelectedItems.Count < 1 && this.btnToLeft.Enabled)
            {
                this.btnToLeft.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set initial enable state for buttons that transfer 
            //item between left and right ListBoxes
            UpdatedEnableStatusForTransferedButtons();

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set initial enable state for buttons that transfer 
            //item between left and right ListBoxes
            UpdatedEnableStatusForTransferedButtons();
        }
    }
}