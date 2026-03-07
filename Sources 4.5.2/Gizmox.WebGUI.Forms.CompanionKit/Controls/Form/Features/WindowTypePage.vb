Namespace CompanionKit.Controls.Form.Features


	Public Class WindowTypePage

        ''' <summary>
        ''' Represents a shortcut on the Modeless From. 
        ''' </summary>
		Private _modelessForm As WindowTypeForm

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the 'Open modeless form' button.
        ''' Shows the Modeless Form.
        ''' </summary>
        Private Sub mobjOpenModelessFormButton_Click(sender As Object, e As EventArgs) Handles mobjOpenModelessFormButton.Click
            _modelessForm = New WindowTypeForm("Modeless")
            AddHandler _modelessForm.Load, AddressOf modelessForm_Load
            AddHandler _modelessForm.Closed, AddressOf modelessForm_Closed
            _modelessForm.Show()
        End Sub

        ''' <summary>
        ''' Handles Load event of the Modeless From.
        ''' </summary>
        Private Sub modelessForm_Load(sender As Object, e As EventArgs)
            ' Update field that is a shortcut on the Modeless From.
            _modelessForm = TryCast(sender, WindowTypeForm)

            ' Disable button that opens new Modeless Form
            Me.mobjOpenModelessFormButton.Enabled = False

        End Sub

        ''' <summary>
        ''' Handles Closed event of the Modeless Form.
        ''' </summary>
        Private Sub modelessForm_Closed(sender As Object, e As EventArgs)
            ' Reset value of the field that is a shortcut on the Modeless From.
            _modelessForm = Nothing
            ' Enable button that opens new Modeless Form
            Me.mobjOpenModelessFormButton.Enabled = True
        End Sub

        ''' <summary>
        ''' Handles Click event of the 'Open modal form' button.
        ''' Shows the Modal dialog.
        ''' </summary>
        Private Sub mobjOpenModalFormButton_Click(sender As Object, e As EventArgs) Handles mobjOpenModalFormButton.Click
            Dim form As New WindowTypeForm("Modal")
            form.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles Click event of the 'Open popup form' button.
        ''' Shows the Popup Form.
        ''' </summary>
        Private Sub mobjOpenPopupFormButton_Click(sender As Object, e As EventArgs) Handles mobjOpenPopupFormButton.Click
            Dim form As New WindowTypeForm("Popup")
            form.ShowPopup()
        End Sub

        ''' <summary>
        ''' Handles VisibleChanged event of the example UserControl.
        ''' Closes the Modeless Form.
        ''' </summary>
        Private Sub WindowTypePage_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
            If _modelessForm IsNot Nothing Then
                _modelessForm.Close()
            End If
        End Sub
    End Class
End Namespace