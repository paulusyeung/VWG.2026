Namespace CompanionKit.Controls.TabControl.Functionality

	Public Class CloseButtonPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Load event of the example's UserControl
        ''' </summary>
        Private Sub CloseButtonPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set checked state for checkbox according to value of the ShowCloseButton property
            Me.mobjDemoTabControl.ShowCloseButton = True
            Me.mobjCloseButtonCheckBox.Checked = Me.mobjDemoTabControl.ShowCloseButton
        End Sub

        ''' <summary>
        ''' Handles CheckedChanged event of the CheckBox.
        ''' Hides and shows close button for TabControl.
        ''' </summary>
        Private Sub mobjCloseButtonCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCloseButtonCheckBox.CheckedChanged
            Me.mobjDemoTabControl.ShowCloseButton = Me.mobjCloseButtonCheckBox.Checked
            Me.mobjDemoTabControl.Update()
        End Sub

        ''' <summary>
        ''' Handles CloseClick of the TabControl.
        ''' Closes selected tab.
        ''' </summary>
        Private Sub mobjDemoTabControl_CloseClick(sender As Object, e As EventArgs) Handles mobjDemoTabControl.CloseClick
            If Me.mobjDemoTabControl.SelectedItem IsNot Nothing Then
                Me.mobjDemoTabControl.TabPages.Remove(Me.mobjDemoTabControl.SelectedItem)
            End If
        End Sub
    End Class

End Namespace