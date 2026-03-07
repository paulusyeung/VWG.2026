Namespace CompanionKit.Controls.ClientStorage.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ExecutingQueriesPage
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
            Me.mobjClientStorage = New Gizmox.WebGUI.Forms.Client.ClientStorage()
            Me.mobjClientTable = New Gizmox.WebGUI.Forms.Client.ClientTable()
            Me.mobjIdClientTableColumn = New Gizmox.WebGUI.Forms.Client.ClientTableColumn("Id", Gizmox.WebGUI.Forms.Client.ClientStorageDataType.[Integer], "", True, True, True)
            Me.mobjUsersClientTableColumn = New Gizmox.WebGUI.Forms.Client.ClientTableColumn("Users", Gizmox.WebGUI.Forms.Client.ClientStorageDataType.Text, "", False, False, False)
            Me.mobjCommonLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.mobjIdColumn = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjUsersColumn = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjTopLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBoxList = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.mobjQueryTypeLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjRadioButtonDelete = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButtonInsert = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButtonSelect = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjQueryTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjRunButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjBottomLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInitButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjCommonLayoutPanel.SuspendLayout()
            Me.mobjTopLayoutPanel.SuspendLayout()
            Me.mobjQueryTypeLayoutPanel.SuspendLayout()
            Me.mobjBottomLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjClientStorage
            ' 
            Me.mobjClientStorage.Description = ""
            Me.mobjClientStorage.MajorVersion = CUShort(1)
            Me.mobjClientStorage.MinorVersion = CUShort(0)
            Me.mobjClientStorage.Name = "objClientStorage"
            Me.mobjClientStorage.Tables.Add(Me.mobjClientTable)
            ' 
            ' mobjClientTable
            ' 
            Me.mobjClientTable.Columns.Add(Me.mobjIdClientTableColumn)
            Me.mobjClientTable.Columns.Add(Me.mobjUsersClientTableColumn)
            Me.mobjClientTable.Name = "objClientTable"
            ' 
            ' mobjCommonLayoutPanel
            ' 
            Me.mobjCommonLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjCommonLayoutPanel.ColumnCount = 1
            Me.mobjCommonLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjListView, 0, 2)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjTopLayoutPanel, 0, 0)
            Me.mobjCommonLayoutPanel.Controls.Add(Me.mobjQueryTextBox, 0, 1)
            Me.mobjCommonLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCommonLayoutPanel.Location = New System.Drawing.Point(15, 15)
            Me.mobjCommonLayoutPanel.Name = "objCommonLayoutPanel"
            Me.mobjCommonLayoutPanel.RowCount = 3
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 170.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjCommonLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjCommonLayoutPanel.Size = New System.Drawing.Size(917, 335)
            Me.mobjCommonLayoutPanel.TabIndex = 0
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.ClientId = "listView"
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.mobjIdColumn, Me.mobjUsersColumn})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(0, 210)
            Me.mobjListView.Name = "objListView"
            Me.mobjListView.Size = New System.Drawing.Size(348, 255)
            Me.mobjListView.TabIndex = 0
            ' 
            ' mobjIdColumn
            ' 
            Me.mobjIdColumn.ClientId = "Id"
            Me.mobjIdColumn.Text = "Id"
            Me.mobjIdColumn.Width = 150
            ' 
            ' mobjUsersColumn
            ' 
            Me.mobjUsersColumn.ClientId = "Users"
            Me.mobjUsersColumn.Text = "Users"
            Me.mobjUsersColumn.Width = 150
            ' 
            ' mobjTopLayoutPanel
            ' 
            Me.mobjTopLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTopLayoutPanel.ColumnCount = 1
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjCheckBoxList, 0, 1)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjQueryTypeLayoutPanel, 0, 2)
            Me.mobjTopLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopLayoutPanel.Name = "objTopLayoutPanel"
            Me.mobjTopLayoutPanel.RowCount = 3
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjTopLayoutPanel.Size = New System.Drawing.Size(348, 170)
            Me.mobjTopLayoutPanel.TabIndex = 0
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "objInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(348, 50)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Note: This sample works only in WebKit"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjCheckBoxList
            ' 
            Me.mobjCheckBoxList.CheckOnClick = True
            Me.mobjCheckBoxList.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckBoxList.Items.AddRange(New Object() {"Id", "Users"})
            Me.mobjCheckBoxList.Location = New System.Drawing.Point(0, 50)
            Me.mobjCheckBoxList.Name = "objCheckBoxList"
            Me.mobjCheckBoxList.Size = New System.Drawing.Size(348, 68)
            Me.mobjCheckBoxList.TabIndex = 0
            ' 
            ' mobjQueryTypeLayoutPanel
            ' 
            Me.mobjQueryTypeLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjQueryTypeLayoutPanel.ColumnCount = 3
            Me.mobjQueryTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjQueryTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjQueryTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjQueryTypeLayoutPanel.Controls.Add(Me.mobjRadioButtonDelete, 2, 0)
            Me.mobjQueryTypeLayoutPanel.Controls.Add(Me.mobjRadioButtonInsert, 1, 0)
            Me.mobjQueryTypeLayoutPanel.Controls.Add(Me.mobjRadioButtonSelect, 0, 0)
            Me.mobjQueryTypeLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjQueryTypeLayoutPanel.Location = New System.Drawing.Point(0, 120)
            Me.mobjQueryTypeLayoutPanel.Name = "objQueryTypeLayoutPanel"
            Me.mobjQueryTypeLayoutPanel.RowCount = 1
            Me.mobjQueryTypeLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjQueryTypeLayoutPanel.Size = New System.Drawing.Size(348, 50)
            Me.mobjQueryTypeLayoutPanel.TabIndex = 0
            Me.mobjQueryTypeLayoutPanel.TabStop = False
            Me.mobjQueryTypeLayoutPanel.Text = "Query Type"
            ' 
            ' mobjRadioButtonDelete
            ' 
            Me.mobjRadioButtonDelete.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjRadioButtonDelete.AutoSize = True
            Me.mobjRadioButtonDelete.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRadioButtonDelete.Location = New System.Drawing.Point(610, 0)
            Me.mobjRadioButtonDelete.Name = "objRadioButtonDelete"
            Me.mobjRadioButtonDelete.Size = New System.Drawing.Size(116, 50)
            Me.mobjRadioButtonDelete.TabIndex = 2
            Me.mobjRadioButtonDelete.Text = "DELETE"
            Me.mobjRadioButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRadioButtonInsert
            ' 
            Me.mobjRadioButtonInsert.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjRadioButtonInsert.AutoSize = True
            Me.mobjRadioButtonInsert.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRadioButtonInsert.Location = New System.Drawing.Point(305, 0)
            Me.mobjRadioButtonInsert.Name = "objRadioButtonInsert"
            Me.mobjRadioButtonInsert.Size = New System.Drawing.Size(116, 50)
            Me.mobjRadioButtonInsert.TabIndex = 1
            Me.mobjRadioButtonInsert.Text = "INSERT"
            Me.mobjRadioButtonInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRadioButtonSelect
            ' 
            Me.mobjRadioButtonSelect.Appearance = Gizmox.WebGUI.Forms.Appearance.Button
            Me.mobjRadioButtonSelect.AutoSize = True
            Me.mobjRadioButtonSelect.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRadioButtonSelect.Location = New System.Drawing.Point(3, 17)
            Me.mobjRadioButtonSelect.Name = "objRadioButtonSelect"
            Me.mobjRadioButtonSelect.Size = New System.Drawing.Size(116, 50)
            Me.mobjRadioButtonSelect.TabIndex = 0
            Me.mobjRadioButtonSelect.Text = "SELECT"
            Me.mobjRadioButtonSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjQueryTextBox
            ' 
            Me.mobjQueryTextBox.AllowDrag = False
            Me.mobjQueryTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjQueryTextBox.Location = New System.Drawing.Point(3, 173)
            Me.mobjQueryTextBox.Multiline = True
            Me.mobjQueryTextBox.Name = "objQueryTextBox"
            Me.mobjQueryTextBox.Size = New System.Drawing.Size(342, 34)
            Me.mobjQueryTextBox.TabIndex = 0
            ' 
            ' mobjRunButton
            ' 
            Me.mobjRunButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRunButton.Location = New System.Drawing.Point(0, 0)
            Me.mobjRunButton.Name = "objRunButton"
            Me.mobjRunButton.Size = New System.Drawing.Size(458, 54)
            Me.mobjRunButton.TabIndex = 0
            Me.mobjRunButton.Text = "Run Query"
            ' 
            ' mobjBottomLayoutPanel
            ' 
            Me.mobjBottomLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjBottomLayoutPanel.ColumnCount = 2
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjBottomLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjInitButton, 1, 0)
            Me.mobjBottomLayoutPanel.Controls.Add(Me.mobjRunButton, 0, 0)
            Me.mobjBottomLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjBottomLayoutPanel.Location = New System.Drawing.Point(15, 480)
            Me.mobjBottomLayoutPanel.Name = "objBottomLayoutPanel"
            Me.mobjBottomLayoutPanel.RowCount = 1
            Me.mobjBottomLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjBottomLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjBottomLayoutPanel.Size = New System.Drawing.Size(917, 54)
            Me.mobjBottomLayoutPanel.TabIndex = 1
            ' 
            ' mobjInitButton
            ' 
            Me.mobjInitButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInitButton.Location = New System.Drawing.Point(458, 0)
            Me.mobjInitButton.Name = "objInitButton"
            Me.mobjInitButton.Size = New System.Drawing.Size(459, 54)
            Me.mobjInitButton.TabIndex = 0
            Me.mobjInitButton.Text = "Init Database"
            ' 
            ' ExecutingQueriesPage
            ' 
            Me.Controls.Add(Me.mobjCommonLayoutPanel)
            Me.Controls.Add(Me.mobjBottomLayoutPanel)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(378, 549)
            Me.Text = "SQLExample"
            Me.mobjCommonLayoutPanel.ResumeLayout(False)
            Me.mobjTopLayoutPanel.ResumeLayout(False)
            Me.mobjQueryTypeLayoutPanel.ResumeLayout(False)
            Me.mobjBottomLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjClientStorage As Gizmox.WebGUI.Forms.Client.ClientStorage
        Private WithEvents mobjClientTable As Gizmox.WebGUI.Forms.Client.ClientTable
        Private mobjIdClientTableColumn As Gizmox.WebGUI.Forms.Client.ClientTableColumn
        Private mobjUsersClientTableColumn As Gizmox.WebGUI.Forms.Client.ClientTableColumn
        Private mobjCommonLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjCheckBoxList As Gizmox.WebGUI.Forms.CheckedListBox
        Private WithEvents mobjQueryTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private mobjQueryTypeLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjRadioButtonDelete As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioButtonInsert As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioButtonSelect As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRunButton As Gizmox.WebGUI.Forms.Button
        Private mobjBottomLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjInitButton As Gizmox.WebGUI.Forms.Button
        Private mobjIdColumn As ColumnHeader
        Private mobjUsersColumn As ColumnHeader
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label


	End Class

End Namespace