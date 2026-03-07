using System;
using System.Collections.Generic;
using System.Web;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;

namespace CompanionKit.Concepts.ClientActions.Events
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WikipediaIntegration : UserControl
    {
		#region Constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="WikipediaIntegration"/> class.
        /// </summary>
        public WikipediaIntegration()
        {
            this.InitializeComponent();
        }

		#endregion Constructors 

		#region Methods 

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
            objClientContext.Invoke("invokeSearchhWikiPedia", mobjQueryTextBox.ID.ToString(), mobjResultHtmlBox.ID.ToString());
        }

		#endregion Methods 
    }
}