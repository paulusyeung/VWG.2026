namespace CompanionKit.Concepts.VisualEffects.BorderImage
{
    partial class BorderImagePage
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
            this.mobjBorderRepeatComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjBorderRepeatLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjVisualButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBorderRepeatPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBorderRepeatPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjBorderRepeatComboBox
            // 
            this.mobjBorderRepeatComboBox.AccessibleDescription = "";
            this.mobjBorderRepeatComboBox.AccessibleName = "";
            this.mobjBorderRepeatComboBox.AllowDrag = false;
            this.mobjBorderRepeatComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjBorderRepeatComboBox.FormattingEnabled = true;
            this.mobjBorderRepeatComboBox.Items.AddRange(new object[] {
            "None",
            "Stretch",
            "Repeat",
            "Round"});
            this.mobjBorderRepeatComboBox.Location = new System.Drawing.Point(30, 53);
            this.mobjBorderRepeatComboBox.Name = "objBorderRepeatComboBox";
            this.mobjBorderRepeatComboBox.Size = new System.Drawing.Size(196, 21);
            this.mobjBorderRepeatComboBox.TabIndex = 5;
            this.mobjBorderRepeatComboBox.Text = "None";
            this.mobjBorderRepeatComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjBorderRepeatComboBox_SelectedIndexChanged);
            // 
            // mobjBorderRepeatLabel
            // 
            this.mobjBorderRepeatLabel.AccessibleDescription = "";
            this.mobjBorderRepeatLabel.AccessibleName = "";
            this.mobjBorderRepeatLabel.AutoSize = true;
            this.mobjBorderRepeatLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjBorderRepeatLabel.Location = new System.Drawing.Point(30, 30);
            this.mobjBorderRepeatLabel.Name = "objBorderRepeatLabel";
            this.mobjBorderRepeatLabel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjBorderRepeatLabel.Size = new System.Drawing.Size(87, 23);
            this.mobjBorderRepeatLabel.TabIndex = 4;
            this.mobjBorderRepeatLabel.Text = "Border Repeat";
            // 
            // mobjVisualButton
            // 
            this.mobjVisualButton.AccessibleDescription = "";
            this.mobjVisualButton.AccessibleName = "";
            this.mobjVisualButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjVisualButton.Location = new System.Drawing.Point(30, 30);
            this.mobjVisualButton.Name = "objVisualButton";
            this.mobjVisualButton.Size = new System.Drawing.Size(196, 86);
            this.mobjVisualButton.TabIndex = 0;
            this.mobjVisualButton.Text = "Button";
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.AccessibleDescription = "";
            this.mobjTopPanel.AccessibleName = "";
            this.mobjTopPanel.Controls.Add(this.mobjBorderRepeatPanel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTopPanel.Location = new System.Drawing.Point(30, 30);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(256, 125);
            this.mobjTopPanel.TabIndex = 7;
            // 
            // mobjBorderRepeatPanel
            // 
            this.mobjBorderRepeatPanel.AccessibleDescription = "";
            this.mobjBorderRepeatPanel.AccessibleName = "";
            this.mobjBorderRepeatPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjBorderRepeatPanel.Controls.Add(this.mobjBorderRepeatComboBox);
            this.mobjBorderRepeatPanel.Controls.Add(this.mobjBorderRepeatLabel);
            this.mobjBorderRepeatPanel.DockPadding.Bottom = 15;
            this.mobjBorderRepeatPanel.DockPadding.Left = 30;
            this.mobjBorderRepeatPanel.DockPadding.Right = 30;
            this.mobjBorderRepeatPanel.DockPadding.Top = 30;
            this.mobjBorderRepeatPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjBorderRepeatPanel.Name = "objBorderRepeatPanel";
            this.mobjBorderRepeatPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 30, 30, 15);
            this.mobjBorderRepeatPanel.Size = new System.Drawing.Size(256, 130);
            this.mobjBorderRepeatPanel.TabIndex = 8;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjVisualButton);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.DockPadding.All = 30;
            this.mobjBottomPanel.Location = new System.Drawing.Point(30, 155);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30);
            this.mobjBottomPanel.Size = new System.Drawing.Size(256, 146);
            this.mobjBottomPanel.TabIndex = 8;
            // 
            // BorderImagePage
            // 
            this.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjTopPanel);
            this.DockPadding.All = 30;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(30);
            this.Size = new System.Drawing.Size(316, 331);
            this.Text = "BorderImagePage";
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBorderRepeatPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjBorderRepeatComboBox;
        private Gizmox.WebGUI.Forms.Label mobjBorderRepeatLabel;
        private Gizmox.WebGUI.Forms.Button mobjVisualButton;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBorderRepeatPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;



    }
}