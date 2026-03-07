Namespace CompanionKit.Controls.DataGridView.PopulatingData

    Public Class FilteringPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Fill up table adapter with data from table
            Me.customersTableAdapter.Fill(Me.northwindDataSet.Customers)

        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjMaxFilterNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMaxFilterNUD_ValueChanged(sender As System.Object, e As System.EventArgs) Handles mobjMaxFilterNUD.ValueChanged
            'Define MaxFilterOptions value
            mobjDGV.MaxFilterOptions = Convert.ToInt32(mobjMaxFilterNUD.Value)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjFilterHeadersRB control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjFilterHeadersRB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjFilterHeadersRB.CheckedChanged
            'Clear all DGV filters
            mobjDGV.ClearAllFilters()

            'Show or hide filter row, MaxFilterOptions label and NumericUpDown
            mobjDGV.ShowFilterRow = mobjFilterRowRB.Checked
            mobjMaxFilterLbl.Visible = mobjFilterRowRB.Checked
            mobjMaxFilterNUD.Visible = mobjFilterRowRB.Checked

            'If Filters in headers are chosen
            If mobjFilterHeadersRB.Checked Then
                'Define MaxFilterOptions value
                mobjDGV.MaxFilterOptions = 1000

                'Create filters in headers - simple for three columns and custom for one 'Region' column
                Dim CustomerIDInfo As New HeaderFilterInfo("CustomerID", False)
                mobjDGV.HeadersFilterInfo.Add(CustomerIDInfo)
                Dim CompanyNameInfo As New HeaderFilterInfo("CompanyName", False)
                mobjDGV.HeadersFilterInfo.Add(CompanyNameInfo)
                Dim ContactNameInfo As New HeaderFilterInfo("ContactName", False)
                mobjDGV.HeadersFilterInfo.Add(ContactNameInfo)
                Dim RegionInfo As New HeaderFilterInfo("Region", True)
                mobjDGV.HeadersFilterInfo.Add(RegionInfo)

                'Define Info Label text

                mobjInfoLabel.Text = "Filter values by column using filters in headers of first 3 columns. Click custom filter in header of 'Region' column and then 'YES' to clear all filters in DataGridView (CustomHeaderFilterClicked event is fired)."
            Else
                'If Filter row is chosen
                'Define MaxFilterOptions value
                mobjDGV.MaxFilterOptions = Convert.ToInt32(mobjMaxFilterNUD.Value)
                'Clear filters in headers
                mobjDGV.HeadersFilterInfo.Clear()
                'Define Info Label text
                mobjInfoLabel.Text = "Use FilterRow to filter values by column in DataGridView."
            End If
        End Sub

        ''' <summary>
        ''' Handles the CustomHeaderFilterClicked event of the mobjDGV control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs"/> instance containing the event data.</param>
        Private Sub mobjDGV_CustomHeaderFilterClicked(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs) Handles mobjDGV.CustomHeaderFilterClicked
            'Show Message if Custom filter in header is clicked
            MessageBox.Show("Clear all filters?", "Confirm", MessageBoxButtons.YesNo, AddressOf message_Closed)
        End Sub

        ''' <summary>
        ''' Handles the Closed event of the message control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub message_Closed(sender As Object, e As EventArgs)
            'If user confirms clearing all filters
            If DirectCast(sender, Gizmox.WebGUI.Forms.Form).DialogResult = DialogResult.Yes Then
                mobjDGV.ClearAllFilters()
            End If
        End Sub
    End Class

End Namespace