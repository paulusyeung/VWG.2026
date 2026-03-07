using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;

namespace CompanionKit.DeviceIntegration.Compass
{
    partial class Example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Example));
            this.compass1 = new CompanionKit.DeviceIntegration.Compass.Compass();
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjWatchCompassButton = new Gizmox.WebGUI.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // compass1
            // 
            this.compass1.CustomStyle = "CompassSkin";
            this.compass1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.compass1.Location = new System.Drawing.Point(237, 83);
            this.compass1.Name = "compass1";
            this.compass1.Size = new System.Drawing.Size(285, 329);
            this.compass1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.compass1, 1, 1);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 329F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 496);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mobjWatchCompassButton);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 55);
            this.panel1.TabIndex = 7;
            // 
            // mobjWatchCompassButton
            // 
            this.mobjWatchCompassButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWatchCompassButton.Location = new System.Drawing.Point(0, 0);
            this.mobjWatchCompassButton.Name = "mobjWatchCompassButton";
            this.mobjWatchCompassButton.Size = new System.Drawing.Size(55, 55);
            this.mobjWatchCompassButton.TabIndex = 0;
            this.mobjWatchCompassButton.Click += new System.EventHandler(this.btnWatchCompass_Click);
            this.mobjWatchCompassButton.Image = new ImageResourceHandle("Off.png");
            // 
            // Example
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(760, 551);
            this.Text = "Offline";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Compass compass1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button mobjWatchCompassButton;
    }
}