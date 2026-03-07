using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.DataGridView.Appearance
{
    partial class CellStylePage
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
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.mobjDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.mobjDataGridViewTextBoxColumn1 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn2 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn3 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn4 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn5 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjDataGridViewTextBoxColumn6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjGroupBox = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjTopLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjColorsPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjColorsLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjColorComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjWrapModePanel = new Gizmox.WebGUI.Forms.Panel();
            this.wrapModeLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjWrapModeComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjColorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjFontPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjFontLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFontChangeButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAlignmentPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjAlignLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjAlignComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjColorDialog = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjFontDialog = new Gizmox.WebGUI.Forms.FontDialog();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            this.mobjGroupBox.SuspendLayout();
            this.mobjTopLayoutPanel.SuspendLayout();
            this.mobjColorsPanel.SuspendLayout();
            this.mobjWrapModePanel.SuspendLayout();
            this.mobjFontPanel.SuspendLayout();
            this.mobjAlignmentPanel.SuspendLayout();
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
            this.mobjDataGridViewTextBoxColumn6});
            this.mobjDataGridView.DataSource = this.mobjBindingSource;
            this.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataGridView.Location = new System.Drawing.Point(0, 190);
            this.mobjDataGridView.Name = "mobjDataGridView";
            this.mobjDataGridView.Size = new System.Drawing.Size(830, 157);
            this.mobjDataGridView.TabIndex = 0;
            this.mobjDataGridView.SelectionChanged += new System.EventHandler(this.mobjDataGridView_SelectionChanged);
            // 
            // mobjDataGridViewTextBoxColumn1
            // 
            this.mobjDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1";
            this.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn2
            // 
            this.mobjDataGridViewTextBoxColumn2.DataPropertyName = "FirstName";
            this.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn2.HeaderText = "FirstName";
            this.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2";
            this.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn3
            // 
            this.mobjDataGridViewTextBoxColumn3.DataPropertyName = "LastName";
            this.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn3.HeaderText = "LastName";
            this.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3";
            this.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn4
            // 
            this.mobjDataGridViewTextBoxColumn4.DataPropertyName = "FullName";
            this.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn4.HeaderText = "FullName";
            this.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4";
            this.mobjDataGridViewTextBoxColumn4.ReadOnly = true;
            this.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            // 
            // mobjDataGridViewTextBoxColumn5
            // 
            this.mobjDataGridViewTextBoxColumn5.DataPropertyName = "FavoriteColor";
            this.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn5.HeaderText = "FavoriteColor";
            this.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5";
            this.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn5.Visible = false;
            // 
            // mobjDataGridViewTextBoxColumn6
            // 
            this.mobjDataGridViewTextBoxColumn6.DataPropertyName = "Foto";
            this.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = typeof(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell);
            this.mobjDataGridViewTextBoxColumn6.HeaderText = "Foto";
            this.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6";
            this.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.True;
            this.mobjDataGridViewTextBoxColumn6.Visible = false;
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataSource = typeof(Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer);
            // 
            // mobjGroupBox
            // 
            this.mobjGroupBox.Controls.Add(this.mobjTopLayoutPanel);
            this.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjGroupBox.Location = new System.Drawing.Point(0, 0);
            this.mobjGroupBox.Name = "mobjGroupBox";
            this.mobjGroupBox.Size = new System.Drawing.Size(830, 140);
            this.mobjGroupBox.TabIndex = 1;
            this.mobjGroupBox.TabStop = false;
            this.mobjGroupBox.Text = "Cell Style";
            // 
            // mobjTopLayoutPanel
            // 
            this.mobjTopLayoutPanel.ColumnCount = 5;
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 28F));
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 28F));
            this.mobjTopLayoutPanel.Controls.Add(this.mobjColorsPanel, 0, 0);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjWrapModePanel, 3, 2);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjColorButton, 1, 0);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjFontPanel, 3, 0);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjFontChangeButton, 4, 0);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjAlignmentPanel, 0, 2);
            this.mobjTopLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopLayoutPanel.Location = new System.Drawing.Point(3, 17);
            this.mobjTopLayoutPanel.Name = "mobjTopLayoutPanel";
            this.mobjTopLayoutPanel.RowCount = 3;
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTopLayoutPanel.Size = new System.Drawing.Size(824, 120);
            this.mobjTopLayoutPanel.TabIndex = 10;
            // 
            // mobjColorsPanel
            // 
            this.mobjColorsPanel.Controls.Add(this.mobjColorsLabel);
            this.mobjColorsPanel.Controls.Add(this.mobjColorComboBox);
            this.mobjColorsPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjColorsPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjColorsPanel.Name = "mobjColorsPanel";
            this.mobjColorsPanel.Size = new System.Drawing.Size(379, 55);
            this.mobjColorsPanel.TabIndex = 0;
            // 
            // mobjColorsLabel
            // 
            this.mobjColorsLabel.AutoSize = true;
            this.mobjColorsLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjColorsLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjColorsLabel.Name = "mobjColorsLabel";
            this.mobjColorsLabel.Size = new System.Drawing.Size(37, 13);
            this.mobjColorsLabel.TabIndex = 0;
            this.mobjColorsLabel.Text = "Colors";
            // 
            // mobjColorComboBox
            // 
            this.mobjColorComboBox.AllowDrag = false;
            this.mobjColorComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjColorComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjColorComboBox.Location = new System.Drawing.Point(0, 34);
            this.mobjColorComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjColorComboBox.MinimumSize = new System.Drawing.Size(0, 30);
            this.mobjColorComboBox.Name = "mobjColorComboBox";
            this.mobjColorComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjColorComboBox.TabIndex = 1;
            // 
            // mobjWrapModePanel
            // 
            this.mobjWrapModePanel.Controls.Add(this.wrapModeLabel);
            this.mobjWrapModePanel.Controls.Add(this.mobjWrapModeComboBox);
            this.mobjWrapModePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWrapModePanel.Location = new System.Drawing.Point(417, 65);
            this.mobjWrapModePanel.Name = "mobjWrapModePanel";
            this.mobjWrapModePanel.Size = new System.Drawing.Size(379, 55);
            this.mobjWrapModePanel.TabIndex = 0;
            // 
            // wrapModeLabel
            // 
            this.wrapModeLabel.AutoSize = true;
            this.wrapModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.wrapModeLabel.Location = new System.Drawing.Point(0, 0);
            this.wrapModeLabel.Name = "wrapModeLabel";
            this.wrapModeLabel.Size = new System.Drawing.Size(59, 13);
            this.wrapModeLabel.TabIndex = 8;
            this.wrapModeLabel.Text = "WrapMode";
            // 
            // mobjWrapModeComboBox
            // 
            this.mobjWrapModeComboBox.AllowDrag = false;
            this.mobjWrapModeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjWrapModeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjWrapModeComboBox.Location = new System.Drawing.Point(0, 34);
            this.mobjWrapModeComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjWrapModeComboBox.MinimumSize = new System.Drawing.Size(0, 30);
            this.mobjWrapModeComboBox.Name = "mobjWrapModeComboBox";
            this.mobjWrapModeComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjWrapModeComboBox.TabIndex = 9;
            this.mobjWrapModeComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjWrapModeComboBox_SelectedIndexChanged);
            // 
            // mobjColorButton
            // 
            this.mobjColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjColorButton.Location = new System.Drawing.Point(379, 0);
            this.mobjColorButton.Name = "mobjColorButton";
            this.mobjColorButton.Size = new System.Drawing.Size(28, 55);
            this.mobjColorButton.TabIndex = 2;
            this.mobjColorButton.Text = "...";
            this.mobjColorButton.UseVisualStyleBackColor = true;
            this.mobjColorButton.Click += new System.EventHandler(this.mobjColorButton_Click);
            // 
            // mobjFontPanel
            // 
            this.mobjFontPanel.Controls.Add(this.mobjFontLabel);
            this.mobjFontPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontPanel.Location = new System.Drawing.Point(417, 0);
            this.mobjFontPanel.Name = "mobjFontPanel";
            this.mobjFontPanel.Size = new System.Drawing.Size(379, 55);
            this.mobjFontPanel.TabIndex = 0;
            // 
            // mobjFontLabel
            // 
            this.mobjFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjFontLabel.Name = "mobjFontLabel";
            this.mobjFontLabel.Size = new System.Drawing.Size(379, 55);
            this.mobjFontLabel.TabIndex = 5;
            this.mobjFontLabel.Text = "Font: Tahoma, 8.25pt";
            // 
            // mobjFontChangeButton
            // 
            this.mobjFontChangeButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFontChangeButton.Location = new System.Drawing.Point(796, 0);
            this.mobjFontChangeButton.Name = "mobjFontChangeButton";
            this.mobjFontChangeButton.Size = new System.Drawing.Size(28, 55);
            this.mobjFontChangeButton.TabIndex = 6;
            this.mobjFontChangeButton.Text = "...";
            this.mobjFontChangeButton.UseVisualStyleBackColor = true;
            this.mobjFontChangeButton.Click += new System.EventHandler(this.mobjFontChangeButton_Click);
            // 
            // mobjAlignmentPanel
            // 
            this.mobjAlignmentPanel.Controls.Add(this.mobjAlignLabel);
            this.mobjAlignmentPanel.Controls.Add(this.mobjAlignComboBox);
            this.mobjAlignmentPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAlignmentPanel.Location = new System.Drawing.Point(0, 65);
            this.mobjAlignmentPanel.Name = "mobjAlignmentPanel";
            this.mobjAlignmentPanel.Size = new System.Drawing.Size(379, 55);
            this.mobjAlignmentPanel.TabIndex = 0;
            // 
            // mobjAlignLabel
            // 
            this.mobjAlignLabel.AutoSize = true;
            this.mobjAlignLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjAlignLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjAlignLabel.Name = "mobjAlignLabel";
            this.mobjAlignLabel.Size = new System.Drawing.Size(54, 13);
            this.mobjAlignLabel.TabIndex = 3;
            this.mobjAlignLabel.Text = "Alignment";
            // 
            // mobjAlignComboBox
            // 
            this.mobjAlignComboBox.AllowDrag = false;
            this.mobjAlignComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjAlignComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjAlignComboBox.Location = new System.Drawing.Point(0, 34);
            this.mobjAlignComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjAlignComboBox.MinimumSize = new System.Drawing.Size(0, 30);
            this.mobjAlignComboBox.Name = "mobjAlignComboBox";
            this.mobjAlignComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjAlignComboBox.TabIndex = 4;
            this.mobjAlignComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjAlignComboBox_SelectedIndexChanged);
            // 
            // mobjColorDialog
            // 
            this.mobjColorDialog.Closed += new System.EventHandler(this.mobjColorDialog_Closed);
            // 
            // mobjFontDialog
            // 
            this.mobjFontDialog.MaxSize = 72;
            this.mobjFontDialog.MinSize = 8;
            this.mobjFontDialog.Apply += new System.EventHandler(this.mobjFontDialog_Apply);
            this.mobjFontDialog.Closed += new System.EventHandler(this.mobjFontDialog_Closed);
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 140);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(830, 50);
            this.mobjDescriptionLabel.TabIndex = 2;
            this.mobjDescriptionLabel.Text = "DataGridView demonstrates how to change the cell style";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 1;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Controls.Add(this.mobjGroupBox, 0, 0);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataGridView, 0, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjDescriptionLabel, 0, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 3;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 140F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(830, 347);
            this.mobjLayoutPanel.TabIndex = 3;
            // 
            // CellStylePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(830, 347);
            this.Text = "CellStylePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            this.mobjGroupBox.ResumeLayout(false);
            this.mobjTopLayoutPanel.ResumeLayout(false);
            this.mobjColorsPanel.ResumeLayout(false);
            this.mobjWrapModePanel.ResumeLayout(false);
            this.mobjFontPanel.ResumeLayout(false);
            this.mobjAlignmentPanel.ResumeLayout(false);
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
        private BindingSource mobjBindingSource;
        private global::Gizmox.WebGUI.Forms.GroupBox mobjGroupBox;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjColorComboBox;
        private global::Gizmox.WebGUI.Forms.Label mobjColorsLabel;
        private ColorDialog mobjColorDialog;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjAlignComboBox;
        private global::Gizmox.WebGUI.Forms.Label mobjAlignLabel;
        private global::Gizmox.WebGUI.Forms.Button mobjColorButton;
        private global::Gizmox.WebGUI.Forms.Button mobjFontChangeButton;
        private global::Gizmox.WebGUI.Forms.Label mobjFontLabel;
        private FontDialog mobjFontDialog;
        private global::Gizmox.WebGUI.Forms.ComboBox mobjWrapModeComboBox;
        private global::Gizmox.WebGUI.Forms.Label wrapModeLabel;
        private Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTopLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjColorsPanel;
        private Gizmox.WebGUI.Forms.Panel mobjAlignmentPanel;
        private Gizmox.WebGUI.Forms.Panel mobjFontPanel;
        private Gizmox.WebGUI.Forms.Panel mobjWrapModePanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
