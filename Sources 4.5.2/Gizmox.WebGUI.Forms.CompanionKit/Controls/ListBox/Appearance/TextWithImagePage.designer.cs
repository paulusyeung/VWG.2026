namespace CompanionKit.Controls.ListBox.Appearance
{
    partial class TextWithImagePage
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
            this.components = new System.ComponentModel.Container();
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.BindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjImageMemLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjImageTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjValueTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDisplayTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjValueMemLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDisplayMemLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP2 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).BeginInit();
            this.mobjTLP1.SuspendLayout();
            this.mobjTLP2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjListBox.DataSource = this.BindingSource1;
            this.mobjListBox.DisplayMember = "FullName";
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.ImageMember = "Foto";
            this.mobjListBox.Location = new System.Drawing.Point(0, 60);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(320, 199);
            this.mobjListBox.TabIndex = 0;
            this.mobjListBox.ValueMember = "ID";
            // 
            // BindingSource1
            // 
            this.BindingSource1.DataSource = typeof(Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "ListBox with Image:";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjImageMemLabel
            // 
            this.mobjImageMemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjImageMemLabel.Location = new System.Drawing.Point(0, 92);
            this.mobjImageMemLabel.Name = "mobjImageMemLabel";
            this.mobjImageMemLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjImageMemLabel.Size = new System.Drawing.Size(160, 48);
            this.mobjImageMemLabel.TabIndex = 7;
            this.mobjImageMemLabel.Text = "ImageMember";
            this.mobjImageMemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjImageTextBox
            // 
            this.mobjImageTextBox.AllowDrag = false;
            this.mobjImageTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjImageTextBox.Location = new System.Drawing.Point(163, 103);
            this.mobjImageTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjImageTextBox.Name = "mobjImageTextBox";
            this.mobjImageTextBox.ReadOnly = true;
            this.mobjImageTextBox.Size = new System.Drawing.Size(154, 25);
            this.mobjImageTextBox.TabIndex = 6;
            // 
            // mobjValueTextBox
            // 
            this.mobjValueTextBox.AllowDrag = false;
            this.mobjValueTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjValueTextBox.Location = new System.Drawing.Point(163, 56);
            this.mobjValueTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueTextBox.Name = "mobjValueTextBox";
            this.mobjValueTextBox.ReadOnly = true;
            this.mobjValueTextBox.Size = new System.Drawing.Size(154, 25);
            this.mobjValueTextBox.TabIndex = 5;
            // 
            // mobjDisplayTextBox
            // 
            this.mobjDisplayTextBox.AllowDrag = false;
            this.mobjDisplayTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjDisplayTextBox.Location = new System.Drawing.Point(163, 10);
            this.mobjDisplayTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjDisplayTextBox.Name = "mobjDisplayTextBox";
            this.mobjDisplayTextBox.ReadOnly = true;
            this.mobjDisplayTextBox.Size = new System.Drawing.Size(154, 25);
            this.mobjDisplayTextBox.TabIndex = 4;
            // 
            // mobjValueMemLabel
            // 
            this.mobjValueMemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueMemLabel.Location = new System.Drawing.Point(0, 46);
            this.mobjValueMemLabel.Name = "mobjValueMemLabel";
            this.mobjValueMemLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjValueMemLabel.Size = new System.Drawing.Size(160, 46);
            this.mobjValueMemLabel.TabIndex = 3;
            this.mobjValueMemLabel.Text = "ValueMember";
            this.mobjValueMemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjDisplayMemLabel
            // 
            this.mobjDisplayMemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDisplayMemLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDisplayMemLabel.Name = "mobjDisplayMemLabel";
            this.mobjDisplayMemLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjDisplayMemLabel.Size = new System.Drawing.Size(160, 46);
            this.mobjDisplayMemLabel.TabIndex = 2;
            this.mobjDisplayMemLabel.Text = "DisplayMember";
            this.mobjDisplayMemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTLP1
            // 
            this.mobjTLP1.ColumnCount = 1;
            this.mobjTLP1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP1.Controls.Add(this.mobjLabel, 0, 0);
            this.mobjTLP1.Controls.Add(this.mobjListBox, 0, 1);
            this.mobjTLP1.Controls.Add(this.mobjTLP2, 0, 2);
            this.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP1.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP1.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP1.Name = "mobjTLP1";
            this.mobjTLP1.RowCount = 3;
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35F));
            this.mobjTLP1.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP1.TabIndex = 8;
            // 
            // mobjTLP2
            // 
            this.mobjTLP2.ColumnCount = 2;
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP2.Controls.Add(this.mobjDisplayMemLabel, 0, 0);
            this.mobjTLP2.Controls.Add(this.mobjImageTextBox, 1, 2);
            this.mobjTLP2.Controls.Add(this.mobjValueTextBox, 1, 1);
            this.mobjTLP2.Controls.Add(this.mobjValueMemLabel, 0, 1);
            this.mobjTLP2.Controls.Add(this.mobjImageMemLabel, 0, 2);
            this.mobjTLP2.Controls.Add(this.mobjDisplayTextBox, 1, 0);
            this.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP2.Location = new System.Drawing.Point(0, 260);
            this.mobjTLP2.Name = "mobjTLP2";
            this.mobjTLP2.RowCount = 3;
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP2.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP2.Size = new System.Drawing.Size(320, 140);
            this.mobjTLP2.TabIndex = 0;
            // 
            // TextWithImagePage
            // 
            this.Controls.Add(this.mobjTLP1);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "TextWithImagePage";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).EndInit();
            this.mobjTLP1.ResumeLayout(false);
            this.mobjTLP2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.BindingSource BindingSource1;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Label mobjImageMemLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjImageTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjValueTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjDisplayTextBox;
        private Gizmox.WebGUI.Forms.Label mobjValueMemLabel;
        private Gizmox.WebGUI.Forms.Label mobjDisplayMemLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP1;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP2;
    }
}
