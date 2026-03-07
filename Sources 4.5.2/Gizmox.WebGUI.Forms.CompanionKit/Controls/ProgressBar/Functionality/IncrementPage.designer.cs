namespace CompanionKit.Controls.ProgressBar.Functionality
{
    partial class IncrementPage
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
            this.mobjDemoProgressBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDemoProgressBar = new Gizmox.WebGUI.Forms.ProgressBar();
            this.mobjStepProgressBarNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.mobjStepProgressBarLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjIncrementButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjNUDPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjStepProgressBarNumericUpDown)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjNUDPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoProgressBarLabel
            // 
            this.mobjDemoProgressBarLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDemoProgressBarLabel, 4);
            this.mobjDemoProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBarLabel.Location = new System.Drawing.Point(177, 30);
            this.mobjDemoProgressBarLabel.Name = "mobjDemoProgressBarLabel";
            this.mobjDemoProgressBarLabel.Size = new System.Drawing.Size(710, 50);
            this.mobjDemoProgressBarLabel.TabIndex = 0;
            this.mobjDemoProgressBarLabel.Text = "Demonstrated of the ProgressBar";
            this.mobjDemoProgressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDemoProgressBar
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDemoProgressBar, 3);
            this.mobjDemoProgressBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoProgressBar.Location = new System.Drawing.Point(177, 80);
            this.mobjDemoProgressBar.Name = "mobjDemoProgressBar";
            this.mobjDemoProgressBar.Size = new System.Drawing.Size(530, 30);
            this.mobjDemoProgressBar.TabIndex = 1;
            // 
            // mobjStepProgressBarNumericUpDown
            // 
            this.mobjStepProgressBarNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjStepProgressBarNumericUpDown.CurrentValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjStepProgressBarNumericUpDown.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjStepProgressBarNumericUpDown.Location = new System.Drawing.Point(0, 39);
            this.mobjStepProgressBarNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.mobjStepProgressBarNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mobjStepProgressBarNumericUpDown.Name = "mobjStepProgressBarNumericUpDown";
            this.mobjStepProgressBarNumericUpDown.Size = new System.Drawing.Size(221, 21);
            this.mobjStepProgressBarNumericUpDown.TabIndex = 2;
            this.mobjStepProgressBarNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mobjStepProgressBarLabel
            // 
            this.mobjStepProgressBarLabel.AutoSize = true;
            this.mobjStepProgressBarLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjStepProgressBarLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjStepProgressBarLabel.Name = "mobjStepProgressBarLabel";
            this.mobjStepProgressBarLabel.Size = new System.Drawing.Size(29, 13);
            this.mobjStepProgressBarLabel.TabIndex = 3;
            this.mobjStepProgressBarLabel.Text = "Step";
            // 
            // mobjIncrementButton
            // 
            this.mobjIncrementButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjIncrementButton.Location = new System.Drawing.Point(486, 130);
            this.mobjIncrementButton.Name = "mobjIncrementButton";
            this.mobjIncrementButton.Size = new System.Drawing.Size(221, 60);
            this.mobjIncrementButton.TabIndex = 4;
            this.mobjIncrementButton.Text = "Increment value";
            this.mobjIncrementButton.Click += new System.EventHandler(this.mobjIncrementButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBarLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoProgressBar, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjIncrementButton, 3, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjNUDPanel, 1, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(887, 221);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjNUDPanel
            // 
            this.mobjNUDPanel.Controls.Add(this.mobjStepProgressBarNumericUpDown);
            this.mobjNUDPanel.Controls.Add(this.mobjStepProgressBarLabel);
            this.mobjNUDPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNUDPanel.Location = new System.Drawing.Point(177, 130);
            this.mobjNUDPanel.Name = "mobjNUDPanel";
            this.mobjNUDPanel.Size = new System.Drawing.Size(221, 60);
            this.mobjNUDPanel.TabIndex = 0;
            // 
            // IncrementPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(887, 221);
            this.Text = "IncrementPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjStepProgressBarNumericUpDown)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjNUDPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjDemoProgressBarLabel;
        private Gizmox.WebGUI.Forms.ProgressBar mobjDemoProgressBar;
        private Gizmox.WebGUI.Forms.NumericUpDown mobjStepProgressBarNumericUpDown;
        private Gizmox.WebGUI.Forms.Label mobjStepProgressBarLabel;
        private Gizmox.WebGUI.Forms.Button mobjIncrementButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjNUDPanel;



    }
}