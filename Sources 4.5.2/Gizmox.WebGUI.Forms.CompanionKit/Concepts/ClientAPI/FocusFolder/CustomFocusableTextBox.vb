Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder

    ' <summary>
    ' A TextBox control
    ' </summary>
    <Gizmox.WebGUI.Forms.Skins.Skin(GetType(CustomFocusableTextBoxSkin))> _
    <Serializable()> _
    Public Class CustomFocusableTextBox
        Inherits Gizmox.WebGUI.Forms.TextBox

        Public Sub New()
            Me.CustomStyle = "CustomFocusableTextBoxSkin"
        End Sub

    End Class
End Namespace

