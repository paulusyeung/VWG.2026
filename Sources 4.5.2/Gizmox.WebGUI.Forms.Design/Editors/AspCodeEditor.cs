using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{


    public class AspCodeEditor : UITypeEditor
    {
        private class AspCodeEditorForm : System.Windows.Forms.Form
        {

            private System.Windows.Forms.Button mobjButtonCancel;
            private System.Windows.Forms.Button mobjButtonOK;
            private System.Windows.Forms.Panel monjPanelContent;
            private System.Windows.Forms.TextBox mobjTextEditor;


            public AspCodeEditorForm()
            {
                InitializeComponent();
            }


            #region Windows Form Designer generated code

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

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                System.Windows.Forms.Panel panel1;
                System.Windows.Forms.Panel panel2;
                this.mobjButtonOK = new System.Windows.Forms.Button();
                this.mobjButtonCancel = new System.Windows.Forms.Button();
                this.monjPanelContent = new System.Windows.Forms.Panel();
                this.mobjTextEditor = new System.Windows.Forms.TextBox();
                panel1 = new System.Windows.Forms.Panel();
                panel2 = new System.Windows.Forms.Panel();
                panel1.SuspendLayout();
                panel2.SuspendLayout();
                this.monjPanelContent.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                panel1.Controls.Add(this.mobjButtonCancel);
                panel1.Controls.Add(this.mobjButtonOK);
                panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                panel1.Location = new System.Drawing.Point(0, 475);
                panel1.Name = "panel1";
                panel1.Size = new System.Drawing.Size(644, 51);
                panel1.TabIndex = 0;
                // 
                // mobjButtonOK
                // 
                this.mobjButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.mobjButtonOK.Location = new System.Drawing.Point(476, 16);
                this.mobjButtonOK.Name = "mobjButtonOK";
                this.mobjButtonOK.Size = new System.Drawing.Size(75, 23);
                this.mobjButtonOK.TabIndex = 0;
                this.mobjButtonOK.Text = "OK";
                this.mobjButtonOK.UseVisualStyleBackColor = true;
                this.mobjButtonOK.Click += new System.EventHandler(this.mobjButtonOK_Click);
                // 
                // mobjButtonCancel
                // 
                this.mobjButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.mobjButtonCancel.Location = new System.Drawing.Point(557, 16);
                this.mobjButtonCancel.Name = "mobjButtonCancel";
                this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
                this.mobjButtonCancel.TabIndex = 1;
                this.mobjButtonCancel.Text = "Cancel";
                this.mobjButtonCancel.UseVisualStyleBackColor = true;
                this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
                // 
                // panel2
                // 
                panel2.Controls.Add(this.monjPanelContent);
                panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                panel2.Location = new System.Drawing.Point(0, 0);
                panel2.Name = "panel2";
                panel2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
                panel2.Size = new System.Drawing.Size(644, 475);
                panel2.TabIndex = 1;
                // 
                // monjPanelContent
                // 
                this.monjPanelContent.BackColor = System.Drawing.Color.White;
                this.monjPanelContent.Controls.Add(this.mobjTextEditor);
                this.monjPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
                this.monjPanelContent.Location = new System.Drawing.Point(10, 10);
                this.monjPanelContent.Name = "monjPanelContent";
                this.monjPanelContent.Size = new System.Drawing.Size(624, 465);
                this.monjPanelContent.TabIndex = 0;
                // 
                // mobjTextEditor
                // 
                this.mobjTextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
                this.mobjTextEditor.Location = new System.Drawing.Point(0, 0);
                this.mobjTextEditor.Multiline = true;
                this.mobjTextEditor.Name = "mobjTextEditor";
                this.mobjTextEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                this.mobjTextEditor.Size = new System.Drawing.Size(624, 465);
                this.mobjTextEditor.TabIndex = 0;
                this.mobjTextEditor.WordWrap = false;
                this.mobjTextEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(mobjTextEditor_KeyDown);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(644, 526);
                this.Controls.Add(panel2);
                this.Controls.Add(panel1);
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "AspCodeEditorForm";
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
                this.Text = "ASP Code Editor";
                panel1.ResumeLayout(false);
                panel2.ResumeLayout(false);
                this.monjPanelContent.ResumeLayout(false);
                this.monjPanelContent.PerformLayout();
                this.ResumeLayout(false);

            }

            #endregion

            private void mobjTextEditor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == WinForms.Keys.A)
                {
                    ((WinForms.TextBox)sender).SelectAll();
                    e.Handled = true;
                }
            }

            private void mobjButtonOK_Click(object sender, EventArgs e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

            private void mobjButtonCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }

            public string Value
            {
                get
                {
                    return this.mobjTextEditor.Text;
                }
                set
                {
                    mobjTextEditor.Text = value;
                }
            }
        }


        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
            
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            AspCodeEditorForm objEditor = new AspCodeEditorForm();
            objEditor.Value = (string)value;
            if (objEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return objEditor.Value;
            }
            return value;
        }


    }
}
