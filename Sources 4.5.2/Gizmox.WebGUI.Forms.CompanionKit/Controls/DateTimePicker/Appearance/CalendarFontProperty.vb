Namespace CompanionKit.Controls.DateTimePicker.Appearance

	Public Class CalendarFontProperty

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Handles Click  event of the Button.
        ''' Opens FontDialog dialog box to change font of the DateTimePicker.
        ''' </summary>
        Private Sub mobjFontButton_Click(sender As Object, e As EventArgs) Handles mobjFontButton.Click
            ' Set initial font for the FontDialog dialog box 
            ' as a font of the demonstrated DateTimePicker.
            ' TODO Changes this.demoDateTimePicker.Font to this.demoDateTimePicker.CalendarFont after fix VWG-6977 issue
            Me.mobjDemoFontDialog.Font = Me.mobjDemoDateTimePicker.Font
            Me.mobjDemoFontDialog.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles Apply event of the FontDialog dialog box.
        ''' Sets new font for DataTimePicker and 
        ''' updates label that represents Font of the DataTimePicker
        ''' </summary>
        Private Sub mobjDemoFontDialog_Apply(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Apply
            Dim fontDialog As FontDialog = TryCast(sender, FontDialog)

            ' Set new font for DataTimePicker and 
            ' update label that represents Font of the DataTimePicker
            ' TODO Changes this.demoDateTimePicker.Font to this.demoDateTimePicker.CalendarFont after fix VWG-6977 issue
            Me.mobjDemoDateTimePicker.Font = Me.mobjDemoFontDialog.Font
            UpdateFontLabel(Me.mobjDemoDateTimePicker.Font)
        End Sub

        ''' <summary>
        ''' Handles Closed event of the FontDialog dialog box.
        ''' Set new font for DataTimePicker and 
        ''' update label that represents Font of the DataTimePicker
        ''' </summary>
        Private Sub mobjDemoFontDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoFontDialog.Closed
            Dim fontDialog As FontDialog = TryCast(sender, FontDialog)
            If fontDialog.DialogResult = DialogResult.OK Then
                ' Set new font for DataTimePicker and 
                ' update label that represents Font of the DataTimePicker
                ' TODO Changes this.demoDateTimePicker.Font to this.demoDateTimePicker.CalendarFont after fix VWG-6977 issue
                Me.mobjDemoDateTimePicker.Font = Me.mobjDemoFontDialog.Font
                UpdateFontLabel(Me.mobjDemoDateTimePicker.Font)
            End If
        End Sub

        
        ''' <summary>
        ''' Updates the font label.
        ''' </summary>
        ''' <param name="dateTimerPickerFont">The date timer picker font.</param>
        Private Sub UpdateFontLabel(dateTimerPickerFont As Drawing.Font)
            If dateTimerPickerFont IsNot Nothing Then
                Me.mobjFontLabel.Text = String.Format("Font: {0}, {1}pt", dateTimerPickerFont.Name, dateTimerPickerFont.Size)
            End If
        End Sub

        ''' <summary>
        ''' Handles Load event of the page' UserControl
        ''' </summary>
        Private Sub CalendarFontProperty_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set initial font of the DateTimePicker for the represented label
            UpdateFontLabel(Me.mobjDemoDateTimePicker.Font)
        End Sub

    End Class

End Namespace