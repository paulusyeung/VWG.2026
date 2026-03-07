using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ComboBoxItems
{
    public partial class ComboBoxItemsPage : UserControl
    {
        public ComboBoxItemsPage()
        {
            InitializeComponent();

            //Fill ComboBox with 3 default items
            mobjComboBox.Items.Add("item1");
            mobjComboBox.Items.Add("item2");
            mobjComboBox.Items.Add("item3");
            mobjComboBox.SelectedIndex = 0;
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

                //Add new item in ComboBox on server
                mobjComboBox.Items.Add(strNewItemText);
                if (mobjComboBox.Items.Count == 1)
                {
                    mobjComboBox.SelectedIndex = 0;
                }
            }
            else if (objEvent.Type == "removeItemOnServer")
            {
                //Get events attributes - index of item to be removed
                int intIndexToRemove = -1;

                if (int.TryParse(objEvent["index"], out intIndexToRemove) && intIndexToRemove >= 0 && intIndexToRemove < mobjComboBox.Items.Count)
                {
                    //Remove item in ComboBox on server by position
                    mobjComboBox.Items.RemoveAt(intIndexToRemove);  

                    // Update selected index in mobjComboBox

                    // If 1st item deleted and there are more items, select the 1st one
                    if (intIndexToRemove == 0 && mobjComboBox.Items.Count >= 1)
                    {
                        mobjComboBox.SelectedIndex = 0;
                    }
                   
                    // If not the 1st item deleted, or there are no more items, select previous index
                    else
                    {
                        mobjComboBox.SelectedIndex = intIndexToRemove-1;
                    }                                    
                }

                
            }
            else
            {
                base.FireEvent(objEvent);
            }
        }

        /// <summary>
        /// Handles the ClientSelectedIndexChanged event of the mobjComboBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        void mobjComboBox_ClientSelectedIndexChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("selectedChanged");
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("addItem");
        }

        /// <summary>
        /// Handles the Click event of the mobjRemoveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjRemoveButton_Click(object sender, EventArgs e)
        {
            VWGClientContext.Current.Invoke("removeItem");
        }

    }
}