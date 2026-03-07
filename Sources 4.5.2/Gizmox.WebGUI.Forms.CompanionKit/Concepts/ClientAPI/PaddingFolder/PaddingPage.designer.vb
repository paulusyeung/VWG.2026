Imports Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.PaddingFolder

Namespace CompanionKit.Concepts.ClientAPI.PaddingFolder

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PaddingPage
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

            Me.objCustomPaddingButton = New CustomPaddingButton()
            Me.objPaddingGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objPaddingGroupBox.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' objCustomPaddingButton
            ' 
            Me.objCustomPaddingButton.CustomStyle = "CustomPaddingButtonSkin"
            Me.objCustomPaddingButton.Location = New System.Drawing.Point(105, 136)
            Me.objCustomPaddingButton.Name = "objCustomPaddingButton"
            Me.objCustomPaddingButton.Size = New System.Drawing.Size(123, 59)
            Me.objCustomPaddingButton.TabIndex = 1
            Me.objCustomPaddingButton.Text = "Long test text string"
            ' 
            ' objPaddingGroupBox
            ' 
            Me.objPaddingGroupBox.Controls.Add(Me.objLabel)
            Me.objPaddingGroupBox.Controls.Add(Me.objCustomPaddingButton)
            Me.objPaddingGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objPaddingGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objPaddingGroupBox.Location = New System.Drawing.Point(15, 15)
            Me.objPaddingGroupBox.Name = "objPaddingGroupBox"
            Me.objPaddingGroupBox.Size = New System.Drawing.Size(278, 318)
            Me.objPaddingGroupBox.TabIndex = 0
            Me.objPaddingGroupBox.TabStop = False
            Me.objPaddingGroupBox.Text = "Padding"
            ' 
            ' objLabel
            ' 
            Me.objLabel.AutoSize = True
            Me.objLabel.Location = New System.Drawing.Point(15, 30)
            Me.objLabel.Name = "objLabel"
            Me.objLabel.Size = New System.Drawing.Size(35, 13)
            Me.objLabel.TabIndex = 2
            Me.objLabel.Text = "Click to button by left (to increase)" & vbCr & vbLf & "or right (to decrease) mouse button" & vbCr & vbLf & "to ch" & "ange padding value" & vbCr & vbLf
            ' 
            ' PaddingPage
            ' 
            Me.Controls.Add(Me.objPaddingGroupBox)
            Me.DockPadding.All = 15
            Me.MaximumSize = New System.Drawing.Size(370, 348)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(370, 348)
            Me.Text = "PaddingPage"
            Me.objPaddingGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private objCustomPaddingButton As CustomPaddingButton
        Private objPaddingGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private objLabel As Gizmox.WebGUI.Forms.Label

    End Class

End Namespace