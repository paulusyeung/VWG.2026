namespace CompanionKit.Controls.WorkspaceTabs.PopulatingData
{
    partial class TabPagesCollectionPage
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
            this.mobjWorkspaceTabs = new Gizmox.WebGUI.Forms.WorkspaceTabs();
            this.mobjWorkspaceTab1 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.mobjWorkspaceTab2 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.mobjWorkspaceTab3 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjWorkspaceTabs)).BeginInit();
            this.mobjWorkspaceTabs.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWorkspaceTabs
            // 
            this.mobjWorkspaceTabs.Controls.Add(this.mobjWorkspaceTab1);
            this.mobjWorkspaceTabs.Controls.Add(this.mobjWorkspaceTab2);
            this.mobjWorkspaceTabs.Controls.Add(this.mobjWorkspaceTab3);
            this.mobjWorkspaceTabs.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWorkspaceTabs.Location = new System.Drawing.Point(0, 90);
            this.mobjWorkspaceTabs.Name = "mobjWorkspaceTabs";
            this.mobjWorkspaceTabs.SelectedIndex = 0;
            this.mobjWorkspaceTabs.Size = new System.Drawing.Size(535, 171);
            this.mobjWorkspaceTabs.TabIndex = 0;
            this.mobjWorkspaceTabs.CloseClick += new System.EventHandler(this.mobjWorkspaceTabs_CloseClick);
            // 
            // mobjWorkspaceTab1
            // 
            this.mobjWorkspaceTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mobjWorkspaceTab1.CustomStyle = "Workspace";
            this.mobjWorkspaceTab1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWorkspaceTab1.Location = new System.Drawing.Point(0, 0);
            this.mobjWorkspaceTab1.Name = "mobjWorkspaceTab1";
            this.mobjWorkspaceTab1.Size = new System.Drawing.Size(527, 145);
            this.mobjWorkspaceTab1.TabIndex = 0;
            this.mobjWorkspaceTab1.Text = "workspaceTab1";
            // 
            // mobjWorkspaceTab2
            // 
            this.mobjWorkspaceTab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mobjWorkspaceTab2.CustomStyle = "Workspace";
            this.mobjWorkspaceTab2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWorkspaceTab2.Location = new System.Drawing.Point(0, 0);
            this.mobjWorkspaceTab2.Name = "mobjWorkspaceTab2";
            this.mobjWorkspaceTab2.Size = new System.Drawing.Size(696, 145);
            this.mobjWorkspaceTab2.TabIndex = 1;
            this.mobjWorkspaceTab2.Text = "workspaceTab2";
            // 
            // mobjWorkspaceTab3
            // 
            this.mobjWorkspaceTab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mobjWorkspaceTab3.CustomStyle = "Workspace";
            this.mobjWorkspaceTab3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWorkspaceTab3.Location = new System.Drawing.Point(0, 0);
            this.mobjWorkspaceTab3.Name = "mobjWorkspaceTab3";
            this.mobjWorkspaceTab3.Size = new System.Drawing.Size(527, 145);
            this.mobjWorkspaceTab3.TabIndex = 2;
            this.mobjWorkspaceTab3.Text = "workspaceTab3";
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjAddButton);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.DockPadding.Bottom = 10;
            this.mobjTopPanel.DockPadding.Top = 10;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjTopPanel.Size = new System.Drawing.Size(535, 70);
            this.mobjTopPanel.TabIndex = 1;
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddButton.Location = new System.Drawing.Point(0, 10);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(535, 50);
            this.mobjAddButton.TabIndex = 0;
            this.mobjAddButton.Text = "Add item";
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjWorkspaceTabs, 0, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(535, 261);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // TabPagesCollectionPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.DockPadding.All = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(565, 291);
            this.Text = "TabPagesCollectionPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjWorkspaceTabs)).EndInit();
            this.mobjWorkspaceTabs.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.WorkspaceTabs mobjWorkspaceTabs;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.WorkspaceTab mobjWorkspaceTab1;
        private Gizmox.WebGUI.Forms.WorkspaceTab mobjWorkspaceTab2;
        private Gizmox.WebGUI.Forms.WorkspaceTab mobjWorkspaceTab3;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}