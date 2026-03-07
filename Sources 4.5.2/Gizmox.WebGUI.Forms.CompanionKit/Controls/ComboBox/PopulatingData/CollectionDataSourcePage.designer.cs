
namespace CompanionKit.Controls.ComboBox.PopulatingData
{
    partial class CollectionDataSourcePage
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
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjCollectionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjNameTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjValueMemberLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDataLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueMemberTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDataTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.DataSource = this.mobjBindingSource;
            this.mobjComboBox.DisplayMember = "FullName";
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.Location = new System.Drawing.Point(0, 10);
            this.mobjComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 0;
            this.mobjComboBox.ValueMember = "ID";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataSource = typeof(System.Collections.Generic.List<Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer>);
            // 
            // mobjCollectionLabel
            // 
            this.mobjCollectionLabel.AutoSize = true;
            this.mobjCollectionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCollectionLabel.Location = new System.Drawing.Point(10, 0);
            this.mobjCollectionLabel.Name = "mobjCollectionLabel";
            this.mobjCollectionLabel.Size = new System.Drawing.Size(285, 50);
            this.mobjCollectionLabel.TabIndex = 1;
            this.mobjCollectionLabel.Text = "DataSource: Collection";
            this.mobjCollectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjValueLabel
            // 
            this.mobjValueLabel.AutoSize = true;
            this.mobjValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueLabel.Location = new System.Drawing.Point(10, 70);
            this.mobjValueLabel.Name = "mobjValueLabel";
            this.mobjValueLabel.Size = new System.Drawing.Size(285, 30);
            this.mobjValueLabel.TabIndex = 2;
            this.mobjValueLabel.Text = "Selected value";
            this.mobjValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjNameLabel
            // 
            this.mobjNameLabel.AutoSize = true;
            this.mobjNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNameLabel.Location = new System.Drawing.Point(10, 120);
            this.mobjNameLabel.Name = "mobjNameLabel";
            this.mobjNameLabel.Size = new System.Drawing.Size(285, 30);
            this.mobjNameLabel.TabIndex = 3;
            this.mobjNameLabel.Text = "Selected Name";
            this.mobjNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjValueTextBox
            // 
            this.mobjValueTextBox.AllowDrag = false;
            this.mobjValueTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueTextBox.Location = new System.Drawing.Point(298, 73);
            this.mobjValueTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueTextBox.Name = "mobjValueTextBox";
            this.mobjValueTextBox.Size = new System.Drawing.Size(200, 24);
            this.mobjValueTextBox.TabIndex = 4;
            // 
            // mobjNameTextBox
            // 
            this.mobjNameTextBox.AllowDrag = false;
            this.mobjNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjNameTextBox.Location = new System.Drawing.Point(298, 123);
            this.mobjNameTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjNameTextBox.Name = "mobjNameTextBox";
            this.mobjNameTextBox.Size = new System.Drawing.Size(200, 24);
            this.mobjNameTextBox.TabIndex = 5;
            // 
            // mobjValueMemberLabel
            // 
            this.mobjValueMemberLabel.AutoSize = true;
            this.mobjValueMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueMemberLabel.Location = new System.Drawing.Point(10, 170);
            this.mobjValueMemberLabel.Name = "mobjValueMemberLabel";
            this.mobjValueMemberLabel.Size = new System.Drawing.Size(285, 30);
            this.mobjValueMemberLabel.TabIndex = 6;
            this.mobjValueMemberLabel.Text = "ValueMember";
            this.mobjValueMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDataLabel
            // 
            this.mobjDataLabel.AutoSize = true;
            this.mobjDataLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataLabel.Location = new System.Drawing.Point(10, 220);
            this.mobjDataLabel.Name = "mobjDataLabel";
            this.mobjDataLabel.Size = new System.Drawing.Size(285, 30);
            this.mobjDataLabel.TabIndex = 7;
            this.mobjDataLabel.Text = "Data";
            this.mobjDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjValueMemberTextBox
            // 
            this.mobjValueMemberTextBox.AllowDrag = false;
            this.mobjValueMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueMemberTextBox.Location = new System.Drawing.Point(298, 173);
            this.mobjValueMemberTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjValueMemberTextBox.Name = "mobjValueMemberTextBox";
            this.mobjValueMemberTextBox.Size = new System.Drawing.Size(200, 24);
            this.mobjValueMemberTextBox.TabIndex = 8;
            this.mobjValueMemberTextBox.Text = "ID";
            this.mobjValueMemberTextBox.TextChanged += new System.EventHandler(this.mobjValueMemberTextBox_TextChanged);
            // 
            // mobjDataTextBox
            // 
            this.mobjDataTextBox.AllowDrag = false;
            this.mobjDataTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDataTextBox.Location = new System.Drawing.Point(298, 223);
            this.mobjDataTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjDataTextBox.Name = "mobjDataTextBox";
            this.mobjDataTextBox.Size = new System.Drawing.Size(200, 24);
            this.mobjDataTextBox.TabIndex = 9;
            this.mobjDataTextBox.Text = "John John";
            this.mobjDataTextBox.TextChanged += new System.EventHandler(this.mobjDataTextBox_TextChanged);
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 4;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.Controls.Add(this.mobjCollectionLabel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataLabel, 1, 9);
            this.mobjLayoutPanel.Controls.Add(this.mobjDataTextBox, 2, 9);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueMemberTextBox, 2, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueMemberLabel, 1, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueTextBox, 2, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueLabel, 1, 3);
            this.mobjLayoutPanel.Controls.Add(this.mobjNameTextBox, 2, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjNameLabel, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjPanel, 2, 1);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 11;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(590, 250);
            this.mobjLayoutPanel.TabIndex = 10;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjComboBox);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.DockPadding.Bottom = 10;
            this.mobjPanel.DockPadding.Top = 10;
            this.mobjPanel.Location = new System.Drawing.Point(295, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10);
            this.mobjPanel.Size = new System.Drawing.Size(285, 50);
            this.mobjPanel.TabIndex = 0;
            // 
            // CollectionDataSourcePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(590, 250);
            this.Text = "CollectionDataSourcePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Label mobjCollectionLabel;
        private Gizmox.WebGUI.Forms.BindingSource mobjBindingSource;
        private Gizmox.WebGUI.Forms.Label mobjValueLabel;
        private Gizmox.WebGUI.Forms.Label mobjNameLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjValueTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjNameTextBox;
        private Gizmox.WebGUI.Forms.Label mobjValueMemberLabel;
        private Gizmox.WebGUI.Forms.Label mobjDataLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjValueMemberTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjDataTextBox;
        private Gizmox.WebGUI.Forms.ErrorProvider mobjErrorProvider;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;



    }
}
