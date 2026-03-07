using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.DeviceIntegration.Globalization
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
            this.mobjPrefferedLangLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPrefferedLangText = new Gizmox.WebGUI.Forms.Label();
            this.mobjLocaleLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLocaleText = new Gizmox.WebGUI.Forms.Label();
            this.mobjGetDataButton = new Gizmox.WebGUI.Forms.Button();
            this.mobjIDLSText = new Gizmox.WebGUI.Forms.Label();
            this.mobjIDLSLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFDOWLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjFDOWText = new Gizmox.WebGUI.Forms.Label();
            this.mobjCurrencyText = new Gizmox.WebGUI.Forms.Label();
            this.mobjCurrencyLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDateLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjDateText = new Gizmox.WebGUI.Forms.Label();
            this.mobjTitleLabel = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPrefferedLangLabel
            // 
            this.mobjPrefferedLangLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPrefferedLangLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjPrefferedLangLabel.Location = new System.Drawing.Point(0, 65);
            this.mobjPrefferedLangLabel.Name = "mobjPrefferedLangLabel";
            this.mobjPrefferedLangLabel.Size = new System.Drawing.Size(181, 40);
            this.mobjPrefferedLangLabel.TabIndex = 0;
            this.mobjPrefferedLangLabel.Text = "Preferred language:";
            this.mobjPrefferedLangLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mobjPrefferedLangText
            // 
            this.mobjPrefferedLangText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPrefferedLangText.ForeColor = System.Drawing.Color.Maroon;
            this.mobjPrefferedLangText.Location = new System.Drawing.Point(186, 261);
            this.mobjPrefferedLangText.Name = "mobjPrefferedLangText";
            this.mobjPrefferedLangText.Size = new System.Drawing.Size(205, 40);
            this.mobjPrefferedLangText.TabIndex = 0;
            this.mobjPrefferedLangText.Text = "--";
            this.mobjPrefferedLangText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjPrefferedLangText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjLocaleLabel
            // 
            this.mobjLocaleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLocaleLabel.Location = new System.Drawing.Point(0, 52);
            this.mobjLocaleLabel.Name = "mobjLocaleLabel";
            this.mobjLocaleLabel.Size = new System.Drawing.Size(181, 40);
            this.mobjLocaleLabel.TabIndex = 0;
            this.mobjLocaleLabel.Text = "Current Locale:";
            this.mobjLocaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjLocaleLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjLocaleText
            // 
            this.mobjLocaleText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLocaleText.ForeColor = System.Drawing.Color.Maroon;
            this.mobjLocaleText.Location = new System.Drawing.Point(186, 221);
            this.mobjLocaleText.Name = "mobjLocaleText";
            this.mobjLocaleText.Size = new System.Drawing.Size(205, 40);
            this.mobjLocaleText.TabIndex = 0;
            this.mobjLocaleText.Text = "--";
            this.mobjLocaleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjLocaleText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjGetDataButton
            // 
            this.mobjGetDataButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjGetDataButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjGetDataButton.Image"));
            this.mobjGetDataButton.Location = new System.Drawing.Point(0, 0);
            this.mobjGetDataButton.Name = "mobjGetDataButton";
            this.mobjGetDataButton.Size = new System.Drawing.Size(50, 50);
            this.mobjGetDataButton.TabIndex = 1;
            this.mobjGetDataButton.Text = ".";
            this.mobjGetDataButton.ClientClick += new Gizmox.WebGUI.Forms.Client.ClientEventHandler(this.mobjGetDataButton_ClientClick);
            // 
            // mobjIDLSText
            // 
            this.mobjIDLSText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjIDLSText.ForeColor = System.Drawing.Color.Maroon;
            this.mobjIDLSText.Location = new System.Drawing.Point(186, 141);
            this.mobjIDLSText.Name = "mobjIDLSText";
            this.mobjIDLSText.Size = new System.Drawing.Size(205, 40);
            this.mobjIDLSText.TabIndex = 0;
            this.mobjIDLSText.Text = "--";
            this.mobjIDLSText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjIDLSText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjIDLSLabel
            // 
            this.mobjIDLSLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjIDLSLabel.Location = new System.Drawing.Point(0, 39);
            this.mobjIDLSLabel.Name = "mobjIDLSLabel";
            this.mobjIDLSLabel.Size = new System.Drawing.Size(181, 40);
            this.mobjIDLSLabel.TabIndex = 0;
            this.mobjIDLSLabel.Text = "Is daylight savings time:";
            this.mobjIDLSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjIDLSLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjFDOWLabel
            // 
            this.mobjFDOWLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFDOWLabel.Location = new System.Drawing.Point(0, 26);
            this.mobjFDOWLabel.Name = "mobjFDOWLabel";
            this.mobjFDOWLabel.Size = new System.Drawing.Size(181, 40);
            this.mobjFDOWLabel.TabIndex = 0;
            this.mobjFDOWLabel.Text = "First day of week:";
            this.mobjFDOWLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjFDOWLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjFDOWText
            // 
            this.mobjFDOWText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjFDOWText.ForeColor = System.Drawing.Color.Maroon;
            this.mobjFDOWText.Location = new System.Drawing.Point(186, 101);
            this.mobjFDOWText.Name = "mobjFDOWText";
            this.mobjFDOWText.Size = new System.Drawing.Size(205, 40);
            this.mobjFDOWText.TabIndex = 0;
            this.mobjFDOWText.Text = "--";
            this.mobjFDOWText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjFDOWText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjCurrencyText
            // 
            this.mobjCurrencyText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCurrencyText.ForeColor = System.Drawing.Color.Maroon;
            this.mobjCurrencyText.Location = new System.Drawing.Point(186, 181);
            this.mobjCurrencyText.Name = "mobjCurrencyText";
            this.mobjCurrencyText.Size = new System.Drawing.Size(205, 40);
            this.mobjCurrencyText.TabIndex = 0;
            this.mobjCurrencyText.Text = "--";
            this.mobjCurrencyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjCurrencyText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjCurrencyLabel
            // 
            this.mobjCurrencyLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCurrencyLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjCurrencyLabel.Name = "mobjCurrencyLabel";
            this.mobjCurrencyLabel.Size = new System.Drawing.Size(181, 40);
            this.mobjCurrencyLabel.TabIndex = 0;
            this.mobjCurrencyLabel.Text = "Currency pattern (USD):";
            this.mobjCurrencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjCurrencyLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjDateLabel
            // 
            this.mobjDateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDateLabel.Location = new System.Drawing.Point(0, 13);
            this.mobjDateLabel.Name = "mobjDateLabel";
            this.mobjDateLabel.Size = new System.Drawing.Size(181, 40);
            this.mobjDateLabel.TabIndex = 0;
            this.mobjDateLabel.Text = "Current date as string:";
            this.mobjDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mobjDateLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjDateText
            // 
            this.mobjDateText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDateText.ForeColor = System.Drawing.Color.Maroon;
            this.mobjDateText.Location = new System.Drawing.Point(186, 301);
            this.mobjDateText.Name = "mobjDateText";
            this.mobjDateText.Size = new System.Drawing.Size(205, 40);
            this.mobjDateText.TabIndex = 0;
            this.mobjDateText.Text = "--";
            this.mobjDateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mobjDateText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mobjTitleLabel
            // 
            this.mobjTitleLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTitleLabel.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjTitleLabel.Location = new System.Drawing.Point(0, 78);
            this.mobjTitleLabel.Name = "mobjTitleLabel";
            this.mobjTitleLabel.Size = new System.Drawing.Size(391, 51);
            this.mobjTitleLabel.TabIndex = 2;
            this.mobjTitleLabel.Text = "Click the button to get globalization info";
            this.mobjTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mobjGetDataButton);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 50);
            this.panel1.TabIndex = 3;
            this.panel1.DockPadding.Left = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mobjPrefferedLangLabel);
            this.panel2.Controls.Add(this.mobjLocaleLabel);
            this.panel2.Controls.Add(this.mobjIDLSLabel);
            this.panel2.Controls.Add(this.mobjFDOWLabel);
            this.panel2.Controls.Add(this.mobjDateLabel);
            this.panel2.Controls.Add(this.mobjCurrencyLabel);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.DockPadding.Right = 5;
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 5, 0);
            this.panel2.Size = new System.Drawing.Size(186, 464);
            this.panel2.TabIndex = 4;
            // 
            // Example
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.mobjPrefferedLangText);
            this.Controls.Add(this.mobjLocaleText);
            this.Controls.Add(this.mobjIDLSText);
            this.Controls.Add(this.mobjFDOWText);
            this.Controls.Add(this.mobjDateText);
            this.Controls.Add(this.mobjCurrencyText);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mobjTitleLabel);
            this.Size = new System.Drawing.Size(391, 565);
            this.Text = "Example";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label mobjPrefferedLangLabel;
        private Label mobjPrefferedLangText;
        private Label mobjLocaleLabel;
        private Label mobjLocaleText;
        private Button mobjGetDataButton;
        private Label mobjIDLSText;
        private Label mobjIDLSLabel;
        private Label mobjFDOWLabel;
        private Label mobjFDOWText;
        private Label mobjCurrencyText;
        private Label mobjCurrencyLabel;
        private Label mobjDateLabel;
        private Label mobjDateText;
        private Label mobjTitleLabel;
        private Panel panel1;
        private Panel panel2;

     


    }
}