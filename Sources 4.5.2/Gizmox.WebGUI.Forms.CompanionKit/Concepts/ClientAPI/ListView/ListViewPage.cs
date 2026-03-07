using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ListView
{
    public partial class ListViewPage : UserControl
    {
        public ListViewPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            //Catch custom events
            if (objEvent.Type == "addItemOnServer")
            {
                //Get events attributes - text of new item
                string strNewItemText = objEvent["text"];

                //Add new item in ListView on server
                mobjListView.Items.Add(strNewItemText);
            }

            else if (objEvent.Type == "fillOnServer")
            {
                //Clear ListView
                mobjListView.Items.Clear();
                //Fill ListView with 5 items 
                for (int i = 0; i < 5; i++) 
                {
                      mobjListView.Items.Add("item" + (i+1).ToString());
                      mobjListView.Items[i].SubItems.Add("subitem" + (i+1).ToString());

                }
            }

            else if (objEvent.Type == "removeItemOnServer")
            {
                //If there are items in ListView
                if (mobjListView.Items.Count > 0)
                {
                    //Remove last item in ListView on server
                    mobjListView.Items.RemoveAt(mobjListView.Items.Count-1);
                }
            }

            else if (objEvent.Type == "removeAllOnServer")
            {
                //Clear ListView
                mobjListView.Items.Clear();
            }

            else
            {
                base.FireEvent(objEvent);
            }
        }


        /// <summary>
        /// Handles the ClientClick event of the mobjAddItemButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjAddItemButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("addItem");
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjRemoveItemButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjRemoveItemButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("removeItem");
        }


        /// <summary>
        /// Handles the ClientClick event of the mobjRemoveAllButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjRemoveAllButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("removeAllFromListView");
        }

        /// <summary>
        /// Handles the ClientClick event of the mobjFillListViewButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjFillListViewButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("fillListView");
        }

        /// <summary>
        /// Handles the ClientSelectedIndexChanged event of the mobjListView control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void mobjListView_ClientSelectedIndexChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("showSelectedItems");
        }

    }
}