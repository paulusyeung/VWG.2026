Namespace CompanionKit.Controls.TreeView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TreeViewItemsSortingPage
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
            Me.mobjTreeView = New Gizmox.WebGUI.Forms.TreeView()
            Me.mobjSortCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTreeViewPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTreeViewPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjInfoLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTreeView
            ' 
            Me.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeView.Location = New System.Drawing.Point(0, 0)
            Me.mobjTreeView.Name = "mobjTreeView"
            Me.mobjTreeView.Size = New System.Drawing.Size(392, 161)
            Me.mobjTreeView.TabIndex = 0
	    Me.mobjTreeView.Nodes.AddRange(New TreeNode() {New TreeNode("A item"), New TreeNode("X item"), New TreeNode("Y item"), New TreeNode("I item"), New TreeNode("J item"), New TreeNode("K item"), _
	New TreeNode("L item"), New TreeNode("M item"), New TreeNode("N item"), New TreeNode("O item"), New TreeNode("B item"), New TreeNode("C item"), _
	New TreeNode("T item"), New TreeNode("U item"), New TreeNode("V item"), New TreeNode("D item"), New TreeNode("H item"), New TreeNode("E item"), _
	New TreeNode("F item"), New TreeNode("G item"), New TreeNode("P item"), New TreeNode("Q item"), New TreeNode("R item"), New TreeNode("S item"), _
	New TreeNode("W item"), New TreeNode("Z item")})
            ' 
            ' mobjSortCheckBox
            ' 
            Me.mobjSortCheckBox.AutoSize = True
            Me.mobjSortCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjSortCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjSortCheckBox.Name = "mobjSortCheckBox"
            Me.mobjSortCheckBox.Size = New System.Drawing.Size(58, 20)
            Me.mobjSortCheckBox.TabIndex = 1
            Me.mobjSortCheckBox.Text = "Sorted"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(109, 13)
            Me.mobjLabel.TabIndex = 2
            Me.mobjLabel.Text = "Nodes are not sorted"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 80.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 3, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoLabelPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(580, 285)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' mobjTreeViewPanel
            ' 
            Me.mobjTreeViewPanel.Controls.Add(Me.mobjTreeView)
            Me.mobjTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewPanel.Location = New System.Drawing.Point(49, 53)
            Me.mobjTreeViewPanel.Name = "mobjTreeViewPanel"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjTreeViewPanel, 2)
            Me.mobjTreeViewPanel.Size = New System.Drawing.Size(392, 161)
            Me.mobjTreeViewPanel.TabIndex = 0
            ' 
            ' mobjPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel, 2)
            Me.mobjPanel.Controls.Add(Me.mobjSortCheckBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(451, 53)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(129, 20)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjInfoLabelPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoLabelPanel, 3)
            Me.mobjInfoLabelPanel.Controls.Add(Me.mobjLabel)
            Me.mobjInfoLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabelPanel.Location = New System.Drawing.Point(49, 23)
            Me.mobjInfoLabelPanel.Name = "mobjInfoLabelPanel"
            Me.mobjInfoLabelPanel.Size = New System.Drawing.Size(482, 20)
            Me.mobjInfoLabelPanel.TabIndex = 0
            ' 
            ' TreeViewItemsSortingPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(580, 285)
            Me.Text = "TreeViewItemsSortingPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTreeViewPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjInfoLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTreeView As Gizmox.WebGUI.Forms.TreeView
        Private WithEvents mobjSortCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTreeViewPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjInfoLabelPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace