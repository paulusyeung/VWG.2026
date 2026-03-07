Namespace CompanionKit.Controls.Form.Features
	Public Class BorderStyleForm

        Public Sub New()
            InitializeComponent()

            Me.BorderWidth = 1
            Me.BorderColor = Drawing.Color.Red
        End Sub

        ''' <summary>
        ''' Handles Click event for 'Ok' button.
        ''' Closes the form and set 'OK' dialog result for Form.
        ''' </summary>
        Private Sub mobjOkButton_Click(sender As Object, e As EventArgs) Handles mobjOkButton.Click
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        ''' <summary>
        ''' Handles Load event of the Form
        ''' </summary>
        Private Sub BorderStyleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Fill up ComboBox with form border styles.
            Dim defaultBorderStyle As BorderStyle = Me.BorderStyle
            Me.mobjComboBox.DataSource = [Enum].GetValues(GetType(Gizmox.WebGUI.Forms.BorderStyle))
            Me.mobjComboBox.SelectedItem = defaultBorderStyle
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox with form border styles.
        ''' </summary>
        Private Sub mobjComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjComboBox.SelectedIndexChanged
            'Change a border style for the form.
            Me.BorderStyle = DirectCast(Me.mobjComboBox.SelectedItem, Gizmox.WebGUI.Forms.BorderStyle)
        End Sub
	End Class
End Namespace
