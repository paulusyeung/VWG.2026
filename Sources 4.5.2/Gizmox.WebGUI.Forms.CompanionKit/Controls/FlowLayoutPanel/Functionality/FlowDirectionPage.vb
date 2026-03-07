Namespace CompanionKit.Controls.FlowLayoutPanel.Functionality

	Public Class FlowDirectionPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjFlowDirectionComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjFlowDirectionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjFlowDirectionComboBox.SelectedIndexChanged
            Select Case mobjFlowDirectionComboBox.SelectedIndex
                Case 0
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight
                    Exit Select
                Case 1
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.TopDown
                    Exit Select
                Case 2
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.RightToLeft
                    Exit Select
                Case 3
                    mobjFlowLayoutPanel.FlowDirection = FlowDirection.BottomUp
                    Exit Select
            End Select
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjWrapCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjWrapCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjWrapCheckBox.CheckedChanged
            mobjFlowLayoutPanel.WrapContents = mobjWrapCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the Load event of the FlowDirectÂionPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub FlowDirectionPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            mobjFlowDirectionComboBox.SelectedIndex = 0
            mobjWrapCheckBox.Checked = mobjFlowLayoutPanel.WrapContents
        End Sub

	End Class

End Namespace