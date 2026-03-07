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
    public partial class LabelImagePage : UserControl
    {
        public LabelImagePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the LabelImagePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LabelImagePage_Load(object sender, EventArgs e)
        {
            // Set selected item for ComboBox control
            cmbImageAlignment.SelectedItem = mobjLabel.ImageAlign;
            // Fill ComboBox with ContentAlignment enum values
            cmbImageAlignment.DataSource = Enum.GetValues(typeof(ContentAlignment));
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbImageAlignment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbImageAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set image align for Label control
            mobjLabel.ImageAlign = (ContentAlignment)cmbImageAlignment.SelectedItem;
        }
    }
}