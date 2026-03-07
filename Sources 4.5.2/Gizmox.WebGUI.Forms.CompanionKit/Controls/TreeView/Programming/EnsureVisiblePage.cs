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

namespace CompanionKit.Controls.TreeView.Programming
{
    public partial class EnsureVisiblePage : UserControl
    {
        public EnsureVisiblePage()
        {
            InitializeComponent();

			this.mobjTreeView.ExpandAll();

            // Fills up the ComboBox with tree nodes.
            AddTreeNodesToComboBox(this.mobjTreeView.Nodes);
            this.mobjComboBox.DisplayMember = "Text";
            this.mobjComboBox.Sorted = true;
        }
        
        /// <summary>
        /// Fills up the ComboBox with tree nodes.
        /// </summary>
        /// <param name="treeNodes">Tree nodes collection</param>
        private void AddTreeNodesToComboBox(TreeNodeCollection treeNodes)
        {
            foreach (TreeNode mobjTreeNode in treeNodes)
            {
                this.mobjComboBox.Items.Add(mobjTreeNode);
                if (mobjTreeNode.Nodes != null && mobjTreeNode.Nodes.Count > 0)
                {
                    AddTreeNodesToComboBox(mobjTreeNode.Nodes);
                }
            }
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox that 
        /// selects selected node in the TreeView
        /// </summary>
        private void mobjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.mobjComboBox.SelectedItem != null)
            {
                this.mobjTreeView.SelectedNode = (TreeNode)this.mobjComboBox.SelectedItem;
				if (this.mobjTreeView.SelectedNode != null)
				{
					// Ensure selected node scrolled into view and visible
					this.mobjTreeView.SelectedNode.EnsureVisible();
				}
            }
        }

        /// <summary>
        /// Handles AfterSelect event of the TreeView that 
        /// changed selected node in the ComboBox
        /// </summary>
        private void mobjTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.mobjTreeView.SelectedNode != null)
            {
                this.mobjComboBox.SelectedItem = this.mobjTreeView.SelectedNode;
            }
        }
    }
}