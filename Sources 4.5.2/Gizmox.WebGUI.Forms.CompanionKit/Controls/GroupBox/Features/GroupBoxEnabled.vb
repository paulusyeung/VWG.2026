Namespace CompanionKit.Controls.GroupBox.Features

	Public Class GroupBoxEnabled

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub
        ''' <summary>
        ''' Handles CheckedChanged event of the CheckBox control
        ''' </summary>
        Private Sub Enable_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjChkEnable.CheckedChanged
            ''Switch GroupBox Enable property according to the CheckBox state
            Me.mobjGrpControls.Enabled = Me.mobjChkEnable.Checked
        End Sub

	End Class

End Namespace