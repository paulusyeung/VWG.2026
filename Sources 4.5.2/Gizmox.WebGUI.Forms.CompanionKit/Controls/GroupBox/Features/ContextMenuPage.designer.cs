using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.GroupBox.Features
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
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.mobjMenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjContainerPanel.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.ContextMenu = this.mobjContextMenu;
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(144, 37);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(288, 75);
            this.mobjGroupBox.TabIndex = 0;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "GroupBox";
            // 
            // mobjContextMenu
            // 
            this.mobjContextMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuItem1,
            this.mobjMenuItem4,
            this.mobjMenuItem5});
            // 
            // mobjMenuItem1
            // 
            this.mobjMenuItem1.Index = 0;
            this.mobjMenuItem1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuItem2,
            this.mobjMenuItem3});
            this.mobjMenuItem1.Text = "Menu Item1";
            this.mobjMenuItem1.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // mobjMenuItem2
            // 
            this.mobjMenuItem2.Index = 0;
            this.mobjMenuItem2.Text = "Menu Sub Item1";
            this.mobjMenuItem2.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // mobjMenuItem3
            // 
            this.mobjMenuItem3.Index = 1;
            this.mobjMenuItem3.Text = "Menu Sub Item2";
            this.mobjMenuItem3.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // mobjMenuItem4
            // 
            this.mobjMenuItem4.Index = 1;
            this.mobjMenuItem4.Text = "Menu Item2";
            this.mobjMenuItem4.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // mobjMenuItem5
            // 
            this.mobjMenuItem5.Index = 2;
            this.mobjMenuItem5.Text = "Menu Item3";
            this.mobjMenuItem5.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(165, 13);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Right click to see a context menu";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjContainerPanel
            // 
            this.mobjContainerPanel.Controls.Add(this.mobjLabel);
            this.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerPanel.Location = new System.Drawing.Point(144, 112);
            this.mobjContainerPanel.Name = "mobjContainerPanel";
            this.mobjContainerPanel.Size = new System.Drawing.Size(288, 50);
            this.mobjContainerPanel.TabIndex = 2;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjContainerPanel, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjGroupBox, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 4;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(576, 200);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // ContextMenuPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(576, 200);
            this.Text = "ContextMenuPage";
            this.mobjContainerPanel.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private global::Gizmox.WebGUI.Forms.ContextMenu mobjContextMenu;
        private MenuItem mobjMenuItem1;
        private MenuItem mobjMenuItem2;
        private MenuItem mobjMenuItem3;
        private MenuItem mobjMenuItem4;
        private MenuItem mobjMenuItem5;
        private Label mobjLabel;
        private Gizmox.WebGUI.Forms.Panel mobjContainerPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
