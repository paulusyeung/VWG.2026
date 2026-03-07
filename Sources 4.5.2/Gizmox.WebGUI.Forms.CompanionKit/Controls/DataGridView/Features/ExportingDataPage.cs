#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.DataGridView.Features
{

    public partial class ExportingDataPage : UserControl
    {
        public ExportingDataPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the example' UserControl
        /// Fills adapter for DataGridView control.
        /// </summary>
        private void ExportingDataPage_Load(object sender, EventArgs e)
        {
            this.mobjCustomersTableAdapter.Fill(this.mobjNorthwindDataSet.Customers);
        }

        /// <summary>
        /// Handles Click event of the Button that exports data from DatagridViw to Excel
        /// </summary>
        private void mobjExportToExcel_Click(object sender, EventArgs e)
        {
            string mstrListSeparator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            StringBuilder mobjStrBuilder = new StringBuilder();
            
            //Add name of headers in the content
            string[] marrOfStrings = new String[this.mobjDataGridView.Columns.Count];
            for (int i = 0; i < this.mobjDataGridView.Columns.Count; i++)
            {
                marrOfStrings[i] = this.mobjDataGridView.Columns[i].HeaderText;
                marrOfStrings[i] = GetWriteableValue(marrOfStrings[i]);
            }

            mobjStrBuilder.Append(string.Join(mstrListSeparator, marrOfStrings));
            mobjStrBuilder.Append(Environment.NewLine);

            //Add data of rows in the content.
            for (int j = 0; j < this.mobjDataGridView.Rows.Count; j++)
            {
                if (this.mobjDataGridView.Rows[j].IsNewRow)
                {
                    continue;
                }
                string[] marrOfData = new String[this.mobjDataGridView.Columns.Count];
                for (int i = 0; i < this.mobjDataGridView.Columns.Count; i++)
                {
                    object o = this.mobjDataGridView.Rows[j].Cells[i].Value;
                    marrOfData[i] = GetWriteableValue(o);
                }
                mobjStrBuilder.Append(string.Join(mstrListSeparator, marrOfData));
                mobjStrBuilder.Append(Environment.NewLine);
            }
           
            //Download file with DataGridView' content
            FileDownloadGateway mobjDownloadGateway = new FileDownloadGateway();
            mobjDownloadGateway.Filename = "ExportData.csv";
            mobjDownloadGateway.DownloadAsAttachment = true;
            mobjDownloadGateway.SetContentType(DownloadContentType.OctetStream);
            mobjDownloadGateway.StartStringDownload(this, mobjStrBuilder.ToString());

            
        }

        /// <summary>
        /// Returns string that represents exported object in th excel.
        /// </summary>
        /// <param name="o">exported object</param>
        /// <returns>string that represents exported object in th excel</returns>
        public static string GetWriteableValue(object o)
        {
            if (o == null || o == Convert.DBNull)
            {
                return "";
            }
            else if (o.ToString().IndexOf(",") == -1)
            {
                return o.ToString();
            }
            else
            {
                return "\"" + o.ToString() + "\"";
            }
        }
     
    }
}
