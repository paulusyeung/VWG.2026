using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ToolTip.Features
{
    public partial class ToolTipTitlePage : UserControl
    {
        public ToolTipTitlePage()
        {
            InitializeComponent();
            // Save related controls into CheckBox.Tag container
            mobjTextBoxCheckBox.Tag = mobjTextBox;
            mobjListBoxCheckBox.Tag = mobjListBox;
            mobjLinkLabelCheckBox.Tag = mobjLinkLabel;
            mobjTrackBarCheckBox.Tag = mobjTrackBar;
            mobjDateTimePickerCheckbox.Tag = mobjDateTimePicker;
        }

        /// <summary>
        /// Handles CheckedChanged event for CheckBox controls
        /// </summary>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Get the CheckBox sender control
            Gizmox.WebGUI.Forms.CheckBox chbSender = (Gizmox.WebGUI.Forms.CheckBox)sender;
            // Get related control to CheckBox stored in tag container
            Control control = (Control)chbSender.Tag;
            // Save text entered to local variable
            string toolTipText = mobjInputTextBox.Text;
            // Set or remove tooltip text for control selected
            if (chbSender.Checked)
            {
                mobjToolTip.SetToolTip(control, toolTipText);
            }
            else
            {
                mobjToolTip.SetToolTip(control, string.Empty);
            }
        }
    }
}