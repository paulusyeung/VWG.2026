namespace CompanionKit.Concepts.VisualEffects.BoxShadow
{
    partial class BoxShadowPage
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
            this.mobjColorPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjMonthCalendar = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.mobjShadowInsetCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjToggleButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjColorDialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjThirdTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSecondTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjChooseColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFirstTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPaddingPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel.SuspendLayout();
            this.mobjThirdTopPanel.SuspendLayout();
            this.mobjSecondTopPanel.SuspendLayout();
            this.mobjFirstTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.mobjPaddingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjColorPanel
            // 
            this.mobjColorPanel.AccessibleDescription = "";
            this.mobjColorPanel.AccessibleName = "";
            this.mobjColorPanel.BackColor = System.Drawing.Color.Black;
            this.mobjColorPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjColorPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjColorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColorPanel.Location = new System.Drawing.Point(15, 0);
            this.mobjColorPanel.Name = "objColorPanel";
            this.mobjColorPanel.Size = new System.Drawing.Size(64, 41);
            this.mobjColorPanel.TabIndex = 10;
            this.mobjColorPanel.BackColorChanged += new System.EventHandler(this.mobjColorPanel_BackColorChanged);
            // 
            // mobjMonthCalendar
            // 
            this.mobjMonthCalendar.AccessibleDescription = "";
            this.mobjMonthCalendar.AccessibleName = "";
            this.mobjMonthCalendar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjMonthCalendar.Location = new System.Drawing.Point(35, 26);
            this.mobjMonthCalendar.Name = "objMonthCalendar";
            this.mobjMonthCalendar.SelectionEnd = new System.DateTime(2013, 9, 5, 8, 43, 42, 659);
            this.mobjMonthCalendar.SelectionRange = new Gizmox.WebGUI.Forms.SelectionRange(new System.DateTime(2013, 9, 5, 0, 0, 0, 0), new System.DateTime(2013, 9, 5, 0, 0, 0, 0));
            this.mobjMonthCalendar.SelectionStart = new System.DateTime(2013, 9, 5, 8, 43, 42, 659);
            this.mobjMonthCalendar.Size = new System.Drawing.Size(227, 162);
            this.mobjMonthCalendar.TabIndex = 9;
            this.mobjMonthCalendar.Value = new System.DateTime(2013, 9, 5, 8, 43, 42, 659);
            // 
            // mobjShadowInsetCheckBox
            // 
            this.mobjShadowInsetCheckBox.AccessibleDescription = "";
            this.mobjShadowInsetCheckBox.AccessibleName = "";
            this.mobjShadowInsetCheckBox.AutoSize = true;
            this.mobjShadowInsetCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjShadowInsetCheckBox.Location = new System.Drawing.Point(30, 0);
            this.mobjShadowInsetCheckBox.Name = "objShadowInsetCheckBox";
            this.mobjShadowInsetCheckBox.Size = new System.Drawing.Size(79, 39);
            this.mobjShadowInsetCheckBox.TabIndex = 6;
            this.mobjShadowInsetCheckBox.Text = "Apply inset";
            this.mobjShadowInsetCheckBox.CheckedChanged += new System.EventHandler(this.mobjShadowInsetCheckBox_CheckedChanged);
            // 
            // mobjToggleButton
            // 
            this.mobjToggleButton.AccessibleDescription = "";
            this.mobjToggleButton.AccessibleName = "";
            this.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjToggleButton.Location = new System.Drawing.Point(30, 5);
            this.mobjToggleButton.Name = "objApplyButton";
            this.mobjToggleButton.Size = new System.Drawing.Size(241, 46);
            this.mobjToggleButton.TabIndex = 7;
            this.mobjToggleButton.Text = "Show BoxShadow";
            this.mobjToggleButton.Click += new System.EventHandler(this.mobjToggleButton_Click);
            // 
            // mobjColorDialog
            // 
            this.mobjColorDialog.Closed += new System.EventHandler(this.mobjColorDialog_Closed);
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.AccessibleDescription = "";
            this.mobjTopPanel.AccessibleName = "";
            this.mobjTopPanel.Controls.Add(this.mobjThirdTopPanel);
            this.mobjTopPanel.Controls.Add(this.mobjSecondTopPanel);
            this.mobjTopPanel.Controls.Add(this.mobjFirstTopPanel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 10);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(301, 150);
            this.mobjTopPanel.TabIndex = 11;
            // 
            // mobjThirdTopPanel
            // 
            this.mobjThirdTopPanel.AccessibleDescription = "";
            this.mobjThirdTopPanel.AccessibleName = "";
            this.mobjThirdTopPanel.Controls.Add(this.mobjToggleButton);
            this.mobjThirdTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjThirdTopPanel.DockPadding.Bottom = 5;
            this.mobjThirdTopPanel.DockPadding.Left = 30;
            this.mobjThirdTopPanel.DockPadding.Right = 30;
            this.mobjThirdTopPanel.DockPadding.Top = 5;
            this.mobjThirdTopPanel.Location = new System.Drawing.Point(0, 94);
            this.mobjThirdTopPanel.Name = "mobjThirdTopPanel";
            this.mobjThirdTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 5, 30, 5);
            this.mobjThirdTopPanel.Size = new System.Drawing.Size(301, 56);
            this.mobjThirdTopPanel.TabIndex = 13;
            // 
            // mobjSecondTopPanel
            // 
            this.mobjSecondTopPanel.AccessibleDescription = "";
            this.mobjSecondTopPanel.AccessibleName = "";
            this.mobjSecondTopPanel.Controls.Add(this.mobjPaddingPanel);
            this.mobjSecondTopPanel.Controls.Add(this.mobjChooseColorButton);
            this.mobjSecondTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSecondTopPanel.DockPadding.Bottom = 7;
            this.mobjSecondTopPanel.DockPadding.Left = 30;
            this.mobjSecondTopPanel.DockPadding.Top = 7;
            this.mobjSecondTopPanel.Location = new System.Drawing.Point(0, 39);
            this.mobjSecondTopPanel.Name = "panel2";
            this.mobjSecondTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 7, 0, 7);
            this.mobjSecondTopPanel.Size = new System.Drawing.Size(301, 55);
            this.mobjSecondTopPanel.TabIndex = 12;
            // 
            // mobjChooseColorButton
            // 
            this.mobjChooseColorButton.AccessibleDescription = "";
            this.mobjChooseColorButton.AccessibleName = "";
            this.mobjChooseColorButton.AutoSize = true;
            this.mobjChooseColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjChooseColorButton.Location = new System.Drawing.Point(30, 7);
            this.mobjChooseColorButton.Name = "button1";
            this.mobjChooseColorButton.Size = new System.Drawing.Size(152, 41);
            this.mobjChooseColorButton.TabIndex = 11;
            this.mobjChooseColorButton.Text = "Choose ShadowColor";
            this.mobjChooseColorButton.Click += new System.EventHandler(this.mobjChooseColorButton_Click);
            // 
            // mobjFirstTopPanel
            // 
            this.mobjFirstTopPanel.AccessibleDescription = "";
            this.mobjFirstTopPanel.AccessibleName = "";
            this.mobjFirstTopPanel.Controls.Add(this.mobjShadowInsetCheckBox);
            this.mobjFirstTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFirstTopPanel.DockPadding.Left = 30;
            this.mobjFirstTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjFirstTopPanel.Name = "panel1";
            this.mobjFirstTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 0, 0, 0);
            this.mobjFirstTopPanel.Size = new System.Drawing.Size(301, 39);
            this.mobjFirstTopPanel.TabIndex = 11;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjMonthCalendar);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(0, 160);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(301, 222);
            this.mobjBottomPanel.TabIndex = 12;
            // 
            // mobjPaddingPanel
            // 
            this.mobjPaddingPanel.AccessibleDescription = "";
            this.mobjPaddingPanel.AccessibleName = "";
            this.mobjPaddingPanel.Controls.Add(this.mobjColorPanel);
            this.mobjPaddingPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjPaddingPanel.DockPadding.Left = 15;
            this.mobjPaddingPanel.Location = new System.Drawing.Point(182, 7);
            this.mobjPaddingPanel.Name = "mobjPaddingPanel";
            this.mobjPaddingPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0);
            this.mobjPaddingPanel.Size = new System.Drawing.Size(100, 41);
            this.mobjPaddingPanel.TabIndex = 12;
            // 
            // BoxShadowPage
            // 
            this.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjTopPanel);
            this.DockPadding.Top = 10;
            this.Location = new System.Drawing.Point(0, -9);
            this.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0);
            this.Size = new System.Drawing.Size(301, 382);
            this.Text = "BoxShadowPage";
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjThirdTopPanel.ResumeLayout(false);
            this.mobjSecondTopPanel.ResumeLayout(false);
            this.mobjFirstTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.mobjPaddingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mobjColorPanel;
        private Gizmox.WebGUI.Forms.MonthCalendar mobjMonthCalendar;
        private Gizmox.WebGUI.Forms.CheckBox mobjShadowInsetCheckBox;
        private Gizmox.WebGUI.Forms.Button mobjToggleButton;
        private Gizmox.WebGUI.Forms.ColorDialog mobjColorDialog;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.Panel mobjThirdTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSecondTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFirstTopPanel;
        private Gizmox.WebGUI.Forms.Button mobjChooseColorButton;
        private Gizmox.WebGUI.Forms.Panel mobjPaddingPanel;




    }
}