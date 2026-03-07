using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsCS
{
    partial class C1ReportViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C1ReportViewerForm));
            this.mobjWrapper = new C1ReportViewerWrapper();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjRB1 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRB2 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRB3 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRB4 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRB5 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRB6 = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjWrapper
            // 
            this.mobjTLP.SetColumnSpan(this.mobjWrapper, 2);
            this.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode");
            this.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjWrapper.Location = new System.Drawing.Point(0, 44);
            this.mobjWrapper.Name = "mobjWrapper";
            this.mobjWrapper.Size = new System.Drawing.Size(916, 265);
            this.mobjWrapper.TabIndex = 0;
            this.mobjWrapper.Theme = "aristo";
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjWrapper, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjRB1, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjRB2, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjRB3, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjRB4, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjRB5, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjRB6, 1, 4);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10F));
            this.mobjTLP.Size = new System.Drawing.Size(916, 442);
            this.mobjTLP.TabIndex = 1;
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(916, 44);
            this.mobjInfoLabel.TabIndex = 0;
            this.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 ReportViewer:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjRB1
            // 
            this.mobjRB1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRB1.Checked = true;
            this.mobjRB1.Location = new System.Drawing.Point(154, 309);
            this.mobjRB1.Name = "mobjRB1";
            this.mobjRB1.Size = new System.Drawing.Size(150, 44);
            this.mobjRB1.TabIndex = 0;
            this.mobjRB1.Text = "aristo";
            this.mobjRB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRB1.CheckedChanged += new System.EventHandler(this.ThemeChanged);
            // 
            // mobjRB2
            // 
            this.mobjRB2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRB2.Location = new System.Drawing.Point(154, 353);
            this.mobjRB2.Name = "mobjRB2";
            this.mobjRB2.Size = new System.Drawing.Size(150, 44);
            this.mobjRB2.TabIndex = 0;
            this.mobjRB2.Text = "metro";
            this.mobjRB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRB2.CheckedChanged += new System.EventHandler(this.ThemeChanged);
            // 
            // mobjRB3
            // 
            this.mobjRB3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRB3.Location = new System.Drawing.Point(154, 397);
            this.mobjRB3.Name = "mobjRB3";
            this.mobjRB3.Size = new System.Drawing.Size(150, 45);
            this.mobjRB3.TabIndex = 0;
            this.mobjRB3.Text = "cobalt";
            this.mobjRB3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRB3.CheckedChanged += new System.EventHandler(this.ThemeChanged);
            // 
            // mobjRB4
            // 
            this.mobjRB4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRB4.Location = new System.Drawing.Point(612, 309);
            this.mobjRB4.Name = "mobjRB4";
            this.mobjRB4.Size = new System.Drawing.Size(150, 44);
            this.mobjRB4.TabIndex = 0;
            this.mobjRB4.Text = "midnight";
            this.mobjRB4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRB4.CheckedChanged += new System.EventHandler(this.ThemeChanged);
            // 
            // mobjRB5
            // 
            this.mobjRB5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRB5.Location = new System.Drawing.Point(612, 353);
            this.mobjRB5.Name = "mobjRB5";
            this.mobjRB5.Size = new System.Drawing.Size(150, 44);
            this.mobjRB5.TabIndex = 0;
            this.mobjRB5.Text = "sterling";
            this.mobjRB5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRB5.CheckedChanged += new System.EventHandler(this.ThemeChanged);
            // 
            // mobjRB6
            // 
            this.mobjRB6.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjRB6.Location = new System.Drawing.Point(612, 397);
            this.mobjRB6.Name = "mobjRB6";
            this.mobjRB6.Size = new System.Drawing.Size(150, 45);
            this.mobjRB6.TabIndex = 0;
            this.mobjRB6.Text = "rocket";
            this.mobjRB6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRB6.CheckedChanged += new System.EventHandler(this.ThemeChanged);
            // 
            // C1ReportViewerPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(391, 600);
            this.Text = "C1ReportViewerPage";
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private C1ReportViewerWrapper mobjWrapper;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.RadioButton mobjRB1;
        private Gizmox.WebGUI.Forms.RadioButton mobjRB2;
        private Gizmox.WebGUI.Forms.RadioButton mobjRB3;
        private Gizmox.WebGUI.Forms.RadioButton mobjRB4;
        private Gizmox.WebGUI.Forms.RadioButton mobjRB5;
        private Gizmox.WebGUI.Forms.RadioButton mobjRB6;

    }
}