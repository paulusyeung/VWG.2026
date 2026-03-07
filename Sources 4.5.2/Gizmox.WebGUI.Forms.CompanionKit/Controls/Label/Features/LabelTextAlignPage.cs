using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.LabelFolder.Features
{
    public partial class LabelTextAlignPage : UserControl
    {
        public LabelTextAlignPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Load event of the LabelTextAlignPage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LabelTextAlignPage_Load(object sender, EventArgs e)
        {
            // Set data source for ComboBox controls
            mobjCB1.DataSource = Enum.GetValues(typeof(ContentAlignment));
            mobjCB2.DataSource = Enum.GetValues(typeof(ContentAlignment));
            mobjCB3.DataSource = Enum.GetValues(typeof(ContentAlignment));
            // Set selected items for ComboBox controls
            mobjCB1.SelectedItem = mobjLabel1.TextAlign;
            mobjCB2.SelectedItem = mobjLabel2.TextAlign;
            mobjCB3.SelectedItem = mobjLabel3.TextAlign;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjCB1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set text alignment for Label control
            mobjLabel1.TextAlign = (ContentAlignment)mobjCB1.SelectedItem;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjCB2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set text alignment for Label control
            mobjLabel2.TextAlign = (ContentAlignment)mobjCB2.SelectedItem;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjCB3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCB3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set text alignment for Label control
            mobjLabel3.TextAlign = (ContentAlignment)mobjCB3.SelectedItem;
        }
    }
}