using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TreeView.Features
{
    partial class CheckBoxesPage
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
            this.mobjTreeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode4 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode5 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode6 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode7 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode8 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode9 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AutoSize = true;
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(136, 31);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(273, 50);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "TreeView with CheckBoxes";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.CheckBoxes = true;
            this.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeView.Location = new System.Drawing.Point(136, 101);
            this.mobjTreeView.Name = "mobjTreeView";
            this.mobjTreeView.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode1,
            this.mobjTreeNode2,
            this.mobjTreeNode3});
            this.mobjTreeView.Size = new System.Drawing.Size(273, 95);
            this.mobjTreeView.TabIndex = 1;
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
            // mobjCheckBox
            // 
            this.mobjCheckBox.AutoSize = true;
            this.mobjCheckBox.Checked = true;
            this.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjCheckBox.Location = new System.Drawing.Point(136, 216);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(84, 17);
            this.mobjCheckBox.TabIndex = 2;
            this.mobjCheckBox.Text = "CheckBoxes";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjTreeView, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjCheckBox, 1, 5);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(546, 289);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // CheckBoxesPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(546, 289);
            this.Text = "CheckBoxesPage";
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
        private TreeNode mobjTreeNode9;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
