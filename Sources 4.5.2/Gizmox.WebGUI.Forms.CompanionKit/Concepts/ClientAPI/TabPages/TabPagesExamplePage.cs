using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.TabPages
{
    public partial class TabPagesExamplePage : UserControl
    {
        public TabPagesExamplePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ClientCloseClick event of the objTabControl control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void objTabControl_ClientCloseClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("closeSelectedTabPage");
        }
    }
}