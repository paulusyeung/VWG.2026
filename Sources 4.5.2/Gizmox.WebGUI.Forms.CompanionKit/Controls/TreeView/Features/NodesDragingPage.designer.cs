using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TreeView.Features
{
    partial class NodesDragingPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjTreeView = new Gizmox.WebGUI.Forms.TreeView();
            this.mobjAllowedDropListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjTreeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode4 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode5 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode6 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode7 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode8 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode9 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjDraggedTreeViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjAllowedTreeViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjUnallowedDropListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjUnallowedTreeViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjAllowedTreeViewPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjUnallowedTreeViewPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTreeViewPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjAllowedTreeViewPanel.SuspendLayout();
            this.mobjUnallowedTreeViewPanel.SuspendLayout();
            this.mobjTreeViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeView.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
        ((Gizmox.WebGUI.Forms.Component)(this.mobjAllowedDropListBox))};
            this.mobjTreeView.Location = new System.Drawing.Point(0, 0);
            this.mobjTreeView.Name = "mobjTreeView";
            this.mobjTreeView.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode1,
            this.mobjTreeNode2,
            this.mobjTreeNode3});
            this.mobjTreeView.Size = new System.Drawing.Size(177, 95);
            this.mobjTreeView.TabIndex = 0;
            // 
            // mobjAllowedDropListBox
            // 
            this.mobjAllowedDropListBox.AllowDrop = true;
            this.mobjAllowedDropListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowedDropListBox.Location = new System.Drawing.Point(0, 0);
            this.mobjAllowedDropListBox.Name = "mobjAllowedDropListBox";
            this.mobjAllowedDropListBox.Size = new System.Drawing.Size(177, 95);
            this.mobjAllowedDropListBox.TabIndex = 1;
            this.mobjAllowedDropListBox.DragDrop += new Gizmox.WebGUI.Forms.DragEventHandler(this.mobjAllowedDropListBox_DragDrop);
            // 
            // mobjTreeNode1
            // 
            this.mobjTreeNode1.Name = "treeNode1";
            this.mobjTreeNode1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode4});
            this.mobjTreeNode1.Text = "Tree Node1";
            // 
            // mobjTreeNode4
            // 
            this.mobjTreeNode4.Name = "treeNode4";
            this.mobjTreeNode4.Text = "Tree Node4";
            // 
            // mobjTreeNode2
            // 
            this.mobjTreeNode2.Name = "treeNode2";
            this.mobjTreeNode2.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode5,
            this.mobjTreeNode6});
            this.mobjTreeNode2.Text = "Tree Node2";
            // 
            // mobjTreeNode5
            // 
            this.mobjTreeNode5.Name = "treeNode5";
            this.mobjTreeNode5.Text = "Tree Node5";
            // 
            // mobjTreeNode6
            // 
            this.mobjTreeNode6.Name = "treeNode6";
            this.mobjTreeNode6.Text = "Tree Node6";
            // 
            // mobjTreeNode3
            // 
            this.mobjTreeNode3.Name = "treeNode3";
            this.mobjTreeNode3.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode7,
            this.mobjTreeNode8,
            this.mobjTreeNode9});
            this.mobjTreeNode3.Text = "Tree Node3";
            // 
            // mobjTreeNode7
            // 
            this.mobjTreeNode7.Name = "treeNode7";
            this.mobjTreeNode7.Text = "Tree Node7";
            // 
            // mobjTreeNode8
            // 
            this.mobjTreeNode8.Name = "treeNode8";
            this.mobjTreeNode8.Text = "Tree Node8";
            // 
            // mobjTreeNode9
            // 
            this.mobjTreeNode9.Name = "treeNode9";
            this.mobjTreeNode9.Text = "Tree Node9";
            // 
            // mobjDraggedTreeViewLabel
            // 
            this.mobjDraggedTreeViewLabel.AutoSize = true;
            this.mobjDraggedTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDraggedTreeViewLabel.Location = new System.Drawing.Point(20, 15);
            this.mobjDraggedTreeViewLabel.Name = "mobjDraggedTreeViewLabel";
            this.mobjDraggedTreeViewLabel.Size = new System.Drawing.Size(177, 50);
            this.mobjDraggedTreeViewLabel.TabIndex = 2;
            this.mobjDraggedTreeViewLabel.Text = "Dragged TreeView";
            this.mobjDraggedTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjAllowedTreeViewLabel
            // 
            this.mobjAllowedTreeViewLabel.AutoSize = true;
            this.mobjAllowedTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowedTreeViewLabel.Location = new System.Drawing.Point(217, 15);
            this.mobjAllowedTreeViewLabel.Name = "mobjAllowedTreeViewLabel";
            this.mobjAllowedTreeViewLabel.Size = new System.Drawing.Size(177, 50);
            this.mobjAllowedTreeViewLabel.TabIndex = 3;
            this.mobjAllowedTreeViewLabel.Text = "Allowed drop";
            this.mobjAllowedTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjUnallowedDropListBox
            // 
            this.mobjUnallowedDropListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjUnallowedDropListBox.Location = new System.Drawing.Point(0, 0);
            this.mobjUnallowedDropListBox.Name = "mobjUnallowedDropListBox";
            this.mobjUnallowedDropListBox.Size = new System.Drawing.Size(177, 95);
            this.mobjUnallowedDropListBox.TabIndex = 5;
            // 
            // mobjUnallowedTreeViewLabel
            // 
            this.mobjUnallowedTreeViewLabel.AutoSize = true;
            this.mobjUnallowedTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjUnallowedTreeViewLabel.Location = new System.Drawing.Point(414, 15);
            this.mobjUnallowedTreeViewLabel.Name = "mobjUnallowedTreeViewLabel";
            this.mobjUnallowedTreeViewLabel.Size = new System.Drawing.Size(177, 50);
            this.mobjUnallowedTreeViewLabel.TabIndex = 6;
            this.mobjUnallowedTreeViewLabel.Text = "Unallowed drop";
            this.mobjUnallowedTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 7;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjUnallowedTreeViewLabel, 5, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjAllowedTreeViewLabel, 3, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDraggedTreeViewLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjAllowedTreeViewPanel, 3, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjUnallowedTreeViewPanel, 5, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjTreeViewPanel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(613, 219);
            this.mobjLayoutPanel.TabIndex = 7;
            // 
            // mobjAllowedTreeViewPanel
            // 
            this.mobjAllowedTreeViewPanel.Controls.Add(this.mobjAllowedDropListBox);
            this.mobjAllowedTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowedTreeViewPanel.Location = new System.Drawing.Point(217, 75);
            this.mobjAllowedTreeViewPanel.Name = "mobjAllowedTreeViewPanel";
            this.mobjAllowedTreeViewPanel.Size = new System.Drawing.Size(177, 95);
            this.mobjAllowedTreeViewPanel.TabIndex = 0;
            // 
            // mobjUnallowedTreeViewPanel
            // 
            this.mobjUnallowedTreeViewPanel.Controls.Add(this.mobjUnallowedDropListBox);
            this.mobjUnallowedTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjUnallowedTreeViewPanel.Location = new System.Drawing.Point(414, 75);
            this.mobjUnallowedTreeViewPanel.Name = "mobjUnallowedTreeViewPanel";
            this.mobjUnallowedTreeViewPanel.Size = new System.Drawing.Size(177, 95);
            this.mobjUnallowedTreeViewPanel.TabIndex = 0;
            // 
            // mobjTreeViewPanel
            // 
            this.mobjTreeViewPanel.Controls.Add(this.mobjTreeView);
            this.mobjTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeViewPanel.Location = new System.Drawing.Point(20, 75);
            this.mobjTreeViewPanel.Name = "mobjTreeViewPanel";
            this.mobjTreeViewPanel.Size = new System.Drawing.Size(177, 95);
            this.mobjTreeViewPanel.TabIndex = 0;
            // 
            // NodesDragingPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(613, 219);
            this.Text = "NodesDragingPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjAllowedTreeViewPanel.ResumeLayout(false);
            this.mobjUnallowedTreeViewPanel.ResumeLayout(false);
            this.mobjTreeViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.TreeView mobjTreeView;
        private global::Gizmox.WebGUI.Forms.ListBox mobjAllowedDropListBox;
        private TreeNode mobjTreeNode1;
        private TreeNode mobjTreeNode2;
        private TreeNode mobjTreeNode3;
        private global::Gizmox.WebGUI.Forms.Label mobjDraggedTreeViewLabel;
        private global::Gizmox.WebGUI.Forms.Label mobjAllowedTreeViewLabel;
        private TreeNode mobjTreeNode4;
        private TreeNode mobjTreeNode5;
        private TreeNode mobjTreeNode6;
        private TreeNode mobjTreeNode7;
        private TreeNode mobjTreeNode8;
        private TreeNode mobjTreeNode9;
        private Gizmox.WebGUI.Forms.ListBox mobjUnallowedDropListBox;
        private Label mobjUnallowedTreeViewLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjAllowedTreeViewPanel;
        private Gizmox.WebGUI.Forms.Panel mobjUnallowedTreeViewPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTreeViewPanel;



    }
}
