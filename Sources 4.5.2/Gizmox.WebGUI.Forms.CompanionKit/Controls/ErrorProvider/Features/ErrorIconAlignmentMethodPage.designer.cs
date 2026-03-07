namespace CompanionKit.Controls.ErrorProvider.Features
{
    partial class ErrorIconAlignmentMethodPage
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
            this.components = new System.ComponentModel.Container();
            this.mobjHideErrorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjShowErrorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjAlignmentLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjIconAlignmentCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjHideErrorButton
            // 
            this.mobjHideErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHideErrorButton.Location = new System.Drawing.Point(135, 215);
            this.mobjHideErrorButton.Margin = new Gizmox.WebGUI.Forms.Padding(30, 15, 30, 15);
            this.mobjHideErrorButton.MaximumSize = new System.Drawing.Size(200, 70);
            this.mobjHideErrorButton.Name = "mobjHideErrorButton";
            this.mobjHideErrorButton.Size = new System.Drawing.Size(185, 70);
            this.mobjHideErrorButton.TabIndex = 4;
            this.mobjHideErrorButton.Text = "Hide Error";
            this.mobjHideErrorButton.Click += new System.EventHandler(this.mobjHideErrorButton_Click);
            // 
            // mobjShowErrorButton
            // 
            this.mobjShowErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowErrorButton.Location = new System.Drawing.Point(135, 115);
            this.mobjShowErrorButton.Margin = new Gizmox.WebGUI.Forms.Padding(30, 15, 30, 15);
            this.mobjShowErrorButton.MaximumSize = new System.Drawing.Size(200, 70);
            this.mobjShowErrorButton.Name = "mobjShowErrorButton";
            this.mobjShowErrorButton.Size = new System.Drawing.Size(185, 70);
            this.mobjShowErrorButton.TabIndex = 4;
            this.mobjShowErrorButton.Text = "Show Error";
            this.mobjShowErrorButton.Click += new System.EventHandler(this.mobjShowErrorButton_Click);
            // 
            // mobjAlignmentLabel
            // 
            this.mobjAlignmentLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjAlignmentLabel.Location = new System.Drawing.Point(0, 300);
            this.mobjAlignmentLabel.Name = "mobjAlignmentLabel";
            this.mobjAlignmentLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 5, 0);
            this.mobjAlignmentLabel.Size = new System.Drawing.Size(105, 100);
            this.mobjAlignmentLabel.TabIndex = 3;
            this.mobjAlignmentLabel.Text = "Icon alignment";
            this.mobjAlignmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjTextLabel.Name = "mobjTextLabel";
            this.mobjTextLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 5, 0);
            this.mobjTextLabel.Size = new System.Drawing.Size(105, 100);
            this.mobjTextLabel.TabIndex = 1;
            this.mobjTextLabel.Text = "Text field with error";
            this.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextBox.Location = new System.Drawing.Point(135, 37);
            this.mobjTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(30, 3, 30, 3);
            this.mobjTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(185, 25);
            this.mobjTextBox.TabIndex = 0;
            // 
            // mobjIconAlignmentCB
            // 
            this.mobjIconAlignmentCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjIconAlignmentCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjIconAlignmentCB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjIconAlignmentCB.FormattingEnabled = true;
            this.mobjIconAlignmentCB.Location = new System.Drawing.Point(135, 339);
            this.mobjIconAlignmentCB.Margin = new Gizmox.WebGUI.Forms.Padding(30, 0, 30, 0);
            this.mobjIconAlignmentCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjIconAlignmentCB.Name = "mobjIconAlignmentCB";
            this.mobjIconAlignmentCB.Size = new System.Drawing.Size(185, 25);
            this.mobjIconAlignmentCB.TabIndex = 5;
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjTLP.Controls.Add(this.mobjTextLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjHideErrorButton, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjShowErrorButton, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjTextBox, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjIconAlignmentCB, 1, 3);
            this.mobjTLP.Controls.Add(this.mobjAlignmentLabel, 0, 3);
            this.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTLP.Location = new System.Drawing.Point(0, 0);
            this.mobjTLP.MaximumSize = new System.Drawing.Size(1280, 0);
            this.mobjTLP.Name = "mobjTLP";
            this.mobjTLP.RowCount = 4;
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.Size = new System.Drawing.Size(350, 400);
            this.mobjTLP.TabIndex = 6;
            // 
            // ErrorIconAlignmentMethodPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(350, 400);
            this.Text = "ErrorIconAlignmentMethodPage";
            this.Load += new System.EventHandler(this.ErrorIconAlignmentMethodPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjHideErrorButton;
        private Gizmox.WebGUI.Forms.Button mobjShowErrorButton;
        private Gizmox.WebGUI.Forms.Label mobjAlignmentLabel;
        private Gizmox.WebGUI.Forms.ErrorProvider mobjErrorProvider;
        private Gizmox.WebGUI.Forms.Label mobjTextLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjIconAlignmentCB;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}