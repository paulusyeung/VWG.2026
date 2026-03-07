Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MinimumSizeForm
    Inherits Gizmox.WebGUI.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Visual WebGui Designer
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Visual WebGui Designer
    'It can be modified using the Visual WebGui Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mobjBorderPanel = New Gizmox.WebGUI.Forms.Panel()
        Me.SuspendLayout()
        '
        ' objBorderPanel
        '
        Me.mobjBorderPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
        Me.mobjBorderPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed
        Me.mobjBorderPanel.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
        Me.mobjBorderPanel.Location = New System.Drawing.Point(0, 0)
        Me.mobjBorderPanel.Name = "objBorderPanel"
        Me.mobjBorderPanel.Size = New System.Drawing.Size(0, 0)
        Me.mobjBorderPanel.TabIndex = 4
        '
        ' MinimumSizeForm
        '
        Me.Controls.Add(Me.mobjBorderPanel)
        Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
        Me.Size = New System.Drawing.Size(342, 140)
        Me.Text = "Form with MinimumSize's border"
        Me.ResumeLayout(False)

    End Sub

    Public mobjBorderPanel As Gizmox.WebGUI.Forms.Panel

End Class