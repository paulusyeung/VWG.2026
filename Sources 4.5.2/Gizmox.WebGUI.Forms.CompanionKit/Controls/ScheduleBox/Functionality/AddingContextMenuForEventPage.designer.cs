namespace CompanionKit.Controls.ScheduleBox.Functionality
{
    partial class AddingContextMenuForEventPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingContextMenuForEventPage));
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.objAppearance = new CompanionKit.Controls.ScheduleBox.Appearence();
			this.demoScheduleBox = new Gizmox.WebGUI.Forms.ScheduleBox();
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			this.objEventMenu = new Gizmox.WebGUI.Forms.ContextMenu();
			this.menuOpen = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuNew = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuDelete = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuRecreate = new Gizmox.WebGUI.Forms.MenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.objAppearance);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(180, 674);
			this.panel1.TabIndex = 2;
			// 
			// objAppearance
			// 
			this.objAppearance.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
			this.objAppearance.Location = new System.Drawing.Point(0, 0);
			this.objAppearance.Name = "objAppearance";
			this.objAppearance.ScheduleBox = null;
			this.objAppearance.Size = new System.Drawing.Size(181, 616);
			this.objAppearance.TabIndex = 1;
			this.objAppearance.Text = "Appearence";
			// 
			// demoScheduleBox
			// 
			this.demoScheduleBox.DisplayMonthHeader = true;
			this.demoScheduleBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.demoScheduleBox.FirstDate = new System.DateTime(2010, 5, 31, 11, 29, 51, 227);
			this.demoScheduleBox.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday;
			this.demoScheduleBox.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock24H;
			this.demoScheduleBox.Location = new System.Drawing.Point(0, 0);
			this.demoScheduleBox.Name = "demoScheduleBox";
			this.demoScheduleBox.Size = new System.Drawing.Size(479, 674);
			this.demoScheduleBox.TabIndex = 0;
			this.demoScheduleBox.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Day;
			this.demoScheduleBox.WorkEndHour = 17;
			this.demoScheduleBox.WorkStartHour = 9;
			this.demoScheduleBox.EventDoubleClick += new Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventHandler(this.EventDoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.demoScheduleBox);
			this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(180, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(479, 674);
			this.panel2.TabIndex = 3;
			// 
			// objEventMenu
			// 
			this.objEventMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuOpen,
            this.menuNew,
            this.menuDelete,
            this.menuRecreate});
			// 
			// menuOpen
			// 
			this.menuOpen.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuOpen.Icon"));
			this.menuOpen.Index = 0;
			this.menuOpen.Tag = "open";
			this.menuOpen.Text = "Open";
			// 
			// menuNew
			// 
			this.menuNew.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuNew.Icon"));
			this.menuNew.Index = 1;
			this.menuNew.Tag = "new";
			this.menuNew.Text = "Add new ...";
			// 
			// menuDelete
			// 
			this.menuDelete.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuDelete.Icon"));
			this.menuDelete.Index = 2;
			this.menuDelete.Tag = "delete";
			this.menuDelete.Text = "Delete";
			// 
			// menuRecreate
			// 
			this.menuRecreate.Icon = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("menuRecreate.Icon"));
			this.menuRecreate.Index = 3;
			this.menuRecreate.Tag = "recreate";
			this.menuRecreate.Text = "Re-create";
			// 
			// AddingContextMenuForEventPage
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Size = new System.Drawing.Size(659, 674);
			this.Text = "AddingContextMenuForEventPage";
			this.Load += new System.EventHandler(this.AddingContextMenuForEventPage_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private Appearence objAppearance;
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.ScheduleBox demoScheduleBox;
		private Gizmox.WebGUI.Forms.Panel panel2;
		private Gizmox.WebGUI.Forms.ContextMenu objEventMenu;
		private Gizmox.WebGUI.Forms.MenuItem menuOpen;
		private Gizmox.WebGUI.Forms.MenuItem menuNew;
		private Gizmox.WebGUI.Forms.MenuItem menuDelete;
		private Gizmox.WebGUI.Forms.MenuItem menuRecreate;




	}
}