#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.CompanionKit.Controls.Util;

#endregion

namespace CompanionKit.Controls.ComboBox.PopulatingData
{
    public partial class CollectionDataSourcePage : UserControl
    {
        public CollectionDataSourcePage()
        {
            InitializeComponent();
            //Set collection of customer as DataSource.
            this.mobjComboBox.DataSource = CustomerData.GetCustomers();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update text of represented TextBoxes with Value and Name of selected item.
            if (this.mobjComboBox.SelectedValue != null)
            {
                this.mobjValueTextBox.Text = this.mobjComboBox.SelectedValue.ToString();
            }
            this.mobjNameTextBox.Text = this.mobjComboBox.Text;
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjValueMemberTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjValueMemberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjValueMemberTextBox.Text))
            {
                try
                {
                    mobjComboBox.ValueMember = mobjValueMemberTextBox.Text;
                }
                catch (Exception ex) { mobjErrorProvider.SetError(mobjValueMemberTextBox, ex.Message); }
                finally { mobjValueMemberTextBox.Text = mobjComboBox.ValueMember; }
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjDataTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjDataTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjDataTextBox.Text))
            {
                foreach (Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer mobjItem in mobjComboBox.Items)
                {
                    if (mobjItem.FullName == mobjDataTextBox.Text)
                    {
                        mobjComboBox.SelectedItem = mobjItem;
                    }
                }
            }
        }
    }
}