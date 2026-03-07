using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ClientCheckedState
{
    public partial class ClientCheckedPage : UserControl
    {
        public ClientCheckedPage()
        {
            InitializeComponent();           
        }

        /// <summary>
        /// Handles the ClientCheckedChanged event of the testCheckBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void testCheckBox_ClientCheckedChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            //Invoking js function to represent Checked state on a label.
            objArgs.Context.Invoke("setLabelText");
        }
    }
}