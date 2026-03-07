using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.TabControl.Appearance
{
    public partial class SpreadAppearancePage : UserControl
    {
        public SpreadAppearancePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the objNormalRadioButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNormalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Switches TabControl appearance mode
            mobjTabControl.Appearance = mobjNormalRadioButton.Checked ? TabAppearance.Normal : TabAppearance.Spread;
        }

        /// <summary>
        /// Handles the Load event of the SpreadAppearancePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SpreadAppearancePage_Load(object sender, EventArgs e)
        {
            //Adds label to each tabPage control
            for (int i = 0; i < mobjTabControl.TabPages.Count; i++)
            {
                Label mobjLabel = new Label();
                mobjLabel.Text = mobjTabControl.TabPages[i].Text;
                mobjLabel.Dock = DockStyle.Fill;
                mobjLabel.AutoSize = false;
                mobjLabel.TextAlign = ContentAlignment.MiddleCenter;
                mobjTabControl.TabPages[i].Controls.Add(mobjLabel);
            }
        }
    }
}