namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsCS
{
    partial class C1BarChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C1BarChartForm));
            this.mobjWrapper = new C1BarChartWrapper();
            this.mobjSetButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWrapper
            // 
            this.mobjTLP.SetColumnSpan(this.mobjWrapper, 2);
            this.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode");
            this.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWrapper.Location = new System.Drawing.Point(0, 75);
            this.mobjWrapper.Name = "mobjWrapper";
            this.mobjWrapper.Size = new System.Drawing.Size(966, 303);
            this.mobjWrapper.TabIndex = 0;
            // 
            // mobjSetButton
            // 
            this.mobjSetButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjSetButton.Location = new System.Drawing.Point(674, 417);
            this.mobjSetButton.Name = "mobjSetButton";
            this.mobjSetButton.Size = new System.Drawing.Size(150, 50);
            this.mobjSetButton.TabIndex = 1;
            this.mobjSetButton.Text = "Set Label Text";
            this.mobjSetButton.Click += new System.EventHandler(this.mobjSetButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjWrapper, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjSetButton, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjTextBox, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(966, 506);
            this.mobjTLP.TabIndex = 2;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTextBox.Location = new System.Drawing.Point(166, 429);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(150, 25);
            this.mobjTextBox.TabIndex = 0;
            this.mobjTextBox.Text = "new text...";
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(966, 75);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 BarChart:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // C1BarChartForm
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(966, 600);
            this.Text = "C1BarChartForm";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private C1BarChartWrapper mobjWrapper;
        private Button mobjSetButton;
        private TableLayoutPanel mobjTLP;
        private TextBox mobjTextBox;
        private Label mobjInfoLabel;

    }
}