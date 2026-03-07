namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class InspectorEditView
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
			this.mobjCheckShowInspector = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjCheckShowAdvanced = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjListFields = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader4 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader5 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader6 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjButtonAdd = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonEdit = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonRemove = new Gizmox.WebGUI.Forms.Button();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.mobjTextColumns = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjComboDocking = new Gizmox.WebGUI.Forms.ComboBox();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.SuspendLayout();
			// 
			// mobjCheckShowInspector
			// 
			this.mobjCheckShowInspector.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjCheckShowInspector.Location = new System.Drawing.Point(3, 4);
			this.mobjCheckShowInspector.Name = "mobjCheckShowInspector";
			this.mobjCheckShowInspector.Size = new System.Drawing.Size(101, 17);
			this.mobjCheckShowInspector.TabIndex = 0;
			this.mobjCheckShowInspector.Text = "Show Inspector";
			// 
			// mobjCheckShowAdvanced
			// 
			this.mobjCheckShowAdvanced.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjCheckShowAdvanced.Location = new System.Drawing.Point(3, 28);
			this.mobjCheckShowAdvanced.Name = "mobjCheckShowAdvanced";
			this.mobjCheckShowAdvanced.Size = new System.Drawing.Size(103, 17);
			this.mobjCheckShowAdvanced.TabIndex = 1;
			this.mobjCheckShowAdvanced.Text = "Show Advanced";
			// 
			// mobjListFields
			// 
			this.mobjListFields.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
						| Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjListFields.AutoGenerateColumns = true;
			this.mobjListFields.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
			this.mobjListFields.DataMember = null;
			this.mobjListFields.ItemsPerPage = 20;
			this.mobjListFields.Location = new System.Drawing.Point(3, 51);
			this.mobjListFields.Name = "mobjListFields";
			this.mobjListFields.ShowItemToolTips = false;
			this.mobjListFields.Size = new System.Drawing.Size(555, 176);
			this.mobjListFields.TabIndex = 6;
			this.mobjListFields.TotalItems = 1;
			this.mobjListFields.DoubleClick += new System.EventHandler(this.mobjListFields_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Image = null;
			this.columnHeader1.Text = "Label";
			this.columnHeader1.Width = 96;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Image = null;
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 96;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Image = null;
			this.columnHeader4.Text = "Target";
			this.columnHeader4.Width = 96;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Image = null;
			this.columnHeader3.Text = "Property";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Image = null;
			this.columnHeader5.Text = "Column";
			this.columnHeader5.Width = 50;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Image = null;
			this.columnHeader6.Text = "Order";
			this.columnHeader6.Width = 50;
			// 
			// mobjButtonAdd
			// 
			this.mobjButtonAdd.Location = new System.Drawing.Point(579, 51);
			this.mobjButtonAdd.Name = "mobjButtonAdd";
			this.mobjButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonAdd.TabIndex = 7;
			this.mobjButtonAdd.Text = "Add";
			this.mobjButtonAdd.UseVisualStyleBackColor = true;
			this.mobjButtonAdd.Click += new System.EventHandler(this.mobjButtonAdd_Click);
			// 
			// mobjButtonEdit
			// 
			this.mobjButtonEdit.Location = new System.Drawing.Point(579, 81);
			this.mobjButtonEdit.Name = "mobjButtonEdit";
			this.mobjButtonEdit.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonEdit.TabIndex = 8;
			this.mobjButtonEdit.Text = "Edit";
			this.mobjButtonEdit.UseVisualStyleBackColor = true;
			this.mobjButtonEdit.Click += new System.EventHandler(this.mobjButtonEdit_Click);
			// 
			// mobjButtonRemove
			// 
			this.mobjButtonRemove.Location = new System.Drawing.Point(579, 111);
			this.mobjButtonRemove.Name = "mobjButtonRemove";
			this.mobjButtonRemove.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonRemove.TabIndex = 9;
			this.mobjButtonRemove.Text = "Remove";
			this.mobjButtonRemove.UseVisualStyleBackColor = true;
			this.mobjButtonRemove.Click += new System.EventHandler(this.mobjButtonRemove_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(152, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Columns";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mobjTextColumns
			// 
			this.mobjTextColumns.Location = new System.Drawing.Point(205, 2);
			this.mobjTextColumns.Name = "mobjTextColumns";
			this.mobjTextColumns.Size = new System.Drawing.Size(159, 20);
			this.mobjTextColumns.TabIndex = 4;
			// 
			// mobjComboDocking
			// 
			this.mobjComboDocking.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
			this.mobjComboDocking.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
			this.mobjComboDocking.Location = new System.Drawing.Point(205, 26);
			this.mobjComboDocking.MaxDropDownItems = 8;
			this.mobjComboDocking.Name = "mobjComboDocking";
			this.mobjComboDocking.Size = new System.Drawing.Size(159, 21);
			this.mobjComboDocking.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(152, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Docking";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// InspectorEditView
			// 
			this.Controls.Add(this.label2);
			this.Controls.Add(this.mobjComboDocking);
			this.Controls.Add(this.mobjTextColumns);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mobjButtonRemove);
			this.Controls.Add(this.mobjButtonEdit);
			this.Controls.Add(this.mobjButtonAdd);
			this.Controls.Add(this.mobjListFields);
			this.Controls.Add(this.mobjCheckShowAdvanced);
			this.Controls.Add(this.mobjCheckShowInspector);
			this.Size = new System.Drawing.Size(681, 236);
			this.Text = "InspectorEditView";
			this.ResumeLayout(false);

        }

        #endregion

        private CheckBox mobjCheckShowInspector;
        private CheckBox mobjCheckShowAdvanced;
        private ListView mobjListFields;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button mobjButtonAdd;
        private Button mobjButtonEdit;
        private Button mobjButtonRemove;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label1;
        private TextBox mobjTextColumns;
        private ComboBox mobjComboDocking;
        private Label label2;


    }
}
