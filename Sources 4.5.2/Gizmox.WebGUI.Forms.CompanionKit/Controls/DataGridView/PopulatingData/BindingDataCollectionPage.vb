Imports Gizmox.WebGUI.Common.Resources
Namespace CompanionKit.Controls.DataGridView.PopulatingData

	Public Class BindingDataCollectionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

            ' Get ResourceHandle for photo of customer.
            Dim mobjPhotoResource As ResourceHandle = New ImageResourceHandle("32x32.Photo.png")
            ' Set objects collection as DataSource for ComboBox.
            Me.mobjDataGridView.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomersWithImage(mobjPhotoResource)


		End Sub

        Private Sub mobjDataGridView_CellValidating(ByVal objSender As System.Object, ByVal objEventArgs As Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs) Handles mobjDataGridView.CellValidating
            ' Gets the column header text
            Dim strHeaderText As String = Me.mobjDataGridView.Columns(objEventArgs.ColumnIndex).HeaderText

            ' Abort validation if cell is not in the CompanyName column
            If Not strHeaderText.Equals("FavoriteColor") Then
                Return
            End If

            ' Get color from inputted name
            Dim objNewColor As System.Drawing.Color = System.Drawing.Color.FromName(objEventArgs.FormattedValue.ToString())
            ' Check if the inputted color is a known (valid) color
            If Not (objNewColor.IsKnownColor) Then
                ' Show error text on the grid row
                Me.mobjDataGridView.Rows(objEventArgs.RowIndex).ErrorText = "Cell must contain a valid color name"
                ' Cancel the value change
                objEventArgs.Cancel = True
            End If
        End Sub

        Private Sub mobjDataGridView_CellEndEdit(ByVal objSender As System.Object, ByVal objEventArgs As Gizmox.WebGUI.Forms.DataGridViewCellEventArgs) Handles mobjDataGridView.CellEndEdit
            ' Clear the row error in case the user enters a valid value.
            Me.mobjDataGridView.Rows(objEventArgs.RowIndex).ErrorText = [String].Empty
        End Sub
    End Class

End Namespace