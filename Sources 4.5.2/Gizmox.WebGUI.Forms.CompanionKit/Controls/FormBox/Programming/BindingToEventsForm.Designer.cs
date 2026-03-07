using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Programming
{
    partial class BindingToEventsForm
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
            this.listBox = new Gizmox.WebGUI.Forms.ListBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5",
            "Item 6",
            "Item 7"});
            this.listBox.Location = new System.Drawing.Point(45, 32);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.listBox.Size = new System.Drawing.Size(208, 173);
            this.listBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is Visual WebGUI Form";
            // 
            // BindingToEventsForm
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Size = new System.Drawing.Size(300, 220);
            this.Text = "BindingToEventsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBox;
        private Label label1;


    }
}