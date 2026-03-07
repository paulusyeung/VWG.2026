using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Client;

namespace CompanionKit.Concepts.ClientAPI.ChangingDockStyle
{
    public partial class DockStylesPage : UserControl
    {
        public DockStylesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the dock style.
        /// </summary>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="style">The dock style.</param>
        private void SetDockStyle(ClientContext objClientContext, DockStyle objStyle)
        {            
            // Invoking js callback function with DockStyle parameter as a string.
            objClientContext.Invoke("setDockStyle", objStyle.ToString().ToLower());
        }

        /// <summary>
        /// Handles the ClientClick event of the leftButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        private void objLeftButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            //Calling js callback function to set label's Dock property to "Left".
            SetDockStyle(objArgs.Context, DockStyle.Left);
        }

        /// <summary>
        /// Handles the ClientClick event of the topButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        private void objTopButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            //Calling js callback function to set label's Dock property to "Top".
            SetDockStyle(objArgs.Context, DockStyle.Top);
        }

        /// <summary>
        /// Handles the ClientClick event of the rightButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        private void objRightButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            //Calling js callback function to set label's Dock property to "Right".
            SetDockStyle(objArgs.Context, DockStyle.Right);
        }

        /// <summary>
        /// Handles the ClientClick event of the fillButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        private void objFillButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            //Calling js callback function to set label's Dock property to "Fill".
            SetDockStyle(objArgs.Context, DockStyle.Fill);
        }

        /// <summary>
        /// Handles the ClientClick event of the bottomButton control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ClientEventArgs"/> instance containing the event data.</param>
        private void objBottomButton_ClientClick(object objSender, ClientEventArgs objArgs)
        {
            //Calling js callback function to set label's Dock property to "Bottom".
            SetDockStyle(objArgs.Context, DockStyle.Bottom);
        }
    }
}