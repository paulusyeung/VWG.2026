using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ToolBar.Functionality
{
    partial class RegisterClientActionPage
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
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Text = "VisualWebGUI";
            this.toolBarButton1.ToolTipText = "";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.CustomStyle = "";
            this.toolBarButton2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Size = 24;
            this.toolBarButton2.Text = "Google";
            this.toolBarButton2.ToolTipText = "";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.CustomStyle = "";
            this.toolBarButton3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Size = 24;
            this.toolBarButton3.Text = "Microsoft";
            this.toolBarButton3.ToolTipText = "";
            // 
            // RegisterClientActionPage
            // 
            this.Controls.Add(this.toolBar1);
            this.Size = new System.Drawing.Size(391, 87);
            this.Text = "RegisterClientActionPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar toolBar1;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton1;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton2;
        private Gizmox.WebGUI.Forms.ToolBarButton toolBarButton3;



    }
}
