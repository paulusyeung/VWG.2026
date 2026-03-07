using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Storage.Functionality
{
    partial class SQLExample
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
            this.mtlpLayout = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mtlpControls = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjFieldsSet = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.mtlpQueryType = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mrbDelete = new Gizmox.WebGUI.Forms.RadioButton();
            this.mrbInsert = new Gizmox.WebGUI.Forms.RadioButton();
            this.mrbSelect = new Gizmox.WebGUI.Forms.RadioButton();
            this.mlsvData = new Gizmox.WebGUI.Forms.ListView();
            this.columnHeader1 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnHeader2 = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mtxtQuery = new Gizmox.WebGUI.Forms.TextBox();
            this.mbtnRun = new Gizmox.WebGUI.Forms.Button();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.mtlpLayout.SuspendLayout();
            this.mtlpControls.SuspendLayout();
            this.mtlpQueryType.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtlpLayout
            // 
            this.mtlpLayout.ColumnCount = 1;
            this.mtlpLayout.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpLayout.Controls.Add(this.mtlpControls, 0, 0);
            this.mtlpLayout.Controls.Add(this.mlsvData, 0, 2);
            this.mtlpLayout.Controls.Add(this.mtxtQuery, 0, 1);
            this.mtlpLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpLayout.Location = new System.Drawing.Point(0, 0);
            this.mtlpLayout.Name = "tableLayoutPanel1";
            this.mtlpLayout.RowCount = 3;
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 100F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpLayout.Size = new System.Drawing.Size(378, 549);
            this.mtlpLayout.TabIndex = 0;
            // 
            // mtlpControls
            // 
            this.mtlpControls.ColumnCount = 1;
            this.mtlpControls.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpControls.Controls.Add(this.mobjFieldsSet, 0, 0);
            this.mtlpControls.Controls.Add(this.mtlpQueryType, 0, 1);
            this.mtlpControls.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpControls.Location = new System.Drawing.Point(0, 0);
            this.mtlpControls.Name = "tableLayoutPanel2";
            this.mtlpControls.RowCount = 1;
            this.mtlpControls.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mtlpControls.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40F));
            this.mtlpControls.Size = new System.Drawing.Size(378, 100);
            this.mtlpControls.TabIndex = 0;
            // 
            // mclbFields
            // 
            this.mobjFieldsSet.CheckOnClick = true;
            this.mobjFieldsSet.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFieldsSet.Items.AddRange(new object[] {
            "ID",
            "Name"});
            this.mobjFieldsSet.Location = new System.Drawing.Point(189, 0);
            this.mobjFieldsSet.Name = "checkedListBox1";
            this.mobjFieldsSet.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.mobjFieldsSet.Size = new System.Drawing.Size(378, 52);
            this.mobjFieldsSet.TabIndex = 0;
            this.mobjFieldsSet.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.OnFieldSetChanged);
            // 
            // mtlpQueryType
            // 
            this.mtlpQueryType.ColumnCount = 3;
            this.mtlpQueryType.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mtlpQueryType.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mtlpQueryType.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mtlpQueryType.Controls.Add(this.mrbDelete, 2, 0);
            this.mtlpQueryType.Controls.Add(this.mrbInsert, 1, 0);
            this.mtlpQueryType.Controls.Add(this.mrbSelect, 0, 0);
            this.mtlpQueryType.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpQueryType.Location = new System.Drawing.Point(0, 60);
            this.mtlpQueryType.Name = "groupBox1";
            this.mtlpQueryType.RowCount = 1;
            this.mtlpQueryType.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpQueryType.Size = new System.Drawing.Size(378, 40);
            this.mtlpQueryType.TabIndex = 0;
            this.mtlpQueryType.TabStop = false;
            this.mtlpQueryType.Text = "Query Type";
            // 
            // mrbDelete
            // 
            this.mrbDelete.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mrbDelete.AutoSize = true;
            this.mrbDelete.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mrbDelete.Location = new System.Drawing.Point(250, 0);
            this.mrbDelete.Name = "radioButton3";
            this.mrbDelete.Size = new System.Drawing.Size(128, 40);
            this.mrbDelete.TabIndex = 2;
            this.mrbDelete.Text = "DELETE";
            this.mrbDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mrbDelete.CheckedChanged += new System.EventHandler(this.OnQueryTypeChanged);
            // 
            // mrbInsert
            // 
            this.mrbInsert.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mrbInsert.AutoSize = true;
            this.mrbInsert.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mrbInsert.Location = new System.Drawing.Point(125, 0);
            this.mrbInsert.Name = "radioButton2";
            this.mrbInsert.Size = new System.Drawing.Size(125, 40);
            this.mrbInsert.TabIndex = 1;
            this.mrbInsert.Text = "INSERT";
            this.mrbInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mrbInsert.CheckedChanged += new System.EventHandler(this.OnQueryTypeChanged);
            // 
            // mrbSelect
            // 
            this.mrbSelect.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mrbSelect.AutoSize = true;
            this.mrbSelect.Checked = true;
            this.mrbSelect.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mrbSelect.Location = new System.Drawing.Point(3, 17);
            this.mrbSelect.Name = "radioButton1";
            this.mrbSelect.Size = new System.Drawing.Size(125, 40);
            this.mrbSelect.TabIndex = 0;
            this.mrbSelect.Text = "SELECT";
            this.mrbSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mrbSelect.CheckedChanged += new System.EventHandler(this.OnQueryTypeChanged);
            // 
            // mlsvData
            // 
            this.mlsvData.AutoGenerateColumns = true;
            this.mlsvData.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.mlsvData.DataMember = null;
            this.mlsvData.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mlsvData.ItemsPerPage = 20;
            this.mlsvData.Location = new System.Drawing.Point(0, 160);
            this.mlsvData.Name = "listView1";
            this.mlsvData.ShowItemToolTips = false;
            this.mlsvData.Size = new System.Drawing.Size(378, 389);
            this.mlsvData.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.ClientId = "ID";
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.ClientId = "Name";
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 150;
            // 
            // mtxtQuery
            // 
            this.mtxtQuery.AllowDrag = false;
            this.mtxtQuery.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtxtQuery.Location = new System.Drawing.Point(3, 103);
            this.mtxtQuery.Multiline = true;
            this.mtxtQuery.Name = "textBox1";
            this.mtxtQuery.Size = new System.Drawing.Size(372, 54);
            this.mtxtQuery.TabIndex = 0;
            // 
            // mbtnRun
            // 
            this.mbtnRun.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mbtnRun.Location = new System.Drawing.Point(0, 0);
            this.mbtnRun.Name = "mbtnRun";
            this.mbtnRun.Size = new System.Drawing.Size(189, 54);
            this.mbtnRun.TabIndex = 0;
            this.mbtnRun.Text = "Run Query";
            this.mbtnRun.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mbtnRun_ClientClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mbtnRun, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 495);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 54);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(189, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Init Database";
            this.button1.Click += new System.EventHandler(this.PopulateDBTable);
            // 
            // SQLExample
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mtlpLayout);
            this.Size = new System.Drawing.Size(378, 549);
            this.Text = "SQLExample";
            this.mtlpLayout.ResumeLayout(false);
            this.mtlpControls.ResumeLayout(false);
            this.mtlpQueryType.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mtlpLayout;
        private TableLayoutPanel mtlpControls;
        private CheckedListBox mobjFieldsSet;
        private TextBox mtxtQuery;
        private ListView mlsvData;
        private TableLayoutPanel mtlpQueryType;
        private RadioButton mrbDelete;
        private RadioButton mrbInsert;
        private RadioButton mrbSelect;
        private Button mbtnRun;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;


    }
}