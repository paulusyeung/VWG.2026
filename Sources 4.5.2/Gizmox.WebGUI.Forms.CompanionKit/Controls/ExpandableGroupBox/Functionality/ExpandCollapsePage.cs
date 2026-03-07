using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ExpandableGroupBox
{
    public partial class ExpandCollapsePage : UserControl
    {
        public ExpandCollapsePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Expand event of the mobjExpandableGroupBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjExpandableGroupBox1_Expand(object sender, EventArgs e)
        {
            //Make only ExpandableGroupBox1 expanded
            mobjExpandableGroupBox2.IsExpanded = false;
            mobjExpandableGroupBox3.IsExpanded = false;
            mobjExpColInfo.Text = "Expanded: ExpandableGroupBox1";
        }

        /// <summary>
        /// Handles the Expand event of the mobjExpandableGroupBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjExpandableGroupBox2_Expand(object sender, EventArgs e)
        {
            //Make only ExpandableGroupBox2 expanded
            mobjExpandableGroupBox1.IsExpanded = false;
            mobjExpandableGroupBox3.IsExpanded = false;
            mobjExpColInfo.Text = "Expanded: ExpandableGroupBox2";
        }

        /// <summary>
        /// Handles the Expand event of the mobjExpandableGroupBox3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjExpandableGroupBox3_Expand(object sender, EventArgs e)
        {
            //Make only ExpandableGroupBox3 expanded
            mobjExpandableGroupBox2.IsExpanded = false;
            mobjExpandableGroupBox1.IsExpanded = false;
            mobjExpColInfo.Text = "Expanded: ExpandableGroupBox3";
        }

        /// <summary>
        /// Handles the Collapse event of the mobjExpandableGroupBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjExpandableGroupBox1_Collapse(object sender, EventArgs e)
        {
            //If no one ExpandableGroupBox is expanded
            if ((!mobjExpandableGroupBox2.IsExpanded) && (!mobjExpandableGroupBox3.IsExpanded))
                mobjExpColInfo.Text = "Expanded: - ";
        }

        /// <summary>
        /// Handles the Collapse event of the mobjExpandableGroupBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjExpandableGroupBox2_Collapse(object sender, EventArgs e)
        {
            //If no one ExpandableGroupBox is expanded
            if ((!mobjExpandableGroupBox1.IsExpanded) && (!mobjExpandableGroupBox3.IsExpanded))
                mobjExpColInfo.Text = "Expanded: - ";
        }

        /// <summary>
        /// Handles the Collapse event of the mobjExpandableGroupBox3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjExpandableGroupBox3_Collapse(object sender, EventArgs e)
        {
            //If no one ExpandableGroupBox is expanded
            if ((!mobjExpandableGroupBox2.IsExpanded) && (!mobjExpandableGroupBox1.IsExpanded))
                mobjExpColInfo.Text = "Expanded: - ";
        }
    }
}