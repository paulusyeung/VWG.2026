using Gizmox.WebGUI.Common.Resources;
namespace CompanionKit.Controls.StatusBar.Appearance
{
    partial class DifferentAppearancePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifferentAppearancePage));
            this.mobjTestStatusBar = new Gizmox.WebGUI.Forms.StatusBar();
            this.mobjStatusBarTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjSetTextButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFontStatusBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjChangeFontButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjChangeStatusBarFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjSetTextPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjChangeFontPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjSetTextPanel.SuspendLayout();
            this.mobjChangeFontPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTestStatusBar
            // 
            this.mobjTestStatusBar.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjTestStatusBar.BackgroundImage"));
            this.mobjTestStatusBar.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch;
            this.mobjTestStatusBar.Location = new System.Drawing.Point(0, 233);
            this.mobjTestStatusBar.Name = "mobjTestStatusBar";
            this.mobjTestStatusBar.Size = new System.Drawing.Size(508, 22);
            this.mobjTestStatusBar.TabIndex = 0;
            this.mobjTestStatusBar.Text = "This is test StatusBar";
            // 
            // mobjStatusBarTextBox
            // 
            this.mobjStatusBarTextBox.AllowDrag = false;
            this.mobjStatusBarTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjStatusBarTextBox.Location = new System.Drawing.Point(52, 49);
            this.mobjStatusBarTextBox.Name = "mobjStatusBarTextBox";
            this.mobjStatusBarTextBox.Size = new System.Drawing.Size(190, 30);
            this.mobjStatusBarTextBox.TabIndex = 1;
            // 
            // mobjSetTextButton
            // 
            this.mobjSetTextButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSetTextButton.Location = new System.Drawing.Point(0, 0);
            this.mobjSetTextButton.MaximumSize = new System.Drawing.Size(0, 50);
            this.mobjSetTextButton.Name = "mobjSetTextButton";
            this.mobjSetTextButton.Size = new System.Drawing.Size(196, 50);
            this.mobjSetTextButton.TabIndex = 2;
            this.mobjSetTextButton.Text = "Set text to StatusBar";
            this.mobjSetTextButton.UseVisualStyleBackColor = true;
            this.mobjSetTextButton.Click += new System.EventHandler(this.mobjSetTextButton_Click);
            // 
            // mobjFontStatusBarLabel
            // 
            this.mobjFontStatusBarLabel.AutoSize = true;
            this.mobjFontStatusBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontStatusBarLabel.Location = new System.Drawing.Point(49, 126);
            this.mobjFontStatusBarLabel.Name = "mobjFontStatusBarLabel";
            this.mobjFontStatusBarLabel.Size = new System.Drawing.Size(196, 60);
            this.mobjFontStatusBarLabel.TabIndex = 3;
            // 
            // mobjChangeFontButton
            // 
            this.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjChangeFontButton.Location = new System.Drawing.Point(0, 0);
            this.mobjChangeFontButton.MaximumSize = new System.Drawing.Size(0, 50);
            this.mobjChangeFontButton.Name = "mobjChangeFontButton";
            this.mobjChangeFontButton.Size = new System.Drawing.Size(196, 50);
            this.mobjChangeFontButton.TabIndex = 4;
            this.mobjChangeFontButton.Text = "Change Font of StatusBar text";
            this.mobjChangeFontButton.UseVisualStyleBackColor = true;
            this.mobjChangeFontButton.Click += new System.EventHandler(this.mobjChangeFontButton_Click);
            // 
            // mobjChangeStatusBarFontDialog
            // 
            this.mobjChangeStatusBarFontDialog.MaxSize = 72;
            this.mobjChangeStatusBarFontDialog.MinSize = 8;
            this.mobjChangeStatusBarFontDialog.Apply += new System.EventHandler(this.mobjChangeStatusBarFontDialog_Apply);
            this.mobjChangeStatusBarFontDialog.Closed += new System.EventHandler(this.mobjChangeStatusBarFontDialog_Closed);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjStatusBarTextBox, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjFontStatusBarLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjSetTextPanel, 3, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjChangeFontPanel, 3, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(510, 233);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjSetTextPanel
            // 
            this.mobjSetTextPanel.Controls.Add(this.mobjSetTextButton);
            this.mobjSetTextPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSetTextPanel.Location = new System.Drawing.Point(265, 46);
            this.mobjSetTextPanel.Name = "mobjSetTextPanel";
            this.mobjSetTextPanel.Size = new System.Drawing.Size(196, 60);
            this.mobjSetTextPanel.TabIndex = 0;
            // 
            // mobjChangeFontPanel
            // 
            this.mobjChangeFontPanel.Controls.Add(this.mobjChangeFontButton);
            this.mobjChangeFontPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjChangeFontPanel.Location = new System.Drawing.Point(265, 126);
            this.mobjChangeFontPanel.Name = "mobjChangeFontPanel";
            this.mobjChangeFontPanel.Size = new System.Drawing.Size(196, 60);
            this.mobjChangeFontPanel.TabIndex = 0;
            // 
            // DifferentAppearancePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Controls.Add(this.mobjTestStatusBar);
            this.Size = new System.Drawing.Size(510, 255);
            this.Text = "DifferentAppearancePage";
            this.Load += new System.EventHandler(this.DifferentAppearancePage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjSetTextPanel.ResumeLayout(false);
            this.mobjChangeFontPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.StatusBar mobjTestStatusBar;
        private Gizmox.WebGUI.Forms.TextBox mobjStatusBarTextBox;
        private Gizmox.WebGUI.Forms.Button mobjSetTextButton;
        private Gizmox.WebGUI.Forms.Label mobjFontStatusBarLabel;
        private Gizmox.WebGUI.Forms.Button mobjChangeFontButton;
        private Gizmox.WebGUI.Forms.FontDialog mobjChangeStatusBarFontDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjSetTextPanel;
        private Gizmox.WebGUI.Forms.Panel mobjChangeFontPanel;



    }
}
