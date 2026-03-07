using System.IO;
using System.Web;
namespace CompanionKit.Controls.ComboBox.Appearance
{
    partial class TextWithImagePage
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
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjImageMemberLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjValueMemberLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDisplayMemberLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjImageMemberTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjValueMemberTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDisplayMemberTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjBindingSource
            // 
            this.mobjBindingSource.DataSource = typeof(System.Collections.Generic.List<Gizmox.WebGUI.Forms.CompanionKit.Controls.Util.Customer>);
            // 
            // mobjImageMemberLabel
            // 
            this.mobjImageMemberLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjImageMemberLabel, 3);
            this.mobjImageMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjImageMemberLabel.Location = new System.Drawing.Point(0, 256);
            this.mobjImageMemberLabel.Name = "mobjImageMemberLabel";
            this.mobjImageMemberLabel.Size = new System.Drawing.Size(337, 40);
            this.mobjImageMemberLabel.TabIndex = 7;
            this.mobjImageMemberLabel.Text = "ImageMember";
            this.mobjImageMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjValueMemberLabel
            // 
            this.mobjValueMemberLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjValueMemberLabel, 3);
            this.mobjValueMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueMemberLabel.Location = new System.Drawing.Point(0, 176);
            this.mobjValueMemberLabel.Name = "mobjValueMemberLabel";
            this.mobjValueMemberLabel.Size = new System.Drawing.Size(337, 40);
            this.mobjValueMemberLabel.TabIndex = 6;
            this.mobjValueMemberLabel.Text = "ValueMember";
            this.mobjValueMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjDisplayMemberLabel
            // 
            this.mobjDisplayMemberLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjDisplayMemberLabel, 3);
            this.mobjDisplayMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDisplayMemberLabel.Location = new System.Drawing.Point(0, 96);
            this.mobjDisplayMemberLabel.Name = "mobjDisplayMemberLabel";
            this.mobjDisplayMemberLabel.Size = new System.Drawing.Size(337, 40);
            this.mobjDisplayMemberLabel.TabIndex = 5;
            this.mobjDisplayMemberLabel.Text = "DisplayMember";
            this.mobjDisplayMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjImageMemberTextBox
            // 
            this.mobjImageMemberTextBox.AllowDrag = false;
            this.mobjImageMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjImageMemberTextBox.Location = new System.Drawing.Point(71, 299);
            this.mobjImageMemberTextBox.Name = "mobjImageMemberTextBox";
            this.mobjImageMemberTextBox.Size = new System.Drawing.Size(194, 24);
            this.mobjImageMemberTextBox.TabIndex = 4;
            this.mobjImageMemberTextBox.Text = "Foto";
            this.mobjImageMemberTextBox.TextChanged += new System.EventHandler(this.mobjImageMemberTextBox_TextChanged);
            // 
            // mobjValueMemberTextBox
            // 
            this.mobjValueMemberTextBox.AllowDrag = false;
            this.mobjValueMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjValueMemberTextBox.Location = new System.Drawing.Point(71, 219);
            this.mobjValueMemberTextBox.Name = "mobjValueMemberTextBox";
            this.mobjValueMemberTextBox.Size = new System.Drawing.Size(194, 24);
            this.mobjValueMemberTextBox.TabIndex = 3;
            this.mobjValueMemberTextBox.Text = "ID";
            this.mobjValueMemberTextBox.TextChanged += new System.EventHandler(this.mobjValueMemberTextBox_TextChanged);
            // 
            // mobjDisplayMemberTextBox
            // 
            this.mobjDisplayMemberTextBox.AllowDrag = false;
            this.mobjDisplayMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjDisplayMemberTextBox.Location = new System.Drawing.Point(71, 139);
            this.mobjDisplayMemberTextBox.Name = "mobjDisplayMemberTextBox";
            this.mobjDisplayMemberTextBox.Size = new System.Drawing.Size(194, 24);
            this.mobjDisplayMemberTextBox.TabIndex = 2;
            this.mobjDisplayMemberTextBox.Text = "FullName";
            this.mobjDisplayMemberTextBox.TextChanged += new System.EventHandler(this.mobjDisplayMemberTextBox_TextChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLayoutPanel.SetColumnSpan(this.mobjLabel, 3);
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 16);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(337, 40);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "ComboBox with Image";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjComboBox.DataSource = this.mobjBindingSource;
            this.mobjComboBox.DisplayMember = "FullName";
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjComboBox.ImageMember = "Foto";
            this.mobjComboBox.Location = new System.Drawing.Point(68, 56);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 21);
            this.mobjComboBox.TabIndex = 0;
            this.mobjComboBox.ValueMember = "ID";
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjImageMemberTextBox, 1, 11);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueMemberTextBox, 1, 8);
            this.mobjLayoutPanel.Controls.Add(this.mobjDisplayMemberTextBox, 1, 5);
            this.mobjLayoutPanel.Controls.Add(this.mobjComboBox, 1, 2);
            this.mobjLayoutPanel.Controls.Add(this.mobjLabel, 0, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjDisplayMemberLabel, 0, 4);
            this.mobjLayoutPanel.Controls.Add(this.mobjValueMemberLabel, 0, 7);
            this.mobjLayoutPanel.Controls.Add(this.mobjImageMemberLabel, 0, 10);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 13;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(337, 342);
            this.mobjLayoutPanel.TabIndex = 8;
            // 
            // TextWithImagePage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(337, 342);
            this.Text = "TextWithImagePage";
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.BindingSource mobjBindingSource;
        private Gizmox.WebGUI.Forms.Label mobjImageMemberLabel;
        private Gizmox.WebGUI.Forms.Label mobjValueMemberLabel;
        private Gizmox.WebGUI.Forms.Label mobjDisplayMemberLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjImageMemberTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjValueMemberTextBox;
        private Gizmox.WebGUI.Forms.TextBox mobjDisplayMemberTextBox;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.ErrorProvider mobjErrorProvider;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}
