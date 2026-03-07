Namespace CompanionKit.Controls.ComboBox.PopulatingData

	Public Class CollectionDataSourcePage

        Public Sub New()
            InitializeComponent()
            'Set collection of customer as DataSource.
            Me.mobjComboBox.DataSource = Utils.CustomerData.GetCustomers()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'Update text of represented TextBoxes with Value and Name of selected item.
            If Me.mobjComboBox.SelectedValue IsNot Nothing Then
                Me.mobjValueTextBox.Text = Me.mobjComboBox.SelectedValue.ToString()
            End If
            Me.mobjNameTextBox.Text = Me.mobjComboBox.Text
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
        ''' Handles the TextChanged event of the mobjDataTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjDataTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjDataTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjDataTextBox.Text) Then
                For Each mobjItem As Utils.Customer In mobjComboBox.Items
                    If mobjItem.FullName = mobjDataTextBox.Text Then
                        mobjComboBox.SelectedItem = mobjItem
                    End If
                Next
            End If
        End Sub
	End Class

End Namespace