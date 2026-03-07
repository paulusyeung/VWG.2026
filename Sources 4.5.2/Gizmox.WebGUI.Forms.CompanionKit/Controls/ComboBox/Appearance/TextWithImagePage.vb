Namespace CompanionKit.Controls.ComboBox.Appearance

	Public Class TextWithImagePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Get ResourceHandle for photo of customer.
			Dim photoResource As Gizmox.WebGUI.Common.Resources.ResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("32x32.Photo.png")
			'Set objects collection as DataSource for ComboBox.
            Me.mobjComboBox.DataSource = Global.CompanionKit.Controls.Utils.CustomerData.GetCustomersWithImage(photoResource)

        End Sub


        ''' <summary>
        ''' Handles the TextChanged event of the mobjDisplayMemberTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjDisplayMemberTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjDisplayMemberTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjDisplayMemberTextBox.Text) Then
                Try
                    mobjComboBox.DisplayMember = mobjDisplayMemberTextBox.Text
                Catch ex As Exception
                    mobjErrorProvider.SetError(mobjDisplayMemberTextBox, ex.Message)
                Finally
                    mobjDisplayMemberTextBox.Text = mobjComboBox.DisplayMember
                End Try
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjValueMemberTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjValueMemberTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjValueMemberTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjValueMemberTextBox.Text) Then
                Try
                    mobjComboBox.ValueMember = mobjValueMemberTextBox.Text
                Catch ex As Exception
                    mobjErrorProvider.SetError(mobjValueMemberTextBox, ex.Message)
                Finally
                    mobjValueMemberTextBox.Text = mobjComboBox.ValueMember
                End Try
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjImageMemberTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjImageMemberTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjImageMemberTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjImageMemberTextBox.Text) Then
                Try
                    mobjComboBox.ImageMember = mobjImageMemberTextBox.Text
                Catch ex As Exception
                    mobjErrorProvider.SetError(mobjImageMemberTextBox, ex.Message)
                Finally
                    mobjImageMemberTextBox.Text = mobjComboBox.ImageMember
                End Try
            End If
        End Sub

	End Class

End Namespace