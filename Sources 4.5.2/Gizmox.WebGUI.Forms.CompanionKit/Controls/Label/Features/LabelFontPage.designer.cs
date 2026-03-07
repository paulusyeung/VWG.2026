namespace CompanionKit.Controls.LabelFolder.Features
{
    partial class LabelFontPage
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
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel3 = new Gizmox.WebGUI.Forms.Label();
            this.mobjButton1 = new Gizmox.WebGUI.Forms.Button();
            this.mobjButton2 = new Gizmox.WebGUI.Forms.Button();
            this.mobjButton3 = new Gizmox.WebGUI.Forms.Button();
            this.fontDialog1 = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjLabel1.Location = new System.Drawing.Point(210, 10);
            this.mobjLabel1.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(140, 96);
            this.mobjLabel1.TabIndex = 0;
            this.mobjLabel1.Text = "Label Text";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjLabel2.Location = new System.Drawing.Point(170, 126);
            this.mobjLabel2.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(140, 96);
            this.mobjLabel2.TabIndex = 1;
            this.mobjLabel2.Text = "Label Text";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLabel3
            // 
            this.mobjLabel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjLabel3.Location = new System.Drawing.Point(170, 242);
            this.mobjLabel3.Margin = new Gizmox.WebGUI.Forms.Padding(10);
            this.mobjLabel3.Name = "mobjLabel3";
            this.mobjLabel3.Size = new System.Drawing.Size(140, 98);
            this.mobjLabel3.TabIndex = 2;
            this.mobjLabel3.Text = "Label Text";
            this.mobjLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjButton1
            // 
            this.mobjButton1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton1.Location = new System.Drawing.Point(15, 15);
            this.mobjButton1.Margin = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjButton1.Name = "mobjButton1";
            this.mobjButton1.Size = new System.Drawing.Size(130, 86);
            this.mobjButton1.TabIndex = 3;
            this.mobjButton1.Text = "Set font";
            this.mobjButton1.UseVisualStyleBackColor = true;
            this.mobjButton1.Click += new System.EventHandler(this.mobjButton1_Click);
            // 
            // mobjButton2
            // 
            this.mobjButton2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton2.Location = new System.Drawing.Point(15, 131);
            this.mobjButton2.Margin = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjButton2.Name = "mobjButton2";
            this.mobjButton2.Size = new System.Drawing.Size(130, 86);
            this.mobjButton2.TabIndex = 4;
            this.mobjButton2.Text = "Set font";
            this.mobjButton2.UseVisualStyleBackColor = true;
            this.mobjButton2.Click += new System.EventHandler(this.mobjButton2_Click);
            // 
            // mobjButton3
            // 
            this.mobjButton3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton3.Location = new System.Drawing.Point(15, 247);
            this.mobjButton3.Margin = new Gizmox.WebGUI.Forms.Padding(15);
            this.mobjButton3.Name = "mobjButton3";
            this.mobjButton3.Size = new System.Drawing.Size(130, 88);
            this.mobjButton3.TabIndex = 5;
            this.mobjButton3.Text = "Set font";
            this.mobjButton3.UseVisualStyleBackColor = true;
            this.mobjButton3.Click += new System.EventHandler(this.mobjButton3_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.MaxSize = 72;
            this.fontDialog1.MinSize = 8;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjButton1, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjLabel3, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjButton3, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjLabel2, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjButton2, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjLabel1, 1, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 6;
            // 
            // LabelFontPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "LabelFontPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjLabel1;
        private Gizmox.WebGUI.Forms.Label mobjLabel2;
        private Gizmox.WebGUI.Forms.Label mobjLabel3;
        private Gizmox.WebGUI.Forms.Button mobjButton1;
        private Gizmox.WebGUI.Forms.Button mobjButton2;
        private Gizmox.WebGUI.Forms.Button mobjButton3;
        private Gizmox.WebGUI.Forms.FontDialog fontDialog1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}