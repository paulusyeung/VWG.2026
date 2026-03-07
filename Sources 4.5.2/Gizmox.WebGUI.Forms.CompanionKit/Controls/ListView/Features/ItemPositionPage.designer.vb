Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ItemPositionPage
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
            Me.mobjViewCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjXNumeric = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjYNumeric = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjXLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjYLabel = New Gizmox.WebGUI.Forms.Label()
            Me.tableLayoutPanel1 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjXNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mobjYNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.tableLayoutPanel1.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "NumericUpDowns show X and Y position of selected item:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjListView
            '
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnHeader1})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Items.AddRange(New Gizmox.WebGUI.Forms.ListViewItem() {Me.listViewItem1, Me.listViewItem2, Me.listViewItem3, Me.listViewItem4})
            Me.mobjListView.Location = New System.Drawing.Point(0, 60)
            Me.mobjListView.MultiSelect = False
            Me.mobjListView.Name = "mobjListView"
            Me.tableLayoutPanel1.SetRowSpan(Me.mobjListView, 2)
            Me.mobjListView.Size = New System.Drawing.Size(160, 220)
            Me.mobjListView.TabIndex = 1
            '
            'columnHeader1
            '
            Me.columnHeader1.Text = "Column"
            Me.columnHeader1.Width = 150
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
            'mobjViewCB
            '
            Me.mobjViewCB.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjViewCB.FormattingEnabled = True
            Me.mobjViewCB.Location = New System.Drawing.Point(165, 189)
            Me.mobjViewCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjViewCB.Name = "mobjViewCB"
            Me.mobjViewCB.Size = New System.Drawing.Size(150, 25)
            Me.mobjViewCB.TabIndex = 2
            Me.mobjViewCB.Text = "Details"
            '
            'mobjViewLabel
            '
            Me.mobjViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjViewLabel.Location = New System.Drawing.Point(160, 60)
            Me.mobjViewLabel.Name = "mobjViewLabel"
            Me.mobjViewLabel.Size = New System.Drawing.Size(160, 60)
            Me.mobjViewLabel.TabIndex = 3
            Me.mobjViewLabel.Text = "View:"
            Me.mobjViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjXNumeric
            '
            Me.mobjXNumeric.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjXNumeric.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjXNumeric.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjXNumeric.Increment = New Decimal(New Integer() {5, 0, 0, 0})
            Me.mobjXNumeric.Location = New System.Drawing.Point(160, 299)
            Me.mobjXNumeric.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjXNumeric.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjXNumeric.Name = "mobjXNumeric"
            Me.mobjXNumeric.Size = New System.Drawing.Size(160, 21)
            Me.mobjXNumeric.TabIndex = 4
            '
            'mobjYNumeric
            '
            Me.mobjYNumeric.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjYNumeric.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjYNumeric.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjYNumeric.Increment = New Decimal(New Integer() {5, 0, 0, 0})
            Me.mobjYNumeric.Location = New System.Drawing.Point(160, 359)
            Me.mobjYNumeric.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me.mobjYNumeric.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjYNumeric.Name = "mobjYNumeric"
            Me.mobjYNumeric.Size = New System.Drawing.Size(160, 21)
            Me.mobjYNumeric.TabIndex = 5
            '
            'mobjXLabel
            '
            Me.mobjXLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjXLabel.Location = New System.Drawing.Point(0, 280)
            Me.mobjXLabel.Name = "mobjXLabel"
            Me.mobjXLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjXLabel.Size = New System.Drawing.Size(160, 60)
            Me.mobjXLabel.TabIndex = 6
            Me.mobjXLabel.Text = "X"
            Me.mobjXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjYLabel
            '
            Me.mobjYLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjYLabel.Location = New System.Drawing.Point(0, 340)
            Me.mobjYLabel.Name = "mobjYLabel"
            Me.mobjYLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjYLabel.Size = New System.Drawing.Size(160, 60)
            Me.mobjYLabel.TabIndex = 7
            Me.mobjYLabel.Text = "Y"
            Me.mobjYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tableLayoutPanel1
            '
            Me.tableLayoutPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.tableLayoutPanel1.ColumnCount = 2
            Me.tableLayoutPanel1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.tableLayoutPanel1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.tableLayoutPanel1.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjYLabel, 0, 4)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjListView, 0, 1)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjXLabel, 0, 3)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjViewLabel, 1, 1)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjYNumeric, 1, 4)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjViewCB, 1, 2)
            Me.tableLayoutPanel1.Controls.Add(Me.mobjXNumeric, 1, 3)
            Me.tableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.tableLayoutPanel1.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
            Me.tableLayoutPanel1.RowCount = 5
            Me.tableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.tableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.tableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.tableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.tableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.tableLayoutPanel1.Size = New System.Drawing.Size(320, 400)
            Me.tableLayoutPanel1.TabIndex = 8
            '
            'ItemPositionPage
            '
            Me.Controls.Add(Me.tableLayoutPanel1)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ItemPositionPage"
            CType(Me.mobjXNumeric, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mobjYNumeric, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private WithEvents mobjViewCB As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjViewLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjXNumeric As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjYNumeric As Gizmox.WebGUI.Forms.NumericUpDown
        Private WithEvents mobjXLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjYLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents columnHeader1 As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents listViewItem1 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem2 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem3 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem4 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents tableLayoutPanel1 As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace