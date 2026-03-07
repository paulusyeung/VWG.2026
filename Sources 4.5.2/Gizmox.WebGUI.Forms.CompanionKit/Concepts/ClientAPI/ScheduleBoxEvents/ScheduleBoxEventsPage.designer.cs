namespace CompanionKit.Concepts.ClientAPI.ScheduleBoxEvents
{
    partial class ScheduleBoxEventsPage
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
            this.objButton = new Gizmox.WebGUI.Forms.Button();
            this.objScheduleBox = new Gizmox.WebGUI.Forms.ScheduleBox();
            this.objSubjectTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.objTagTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.colorCombo = new Gizmox.WebGUI.Forms.ComboBox();
            this.objViewModeCombo = new Gizmox.WebGUI.Forms.ComboBox();
            this.objSubjectLabel = new Gizmox.WebGUI.Forms.Label();
            this.objTagLabel = new Gizmox.WebGUI.Forms.Label();
            this.objColorLabel = new Gizmox.WebGUI.Forms.Label();
            this.objStartDateLabel = new Gizmox.WebGUI.Forms.Label();
            this.objEndDateLabel = new Gizmox.WebGUI.Forms.Label();
            this.objViewModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.objInputDataGroup = new Gizmox.WebGUI.Forms.GroupBox();
            this.objEndDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.objStartDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.objViewModeGroup = new Gizmox.WebGUI.Forms.GroupBox();
            this.objBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objChildBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objInputDataGroup.SuspendLayout();
            this.objViewModeGroup.SuspendLayout();
            this.objBottomPanel.SuspendLayout();
            this.objChildBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objButton
            // 
            this.objButton.Location = new System.Drawing.Point(0, 1);
            this.objButton.Name = "objButton";
            this.objButton.Size = new System.Drawing.Size(123, 59);
            this.objButton.TabIndex = 0;
            this.objButton.Text = "AddEvent";
            this.objButton.Click += new System.EventHandler(this.objButton_Click);
            // 
            // objScheduleBox
            // 
            this.objScheduleBox.ClientId = "schedule";
            this.objScheduleBox.DisplayMonthHeader = false;
            this.objScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objScheduleBox.FirstDate = new System.DateTime(2013, 8, 8, 13, 50, 24, 484);
            this.objScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday;
            this.objScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock12H;
            this.objScheduleBox.Location = new System.Drawing.Point(15, 15);
            this.objScheduleBox.Name = "objScheduleBox";
            this.objScheduleBox.Size = new System.Drawing.Size(364, 260);
            this.objScheduleBox.TabIndex = 1;
            this.objScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week;
            this.objScheduleBox.WorkEndHour = 17;
            this.objScheduleBox.WorkStartHour = 9;
            // 
            // objSubjectTextBox
            // 
            this.objSubjectTextBox.AllowDrag = false;
            this.objSubjectTextBox.ClientId = "subject";
            this.objSubjectTextBox.Location = new System.Drawing.Point(62, 20);
            this.objSubjectTextBox.Name = "objSubjectTextBox";
            this.objSubjectTextBox.Size = new System.Drawing.Size(93, 20);
            this.objSubjectTextBox.TabIndex = 2;
            // 
            // objTagTextBox
            // 
            this.objTagTextBox.AllowDrag = false;
            this.objTagTextBox.ClientId = "tag";
            this.objTagTextBox.Location = new System.Drawing.Point(62, 46);
            this.objTagTextBox.Name = "objTagTextBox";
            this.objTagTextBox.Size = new System.Drawing.Size(93, 20);
            this.objTagTextBox.TabIndex = 3;
            // 
            // colorCombo
            // 
            this.colorCombo.AllowDrag = false;
            this.colorCombo.ClientId = "color";
            this.colorCombo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.colorCombo.FormattingEnabled = true;
            this.colorCombo.Items.AddRange(new object[] {
            "Red",
            "Blue",
            "Green",
            "Yellow",
            "Purple"});
            this.colorCombo.Location = new System.Drawing.Point(62, 69);
            this.colorCombo.Name = "colorCombo";
            this.colorCombo.Size = new System.Drawing.Size(93, 21);
            this.colorCombo.TabIndex = 6;
            this.colorCombo.Text = "Red";
            // 
            // objViewModeCombo
            // 
            this.objViewModeCombo.AllowDrag = false;
            this.objViewModeCombo.ClientId = "view";
            this.objViewModeCombo.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.objViewModeCombo.FormattingEnabled = true;
            this.objViewModeCombo.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "FullWeek",
            "FullMonth"});
            this.objViewModeCombo.Location = new System.Drawing.Point(58, 24);
            this.objViewModeCombo.Name = "objViewModeCombo";
            this.objViewModeCombo.Size = new System.Drawing.Size(71, 21);
            this.objViewModeCombo.TabIndex = 7;
            this.objViewModeCombo.Text = "Week";
            this.objViewModeCombo.SelectedIndexChanged += new System.EventHandler(this.objViewModeCombo_SelectedIndexChanged);
            // 
            // objSubjectLabel
            // 
            this.objSubjectLabel.AutoSize = true;
            this.objSubjectLabel.Location = new System.Drawing.Point(7, 23);
            this.objSubjectLabel.Name = "objSubjectLabel";
            this.objSubjectLabel.Size = new System.Drawing.Size(43, 13);
            this.objSubjectLabel.TabIndex = 8;
            this.objSubjectLabel.Text = "Sub";
            // 
            // objTagLabel
            // 
            this.objTagLabel.AutoSize = true;
            this.objTagLabel.Location = new System.Drawing.Point(7, 49);
            this.objTagLabel.Name = "objTagLabel";
            this.objTagLabel.Size = new System.Drawing.Size(52, 13);
            this.objTagLabel.TabIndex = 9;
            this.objTagLabel.Text = "Tag";
            // 
            // objColorLabel
            // 
            this.objColorLabel.AutoSize = true;
            this.objColorLabel.Location = new System.Drawing.Point(7, 72);
            this.objColorLabel.Name = "objColorLabel";
            this.objColorLabel.Size = new System.Drawing.Size(32, 13);
            this.objColorLabel.TabIndex = 10;
            this.objColorLabel.Text = "Color";
            // 
            // objStartDateLabel
            // 
            this.objStartDateLabel.AutoSize = true;
            this.objStartDateLabel.Location = new System.Drawing.Point(7, 107);
            this.objStartDateLabel.Name = "objStartDateLabel";
            this.objStartDateLabel.Size = new System.Drawing.Size(54, 13);
            this.objStartDateLabel.TabIndex = 11;
            this.objStartDateLabel.Text = "Start";
            // 
            // objEndDateLabel
            // 
            this.objEndDateLabel.AutoSize = true;
            this.objEndDateLabel.Location = new System.Drawing.Point(7, 138);
            this.objEndDateLabel.Name = "objEndDateLabel";
            this.objEndDateLabel.Size = new System.Drawing.Size(48, 13);
            this.objEndDateLabel.TabIndex = 12;
            this.objEndDateLabel.Text = "End";
            // 
            // objViewModeLabel
            // 
            this.objViewModeLabel.AutoSize = true;
            this.objViewModeLabel.Location = new System.Drawing.Point(13, 27);
            this.objViewModeLabel.Name = "objViewModeLabel";
            this.objViewModeLabel.Size = new System.Drawing.Size(55, 13);
            this.objViewModeLabel.TabIndex = 13;
            this.objViewModeLabel.Text = "View";
            // 
            // objInputDataGroup
            // 
            this.objInputDataGroup.Controls.Add(this.objEndDateTimePicker);
            this.objInputDataGroup.Controls.Add(this.objSubjectLabel);
            this.objInputDataGroup.Controls.Add(this.objStartDateTimePicker);
            this.objInputDataGroup.Controls.Add(this.objSubjectTextBox);
            this.objInputDataGroup.Controls.Add(this.objEndDateLabel);
            this.objInputDataGroup.Controls.Add(this.objTagTextBox);
            this.objInputDataGroup.Controls.Add(this.objStartDateLabel);
            this.objInputDataGroup.Controls.Add(this.objColorLabel);
            this.objInputDataGroup.Controls.Add(this.objTagLabel);
            this.objInputDataGroup.Controls.Add(this.colorCombo);
            this.objInputDataGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objInputDataGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objInputDataGroup.Location = new System.Drawing.Point(0, 0);
            this.objInputDataGroup.Name = "inputDataGroup";
            this.objInputDataGroup.Size = new System.Drawing.Size(196, 168);
            this.objInputDataGroup.TabIndex = 14;
            this.objInputDataGroup.TabStop = false;
            this.objInputDataGroup.Text = "Input Data";
            // 
            // objEndDateTimePicker
            // 
            this.objEndDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.objEndDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.objEndDateTimePicker.Location = new System.Drawing.Point(62, 132);
            this.objEndDateTimePicker.Name = "objEndDateTimePicker";
            this.objEndDateTimePicker.Size = new System.Drawing.Size(127, 21);
            this.objEndDateTimePicker.TabIndex = 17;
            // 
            // objStartDateTimePicker
            // 
            this.objStartDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.objStartDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.objStartDateTimePicker.Location = new System.Drawing.Point(62, 101);
            this.objStartDateTimePicker.Name = "objStartDateTimePicker";
            this.objStartDateTimePicker.Size = new System.Drawing.Size(127, 21);
            this.objStartDateTimePicker.TabIndex = 16;
            // 
            // objViewModeGroup
            // 
            this.objViewModeGroup.Controls.Add(this.objViewModeCombo);
            this.objViewModeGroup.Controls.Add(this.objViewModeLabel);
            this.objViewModeGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objViewModeGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objViewModeGroup.Location = new System.Drawing.Point(196, 0);
            this.objViewModeGroup.Name = "objViewModeGroup";
            this.objViewModeGroup.Size = new System.Drawing.Size(135, 68);
            this.objViewModeGroup.TabIndex = 15;
            this.objViewModeGroup.TabStop = false;
            this.objViewModeGroup.Text = "View Mode";
            // 
            // objBottomPanel
            // 
            this.objBottomPanel.Controls.Add(this.objViewModeGroup);
            this.objBottomPanel.Controls.Add(this.objChildBottomPanel);
            this.objBottomPanel.Controls.Add(this.objInputDataGroup);
            this.objBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objBottomPanel.Location = new System.Drawing.Point(15, 275);
            this.objBottomPanel.Name = "objBottomPanel";
            this.objBottomPanel.Size = new System.Drawing.Size(364, 168);
            this.objBottomPanel.TabIndex = 16;
            // 
            // objChildBottomPanel
            // 
            this.objChildBottomPanel.Controls.Add(this.objButton);
            this.objChildBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objChildBottomPanel.Location = new System.Drawing.Point(196, 68);
            this.objChildBottomPanel.Name = "objChildBottomPanel";
            this.objChildBottomPanel.Size = new System.Drawing.Size(168, 100);
            this.objChildBottomPanel.TabIndex = 16;
            // 
            // ScheduleBoxEventsPage
            // 
            this.Controls.Add(this.objScheduleBox);
            this.Controls.Add(this.objBottomPanel);
            this.DockPadding.All = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(394, 458);
            this.Text = "ScheduleBoxEventsPage";
            this.Load += new System.EventHandler(this.ScheduleBoxEventsPage_Load);
            this.objInputDataGroup.ResumeLayout(false);
            this.objViewModeGroup.ResumeLayout(false);
            this.objBottomPanel.ResumeLayout(false);
            this.objChildBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button objButton;
        private Gizmox.WebGUI.Forms.ScheduleBox objScheduleBox;
        private Gizmox.WebGUI.Forms.TextBox objSubjectTextBox;
        private Gizmox.WebGUI.Forms.TextBox objTagTextBox;
        private Gizmox.WebGUI.Forms.ComboBox colorCombo;
        private Gizmox.WebGUI.Forms.ComboBox objViewModeCombo;
        private Gizmox.WebGUI.Forms.Label objSubjectLabel;
        private Gizmox.WebGUI.Forms.Label objTagLabel;
        private Gizmox.WebGUI.Forms.Label objColorLabel;
        private Gizmox.WebGUI.Forms.Label objStartDateLabel;
        private Gizmox.WebGUI.Forms.Label objEndDateLabel;
        private Gizmox.WebGUI.Forms.Label objViewModeLabel;
        private Gizmox.WebGUI.Forms.GroupBox objInputDataGroup;
        private Gizmox.WebGUI.Forms.GroupBox objViewModeGroup;
        private Gizmox.WebGUI.Forms.DateTimePicker objEndDateTimePicker;
        private Gizmox.WebGUI.Forms.DateTimePicker objStartDateTimePicker;
        private Gizmox.WebGUI.Forms.Panel objBottomPanel;
        private Gizmox.WebGUI.Forms.Panel objChildBottomPanel;



    }
}