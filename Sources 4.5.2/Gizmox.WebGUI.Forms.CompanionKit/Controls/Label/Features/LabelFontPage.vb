Namespace CompanionKit.Controls.LabelFolder.Features

    Public Class LabelFontPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjButton1.Click
            ' Save label object in FontDialog.Tag property
            Me.fontDialog1.Tag = Me.mobjLabel1
            ' Set font for FontDialog using Label.Font property
            Me.fontDialog1.Font = Me.mobjLabel1.Font
            ' Open FontDialog window
            Me.fontDialog1.ShowDialog(New EventHandler(AddressOf Me.FontDialog_Closed))

        End Sub
        ''' <summary>
        ''' Handles the Click event of the mobjButton2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjButton2.Click
            ' Save label object in FontDialog.Tag property
            Me.fontDialog1.Tag = Me.mobjLabel2
            ' Set font for FontDialog using Label.Font property
            Me.fontDialog1.Font = Me.mobjLabel2.Font
            ' Open FontDialog window
            Me.fontDialog1.ShowDialog(New EventHandler(AddressOf Me.FontDialog_Closed))
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton3 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjButton3.Click
            ' Save label object in FontDialog.Tag property
            Me.fontDialog1.Tag = Me.mobjLabel3
            ' Set font for FontDialog using Label.Font property
            Me.fontDialog1.Font = Me.mobjLabel3.Font
            ' Open FontDialog window
            Me.fontDialog1.ShowDialog(New EventHandler(AddressOf Me.FontDialog_Closed))
        End Sub

        ''' <summary>
        ''' Handles the Closed event of the FontDialog control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub FontDialog_Closed(ByVal sender As Object, ByVal e As EventArgs) Handles fontDialog1.Closed
            ' Get Label object saved
            Dim label As Label = TryCast(DirectCast(sender, FontDialog).Tag, Label)
            ' Set font for Label object
            label.Font = Me.fontDialog1.Font
        End Sub

    End Class

End Namespace