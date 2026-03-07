Namespace CompanionKit.Controls.Splitter.Features

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
			Me.mobjPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel3 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjGroupBoxwithSplitter = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjSplitter4 = New Gizmox.WebGUI.Forms.Splitter()
            Me.mobjPanel5 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSplitter2 = New Gizmox.WebGUI.Forms.Splitter()
            Me.mobjPanel4 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSplitter3 = New Gizmox.WebGUI.Forms.Splitter()
            Me.mobjSplitter1 = New Gizmox.WebGUI.Forms.Splitter()
            Me.mobjGroupBoxwithSplitter.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjPanel1
            ' 
            Me.mobjPanel1.BackColor = System.Drawing.Color.Yellow
            Me.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjPanel1.Location = New System.Drawing.Point(3, 17)
            Me.mobjPanel1.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjPanel1.MinimumSize = New System.Drawing.Size(50, 0)
            Me.mobjPanel1.Name = "mobjPanel1"
            Me.mobjPanel1.Size = New System.Drawing.Size(71, 220)
            Me.mobjPanel1.TabIndex = 1
            ' 
            ' mobjPanel2
            ' 
            Me.mobjPanel2.BackColor = System.Drawing.Color.Red
            Me.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPanel2.Location = New System.Drawing.Point(77, 17)
            Me.mobjPanel2.MaximumSize = New System.Drawing.Size(0, 150)
            Me.mobjPanel2.MinimumSize = New System.Drawing.Size(0, 50)
            Me.mobjPanel2.Name = "mobjPanel2"
            Me.mobjPanel2.Size = New System.Drawing.Size(328, 58)
            Me.mobjPanel2.TabIndex = 3
            ' 
            ' mobjPanel3
            ' 
            Me.mobjPanel3.BackColor = System.Drawing.Color.Green
            Me.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel3.Location = New System.Drawing.Point(77, 78)
            Me.mobjPanel3.Name = "mobjPanel3"
            Me.mobjPanel3.Size = New System.Drawing.Size(225, 87)
            Me.mobjPanel3.TabIndex = 5
            ' 
            ' mobjGroupBoxwithSplitter
            ' 
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjPanel3)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjSplitter4)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjPanel5)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjSplitter2)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjPanel4)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjSplitter3)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjPanel2)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjSplitter1)
            Me.mobjGroupBoxwithSplitter.Controls.Add(Me.mobjPanel1)
            Me.mobjGroupBoxwithSplitter.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBoxwithSplitter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBoxwithSplitter.Location = New System.Drawing.Point(25, 25)
            Me.mobjGroupBoxwithSplitter.Name = "mobjGroupBoxwithSplitter"
            Me.mobjGroupBoxwithSplitter.Size = New System.Drawing.Size(408, 240)
            Me.mobjGroupBoxwithSplitter.TabIndex = 0
            Me.mobjGroupBoxwithSplitter.TabStop = False
            Me.mobjGroupBoxwithSplitter.Text = "GroupBox with a Splitter"
            ' 
            ' mobjSplitter4
            ' 
            Me.mobjSplitter4.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSplitter4.Location = New System.Drawing.Point(77, 165)
            Me.mobjSplitter4.Name = "mobjSplitter4"
            Me.mobjSplitter4.Size = New System.Drawing.Size(225, 3)
            Me.mobjSplitter4.TabIndex = 11
            Me.mobjSplitter4.TabStop = False
            ' 
            ' mobjPanel5
            ' 
            Me.mobjPanel5.BackColor = System.Drawing.Color.Blue
            Me.mobjPanel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjPanel5.Location = New System.Drawing.Point(77, 168)
            Me.mobjPanel5.MaximumSize = New System.Drawing.Size(0, 150)
            Me.mobjPanel5.MinimumSize = New System.Drawing.Size(0, 50)
            Me.mobjPanel5.Name = "mobjPanel5"
            Me.mobjPanel5.Size = New System.Drawing.Size(225, 69)
            Me.mobjPanel5.TabIndex = 10
            ' 
            ' mobjSplitter2
            ' 
            Me.mobjSplitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.mobjSplitter2.Location = New System.Drawing.Point(302, 78)
            Me.mobjSplitter2.Name = "mobjSplitter2"
            Me.mobjSplitter2.Size = New System.Drawing.Size(3, 159)
            Me.mobjSplitter2.TabIndex = 9
            Me.mobjSplitter2.TabStop = False
            ' 
            ' mobjPanel4
            ' 
            Me.mobjPanel4.BackColor = System.Drawing.Color.Orange
            Me.mobjPanel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Right
            Me.mobjPanel4.Location = New System.Drawing.Point(305, 78)
            Me.mobjPanel4.MaximumSize = New System.Drawing.Size(150, 0)
            Me.mobjPanel4.MinimumSize = New System.Drawing.Size(50, 0)
            Me.mobjPanel4.Name = "mobjPanel4"
            Me.mobjPanel4.Size = New System.Drawing.Size(100, 159)
            Me.mobjPanel4.TabIndex = 8
            ' 
            ' mobjSplitter3
            ' 
            Me.mobjSplitter3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSplitter3.Location = New System.Drawing.Point(77, 75)
            Me.mobjSplitter3.Name = "mobjSplitter3"
            Me.mobjSplitter3.Size = New System.Drawing.Size(328, 3)
            Me.mobjSplitter3.TabIndex = 7
            Me.mobjSplitter3.TabStop = False
            ' 
            ' mobjSplitter1
            ' 
            Me.mobjSplitter1.Location = New System.Drawing.Point(74, 17)
            Me.mobjSplitter1.Name = "mobjSplitter1"
            Me.mobjSplitter1.Size = New System.Drawing.Size(3, 220)
            Me.mobjSplitter1.TabIndex = 6
            Me.mobjSplitter1.TabStop = False
            ' 
            ' MinMaxPanelSizePage
            ' 
            Me.Controls.Add(Me.mobjGroupBoxwithSplitter)
            Me.DockPadding.All = 25
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(25)
            Me.Size = New System.Drawing.Size(458, 290)
            Me.Text = "MinMaxPanelSizePage"
            Me.mobjGroupBoxwithSplitter.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjPanel1 As Global.Gizmox.WebGUI.Forms.Panel
        Private mobjPanel2 As Global.Gizmox.WebGUI.Forms.Panel
        Private mobjPanel3 As Global.Gizmox.WebGUI.Forms.Panel
        Private mobjGroupBoxwithSplitter As Gizmox.WebGUI.Forms.GroupBox
        Private mobjSplitter1 As Gizmox.WebGUI.Forms.Splitter
        Private mobjSplitter3 As Gizmox.WebGUI.Forms.Splitter
        Private mobjSplitter4 As Gizmox.WebGUI.Forms.Splitter
        Private mobjPanel5 As Gizmox.WebGUI.Forms.Panel
        Private mobjSplitter2 As Gizmox.WebGUI.Forms.Splitter
        Private mobjPanel4 As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
