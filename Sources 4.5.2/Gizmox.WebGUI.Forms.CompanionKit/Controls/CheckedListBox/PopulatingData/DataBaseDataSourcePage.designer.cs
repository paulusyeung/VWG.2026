namespace CompanionKit.Controls.CheckedListBox.PopulatingData
{
    partial class DataBaseDataSourcePage
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
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckedListBox = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.bindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.northwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.customersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjValueLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjDisplayLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueTB = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDisplayTB = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 52);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "CheckedListBox with DataBase DataSource:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCheckedListBox
            // 
            this.mobjTLP.SetColumnSpan(this.mobjCheckedListBox, 2);
            this.mobjCheckedListBox.DataSource = this.bindingSource1;
            this.mobjCheckedListBox.DisplayMember = "ContactName";
            this.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckedListBox.Location = new System.Drawing.Point(0, 52);
            this.mobjCheckedListBox.Name = "mobjCheckedListBox";
            this.mobjCheckedListBox.Size = new System.Drawing.Size(320, 212);
            this.mobjCheckedListBox.TabIndex = 1;
            this.mobjCheckedListBox.ValueMember = "CustomerID";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Customers";
            this.bindingSource1.DataSource = this.northwindDataSet;
            // 
            // northwindDataSet
            // 
            this.northwindDataSet.DataSetName = "NorthwindDataSet";
            this.northwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // mobjValueLbl
            // 
            this.mobjValueLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueLbl.Location = new System.Drawing.Point(0, 279);
            this.mobjValueLbl.Name = "mobjValueLbl";
            this.mobjValueLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjValueLbl.Size = new System.Drawing.Size(160, 35);
            this.mobjValueLbl.TabIndex = 2;
            this.mobjValueLbl.Text = "ValueMember";
            this.mobjValueLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjDisplayLbl
            // 
            this.mobjDisplayLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDisplayLbl.Location = new System.Drawing.Point(0, 314);
            this.mobjDisplayLbl.Name = "mobjDisplayLbl";
            this.mobjDisplayLbl.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjDisplayLbl.Size = new System.Drawing.Size(160, 36);
            this.mobjDisplayLbl.TabIndex = 3;
            this.mobjDisplayLbl.Text = "DisplayMember";
            this.mobjDisplayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjValueTB
            // 
            this.mobjValueTB.AllowDrag = false;
            this.mobjValueTB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjValueTB.Location = new System.Drawing.Point(163, 284);
            this.mobjValueTB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueTB.Name = "mobjValueTB";
            this.mobjValueTB.ReadOnly = true;
            this.mobjValueTB.Size = new System.Drawing.Size(154, 25);
            this.mobjValueTB.TabIndex = 4;
            // 
            // mobjDisplayTB
            // 
            this.mobjDisplayTB.AllowDrag = false;
            this.mobjDisplayTB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjDisplayTB.Location = new System.Drawing.Point(163, 319);
            this.mobjDisplayTB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjDisplayTB.Name = "mobjDisplayTB";
            this.mobjDisplayTB.ReadOnly = true;
            this.mobjDisplayTB.Size = new System.Drawing.Size(154, 25);
            this.mobjDisplayTB.TabIndex = 5;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjDisplayTB, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjCheckedListBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjValueTB, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjValueLbl, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjDisplayLbl, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 350);
            this.mobjTLP.TabIndex = 6;
            // 
            // DataBaseDataSourcePage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 350);
            this.Text = "DataBaseDataSourcePage";
            this.Load += new System.EventHandler(this.DataBaseDataSourcePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckedListBox mobjCheckedListBox;
        private Gizmox.WebGUI.Forms.BindingSource bindingSource1;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet northwindDataSet;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private Gizmox.WebGUI.Forms.Label mobjValueLbl;
        private Gizmox.WebGUI.Forms.Label mobjDisplayLbl;
        private Gizmox.WebGUI.Forms.TextBox mobjValueTB;
        private Gizmox.WebGUI.Forms.TextBox mobjDisplayTB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
