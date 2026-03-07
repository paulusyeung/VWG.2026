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

namespace CompanionKit.Controls.ListBox.Appearance
{
    public partial class CheckBoxAndRadioButtonsPage : UserControl
    {
        public CheckBoxAndRadioButtonsPage()
        {
            InitializeComponent();
            //Set initial Normal view for LitBox. ListBox' item will be displayed without RadioButton and CheckBox
            UpdateListBoxCaption();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxViewRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Change CheckBoxes property value to checked state of 'CheckBox' RadioButton.
            // If value is true, ListBox item will be displayed with CheckBox, 
            // otherwise it will be displayed without CheckBox
            this.mobjListBox.CheckBoxes = this.checkBoxViewRadioButton.Checked;
            UpdateListBoxCaption();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButtonViewRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioButtonViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Change RadioBoxes property value to checked state of 'RadioButton' RadioButton.
            // If value is true, ListBox item will be displayed with RadioButton, 
            // otherwise it will be displayed without RadioButton
            this.mobjListBox.RadioBoxes = this.radioButtonViewRadioButton.Checked;
            UpdateListBoxCaption();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the normalViewRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void normalViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBoxCaption();
        }

        /// <summary>
        /// Update text of the ListBox caption label according to the selected  item view type
        /// </summary>
        private void UpdateListBoxCaption()
        {
            string listBoxItemsViewType = "";
            if (this.checkBoxViewRadioButton.Checked)
            {
                listBoxItemsViewType = "checkbox ";
            }
            else if (this.radioButtonViewRadioButton.Checked)
            {
                listBoxItemsViewType = "radiobutton ";
            }

            this.mobjDescritionLabel.Text = string.Format("Listbox with {0}items:", listBoxItemsViewType);

        }

    }
}
