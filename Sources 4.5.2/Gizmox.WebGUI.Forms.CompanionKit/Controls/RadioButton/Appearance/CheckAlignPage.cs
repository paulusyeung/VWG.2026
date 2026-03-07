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

namespace CompanionKit.Controls.RadioButton.Appearance
{
    public partial class CheckAlignPage : UserControl
    {
        public CheckAlignPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjRadioComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRadioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Toggles CheckAlign mode according to selected mobjRadioAlignmentComboBox's item
            switch (mobjRadioComboBox.SelectedItem.ToString())
            {
                case "TopLeft":
                    mobjRadioButton.CheckAlign = ContentAlignment.TopLeft;
                    break;
                case "TopCenter":
                    mobjRadioButton.CheckAlign = ContentAlignment.TopCenter;
                    break;
                case "TopRight":
                    mobjRadioButton.CheckAlign = ContentAlignment.TopRight;
                    break;
                case "MiddleLeft":
                    mobjRadioButton.CheckAlign = ContentAlignment.MiddleLeft;
                    break;
                case "MiddleCenter":
                    mobjRadioButton.CheckAlign = ContentAlignment.MiddleCenter;
                    break;
                case "MiddleRight":
                    mobjRadioButton.CheckAlign = ContentAlignment.MiddleRight;
                    break;
                case "BottomLeft":
                    mobjRadioButton.CheckAlign = ContentAlignment.BottomLeft;
                    break;
                case "BottomCenter":
                    mobjRadioButton.CheckAlign = ContentAlignment.BottomCenter;
                    break;
                case "BottomRight":
                    mobjRadioButton.CheckAlign = ContentAlignment.BottomRight;
                    break;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjTextComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Toggles TextAlign mode according to selected mobjTextAlignmentComboBox's item
            switch (mobjTextComboBox.SelectedItem.ToString())
            {
                case "TopLeft":
                    mobjRadioButton.TextAlign = ContentAlignment.TopLeft;
                    break;
                case "TopCenter":
                    mobjRadioButton.TextAlign = ContentAlignment.TopCenter;
                    break;
                case "TopRight":
                    mobjRadioButton.TextAlign = ContentAlignment.TopRight;
                    break;
                case "MiddleLeft":
                    mobjRadioButton.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case "MiddleCenter":
                    mobjRadioButton.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case "MiddleRight":
                    mobjRadioButton.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case "BottomLeft":
                    mobjRadioButton.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case "BottomCenter":
                    mobjRadioButton.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case "BottomRight":
                    mobjRadioButton.TextAlign = ContentAlignment.BottomRight;
                    break;
            }
        }

        /// <summary>
        /// Handles the Load event of the CheckAlignPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckAlignPage_Load(object sender, EventArgs e)
        {
            //Defines selected indexes of comboBoxes
            mobjTextComboBox.SelectedIndex = 0;
            mobjRadioComboBox.SelectedIndex = 3;
        }
    }
}