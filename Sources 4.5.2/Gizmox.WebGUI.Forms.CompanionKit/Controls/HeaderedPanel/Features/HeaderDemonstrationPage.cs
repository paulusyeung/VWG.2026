using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.HeaderedPanel.Features
{
    public partial class HeaderDemonstrationPage : UserControl
    {
        public HeaderDemonstrationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjTextRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //If "Text" radioButton is checked - sets Text property
            if (mobjTextRadioButton.Checked)
            {
                mobjHeaderedPanel.Text = "Text";
            }
            //If unchecked - clears Text property
            else { mobjHeaderedPanel.Text = string.Empty; }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjTextIconRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextIconRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //If "Text + Icon" is checked - sets Text and Icon properties
            if (mobjTextIconRadioButton.Checked)
            {
                mobjHeaderedPanel.Text = "Text + Icon";
                mobjHeaderedPanel.Icon = "Images.32x32.Categorize.png";
            }
            //If unchecked - clears Text and Icon properties
            else { mobjHeaderedPanel.Text = string.Empty; mobjHeaderedPanel.Icon = null; }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBoxRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBoxRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //If "CheckBox" is checked - creates CheckBox control and assigns it to Header 
            if (mobjCheckBoxRadioButton.Checked)
            {
                Gizmox.WebGUI.Forms.CheckBox mobjCheckBox =  new Gizmox.WebGUI.Forms.CheckBox();
                mobjCheckBox.Dock = DockStyle.Right;
                mobjCheckBox.Text = "CheckBox";
                mobjHeaderedPanel.Header = mobjCheckBox;
            }
            //If unchecked - clears Header property
            else { mobjHeaderedPanel.Header = null; }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjButtonRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //If "Button" is checked - creates Button control and assigns it to Header 
            if (mobjButtonRadioButton.Checked)
            {
                Gizmox.WebGUI.Forms.Button mobjButton = new Gizmox.WebGUI.Forms.Button();
                mobjButton.Text = "Button";
                mobjHeaderedPanel.Header = mobjButton;
            }
            //If unchecked - clears Header property
            else { mobjHeaderedPanel.Header = null; }
        }
    }
}