namespace CompanionKit.Controls.MessageBoxControl.Functionality
{
    partial class MessageBoxButtonsPage
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
            this.mobjMessageBoxButtonsCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjShowButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjShowModalMask = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjResultLbl = new Gizmox.WebGUI.Forms.Label();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjMessageBoxButtonsCB
            // 
            this.mobjMessageBoxButtonsCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjMessageBoxButtonsCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjMessageBoxButtonsCB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjMessageBoxButtonsCB.FormattingEnabled = true;
            this.mobjMessageBoxButtonsCB.Location = new System.Drawing.Point(160, 109);
            this.mobjMessageBoxButtonsCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjMessageBoxButtonsCB.Name = "mobjMessageBoxButtonsCB";
            this.mobjMessageBoxButtonsCB.Size = new System.Drawing.Size(160, 25);
            this.mobjMessageBoxButtonsCB.TabIndex = 0;
            // 
            // mobjLabel
            // 
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLabel.Location = new System.Drawing.Point(0, 80);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjLabel.Size = new System.Drawing.Size(160, 80);
            this.mobjLabel.TabIndex = 1;
            this.mobjLabel.Text = "MessageBox buttons";
            this.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjShowButton
            // 
            this.mobjShowButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjTLP.SetColumnSpan(this.mobjShowButton, 2);
            this.mobjShowButton.Location = new System.Drawing.Point(85, 255);
            this.mobjShowButton.Name = "mobjShowButton";
            this.mobjShowButton.Size = new System.Drawing.Size(150, 50);
            this.mobjShowButton.TabIndex = 2;
            this.mobjShowButton.Text = "Show";
            this.mobjShowButton.UseVisualStyleBackColor = true;
            this.mobjShowButton.Click += new System.EventHandler(this.mobjShowButton_Click);
            // 
            // mobjInfoLabel
            // 
            this.mobjTLP.SetColumnSpan(this.mobjInfoLabel, 2);
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(320, 80);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "Choose buttons to show within the MessageBox window:";
            this.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjShowModalMask
            // 
            this.mobjShowModalMask.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mobjShowModalMask.Checked = true;
            this.mobjShowModalMask.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.mobjTLP.SetColumnSpan(this.mobjShowModalMask, 2);
            this.mobjShowModalMask.Location = new System.Drawing.Point(85, 175);
            this.mobjShowModalMask.Name = "mobjShowModalMask";
            this.mobjShowModalMask.Size = new System.Drawing.Size(150, 50);
            this.mobjShowModalMask.TabIndex = 4;
            this.mobjShowModalMask.Text = "Show Modal Mask";
            this.mobjShowModalMask.UseVisualStyleBackColor = true;
            // 
            // mobjResultLbl
            // 
            this.mobjTLP.SetColumnSpan(this.mobjResultLbl, 2);
            this.mobjResultLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjResultLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mobjResultLbl.Location = new System.Drawing.Point(0, 320);
            this.mobjResultLbl.Name = "mobjResultLbl";
            this.mobjResultLbl.Size = new System.Drawing.Size(320, 80);
            this.mobjResultLbl.TabIndex = 10;
            this.mobjResultLbl.Text = "Result";
            this.mobjResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjTLP.Controls.Add(this.mobjInfoLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjResultLbl, 0, 4);
            this.mobjTLP.Controls.Add(this.mobjLabel, 0, 1);
            this.mobjTLP.Controls.Add(this.mobjShowButton, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjShowModalMask, 0, 2);
            this.mobjTLP.Controls.Add(this.mobjMessageBoxButtonsCB, 1, 1);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 5;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20F));
            this.mobjTLP.Size = new System.Drawing.Size(320, 400);
            this.mobjTLP.TabIndex = 11;
            // 
            // MessageBoxButtonsPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(320, 400);
            this.Text = "MessageBoxButtonsPage";
            this.Load += new System.EventHandler(this.MessageBoxButtonsPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox mobjMessageBoxButtonsCB;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.Button mobjShowButton;
        private Gizmox.WebGUI.Forms.Label mobjInfoLabel;
        private Gizmox.WebGUI.Forms.CheckBox mobjShowModalMask;
        private Gizmox.WebGUI.Forms.Label mobjResultLbl;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}