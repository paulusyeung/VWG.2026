namespace CompanionKit.Controls.Button.Functionality
{
    partial class DropDownMenuPage
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
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButton
            // 
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButton.DropDownMenu = this.contextMenu1;
            this.mobjButton.Location = new System.Drawing.Point(46, 87);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(228, 76);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "Button with DropDown Menu";
            this.mobjButton.UseVisualStyleBackColor = true;
            // 
            // contextMenu1
            // 
            this.contextMenu1.AllowDrop = true;
            this.contextMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
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
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "MenuItem4";
            this.menuItem4.Click += new System.EventHandler(this.menuItem_Click);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 50);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Button with defined DropDownMenu property as ContextMenu:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjButton, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 200);
            this.mobjTLP.TabIndex = 2;
            // 
            // DropDownMenuPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 200);
            this.Text = "DropDownMenuPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.ContextMenu contextMenu1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem2;
        private Gizmox.WebGUI.Forms.MenuItem menuItem3;
        private Gizmox.WebGUI.Forms.MenuItem menuItem4;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
