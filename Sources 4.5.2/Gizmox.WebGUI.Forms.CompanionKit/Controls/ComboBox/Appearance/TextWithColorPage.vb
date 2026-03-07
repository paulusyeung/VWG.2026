Namespace CompanionKit.Controls.ComboBox.Appearance

	Public Class TextWithColorPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

			'Set collection of customer as DataSource.
            Me.mobjComboBox.DataSource = Utils.CustomerData.GetCustomers()
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
        ''' Handles the TextChanged event of the mobjColorMemberTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjColorMemberTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjColorMemberTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjColorMemberTextBox.Text) Then
                Try
                    mobjComboBox.ColorMember = mobjColorMemberTextBox.Text
                Catch ex As Exception
                    mobjErrorProvider.SetError(mobjColorMemberTextBox, ex.Message)
                Finally
                    mobjColorMemberTextBox.Text = mobjComboBox.ColorMember
                End Try
            End If
        End Sub
	End Class

End Namespace