Namespace CompanionKit.Controls.HeaderedPanel.Features

	Public Class HeaderDemonstrationPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the objTextRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjTextRadioButton.CheckedChanged
            'If "Text" radioButton is checked - sets Text property
            If mobjTextRadioButton.Checked Then
                mobjHeaderedPanel.Text = "Text"
            Else
                'If unchecked - clears Text property
                mobjHeaderedPanel.Text = String.Empty
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjTextIconRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextIconRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjTextIconRadioButton.CheckedChanged
            'If "Text + Icon" is checked - sets Text and Icon properties
            If mobjTextIconRadioButton.Checked Then
                mobjHeaderedPanel.Text = "Text + Icon"
                mobjHeaderedPanel.Icon = "Images.32x32.Categorize.png"
            Else
                'If unchecked - clears Text and Icon properties
                mobjHeaderedPanel.Text = String.Empty
                mobjHeaderedPanel.Icon = Nothing
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBoxRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBoxRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBoxRadioButton.CheckedChanged
            'If "CheckBox" is checked - creates CheckBox control and assigns it to Header 
            If mobjCheckBoxRadioButton.Checked Then
                Dim mobjCheckBox As New Gizmox.WebGUI.Forms.CheckBox()
                mobjCheckBox.Dock = DockStyle.Right
                mobjCheckBox.Text = "CheckBox"
                mobjHeaderedPanel.Header = mobjCheckBox
            Else
                'If unchecked - clears Header property
                mobjHeaderedPanel.Header = Nothing
            End If
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjButtonRadioButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub objButtonRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles mobjButtonRadioButton.CheckedChanged
            'If "Button" is checked - creates Button control and assigns it to Header 
            If mobjButtonRadioButton.Checked Then
                Dim mobjButton As New Gizmox.WebGUI.Forms.Button()
                mobjButton.Text = "Button"
                mobjHeaderedPanel.Header = mobjButton
            Else
                'If unchecked - clears Header property
                mobjHeaderedPanel.Header = Nothing
            End If
        End Sub

	End Class

End Namespace