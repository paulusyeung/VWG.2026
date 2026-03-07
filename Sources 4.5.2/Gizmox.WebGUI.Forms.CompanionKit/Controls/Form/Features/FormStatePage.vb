Namespace CompanionKit.Controls.Form.Features

	Public Class FormStatePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Fills up the ComboBox with window states.
        ''' </summary>
        Private Sub FormStatePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.mobjComboBox.DataSource = [Enum].GetValues(GetType(FormWindowState))
            Me.mobjMaximizeBtnCheckBox.Checked = True
            Me.mobjMinimizeBtnCheckBox.Checked = True
        End Sub

        ''' <summary>
        ''' Opens the form with defined state and enable/disable maximize
        ''' and minimize boxes according to checked state of 'Maximize button' and
        ''' 'Minimize button' CheckBoxes.
        ''' </summary>
        Private Sub mobjOpenFormWindowState_Click(sender As Object, e As EventArgs) Handles mobjOpenFormWindowState.Click
            Dim mobjForm As New WindowStateForm()
            mobjForm.MaximizeBox = Me.mobjMaximizeBtnCheckBox.Checked
            mobjForm.MinimizeBox = Me.mobjMinimizeBtnCheckBox.Checked
            mobjForm.WindowState = DirectCast(Me.mobjComboBox.SelectedItem, FormWindowState)
            mobjForm.ShowDialog()
        End Sub
	End Class

End Namespace