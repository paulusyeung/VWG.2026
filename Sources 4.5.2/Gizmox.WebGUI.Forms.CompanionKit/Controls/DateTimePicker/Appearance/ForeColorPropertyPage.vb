Imports System.Drawing

Namespace CompanionKit.Controls.DateTimePicker.Appearance

    Public Class ForeColorPropertyPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Load event of the ForeColorPropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ForeColorPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            Dim mobjDefaultForeColor As Color = Me.mobjDemoDateTimePicker.ForeColor

            'Set DataSource as array of Colors for ComboBox with foreground colors.
            Dim arrKnownColors As KnownColor() = DirectCast([Enum].GetValues(GetType(KnownColor)), KnownColor())
            Dim arrColors As Color() = New Color(arrKnownColors.Length - 1) {}
            For i As Integer = 0 To arrKnownColors.Length - 1
                arrColors(i) = Color.FromKnownColor(arrKnownColors(i))
            Next
            Me.mobjForeColorComboBox.DataSource = arrColors
            Me.mobjForeColorComboBox.ColorMember = "Name"
            Me.mobjForeColorComboBox.DisplayMember = "Name"
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox that contains of colors.
        ''' Sets selected color as foreground colors for DataTimePicker
        ''' </summary>
        Private Sub mobjForeColorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjForeColorComboBox.SelectedIndexChanged
            ' Set selected color as foreground colors for DataTimePicker
            Me.mobjDemoDateTimePicker.ForeColor = DirectCast(Me.mobjForeColorComboBox.SelectedItem, Color)
        End Sub

    End Class

End Namespace