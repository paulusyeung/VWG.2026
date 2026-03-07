Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class LabelEditPage
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
            Me.listViewItem1 = New Gizmox.WebGUI.Forms.ListViewItem("item1")
            Me.listViewItem2 = New Gizmox.WebGUI.Forms.ListViewItem("item2")
            Me.listViewItem3 = New Gizmox.WebGUI.Forms.ListViewItem("item3")
            Me.listViewItem4 = New Gizmox.WebGUI.Forms.ListViewItem("item4")
            Me.listViewItem5 = New Gizmox.WebGUI.Forms.ListViewItem("item5")
            Me.mobjViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjEditCheck = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjDetailsRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjListRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjLargeIconRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjSmallIconRB = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTLPMain = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLPView = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLPMain.SuspendLayout()
            Me.mobjTLPView.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLPMain.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 80)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Use LabelEdit property to edit item's text:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnHeader1})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Items.AddRange(New Gizmox.WebGUI.Forms.ListViewItem() {Me.listViewItem1, Me.listViewItem2, Me.listViewItem3, Me.listViewItem4, Me.listViewItem5})
            Me.mobjListView.Location = New System.Drawing.Point(0, 80)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(160, 240)
            Me.mobjListView.TabIndex = 1
            '
            'columnHeader1
            '
            Me.columnHeader1.Text = "Column"
            Me.columnHeader1.Width = 119
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
            'mobjViewLabel
            '
            Me.mobjViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjViewLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjViewLabel.Name = "mobjViewLabel"
            Me.mobjViewLabel.Size = New System.Drawing.Size(160, 48)
            Me.mobjViewLabel.TabIndex = 3
            Me.mobjViewLabel.Text = "View:"
            Me.mobjViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjEditCheck
            '
            Me.mobjEditCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTLPMain.SetColumnSpan(Me.mobjEditCheck, 2)
            Me.mobjEditCheck.Location = New System.Drawing.Point(85, 340)
            Me.mobjEditCheck.Name = "mobjEditCheck"
            Me.mobjEditCheck.Size = New System.Drawing.Size(150, 40)
            Me.mobjEditCheck.TabIndex = 4
            Me.mobjEditCheck.Text = "LabelEdit"
            Me.mobjEditCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjDetailsRB
            '
            Me.mobjDetailsRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjDetailsRB.Checked = True
            Me.mobjDetailsRB.Location = New System.Drawing.Point(20, 57)
            Me.mobjDetailsRB.Name = "mobjDetailsRB"
            Me.mobjDetailsRB.Size = New System.Drawing.Size(120, 30)
            Me.mobjDetailsRB.TabIndex = 5
            Me.mobjDetailsRB.Text = "Details"
            Me.mobjDetailsRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListRB
            '
            Me.mobjListRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjListRB.Location = New System.Drawing.Point(20, 105)
            Me.mobjListRB.Name = "mobjListRB"
            Me.mobjListRB.Size = New System.Drawing.Size(120, 30)
            Me.mobjListRB.TabIndex = 6
            Me.mobjListRB.Text = "List"
            Me.mobjListRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjLargeIconRB
            '
            Me.mobjLargeIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjLargeIconRB.Location = New System.Drawing.Point(20, 153)
            Me.mobjLargeIconRB.Name = "mobjLargeIconRB"
            Me.mobjLargeIconRB.Size = New System.Drawing.Size(120, 30)
            Me.mobjLargeIconRB.TabIndex = 7
            Me.mobjLargeIconRB.Text = "LargeIcon"
            Me.mobjLargeIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjSmallIconRB
            '
            Me.mobjSmallIconRB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjSmallIconRB.Location = New System.Drawing.Point(20, 201)
            Me.mobjSmallIconRB.Name = "mobjSmallIconRB"
            Me.mobjSmallIconRB.Size = New System.Drawing.Size(120, 30)
            Me.mobjSmallIconRB.TabIndex = 8
            Me.mobjSmallIconRB.Text = "SmallIcon"
            Me.mobjSmallIconRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLPMain
            '
            Me.mobjTLPMain.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLPMain.ColumnCount = 2
            Me.mobjTLPMain.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLPMain.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLPMain.Controls.Add(Me.mobjTLPView, 1, 1)
            Me.mobjTLPMain.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLPMain.Controls.Add(Me.mobjListView, 0, 1)
            Me.mobjTLPMain.Controls.Add(Me.mobjEditCheck, 0, 2)
            Me.mobjTLPMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLPMain.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLPMain.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLPMain.Name = "mobjTLPMain"
            Me.mobjTLPMain.RowCount = 3
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0!))
            Me.mobjTLPMain.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPMain.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLPMain.TabIndex = 9
            '
            'mobjTLPView
            '
            Me.mobjTLPView.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjTLPView.ColumnCount = 1
            Me.mobjTLPView.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLPView.Controls.Add(Me.mobjViewLabel, 0, 0)
            Me.mobjTLPView.Controls.Add(Me.mobjDetailsRB, 0, 1)
            Me.mobjTLPView.Controls.Add(Me.mobjSmallIconRB, 0, 4)
            Me.mobjTLPView.Controls.Add(Me.mobjListRB, 0, 2)
            Me.mobjTLPView.Controls.Add(Me.mobjLargeIconRB, 0, 3)
            Me.mobjTLPView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLPView.Location = New System.Drawing.Point(160, 80)
            Me.mobjTLPView.Name = "mobjTLPView"
            Me.mobjTLPView.RowCount = 5
            Me.mobjTLPView.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPView.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPView.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPView.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPView.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLPView.Size = New System.Drawing.Size(160, 240)
            Me.mobjTLPView.TabIndex = 10
            '
            'LabelEditPage
            '
            Me.Controls.Add(Me.mobjTLPMain)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "LabelEditPage"
            Me.mobjTLPMain.ResumeLayout(False)
            Me.mobjTLPView.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents mobjViewLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjEditCheck As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents columnHeader1 As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents listViewItem1 As Gizmox.WebGUI.Forms.ListViewItem
        Friend WithEvents listViewItem2 As Gizmox.WebGUI.Forms.ListViewItem
        Friend WithEvents listViewItem3 As Gizmox.WebGUI.Forms.ListViewItem
        Friend WithEvents listViewItem4 As Gizmox.WebGUI.Forms.ListViewItem
        Friend WithEvents listViewItem5 As Gizmox.WebGUI.Forms.ListViewItem
        Friend WithEvents mobjDetailsRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjListRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjLargeIconRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjSmallIconRB As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjTLPMain As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLPView As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace