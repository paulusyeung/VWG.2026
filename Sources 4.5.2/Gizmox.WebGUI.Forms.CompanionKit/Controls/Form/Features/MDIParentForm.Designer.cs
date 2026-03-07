using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.Form.Features
{
    partial class MDIParentForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjMainMenu = new Gizmox.WebGUI.Forms.MainMenu();
            this.mobjMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjOpenMDIChildFormMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjCloseActiveMDIChildFormMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjCloseAllMDIChildFormsMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mobjMainMenu
            // 
            this.mobjMainMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mobjMainMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjMenuItem});
            this.mobjMainMenu.Name = "mainMenu1";
            this.mobjMainMenu.Size = new System.Drawing.Size(100, 100);
            // 
            // mobjMenuItem
            // 
            this.mobjMenuItem.Index = 0;
            this.mobjMenuItem.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.mobjOpenMDIChildFormMenuItem,
            this.mobjCloseActiveMDIChildFormMenuItem,
            this.mobjCloseAllMDIChildFormsMenuItem});
            this.mobjMenuItem.Text = "Form";
            // 
            // mobjOpenMDIChildFormMenuItem
            // 
            this.mobjOpenMDIChildFormMenuItem.Index = 0;
            this.mobjOpenMDIChildFormMenuItem.Text = "Open MDI Child Form";
            this.mobjOpenMDIChildFormMenuItem.Click += new System.EventHandler(this.mobjOpenMDIChildFormMenuItem_Click);
            // 
            // mobjCloseActiveMDIChildFormMenuItem
            // 
            this.mobjCloseActiveMDIChildFormMenuItem.Enabled = false;
            this.mobjCloseActiveMDIChildFormMenuItem.Index = 1;
            this.mobjCloseActiveMDIChildFormMenuItem.Text = "Close Active MDI Child Form";
            this.mobjCloseActiveMDIChildFormMenuItem.Click += new System.EventHandler(this.mobjCloseActiveMDIChildFormMenuItem_Click);
            // 
            // mobjCloseAllMDIChildFormsMenuItem
            // 
            this.mobjCloseAllMDIChildFormsMenuItem.Enabled = false;
            this.mobjCloseAllMDIChildFormsMenuItem.Index = 2;
            this.mobjCloseAllMDIChildFormsMenuItem.Text = "Close All MDI Child Forms";
            this.mobjCloseAllMDIChildFormsMenuItem.Click += new System.EventHandler(this.mobjCloseAllMDIChildFormsMenuItem_Click);
            // 
            // MDIParentForm
            // 
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.IsMdiContainer = true;
            this.Menu = this.mobjMainMenu;
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "MDIParentForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MainMenu mobjMainMenu;
        private MenuItem mobjMenuItem;
        private MenuItem mobjOpenMDIChildFormMenuItem;
        private MenuItem mobjCloseActiveMDIChildFormMenuItem;
        private MenuItem mobjCloseAllMDIChildFormsMenuItem;


    }
}