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
    public partial class SelectedImagePage : UserControl
    {
        public SelectedImagePage()
        {
            InitializeComponent();            
            
            // Sets image list that is used for TreeView node
            this.mobjTreeView.ImageList = new ImageList();
            this.mobjTreeView.ImageList.Images.Add(new global::Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.SelectedTreeNode.gif"));
            this.mobjTreeView.ImageList.Images.Add(new global::Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.DefaultTreeNode.gif"));
            
            // Sets image index for tree node of normal and selected node.
            this.mobjTreeView.ImageIndex = 1;
            this.mobjTreeView.SelectedImageIndex = 0;
        }
    }
}