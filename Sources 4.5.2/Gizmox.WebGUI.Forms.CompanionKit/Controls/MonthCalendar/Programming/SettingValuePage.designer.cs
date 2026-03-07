namespace CompanionKit.Controls.MonthCalendar.Programming
{
    partial class SettingValuePage
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
            this.mobjEnableMonthCalendar = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.mobjSelectDateDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjSetDateButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDisableMonthCalendar = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.mobjDisableMonthCalendarRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjEnableMonthCalendarRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableMonthCalendar
            // 
            this.mobjEnableMonthCalendar.Location = new System.Drawing.Point(20, 182);
            this.mobjEnableMonthCalendar.Name = "enableMonthCalendar";
            this.mobjEnableMonthCalendar.SelectionEnd = new System.DateTime(2010, 5, 7, 17, 4, 35, 786);
            this.mobjEnableMonthCalendar.SelectionRange = new Gizmox.WebGUI.Forms.SelectionRange(new System.DateTime(2010, 5, 7, 0, 0, 0, 0), new System.DateTime(2010, 5, 7, 0, 0, 0, 0));
            this.mobjEnableMonthCalendar.SelectionStart = new System.DateTime(2010, 5, 7, 17, 4, 35, 786);
            this.mobjEnableMonthCalendar.Size = new System.Drawing.Size(227, 162);
            this.mobjEnableMonthCalendar.TabIndex = 1;
            this.mobjEnableMonthCalendar.Value = new System.DateTime(2010, 5, 7, 17, 4, 35, 786);
            // 
            // selectDateDateTimePicker
            // 
            this.mobjSelectDateDateTimePicker.CustomFormat = "";
            this.mobjSelectDateDateTimePicker.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSelectDateDateTimePicker.Location = new System.Drawing.Point(20, 22);
            this.mobjSelectDateDateTimePicker.Name = "selectDateDateTimePicker";
            this.mobjSelectDateDateTimePicker.Size = new System.Drawing.Size(379, 21);
            this.mobjSelectDateDateTimePicker.TabIndex = 4;
            this.mobjSelectDateDateTimePicker.ValueChanged += new System.EventHandler(this.mobjSetDateButton_Click);
            // 
            // setDateButton
            // 
            this.mobjSetDateButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSetDateButton.Location = new System.Drawing.Point(419, 22);
            this.mobjSetDateButton.Name = "setDateButton";
            this.mobjSetDateButton.Size = new System.Drawing.Size(379, 50);
            this.mobjSetDateButton.TabIndex = 5;
            this.mobjSetDateButton.Text = "Set date to MonthCalendar";
            this.mobjSetDateButton.UseVisualStyleBackColor = true;
            this.mobjSetDateButton.Click += new System.EventHandler(this.mobjSetDateButton_Click);
            // 
            // disableMonthCalendar
            // 
            this.mobjDisableMonthCalendar.Enabled = false;
            this.mobjDisableMonthCalendar.Location = new System.Drawing.Point(419, 182);
            this.mobjDisableMonthCalendar.Name = "disableMonthCalendar";
            this.mobjDisableMonthCalendar.SelectionEnd = new System.DateTime(2010, 5, 7, 17, 4, 35, 801);
            this.mobjDisableMonthCalendar.SelectionRange = new Gizmox.WebGUI.Forms.SelectionRange(new System.DateTime(2010, 5, 7, 0, 0, 0, 0), new System.DateTime(2010, 5, 7, 0, 0, 0, 0));
            this.mobjDisableMonthCalendar.SelectionStart = new System.DateTime(2010, 5, 7, 17, 4, 35, 801);
            this.mobjDisableMonthCalendar.Size = new System.Drawing.Size(227, 162);
            this.mobjDisableMonthCalendar.TabIndex = 6;
            this.mobjDisableMonthCalendar.Value = new System.DateTime(2010, 5, 7, 17, 4, 35, 801);
            // 
            // disableMonthCalendarRadioButton
            // 
            this.mobjDisableMonthCalendarRadioButton.AutoSize = true;
            this.mobjDisableMonthCalendarRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDisableMonthCalendarRadioButton.Location = new System.Drawing.Point(419, 92);
            this.mobjDisableMonthCalendarRadioButton.Name = "disableMonthCalendarRadioButton";
            this.mobjDisableMonthCalendarRadioButton.Size = new System.Drawing.Size(379, 70);
            this.mobjDisableMonthCalendarRadioButton.TabIndex = 7;
            this.mobjDisableMonthCalendarRadioButton.Text = "Set date to disabled MonthCalendar";
            this.mobjDisableMonthCalendarRadioButton.UseVisualStyleBackColor = true;
            // 
            // enableMonthCalendarRadioButton
            // 
            this.mobjEnableMonthCalendarRadioButton.AutoSize = true;
            this.mobjEnableMonthCalendarRadioButton.Checked = true;
            this.mobjEnableMonthCalendarRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjEnableMonthCalendarRadioButton.Location = new System.Drawing.Point(20, 92);
            this.mobjEnableMonthCalendarRadioButton.Name = "enableMonthCalendarRadioButton";
            this.mobjEnableMonthCalendarRadioButton.Size = new System.Drawing.Size(379, 70);
            this.mobjEnableMonthCalendarRadioButton.TabIndex = 8;
            this.mobjEnableMonthCalendarRadioButton.Text = "Set date to enabled MonthCalendar";
            this.mobjEnableMonthCalendarRadioButton.UseVisualStyleBackColor = true;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDisableMonthCalendar, 3, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectDateDateTimePicker, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetDateButton, 3, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjEnableMonthCalendarRadioButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjEnableMonthCalendar, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjDisableMonthCalendarRadioButton, 3, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(819, 387);
            this.mobjLayoutPanel.TabIndex = 9;
            // 
            // SettingValuePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(819, 387);
            this.Text = "SettingValuePage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MonthCalendar mobjEnableMonthCalendar;
        private Gizmox.WebGUI.Forms.DateTimePicker mobjSelectDateDateTimePicker;
        private Gizmox.WebGUI.Forms.Button mobjSetDateButton;
        private Gizmox.WebGUI.Forms.MonthCalendar mobjDisableMonthCalendar;
        private Gizmox.WebGUI.Forms.RadioButton mobjDisableMonthCalendarRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjEnableMonthCalendarRadioButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}