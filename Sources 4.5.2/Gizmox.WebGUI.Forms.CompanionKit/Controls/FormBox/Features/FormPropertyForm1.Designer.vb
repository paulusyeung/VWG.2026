Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FormPropertyForm1
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
            Me.btnShowFormType = New Gizmox.WebGUI.Forms.Button
            Me.SuspendLayout()
            '
            'btnShowFormType
            '
            Me.btnShowFormType.Location = New System.Drawing.Point(200, 89)
            Me.btnShowFormType.Name = "btnShowFormType"
            Me.btnShowFormType.Size = New System.Drawing.Size(150, 23)
            Me.btnShowFormType.TabIndex = 0
            Me.btnShowFormType.Text = "Show Form Type"
            '
            'FormPropertyForm1
            '
            Me.Controls.Add(Me.btnShowFormType)
            Me.Size = New System.Drawing.Size(550, 200)
            Me.Text = "FormPropertyForm1"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents btnShowFormType As Gizmox.WebGUI.Forms.Button

    End Class

End Namespace
