namespace CompanionKit.Controls.MainMenu.Features
{
    partial class IconsPage
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
            this.openFormWithMainMenuButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFormWithMainMenuButton
            // 
            this.openFormWithMainMenuButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.openFormWithMainMenuButton.Location = new System.Drawing.Point(35, 155);
            this.openFormWithMainMenuButton.Name = "openFormWithMainMenuButton";
            this.openFormWithMainMenuButton.Size = new System.Drawing.Size(250, 90);
            this.openFormWithMainMenuButton.TabIndex = 0;
            this.openFormWithMainMenuButton.Text = "Open Form with MainMenu that supports Menu Item icons";
            this.openFormWithMainMenuButton.UseVisualStyleBackColor = true;
            this.openFormWithMainMenuButton.Click += new System.EventHandler(this.openFormWithMainMenuButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.openFormWithMainMenuButton, 0, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 1;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 1;
            // 
            // IconsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "IconsPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button openFormWithMainMenuButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}