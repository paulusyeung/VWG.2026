using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.TabControl.Appearance
{
    public partial class ExpandCollapsePage : UserControl
    {
        public ExpandCollapsePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Expand event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTabControl_Expand(object sender, EventArgs e)
        {
            SetLabelText("Expanded");
        }

        /// <summary>
        /// Handles the Collapse event of the mobjTabControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTabControl_Collapse(object sender, EventArgs e)
        {
            SetLabelText("Collapsed");
        }


        /// <summary>
        /// Sets the label text.
        /// </summary>
        /// <param name="strState">String value of state.</param>
        private void SetLabelText(string strState)
        {
            mobjStateLabel.Text = string.Format("Now TabControl is:{0}", strState);
        }
    }
}