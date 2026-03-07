namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.ApplicationScenarios
{
    partial class DisplayPicturePage
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
            this.mobjRepresentedPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjOpenFileButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoOpenFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjRepresentedPictureBox)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjRepresentedPictureBox
            // 
            this.mobjRepresentedPictureBox.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.mobjRepresentedPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRepresentedPictureBox.Location = new System.Drawing.Point(63, 28);
            this.mobjRepresentedPictureBox.Name = "mobjRepresentedPictureBox";
            this.mobjRepresentedPictureBox.Size = new System.Drawing.Size(508, 231);
            this.mobjRepresentedPictureBox.TabIndex = 0;
            this.mobjRepresentedPictureBox.TabStop = false;
            // 
            // mobjOpenFileButton
            // 
            this.mobjOpenFileButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOpenFileButton.Location = new System.Drawing.Point(63, 279);
            this.mobjOpenFileButton.Name = "mobjOpenFileButton";
            this.mobjOpenFileButton.Size = new System.Drawing.Size(508, 50);
            this.mobjOpenFileButton.TabIndex = 1;
            this.mobjOpenFileButton.Text = "Open image file";
            this.mobjOpenFileButton.UseVisualStyleBackColor = true;
            this.mobjOpenFileButton.Click += new System.EventHandler(this.mobjOpenFileButton_Click);
            // 
            // mobjDemoOpenFileDialog
            // 
            this.mobjDemoOpenFileDialog.Closed += new System.EventHandler(this.demoOpenFileDialog_Closed);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjRepresentedPictureBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOpenFileButton, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(636, 359);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // DisplayPicturePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(636, 359);
            this.Text = "DisplayPicturePage";
            this.Load += new System.EventHandler(this.DisplayPicturePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjRepresentedPictureBox)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.PictureBox mobjRepresentedPictureBox;
        private Gizmox.WebGUI.Forms.Button mobjOpenFileButton;
        private Gizmox.WebGUI.Forms.OpenFileDialog mobjDemoOpenFileDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}