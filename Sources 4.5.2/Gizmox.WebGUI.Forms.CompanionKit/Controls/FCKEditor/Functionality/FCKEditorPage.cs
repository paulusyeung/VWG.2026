using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.FCKEditor
{
    public partial class FCKEditorPage : UserControl
    {
        public FCKEditorPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjSendButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSendButton_Click(object sender, EventArgs e)
        {
            //Sent FCKEditor value to RichTextBox
            mobjRichTextBox.Html = mobjFCKEditor.Value;
        }
    }
}