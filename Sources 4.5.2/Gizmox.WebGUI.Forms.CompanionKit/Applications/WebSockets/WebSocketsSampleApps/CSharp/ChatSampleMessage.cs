using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsCS
{
    public class ChatSampleMessage : CompanionKitWebSocketMessage
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        public ChatSampleMessage(string strName, string strMessage)
        {
            this.Name = strName;
            this.Message = strMessage;
        }
    }
}