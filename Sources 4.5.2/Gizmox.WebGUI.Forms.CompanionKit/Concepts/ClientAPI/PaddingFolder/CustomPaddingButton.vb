Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.PaddingFolder
    ' <summary>
    ' A Button control
    ' </summary>
    <Gizmox.WebGUI.Forms.Skins.Skin(GetType(CustomPaddingButtonSkin))> _
    <Serializable()> _
    Public Class CustomPaddingButton
        Inherits Gizmox.WebGUI.Forms.Button

        Public Sub New()
            Me.CustomStyle = "CustomPaddingButtonSkin"
        End Sub

    End Class
End Namespace

