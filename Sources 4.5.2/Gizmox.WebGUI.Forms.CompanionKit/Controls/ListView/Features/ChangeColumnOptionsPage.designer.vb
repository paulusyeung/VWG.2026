Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ChangeColumnOptionsPage
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
            Me.contextMenu1 = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.menuItem1 = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.mobjColumnImportant = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnOpened = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnAttached = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnSubject = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnFrom = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnReceived = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnSize = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.mobjColumnControl = New Gizmox.WebGUI.Forms.ColumnHeader()
            Me.SuspendLayout()
            ' 
            ' contextMenu1
            ' 
            Me.contextMenu1.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.menuItem1})
            ' 
            ' menuItem1
            ' 
            Me.menuItem1.Index = 0
            Me.menuItem1.Text = "Column options..."
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjListView.AutoGenerateColumns = True
            Me.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.mobjColumnImportant, Me.mobjColumnOpened, Me.mobjColumnAttached, Me.mobjColumnSubject, Me.mobjColumnFrom, Me.mobjColumnReceived, _
             Me.mobjColumnSize, Me.mobjColumnControl})
            Me.mobjListView.ContextMenu = Me.contextMenu1
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.GridLines = False
            Me.mobjListView.ItemsPerPage = 20
            Me.mobjListView.Location = New System.Drawing.Point(0, 0)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.ShowItemToolTips = False
            Me.mobjListView.Size = New System.Drawing.Size(702, 401)
            Me.mobjListView.TabIndex = 0
            Me.mobjListView.UseInternalPaging = True
            Me.mobjListView.FullRowSelect = True
            ' 
            ' mobjColumnImportant
            ' 
            Me.mobjColumnImportant.ContextMenu = Me.contextMenu1
            Me.mobjColumnImportant.Image = Nothing
            Me.mobjColumnImportant.Text = ""
            Me.mobjColumnImportant.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.mobjColumnImportant.Width = 20
            ' 
            ' mobjColumnOpened
            ' 
            Me.mobjColumnOpened.ContextMenu = Me.contextMenu1
            Me.mobjColumnOpened.Image = Nothing
            Me.mobjColumnOpened.Text = ""
            Me.mobjColumnOpened.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.mobjColumnOpened.Width = 20
            ' 
            ' mobjColumnAttached
            ' 
            Me.mobjColumnAttached.ContextMenu = Me.contextMenu1
            Me.mobjColumnAttached.Image = Nothing
            Me.mobjColumnAttached.Text = ""
            Me.mobjColumnAttached.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.mobjColumnAttached.Width = 20
            ' 
            ' mobjColumnSubject
            ' 
            Me.mobjColumnSubject.ContextMenu = Me.contextMenu1
            Me.mobjColumnSubject.Image = Nothing
            Me.mobjColumnSubject.Text = "Subject"
            Me.mobjColumnSubject.Width = 250
            ' 
            ' mobjColumnFrom
            ' 
            Me.mobjColumnFrom.ContextMenu = Me.contextMenu1
            Me.mobjColumnFrom.Image = Nothing
            Me.mobjColumnFrom.Text = "From"
            Me.mobjColumnFrom.Width = 150
            ' 
            ' mobjColumnReceived
            ' 
            Me.mobjColumnReceived.ContextMenu = Me.contextMenu1
            Me.mobjColumnReceived.Image = Nothing
            Me.mobjColumnReceived.Text = "Received"
            Me.mobjColumnReceived.Width = 150
            ' 
            ' mobjColumnSize
            ' 
            Me.mobjColumnSize.ContextMenu = Me.contextMenu1
            Me.mobjColumnSize.Image = Nothing
            Me.mobjColumnSize.Text = "Size"
            Me.mobjColumnSize.Width = 50
            ' 
            ' mobjColumnControl
            ' 
            Me.mobjColumnControl.ContextMenu = Me.contextMenu1
            Me.mobjColumnControl.Image = Nothing
            Me.mobjColumnControl.PreferedItemHeight = 23
            Me.mobjColumnControl.Text = "Action"
            Me.mobjColumnControl.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control
            Me.mobjColumnControl.Width = 200
            ' 
            ' ChangeColumnOptionsPage
            ' 
            Me.Controls.Add(Me.mobjListView)
            Me.Size = New System.Drawing.Size(702, 401)
            Me.Text = "ColumnReorderingWithDialogPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents contextMenu1 As Gizmox.WebGUI.Forms.ContextMenu
        Private WithEvents menuItem1 As Gizmox.WebGUI.Forms.MenuItem
        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private WithEvents mobjColumnFrom As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnSubject As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnReceived As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnSize As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnImportant As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnOpened As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnAttached As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjColumnControl As Gizmox.WebGUI.Forms.ColumnHeader

	End Class

End Namespace