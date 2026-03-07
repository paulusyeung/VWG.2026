Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ArgumentsPropertyForm
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
            Me.label1 = New Gizmox.WebGUI.Forms.Label
            Me.lblSize = New Gizmox.WebGUI.Forms.Label
            Me.lblColor = New Gizmox.WebGUI.Forms.Label
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(32, 9)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(35, 13)
            Me.label1.TabIndex = 2
            Me.label1.Text = "This is Visual WebGUI Form"
            '
            'lblSize
            '
            Me.lblSize.AutoSize = True
            Me.lblSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.lblSize.Location = New System.Drawing.Point(70, 66)
            Me.lblSize.Name = "lblSize"
            Me.lblSize.Size = New System.Drawing.Size(35, 13)
            Me.lblSize.TabIndex = 1
            '
            'lblColor
            '
            Me.lblColor.AutoSize = True
            Me.lblColor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.lblColor.Location = New System.Drawing.Point(64, 41)
            Me.lblColor.Name = "lblColor"
            Me.lblColor.Size = New System.Drawing.Size(35, 13)
            Me.lblColor.TabIndex = 0
            '
            'ArgumentsPropertyForm
            '
            Me.Controls.Add(Me.lblColor)
            Me.Controls.Add(Me.lblSize)
            Me.Controls.Add(Me.label1)
            Me.Size = New System.Drawing.Size(200, 100)
            Me.Text = "ArgumentsPropertyForm"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents label1 As Gizmox.WebGUI.Forms.Label
        Private WithEvents lblSize As Gizmox.WebGUI.Forms.Label
        Private WithEvents lblColor As Gizmox.WebGUI.Forms.Label

    End Class

End Namespace