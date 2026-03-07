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

namespace CompanionKit.Controls.ListView.Programming
{
    public partial class ItemFormatingValidatingPage : UserControl
    {
        public ItemFormatingValidatingPage()
        {
            InitializeComponent();

            //Set DataSource as array of Colors.
            KnownColor[] knownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            Color[] colors = new Color[knownColors.Length];
            for (int i = 0; i < knownColors.Length; ++i)
            {
                colors[i] = Color.FromKnownColor(knownColors[i]);
            }
            this.mobjForeCB.DataSource = colors;
            this.mobjForeCB.ColorMember = "Name";
            this.mobjForeCB.DisplayMember = "Name";
            
            this.mobjBackCB.DataSource = colors.Clone();
            this.mobjBackCB.ColorMember = "Name";
            this.mobjBackCB.DisplayMember = "Name";
            
            //Show Grid Lines
            this.mobjListView.GridLines = true;

            //Fill up the ListView
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User1", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User2", "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User3", "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User4", "8-800-9874613" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User5", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User6", "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User7", "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User8", "8-800-9874613" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User9", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User10", "8-800-9513546" }));
           
            //Set default background and foreground colors
            foreach (ListViewItem objItem in this.mobjListView.Items)
            {
                objItem.ForeColor = Color.Black;
                objItem.BackColor = Color.White;
            }
        }


        /// <summary>
        /// Handles the ItemFormatting event of the mobjListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ListViewItemFormattingEventArgs"/> instance containing the event data.</param>
        private void mobjListView_ItemFormatting(object sender, ListViewItemFormattingEventArgs e)
        {
            //Define currently formatted item in ListView
            ListViewItem formattedItem = this.mobjListView.SelectedItem;
            if (formattedItem !=null)
            {
                //Change Result Text
                this.mobjResultLabel.Text = string.Format("Item #{0} has foreground {1} and background {2} colors.", formattedItem.Index, formattedItem.ForeColor.Name, formattedItem.BackColor.Name);
            }
            
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjForeCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjForeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change fore color of selected item
            if (this.mobjListView.SelectedItem != null)
            {
                this.mobjListView.SelectedItem.ForeColor = (Color)this.mobjForeCB.SelectedItem;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjBackCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjBackCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change back color of selected item
            if (this.mobjListView.SelectedItem != null)
            {
                this.mobjListView.SelectedItem.BackColor = (Color)this.mobjBackCB.SelectedItem;
            }
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change selected items in ComboBoxes
            if (this.mobjListView.SelectedItem != null && this.mobjForeCB.Items.Contains(this.mobjListView.SelectedItem.ForeColor))
            {
                this.mobjForeCB.SelectedItem = this.mobjListView.SelectedItem.ForeColor;
            }
            if (this.mobjListView.SelectedItem != null && this.mobjForeCB.Items.Contains(this.mobjListView.SelectedItem.BackColor))
            {
                this.mobjBackCB.SelectedItem = this.mobjListView.SelectedItem.BackColor;
            }
        }
    }
}