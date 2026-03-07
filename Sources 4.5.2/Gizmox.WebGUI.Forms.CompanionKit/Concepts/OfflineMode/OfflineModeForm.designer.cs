namespace OfflineModeSampleAppCS
{
    partial class OfflineModeForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfflineModeForm));
            this.mobjStatusStrip = new Gizmox.WebGUI.Forms.StatusStrip();
            this.mobjToolStripStatusLabel = new Gizmox.WebGUI.Forms.ToolStripStatusLabel();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLogTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjStatusStrip
            // 
            this.mobjStatusStrip.BackColor = System.Drawing.Color.Green;
            this.mobjStatusStrip.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjStatusStrip.DockPadding.Left = 1;
            this.mobjStatusStrip.DockPadding.Right = 14;
            this.mobjStatusStrip.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.mobjToolStripStatusLabel});
            this.mobjStatusStrip.Location = new System.Drawing.Point(0, 499);
            this.mobjStatusStrip.MinimumSize = new System.Drawing.Size(0, 50);
            this.mobjStatusStrip.Name = "mobjStatusStrip";
            this.mobjStatusStrip.Size = new System.Drawing.Size(882, 50);
            this.mobjStatusStrip.TabIndex = 0;
            this.mobjStatusStrip.Text = "StatusStrip";
            // 
            // mobjToolStripStatusLabel
            // 
            this.mobjToolStripStatusLabel.ClientId = "statusStripLabel";
            this.mobjToolStripStatusLabel.Margin = new Gizmox.WebGUI.Forms.Padding(0, 1, 0, 2);
            this.mobjToolStripStatusLabel.Name = "mobjToolStripStatusLabel";
            this.mobjToolStripStatusLabel.Size = new System.Drawing.Size(37, 13);
            this.mobjToolStripStatusLabel.Text = "Online";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 128F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjLogTextBox, 1, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjPictureBox, 2, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 128F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(882, 471);
            this.mobjLayoutPanel.TabIndex = 1;
            // 
            // mobjLogTextBox
            // 
            this.mobjLogTextBox.ClientId = "textBox";
            this.mobjLayoutPanel.SetColumnSpan(this.mobjLogTextBox, 3);
            this.mobjLogTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLogTextBox.Location = new System.Drawing.Point(23, 232);
            this.mobjLogTextBox.Multiline = true;
            this.mobjLogTextBox.Name = "mobjLogTextBox";
            this.mobjLogTextBox.ReadOnly = true;
            this.mobjLogTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.mobjLogTextBox.Size = new System.Drawing.Size(836, 194);
            this.mobjLogTextBox.TabIndex = 0;
            // 
            // mobjPictureBox
            // 
            this.mobjPictureBox.ClientId = "pictureBox";
            this.mobjPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPictureBox.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"));
            this.mobjPictureBox.Location = new System.Drawing.Point(377, 20);
            this.mobjPictureBox.Name = "mobjPictureBox";
            this.mobjPictureBox.Size = new System.Drawing.Size(128, 128);
            this.mobjPictureBox.TabIndex = 0;
            this.mobjPictureBox.TabStop = false;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjLabel, 3);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(20, 189);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(842, 40);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Log :";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OfflineModeForm
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Controls.Add(this.mobjStatusStrip);
            this.Size = new System.Drawing.Size(882, 521);
            this.Text = "OfflineModePage";
            this.ClientPreload += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.OfflineModeForm_ClientPreload);
            this.OfflineInitializing += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.OfflineModeForm_OfflineInitializing);
            this.OfflineConfirming += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.OfflineModeForm_OfflineConfirming);
            this.mobjLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.StatusStrip mobjStatusStrip;
        private Gizmox.WebGUI.Forms.ToolStripStatusLabel mobjToolStripStatusLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.PictureBox mobjPictureBox;
        private Gizmox.WebGUI.Forms.TextBox mobjLogTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
    }
}