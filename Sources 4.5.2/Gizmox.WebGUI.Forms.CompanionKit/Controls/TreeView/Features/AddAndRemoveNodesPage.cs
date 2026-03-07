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

namespace CompanionKit.Controls.TreeView.Features
{
    public partial class AddAndRemoveNodesPage : UserControl
    {
        public AddAndRemoveNodesPage()
        {
            InitializeComponent();           
        }

        /// <summary>
        /// Handles click event for the button that removes selected node from the TreeView
        /// </summary>
        private void mobjRemoveButton_Click(object sender, EventArgs e)
        {
            TreeNode mobjSelectedNode = this.mobjTreeView.SelectedNode;
            if (mobjSelectedNode != null)
            {
                TreeNode mobjParentNode = mobjSelectedNode.Parent;
                if (mobjParentNode != null)
                {
                    mobjParentNode.Nodes.Remove(mobjSelectedNode);
                }
                else
                {
                    this.mobjTreeView.Nodes.Remove(mobjSelectedNode);
                }
                this.mobjTreeView.SelectedNode = null;
            }
            else
            {
                MessageBox.Show("Please selected node, that should be removed!");
            }
        }

        /// <summary>
        /// Handles click event for the button that adds selected node from the TreeView
        /// </summary>
        private void mobjAddButton_Click(object sender, EventArgs e)
        {
            // Get added node name.
            string mstrAddedNodeText = this.mobjTextBox.Text;

            // Check whether added node name was entered. 
            // If the name hasn't been entered show error message.
            if (string.IsNullOrEmpty(mstrAddedNodeText))
            {
                MessageBox.Show("Please input text for added item!");
                return;
            }
            // Create a new node and add to TreeView as child node of selected node.
            TreeNode mobjAddedNode = new TreeNode(mstrAddedNodeText);
            TreeNode mobjSelectedNode = this.mobjTreeView.SelectedNode;
            if (mobjSelectedNode != null)
            {
                mobjSelectedNode.Nodes.Add(mobjAddedNode);
            }
            else
            {
                this.mobjTreeView.Nodes.Add(mobjAddedNode);
            }

            this.mobjTreeView.SelectedNode = mobjAddedNode;
        }
    }
}