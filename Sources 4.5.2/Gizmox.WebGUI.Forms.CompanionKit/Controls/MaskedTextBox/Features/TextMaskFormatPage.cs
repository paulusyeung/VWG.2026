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
    public partial class TextMaskFormatPage : UserControl
    {
        public TextMaskFormatPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the TextMaskFormatPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TextMaskFormatPage_Load(object sender, EventArgs e)
        {
            this.mobjMaskValuesComboBox.DataSource = Enum.GetValues(typeof(Masks));
            this.mobjTextMaskFormatComboBox.DataSource = Enum.GetValues(typeof(Gizmox.WebGUI.Forms.MaskFormat));
            UpdateTextOfLabel();
        }

        public enum Masks
        {
            Numeric,
            PhoneNumber,
            PhoneNumberNoAreaCode,
            ShortDate,
            ShortDateAndTimeUS,
            SocialSecurityNumber,
            TimeEuropean,
            TimeUS,
            ZipCode
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjMaskValuesComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaskValuesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Masks selectedMask = (Masks)this.mobjMaskValuesComboBox.SelectedItem;
            
            switch (selectedMask)
            {
                case Masks.Numeric:
                    this.mobjMaskedTextBox.Mask = "00000";
                    break;
                case Masks.PhoneNumber:
                    this.mobjMaskedTextBox.Mask = "(999) 000-0000";
                    break;
                case Masks.PhoneNumberNoAreaCode:
                    this.mobjMaskedTextBox.Mask = "000-0000";
                    break;
                case Masks.ShortDate:
                    this.mobjMaskedTextBox.Mask = "00/00/0000";
                    break;
                case Masks.ShortDateAndTimeUS:
                    this.mobjMaskedTextBox.Mask = "00/00/0000 90:00";
                    break;
                case Masks.SocialSecurityNumber:
                    this.mobjMaskedTextBox.Mask = "000-00-0000";
                    break;
                case Masks.TimeEuropean:
                    this.mobjMaskedTextBox.Mask = "00:00";
                    break;
                case Masks.TimeUS:
                    this.mobjMaskedTextBox.Mask = "90:00";
                    break;
                case Masks.ZipCode:
                    this.mobjMaskedTextBox.Mask = "00000-9999";
                    break;
            }
            UpdateTextOfLabel();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjTextMaskFormatComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextMaskFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mobjMaskedTextBox.TextMaskFormat = (MaskFormat)this.mobjTextMaskFormatComboBox.SelectedItem;
            UpdateTextOfLabel();
        }

        /// <summary>
        /// Handles the TextChanged event of the mobjMaskedTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTextOfLabel();
        }

        /// <summary>
        /// Updates the text of label.
        /// </summary>
        private void UpdateTextOfLabel() 
        {
            this.mobjValueOfTextPropertyLabel.Text = string.Format("Value of MaskedTextBox Text property: {0}", this.mobjMaskedTextBox.Text);
        }

    }
}