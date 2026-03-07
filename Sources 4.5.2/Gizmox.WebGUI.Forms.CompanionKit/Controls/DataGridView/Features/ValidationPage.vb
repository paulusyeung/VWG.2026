Namespace CompanionKit.Controls.DataGridView.Features

	Public Class ValidationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub ValidationPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up the DataGridView.
            Dim i As Integer
            For i = 1 To 19
                Me.mobjUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), _
                       String.Format("8-800-236589{0}", i), "Franklin", _
                       String.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064")
            Next i
        End Sub

        ''' <summary>
        ''' Handles CellValidating event of the DataGRidView.
        ''' Validates whether enter values isn't null or empty .
        ''' and validates whether entered values in Phone or Email columns are matches with correct format.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub mobjDataGridView_CellValidating(ByVal sender As System.Object, ByVal e As Global.Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs) Handles mobjDataGridView.CellValidating

            Dim formattedValue As String = TryCast(e.FormattedValue, String)
            If String.IsNullOrEmpty(formattedValue) Then
                MessageBox.Show("Please enter value!")
                e.Cancel = True
            ElseIf Not (Not Me.mobjDataGridView.Columns.Item(e.ColumnIndex).DataPropertyName.Equals("UserPhone") _
      OrElse System.Text.RegularExpressions.Regex.IsMatch(formattedValue, "^\d{1}-\d{3}-\d{7}$")) Then
                MessageBox.Show("Please enter phone in format: X-XXX-XXXXXXX!")
                e.Cancel = True
            ElseIf Not (Not Me.mobjDataGridView.Columns.Item(e.ColumnIndex).DataPropertyName.Equals("UserEmail") _
      OrElse System.Text.RegularExpressions.Regex.IsMatch(formattedValue, "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")) Then
                MessageBox.Show("Please enter correct user e-mail!")
                e.Cancel = True
            End If

        End Sub
	End Class

End Namespace