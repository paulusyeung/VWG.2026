using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.APIEvent
{
    public partial class APIEventPage : UserControl
    {
        public APIEventPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            //Catch custom event
            if (objEvent.Type == "customEvent")
            {
                //Get events attributes
                int intIndex;
                Gizmox.WebGUI.CommonUtils.TryParse((string)objEvent["index"], out intIndex);
                string strText = objEvent["text"];
                //Display attributes on label
                objLabel.Text = String.Format("Index:{0}, Text:{1}",intIndex,strText);
            }
            else
            {
                base.FireEvent(objEvent);
            }
        }

        /// <summary>
        /// Handles the ClientSelectedIndexChanged event of the objComboBox control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void objComboBox_ClientSelectedIndexChanged(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("raiseCustomEvent");
        }
    }
}