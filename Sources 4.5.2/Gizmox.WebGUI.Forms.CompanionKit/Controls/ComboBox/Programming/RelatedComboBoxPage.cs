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

namespace CompanionKit.Controls.ComboBox.Programming
{
    public partial class RelatedComboBoxPage : UserControl
    {
        public RelatedComboBoxPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the RelatedComboBoxPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RelatedComboBoxPage_Load(object sender, EventArgs e)
        {
            //Fill up ComboBoxes' adapters with data form according tables of DataBase
            this.customersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);
            this.ordersTableAdapter.Fill(this.mobjNorthwindDataSet.Orders);
            this.order_DetailsTableAdapter.Fill(this.mobjNorthwindDataSet.Order_Details);
            this.mobjPricesTextBox.Validator = TextBoxValidation.FloatValidator;
            this.mobjIDTextBox.Validator = TextBoxValidation.IntegerValidator;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Remove Filter from 'Orders' DataSources.
            this.mobjSecondBindingSource.RemoveFilter();
            if (this.mobjCustomerComboBox.SelectedValue != null)
            {
                //Set Filter for 'Orders' DataSources that it contains orders only of selected customer.
                this.mobjSecondBindingSource.Filter = string.Format("CustomerID='{0}'", this.mobjCustomerComboBox.SelectedValue.ToString());
            }
        }
        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Remove Filter from 'Order Details' DataSources.
            this.mobjThirdBindingSource.RemoveFilter();
            if (this.mobjIDComboBox.SelectedValue != null)
            {
                //Set Filter for 'Order Details' DataSources that it contains records only of selected customer order.
                this.mobjThirdBindingSource.Filter = string.Format("OrderID='{0}'", this.mobjIDComboBox.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjCustomersTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCustomersTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjCustomersTextBox.Text))
            {
                foreach (System.Data.DataRowView mobjItem in mobjCustomerComboBox.Items)
                {
                    if (mobjItem.Row.ItemArray[2].ToString() == mobjCustomersTextBox.Text)
                    {
                        mobjCustomerComboBox.SelectedItem = mobjItem;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjIDTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjIDTextBox.Text))
            {
                foreach (System.Data.DataRowView mobjItem in mobjIDComboBox.Items)
                {
                    if (mobjItem.Row.ItemArray[0].ToString() == mobjIDTextBox.Text)
                    {
                        mobjIDComboBox.SelectedItem = mobjItem;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjPricesTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPricesTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjPricesTextBox.Text))
            {
                foreach (System.Data.DataRowView mobjItem in mobjPriceComboBox.Items)
                {
                    if (mobjItem.Row.ItemArray[2].ToString() == mobjPricesTextBox.Text)
                    {
                        mobjPriceComboBox.SelectedItem = mobjItem;
                    }
                }
            }
        }
    }
}