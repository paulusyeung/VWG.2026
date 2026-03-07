Imports System.Drawing

Namespace CompanionKit.Controls.StatusBar.Appearance

	Public Class DifferentAppearancePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click event of the 'Set text to StatusBar' button.
        ''' Sets text of the TextBox in the text for the StatusBar.
        ''' </summary>
        Private Sub mobjSetTextButton_Click(sender As Object, e As EventArgs) Handles mobjSetTextButton.Click
            Me.mobjTestStatusBar.Text = Me.mobjStatusBarTextBox.Text
        End Sub

        ''' <summary>
        ''' Handles Click event of the 'Change Font of StatusBar text' button.
        ''' Opens a FontDialog for the change font for the text of the StatusBar.
        ''' </summary>
        Private Sub mobjChangeFontButton_Click(sender As Object, e As EventArgs) Handles mobjChangeFontButton.Click
            Me.mobjChangeStatusBarFontDialog.Font = Me.mobjTestStatusBar.Font
            Me.mobjChangeStatusBarFontDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles Apply action for FontDialog.
        ''' Changes font of the StatusBar text.
        ''' </summary>
        Private Sub mobjChangeStatusBarFontDialog_Apply(sender As Object, e As EventArgs) Handles mobjChangeStatusBarFontDialog.Apply
            Dim mobjFontDialog As FontDialog = TryCast(sender, FontDialog)
            SetFontForStatusBar(mobjFontDialog.Font)
        End Sub

        ''' <summary>
        ''' Handles Closed event for FontDialog.
        ''' Changes font of the StatusBar text.
        ''' </summary>
        Private Sub mobjChangeStatusBarFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjChangeStatusBarFontDialog.Closed
            Dim mobjFontDialog As FontDialog = TryCast(sender, FontDialog)
            SetFontForStatusBar(mobjFontDialog.Font)
        End Sub

        ''' <summary>
        ''' Changes font of the StatusBar text to passed Font.
        ''' </summary>
        ''' <param name="newFont">a new font of the StatusBar text.</param>
        Private Sub SetFontForStatusBar(newFont As Font)
            Me.mobjTestStatusBar.Font = newFont
            UpdateFontLabel(newFont)
        End Sub

        ''' <summary>
        ''' Updates the label text, that indicates what font is of the StatusBar text.
        ''' </summary>
        ''' <param name="newFont">the font of the StatusBar text.</param>
        Private Sub UpdateFontLabel(newFont As Font)
            If newFont IsNot Nothing Then
                Me.mobjFontStatusBarLabel.Text = String.Format("Font: {0}, {1}pt", newFont.Name, newFont.Size)
            End If
        End Sub

        ''' <summary>
        ''' Handles Load event for example UserControl.
        ''' </summary>
        Private Sub DifferentAppearancePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.mobjStatusBarTextBox.Text = Me.mobjTestStatusBar.Text
            UpdateFontLabel(Me.mobjTestStatusBar.Font)
            Me.mobjTestStatusBar.BackgroundImage = New ImageResourceHandle("StatusBarImg.jpg")
        End Sub

	End Class

End Namespace