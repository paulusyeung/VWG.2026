using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    partial class ExampleConnectivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleConnectivity));
            this.mobjLayout = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjConnectivityStatePictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjConnectivityStatePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mobjLayout
            // 
            this.mobjLayout.ColumnCount = 3;
            this.mobjLayout.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayout.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 256F));
            this.mobjLayout.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayout.Controls.Add(this.mobjConnectivityStatePictureBox, 1, 1);
            this.mobjLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayout.Location = new System.Drawing.Point(0, 0);
            this.mobjLayout.Name = "tableLayoutPanel1";
            this.mobjLayout.RowCount = 3;
            this.mobjLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 256F));
            this.mobjLayout.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayout.Size = new System.Drawing.Size(391, 289);
            this.mobjLayout.TabIndex = 0;
            // 
            // mobjConnectivityStatePictureBox
            // 
            this.mobjConnectivityStatePictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjConnectivityStatePictureBox.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjConnectivityStatePictureBox.Image"));
            this.mobjConnectivityStatePictureBox.Location = new System.Drawing.Point(67, 16);
            this.mobjConnectivityStatePictureBox.Name = "pictureBox1";
            this.mobjConnectivityStatePictureBox.Size = new System.Drawing.Size(256, 256);
            this.mobjConnectivityStatePictureBox.TabIndex = 0;
            this.mobjConnectivityStatePictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(0, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Some devices may no support Offline/Online events";
            // 
            // ExampleConnectivity
            // 
            this.Controls.Add(this.mobjLayout);
            this.Controls.Add(this.label1);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ExampleConnectivity";
            this.mobjLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjConnectivityStatePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mobjLayout;
        private PictureBox mobjConnectivityStatePictureBox;
        private Label label1;


    }
}