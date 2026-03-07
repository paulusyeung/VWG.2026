Namespace CompanionKit.Controls.MessageBoxControl.ApplicationScenario

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MessageBoxBuilderPage
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
            Me.mobjButtonShow = New Gizmox.WebGUI.Forms.Button()
            Me.mobjComboIcon = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjIconLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboButtons = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjButtonsLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextMessage = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjMessageLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextTitle = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjTitleLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjButtonShow
            '
            Me.mobjButtonShow.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjButtonShow.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjButtonShow.Location = New System.Drawing.Point(150, 360)
            Me.mobjButtonShow.Name = "mobjButtonShow"
            Me.mobjButtonShow.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonShow.TabIndex = 9
            Me.mobjButtonShow.Text = "Show"
            '
            'mobjComboIcon
            '
            Me.mobjComboIcon.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjComboIcon.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjComboIcon.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboIcon.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboIcon.Location = New System.Drawing.Point(10, 329)
            Me.mobjComboIcon.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjComboIcon.Name = "mobjComboIcon"
            Me.mobjComboIcon.Size = New System.Drawing.Size(380, 25)
            Me.mobjComboIcon.TabIndex = 8
            '
            'mobjIconLbl
            '
            Me.mobjIconLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjIconLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjIconLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjIconLbl.Location = New System.Drawing.Point(0, 280)
            Me.mobjIconLbl.Name = "mobjIconLbl"
            Me.mobjIconLbl.Size = New System.Drawing.Size(400, 40)
            Me.mobjIconLbl.TabIndex = 7
            Me.mobjIconLbl.Text = "Icon"
            Me.mobjIconLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjComboButtons
            '
            Me.mobjComboButtons.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjComboButtons.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjComboButtons.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboButtons.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjComboButtons.Location = New System.Drawing.Point(10, 249)
            Me.mobjComboButtons.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjComboButtons.Name = "mobjComboButtons"
            Me.mobjComboButtons.Size = New System.Drawing.Size(380, 25)
            Me.mobjComboButtons.TabIndex = 6
            '
            'mobjButtonsLbl
            '
            Me.mobjButtonsLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjButtonsLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButtonsLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjButtonsLbl.Location = New System.Drawing.Point(0, 200)
            Me.mobjButtonsLbl.Name = "mobjButtonsLbl"
            Me.mobjButtonsLbl.Size = New System.Drawing.Size(400, 40)
            Me.mobjButtonsLbl.TabIndex = 5
            Me.mobjButtonsLbl.Text = "Buttons"
            Me.mobjButtonsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTextMessage
            '
            Me.mobjTextMessage.AcceptsTab = True
            Me.mobjTextMessage.AllowDrag = False
            Me.mobjTextMessage.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextMessage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjTextMessage.Location = New System.Drawing.Point(10, 127)
            Me.mobjTextMessage.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3)
            Me.mobjTextMessage.Multiline = True
            Me.mobjTextMessage.Name = "mobjTextMessage"
            Me.mobjTextMessage.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjTextMessage.Size = New System.Drawing.Size(380, 65)
            Me.mobjTextMessage.TabIndex = 3
            Me.mobjTextMessage.Text = "MessageBox Line1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MessageBox Line2"
            Me.mobjTextMessage.WordWrap = False
            '
            'mobjMessageLbl
            '
            Me.mobjMessageLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjMessageLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMessageLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjMessageLbl.Location = New System.Drawing.Point(0, 80)
            Me.mobjMessageLbl.Name = "mobjMessageLbl"
            Me.mobjMessageLbl.Size = New System.Drawing.Size(400, 40)
            Me.mobjMessageLbl.TabIndex = 2
            Me.mobjMessageLbl.Text = "Message"
            Me.mobjMessageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTextTitle
            '
            Me.mobjTextTitle.AcceptsTab = True
            Me.mobjTextTitle.AllowDrag = False
            Me.mobjTextTitle.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextTitle.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjTextTitle.Location = New System.Drawing.Point(10, 47)
            Me.mobjTextTitle.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3)
            Me.mobjTextTitle.Name = "mobjTextTitle"
            Me.mobjTextTitle.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjTextTitle.Size = New System.Drawing.Size(380, 25)
            Me.mobjTextTitle.TabIndex = 1
            Me.mobjTextTitle.Text = "MessageBox Title"
            Me.mobjTextTitle.WordWrap = False
            '
            'mobjTitleLbl
            '
            Me.mobjTitleLbl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjTitleLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTitleLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjTitleLbl.Location = New System.Drawing.Point(0, 0)
            Me.mobjTitleLbl.Name = "mobjTitleLbl"
            Me.mobjTitleLbl.Size = New System.Drawing.Size(400, 40)
            Me.mobjTitleLbl.TabIndex = 0
            Me.mobjTitleLbl.Text = "Title"
            Me.mobjTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjTitleLbl, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjButtonShow, 0, 8)
            Me.mobjTLP.Controls.Add(Me.mobjComboIcon, 0, 7)
            Me.mobjTLP.Controls.Add(Me.mobjIconLbl, 0, 6)
            Me.mobjTLP.Controls.Add(Me.mobjComboButtons, 0, 5)
            Me.mobjTLP.Controls.Add(Me.mobjButtonsLbl, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjMessageLbl, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjTextTitle, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjTextMessage, 0, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 9
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(400, 400)
            Me.mobjTLP.TabIndex = 10
            '
            'MessageBoxBuilderPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(400, 400)
            Me.Text = "MessageBoxBuilderPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjButtonShow As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjComboIcon As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjIconLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjComboButtons As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjButtonsLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextMessage As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjMessageLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTextTitle As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjTitleLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace