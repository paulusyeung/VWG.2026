Namespace CompanionKit.Controls.ListView.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BindingDataCollectionPage
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
            Me.components = New System.ComponentModel.Container()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.columnID = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnFirstName = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnLastName = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnFullName = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.columnFavoriteColor = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.bindingSource1 = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(600, 57)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "ListView with a collection DataSource:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.AutoGenerateColumns = False
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.columnID, Me.columnFirstName, Me.columnLastName, Me.columnFullName, Me.columnFavoriteColor})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(5, 62)
            Me.mobjListView.Margin = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(590, 318)
            Me.mobjListView.TabIndex = 1
            Me.mobjListView.TotalItems = 1
            ' 
            ' columnID
            ' 
            Me.columnID.Tag = "ID"
            Me.columnID.Text = "ID"
            Me.columnID.Width = 64
            ' 
            ' columnFirstName
            ' 
            Me.columnFirstName.Tag = "FirstName"
            Me.columnFirstName.Text = "First Name"
            Me.columnFirstName.Width = 100
            ' 
            ' columnLastName
            ' 
            Me.columnLastName.Tag = "LastName"
            Me.columnLastName.Text = "Last Name"
            Me.columnLastName.Width = 100
            ' 
            ' columnFullName
            ' 
            Me.columnFullName.Tag = "FullName"
            Me.columnFullName.Text = "Full Name"
            Me.columnFullName.Width = 100
            ' 
            ' columnFavoriteColor
            ' 
            Me.columnFavoriteColor.Tag = "FavoriteColor"
            Me.columnFavoriteColor.Text = "Favorite Color"
            Me.columnFavoriteColor.Width = 100
            ' 
            ' bindingSource1
            ' 
            Me.bindingSource1.DataSource = GetType(Utils.Customer)
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(600, 385)
            Me.mobjTLP.TabIndex = 2
            ' 
            ' BindingDataCollectionPage
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "BindingDataCollectionPage"
            DirectCast(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Friend WithEvents bindingSource1 As Gizmox.WebGUI.Forms.BindingSource
        Friend WithEvents columnID As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents columnFirstName As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents columnLastName As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents columnFullName As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents columnFavoriteColor As Gizmox.WebGUI.Forms.ColumnHeader
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
