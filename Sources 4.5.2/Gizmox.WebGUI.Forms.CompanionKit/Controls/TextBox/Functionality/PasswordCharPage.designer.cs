using Gizmox.WebGUI.Forms;
namespace CompanionKit.Controls.TextBox.Functionality
{
    partial class PasswordCharPage
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
            this.mobjTextBoxLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjCharTextBox = new Gizmox.WebGUI.Forms.TextBox();
            this.mobjPasswordCharLabel = new Gizmox.WebGUI.Forms.Label();
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
            this.mobjTextBox.Location = new System.Drawing.Point(0, 30);
            this.mobjTextBox.Name = "mobjTextBox";
            this.mobjTextBox.PasswordChar = '+';
            this.mobjTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjTextBox.TabIndex = 0;
            // 
            // mobjTextBoxLabel
            // 
            this.mobjTextBoxLabel.AutoSize = true;
            this.mobjTextBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTextBoxLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjTextBoxLabel.Name = "mobjTextBoxLabel";
            this.mobjTextBoxLabel.Size = new System.Drawing.Size(93, 13);
            this.mobjTextBoxLabel.TabIndex = 1;
            this.mobjTextBoxLabel.Text = "PasswordTextBox";
            // 
            // mobjCharTextBox
            // 
            this.mobjCharTextBox.AllowDrag = false;
            this.mobjCharTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjCharTextBox.Location = new System.Drawing.Point(0, 30);
            this.mobjCharTextBox.Name = "mobjCharTextBox";
            this.mobjCharTextBox.Size = new System.Drawing.Size(200, 30);
            this.mobjCharTextBox.TabIndex = 2;
            this.mobjCharTextBox.TextChanged += new System.EventHandler(this.mobjCharTextBox_TextChanged);
            // 
            // mobjPasswordCharLabel
            // 
            this.mobjPasswordCharLabel.AutoSize = true;
            this.mobjPasswordCharLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPasswordCharLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjPasswordCharLabel.Name = "mobjPasswordCharLabel";
            this.mobjPasswordCharLabel.Size = new System.Drawing.Size(76, 13);
            this.mobjPasswordCharLabel.TabIndex = 3;
            this.mobjPasswordCharLabel.Text = "PasswordChar";
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
            this.mobjLayoutPanel.Size = new System.Drawing.Size(401, 181);
            this.mobjLayoutPanel.TabIndex = 4;
            // 
            // mobjTopPanel
            // 
            this.mobjTopPanel.Controls.Add(this.mobjTextBoxLabel);
            this.mobjTopPanel.Controls.Add(this.mobjTextBox);
            this.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTopPanel.Location = new System.Drawing.Point(100, 20);
            this.mobjTopPanel.Name = "mobjTopPanel";
            this.mobjTopPanel.Size = new System.Drawing.Size(200, 60);
            this.mobjTopPanel.TabIndex = 0;
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjPasswordCharLabel);
            this.mobjBottomPanel.Controls.Add(this.mobjCharTextBox);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(100, 100);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(200, 60);
            this.mobjBottomPanel.TabIndex = 0;
            // 
            // PasswordCharPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(401, 181);
            this.Text = "PasswordCharPage";
            this.mobjLayoutPanel.ResumeLayout(false);
            this.mobjTopPanel.ResumeLayout(false);
            this.mobjBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.TextBox mobjTextBox;
        private global::Gizmox.WebGUI.Forms.Label mobjTextBoxLabel;
        private Gizmox.WebGUI.Forms.TextBox mobjCharTextBox;
        private Label mobjPasswordCharLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;
        private Gizmox.WebGUI.Forms.Panel mobjTopPanel;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;


    }
}
