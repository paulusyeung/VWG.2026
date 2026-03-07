Namespace CompanionKit.Controls.BindingNavigator.Features

	Public Class CountItemFormatPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub CountItemFormatPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set data source for BindingSource
            mobjBindingSource.DataSource = New String() {"Item1", "Item2", "Item3", "Item4", "Item5"}
            ' Set display format for BindingNavigator control
            SetFormat()
        End Sub

        ''' <summary>
        ''' Handles Click event for Button control
        ''' </summary>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            ' Set display format for BindingNavigator control
            SetFormat()
        End Sub

        ''' <summary>
        ''' Sets display format for BindingNavigator control
        ''' </summary>
        Private Sub SetFormat()
            mobjBindingNavigator.CountItemFormat = mobjPrefixTextBox.Text + " {0} " + mobjCenterTextTextBox.Text + " {1} " + mobjSuffixTextBox.Text
        End Sub

    End Class

End Namespace