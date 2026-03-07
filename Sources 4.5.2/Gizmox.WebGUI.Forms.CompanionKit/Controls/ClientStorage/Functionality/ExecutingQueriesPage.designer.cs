using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ClientStorage.Functionality
{
    partial class ExecutingQueriesPage
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
            this.mobjClientStorage = new Gizmox.WebGUI.Forms.Client.ClientStorage();
            this.mobjClientTable = new Gizmox.WebGUI.Forms.Client.ClientTable();
            this.mobjIdClientTableColumn = new Gizmox.WebGUI.Forms.Client.ClientTableColumn("Id", Gizmox.WebGUI.Forms.Client.ClientStorageDataType.Integer, "", true, true, true);
            this.mobjUsersClientTableColumn = new Gizmox.WebGUI.Forms.Client.ClientTableColumn("Users", Gizmox.WebGUI.Forms.Client.ClientStorageDataType.Text, "", false, false, false);
            this.mobjCommonLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjIdColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjUsersColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjTopLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCheckBoxList = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.mobjQueryTypeLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjRadioButtonDelete = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButtonInsert = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButtonSelect = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjQueryTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjRunButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjBottomLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInitButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjCommonLayoutPanel.SuspendLayout();
            this.mobjTopLayoutPanel.SuspendLayout();
            this.mobjQueryTypeLayoutPanel.SuspendLayout();
            this.mobjBottomLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjClientStorage
            // 
            this.mobjClientStorage.Description = "";
            this.mobjClientStorage.MajorVersion = ((ushort)(1));
            this.mobjClientStorage.MinorVersion = ((ushort)(0));
            this.mobjClientStorage.Name = "objClientStorage";
            this.mobjClientStorage.Tables.Add(this.mobjClientTable);
            // 
            // mobjClientTable
            // 
            this.mobjClientTable.Columns.Add(this.mobjIdClientTableColumn);
            this.mobjClientTable.Columns.Add(this.mobjUsersClientTableColumn);
            this.mobjClientTable.Name = "objClientTable";
            // 
            // mobjCommonLayoutPanel
            // 
            this.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjCommonLayoutPanel.ColumnCount = 1;
            this.mobjCommonLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjListView, 0, 2);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjTopLayoutPanel, 0, 0);
            this.mobjCommonLayoutPanel.Controls.Add(this.mobjQueryTextBox, 0, 1);
            this.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCommonLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.mobjCommonLayoutPanel.Name = "objCommonLayoutPanel";
            this.mobjCommonLayoutPanel.RowCount = 3;
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 170F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjCommonLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjCommonLayoutPanel.Size = new System.Drawing.Size(917, 335);
            this.mobjCommonLayoutPanel.TabIndex = 0;
            // 
            // mobjListView
            // 
            this.mobjListView.ClientId = "listView";
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjIdColumn,
            this.mobjUsersColumn});
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(0, 210);
            this.mobjListView.Name = "objListView";
            this.mobjListView.Size = new System.Drawing.Size(348, 255);
            this.mobjListView.TabIndex = 0;
            // 
            // mobjIdColumn
            // 
            this.mobjIdColumn.ClientId = "Id";
            this.mobjIdColumn.Text = "Id";
            this.mobjIdColumn.Width = 150;
            // 
            // mobjUsersColumn
            // 
            this.mobjUsersColumn.ClientId = "Users";
            this.mobjUsersColumn.Text = "Users";
            this.mobjUsersColumn.Width = 150;
            // 
            // mobjTopLayoutPanel
            // 
            this.mobjTopLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTopLayoutPanel.ColumnCount = 1;
            this.mobjTopLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTopLayoutPanel.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjCheckBoxList, 0, 1);
            this.mobjTopLayoutPanel.Controls.Add(this.mobjQueryTypeLayoutPanel, 0, 2);
            this.mobjTopLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjTopLayoutPanel.Name = "objTopLayoutPanel";
            this.mobjTopLayoutPanel.RowCount = 3;
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTopLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjTopLayoutPanel.Size = new System.Drawing.Size(348, 170);
            this.mobjTopLayoutPanel.TabIndex = 0;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "objInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(348, 50);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Note: This sample works only in WebKit";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjCheckBoxList
            // 
            this.mobjCheckBoxList.CheckOnClick = true;
            this.mobjCheckBoxList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCheckBoxList.Items.AddRange(new object[] {
            "Id",
            "Users"});
            this.mobjCheckBoxList.Location = new System.Drawing.Point(0, 50);
            this.mobjCheckBoxList.Name = "objCheckBoxList";
            this.mobjCheckBoxList.Size = new System.Drawing.Size(348, 68);
            this.mobjCheckBoxList.TabIndex = 0;
            this.mobjCheckBoxList.ItemCheck += new Gizmox.WebGUI.Forms.ItemCheckHandler(this.mobjCheckBoxList_ItemCheck);
            // 
            // mobjQueryTypeLayoutPanel
            // 
            this.mobjQueryTypeLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjQueryTypeLayoutPanel.ColumnCount = 3;
            this.mobjQueryTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjQueryTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjQueryTypeLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjQueryTypeLayoutPanel.Controls.Add(this.mobjRadioButtonDelete, 2, 0);
            this.mobjQueryTypeLayoutPanel.Controls.Add(this.mobjRadioButtonInsert, 1, 0);
            this.mobjQueryTypeLayoutPanel.Controls.Add(this.mobjRadioButtonSelect, 0, 0);
            this.mobjQueryTypeLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjQueryTypeLayoutPanel.Location = new System.Drawing.Point(0, 120);
            this.mobjQueryTypeLayoutPanel.Name = "objQueryTypeLayoutPanel";
            this.mobjQueryTypeLayoutPanel.RowCount = 1;
            this.mobjQueryTypeLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjQueryTypeLayoutPanel.Size = new System.Drawing.Size(348, 50);
            this.mobjQueryTypeLayoutPanel.TabIndex = 0;
            this.mobjQueryTypeLayoutPanel.TabStop = false;
            this.mobjQueryTypeLayoutPanel.Text = "Query Type";
            // 
            // mobjRadioButtonDelete
            // 
            this.mobjRadioButtonDelete.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjRadioButtonDelete.AutoSize = true;
            this.mobjRadioButtonDelete.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRadioButtonDelete.Location = new System.Drawing.Point(610, 0);
            this.mobjRadioButtonDelete.Name = "objRadioButtonDelete";
            this.mobjRadioButtonDelete.Size = new System.Drawing.Size(116, 50);
            this.mobjRadioButtonDelete.TabIndex = 2;
            this.mobjRadioButtonDelete.Text = "DELETE";
            this.mobjRadioButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRadioButtonDelete.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjRadioButtonInsert
            // 
            this.mobjRadioButtonInsert.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjRadioButtonInsert.AutoSize = true;
            this.mobjRadioButtonInsert.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRadioButtonInsert.Location = new System.Drawing.Point(305, 0);
            this.mobjRadioButtonInsert.Name = "objRadioButtonInsert";
            this.mobjRadioButtonInsert.Size = new System.Drawing.Size(116, 50);
            this.mobjRadioButtonInsert.TabIndex = 1;
            this.mobjRadioButtonInsert.Text = "INSERT";
            this.mobjRadioButtonInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRadioButtonInsert.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjRadioButtonSelect
            // 
            this.mobjRadioButtonSelect.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjRadioButtonSelect.AutoSize = true;
            this.mobjRadioButtonSelect.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRadioButtonSelect.Location = new System.Drawing.Point(3, 17);
            this.mobjRadioButtonSelect.Name = "objRadioButtonSelect";
            this.mobjRadioButtonSelect.Size = new System.Drawing.Size(116, 50);
            this.mobjRadioButtonSelect.TabIndex = 0;
            this.mobjRadioButtonSelect.Text = "SELECT";
            this.mobjRadioButtonSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRadioButtonSelect.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // mobjQueryTextBox
            // 
            this.mobjQueryTextBox.AllowDrag = false;
            this.mobjQueryTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjQueryTextBox.Location = new System.Drawing.Point(3, 173);
            this.mobjQueryTextBox.Multiline = true;
            this.mobjQueryTextBox.Name = "objQueryTextBox";
            this.mobjQueryTextBox.Size = new System.Drawing.Size(342, 34);
            this.mobjQueryTextBox.TabIndex = 0;
            // 
            // mobjRunButton
            // 
            this.mobjRunButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRunButton.Location = new System.Drawing.Point(0, 0);
            this.mobjRunButton.Name = "objRunButton";
            this.mobjRunButton.Size = new System.Drawing.Size(458, 54);
            this.mobjRunButton.TabIndex = 0;
            this.mobjRunButton.Text = "Run Query";
            this.mobjRunButton.Click += new System.EventHandler(this.mobjRunButton_Click);
            // 
            // mobjBottomLayoutPanel
            // 
            this.mobjBottomLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjBottomLayoutPanel.ColumnCount = 2;
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjBottomLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjInitButton, 1, 0);
            this.mobjBottomLayoutPanel.Controls.Add(this.mobjRunButton, 0, 0);
            this.mobjBottomLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjBottomLayoutPanel.Location = new System.Drawing.Point(15, 480);
            this.mobjBottomLayoutPanel.Name = "objBottomLayoutPanel";
            this.mobjBottomLayoutPanel.RowCount = 1;
            this.mobjBottomLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjBottomLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjBottomLayoutPanel.Size = new System.Drawing.Size(917, 54);
            this.mobjBottomLayoutPanel.TabIndex = 1;
            // 
            // mobjInitButton
            // 
            this.mobjInitButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInitButton.Location = new System.Drawing.Point(458, 0);
            this.mobjInitButton.Name = "objInitButton";
            this.mobjInitButton.Size = new System.Drawing.Size(459, 54);
            this.mobjInitButton.TabIndex = 0;
            this.mobjInitButton.Text = "Init Database";
            this.mobjInitButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjInitButton_ClientClick);
            // 
            // ExecutingQueriesPage
            // 
            this.Controls.Add(this.mobjCommonLayoutPanel);
            this.Controls.Add(this.mobjBottomLayoutPanel);
            this.DockPadding.All = 15;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(15);
            this.Size = new System.Drawing.Size(378, 549);
            this.Text = "SQLExample";
            this.Load += new System.EventHandler(this.ExecutingQueriesPage_Load);
            this.mobjCommonLayoutPanel.ResumeLayout(false);
            this.mobjTopLayoutPanel.ResumeLayout(false);
            this.mobjQueryTypeLayoutPanel.ResumeLayout(false);
            this.mobjBottomLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Client.ClientStorage mobjClientStorage;
        private Gizmox.WebGUI.Forms.Client.ClientTable mobjClientTable;
        private Gizmox.WebGUI.Forms.Client.ClientTableColumn mobjIdClientTableColumn;
        private Gizmox.WebGUI.Forms.Client.ClientTableColumn mobjUsersClientTableColumn;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjCommonLayoutPanel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTopLayoutPanel;
        private Gizmox.WebGUI.Forms.CheckedListBox mobjCheckBoxList;
        private Gizmox.WebGUI.Forms.TextBox mobjQueryTextBox;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjQueryTypeLayoutPanel;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButtonDelete;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButtonInsert;
        private Gizmox.WebGUI.Forms.RadioButton mobjRadioButtonSelect;
        private Gizmox.WebGUI.Forms.Button mobjRunButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjBottomLayoutPanel;
        private Gizmox.WebGUI.Forms.Button mobjInitButton;
        private ColumnHeader mobjIdColumn;
        private ColumnHeader mobjUsersColumn;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;


    }
}