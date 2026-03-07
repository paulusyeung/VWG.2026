using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TreeView.Features
{
    partial class TreeViewItemsSortingPage
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
            this.mobjSortCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTreeViewPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjInfoLabelPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTreeViewPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.mobjInfoLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTreeView
            // 
            this.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeView.Location = new System.Drawing.Point(0, 0);
            this.mobjTreeView.Name = "mobjTreeView";
            this.mobjTreeView.Size = new System.Drawing.Size(392, 161);
            this.mobjTreeView.TabIndex = 0;
	    this.mobjTreeView.Nodes.AddRange(new TreeNode[] {
                 new TreeNode("A item"),
                 new TreeNode("X item"),
                 new TreeNode("Y item"),
                 new TreeNode("I item"),
                 new TreeNode("J item"),
                 new TreeNode("K item"),
                 new TreeNode("L item"),
                 new TreeNode("M item"),
                 new TreeNode("N item"),
                 new TreeNode("O item"),
                 new TreeNode("B item"),
                 new TreeNode("C item"),
                 new TreeNode("T item"),
                 new TreeNode("U item"),
                 new TreeNode("V item"),
                 new TreeNode("D item"),
                 new TreeNode("H item"),
                 new TreeNode("E item"),
                 new TreeNode("F item"),
                 new TreeNode("G item"),
                 new TreeNode("P item"),
                 new TreeNode("Q item"),
                 new TreeNode("R item"),
                 new TreeNode("S item"),
                 new TreeNode("W item"),
                 new TreeNode("Z item")
                });
            // 
            // mobjSortCheckBox
            // 
            this.mobjSortCheckBox.AutoSize = true;
            this.mobjSortCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjSortCheckBox.Location = new System.Drawing.Point(0, 0);
            this.mobjSortCheckBox.Name = "mobjSortCheckBox";
            this.mobjSortCheckBox.Size = new System.Drawing.Size(58, 20);
            this.mobjSortCheckBox.TabIndex = 1;
            this.mobjSortCheckBox.Text = "Sorted";
            this.mobjSortCheckBox.CheckedChanged += new System.EventHandler(this.mobjSortCheckBox_CheckedChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(109, 13);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "Nodes are not sorted";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTreeViewPanel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 3, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoLabelPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(580, 285);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // mobjTreeViewPanel
            // 
            this.mobjTreeViewPanel.Controls.Add(this.mobjTreeView);
            this.mobjTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeViewPanel.Location = new System.Drawing.Point(49, 53);
            this.mobjTreeViewPanel.Name = "mobjTreeViewPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjTreeViewPanel, 2);
            this.mobjTreeViewPanel.Size = new System.Drawing.Size(392, 161);
            this.mobjTreeViewPanel.TabIndex = 0;
            // 
            // mobjPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjPanel, 2);
            this.mobjPanel.Controls.Add(this.mobjSortCheckBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(451, 53);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(129, 20);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjInfoLabelPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjInfoLabelPanel, 3);
            this.mobjInfoLabelPanel.Controls.Add(this.mobjLabel);
            this.mobjInfoLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabelPanel.Location = new System.Drawing.Point(49, 23);
            this.mobjInfoLabelPanel.Name = "mobjInfoLabelPanel";
            this.mobjInfoLabelPanel.Size = new System.Drawing.Size(482, 20);
            this.mobjInfoLabelPanel.TabIndex = 0;
            // 
            // TreeViewItemsSortingPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(580, 285);
            this.Text = "TreeViewItemsSortingPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTreeViewPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.mobjInfoLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView mobjTreeView;
        private Gizmox.WebGUI.Forms.CheckBox mobjSortCheckBox;
        private Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTreeViewPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Panel mobjInfoLabelPanel;



    }
}