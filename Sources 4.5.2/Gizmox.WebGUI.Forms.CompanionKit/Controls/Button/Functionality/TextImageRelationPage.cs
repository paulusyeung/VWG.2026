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

namespace CompanionKit.Controls.Button.Functionality
{
    public partial class TextImageRelationPage : UserControl
    {
        public TextImageRelationPage()
        {
            InitializeComponent();

            //Fill ComboBoxes with appropriate data
            mobjTextImageCB.DataSource = Enum.GetValues(typeof(TextImageRelation));
            mobjTextCB.DataSource = Enum.GetValues(typeof(ContentAlignment));
            mobjImageCB.DataSource = Enum.GetValues(typeof(ContentAlignment));
            

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjTextImageCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextImageCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            mobjButton.TextImageRelation = (TextImageRelation)mobjTextImageCB.SelectedItem;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjImageCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjImageCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            mobjButton.ImageAlign = (ContentAlignment)mobjImageCB.SelectedItem;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjTextCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            mobjButton.TextAlign = (ContentAlignment)mobjTextCB.SelectedItem;
        }
    }
}