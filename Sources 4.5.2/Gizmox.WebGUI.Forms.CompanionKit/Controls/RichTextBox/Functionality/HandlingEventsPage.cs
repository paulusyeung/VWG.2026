using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.RichTextBox.Functionality
{
    public partial class HandlingEventsPage : UserControl
    {
        public HandlingEventsPage()
        {
            InitializeComponent();

            //Set default html for both RichTextBoxes
            mobjDemoRTB.Html = "<b><em>Visual WebGui</em></b> is a platform for rapid development of desktop applications";
            mobjSaverRTB.Html = mobjDemoRTB.Html;
        }


        /// <summary>
        /// Handles the HtmlChanged event of the mobjDemoRTB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjDemoRTB_HtmlChanged(object sender, EventArgs e)
        {
            //Change Html property of the lower RichTextBox
            mobjSaverRTB.Html = mobjDemoRTB.Html;
        }

        /// <summary>
        /// Handles the Click event of the mobjSendButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSendButton_Click(object sender, EventArgs e)
        {
            //Updates Demo RichTextBox to raise its HtmlChanged event
            mobjDemoRTB.Update();
        }



    }
}
