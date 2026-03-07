Namespace CompanionKit.Controls.ImageListFolder.Programming

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TreeViewImageListPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(TreeViewImageListPage))
            Me.mobjImageList = New Gizmox.WebGUI.Forms.ImageList(Me.components)
            Me.mobjTreeViewMessages = New Gizmox.WebGUI.Forms.TreeView()
            Me.SuspendLayout()
            ' 
            ' mobjImageList
            ' 
            Me.mobjImageList.Images.AddRange(New Gizmox.WebGUI.Common.Resources.ResourceHandle() {New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images")), New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images1")), New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images2")), New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images3")), New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images4")), New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images5")), _
             New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjImageList.Images6"))})
            Me.mobjImageList.ImageSize = New System.Drawing.Size(16, 16)
            Me.mobjImageList.Images.SetKeyName(0, "16x16.Inbox.png")
            Me.mobjImageList.Images.SetKeyName(1, "16x16.Outbox.png")
            Me.mobjImageList.Images.SetKeyName(2, "16x16.SentItems.png")
            Me.mobjImageList.Images.SetKeyName(3, "16x16.Junk.png")
            Me.mobjImageList.Images.SetKeyName(4, "16x16.RecoverDeletedItems.png")
            Me.mobjImageList.Images.SetKeyName(5, "16x16.ClosedEmail.png")
            Me.mobjImageList.Images.SetKeyName(6, "16x16.OpenedEmail.png")
            ' 
            ' mobjTreeViewMessages
            ' 
            Me.mobjTreeViewMessages.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTreeViewMessages.Location = New System.Drawing.Point(20, 20)
            Me.mobjTreeViewMessages.Name = "mobjTreeViewMessages"
            Me.mobjTreeViewMessages.Size = New System.Drawing.Size(351, 266)
            Me.mobjTreeViewMessages.TabIndex = 1
            ' 
            ' TreeViewImageListPage
            ' 
            Me.Controls.Add(Me.mobjTreeViewMessages)
            Me.DockPadding.All = 20
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(20)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "TreeViewImageListPage"
            Me.ResumeLayout(False)

        End Sub

        Private mobjImageList As Gizmox.WebGUI.Forms.ImageList
        Private mobjTreeViewMessages As Gizmox.WebGUI.Forms.TreeView

    End Class

End Namespace