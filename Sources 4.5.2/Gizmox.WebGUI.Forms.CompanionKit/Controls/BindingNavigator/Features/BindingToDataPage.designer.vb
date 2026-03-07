Namespace CompanionKit.Controls.BindingNavigator.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BindingToDataPage
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
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjBindingNavigator = New Gizmox.WebGUI.Forms.BindingNavigator(Me.components)
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
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
            ' mobjBindingNavigator
            ' 
            Me.mobjBindingNavigator.BindingSource = Me.mobjBindingSource
            Me.mobjBindingNavigator.DragHandle = True
            Me.mobjBindingNavigator.DropDownArrows = True
            Me.mobjBindingNavigator.ImageSize = New System.Drawing.Size(16, 16)
            Me.mobjBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.mobjBindingNavigator.MenuHandle = True
            Me.mobjBindingNavigator.Name = "mobjBindingNavigator"
            Me.mobjBindingNavigator.ShowToolTips = True
            Me.mobjBindingNavigator.Size = New System.Drawing.Size(500, 28)
            Me.mobjBindingNavigator.TabIndex = 0
            Me.mobjBindingNavigator.AddStandardItems()
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
            ' BindingToDataPage
            ' 
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(500, 200)
            Me.Text = "BindingToDataPage"
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private mobjBindingNavigator As Gizmox.WebGUI.Forms.BindingNavigator
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource

	End Class

End Namespace