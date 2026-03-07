Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Namespace Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.ColorAndText


    ' <summary>
    ' A Button control
    ' </summary>
    <Gizmox.WebGUI.Forms.Skins.Skin(GetType(CustomStateButtonSkin))> _
    <Serializable()> _
    Public Class CustomStateButton
        Inherits Gizmox.WebGUI.Forms.Button

        Public Sub New()
            Me.CustomStyle = "CustomStateButtonSkin"
        End Sub

    End Class

End Namespace

