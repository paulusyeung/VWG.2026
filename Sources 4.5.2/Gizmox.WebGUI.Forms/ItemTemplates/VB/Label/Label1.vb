Imports System
Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

' <summary>
' A Label control
' </summary>
<Gizmox.WebGUI.Forms.Skins.Skin(GetType($safeitemname$Skin))> _
<Serializable()> _
Public Class $safeitemname$
Inherits Gizmox.WebGUI.Forms.Label

	Public Sub New()
    	Me.CustomStyle = "$safeitemname$Skin"
	End Sub

End Class
