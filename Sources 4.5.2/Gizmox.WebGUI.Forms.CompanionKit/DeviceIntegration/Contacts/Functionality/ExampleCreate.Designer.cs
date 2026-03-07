using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Contacts.Functionality
{
    partial class ExampleCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleCreate));
            this.mtlpLayout = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mpnlName = new Gizmox.WebGUI.Forms.Panel();
            this.tbName = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlPhone = new Gizmox.WebGUI.Forms.Panel();
            this.tbPhone = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlMail = new Gizmox.WebGUI.Forms.Panel();
            this.tbMail = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlAddress = new Gizmox.WebGUI.Forms.Panel();
            this.tbAddress = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.mpnlSubmit = new Gizmox.WebGUI.Forms.Panel();
            this.btnCreate = new Gizmox.WebGUI.Forms.Button();
            this.mobjStatusPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjStatusLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjStatusImage = new Gizmox.WebGUI.Forms.PictureBox();
            this.mtlpLayout.SuspendLayout();
            this.mpnlName.SuspendLayout();
            this.mpnlPhone.SuspendLayout();
            this.mpnlMail.SuspendLayout();
            this.mpnlAddress.SuspendLayout();
            this.mpnlSubmit.SuspendLayout();
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
            this.mtlpLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mtlpLayout.Location = new System.Drawing.Point(0, 0);
            this.mtlpLayout.Name = "tableLayoutPanel1";
            this.mtlpLayout.RowCount = 5;
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mtlpLayout.Size = new System.Drawing.Size(374, 390);
            this.mtlpLayout.TabIndex = 0;
            // 
            // mpnlName
            // 
            this.mpnlName.Controls.Add(this.tbName);
            this.mpnlName.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlName.DockPadding.All = 20;
            this.mpnlName.Location = new System.Drawing.Point(0, 0);
            this.mpnlName.Name = "panel1";
            this.mpnlName.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlName.Size = new System.Drawing.Size(374, 92);
            this.mpnlName.TabIndex = 0;
            // 
            // tbName
            // 
            this.tbName.AllowDrag = false;
            this.tbName.CustomStyle = "Watermark";
            this.tbName.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(20, 20);
            this.tbName.Message = "Name";
            this.tbName.Name = "watermarkTextBox1";
            this.tbName.Size = new System.Drawing.Size(334, 52);
            this.tbName.TabIndex = 0;
            // 
            // mpnlPhone
            // 
            this.mpnlPhone.Controls.Add(this.tbPhone);
            this.mpnlPhone.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlPhone.DockPadding.All = 20;
            this.mpnlPhone.Location = new System.Drawing.Point(0, 92);
            this.mpnlPhone.Name = "panel2";
            this.mpnlPhone.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlPhone.Size = new System.Drawing.Size(374, 92);
            this.mpnlPhone.TabIndex = 0;
            // 
            // tbPhone
            // 
            this.tbPhone.AllowDrag = false;
            this.tbPhone.CustomStyle = "Watermark";
            this.tbPhone.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbPhone.Location = new System.Drawing.Point(20, 20);
            this.tbPhone.Message = "Phone Number";
            this.tbPhone.Name = "watermarkTextBox2";
            this.tbPhone.Size = new System.Drawing.Size(334, 52);
            this.tbPhone.TabIndex = 0;
            // 
            // mpnlMail
            // 
            this.mpnlMail.Controls.Add(this.tbMail);
            this.mpnlMail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlMail.DockPadding.All = 20;
            this.mpnlMail.Location = new System.Drawing.Point(0, 184);
            this.mpnlMail.Name = "panel3";
            this.mpnlMail.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlMail.Size = new System.Drawing.Size(374, 92);
            this.mpnlMail.TabIndex = 0;
            // 
            // tbMail
            // 
            this.tbMail.AllowDrag = false;
            this.tbMail.CustomStyle = "Watermark";
            this.tbMail.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbMail.Location = new System.Drawing.Point(20, 20);
            this.tbMail.Message = "Email";
            this.tbMail.Name = "watermarkTextBox3";
            this.tbMail.Size = new System.Drawing.Size(334, 52);
            this.tbMail.TabIndex = 0;
            // 
            // mpnlAddress
            // 
            this.mpnlAddress.Controls.Add(this.tbAddress);
            this.mpnlAddress.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlAddress.DockPadding.All = 20;
            this.mpnlAddress.Location = new System.Drawing.Point(0, 276);
            this.mpnlAddress.Name = "panel4";
            this.mpnlAddress.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlAddress.Size = new System.Drawing.Size(374, 92);
            this.mpnlAddress.TabIndex = 0;
            // 
            // tbAddress
            // 
            this.tbAddress.AllowDrag = false;
            this.tbAddress.CustomStyle = "Watermark";
            this.tbAddress.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tbAddress.Location = new System.Drawing.Point(20, 20);
            this.tbAddress.Message = "Address";
            this.tbAddress.Name = "watermarkTextBox4";
            this.tbAddress.Size = new System.Drawing.Size(334, 52);
            this.tbAddress.TabIndex = 0;
            // 
            // mpnlSubmit
            // 
            this.mpnlSubmit.Controls.Add(this.btnCreate);
            this.mpnlSubmit.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mpnlSubmit.DockPadding.All = 20;
            this.mpnlSubmit.Location = new System.Drawing.Point(0, 368);
            this.mpnlSubmit.Name = "panel5";
            this.mpnlSubmit.Padding = new Gizmox.WebGUI.Forms.Padding(20);
            this.mpnlSubmit.Size = new System.Drawing.Size(374, 93);
            this.mpnlSubmit.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.btnCreate.Location = new System.Drawing.Point(20, 20);
            this.btnCreate.Name = "button1";
            this.btnCreate.Size = new System.Drawing.Size(334, 53);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Contact";
            // 
            // mobjStatusPanel
            // 
            this.mobjStatusPanel.Controls.Add(this.mobjStatusLabel);
            this.mobjStatusPanel.Controls.Add(this.mobjStatusImage);
            this.mobjStatusPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjStatusPanel.Location = new System.Drawing.Point(378, 20);
            this.mobjStatusPanel.Name = "mobjStatusPanel";
            this.mobjStatusPanel.Size = new System.Drawing.Size(374, 30);
            this.mobjStatusPanel.TabIndex = 1;
            // 
            // mobjStatusLabel
            // 
            this.mobjStatusLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjStatusLabel.Location = new System.Drawing.Point(20, 0);
            this.mobjStatusLabel.Name = "mobjStatusLabel";
            this.mobjStatusLabel.Size = new System.Drawing.Size(354, 30);
            this.mobjStatusLabel.TabIndex = 1;
            this.mobjStatusLabel.Text = "Enter new contact details";
            this.mobjStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjStatusImage
            // 
            this.mobjStatusImage.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjStatusImage.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjStatusImage.Image"));
            this.mobjStatusImage.Location = new System.Drawing.Point(0, 0);
            this.mobjStatusImage.Name = "mobjStatusImage";
            this.mobjStatusImage.Size = new System.Drawing.Size(20, 20);
            this.mobjStatusImage.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage;
            this.mobjStatusImage.TabIndex = 0;
            this.mobjStatusImage.TabStop = false;
            // 
            // ExampleCreate
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.mtlpLayout);
            this.Controls.Add(this.mobjStatusPanel);
            this.Size = new System.Drawing.Size(391, 461);
            this.Text = "ExampleFind";
            this.Load += new System.EventHandler(this.ExampleCreate_Load);
            this.mtlpLayout.ResumeLayout(false);
            this.mpnlName.ResumeLayout(false);
            this.mpnlPhone.ResumeLayout(false);
            this.mpnlMail.ResumeLayout(false);
            this.mpnlAddress.ResumeLayout(false);
            this.mpnlSubmit.ResumeLayout(false);
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
        private Button btnCreate;
        private Panel mobjStatusPanel;
        private PictureBox mobjStatusImage;
        private Label mobjStatusLabel;




    }
}