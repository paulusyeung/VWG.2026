
namespace CompanionKit.Controls.ComboBox.Features
{
    partial class CustomComboBoxPage
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
            this.mobjFormComboBox = new CompanionKit.Controls.ComboBox.Features.FormComboBox();
            this.mobjTreeViewComboBox = new CompanionKit.Controls.ComboBox.Features.TreeViewComboBox();
            this.mobjTreeViewLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFormLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjFormComboBox
            // 
            this.mobjFormComboBox.AllowDrag = false;
            this.mobjFormComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjFormComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFormComboBox.Location = new System.Drawing.Point(71, 160);
            this.mobjFormComboBox.Name = "formComboBox1";
            this.mobjFormComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjFormComboBox.TabIndex = 0;
            this.mobjFormComboBox.Text = "DropDown Form";
            // 
            // mobjTreeViewComboBox
            // 
            this.mobjTreeViewComboBox.AllowDrag = false;
            this.mobjTreeViewComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjTreeViewComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeViewComboBox.Location = new System.Drawing.Point(71, 60);
            this.mobjTreeViewComboBox.Name = "treeViewComboBox1";
            this.mobjTreeViewComboBox.SelectedItem = null;
            this.mobjTreeViewComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjTreeViewComboBox.TabIndex = 1;
            this.mobjTreeViewComboBox.Text = "Select TreeView Node";
            // 
            // mobjTreeViewLabel
            // 
            this.mobjTreeViewLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjTreeViewLabel, 3);
            this.mobjTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTreeViewLabel.Location = new System.Drawing.Point(0, 10);
            this.mobjTreeViewLabel.Name = "label1";
            this.mobjTreeViewLabel.Size = new System.Drawing.Size(342, 50);
            this.mobjTreeViewLabel.TabIndex = 2;
            this.mobjTreeViewLabel.Text = "Custom TreeView ComboBox";
            this.mobjTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjFormLabel
            // 
            this.mobjFormLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjFormLabel, 3);
            this.mobjFormLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjFormLabel.Location = new System.Drawing.Point(0, 110);
            this.mobjFormLabel.Name = "label2";
            this.mobjFormLabel.Size = new System.Drawing.Size(342, 50);
            this.mobjFormLabel.TabIndex = 3;
            this.mobjFormLabel.Text = "Custom Form ComboBox";
            this.mobjFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjFormComboBox, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjTreeViewComboBox, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjTreeViewLabel, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjFormLabel, 0, 4);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 7;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(342, 200);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // CustomComboBoxPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(342, 200);
            this.Text = "CustomComboBoxPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FormComboBox mobjFormComboBox;
        private TreeViewComboBox mobjTreeViewComboBox;
        private Gizmox.WebGUI.Forms.Label mobjTreeViewLabel;
        private Gizmox.WebGUI.Forms.Label mobjFormLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
