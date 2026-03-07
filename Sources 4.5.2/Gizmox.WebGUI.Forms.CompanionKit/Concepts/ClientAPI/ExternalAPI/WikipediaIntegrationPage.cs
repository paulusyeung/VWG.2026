using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Client;

namespace CompanionKit.Concepts.ClientAPI.ExternalAPI
{
    public partial class WikipediaIntegrationPage : UserControl
    {
        public WikipediaIntegrationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ClientEnterKeyDown event of the mobjQueryTextBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjQueryTextBox_ClientEnterKeyDown(object objSender, ClientEventArgs objArgs)
        {
            SearchWikipedia(objArgs.Context);
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjSearchButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjSearchButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            SearchWikipedia(objArgs.Context);
        }

        /// <summary>
        /// Searches the wikipedia.
        /// </summary>
        /// <param name="objClientContext">The obj client context.</param>
        private void SearchWikipedia(ClientContext objClientContext)
        {
            objClientContext.Invoke("invokeSearchhWikiPedia", mobjQueryTextBox.ID, mobjResultHtmlBox.ID);
        }

    }
}