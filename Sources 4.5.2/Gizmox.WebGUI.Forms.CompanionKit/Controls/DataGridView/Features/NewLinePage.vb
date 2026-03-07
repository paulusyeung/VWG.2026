Namespace CompanionKit.Controls.DataGridView.Features

	Public Class NewLinePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        Private Sub NewLinePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Fill up the DataGridView.
            Dim i As Integer
			For i = 1 To 10
                Me.mobjUserDS.Users.AddUsersRow( _
    String.Format("User{0}", i), _
    String.Format("user{0}@gmail.com", i), _
    String.Format("8-800-236589{0}", i), _
    "Franklin", _
    String.Format("10{0} Murfreeboro Rd.", i), _
    "USA", _
    "Tennessee", _
    "37064")
			Next i
        End Sub
	End Class

End Namespace