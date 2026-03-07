namespace CompanionKit.Concepts.ClientAPI.FillingDataGridView
{
    partial class FillingDataGridViewPage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.objRightPanel = new Gizmox.WebGUI.Forms.Panel();
            this.objNumericUpDown = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.objButton = new Gizmox.WebGUI.Forms.Button();
            this.objDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.Id = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Value = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.objRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // objRightPanel
            // 
            this.objRightPanel.Controls.Add(this.objNumericUpDown);
            this.objRightPanel.Controls.Add(this.objButton);
            this.objRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.objRightPanel.Location = new System.Drawing.Point(15, 168);
            this.objRightPanel.Name = "objRightPanel";
            this.objRightPanel.Size = new System.Drawing.Size(261, 90);
            this.objRightPanel.TabIndex = 3;
            // 
            // objNumericUpDown
            // 
            this.objNumericUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.objNumericUpDown.ClientId = "nud";
            this.objNumericUpDown.CurrentValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.objNumericUpDown.Location = new System.Drawing.Point(17, 12);
            this.objNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.objNumericUpDown.Name = "objNumericUpDown";
            this.objNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.objNumericUpDown.TabIndex = 2;
            this.objNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // objButton
            // 
            this.objButton.Location = new System.Drawing.Point(17, 49);
            this.objButton.Name = "objButton";
            this.objButton.Size = new System.Drawing.Size(120, 26);
            this.objButton.TabIndex = 1;
            this.objButton.Text = "Fill Grid";
            this.objButton.Click += new System.EventHandler(this.objButton_Click);
            // 
            // objDataGridView
            // 
            this.objDataGridView.AllowDrag = false;
            this.objDataGridView.AutoSizeColumnsMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.objDataGridView.ClientId = "dvg";
            this.objDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Id,
            this.Value});
            this.objDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.objDataGridView.Location = new System.Drawing.Point(15, 15);
            this.objDataGridView.Name = "objDataGridView";
            this.objDataGridView.Size = new System.Drawing.Size(261, 153);
            this.objDataGridView.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.AllowRowFiltering = false;
            this.Id.CanGroupBy = false;
            this.Id.ClientId = "colId";
            this.Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Id.Name = "Id";
            this.Id.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Id.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Value
            // 
            this.Value.AllowRowFiltering = false;
            this.Value.CanGroupBy = false;
            this.Value.ClientId = "colVal";
            this.Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.Value.Name = "Value";
            this.Value.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.False;
            this.Value.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FillingDataGridViewPage
            // 
            this.Controls.Add(this.objDataGridView);
            this.Controls.Add(this.objRightPanel);
            this.DockPadding.All = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(295, 273);
            this.Text = "FillingDataGridViewPage";
            this.objRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel objRightPanel;
        private Gizmox.WebGUI.Forms.Button objButton;
        private Gizmox.WebGUI.Forms.DataGridView objDataGridView;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn Id;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn Value;
        private Gizmox.WebGUI.Forms.NumericUpDown objNumericUpDown;



    }
}