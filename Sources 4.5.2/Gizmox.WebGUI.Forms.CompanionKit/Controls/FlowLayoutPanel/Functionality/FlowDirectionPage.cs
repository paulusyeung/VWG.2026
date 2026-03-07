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

namespace CompanionKit.Controls.FlowLayoutPanel.Functionality
{
    public partial class FlowDirectionPage : UserControl
    {
        public FlowDirectionPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjFlowDirectionComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjFlowDirectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mobjFlowDirectionComboBox.SelectedIndex)
            {
                case 0:
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight; 
                    break;
                case 1:
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                    break;
                case 2:
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
                    break;
                case 3:
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.BottomUp;
                    break;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjWrapCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjWrapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mobjFlowLayoutPanel.WrapContents = mobjWrapCheckBox.Checked;
        }

        /// <summary>
        /// Handles the Load event of the FlowDirectÂionPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FlowDirectionPage_Load(object sender, EventArgs e)
        {
            mobjFlowDirectionComboBox.SelectedIndex = 0;
            mobjWrapCheckBox.Checked = mobjFlowLayoutPanel.WrapContents;
        }
    }
}