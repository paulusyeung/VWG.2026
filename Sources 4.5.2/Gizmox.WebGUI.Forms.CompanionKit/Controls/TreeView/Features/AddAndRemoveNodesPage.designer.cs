using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TreeView.Features
{
    partial class AddAndRemoveNodesPage
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
            this.mobjTreeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.mobjTreeViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNodeNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjRemoveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobLabelPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeView.Location = new System.Drawing.Point(0, 0);
            this.mobjTreeView.Name = "mobjTreeView";
            this.mobjTreeView.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.mobjTreeNode1,
            this.mobjTreeNode2,
            this.mobjTreeNode3});
            this.mobjTreeView.Size = new System.Drawing.Size(434, 63);
            this.mobjTreeView.TabIndex = 0;
            // 
            // mobjTreeNode1
            // 
            this.mobjTreeNode1.Name = "treeNode1";
            this.mobjTreeNode1.Text = "Tree Node1";
            // 
            // mobjTreeNode2
            // 
            this.mobjTreeNode2.Name = "treeNode2";
            this.mobjTreeNode2.Text = "Tree Node2";
            // 
            // mobjTreeNode3
            // 
            this.mobjTreeNode3.Name = "treeNode3";
            this.mobjTreeNode3.Text = "Tree Node3";
            // 
            // mobjTreeViewLabel
            // 
            this.mobjTreeViewLabel.AutoSize = true;
            this.mobjTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTreeViewLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjTreeViewLabel.Name = "mobjTreeViewLabel";
            this.mobjTreeViewLabel.Size = new System.Drawing.Size(100, 13);
            this.mobjTreeViewLabel.TabIndex = 1;
            this.mobjTreeViewLabel.Text = "Extended TreeView";
            // 
            // mobjNodeNameLabel
            // 
            this.mobjNodeNameLabel.AutoSize = true;
            this.mobjNodeNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjNodeNameLabel.Location = new System.Drawing.Point(88, 126);
            this.mobjNodeNameLabel.Name = "mobjNodeNameLabel";
            this.mobjNodeNameLabel.Size = new System.Drawing.Size(207, 13);
            this.mobjNodeNameLabel.TabIndex = 2;
            this.mobjNodeNameLabel.Text = "Added node name";
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjAddButton.Location = new System.Drawing.Point(88, 186);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(207, 50);
            this.mobjAddButton.TabIndex = 3;
            this.mobjAddButton.Text = "Add a new node";
            this.mobjAddButton.UseVisualStyleBackColor = true;
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjRemoveButton
            // 
            this.mobjRemoveButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjRemoveButton.Location = new System.Drawing.Point(315, 186);
            this.mobjRemoveButton.Name = "mobjRemoveButton";
            this.mobjRemoveButton.Size = new System.Drawing.Size(207, 50);
            this.mobjRemoveButton.TabIndex = 4;
            this.mobjRemoveButton.Text = "Remove selected node";
            this.mobjRemoveButton.UseVisualStyleBackColor = true;
            this.mobjRemoveButton.Click += new System.EventHandler(this.mobjRemoveButton_Click);
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTextBox.Location = new System.Drawing.Point(318, 129);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(201, 30);
            this.mobjTextBox.TabIndex = 5;
            this.mobjTextBox.Text = "Added Node";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjRemoveButton, 3, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjTextBox, 3, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjAddButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjNodeNameLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobLabelPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(612, 251);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // mobjPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjPanel, 3);
            this.mobjPanel.Controls.Add(this.mobjTreeView);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(88, 43);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(434, 63);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobLabelPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobLabelPanel, 3);
            this.mobLabelPanel.Controls.Add(this.mobjTreeViewLabel);
            this.mobLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobLabelPanel.Location = new System.Drawing.Point(88, 13);
            this.mobLabelPanel.Name = "mobLabelPanel";
            this.mobLabelPanel.Size = new System.Drawing.Size(434, 30);
            this.mobLabelPanel.TabIndex = 0;
            // 
            // AddAndRemoveNodesPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(612, 251);
            this.Text = "AddAndRemoveNodesPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.TreeView mobjTreeView;
        private global::Gizmox.WebGUI.Forms.Label mobjTreeViewLabel;
        private global::Gizmox.WebGUI.Forms.Label mobjNodeNameLabel;
        private global::Gizmox.WebGUI.Forms.Button mobjAddButton;
        private global::Gizmox.WebGUI.Forms.Button mobjRemoveButton;
        private global::Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private TreeNode mobjTreeNode1;
        private TreeNode mobjTreeNode2;
        private TreeNode mobjTreeNode3;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobLabelPanel;



    }
}
