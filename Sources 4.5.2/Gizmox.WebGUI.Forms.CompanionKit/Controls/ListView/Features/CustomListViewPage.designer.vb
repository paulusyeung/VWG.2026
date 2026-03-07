Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CustomListViewPage
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
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.columnUserID = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnUserName = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnPhoto = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnVisitDate = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnPhone = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnCheckBox = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnUserID, Me.columnUserName, Me.columnPhoto, Me.columnVisitDate, Me.columnPhone, Me.columnCheckBox})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Font = New System.Drawing.Font("Tahoma", 10.25!)
            Me.mobjListView.Location = New System.Drawing.Point(5, 65)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(310, 330)
            Me.mobjListView.TabIndex = 0
            Me.mobjListView.TotalItems = 1
            '
            'columnUserID
            '
            Me.columnUserID.Text = "User ID"
            Me.columnUserID.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center
            Me.columnUserID.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Number
            Me.columnUserID.Width = 69
            '
            'columnUserName
            '
            Me.columnUserName.Text = "User Name"
            Me.columnUserName.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center
            Me.columnUserName.Width = 91
            '
            'columnPhoto
            '
            Me.columnPhoto.Text = "Photo"
            Me.columnPhoto.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center
            Me.columnPhoto.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.columnPhoto.Width = 50
            '
            'columnVisitDate
            '
            Me.columnVisitDate.Text = "Visit Date"
            Me.columnVisitDate.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center
            Me.columnVisitDate.Type = Gizmox.WebGUI.Forms.ListViewColumnType.[Date]
            Me.columnVisitDate.Width = 90
            '
            'columnPhone
            '
            Me.columnPhone.Text = "Phone"
            Me.columnPhone.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center
            Me.columnPhone.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control
            Me.columnPhone.Width = 164
            '
            'columnCheckBox
            '
            Me.columnCheckBox.Text = "VIP"
            Me.columnCheckBox.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center
            Me.columnCheckBox.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control
            Me.columnCheckBox.Width = 50
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "ListView with a custom control in the item:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 2
            '
            'CustomListViewPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "CustomListViewPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents columnUserID As ColumnHeader
        Friend WithEvents columnUserName As ColumnHeader
        Friend WithEvents columnPhone As ColumnHeader
        Friend WithEvents columnCheckBox As ColumnHeader
        Friend WithEvents columnPhoto As ColumnHeader
        Friend WithEvents columnVisitDate As ColumnHeader
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace