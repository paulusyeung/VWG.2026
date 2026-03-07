using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ToolStripMenuItem.Features
{
    public partial class DropDownTitlePanelPage : UserControl
    {
        public DropDownTitlePanelPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the DropDownTitlePanelPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DropDownTitlePanelPage_Load(object sender, EventArgs e)
        {
            //OnLoad Header Panel and its containment initialization: TextBox and Buttons
            mobjToolStripMenuItem1.DropDown.HeaderPanel.BackColor = Color.Crimson;
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Size = new System.Drawing.Size(100, 20);
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            mobjRemoveButton = new Gizmox.WebGUI.Forms.Button();
            mobjAddButton.Text = "Add";
            mobjAddButton.Size = new System.Drawing.Size(1, 25);
            mobjRemoveButton.Text = "Remove";
            mobjRemoveButton.Size = new System.Drawing.Size(1, 25);
            mobjRemoveButton.Dock = DockStyle.Top;
            mobjAddButton.Dock = DockStyle.Top;
            mobjAddButton.Click += new EventHandler(mobjAddButton_Click);
            mobjRemoveButton.Click += new EventHandler(mobjRemoveButton_Click);
            mobjTextBox.Text = "NewItem";
            mobjTextBox.Size = new System.Drawing.Size(1, 25);
            mobjTextBox.Dock = DockStyle.Top;
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Controls.Add(mobjRemoveButton);
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Controls.Add(mobjAddButton);
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Controls.Add(mobjTextBox);
        }

        /// <summary>
        /// Handles the Click event of the mobjRemoveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void mobjRemoveButton_Click(object sender, EventArgs e)
        {
            //Removes last non-default item
            if (mobjToolStripMenuItem1.DropDownItems.Count > 5)
            {
                mobjToolStripMenuItem1.DropDownItems.RemoveAt(mobjToolStripMenuItem1.DropDownItems.Count - 1);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjAddButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void mobjAddButton_Click(object sender, EventArgs e)
        {
            //If textBox's text is not empty - add new item with name from textbox
            if (!string.IsNullOrEmpty(mobjTextBox.Text))
            {
                mobjToolStripMenuItem1.DropDownItems.Add(mobjTextBox.Text, null, ShowMessage);
            }
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void ShowMessage(object sender, EventArgs e)
        {
            //Shows message, which displays current toolStripMenuItem (non-default)
            MessageBox.Show("You clicked on " + ((ToolStripItem)sender).Text);
        }
    }
}