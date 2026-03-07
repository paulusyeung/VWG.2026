using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.TreeView.Features
{
    public partial class TreeViewItemsSortingPage : UserControl
    {
        public TreeViewItemsSortingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjSortCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSortCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Gets CheckBox's state
            bool mblnState = ((Gizmox.WebGUI.Forms.CheckBox)sender).Checked;
            //Changes label text accrding to checked state
            mobjLabel.Text = mblnState ? "Nodes are sorted" : "Nodes are not sorted";
            //Sets sorted state
            mobjTreeView.Sorted = mblnState;
            //If Sorted = false - clear all nodes and new ones (unsorted list)
            if (!mobjTreeView.Sorted)
            {
                mobjTreeView.Nodes.Clear();
                mobjTreeView.Nodes.AddRange(new TreeNode[] {
                 new TreeNode("A item"),
                 new TreeNode("X item"),
                 new TreeNode("Y item"),
                 new TreeNode("I item"),
                 new TreeNode("J item"),
                 new TreeNode("K item"),
                 new TreeNode("L item"),
                 new TreeNode("M item"),
                 new TreeNode("N item"),
                 new TreeNode("O item"),
                 new TreeNode("B item"),
                 new TreeNode("C item"),
                 new TreeNode("T item"),
                 new TreeNode("U item"),
                 new TreeNode("V item"),
                 new TreeNode("D item"),
                 new TreeNode("H item"),
                 new TreeNode("E item"),
                 new TreeNode("F item"),
                 new TreeNode("G item"),
                 new TreeNode("P item"),
                 new TreeNode("Q item"),
                 new TreeNode("R item"),
                 new TreeNode("S item"),
                 new TreeNode("W item"),
                 new TreeNode("Z item")
                });
            }
        }
    }
}