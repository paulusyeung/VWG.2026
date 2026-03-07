Namespace CompanionKit.Controls.SearchTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SearchingPage
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
            Me.mobjColumnHeader = DirectCast(New Gizmox.WebGUI.Forms.ColumnHeader(), Gizmox.WebGUI.Forms.ColumnHeader)
            Me.mobjSearchTextBox = New Gizmox.WebGUI.Forms.SearchTextBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.ColumnResizeStyle = Gizmox.WebGUI.Forms.ColumnHeaderAutoResizeStyle.HeaderSize
            Me.mobjListView.Columns.AddRange(New Gizmox.WebGUI.Forms.ColumnHeader() {Me.mobjColumnHeader})
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(113, 37)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Scrollable = False
            Me.mobjListView.Size = New System.Drawing.Size(180, 173)
            Me.mobjListView.TabIndex = 0
            ' 
            ' mobjColumnHeader
            ' 
            Me.mobjColumnHeader.Text = "Fruit"
            Me.mobjColumnHeader.Width = 152
            ' 
            ' mobjSearchTextBox
            ' 
            Me.mobjSearchTextBox.AllowDrag = False
            Me.mobjSearchTextBox.CustomStyle = "STB"
            Me.mobjSearchTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSearchTextBox.Location = New System.Drawing.Point(116, 293)
            Me.mobjSearchTextBox.Name = "mobjSearchTextBox"
            Me.mobjSearchTextBox.Size = New System.Drawing.Size(174, 24)
            Me.mobjSearchTextBox.TabIndex = 1
            ' 
            ' mobjLabel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjLabel, 3)
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 220)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(407, 60)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "Enter text and press button with ""Magnifier"" icon"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 180.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjListView, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel, 0, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSearchTextBox, 1, 5)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(407, 358)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' SearchingPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(407, 358)
            Me.Text = "SearchingPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private mobjColumnHeader As Gizmox.WebGUI.Forms.ColumnHeader
        Private WithEvents mobjSearchTextBox As Gizmox.WebGUI.Forms.SearchTextBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace