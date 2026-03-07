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
    public partial class AutoSizePage : UserControl
    {
        public AutoSizePage()
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
            AddNewButtonToPanel();
        }

        /// <summary>
        /// Adds a button to demonstrated panel
        /// </summary>
        private void AddNewButtonToPanel()
        {
            global::Gizmox.WebGUI.Forms.Button button = new global::Gizmox.WebGUI.Forms.Button();
            button.Text = string.Format("Button {0}", (this.mobjPanel.Controls.Count + 1)); 
            button.Left = this.mobjPanel.Controls.Count * (button.Width + 10);
            this.mobjPanel.Controls.Add(button);
        }

        /// <summary>
        /// Updates maximum size for demonstrated panel
        /// </summary>
        private void UpdatePanelMaximumSize()
        {
            int panelMaxWidth = 1000;
            int panelMaxHeight = 250;
            this.mobjPanel.MaximumSize = new Size(panelMaxWidth, panelMaxHeight);
        }

        /// <summary>
        /// Handles the Load event of the AutoSizePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AutoSizePage_Load(object sender, EventArgs e)
        {
            UpdatePanelMaximumSize();
            AddNewButtonToPanel();
            this.mobjAutoSizeCB.Checked = this.mobjPanel.AutoSize;
        }

        /// <summary>
        /// Handles the Resize event of the AutoSizePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AutoSizePage_Resize(object sender, EventArgs e)
        {
            UpdatePanelMaximumSize();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAutoSizeCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAutoSizeCB_CheckedChanged(object sender, EventArgs e)
        {
            mobjPanel.AutoSize = mobjAutoSizeCB.Checked;
        }

    }
}
