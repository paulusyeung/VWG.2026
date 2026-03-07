namespace CompanionKit.Controls.CommonDialogs.FontDialog.Functionality
{
    partial class FontPage
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
            this.mobjChangeFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjChangeFontLabel
            // 
            this.mobjChangeFontLabel.AutoSize = true;
            this.mobjChangeFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeFontLabel.Location = new System.Drawing.Point(84, 40);
            this.mobjChangeFontLabel.Name = "mobjChangeFontLabel";
            this.mobjChangeFontLabel.Size = new System.Drawing.Size(393, 50);
            this.mobjChangeFontLabel.TabIndex = 1;
            this.mobjChangeFontLabel.Text = "Font selected in the dialog: ";
            this.mobjChangeFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjChangeFontButton
            // 
            this.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeFontButton.Location = new System.Drawing.Point(84, 110);
            this.mobjChangeFontButton.Name = "mobjChangeFontButton";
            this.mobjChangeFontButton.Size = new System.Drawing.Size(393, 50);
            this.mobjChangeFontButton.TabIndex = 2;
            this.mobjChangeFontButton.Text = "Change font for label with FontDialog";
            this.mobjChangeFontButton.UseVisualStyleBackColor = true;
            this.mobjChangeFontButton.Click += new System.EventHandler(this.mobjChangeFontButton_Click);
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 28;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeFontLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeFontButton, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(562, 201);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // FontPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(562, 201);
            this.Text = "FontPage";
            this.Load += new System.EventHandler(this.FontPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjChangeFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjChangeFontButton;
        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
