using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.ListView.Features
{
    partial class ListViewControlPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.tabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.checkBoxAttachments = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBoxImportant = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBoxRead = new Gizmox.WebGUI.Forms.CheckBox();
            this.tabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxSize = new Gizmox.WebGUI.Forms.TextBox();
            this.textBoxSubject = new Gizmox.WebGUI.Forms.TextBox();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxFrom = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabControl1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(535, 116);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tabPage1.Controls.Add(this.checkBoxAttachments);
            this.tabPage1.Controls.Add(this.checkBoxImportant);
            this.tabPage1.Controls.Add(this.checkBoxRead);
            this.tabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(527, 90);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // checkBox1
            // 
            this.checkBoxAttachments.AutoSize = true;
            this.checkBoxAttachments.Location = new System.Drawing.Point(10, 13);
            this.checkBoxAttachments.Name = "checkBoxAttachments";
            this.checkBoxAttachments.Size = new System.Drawing.Size(48, 17);
            this.checkBoxAttachments.TabIndex = 3;
            this.checkBoxAttachments.Text = "Attachments";
            // 
            // checkBox2
            // 
            this.checkBoxRead.AutoSize = true;
            this.checkBoxRead.Location = new System.Drawing.Point(10, 31);
            this.checkBoxRead.Name = "checkBox2";
            this.checkBoxRead.Text = "Read";
            this.checkBoxRead.Size = new System.Drawing.Size(75, 23);
            this.checkBoxRead.TabIndex = 4;
            // 
            // checkBox3
            // 
            this.checkBoxImportant.AutoSize = true;
            this.checkBoxImportant.Location = new System.Drawing.Point(10, 49);
            this.checkBoxImportant.Name = "checkBox3";
            this.checkBoxImportant.Text = "Important";
            this.checkBoxImportant.Size = new System.Drawing.Size(75, 23);
            this.checkBoxImportant.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBoxSize);
            this.tabPage2.Controls.Add(this.textBoxSubject);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBoxFrom);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(527, 90);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Size";
            // 
            // textBox3
            // 
            this.textBoxSize.Location = new System.Drawing.Point(69, 64);
            this.textBoxSize.Name = "textBox3";
            this.textBoxSize.Size = new System.Drawing.Size(438, 20);
            this.textBoxSize.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(69, 37);
            this.textBoxSubject.Name = "textBox2";
            this.textBoxSubject.Size = new System.Drawing.Size(156, 20);
            this.textBoxSubject.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject";
            // 
            // textBox1
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(69, 10);
            this.textBoxFrom.Name = "textBox1";
            this.textBoxFrom.Size = new System.Drawing.Size(156, 20);
            this.textBoxFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // UserControl1
            // 
            this.Controls.Add(this.tabControl1);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(541, 122);
            this.ResumeLayout(false);

        }

        #endregion

        private global::Gizmox.WebGUI.Forms.TabControl tabControl1;
        private TabPage tabPage1;
        private global::Gizmox.WebGUI.Forms.CheckBox checkBoxImportant;
        private global::Gizmox.WebGUI.Forms.CheckBox checkBoxRead;
        private TabPage tabPage2;
        private global::Gizmox.WebGUI.Forms.CheckBox checkBoxAttachments;
        private global::Gizmox.WebGUI.Forms.Label label3;
        private global::Gizmox.WebGUI.Forms.TextBox textBoxSize;
        private global::Gizmox.WebGUI.Forms.TextBox textBoxSubject;
        private global::Gizmox.WebGUI.Forms.Label label2;
        private global::Gizmox.WebGUI.Forms.TextBox textBoxFrom;
        private global::Gizmox.WebGUI.Forms.Label label1;


    }
}