using System;
using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design.Controls
{
    partial class ItemChooser
    {
        #region Class Members

        private WinForms.Button mobjButtonMoveUp;
        private WinForms.Button mobjButtonMoveDown;
        private WinForms.Button mobjButtonShow;
        private WinForms.Panel mobjPanelButtons;
        private WinForms.Button mobjButtonHide;
        private WinForms.CheckedListBox mobjListItems;

        /// <summary>
        /// Occurs when an item is selected
        /// </summary>
        public event EventHandler ItemSelected;

        /// <summary>
        /// Occurs when an item is checked
        /// </summary>
        public event WinForms.ItemCheckEventHandler ItemCheck;


        #endregion Class Members

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
            this.mobjListItems = new System.Windows.Forms.CheckedListBox();
            this.mobjPanelButtons = new System.Windows.Forms.Panel();
            this.mobjButtonHide = new System.Windows.Forms.Button();
            this.mobjButtonShow = new System.Windows.Forms.Button();
            this.mobjButtonMoveDown = new System.Windows.Forms.Button();
            this.mobjButtonMoveUp = new System.Windows.Forms.Button();
            this.mobjPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjListItems
            // 
            this.mobjListItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mobjListItems.Location = new System.Drawing.Point(0, 0);
            this.mobjListItems.Name = "mobjListItems";
            this.mobjListItems.Size = new System.Drawing.Size(821, 454);
            this.mobjListItems.TabIndex = 0;
            // 
            // mobjPanelMove
            // 
            this.mobjPanelButtons.Controls.Add(this.mobjButtonHide);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonShow);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonMoveDown);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonMoveUp);
            this.mobjPanelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.mobjPanelButtons.Location = new System.Drawing.Point(710, 0);
            this.mobjPanelButtons.Name = "mobjPanelButtons";
            this.mobjPanelButtons.Size = new System.Drawing.Size(111, 454);
            this.mobjPanelButtons.TabIndex = 1;
            // 
            // mobjButtonHide
            // 
            this.mobjButtonHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjButtonHide.Location = new System.Drawing.Point(4, 87);
            this.mobjButtonHide.Name = "mobjButtonHide";
            this.mobjButtonHide.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonHide.TabIndex = 3;
            this.mobjButtonHide.Text = "Hide";
            // 
            // mobjButtonShow
            // 
            this.mobjButtonShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjButtonShow.Location = new System.Drawing.Point(4, 58);
            this.mobjButtonShow.Name = "mobjButtonShow";
            this.mobjButtonShow.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonShow.TabIndex = 2;
            this.mobjButtonShow.Text = "Show";
            // 
            // mobjButtonMoveDown
            // 
            this.mobjButtonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjButtonMoveDown.Location = new System.Drawing.Point(4, 29);
            this.mobjButtonMoveDown.Name = "mobjButtonMoveDown";
            this.mobjButtonMoveDown.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonMoveDown.TabIndex = 1;
            this.mobjButtonMoveDown.Text = "Move Down";
            // 
            // mobjButtonMoveUp
            // 
            this.mobjButtonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mobjButtonMoveUp.Location = new System.Drawing.Point(4, 0);
            this.mobjButtonMoveUp.Name = "mobjButtonMoveUp";
            this.mobjButtonMoveUp.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonMoveUp.TabIndex = 0;
            this.mobjButtonMoveUp.Text = "Move Up";
            // 
            // Form1
            //             
            this.Controls.Add(this.mobjPanelButtons);
            this.Controls.Add(this.mobjListItems);
            this.Size = new System.Drawing.Size(320, 190);
            this.Name = "ItemChooser";
            this.mobjPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
