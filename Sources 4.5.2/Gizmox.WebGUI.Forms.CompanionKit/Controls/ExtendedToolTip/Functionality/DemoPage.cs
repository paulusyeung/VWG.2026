using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ExtendedToolTip.Functionality
{
    public partial class DemoPage : UserControl
    {
        public DemoPage()
        {
            InitializeComponent();
            
            //Set ExtendedToolTip as default
            SetExtendedToolTip(mobjContentText.Text);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjIsExtended control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIsExtended_CheckedChanged(object sender, EventArgs e)
        {
            //If ToolTip should be simple
            if (!mobjIsExtended.Checked)
            {
                mobjExtendedToolTip.SetToolTipTemplateName(mobjButton, null);
                mobjExtendedToolTip.SetToolTip(mobjButton, "Simple ToolTip Text");
            }
            else
                SetExtendedToolTip(mobjContentText.Text);
        }

        /// <summary>
        /// Sets the extended tool tip.
        /// </summary>
        private void SetExtendedToolTip(string objText)
        {
            //Set extendedToolTip for button with Header and Content
            mobjExtendedToolTip.SetToolTipTemplateName(mobjButton, "Default");
            mobjExtendedToolTip.SetHeader(mobjButton, "<b>Bold Header</b>");
            mobjExtendedToolTip.SetContent(mobjButton, "<div  style=\"width:200px; height:150px; border:1px solid #ccc; background:#B3D4C4\">" + objText + "</div>");
        }

        /// <summary>
        /// Handles the Click event of the mobjSetButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSetButton_Click(object sender, EventArgs e)
        {
            //If ToolTip should be extended
            if (mobjIsExtended.Checked)
                SetExtendedToolTip(mobjContentText.Text);
        }
    }
}