using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsCS
{
    public partial class C1TreeViewForm : Form
    {
        public C1TreeViewForm()
        {
            InitializeComponent();
            //Set default theme for wrapper
            mobjWrapper.Theme = "aristo";
            //Set AutoPostBack property to True
            mobjWrapper.AutoPostBack = true;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Change ShowCheckBoxes property of TreeView control
            mobjWrapper.ShowCheckBoxes = mobjCheckBox.Checked;
        }

        /// <summary>
        /// Handles the SelectedNodesChanged event of the mobjWrapper control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs"/> instance containing the event data.</param>
        private void mobjWrapper_SelectedNodesChanged(object sender, C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs e)
        {
            //Define last selected node
            mobjLabel.Text = "Last selected node: " + e.Node.Text;
        }

        /// <summary>
        /// Handles the NodeCheckChanged event of the mobjWrapper control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs"/> instance containing the event data.</param>
        private void mobjWrapper_NodeCheckChanged(object sender, C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs e)
        {
            //Show message box if Main Node is selected
            if (e.Node.Text == "Main" && e.Node.Checked)
                MessageBox.Show("Main node is checked.");
        }

    }
}