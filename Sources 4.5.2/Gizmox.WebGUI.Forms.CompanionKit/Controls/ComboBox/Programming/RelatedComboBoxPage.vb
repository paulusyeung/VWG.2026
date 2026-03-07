Namespace CompanionKit.Controls.ComboBox.Programming

	Public Class RelatedComboBoxPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub


        ''' <summary>
        ''' Handles the Load event of the RelatedComboBoxPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub RelatedComboBoxPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Fill up ComboBoxes' adapters with data form according tables of DataBase
            Me.customersTableAdapter.Fill(Me.mobjNorthwindDataSet.Customers)
            Me.ordersTableAdapter.Fill(Me.mobjNorthwindDataSet.Orders)
            Me.order_DetailsTableAdapter.Fill(Me.mobjNorthwindDataSet.Order_Details)
            Me.mobjPricesTextBox.Validator = TextBoxValidation.FloatValidator
            Me.mobjIDTextBox.Validator = TextBoxValidation.IntegerValidator
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the comboBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCustomerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjCustomerComboBox.SelectedIndexChanged
            'Remove Filter from 'Orders' DataSources.
            Me.mobjSecondBindingSource.RemoveFilter()
            If Me.mobjCustomerComboBox.SelectedValue IsNot Nothing Then
                'Set Filter for 'Orders' DataSources that it contains orders only of selected customer.
                Me.mobjSecondBindingSource.Filter = String.Format("CustomerID='{0}'", Me.mobjCustomerComboBox.SelectedValue.ToString())
            End If
        End Sub
        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the comboBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIDComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjIDComboBox.SelectedIndexChanged
            'Remove Filter from 'Order Details' DataSources.
            Me.mobjThirdBindingSource.RemoveFilter()
            If Me.mobjIDComboBox.SelectedValue IsNot Nothing Then
                'Set Filter for 'Order Details' DataSources that it contains records only of selected customer order.
                Me.mobjThirdBindingSource.Filter = String.Format("OrderID='{0}'", Me.mobjIDComboBox.SelectedValue.ToString())
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjCustomersTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCustomersTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjCustomersTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjCustomersTextBox.Text) Then
                For Each mobjItem As System.Data.DataRowView In mobjCustomerComboBox.Items
                    If mobjItem.Row.ItemArray(2).ToString() = mobjCustomersTextBox.Text Then
                        mobjCustomerComboBox.SelectedItem = mobjItem
                    End If
                Next
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjIDTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjIDTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjIDTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjIDTextBox.Text) Then
                For Each mobjItem As System.Data.DataRowView In mobjIDComboBox.Items
                    If mobjItem.Row.ItemArray(0).ToString() = mobjIDTextBox.Text Then
                        mobjIDComboBox.SelectedItem = mobjItem
                    End If
                Next
            End If
        End Sub

        ''' <summary>
        ''' Handles the TextChanged event of the mobjPricesTextBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjPricesTextBox_TextChanged(sender As Object, e As EventArgs) Handles mobjPricesTextBox.TextChanged
            If Not String.IsNullOrEmpty(mobjPricesTextBox.Text) Then
                For Each mobjItem As System.Data.DataRowView In mobjPriceComboBox.Items
                    If mobjItem.Row.ItemArray(2).ToString() = mobjPricesTextBox.Text Then
                        mobjPriceComboBox.SelectedItem = mobjItem
                    End If
                Next
            End If
        End Sub
	End Class

End Namespace