using System;
using Gizmox.WebGUI.Common.Resources;
namespace CompanionKit.Controls.ListView.Features
{
    partial class ItemPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
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
            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
            this.mobjColumnImportant = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnOpened = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnAttached = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnSubject = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnFrom = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnReceived = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnSize = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.mobjColumnControl = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // mobjListView
            // 
            this.mobjListView.AccessibleDescription = "";
            this.mobjListView.AccessibleName = "";
            this.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.mobjColumnImportant,
            this.mobjColumnOpened,
            this.mobjColumnAttached,
            this.mobjColumnSubject,
            this.mobjColumnFrom,
            this.mobjColumnReceived,
            this.mobjColumnSize,
            this.mobjColumnControl});
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.Location = new System.Drawing.Point(3, 3);
            this.mobjListView.Name = "mobjListView";
            this.mobjListView.Size = new System.Drawing.Size(822, 426);
            this.mobjListView.TabIndex = 0;
            this.mobjListView.UseInternalPaging = true;
            // 
            // mobjColumnImportant
            // 
            this.mobjColumnImportant.Text = "";
            this.mobjColumnImportant.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.mobjColumnImportant.Width = 20;
            // 
            // mobjColumnOpened
            // 
            this.mobjColumnOpened.Text = "";
            this.mobjColumnOpened.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.mobjColumnOpened.Width = 20;
            // 
            // mobjColumnAttached
            // 
            this.mobjColumnAttached.Text = "Action";
            this.mobjColumnAttached.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.mobjColumnAttached.Width = 20;
            // 
            // mobjColumnSubject
            // 
            this.mobjColumnSubject.Text = "Subject";
            this.mobjColumnSubject.Width = 250;
            // 
            // mobjColumnFrom
            // 
            this.mobjColumnFrom.Text = "From";
            this.mobjColumnFrom.Width = 150;
            // 
            // mobjColumnReceived
            // 
            this.mobjColumnReceived.Text = "Received";
            this.mobjColumnReceived.Width = 150;
            // 
            // mobjColumnSize
            // 
            this.mobjColumnSize.Text = "Size";
            this.mobjColumnSize.Width = 50;
            // 
            // mobjColumnControl
            // 
            this.mobjColumnControl.PreferedItemHeight = 23;
            this.mobjColumnControl.Text = "";
            this.mobjColumnControl.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control;
            this.mobjColumnControl.Width = 200;
            // 
            // ItemPanel
            // 
            this.Controls.Add(this.mobjListView);
            this.DockPadding.All = 3;
            this.Padding = new Gizmox.WebGUI.Forms.Padding(3);
            this.Size = new System.Drawing.Size(800, 400);
            this.Text = "ItemPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView mobjListView;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnFrom;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSubject;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnReceived;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSize;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnImportant;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnOpened;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnAttached;
        private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnControl;


	}
}