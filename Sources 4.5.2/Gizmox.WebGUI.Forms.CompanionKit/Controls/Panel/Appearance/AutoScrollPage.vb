Namespace CompanionKit.Controls.Panel.Appearance

	Public Class AutoScrollPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

        ''' <summary>
        ''' Adds a button to demonstrated panel
        ''' </summary>
        ''' <remarks></remarks>
		Private Sub AddNewButtonToPanel()
            'Create a new button
			Dim button As New Global.Gizmox.WebGUI.Forms.Button
            button.Text = String.Format("Button {0}", (Me.mobjPanel.Controls.Count + 1))
            button.Left = (Me.mobjPanel.Controls.Count * (button.Width + 10))
            'Add button to demonstrated panel
            Me.mobjPanel.Controls.Add(button)
		End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            'Add a button to panel
            AddNewButtonToPanel()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the AutoScrollPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		Private Sub AutoScrollPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			AddNewButtonToPanel()
		End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjAutoScrollEnabled control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAutoScrollEnabled_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjAutoScrollEnabled.CheckedChanged
            mobjPanel.AutoScroll = mobjAutoScrollEnabled.Checked
        End Sub
    End Class

End Namespace