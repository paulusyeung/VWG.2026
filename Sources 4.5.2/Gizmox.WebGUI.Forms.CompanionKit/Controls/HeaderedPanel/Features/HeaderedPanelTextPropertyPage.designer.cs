namespace CompanionKit.Controls.HeaderedPanel.Features
{
    partial class HeaderedPanelTextPropertyPage
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
            this.mobjContentLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjHeaderedPanel = new Gizmox.WebGUI.Forms.HeaderedPanel();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjHeaderedPanel.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjContentLabel
            // 
            this.mobjContentLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjContentLabel.AutoSize = true;
            this.mobjContentLabel.Location = new System.Drawing.Point(142, 54);
            this.mobjContentLabel.Name = "mobjContentLabel";
            this.mobjContentLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjContentLabel.TabIndex = 0;
            this.mobjContentLabel.Text = "Panel content";
            // 
            // mobjHeaderedPanel
            // 
            this.mobjHeaderedPanel.Controls.Add(this.mobjContentLabel);
            this.mobjHeaderedPanel.CustomStyle = "HeaderedPanel";
            this.mobjHeaderedPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHeaderedPanel.Location = new System.Drawing.Point(122, 30);
            this.mobjHeaderedPanel.Name = "mobjHeaderedPanel";
            this.mobjHeaderedPanel.Size = new System.Drawing.Size(367, 122);
            this.mobjHeaderedPanel.TabIndex = 0;
            // 
            // mobjButton
            // 
            this.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjButton.Location = new System.Drawing.Point(122, 229);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(367, 45);
            this.mobjButton.TabIndex = 1;
            this.mobjButton.Text = "Set text";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjTextBox.Location = new System.Drawing.Point(0, 41);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(367, 30);
            this.mobjTextBox.TabIndex = 2;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AutoSize = true;
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 10);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(69, 13);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "Header text:";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjHeaderedPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjButton, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjContainerPanel, 1, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(613, 306);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjContainerPanel
            // 
            this.mobjContainerPanel.Controls.Add(this.mobjInfoLabel);
            this.mobjContainerPanel.Controls.Add(this.mobjTextBox);
            this.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContainerPanel.DockPadding.Top = 10;
            this.mobjContainerPanel.Location = new System.Drawing.Point(122, 152);
            this.mobjContainerPanel.Name = "mobjContainerPanel";
            this.mobjContainerPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0);
            this.mobjContainerPanel.Size = new System.Drawing.Size(367, 61);
            this.mobjContainerPanel.TabIndex = 0;
            // 
            // HeaderedPanelTextPropertyPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(613, 306);
            this.Text = "HeaderedPanelTextPropertyPage";
            this.mobjHeaderedPanel.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjContentLabel;
        private Gizmox.WebGUI.Forms.HeaderedPanel mobjHeaderedPanel;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjContainerPanel;



    }
}