namespace CompanionKit.Controls.StackPanel.Functionality
{
    partial class StackPanelDemonstrationPage
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
            this.mobjStackPanel = new Gizmox.WebGUI.Forms.StackPanel();
            this.mobjOrienationGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjVerticalRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjHorizontalRadioButton = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjAddButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjRemoveButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjStackContainerPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjOrientationPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAddPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjRemovePanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjOrienationGroupBox.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjStackContainerPanel.SuspendLayout();
            this.mobjOrientationPanel.SuspendLayout();
            this.mobjAddPanel.SuspendLayout();
            this.mobjRemovePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjStackPanel
            // 
            this.mobjStackPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjStackPanel.CustomStyle = "StackPanel";
            this.mobjStackPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStackPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjStackPanel.Name = "mobjStackPanel";
            this.mobjStackPanel.Size = new System.Drawing.Size(508, 99);
            this.mobjStackPanel.TabIndex = 0;
            // 
            // mobjOrienationGroupBox
            // 
            this.mobjOrienationGroupBox.Controls.Add(this.mobjVerticalRadioButton);
            this.mobjOrienationGroupBox.Controls.Add(this.mobjHorizontalRadioButton);
            this.mobjOrienationGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOrienationGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjOrienationGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mobjOrienationGroupBox.MaximumSize = new System.Drawing.Size(250, 100);
            this.mobjOrienationGroupBox.Name = "mobjOrienationGroupBox";
            this.mobjOrienationGroupBox.Size = new System.Drawing.Size(244, 98);
            this.mobjOrienationGroupBox.TabIndex = 1;
            this.mobjOrienationGroupBox.TabStop = false;
            this.mobjOrienationGroupBox.Text = "Orienation";
            // 
            // mobjVerticalRadioButton
            // 
            this.mobjVerticalRadioButton.AutoSize = true;
            this.mobjVerticalRadioButton.Checked = true;
            this.mobjVerticalRadioButton.Location = new System.Drawing.Point(19, 26);
            this.mobjVerticalRadioButton.Name = "mobjVerticalRadioButton";
            this.mobjVerticalRadioButton.Size = new System.Drawing.Size(60, 17);
            this.mobjVerticalRadioButton.TabIndex = 3;
            this.mobjVerticalRadioButton.Text = "Vertical";
            // 
            // mobjHorizontalRadioButton
            // 
            this.mobjHorizontalRadioButton.AutoSize = true;
            this.mobjHorizontalRadioButton.Location = new System.Drawing.Point(19, 54);
            this.mobjHorizontalRadioButton.Name = "mobjHorizontalRadioButton";
            this.mobjHorizontalRadioButton.Size = new System.Drawing.Size(73, 17);
            this.mobjHorizontalRadioButton.TabIndex = 2;
            this.mobjHorizontalRadioButton.Text = "Horizontal";
            this.mobjHorizontalRadioButton.CheckedChanged += new System.EventHandler(this.mobjHorizontalRadioButton_CheckedChanged);
            // 
            // mobjAddButton
            // 
            this.mobjAddButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddButton.Location = new System.Drawing.Point(5, 5);
            this.mobjAddButton.Name = "mobjAddButton";
            this.mobjAddButton.Size = new System.Drawing.Size(234, 39);
            this.mobjAddButton.TabIndex = 2;
            this.mobjAddButton.Text = "Add item";
            this.mobjAddButton.Click += new System.EventHandler(this.mobjAddButton_Click);
            // 
            // mobjRemoveButton
            // 
            this.mobjRemoveButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRemoveButton.Location = new System.Drawing.Point(5, 5);
            this.mobjRemoveButton.Name = "mobjRemoveButton";
            this.mobjRemoveButton.Size = new System.Drawing.Size(234, 39);
            this.mobjRemoveButton.TabIndex = 3;
            this.mobjRemoveButton.Text = "Remove item";
            this.mobjRemoveButton.Click += new System.EventHandler(this.mobjRemoveButton_Click);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 5;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 38.46154F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 38.46154F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F));
            this.mobjLayoutPanel.Controls.Add(this.mobjStackContainerPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjOrientationPanel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjAddPanel, 3, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjRemovePanel, 3, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 6;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 38.46154F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 19.23077F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 19.23077F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.53846F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(655, 280);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjStackContainerPanel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjStackContainerPanel, 3);
            this.mobjStackContainerPanel.Controls.Add(this.mobjStackPanel);
            this.mobjStackContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStackContainerPanel.Location = new System.Drawing.Point(73, 29);
            this.mobjStackContainerPanel.Name = "mobjStackContainerPanel";
            this.mobjStackContainerPanel.Size = new System.Drawing.Size(508, 99);
            this.mobjStackContainerPanel.TabIndex = 0;
            // 
            // mobjOrientationPanel
            // 
            this.mobjOrientationPanel.Controls.Add(this.mobjOrienationGroupBox);
            this.mobjOrientationPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjOrientationPanel.Location = new System.Drawing.Point(73, 148);
            this.mobjOrientationPanel.Name = "mobjOrientationPanel";
            this.mobjLayoutPanel.SetRowSpan(this.mobjOrientationPanel, 2);
            this.mobjOrientationPanel.Size = new System.Drawing.Size(244, 98);
            this.mobjOrientationPanel.TabIndex = 0;
            // 
            // mobjAddPanel
            // 
            this.mobjAddPanel.Controls.Add(this.mobjAddButton);
            this.mobjAddPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAddPanel.DockPadding.All = 5;
            this.mobjAddPanel.Location = new System.Drawing.Point(337, 148);
            this.mobjAddPanel.Name = "mobjAddPanel";
            this.mobjAddPanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjAddPanel.Size = new System.Drawing.Size(244, 49);
            this.mobjAddPanel.TabIndex = 0;
            // 
            // mobjRemovePanel
            // 
            this.mobjRemovePanel.Controls.Add(this.mobjRemoveButton);
            this.mobjRemovePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRemovePanel.DockPadding.All = 5;
            this.mobjRemovePanel.Location = new System.Drawing.Point(337, 197);
            this.mobjRemovePanel.Name = "mobjRemovePanel";
            this.mobjRemovePanel.Padding = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjRemovePanel.Size = new System.Drawing.Size(244, 49);
            this.mobjRemovePanel.TabIndex = 0;
            // 
            // StackPanelDemonstrationPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(655, 280);
            this.Text = "StackPanelDemonstrationPage";
            this.mobjOrienationGroupBox.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjStackContainerPanel.ResumeLayout(false);
            this.mobjOrientationPanel.ResumeLayout(false);
            this.mobjAddPanel.ResumeLayout(false);
            this.mobjRemovePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.StackPanel mobjStackPanel;
        private Gizmox.WebGUI.Forms.GroupBox mobjOrienationGroupBox;
        private Gizmox.WebGUI.Forms.RadioButton mobjVerticalRadioButton;
        private Gizmox.WebGUI.Forms.RadioButton mobjHorizontalRadioButton;
        private Gizmox.WebGUI.Forms.Button mobjAddButton;
        private Gizmox.WebGUI.Forms.Button mobjRemoveButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjStackContainerPanel;
        private Gizmox.WebGUI.Forms.Panel mobjOrientationPanel;
        private Gizmox.WebGUI.Forms.Panel mobjAddPanel;
        private Gizmox.WebGUI.Forms.Panel mobjRemovePanel;



    }
}