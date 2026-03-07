Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.WidthHeight


    ' <summary>
    ' A TextBox control
    ' </summary>
    <Gizmox.WebGUI.Forms.Skins.Skin(GetType(MyTextBoxSkin))> _
    <Serializable()> _
    Public Class MyTextBox
        Inherits Gizmox.WebGUI.Forms.TextBox

        Public Sub New()
            Me.CustomStyle = "MyTextBoxSkin"
        End Sub

    End Class
End Namespace