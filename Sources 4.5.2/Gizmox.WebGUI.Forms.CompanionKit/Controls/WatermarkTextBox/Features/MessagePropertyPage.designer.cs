namespace CompanionKit.Controls.WatermarkTextBox.Features
{
    partial class MessagePropertyPage
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
            this.mobjWatermarkTextBox = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mobjInputTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjWatermarkLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjInputLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjInfoPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objWatermarkTextBox
            // 
            this.mobjWatermarkTextBox.AllowDrag = false;
            this.mobjWatermarkTextBox.CustomStyle = "Watermark";
            this.mobjWatermarkTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjWatermarkTextBox.Location = new System.Drawing.Point(0, 40);
            this.mobjWatermarkTextBox.Message = "Write text here...";
            this.mobjWatermarkTextBox.Name = "objWatermarkTextBox";
            this.mobjWatermarkTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjWatermarkTextBox.TabIndex = 0;
            // 
            // objInputTextBox
            // 
            this.mobjInputTextBox.AllowDrag = false;
            this.mobjInputTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjInputTextBox.Location = new System.Drawing.Point(0, 40);
            this.mobjInputTextBox.Name = "objInputTextBox";
            this.mobjInputTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjInputTextBox.TabIndex = 1;
            // 
            // objButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjButton.Location = new System.Drawing.Point(122, 201);
            this.mobjButton.Name = "objButton";
            this.mobjButton.Size = new System.Drawing.Size(200, 50);
            this.mobjButton.TabIndex = 2;
            this.mobjButton.Text = "Set Message";
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // objInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "objInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(193, 39);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "Enter some text to TextBox and press \r\n\"Set\" to set WatermarkTextBox\'s\r\nmessage p" +
    "roperty.";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objWatermarkLabel
            // 
            this.mobjWatermarkLabel.AutoSize = true;
            this.mobjWatermarkLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWatermarkLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjWatermarkLabel.Name = "objWatermarkLabel";
            this.mobjWatermarkLabel.Size = new System.Drawing.Size(104, 13);
            this.mobjWatermarkLabel.TabIndex = 4;
            this.mobjWatermarkLabel.Text = "WatermarkTextBox:";
            // 
            // objInputLabel
            // 
            this.mobjInputLabel.AutoSize = true;
            this.mobjInputLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInputLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInputLabel.Name = "objInputLabel";
            this.mobjInputLabel.Size = new System.Drawing.Size(80, 13);
            this.mobjInputLabel.TabIndex = 5;
            this.mobjInputLabel.Text = "Input TextBox:";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoPanel, 0, 0);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(445, 269);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjInputTextBox);
            this.mobjBottomPanel.Controls.Add(this.mobjInputLabel);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(122, 121);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(200, 60);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjWatermarkLabel);
            this.mobjTopPanel.Controls.Add(this.mobjWatermarkTextBox);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(122, 41);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(200, 60);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjInfoPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjInfoPanel, 3);
            this.mobjInfoPanel.Controls.Add(this.mobjInfoLabel);
            this.mobjInfoPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoPanel.Name = "mobjInfoPanel";
            this.mobjInfoPanel.Size = new System.Drawing.Size(445, 41);
            this.mobjInfoPanel.TabIndex = 0;
            // 
            // MessagePropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(445, 300);
            this.Text = "MessagePropertyPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.WatermarkTextBox mobjWatermarkTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjInputTextBox;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Label mobjWatermarkLabel;
        private Gizmox.WebGUI.Forms.Label mobjInputLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjInfoPanel;



    }
}