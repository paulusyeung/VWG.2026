using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsCS
{
    public class CompanionKitWebSocketMessage
    {
        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        public Type ObjectType { get; set; }

        public CompanionKitWebSocketMessage()
        {
            this.ObjectType = this.GetType();
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="objMessage">The obj message.</param>
        public static void SendMessage(CompanionKitWebSocketMessage objMessage)
        {
            //Serialize object to string 
            string strMessage = JsonConvert.SerializeObject(objMessage);
            //Sends serialized message via WebSockets
            Application.WebSockets.Send(Application.WebSockets.ConnectionId, strMessage, SendType.All);
        }
    }
}