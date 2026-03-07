namespace CompanionKit.Controls.Chart.Features
{
    partial class View3DPropertyPage
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
            this.mobjChart = new Gizmox.WebGUI.Forms.Charts.Chart();
            this.mobjView3DCheckBox = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjChart
            // 
            this.mobjChart.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjChart.AnimationEnabled = false;
            this.mobjChart.AnimationType = Gizmox.WebGUI.Forms.Charts.AnimationTypes.Type1;
            this.mobjChart.AxisX = null;
            this.mobjChart.AxisY = null;
            this.mobjChart.ColorSet = null;
            this.mobjChart.Location = new System.Drawing.Point(0, 16);
            this.mobjChart.Name = "mobjChart";
            this.mobjChart.Size = new System.Drawing.Size(400, 350);
            this.mobjChart.TabIndex = 0;
            this.mobjChart.Theme = Gizmox.WebGUI.Forms.Charts.ThemeTypes.Theme1;
            this.mobjChart.Title = null;
            this.mobjChart.View3D = false;
            // 
            // mobjView3DCheckBox
            // 
            this.mobjView3DCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjView3DCheckBox.Location = new System.Drawing.Point(160, 391);
            this.mobjView3DCheckBox.Name = "mobjView3DCheckBox";
            this.mobjView3DCheckBox.Size = new System.Drawing.Size(80, 50);
            this.mobjView3DCheckBox.TabIndex = 0;
            this.mobjView3DCheckBox.Text = "View 3D";
            this.mobjView3DCheckBox.CheckedChanged += new System.EventHandler(this.mobjView3DCheckBox_CheckedChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 1;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100F));
            this.mobjTLP.Controls.Add(this.mobjChart, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjView3DCheckBox, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(400, 450);
            this.mobjTLP.TabIndex = 1;
            // 
            // View3DPropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(400, 450);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Charts.Chart mobjChart;
        private Gizmox.WebGUI.Forms.CheckBox mobjView3DCheckBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}