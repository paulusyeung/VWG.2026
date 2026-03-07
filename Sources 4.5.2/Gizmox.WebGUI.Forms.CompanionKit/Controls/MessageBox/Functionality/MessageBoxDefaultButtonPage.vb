Namespace CompanionKit.Controls.MessageBoxControl.Functionality

    Public Class MessageBoxDefaultButtonPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the MessageBoxDefaultButtonPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub MessageBoxDefaultButtonPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' // Bind values of the MessageBoxDefaultButton enumerator to ComboBox control
            Me.mobjMessageBoxButtonsCB.DataSource = System.Enum.GetValues(GetType(MessageBoxDefaultButton))
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjShowButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjShowButton.Click
            ' Show MessageBox with the selected default button, handler and modal mask set
            MessageBox.Show("Message text", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, DirectCast(Me.mobjMessageBoxButtonsCB.SelectedValue, MessageBoxDefaultButton), DirectCast(Me.mobjMessageBoxButtonsCB.SelectedValue, MessageBoxOptions), New EventHandler(AddressOf Me.MessageBoxHandler), Me.mobjShowModalMask.Checked)
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