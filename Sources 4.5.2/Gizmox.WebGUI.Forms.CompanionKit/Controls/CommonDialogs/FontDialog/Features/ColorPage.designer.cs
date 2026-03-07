namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features
{
    partial class ColorPage
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
            this.mobjColorFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeForeColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjColorFontLabel
            // 
            this.mobjColorFontLabel.AutoSize = true;
            this.mobjColorFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjColorFontLabel.Location = new System.Drawing.Point(88, 34);
            this.mobjColorFontLabel.Name = "mobjColorFontLabel";
            this.mobjColorFontLabel.Size = new System.Drawing.Size(415, 50);
            this.mobjColorFontLabel.TabIndex = 1;
            this.mobjColorFontLabel.Text = "Font selected in the dialog:";
            this.mobjColorFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjChangeForeColorButton
            // 
            this.mobjChangeForeColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeForeColorButton.Location = new System.Drawing.Point(88, 104);
            this.mobjChangeForeColorButton.Name = "mobjChangeForeColorButton";
            this.mobjChangeForeColorButton.Size = new System.Drawing.Size(415, 80);
            this.mobjChangeForeColorButton.TabIndex = 2;
            this.mobjChangeForeColorButton.Text = "Open FontDialog to change foreground color of label";
            this.mobjChangeForeColorButton.UseVisualStyleBackColor = true;
            this.mobjChangeForeColorButton.Click += new System.EventHandler(this.mobjChangeForeColorButton_Click);
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 28;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.ShowColor = true;
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjColorFontLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeForeColorButton, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(593, 219);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // ColorPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(593, 219);
            this.Text = "ColorPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjColorFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjChangeForeColorButton;
        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
