Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Namespace CompanionKit.Controls.RibbonBar.ApplicationScenario

    Public Class TextEditingApplicationPage

        Protected mstrUserName As String = String.Empty
        Protected mintUserId As Integer = 0

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            Me.InitializateRibbonBar()



        End Sub

        Private Sub InitializateRibbonBar()
            Dim mobjRichTextEditor As ISupportsRibbonBar = Me.mobjRichTextEditor
            If (Not mobjRichTextEditor Is Nothing) Then
                mobjRichTextEditor.ApplyGroup(Me.mobjBasicTextRibbonBarGroup, "BasicText")
                mobjRichTextEditor.ApplyGroup(Me.mobjProffingRibbonBarGroup, "Proofing")
                mobjRichTextEditor.ApplyGroup(Me.mobjClipboardRibbonBarGroup, "Clipboard")
                mobjRichTextEditor.ApplyGroup(Me.mobjFonRibbonBarGroup, "Font")
                mobjRichTextEditor.ApplyGroup(Me.mobjParagraphRibbonBarGroup, "Paragraph")
                mobjRichTextEditor.ApplyGroup(Me.mobjZoomRibbonBarGroup, "Zoom")
            End If
        End Sub

        Private Sub mobjStartMenuButton_Click(sender As System.Object, e As System.EventArgs) Handles mobjStartMenuButton1.Click, mobjStartMenuButton3.Click, mobjStartMenuButton2.Click
            mobjMainRibbonBar.StartMenuProperties.RightToolStripProperties.Items.Clear()
            Dim objButton As ToolStripButton = TryCast(sender, ToolStripButton)
            If objButton IsNot Nothing Then
                Dim y As Integer = Integer.Parse(objButton.Tag.ToString())
                For i As Integer = 1 To 3
                    Dim objNewButton As New ToolStripButton(String.Format("Sub Item {0}", (y - 1) * 3 + i))
                    objNewButton.TextAlign = Drawing.ContentAlignment.MiddleLeft
                    AddHandler objNewButton.Click, AddressOf objNewButton_Click
                    mobjMainRibbonBar.StartMenuProperties.RightToolStripProperties.Items.Add(objNewButton)
                Next
            End If

        End Sub

        Private Sub objNewButton_Click(sender As Object, e As EventArgs)
            Dim objButton As ToolStripButton = TryCast(sender, ToolStripButton)
            If objButton IsNot Nothing Then
                MessageBox.Show(objButton.Text + " was clicked", "RibbonBar Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub


        Private Sub mobjQAButton1_Click(sender As System.Object, e As System.EventArgs) Handles mobjQAButton1.Click
            mobjGroupedRibbonBarPage1.Visible = True
            mobjGroupedRibbonBarPage2.Visible = True
            MessageBox.Show("Test1", "RibbonBar Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub mobjQAButton2_Click(sender As System.Object, e As System.EventArgs) Handles mobjQAButton2.Click
            mobjGroupedRibbonBarPage1.Visible = False
            mobjGroupedRibbonBarPage2.Visible = False
            MessageBox.Show("Test2", "RibbonBar Sample", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class

End Namespace