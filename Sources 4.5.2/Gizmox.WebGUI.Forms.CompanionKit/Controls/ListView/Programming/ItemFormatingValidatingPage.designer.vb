Namespace CompanionKit.Controls.ListView.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ItemFormatingValidatingPage
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
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.columnUserName = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnPhone = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjForecolorLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjBackcolorLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjResultLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjForeCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjBackCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjLabel, 2)
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 120)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "ListView with handling ItemFormatting event:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnUserName, Me.columnPhone})
            Me.mobjTLP.SetColumnSpan(Me.mobjListView, 2)
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(5, 185)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.MultiSelect = False
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(310, 150)
            Me.mobjListView.TabIndex = 1
            Me.mobjListView.TotalItems = 1
            '
            'columnUserName
            '
            Me.columnUserName.Text = "User Name"
            Me.columnUserName.Width = 108
            '
            'columnPhone
            '
            Me.columnPhone.Text = "Phone"
            Me.columnPhone.Width = 132
            '
            'mobjForecolorLbl
            '
            Me.mobjForecolorLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjForecolorLbl.Location = New System.Drawing.Point(0, 60)
            Me.mobjForecolorLbl.Name = "mobjForecolorLbl"
            Me.mobjForecolorLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjForecolorLbl.Size = New System.Drawing.Size(160, 60)
            Me.mobjForecolorLbl.TabIndex = 2
            Me.mobjForecolorLbl.Text = "Foreground color"
            Me.mobjForecolorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjBackcolorLbl
            '
            Me.mobjBackcolorLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBackcolorLbl.Location = New System.Drawing.Point(0, 0)
            Me.mobjBackcolorLbl.Name = "mobjBackcolorLbl"
            Me.mobjBackcolorLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjBackcolorLbl.Size = New System.Drawing.Size(160, 60)
            Me.mobjBackcolorLbl.TabIndex = 3
            Me.mobjBackcolorLbl.Text = "Background color"
            Me.mobjBackcolorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjResultLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjResultLabel, 2)
            Me.mobjResultLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjResultLabel.Location = New System.Drawing.Point(0, 340)
            Me.mobjResultLabel.Name = "mobjResultLabel"
            Me.mobjResultLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjResultLabel.TabIndex = 4
            Me.mobjResultLabel.Text = "result of formatting"
            Me.mobjResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjForeCB
            '
            Me.mobjForeCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjForeCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjForeCB.Location = New System.Drawing.Point(160, 79)
            Me.mobjForeCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjForeCB.Name = "mobjForeCB"
            Me.mobjForeCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjForeCB.TabIndex = 5
            '
            'mobjBackCB
            '
            Me.mobjBackCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjBackCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjBackCB.Location = New System.Drawing.Point(160, 19)
            Me.mobjBackCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjBackCB.Name = "mobjBackCB"
            Me.mobjBackCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjBackCB.TabIndex = 6
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjBackcolorLbl, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjResultLabel, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjForeCB, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjBackCB, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjForecolorLbl, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 7
            '
            'ItemFormatingValidatingPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ItemFormatingValidatingPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents columnUserName As ColumnHeader
        Friend WithEvents columnPhone As ColumnHeader
        Friend WithEvents mobjForecolorLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjBackcolorLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjResultLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjForeCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjBackCB As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
