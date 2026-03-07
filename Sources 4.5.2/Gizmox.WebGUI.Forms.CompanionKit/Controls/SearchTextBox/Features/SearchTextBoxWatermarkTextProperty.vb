Namespace CompanionKit.Controls.SearchTextBox.Features

	Public Class SearchTextBoxWatermarkTextProperty

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub SearchTextBoxWatermarkTextProperty_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Set watermark
            Me.SetWatermarkText()
        End Sub

        ''' <summary>
        ''' Handles Click event for Button control
        ''' </summary>
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Set watermark
            Me.SetWatermarkText()
        End Sub

        ''' <summary>
        ''' Sets watermark text for SearchTextBox control
        ''' </summary>
        Public Sub SetWatermarkText()
            Me.searchTextBox1.WatermarkText = Me.textBox1.Text
        End Sub

	End Class

End Namespace