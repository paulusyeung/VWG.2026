namespace CompanionKit.Controls.SearchTextBox.Features
{
    partial class SearchTextBoxDropDownMenuPropertyPage
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
            this.searchTextBox1 = new Gizmox.WebGUI.Forms.SearchTextBox();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.CustomStyle = "STB";
            this.searchTextBox1.DropDownMenu = this.contextMenu1;
            this.searchTextBox1.Location = new System.Drawing.Point(17, 23);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(200, 20);
            this.searchTextBox1.TabIndex = 0;
            // 
            // SearchTextBoxDropDownMenuPropertyPage
            // 
            this.Controls.Add(this.searchTextBox1);
            this.Size = new System.Drawing.Size(400, 150);
            this.Text = "SearchTextBoxDropDownMenuPropertyPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.SearchTextBox searchTextBox1;
        private Gizmox.WebGUI.Forms.ContextMenu contextMenu1;



    }
}