Imports System.Drawing

Namespace CompanionKit.Controls.DateTimePicker.Appearance

    Public Class BackColorPropertyPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles Load event of the page' UserControl
        ''' </summary>
        Private Sub BackColorPropertyPage_Load(sender As Object, e As EventArgs) Handles Me.Load

            Dim defaultBackColor As Color = Me.mobjDemoDateTimePicker.BackColor

            'Set DataSource as array of Colors for ComboBox with background colors.
            Dim knownColors As KnownColor() = DirectCast([Enum].GetValues(GetType(KnownColor)), KnownColor())
            Dim colors As Color() = New Color(knownColors.Length - 1) {}
            For i As Integer = 0 To knownColors.Length - 1
                colors(i) = Color.FromKnownColor(knownColors(i))
            Next
            Me.mobjBackColorComboBox.DataSource = colors
            Me.mobjBackColorComboBox.ColorMember = "Name"
            Me.mobjBackColorComboBox.DisplayMember = "Name"

            ' Set default back color of the DataTimePicker in the ComboBox.
            Me.mobjBackColorComboBox.SelectedItem = defaultBackColor


        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the  ComboBox that contains color.
        ''' Sets selected colors as background colors for DataTimePick
        ''' </summary>
        Private Sub mobjBackColorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjBackColorComboBox.SelectedIndexChanged
            ' Set selected colors as background colors for DataTimePicker
            Me.mobjDemoDateTimePicker.BackColor = DirectCast(Me.mobjBackColorComboBox.SelectedItem, Color)
        End Sub
    End Class

End Namespace