using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Microsoft.Reporting.WebForms;

namespace CompanionKit.Concepts.Context
{
    partial class ContextPage
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
            this.mobjContextGB = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjContextTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjParameterA1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjParameterBTxt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButtonSave1 = new Gizmox.WebGUI.Forms.Button();
            this.mobjParameterATxt1 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButtonLoad1 = new Gizmox.WebGUI.Forms.Button();
            this.mobjParameterB1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjSessionGB = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjSessionTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjParameterA3 = new Gizmox.WebGUI.Forms.Label();
            this.mobjButtonSave3 = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonLoad3 = new Gizmox.WebGUI.Forms.Button();
            this.mobjParameterB3 = new Gizmox.WebGUI.Forms.Label();
            this.mobjParameterATxt3 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjParameterBTxt3 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjAppGB = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjAppTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjParameterA4 = new Gizmox.WebGUI.Forms.Label();
            this.mobjParameterBTxt4 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButtonSave4 = new Gizmox.WebGUI.Forms.Button();
            this.mobjParameterATxt4 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjButtonLoad4 = new Gizmox.WebGUI.Forms.Button();
            this.mobjParameterB4 = new Gizmox.WebGUI.Forms.Label();
            this.mobjCookiesGB = new Gizmox.WebGUI.Forms.GroupBox();
            this.mobjCookiesTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjParameterA2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjButtonSave2 = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonLoad2 = new Gizmox.WebGUI.Forms.Button();
            this.mobjParameterBTxt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjParameterB2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjParameterATxt2 = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjContextGB.SuspendLayout();
            this.mobjContextTLP.SuspendLayout();
            this.mobjSessionGB.SuspendLayout();
            this.mobjSessionTLP.SuspendLayout();
            this.mobjAppGB.SuspendLayout();
            this.mobjAppTLP.SuspendLayout();
            this.mobjCookiesGB.SuspendLayout();
            this.mobjCookiesTLP.SuspendLayout();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjContextGB
            // 
            this.mobjContextGB.Controls.Add(this.mobjContextTLP);
            this.mobjContextGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContextGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjContextGB.Location = new System.Drawing.Point(0, 0);
            this.mobjContextGB.Name = "mobjContextGB";
            this.mobjContextGB.Size = new System.Drawing.Size(553, 280);
            this.mobjContextGB.TabIndex = 0;
            this.mobjContextGB.TabStop = false;
            this.mobjContextGB.Text = "Context Scope Parameters";
            // 
            // mobjContextTLP
            // 
            this.mobjContextTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjContextTLP.ColumnCount = 2;
            this.mobjContextTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjContextTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjContextTLP.Controls.Add(this.mobjParameterA1, 0, 0);
            this.mobjContextTLP.Controls.Add(this.mobjParameterBTxt1, 1, 1);
            this.mobjContextTLP.Controls.Add(this.mobjButtonSave1, 1, 2);
            this.mobjContextTLP.Controls.Add(this.mobjParameterATxt1, 1, 0);
            this.mobjContextTLP.Controls.Add(this.mobjButtonLoad1, 0, 2);
            this.mobjContextTLP.Controls.Add(this.mobjParameterB1, 0, 1);
            this.mobjContextTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjContextTLP.Location = new System.Drawing.Point(3, 17);
            this.mobjContextTLP.Name = "mobjContextTLP";
            this.mobjContextTLP.RowCount = 3;
            this.mobjContextTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjContextTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjContextTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjContextTLP.Size = new System.Drawing.Size(547, 260);
            this.mobjContextTLP.TabIndex = 6;
            // 
            // mobjParameterA1
            // 
            this.mobjParameterA1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterA1.Location = new System.Drawing.Point(0, 0);
            this.mobjParameterA1.Name = "mobjParameterA1";
            this.mobjParameterA1.Size = new System.Drawing.Size(273, 86);
            this.mobjParameterA1.TabIndex = 0;
            this.mobjParameterA1.Text = "ParameterA:";
            this.mobjParameterA1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjParameterBTxt1
            // 
            this.mobjParameterBTxt1.AcceptsTab = true;
            this.mobjParameterBTxt1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterBTxt1.Location = new System.Drawing.Point(200, 114);
            this.mobjParameterBTxt1.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt1.Name = "mobjParameterBTxt1";
            this.mobjParameterBTxt1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterBTxt1.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt1.TabIndex = 3;
            this.mobjParameterBTxt1.WordWrap = false;
            // 
            // mobjButtonSave1
            // 
            this.mobjButtonSave1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonSave1.Location = new System.Drawing.Point(372, 204);
            this.mobjButtonSave1.Name = "mobjButtonSave1";
            this.mobjButtonSave1.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonSave1.TabIndex = 4;
            this.mobjButtonSave1.Text = "Save";
            this.mobjButtonSave1.Click += new System.EventHandler(this.mobjButtonSave1_Click);
            // 
            // mobjParameterATxt1
            // 
            this.mobjParameterATxt1.AcceptsTab = true;
            this.mobjParameterATxt1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterATxt1.Location = new System.Drawing.Point(200, 38);
            this.mobjParameterATxt1.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt1.Name = "mobjParameterATxt1";
            this.mobjParameterATxt1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterATxt1.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt1.TabIndex = 2;
            this.mobjParameterATxt1.WordWrap = false;
            // 
            // mobjButtonLoad1
            // 
            this.mobjButtonLoad1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonLoad1.Location = new System.Drawing.Point(99, 204);
            this.mobjButtonLoad1.Name = "mobjButtonLoad1";
            this.mobjButtonLoad1.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonLoad1.TabIndex = 5;
            this.mobjButtonLoad1.Text = "Load";
            this.mobjButtonLoad1.Click += new System.EventHandler(this.mobjButtonLoad1_Click);
            // 
            // mobjParameterB1
            // 
            this.mobjParameterB1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterB1.Location = new System.Drawing.Point(0, 86);
            this.mobjParameterB1.Name = "mobjParameterB1";
            this.mobjParameterB1.Size = new System.Drawing.Size(273, 86);
            this.mobjParameterB1.TabIndex = 1;
            this.mobjParameterB1.Text = "ParameterB:";
            this.mobjParameterB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjSessionGB
            // 
            this.mobjSessionGB.Controls.Add(this.mobjSessionTLP);
            this.mobjSessionGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSessionGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjSessionGB.Location = new System.Drawing.Point(0, 280);
            this.mobjSessionGB.Name = "mobjSessionGB";
            this.mobjSessionGB.Size = new System.Drawing.Size(553, 280);
            this.mobjSessionGB.TabIndex = 1;
            this.mobjSessionGB.TabStop = false;
            this.mobjSessionGB.Text = "Session Scope Parameters";
            // 
            // mobjSessionTLP
            // 
            this.mobjSessionTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjSessionTLP.ColumnCount = 2;
            this.mobjSessionTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjSessionTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjSessionTLP.Controls.Add(this.mobjParameterA3, 0, 0);
            this.mobjSessionTLP.Controls.Add(this.mobjButtonSave3, 1, 2);
            this.mobjSessionTLP.Controls.Add(this.mobjButtonLoad3, 0, 2);
            this.mobjSessionTLP.Controls.Add(this.mobjParameterB3, 0, 1);
            this.mobjSessionTLP.Controls.Add(this.mobjParameterATxt3, 1, 0);
            this.mobjSessionTLP.Controls.Add(this.mobjParameterBTxt3, 1, 1);
            this.mobjSessionTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjSessionTLP.Location = new System.Drawing.Point(3, 17);
            this.mobjSessionTLP.Name = "mobjSessionTLP";
            this.mobjSessionTLP.RowCount = 3;
            this.mobjSessionTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjSessionTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjSessionTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjSessionTLP.Size = new System.Drawing.Size(547, 260);
            this.mobjSessionTLP.TabIndex = 6;
            // 
            // mobjParameterA3
            // 
            this.mobjParameterA3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterA3.Location = new System.Drawing.Point(0, 0);
            this.mobjParameterA3.Name = "mobjParameterA3";
            this.mobjParameterA3.Size = new System.Drawing.Size(273, 86);
            this.mobjParameterA3.TabIndex = 0;
            this.mobjParameterA3.Text = "ParameterA:";
            this.mobjParameterA3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjButtonSave3
            // 
            this.mobjButtonSave3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonSave3.Location = new System.Drawing.Point(372, 204);
            this.mobjButtonSave3.Name = "mobjButtonSave3";
            this.mobjButtonSave3.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonSave3.TabIndex = 4;
            this.mobjButtonSave3.Text = "Save";
            this.mobjButtonSave3.Click += new System.EventHandler(this.mobjButtonSave3_Click);
            // 
            // mobjButtonLoad3
            // 
            this.mobjButtonLoad3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonLoad3.Location = new System.Drawing.Point(99, 204);
            this.mobjButtonLoad3.Name = "mobjButtonLoad3";
            this.mobjButtonLoad3.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonLoad3.TabIndex = 5;
            this.mobjButtonLoad3.Text = "Load";
            this.mobjButtonLoad3.Click += new System.EventHandler(this.mobjButtonLoad3_Click);
            // 
            // mobjParameterB3
            // 
            this.mobjParameterB3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterB3.Location = new System.Drawing.Point(0, 86);
            this.mobjParameterB3.Name = "mobjParameterB3";
            this.mobjParameterB3.Size = new System.Drawing.Size(273, 86);
            this.mobjParameterB3.TabIndex = 1;
            this.mobjParameterB3.Text = "ParameterB:";
            this.mobjParameterB3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjParameterATxt3
            // 
            this.mobjParameterATxt3.AcceptsTab = true;
            this.mobjParameterATxt3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterATxt3.Location = new System.Drawing.Point(200, 38);
            this.mobjParameterATxt3.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt3.Name = "mobjParameterATxt3";
            this.mobjParameterATxt3.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterATxt3.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt3.TabIndex = 2;
            this.mobjParameterATxt3.WordWrap = false;
            // 
            // mobjParameterBTxt3
            // 
            this.mobjParameterBTxt3.AcceptsTab = true;
            this.mobjParameterBTxt3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterBTxt3.Location = new System.Drawing.Point(200, 114);
            this.mobjParameterBTxt3.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt3.Name = "mobjParameterBTxt3";
            this.mobjParameterBTxt3.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterBTxt3.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt3.TabIndex = 3;
            this.mobjParameterBTxt3.WordWrap = false;
            // 
            // mobjAppGB
            // 
            this.mobjAppGB.Controls.Add(this.mobjAppTLP);
            this.mobjAppGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAppGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjAppGB.Location = new System.Drawing.Point(553, 280);
            this.mobjAppGB.Name = "mobjAppGB";
            this.mobjAppGB.Size = new System.Drawing.Size(554, 280);
            this.mobjAppGB.TabIndex = 2;
            this.mobjAppGB.TabStop = false;
            this.mobjAppGB.Text = "Application Scope Parameters";
            // 
            // mobjAppTLP
            // 
            this.mobjAppTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjAppTLP.ColumnCount = 2;
            this.mobjAppTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAppTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjAppTLP.Controls.Add(this.mobjParameterA4, 0, 0);
            this.mobjAppTLP.Controls.Add(this.mobjParameterBTxt4, 1, 1);
            this.mobjAppTLP.Controls.Add(this.mobjButtonSave4, 1, 2);
            this.mobjAppTLP.Controls.Add(this.mobjParameterATxt4, 1, 0);
            this.mobjAppTLP.Controls.Add(this.mobjButtonLoad4, 0, 2);
            this.mobjAppTLP.Controls.Add(this.mobjParameterB4, 0, 1);
            this.mobjAppTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAppTLP.Location = new System.Drawing.Point(3, 17);
            this.mobjAppTLP.Name = "mobjAppTLP";
            this.mobjAppTLP.RowCount = 3;
            this.mobjAppTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjAppTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjAppTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjAppTLP.Size = new System.Drawing.Size(548, 260);
            this.mobjAppTLP.TabIndex = 6;
            // 
            // mobjParameterA4
            // 
            this.mobjParameterA4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterA4.Location = new System.Drawing.Point(0, 0);
            this.mobjParameterA4.Name = "mobjParameterA4";
            this.mobjParameterA4.Size = new System.Drawing.Size(274, 86);
            this.mobjParameterA4.TabIndex = 0;
            this.mobjParameterA4.Text = "ParameterA:";
            this.mobjParameterA4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjParameterBTxt4
            // 
            this.mobjParameterBTxt4.AcceptsTab = true;
            this.mobjParameterBTxt4.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterBTxt4.Location = new System.Drawing.Point(200, 114);
            this.mobjParameterBTxt4.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt4.Name = "mobjParameterBTxt4";
            this.mobjParameterBTxt4.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterBTxt4.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt4.TabIndex = 3;
            this.mobjParameterBTxt4.WordWrap = false;
            // 
            // mobjButtonSave4
            // 
            this.mobjButtonSave4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonSave4.Location = new System.Drawing.Point(373, 204);
            this.mobjButtonSave4.Name = "mobjButtonSave4";
            this.mobjButtonSave4.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonSave4.TabIndex = 4;
            this.mobjButtonSave4.Text = "Save";
            this.mobjButtonSave4.Click += new System.EventHandler(this.mobjButtonSave4_Click);
            // 
            // mobjParameterATxt4
            // 
            this.mobjParameterATxt4.AcceptsTab = true;
            this.mobjParameterATxt4.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterATxt4.Location = new System.Drawing.Point(200, 38);
            this.mobjParameterATxt4.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt4.Name = "mobjParameterATxt4";
            this.mobjParameterATxt4.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterATxt4.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt4.TabIndex = 2;
            this.mobjParameterATxt4.WordWrap = false;
            // 
            // mobjButtonLoad4
            // 
            this.mobjButtonLoad4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonLoad4.Location = new System.Drawing.Point(99, 204);
            this.mobjButtonLoad4.Name = "mobjButtonLoad4";
            this.mobjButtonLoad4.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonLoad4.TabIndex = 5;
            this.mobjButtonLoad4.Text = "Load";
            this.mobjButtonLoad4.Click += new System.EventHandler(this.mobjButtonLoad4_Click);
            // 
            // mobjParameterB4
            // 
            this.mobjParameterB4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterB4.Location = new System.Drawing.Point(0, 86);
            this.mobjParameterB4.Name = "mobjParameterB4";
            this.mobjParameterB4.Size = new System.Drawing.Size(274, 86);
            this.mobjParameterB4.TabIndex = 1;
            this.mobjParameterB4.Text = "ParameterB:";
            this.mobjParameterB4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjCookiesGB
            // 
            this.mobjCookiesGB.Controls.Add(this.mobjCookiesTLP);
            this.mobjCookiesGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCookiesGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjCookiesGB.Location = new System.Drawing.Point(553, 0);
            this.mobjCookiesGB.Name = "mobjCookiesGB";
            this.mobjCookiesGB.Size = new System.Drawing.Size(554, 280);
            this.mobjCookiesGB.TabIndex = 3;
            this.mobjCookiesGB.TabStop = false;
            this.mobjCookiesGB.Text = "Cookies Scope Parameters";
            // 
            // mobjCookiesTLP
            // 
            this.mobjCookiesTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjCookiesTLP.ColumnCount = 2;
            this.mobjCookiesTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjCookiesTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjCookiesTLP.Controls.Add(this.mobjParameterA2, 0, 0);
            this.mobjCookiesTLP.Controls.Add(this.mobjButtonSave2, 1, 2);
            this.mobjCookiesTLP.Controls.Add(this.mobjButtonLoad2, 0, 2);
            this.mobjCookiesTLP.Controls.Add(this.mobjParameterBTxt2, 1, 1);
            this.mobjCookiesTLP.Controls.Add(this.mobjParameterB2, 0, 1);
            this.mobjCookiesTLP.Controls.Add(this.mobjParameterATxt2, 1, 0);
            this.mobjCookiesTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjCookiesTLP.Location = new System.Drawing.Point(3, 17);
            this.mobjCookiesTLP.Name = "mobjCookiesTLP";
            this.mobjCookiesTLP.RowCount = 3;
            this.mobjCookiesTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjCookiesTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjCookiesTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F));
            this.mobjCookiesTLP.Size = new System.Drawing.Size(548, 260);
            this.mobjCookiesTLP.TabIndex = 6;
            // 
            // mobjParameterA2
            // 
            this.mobjParameterA2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterA2.Location = new System.Drawing.Point(0, 0);
            this.mobjParameterA2.Name = "mobjParameterA2";
            this.mobjParameterA2.Size = new System.Drawing.Size(274, 86);
            this.mobjParameterA2.TabIndex = 0;
            this.mobjParameterA2.Text = "ParameterA:";
            this.mobjParameterA2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjButtonSave2
            // 
            this.mobjButtonSave2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonSave2.Location = new System.Drawing.Point(373, 204);
            this.mobjButtonSave2.Name = "mobjButtonSave2";
            this.mobjButtonSave2.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonSave2.TabIndex = 2;
            this.mobjButtonSave2.Text = "Save";
            this.mobjButtonSave2.Click += new System.EventHandler(this.mobjButtonSave2_Click);
            // 
            // mobjButtonLoad2
            // 
            this.mobjButtonLoad2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjButtonLoad2.Location = new System.Drawing.Point(99, 204);
            this.mobjButtonLoad2.Name = "mobjButtonLoad2";
            this.mobjButtonLoad2.Size = new System.Drawing.Size(100, 40);
            this.mobjButtonLoad2.TabIndex = 3;
            this.mobjButtonLoad2.Text = "Load";
            this.mobjButtonLoad2.Click += new System.EventHandler(this.mobjButtonLoad2_Click);
            // 
            // mobjParameterBTxt2
            // 
            this.mobjParameterBTxt2.AcceptsTab = true;
            this.mobjParameterBTxt2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterBTxt2.Location = new System.Drawing.Point(200, 114);
            this.mobjParameterBTxt2.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt2.Name = "mobjParameterBTxt2";
            this.mobjParameterBTxt2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterBTxt2.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterBTxt2.TabIndex = 5;
            this.mobjParameterBTxt2.WordWrap = false;
            // 
            // mobjParameterB2
            // 
            this.mobjParameterB2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjParameterB2.Location = new System.Drawing.Point(0, 86);
            this.mobjParameterB2.Name = "mobjParameterB2";
            this.mobjParameterB2.Size = new System.Drawing.Size(274, 86);
            this.mobjParameterB2.TabIndex = 1;
            this.mobjParameterB2.Text = "ParameterB:";
            this.mobjParameterB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjParameterATxt2
            // 
            this.mobjParameterATxt2.AcceptsTab = true;
            this.mobjParameterATxt2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjParameterATxt2.Location = new System.Drawing.Point(200, 38);
            this.mobjParameterATxt2.MaximumSize = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt2.Name = "mobjParameterATxt2";
            this.mobjParameterATxt2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.mobjParameterATxt2.Size = new System.Drawing.Size(200, 25);
            this.mobjParameterATxt2.TabIndex = 4;
            this.mobjParameterATxt2.WordWrap = false;
            // 
            // mobjTLP
            // 
            this.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjContextGB, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjAppGB, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjCookiesGB, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjSessionGB, 0, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 2;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Size = new System.Drawing.Size(1107, 560);
            this.mobjTLP.TabIndex = 4;
            // 
            // ContextPage
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(800, 500);
            this.mobjContextGB.ResumeLayout(false);
            this.mobjContextTLP.ResumeLayout(false);
            this.mobjSessionGB.ResumeLayout(false);
            this.mobjSessionTLP.ResumeLayout(false);
            this.mobjAppGB.ResumeLayout(false);
            this.mobjAppTLP.ResumeLayout(false);
            this.mobjCookiesGB.ResumeLayout(false);
            this.mobjCookiesTLP.ResumeLayout(false);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.GroupBox mobjContextGB;
        private Gizmox.WebGUI.Forms.Label mobjParameterA1;
        private Gizmox.WebGUI.Forms.Label mobjParameterB1;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterATxt1;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterBTxt1;
        private Gizmox.WebGUI.Forms.Button mobjButtonSave1;
        private Gizmox.WebGUI.Forms.Button mobjButtonLoad1;
        private Gizmox.WebGUI.Forms.GroupBox mobjSessionGB;
        private Gizmox.WebGUI.Forms.GroupBox mobjAppGB;
        private Gizmox.WebGUI.Forms.Label mobjParameterA3;
        private Gizmox.WebGUI.Forms.Label mobjParameterB3;
        private Gizmox.WebGUI.Forms.Label mobjParameterA4;
        private Gizmox.WebGUI.Forms.Label mobjParameterB4;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterATxt3;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterBTxt3;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterATxt4;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterBTxt4;
        private Gizmox.WebGUI.Forms.Button mobjButtonSave3;
        private Gizmox.WebGUI.Forms.Button mobjButtonLoad3;
        private Gizmox.WebGUI.Forms.Button mobjButtonSave4;
        private Gizmox.WebGUI.Forms.Button mobjButtonLoad4;

        private static string mobjLock = "lock";
        private Gizmox.WebGUI.Forms.GroupBox mobjCookiesGB;
        private Gizmox.WebGUI.Forms.Label mobjParameterA2;
        private Gizmox.WebGUI.Forms.Label mobjParameterB2;
        private Gizmox.WebGUI.Forms.Button mobjButtonSave2;
        private Gizmox.WebGUI.Forms.Button mobjButtonLoad2;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterATxt2;
        private Gizmox.WebGUI.Forms.TextBox mobjParameterBTxt2;
        private TableLayoutPanel mobjTLP;
        private TableLayoutPanel mobjContextTLP;
        private TableLayoutPanel mobjCookiesTLP;
        private TableLayoutPanel mobjSessionTLP;
        private TableLayoutPanel mobjAppTLP;

    }
}