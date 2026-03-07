Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ResizingPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.userIDColumn = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.userNameColumn = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.userPhoneColumn = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "The ListView to demonstrate column resizing:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.ColumnContent
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.userIDColumn, Me.userNameColumn, Me.userPhoneColumn})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(5, 57)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(310, 288)
            Me.mobjListView.TabIndex = 1
            Me.mobjListView.TotalItems = 1
            '
            'userIDColumn
            '
            Me.userIDColumn.Text = "User ID"
            Me.userIDColumn.Width = 50
            '
            'userNameColumn
            '
            Me.userNameColumn.Text = "User Name"
            Me.userNameColumn.Width = 120
            '
            'userPhoneColumn
            '
            Me.userPhoneColumn.Text = "User Phone"
            Me.userPhoneColumn.Width = 120
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
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 2
            '
            'ResizingPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "ResizingPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents userIDColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents userNameColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents userPhoneColumn As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
