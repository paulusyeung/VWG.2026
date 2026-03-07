Namespace CompanionKit.Controls.ListView.Performance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PagingPage
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
            Me.listViewWithPaging = New Gizmox.WebGUI.Forms.ListView()
            Me.columnUserNameWithPaging = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnEmailWithPaging = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.listViewWithoutPaging = New Gizmox.WebGUI.Forms.ListView()
            Me.columnUserNameWithoutPaging = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnEmailWithoutPaging = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPerPageLabel = New Gizmox.WebGUI.Forms.Label()
            Me.itemsPerPagesNumUpDown = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.itemsPerPagesNumUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'listViewWithPaging
            '
            Me.listViewWithPaging.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnUserNameWithPaging, Me.columnEmailWithPaging})
            Me.mobjTLP.SetColumnSpan(Me.listViewWithPaging, 2)
            Me.listViewWithPaging.DataMember = Nothing
            Me.listViewWithPaging.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.listViewWithPaging.Location = New System.Drawing.Point(0, 120)
            Me.listViewWithPaging.Name = "listView1"
            Me.listViewWithPaging.Size = New System.Drawing.Size(320, 110)
            Me.listViewWithPaging.TabIndex = 0
            Me.listViewWithPaging.UseInternalPaging = True
            '
            'columnUserNameWithPaging
            '
            Me.columnUserNameWithPaging.Text = "User Name"
            Me.columnUserNameWithPaging.Width = 94
            '
            'columnEmailWithPaging
            '
            Me.columnEmailWithPaging.Text = "E-mail"
            Me.columnEmailWithPaging.Width = 137
            '
            'mobjLabel1
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjLabel1, 2)
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 60)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(320, 60)
            Me.mobjLabel1.TabIndex = 1
            Me.mobjLabel1.Text = "ListView with paging items:"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'listViewWithoutPaging
            '
            Me.listViewWithoutPaging.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnUserNameWithoutPaging, Me.columnEmailWithoutPaging})
            Me.mobjTLP.SetColumnSpan(Me.listViewWithoutPaging, 2)
            Me.listViewWithoutPaging.DataMember = Nothing
            Me.listViewWithoutPaging.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.listViewWithoutPaging.Location = New System.Drawing.Point(0, 290)
            Me.listViewWithoutPaging.Name = "listViewWithoutPaging"
            Me.listViewWithoutPaging.Size = New System.Drawing.Size(320, 110)
            Me.listViewWithoutPaging.TabIndex = 3
            Me.listViewWithoutPaging.TotalItems = 1
            '
            'columnUserNameWithoutPaging
            '
            Me.columnUserNameWithoutPaging.Text = "User Name"
            Me.columnUserNameWithoutPaging.Width = 95
            '
            'columnEmailWithoutPaging
            '
            Me.columnEmailWithoutPaging.Text = "Email"
            Me.columnEmailWithoutPaging.Width = 135
            '
            'mobjLabel2
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjLabel2, 2)
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(0, 230)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(320, 60)
            Me.mobjLabel2.TabIndex = 4
            Me.mobjLabel2.Text = "ListView without paging items:"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjPerPageLabel
            '
            Me.mobjPerPageLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPerPageLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPerPageLabel.Name = "mobjPerPageLabel"
            Me.mobjPerPageLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjPerPageLabel.Size = New System.Drawing.Size(160, 60)
            Me.mobjPerPageLabel.TabIndex = 5
            Me.mobjPerPageLabel.Text = "ItemsPerPage"
            Me.mobjPerPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'itemsPerPagesNumUpDown
            '
            Me.itemsPerPagesNumUpDown.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.itemsPerPagesNumUpDown.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.itemsPerPagesNumUpDown.CurrentValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.itemsPerPagesNumUpDown.Location = New System.Drawing.Point(160, 19)
            Me.itemsPerPagesNumUpDown.MaximumSize = New System.Drawing.Size(200, 0)
            Me.itemsPerPagesNumUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.itemsPerPagesNumUpDown.Name = "numericUpDown1"
            Me.itemsPerPagesNumUpDown.Size = New System.Drawing.Size(160, 21)
            Me.itemsPerPagesNumUpDown.TabIndex = 6
            Me.itemsPerPagesNumUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjPerPageLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.listViewWithoutPaging, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 0, 3)
            Me.mobjTLP.Controls.Add(Me.itemsPerPagesNumUpDown, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 0, 1)
            Me.mobjTLP.Controls.Add(Me.listViewWithPaging, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.5!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 27.5!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 7
            '
            'PagingPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "PagingPage"
            CType(Me.itemsPerPagesNumUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents listViewWithPaging As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents columnUserNameWithPaging As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents columnEmailWithPaging As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents listViewWithoutPaging As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents columnUserNameWithoutPaging As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents columnEmailWithoutPaging As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjPerPageLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents itemsPerPagesNumUpDown As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
