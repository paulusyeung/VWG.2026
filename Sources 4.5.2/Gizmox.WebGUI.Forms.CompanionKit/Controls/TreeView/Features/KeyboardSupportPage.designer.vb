Namespace CompanionKit.Controls.TreeView.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class KeyboardSupportPage
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
            Me.mobjTreeView = New Gizmox.WebGUI.Forms.TreeView()
            Me.mobjTreeNode1 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode4 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode5 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode6 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode7 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode8 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjTreeNode9 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AutoSize = True
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(44, 13)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(352, 50)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "TreeView with Keyboard navigation"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjTreeView
            ' 
            Me.mobjTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeView.Location = New System.Drawing.Point(44, 73)
            Me.mobjTreeView.Name = "mobjTreeView"
            Me.mobjTreeView.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.mobjTreeNode1, Me.mobjTreeNode2, Me.mobjTreeNode3})
            Me.mobjTreeView.Size = New System.Drawing.Size(352, 82)
            Me.mobjTreeView.TabIndex = 1
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
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTreeView, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(441, 197)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' KeyboardSupportPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(441, 197)
            Me.Text = "KeyboardSupportPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjInfoLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTreeView As Global.Gizmox.WebGUI.Forms.TreeView
        Private mobjTreeNode1 As TreeNode
        Private mobjTreeNode2 As TreeNode
        Private mobjTreeNode3 As TreeNode
        Private mobjTreeNode4 As TreeNode
        Private mobjTreeNode5 As TreeNode
        Private mobjTreeNode6 As TreeNode
        Private mobjTreeNode7 As TreeNode
        Private mobjTreeNode8 As TreeNode
        Private mobjTreeNode9 As TreeNode
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
