using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ExpandableGroupBox.Functionality
{
    public partial class TextImagePage : UserControl
    {
        public TextImagePage()
        {
            InitializeComponent();

        }
        private void mobjIsSpreadCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Change ExpandableGroupBox.IsTextImageSpread property
            mobjExpandableGroupBox.IsTextImageSpread = mobjIsSpreadCheck.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjImageBeforeRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjImageBeforeRB_CheckedChanged(object sender, EventArgs e)
        {
            //Change ExpandableGroupBox.TextImageRelation property
            if (mobjImageBeforeRB.Checked)
                mobjExpandableGroupBox.TextImageRelation = Gizmox.WebGUI.Forms.ExpandableGroupBox.HorizontalTextImageRelation.ImageBeforeText;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjTextBeforeRB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjTextBeforeRB_CheckedChanged(object sender, EventArgs e)
        {
            //Change ExpandableGroupBox.TextImageRelation property
            if (mobjTextBeforeRB.Checked)
                mobjExpandableGroupBox.TextImageRelation = Gizmox.WebGUI.Forms.ExpandableGroupBox.HorizontalTextImageRelation.TextBeforeImage;
        }


    }
}