Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ResultsPropertyForm
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
            Me.btnSend = New Gizmox.WebGUI.Forms.Button
            Me.cmbSize = New Gizmox.WebGUI.Forms.ComboBox
            Me.cmbColor = New Gizmox.WebGUI.Forms.ComboBox
            Me.lblSize = New Gizmox.WebGUI.Forms.Label
            Me.lblColor = New Gizmox.WebGUI.Forms.Label
            Me.label1 = New Gizmox.WebGUI.Forms.Label
            Me.SuspendLayout()
            '
            'btnSend
            '
            Me.btnSend.Location = New System.Drawing.Point(70, 121)
            Me.btnSend.Name = "btnSend"
            Me.btnSend.Size = New System.Drawing.Size(160, 23)
            Me.btnSend.TabIndex = 5
            Me.btnSend.Text = "Send Results"
            '
            'cmbSize
            '
            Me.cmbSize.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.cmbSize.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.cmbSize.FormattingEnabled = True
            Me.cmbSize.Items.AddRange(New Object() {"Small", "Medium", "Large"})
            Me.cmbSize.Location = New System.Drawing.Point(109, 82)
            Me.cmbSize.MaxDropDownItems = 8
            Me.cmbSize.Name = "cmbSize"
            Me.cmbSize.Size = New System.Drawing.Size(121, 21)
            Me.cmbSize.TabIndex = 4
            '
            'cmbColor
            '
            Me.cmbColor.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.cmbColor.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.cmbColor.FormattingEnabled = True
            Me.cmbColor.Items.AddRange(New Object() {"Red", "Green", "Blue"})
            Me.cmbColor.Location = New System.Drawing.Point(109, 48)
            Me.cmbColor.MaxDropDownItems = 8
            Me.cmbColor.Name = "cmbColor"
            Me.cmbColor.Size = New System.Drawing.Size(121, 21)
            Me.cmbColor.TabIndex = 3
            '
            'lblSize
            '
            Me.lblSize.AutoSize = True
            Me.lblSize.Location = New System.Drawing.Point(70, 85)
            Me.lblSize.Name = "lblSize"
            Me.lblSize.Size = New System.Drawing.Size(35, 13)
            Me.lblSize.TabIndex = 2
            Me.lblSize.Text = "Size:"
            '
            'lblColor
            '
            Me.lblColor.AutoSize = True
            Me.lblColor.Location = New System.Drawing.Point(70, 51)
            Me.lblColor.Name = "lblColor"
            Me.lblColor.Size = New System.Drawing.Size(35, 13)
            Me.lblColor.TabIndex = 1
            Me.lblColor.Text = "Color: "
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(82, 9)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(35, 13)
            Me.label1.TabIndex = 0
            Me.label1.Text = "This is Visual WebGUI Form"
            '
            'ResultsPropertyForm
            '
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.lblColor)
            Me.Controls.Add(Me.lblSize)
            Me.Controls.Add(Me.cmbColor)
            Me.Controls.Add(Me.cmbSize)
            Me.Controls.Add(Me.btnSend)
            Me.Size = New System.Drawing.Size(300, 170)
            Me.Text = "ResultsPropertyForm"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents btnSend As Gizmox.WebGUI.Forms.Button
        Private WithEvents cmbSize As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents cmbColor As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents lblSize As Gizmox.WebGUI.Forms.Label
        Private WithEvents lblColor As Gizmox.WebGUI.Forms.Label
        Private WithEvents label1 As Gizmox.WebGUI.Forms.Label

    End Class

End Namespace