using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.LoadingIcon
{
    public partial class LoadingIconPage : UserControl
    {
        public LoadingIconPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the objButton control by invoking js function to show and hide icon with defined duration.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void objButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("showLoadingIcon");
        }
    }
}