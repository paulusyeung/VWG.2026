using Gizmox.WebGUI.Forms;
namespace CompanionKit.Concepts.ControlBehavior.Selectable
{
    partial class SelectablePage
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
            this.mobjLabel5 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel4 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel3 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel2 = new Gizmox.WebGUI.Forms.Label();
            this.mobjLabel1 = new Gizmox.WebGUI.Forms.Label();
            this.mobjSelectedInfo = new Gizmox.WebGUI.Forms.Label();
            this.mobjInfoLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjLabel5);
            this.mobjPanel.Controls.Add(this.mobjLabel4);
            this.mobjPanel.Controls.Add(this.mobjLabel3);
            this.mobjPanel.Controls.Add(this.mobjLabel2);
            this.mobjPanel.Controls.Add(this.mobjLabel1);
            this.mobjPanel.Location = new System.Drawing.Point(33, 102);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(182, 194);
            this.mobjPanel.TabIndex = 1;
            // 
            // mobjLabel5
            // 
            this.mobjLabel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjLabel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel5.Location = new System.Drawing.Point(0, 120);
            this.mobjLabel5.Name = "mobjLabel5";
            this.mobjLabel5.Size = new System.Drawing.Size(182, 30);
            this.mobjLabel5.TabIndex = 4;
            this.mobjLabel5.Tag = true;
            this.mobjLabel5.Text = "item5";
            this.mobjLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel4
            // 
            this.mobjLabel4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjLabel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel4.Location = new System.Drawing.Point(0, 90);
            this.mobjLabel4.Name = "mobjLabel4";
            this.mobjLabel4.Size = new System.Drawing.Size(182, 30);
            this.mobjLabel4.TabIndex = 3;
            this.mobjLabel4.Tag = true;
            this.mobjLabel4.Text = "item4";
            this.mobjLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel3
            // 
            this.mobjLabel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjLabel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel3.Location = new System.Drawing.Point(0, 60);
            this.mobjLabel3.Name = "mobjLabel3";
            this.mobjLabel3.Size = new System.Drawing.Size(182, 30);
            this.mobjLabel3.TabIndex = 2;
            this.mobjLabel3.Tag = true;
            this.mobjLabel3.Text = "item3";
            this.mobjLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel2
            // 
            this.mobjLabel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel2.Location = new System.Drawing.Point(0, 30);
            this.mobjLabel2.Name = "mobjLabel2";
            this.mobjLabel2.Size = new System.Drawing.Size(182, 30);
            this.mobjLabel2.TabIndex = 1;
            this.mobjLabel2.Tag = true;
            this.mobjLabel2.Text = "item2";
            this.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjLabel1
            // 
            this.mobjLabel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLabel1.Location = new System.Drawing.Point(0, 0);
            this.mobjLabel1.Name = "mobjLabel1";
            this.mobjLabel1.Size = new System.Drawing.Size(182, 30);
            this.mobjLabel1.TabIndex = 0;
            this.mobjLabel1.Tag = true;
            this.mobjLabel1.Text = "item1";
            this.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mobjSelectedInfo
            // 
            this.mobjSelectedInfo.Location = new System.Drawing.Point(33, 70);
            this.mobjSelectedInfo.Name = "mobjSelectedInfo";
            this.mobjSelectedInfo.Size = new System.Drawing.Size(182, 32);
            this.mobjSelectedInfo.TabIndex = 2;
            this.mobjSelectedInfo.Text = "Selected: None";
            // 
            // mobjInfoLabel
            // 
            this.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjInfoLabel.Name = "mobjInfoLabel";
            this.mobjInfoLabel.Size = new System.Drawing.Size(391, 70);
            this.mobjInfoLabel.TabIndex = 3;
            this.mobjInfoLabel.Text = "Click any label on panel to select it. Selected label changes background color:";
            // 
            // SelectablePage
            // 
            this.Controls.Add(this.mobjInfoLabel);
            this.Controls.Add(this.mobjSelectedInfo);
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(391, 330);
            this.Text = "SelectablePage";
            this.ControlSelected += new Gizmox.WebGUI.Forms.ControlsEventHandler(this.mobjPanel_ControlSelected);
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel mobjPanel;
        private Label mobjLabel3;
        private Label mobjLabel2;
        private Label mobjLabel1;
        private Label mobjLabel5;
        private Label mobjLabel4;
        private Label mobjSelectedInfo;
        private Label mobjInfoLabel;


    }
}