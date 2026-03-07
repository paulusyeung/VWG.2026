namespace CompanionKit.Controls.CheckBox.Functionality
{
    partial class CheckStatePage
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
            this.mobjCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjStateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckStateButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.mobjCheckBox.Location = new System.Drawing.Point(30, 99);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjCheckBox.Size = new System.Drawing.Size(130, 50);
            this.mobjCheckBox.TabIndex = 0;
            this.mobjCheckBox.Text = "Demo CheckBox";
            this.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjCheckBox.ThreeState = true;
            // 
            // mobjStateLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjStateLabel, 2);
            this.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStateLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjStateLabel.Location = new System.Drawing.Point(0, 166);
            this.mobjStateLabel.Name = "mobjStateLabel";
            this.mobjStateLabel.Size = new System.Drawing.Size(320, 84);
            this.mobjStateLabel.TabIndex = 1;
            this.mobjStateLabel.Text = "label1";
            this.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCheckStateButton
            // 
            this.mobjCheckStateButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Left;
            this.mobjCheckStateButton.Location = new System.Drawing.Point(170, 104);
            this.mobjCheckStateButton.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0);
            this.mobjCheckStateButton.Name = "mobjCheckStateButton";
            this.mobjCheckStateButton.Size = new System.Drawing.Size(120, 40);
            this.mobjCheckStateButton.TabIndex = 2;
            this.mobjCheckStateButton.Text = "Checks State";
            this.mobjCheckStateButton.UseVisualStyleBackColor = true;
            this.mobjCheckStateButton.Click += new System.EventHandler(this.mobjCheckStateButton_Click);
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 83);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "CheckBox with changing CheckState property:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjStateLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjCheckStateButton, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjCheckBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 250);
            this.mobjTLP.TabIndex = 3;
            // 
            // CheckStatePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 250);
            this.Text = "CheckStatePage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.Label mobjStateLabel;
        private Gizmox.WebGUI.Forms.Button mobjCheckStateButton;
        internal Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
