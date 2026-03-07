using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ContextMenu.Programming
{
    partial class PopupPage
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
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.mobjMenuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjDescriptionLabel.ContextMenu = this.mobjContextMenu;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(15, 16);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(606, 110);
            this.mobjDescriptionLabel.TabIndex = 0;
            // 
            // mobjContextMenu
            // 
            this.mobjContextMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuItem1,
            this.mobjMenuItem2,
            this.mobjMenuItem3});
            this.mobjContextMenu.Collapse += new System.EventHandler(this.mobjContextMenu_Collapse);
            this.mobjContextMenu.Popup += new System.EventHandler(this.mobjContextMenu_Popup);
            // 
            // mobjMenuItem1
            // 
            this.mobjMenuItem1.Index = 0;
            this.mobjMenuItem1.Text = "Menu Item1";
            this.mobjMenuItem1.Click += new System.EventHandler(this.mobjMenuItem_Click);
            // 
            // mobjMenuItem2
            // 
            this.mobjMenuItem2.Index = 1;
            this.mobjMenuItem2.Text = "Menu Item2";
            this.mobjMenuItem2.Click += new System.EventHandler(this.mobjMenuItem_Click);
            // 
            // mobjMenuItem3
            // 
            this.mobjMenuItem3.Index = 2;
            this.mobjMenuItem3.Text = "Menu Item3";
            this.mobjMenuItem3.Click += new System.EventHandler(this.mobjMenuItem_Click);
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.ContextMenu = this.mobjContextMenu;
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Location = new System.Drawing.Point(127, 110);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(382, 63);
            this.mobjLabel2.TabIndex = 1;
            this.mobjLabel2.Text = "Represents information about selected menu item";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.AutoSize = true;
            this.mobjLabel1.ContextMenu = this.mobjContextMenu;
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Font = new System.Drawing.Font("Tahoma", 12.25F, System.Drawing.FontStyle.Bold);
            this.mobjLabel1.Location = new System.Drawing.Point(127, 27);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(382, 63);
            this.mobjLabel1.TabIndex = 2;
            this.mobjLabel1.Text = "Right click to see a context menu";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ContextMenu = this.mobjContextMenu;
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel1, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel2, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(637, 200);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // PopupPage
            // 
            this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.ContextMenu = this.mobjContextMenu;
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(637, 200);
            this.Text = "PopupPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private global::Gizmox.WebGUI.Forms.Label mobjLabel2;
        private global::Gizmox.WebGUI.Forms.ContextMenu mobjContextMenu;
        private MenuItem mobjMenuItem1;
        private MenuItem mobjMenuItem2;
        private MenuItem mobjMenuItem3;
        private global::Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
