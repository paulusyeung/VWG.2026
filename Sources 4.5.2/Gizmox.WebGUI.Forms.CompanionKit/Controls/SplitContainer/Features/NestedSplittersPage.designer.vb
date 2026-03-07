Namespace CompanionKit.Controls.SplitContainer.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class NestedSplittersPage
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
            Me.mobjSplitContainer1 = New Gizmox.WebGUI.Forms.SplitContainer()
            Me.mobjSplitContainer2 = New Gizmox.WebGUI.Forms.SplitContainer()
            Me.mobjSplitContainer3 = New Gizmox.WebGUI.Forms.SplitContainer()
            Me.mobjSplitContainer4 = New Gizmox.WebGUI.Forms.SplitContainer()
            Me.mobjSplitContainer5 = New Gizmox.WebGUI.Forms.SplitContainer()
            Me.mobjGroupBoxWithSplitContainer = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjGroupBoxWithSplitContainer.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSplitContainer1
            ' 
            Me.mobjSplitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer1.Name = "mobjSplitContainer1"
            ' 
            ' mobjSplitContainer1.Panel1
            ' 
            Me.mobjSplitContainer1.Panel1.BackColor = System.Drawing.Color.Red
            ' 
            ' mobjSplitContainer1.Panel2
            ' 
            Me.mobjSplitContainer1.Panel2.Controls.Add(Me.mobjSplitContainer2)
            Me.mobjSplitContainer1.Size = New System.Drawing.Size(356, 203)
            Me.mobjSplitContainer1.SplitterDistance = 120
            Me.mobjSplitContainer1.TabIndex = 0
            ' 
            ' mobjSplitContainer2
            ' 
            Me.mobjSplitContainer2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer2.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer2.Name = "mobjSplitContainer2"
            Me.mobjSplitContainer2.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal
            ' 
            ' mobjSplitContainer2.Panel1
            ' 
            Me.mobjSplitContainer2.Panel1.BackColor = System.Drawing.Color.MediumBlue
            ' 
            ' mobjSplitContainer2.Panel2
            ' 
            Me.mobjSplitContainer2.Panel2.Controls.Add(Me.mobjSplitContainer3)
            Me.mobjSplitContainer2.Size = New System.Drawing.Size(232, 203)
            Me.mobjSplitContainer2.SplitterDistance = 55
            Me.mobjSplitContainer2.TabIndex = 0
            ' 
            ' mobjSplitContainer3
            ' 
            Me.mobjSplitContainer3.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer3.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer3.Name = "mobjSplitContainer3"
            ' 
            ' mobjSplitContainer3.Panel1
            ' 
            Me.mobjSplitContainer3.Panel1.Controls.Add(Me.mobjSplitContainer4)
            ' 
            ' mobjSplitContainer3.Panel2
            ' 
            Me.mobjSplitContainer3.Panel2.BackColor = System.Drawing.Color.Violet
            Me.mobjSplitContainer3.Size = New System.Drawing.Size(232, 144)
            Me.mobjSplitContainer3.SplitterDistance = 123
            Me.mobjSplitContainer3.TabIndex = 0
            ' 
            ' mobjSplitContainer4
            ' 
            Me.mobjSplitContainer4.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer4.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer4.Name = "mobjSplitContainer4"
            Me.mobjSplitContainer4.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal
            ' 
            ' mobjSplitContainer4.Panel1
            ' 
            Me.mobjSplitContainer4.Panel1.Controls.Add(Me.mobjSplitContainer5)
            ' 
            ' mobjSplitContainer4.Panel2
            ' 
            Me.mobjSplitContainer4.Panel2.BackColor = System.Drawing.Color.Green
            Me.mobjSplitContainer4.Size = New System.Drawing.Size(123, 144)
            Me.mobjSplitContainer4.SplitterDistance = 88
            Me.mobjSplitContainer4.TabIndex = 0
            ' 
            ' mobjSplitContainer5
            ' 
            Me.mobjSplitContainer5.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer5.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer5.Name = "mobjSplitContainer5"
            ' 
            ' mobjSplitContainer5.Panel1
            ' 
            Me.mobjSplitContainer5.Panel1.BackColor = System.Drawing.Color.Gold
            ' 
            ' mobjSplitContainer5.Panel2
            ' 
            Me.mobjSplitContainer5.Panel2.BackColor = System.Drawing.Color.Sienna
            Me.mobjSplitContainer5.Size = New System.Drawing.Size(123, 88)
            Me.mobjSplitContainer5.SplitterDistance = 52
            Me.mobjSplitContainer5.TabIndex = 0
            ' 
            ' mobjGroupBoxWithSplitContainer
            ' 
            Me.mobjGroupBoxWithSplitContainer.Controls.Add(Me.mobjSplitContainer1)
            Me.mobjGroupBoxWithSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBoxWithSplitContainer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBoxWithSplitContainer.Location = New System.Drawing.Point(25, 25)
            Me.mobjGroupBoxWithSplitContainer.Name = "mobjGroupBoxWithSplitContainer"
            Me.mobjGroupBoxWithSplitContainer.Size = New System.Drawing.Size(362, 223)
            Me.mobjGroupBoxWithSplitContainer.TabIndex = 0
            Me.mobjGroupBoxWithSplitContainer.TabStop = False
            Me.mobjGroupBoxWithSplitContainer.Text = "Nested SplitContainers"
            ' 
            ' NestedSplittersPage
            ' 
            Me.Controls.Add(Me.mobjGroupBoxWithSplitContainer)
            Me.DockPadding.All = 25
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.Size = New System.Drawing.Size(412, 273)
            Me.Text = "NestedSplittersPage"
            Me.mobjGroupBoxWithSplitContainer.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjSplitContainer1 As Gizmox.WebGUI.Forms.SplitContainer
        Private mobjSplitContainer2 As Gizmox.WebGUI.Forms.SplitContainer
        Private mobjSplitContainer3 As Gizmox.WebGUI.Forms.SplitContainer
        Private mobjSplitContainer4 As Gizmox.WebGUI.Forms.SplitContainer
        Private mobjSplitContainer5 As Gizmox.WebGUI.Forms.SplitContainer
        Private mobjGroupBoxWithSplitContainer As Gizmox.WebGUI.Forms.GroupBox

	End Class

End Namespace
