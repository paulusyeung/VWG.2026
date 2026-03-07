using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Microsoft.Reporting.WebForms;

namespace CompanionKit.Concepts.AspNetWrappers.ReportViewer
{
    partial class ReportViewerPage
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
            this.mobjReportViewer = new Gizmox.WebGUI.Reporting.ReportViewer();
            this.SuspendLayout();
            // 
            // mobjReportViewer
            // 
            this.mobjReportViewer.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjReportViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjReportViewer.Name = "mobjReportViewer";

            this.mobjReportViewer.Size = new System.Drawing.Size(602, 602);
            this.mobjReportViewer.TabIndex = 0;
            this.mobjReportViewer.HostedPageLoad += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(mobjReportViewer_HostedPageLoad);
            this.mobjReportViewer.Search += new SearchEventHandler(mobjReportViewer_Search);
            // 
            // ReportViewerPage
            // 
            this.Controls.Add(this.mobjReportViewer);
            this.Size = new System.Drawing.Size(391, 600);
            this.Text = "ReportViewerPage";

        }

        #endregion
        private Gizmox.WebGUI.Reporting.ReportViewer mobjReportViewer;

    }
}