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

namespace CompanionKit.Controls.CheckedListBox.Functionality
{
    public partial class CheckOnClickPage : UserControl
    {
        public CheckOnClickPage()
        {
            InitializeComponent();
            //Set initial checked state for the CheckBox according to CheckOnClick property value of demonstrates CheckedListBox 
            this.mobjCheckOnClick.Checked = this.mobjCheckedListBox.CheckOnClick;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckOnClick control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckOnClick_CheckedChanged(object sender, EventArgs e)
        {
            //Change CheckOnClick property value of demonstrates CheckedListBox according to checked state of the CheckBox.
            this.mobjCheckedListBox.CheckOnClick = this.mobjCheckOnClick.Checked;
            // TODO: check after Beta 2 released, VWG-6446, remove call to Update()
			this.mobjCheckedListBox.Update();

        }
    }
}
