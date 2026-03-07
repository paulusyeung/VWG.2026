using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ToolBar.Appearance
{
    partial class ToolBarButtonStylePage
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
            this.toolBar1 = new Gizmox.WebGUI.Forms.ToolBar();
            this.toolBarButton1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton2 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton3 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.toolBar1.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar1.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3});
            this.toolBar1.ButtonSize = new System.Drawing.Size(0, 22);
            this.toolBar1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.toolBar1.DragHandle = true;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageSize = new System.Drawing.Size(16, 16);
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.MenuHandle = true;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(391, 42);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Text = "Push";
            this.toolBarButton1.ToolTipText = "";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.CustomStyle = "";
            this.toolBarButton2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Size = 50;
            this.toolBarButton2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.ToggleButton;
            this.toolBarButton2.Text = "Toggle";
            this.toolBarButton2.ToolTipText = "";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.CustomStyle = "";
            this.toolBarButton3.DropDownMenu = this.contextMenu1;
            this.toolBarButton3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Size = 24;
            this.toolBarButton3.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.DropDownButton;
            this.toolBarButton3.Text = "DropDown";
            this.toolBarButton3.ToolTipText = "";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "MenuItem1";
            this.menuItem1.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "MenuItem2";
            this.menuItem2.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "MenuItem3";
            this.menuItem3.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // ToolBarButtonStylePage
            // 
            this.Controls.Add(this.toolBar1);
            this.Size = new System.Drawing.Size(391, 87);
            this.Text = "ToolBarButtonStylePage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar toolBar1;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton1;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton2;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton3;
        private Gizmox.WebGUI.Forms.ContextMenu contextMenu1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem2;
        private Gizmox.WebGUI.Forms.MenuItem menuItem3;



    }
}
