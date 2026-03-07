Imports System.Reflection

Namespace CompanionKit.Controls.DataGridView.Features

	Public Class ExportingDataPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
		End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl
        ''' Fills adapter for DataGridView control.
        ''' </summary>
        Private Sub ExportingDataPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub

        ''' <summary>
        ''' Handles Click event of the Button that exports data from DatagridViw to Excel
        ''' </summary>
        Private Sub mobjExportToExcel_Click(sender As Object, e As EventArgs) Handles mobjExportToExcel.Click
            Dim mstrListSeparator As String = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator
            Dim mobjStrBuilder As New System.Text.StringBuilder()

            'Add name of headers in the content
            Dim marrOfStrings As String() = New [String](Me.mobjDataGridView.Columns.Count - 1) {}
            For i As Integer = 0 To Me.mobjDataGridView.Columns.Count - 1
                marrOfStrings(i) = Me.mobjDataGridView.Columns(i).HeaderText
                marrOfStrings(i) = GetWriteableValue(marrOfStrings(i))
            Next

            mobjStrBuilder.Append(String.Join(mstrListSeparator, marrOfStrings))
            mobjStrBuilder.Append(Environment.NewLine)

            'Add data of rows in the content.
            For j As Integer = 0 To Me.mobjDataGridView.Rows.Count - 1
                If Me.mobjDataGridView.Rows(j).IsNewRow Then
                    Continue For
                End If
                Dim marrOfData As String() = New [String](Me.mobjDataGridView.Columns.Count - 1) {}
                For i As Integer = 0 To Me.mobjDataGridView.Columns.Count - 1
                    Dim o As Object = Me.mobjDataGridView.Rows(j).Cells(i).Value
                    marrOfData(i) = GetWriteableValue(o)
                Next
                mobjStrBuilder.Append(String.Join(mstrListSeparator, marrOfData))
                mobjStrBuilder.Append(Environment.NewLine)
            Next

            'Download file with DataGridView' content
            Dim mobjDownloadGateway As New FileDownloadGateway()
            mobjDownloadGateway.Filename = "ExportData.csv"
            mobjDownloadGateway.DownloadAsAttachment = True
            mobjDownloadGateway.SetContentType(DownloadContentType.OctetStream)
            mobjDownloadGateway.StartStringDownload(Me, mobjStrBuilder.ToString())


        End Sub

        ''' <summary>
        ''' Returns string that represents exported object in th excel.
        ''' </summary>
        ''' <param name="o">exported object</param>
        ''' <returns>string that represents exported object in th excel</returns>
        Public Shared Function GetWriteableValue(o As Object) As String
            If o Is Nothing OrElse o = Convert.DBNull Then
                Return ""
            ElseIf o.ToString().IndexOf(",") = -1 Then
                Return o.ToString()
            Else
                Return """" + o.ToString() + """"
            End If
        End Function
	End Class

End Namespace
