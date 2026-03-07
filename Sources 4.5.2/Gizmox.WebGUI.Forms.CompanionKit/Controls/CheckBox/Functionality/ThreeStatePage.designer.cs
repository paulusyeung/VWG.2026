namespace CompanionKit.Controls.CheckBox.Functionality
{
    partial class ThreeStatePage
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
            this.mobjStateCombo = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjStateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjCheckBox
            // 
            this.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.mobjCheckBox.Location = new System.Drawing.Point(40, 87);
            this.mobjCheckBox.Name = "mobjCheckBox";
            this.mobjCheckBox.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjCheckBox.Size = new System.Drawing.Size(120, 50);
            this.mobjCheckBox.TabIndex = 0;
            this.mobjCheckBox.Text = "CheckBox";
            this.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjCheckBox.ThreeState = true;
            this.mobjCheckBox.CheckStateChanged += new System.EventHandler(this.mobjCheckBox_CheckStateChanged);
            // 
            // mobjStateCombo
            // 
            this.mobjStateCombo.AllowDrag = false;
            this.mobjStateCombo.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjStateCombo.FormattingEnabled = true;
            this.mobjStateCombo.Location = new System.Drawing.Point(170, 102);
            this.mobjStateCombo.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjStateCombo.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjStateCombo.Name = "mobjStateCombo";
            this.mobjStateCombo.Size = new System.Drawing.Size(140, 25);
            this.mobjStateCombo.TabIndex = 1;
            this.mobjStateCombo.Text = "Unchecked";
            this.mobjStateCombo.SelectedIndexChanged += new System.EventHandler(this.mobjStateCombo_SelectedIndexChanged);
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 75);
            this.mobjInfoLabel.TabIndex = 2;
            this.mobjInfoLabel.Text = "CheckBox demonstrates ThreeState functionality:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjStateLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjStateLabel, 2);
            this.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStateLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobjStateLabel.Location = new System.Drawing.Point(0, 150);
            this.mobjStateLabel.Name = "mobjStateLabel";
            this.mobjStateLabel.Size = new System.Drawing.Size(320, 100);
            this.mobjStateLabel.TabIndex = 3;
            this.mobjStateLabel.Text = "CheckBox State: ";
            this.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjStateCombo, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjStateLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjCheckBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 250);
            this.mobjTLP.TabIndex = 4;
            // 
            // ThreeStatePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 250);
            this.Text = "ThreeStatePage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.CheckBox mobjCheckBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjStateCombo;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Label mobjStateLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;




    }
}
