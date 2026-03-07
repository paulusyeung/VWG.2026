namespace CompanionKit.Concepts.VisualEffects.GradientBackground
{
    partial class GradientBackgroundPage
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjGradientTypeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjGradientTypeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjColor1Dialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjColor2Dialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjFourthTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjThirdTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPaddingPanel2 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjColor2Panel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjColor2ChooseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjSecondTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPaddingPanel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjColor1Panel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjColor1ChooseButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFirstTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjComboBoxPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel.SuspendLayout();
            this.mobjFourthTopPanel.SuspendLayout();
            this.mobjThirdTopPanel.SuspendLayout();
            this.mobjPaddingPanel2.SuspendLayout();
            this.mobjSecondTopPanel.SuspendLayout();
            this.mobjPaddingPanel1.SuspendLayout();
            this.mobjFirstTopPanel.SuspendLayout();
            this.mobjComboBoxPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjToggleButton
            // 
            this.mobjToggleButton.AccessibleDescription = "";
            this.mobjToggleButton.AccessibleName = "";
            this.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjToggleButton.Location = new System.Drawing.Point(30, 5);
            this.mobjToggleButton.Name = "objApplyButton";
            this.mobjToggleButton.Size = new System.Drawing.Size(231, 50);
            this.mobjToggleButton.TabIndex = 12;
            this.mobjToggleButton.Text = "Show GradientBackground";
            this.mobjToggleButton.Click += new System.EventHandler(this.mobjToggleButton_Click);
            // 
            // mobjListBox
            // 
            this.mobjListBox.AccessibleDescription = "";
            this.mobjListBox.AccessibleName = "";
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item3",
            "Item4",
            "Item5"});
            this.mobjListBox.Location = new System.Drawing.Point(60, 30);
            this.mobjListBox.Name = "objListBox";
            this.mobjListBox.Size = new System.Drawing.Size(171, 160);
            this.mobjListBox.TabIndex = 13;
            // 
            // mobjGradientTypeComboBox
            // 
            this.mobjGradientTypeComboBox.AccessibleDescription = "";
            this.mobjGradientTypeComboBox.AccessibleName = "";
            this.mobjGradientTypeComboBox.AllowDrag = false;
            this.mobjGradientTypeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjGradientTypeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjGradientTypeComboBox.FormattingEnabled = true;
            this.mobjGradientTypeComboBox.Items.AddRange(new object[] {
            "Linear",
            "Radial",
            "RepeatingLinearGradient",
            "RepeatingRadialGradient"});
            this.mobjGradientTypeComboBox.Location = new System.Drawing.Point(15, 0);
            this.mobjGradientTypeComboBox.Name = "objGradientTypeComboBox";
            this.mobjGradientTypeComboBox.Size = new System.Drawing.Size(131, 21);
            this.mobjGradientTypeComboBox.TabIndex = 3;
            this.mobjGradientTypeComboBox.Text = "Linear";
            this.mobjGradientTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjGradientTypeComboBox_SelectedIndexChanged);
            // 
            // mobjGradientTypeLabel
            // 
            this.mobjGradientTypeLabel.AccessibleDescription = "";
            this.mobjGradientTypeLabel.AccessibleName = "";
            this.mobjGradientTypeLabel.AutoSize = true;
            this.mobjGradientTypeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjGradientTypeLabel.Location = new System.Drawing.Point(30, 10);
            this.mobjGradientTypeLabel.Name = "objGradientTypeLabel";
            this.mobjGradientTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.mobjGradientTypeLabel.TabIndex = 0;
            this.mobjGradientTypeLabel.Text = "GradientType";
            this.mobjGradientTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjGradientTypeLabel.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect();
            // 
            // mobjColor1Dialog
            // 
            this.mobjColor1Dialog.Closed += new System.EventHandler(this.mobjColorDialog1_Closed);
            // 
            // mobjColor2Dialog
            // 
            this.mobjColor2Dialog.Closed += new System.EventHandler(this.mobjColorDialog2_Closed);
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.AccessibleDescription = "";
            this.mobjTopPanel.AccessibleName = "";
            this.mobjTopPanel.Controls.Add(this.mobjFourthTopPanel);
            this.mobjTopPanel.Controls.Add(this.mobjThirdTopPanel);
            this.mobjTopPanel.Controls.Add(this.mobjSecondTopPanel);
            this.mobjTopPanel.Controls.Add(this.mobjFirstTopPanel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(291, 197);
            this.mobjTopPanel.TabIndex = 14;
            // 
            // mobjFourthTopPanel
            // 
            this.mobjFourthTopPanel.AccessibleDescription = "";
            this.mobjFourthTopPanel.AccessibleName = "";
            this.mobjFourthTopPanel.Controls.Add(this.mobjToggleButton);
            this.mobjFourthTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFourthTopPanel.DockPadding.Bottom = 5;
            this.mobjFourthTopPanel.DockPadding.Left = 30;
            this.mobjFourthTopPanel.DockPadding.Right = 30;
            this.mobjFourthTopPanel.DockPadding.Top = 5;
            this.mobjFourthTopPanel.Location = new System.Drawing.Point(0, 137);
            this.mobjFourthTopPanel.Name = "mobjFourthTopPanel";
            this.mobjFourthTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 5, 30, 5);
            this.mobjFourthTopPanel.Size = new System.Drawing.Size(291, 60);
            this.mobjFourthTopPanel.TabIndex = 17;
            // 
            // mobjThirdTopPanel
            // 
            this.mobjThirdTopPanel.AccessibleDescription = "";
            this.mobjThirdTopPanel.AccessibleName = "";
            this.mobjThirdTopPanel.Controls.Add(this.mobjPaddingPanel2);
            this.mobjThirdTopPanel.Controls.Add(this.mobjColor2ChooseButton);
            this.mobjThirdTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjThirdTopPanel.DockPadding.Bottom = 5;
            this.mobjThirdTopPanel.DockPadding.Left = 30;
            this.mobjThirdTopPanel.DockPadding.Top = 5;
            this.mobjThirdTopPanel.Location = new System.Drawing.Point(0, 84);
            this.mobjThirdTopPanel.Name = "mobjThirdTopPanel";
            this.mobjThirdTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 5, 0, 5);
            this.mobjThirdTopPanel.Size = new System.Drawing.Size(291, 50);
            this.mobjThirdTopPanel.TabIndex = 13;
            // 
            // mobjPaddingPanel2
            // 
            this.mobjPaddingPanel2.AccessibleDescription = "";
            this.mobjPaddingPanel2.AccessibleName = "";
            this.mobjPaddingPanel2.Controls.Add(this.mobjColor2Panel);
            this.mobjPaddingPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjPaddingPanel2.DockPadding.Left = 15;
            this.mobjPaddingPanel2.Location = new System.Drawing.Point(141, 5);
            this.mobjPaddingPanel2.Name = "mobjPaddingPanel2";
            this.mobjPaddingPanel2.Padding = new Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0);
            this.mobjPaddingPanel2.Size = new System.Drawing.Size(115, 40);
            this.mobjPaddingPanel2.TabIndex = 15;
            // 
            // mobjColor2Panel
            // 
            this.mobjColor2Panel.AccessibleDescription = "";
            this.mobjColor2Panel.AccessibleName = "";
            this.mobjColor2Panel.BackColor = System.Drawing.Color.White;
            this.mobjColor2Panel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjColor2Panel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjColor2Panel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColor2Panel.Location = new System.Drawing.Point(15, 0);
            this.mobjColor2Panel.Name = "objColor2Panel";
            this.mobjColor2Panel.Size = new System.Drawing.Size(63, 40);
            this.mobjColor2Panel.TabIndex = 13;
            this.mobjColor2Panel.BackColorChanged += new System.EventHandler(this.ColorPanelBackColorChanged);
            // 
            // mobjColor2ChooseButton
            // 
            this.mobjColor2ChooseButton.AccessibleDescription = "";
            this.mobjColor2ChooseButton.AccessibleName = "";
            this.mobjColor2ChooseButton.AutoSize = true;
            this.mobjColor2ChooseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColor2ChooseButton.Location = new System.Drawing.Point(30, 5);
            this.mobjColor2ChooseButton.Name = "mobjColor2ChooseButton";
            this.mobjColor2ChooseButton.Size = new System.Drawing.Size(111, 40);
            this.mobjColor2ChooseButton.TabIndex = 14;
            this.mobjColor2ChooseButton.Text = "Choose Color2";
            this.mobjColor2ChooseButton.Click += new System.EventHandler(this.mobjColor2ChooseButton_Click);
            // 
            // mobjSecondTopPanel
            // 
            this.mobjSecondTopPanel.AccessibleDescription = "";
            this.mobjSecondTopPanel.AccessibleName = "";
            this.mobjSecondTopPanel.Controls.Add(this.mobjPaddingPanel1);
            this.mobjSecondTopPanel.Controls.Add(this.mobjColor1ChooseButton);
            this.mobjSecondTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSecondTopPanel.DockPadding.Bottom = 5;
            this.mobjSecondTopPanel.DockPadding.Left = 30;
            this.mobjSecondTopPanel.DockPadding.Top = 5;
            this.mobjSecondTopPanel.Location = new System.Drawing.Point(0, 37);
            this.mobjSecondTopPanel.Name = "mobjSecondTopPanel";
            this.mobjSecondTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 5, 0, 5);
            this.mobjSecondTopPanel.Size = new System.Drawing.Size(291, 50);
            this.mobjSecondTopPanel.TabIndex = 16;
            // 
            // mobjPaddingPanel1
            // 
            this.mobjPaddingPanel1.AccessibleDescription = "";
            this.mobjPaddingPanel1.AccessibleName = "";
            this.mobjPaddingPanel1.Controls.Add(this.mobjColor1Panel);
            this.mobjPaddingPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjPaddingPanel1.DockPadding.Left = 15;
            this.mobjPaddingPanel1.Location = new System.Drawing.Point(141, 5);
            this.mobjPaddingPanel1.Name = "mobjPaddingPanel1";
            this.mobjPaddingPanel1.Padding = new Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0);
            this.mobjPaddingPanel1.Size = new System.Drawing.Size(115, 40);
            this.mobjPaddingPanel1.TabIndex = 16;
            // 
            // mobjColor1Panel
            // 
            this.mobjColor1Panel.AccessibleDescription = "";
            this.mobjColor1Panel.AccessibleName = "";
            this.mobjColor1Panel.BackColor = System.Drawing.Color.Black;
            this.mobjColor1Panel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjColor1Panel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjColor1Panel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColor1Panel.Location = new System.Drawing.Point(15, 0);
            this.mobjColor1Panel.Name = "objColor1Panel";
            this.mobjColor1Panel.Size = new System.Drawing.Size(63, 40);
            this.mobjColor1Panel.TabIndex = 14;
            this.mobjColor1Panel.BackColorChanged += new System.EventHandler(this.ColorPanelBackColorChanged);
            // 
            // mobjColor1ChooseButton
            // 
            this.mobjColor1ChooseButton.AccessibleDescription = "";
            this.mobjColor1ChooseButton.AccessibleName = "";
            this.mobjColor1ChooseButton.AutoSize = true;
            this.mobjColor1ChooseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColor1ChooseButton.Location = new System.Drawing.Point(30, 5);
            this.mobjColor1ChooseButton.Name = "mobjColor1ChooseButton";
            this.mobjColor1ChooseButton.Size = new System.Drawing.Size(111, 40);
            this.mobjColor1ChooseButton.TabIndex = 15;
            this.mobjColor1ChooseButton.Text = "Choose Color1";
            this.mobjColor1ChooseButton.Click += new System.EventHandler(this.mobjColor1ChooseButton_Click);
            // 
            // mobjFirstTopPanel
            // 
            this.mobjFirstTopPanel.AccessibleDescription = "";
            this.mobjFirstTopPanel.AccessibleName = "";
            this.mobjFirstTopPanel.Controls.Add(this.mobjComboBoxPanel);
            this.mobjFirstTopPanel.Controls.Add(this.mobjGradientTypeLabel);
            this.mobjFirstTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFirstTopPanel.DockPadding.Left = 30;
            this.mobjFirstTopPanel.DockPadding.Top = 10;
            this.mobjFirstTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjFirstTopPanel.Name = "mobjFirstTopPanel";
            this.mobjFirstTopPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 10, 0, 0);
            this.mobjFirstTopPanel.Size = new System.Drawing.Size(291, 37);
            this.mobjFirstTopPanel.TabIndex = 15;
            // 
            // mobjComboBoxPanel
            // 
            this.mobjComboBoxPanel.AccessibleDescription = "";
            this.mobjComboBoxPanel.AccessibleName = "";
            this.mobjComboBoxPanel.Controls.Add(this.mobjGradientTypeComboBox);
            this.mobjComboBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjComboBoxPanel.DockPadding.Left = 15;
            this.mobjComboBoxPanel.Location = new System.Drawing.Point(102, 10);
            this.mobjComboBoxPanel.Name = "mobjComboBoxPanel";
            this.mobjComboBoxPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0);
            this.mobjComboBoxPanel.Size = new System.Drawing.Size(159, 27);
            this.mobjComboBoxPanel.TabIndex = 4;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjListBox);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.DockPadding.Bottom = 30;
            this.mobjBottomPanel.DockPadding.Left = 60;
            this.mobjBottomPanel.DockPadding.Right = 60;
            this.mobjBottomPanel.DockPadding.Top = 30;
            this.mobjBottomPanel.Location = new System.Drawing.Point(0, 197);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Padding = new Gizmox.WebGUI.Forms.Padding(60, 30, 60, 30);
            this.mobjBottomPanel.Size = new System.Drawing.Size(291, 223);
            this.mobjBottomPanel.TabIndex = 15;
            // 
            // GradientBackgroundPage
            // 
            this.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjTopPanel);
            this.Size = new System.Drawing.Size(291, 420);
            this.Text = "GradientBackgroundPage";
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjFourthTopPanel.ResumeLayout(false);
            this.mobjThirdTopPanel.ResumeLayout(false);
            this.mobjPaddingPanel2.ResumeLayout(false);
            this.mobjSecondTopPanel.ResumeLayout(false);
            this.mobjPaddingPanel1.ResumeLayout(false);
            this.mobjFirstTopPanel.ResumeLayout(false);
            this.mobjComboBoxPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjToggleButton;
        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjGradientTypeComboBox;
        private Gizmox.WebGUI.Forms.Label mobjGradientTypeLabel;
        private Gizmox.WebGUI.Forms.ColorDialog mobjColor1Dialog;
        private Gizmox.WebGUI.Forms.ColorDialog mobjColor2Dialog;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjColor1Panel;
        private Gizmox.WebGUI.Forms.Panel mobjColor2Panel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFirstTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFourthTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjThirdTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSecondTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjComboBoxPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPaddingPanel2;
        private Gizmox.WebGUI.Forms.Button mobjColor2ChooseButton;
        private Gizmox.WebGUI.Forms.Panel mobjPaddingPanel1;
        private Gizmox.WebGUI.Forms.Button mobjColor1ChooseButton;



    }
}