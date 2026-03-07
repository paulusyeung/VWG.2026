#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Newtonsoft.Json;

#endregion

namespace WebSocketsSampleAppsCS
{
    public partial class ChatForm : Form, IPageHandler
    {
        public ChatForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the ChatPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChatPage_Load(object sender, EventArgs e)
        {
            //Sets WebSocket's handler class
            Application.WebSockets.SetHandler<ChatWebSocketsHandler>();
            //Tries to cast WebSocketHandler as CompanionKitWebSocketsHandler
            ChatWebSocketsHandler objHandler = Application.WebSockets.WebSocketHandler as ChatWebSocketsHandler;
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
        public void PageHandle(string strConnectionId, string strData)
        {
            //Desearialize string data to ChatSampleMessage object
            ChatSampleMessage mobjMessage = JsonConvert.DeserializeObject<ChatSampleMessage>(strData);
            //If received data truly have ChatSampleMessage type, then proceed...
            if (mobjMessage.ObjectType.Equals(mobjMessage.GetType()))
            {
                string strName = mobjMessage.Name;
                //If it's the client who sent the message
                if (strConnectionId == Application.WebSockets.ConnectionId)
                {
                    strName = "[ME]";
                    //Disable Name watermarkTextBox if it's enabled
                    if (mobjNameTextBox.Enabled)
                        mobjNameTextBox.Enabled = false;
                }
                //Displays received message at Chat's textBox
                mobjChatTextBox.Text += string.Format("{0}:{1} \r\n", strName, mobjMessage.Message);
            }
        }

        /// <summary>
        /// Pages the client handle.
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs" /> instance containing the event data.</param>
        public void PageClientHandle(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            //Not implemented. Retained for interface compatibility. 
        }

        /// <summary>
        /// Handles the Click event of the mobjSendButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSendButton_Click(object sender, EventArgs e)
        {

            //If Name watermarkTextBox is empty
            if (mobjNameTextBox.Text == "")
                MessageBox.Show("Please enter your name!");

            //If message text is not empty
            else if (!string.IsNullOrWhiteSpace(mobjMessageTextBox.Text))
            {
                ChatSampleMessage mobjMessage = new ChatSampleMessage(mobjNameTextBox.Text, mobjMessageTextBox.Text);
                //Sends the message to all the clients
                ChatSampleMessage.SendMessage(mobjMessage);
                //Clears the message TextBox and returns focus back
                mobjMessageTextBox.Text = "";
                mobjMessageTextBox.Focus();
            }
        }
    }
}