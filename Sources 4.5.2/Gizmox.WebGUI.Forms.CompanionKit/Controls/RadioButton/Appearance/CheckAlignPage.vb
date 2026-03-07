Imports System
Imports System.Drawing

Namespace CompanionKit.Controls.RadioButton.Appearance

	Public Class CheckAlignPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjRadioComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRadioComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjRadioComboBox.SelectedIndexChanged
            'Toggles CheckAlign mode according to selected mobjRadioAlignmentComboBox's item
            Select Case mobjRadioComboBox.SelectedItem.ToString()
                Case "TopLeft"
                    mobjRadioButton.CheckAlign = ContentAlignment.TopLeft
                    Exit Select
                Case "TopCenter"
                    mobjRadioButton.CheckAlign = ContentAlignment.TopCenter
                    Exit Select
                Case "TopRight"
                    mobjRadioButton.CheckAlign = ContentAlignment.TopRight
                    Exit Select
                Case "MiddleLeft"
                    mobjRadioButton.CheckAlign = ContentAlignment.MiddleLeft
                    Exit Select
                Case "MiddleCenter"
                    mobjRadioButton.CheckAlign = ContentAlignment.MiddleCenter
                    Exit Select
                Case "MiddleRight"
                    mobjRadioButton.CheckAlign = ContentAlignment.MiddleRight
                    Exit Select
                Case "BottomLeft"
                    mobjRadioButton.CheckAlign = ContentAlignment.BottomLeft
                    Exit Select
                Case "BottomCenter"
                    mobjRadioButton.CheckAlign = ContentAlignment.BottomCenter
                    Exit Select
                Case "BottomRight"
                    mobjRadioButton.CheckAlign = ContentAlignment.BottomRight
                    Exit Select
            End Select
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjTextComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjTextComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjTextComboBox.SelectedIndexChanged
            'Toggles TextAlign mode according to selected mobjTextAlignmentComboBox's item
            Select Case mobjTextComboBox.SelectedItem.ToString()
                Case "TopLeft"
                    mobjRadioButton.TextAlign = ContentAlignment.TopLeft
                    Exit Select
                Case "TopCenter"
                    mobjRadioButton.TextAlign = ContentAlignment.TopCenter
                    Exit Select
                Case "TopRight"
                    mobjRadioButton.TextAlign = ContentAlignment.TopRight
                    Exit Select
                Case "MiddleLeft"
                    mobjRadioButton.TextAlign = ContentAlignment.MiddleLeft
                    Exit Select
                Case "MiddleCenter"
                    mobjRadioButton.TextAlign = ContentAlignment.MiddleCenter
                    Exit Select
                Case "MiddleRight"
                    mobjRadioButton.TextAlign = ContentAlignment.MiddleRight
                    Exit Select
                Case "BottomLeft"
                    mobjRadioButton.TextAlign = ContentAlignment.BottomLeft
                    Exit Select
                Case "BottomCenter"
                    mobjRadioButton.TextAlign = ContentAlignment.BottomCenter
                    Exit Select
                Case "BottomRight"
                    mobjRadioButton.TextAlign = ContentAlignment.BottomRight
                    Exit Select
            End Select
        End Sub

        ''' <summary>
        ''' Handles the Load event of the CheckAlignPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub CheckAlignPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Defines selected indexes of comboBoxes
            mobjTextComboBox.SelectedIndex = 0
            mobjRadioComboBox.SelectedIndex = 3
        End Sub

	End Class

End Namespace