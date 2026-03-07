using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.CompanionKit.UI;
using System.Drawing;
using Gizmox.WebGUI.Forms.VisualEffects;

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    partial class ThemesBrowser
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
            this.mobjThemesSelectionList = new MainDeviceListView();
            this.mobjTitleLabel = new Label();
            this.SuspendLayout();

            this.mobjTitleLabel.Dock = DockStyle.Top;
            this.mobjTitleLabel.Text = "Select a Theme";
            this.mobjTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.mobjTitleLabel.Height = 50;
            // 
            // mainDeviceListView1
            // 
            this.mobjThemesSelectionList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;            
            this.mobjThemesSelectionList.Location = new System.Drawing.Point(0, 0);
            this.mobjThemesSelectionList.Name = "mainDeviceListView1";
            this.mobjThemesSelectionList.View = View.LargeIcon;
            this.mobjThemesSelectionList.LargeImageList = new ImageList();
            this.mobjThemesSelectionList.LargeImageList.ImageSize = new Size(101, 150);
            this.mobjThemesSelectionList.TabIndex = 0;            
            // 
            // ThemesBrowser
            // 
            this.Controls.Add(this.mobjThemesSelectionList);
            this.Controls.Add(this.mobjTitleLabel);
            this.ResumeLayout(false);

        }

        protected override void RenderAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
        }

        #endregion

        private MainDeviceListView mobjThemesSelectionList;
        private Label mobjTitleLabel;


    }
}