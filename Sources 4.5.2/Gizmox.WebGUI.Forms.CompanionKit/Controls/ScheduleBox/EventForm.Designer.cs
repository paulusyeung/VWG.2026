namespace CompanionKit.Controls.ScheduleBox
{
    partial class EventForm 
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.subjectLabel = new Gizmox.WebGUI.Forms.Label();
			this.subjectTextBox = new Gizmox.WebGUI.Forms.TextBox();
			this.startDateLabel = new Gizmox.WebGUI.Forms.Label();
			this.startDateDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
			this.endDateDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
			this.endDateLabel = new Gizmox.WebGUI.Forms.Label();
			this.okButton = new Gizmox.WebGUI.Forms.Button();
			this.cancelEventButton = new Gizmox.WebGUI.Forms.Button();
			this.tagLabel = new Gizmox.WebGUI.Forms.Label();
			this.tagTextBox = new Gizmox.WebGUI.Forms.TextBox();
			this.testButton = new Gizmox.WebGUI.Forms.Button();
			this.errorProvider1 = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
			this.SuspendLayout();
			// 
			// subjectLabel
			// 
			this.subjectLabel.AutoSize = true;
			this.subjectLabel.Location = new System.Drawing.Point(20, 30);
			this.subjectLabel.Name = "subjectLabel";
			this.subjectLabel.Size = new System.Drawing.Size(35, 13);
			this.subjectLabel.TabIndex = 0;
			this.subjectLabel.Text = "Event subject:";
			// 
			// subjectTextBox
			// 
			this.subjectTextBox.Location = new System.Drawing.Point(99, 26);
			this.subjectTextBox.Name = "subjectTextBox";
			this.subjectTextBox.Size = new System.Drawing.Size(305, 20);
			this.subjectTextBox.TabIndex = 1;
			// 
			// startDateLabel
			// 
			this.startDateLabel.AutoSize = true;
			this.startDateLabel.Location = new System.Drawing.Point(20, 75);
			this.startDateLabel.Name = "startDateLabel";
			this.startDateLabel.Size = new System.Drawing.Size(35, 13);
			this.startDateLabel.TabIndex = 2;
			this.startDateLabel.Text = "Start  time:";
			// 
			// startDateDateTimePicker
			// 
			this.startDateDateTimePicker.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
			this.startDateDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt";
			this.startDateDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
			this.startDateDateTimePicker.Location = new System.Drawing.Point(99, 71);
			this.startDateDateTimePicker.Name = "startDateDateTimePicker";
			this.startDateDateTimePicker.Size = new System.Drawing.Size(305, 21);
			this.startDateDateTimePicker.TabIndex = 3;
			this.startDateDateTimePicker.ValueChanged += new System.EventHandler(this.startDateDateTimePicker_ValueChanged);
			// 
			// endDateDateTimePicker
			// 
			this.endDateDateTimePicker.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
			this.endDateDateTimePicker.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt";
			this.endDateDateTimePicker.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
			this.endDateDateTimePicker.Location = new System.Drawing.Point(99, 100);
			this.endDateDateTimePicker.Name = "endDateDateTimePicker";
			this.endDateDateTimePicker.Size = new System.Drawing.Size(305, 21);
			this.endDateDateTimePicker.TabIndex = 4;
			// 
			// endDateLabel
			// 
			this.endDateLabel.AutoSize = true;
			this.endDateLabel.Location = new System.Drawing.Point(20, 104);
			this.endDateLabel.Name = "endDateLabel";
			this.endDateLabel.Size = new System.Drawing.Size(35, 13);
			this.endDateLabel.TabIndex = 5;
			this.endDateLabel.Text = "End time:";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(250, 228);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelEventButton
			// 
			this.cancelEventButton.Location = new System.Drawing.Point(329, 228);
			this.cancelEventButton.Name = "cancelEventButton";
			this.cancelEventButton.Size = new System.Drawing.Size(75, 23);
			this.cancelEventButton.TabIndex = 7;
			this.cancelEventButton.Text = "Cancel";
			this.cancelEventButton.UseVisualStyleBackColor = true;
			this.cancelEventButton.Click += new System.EventHandler(this.cancelEventButton_Click);
			// 
			// tagLabel
			// 
			this.tagLabel.AutoSize = true;
			this.tagLabel.Location = new System.Drawing.Point(20, 148);
			this.tagLabel.Name = "tagLabel";
			this.tagLabel.Size = new System.Drawing.Size(35, 13);
			this.tagLabel.TabIndex = 8;
			this.tagLabel.Text = "Details:";
			// 
			// tagTextBox
			// 
			this.tagTextBox.Location = new System.Drawing.Point(99, 144);
			this.tagTextBox.Multiline = true;
			this.tagTextBox.Name = "tagTextBox";
			this.tagTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
			this.tagTextBox.Size = new System.Drawing.Size(305, 68);
			this.tagTextBox.TabIndex = 9;
			// 
			// testButton
			// 
			this.testButton.AutoSize = true;
			this.testButton.Location = new System.Drawing.Point(23, 228);
			this.testButton.Name = "testButton";
			this.testButton.Size = new System.Drawing.Size(113, 23);
			this.testButton.TabIndex = 6;
			this.testButton.Text = "Fill with a test data";
			this.testButton.UseVisualStyleBackColor = true;
			this.testButton.Click += new System.EventHandler(this.testButton_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.BlinkRate = 3;
			this.errorProvider1.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
			// 
			// EventForm
			// 
			this.AcceptButton = this.okButton;
			this.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
			this.CancelButton = this.cancelEventButton;
			this.Controls.Add(this.testButton);
			this.Controls.Add(this.tagTextBox);
			this.Controls.Add(this.tagLabel);
			this.Controls.Add(this.cancelEventButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.endDateLabel);
			this.Controls.Add(this.endDateDateTimePicker);
			this.Controls.Add(this.startDateDateTimePicker);
			this.Controls.Add(this.startDateLabel);
			this.Controls.Add(this.subjectTextBox);
			this.Controls.Add(this.subjectLabel);
			this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.None;
			this.Size = new System.Drawing.Size(442, 272);
			this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
			this.Text = "Event details";
			this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label subjectLabel;
        private Gizmox.WebGUI.Forms.TextBox subjectTextBox;
        private Gizmox.WebGUI.Forms.Label startDateLabel;
        private Gizmox.WebGUI.Forms.DateTimePicker endDateDateTimePicker;
        private Gizmox.WebGUI.Forms.Label endDateLabel;
        private Gizmox.WebGUI.Forms.Button okButton;
        private Gizmox.WebGUI.Forms.Button cancelEventButton;
        private Gizmox.WebGUI.Forms.Label tagLabel;
        private Gizmox.WebGUI.Forms.TextBox tagTextBox;
        public Gizmox.WebGUI.Forms.DateTimePicker startDateDateTimePicker;
		private Gizmox.WebGUI.Forms.Button testButton;
		private Gizmox.WebGUI.Forms.ErrorProvider errorProvider1;


    }
}