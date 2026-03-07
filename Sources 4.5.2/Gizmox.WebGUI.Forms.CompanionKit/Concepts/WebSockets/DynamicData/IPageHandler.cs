using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Forms.Client;

namespace WebSocketsSampleAppsCS
{
    public interface IPageHandler
    {
        /// <summary>
        /// Pages the handle.
        /// </summary>
        /// <param name="strConnectionId">The STR connection id.</param>
        /// <param name="strData">The STR data.</param>
        void PageHandle(string strConnectionId, string strData);

        /// <summary>
        /// Pages the client handle.
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        void PageClientHandle(object objSender, ClientEventArgs objArgs);
    }
}
