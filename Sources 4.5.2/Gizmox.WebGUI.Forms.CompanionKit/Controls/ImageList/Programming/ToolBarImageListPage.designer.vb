Namespace CompanionKit.Controls.ImageListFolder.Programming

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ToolBarImageListPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ToolBarImageListPage))
            Me.mobjToolBar = New Gizmox.WebGUI.Forms.ToolBar()
            Me.mobjToolBarButtonAdd = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonRemove = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonSep1 = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonNew = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonOpen = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonSep2 = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonSave = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonCut = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonCopy = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonPaste = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonSep3 = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonBack = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonNext = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjToolBarButtonHelp = New Gizmox.WebGUI.Forms.ToolBarButton()
            Me.mobjImageList = New Gizmox.WebGUI.Forms.ImageList(Me.components)
            Me.SuspendLayout()
            ' 
            ' mobjToolBar
            ' 
            Me.mobjToolBar.Buttons.AddRange(New Gizmox.WebGUI.Forms.ToolBarButton() {Me.mobjToolBarButtonAdd, Me.mobjToolBarButtonRemove, Me.mobjToolBarButtonSep1, Me.mobjToolBarButtonNew, Me.mobjToolBarButtonOpen, Me.mobjToolBarButtonSep2, _
             Me.mobjToolBarButtonSave, Me.mobjToolBarButtonCut, Me.mobjToolBarButtonCopy, Me.mobjToolBarButtonPaste, Me.mobjToolBarButtonSep3, Me.mobjToolBarButtonBack, _
             Me.mobjToolBarButtonNext, Me.mobjToolBarButtonHelp})
            Me.mobjToolBar.DragHandle = True
            Me.mobjToolBar.DropDownArrows = True
            Me.mobjToolBar.ImageList = Me.mobjImageList
            Me.mobjToolBar.Location = New System.Drawing.Point(0, 0)
            Me.mobjToolBar.MenuHandle = True
            Me.mobjToolBar.Name = "mobjToolBar"
            Me.mobjToolBar.ShowToolTips = True
            Me.mobjToolBar.Size = New System.Drawing.Size(391, 114)
            Me.mobjToolBar.TabIndex = 0
            ' 
            ' mobjToolBarButtonAdd
            ' 
            Me.mobjToolBarButtonAdd.CustomStyle = ""
            Me.mobjToolBarButtonAdd.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonAdd.ImageKey = "Add.png"
            Me.mobjToolBarButtonAdd.Name = "mobjToolBarButtonAdd"
            Me.mobjToolBarButtonAdd.Size = 24
            Me.mobjToolBarButtonAdd.Text = "Add"
            Me.mobjToolBarButtonAdd.ToolTipText = "Add"
            ' 
            ' mobjToolBarButtonRemove
            ' 
            Me.mobjToolBarButtonRemove.CustomStyle = ""
            Me.mobjToolBarButtonRemove.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonRemove.ImageKey = "delete.png"
            Me.mobjToolBarButtonRemove.Name = "mobjToolBarButtonRemove"
            Me.mobjToolBarButtonRemove.Size = 24
            Me.mobjToolBarButtonRemove.Text = "Remove"
            Me.mobjToolBarButtonRemove.ToolTipText = "Remove"
            ' 
            ' mobjToolBarButtonSep1
            ' 
            Me.mobjToolBarButtonSep1.CustomStyle = ""
            Me.mobjToolBarButtonSep1.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonSep1.Name = "mobjToolBarButtonSep1"
            Me.mobjToolBarButtonSep1.Size = 24
            Me.mobjToolBarButtonSep1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator
            Me.mobjToolBarButtonSep1.ToolTipText = ""
            ' 
            ' mobjToolBarButtonNew
            ' 
            Me.mobjToolBarButtonNew.CustomStyle = ""
            Me.mobjToolBarButtonNew.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonNew.ImageKey = "Folder.png"
            Me.mobjToolBarButtonNew.Name = "mobjToolBarButtonNew"
            Me.mobjToolBarButtonNew.Size = 24
            Me.mobjToolBarButtonNew.Text = "New"
            Me.mobjToolBarButtonNew.ToolTipText = "New"
            ' 
            ' mobjToolBarButtonOpen
            ' 
            Me.mobjToolBarButtonOpen.CustomStyle = ""
            Me.mobjToolBarButtonOpen.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonOpen.ImageKey = "Open.png"
            Me.mobjToolBarButtonOpen.Name = "mobjToolBarButtonOpen"
            Me.mobjToolBarButtonOpen.Size = 24
            Me.mobjToolBarButtonOpen.Text = "Open"
            Me.mobjToolBarButtonOpen.ToolTipText = "Open"
            ' 
            ' mobjToolBarButtonSep2
            ' 
            Me.mobjToolBarButtonSep2.CustomStyle = ""
            Me.mobjToolBarButtonSep2.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonSep2.Name = "mobjToolBarButtonSep2"
            Me.mobjToolBarButtonSep2.Size = 24
            Me.mobjToolBarButtonSep2.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator
            Me.mobjToolBarButtonSep2.ToolTipText = ""
            ' 
            ' mobjToolBarButtonSave
            ' 
            Me.mobjToolBarButtonSave.CustomStyle = ""
            Me.mobjToolBarButtonSave.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonSave.ImageKey = "save.png"
            Me.mobjToolBarButtonSave.Name = "mobjToolBarButtonSave"
            Me.mobjToolBarButtonSave.Size = 24
            Me.mobjToolBarButtonSave.Text = "Save"
            Me.mobjToolBarButtonSave.ToolTipText = "Save"
            ' 
            ' mobjToolBarButtonCut
            ' 
            Me.mobjToolBarButtonCut.CustomStyle = ""
            Me.mobjToolBarButtonCut.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonCut.ImageKey = "cut.png"
            Me.mobjToolBarButtonCut.Name = "mobjToolBarButtonCut"
            Me.mobjToolBarButtonCut.Size = 24
            Me.mobjToolBarButtonCut.Text = "Cut"
            Me.mobjToolBarButtonCut.ToolTipText = "Cut"
            ' 
            ' mobjToolBarButtonCopy
            ' 
            Me.mobjToolBarButtonCopy.CustomStyle = ""
            Me.mobjToolBarButtonCopy.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonCopy.ImageKey = "copy.png"
            Me.mobjToolBarButtonCopy.Name = "mobjToolBarButtonCopy"
            Me.mobjToolBarButtonCopy.Size = 24
            Me.mobjToolBarButtonCopy.Text = "Copy"
            Me.mobjToolBarButtonCopy.ToolTipText = "Copy"
            ' 
            ' mobjToolBarButtonPaste
            ' 
            Me.mobjToolBarButtonPaste.CustomStyle = ""
            Me.mobjToolBarButtonPaste.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonPaste.ImageKey = "paste.png"
            Me.mobjToolBarButtonPaste.Name = "mobjToolBarButtonPaste"
            Me.mobjToolBarButtonPaste.Size = 24
            Me.mobjToolBarButtonPaste.Text = "Paste"
            Me.mobjToolBarButtonPaste.ToolTipText = "Paste"
            ' 
            ' mobjToolBarButtonSep3
            ' 
            Me.mobjToolBarButtonSep3.CustomStyle = ""
            Me.mobjToolBarButtonSep3.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonSep3.Name = "mobjToolBarButtonSep3"
            Me.mobjToolBarButtonSep3.Size = 24
            Me.mobjToolBarButtonSep3.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator
            Me.mobjToolBarButtonSep3.ToolTipText = ""
            ' 
            ' mobjToolBarButtonBack
            ' 
            Me.mobjToolBarButtonBack.CustomStyle = ""
            Me.mobjToolBarButtonBack.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonBack.ImageKey = "Back.png"
            Me.mobjToolBarButtonBack.Name = "mobjToolBarButtonBack"
            Me.mobjToolBarButtonBack.Size = 24
            Me.mobjToolBarButtonBack.Text = "Back"
            Me.mobjToolBarButtonBack.ToolTipText = "Back"
            ' 
            ' mobjToolBarButtonNext
            ' 
            Me.mobjToolBarButtonNext.CustomStyle = ""
            Me.mobjToolBarButtonNext.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonNext.ImageKey = "Next.png"
            Me.mobjToolBarButtonNext.Name = "mobjToolBarButtonNext"
            Me.mobjToolBarButtonNext.Size = 24
            Me.mobjToolBarButtonNext.Text = "Next"
            Me.mobjToolBarButtonNext.ToolTipText = "Next"
            ' 
            ' mobjToolBarButtonHelp
            ' 
            Me.mobjToolBarButtonHelp.CustomStyle = ""
            Me.mobjToolBarButtonHelp.Font = New System.Drawing.Font("Tahoma", 8.25F)
            Me.mobjToolBarButtonHelp.ImageKey = "Help.png"
            Me.mobjToolBarButtonHelp.Name = "mobjToolBarButtonHelp"
            Me.mobjToolBarButtonHelp.Size = 24
            Me.mobjToolBarButtonHelp.Text = "Help"
            Me.mobjToolBarButtonHelp.ToolTipText = "Help"
            ' 
            ' mobjImageList
            ' 
            Me.mobjImageList.Images.AddRange(New Gizmox.WebGUI.Common.Resources.ResourceHandle() {New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images1")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images2")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images3")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images4")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images5")), _
             New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images6")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images7")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images8")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images9")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images10"))})
            Me.mobjImageList.ImageSize = New System.Drawing.Size(16, 16)
            Me.mobjImageList.Images.SetKeyName(0, "Add.png")
            Me.mobjImageList.Images.SetKeyName(1, "delete.png")
            Me.mobjImageList.Images.SetKeyName(2, "Folder.png")
            Me.mobjImageList.Images.SetKeyName(3, "Open.png")
            Me.mobjImageList.Images.SetKeyName(4, "save.png")
            Me.mobjImageList.Images.SetKeyName(5, "cut.png")
            Me.mobjImageList.Images.SetKeyName(6, "copy.png")
            Me.mobjImageList.Images.SetKeyName(7, "paste.png")
            Me.mobjImageList.Images.SetKeyName(8, "Back.png")
            Me.mobjImageList.Images.SetKeyName(9, "Next.png")
            Me.mobjImageList.Images.SetKeyName(10, "Help.png")
            ' 
            ' ToolBarImageListPage
            ' 
            Me.Controls.Add(Me.mobjToolBar)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "ToolBarImageListPage"
            Me.ResumeLayout(False)

        End Sub


        Private WithEvents mobjToolBar As Gizmox.WebGUI.Forms.ToolBar
        Private mobjToolBarButtonAdd As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonSave As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonCut As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonCopy As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonPaste As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonBack As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonNext As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonRemove As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonSep1 As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonNew As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonOpen As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonHelp As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonSep2 As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjToolBarButtonSep3 As Gizmox.WebGUI.Forms.ToolBarButton
        Private mobjImageList As Gizmox.WebGUI.Forms.ImageList


    End Class

End Namespace