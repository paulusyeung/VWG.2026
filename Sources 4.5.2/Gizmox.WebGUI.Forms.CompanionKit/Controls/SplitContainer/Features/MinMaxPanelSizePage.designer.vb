Namespace CompanionKit.Controls.SplitContainer.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MinMaxPanelSizePage
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
            Me.mobjGroupBoxWithSplitContainer = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjGroupBoxWithSplitContainer.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjSplitContainer1
            '
            Me.mobjSplitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer1.Name = "mobjSplitContainer1"
            '
            'mobjSplitContainer1.Panel1
            '
            Me.mobjSplitContainer1.Panel1.BackColor = System.Drawing.Color.Red
            Me.mobjSplitContainer1.Panel1MinSize = 100
            '
            'mobjSplitContainer1.Panel2
            '
            Me.mobjSplitContainer1.Panel2.Controls.Add(Me.mobjSplitContainer2)
            Me.mobjSplitContainer1.Panel2MinSize = 50
            Me.mobjSplitContainer1.Size = New System.Drawing.Size(381, 232)
            Me.mobjSplitContainer1.SplitterDistance = 127
            Me.mobjSplitContainer1.TabIndex = 0
            '
            'mobjSplitContainer2
            '
            Me.mobjSplitContainer2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer2.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer2.Name = "mobjSplitContainer2"
            Me.mobjSplitContainer2.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal
            '
            'mobjSplitContainer2.Panel1
            '
            Me.mobjSplitContainer2.Panel1.BackColor = System.Drawing.Color.Green
            Me.mobjSplitContainer2.Panel1MinSize = 50
            '
            'mobjSplitContainer2.Panel2
            '
            Me.mobjSplitContainer2.Panel2.BackColor = System.Drawing.Color.Yellow
            Me.mobjSplitContainer2.Panel2MinSize = 100
            Me.mobjSplitContainer2.Size = New System.Drawing.Size(250, 232)
            Me.mobjSplitContainer2.SplitterDistance = 85
            Me.mobjSplitContainer2.TabIndex = 0
            '
            'mobjGroupBoxWithSplitContainer
            '
            Me.mobjGroupBoxWithSplitContainer.Controls.Add(Me.mobjSplitContainer1)
            Me.mobjGroupBoxWithSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBoxWithSplitContainer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBoxWithSplitContainer.Location = New System.Drawing.Point(25, 25)
            Me.mobjGroupBoxWithSplitContainer.Name = "mobjGroupBoxWithSplitContainer"
            Me.mobjGroupBoxWithSplitContainer.Size = New System.Drawing.Size(381, 246)
            Me.mobjGroupBoxWithSplitContainer.TabIndex = 0
            Me.mobjGroupBoxWithSplitContainer.TabStop = False
            Me.mobjGroupBoxWithSplitContainer.Text = "SplitContainer with min/max panels"
            '
            'MinMaxPanelSizePage
            '
            Me.Controls.Add(Me.mobjGroupBoxWithSplitContainer)
            Me.DockPadding.All = 25
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.Size = New System.Drawing.Size(431, 296)
            Me.Text = "MinMaxPanelSizePage"
            Me.mobjGroupBoxWithSplitContainer.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjSplitContainer1 As Gizmox.WebGUI.Forms.SplitContainer
        Friend WithEvents mobjSplitContainer2 As Gizmox.WebGUI.Forms.SplitContainer
        Friend WithEvents mobjGroupBoxWithSplitContainer As Gizmox.WebGUI.Forms.GroupBox

	End Class

End Namespace
