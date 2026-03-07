Namespace CompanionKit.Controls.ImageListFolder.Programming

    Public Class TreeViewImageListPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub
        ''' <summary>
        ''' Handles Load event of the Form
        ''' </summary>
        Private Sub TreeViewImageListPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set the ImageList object to the TreeView
            Me.mobjTreeViewMessages.ImageList = Me.mobjImageList
            ' Set the image for TreeView nodes using ImageIndex property
            Me.mobjTreeViewMessages.ImageIndex = 5
            ' Set the image for TreeView nodes using SelectedImageKey property
            Me.mobjTreeViewMessages.SelectedImageKey = "16x16.OpenedEmail.png"
            ' Create object for generating nodes quantity
            Dim random As New Random
            ' Generate nodes quantity
            Dim nodesQty As Integer = random.Next(1, 5)
            ' Create TreeView node
            Dim inboxNode As New TreeNode(String.Format("Inbox ({0})", nodesQty), 0, 0)
            Dim i As Integer
            ' Fill TreeView node with child nodes
            For i = 0 To nodesQty - 1
                inboxNode.Nodes.Add("Email message")
            Next i
            ' Add node to TreeView
            Me.mobjTreeViewMessages.Nodes.Add(inboxNode)
            ' Generate nodes quantity
            nodesQty = random.Next(1, 4)
            ' Create TreeView node
            Dim outboxNode As New TreeNode(String.Format("Outbox ({0})", nodesQty), 1, 1)
            ' Fill TreeView node with child nodes
            For i = 0 To nodesQty - 1
                outboxNode.Nodes.Add("Email message")
            Next i
            ' Add node to TreeView
            Me.mobjTreeViewMessages.Nodes.Add(outboxNode)
            ' Generate nodes quantity
            nodesQty = random.Next(1, 4)
            ' Create TreeView node
            Dim sentMailNode As New TreeNode(String.Format("Sent Mail ({0})", nodesQty), 2, 2)
            ' Fill TreeView node with child nodes
            For i = 0 To nodesQty - 1
                sentMailNode.Nodes.Add("Email message")
            Next i
            ' Add node to TreeView
            Me.mobjTreeViewMessages.Nodes.Add(sentMailNode)
            ' Generate nodes quantity
            nodesQty = random.Next(1, 4)
            ' Create TreeView node
            Dim junkMailNode As New TreeNode(String.Format("Junk Mail ({0})", nodesQty), 3, 3)
            ' Fill TreeView node with child nodes
            For i = 0 To nodesQty - 1
                junkMailNode.Nodes.Add("Email message")
            Next i
            ' Add node to TreeView
            Me.mobjTreeViewMessages.Nodes.Add(junkMailNode)
            ' Generate nodes quantity
            nodesQty = random.Next(1, 4)
            ' Create TreeView node
            Dim trashNode As New TreeNode(String.Format("Trash ({0})", nodesQty), 4, 4)
            ' Fill TreeView node with child nodes
            For i = 0 To nodesQty - 1
                trashNode.Nodes.Add("Email message")
            Next i
            ' Add node to TreeView
            Me.mobjTreeViewMessages.Nodes.Add(trashNode)

        End Sub
    End Class

End Namespace