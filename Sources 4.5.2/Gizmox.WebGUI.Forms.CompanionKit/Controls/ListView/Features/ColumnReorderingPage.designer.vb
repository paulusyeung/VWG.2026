Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ColumnReorderingPage
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
            Me.allowedReorderingColumnListView = New Gizmox.WebGUI.Forms.ListView()
            Me.userIDColumnWithReordering = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.userFirstNameColumnWithReordering = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.userSecondNameColumnWithReordering = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.unallowedReorderingColumnListView = New Gizmox.WebGUI.Forms.ListView()
            Me.userIDColumnWithoutReordering = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.userFirstNameColumnWithoutReordering = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.userSecondNameColumnWithoutReordering = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'allowedReorderingColumnListView
            '
            Me.allowedReorderingColumnListView.AllowColumnReorder = True
            Me.allowedReorderingColumnListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.userIDColumnWithReordering, Me.userFirstNameColumnWithReordering, Me.userSecondNameColumnWithReordering})
            Me.allowedReorderingColumnListView.DataMember = Nothing
            Me.allowedReorderingColumnListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.allowedReorderingColumnListView.Location = New System.Drawing.Point(5, 65)
            Me.allowedReorderingColumnListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.allowedReorderingColumnListView.Name = "listView1"
            Me.allowedReorderingColumnListView.Size = New System.Drawing.Size(310, 130)
            Me.allowedReorderingColumnListView.TabIndex = 0
            Me.allowedReorderingColumnListView.TotalItems = 1
            '
            'userIDColumnWithReordering
            '
            Me.userIDColumnWithReordering.Text = "User ID"
            Me.userIDColumnWithReordering.Width = 50
            '
            'userFirstNameColumnWithReordering
            '
            Me.userFirstNameColumnWithReordering.Text = "User First Name"
            Me.userFirstNameColumnWithReordering.Width = 120
            '
            'userSecondNameColumnWithReordering
            '
            Me.userSecondNameColumnWithReordering.Text = "User Second Name"
            Me.userSecondNameColumnWithReordering.Width = 120
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(320, 60)
            Me.mobjLabel1.TabIndex = 1
            Me.mobjLabel1.Text = "ListView with allowed reordering of columns:"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'unallowedReorderingColumnListView
            '
            Me.unallowedReorderingColumnListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.userIDColumnWithoutReordering, Me.userFirstNameColumnWithoutReordering, Me.userSecondNameColumnWithoutReordering})
            Me.unallowedReorderingColumnListView.DataMember = Nothing
            Me.unallowedReorderingColumnListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.unallowedReorderingColumnListView.Location = New System.Drawing.Point(5, 265)
            Me.unallowedReorderingColumnListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.unallowedReorderingColumnListView.Name = "unallowedReorderingColumnListView"
            Me.unallowedReorderingColumnListView.Size = New System.Drawing.Size(310, 130)
            Me.unallowedReorderingColumnListView.TabIndex = 3
            Me.unallowedReorderingColumnListView.TotalItems = 1
            '
            'userIDColumnWithoutReordering
            '
            Me.userIDColumnWithoutReordering.Text = "User ID"
            Me.userIDColumnWithoutReordering.Width = 50
            '
            'userFirstNameColumnWithoutReordering
            '
            Me.userFirstNameColumnWithoutReordering.Text = "User First Name"
            Me.userFirstNameColumnWithoutReordering.Width = 120
            '
            'userSecondNameColumnWithoutReordering
            '
            Me.userSecondNameColumnWithoutReordering.Text = "User Second Name"
            Me.userSecondNameColumnWithoutReordering.Width = 120
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(0, 200)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(320, 60)
            Me.mobjLabel2.TabIndex = 4
            Me.mobjLabel2.Text = "ListView with unallowed reordering of columns:"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 0, 2)
            Me.mobjTLP.Controls.Add(Me.unallowedReorderingColumnListView, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 0, 0)
            Me.mobjTLP.Controls.Add(Me.allowedReorderingColumnListView, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 5
            '
            'ColumnReorderingPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ColumnReorderingPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents allowedReorderingColumnListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents userIDColumnWithReordering As ColumnHeader
        Friend WithEvents userFirstNameColumnWithReordering As ColumnHeader
        Friend WithEvents userSecondNameColumnWithReordering As ColumnHeader
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents unallowedReorderingColumnListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents mobjLabel2 As Label
        Friend WithEvents userIDColumnWithoutReordering As ColumnHeader
        Friend WithEvents userFirstNameColumnWithoutReordering As ColumnHeader
        Friend WithEvents userSecondNameColumnWithoutReordering As ColumnHeader
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
