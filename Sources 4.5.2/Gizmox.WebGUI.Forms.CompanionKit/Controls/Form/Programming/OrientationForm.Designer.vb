Namespace CompanionKit.Controls.Form.Programming

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrientationForm
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
        Me.mobjOrientationLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjCloseButton = New Gizmox.WebGUI.Forms.Button()
        Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
        Me.mobjPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'mobjOrientationLabel
        '
        Me.mobjOrientationLabel.AccessibleDescription = ""
        Me.mobjOrientationLabel.AccessibleName = ""
        Me.mobjOrientationLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
        Me.mobjOrientationLabel.Location = New System.Drawing.Point(0, 0)
        Me.mobjOrientationLabel.Name = "mobjOrientationLabel"
        Me.mobjOrientationLabel.Size = New System.Drawing.Size(419, 112)
        Me.mobjOrientationLabel.TabIndex = 0
        Me.mobjOrientationLabel.Text = "Orientation (device support only)"
        Me.mobjOrientationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mobjCloseButton
        '
        Me.mobjCloseButton.AccessibleDescription = ""
        Me.mobjCloseButton.AccessibleName = ""
        Me.mobjCloseButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.mobjCloseButton.Location = New System.Drawing.Point(70, 0)
        Me.mobjCloseButton.Name = "mobjCloseButton"
        Me.mobjCloseButton.Size = New System.Drawing.Size(279, 30)
        Me.mobjCloseButton.TabIndex = 1
        Me.mobjCloseButton.Text = "Close Form"
        '
        'mobjPanel
        '
        Me.mobjPanel.AccessibleDescription = ""
        Me.mobjPanel.AccessibleName = ""
        Me.mobjPanel.Controls.Add(Me.mobjCloseButton)
        Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
        Me.mobjPanel.DockPadding.Left = 70
        Me.mobjPanel.DockPadding.Right = 70
        Me.mobjPanel.Location = New System.Drawing.Point(0, 112)
        Me.mobjPanel.Name = "mobjPanel"
        Me.mobjPanel.Padding = New Gizmox.WebGUI.Forms.Padding(70, 0, 70, 0)
        Me.mobjPanel.Size = New System.Drawing.Size(419, 30)
        Me.mobjPanel.TabIndex = 2
        '
        'OrientationForm
        '
        Me.Controls.Add(Me.mobjPanel)
        Me.Controls.Add(Me.mobjOrientationLabel)
        Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
        Me.Size = New System.Drawing.Size(419, 466)
        Me.Text = "OrientationForm"
        Me.mobjPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents mobjOrientationLabel As Gizmox.WebGUI.Forms.Label
    Private WithEvents mobjCloseButton As Gizmox.WebGUI.Forms.Button
    Private WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
    End Class
End Namespace