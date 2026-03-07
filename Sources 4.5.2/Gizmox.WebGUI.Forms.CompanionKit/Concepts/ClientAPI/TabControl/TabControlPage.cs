using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.TabControl
{
    public partial class TabControlPage : UserControl
    {
        public TabControlPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ClientSelectedIndexChanged event of the objTabControl control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void objTabControl_ClientSelectedIndexChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            //Invoking js handler function
            objArgs.Context.Invoke("currentSelectedTabPage");
        }
    }
}