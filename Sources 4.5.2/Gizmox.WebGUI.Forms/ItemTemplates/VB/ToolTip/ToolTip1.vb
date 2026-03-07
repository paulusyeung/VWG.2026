Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports System
Imports System.ComponentModel
Imports Gizmox.WebGUI.Forms.Skins

' <summary>
' A TextBox control
' </summary>
<Gizmox.WebGUI.Forms.Skins.Skin(GetType($safeitemname$Skin))> _
<ProvideProperty("ToolTipTemplateName", GetType(Control))> _
<Serializable()> _
Public Class $safeitemname$
Inherits Gizmox.WebGUI.Forms.ToolTip

''' <summary>
''' Gets the tool tip key.
''' </summary>
''' 
Protected Overrides ReadOnly Property ToolTipKey As String
    Get
        Return "$safeitemname$Skin"
    End Get
End Property

''' <summary>
''' Gets the name of the tool tip template.
''' </summary>
''' <param name="objControl">The obj control.</param><returns></returns>
<DefaultValue("")> _
Public Function GetToolTipTemplateName(ByRef objControl As Control) As String
    Return MyBase.GetExtendedToolTipTemplateName(objControl)
End Function

''' <summary>
''' Sets the name of the tool tip template.
''' </summary>
''' <param name="objControl">The obj control.</param>
''' <param name="strValue">The STR value.</param>
Public Sub SetToolTipTemplateName(ByRef objControl As Control, ByRef strValue As String)
    MyBase.SetExtendedToolTipTemplateName(objControl, strValue)
End Sub

''' <summary>
''' Determines whether to serialize the tooltip template name.
''' </summary>
''' <param name="objControl">The obj control.</param><returns></returns>
Private Function ShouldSerializeToolTipTemplateName(ByRef objControl) As Boolean
    Return Not String.IsNullOrEmpty(GetToolTipTemplateName(objControl))
End Function
''' <summary>
''' Resets the name of the tool tip template.
''' </summary>
''' <param name="objControl">The obj control.</param>
Private Sub ResetToolTipTemplateName(ByRef objControl)
    SetToolTipTemplateName(objControl, String.Empty)
End Sub

End Class