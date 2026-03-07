using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Converters;

namespace CompanionKit.Controls.RichTextBox.Functionality
{
    public partial class LoadFilePage : UserControl
    {
        public LoadFilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjLoadButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjLoadButton_Click(object sender, EventArgs e)
        {
            //Define full path of selected rtf file
            //NOTE: in order to use this code in your project, just edit the path below
            //NOTE: if you add rtf files in the base directory, just remove "Controls", "RichTextBox", "Functionality" part
            string mobjFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                System.IO.Path.Combine("Controls", 
                System.IO.Path.Combine("RichTextBox", 
                System.IO.Path.Combine("Functionality", mobjListView.SelectedItem.Text))));
            //Load file to RichTextBox
            mobjRichTextBox.LoadFile(mobjFilePath);
        }

    }
}