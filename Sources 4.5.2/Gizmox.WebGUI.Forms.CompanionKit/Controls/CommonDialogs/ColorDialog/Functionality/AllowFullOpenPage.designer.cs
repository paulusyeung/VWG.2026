namespace CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality
{
    partial class AllowFullOpenPage
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
            this.mobjColorLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoColorDialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjChangeBackColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjChangeForeColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjColorLabel
            // 
            this.mobjColorLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjColorLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjColorLabel.Name = "mobjColorLabel";
            this.mobjColorLabel.Size = new System.Drawing.Size(376, 61);
            this.mobjColorLabel.TabIndex = 0;
            this.mobjColorLabel.Text = "The label demonstrates selected colors";
            this.mobjColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjDemoColorDialog
            // 
            this.mobjDemoColorDialog.Closed += new System.EventHandler(this.mobjDemoColorDialog_Closed);
            // 
            // mobjChangeBackColorButton
            // 
            this.mobjChangeBackColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeBackColorButton.Location = new System.Drawing.Point(80, 95);
            this.mobjChangeBackColorButton.Name = "mobjChangeBackColorButton";
            this.mobjChangeBackColorButton.Size = new System.Drawing.Size(376, 50);
            this.mobjChangeBackColorButton.TabIndex = 1;
            this.mobjChangeBackColorButton.Text = "Set Background color";
            this.mobjChangeBackColorButton.UseVisualStyleBackColor = true;
            this.mobjChangeBackColorButton.Click += new System.EventHandler(this.mobjChangeBackColorButton_Click);
            // 
            // mobjChangeForeColorButton
            // 
            this.mobjChangeForeColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeForeColorButton.Location = new System.Drawing.Point(80, 165);
            this.mobjChangeForeColorButton.Name = "mobjChangeForeColorButton";
            this.mobjChangeForeColorButton.Size = new System.Drawing.Size(376, 50);
            this.mobjChangeForeColorButton.TabIndex = 2;
            this.mobjChangeForeColorButton.Text = "Set Foreground color";
            this.mobjChangeForeColorButton.UseVisualStyleBackColor = true;
            this.mobjChangeForeColorButton.Click += new System.EventHandler(this.mobjChangeForeColorButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeForeColorButton, 1, 6);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeBackColorButton, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 8;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(538, 250);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjColorLabel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(80, 14);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjTopPanel, 2);
            this.mobjTopPanel.Size = new System.Drawing.Size(376, 61);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // AllowFullOpenPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(538, 250);
            this.Text = "AllowFullOpenPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjColorLabel;
        private Gizmox.WebGUI.Forms.ColorDialog mobjDemoColorDialog;
        private Gizmox.WebGUI.Forms.Button mobjChangeBackColorButton;
        private Gizmox.WebGUI.Forms.Button mobjChangeForeColorButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;



    }
}
