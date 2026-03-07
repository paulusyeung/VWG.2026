Namespace CompanionKit.Controls.MaskedTextBox.Features

	Public Class TextMaskFormatPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        Public Enum Masks
            Numeric
            PhoneNumber
            PhoneNumberNoAreaCode
            ShortDate
            ShortDateAndTimeUS
            SocialSecurityNumber
            TimeEuropean
            TimeUS
            ZipCode
        End Enum

        ''' <summary>
        ''' Handles the Load event of the TextMaskFormatPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub TextMaskFormatPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.mobjMaskValuesComboBox.DataSource = System.Enum.GetValues(GetType(Masks))
            Me.mobjTextMaskFormatComboBox.DataSource = System.Enum.GetValues(GetType(MaskFormat))
            Me.UpdateTextOfLabel()
        End Sub

        ''' <summary>
        ''' Updates the text of label.
        ''' </summary>
        Private Sub UpdateTextOfLabel()
            Me.mobjValueOfTextPropertyLabel.Text = String.Format("Value of MaskedTextBox Text property: {0}", Me.mobjMaskedTextBox.Text)
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjMaskValuesComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMaskValuesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjMaskValuesComboBox.SelectedIndexChanged

            Dim selectedMask As Masks = DirectCast(Me.mobjMaskValuesComboBox.SelectedItem, Masks)

            Select Case selectedMask
                Case Masks.Numeric
                    Me.mobjMaskedTextBox.Mask = "00000"
                    Exit Select
                Case Masks.PhoneNumber
                    Me.mobjMaskedTextBox.Mask = "(999) 000-0000"
                    Exit Select
                Case Masks.PhoneNumberNoAreaCode
                    Me.mobjMaskedTextBox.Mask = "000-0000"
                    Exit Select
                Case Masks.ShortDate
                    Me.mobjMaskedTextBox.Mask = "00/00/0000"
                    Exit Select
                Case Masks.ShortDateAndTimeUS
                    Me.mobjMaskedTextBox.Mask = "00/00/0000 90:00"
                    Exit Select
                Case Masks.SocialSecurityNumber
                    Me.mobjMaskedTextBox.Mask = "000-00-0000"
                    Exit Select
                Case Masks.TimeEuropean
                    Me.mobjMaskedTextBox.Mask = "00:00"
                    Exit Select
                Case Masks.TimeUS
                    Me.mobjMaskedTextBox.Mask = "90:00"
                    Exit Select
                Case Masks.ZipCode
                    Me.mobjMaskedTextBox.Mask = "00000-9999"
                    Exit Select
            End Select
            Me.UpdateTextOfLabel()

        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjMaskedTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjMaskedTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjMaskedTextBox.TextChanged
            Me.UpdateTextOfLabel()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjTextMaskFormatComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextMaskFormatComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjTextMaskFormatComboBox.SelectedIndexChanged
            Me.mobjMaskedTextBox.TextMaskFormat = DirectCast(Me.mobjTextMaskFormatComboBox.SelectedItem, MaskFormat)
            Me.UpdateTextOfLabel()
        End Sub
    End Class

End Namespace