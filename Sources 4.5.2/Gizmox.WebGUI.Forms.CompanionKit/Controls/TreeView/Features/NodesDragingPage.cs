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
    public partial class NodesDragingPage : UserControl
    {
        public NodesDragingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles DragDrop event that is fired when a drag-and-drop operation is completed.
        /// Adds draged TreeView node in to ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mobjAllowedDropListBox_DragDrop(object sender, DragEventArgs e)
        {
            DragDropEventArgs mobjDragDropEventArgs = e as DragDropEventArgs;
            if (mobjDragDropEventArgs != null)
            {
                this.mobjAllowedDropListBox.Items.Add(((TreeNode)mobjDragDropEventArgs.Source).Text);
            }
        }
    }
}