namespace CompanionKit.Concepts.ControlBehavior.DraggableFeature
{
    partial class DraggableFeaturePage
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
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTargetPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjRevertModeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjRevertLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSnapModeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjSnapModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSnapToLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSnapToComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTargetPanel.SuspendLayout();
            this.mobjGroupBox.SuspendLayout();
            this.mobjContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButton
            // 
            this.mobjButton.AccessibleDescription = "";
            this.mobjButton.AccessibleName = "";
            this.mobjButton.Draggable = new Gizmox.WebGUI.Forms.DraggableOptions(true);
            this.mobjButton.Location = new System.Drawing.Point(38, 67);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(100, 100);
            this.mobjButton.TabIndex = 2;
            this.mobjButton.Text = "Draggable Button";
            this.mobjButton.LocationChanged += new System.EventHandler(this.mobjButton_LocationChanged);
            // 
            // mobjTargetPanel
            // 
            this.mobjTargetPanel.AccessibleDescription = "";
            this.mobjTargetPanel.AccessibleName = "";
            this.mobjTargetPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Red);
            this.mobjTargetPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjTargetPanel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjTargetPanel.Controls.Add(this.mobjLabel);
            this.mobjTargetPanel.Location = new System.Drawing.Point(297, 66);
            this.mobjTargetPanel.Name = "mobjTargetPanel";
            this.mobjTargetPanel.Size = new System.Drawing.Size(102, 102);
            this.mobjTargetPanel.TabIndex = 1;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AccessibleDescription = "";
            this.mobjLabel.AccessibleName = "";
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(100, 100);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Drag here";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.AccessibleDescription = "";
            this.mobjCheckBox.AccessibleName = "";
            this.mobjCheckBox.AutoSize = true;
            this.mobjCheckBox.Checked = true;
            this.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjCheckBox.Location = new System.Drawing.Point(23, 33);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(124, 17);
            this.mobjCheckBox.TabIndex = 3;
            this.mobjCheckBox.Text = "Allow to drag button";
            this.mobjCheckBox.CheckedChanged += new System.EventHandler(this.mobjCheckBox_CheckedChanged);
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.AccessibleDescription = "";
            this.mobjGroupBox.AccessibleName = "";
            this.mobjGroupBox.Controls.Add(this.mobjRevertModeComboBox);
            this.mobjGroupBox.Controls.Add(this.mobjRevertLabel);
            this.mobjGroupBox.Controls.Add(this.mobjSnapModeComboBox);
            this.mobjGroupBox.Controls.Add(this.mobjSnapModeLabel);
            this.mobjGroupBox.Controls.Add(this.mobjSnapToLabel);
            this.mobjGroupBox.Controls.Add(this.mobjSnapToComboBox);
            this.mobjGroupBox.Controls.Add(this.mobjCheckBox);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(15, 179);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(413, 160);
            this.mobjGroupBox.TabIndex = 4;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "Options";
            // 
            // mobjRevertModeComboBox
            // 
            this.mobjRevertModeComboBox.AccessibleDescription = "";
            this.mobjRevertModeComboBox.AccessibleName = "";
            this.mobjRevertModeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjRevertModeComboBox.FormattingEnabled = true;
            this.mobjRevertModeComboBox.Items.AddRange(new object[] {
            "None",
            "Always",
            "Invalid",
            "Valid"});
            this.mobjRevertModeComboBox.Location = new System.Drawing.Point(152, 60);
            this.mobjRevertModeComboBox.Name = "mobjRevertModeComboBox";
            this.mobjRevertModeComboBox.Size = new System.Drawing.Size(100, 21);
            this.mobjRevertModeComboBox.TabIndex = 5;
            this.mobjRevertModeComboBox.Text = "None";
            this.mobjRevertModeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjRevertModeComboBox_SelectedIndexChanged);
            // 
            // mobjRevertLabel
            // 
            this.mobjRevertLabel.AccessibleDescription = "";
            this.mobjRevertLabel.AccessibleName = "";
            this.mobjRevertLabel.AutoSize = true;
            this.mobjRevertLabel.Location = new System.Drawing.Point(20, 63);
            this.mobjRevertLabel.Name = "mobjRevertLabel";
            this.mobjRevertLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjRevertLabel.TabIndex = 7;
            this.mobjRevertLabel.Text = "RevertMode";
            // 
            // mobjSnapModeComboBox
            // 
            this.mobjSnapModeComboBox.AccessibleDescription = "";
            this.mobjSnapModeComboBox.AccessibleName = "";
            this.mobjSnapModeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjSnapModeComboBox.FormattingEnabled = true;
            this.mobjSnapModeComboBox.Items.AddRange(new object[] {
            "Both",
            "Inner",
            "Outer"});
            this.mobjSnapModeComboBox.Location = new System.Drawing.Point(152, 92);
            this.mobjSnapModeComboBox.Name = "mobjSnapModeComboBox";
            this.mobjSnapModeComboBox.Size = new System.Drawing.Size(100, 21);
            this.mobjSnapModeComboBox.TabIndex = 9;
            this.mobjSnapModeComboBox.Text = "Both";
            this.mobjSnapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjSnapModeComboBox_SelectedIndexChanged);
            // 
            // mobjSnapModeLabel
            // 
            this.mobjSnapModeLabel.AccessibleDescription = "";
            this.mobjSnapModeLabel.AccessibleName = "";
            this.mobjSnapModeLabel.AutoSize = true;
            this.mobjSnapModeLabel.Location = new System.Drawing.Point(20, 95);
            this.mobjSnapModeLabel.Name = "mobjSnapModeLabel";
            this.mobjSnapModeLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjSnapModeLabel.TabIndex = 10;
            this.mobjSnapModeLabel.Text = "SnapMode";
            // 
            // mobjSnapToLabel
            // 
            this.mobjSnapToLabel.AccessibleDescription = "";
            this.mobjSnapToLabel.AccessibleName = "";
            this.mobjSnapToLabel.AutoSize = true;
            this.mobjSnapToLabel.Location = new System.Drawing.Point(20, 125);
            this.mobjSnapToLabel.Name = "mobjSnapToLabel";
            this.mobjSnapToLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjSnapToLabel.TabIndex = 11;
            this.mobjSnapToLabel.Text = "SnapTo";
            // 
            // mobjSnapToComboBox
            // 
            this.mobjSnapToComboBox.AccessibleDescription = "";
            this.mobjSnapToComboBox.AccessibleName = "";
            this.mobjSnapToComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjSnapToComboBox.FormattingEnabled = true;
            this.mobjSnapToComboBox.Items.AddRange(new object[] {
            "None",
            "All",
            "Siblings"});
            this.mobjSnapToComboBox.Location = new System.Drawing.Point(152, 125);
            this.mobjSnapToComboBox.Name = "mobjSnapToComboBox";
            this.mobjSnapToComboBox.Size = new System.Drawing.Size(100, 21);
            this.mobjSnapToComboBox.TabIndex = 13;
            this.mobjSnapToComboBox.Text = "None";
            this.mobjSnapToComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjSnapToComboBox_SelectedIndexChanged);
            // 
            // mobjContainerPanel
            // 
            this.mobjContainerPanel.AccessibleDescription = "";
            this.mobjContainerPanel.AccessibleName = "";
            this.mobjContainerPanel.Controls.Add(this.mobjButton);
            this.mobjContainerPanel.Controls.Add(this.mobjGroupBox);
            this.mobjContainerPanel.Controls.Add(this.mobjTargetPanel);
            this.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerPanel.DockPadding.Bottom = 15;
            this.mobjContainerPanel.DockPadding.Left = 15;
            this.mobjContainerPanel.DockPadding.Right = 15;
            this.mobjContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjContainerPanel.Name = "mobjContainerPanel";
            this.mobjContainerPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 0, 15, 15);
            this.mobjContainerPanel.Size = new System.Drawing.Size(443, 354);
            this.mobjContainerPanel.TabIndex = 5;
            // 
            // DraggableFeaturePage
            // 
            this.Controls.Add(this.mobjContainerPanel);
            this.MaximumSize = new System.Drawing.Size(1000, 0);
            this.Size = new System.Drawing.Size(443, 354);
            this.Text = "DraggableFeaturePage";
            this.Load += new System.EventHandler(this.DraggableFeaturePage_Load);
            this.mobjTargetPanel.ResumeLayout(false);
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Panel mobjTargetPanel;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjRevertModeComboBox;
        private Gizmox.WebGUI.Forms.Label mobjRevertLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjSnapModeComboBox;
        private Gizmox.WebGUI.Forms.Label mobjSnapModeLabel;
        private Gizmox.WebGUI.Forms.Label mobjSnapToLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjSnapToComboBox;
        private Gizmox.WebGUI.Forms.Panel mobjContainerPanel;



    }
}