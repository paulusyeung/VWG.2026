namespace CompanionKit.Controls.DataGridView.Features
{
    partial class ResizeAllRowsPage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDGV = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjResizeAllCB = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjStandardTabCB = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjLayoutPanel.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(591, 100);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Change the values of ResizeAllRows and StandardTab properties using CheckBoxes:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDGV
            // 
            this.mobjDGV.AllowDrag = false;
            this.mobjDGV.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjColumn1,
            this.mobjColumn2,
            this.mobjColumn3});
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDGV, 2);
            this.mobjDGV.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDGV.Location = new System.Drawing.Point(0, 100);
            this.mobjDGV.Name = "mobjDGV";
            this.mobjDGV.Size = new System.Drawing.Size(591, 298);
            this.mobjDGV.TabIndex = 1;
            // 
            // mobjColumn1
            // 
            this.mobjColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjColumn1.Name = "mobjColumn1";
            // 
            // mobjColumn2
            // 
            this.mobjColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjColumn2.Name = "mobjColumn2";
            // 
            // mobjColumn3
            // 
            this.mobjColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjColumn3.Name = "mobjColumn3";
            // 
            // mobjResizeAllCB
            // 
            this.mobjResizeAllCB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjResizeAllCB.Location = new System.Drawing.Point(0, 398);
            this.mobjResizeAllCB.Name = "mobjResizeAllCB";
            this.mobjResizeAllCB.Size = new System.Drawing.Size(295, 60);
            this.mobjResizeAllCB.TabIndex = 2;
            this.mobjResizeAllCB.Text = "EnforceEqualRowSize";
            this.mobjResizeAllCB.CheckedChanged += new System.EventHandler(this.mobjResizeAllCB_CheckedChanged);
            // 
            // mobjStandardTabCB
            // 
            this.mobjStandardTabCB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStandardTabCB.Location = new System.Drawing.Point(295, 398);
            this.mobjStandardTabCB.Name = "mobjStandardTabCB";
            this.mobjStandardTabCB.Size = new System.Drawing.Size(296, 60);
            this.mobjStandardTabCB.TabIndex = 3;
            this.mobjStandardTabCB.Text = "StandardTab";
            this.mobjStandardTabCB.CheckedChanged += new System.EventHandler(this.mobjStandardTabCB_CheckedChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 2;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjStandardTabCB, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDGV, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjResizeAllCB, 0, 2);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(591, 458);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // ResizeAllRowsPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(591, 458);
            this.Text = "ResizeAllRowsPage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDGV)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.DataGridView mobjDGV;
        private Gizmox.WebGUI.Forms.CheckBox mobjResizeAllCB;
        private Gizmox.WebGUI.Forms.CheckBox mobjStandardTabCB;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn mobjColumn1;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn mobjColumn2;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn mobjColumn3;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}