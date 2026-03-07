namespace CompanionKit.Controls.Chart.Features
{
    partial class ThemePropertyPage
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
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjThemesComboBox = new Gizmox.WebGUI.Forms.ComboBox();
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
            this.mobjTLP.SetColumnSpan(this.mobjChart, 2);
            this.mobjChart.Location = new System.Drawing.Point(117, 0);
            this.mobjChart.Name = "mobjChart";
            this.mobjChart.Size = new System.Drawing.Size(400, 382);
            this.mobjChart.TabIndex = 0;
            this.mobjChart.Theme = Gizmox.WebGUI.Forms.Charts.ThemeTypes.Theme1;
            this.mobjChart.Title = null;
            this.mobjChart.View3D = false;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 382);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel.Size = new System.Drawing.Size(200, 68);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "Theme";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjThemesComboBox
            // 
            this.mobjThemesComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjThemesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjThemesComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjThemesComboBox.FormattingEnabled = true;
            this.mobjThemesComboBox.Location = new System.Drawing.Point(210, 405);
            this.mobjThemesComboBox.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0);
            this.mobjThemesComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjThemesComboBox.Name = "mobjThemesComboBox";
            this.mobjThemesComboBox.Size = new System.Drawing.Size(180, 25);
            this.mobjThemesComboBox.TabIndex = 2;
            this.mobjThemesComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjThemesComboBox_SelectedIndexChanged);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjChart, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjThemesComboBox, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15F));
            this.mobjTLP.Size = new System.Drawing.Size(400, 450);
            this.mobjTLP.TabIndex = 3;
            // 
            // ThemePropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(400, 450);
            this.Text = "ThemePropertyPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Charts.Chart mobjChart;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjThemesComboBox;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}