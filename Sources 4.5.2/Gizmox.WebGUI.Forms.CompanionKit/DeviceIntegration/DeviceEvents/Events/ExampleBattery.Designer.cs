using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.DeviceEvents.Events
{
    partial class ExampleBattery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleBattery));
            this.tableLayoutPanel1 = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjLevelLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPluggedLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjBatteryControl = new BatteryControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mobjPluggedLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.mobjLevelLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mobjBatteryControl, 1, 1);
            this.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.mobjLevelLabel.AutoSize = true;
            this.mobjLevelLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLevelLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobjLevelLabel.Location = new System.Drawing.Point(0, 131);
            this.mobjLevelLabel.Name = "label1";
            this.mobjLevelLabel.Size = new System.Drawing.Size(135, 43);
            this.mobjLevelLabel.TabIndex = 0;
            this.mobjLevelLabel.Text = "Level: --%";
            this.mobjLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.mobjPluggedLabel.AutoSize = true;
            this.mobjPluggedLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPluggedLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobjPluggedLabel.Location = new System.Drawing.Point(255, 131);
            this.mobjPluggedLabel.Name = "label2";
            this.mobjPluggedLabel.Size = new System.Drawing.Size(136, 43);
            this.mobjPluggedLabel.TabIndex = 0;
            this.mobjPluggedLabel.Text = "AC: --";
            this.mobjPluggedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // batteryControl1
            // 
            this.mobjBatteryControl.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.mobjBatteryControl.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("batteryControl1.BackgroundImage"));
            this.mobjBatteryControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBatteryControl.Location = new System.Drawing.Point(135, 131);
            this.mobjBatteryControl.Name = "batteryControl1";
            this.mobjBatteryControl.Size = new System.Drawing.Size(120, 43);
            this.mobjBatteryControl.TabIndex = 0;
            this.mobjBatteryControl.Text = "BatteryControl";
            // 
            // ExampleBattery
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "ExampleBattery";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private BatteryControl mobjBatteryControl;
        private Label mobjLevelLabel;
        private Label mobjPluggedLabel;
    }
}