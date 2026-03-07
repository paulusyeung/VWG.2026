namespace CompanionKit.Controls.Panel.Appearance
{
    partial class AutoScrollPage
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
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAutoScrollEnabled = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPanel
            // 
            this.mobjPanel.AutoScroll = true;
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(0, 80);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(320, 240);
            this.mobjPanel.TabIndex = 0;
            // 
            // mobjButton
            // 
            this.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButton.Location = new System.Drawing.Point(75, 335);
            this.mobjButton.Name = "mobjButton";
            this.mobjButton.Size = new System.Drawing.Size(170, 50);
            this.mobjButton.TabIndex = 1;
            this.mobjButton.Text = "Add Button to Panel";
            this.mobjButton.UseVisualStyleBackColor = true;
            this.mobjButton.Click += new System.EventHandler(this.mobjButton_Click);
            // 
            // mobjAutoScrollEnabled
            // 
            this.mobjAutoScrollEnabled.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjAutoScrollEnabled.Checked = true;
            this.mobjAutoScrollEnabled.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjAutoScrollEnabled.Location = new System.Drawing.Point(85, 15);
            this.mobjAutoScrollEnabled.Name = "mobjAutoScrollEnabled";
            this.mobjAutoScrollEnabled.Size = new System.Drawing.Size(150, 50);
            this.mobjAutoScrollEnabled.TabIndex = 2;
            this.mobjAutoScrollEnabled.Text = "Enable AutoScroll";
            this.mobjAutoScrollEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjAutoScrollEnabled.CheckedChanged += new System.EventHandler(this.mobjAutoScrollEnabled_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjAutoScrollEnabled, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjButton, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjPanel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 3;
            // 
            // AutoScrollPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "AutoScrollPage";
            this.Load += new System.EventHandler(this.AutoScrollPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.Button mobjButton;
        private Gizmox.WebGUI.Forms.CheckBox mobjAutoScrollEnabled;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
