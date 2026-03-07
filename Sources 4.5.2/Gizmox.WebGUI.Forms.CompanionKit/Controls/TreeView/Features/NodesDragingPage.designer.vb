Namespace CompanionKit.Controls.TreeView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class NodesDragingPage
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
            Me.mobjAllowedDropListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjTreeNode1 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode4 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode5 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode6 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode7 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode8 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode9 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjDraggedTreeViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAllowedTreeViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjUnallowedDropListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjUnallowedTreeViewLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjAllowedTreeViewPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjUnallowedTreeViewPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTreeViewPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjAllowedTreeViewPanel.SuspendLayout()
            Me.mobjUnallowedTreeViewPanel.SuspendLayout()
            Me.mobjTreeViewPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTreeView
            ' 
            Me.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeView.DragTargets = New Gizmox.WebGUI.Forms.Component() {DirectCast(Me.mobjAllowedDropListBox, Gizmox.WebGUI.Forms.Component)}
            Me.mobjTreeView.Location = New System.Drawing.Point(0, 0)
            Me.mobjTreeView.Name = "mobjTreeView"
            Me.mobjTreeView.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode1, Me.mobjTreeNode2, Me.mobjTreeNode3})
            Me.mobjTreeView.Size = New System.Drawing.Size(177, 95)
            Me.mobjTreeView.TabIndex = 0
            ' 
            ' mobjAllowedDropListBox
            ' 
            Me.mobjAllowedDropListBox.AllowDrop = True
            Me.mobjAllowedDropListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowedDropListBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjAllowedDropListBox.Name = "mobjAllowedDropListBox"
            Me.mobjAllowedDropListBox.Size = New System.Drawing.Size(177, 95)
            Me.mobjAllowedDropListBox.TabIndex = 1
            ' 
            ' mobjTreeNode1
            ' 
            Me.mobjTreeNode1.Name = "treeNode1"
            Me.mobjTreeNode1.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode4})
            Me.mobjTreeNode1.Text = "Tree Node1"
            ' 
            ' mobjTreeNode4
            ' 
            Me.mobjTreeNode4.Name = "treeNode4"
            Me.mobjTreeNode4.Text = "Tree Node4"
            ' 
            ' mobjTreeNode2
            ' 
            Me.mobjTreeNode2.Name = "treeNode2"
            Me.mobjTreeNode2.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode5, Me.mobjTreeNode6})
            Me.mobjTreeNode2.Text = "Tree Node2"
            ' 
            ' mobjTreeNode5
            ' 
            Me.mobjTreeNode5.Name = "treeNode5"
            Me.mobjTreeNode5.Text = "Tree Node5"
            ' 
            ' mobjTreeNode6
            ' 
            Me.mobjTreeNode6.Name = "treeNode6"
            Me.mobjTreeNode6.Text = "Tree Node6"
            ' 
            ' mobjTreeNode3
            ' 
            Me.mobjTreeNode3.Name = "treeNode3"
            Me.mobjTreeNode3.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode7, Me.mobjTreeNode8, Me.mobjTreeNode9})
            Me.mobjTreeNode3.Text = "Tree Node3"
            ' 
            ' mobjTreeNode7
            ' 
            Me.mobjTreeNode7.Name = "treeNode7"
            Me.mobjTreeNode7.Text = "Tree Node7"
            ' 
            ' mobjTreeNode8
            ' 
            Me.mobjTreeNode8.Name = "treeNode8"
            Me.mobjTreeNode8.Text = "Tree Node8"
            ' 
            ' mobjTreeNode9
            ' 
            Me.mobjTreeNode9.Name = "treeNode9"
            Me.mobjTreeNode9.Text = "Tree Node9"
            ' 
            ' mobjDraggedTreeViewLabel
            ' 
            Me.mobjDraggedTreeViewLabel.AutoSize = True
            Me.mobjDraggedTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDraggedTreeViewLabel.Location = New System.Drawing.Point(20, 15)
            Me.mobjDraggedTreeViewLabel.Name = "mobjDraggedTreeViewLabel"
            Me.mobjDraggedTreeViewLabel.Size = New System.Drawing.Size(177, 50)
            Me.mobjDraggedTreeViewLabel.TabIndex = 2
            Me.mobjDraggedTreeViewLabel.Text = "Dragged TreeView"
            Me.mobjDraggedTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjAllowedTreeViewLabel
            ' 
            Me.mobjAllowedTreeViewLabel.AutoSize = True
            Me.mobjAllowedTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowedTreeViewLabel.Location = New System.Drawing.Point(217, 15)
            Me.mobjAllowedTreeViewLabel.Name = "mobjAllowedTreeViewLabel"
            Me.mobjAllowedTreeViewLabel.Size = New System.Drawing.Size(177, 50)
            Me.mobjAllowedTreeViewLabel.TabIndex = 3
            Me.mobjAllowedTreeViewLabel.Text = "Allowed drop"
            Me.mobjAllowedTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjUnallowedDropListBox
            ' 
            Me.mobjUnallowedDropListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjUnallowedDropListBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjUnallowedDropListBox.Name = "mobjUnallowedDropListBox"
            Me.mobjUnallowedDropListBox.Size = New System.Drawing.Size(177, 95)
            Me.mobjUnallowedDropListBox.TabIndex = 5
            ' 
            ' mobjUnallowedTreeViewLabel
            ' 
            Me.mobjUnallowedTreeViewLabel.AutoSize = True
            Me.mobjUnallowedTreeViewLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjUnallowedTreeViewLabel.Location = New System.Drawing.Point(414, 15)
            Me.mobjUnallowedTreeViewLabel.Name = "mobjUnallowedTreeViewLabel"
            Me.mobjUnallowedTreeViewLabel.Size = New System.Drawing.Size(177, 50)
            Me.mobjUnallowedTreeViewLabel.TabIndex = 6
            Me.mobjUnallowedTreeViewLabel.Text = "Unallowed drop"
            Me.mobjUnallowedTreeViewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 7
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjUnallowedTreeViewLabel, 5, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowedTreeViewLabel, 3, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDraggedTreeViewLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAllowedTreeViewPanel, 3, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjUnallowedTreeViewPanel, 5, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeViewPanel, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(613, 219)
            Me.mobjLayoutPanel.TabIndex = 7
            ' 
            ' mobjAllowedTreeViewPanel
            ' 
            Me.mobjAllowedTreeViewPanel.Controls.Add(Me.mobjAllowedDropListBox)
            Me.mobjAllowedTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAllowedTreeViewPanel.Location = New System.Drawing.Point(217, 75)
            Me.mobjAllowedTreeViewPanel.Name = "mobjAllowedTreeViewPanel"
            Me.mobjAllowedTreeViewPanel.Size = New System.Drawing.Size(177, 95)
            Me.mobjAllowedTreeViewPanel.TabIndex = 0
            ' 
            ' mobjUnallowedTreeViewPanel
            ' 
            Me.mobjUnallowedTreeViewPanel.Controls.Add(Me.mobjUnallowedDropListBox)
            Me.mobjUnallowedTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjUnallowedTreeViewPanel.Location = New System.Drawing.Point(414, 75)
            Me.mobjUnallowedTreeViewPanel.Name = "mobjUnallowedTreeViewPanel"
            Me.mobjUnallowedTreeViewPanel.Size = New System.Drawing.Size(177, 95)
            Me.mobjUnallowedTreeViewPanel.TabIndex = 0
            ' 
            ' mobjTreeViewPanel
            ' 
            Me.mobjTreeViewPanel.Controls.Add(Me.mobjTreeView)
            Me.mobjTreeViewPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewPanel.Location = New System.Drawing.Point(20, 75)
            Me.mobjTreeViewPanel.Name = "mobjTreeViewPanel"
            Me.mobjTreeViewPanel.Size = New System.Drawing.Size(177, 95)
            Me.mobjTreeViewPanel.TabIndex = 0
            ' 
            ' NodesDragingPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(613, 219)
            Me.Text = "NodesDragingPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjAllowedTreeViewPanel.ResumeLayout(False)
            Me.mobjUnallowedTreeViewPanel.ResumeLayout(False)
            Me.mobjTreeViewPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjTreeView As Global.Gizmox.WebGUI.Forms.TreeView
        Private WithEvents mobjAllowedDropListBox As Global.Gizmox.WebGUI.Forms.ListBox
        Private mobjTreeNode1 As TreeNode
        Private mobjTreeNode2 As TreeNode
        Private mobjTreeNode3 As TreeNode
        Private mobjDraggedTreeViewLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjAllowedTreeViewLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjTreeNode4 As TreeNode
        Private mobjTreeNode5 As TreeNode
        Private mobjTreeNode6 As TreeNode
        Private mobjTreeNode7 As TreeNode
        Private mobjTreeNode8 As TreeNode
        Private mobjTreeNode9 As TreeNode
        Private WithEvents mobjUnallowedDropListBox As Gizmox.WebGUI.Forms.ListBox
        Private mobjUnallowedTreeViewLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjAllowedTreeViewPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjUnallowedTreeViewPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjTreeViewPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
