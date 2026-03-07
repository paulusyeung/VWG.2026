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

namespace CompanionKit.Controls.ComboBox.PopulatingData
{
    public partial class DatabaseDataSourcePage : UserControl
    {
        public DatabaseDataSourcePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mobjComboBox.SelectedValue != null)
            {
                //Update TextBox that represents selected of ComboBox
                this.mobjValueTextBox.Text = this.mobjComboBox.SelectedValue.ToString();
            }
            //Update TextBox that represents text of ComboBox
            this.mobjNameTextBox.Text = this.mobjComboBox.Text;
        }

        /// <summary>
        /// Handles the Load event of the DatabaseDataSourcePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DatabaseDataSourcePage_Load(object sender, EventArgs e)
        {
            //Fill up adapter with data form Customers table of DataBase
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);
        }

        /// <summary>
        /// Handles the TextChanged event of the comboBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_TextChanged(object sender, EventArgs e)
        {
            //Update TextBox that represents text of ComboBox
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
                foreach (System.Data.DataRowView mobjItem in mobjComboBox.Items)
                {
                    if (mobjItem.Row.ItemArray[2].ToString() == mobjDataTextBox.Text)
                    {
                        mobjComboBox.SelectedItem = mobjItem;
                    }
                }
            }
        }
    }
}