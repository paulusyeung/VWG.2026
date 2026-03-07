using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System.IO;

namespace CompanionKit.Controls.RichTextBox.Functionality
{
    public partial class LoadingFormattedTextPage : UserControl
    {
        public LoadingFormattedTextPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the LoadingFormattedTextPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoadingFormattedTextPage_Load(object sender, EventArgs e)
        {
            StreamReader strReader = new StreamReader(Context.Server.MapPath("~/Resources/UserData/about.html"));
            this.mobjRichTextBox.Html = strReader.ReadToEnd();
            strReader.Close();
        }
    }
}