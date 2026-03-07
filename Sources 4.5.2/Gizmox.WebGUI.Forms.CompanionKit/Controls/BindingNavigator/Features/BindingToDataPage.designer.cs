namespace CompanionKit.Controls.BindingNavigator.Features
{
    partial class BindingToDataPage
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
            this.mobjListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.mobjBindingSource = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.mobjBindingNavigator = new Gizmox.WebGUI.Forms.BindingNavigator(this.components);
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingNavigator)).BeginInit();
            this.mobjPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListBox
            // 
            this.mobjListBox.DataSource = this.mobjBindingSource;
            this.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListBox.Location = new System.Drawing.Point(0, 28);
            this.mobjListBox.Name = "mobjListBox";
            this.mobjListBox.Size = new System.Drawing.Size(500, 160);
            this.mobjListBox.TabIndex = 1;
            // 
            // mobjBindingNavigator
            // 
            this.mobjBindingNavigator.BindingSource = this.mobjBindingSource;
            this.mobjBindingNavigator.DragHandle = true;
            this.mobjBindingNavigator.DropDownArrows = true;
            this.mobjBindingNavigator.ImageSize = new System.Drawing.Size(16, 16);
            this.mobjBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.mobjBindingNavigator.MenuHandle = true;
            this.mobjBindingNavigator.Name = "mobjBindingNavigator";
            this.mobjBindingNavigator.ShowToolTips = true;
            this.mobjBindingNavigator.Size = new System.Drawing.Size(500, 28);
            this.mobjBindingNavigator.TabIndex = 0;
            this.mobjBindingNavigator.AddStandardItems();
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjListBox);
            this.mobjPanel.Controls.Add(this.mobjBindingNavigator);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(500, 200);
            this.mobjPanel.TabIndex = 0;
            // 
            // BindingToDataPage
            // 
            this.Controls.Add(this.mobjPanel);
            this.Size = new System.Drawing.Size(500, 200);
            this.Text = "BindingToDataPage";
            this.Load += new System.EventHandler(this.BindingToDataPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobjBindingNavigator)).EndInit();
            this.mobjPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox mobjListBox;
        private Gizmox.WebGUI.Forms.BindingNavigator mobjBindingNavigator;
        private Gizmox.WebGUI.Forms.Panel mobjPanel;
        private Gizmox.WebGUI.Forms.BindingSource mobjBindingSource;



    }
}