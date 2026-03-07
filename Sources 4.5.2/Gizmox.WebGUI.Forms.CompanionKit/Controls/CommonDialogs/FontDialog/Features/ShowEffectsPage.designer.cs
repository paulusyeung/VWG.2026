namespace CompanionKit.Controls.CommonDialogs.FontDialog.Features
{
    partial class ShowEffectsPage
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
            this.mobjDemoFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjShowEffectsLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjAllowShowEffectsCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjShowEffectsButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoFontDialog
            // 
            this.mobjDemoFontDialog.MaxSize = 28;
            this.mobjDemoFontDialog.MinSize = 8;
            this.mobjDemoFontDialog.Closed += new System.EventHandler(this.mobjDemoFontDialog_Closed);
            // 
            // mobjShowEffectsLabel
            // 
            this.mobjShowEffectsLabel.AutoSize = true;
            this.mobjShowEffectsLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowEffectsLabel.Location = new System.Drawing.Point(99, 28);
            this.mobjShowEffectsLabel.Name = "mobjShowEffectsLabel";
            this.mobjShowEffectsLabel.Size = new System.Drawing.Size(466, 50);
            this.mobjShowEffectsLabel.TabIndex = 1;
            this.mobjShowEffectsLabel.Text = "Font selected in the dialog: ";
            // 
            // mobjAllowShowEffectsCheckBox
            // 
            this.mobjAllowShowEffectsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjAllowShowEffectsCheckBox.Checked = true;
            this.mobjAllowShowEffectsCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjAllowShowEffectsCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAllowShowEffectsCheckBox.Location = new System.Drawing.Point(99, 118);
            this.mobjAllowShowEffectsCheckBox.Name = "mobjAllowShowEffectsCheckBox";
            this.mobjAllowShowEffectsCheckBox.Size = new System.Drawing.Size(466, 70);
            this.mobjAllowShowEffectsCheckBox.TabIndex = 2;
            this.mobjAllowShowEffectsCheckBox.Text = "Enable panel with effects in the FontDialog";
            this.mobjAllowShowEffectsCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobjShowEffectsButton
            // 
            this.mobjShowEffectsButton.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.mobjShowEffectsButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowEffectsButton.Location = new System.Drawing.Point(99, 208);
            this.mobjShowEffectsButton.Name = "mobjShowEffectsButton";
            this.mobjShowEffectsButton.Size = new System.Drawing.Size(466, 50);
            this.mobjShowEffectsButton.TabIndex = 3;
            this.mobjShowEffectsButton.Text = "Open FontDialog to change font of the label";
            this.mobjShowEffectsButton.UseVisualStyleBackColor = true;
            this.mobjShowEffectsButton.Click += new System.EventHandler(this.mobjShowEffectsButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjShowEffectsLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjShowEffectsButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjAllowShowEffectsCheckBox, 1, 3);
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(666, 287);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // ShowEffectsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(666, 287);
            this.Text = "ShowEffectsPage";
            this.Load += new System.EventHandler(this.ShowEffectsPage_Load);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.FontDialog mobjDemoFontDialog;
        private Gizmox.WebGUI.Forms.Label mobjShowEffectsLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjAllowShowEffectsCheckBox;
        private Gizmox.WebGUI.Forms.Button mobjShowEffectsButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
