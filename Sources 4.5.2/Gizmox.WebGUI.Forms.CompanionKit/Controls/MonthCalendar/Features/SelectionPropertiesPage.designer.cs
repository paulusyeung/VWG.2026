namespace CompanionKit.Controls.MonthCalendar.Features
{
    partial class SelectionPropertiesPage
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
            this.mobjMaxSelectionTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjEndTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjStartTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjStartDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjEndDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjMonthCalendar = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjCalendarPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).BeginInit();
            this.mobjGroupBox.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMaxSelectionTextLabel
            // 
            this.mobjMaxSelectionTextLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjMaxSelectionTextLabel, 2);
            this.mobjMaxSelectionTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjMaxSelectionTextLabel.Location = new System.Drawing.Point(271, 13);
            this.mobjMaxSelectionTextLabel.Name = "objMaxSelectionTextLabel";
            this.mobjMaxSelectionTextLabel.Size = new System.Drawing.Size(252, 30);
            this.mobjMaxSelectionTextLabel.TabIndex = 6;
            this.mobjMaxSelectionTextLabel.Text = "MaxCount:";
            // 
            // mobjEndTextLabel
            // 
            this.mobjEndTextLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjEndTextLabel, 2);
            this.mobjEndTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjEndTextLabel.Location = new System.Drawing.Point(20, 93);
            this.mobjEndTextLabel.Name = "objEndTextLabel";
            this.mobjEndTextLabel.Size = new System.Drawing.Size(251, 30);
            this.mobjEndTextLabel.TabIndex = 5;
            this.mobjEndTextLabel.Text = "EndRange:";
            // 
            // mobjStartTextLabel
            // 
            this.mobjStartTextLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjStartTextLabel, 2);
            this.mobjStartTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStartTextLabel.Location = new System.Drawing.Point(20, 13);
            this.mobjStartTextLabel.Name = "objStartTextLabel";
            this.mobjStartTextLabel.Size = new System.Drawing.Size(251, 30);
            this.mobjStartTextLabel.TabIndex = 4;
            this.mobjStartTextLabel.Text = "StartRange:";
            // 
            // mobjStartDateTimePicker
            // 
            this.mobjStartDateTimePicker.CustomFormat = "";
            this.mobjStartDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStartDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.mobjStartDateTimePicker.Location = new System.Drawing.Point(20, 43);
            this.mobjStartDateTimePicker.Name = "objStartDateTimePicker";
            this.mobjStartDateTimePicker.Size = new System.Drawing.Size(231, 21);
            this.mobjStartDateTimePicker.TabIndex = 1;
            // 
            // mobjNumericUpDown
            // 
            this.mobjNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjNumericUpDown.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjNumericUpDown.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNumericUpDown.Location = new System.Drawing.Point(271, 43);
            this.mobjNumericUpDown.Name = "objNumericUpDown";
            this.mobjNumericUpDown.Size = new System.Drawing.Size(231, 17);
            this.mobjNumericUpDown.TabIndex = 3;
            this.mobjNumericUpDown.ValueChanged += new System.EventHandler(this.mobjNumericUpDown_ValueChanged);
            // 
            // mobjEndDateTimePicker
            // 
            this.mobjEndDateTimePicker.CustomFormat = "";
            this.mobjEndDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjEndDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.mobjEndDateTimePicker.Location = new System.Drawing.Point(20, 123);
            this.mobjEndDateTimePicker.Name = "objEndDateTimePicker";
            this.mobjEndDateTimePicker.Size = new System.Drawing.Size(231, 21);
            this.mobjEndDateTimePicker.TabIndex = 2;
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjLayoutPanel);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjGroupBox.Size = new System.Drawing.Size(533, 191);
            this.mobjGroupBox.TabIndex = 4;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "SelectionGroup";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjEndTextLabel, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjStartTextLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjMaxSelectionTextLabel, 3, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjNumericUpDown, 3, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjStartDateTimePicker, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjEndDateTimePicker, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 3, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(5, 19);
            this.mobjLayoutPanel.Name = "tableLayoutPanel1";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(523, 167);
            this.mobjLayoutPanel.TabIndex = 8;
            // 
            // mobjButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(271, 93);
            this.mobjButton.Name = "objButton";
            this.mobjLayoutPanel.SetRowSpan(this.mobjButton, 2);
            this.mobjButton.Size = new System.Drawing.Size(231, 60);
            this.mobjButton.TabIndex = 7;
            this.mobjButton.Text = "Set Range";
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjMonthCalendar
            // 
            this.mobjMonthCalendar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjMonthCalendar.Location = new System.Drawing.Point(153, 74);
            this.mobjMonthCalendar.Name = "objMonthCalendar";
            this.mobjMonthCalendar.SelectionEnd = new System.DateTime(2013, 9, 19, 11, 29, 50, 244);
            this.mobjMonthCalendar.SelectionRange = new Gizmox.WebGUI.Forms.SelectionRange(new System.DateTime(2013, 9, 19, 0, 0, 0, 0), new System.DateTime(2013, 9, 19, 0, 0, 0, 0));
            this.mobjMonthCalendar.SelectionStart = new System.DateTime(2013, 9, 19, 11, 29, 50, 244);
            this.mobjMonthCalendar.Size = new System.Drawing.Size(227, 162);
            this.mobjMonthCalendar.TabIndex = 0;
            this.mobjMonthCalendar.Value = new System.DateTime(2013, 9, 19, 11, 29, 50, 244);
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjCommonLayoutPanel.ColumnCount = 3;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjMonthCalendar, 1, 1);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjPanel, 0, 3);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjCalendarPanel, 0, 1);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjCommonLayoutPanel.Name = "mobjCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 5;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(533, 452);
            this.mobjCommonLayoutPanel.TabIndex = 5;
            // 
            // mobjCalendarPanel
            // 
            this.mobjCalendarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCalendarPanel.Location = new System.Drawing.Point(0, 70);
            this.mobjCalendarPanel.Name = "mobjCalendarPanel";
            this.mobjCalendarPanel.Size = new System.Drawing.Size(50, 171);
            this.mobjCalendarPanel.TabIndex = 0;
            // 
            // mobjPanel
            // 
            this.mobjCommonLayoutPanel.SetColumnSpan(this.mobjPanel, 3);
            this.mobjPanel.Controls.Add(this.mobjGroupBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(0, 261);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjCommonLayoutPanel.SetRowSpan(this.mobjPanel, 2);
            this.mobjPanel.Size = new System.Drawing.Size(533, 191);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AutoSize = true;
            this.mobjCommonLayoutPanel.SetColumnSpan(this.mobjInfoLabel, 3);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(533, 70);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Tip: User can select range by holding Shift and pressing on date ";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectionPropertiesPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.Location = new System.Drawing.Point(0, -68);
            this.Size = new System.Drawing.Size(533, 452);
            this.Text = "SelectionPropertiesPage";
            this.Load += new System.EventHandler(this.SelectionPropertiesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjNumericUpDown)).EndInit();
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjMaxSelectionTextLabel;
        private Gizmox.WebGUI.Forms.Label mobjEndTextLabel;
        private Gizmox.WebGUI.Forms.Label mobjStartTextLabel;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjStartDateTimePicker;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjNumericUpDown;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjEndDateTimePicker;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.MonthCalendar mobjMonthCalendar;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjCalendarPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;



    }
}