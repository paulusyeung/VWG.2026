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

namespace CompanionKit.Controls.ComboBox.Appearance
{
    public partial class TextWithColorPage : UserControl
    {

        public TextWithColorPage()
        {
            InitializeComponent();
            //Set collection of customer as DataSource.
            this.mobjComboBox.DataSource = CustomerData.GetCustomers();
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjDisplayMemberTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjDisplayMemberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjDisplayMemberTextBox.Text))
            {
                try
                {
                    mobjComboBox.DisplayMember = mobjDisplayMemberTextBox.Text;
                }
                catch (Exception ex) { mobjErrorProvider.SetError(mobjDisplayMemberTextBox, ex.Message); }
                finally { mobjDisplayMemberTextBox.Text = mobjComboBox.DisplayMember; }
            }
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
        /// Handles the TextChanged event of the mobjColorMemberTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColorMemberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjColorMemberTextBox.Text))
            {
                try
                {
                    mobjComboBox.ColorMember = mobjColorMemberTextBox.Text;
                }
                catch (Exception ex) { mobjErrorProvider.SetError(mobjColorMemberTextBox, ex.Message); }
                finally { mobjColorMemberTextBox.Text = mobjComboBox.ColorMember; }
            }
        }
    }
}