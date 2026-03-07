Namespace CompanionKit.Controls.LabelFolder.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LabelUseMnemonicPage
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
            Me.mobjNicknameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPassLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjEmailLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAddressLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNicknameTB = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPassTB = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjEmailTB = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjAddressTB = New Gizmox.WebGUI.Forms.TextBox()
            Me.chbUseMnemonic = New Gizmox.WebGUI.Forms.CheckBox()
            Me.tbNickname = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjNicknameLabel
            '
            Me.mobjNicknameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNicknameLabel.KeyFilter = Gizmox.WebGUI.Forms.KeyFilter.Alt
            Me.mobjNicknameLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjNicknameLabel.Name = "mobjNicknameLabel"
            Me.mobjNicknameLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjNicknameLabel.Size = New System.Drawing.Size(160, 70)
            Me.mobjNicknameLabel.TabIndex = 0
            Me.mobjNicknameLabel.Text = "&Nickname"
            Me.mobjNicknameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjPassLabel
            '
            Me.mobjPassLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPassLabel.KeyFilter = Gizmox.WebGUI.Forms.KeyFilter.Alt
            Me.mobjPassLabel.Location = New System.Drawing.Point(0, 70)
            Me.mobjPassLabel.Name = "mobjPassLabel"
            Me.mobjPassLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjPassLabel.Size = New System.Drawing.Size(160, 70)
            Me.mobjPassLabel.TabIndex = 2
            Me.mobjPassLabel.Text = "&Password"
            Me.mobjPassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjEmailLabel
            '
            Me.mobjEmailLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjEmailLabel.KeyFilter = Gizmox.WebGUI.Forms.KeyFilter.Alt
            Me.mobjEmailLabel.Location = New System.Drawing.Point(0, 140)
            Me.mobjEmailLabel.Name = "mobjEmailLabel"
            Me.mobjEmailLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjEmailLabel.Size = New System.Drawing.Size(160, 70)
            Me.mobjEmailLabel.TabIndex = 4
            Me.mobjEmailLabel.Text = "&Email"
            Me.mobjEmailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjAddressLabel
            '
            Me.mobjAddressLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAddressLabel.KeyFilter = Gizmox.WebGUI.Forms.KeyFilter.Alt
            Me.mobjAddressLabel.Location = New System.Drawing.Point(0, 210)
            Me.mobjAddressLabel.Name = "mobjAddressLabel"
            Me.mobjAddressLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjAddressLabel.Size = New System.Drawing.Size(160, 70)
            Me.mobjAddressLabel.TabIndex = 6
            Me.mobjAddressLabel.Text = "&Address"
            Me.mobjAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjNicknameTB
            '
            Me.mobjNicknameTB.AllowDrag = False
            Me.mobjNicknameTB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjNicknameTB.Location = New System.Drawing.Point(163, 22)
            Me.mobjNicknameTB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjNicknameTB.Name = "mobjNicknameTB"
            Me.mobjNicknameTB.Size = New System.Drawing.Size(154, 25)
            Me.mobjNicknameTB.TabIndex = 1
            '
            'mobjPassTB
            '
            Me.mobjPassTB.AllowDrag = False
            Me.mobjPassTB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjPassTB.Location = New System.Drawing.Point(163, 92)
            Me.mobjPassTB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjPassTB.Name = "mobjPassTB"
            Me.mobjPassTB.Size = New System.Drawing.Size(154, 25)
            Me.mobjPassTB.TabIndex = 3
            '
            'mobjEmailTB
            '
            Me.mobjEmailTB.AllowDrag = False
            Me.mobjEmailTB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjEmailTB.Location = New System.Drawing.Point(163, 162)
            Me.mobjEmailTB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjEmailTB.Name = "mobjEmailTB"
            Me.mobjEmailTB.Size = New System.Drawing.Size(154, 25)
            Me.mobjEmailTB.TabIndex = 5
            '
            'mobjAddressTB
            '
            Me.mobjAddressTB.AllowDrag = False
            Me.mobjAddressTB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjAddressTB.Location = New System.Drawing.Point(163, 232)
            Me.mobjAddressTB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjAddressTB.Name = "mobjAddressTB"
            Me.mobjAddressTB.Size = New System.Drawing.Size(154, 25)
            Me.mobjAddressTB.TabIndex = 7
            '
            'chbUseMnemonic
            '
            Me.chbUseMnemonic.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.chbUseMnemonic.Checked = True
            Me.chbUseMnemonic.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjTLP.SetColumnSpan(Me.chbUseMnemonic, 2)
            Me.chbUseMnemonic.Location = New System.Drawing.Point(95, 290)
            Me.chbUseMnemonic.Name = "chbUseMnemonic"
            Me.chbUseMnemonic.Size = New System.Drawing.Size(130, 50)
            Me.chbUseMnemonic.TabIndex = 8
            Me.chbUseMnemonic.Text = "Use mnemonic"
            Me.chbUseMnemonic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chbUseMnemonic.UseVisualStyleBackColor = True
            '
            'tbNickname
            '
            Me.tbNickname.AllowDrag = False
            Me.tbNickname.Location = New System.Drawing.Point(84, 19)
            Me.tbNickname.Name = "tbNickname"
            Me.tbNickname.Size = New System.Drawing.Size(150, 20)
            Me.tbNickname.TabIndex = 1
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjNicknameLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.chbUseMnemonic, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjPassLabel, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjAddressTB, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjEmailLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjEmailTB, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjAddressLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjPassTB, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjNicknameTB, 1, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 9
            '
            'LabelUseMnemonicPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "LabelUseMnemonicPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjNicknameLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjPassLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjEmailLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjAddressLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjNicknameTB As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjPassTB As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjEmailTB As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjAddressTB As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents chbUseMnemonic As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents tbNickname As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
    End Class

End Namespace