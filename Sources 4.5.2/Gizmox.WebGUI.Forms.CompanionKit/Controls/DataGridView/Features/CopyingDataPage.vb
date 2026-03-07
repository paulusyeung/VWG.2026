Namespace CompanionKit.Controls.DataGridView.Features

	Public Class CopyingDataPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()


		End Sub

        Private Sub FrozenColumnsAndRowsPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up the DataGridView.
            Dim i As Integer
            For i = 0 To 18
                Me.mobjUserDS.Users.AddUsersRow(String.Format("User{0}", i), String.Format("user{0}@gmail.com", i), _
                       String.Format("8-800-236589{0}", i), "Franklin", _
                       String.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064")
            Next i
            Me.mobjDataGridView.Rows.Item(0).Frozen = True

        End Sub
	End Class

End Namespace