Namespace CompanionKit.Controls.BindingNavigator.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CustomizingImagesPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(CustomizingImagesPage))
            Me.mobjBindingNavigator = New Gizmox.WebGUI.Forms.BindingNavigator(Me.components)
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjImageList = New Gizmox.WebGUI.Forms.ImageList(Me.components)
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            DirectCast(Me.mobjBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjBindingNavigator
            ' 
            Me.mobjBindingNavigator.BindingSource = Me.mobjBindingSource
            Me.mobjBindingNavigator.DragHandle = True
            Me.mobjBindingNavigator.DropDownArrows = True
            Me.mobjBindingNavigator.ImageList = Me.mobjImageList
            Me.mobjBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.mobjBindingNavigator.MenuHandle = True
            Me.mobjBindingNavigator.Name = "mobjBindingNavigator"
            Me.mobjBindingNavigator.ShowToolTips = True
            Me.mobjBindingNavigator.Size = New System.Drawing.Size(500, 28)
            Me.mobjBindingNavigator.TabIndex = 0
            Me.mobjBindingNavigator.AddStandardItems()
            ' 
            ' mobjImageList
            ' 
            Me.mobjImageList.Images.AddRange(New Gizmox.WebGUI.Common.Resources.ResourceHandle() {New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images1")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images2")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images3")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images4")), New Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("mobjImageList.Images5"))})
            Me.mobjImageList.ImageSize = New System.Drawing.Size(16, 16)
            Me.mobjImageList.Images.SetKeyName(0, "Back.gif")
            Me.mobjImageList.Images.SetKeyName(1, "Back.png")
            Me.mobjImageList.Images.SetKeyName(2, "Next.png")
            Me.mobjImageList.Images.SetKeyName(3, "Next.gif")
            Me.mobjImageList.Images.SetKeyName(4, "Add.png")
            Me.mobjImageList.Images.SetKeyName(5, "Remove.png")
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjListBox)
            Me.mobjPanel.Controls.Add(Me.mobjBindingNavigator)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(500, 200)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjListBox
            ' 
            Me.mobjListBox.DataSource = Me.mobjBindingSource
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Location = New System.Drawing.Point(0, 28)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(500, 160)
            Me.mobjListBox.TabIndex = 1
            ' 
            ' CustomizingImagesPage
            ' 
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(500, 200)
            Me.Text = "CustomizingImagesPage"
            DirectCast(Me.mobjBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjBindingNavigator As Gizmox.WebGUI.Forms.BindingNavigator
        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjImageList As Gizmox.WebGUI.Forms.ImageList
        Private mobjListBox As Gizmox.WebGUI.Forms.ListBox

	End Class

End Namespace