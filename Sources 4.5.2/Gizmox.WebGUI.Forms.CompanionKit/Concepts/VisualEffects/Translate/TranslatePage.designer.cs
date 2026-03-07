namespace CompanionKit.Concepts.VisualEffects.Translate
{
    partial class TranslatePage
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
            this.mobjToggleButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSecondTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjFirstTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjDirectionGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjHorizontalCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjVerticalCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel.SuspendLayout();
            this.mobjSecondTopPanel.SuspendLayout();
            this.mobjFirstTopPanel.SuspendLayout();
            this.mobjDirectionGroupBox.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjApplyButton
            // 
            this.mobjToggleButton.AccessibleDescription = "";
            this.mobjToggleButton.AccessibleName = "";
            this.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjToggleButton.Location = new System.Drawing.Point(30, 10);
            this.mobjToggleButton.Name = "mobjApplyButton";
            this.mobjToggleButton.Size = new System.Drawing.Size(223, 41);
            this.mobjToggleButton.TabIndex = 14;
            this.mobjToggleButton.Text = "Apply Translate Visual Effect";
            this.mobjToggleButton.Click += new System.EventHandler(this.mobjToggleButton_Click);
            // 
            // objTopPanel
            // 
            this.mobjTopPanel.AccessibleDescription = "";
            this.mobjTopPanel.AccessibleName = "";
            this.mobjTopPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent);
            this.mobjTopPanel.Controls.Add(this.mobjSecondTopPanel);
            this.mobjTopPanel.Controls.Add(this.mobjFirstTopPanel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(283, 163);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjSecondTopPanel
            // 
            this.mobjSecondTopPanel.AccessibleDescription = "";
            this.mobjSecondTopPanel.AccessibleName = "";
            this.mobjSecondTopPanel.Controls.Add(this.mobjToggleButton);
            this.mobjSecondTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSecondTopPanel.DockPadding.Bottom = 10;
            this.mobjSecondTopPanel.DockPadding.Left = 30;
            this.mobjSecondTopPanel.DockPadding.Right = 30;
            this.mobjSecondTopPanel.DockPadding.Top = 10;
            this.mobjSecondTopPanel.Location = new System.Drawing.Point(0, 102);
            this.mobjSecondTopPanel.Name = "mobjSecondTopPanel";
            this.mobjSecondTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 10, 30, 10);
            this.mobjSecondTopPanel.Size = new System.Drawing.Size(283, 61);
            this.mobjSecondTopPanel.TabIndex = 16;
            // 
            // mobjFirstTopPanel
            // 
            this.mobjFirstTopPanel.AccessibleDescription = "";
            this.mobjFirstTopPanel.AccessibleName = "";
            this.mobjFirstTopPanel.Controls.Add(this.mobjDirectionGroupBox);
            this.mobjFirstTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFirstTopPanel.DockPadding.Bottom = 15;
            this.mobjFirstTopPanel.DockPadding.Left = 30;
            this.mobjFirstTopPanel.DockPadding.Top = 15;
            this.mobjFirstTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjFirstTopPanel.Name = "mobjFirstTopPanel";
            this.mobjFirstTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 15, 0, 15);
            this.mobjFirstTopPanel.Size = new System.Drawing.Size(283, 102);
            this.mobjFirstTopPanel.TabIndex = 15;
            // 
            // mobjDirectionGroupBox
            // 
            this.mobjDirectionGroupBox.AccessibleDescription = "";
            this.mobjDirectionGroupBox.AccessibleName = "";
            this.mobjDirectionGroupBox.Controls.Add(this.mobjHorizontalCheckBox);
            this.mobjDirectionGroupBox.Controls.Add(this.mobjVerticalCheckBox);
            this.mobjDirectionGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjDirectionGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjDirectionGroupBox.Location = new System.Drawing.Point(30, 15);
            this.mobjDirectionGroupBox.Name = "mobjDirectionGroupBox";
            this.mobjDirectionGroupBox.Size = new System.Drawing.Size(152, 72);
            this.mobjDirectionGroupBox.TabIndex = 2;
            this.mobjDirectionGroupBox.TabStop = false;
            this.mobjDirectionGroupBox.Text = "Direction";
            // 
            // mobjHorizontalCheckBox
            // 
            this.mobjHorizontalCheckBox.AccessibleDescription = "";
            this.mobjHorizontalCheckBox.AccessibleName = "";
            this.mobjHorizontalCheckBox.AutoSize = true;
            this.mobjHorizontalCheckBox.Location = new System.Drawing.Point(32, 21);
            this.mobjHorizontalCheckBox.Name = "objHorizontalCheckBox";
            this.mobjHorizontalCheckBox.Size = new System.Drawing.Size(74, 17);
            this.mobjHorizontalCheckBox.TabIndex = 15;
            this.mobjHorizontalCheckBox.Text = "Horizontal";
            this.mobjHorizontalCheckBox.CheckedChanged += new System.EventHandler(this.mobjHorizontalCheckBox_CheckedChanged);
            // 
            // mobjVerticalCheckBox
            // 
            this.mobjVerticalCheckBox.AccessibleDescription = "";
            this.mobjVerticalCheckBox.AccessibleName = "";
            this.mobjVerticalCheckBox.AutoSize = true;
            this.mobjVerticalCheckBox.Location = new System.Drawing.Point(32, 47);
            this.mobjVerticalCheckBox.Name = "objVerticalCheckBox";
            this.mobjVerticalCheckBox.Size = new System.Drawing.Size(61, 17);
            this.mobjVerticalCheckBox.TabIndex = 16;
            this.mobjVerticalCheckBox.Text = "Vertical";
            this.mobjVerticalCheckBox.CheckedChanged += new System.EventHandler(this.mobjVerticalCheckBox_CheckedChanged);
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.BackColor = System.Drawing.Color.Silver;
            this.mobjPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))));
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjPanel.Location = new System.Drawing.Point(20, 20);
            this.mobjPanel.Name = "objPanel";
            this.mobjPanel.Size = new System.Drawing.Size(80, 80);
            this.mobjPanel.TabIndex = 1;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjPanel);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(0, 163);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(283, 233);
            this.mobjBottomPanel.TabIndex = 2;
            // 
            // TranslatePage
            // 
            this.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjTopPanel);
            this.Size = new System.Drawing.Size(283, 396);
            this.Text = "TranslatePage";
            this.Load += new System.EventHandler(this.TranslatePage_Load);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjSecondTopPanel.ResumeLayout(false);
            this.mobjFirstTopPanel.ResumeLayout(false);
            this.mobjDirectionGroupBox.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjToggleButton;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.CheckBox mobjVerticalCheckBox;
        private Gizmox.WebGUI.Forms.CheckBox mobjHorizontalCheckBox;
        private Gizmox.WebGUI.Forms.GroupBox mobjDirectionGroupBox;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSecondTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFirstTopPanel;



    }
}