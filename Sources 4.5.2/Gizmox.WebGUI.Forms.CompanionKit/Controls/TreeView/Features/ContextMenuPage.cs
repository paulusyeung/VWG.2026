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
    public partial class ContextMenuPage : UserControl
    {
        public ContextMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles click event for menu item that adds node to TreeView.
        /// If TreeView contains selected node, a new node is added as child of selected node. 
        /// Otherwise, a new node is added as parent node into the TreeView.
        /// </summary>
        private void mobjAddNodeMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new node
            TreeNode mobjAddedNode = new TreeNode("Added Node");
            TreeNode mobjSelectedNode = this.mobjTreeView.SelectedNode;
            
            // Check whether TreeView contains selected node.
            // If TreeView contains selected node, a new node is added as child of selected node. 
            // Otherwise, a new node is added as parent node into the TreeView.
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

        /// <summary>
        /// Handles click event for menu item that removes seleted node to TreeView.
        /// </summary>
        private void mobjRemoveNadeMenuItem_Click(object sender, EventArgs e)
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
            
        }

        /// <summary>
        /// Handles click event for menu item that shows informations about seleted 
        /// node of the TreeView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mobjViewNodeMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode mobjSelectedNode = this.mobjTreeView.SelectedNode;
            if (mobjSelectedNode != null)
            {
                MessageBox.Show(string.Format("You are viewing information about '{0}' tree node.", mobjSelectedNode.Text));
            }
            else
            {
                MessageBox.Show("Please select node for viewing!");
            }
        }

        /// <summary>
        /// Disabels or enable view and remove context menu items according
        /// to whether TreeView contains selected node.
        /// </summary>
        private void mobjContextMenu_Popup(object sender, EventArgs e)
        {
            if (this.mobjTreeView.SelectedNode != null)
            {
                if (!this.mobjRemoveNadeMenuItem.Enabled)
                {
                    this.mobjRemoveNadeMenuItem.Enabled = true;
                }

                if (!this.mobjViewNodeMenuItem.Enabled)
                {
                    this.mobjViewNodeMenuItem.Enabled = true;
                }
            }
            else
            { 
                if (this.mobjRemoveNadeMenuItem.Enabled)
                {
                    this.mobjRemoveNadeMenuItem.Enabled = false;
                }

                if (this.mobjViewNodeMenuItem.Enabled)
                {
                    this.mobjViewNodeMenuItem.Enabled = false;
                }
            }
        }
    }
}