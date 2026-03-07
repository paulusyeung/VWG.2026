Namespace CompanionKit.Controls.GroupBox.Programming

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
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjButtonClickedLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjButtonClickedLabel)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(102, 21)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(478, 98)
            Me.mobjGroupBox.TabIndex = 0
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "GroupBox"
            ' 
            ' mobjButtonClickedLabel
            ' 
            Me.mobjButtonClickedLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonClickedLabel.AutoSize = True
            Me.mobjButtonClickedLabel.Location = New System.Drawing.Point(206, 47)
            Me.mobjButtonClickedLabel.Name = "mobjButtonClickedLabel"
            Me.mobjButtonClickedLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjButtonClickedLabel.TabIndex = 0
            Me.mobjButtonClickedLabel.Text = "Right clicked"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjLabel, 3)
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 119)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(683, 60)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Click inside the boundaries of group box"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGroupBox, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel, 0, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(683, 200)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' MouseClickedPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(683, 200)
            Me.Text = "MouseClickedPage"
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjGroupBox As Global.Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjButtonClickedLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace
