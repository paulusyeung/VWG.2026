Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.BackgroundImage


    ' <summary>
    ' A Panel control
    ' </summary>
    <Gizmox.WebGUI.Forms.Skins.Skin(GetType(BackImagePanelSkin))> _
    <Serializable()> _
    Public Class BackImagePanel
        Inherits Gizmox.WebGUI.Forms.Panel

        Public Sub New()
            Me.CustomStyle = "BackImagePanelSkin"
        End Sub

    End Class
End Namespace