using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using System;

namespace CompanionKit.DeviceIntegration.Storage.Functionality
{
    partial class LocalStorageExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalStorageExample));
            this.mtlpLayout = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mpnlName = new Gizmox.WebGUI.Forms.Panel();
            this.mtlpName = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.tbName = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlPhone = new Gizmox.WebGUI.Forms.Panel();
            this.mtlpPhone = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.tbPhone = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlMail = new Gizmox.WebGUI.Forms.Panel();
            this.mtlpEmail = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.tbMail = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlAddress = new Gizmox.WebGUI.Forms.Panel();
            this.mtlpAddress = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.tbAddress = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlSubmit = new Gizmox.WebGUI.Forms.Panel();
            this.mtlpClear = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mbtnStore = new Gizmox.WebGUI.Forms.Button();
            this.mbtnLoad = new Gizmox.WebGUI.Forms.Button();
            this.mobjStatusPanel = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjStatusImage = new Gizmox.WebGUI.Forms.PictureBox();
            this.mtlpLayout.SuspendLayout();
            this.mpnlName.SuspendLayout();
            this.mtlpName.SuspendLayout();
            this.mpnlPhone.SuspendLayout();
            this.mtlpPhone.SuspendLayout();
            this.mpnlMail.SuspendLayout();
            this.mtlpEmail.SuspendLayout();
            this.mpnlAddress.SuspendLayout();
            this.mtlpAddress.SuspendLayout();
            this.mpnlSubmit.SuspendLayout();
            this.mtlpClear.SuspendLayout();
            this.mobjStatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjStatusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mtlpLayout
            // 
            this.mtlpLayout.ColumnCount = 1;
            this.mtlpLayout.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpLayout.Controls.Add(this.mpnlName, 0, 0);
            this.mtlpLayout.Controls.Add(this.mpnlPhone, 0, 1);
            this.mtlpLayout.Controls.Add(this.mpnlMail, 0, 2);
            this.mtlpLayout.Controls.Add(this.mpnlAddress, 0, 3);
            this.mtlpLayout.Controls.Add(this.mpnlSubmit, 0, 4);
            this.mtlpLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mtlpLayout.Location = new System.Drawing.Point(0, 84);
            this.mtlpLayout.Name = "tableLayoutPanel1";
            this.mtlpLayout.RowCount = 5;
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.Size = new System.Drawing.Size(391, 377);
            this.mtlpLayout.TabIndex = 0;
            // 
            // mpnlName
            // 
            this.mpnlName.Controls.Add(this.mtlpName);
            this.mpnlName.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlName.DockPadding.All = 20;
            this.mpnlName.Location = new System.Drawing.Point(0, 0);
            this.mpnlName.Name = "panel1";
            this.mpnlName.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlName.Size = new System.Drawing.Size(391, 75);
            this.mpnlName.TabIndex = 0;
            // 
            // mtlpName
            // 
            this.mtlpName.ColumnCount = 1;
            this.mtlpName.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpName.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mtlpName.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpName.Controls.Add(this.tbName, 0, 0);
            this.mtlpName.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpName.Location = new System.Drawing.Point(20, 20);
            this.mtlpName.Name = "tableLayoutPanel1";
            this.mtlpName.RowCount = 1;
            this.mtlpName.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpName.Size = new System.Drawing.Size(351, 35);
            this.mtlpName.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.AllowDrag = false;
            this.tbName.CustomStyle = "Watermark";
            this.tbName.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 3);
            this.tbName.Message = "Name";
            this.tbName.Name = "watermarkTextBox1";
            this.tbName.Size = new System.Drawing.Size(345, 29);
            this.tbName.TabIndex = 0;
            // 
            // mpnlPhone
            // 
            this.mpnlPhone.Controls.Add(this.mtlpPhone);
            this.mpnlPhone.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlPhone.DockPadding.All = 20;
            this.mpnlPhone.Location = new System.Drawing.Point(0, 75);
            this.mpnlPhone.Name = "panel2";
            this.mpnlPhone.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlPhone.Size = new System.Drawing.Size(391, 75);
            this.mpnlPhone.TabIndex = 0;
            // 
            // mtlpPhone
            // 
            this.mtlpPhone.ColumnCount = 1;
            this.mtlpPhone.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpPhone.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mtlpPhone.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpPhone.Controls.Add(this.tbPhone, 0, 0);
            this.mtlpPhone.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpPhone.Location = new System.Drawing.Point(20, 20);
            this.mtlpPhone.Name = "tableLayoutPanel2";
            this.mtlpPhone.RowCount = 1;
            this.mtlpPhone.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpPhone.Size = new System.Drawing.Size(351, 35);
            this.mtlpPhone.TabIndex = 1;
            // 
            // tbPhone
            // 
            this.tbPhone.AllowDrag = false;
            this.tbPhone.CustomStyle = "Watermark";
            this.tbPhone.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbPhone.Location = new System.Drawing.Point(3, 3);
            this.tbPhone.Message = "Phone #";
            this.tbPhone.Name = "watermarkTextBox2";
            this.tbPhone.Size = new System.Drawing.Size(345, 29);
            this.tbPhone.TabIndex = 0;
            // 
            // mpnlMail
            // 
            this.mpnlMail.Controls.Add(this.mtlpEmail);
            this.mpnlMail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlMail.DockPadding.All = 20;
            this.mpnlMail.Location = new System.Drawing.Point(0, 150);
            this.mpnlMail.Name = "panel3";
            this.mpnlMail.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlMail.Size = new System.Drawing.Size(391, 75);
            this.mpnlMail.TabIndex = 0;
            // 
            // mtlpEmail
            // 
            this.mtlpEmail.ColumnCount = 1;
            this.mtlpEmail.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpEmail.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mtlpEmail.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpEmail.Controls.Add(this.tbMail, 0, 0);
            this.mtlpEmail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpEmail.Location = new System.Drawing.Point(20, 20);
            this.mtlpEmail.Name = "tableLayoutPanel3";
            this.mtlpEmail.RowCount = 1;
            this.mtlpEmail.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpEmail.Size = new System.Drawing.Size(351, 35);
            this.mtlpEmail.TabIndex = 1;
            // 
            // tbMail
            // 
            this.tbMail.AllowDrag = false;
            this.tbMail.CustomStyle = "Watermark";
            this.tbMail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbMail.Location = new System.Drawing.Point(3, 3);
            this.tbMail.Message = "Email";
            this.tbMail.Name = "watermarkTextBox3";
            this.tbMail.Size = new System.Drawing.Size(345, 29);
            this.tbMail.TabIndex = 0;
            // 
            // mpnlAddress
            // 
            this.mpnlAddress.Controls.Add(this.mtlpAddress);
            this.mpnlAddress.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlAddress.DockPadding.All = 20;
            this.mpnlAddress.Location = new System.Drawing.Point(0, 225);
            this.mpnlAddress.Name = "panel4";
            this.mpnlAddress.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlAddress.Size = new System.Drawing.Size(391, 75);
            this.mpnlAddress.TabIndex = 0;
            // 
            // mtlpAddress
            // 
            this.mtlpAddress.ColumnCount = 1;
            this.mtlpAddress.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpAddress.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mtlpAddress.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpAddress.Controls.Add(this.tbAddress, 0, 0);
            this.mtlpAddress.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpAddress.Location = new System.Drawing.Point(20, 20);
            this.mtlpAddress.Name = "tableLayoutPanel4";
            this.mtlpAddress.RowCount = 1;
            this.mtlpAddress.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpAddress.Size = new System.Drawing.Size(351, 35);
            this.mtlpAddress.TabIndex = 1;
            // 
            // tbAddress
            // 
            this.tbAddress.AllowDrag = false;
            this.tbAddress.CustomStyle = "Watermark";
            this.tbAddress.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbAddress.Location = new System.Drawing.Point(3, 3);
            this.tbAddress.Message = "Address";
            this.tbAddress.Name = "watermarkTextBox4";
            this.tbAddress.Size = new System.Drawing.Size(345, 29);
            this.tbAddress.TabIndex = 0;
            // 
            // mpnlSubmit
            // 
            this.mpnlSubmit.Controls.Add(this.mtlpClear);
            this.mpnlSubmit.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlSubmit.DockPadding.All = 20;
            this.mpnlSubmit.Location = new System.Drawing.Point(0, 300);
            this.mpnlSubmit.Name = "panel5";
            this.mpnlSubmit.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlSubmit.Size = new System.Drawing.Size(391, 77);
            this.mpnlSubmit.TabIndex = 0;
            // 
            // mtlpClear
            // 
            this.mtlpClear.ColumnCount = 3;
            this.mtlpClear.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpClear.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mtlpClear.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mtlpClear.Controls.Add(this.mbtnStore, 0, 0);
            this.mtlpClear.Controls.Add(this.mbtnLoad, 2, 0);
            this.mtlpClear.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mtlpClear.Location = new System.Drawing.Point(20, 20);
            this.mtlpClear.Name = "tableLayoutPanel5";
            this.mtlpClear.RowCount = 1;
            this.mtlpClear.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mtlpClear.Size = new System.Drawing.Size(351, 37);
            this.mtlpClear.TabIndex = 1;
            // 
            // mbtnStore
            // 
            this.mbtnStore.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mbtnStore.Location = new System.Drawing.Point(0, 0);
            this.mbtnStore.Name = "button1";
            this.mbtnStore.Size = new System.Drawing.Size(165, 37);
            this.mbtnStore.TabIndex = 0;
            this.mbtnStore.Text = "Save";
            // 
            // mbtnLoad
            // 
            this.mbtnLoad.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mbtnLoad.Location = new System.Drawing.Point(185, 0);
            this.mbtnLoad.Name = "button5";
            this.mbtnLoad.Size = new System.Drawing.Size(166, 37);
            this.mbtnLoad.TabIndex = 0;
            this.mbtnLoad.Text = "Load";
            this.mbtnLoad.Click += new EventHandler(mbtnLoad_Click);
            // 
            // mobjStatusPanel
            // 
            this.mobjStatusPanel.Controls.Add(this.label1);
            this.mobjStatusPanel.Controls.Add(this.mobjStatusImage);
            this.mobjStatusPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjStatusPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjStatusPanel.Name = "mobjStatusPanel";
            this.mobjStatusPanel.Size = new System.Drawing.Size(391, 41);
            this.mobjStatusPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Load the saved data after application restart. ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjStatusImage
            // 
            this.mobjStatusImage.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjStatusImage.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjStatusImage.Image"));
            this.mobjStatusImage.Location = new System.Drawing.Point(0, 0);
            this.mobjStatusImage.Name = "mobjStatusImage";
            this.mobjStatusImage.Size = new System.Drawing.Size(20, 41);
            this.mobjStatusImage.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage;
            this.mobjStatusImage.TabIndex = 0;
            this.mobjStatusImage.TabStop = false;
            // 
            // LocalStorageExample
            // 
            this.Controls.Add(this.mobjStatusPanel);
            this.Controls.Add(this.mtlpLayout);
            this.Size = new System.Drawing.Size(391, 461);
            this.mtlpLayout.ResumeLayout(false);
            this.mpnlName.ResumeLayout(false);
            this.mtlpName.ResumeLayout(false);
            this.mpnlPhone.ResumeLayout(false);
            this.mtlpPhone.ResumeLayout(false);
            this.mpnlMail.ResumeLayout(false);
            this.mtlpEmail.ResumeLayout(false);
            this.mpnlAddress.ResumeLayout(false);
            this.mtlpAddress.ResumeLayout(false);
            this.mpnlSubmit.ResumeLayout(false);
            this.mtlpClear.ResumeLayout(false);
            this.mobjStatusPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjStatusImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mtlpLayout;
        private Panel mpnlName;
        private Panel mpnlPhone;
        private WatermarkTextBox tbName;
        private WatermarkTextBox tbPhone;
        private Panel mpnlMail;
        private WatermarkTextBox tbMail;
        private Panel mpnlAddress;
        private WatermarkTextBox tbAddress;
        private Panel mpnlSubmit;
        private Button mbtnStore;
        private TableLayoutPanel mtlpName;
        private TableLayoutPanel mtlpPhone;
        private TableLayoutPanel mtlpEmail;
        private TableLayoutPanel mtlpAddress;
        private TableLayoutPanel mtlpClear;
        private Button mbtnLoad;
        private Panel mobjStatusPanel;
        private PictureBox mobjStatusImage;
        private Label label1;




    }
}