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

namespace CompanionKit.Controls.CheckedListBox.Features
{
    public partial class SelectionModesPage : UserControl
    {
        public SelectionModesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the SelectionModesPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SelectionModesPage_Load(object sender, EventArgs e)
        {
            // Fill up ComboBox with avalaible selection mode of the CheckedListBox.
            SelectionMode defaultSelectionMode = this.mobjCheckedListBox.SelectionMode;
            this.mobjSelectionModesComboBox.DataSource = Enum.GetValues(typeof(SelectionMode));
            this.mobjSelectionModesComboBox.SelectedItem = defaultSelectionMode;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjSelectionModesComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSelectionModesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionMode newSelectionMode = (SelectionMode)this.mobjSelectionModesComboBox.SelectedItem;
            this.mobjCheckedListBox.SelectionMode = newSelectionMode;
            switch (newSelectionMode)
            {
                case SelectionMode.None:
                    // Unchecked all items'CheckBoxes
                    foreach(int checkedItemIndex in this.mobjCheckedListBox.CheckedIndices)
                    {
                        this.mobjCheckedListBox.SetItemChecked(checkedItemIndex, false);
                    }
                    break;
            }
        }

        /// <summary>
        /// Handles the ItemCheck event of the mobjCheckedListBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
        private void mobjCheckedListBox_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {
            // unallow to check item if selection mode is none.
            if (this.mobjCheckedListBox.SelectionMode == SelectionMode.None 
                && objArgs.NewValue == CheckState.Checked)
            {
                this.mobjCheckedListBox.SetItemChecked(objArgs.Index, false);
                
            }
        }
    }
}
