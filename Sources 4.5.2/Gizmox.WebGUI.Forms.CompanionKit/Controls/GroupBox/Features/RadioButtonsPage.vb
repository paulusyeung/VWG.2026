Namespace CompanionKit.Controls.GroupBox.Features

	Public Class RadioButtonsPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

		End Sub

        Private Sub Requirement_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjRadioButton9.CheckedChanged, mobjRadioButton8.CheckedChanged, mobjRadioButton7.CheckedChanged, mobjRadioButton6.CheckedChanged, mobjRadioButton10.CheckedChanged
            ''Set Label visible if it is not
            If Not Me.mobjLblRequrements.Visible Then
                Me.mobjLblRequrements.Visible = True
            End If
            ''Set text to Label using the Text property value of the RadioButton
            ''that raised the event
            Me.mobjLblRequrements.Text = String.Format("Requirements:" & vbCr & vbLf & "{0}", DirectCast(sender, Control).Text)

        End Sub

        Private Sub ClassRoom_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjRadioButton5.CheckedChanged, mobjRadioButton4.CheckedChanged, mobjRadioButton3.CheckedChanged, mobjRadioButton2.CheckedChanged, mobjRadioButton1.CheckedChanged
            ''Set Label visible if it is not
            If Not Me.mobjLblStatusClass.Visible Then
                Me.mobjLblStatusClass.Visible = True
            End If
            ''Set text to Label using the Text property value of the RadioBotton
            ''that raised the event
            Me.mobjLblStatusClass.Text = String.Format("Requirements: " & vbCr & vbLf & "{0}", DirectCast(sender, Control).Text)

        End Sub
    End Class

End Namespace