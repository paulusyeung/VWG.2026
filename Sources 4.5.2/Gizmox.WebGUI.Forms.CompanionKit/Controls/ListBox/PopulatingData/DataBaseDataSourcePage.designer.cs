namespace CompanionKit.Controls.ListBox.PopulatingData
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.bindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.northwindDataSet = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.customersTableAdapter = new Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter();
            this.mobjDisplayLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDisplayText = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjValueText = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.northwindDataSet)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjTLP.SetColumnSpan(this.mobjListBox, 2);
            this.mobjListBox.DataSource = this.bindingSource1;
            this.mobjListBox.DisplayMember = "ContactName";
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Location = new System.Drawing.Point(0, 52);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(320, 186);
            this.mobjListBox.TabIndex = 0;
            this.mobjListBox.ValueMember = "CustomerID";
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
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 52);
            this.mobjInfoLabel.TabIndex = 1;
            this.mobjInfoLabel.Text = "ListBox with a database DataSource:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // mobjDisplayLabel
            // 
            this.mobjDisplayLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDisplayLabel.Location = new System.Drawing.Point(0, 244);
            this.mobjDisplayLabel.Name = "mobjDisplayLabel";
            this.mobjDisplayLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjDisplayLabel.Size = new System.Drawing.Size(160, 52);
            this.mobjDisplayLabel.TabIndex = 2;
            this.mobjDisplayLabel.Text = "Display Member";
            this.mobjDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjValueLabel
            // 
            this.mobjValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueLabel.Location = new System.Drawing.Point(0, 296);
            this.mobjValueLabel.Name = "mobjValueLabel";
            this.mobjValueLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjValueLabel.Size = new System.Drawing.Size(160, 54);
            this.mobjValueLabel.TabIndex = 3;
            this.mobjValueLabel.Text = "Value Member";
            this.mobjValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjDisplayText
            // 
            this.mobjDisplayText.AllowDrag = false;
            this.mobjDisplayText.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjDisplayText.Location = new System.Drawing.Point(163, 257);
            this.mobjDisplayText.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjDisplayText.Name = "mobjDisplayText";
            this.mobjDisplayText.ReadOnly = true;
            this.mobjDisplayText.Size = new System.Drawing.Size(154, 25);
            this.mobjDisplayText.TabIndex = 4;
            // 
            // mobjValueText
            // 
            this.mobjValueText.AllowDrag = false;
            this.mobjValueText.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjValueText.Location = new System.Drawing.Point(163, 310);
            this.mobjValueText.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueText.Name = "mobjValueText";
            this.mobjValueText.ReadOnly = true;
            this.mobjValueText.Size = new System.Drawing.Size(154, 25);
            this.mobjValueText.TabIndex = 5;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjValueText, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjListBox, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjDisplayText, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjDisplayLabel, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjValueLabel, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
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

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.BindingSource bindingSource1;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSet northwindDataSet;
        private Gizmox.WebGUI.Forms.CompanionKit.NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private Gizmox.WebGUI.Forms.Label mobjDisplayLabel;
        private Gizmox.WebGUI.Forms.Label mobjValueLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjDisplayText;
        private Gizmox.WebGUI.Forms.TextBox mobjValueText;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
