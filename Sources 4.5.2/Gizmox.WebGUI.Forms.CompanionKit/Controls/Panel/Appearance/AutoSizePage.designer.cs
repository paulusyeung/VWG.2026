namespace CompanionKit.Controls.Panel.Appearance
{
    partial class AutoSizePage
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
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAutoSizeCB = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjButton
            // 
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButton.Location = new System.Drawing.Point(60, 345);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(200, 50);
            this.mobjButton.TabIndex = 1;
            this.mobjButton.Text = "Add Button to Panel";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjAutoSizeCB
            // 
            this.mobjAutoSizeCB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjAutoSizeCB.Location = new System.Drawing.Point(100, 75);
            this.mobjAutoSizeCB.Name = "mobjAutoSizeCB";
            this.mobjAutoSizeCB.Size = new System.Drawing.Size(120, 50);
            this.mobjAutoSizeCB.TabIndex = 2;
            this.mobjAutoSizeCB.Text = "AutoSize";
            this.mobjAutoSizeCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjAutoSizeCB.UseVisualStyleBackColor = true;
            this.mobjAutoSizeCB.CheckedChanged += new System.EventHandler(this.mobjAutoSizeCB_CheckedChanged);
            // 
            // mobjPanel
            // 
            this.mobjPanel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.mobjPanel.BackColor = System.Drawing.Color.Transparent;
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel.Location = new System.Drawing.Point(10, 140);
            this.mobjPanel.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(250, 200);
            this.mobjPanel.TabIndex = 3;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 4;
            this.mobjInfoLabel.Text = "Change AutoSize property for Panel with MaxWidth=1000:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjButton, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjAutoSizeCB, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjPanel, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 5;
            // 
            // AutoSizePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "AutoSizePage";
            this.Load += new System.EventHandler(this.AutoSizePage_Load);
            this.Resize += new System.EventHandler(this.AutoSizePage_Resize);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjAutoSizeCB;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
