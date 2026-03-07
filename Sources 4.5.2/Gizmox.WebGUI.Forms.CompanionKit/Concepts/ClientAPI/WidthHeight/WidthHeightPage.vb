Imports System.Drawing
Imports Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.WidthHeight

Namespace CompanionKit.Concepts.ClientAPI.WidthHeight

    Public Class WidthHeightPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Add info label to user control
            Dim mobjLabel As New Label()
            mobjLabel.Dock = DockStyle.Top
            mobjLabel.Padding = New Padding(10, 10, 0, 0)
            mobjLabel.Text = "'A' and 'D' buttons change width of TextBox, 'S' and 'W' - height."
            mobjLabel.Size = New Size(20, 55)
            mobjLabel.AutoSize = False

            Me.Controls.Add(mobjLabel)

            'Add custom textBox to user control
            Dim mobjTextBox As New MyTextBox()
            mobjTextBox.CustomStyle = "MyTextBoxSkin"
            mobjTextBox.Location = New Point(10, 60)
            mobjTextBox.Multiline = True
            mobjTextBox.Size = New Size(200, 100)

            Me.Controls.Add(mobjTextBox)

        End Sub
    End Class

End Namespace