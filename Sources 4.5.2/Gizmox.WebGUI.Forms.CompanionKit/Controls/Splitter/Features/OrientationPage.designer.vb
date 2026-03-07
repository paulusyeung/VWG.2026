Namespace CompanionKit.Controls.Splitter.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class OrientationPage
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
            Me.mobjPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSplitter1 = New Gizmox.WebGUI.Forms.Splitter()
            Me.mobjPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSplitter2 = New Gizmox.WebGUI.Forms.Splitter()
            Me.mobjPanel3 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjGroupBoxWithSplitter = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjGroupBoxWithSplitter.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjPanel1
            ' 
            Me.mobjPanel1.BackColor = System.Drawing.Color.Red
            Me.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.mobjPanel1.Location = New System.Drawing.Point(172, 17)
            Me.mobjPanel1.Name = "mobjPanel1"
            Me.mobjPanel1.Size = New System.Drawing.Size(200, 269)
            Me.mobjPanel1.TabIndex = 0
            ' 
            ' mobjSplitter1
            ' 
            Me.mobjSplitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.mobjSplitter1.Location = New System.Drawing.Point(169, 17)
            Me.mobjSplitter1.Name = "mobjSplitter1"
            Me.mobjSplitter1.Size = New System.Drawing.Size(3, 269)
            Me.mobjSplitter1.TabIndex = 1
            Me.mobjSplitter1.TabStop = False
            ' 
            ' mobjPanel2
            ' 
            Me.mobjPanel2.BackColor = System.Drawing.Color.Blue
            Me.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjPanel2.Location = New System.Drawing.Point(3, 186)
            Me.mobjPanel2.Name = "mobjPanel2"
            Me.mobjPanel2.Size = New System.Drawing.Size(166, 100)
            Me.mobjPanel2.TabIndex = 2
            ' 
            ' mobjSplitter2
            ' 
            Me.mobjSplitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSplitter2.Location = New System.Drawing.Point(3, 183)
            Me.mobjSplitter2.Name = "mobjSplitter2"
            Me.mobjSplitter2.Size = New System.Drawing.Size(166, 3)
            Me.mobjSplitter2.TabIndex = 3
            Me.mobjSplitter2.TabStop = False
            ' 
            ' mobjPanel3
            ' 
            Me.mobjPanel3.BackColor = System.Drawing.Color.Orange
            Me.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel3.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel3.Name = "mobjPanel3"
            Me.mobjPanel3.Size = New System.Drawing.Size(166, 166)
            Me.mobjPanel3.TabIndex = 4
            ' 
            ' mobjGroupBoxWithSplitter
            ' 
            Me.mobjGroupBoxWithSplitter.Controls.Add(Me.mobjPanel3)
            Me.mobjGroupBoxWithSplitter.Controls.Add(Me.mobjSplitter2)
            Me.mobjGroupBoxWithSplitter.Controls.Add(Me.mobjPanel2)
            Me.mobjGroupBoxWithSplitter.Controls.Add(Me.mobjSplitter1)
            Me.mobjGroupBoxWithSplitter.Controls.Add(Me.mobjPanel1)
            Me.mobjGroupBoxWithSplitter.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBoxWithSplitter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBoxWithSplitter.Location = New System.Drawing.Point(25, 25)
            Me.mobjGroupBoxWithSplitter.Name = "mobjGroupBoxWithSplitter"
            Me.mobjGroupBoxWithSplitter.Size = New System.Drawing.Size(375, 289)
            Me.mobjGroupBoxWithSplitter.TabIndex = 0
            Me.mobjGroupBoxWithSplitter.TabStop = False
            Me.mobjGroupBoxWithSplitter.Text = "GroupBox"
            ' 
            ' OrientationPage
            ' 
            Me.Controls.Add(Me.mobjGroupBoxWithSplitter)
            Me.DockPadding.All = 25
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(25)
            Me.Size = New System.Drawing.Size(425, 339)
            Me.Text = "OrientationPage"
            Me.mobjGroupBoxWithSplitter.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjPanel1 As Global.Gizmox.WebGUI.Forms.Panel
        Private mobjSplitter1 As Global.Gizmox.WebGUI.Forms.Splitter
        Private mobjPanel2 As Global.Gizmox.WebGUI.Forms.Panel
        Private mobjSplitter2 As Global.Gizmox.WebGUI.Forms.Splitter
        Private mobjPanel3 As Global.Gizmox.WebGUI.Forms.Panel
        Private mobjGroupBoxWithSplitter As Gizmox.WebGUI.Forms.GroupBox

	End Class

End Namespace
