Namespace CompanionKit.Controls.TextBox.Functionality

	Public Class ValidatorPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			' Set validator for demo TexBoxt that it will allow to enter only number, '.' or '_' 
            Me.mobjTextBox.Validator = New TextBoxValidation("", "", String.Concat(New String() {"0-9\.\-"}))

		End Sub
	End Class

End Namespace