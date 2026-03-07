using CompanionKit.Controls.DataGridView;
using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.DataGridView.Features
{
    partial class SelectionPage
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
            this.components = new System.ComponentModel.Container();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
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
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjUserDS = new CompanionKit.Controls.DataGridView.UserDS();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSelectionModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSelectionModeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjComboPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjUserDS)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjComboPanel.SuspendLayout();
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
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDataGridView, 3);
            this.mobjDataGridView.DataSource = this.mobjBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 100);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.Size = new System.Drawing.Size(631, 243);
            this.mobjDataGridView.TabIndex = 1;
            // 
            // mobjDataGridViewTextBoxColumn1
            // 
            this.mobjDataGridViewTextBoxColumn1.DataPropertyName = "UserId";
            this.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            this.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn1.HeaderText = "User ID";
            this.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1";
            this.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn2
            // 
            this.mobjDataGridViewTextBoxColumn2.DataPropertyName = "UserName";
            this.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle11;
            this.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn2.HeaderText = "User Name";
            this.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2";
            this.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn3
            // 
            this.mobjDataGridViewTextBoxColumn3.DataPropertyName = "UserEmail";
            this.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle12;
            this.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn3.HeaderText = "User Email";
            this.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3";
            this.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn4
            // 
            this.mobjDataGridViewTextBoxColumn4.DataPropertyName = "UserPhone";
            this.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle13;
            this.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn4.HeaderText = "User Phone";
            this.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4";
            this.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn5
            // 
            this.mobjDataGridViewTextBoxColumn5.DataPropertyName = "UserCity";
            this.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle14;
            this.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn5.HeaderText = "User City";
            this.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5";
            this.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn6
            // 
            this.mobjDataGridViewTextBoxColumn6.DataPropertyName = "UserAddress";
            this.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle15;
            this.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn6.HeaderText = "User Address";
            this.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6";
            this.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn6.Width = 130;
            // 
            // mobjDataGridViewTextBoxColumn7
            // 
            this.mobjDataGridViewTextBoxColumn7.DataPropertyName = "UserCountry";
            this.mobjDataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle16;
            this.mobjDataGridViewTextBoxColumn7.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn7.HeaderText = "User Country";
            this.mobjDataGridViewTextBoxColumn7.Name = "mobjDataGridViewTextBoxColumn7";
            this.mobjDataGridViewTextBoxColumn7.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn8
            // 
            this.mobjDataGridViewTextBoxColumn8.DataPropertyName = "UserState";
            this.mobjDataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle17;
            this.mobjDataGridViewTextBoxColumn8.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn8.HeaderText = "User State";
            this.mobjDataGridViewTextBoxColumn8.Name = "mobjDataGridViewTextBoxColumn8";
            this.mobjDataGridViewTextBoxColumn8.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn9
            // 
            this.mobjDataGridViewTextBoxColumn9.DataPropertyName = "UserZipCode";
            this.mobjDataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle18;
            this.mobjDataGridViewTextBoxColumn9.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn9.HeaderText = "User ZipCode";
            this.mobjDataGridViewTextBoxColumn9.Name = "mobjDataGridViewTextBoxColumn9";
            this.mobjDataGridViewTextBoxColumn9.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataMember = "Users";
            this.mobjBindingSource.DataSource = this.mobjUserDS;
            // 
            // mobjUserDS
            // 
            this.mobjUserDS.DataSetName = "UserDS";
            this.mobjUserDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDescriptionLabel, 3);
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 50);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(631, 50);
            this.mobjDescriptionLabel.TabIndex = 2;
            this.mobjDescriptionLabel.Text = "DataGridView demonstrates selection modes";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjSelectionModeLabel
            // 
            this.mobjSelectionModeLabel.AutoSize = true;
            this.mobjSelectionModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSelectionModeLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjSelectionModeLabel.Name = "mobjSelectionModeLabel";
            this.mobjSelectionModeLabel.Size = new System.Drawing.Size(372, 50);
            this.mobjSelectionModeLabel.TabIndex = 3;
            this.mobjSelectionModeLabel.Text = "Change the selection mode:";
            this.mobjSelectionModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjSelectionModeComboBox
            // 
            this.mobjSelectionModeComboBox.AllowDrag = false;
            this.mobjSelectionModeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.mobjSelectionModeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjSelectionModeComboBox.Location = new System.Drawing.Point(0, 19);
            this.mobjSelectionModeComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjSelectionModeComboBox.MinimumSize = new System.Drawing.Size(0, 30);
            this.mobjSelectionModeComboBox.Name = "mobjSelectionModeComboBox";
            this.mobjSelectionModeComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjSelectionModeComboBox.TabIndex = 4;
            this.mobjSelectionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjSelectionModeComboBox_SelectedIndexChanged);
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjSelectionModeLabel, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboPanel, 2, 0);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(631, 343);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // mobjComboPanel
            // 
            this.mobjComboPanel.Controls.Add(this.mobjSelectionModeComboBox);
            this.mobjComboPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboPanel.DockPadding.Bottom = 10;
            this.mobjComboPanel.Location = new System.Drawing.Point(382, 0);
            this.mobjComboPanel.Name = "mobjComboPanel";
            this.mobjComboPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 10);
            this.mobjComboPanel.Size = new System.Drawing.Size(249, 50);
            this.mobjComboPanel.TabIndex = 0;
            // 
            // SelectionPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(631, 343);
            this.Text = "SelectionPage";
            this.Load += new System.EventHandler(this.SelectionPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjUserDS)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjComboPanel.ResumeLayout(false);
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
        private BindingSource mobjBindingSource;
        private CompanionKit.Controls.DataGridView.UserDS mobjUserDS;
        private Label mobjDescriptionLabel;
        private Label mobjSelectionModeLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjSelectionModeComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjComboPanel;
    }
}
