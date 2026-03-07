Namespace CompanionKit.Controls.HeaderedPanel.Features

	Public Class HeaderedPanelHeaderPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub HeaderedPanelHeaderPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' Set Label as header control for HeaderedPanel
            mobjHeaderedPanel.Header = New Label("Header content")
        End Sub

        ''' <summary>
        ''' Handles DoubleClick event for Control
        ''' </summary>
        Private Sub Control_DoubleClick(sender As Object, e As EventArgs) Handles mobjTextBox.DoubleClick, mobjComboBox.DoubleClick, mobjDateTimePicker.DoubleClick
            ' Set control as header for HeaderedPanel
            mobjHeaderedPanel.Header = DirectCast(sender, Control)
        End Sub

        ''' <summary>
        ''' Handles Click event for Button control
        ''' </summary>
        Private Sub mobjButton_Click(sender As Object, e As EventArgs) Handles mobjButton.Click
            ' Clear all form controls
            Me.Controls.Clear()
            ' Initialize all form controls
            Me.InitializeComponent()
            ' Set Label as header control for HeaderedPanel
            mobjHeaderedPanel.Header = New Label("Header content")
        End Sub

	End Class

End Namespace