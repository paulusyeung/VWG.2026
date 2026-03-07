using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement.CustomControls;
using Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement;

namespace CompanionKit.DeviceIntegration.FileManagement
{
    partial class FileExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorer));
            this.toolStrip1 = new Gizmox.WebGUI.Forms.ToolStrip();
            this.mobjFolderUpButton = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.toolStripSeparator3 = new Gizmox.WebGUI.Forms.ToolStripSeparator();
            this.mobjCopyButton = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.mobjCutButton = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.mobjPasteButton = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.toolStripSeparator4 = new Gizmox.WebGUI.Forms.ToolStripSeparator();
            this.mobjDeleteButton = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.toolStripSeparator2 = new Gizmox.WebGUI.Forms.ToolStripSeparator();
            this.folderList1 = new Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement.FoldersControl();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = Gizmox.WebGUI.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.mobjFolderUpButton,
            this.toolStripSeparator3,
            this.mobjCopyButton,
            this.mobjCutButton,
            this.mobjPasteButton,
            this.toolStripSeparator4,
            this.mobjDeleteButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(613, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mobjFolderUpButton
            // 
            this.mobjFolderUpButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjFolderUpButton.Image"));
            this.mobjFolderUpButton.ImageScaling = Gizmox.WebGUI.Forms.ToolStripItemImageScaling.None;
            this.mobjFolderUpButton.Name = "mobjFolderUpButton";
            this.mobjFolderUpButton.Size = new System.Drawing.Size(48, 48);
            this.mobjFolderUpButton.Click += new System.EventHandler(this.mobjFolderUpButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // mobjCopyButton
            // 
            this.mobjCopyButton.AutoSize = false;
            this.mobjCopyButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjCopyButton.Image"));
            this.mobjCopyButton.ImageScaling = Gizmox.WebGUI.Forms.ToolStripItemImageScaling.None;
            this.mobjCopyButton.Name = "mobjCopyButton";
            this.mobjCopyButton.Size = new System.Drawing.Size(48, 48);
            this.mobjCopyButton.Click += new System.EventHandler(this.mobjCopyButton_Click);
            // 
            // mobjCutButton
            // 
            this.mobjCutButton.AutoSize = false;
            this.mobjCutButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjCutButton.Image"));
            this.mobjCutButton.ImageScaling = Gizmox.WebGUI.Forms.ToolStripItemImageScaling.None;
            this.mobjCutButton.Name = "mobjCutButton";
            this.mobjCutButton.Size = new System.Drawing.Size(48, 48);
            this.mobjCutButton.Click += new System.EventHandler(this.mobjCutButton_Click);
            // 
            // mobjPasteButton
            // 
            this.mobjPasteButton.AutoSize = false;
            this.mobjPasteButton.Enabled = false;
            this.mobjPasteButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPasteButton.Image"));
            this.mobjPasteButton.ImageScaling = Gizmox.WebGUI.Forms.ToolStripItemImageScaling.None;
            this.mobjPasteButton.Name = "mobjPasteButton";
            this.mobjPasteButton.Size = new System.Drawing.Size(48, 48);
            this.mobjPasteButton.Click += new System.EventHandler(this.mobjPasteButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // mobjDeleteButton
            // 
            this.mobjDeleteButton.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjDeleteButton.Image"));
            this.mobjDeleteButton.ImageScaling = Gizmox.WebGUI.Forms.ToolStripItemImageScaling.None;
            this.mobjDeleteButton.Name = "mobjDeleteButton";
            this.mobjDeleteButton.Size = new System.Drawing.Size(23, 4);
            this.mobjDeleteButton.Click += new System.EventHandler(this.mobjDeleteButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // folderList1
            // 
            this.folderList1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.folderList1.BackColor = System.Drawing.Color.White;
            this.folderList1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.folderList1.Location = new System.Drawing.Point(0, 25);
            this.folderList1.Name = "folderList1";
            this.folderList1.Size = new System.Drawing.Size(613, 593);
            this.folderList1.TabIndex = 1;
            this.folderList1.DirectoryChanged += new System.EventHandler<Gizmox.WebGUI.Common.Device.FileManagement.EntryEventArgs>(this.folderList1_DirectoryChanged);
            // 
            // FileExplorer
            // 
            this.Controls.Add(this.folderList1);
            this.Controls.Add(this.toolStrip1);
            this.Size = new System.Drawing.Size(613, 618);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStrip toolStrip1;
        private FoldersControl folderList1;
        private ToolStripButton mobjFolderUpButton;
        private ToolStripButton mobjCopyButton;
        private ToolStripButton mobjCutButton;
        private ToolStripButton mobjPasteButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton mobjDeleteButton;
    }
}