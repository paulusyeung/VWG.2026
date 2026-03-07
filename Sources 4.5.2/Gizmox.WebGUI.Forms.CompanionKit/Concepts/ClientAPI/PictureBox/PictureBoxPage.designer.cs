namespace CompanionKit.Concepts.ClientAPI.PictureBox
{
    partial class PictureBoxPage
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).BeginInit();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjListBox.ClientId = "lb";
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Items.AddRange(new object[] {
            "Sea",
            "Stone",
            "View"});
            this.mobjListBox.Location = new System.Drawing.Point(15, 36);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(229, 108);
            this.mobjListBox.TabIndex = 0;
            this.mobjListBox.SelectedIndexChanged += new System.EventHandler(this.mobjListBox_SelectedIndexChanged);
            // 
            // mobjPictureBox
            // 
            this.mobjPictureBox.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black);
            this.mobjPictureBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPictureBox.ClientId = "pb";
            this.mobjPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPictureBox.Location = new System.Drawing.Point(15, 149);
            this.mobjPictureBox.Name = "mobjPictureBox";
            this.mobjPictureBox.Size = new System.Drawing.Size(229, 200);
            this.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.mobjPictureBox.TabIndex = 1;
            this.mobjPictureBox.TabStop = false;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjListBox);
            this.mobjPanel.Controls.Add(this.mobjLabel);
            this.mobjPanel.Controls.Add(this.mobjPictureBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjPanel.DockPadding.Bottom = 15;
            this.mobjPanel.DockPadding.Left = 15;
            this.mobjPanel.DockPadding.Right = 10;
            this.mobjPanel.DockPadding.Top = 10;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 10, 10, 15);
            this.mobjPanel.Size = new System.Drawing.Size(254, 360);
            this.mobjPanel.TabIndex = 2;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(15, 10);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(229, 26);
            this.mobjLabel.TabIndex = 2;
            this.mobjLabel.Text = "Select PictureBox image:";
            // 
            // PictureBoxPage
            // 
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(439, 360);
            this.Text = "PictureBoxPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).EndInit();
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.PictureBox mobjPictureBox;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Label mobjLabel;



    }
}