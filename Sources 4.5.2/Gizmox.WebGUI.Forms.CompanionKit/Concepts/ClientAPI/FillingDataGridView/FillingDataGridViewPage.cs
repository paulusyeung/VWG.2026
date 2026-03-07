using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.FillingDataGridView
{
    public partial class FillingDataGridViewPage : UserControl
    {
        public FillingDataGridViewPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control by invoking js-function, which fills DGV
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void objButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("fillGrid");
        }
    }
}