using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Newtonsoft.Json;
using Gizmox.WebGUI.Forms;
using System.Threading;
using Gizmox.WebGUI.Common.WebSockets;

namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsCS
{
    public class DynamicDataWebSocketsHandler : IWebSocketHandler
    {
        private Thread mobjWorkThread;
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
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is server handler.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is server handler; otherwise, <c>false</c>.
        /// </value>
        public bool IsServerHandler
        {
            get { return false; }
        }


        public void WebSocketInitialized()
        {
           
            //Define args for thread handler
            var mobjArgs = new WebSocketState() { Service = Application.WebSockets, ConnectionId = Application.WebSockets.ConnectionId };
            //Create and start thread instance
            mobjWorkThread = new Thread(ThreadHandler);
            mobjWorkThread.Start(mobjArgs);
        }

        /// <summary>
        /// Thread's handler that simulatse time consuming operation.
        /// </summary>
        /// <param name="objArgs">The obj args.</param>
        public void ThreadHandler(object objArgs)
        {

            var mobjState = objArgs as WebSocketState;
            string strConnectionId = mobjState.ConnectionId;

            while (true)
            {
                //Simulate time consuming operation.
                Thread.Sleep(1000);
                // Create new message
                DynamicDataSampleMessage mobjMessage = new DynamicDataSampleMessage();
                Random mobjRandom = new Random();
                //Fill message with random values
                for (int i = 0; i < mobjMessage.RandomValues.Length; i++)
                {
                    mobjMessage.RandomValues[i] = mobjRandom.Next(0, 101);
                }
                //Send the message
                mobjState.Service.Send(strConnectionId, JsonConvert.SerializeObject(mobjMessage), SendType.Self);
            }
        }

        public void Abort()
        {
            //Stop working thread
            mobjWorkThread.Abort();
        }
    }

    class WebSocketState
    {
            /// <summary>
            /// Gets or sets the service.
            /// </summary>
            /// <value>
            /// The service.
            /// </value>
            public WebSocketService Service { get; set; }

            /// <summary>
            /// Gets or sets the connection id.
            /// </summary>
            /// <value>
            /// The connection id.
            /// </value>
            public string ConnectionId { get; set; }
    }
    
}