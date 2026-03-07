Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlBoxForm
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
        Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
        Me.mobjCloseButton = New Gizmox.WebGUI.Forms.Button()
        Me.SuspendLayout()
        '
        ' mobjCheckBox
        '
        Me.mobjCheckBox.AccessibleDescription = ""
        Me.mobjCheckBox.AccessibleName = ""
        Me.mobjCheckBox.AutoSize = True
        Me.mobjCheckBox.Checked = True
        Me.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
        Me.mobjCheckBox.Location = New System.Drawing.Point(89, 50)
        Me.mobjCheckBox.Name = "mobjCheckBox"
        Me.mobjCheckBox.Size = New System.Drawing.Size(134, 17)
        Me.mobjCheckBox.TabIndex = 0
        Me.mobjCheckBox.Text = "Show ControlBox"
        '
        ' mobjCloseButton
        '
        Me.mobjCloseButton.AccessibleDescription = ""
        Me.mobjCloseButton.AccessibleName = ""
        Me.mobjCloseButton.Location = New System.Drawing.Point(89, 86)
        Me.mobjCloseButton.Name = "mobjCloseButton"
        Me.mobjCloseButton.Size = New System.Drawing.Size(134, 50)
        Me.mobjCloseButton.TabIndex = 1
        Me.mobjCloseButton.Text = "Close dialog"
        Me.mobjCloseButton.Visible = False
        '
        ' ControlBoxForm
        '
        Me.Controls.Add(Me.mobjCloseButton)
        Me.Controls.Add(Me.mobjCheckBox)
        Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
        Me.Size = New System.Drawing.Size(316, 155)
        Me.Text = "ControlBox Form"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
    Private WithEvents mobjCloseButton As Gizmox.WebGUI.Forms.Button


End Class