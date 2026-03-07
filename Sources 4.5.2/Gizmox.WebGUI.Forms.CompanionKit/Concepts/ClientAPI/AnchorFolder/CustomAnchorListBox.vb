Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.AnchorFolder

    ' <summary>
    ' A ListBox control
    ' </summary>
    <Gizmox.WebGUI.Forms.Skins.Skin(GetType(CustomAnchorListBoxSkin))> _
    <Serializable()> _
    Public Class CustomAnchorListBox
        Inherits Gizmox.WebGUI.Forms.ListBox

        Public Sub New()
            Me.CustomStyle = "CustomAnchorListBoxSkin"
        End Sub

    End Class
End Namespace

