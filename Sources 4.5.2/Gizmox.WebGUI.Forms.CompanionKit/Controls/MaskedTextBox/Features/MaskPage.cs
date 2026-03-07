using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;


namespace CompanionKit.Controls.MaskedTextBox.Features
{
    public partial class MaskPage : UserControl
    {
        public MaskPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjMaskComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextMaskFormatPage.Masks selectedMask = (TextMaskFormatPage.Masks)this.mobjMaskComboBox.SelectedItem;
            
            switch (selectedMask)
            {
                case TextMaskFormatPage.Masks.Numeric:
                    this.mobjMaskedTextBox.Mask = "00000";
                    break;
                case TextMaskFormatPage.Masks.PhoneNumber:
                    this.mobjMaskedTextBox.Mask = "(999) 000-0000";
                    break;
                case TextMaskFormatPage.Masks.PhoneNumberNoAreaCode:
                    this.mobjMaskedTextBox.Mask = "000-0000";
                    break;
                case TextMaskFormatPage.Masks.ShortDate:
                    this.mobjMaskedTextBox.Mask = "00/00/0000";
                    break;
                case TextMaskFormatPage.Masks.ShortDateAndTimeUS:
                    this.mobjMaskedTextBox.Mask = "00/00/0000 90:00";
                    break;
                case TextMaskFormatPage.Masks.SocialSecurityNumber:
                    this.mobjMaskedTextBox.Mask = "000-00-0000";
                    break;
                case TextMaskFormatPage.Masks.TimeEuropean:
                    this.mobjMaskedTextBox.Mask = "00:00";
                    break;
                case TextMaskFormatPage.Masks.TimeUS:
                    this.mobjMaskedTextBox.Mask = "90:00";
                    break;
                case TextMaskFormatPage.Masks.ZipCode:
                    this.mobjMaskedTextBox.Mask = "00000-9999";
                    break;
            }
        }

        /// <summary>
        /// Handles the Load event of the MaskPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MaskPage_Load(object sender, EventArgs e)
        {
            this.mobjMaskComboBox.DataSource = Enum.GetValues(typeof(TextMaskFormatPage.Masks));
        }
    }
}