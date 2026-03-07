Namespace CompanionKit.Concepts.ClientAPI.TreeViewNodes

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TreeViewNodesPage
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
            Me.objTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.objButton = New Gizmox.WebGUI.Forms.Button()
            Me.objTopChilldPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.objPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.treeNode6 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode7 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode1 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode2 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode11 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode12 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode13 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode14 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode3 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode8 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode9 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode10 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode4 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.treeNode5 = New Gizmox.WebGUI.Forms.TreeNode()
            Me.objTreeView = New Gizmox.WebGUI.Forms.TreeView()
            Me.objTopChilldPanel.SuspendLayout()
            Me.objPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'objTextBox
            '
            Me.objTextBox.AllowDrag = False
            Me.objTextBox.ClientId = "textBox"
            Me.objTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objTextBox.Location = New System.Drawing.Point(10, 71)
            Me.objTextBox.Multiline = True
            Me.objTextBox.Name = "objTextBox"
            Me.objTextBox.Size = New System.Drawing.Size(137, 163)
            Me.objTextBox.TabIndex = 1
            '
            'objButton
            '
            Me.objButton.Location = New System.Drawing.Point(13, 17)
            Me.objButton.Name = "objButton"
            Me.objButton.Size = New System.Drawing.Size(122, 25)
            Me.objButton.TabIndex = 2
            Me.objButton.Text = "Print Info"
            '
            'objTopChilldPanel
            '
            Me.objTopChilldPanel.Controls.Add(Me.objButton)
            Me.objTopChilldPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.objTopChilldPanel.Location = New System.Drawing.Point(10, 10)
            Me.objTopChilldPanel.Name = "objTopChilldPanel"
            Me.objTopChilldPanel.Size = New System.Drawing.Size(142, 61)
            Me.objTopChilldPanel.TabIndex = 3
            '
            'objPanel
            '
            Me.objPanel.Controls.Add(Me.objTextBox)
            Me.objPanel.Controls.Add(Me.objTopChilldPanel)
            Me.objPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.objPanel.DockPadding.All = 10
            Me.objPanel.Location = New System.Drawing.Point(146, 15)
            Me.objPanel.Name = "objPanel"
            Me.objPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.objPanel.Size = New System.Drawing.Size(162, 244)
            Me.objPanel.TabIndex = 3
            '
            'treeNode6
            '
            Me.treeNode6.Name = ""
            Me.treeNode6.Text = "treeNode6"
            '
            'treeNode7
            '
            Me.treeNode7.Name = ""
            Me.treeNode7.Text = "treeNode7"
            '
            'treeNode1
            '
            Me.treeNode1.Name = ""
            Me.treeNode1.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.treeNode6, Me.treeNode7})
            Me.treeNode1.Text = "treeNode1"
            '
            'treeNode2
            '
            Me.treeNode2.Name = ""
            Me.treeNode2.Text = "treeNode2"
            '
            'treeNode11
            '
            Me.treeNode11.Name = ""
            Me.treeNode11.Text = "treeNode11"
            '
            'treeNode12
            '
            Me.treeNode12.Name = ""
            Me.treeNode12.Text = "treeNode11"
            '
            'treeNode13
            '
            Me.treeNode13.Name = ""
            Me.treeNode13.Text = "treeNode11"
            '
            'treeNode14
            '
            Me.treeNode14.Name = ""
            Me.treeNode14.Text = "treeNode11"
            '
            'treeNode3
            '
            Me.treeNode3.Name = ""
            Me.treeNode3.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.treeNode11, Me.treeNode12, Me.treeNode13, Me.treeNode14})
            Me.treeNode3.Text = "treeNode3"
            '
            'treeNode8
            '
            Me.treeNode8.Name = ""
            Me.treeNode8.Text = "treeNode8"
            '
            'treeNode9
            '
            Me.treeNode9.Name = ""
            Me.treeNode9.Text = "treeNode9"
            '
            'treeNode10
            '
            Me.treeNode10.Name = ""
            Me.treeNode10.Text = "treeNode10"
            '
            'treeNode4
            '
            Me.treeNode4.Name = ""
            Me.treeNode4.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.treeNode8, Me.treeNode9, Me.treeNode10})
            Me.treeNode4.Text = "treeNode4"
            '
            'treeNode5
            '
            Me.treeNode5.Name = ""
            Me.treeNode5.Text = "treeNode5"
            '
            'objTreeView
            '
            Me.objTreeView.ClientId = "treeView"
            Me.objTreeView.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.objTreeView.Location = New System.Drawing.Point(15, 15)
            Me.objTreeView.Name = "objTreeView"
            Me.objTreeView.Nodes.AddRange(New Gizmox.WebGUI.Forms.TreeNode() {Me.treeNode1, Me.treeNode2, Me.treeNode3, Me.treeNode4, Me.treeNode5})
            Me.objTreeView.Size = New System.Drawing.Size(131, 244)
            Me.objTreeView.TabIndex = 0
            '
            'TreeViewNodesPage
            '
            Me.Controls.Add(Me.objPanel)
            Me.Controls.Add(Me.objTreeView)
            Me.DockPadding.All = 15
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(15)
            Me.Size = New System.Drawing.Size(323, 274)
            Me.Text = "TreeViewNodesPage"
            Me.objTopChilldPanel.ResumeLayout(False)
            Me.objPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents objTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents objButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents objTopChilldPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents objPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents treeNode6 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode7 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode1 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode2 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode11 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode12 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode13 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode14 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode3 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode8 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode9 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode10 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode4 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents treeNode5 As Gizmox.WebGUI.Forms.TreeNode
        Private WithEvents objTreeView As Gizmox.WebGUI.Forms.TreeView

	End Class

End Namespace