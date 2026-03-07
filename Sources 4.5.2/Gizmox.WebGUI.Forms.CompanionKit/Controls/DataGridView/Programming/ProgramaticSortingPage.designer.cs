using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.DataGridView.Programming
{
    partial class ProgramaticSortingPage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjDataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn7 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn8 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn9 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjDataGridView
            // 
            this.mobjDataGridView.AllowDrag = false;
            this.mobjDataGridView.AutoGenerateColumns = false;
            this.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mobjDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.mobjDataGridViewTextBoxColumn1,
            this.mobjDataGridViewTextBoxColumn2,
            this.mobjDataGridViewTextBoxColumn3,
            this.mobjDataGridViewTextBoxColumn4,
            this.mobjDataGridViewTextBoxColumn5,
            this.mobjDataGridViewTextBoxColumn6,
            this.mobjDataGridViewTextBoxColumn7,
            this.mobjDataGridViewTextBoxColumn8,
            this.mobjDataGridViewTextBoxColumn9});
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 50);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.Size = new System.Drawing.Size(583, 243);
            this.mobjDataGridView.TabIndex = 0;
            this.mobjDataGridView.ColumnHeaderMouseClick += new Gizmox.WebGUI.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // mobjDataGridViewTextBoxColumn1
            // 
            this.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn1.HeaderText = "User ID";
            this.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1";
            this.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn1.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn2
            // 
            this.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn2.HeaderText = "User Name";
            this.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2";
            this.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn2.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn3
            // 
            this.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn3.HeaderText = "User Email";
            this.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3";
            this.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn3.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn4
            // 
            this.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn4.HeaderText = "User Phone";
            this.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4";
            this.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn4.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn5
            // 
            this.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5;
            this.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn5.HeaderText = "User City";
            this.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5";
            this.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn5.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn6
            // 
            this.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn6.HeaderText = "User Address";
            this.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6";
            this.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn6.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            this.mobjDataGridViewTextBoxColumn6.Width = 130;
            // 
            // mobjDataGridViewTextBoxColumn7
            // 
            this.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7;
            this.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn7.HeaderText = "User Country";
            this.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7";
            this.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn7.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn8
            // 
            this.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle8;
            this.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn8.HeaderText = "User State";
            this.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8";
            this.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn8.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDataGridViewTextBoxColumn9
            // 
            this.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle9;
            this.mobjDataGridViewTextBoxColumn9.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn9.HeaderText = "User ZipCode";
            this.mobjDataGridViewTextBoxColumn9.Name = "mobjDataGridViewTextBoxColumn9";
            this.mobjDataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn9.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(583, 50);
            this.mobjDescriptionLabel.TabIndex = 1;
            this.mobjDescriptionLabel.Text = "DataGridView with programmatic sorting mode";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 2;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(583, 293);
            this.mobjLayoutPanel.TabIndex = 2;
            // 
            // ProgramaticSortingPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(583, 293);
            this.Text = "ProgramaticSortingPage";
            this.Load += new System.EventHandler(this.ProgramaticSortingPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.DataGridView mobjDataGridView;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn mobjDataGridViewTextBoxColumn9;
        private Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;




    }
}
