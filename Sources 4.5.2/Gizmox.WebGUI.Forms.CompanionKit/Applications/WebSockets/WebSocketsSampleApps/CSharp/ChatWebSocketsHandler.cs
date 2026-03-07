using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsCS
{
    public class ChatWebSocketsHandler : IWebSocketHandler
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public object Page { get; set; }

        /// <summary>
        /// Clients the handle.
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        public void ClientHandle(object objSender, ClientEventArgs objArgs)
        {
            //Calls PageClientHandle method from Page instance
            var mobjPage = Page as IPageHandler;
            mobjPage.PageClientHandle(objSender, objArgs);
        }

        /// <summary>
        /// Handles the specified STR sender conection id.
        /// </summary>
        /// <param name="strSenderConectionId">The STR sender conection id.</param>
        /// <param name="strData">The STR data.</param>
        public void Handle(string strSenderConectionId, string strData)
        {
            //Calls PageHandle method from Page instance
            var mobjPage = Page as IPageHandler;
            mobjPage.PageHandle(strSenderConectionId, strData);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is client handler.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is client handler; otherwise, <c>false</c>.
        /// </value>
        public bool IsClientHandler
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is server handler.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is server handler; otherwise, <c>false</c>.
        /// </value>
        public bool IsServerHandler
        {
            get { return true; }
        }


        public void WebSocketInitialized()
        {
            //Not implemented. Retained for interface compatibility. 
        }
    }
    
}