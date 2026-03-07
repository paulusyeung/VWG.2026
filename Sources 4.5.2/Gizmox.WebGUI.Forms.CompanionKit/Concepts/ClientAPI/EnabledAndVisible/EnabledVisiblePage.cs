using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.EnabledAndVisible
{
    public partial class EnabledVisiblePage : UserControl
    {
        public EnabledVisiblePage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the ClientCheckedChanged event of the mobjVisibleCheckBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjVisibleCheckBox_ClientCheckedChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("visibleChange");
        }


        /// <summary>
        /// Handles the ClientCheckedChanged event of the mobjEnabledCheckBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjEnabledCheckBox_ClientCheckedChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("enabledChange");
        }
    }
}