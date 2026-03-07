namespace CompanionKit.Controls.ErrorProvider.Features
{
    partial class BlinkStylePropertyPage
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
            this.mobjShowErrorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjBlinkStyleLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjBlinkStyleCB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjErrorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.mobjHideErrorButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjTLP = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjShowErrorButton
            // 
            this.mobjShowErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjShowErrorButton.Location = new System.Drawing.Point(102, 115);
            this.mobjShowErrorButton.Margin = new Gizmox.WebGUI.Forms.Padding(15, 15, 40, 15);
            this.mobjShowErrorButton.MaximumSize = new System.Drawing.Size(200, 70);
            this.mobjShowErrorButton.Name = "mobjShowErrorButton";
            this.mobjShowErrorButton.Size = new System.Drawing.Size(200, 70);
            this.mobjShowErrorButton.TabIndex = 4;
            this.mobjShowErrorButton.Text = "Show Error";
            this.mobjShowErrorButton.Click += new System.EventHandler(this.mobjShowErrorButton_Click);
            // 
            // mobjBlinkStyleLabel
            // 
            this.mobjBlinkStyleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBlinkStyleLabel.Location = new System.Drawing.Point(0, 300);
            this.mobjBlinkStyleLabel.Name = "mobjBlinkStyleLabel";
            this.mobjBlinkStyleLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjBlinkStyleLabel.Size = new System.Drawing.Size(87, 100);
            this.mobjBlinkStyleLabel.TabIndex = 3;
            this.mobjBlinkStyleLabel.Text = "Blink style";
            this.mobjBlinkStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTextLabel
            // 
            this.mobjTextLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTextLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjTextLabel.Name = "mobjTextLabel";
            this.mobjTextLabel.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0);
            this.mobjTextLabel.Size = new System.Drawing.Size(87, 100);
            this.mobjTextLabel.TabIndex = 1;
            this.mobjTextLabel.Text = "Text field with error";
            this.mobjTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjTextBox.Location = new System.Drawing.Point(97, 37);
            this.mobjTextBox.Margin = new Gizmox.WebGUI.Forms.Padding(10, 3, 40, 3);
            this.mobjTextBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.Size = new System.Drawing.Size(200, 25);
            this.mobjTextBox.TabIndex = 0;
            // 
            // mobjBlinkStyleCB
            // 
            this.mobjBlinkStyleCB.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.mobjBlinkStyleCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.mobjBlinkStyleCB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjBlinkStyleCB.FormattingEnabled = true;
            this.mobjBlinkStyleCB.Location = new System.Drawing.Point(97, 339);
            this.mobjBlinkStyleCB.Margin = new Gizmox.WebGUI.Forms.Padding(10, 0, 40, 0);
            this.mobjBlinkStyleCB.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjBlinkStyleCB.Name = "mobjBlinkStyleCB";
            this.mobjBlinkStyleCB.Size = new System.Drawing.Size(200, 25);
            this.mobjBlinkStyleCB.TabIndex = 5;
            // 
            // mobjErrorProvider
            // 
            this.mobjErrorProvider.BlinkRate = 3;
            // 
            // mobjHideErrorButton
            // 
            this.mobjHideErrorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjHideErrorButton.Location = new System.Drawing.Point(102, 215);
            this.mobjHideErrorButton.Margin = new Gizmox.WebGUI.Forms.Padding(15, 15, 40, 15);
            this.mobjHideErrorButton.MaximumSize = new System.Drawing.Size(200, 70);
            this.mobjHideErrorButton.Name = "mobjHideErrorButton";
            this.mobjHideErrorButton.Size = new System.Drawing.Size(200, 70);
            this.mobjHideErrorButton.TabIndex = 4;
            this.mobjHideErrorButton.Text = "Hide Error";
            this.mobjHideErrorButton.Click += new System.EventHandler(this.mobjHideErrorButton_Click);
            // 
            // mobjTLP
            // 
            this.mobjTLP.ColumnCount = 2;
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjTLP.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 75F));
            this.mobjTLP.Controls.Add(this.mobjTextLabel, 0, 0);
            this.mobjTLP.Controls.Add(this.mobjTextBox, 1, 0);
            this.mobjTLP.Controls.Add(this.mobjHideErrorButton, 1, 2);
            this.mobjTLP.Controls.Add(this.mobjShowErrorButton, 1, 1);
            this.mobjTLP.Controls.Add(this.mobjBlinkStyleLabel, 0, 3);
            this.mobjTLP.Controls.Add(this.mobjBlinkStyleCB, 1, 3);
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
            // BlinkStylePropertyPage
            // 
            this.Controls.Add(this.mobjTLP);
            this.Size = new System.Drawing.Size(350, 400);
            this.Text = "BlinkStylePropertyPage";
            this.Load += new System.EventHandler(this.BlinkStylePropertyPage_Load);
            this.mobjTLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button mobjShowErrorButton;
        private Gizmox.WebGUI.Forms.Label mobjBlinkStyleLabel;
        private Gizmox.WebGUI.Forms.Label mobjTextLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private Gizmox.WebGUI.Forms.ComboBox mobjBlinkStyleCB;
        private Gizmox.WebGUI.Forms.ErrorProvider mobjErrorProvider;
        private Gizmox.WebGUI.Forms.Button mobjHideErrorButton;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjTLP;



    }
}