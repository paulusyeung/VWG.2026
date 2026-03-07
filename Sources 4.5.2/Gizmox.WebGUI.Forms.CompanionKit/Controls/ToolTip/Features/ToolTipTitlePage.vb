Namespace CompanionKit.Controls.ToolTip.Features

	Public Class ToolTipTitlePage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Save related controls into CheckBox.Tag container
            mobjTextBoxCheckBox.Tag = mobjTextBox
            mobjListBoxCheckBox.Tag = mobjListBox
            mobjLinkLabelCheckBox.Tag = mobjLinkLabel
            mobjTrackBarCheckBox.Tag = mobjTrackBar
            mobjDateTimePickerCheckbox.Tag = mobjDateTimePicker
        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event for CheckBox controls
        ''' </summary>
        Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjDateTimePickerCheckbox.CheckedChanged, mobjLinkLabelCheckBox.CheckedChanged, mobjListBoxCheckBox.CheckedChanged, mobjTextBoxCheckBox.CheckedChanged, mobjTrackBarCheckBox.CheckedChanged
            ' Get the CheckBox sender control
            Dim chbSender As Gizmox.WebGUI.Forms.CheckBox = DirectCast(sender, Gizmox.WebGUI.Forms.CheckBox)
            ' Get related control to CheckBox stored in tag container
            Dim control As Control = DirectCast(chbSender.Tag, Control)
            ' Save text entered to local variable
            Dim toolTipText As String = mobjInputTextBox.Text
            ' Set or remove tooltip text for control selected
            If chbSender.Checked Then
                mobjToolTip.SetToolTip(control, toolTipText)
            Else
                mobjToolTip.SetToolTip(control, String.Empty)
            End If
        End Sub

	End Class

End Namespace