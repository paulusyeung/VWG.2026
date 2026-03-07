using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace ComponentOneSampleAppsCS
{
    partial class C1LineChartForm
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C1LineChartForm));
            this.mobjWrapper = new C1LineChartWrapper();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjSetButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWrapper
            // 
            this.mobjTLP.SetColumnSpan(this.mobjWrapper, 2);
            this.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode");
            this.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWrapper.Location = new System.Drawing.Point(0, 76);
            this.mobjWrapper.Name = "mobjWrapper";
            this.mobjWrapper.Size = new System.Drawing.Size(1041, 304);
            this.mobjWrapper.TabIndex = 0;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjWrapper, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjSetButton, 0, 2);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 3;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(1041, 508);
            this.mobjTLP.TabIndex = 2;
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(1041, 76);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 LineChart:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjSetButton
            // 
            this.mobjSetButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjSetButton.Location = new System.Drawing.Point(445, 419);
            this.mobjSetButton.Name = "mobjSetButton";
            this.mobjSetButton.Size = new System.Drawing.Size(150, 50);
            this.mobjSetButton.TabIndex = 0;
            this.mobjSetButton.Text = "Generate new Chart";
            this.mobjSetButton.Click += new System.EventHandler(this.mobjSetButton_Click);
            // 
            // C1LineChartPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(391, 600);
            this.Text = "C1LineChartPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1LineChartWrapper mobjWrapper;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.Button mobjSetButton;
    }
}