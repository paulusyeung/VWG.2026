Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ViewsPage
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
            Me.userNameColumn = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.phoneColumn = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjDetailsRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjListRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjLargeIconRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjSmallIconRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 2
            Me.mobjInfoLabel.Text = "ListView with selected view type:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.userNameColumn, Me.phoneColumn})
            Me.mobjTLP.SetColumnSpan(Me.mobjListView, 2)
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(5, 65)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(310, 170)
            Me.mobjListView.TabIndex = 3
            Me.mobjListView.TotalItems = 1
            '
            'userNameColumn
            '
            Me.userNameColumn.Text = "User Name"
            Me.userNameColumn.Width = 120
            '
            'phoneColumn
            '
            Me.phoneColumn.Text = "Phone"
            Me.phoneColumn.Width = 120
            '
            'mobjDetailsRB
            '
            Me.mobjDetailsRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjDetailsRB.Checked = True
            Me.mobjDetailsRB.Location = New System.Drawing.Point(15, 260)
            Me.mobjDetailsRB.Name = "mobjDetailsRB"
            Me.mobjDetailsRB.Size = New System.Drawing.Size(130, 40)
            Me.mobjDetailsRB.TabIndex = 4
            Me.mobjDetailsRB.Text = "Details"
            Me.mobjDetailsRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListRB
            '
            Me.mobjListRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjListRB.Location = New System.Drawing.Point(15, 340)
            Me.mobjListRB.Name = "mobjListRB"
            Me.mobjListRB.Size = New System.Drawing.Size(130, 40)
            Me.mobjListRB.TabIndex = 5
            Me.mobjListRB.Text = "List"
            Me.mobjListRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjLargeIconRB
            '
            Me.mobjLargeIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLargeIconRB.Location = New System.Drawing.Point(175, 260)
            Me.mobjLargeIconRB.Name = "mobjLargeIconRB"
            Me.mobjLargeIconRB.Size = New System.Drawing.Size(130, 40)
            Me.mobjLargeIconRB.TabIndex = 6
            Me.mobjLargeIconRB.Text = "LargeIcon"
            Me.mobjLargeIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjSmallIconRB
            '
            Me.mobjSmallIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjSmallIconRB.Location = New System.Drawing.Point(175, 340)
            Me.mobjSmallIconRB.Name = "mobjSmallIconRB"
            Me.mobjSmallIconRB.Size = New System.Drawing.Size(130, 40)
            Me.mobjSmallIconRB.TabIndex = 7
            Me.mobjSmallIconRB.Text = "SmallIcon"
            Me.mobjSmallIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjListRB, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjSmallIconRB, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjLargeIconRB, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjDetailsRB, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 45.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 8
            '
            'ViewsPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ViewsPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents userNameColumn As ColumnHeader
        Friend WithEvents phoneColumn As ColumnHeader
        Friend WithEvents mobjDetailsRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjListRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjLargeIconRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjSmallIconRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel


	End Class

End Namespace
