using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.ListView.PopulatingData
{
    partial class BindingDataCollectionPage
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
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.columnID = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnFirstName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnLastName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnFullName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.columnFavoriteColor = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.bindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(600, 57);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "ListView with a collection DataSource:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjListView
            // 
            this.mobjListView.AutoGenerateColumns = false;
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnID,
            this.columnFirstName,
            this.columnLastName,
            this.columnFullName,
            this.columnFavoriteColor});
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(5, 62);
            this.mobjListView.Margin = new Gizmox.WebGUI.Forms.Padding(5);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(590, 318);
            this.mobjListView.TabIndex = 1;
            this.mobjListView.TotalItems = 1;
            // 
            // columnID
            // 
            this.columnID.Tag = "ID";
            this.columnID.Text = "ID";
            this.columnID.Width = 64;
            // 
            // columnFirstName
            // 
            this.columnFirstName.Tag = "FirstName";
            this.columnFirstName.Text = "First Name";
            this.columnFirstName.Width = 100;
            // 
            // columnLastName
            // 
            this.columnLastName.Tag = "LastName";
            this.columnLastName.Text = "Last Name";
            this.columnLastName.Width = 100;
            // 
            // columnFullName
            // 
            this.columnFullName.Tag = "FullName";
            this.columnFullName.Text = "Full Name";
            this.columnFullName.Width = 100;
            // 
            // columnFavoriteColor
            // 
            this.columnFavoriteColor.Tag = "FavoriteColor";
            this.columnFavoriteColor.Text = "Favorite Color";
            this.columnFavoriteColor.Width = 100;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer);
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjListView, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85F));
            this.mobjTLP.Size = new System.Drawing.Size(600, 385);
            this.mobjTLP.TabIndex = 2;
            // 
            // BindingDataCollectionPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "BindingDataCollectionPage";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.BindingSource bindingSource1;
        private Gizmox.WebGUI.Forms.ColumnHeader columnID;
        private Gizmox.WebGUI.Forms.ColumnHeader columnFirstName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnLastName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnFullName;
        private Gizmox.WebGUI.Forms.ColumnHeader columnFavoriteColor;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}
