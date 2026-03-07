Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text

Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms
Imports Microsoft.Reporting.WebForms
Imports Gizmox.WebGUI.Common.Interfaces

Namespace CompanionKit.Concepts.AspNetWrappers.ReportViewer

    Public Class ReportViewerPage
        'Define report data
        Private Shared mobjReportData As DataTable = Nothing
        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub
        ''' <summary>
        ''' Handles the HostedPageLoad event of the mobjReportViewer control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs"/> instance containing the event data.</param>
        Private Sub mobjReportViewer_HostedPageLoad(sender As Object, e As Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs) Handles mobjReportViewer.HostedPageLoad
            'Get Current static Context
            Dim objHttpContext As System.Web.HttpContext = System.Web.HttpContext.Current

            If objHttpContext IsNot Nothing AndAlso objHttpContext.Request IsNot Nothing Then
                If objHttpContext.Request.RequestType = "GET" Then
                    Me.mobjReportViewer.ProcessingMode = ProcessingMode.Local
                    'Define ReportPath property according to the .NET version
#If (WG_NETFX = "WG_NET40") OrElse (WG_NETFX = "WG_NET45") OrElse (WG_NETFX = "WG_NET451") OrElse (WG_NETFX = "WG_NET452") OrElse (WG_NETFX = "WG_NET46") Then
                    Me.mobjReportViewer.LocalReport.ReportPath = "Resources\UserData\Report.rdlc"
#Else
                    Me.mobjReportViewer.LocalReport.ReportPath = "Resources\UserData\Report.rdl"
#End If
                    'Add data source
                    Me.mobjReportViewer.LocalReport.DataSources.Clear()
                    Me.mobjReportViewer.LocalReport.DataSources.Add(New ReportDataSource("Sales", LoadSalesData(Me.Context)))
                End If
            End If
        End Sub

        ''' <summary>
        ''' Handles the Search event of the mobjReportViewer control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="SearchEventArgs"/> instance containing the event data.</param>
        Private Sub mobjReportViewer_Search(sender As Object, e As SearchEventArgs) Handles mobjReportViewer.Search
            MessageBox.Show(e.SearchString)
        End Sub

        'Define DataTable from Report.xml
        Private Shared Function LoadSalesData(objContext As IContext) As DataTable
            If mobjReportData Is Nothing Then
                Dim dataSet As New DataSet()
                dataSet.ReadXml(objContext.Server.MapPath("~\Resources\UserData\Report.xml"))
                mobjReportData = dataSet.Tables(0)
            End If
            Return mobjReportData
        End Function

    End Class

End Namespace