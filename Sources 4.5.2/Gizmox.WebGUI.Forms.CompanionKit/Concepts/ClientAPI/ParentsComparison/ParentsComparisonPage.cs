using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ParentsComparison
{
    public partial class ParentsComparisonPage : UserControl
    {
        public ParentsComparisonPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("compareParents");
        }
    }
}