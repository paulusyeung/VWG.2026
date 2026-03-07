using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Common.Interfaces;

namespace CompanionKit.Concepts.ControlBehavior.Selectable
{
    public partial class SelectablePage : UserControl
    {
        public SelectablePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the SelectablePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SelectablePage_Click(object sender, System.EventArgs e)
        {
            mobjPanel_ControlSelected(this, new ControlsEventArgs(new Control[0]));
        }

        /// <summary>
        /// Handles the ControlSelected event of the mobjPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void mobjPanel_ControlSelected(object sender, ControlsEventArgs e)
        {
            //For each label inside of a panel
            foreach (Control mobjControl in mobjPanel.Controls)
            {
                mobjControl.BackColor = Color.Transparent;
            }
            
            int intLabelsCount = 0;

            foreach (Control objControl in e.Controls)
            {
                if (objControl.Tag != null)
                {
                    objControl.BackColor = Color.Lavender;
                    intLabelsCount++;
                }
            }

            string infoText = string.Empty;

            if (intLabelsCount == 0)
            {
                infoText = "Selected: None";
            }
            else if (intLabelsCount == 1)
            {
                infoText = "Selected: 1 item";
            }
            else
            {
                infoText = string.Format("Selected: {0} items", intLabelsCount);
            }

            //Show currently selected label
            mobjSelectedInfo.Text = infoText;
        }
    }
}