using Gizmox.WebGUI.Forms;
namespace CompanionKit.Concepts.VisualEffects.Transform
{
    partial class TransformPage
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
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjRotateRB = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjScaleRB = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjTranslateRB = new Gizmox.WebGUI.Forms.CheckBox();
            this.mobjScewRB = new Gizmox.WebGUI.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mobjPanel
            // 
            this.mobjPanel.AccessibleDescription = "";
            this.mobjPanel.AccessibleName = "";
            this.mobjPanel.BackColor = System.Drawing.Color.MistyRose;
            this.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjPanel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(2);
            this.mobjPanel.Location = new System.Drawing.Point(75, 131);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(164, 167);
            this.mobjPanel.TabIndex = 1;
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.AccessibleDescription = "";
            this.mobjInfoLabel.AccessibleName = "";
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(377, 50);
            this.mobjInfoLabel.TabIndex = 2;
            this.mobjInfoLabel.Text = "Use buttons to set appropriate type of Transform visual effect:";
            // 
            // mobjRotateRB
            // 
            this.mobjRotateRB.AccessibleDescription = "";
            this.mobjRotateRB.AccessibleName = "";
            this.mobjRotateRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjRotateRB.Location = new System.Drawing.Point(35, 50);
            this.mobjRotateRB.Name = "mobjRotateRB";
            this.mobjRotateRB.Size = new System.Drawing.Size(122, 30);
            this.mobjRotateRB.TabIndex = 3;
            this.mobjRotateRB.Text = "Rotate";
            this.mobjRotateRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjRotateRB.CheckedChanged += new System.EventHandler(this.TransformTypeCheckedChanged);
            // 
            // mobjScaleRB
            // 
            this.mobjScaleRB.AccessibleDescription = "";
            this.mobjScaleRB.AccessibleName = "";
            this.mobjScaleRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjScaleRB.Location = new System.Drawing.Point(35, 91);
            this.mobjScaleRB.Name = "mobjScaleRB";
            this.mobjScaleRB.Size = new System.Drawing.Size(122, 30);
            this.mobjScaleRB.TabIndex = 4;
            this.mobjScaleRB.Text = "Scale";
            this.mobjScaleRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjScaleRB.CheckedChanged += new System.EventHandler(this.TransformTypeCheckedChanged);
            // 
            // mobjTranslateRB
            // 
            this.mobjTranslateRB.AccessibleDescription = "";
            this.mobjTranslateRB.AccessibleName = "";
            this.mobjTranslateRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjTranslateRB.Location = new System.Drawing.Point(170, 50);
            this.mobjTranslateRB.Name = "mobjTranslateRB";
            this.mobjTranslateRB.Size = new System.Drawing.Size(122, 30);
            this.mobjTranslateRB.TabIndex = 5;
            this.mobjTranslateRB.Text = "Translate";
            this.mobjTranslateRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjTranslateRB.CheckedChanged += new System.EventHandler(this.TransformTypeCheckedChanged);
            // 
            // mobjScewRB
            // 
            this.mobjScewRB.AccessibleDescription = "";
            this.mobjScewRB.AccessibleName = "";
            this.mobjScewRB.Appearance = Gizmox.WebGUI.Forms.Appearance.Button;
            this.mobjScewRB.Location = new System.Drawing.Point(170, 91);
            this.mobjScewRB.Name = "mobjScewRB";
            this.mobjScewRB.Size = new System.Drawing.Size(122, 30);
            this.mobjScewRB.TabIndex = 6;
            this.mobjScewRB.Text = "Scew";
            this.mobjScewRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mobjScewRB.CheckedChanged += new System.EventHandler(this.TransformTypeCheckedChanged);
            // 
            // TransformPage
            // 
            this.Controls.Add(this.mobjScewRB);
            this.Controls.Add(this.mobjTranslateRB);
            this.Controls.Add(this.mobjScaleRB);
            this.Controls.Add(this.mobjRotateRB);
            this.Controls.Add(this.mobjInfoLabel);
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(377, 439);
            this.Text = "TransformPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mobjPanel;
        private Label mobjInfoLabel;
        private CheckBox mobjRotateRB;
        private CheckBox mobjScaleRB;
        private CheckBox mobjTranslateRB;
        private CheckBox mobjScewRB;


    }
}