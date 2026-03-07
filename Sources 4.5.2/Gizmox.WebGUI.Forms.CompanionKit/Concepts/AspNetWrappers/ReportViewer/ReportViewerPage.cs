#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Microsoft.Reporting.WebForms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace CompanionKit.Concepts.AspNetWrappers.ReportViewer
{
    public partial class ReportViewerPage : UserControl
    {
        //Define report data
        private static DataTable mobjReportData = null;

        public ReportViewerPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the HostedPageLoad event of the mobjReportViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs"/> instance containing the event data.</param>
        void mobjReportViewer_HostedPageLoad(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            //Get Current static Context
            System.Web.HttpContext objHttpContext = System.Web.HttpContext.Current;

            if (objHttpContext != null && objHttpContext.Request != null)
            {
                if (objHttpContext.Request.RequestType == "GET")
                {
                    this.mobjReportViewer.ProcessingMode = ProcessingMode.Local;
                    //Define ReportPath property according to the .NET version
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                    this.mobjReportViewer.LocalReport.ReportPath = @"Resources\UserData\Report.rdlc";
#else
                    this.mobjReportViewer.LocalReport.ReportPath = @"Resources\UserData\Report.rdl";
#endif
                    //Add data source
                    this.mobjReportViewer.LocalReport.DataSources.Clear();
                    this.mobjReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Sales", LoadSalesData(this.Context)));
                }
            }
        }

        /// <summary>
        /// Handles the Search event of the mobjReportViewer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SearchEventArgs"/> instance containing the event data.</param>
        void mobjReportViewer_Search(object sender, SearchEventArgs e)
        {
            MessageBox.Show(e.SearchString);
        }

        //Define DataTable from Report.xml
        private static DataTable LoadSalesData(IContext objContext)
        {
            if (mobjReportData == null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(objContext.Server.MapPath(@"~\Resources\UserData\Report.xml"));
                mobjReportData = dataSet.Tables[0];
            }
            return mobjReportData;
        }

    }
}