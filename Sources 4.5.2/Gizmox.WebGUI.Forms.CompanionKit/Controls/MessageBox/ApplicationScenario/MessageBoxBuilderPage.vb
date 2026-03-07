Namespace CompanionKit.Controls.MessageBoxControl.ApplicationScenario

    Public Class MessageBoxBuilderPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Fill ComboBox.Items collection with MessageBoxButtons enumerator values
            Me.mobjComboButtons.Items.AddRange(System.Enum.GetValues(GetType(MessageBoxButtons)))
            ' Fill ComboBox.Items collection with MessageBoxIcon enumerator values
            Me.mobjComboIcon.Items.AddRange(System.Enum.GetValues(GetType(MessageBoxIcon)))
            ' Set SelectedIndex property values for ComboBox controls
            Me.mobjComboButtons.SelectedIndex = 0
            Me.mobjComboIcon.SelectedIndex = 0

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonShow control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjButtonShow.Click
            ' Show MessageBox window with custom caption, message text, buttons, icon and handler
            MessageBox.Show(Me.mobjTextMessage.Text, Me.mobjTextTitle.Text, DirectCast(Me.mobjComboButtons.SelectedItem, MessageBoxButtons), DirectCast(Me.mobjComboIcon.SelectedItem, MessageBoxIcon), New EventHandler(AddressOf Me.objMessageBox_Closed))
        End Sub

        ''' <summary>
        ''' These event handler calls when MessageBox windows closed
        ''' </summary>
        Private Sub objMessageBox_Closed(ByVal sender As Object, ByVal e As EventArgs)
            ' Show the button pressed using another MessageBox window
            MessageBox.Show(("You pressed button: " & DirectCast(sender, MessageBoxWindow).DialogResult.ToString), "MessageBox Result")
        End Sub

    End Class

End Namespace