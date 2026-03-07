Imports System.Drawing

Namespace CompanionKit.Controls.DateTimePicker.Appearance

    Public Class CalendarForeColorPropertyPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        Private Sub CalendarForeColorPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            ' TODO Changes this.demoDateTimePicker.ForeColor to this.demoDateTimePicker.CalendarForeColor after fix VWG-6977 issue
            Dim defaultForeColor As Color = Me.mobjDemoDateTimePicker.ForeColor

            ' Set DataSource as array of Colors for ComboBox with foreground colors.
            Dim knownColors As KnownColor() = DirectCast([Enum].GetValues(GetType(KnownColor)), KnownColor())
            Dim colors As Color() = New Color(knownColors.Length - 1) {}
            For i As Integer = 0 To knownColors.Length - 1
                colors(i) = Color.FromKnownColor(knownColors(i))
            Next
            Me.mobjForeColorComboBox.DataSource = colors
            Me.mobjForeColorComboBox.ColorMember = "Name"
            Me.mobjForeColorComboBox.DisplayMember = "Name"

            ' Set default calendar ForeColor of the DataTimePicker in the ComboBox.
            Me.mobjForeColorComboBox.SelectedItem = defaultForeColor
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox that contains of colors.
        ''' Sets selected color as foreground colors for DataTimePicker
        ''' </summary>
        Private Sub mobjForeColorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjForeColorComboBox.SelectedIndexChanged
            ' Set selected color as foreground colors for DataTimePicker
            ' TODO Changes this.demoDateTimePicker.ForeColor to this.demoDateTimePicker.CalendarForeColor after fix VWG-6977 issue
            Me.mobjDemoDateTimePicker.ForeColor = DirectCast(Me.mobjForeColorComboBox.SelectedItem, Color)
        End Sub
    End Class

End Namespace