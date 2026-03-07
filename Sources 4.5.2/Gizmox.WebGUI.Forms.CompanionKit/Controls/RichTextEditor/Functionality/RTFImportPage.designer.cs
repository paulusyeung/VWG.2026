namespace CompanionKit.Controls.RichTextEditor.Functionality
{
    partial class RTFImportPage
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
            this.mobjRichTextEditor = new Gizmox.WebGUI.Forms.RichTextEditor();
            this.mobjComboBox = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjBottomPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjLayoutPanel = new Gizmox.WebGUI.Forms.TableLayoutPanel();
            this.mobjBottomPanel.SuspendLayout();
            this.mobjLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjRichTextEditor
            // 
            this.mobjRichTextEditor.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjRichTextEditor.Location = new System.Drawing.Point(141, 40);
            this.mobjRichTextEditor.Name = "mobjRichTextEditor";
            this.mobjRichTextEditor.Size = new System.Drawing.Size(283, 149);
            this.mobjRichTextEditor.TabIndex = 0;
            // 
            // mobjComboBox
            // 
            this.mobjComboBox.AllowDrag = false;
            this.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBox.FormattingEnabled = true;
            this.mobjComboBox.Items.AddRange(new object[] {
            "List.rtf",
            "Sample.rtf",
            "Scenario.rtf"});
            this.mobjComboBox.Location = new System.Drawing.Point(0, 42);
            this.mobjComboBox.MaximumSize = new System.Drawing.Size(200, 0);
            this.mobjComboBox.Name = "mobjComboBox";
            this.mobjComboBox.Size = new System.Drawing.Size(200, 30);
            this.mobjComboBox.TabIndex = 1;
            this.mobjComboBox.Text = "List.rtf";
            this.mobjComboBox.SelectedIndexChanged += new System.EventHandler(this.mobjComboBox_SelectedIndexChanged);
            // 
            // mobjBottomPanel
            // 
            this.mobjBottomPanel.Controls.Add(this.mobjLabel);
            this.mobjBottomPanel.Controls.Add(this.mobjComboBox);
            this.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjBottomPanel.Location = new System.Drawing.Point(141, 229);
            this.mobjBottomPanel.Name = "mobjBottomPanel";
            this.mobjBottomPanel.Size = new System.Drawing.Size(283, 63);
            this.mobjBottomPanel.TabIndex = 4;
            // 
            // mobjLabel
            // 
            this.mobjLabel.AutoSize = true;
            this.mobjLabel.Location = new System.Drawing.Point(16, 0);
            this.mobjLabel.Name = "mobjLabel";
            this.mobjLabel.Size = new System.Drawing.Size(35, 13);
            this.mobjLabel.TabIndex = 3;
            this.mobjLabel.Text = "Choose RTF file:";
            // 
            // mobjLayoutPanel
            // 
            this.mobjLayoutPanel.ColumnCount = 3;
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50F));
            this.mobjLayoutPanel.ColumnStyles.Add(new Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25F));
            this.mobjLayoutPanel.Controls.Add(this.mobjRichTextEditor, 1, 1);
            this.mobjLayoutPanel.Controls.Add(this.mobjBottomPanel, 1, 3);
            this.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjLayoutPanel.Name = "mobjLayoutPanel";
            this.mobjLayoutPanel.RowCount = 5;
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30F));
            this.mobjLayoutPanel.RowStyles.Add(new Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40F));
            this.mobjLayoutPanel.Size = new System.Drawing.Size(567, 333);
            this.mobjLayoutPanel.TabIndex = 5;
            // 
            // RTFImportPage
            // 
            this.Controls.Add(this.mobjLayoutPanel);
            this.Size = new System.Drawing.Size(567, 333);
            this.Text = "RTFImportPage";
            this.Load += new System.EventHandler(this.RTFImportPage_Load);
            this.mobjBottomPanel.ResumeLayout(false);
            this.mobjLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.RichTextEditor mobjRichTextEditor;
        private Gizmox.WebGUI.Forms.ComboBox mobjComboBox;
        private Gizmox.WebGUI.Forms.Panel mobjBottomPanel;
        private Gizmox.WebGUI.Forms.Label mobjLabel;
        private Gizmox.WebGUI.Forms.TableLayoutPanel mobjLayoutPanel;



    }
}