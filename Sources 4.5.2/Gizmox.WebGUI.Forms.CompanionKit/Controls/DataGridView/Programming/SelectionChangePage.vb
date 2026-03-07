Namespace CompanionKit.Controls.DataGridView.Programming

	Public Class SelectionChangePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

		Private Sub SelectionChangePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'Fill up DataGridView
			Dim i As Integer
			For i = 1 To 19
                Me.mobjUserDS.Users.AddUsersRow(String.Format("User{0}", i), _
                                            String.Format("user{0}@gmail.com", i), _
                                            String.Format("8-800-236589{0}", i), "Franklin", _
                                            String.Format("10{0} Murfreeboro Rd.", i), "USA", _
                                            "Tennessee", "37064")
			Next i

		End Sub

        ''' <summary>
        ''' Handles SelectionChanged event for the DataGridView.
        ''' Builds the string with the indexes of the selected cells 
        ''' and displays it in the informed label.
        ''' </summary>
        Private Sub mobjDataGridView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjDataGridView.SelectionChanged
            Dim mobjStringBuilder As New Text.StringBuilder("You are select the following cells: ")
            Dim i As Integer
            For i = 0 To Me.mobjDataGridView.SelectedCells.Count - 1
                Dim mobjCell As DataGridViewCell = Me.mobjDataGridView.SelectedCells.Item(i)
                If (i = 0) Then
                    mobjStringBuilder.Append(String.Format("[{0},{1}]", mobjCell.RowIndex, mobjCell.ColumnIndex))
                Else
                    mobjStringBuilder.Append(String.Format(", [{0},{1}]", mobjCell.RowIndex, mobjCell.ColumnIndex))
                End If
            Next i
            mobjStringBuilder.Append(".")
            Me.mobjInformedLabel.Text = mobjStringBuilder.ToString

        End Sub
	End Class

End Namespace