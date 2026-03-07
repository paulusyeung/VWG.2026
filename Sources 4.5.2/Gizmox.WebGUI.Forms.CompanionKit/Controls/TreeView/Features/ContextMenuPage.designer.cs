using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TreeView.Features
{
    partial class ContextMenuPage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTreeView = new Gizmox.WebGUI.Forms.TreeView();
            this.mobjContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.mobjAddNodeMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjRemoveNadeMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjViewNodeMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjTreeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode4 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode5 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode6 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode7 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode8 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AutoSize = true;
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(46, 13);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(371, 50);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "TreeView with ContextMenu";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.ContextMenu = this.mobjContextMenu;
            this.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeView.Location = new System.Drawing.Point(46, 73);
            this.mobjTreeView.Name = "mobjTreeView";
            this.mobjTreeView.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode1,
            this.mobjTreeNode2,
            this.mobjTreeNode3});
            this.mobjTreeView.Size = new System.Drawing.Size(371, 82);
            this.mobjTreeView.TabIndex = 1;
            // 
            // mobjContextMenu
            // 
            this.mobjContextMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjAddNodeMenuItem,
            this.mobjRemoveNadeMenuItem,
            this.mobjViewNodeMenuItem});
            this.mobjContextMenu.Popup += new System.EventHandler(this.mobjContextMenu_Popup);
            // 
            // mobjAddNodeMenuItem
            // 
            this.mobjAddNodeMenuItem.Index = 0;
            this.mobjAddNodeMenuItem.Text = "Add new node";
            this.mobjAddNodeMenuItem.Click += new System.EventHandler(this.mobjAddNodeMenuItem_Click);
            // 
            // mobjRemoveNadeMenuItem
            // 
            this.mobjRemoveNadeMenuItem.Index = 1;
            this.mobjRemoveNadeMenuItem.Text = "Remove selected node";
            this.mobjRemoveNadeMenuItem.Click += new System.EventHandler(this.mobjRemoveNadeMenuItem_Click);
            // 
            // mobjViewNodeMenuItem
            // 
            this.mobjViewNodeMenuItem.Index = 2;
            this.mobjViewNodeMenuItem.Text = "View selected node";
            this.mobjViewNodeMenuItem.Click += new System.EventHandler(this.mobjViewNodeMenuItem_Click);
            // 
            // mobjTreeNode1
            // 
            this.mobjTreeNode1.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode1.Name = "treeNode1";
            this.mobjTreeNode1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode4});
            this.mobjTreeNode1.Text = "Tree Node1";
            // 
            // mobjTreeNode4
            // 
            this.mobjTreeNode4.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode4.Name = "treeNode4";
            this.mobjTreeNode4.Text = "Tree Node4";
            // 
            // mobjTreeNode2
            // 
            this.mobjTreeNode2.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode2.Name = "treeNode2";
            this.mobjTreeNode2.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode5,
            this.mobjTreeNode6});
            this.mobjTreeNode2.Text = "Tree Node2";
            // 
            // mobjTreeNode5
            // 
            this.mobjTreeNode5.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode5.Name = "treeNode5";
            this.mobjTreeNode5.Text = "Tree Node5";
            // 
            // mobjTreeNode6
            // 
            this.mobjTreeNode6.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode6.Name = "treeNode6";
            this.mobjTreeNode6.Text = "Tree Node6";
            // 
            // mobjTreeNode3
            // 
            this.mobjTreeNode3.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode3.Name = "treeNode3";
            this.mobjTreeNode3.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode7,
            this.mobjTreeNode8});
            this.mobjTreeNode3.Text = "Tree Node3";
            // 
            // mobjTreeNode7
            // 
            this.mobjTreeNode7.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode7.Name = "treeNode7";
            this.mobjTreeNode7.Text = "Tree Node7";
            // 
            // mobjTreeNode8
            // 
            this.mobjTreeNode8.ContextMenu = this.mobjContextMenu;
            this.mobjTreeNode8.Name = "treeNode8";
            this.mobjTreeNode8.Text = "Tree Node8";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTreeView, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(464, 197);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // ContextMenuPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(464, 197);
            this.Text = "ContextMenuPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private global::Gizmox.WebGUI.Forms.TreeView mobjTreeView;
        private TreeNode mobjTreeNode1;
        private TreeNode mobjTreeNode4;
        private TreeNode mobjTreeNode2;
        private TreeNode mobjTreeNode5;
        private TreeNode mobjTreeNode6;
        private TreeNode mobjTreeNode3;
        private TreeNode mobjTreeNode7;
        private TreeNode mobjTreeNode8;
        private global::Gizmox.WebGUI.Forms.ContextMenu mobjContextMenu;
        private MenuItem mobjAddNodeMenuItem;
        private MenuItem mobjRemoveNadeMenuItem;
        private MenuItem mobjViewNodeMenuItem;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
