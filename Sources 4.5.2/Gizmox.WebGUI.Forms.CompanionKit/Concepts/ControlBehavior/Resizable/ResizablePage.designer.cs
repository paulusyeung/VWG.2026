namespace CompanionKit.Concepts.ControlBehavior.Resizable
{
    partial class ResizablePage
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
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabelInfo = new Gizmox.WebGUI.Forms.Label();
            this.mobjAspectRatio = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjIsGhost = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjIsAnimated = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLabelSize = new Gizmox.WebGUI.Forms.Label();
            this.mobjResetButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDurationLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjDurationNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjGridLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjGridNUD = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDurationNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjGridNUD)).BeginInit();
            this.mobjGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.BackColor = System.Drawing.Color.LightGray;
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjPanel.Location = new System.Drawing.Point(12, 54);
            this.mobjPanel.MaximumSize = new System.Drawing.Size(200, 200);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Resizable = new Gizmox.WebGUI.Forms.ResizableOptions(true);
            this.mobjPanel.Size = new System.Drawing.Size(100, 100);
            this.mobjPanel.TabIndex = 0;
            this.mobjPanel.Resize += new System.EventHandler(this.mobjPanel_Resize);
            // 
            // mobjLabelInfo
            // 
            this.mobjLabelInfo.AccessibleDescription = "";
            this.mobjLabelInfo.AccessibleName = "";
            this.mobjLabelInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabelInfo.Location = new System.Drawing.Point(9, 9);
            this.mobjLabelInfo.Name = "mobjLabelInfo";
            this.mobjLabelInfo.Size = new System.Drawing.Size(495, 45);
            this.mobjLabelInfo.TabIndex = 1;
            this.mobjLabelInfo.Text = "Resizable Panel. Maximum size {200, 200}.";
            // 
            // mobjAspectRatio
            // 
            this.mobjAspectRatio.AccessibleDescription = "";
            this.mobjAspectRatio.AccessibleName = "";
            this.mobjAspectRatio.Location = new System.Drawing.Point(9, 25);
            this.mobjAspectRatio.Name = "mobjAspectRatio";
            this.mobjAspectRatio.Size = new System.Drawing.Size(175, 25);
            this.mobjAspectRatio.TabIndex = 3;
            this.mobjAspectRatio.Text = "Aspect Ratio";
            this.mobjAspectRatio.CheckedChanged += new System.EventHandler(this.mobjAspectRatio_CheckedChanged);
            // 
            // mobjIsGhost
            // 
            this.mobjIsGhost.AccessibleDescription = "";
            this.mobjIsGhost.AccessibleName = "";
            this.mobjIsGhost.Location = new System.Drawing.Point(9, 52);
            this.mobjIsGhost.Name = "mobjIsGhost";
            this.mobjIsGhost.Size = new System.Drawing.Size(175, 25);
            this.mobjIsGhost.TabIndex = 4;
            this.mobjIsGhost.Text = "Ghost";
            this.mobjIsGhost.CheckedChanged += new System.EventHandler(this.mobjIsGhost_CheckedChanged);
            // 
            // mobjIsAnimated
            // 
            this.mobjIsAnimated.AccessibleDescription = "";
            this.mobjIsAnimated.AccessibleName = "";
            this.mobjIsAnimated.Location = new System.Drawing.Point(9, 79);
            this.mobjIsAnimated.Name = "mobjIsAnimated";
            this.mobjIsAnimated.Size = new System.Drawing.Size(175, 25);
            this.mobjIsAnimated.TabIndex = 5;
            this.mobjIsAnimated.Text = "Animation";
            this.mobjIsAnimated.CheckedChanged += new System.EventHandler(this.mobjIsAnimated_CheckedChanged);
            // 
            // mobjLabelSize
            // 
            this.mobjLabelSize.AccessibleDescription = "";
            this.mobjLabelSize.AccessibleName = "";
            this.mobjLabelSize.AutoSize = true;
            this.mobjLabelSize.Location = new System.Drawing.Point(9, 264);
            this.mobjLabelSize.Name = "mobjLabelSize";
            this.mobjLabelSize.Size = new System.Drawing.Size(33, 13);
            this.mobjLabelSize.TabIndex = 6;
            this.mobjLabelSize.Text = "Size: ";
            // 
            // mobjResetButton
            // 
            this.mobjResetButton.AccessibleDescription = "";
            this.mobjResetButton.AccessibleName = "";
            this.mobjResetButton.Location = new System.Drawing.Point(272, 257);
            this.mobjResetButton.Name = "mobjResetButton";
            this.mobjResetButton.Size = new System.Drawing.Size(148, 27);
            this.mobjResetButton.TabIndex = 7;
            this.mobjResetButton.Text = "Reset Size";
            this.mobjResetButton.Click += new System.EventHandler(this.mobjResetButton_Click);
            // 
            // mobjDurationLbl
            // 
            this.mobjDurationLbl.AccessibleDescription = "";
            this.mobjDurationLbl.AccessibleName = "";
            this.mobjDurationLbl.Location = new System.Drawing.Point(9, 112);
            this.mobjDurationLbl.Name = "mobjDurationLbl";
            this.mobjDurationLbl.Size = new System.Drawing.Size(138, 25);
            this.mobjDurationLbl.TabIndex = 8;
            this.mobjDurationLbl.Text = "Animation duration:";
            // 
            // mobjDurationNUD
            // 
            this.mobjDurationNUD.AccessibleDescription = "";
            this.mobjDurationNUD.AccessibleName = "";
            this.mobjDurationNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjDurationNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjDurationNUD.CurrentValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.mobjDurationNUD.Location = new System.Drawing.Point(147, 110);
            this.mobjDurationNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mobjDurationNUD.Name = "mobjDurationNUD";
            this.mobjDurationNUD.Size = new System.Drawing.Size(96, 17);
            this.mobjDurationNUD.TabIndex = 9;
            this.mobjDurationNUD.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.mobjDurationNUD.ValueChanged += new System.EventHandler(this.mobjDurationNUD_ValueChanged);
            // 
            // mobjGridLbl
            // 
            this.mobjGridLbl.AccessibleDescription = "";
            this.mobjGridLbl.AccessibleName = "";
            this.mobjGridLbl.Location = new System.Drawing.Point(9, 141);
            this.mobjGridLbl.Name = "mobjGridLbl";
            this.mobjGridLbl.Size = new System.Drawing.Size(109, 25);
            this.mobjGridLbl.TabIndex = 11;
            this.mobjGridLbl.Text = "Grid";
            // 
            // mobjGridNUD
            // 
            this.mobjGridNUD.AccessibleDescription = "";
            this.mobjGridNUD.AccessibleName = "";
            this.mobjGridNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjGridNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.mobjGridNUD.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mobjGridNUD.Location = new System.Drawing.Point(147, 139);
            this.mobjGridNUD.Name = "mobjGridNUD";
            this.mobjGridNUD.Size = new System.Drawing.Size(96, 17);
            this.mobjGridNUD.TabIndex = 13;
            this.mobjGridNUD.ValueChanged += new System.EventHandler(this.mobjGridNUD_ValueChanged);
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.AccessibleDescription = "";
            this.mobjGroupBox.AccessibleName = "";
            this.mobjGroupBox.Controls.Add(this.mobjAspectRatio);
            this.mobjGroupBox.Controls.Add(this.mobjIsGhost);
            this.mobjGroupBox.Controls.Add(this.mobjIsAnimated);
            this.mobjGroupBox.Controls.Add(this.mobjGridNUD);
            this.mobjGroupBox.Controls.Add(this.mobjGridLbl);
            this.mobjGroupBox.Controls.Add(this.mobjDurationLbl);
            this.mobjGroupBox.Controls.Add(this.mobjDurationNUD);
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(211, 51);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(265, 177);
            this.mobjGroupBox.TabIndex = 17;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "Resizable opions:";
            // 
            // ResizablePage
            // 
            this.Controls.Add(this.mobjGroupBox);
            this.Controls.Add(this.mobjLabelInfo);
            this.Controls.Add(this.mobjPanel);
            this.Controls.Add(this.mobjLabelSize);
            this.Controls.Add(this.mobjResetButton);
            this.Size = new System.Drawing.Size(495, 364);
            this.Text = "ResizablePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDurationNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjGridNUD)).EndInit();
            this.mobjGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Label mobjLabelInfo;
        private Gizmox.WebGUI.Forms.CheckBox mobjAspectRatio;
        private Gizmox.WebGUI.Forms.CheckBox mobjIsGhost;
        private Gizmox.WebGUI.Forms.CheckBox mobjIsAnimated;
        private Gizmox.WebGUI.Forms.Label mobjLabelSize;
        private Gizmox.WebGUI.Forms.Button mobjResetButton;
        private Gizmox.WebGUI.Forms.Label mobjDurationLbl;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjDurationNUD;
        private Gizmox.WebGUI.Forms.Label mobjGridLbl;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjGridNUD;
        private Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;


    }
}