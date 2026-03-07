Namespace CompanionKit.Controls.MaskedTextBox.Features

	Public Class MaskPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Load event of the MaskPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub MaskPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.mobjMaskComboBox.DataSource = System.Enum.GetValues(GetType(TextMaskFormatPage.Masks))

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjMaskComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMaskComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjMaskComboBox.SelectedIndexChanged
            Select Case DirectCast(Me.mobjMaskComboBox.SelectedItem, TextMaskFormatPage.Masks)
                Case TextMaskFormatPage.Masks.Numeric
                    Me.mobjMaskedTextBox.Mask = "00000"
                    Exit Select
                Case TextMaskFormatPage.Masks.PhoneNumber
                    Me.mobjMaskedTextBox.Mask = "(999) 000-0000"
                    Exit Select
                Case TextMaskFormatPage.Masks.PhoneNumberNoAreaCode
                    Me.mobjMaskedTextBox.Mask = "000-0000"
                    Exit Select
                Case TextMaskFormatPage.Masks.ShortDate
                    Me.mobjMaskedTextBox.Mask = "00/00/0000"
                    Exit Select
                Case TextMaskFormatPage.Masks.ShortDateAndTimeUS
                    Me.mobjMaskedTextBox.Mask = "00/00/0000 90:00"
                    Exit Select
                Case TextMaskFormatPage.Masks.SocialSecurityNumber
                    Me.mobjMaskedTextBox.Mask = "000-00-0000"
                    Exit Select
                Case TextMaskFormatPage.Masks.TimeEuropean
                    Me.mobjMaskedTextBox.Mask = "00:00"
                    Exit Select
                Case TextMaskFormatPage.Masks.TimeUS
                    Me.mobjMaskedTextBox.Mask = "90:00"
                    Exit Select
                Case TextMaskFormatPage.Masks.ZipCode
                    Me.mobjMaskedTextBox.Mask = "00000-9999"
                    Exit Select
            End Select

        End Sub
    End Class

End Namespace