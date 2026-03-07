Imports Gizmox.WebGUI.Forms.CompanionKit.Concepts.ClientAPI.AnchorFolder

Namespace CompanionKit.Concepts.ClientAPI.AnchorFolder

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AnchorPage
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
            Me.objAnchorPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objCustomAnchorListBox = New CustomAnchorListBox()
            Me.objAnchorDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.objAnchorGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.objAnchorPanel.SuspendLayout()
            Me.objAnchorGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'objAnchorPanel
            '
            Me.objAnchorPanel.Controls.Add(Me.objCustomAnchorListBox)
            Me.objAnchorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.objAnchorPanel.Location = New System.Drawing.Point(0, 122)
            Me.objAnchorPanel.Name = "objAnchorPanel"
            Me.objAnchorPanel.Size = New System.Drawing.Size(320, 153)
            Me.objAnchorPanel.TabIndex = 2
            '
            'objCustomAnchorListBox
            '
            Me.objCustomAnchorListBox.CustomStyle = "CustomAnchorListBoxSkin"
            Me.objCustomAnchorListBox.Items.AddRange(New Object() {"left: true", "right: false", "top: true", "bottom: false"})
            Me.objCustomAnchorListBox.Location = New System.Drawing.Point(29, 18)
            Me.objCustomAnchorListBox.Name = "objCustomAnchorListBox"
            Me.objCustomAnchorListBox.Size = New System.Drawing.Size(136, 108)
            Me.objCustomAnchorListBox.TabIndex = 0
            '
            'objAnchorDescriptionLabel
            '
            Me.objAnchorDescriptionLabel.AutoSize = True
            Me.objAnchorDescriptionLabel.Location = New System.Drawing.Point(11, 26)
            Me.objAnchorDescriptionLabel.Name = "objAnchorDescriptionLabel"
            Me.objAnchorDescriptionLabel.Size = New System.Drawing.Size(35, 13)
            Me.objAnchorDescriptionLabel.TabIndex = 1
            Me.objAnchorDescriptionLabel.Text = "To change anchor press:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left key - left" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right key - right" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Up key - top" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Down k" & _
        "ey - bottom" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            '
            'objAnchorGroupBox
            '
            Me.objAnchorGroupBox.Controls.Add(Me.objAnchorDescriptionLabel)
            Me.objAnchorGroupBox.Controls.Add(Me.objAnchorPanel)
            Me.objAnchorGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objAnchorGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.objAnchorGroupBox.Location = New System.Drawing.Point(15, 15)
            Me.objAnchorGroupBox.Name = "objAnchorGroupBox"
            Me.objAnchorGroupBox.Size = New System.Drawing.Size(320, 275)
            Me.objAnchorGroupBox.TabIndex = 4
            Me.objAnchorGroupBox.TabStop = False
            Me.objAnchorGroupBox.Text = "Anchor"
            '
            'AnchorPage
            '
            Me.Controls.Add(Me.objAnchorGroupBox)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(350, 305)
            Me.Text = "AnchorPage"
            Me.objAnchorPanel.ResumeLayout(False)
            Me.objAnchorGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objAnchorPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objAnchorDescriptionLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents objAnchorGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents objCustomAnchorListBox As CustomAnchorListBox

    End Class

End Namespace