namespace CompanionKit.Controls.PropertyGrid.ApplicationScenarios
{
    partial class ExampleApplicationPage
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
            this.demoDateTimePicker = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.mobjOptionsContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
            this.optionsMenuItem = new Gizmox.WebGUI.Forms.MenuItem();
            this.eventSummaryTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.createEventsButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjEventsListView = new Gizmox.WebGUI.Forms.ListView();
            this.dateEventColumn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.eventSummaryColumn = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.descriptionlabel = new Gizmox.WebGUI.Forms.Label();
            this.eventSummaryLabel = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // demoDateTimePicker
            // 
            this.demoDateTimePicker.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.demoDateTimePicker.ContextMenu = this.mobjOptionsContextMenu;
            this.demoDateTimePicker.CustomFormat = "";
            this.demoDateTimePicker.Location = new System.Drawing.Point(39, 29);
            this.demoDateTimePicker.Name = "demoDateTimePicker";
            this.demoDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.demoDateTimePicker.TabIndex = 0;
            // 
            // optionsContextMenu
            // 
            this.mobjOptionsContextMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.optionsMenuItem});
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Index = 0;
            this.optionsMenuItem.Text = "Options...";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // eventSummaryTextBox
            // 
            this.eventSummaryTextBox.ContextMenu = this.mobjOptionsContextMenu;
            this.eventSummaryTextBox.Location = new System.Drawing.Point(346, 29);
            this.eventSummaryTextBox.Name = "eventSummaryTextBox";
            this.eventSummaryTextBox.Size = new System.Drawing.Size(223, 20);
            this.eventSummaryTextBox.TabIndex = 1;
            // 
            // createEventsButton
            // 
            this.createEventsButton.ContextMenu = this.mobjOptionsContextMenu;
            this.createEventsButton.Location = new System.Drawing.Point(451, 61);
            this.createEventsButton.Name = "createEventsButton";
            this.createEventsButton.Size = new System.Drawing.Size(118, 23);
            this.createEventsButton.TabIndex = 2;
            this.createEventsButton.Text = "Create event";
            this.createEventsButton.UseVisualStyleBackColor = true;
            this.createEventsButton.Click += new System.EventHandler(this.createEventsButton_Click);
            // 
            // eventsListView
            // 
            this.mobjEventsListView.AutoGenerateColumns = true;
            this.mobjEventsListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.dateEventColumn,
            this.eventSummaryColumn});
            this.mobjEventsListView.ContextMenu = this.mobjOptionsContextMenu;
            this.mobjEventsListView.DataMember = null;
            this.mobjEventsListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjEventsListView.ForeColor = System.Drawing.Color.Blue;
            this.mobjEventsListView.ItemsPerPage = 20;
            this.mobjEventsListView.Location = new System.Drawing.Point(39, 110);
            this.mobjEventsListView.Name = "eventsListView";
            this.mobjEventsListView.ShowItemToolTips = false;
            this.mobjEventsListView.Size = new System.Drawing.Size(530, 185);
            this.mobjEventsListView.TabIndex = 3;
            this.mobjEventsListView.TotalItems = 1;
            // 
            // dateEventColumn
            // 
            this.dateEventColumn.ContextMenu = this.mobjOptionsContextMenu;
            this.dateEventColumn.Image = null;
            this.dateEventColumn.Text = "Time of event";
            this.dateEventColumn.Width = 200;
            // 
            // eventSummaryColumn
            // 
            this.eventSummaryColumn.ContextMenu = this.mobjOptionsContextMenu;
            this.eventSummaryColumn.Image = null;
            this.eventSummaryColumn.Text = "Event summary";
            this.eventSummaryColumn.Width = 350;
            // 
            // descriptionlabel
            // 
            this.descriptionlabel.AutoSize = true;
            this.descriptionlabel.Location = new System.Drawing.Point(39, 91);
            this.descriptionlabel.Name = "descriptionlabel";
            this.descriptionlabel.Size = new System.Drawing.Size(35, 13);
            this.descriptionlabel.TabIndex = 4;
            this.descriptionlabel.Text = "Right click the event to change properties";
            // 
            // eventSummaryLabel
            // 
            this.eventSummaryLabel.AutoSize = true;
            this.eventSummaryLabel.Location = new System.Drawing.Point(259, 33);
            this.eventSummaryLabel.Name = "eventSummaryLabel";
            this.eventSummaryLabel.Size = new System.Drawing.Size(35, 13);
            this.eventSummaryLabel.TabIndex = 5;
            this.eventSummaryLabel.Text = "Event summary";
            // 
            // ExampleApplicationPage
            // 
            this.ContextMenu = this.mobjOptionsContextMenu;
            this.Controls.Add(this.eventSummaryLabel);
            this.Controls.Add(this.descriptionlabel);
            this.Controls.Add(this.mobjEventsListView);
            this.Controls.Add(this.createEventsButton);
            this.Controls.Add(this.eventSummaryTextBox);
            this.Controls.Add(this.demoDateTimePicker);
            this.Size = new System.Drawing.Size(632, 306);
            this.Text = "ExampleApplicationPage";
            this.Load += new System.EventHandler(this.ExampleApplicationPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DateTimePicker demoDateTimePicker;
        private Gizmox.WebGUI.Forms.TextBox eventSummaryTextBox;
        private Gizmox.WebGUI.Forms.Button createEventsButton;
        private Gizmox.WebGUI.Forms.ListView mobjEventsListView;
        private Gizmox.WebGUI.Forms.ColumnHeader dateEventColumn;
        private Gizmox.WebGUI.Forms.ColumnHeader eventSummaryColumn;
        private Gizmox.WebGUI.Forms.ContextMenu mobjOptionsContextMenu;
        private Gizmox.WebGUI.Forms.MenuItem optionsMenuItem;
        private Gizmox.WebGUI.Forms.Label descriptionlabel;
        private Gizmox.WebGUI.Forms.Label eventSummaryLabel;



    }
}
