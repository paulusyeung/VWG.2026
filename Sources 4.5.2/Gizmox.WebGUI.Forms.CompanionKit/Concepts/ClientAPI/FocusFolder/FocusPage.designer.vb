Imports Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.FocusFolder

Namespace CompanionKit.Concepts.ClientAPI.FocusFolder

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FocusPage
        Inherits UserControl

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Visual WebGui UserControl Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the WebGui UserControl Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()

            Me.objCustomFocusableTextBox1 = New CustomFocusableTextBox()
            Me.objCustomFocusableTextBox2 = New CustomFocusableTextBox()
            Me.objCustomFocusableTextBox3 = New CustomFocusableTextBox()
            Me.objLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' objCustomFocusableTextBox1
            ' 
            Me.objCustomFocusableTextBox1.AllowDrag = False
            Me.objCustomFocusableTextBox1.CustomStyle = "CustomFocusableTextBoxSkin"
            Me.objCustomFocusableTextBox1.Location = New System.Drawing.Point(96, 70)
            Me.objCustomFocusableTextBox1.Name = "objCustomFocusableTextBox1"
            Me.objCustomFocusableTextBox1.Size = New System.Drawing.Size(100, 20)
            Me.objCustomFocusableTextBox1.TabIndex = 0
            ' 
            ' objCustomFocusableTextBox2
            ' 
            Me.objCustomFocusableTextBox2.AllowDrag = False
            Me.objCustomFocusableTextBox2.CustomStyle = "CustomFocusableTextBoxSkin"
            Me.objCustomFocusableTextBox2.Location = New System.Drawing.Point(96, 120)
            Me.objCustomFocusableTextBox2.Name = "objCustomFocusableTextBox2"
            Me.objCustomFocusableTextBox2.Size = New System.Drawing.Size(100, 20)
            Me.objCustomFocusableTextBox2.TabIndex = 1
            ' 
            ' objCustomFocusableTextBox3
            ' 
            Me.objCustomFocusableTextBox3.AllowDrag = False
            Me.objCustomFocusableTextBox3.CustomStyle = "CustomFocusableTextBoxSkin"
            Me.objCustomFocusableTextBox3.Location = New System.Drawing.Point(96, 170)
            Me.objCustomFocusableTextBox3.Name = "objCustomFocusableTextBox3"
            Me.objCustomFocusableTextBox3.Size = New System.Drawing.Size(100, 20)
            Me.objCustomFocusableTextBox3.TabIndex = 2
            ' 
            ' objLabel
            ' 
            Me.objLabel.AutoSize = True
            Me.objLabel.Location = New System.Drawing.Point(81, 16)
            Me.objLabel.Name = "objLabel"
            Me.objLabel.Size = New System.Drawing.Size(35, 13)
            Me.objLabel.TabIndex = 3
            Me.objLabel.Text = "Hover on textbox to focus"
            ' 
            ' FocusPage
            ' 
            Me.Controls.Add(Me.objLabel)
            Me.Controls.Add(Me.objCustomFocusableTextBox3)
            Me.Controls.Add(Me.objCustomFocusableTextBox2)
            Me.Controls.Add(Me.objCustomFocusableTextBox1)
            Me.Size = New System.Drawing.Size(300, 271)
            Me.Text = "FocusPage"
            Me.ResumeLayout(False)

        End Sub

        Private objCustomFocusableTextBox1 As CustomFocusableTextBox
        Private objCustomFocusableTextBox2 As CustomFocusableTextBox
        Private objCustomFocusableTextBox3 As CustomFocusableTextBox
        Private objLabel As Gizmox.WebGUI.Forms.Label

    End Class

End Namespace