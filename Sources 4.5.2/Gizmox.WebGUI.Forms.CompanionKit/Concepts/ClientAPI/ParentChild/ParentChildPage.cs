using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ParentChild
{
    public partial class ParentChildPage : UserControl
    {
        public ParentChildPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objToSecondPanelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objToSecondPanelButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("sendCheckedControls", objFirstParentPanel.ID, objSecondParentPanel.ID);
        }

        /// <summary>
        /// Handles the Click event of the objToFirstPanelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objToFirstPanelButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("sendCheckedControls", objSecondParentPanel.ID, objFirstParentPanel.ID);
        }

    }
}