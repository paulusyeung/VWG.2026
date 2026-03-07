Namespace CompanionKit.Controls.MessageBoxControl.Functionality

    Public Class MessageBoxTextCaptionPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjShowButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjShowButton.Click
            ' Show MessageBox with custom caption, text, handler and modal mask set
            MessageBox.Show(Me.mobjText.Text, Me.mobjCaptionText.Text, MessageBoxButtons.OKCancel, New EventHandler(AddressOf Me.MessageBoxHandler), Me.mobjShowModalMask.Checked)
        End Sub

        ''' <summary>
        ''' These event handler calls when MessageBox windows closed
        ''' </summary>
        Private Sub MessageBoxHandler(ByVal sender As Object, ByVal e As EventArgs)
            ' Get Gizmox.WebGUI.Forms.Form object that called MessageBox
            Dim senderForm As Gizmox.WebGUI.Forms.Form = DirectCast(sender, Gizmox.WebGUI.Forms.Form)

            If (Not senderForm Is Nothing) Then
                ' Set DialogResult value of the Form as a text for label
                Me.mobjResultLbl.Text = String.Format("Dialog result value: ""{0}""", senderForm.DialogResult)
            End If
        End Sub

    End Class

End Namespace