using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ComponentOneSampleAppsCS
{
    public partial class C1GridViewForm : Form
    {
        public C1GridViewForm()
        {
            InitializeComponent();
            //Set default theme for wrapper
            mobjWrapper.Theme = "aristo";
        }

        /// <summary>
        /// Handles the PageIndexChanged event of the mobjGridViewWrapper control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjGridViewWrapper_PageIndexChanged(object sender, EventArgs e)
        {
            //Set new Label Text
            setNewLabelText();
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjNUD_ValueChanged(object sender, EventArgs e)
        {
            //Set new PageSize property value
            mobjWrapper.PageSize = (int)mobjNUD.Value;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjShowFilterRow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShowFilterRow_CheckedChanged(object sender, EventArgs e)
        {
            //Set new ShowFilter property value
            mobjWrapper.ShowFilter = mobjShowFilterRow.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAllowPaging control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAllowPaging_CheckedChanged(object sender, EventArgs e)
        {
            //Set new AllowPaging property value
            mobjWrapper.AllowPaging = mobjAllowPaging.Checked;
            //Disable NumericUpDown if needed
            mobjNUD.Enabled = mobjAllowPaging.Checked;
            //Set new Label Text
            if (!mobjAllowPaging.Checked)
                mobjSelectedPageIndex.Text = "Selected Page Index: 0";
            else
                setNewLabelText();
        }

        /// <summary>
        /// Handles the Load event of the Page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Page_Load(object sender, EventArgs e)
        {
            //Define default values
            setNewLabelText();
            mobjNUD.Value = mobjWrapper.PageSize;
        }

        /// <summary>
        /// Handles the Sorted event of the mobjGridViewWrapper control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjGridViewWrapper_Sorted(object sender, EventArgs e)
        {
            //Set Label Text to a correct value after sorting
            setNewLabelText();
        }

        /// <summary>
        /// Sets the new label text.
        /// </summary>
        private void setNewLabelText()
        {
            mobjSelectedPageIndex.Text = "Selected Page Index: " + mobjWrapper.PageIndex;
        }

    }
}