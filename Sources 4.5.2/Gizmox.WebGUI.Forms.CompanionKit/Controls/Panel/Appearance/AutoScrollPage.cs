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

namespace CompanionKit.Controls.Panel.Appearance
{
    public partial class AutoScrollPage : UserControl
    {
        public AutoScrollPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Click event of the mobjButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_Click(object sender, EventArgs e)
        {
            // Add a button to panel
            AddNewButtonToPanel();
        }

        /// <summary>
        /// Adds a button to demonstrated panel
        /// </summary>
        private void AddNewButtonToPanel()
        {
            //Create a new button
            Gizmox.WebGUI.Forms.Button button = new Gizmox.WebGUI.Forms.Button();
            button.Text = string.Format("Button {0}", (this.mobjPanel.Controls.Count + 1));
            button.Left = this.mobjPanel.Controls.Count * (button.Width + 10);
            //Add button to demonstrated panel
            this.mobjPanel.Controls.Add(button);
        }

        /// <summary>
        /// Handles the Load event of the AutoScrollPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AutoScrollPage_Load(object sender, EventArgs e)
        {
            AddNewButtonToPanel();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAutoScrollEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAutoScrollEnabled_CheckedChanged(object sender, EventArgs e)
        {
            mobjPanel.AutoScroll = mobjAutoScrollEnabled.Checked;
        }

    }
}