Namespace CompanionKit.Concepts.ClientAPI.ListView

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ListViewPage
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
            Me.columnHeader1 = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnHeader2 = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjAddItemButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjRemoveItemButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjRemoveAllButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFillListViewButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.SuspendLayout()
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.ClientId = "lw"
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Location = New System.Drawing.Point(17, 62)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(243, 190)
            Me.mobjListView.TabIndex = 0
            ' 
            ' columnHeader1
            ' 
            Me.columnHeader1.ClientId = "col1"
            Me.columnHeader1.Text = "column1"
            Me.columnHeader1.Width = 114
            ' 
            ' columnHeader2
            ' 
            Me.columnHeader2.ClientId = "col2"
            Me.columnHeader2.Text = "column2"
            Me.columnHeader2.Width = 105
            ' 
            ' mobjAddItemButton
            ' 
            Me.mobjAddItemButton.Location = New System.Drawing.Point(147, 15)
            Me.mobjAddItemButton.Name = "mobjAddItemButton"
            Me.mobjAddItemButton.Size = New System.Drawing.Size(113, 30)
            Me.mobjAddItemButton.TabIndex = 1
            Me.mobjAddItemButton.Text = "Add item"
            ' 
            ' mobjRemoveItemButton
            ' 
            Me.mobjRemoveItemButton.Location = New System.Drawing.Point(147, 263)
            Me.mobjRemoveItemButton.Name = "mobjRemoveItemButton"
            Me.mobjRemoveItemButton.Size = New System.Drawing.Size(113, 30)
            Me.mobjRemoveItemButton.TabIndex = 2
            Me.mobjRemoveItemButton.Text = "Remove one"
            ' 
            ' mobjRemoveAllButton
            ' 
            Me.mobjRemoveAllButton.Location = New System.Drawing.Point(17, 263)
            Me.mobjRemoveAllButton.Name = "mobjRemoveAllButton"
            Me.mobjRemoveAllButton.Size = New System.Drawing.Size(113, 30)
            Me.mobjRemoveAllButton.TabIndex = 3
            Me.mobjRemoveAllButton.Text = "Remove All"
            ' 
            ' mobjFillListViewButton
            ' 
            Me.mobjFillListViewButton.Location = New System.Drawing.Point(17, 15)
            Me.mobjFillListViewButton.Name = "mobjFillListViewButton"
            Me.mobjFillListViewButton.Size = New System.Drawing.Size(113, 30)
            Me.mobjFillListViewButton.TabIndex = 4
            Me.mobjFillListViewButton.Text = "Initialize List"
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.ClientId = "lbl"
            Me.mobjInfoLabel.Location = New System.Drawing.Point(17, 304)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(243, 50)
            Me.mobjInfoLabel.TabIndex = 5
            Me.mobjInfoLabel.Text = "--"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' ListViewPage
            ' 
            Me.Controls.Add(Me.mobjInfoLabel)
            Me.Controls.Add(Me.mobjFillListViewButton)
            Me.Controls.Add(Me.mobjRemoveAllButton)
            Me.Controls.Add(Me.mobjRemoveItemButton)
            Me.Controls.Add(Me.mobjAddItemButton)
            Me.Controls.Add(Me.mobjListView)
            Me.ClientId = "uc"
            Me.Size = New System.Drawing.Size(493, 403)
            Me.Text = "ListViewPage"
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private WithEvents mobjAddItemButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjRemoveItemButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjRemoveAllButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents columnHeader1 As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents columnHeader2 As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjFillListViewButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label

	End Class

End Namespace