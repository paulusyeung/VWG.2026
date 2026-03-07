Imports System.Drawing
Imports Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.BackgroundImage

Namespace CompanionKit.Concepts.ClientAPI.BackgroundImage

    Public Class BackgroundImagePage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()


            'Add custom panel to user control

            Dim mobjBackImagePanel As New BackImagePanel()
            mobjBackImagePanel.CustomStyle = "BackImagePanelSkin"
            mobjBackImagePanel.Location = New Point(10, 60)
            mobjBackImagePanel.Size = New System.Drawing.Size(300, 280)
            mobjBackImagePanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle

            Controls.Add(mobjBackImagePanel)


        End Sub
    End Class

End Namespace