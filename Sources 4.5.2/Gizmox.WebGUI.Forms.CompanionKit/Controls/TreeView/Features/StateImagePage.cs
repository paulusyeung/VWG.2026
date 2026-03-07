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
    public partial class StateImagePage : UserControl
    {
        public StateImagePage()
        {
            InitializeComponent();

            // Set the image list that is used to indicate the state of the TreeView and its nodes.
            this.mobjTreeView.StateImageList = new ImageList();
            this.mobjTreeView.StateImageList.Images.Add(new global::Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.DefaultTreeNode.gif"));
            this.mobjTreeView.StateImageList.Images.Add(new global::Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.SelectedTreeNode.gif"));
        }
    }
}