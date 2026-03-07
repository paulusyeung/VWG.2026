Namespace CompanionKit.Controls.ListView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ItemPanel
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
            Me.mobjColumnImportant = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnOpened = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnAttached = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnSubject = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnFrom = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnReceived = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnSize = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjColumnControl = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.SuspendLayout()
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.AccessibleDescription = ""
            Me.mobjListView.AccessibleName = ""
            Me.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.mobjColumnImportant, Me.mobjColumnOpened, Me.mobjColumnAttached, Me.mobjColumnSubject, Me.mobjColumnFrom, Me.mobjColumnReceived, _
             Me.mobjColumnSize, Me.mobjColumnControl})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(3, 3)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(822, 426)
            Me.mobjListView.TabIndex = 0
            Me.mobjListView.UseInternalPaging = True
            ' 
            ' mobjColumnImportant
            ' 
            Me.mobjColumnImportant.Text = ""
            Me.mobjColumnImportant.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.mobjColumnImportant.Width = 20
            ' 
            ' mobjColumnOpened
            ' 
            Me.mobjColumnOpened.Text = ""
            Me.mobjColumnOpened.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.mobjColumnOpened.Width = 20
            ' 
            ' mobjColumnAttached
            ' 
            Me.mobjColumnAttached.Text = "Action"
            Me.mobjColumnAttached.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon
            Me.mobjColumnAttached.Width = 20
            ' 
            ' mobjColumnSubject
            ' 
            Me.mobjColumnSubject.Text = "Subject"
            Me.mobjColumnSubject.Width = 250
            ' 
            ' mobjColumnFrom
            ' 
            Me.mobjColumnFrom.Text = "From"
            Me.mobjColumnFrom.Width = 150
            ' 
            ' mobjColumnReceived
            ' 
            Me.mobjColumnReceived.Text = "Received"
            Me.mobjColumnReceived.Width = 150
            ' 
            ' mobjColumnSize
            ' 
            Me.mobjColumnSize.Text = "Size"
            Me.mobjColumnSize.Width = 50
            ' 
            ' mobjColumnControl
            ' 
            Me.mobjColumnControl.PreferedItemHeight = 23
            Me.mobjColumnControl.Text = ""
            Me.mobjColumnControl.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Control
            Me.mobjColumnControl.Width = 200
            ' 
            ' ItemPanel
            ' 
            Me.Controls.Add(Me.mobjListView)
            Me.DockPadding.All = 3
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(3)
            Me.Size = New System.Drawing.Size(800, 400)
            Me.Text = "ItemPanel"
            Me.ResumeLayout(False)
		End Sub

        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents mobjColumnFrom As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnSubject As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnReceived As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnSize As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnImportant As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnOpened As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnAttached As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjColumnControl As Gizmox.WebGUI.Forms.ColumnHeader

	End Class

End Namespace