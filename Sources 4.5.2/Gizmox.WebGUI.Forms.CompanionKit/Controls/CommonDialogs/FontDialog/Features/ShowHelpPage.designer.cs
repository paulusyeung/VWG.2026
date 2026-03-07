namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features
{
    partial class ShowHelpPage
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
            this.mobjAllowShowHelpCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjShowHelpLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjShowHelpButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjAllowShowHelpCheckBox
            // 
            this.mobjAllowShowHelpCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjAllowShowHelpCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowShowHelpCheckBox.Location = new System.Drawing.Point(83, 111);
            this.mobjAllowShowHelpCheckBox.Name = "mobjAllowShowHelpCheckBox";
            this.mobjAllowShowHelpCheckBox.Size = new System.Drawing.Size(388, 70);
            this.mobjAllowShowHelpCheckBox.TabIndex = 1;
            this.mobjAllowShowHelpCheckBox.Text = "Enable help button in FontDialog";
            this.mobjAllowShowHelpCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjShowHelpLabel
            // 
            this.mobjShowHelpLabel.AutoSize = true;
            this.mobjShowHelpLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowHelpLabel.Location = new System.Drawing.Point(83, 21);
            this.mobjShowHelpLabel.Name = "mobjShowHelpLabel";
            this.mobjShowHelpLabel.Size = new System.Drawing.Size(388, 50);
            this.mobjShowHelpLabel.TabIndex = 2;
            this.mobjShowHelpLabel.Text = "Font selected in the dialog:";
            // 
            // mobjShowHelpButton
            // 
            this.mobjShowHelpButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowHelpButton.Location = new System.Drawing.Point(83, 201);
            this.mobjShowHelpButton.Name = "mobjShowHelpButton";
            this.mobjShowHelpButton.Size = new System.Drawing.Size(388, 50);
            this.mobjShowHelpButton.TabIndex = 3;
            this.mobjShowHelpButton.Text = "Change font for label with FontDialog";
            this.mobjShowHelpButton.UseVisualStyleBackColor = true;
            this.mobjShowHelpButton.Click += new System.EventHandler(this.mobjShowHelpButton_Click);
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 28;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjShowHelpLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjShowHelpButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjAllowShowHelpCheckBox, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(555, 273);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // ShowHelpPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(555, 273);
            this.Text = "ShowHelpPage";
            this.Load += new System.EventHandler(this.ShowHelpPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjAllowShowHelpCheckBox;
        private Gizmox.WebGUI.Forms.Label mobjShowHelpLabel;
        private Gizmox.WebGUI.Forms.Button mobjShowHelpButton;
        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
