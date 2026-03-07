namespace CompanionKit.Controls.TrackBar.Functionality
{
    partial class TickStylePage
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
            this.mobjDemoTrackBar = new Gizmox.WebGUI.Forms.TrackBar();
            this.mobjTickStyleLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTickStyleComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDemoTrackBar
            // 
            this.mobjDemoTrackBar.AllowDrag = false;
            this.mobjDemoTrackBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDemoTrackBar.Location = new System.Drawing.Point(91, 106);
            this.mobjDemoTrackBar.Maximum = 100;
            this.mobjDemoTrackBar.Name = "mobjDemoTrackBar";
            this.mobjDemoTrackBar.Size = new System.Drawing.Size(424, 40);
            this.mobjDemoTrackBar.TabIndex = 0;
            this.mobjDemoTrackBar.TickFrequency = 5;
            // 
            // mobjTickStyleLabel
            // 
            this.mobjTickStyleLabel.AutoSize = true;
            this.mobjTickStyleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTickStyleLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjTickStyleLabel.Name = "mobjTickStyleLabel";
            this.mobjTickStyleLabel.Size = new System.Drawing.Size(126, 13);
            this.mobjTickStyleLabel.TabIndex = 2;
            this.mobjTickStyleLabel.Text = "TickStyle of the TrackBar";
            // 
            // mobjTickStyleComboBox
            // 
            this.mobjTickStyleComboBox.AllowDrag = false;
            this.mobjTickStyleComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjTickStyleComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjTickStyleComboBox.Location = new System.Drawing.Point(0, 39);
            this.mobjTickStyleComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTickStyleComboBox.Name = "mobjTickStyleComboBox";
            this.mobjTickStyleComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjTickStyleComboBox.TabIndex = 3;
            this.mobjTickStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjTickStyleComboBox_SelectedIndexChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDemoTrackBar, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 1, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(607, 172);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjTickStyleLabel);
            this.mobjPanel.Controls.Add(this.mobjTickStyleComboBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(91, 26);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(424, 60);
            this.mobjPanel.TabIndex = 0;
            // 
            // TickStylePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(607, 172);
            this.Text = "TickStylePage";
            this.Load += new System.EventHandler(this.TickStylePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDemoTrackBar)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TrackBar mobjDemoTrackBar;
        private Gizmox.WebGUI.Forms.Label mobjTickStyleLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjTickStyleComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;



    }
}
