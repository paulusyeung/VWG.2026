#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Threading;
using Gizmox.WebGUI.Common.WebSockets;
using Newtonsoft.Json;

#endregion

namespace WebSocketsSampleAppsCS
{
    public partial class DynamicDataForm : Form, IPageHandler
    {

        public DynamicDataForm()
        {
            //Sets WebSocket's handler class
            Application.WebSockets.SetHandler<DynamicDataWebSocketsHandler>();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the DynamicDataPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DynamicDataPage_Load(object sender, EventArgs e)
        {
            //Tries to cast WebSocketHandler as CompanionKitWebSocketsHandler
            DynamicDataWebSocketsHandler objHandler = Application.WebSockets.WebSocketHandler as DynamicDataWebSocketsHandler;
            if (objHandler != null)
            {
                //Sets current instance to Page property
                objHandler.Page = this;
            }
        }

        /// <summary>
        /// Pages the handle.
        /// </summary>
        /// <param name="strConnectionId">The STR connection id.</param>
        /// <param name="strData">The STR data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void PageHandle(string strConnectionId, string strData)
        {
            //Not implemented. Retained for interface compatibility. 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pages the client handle.
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs" /> instance containing the event data.</param>
        public void PageClientHandle(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            //Invokes js ClientHandler function
            objArgs.Context.Invoke("ClientHandler");
        }

       

       /// <summary>
       /// Called when [unregister components].
       /// </summary>
       protected override void OnUnregisterComponents()
       {
           base.OnUnregisterComponents();
           ((DynamicDataWebSocketsHandler)(Application.WebSockets.WebSocketHandler)).Abort();
       }

    }
}