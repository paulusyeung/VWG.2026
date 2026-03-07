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
using Gizmox.WebGUI.Common.Resources;
using System.IO;
using System.Web;

#endregion

namespace CompanionKit.Controls.ComboBox.Appearance
{
    public partial class TextWithImagePage : UserControl
    {
        public TextWithImagePage()
        {
            InitializeComponent();
            //Get ResourceHandle for photo of customer.
            ResourceHandle photoResource = new ImageResourceHandle("32x32.Photo.png");
            //Set objects collection as DataSource for ComboBox.
            this.mobjComboBox.DataSource = CustomerData.GetCustomersWithImage(photoResource);
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
        /// Handles the TextChanged event of the mobjImageMemberTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjImageMemberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mobjImageMemberTextBox.Text))
            {
                try
                {
                    mobjComboBox.ImageMember = mobjImageMemberTextBox.Text;
                }
                catch (Exception ex) { mobjErrorProvider.SetError(mobjImageMemberTextBox, ex.Message); }
                finally { mobjImageMemberTextBox.Text = mobjComboBox.ImageMember; }
            }
        }
    }
}
