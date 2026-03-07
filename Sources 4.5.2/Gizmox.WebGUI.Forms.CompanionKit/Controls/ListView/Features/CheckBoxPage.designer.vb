Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CheckBoxPage
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
            Me.columnHeader1 = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnHeader2 = CType(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.listViewItem1 = New Gizmox.WebGUI.Forms.ListViewItem(New String() {"item1", "subitem1"}, -1)
            Me.listViewItem2 = New Gizmox.WebGUI.Forms.ListViewItem(New String() {"item2", "subitem2"}, -1)
            Me.listViewItem3 = New Gizmox.WebGUI.Forms.ListViewItem(New String() {"item3", "subitem3"}, -1)
            Me.listViewItem4 = New Gizmox.WebGUI.Forms.ListViewItem(New String() {"item4", "subitem4"}, -1)
            Me.listViewItem5 = New Gizmox.WebGUI.Forms.ListViewItem(New String() {"item5", "subitem5"}, -1)
            Me.mobjGridCheck = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjBoxesCheck = New Gizmox.WebGUI.Forms.CheckBox()
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
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Show or hide grid lines and check boxes in ListView:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
            Me.mobjTLP.SetColumnSpan(Me.mobjListView, 2)
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Items.AddRange(New Gizmox.WebGUI.Forms.ListViewItem() {Me.listViewItem1, Me.listViewItem2, Me.listViewItem3, Me.listViewItem4, Me.listViewItem5})
            Me.mobjListView.Location = New System.Drawing.Point(5, 145)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(310, 250)
            Me.mobjListView.TabIndex = 1
            '
            'columnHeader1
            '
            Me.columnHeader1.Text = "Column1"
            Me.columnHeader1.Width = 95
            '
            'columnHeader2
            '
            Me.columnHeader2.Text = "Column2"
            Me.columnHeader2.Width = 117
            '
            'listViewItem1
            '
            Me.listViewItem1.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem1.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem1.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem1.Text = "item1"
            '
            'listViewItem2
            '
            Me.listViewItem2.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem2.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem2.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem2.Text = "item2"
            '
            'listViewItem3
            '
            Me.listViewItem3.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem3.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem3.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem3.Text = "item3"
            '
            'listViewItem4
            '
            Me.listViewItem4.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem4.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem4.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem4.Text = "item4"
            '
            'listViewItem5
            '
            Me.listViewItem5.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem5.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem5.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem5.Text = "item5"
            '
            'mobjGridCheck
            '
            Me.mobjGridCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjGridCheck.Location = New System.Drawing.Point(30, 80)
            Me.mobjGridCheck.Name = "mobjGridCheck"
            Me.mobjGridCheck.Size = New System.Drawing.Size(130, 40)
            Me.mobjGridCheck.TabIndex = 2
            Me.mobjGridCheck.Text = "GridLines"
            Me.mobjGridCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjBoxesCheck
            '
            Me.mobjBoxesCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjBoxesCheck.Location = New System.Drawing.Point(180, 80)
            Me.mobjBoxesCheck.Name = "mobjBoxesCheck"
            Me.mobjBoxesCheck.Size = New System.Drawing.Size(130, 40)
            Me.mobjBoxesCheck.TabIndex = 3
            Me.mobjBoxesCheck.Text = "CheckBoxes"
            Me.mobjBoxesCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjBoxesCheck, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjGridCheck, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 4
            '
            'CheckBoxPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "CheckBoxPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private WithEvents columnHeader1 As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents columnHeader2 As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents listViewItem1 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem2 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem3 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem4 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem5 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents mobjGridCheck As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjBoxesCheck As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
