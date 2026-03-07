namespace CompanionKit.Concepts.VisualEffects.TextShadow
{
    partial class TextShadowPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextShadowPage));
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjColorPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjToggleButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjColorDialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSecondPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjFirstPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjColorContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjShadowColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel.SuspendLayout();
            this.mobjSecondPanel.SuspendLayout();
            this.mobjFirstPanel.SuspendLayout();
            this.mobjColorContainerPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.AccessibleDescription = "";
            this.mobjTextLabel.AccessibleName = "";
            this.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLabel.Location = new System.Drawing.Point(30, 0);
            this.mobjTextLabel.Name = "objTextLabel";
            this.mobjTextLabel.Size = new System.Drawing.Size(267, 140);
            this.mobjTextLabel.TabIndex = 12;
            this.mobjTextLabel.Text = resources.GetString("mobjTextLabel.Text");
            this.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjColorPanel
            // 
            this.mobjColorPanel.AccessibleDescription = "";
            this.mobjColorPanel.AccessibleName = "";
            this.mobjColorPanel.BackColor = System.Drawing.Color.LightGray;
            this.mobjColorPanel.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.mobjColorPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjColorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColorPanel.Location = new System.Drawing.Point(15, 0);
            this.mobjColorPanel.Name = "objColorPanel";
            this.mobjColorPanel.Size = new System.Drawing.Size(59, 41);
            this.mobjColorPanel.TabIndex = 11;
            // 
            // mobjToggleButton
            // 
            this.mobjToggleButton.AccessibleDescription = "";
            this.mobjToggleButton.AccessibleName = "";
            this.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjToggleButton.Location = new System.Drawing.Point(30, 5);
            this.mobjToggleButton.Name = "objApplyButton";
            this.mobjToggleButton.Size = new System.Drawing.Size(267, 45);
            this.mobjToggleButton.TabIndex = 8;
            this.mobjToggleButton.Text = "Show TextShadow";
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
            this.mobjTopPanel.Controls.Add(this.mobjSecondPanel);
            this.mobjTopPanel.Controls.Add(this.mobjFirstPanel);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTopPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopPanel.Name = "objTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(327, 126);
            this.mobjTopPanel.TabIndex = 13;
            // 
            // mobjSecondPanel
            // 
            this.mobjSecondPanel.AccessibleDescription = "";
            this.mobjSecondPanel.AccessibleName = "";
            this.mobjSecondPanel.Controls.Add(this.mobjToggleButton);
            this.mobjSecondPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSecondPanel.DockPadding.Bottom = 5;
            this.mobjSecondPanel.DockPadding.Left = 30;
            this.mobjSecondPanel.DockPadding.Right = 30;
            this.mobjSecondPanel.DockPadding.Top = 5;
            this.mobjSecondPanel.Location = new System.Drawing.Point(0, 71);
            this.mobjSecondPanel.Name = "mobjSecondPanel";
            this.mobjSecondPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 5, 30, 5);
            this.mobjSecondPanel.Size = new System.Drawing.Size(327, 55);
            this.mobjSecondPanel.TabIndex = 13;
            // 
            // mobjFirstPanel
            // 
            this.mobjFirstPanel.AccessibleDescription = "";
            this.mobjFirstPanel.AccessibleName = "";
            this.mobjFirstPanel.Controls.Add(this.mobjColorContainerPanel);
            this.mobjFirstPanel.Controls.Add(this.mobjShadowColorButton);
            this.mobjFirstPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFirstPanel.DockPadding.Bottom = 5;
            this.mobjFirstPanel.DockPadding.Left = 30;
            this.mobjFirstPanel.DockPadding.Top = 25;
            this.mobjFirstPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjFirstPanel.Name = "mobjFirstPanel";
            this.mobjFirstPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 25, 0, 5);
            this.mobjFirstPanel.Size = new System.Drawing.Size(327, 71);
            this.mobjFirstPanel.TabIndex = 12;
            // 
            // panel1
            // 
            this.mobjColorContainerPanel.AccessibleDescription = "";
            this.mobjColorContainerPanel.AccessibleName = "";
            this.mobjColorContainerPanel.Controls.Add(this.mobjColorPanel);
            this.mobjColorContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjColorContainerPanel.DockPadding.Left = 15;
            this.mobjColorContainerPanel.Location = new System.Drawing.Point(176, 25);
            this.mobjColorContainerPanel.Name = "panel1";
            this.mobjColorContainerPanel.Padding = new Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0);
            this.mobjColorContainerPanel.Size = new System.Drawing.Size(121, 41);
            this.mobjColorContainerPanel.TabIndex = 13;
            // 
            // mobjShadowColorButton
            // 
            this.mobjShadowColorButton.AccessibleDescription = "";
            this.mobjShadowColorButton.AccessibleName = "";
            this.mobjShadowColorButton.AutoSize = true;
            this.mobjShadowColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjShadowColorButton.Location = new System.Drawing.Point(30, 25);
            this.mobjShadowColorButton.Name = "mobjShadowColorButton";
            this.mobjShadowColorButton.Size = new System.Drawing.Size(146, 41);
            this.mobjShadowColorButton.TabIndex = 12;
            this.mobjShadowColorButton.Text = "Choose ShadowColor";
            this.mobjShadowColorButton.Click += new System.EventHandler(this.mobjShadowColorButton_Click);
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.AccessibleDescription = "";
            this.mobjBottomPanel.AccessibleName = "";
            this.mobjBottomPanel.Controls.Add(this.mobjTextLabel);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.DockPadding.Left = 30;
            this.mobjBottomPanel.DockPadding.Right = 30;
            this.mobjBottomPanel.Location = new System.Drawing.Point(0, 126);
            this.mobjBottomPanel.Name = "objBottomPanel";
            this.mobjBottomPanel.Padding = new Gizmox.WebGUI.Forms.Padding(30, 0, 30, 0);
            this.mobjBottomPanel.Size = new System.Drawing.Size(327, 140);
            this.mobjBottomPanel.TabIndex = 14;
            // 
            // TextShadowPage
            // 
            this.Controls.Add(this.mobjBottomPanel);
            this.Controls.Add(this.mobjTopPanel);
            this.Size = new System.Drawing.Size(327, 266);
            this.Text = "TextShadowPage";
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjSecondPanel.ResumeLayout(false);
            this.mobjFirstPanel.ResumeLayout(false);
            this.mobjColorContainerPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjTextLabel;
        private Gizmox.WebGUI.Forms.Panel mobjColorPanel;
        private Gizmox.WebGUI.Forms.Button mobjToggleButton;
        private Gizmox.WebGUI.Forms.ColorDialog mobjColorDialog;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFirstPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSecondPanel;
        private Gizmox.WebGUI.Forms.Button mobjShadowColorButton;
        private Gizmox.WebGUI.Forms.Panel mobjColorContainerPanel;



    }
}