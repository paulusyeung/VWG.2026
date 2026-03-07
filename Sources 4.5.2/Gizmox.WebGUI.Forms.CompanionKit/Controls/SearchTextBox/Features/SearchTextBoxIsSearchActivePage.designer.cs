namespace CompanionKit.Controls.SearchTextBox.Features
{
    partial class SearchTextBoxIsSearchActivePage
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
            this.searchTextBox1 = new Gizmox.WebGUI.Forms.SearchTextBox();
            this.btnCheck = new Gizmox.WebGUI.Forms.Button();
            this.errorProvider1 = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.CustomStyle = "STB";
            this.searchTextBox1.Location = new System.Drawing.Point(17, 23);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(200, 20);
            this.searchTextBox1.TabIndex = 0;
            this.searchTextBox1.WatermarkText = "Type to search";
            this.searchTextBox1.Search += new System.EventHandler(this.searchTextBox1_Search);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(242, 23);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(86, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check status";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 3;
            this.errorProvider1.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            // 
            // SearchTextBoxIsSearchActivePage
            // 
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.searchTextBox1);
            this.Size = new System.Drawing.Size(400, 150);
            this.Text = "SearchTextBoxIsSearchActivePage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SearchTextBox searchTextBox1;
        private Gizmox.WebGUI.Forms.Button btnCheck;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider1;



    }
}