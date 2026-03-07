Namespace CompanionKit.Controls.SplitContainer.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MouseClickedPage
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
            Me.mobjSplitContainer = New Gizmox.WebGUI.Forms.SplitContainer()
            Me.mobjGroupBoxWithSplitContainer = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjGroupBoxWithSplitContainer.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjSplitContainer1
            ' 
            Me.mobjSplitContainer.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSplitContainer.Location = New System.Drawing.Point(0, 0)
            Me.mobjSplitContainer.Name = "mobjSplitContainer1"
            ' 
            ' mobjSplitContainer1.Panel1
            ' 
            Me.mobjSplitContainer.Panel1.BackColor = System.Drawing.Color.Yellow
            ' 
            ' mobjSplitContainer1.Panel2
            ' 
            Me.mobjSplitContainer.Panel2.BackColor = System.Drawing.Color.Red
            Me.mobjSplitContainer.Size = New System.Drawing.Size(409, 199)
            Me.mobjSplitContainer.SplitterDistance = 136
            Me.mobjSplitContainer.TabIndex = 0
            ' 
            ' mobjGroupBoxWithSplitContainer
            ' 
            Me.mobjGroupBoxWithSplitContainer.Controls.Add(Me.mobjSplitContainer)
            Me.mobjGroupBoxWithSplitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBoxWithSplitContainer.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBoxWithSplitContainer.Location = New System.Drawing.Point(25, 25)
            Me.mobjGroupBoxWithSplitContainer.Name = "mobjGroupBoxWithSplitContainer"
            Me.mobjGroupBoxWithSplitContainer.Size = New System.Drawing.Size(415, 219)
            Me.mobjGroupBoxWithSplitContainer.TabIndex = 0
            Me.mobjGroupBoxWithSplitContainer.TabStop = False
            Me.mobjGroupBoxWithSplitContainer.Text = "SplitContainers with Click event "
            ' 
            ' MouseClickedPage
            ' 
            Me.Controls.Add(Me.mobjGroupBoxWithSplitContainer)
            Me.DockPadding.All = 25
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.Size = New System.Drawing.Size(465, 269)
            Me.Text = "MouseClickedPage"
            Me.mobjGroupBoxWithSplitContainer.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjSplitContainer As Global.Gizmox.WebGUI.Forms.SplitContainer
        Private mobjGroupBoxWithSplitContainer As Gizmox.WebGUI.Forms.GroupBox

	End Class

End Namespace
