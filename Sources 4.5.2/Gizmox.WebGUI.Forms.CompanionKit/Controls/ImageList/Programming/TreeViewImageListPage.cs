using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ImageListFolder.Programming
{
    public partial class TreeViewImageListPage : UserControl
    {
        public TreeViewImageListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewImageListPage_Load(object sender, EventArgs e)
        {
            // Set the ImageList object to the TreeView
            mobjTreeViewMessages.ImageList = mobjImageList;
            // Set the image for TreeView nodes using ImageIndex property
            mobjTreeViewMessages.ImageIndex = 5;
            // Set the image for TreeView nodes using SelectedImageKey property
            mobjTreeViewMessages.SelectedImageKey = "16x16.OpenedEmail.png";
            // Create object for generating nodes quantity
            Random random = new Random();
            // Generate nodes quantity
            int nodesQty = random.Next(1, 5);
            // Create TreeView node
            Gizmox.WebGUI.Forms.TreeNode inboxNode = new TreeNode(string.Format("Inbox ({0})", nodesQty), 0, 0);
            // Fill TreeView node with child nodes
            for (int i = 0; i < nodesQty; i++)
            {
                inboxNode.Nodes.Add("Email message");
            }
            // Add node to TreeView
            mobjTreeViewMessages.Nodes.Add(inboxNode);
            // Generate nodes quantity
            nodesQty = random.Next(1, 4);
            // Create TreeView node
            Gizmox.WebGUI.Forms.TreeNode outboxNode = new TreeNode(string.Format("Outbox ({0})", nodesQty), 1, 1);
            // Fill TreeView node with child nodes
            for (int i = 0; i < nodesQty; i++)
            {
                outboxNode.Nodes.Add("Email message");
            }
            // Add node to TreeView
            mobjTreeViewMessages.Nodes.Add(outboxNode);
            // Generate nodes quantity
            nodesQty = random.Next(1, 4);
            // Create TreeView node
            Gizmox.WebGUI.Forms.TreeNode sentMailNode = new TreeNode(string.Format("Sent Mail ({0})", nodesQty), 2, 2);
            // Fill TreeView node with child nodes
            for (int i = 0; i < nodesQty; i++)
            {
                sentMailNode.Nodes.Add("Email message");
            }
            // Add node to TreeView
            mobjTreeViewMessages.Nodes.Add(sentMailNode);
            // Generate nodes quantity
            nodesQty = random.Next(1, 4);
            // Create TreeView node
            Gizmox.WebGUI.Forms.TreeNode junkMailNode = new TreeNode(string.Format("Junk Mail ({0})", nodesQty), 3, 3);
            // Fill TreeView node with child nodes
            for (int i = 0; i < nodesQty; i++)
            {
                junkMailNode.Nodes.Add("Email message");
            }
            // Add node to TreeView
            mobjTreeViewMessages.Nodes.Add(junkMailNode);
            // Generate nodes quantity
            nodesQty = random.Next(1, 4);
            // Create TreeView node
            Gizmox.WebGUI.Forms.TreeNode trashNode = new TreeNode(string.Format("Trash ({0})", nodesQty), 4, 4);
            // Fill TreeView node with child nodes
            for (int i = 0; i < nodesQty; i++)
            {
                trashNode.Nodes.Add("Email message");
            }
            // Add node to TreeView
            mobjTreeViewMessages.Nodes.Add(trashNode);
        }
    }
}