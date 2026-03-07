namespace CompanionKit.Controls.DateTimePicker.Appearance
{
    partial class CalendarFontProperty
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
            this.mobjFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjDemoDateTimePickerLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjFontLabel
            // 
            this.mobjFontLabel.AutoSize = true;
            this.mobjFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjFontLabel.Name = "mobjFontLabel";
            this.mobjFontLabel.Size = new System.Drawing.Size(33, 13);
            this.mobjFontLabel.TabIndex = 0;
            this.mobjFontLabel.Text = "Font:";
            // 
            // mobjFontButton
            // 
            this.mobjFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.mobjFontButton.Location = new System.Drawing.Point(320, 0);
            this.mobjFontButton.Name = "mobjFontButton";
            this.mobjFontButton.Size = new System.Drawing.Size(25, 30);
            this.mobjFontButton.TabIndex = 1;
            this.mobjFontButton.UseVisualStyleBackColor = true;
            this.mobjFontButton.Click += new System.EventHandler(this.mobjFontButton_Click);
            // 
            // mobjDemoDateTimePicker
            // 
            this.mobjDemoDateTimePicker.CustomFormat = "";
            this.mobjDemoDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePicker.Location = new System.Drawing.Point(74, 125);
            this.mobjDemoDateTimePicker.Name = "mobjDemoDateTimePicker";
            this.mobjDemoDateTimePicker.Size = new System.Drawing.Size(345, 21);
            this.mobjDemoDateTimePicker.TabIndex = 2;
            // 
            // mobjDemoDateTimePickerLabel
            // 
            this.mobjDemoDateTimePickerLabel.AutoSize = true;
            this.mobjDemoDateTimePickerLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoDateTimePickerLabel.Location = new System.Drawing.Point(74, 95);
            this.mobjDemoDateTimePickerLabel.Name = "mobjDemoDateTimePickerLabel";
            this.mobjDemoDateTimePickerLabel.Size = new System.Drawing.Size(345, 30);
            this.mobjDemoDateTimePickerLabel.TabIndex = 3;
            this.mobjDemoDateTimePickerLabel.Text = "Demonstrated DateTimePicker";
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 72;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.Apply += new System.EventHandler(this.mobjDemoFontDialog_Apply);
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePicker, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoDateTimePickerLabel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(494, 200);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjFontButton);
            this.mobjTopPanel.Controls.Add(this.mobjFontLabel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(74, 45);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(345, 30);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // CalendarFontProperty
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(337, 200);
            this.Size = new System.Drawing.Size(494, 200);
            this.Text = "CalendarFontProperty";
            this.Load += new System.EventHandler(this.CalendarFontProperty_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjFontLabel;
        private Gizmox.WebGUI.Forms.Button mobjFontButton;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjDemoDateTimePicker;
        private Gizmox.WebGUI.Forms.Label mobjDemoDateTimePickerLabel;
        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;



    }
}