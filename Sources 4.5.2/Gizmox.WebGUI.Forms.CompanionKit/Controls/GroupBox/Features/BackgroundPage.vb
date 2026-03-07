Imports System.Drawing

Namespace CompanionKit.Controls.GroupBox.Features

    Public Class BackgroundPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub
        ''' <summary>
        ''' Handles CheckedChanged event of the RadioButton controls
        ''' Changes GroupBox background color according to RadioButton
        ''' value that raised the event
        ''' </summary>
        Private Sub Color_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjTransparent.CheckedChanged, mobjSnow.CheckedChanged, mobjMoccasin.CheckedChanged
            If (sender Is Me.mobjMoccasin) Then
                Me.mobjGroupColor.BackColor = Color.Moccasin
            ElseIf (sender Is Me.mobjSnow) Then
                Me.mobjGroupColor.BackColor = Color.Snow
            ElseIf (sender Is Me.mobjTransparent) Then
                Me.mobjGroupColor.BackColor = Color.Transparent
            End If
        End Sub
    End Class

End Namespace