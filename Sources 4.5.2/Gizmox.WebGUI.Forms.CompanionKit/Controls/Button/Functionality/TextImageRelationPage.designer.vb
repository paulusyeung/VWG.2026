Namespace CompanionKit.Controls.Button.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextImageRelationPage
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextImageRelationPage))
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextImageLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjImageLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTextImageCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjImageCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTextCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjButton
            '
            Me.mobjButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTLP.SetColumnSpan(Me.mobjButton, 2)
            Me.mobjButton.Image = New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjButton.Image"))
            Me.mobjButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.mobjButton.Location = New System.Drawing.Point(92, 89)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(135, 65)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "button"
            Me.mobjButton.TextAlign = System.Drawing.ContentAlignment.TopLeft
            Me.mobjButton.UseVisualStyleBackColor = True
            '
            'mobjLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjLabel, 2)
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Button with text and image:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTextImageLbl
            '
            Me.mobjTextImageLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextImageLbl.Location = New System.Drawing.Point(0, 192)
            Me.mobjTextImageLbl.Name = "mobjTextImageLbl"
            Me.mobjTextImageLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextImageLbl.Size = New System.Drawing.Size(160, 52)
            Me.mobjTextImageLbl.TabIndex = 2
            Me.mobjTextImageLbl.Text = "Text Image Relation"
            Me.mobjTextImageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjImageLbl
            '
            Me.mobjImageLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjImageLbl.Location = New System.Drawing.Point(0, 244)
            Me.mobjImageLbl.Name = "mobjImageLbl"
            Me.mobjImageLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjImageLbl.Size = New System.Drawing.Size(160, 52)
            Me.mobjImageLbl.TabIndex = 3
            Me.mobjImageLbl.Text = "Image Align"
            Me.mobjImageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTextLbl
            '
            Me.mobjTextLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLbl.Location = New System.Drawing.Point(0, 296)
            Me.mobjTextLbl.Name = "mobjTextLbl"
            Me.mobjTextLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjTextLbl.Size = New System.Drawing.Size(160, 54)
            Me.mobjTextLbl.TabIndex = 4
            Me.mobjTextLbl.Text = "Text Align"
            Me.mobjTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTextImageCB
            '
            Me.mobjTextImageCB.AllowDrag = False
            Me.mobjTextImageCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextImageCB.FormattingEnabled = True
            Me.mobjTextImageCB.Location = New System.Drawing.Point(160, 207)
            Me.mobjTextImageCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextImageCB.Name = "mobjTextImageCB"
            Me.mobjTextImageCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjTextImageCB.TabIndex = 5
            '
            'mobjImageCB
            '
            Me.mobjImageCB.AllowDrag = False
            Me.mobjImageCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjImageCB.FormattingEnabled = True
            Me.mobjImageCB.Location = New System.Drawing.Point(160, 259)
            Me.mobjImageCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjImageCB.Name = "mobjImageCB"
            Me.mobjImageCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjImageCB.TabIndex = 6
            '
            'mobjTextCB
            '
            Me.mobjTextCB.AllowDrag = False
            Me.mobjTextCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextCB.FormattingEnabled = True
            Me.mobjTextCB.Location = New System.Drawing.Point(160, 312)
            Me.mobjTextCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTextCB.Name = "mobjTextCB"
            Me.mobjTextCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjTextCB.TabIndex = 7
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjTextCB, 1, 4)
            Me.mobjTLP.Controls.Add(Me.mobjButton, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjImageCB, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjTextImageLbl, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjTextImageCB, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjImageLbl, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjTextLbl, 0, 4)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 8
            '
            'TextImageRelationPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "TextImageRelationPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTextImageLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjImageLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTextLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTextImageCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjImageCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTextCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
