namespace CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality
{
    partial class SettingColorPage
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
            this.mobjDemoColorDialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjColorlLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeBackColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoColorDialog
            // 
            this.mobjDemoColorDialog.Closed += new System.EventHandler(this.mobjDemoColorDialog_Closed);
            // 
            // mobjColorlLabel
            // 
            this.mobjColorlLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjColorlLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjColorlLabel.Name = "mobjColorlLabel";
            this.mobjColorlLabel.Size = new System.Drawing.Size(432, 81);
            this.mobjColorlLabel.TabIndex = 0;
            this.mobjColorlLabel.Text = "This label demonstrates what color is selected with color dialog.";
            this.mobjColorlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjChangeBackColorButton
            // 
            this.mobjChangeBackColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeBackColorButton.Location = new System.Drawing.Point(92, 115);
            this.mobjChangeBackColorButton.Name = "mobjChangeBackColorButton";
            this.mobjChangeBackColorButton.Size = new System.Drawing.Size(432, 50);
            this.mobjChangeBackColorButton.TabIndex = 1;
            this.mobjChangeBackColorButton.Text = "Change Label Background color.";
            this.mobjChangeBackColorButton.UseVisualStyleBackColor = true;
            this.mobjChangeBackColorButton.Click += new System.EventHandler(this.mobjChangeBackColorButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeBackColorButton, 1, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(618, 200);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjColorlLabel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(92, 14);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjTopPanel, 2);
            this.mobjTopPanel.Size = new System.Drawing.Size(432, 81);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // SettingColorPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(618, 200);
            this.Text = "SettingColorPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ColorDialog mobjDemoColorDialog;
        private Gizmox.WebGUI.Forms.Label mobjColorlLabel;
        private Gizmox.WebGUI.Forms.Button mobjChangeBackColorButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;



    }
}
