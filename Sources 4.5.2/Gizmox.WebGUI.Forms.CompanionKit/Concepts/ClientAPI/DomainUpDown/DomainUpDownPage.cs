using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.DomainUpDown
{
    public partial class DomainUpDownPage : UserControl
    {
        public DomainUpDownPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ClientSelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjComboBox_ClientSelectedIndexChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("onComboBoxValueChanged");
        }

        /// <summary>
        /// Handles the ClientSelectedItemChanged event of the mobjDomainUpDown control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjDomainUpDown_ClientSelectedItemChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("onDomainValueChanged");
        }

    }
}