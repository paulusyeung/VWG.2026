using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TextBox.Functionality
{
    partial class CharacterCasingPage
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
            this.mobjTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjDescriptionLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjTopPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLayoutPanel.SuspendLayout();
            this.mobjTopPanel.SuspendLayout();
            this.mobjBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjTextBox
            // 
            this.mobjTextBox.AllowDrag = false;
            this.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjTextBox.Location = new System.Drawing.Point(0, 35);
            this.mobjTextBox.Name = "textBox1";
            this.mobjTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjTextBox.TabIndex = 0;
            this.mobjTextBox.Text = "abCdDf";
            // 
            // mobjDescriptionLabel
            // 
            this.mobjDescriptionLabel.AutoSize = true;
            this.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjDescriptionLabel.Name = "mobjDescriptionLabel";
            this.mobjDescriptionLabel.Size = new System.Drawing.Size(47, 13);
            this.mobjDescriptionLabel.TabIndex = 3;
            this.mobjDescriptionLabel.Text = "TextBox";
            this.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "Normal",
            "Upper",
            "Lower"});
            this.mobjComboBox.Location = new System.Drawing.Point(0, 39);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjComboBox.TabIndex = 4;
            this.mobjComboBox.Text = "Normal";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(66, 13);
            this.mobjLabel.TabIndex = 5;
            this.mobjLabel.Text = "Casing Type";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Controls.Add(this.mobjTopPanel, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(394, 232);
            this.mobjLayoutPanel.TabIndex = 6;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjDescriptionLabel);
            this.mobjTopPanel.Controls.Add(this.mobjTextBox);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(97, 46);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(200, 60);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjLabel);
            this.mobjBottomPanel.Controls.Add(this.mobjComboBox);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(97, 126);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(200, 60);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // CharacterCasingPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(394, 232);
            this.Text = "CharacterCasingPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

		private Gizmox.WebGUI.Forms.TextBox mobjTextBox;
		private Gizmox.WebGUI.Forms.Label mobjDescriptionLabel;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;


    }
}
