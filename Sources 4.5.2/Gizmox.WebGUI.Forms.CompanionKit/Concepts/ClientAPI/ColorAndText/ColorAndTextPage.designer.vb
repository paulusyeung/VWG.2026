Imports Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.ColorAndText

Namespace CompanionKit.Concepts.ClientAPI.ColorAndText

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ColorAndTextPage
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


            Me.objCustomStateButton = New CustomStateButton()
            Me.objLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' objCustomStateButtonCS
            ' 
            Me.objCustomStateButton.CustomStyle = "CustomStateButtonSkin"
            Me.objCustomStateButton.Location = New System.Drawing.Point(24, 84)
            Me.objCustomStateButton.Name = "objCustomStateButton"
            Me.objCustomStateButton.Size = New System.Drawing.Size(150, 150)
            Me.objCustomStateButton.TabIndex = 0
            Me.objCustomStateButton.Text = "Undefined"
            ' 
            ' objLabel
            ' 
            Me.objLabel.AutoSize = True
            Me.objLabel.Location = New System.Drawing.Point(21, 21)
            Me.objLabel.Name = "label1"
            Me.objLabel.Size = New System.Drawing.Size(35, 13)
            Me.objLabel.TabIndex = 1
            Me.objLabel.Text = "Press the button to change state:"
            ' 
            ' ColorAndTextPage
            ' 
            Me.Controls.Add(Me.objLabel)
            Me.Controls.Add(Me.objCustomStateButton)
            Me.Size = New System.Drawing.Size(202, 277)
            Me.Text = "ColorAndTextPage"
            Me.ResumeLayout(False)
        End Sub

        Private objCustomStateButton As CustomStateButton
        Private objLabel As Gizmox.WebGUI.Forms.Label

    End Class

End Namespace