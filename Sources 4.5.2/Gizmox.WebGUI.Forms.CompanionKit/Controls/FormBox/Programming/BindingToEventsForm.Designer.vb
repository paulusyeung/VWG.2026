Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Programming

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BindingToEventsForm
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
            Me.listBox = New Gizmox.WebGUI.Forms.ListBox
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(82, 9)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(35, 13)
            Me.label1.TabIndex = 1
            Me.label1.Text = "This is Visual WebGUI Form"
            '
            'listBox
            '
            Me.listBox.Items.AddRange(New Object() {"Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7"})
            Me.listBox.Location = New System.Drawing.Point(45, 32)
            Me.listBox.Name = "listBox"
            Me.listBox.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One
            Me.listBox.Size = New System.Drawing.Size(208, 173)
            Me.listBox.TabIndex = 0
            '
            'BindingToEventsForm
            '
            Me.Controls.Add(Me.listBox)
            Me.Controls.Add(Me.label1)
            Me.Size = New System.Drawing.Size(300, 220)
            Me.Text = "BindingToEventsForm"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents label1 As Gizmox.WebGUI.Forms.Label
        Private WithEvents listBox As Gizmox.WebGUI.Forms.ListBox

    End Class

End Namespace