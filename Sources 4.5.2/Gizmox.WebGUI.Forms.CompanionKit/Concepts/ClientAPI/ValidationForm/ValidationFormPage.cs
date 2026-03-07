using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ClientAPI.ValidationForm
{
    public partial class ValidationFormPage : UserControl
    {
        public ValidationFormPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the ClientClick event of the objLoginButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        private void objLoginButton_ClientClick(object objSender, Gizmox.WebGUI.Forms.Client.ClientEventArgs objArgs)
        {
            objArgs.Context.Invoke("validateInputData");
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            //Condition, which catch our client custom event
            if(objEvent.Type == "validation")
            {
                //Getting parameters from client side
                string strEmail = objEvent["email"];
                string strPassword = objEvent["password"];
                //Show identification message
                MessageBox.Show(String.Format("You have been authorized:{0}",strEmail), "Thank you", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { base.FireEvent(objEvent); }
        }
    }
}