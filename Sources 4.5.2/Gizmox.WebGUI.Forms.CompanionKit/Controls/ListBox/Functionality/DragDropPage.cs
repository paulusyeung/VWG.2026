#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.ListBox.Functionality
{
    public partial class DragDropPage : UserControl
    {
        public DragDropPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the DragDrop event of the mobjListBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void mobjListBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (e is DragDropEventArgs)
            {
                DragDropEventArgs dragDropEventArgs = e as DragDropEventArgs;
                if (dragDropEventArgs.Source is Gizmox.WebGUI.Forms.ListBox)
                {
                    //Get text of drag item of left ListBox.
                    string addedItem = ((Gizmox.WebGUI.Forms.ListBox)dragDropEventArgs.Source).SelectedItem as string;
                    if (addedItem != null)
                    {
                        //Add draged item to right ListBox
                        this.mobjListBox2.Items.Add(addedItem);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAllowDrop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAllowDrop_CheckedChanged(object sender, EventArgs e)
        {
            mobjListBox2.AllowDrop = mobjAllowDrop.Checked;
        }

    }
}