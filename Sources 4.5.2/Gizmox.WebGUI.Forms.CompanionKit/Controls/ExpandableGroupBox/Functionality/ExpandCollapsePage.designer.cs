namespace CompanionKit.Controls.ExpandableGroupBox
{
    partial class ExpandCollapsePage
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
            this.mobjExpColInfo = new Gizmox.WebGUI.Forms.Label();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjExpandableGroupBox3 = new Gizmox.WebGUI.Forms.ExpandableGroupBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjExpandableGroupBox2 = new Gizmox.WebGUI.Forms.ExpandableGroupBox();
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjExpandableGroupBox1 = new Gizmox.WebGUI.Forms.ExpandableGroupBox();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox3)).BeginInit();
            this.mobjExpandableGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox2)).BeginInit();
            this.mobjExpandableGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox1)).BeginInit();
            this.mobjExpandableGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjExpColInfo
            // 
            this.mobjExpColInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjExpColInfo.Location = new System.Drawing.Point(0, 340);
            this.mobjExpColInfo.Name = "mobjExpColInfo";
            this.mobjExpColInfo.Size = new System.Drawing.Size(320, 60);
            this.mobjExpColInfo.TabIndex = 2;
            this.mobjExpColInfo.Text = "Expanded: ExpandableGroupBox1";
            this.mobjExpColInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 60);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "ExpandableGroupBoxes demonstrate Accordion behavior:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjExpColInfo, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjPanel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 2;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjExpandableGroupBox3);
            this.mobjPanel.Controls.Add(this.mobjExpandableGroupBox2);
            this.mobjPanel.Controls.Add(this.mobjExpandableGroupBox1);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(0, 60);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(320, 280);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjExpandableGroupBox3
            // 
            this.mobjExpandableGroupBox3.Controls.Add(this.mobjLabel);
            this.mobjExpandableGroupBox3.CustomStyle = "X";
            this.mobjExpandableGroupBox3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjExpandableGroupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjExpandableGroupBox3.IsExpanded = false;
            this.mobjExpandableGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.mobjExpandableGroupBox3.Name = "mobjExpandableGroupBox3";
            this.mobjExpandableGroupBox3.Size = new System.Drawing.Size(320, 90);
            this.mobjExpandableGroupBox3.TabIndex = 2;
            this.mobjExpandableGroupBox3.Text = "expandableGroupBox3";
            this.mobjExpandableGroupBox3.Collapse += new System.EventHandler(this.mobjExpandableGroupBox3_Collapse);
            this.mobjExpandableGroupBox3.Expand += new System.EventHandler(this.mobjExpandableGroupBox3_Expand);
            // 
            // mobjLabel
            // 
            this.mobjLabel.Location = new System.Drawing.Point(47, 36);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(123, 40);
            this.mobjLabel.TabIndex = 0;
            this.mobjLabel.Text = "Label";
            // 
            // mobjExpandableGroupBox2
            // 
            this.mobjExpandableGroupBox2.Controls.Add(this.mobjCheckBox);
            this.mobjExpandableGroupBox2.CustomStyle = "X";
            this.mobjExpandableGroupBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjExpandableGroupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjExpandableGroupBox2.IsExpanded = false;
            this.mobjExpandableGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.mobjExpandableGroupBox2.Name = "mobjExpandableGroupBox2";
            this.mobjExpandableGroupBox2.Size = new System.Drawing.Size(320, 90);
            this.mobjExpandableGroupBox2.TabIndex = 1;
            this.mobjExpandableGroupBox2.Text = "expandableGroupBox2";
            this.mobjExpandableGroupBox2.Collapse += new System.EventHandler(this.mobjExpandableGroupBox2_Collapse);
            this.mobjExpandableGroupBox2.Expand += new System.EventHandler(this.mobjExpandableGroupBox2_Expand);
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Location = new System.Drawing.Point(50, 34);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Size = new System.Drawing.Size(120, 40);
            this.mobjCheckBox.TabIndex = 0;
            this.mobjCheckBox.Text = "CheckBox";
            // 
            // mobjExpandableGroupBox1
            // 
            this.mobjExpandableGroupBox1.Controls.Add(this.mobjButton);
            this.mobjExpandableGroupBox1.CustomStyle = "X";
            this.mobjExpandableGroupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjExpandableGroupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjExpandableGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.mobjExpandableGroupBox1.Name = "mobjExpandableGroupBox1";
            this.mobjExpandableGroupBox1.Size = new System.Drawing.Size(320, 90);
            this.mobjExpandableGroupBox1.TabIndex = 0;
            this.mobjExpandableGroupBox1.Text = "expandableGroupBox1";
            this.mobjExpandableGroupBox1.Collapse += new System.EventHandler(this.mobjExpandableGroupBox1_Collapse);
            this.mobjExpandableGroupBox1.Expand += new System.EventHandler(this.mobjExpandableGroupBox1_Expand);
            // 
            // mobjButton
            // 
            this.mobjButton.Location = new System.Drawing.Point(50, 34);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(120, 30);
            this.mobjButton.TabIndex = 0;
            this.mobjButton.Text = "Button";
            // 
            // ExpandCollapsePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "ExpandCollapsePage";
            this.mobjTLP.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox3)).EndInit();
            this.mobjExpandableGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox2)).EndInit();
            this.mobjExpandableGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjExpandableGroupBox1)).EndInit();
            this.mobjExpandableGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjExpColInfo;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.ExpandableGroupBox mobjExpandableGroupBox3;
        private Gizmox.WebGUI.Forms.ExpandableGroupBox mobjExpandableGroupBox2;
        private Gizmox.WebGUI.Forms.ExpandableGroupBox mobjExpandableGroupBox1;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.Button mobjButton;

    }
}