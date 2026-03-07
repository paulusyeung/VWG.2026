Namespace CompanionKit.Controls.ComboBox.PopulatingData

	Public Class DatabaseDataSourcePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the comboBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            If Me.mobjComboBox.SelectedValue IsNot Nothing Then
                'Update TextBox that represents selected of ComboBox
                Me.mobjValueTextBox.Text = Me.mobjComboBox.SelectedValue.ToString()
            End If
            'Update TextBox that represents text of ComboBox
            Me.mobjNameTextBox.Text = Me.mobjComboBox.Text
        End Sub

        ''' <summary>
        ''' Handles the Load event of the DatabaseDataSourcePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub DatabaseDataSourcePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Fill up adapter with data form Customers table of DataBase
            Me.mobjCustomersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the comboBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjComboBox_TextChanged(sender As Object, e As EventArgs) Handles mobjComboBox.TextChanged
            'Update TextBox that represents text of ComboBox
            Me.mobjNameTextBox.Text = Me.mobjComboBox.Text
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjValueMemberTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjValueMemberTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjValueTextBox.TextChanged
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
                For Each mobjItem As System.Data.DataRowView In mobjComboBox.Items
                    If mobjItem.Row.ItemArray(2).ToString() = mobjDataTextBox.Text Then
                        mobjComboBox.SelectedItem = mobjItem
                    End If
                Next
            End If
        End Sub

	End Class

End Namespace