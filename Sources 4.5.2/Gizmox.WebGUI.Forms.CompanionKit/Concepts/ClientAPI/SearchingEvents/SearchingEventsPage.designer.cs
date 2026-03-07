namespace CompanionKit.Concepts.ClientAPI.SearchingEvents
{
    partial class SearchingEventsPage
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
            this.objScheduleBox = new Gizmox.WebGUI.Forms.ScheduleBox();
            this.objSearchTypeGroup = new Gizmox.WebGUI.Forms.GroupBox();
            this.objRangeRadio = new Gizmox.WebGUI.Forms.RadioButton();
            this.objExactRadio = new Gizmox.WebGUI.Forms.RadioButton();
            this.objInputDataGroup = new Gizmox.WebGUI.Forms.GroupBox();
            this.objEndDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.objStartDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.objEndLabel = new Gizmox.WebGUI.Forms.Label();
            this.objStartLabel = new Gizmox.WebGUI.Forms.Label();
            this.objOutputDataGroup = new Gizmox.WebGUI.Forms.GroupBox();
            this.objOutputTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.objButton = new Gizmox.WebGUI.Forms.Button();
            this.objViewModeCombo = new Gizmox.WebGUI.Forms.ComboBox();
            this.objViewModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.objViewModeGroup = new Gizmox.WebGUI.Forms.GroupBox();
            this.objPanel1 = new Gizmox.WebGUI.Forms.Panel();
            this.objPanel2 = new Gizmox.WebGUI.Forms.Panel();
            this.objPanel3 = new Gizmox.WebGUI.Forms.Panel();
            this.objSearchTypeGroup.SuspendLayout();
            this.objInputDataGroup.SuspendLayout();
            this.objOutputDataGroup.SuspendLayout();
            this.objViewModeGroup.SuspendLayout();
            this.objPanel1.SuspendLayout();
            this.objPanel2.SuspendLayout();
            this.objPanel3.SuspendLayout();
            this.SuspendLayout();
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
            this.objScheduleBox.Size = new System.Drawing.Size(340, 136);
            this.objScheduleBox.TabIndex = 1;
            this.objScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week;
            this.objScheduleBox.WorkEndHour = 17;
            this.objScheduleBox.WorkStartHour = 9;
            // 
            // objSearchTypeGroup
            // 
            this.objSearchTypeGroup.Controls.Add(this.objRangeRadio);
            this.objSearchTypeGroup.Controls.Add(this.objExactRadio);
            this.objSearchTypeGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objSearchTypeGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objSearchTypeGroup.Location = new System.Drawing.Point(10, 10);
            this.objSearchTypeGroup.Name = "objSearchTypeGroup";
            this.objSearchTypeGroup.Size = new System.Drawing.Size(122, 71);
            this.objSearchTypeGroup.TabIndex = 4;
            this.objSearchTypeGroup.TabStop = false;
            this.objSearchTypeGroup.Text = "Search by";
            // 
            // objRangeRadio
            // 
            this.objRangeRadio.AutoSize = true;
            this.objRangeRadio.Location = new System.Drawing.Point(10, 43);
            this.objRangeRadio.Name = "objRangeRadio";
            this.objRangeRadio.Size = new System.Drawing.Size(56, 17);
            this.objRangeRadio.TabIndex = 17;
            this.objRangeRadio.Text = "Range";
            this.objRangeRadio.CheckedChanged += new System.EventHandler(this.objRangeRadio_CheckedChanged);
            // 
            // objExactRadio
            // 
            this.objExactRadio.AutoSize = true;
            this.objExactRadio.Checked = true;
            this.objExactRadio.ClientId = "exact";
            this.objExactRadio.Location = new System.Drawing.Point(10, 17);
            this.objExactRadio.Name = "objExactRadio";
            this.objExactRadio.Size = new System.Drawing.Size(77, 17);
            this.objExactRadio.TabIndex = 16;
            this.objExactRadio.Text = "Exact date";
            // 
            // objInputDataGroup
            // 
            this.objInputDataGroup.Controls.Add(this.objEndDateTimePicker);
            this.objInputDataGroup.Controls.Add(this.objStartDateTimePicker);
            this.objInputDataGroup.Controls.Add(this.objEndLabel);
            this.objInputDataGroup.Controls.Add(this.objStartLabel);
            this.objInputDataGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objInputDataGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objInputDataGroup.Location = new System.Drawing.Point(132, 10);
            this.objInputDataGroup.Name = "objInputDataGroup";
            this.objInputDataGroup.Size = new System.Drawing.Size(198, 71);
            this.objInputDataGroup.TabIndex = 5;
            this.objInputDataGroup.TabStop = false;
            this.objInputDataGroup.Text = "Input data";
            // 
            // objEndDateTimePicker
            // 
            this.objEndDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.objEndDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.objEndDateTimePicker.Location = new System.Drawing.Point(86, 47);
            this.objEndDateTimePicker.Name = "objEndDateTimePicker";
            this.objEndDateTimePicker.Size = new System.Drawing.Size(100, 21);
            this.objEndDateTimePicker.TabIndex = 16;
            this.objEndDateTimePicker.Visible = false;
            // 
            // objStartDateTimePicker
            // 
            this.objStartDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.objStartDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.objStartDateTimePicker.Location = new System.Drawing.Point(86, 17);
            this.objStartDateTimePicker.Name = "objStartDateTimePicker";
            this.objStartDateTimePicker.Size = new System.Drawing.Size(100, 21);
            this.objStartDateTimePicker.TabIndex = 16;
            // 
            // objEndLabel
            // 
            this.objEndLabel.AutoSize = true;
            this.objEndLabel.ClientId = "eLabel";
            this.objEndLabel.Location = new System.Drawing.Point(19, 49);
            this.objEndLabel.Name = "objEndLabel";
            this.objEndLabel.Size = new System.Drawing.Size(35, 13);
            this.objEndLabel.TabIndex = 7;
            this.objEndLabel.Text = "End";
            this.objEndLabel.Visible = false;
            // 
            // objStartLabel
            // 
            this.objStartLabel.AutoSize = true;
            this.objStartLabel.Location = new System.Drawing.Point(19, 23);
            this.objStartLabel.Name = "objStartLabel";
            this.objStartLabel.Size = new System.Drawing.Size(35, 13);
            this.objStartLabel.TabIndex = 6;
            this.objStartLabel.Text = "Start";
            // 
            // objOutputDataGroup
            // 
            this.objOutputDataGroup.Controls.Add(this.objOutputTextBox);
            this.objOutputDataGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objOutputDataGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objOutputDataGroup.Location = new System.Drawing.Point(10, 10);
            this.objOutputDataGroup.MinimumSize = new System.Drawing.Size(320, 80);
            this.objOutputDataGroup.Name = "objOutputDataGroup";
            this.objOutputDataGroup.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.objOutputDataGroup.Size = new System.Drawing.Size(320, 80);
            this.objOutputDataGroup.TabIndex = 6;
            this.objOutputDataGroup.TabStop = false;
            this.objOutputDataGroup.Text = "Output data";
            // 
            // objOutputTextBox
            // 
            this.objOutputTextBox.AllowDrag = false;
            this.objOutputTextBox.ClientId = "textBox";
            this.objOutputTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.objOutputTextBox.Location = new System.Drawing.Point(10, 24);
            this.objOutputTextBox.Multiline = true;
            this.objOutputTextBox.Name = "objOutputTextBox";
            this.objOutputTextBox.ReadOnly = true;
            this.objOutputTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.objOutputTextBox.Size = new System.Drawing.Size(300, 46);
            this.objOutputTextBox.TabIndex = 0;
            // 
            // objButton
            // 
            this.objButton.Location = new System.Drawing.Point(218, 15);
            this.objButton.Name = "objButton";
            this.objButton.Size = new System.Drawing.Size(112, 42);
            this.objButton.TabIndex = 7;
            this.objButton.Text = "Find Events";
            this.objButton.Click += new System.EventHandler(this.objButton_Click);
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
            this.objViewModeCombo.Location = new System.Drawing.Point(74, 17);
            this.objViewModeCombo.Name = "objViewModeCombo";
            this.objViewModeCombo.Size = new System.Drawing.Size(97, 21);
            this.objViewModeCombo.TabIndex = 7;
            this.objViewModeCombo.Text = "Week";
            this.objViewModeCombo.SelectedIndexChanged += new System.EventHandler(this.objViewModeCombo_SelectedIndexChanged);
            // 
            // objViewModeLabel
            // 
            this.objViewModeLabel.AutoSize = true;
            this.objViewModeLabel.Location = new System.Drawing.Point(12, 20);
            this.objViewModeLabel.Name = "objViewModeLabel";
            this.objViewModeLabel.Size = new System.Drawing.Size(55, 13);
            this.objViewModeLabel.TabIndex = 13;
            this.objViewModeLabel.Text = "View";
            // 
            // objViewModeGroup
            // 
            this.objViewModeGroup.Controls.Add(this.objViewModeCombo);
            this.objViewModeGroup.Controls.Add(this.objViewModeLabel);
            this.objViewModeGroup.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objViewModeGroup.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.objViewModeGroup.Location = new System.Drawing.Point(10, 10);
            this.objViewModeGroup.Name = "objViewModeGroup";
            this.objViewModeGroup.Size = new System.Drawing.Size(196, 48);
            this.objViewModeGroup.TabIndex = 15;
            this.objViewModeGroup.TabStop = false;
            this.objViewModeGroup.Text = "View Mode";
            // 
            // objPanel1
            // 
            this.objPanel1.Controls.Add(this.objInputDataGroup);
            this.objPanel1.Controls.Add(this.objSearchTypeGroup);
            this.objPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objPanel1.DockPadding.All = 10;
            this.objPanel1.Location = new System.Drawing.Point(15, 151);
            this.objPanel1.Name = "objPanel1";
            this.objPanel1.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.objPanel1.Size = new System.Drawing.Size(340, 91);
            this.objPanel1.TabIndex = 16;
            // 
            // objPanel2
            // 
            this.objPanel2.Controls.Add(this.objViewModeGroup);
            this.objPanel2.Controls.Add(this.objButton);
            this.objPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objPanel2.DockPadding.All = 10;
            this.objPanel2.Location = new System.Drawing.Point(15, 242);
            this.objPanel2.Name = "objPanel2";
            this.objPanel2.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.objPanel2.Size = new System.Drawing.Size(340, 68);
            this.objPanel2.TabIndex = 17;
            // 
            // objPanel3
            // 
            this.objPanel3.Controls.Add(this.objOutputDataGroup);
            this.objPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objPanel3.DockPadding.All = 10;
            this.objPanel3.Location = new System.Drawing.Point(15, 310);
            this.objPanel3.MaximumSize = new System.Drawing.Size(340, 100);
            this.objPanel3.Name = "objPanel3";
            this.objPanel3.Padding = new Gizmox.WebGUI.Forms.Padding(10);
            this.objPanel3.Size = new System.Drawing.Size(340, 100);
            this.objPanel3.TabIndex = 18;
            // 
            // SearchingEventsPage
            // 
            this.Controls.Add(this.objScheduleBox);
            this.Controls.Add(this.objPanel1);
            this.Controls.Add(this.objPanel2);
            this.Controls.Add(this.objPanel3);
            this.DockPadding.All = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(370, 425);
            this.Text = "SearchingEventsPage";
            this.Load += new System.EventHandler(this.SearchingEventsPage_Load);
            this.objSearchTypeGroup.ResumeLayout(false);
            this.objInputDataGroup.ResumeLayout(false);
            this.objOutputDataGroup.ResumeLayout(false);
            this.objViewModeGroup.ResumeLayout(false);
            this.objPanel1.ResumeLayout(false);
            this.objPanel2.ResumeLayout(false);
            this.objPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ScheduleBox objScheduleBox;
        private Gizmox.WebGUI.Forms.GroupBox objSearchTypeGroup;
        private Gizmox.WebGUI.Forms.GroupBox objInputDataGroup;
        private Gizmox.WebGUI.Forms.GroupBox objOutputDataGroup;
        private Gizmox.WebGUI.Forms.Label objEndLabel;
        private Gizmox.WebGUI.Forms.Label objStartLabel;
        private Gizmox.WebGUI.Forms.TextBox objOutputTextBox;
        private Gizmox.WebGUI.Forms.Button objButton;
        private Gizmox.WebGUI.Forms.ComboBox objViewModeCombo;
        private Gizmox.WebGUI.Forms.Label objViewModeLabel;
        private Gizmox.WebGUI.Forms.GroupBox objViewModeGroup;
        private Gizmox.WebGUI.Forms.DateTimePicker objEndDateTimePicker;
        private Gizmox.WebGUI.Forms.DateTimePicker objStartDateTimePicker;
        private Gizmox.WebGUI.Forms.RadioButton objRangeRadio;
        private Gizmox.WebGUI.Forms.RadioButton objExactRadio;
        private Gizmox.WebGUI.Forms.Panel objPanel1;
        private Gizmox.WebGUI.Forms.Panel objPanel2;
        private Gizmox.WebGUI.Forms.Panel objPanel3;



    }
}